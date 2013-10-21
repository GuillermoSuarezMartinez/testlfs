using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo entradas salidas Siemens1200.
    /// </summary>
    public class ODispositivoSiemens1200ES : ODispositivoES
    {
        #region Atributos
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        protected Queue ColaMensajesEntradaSalida;
        /// <summary>
        /// Evento reset de recepción de tramas KeepAlive.
        /// Entrada/Salida.
        /// </summary>
        protected OResetManual Reset;  // 0-KeepAlive; 1-Lecturas.
        /// <summary>
        /// Colección para la búsqueda de lecturas. La clave es la dupla "dirección-bit".
        /// </summary>
        protected OHashtable AlmacenLecturas;
        /// <summary>
        /// Colección para la búsqueda de escrituras. La clave es la dupla "dirección-bit".
        /// </summary>
        protected OHashtable AlmacenEscrituras;
        /// <summary>
        /// Número de lecturas a realizar.
        /// </summary>
        protected int NumeroLecturas;
        /// <summary>
        /// Número de bytes de entradas.
        /// </summary>
        protected int NumeroBytesEntradas;
        /// <summary>
        /// Número de bytes de salidas.
        /// </summary>
        protected int NumeroBytesSalidas;
        /// <summary>
        /// Valor de las lecturas.
        /// </summary>
        protected byte[] BytesLecturas;
        /// <summary>
        /// Valor inicial del registro de lecturas.
        /// </summary>
        protected int RegistroInicialEntradas;
        /// <summary>
        /// Valor inicial del registro de escrituras.
        /// </summary>
        protected int RegistroInicialSalidas;
        /// <summary>
        /// Protocolo comunicación usado para el hilo vida.
        /// </summary>
        protected OProtocoloTCPSiemens ProtocoloHiloVida;
        /// <summary>
        /// Protocolo comunicación usado para la escritura.
        /// </summary>
        protected OProtocoloTCPSiemens ProtocoloEscritura;
        /// <summary>
        /// Protocolo comunicación usado para el proceso del mensaje.
        /// </summary>
        protected OProtocoloTCPSiemens ProtocoloProcesoMensaje;
        /// <summary>
        /// Protocolo de comunicación usado para el proceso del hilo.
        /// </summary>
        protected OProtocoloTCPSiemens ProtocoloProcesoHilo;
        /// <summary>
        /// Fecha del último wrapper de error.
        /// </summary>
        private DateTime _fechaErrorWrapperWinsock = DateTime.MaxValue;
        /// <summary>
        /// Identificador del mensaje a enviar para la escritura.
        /// </summary>
        private byte _idMensaje = 1;
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _colaEscrituras;
        /// <summary>
        /// Lectura inicial de salida.
        /// </summary>
        internal int LecturaInicialSalida;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoSiemens1200ES.
        /// </summary>
        /// <param name="tags">Colección de tags.</param>
        /// <param name="hilos">Colección de hilos.</param>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public ODispositivoSiemens1200ES(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo)
        {
            Inicializar();

            Wrapper.Info("ODispositivoSiemens1200ES constructor de objetos del dispositivo de ES Siemens creados.");

            // Inicio de los parámetros TCP.
            try
            {
                CrearParametrosConexionTcp();
                Hilos.Add(ProcesarHilo, true);
                Wrapper.Info("ODispositivoSiemens1200ES constructor de comunicaciones Tcp del dispositivo de ES Siemens arrancadas correctamente.");
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [ODispositivoSiemens1200ES]: " + ex);
            }
        }
        #endregion Constructor

        #region Propiedades
        /// <summary>
        /// Identificador del mensaje.
        /// </summary>
        protected byte IdMensaje
        {
            get { return _idMensaje; }
            set
            {
                if (_idMensaje > 255)
                {
                    _idMensaje = 1;
                }
                else
                {
                    _idMensaje++;
                }
            }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Procesar las lecturas del dispositivo.
        /// </summary>
        public override void ProcesarHiloVida()
        {
            var estadoComm = new OEstadoComms
                {
                    Nombre = Nombre,
                    Id = Identificador,
                    Enlace = Tags.HtVida.Enlaces[0]
                };
            bool responde = true;
            DateTime fechaErrorWrapper = DateTime.MaxValue;

            int reintento = 0;
            const int maxReintentos = 3;

            bool modoKeepAlive = true;
            bool ini = true;

            while (true)
            {
                // Conectar.
                if (Winsock.State != WinsockStates.Connected)
                {
                    try
                    {
                        Conectar();
                        int reConexionSg = Convert.ToInt32(ReConexionSg * 1000);
                        Thread.Sleep(reConexionSg);
                        estadoComm.Estado = "NOK";
                    }
                    catch (Exception ex)
                    {
                        if (fechaErrorWrapper == DateTime.MaxValue)
                        {
                            Wrapper.Error("ODispositivoSiemens1200ES [ProcesarHiloVida_fechaErrorWrapper == DateTime.MaxValue]: ", ex);
                            fechaErrorWrapper = DateTime.Now;
                        }
                        else
                        {
                            TimeSpan t = DateTime.Now.Subtract(fechaErrorWrapper);
                            if (t.TotalSeconds > LogErrorComunicacionSg)
                            {
                                Wrapper.Error("ODispositivoSiemens1200ES [ProcesarHiloVida_(t.TotalSeconds > this.LogErrorComunicacionSg]: ", ex);
                                fechaErrorWrapper = DateTime.Now;
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        using (ProtocoloHiloVida)
                        {
                            if (modoKeepAlive && !ini) // Escrituras.
                            {
                                modoKeepAlive = false;
                                lock (_colaEscrituras.SyncRoot)
                                {
                                    if (_colaEscrituras.Count > 0)
                                    {
                                        var de = ((DispositivoEscrituras)_colaEscrituras.Dequeue());
                                        if (Wrapper.NivelLog <= NivelLog.Debug)
                                        {
                                            string traza = "";
                                            for (int i = 0; i < de.Variables.Length; i++)
                                            {
                                                traza = traza + " #Variable=" + de.Variables[i] + "=" + de.Valores[i];
                                            }
                                            Wrapper.Info("ODispositivoSiemens1200ES [ProcesarHiloVida] Escritura de " + traza);
                                        }
                                        var salidas = ProtocoloEscritura.SalidasEnviar(ProcesarEscritura(de.Variables, de.Valores), _idMensaje);
                                        if (salidas == null)
                                        {
                                            Wrapper.Warn("ODispositivoSiemens1200ES [ProcesarHiloVida] Protocolo de solo lectura.");
                                            return;
                                        }
                                        Enviar(salidas);
                                    }
                                }
                            }
                            else // KeepAlive.
                            {
                                ini = false;
                                modoKeepAlive = true;

                                Enviar(ProtocoloHiloVida.KeepAliveEnviar());

                                // Letargo del hilo hasta t-tiempo, o bien, hasta recibir respuesta, el cual 
                                // realiza el Set sobre el eventReset del evento 'wsk_DataArrival'.
                                if (!Reset.Dormir(0, TimeSpan.FromSeconds(ConfigDispositivo.TiempoVida)))
                                {
                                    responde = false;
                                    modoKeepAlive = false;
                                    if (reintento < maxReintentos)
                                    {
                                        reintento++;
                                    }
                                    else
                                    {
                                        estadoComm.Estado = "NOK";
                                    }
                                    Wrapper.Warn("ODispositivoSiemens1200ES [ProcesarHiloVida] Timeout en el KeepAlive.");
                                }

                                // Resetear el evento.
                                Reset.Resetear(0);
                                if (responde)
                                {
                                    estadoComm.Estado = "OK";
                                    reintento = 0;
                                }
                                else
                                {
                                    responde = true;
                                }
                            }
                            Thread.Sleep(10);
                        }
                    }
                    catch (Exception ex)
                    {
                        estadoComm.Estado = "NOK";
                        Wrapper.Error("ODispositivoSiemens1200ES [ProcesarHiloVida_estado.Estado = NOK]: ", ex);
                    }
                }
                try
                {
                    TimeSpan ts = DateTime.Now.Subtract(FechaUltimoEventoComm);
                    if (!(ts.TotalSeconds > (double)ConfigDispositivo.SegEventoComs)) continue;
                    Eventargs.Argumento = estadoComm;
                    OnComm(Eventargs);
                    FechaUltimoEventoComm = DateTime.Now;
                }
                catch (Exception ex)
                {
                    Wrapper.Error("ODispositivoSiemens1200ES [ProcesarHiloVida_ts.TotalSeconds > (double)this.ConfigDispositivo.SegEventoComs]: ", ex);
                }
            }
        }
        /// <summary>
        /// Leer el valor de las descripciones de variables de la colección
        /// a partir del valor de la colección de datos DB actualiza  en el
        /// proceso del hilo vida.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se ejecuta sobre el dispositivo.</param>
        /// <returns>Colección de resultados.</returns>
        public override object[] Leer(string[] variables, bool demanda)
        {
            object[] resultado = null;
            try
            {
                if (variables != null)
                {
                    // Inicializar contador de variables.
                    int longitud = variables.Length;

                    // Asignar a la colección resultado el número de variables de la colección de variables.
                    resultado = new object[longitud];
                    for (int i = 0; i < longitud; i++)
                    {
                        resultado[i] = Tags.GetDB(variables[i]).Valor;
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoSiemens1200ES [Leer]: ", ex);
                throw;
            }
            return resultado;
        }
        /// <summary>
        /// Escribir el valor de los identificadores de variables de la colección.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns></returns>
        public override bool Escribir(string[] variables, object[] valores)
        {
            lock (_colaEscrituras.SyncRoot)
            {
                _colaEscrituras.Enqueue(new DispositivoEscrituras(variables, valores));
            }
            return true;
        }
        #endregion Métodos públicos

        #region Métodos protegidos
        /// <summary>
        /// Establecer el valor inicial de los objetos.
        /// </summary>
        protected virtual void Inicializar()
        {
            // Cola de envío/recepción de tramas.
            ColaMensajesEntradaSalida = new Queue();
            _colaEscrituras = new Queue();

            // Evento reset de envío/recepción de tramas KeepAlive y Entrada/Salida.
            Reset = new OResetManual(2);

            // Inicializar datos.
            var entradas = new ArrayList();
            var salidas = new ArrayList();

            AlmacenLecturas = new OHashtable();
            AlmacenEscrituras = new OHashtable();

            foreach (OInfoDato infodato in from DictionaryEntry item in Tags.GetDatos() select (OInfoDato)item.Value)
            {
                infodato.Valor = 0;
                string key = string.Format("{0}-{1}", infodato.Direccion, infodato.Bit);
                if (infodato.EsEntrada)
                {
                    AlmacenLecturas.Add(key, infodato);
                    if (!entradas.Contains(infodato.Direccion))
                    {
                        entradas.Add(infodato.Direccion);
                    }
                }
                else
                {
                    AlmacenEscrituras.Add(key, infodato);
                    if (!salidas.Contains(infodato.Direccion))
                    {
                        salidas.Add(infodato.Direccion);
                    }
                }
            }
        }
        /// <summary>
        /// Procesar los mensajes recibidos en el evento del socket DataArrival.
        /// </summary>
        /// <param name="mensaje"></param>
        protected virtual void ProcesarMensajeRecibido(byte[] mensaje) { }
        /// <summary>
        /// Hilo de proceso de E/S.
        /// </summary>
        protected virtual void ProcesarHilo() { }
        /// <summary>
        /// Método que encola tramas de bytes en la colección de recepción.
        /// </summary>
        /// <param name="trama">Trama de bytes.</param>
        protected void Encolar(byte[] trama)
        {
            // Bloquear la cola sincronizada.
            lock (ColaMensajesEntradaSalida.SyncRoot)
            {
                // Encolar la trama de ES recibida.
                ColaMensajesEntradaSalida.Enqueue(trama);

                // Despertar el hilo 'ESProcesarHilo' aletargado en la línea: 'this._eReset.Dormir(1)'
                Reset.Despertar(1);
            }
        }
        /// <summary>
        /// Método que desencola tramas de bytes de la colección de recepción.
        /// </summary>
        /// <returns></returns>
        protected byte[] Desencolar()
        {
            // Bloquear la cola sincronizada.
            lock (ColaMensajesEntradaSalida.SyncRoot)
            {
                byte[] mensaje = null;
                if (ColaMensajesEntradaSalida.Count > 0)
                {
                    // Desencolar el objeto Trama encolado en wsk_DataArrival.
                    mensaje = ((byte[])ColaMensajesEntradaSalida.Dequeue());
                }
                else
                {
                    Reset.Resetear(1);
                }
                return mensaje;
            }
        }
        #endregion Métodos protegidos

        #region Métodos privados
        /// <summary>
        /// Crear conexión Winsock y suscribirse a los eventos del socket.
        /// </summary>
        private void CrearParametrosConexionTcp()
        {
            try
            {
                Winsock = new OWinsockBase { LegacySupport = true };
                Winsock.DataArrival += Winsock_DataArrival;
                Winsock.StateChanged += Winsock_StateChanged;
                Winsock.SendComplete += Winsock_SendComplete;
                Winsock.ErrorReceived += Winsock_ErrorReceived;
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoSiemens1200ES [CrearParametrosConexionTcp]: " + ex);
                throw;
            }
        }
        /// <summary>
        /// Conectar con el dispositivo TCP.
        /// </summary>
        private void Conectar()
        {
            Winsock.Connect(Direccion.ToString(), Puerto);
        }
        /// <summary>
        /// Enviar datos al dispositivo.
        /// </summary>
        /// <param name="data">Objeto de tipo datos.</param>
        private void Enviar(Object data)
        {
            Winsock.Send(data);
        }
        /// <summary>
        /// Calcular el valor de las salidas para enviar al dispositivo.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns></returns>
        private byte[] ProcesarEscritura(string[] variables, IList<object> valores)
        {
            var salidas = new byte[NumeroBytesSalidas];
            var salidaLocal = new byte[NumeroBytesSalidas];

            for (int i = 0; i < NumeroBytesSalidas; i++)
            {
                salidaLocal[i] = BytesLecturas[LecturaInicialSalida + i];
            }
            for (int i = 0; i < variables.Length; i++)
            {
                OInfoDato infodato = Tags.GetDB(variables[i]);
                if (infodato.EsEntrada) continue;
                salidas[infodato.Direccion - RegistroInicialSalidas] = ProcesarByte(salidaLocal[infodato.Direccion - RegistroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                //salidaLocal[infodato.Direccion - RegistroInicialSalidas] = salidas[infodato.Direccion - RegistroInicialSalidas];
            }
            return salidas;
        }
        /// <summary>
        /// Procesar los bits poniendo a 1 o 0 el bit correspondiente.
        /// </summary>
        /// <param name="valor">Valor a procesar.</param>
        /// <param name="bit">Número de bit.</param>
        /// <param name="valorBit">Valor del bit.</param>
        /// <returns></returns>
        private static byte ProcesarByte(byte valor, int bit, int valorBit)
        {
            byte resultado = valorBit == 1
                           ? (byte)((valor) | (byte)(Math.Pow(2, bit)))
                           : (byte)(valor & ~(byte)(Math.Pow(2, bit)));
            return resultado;
        }
        #endregion Métodos privados

        #region Manejadores de eventos socket
        /// <summary>
        /// Evento de recepción de datos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">WinsockDataArrivalEventArgs que contiene los datos del evento.</param>
        private void Winsock_DataArrival(object sender, WinsockDataArrivalEventArgs e)
        {
            try
            {
                // El método Get de winsock solo devuelve datos de tipo objeto.
                var datos = Winsock.Get<object>();

                string resultado = "";
                var bytesRecibidos = (byte[])datos;

                ProcesarMensajeRecibido(bytesRecibidos);

                if (bytesRecibidos != null)
                {
                    resultado = bytesRecibidos.Aggregate(resultado, (current, t) => current + ("[" + t + "]"));
                }
                Wrapper.Debug("ODispositivoSiemens1200ES [Winsock_DataArrival]: " + resultado);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [Winsock_DataArrival]: " + ex);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha enviado toda la información
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">WinsockSendEventArgs que contiene los datos del evento.</param>
        private static void Winsock_SendComplete(object sender, WinsockSendEventArgs e)
        {
            // Verificar la llegada.
            try
            {
                string enviado = "";
                if (e.DataSent != null)
                {
                    enviado = e.DataSent.Aggregate(enviado, (current, t) => current + ("[" + t + "]"));
                }
                Wrapper.Debug("ODispositivoSiemens1200ES [Winsock_SendComplete]: " + enviado);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [Winsock_SendComplete]: " + ex);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha cambiado de estado. Trazabilidad del canal.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">WinsockStateChangedEventArgs que contiene los datos del evento.</param>
        private static void Winsock_StateChanged(object sender, WinsockStateChangedEventArgs e)
        {
            try
            {
                Wrapper.Debug("ODispositivoSiemens1200ES [Winsock_StateChanged]. Cambia de " + e.Old_State + " a " + e.New_State + ".");
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [Winsock_StateChanged]: " + ex);
            }
        }
        /// <summary>
        /// Evento de errores en la comunicación TCP.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">WinsockErrorReceivedEventArgs que contiene los datos del evento.</param>
        private void Winsock_ErrorReceived(object sender, WinsockErrorReceivedEventArgs e)
        {
            try
            {
                string error = "ODispositivoSiemens1200ES [Winsock_ErrorReceived]: " + e.Message;
                if (_fechaErrorWrapperWinsock == DateTime.MaxValue)
                {
                    Wrapper.Error(error);
                    _fechaErrorWrapperWinsock = DateTime.Now;
                }
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(_fechaErrorWrapperWinsock);
                    if (ts.TotalSeconds > LogErrorComunicacionSg)
                    {
                        Wrapper.Error(error);
                        _fechaErrorWrapperWinsock = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [Winsock_ErrorReceived]: " + ex);
            }
        }
        #endregion Manejadores de eventos socket
    }
}