using System;
using System.Collections;
using System.Linq;
using System.Threading;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo entradas salidas Siemens1200
    /// </summary>
    public class ODispositivoSiemens1200ES : ODispositivoES
    {
        #region Atributos
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        protected Queue QEntradaSalida;
        /// <summary>
        /// Evento reset de recepción de tramas KeepAlive.
        /// Entrada/Salida.
        /// </summary>
        protected OResetManual Reset;  // 0-KeepAlive; 1-lecturas.
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
        protected int NumLecturas;
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
        protected byte[] _lecturas;
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
        /// Fecha del ultimo wrapper de error.
        /// </summary>
        private DateTime _fechaErrorWrapperWinsock = DateTime.MaxValue;
        /// <summary>
        /// Identificador del mensaje a enviar para la escritura.
        /// </summary>
        private byte _idMensaje = 1;
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _qEscrituras;
        internal int LecturaInicialSalida;
        #endregion

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
            // Inicialización de objetos
            this.IniciarObjetos();

            Wrapper.Info("ODispositivoSiemens1200ES constructor de objetos del dispositivo de ES Siemens creados.");
            // Inicio de los parámetros TCP
            try
            {
                this.CrearParametrosConexionTcp();
                Hilos.Add(EsProcesarHilo, true);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [ODispositivoSiemens1200ES]: " + ex);
            }
            Wrapper.Info("ODispositivoSiemens1200ES constructor de comunicaciones Tcp del dispositivo de ES Siemens arrancadas correctamente.");
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento de cambio de dato entradas
        /// </summary>
        public event OManejadorEventoComm OrbitaCambioDatoEntradas;
        /// <summary>
        /// Evento de cambio de dato salidas
        /// </summary>
        public event OManejadorEventoComm OrbitaCambioDatoSalidas;
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Procesa las lecturas del dispositivo.
        /// </summary>
        public override void ProcesarHiloVida()
        {
            var estado = new OEstadoComms
                {
                    Nombre = this.Nombre,
                    Id = this.Identificador,
                    Enlace = this.Tags.HtVida.Enlaces[0]
                };
            Boolean responde = true;
            DateTime fechaErrorWrapper = DateTime.MaxValue;

            int reintento = 0;
            const int maxReintentos = 3;

            bool modoKeepAlive = true;
            bool ini = true;

            while (true)
            {
                // Conectar.
                if (this.Winsock.State != WinsockStates.Connected)
                {
                    try
                    {
                        this.Conectar();
                        int reConexionSg = Convert.ToInt32(this.ReConexionSg * 1000);
                        Thread.Sleep(reConexionSg);
                        estado.Estado = "NOK";
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
                            if (t.TotalSeconds > this.LogErrorComunicacionSg)
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
                            // Escrituras.
                            if (modoKeepAlive && !ini)
                            {
                                modoKeepAlive = false;
                                lock (this._qEscrituras.SyncRoot)
                                {
                                    if (this._qEscrituras.Count > 0)
                                    {
                                        var de = ((DispositivoEscrituras)this._qEscrituras.Dequeue());
                                        string traza = "";
                                        for (int i = 0; i < de.Variables.Length; i++)
                                        {
                                            traza = traza + " #Variable: " + de.Variables[i] + " Valor: " + de.Valores[i];
                                        }
                                        Wrapper.Info("ODispositivoSiemens1200ES [ProcesarHiloVida] Escritura de " + traza);
                                        var salidas = ProtocoloEscritura.SalidasEnviar(this.ProcesarEscritura(de.Variables, de.Valores), this._idMensaje);
                                        if (salidas == null)
                                        {
                                            Wrapper.Warn("ODispositivoSiemens1200ES [ProcesarHiloVida] Protocolo de solo lectura.");
                                            return;
                                        }
                                        this.Enviar(salidas);
                                    }
                                }
                            }
                            else // KeepAlive.
                            {
                                ini = false;
                                modoKeepAlive = true;

                                this.Enviar(ProtocoloHiloVida.KeepAliveEnviar());

                                // Letargo del hilo hasta t-tiempo, o bien, hasta recibir respuesta, el cual realiza el Set sobre
                                // el eventReset del evento 'wsk_DataArrival'.
                                if (!this.Reset.Dormir(0, TimeSpan.FromSeconds(this.ConfigDispositivo.TiempoVida)))
                                {
                                    responde = false;
                                    modoKeepAlive = false;
                                    if (reintento < maxReintentos)
                                    {
                                        reintento++;
                                    }
                                    else
                                    {
                                        estado.Estado = "NOK";
                                    }
                                    // Trazar recepción errónea.
                                    Wrapper.Warn("ODispositivoSiemens1200ES [ProcesarHiloVida] Timeout en el KeepAlive.");
                                }

                                // Resetear el evento.
                                this.Reset.Resetear(0);

                                if (responde)
                                {
                                    estado.Estado = "OK";
                                    reintento = 0;
                                    //  Thread.Sleep(this._config.TiempoVida);
                                }
                                else
                                {
                                    responde = true;
                                    // Establecer un micro tiempo de letargo, necesario en este tipo de hilos.
                                    // Realizar un envio inmediato tras la no respuesta anterior.
                                }
                            }
                            Thread.Sleep(1);
                        }
                    }
                    catch (Exception ex)
                    {
                        estado.Estado = "NOK";
                        Wrapper.Error("ODispositivoSiemens1200ES [ProcesarHiloVida_estado.Estado = NOK]: ", ex);
                    }
                }
                try
                {
                    TimeSpan ts = DateTime.Now.Subtract(this.FechaUltimoEventoComm);
                    if (!(ts.TotalSeconds > (double)this.ConfigDispositivo.SegEventoComs)) continue;
                    this.Eventargs.Argumento = estado;
                    this.OnComm(this.Eventargs);
                    this.FechaUltimoEventoComm = DateTime.Now;
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
        /// <param name="demanda">Indica si la lectura se ejecuta sobre el dispositivo</param>
        /// <returns>Colección de resultados.</returns>
        public override object[] Leer(string[] variables, bool demanda)
        {
            object[] resultado = null;
            try
            {
                if (variables != null)
                {
                    // Inicializar contador de variables.
                    int contador = variables.Length;
                    // Asignar a la colección resultado el número de variables de la colección de variables.
                    resultado = new object[contador];
                    for (int i = 0; i < contador; i++)
                    {
                        resultado[i] = this.Tags.GetDB(variables[i]).Valor;
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
            lock (this._qEscrituras.SyncRoot)
            {
                this._qEscrituras.Enqueue(new DispositivoEscrituras(variables, valores));
            }
            return true;
        }
        /// <summary>
        /// Cambio de dato de las entradas
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCambioDatoEntradas(OEventArgs e)
        {
            // Hacer una copia temporal del evento para evitar una condición
            // de carrera, si el último suscriptor desuscribe inmediatamente
            // después de la comprobación nula y antes de que el  evento  se
            // produce.
            OManejadorEventoComm handler = OrbitaCambioDatoEntradas;
            if (handler != null)
            {
                handler(e);
            }
        }
        /// <summary>
        /// Cambio de dato de las salidas
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCambioDatoSalidas(OEventArgs e)
        {
            // Hacer una copia temporal del evento para evitar una condición
            // de carrera, si el último suscriptor desuscribe inmediatamente
            // después de la comprobación nula y antes de que el  evento  se
            // produce.
            OManejadorEventoComm handler = OrbitaCambioDatoSalidas;
            if (handler != null)
            {
                handler(e);
            }
        }
        #endregion

        #region Métodos privados

        #region Comunes
        /// <summary>
        /// Publica los eventos de socket
        /// </summary>
        private void CrearParametrosConexionTcp()
        {
            try
            {
                this.Winsock = new OWinsockBase { LegacySupport = true };
                this.Winsock.DataArrival += Winsock_DataArrival;
                this.Winsock.StateChanged += Winsock_StateChanged;
                this.Winsock.SendComplete += Winsock_SendComplete;
                this.Winsock.ErrorReceived += Winsock_ErrorReceived;
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoSiemens1200ES [CrearParametrosConexionTcp]: " + ex);
                throw;
            }
        }
        /// <summary>
        /// Conecta con el dispositivo TCP
        /// </summary>
        private void Conectar()
        {
            this.Winsock.Connect(this.Direccion.ToString(), this.Puerto);
        }
        /// <summary>
        /// Establece el valor inicial de los objetos
        /// </summary>
        protected virtual void IniciarObjetos()
        {
            // Cola de envío/recepción de tramas.
            this.QEntradaSalida = new Queue();
            this._qEscrituras = new Queue();

            // Evento reset de envío/recepción de tramas KeepAlive y Entrada/Salida.
            this.Reset = new OResetManual(2);

            // Inicializar datos.
            var entradas = new ArrayList();
            var salidas = new ArrayList();

            this.AlmacenLecturas = new OHashtable();
            this.AlmacenEscrituras = new OHashtable();

            foreach (OInfoDato infodato in from DictionaryEntry item in this.Tags.GetDatos() select (OInfoDato)item.Value)
            {
                infodato.Valor = 0;
                string key = string.Format("{0}-{1}", infodato.Direccion, infodato.Bit);
                if (infodato.EsEntrada)
                {
                    this.AlmacenLecturas.Add(key, infodato);
                    if (!entradas.Contains(infodato.Direccion))
                    {
                        entradas.Add(infodato.Direccion);
                    }
                }
                else
                {
                    this.AlmacenEscrituras.Add(key, infodato);
                    if (!salidas.Contains(infodato.Direccion))
                    {
                        salidas.Add(infodato.Direccion);
                    }
                }
            }
        }
        /// <summary>
        /// Procesa los mensajes recibidos en el data arrival.
        /// </summary>
        /// <param name="mensaje"></param>
        protected virtual void ProcesarMensajeRecibido(byte[] mensaje) { }
        /// <summary>
        /// Procesa los bits poniendo a 1 o 0 el bit correspondiente.
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="bit"></param>
        /// <param name="valorBit"></param>
        /// <returns></returns>
        private static byte ProcesarByte(byte valor, int bit, int valorBit)
        {
            byte ret;
            if (valorBit == 1)
            {
                ret = (byte)((valor) | (byte)(Math.Pow(2, bit)));
            }
            else
            {
                ret = (byte)(valor & ~(byte)(Math.Pow(2, bit)));
            }
            return ret;
        }
        #endregion Comunes

        #region ES
        /// <summary>
        /// Calcula el valor de las salidas para enviar al dispositivo
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores"></param>
        /// <returns></returns>
        private byte[] ProcesarEscritura(string[] variables, Object[] valores)
        {
            var salidas = new byte[NumeroBytesSalidas];
            var salidalocal = new byte[NumeroBytesSalidas];

            for (int i = 0; i < NumeroBytesSalidas; i++)
            {
                salidalocal[i] = this._lecturas[this.LecturaInicialSalida + i];
            }
            for (int i = 0; i < variables.Length; i++)
            {
                OInfoDato infodato = this.Tags.GetDB(variables[i]);
                if (infodato.EsEntrada) continue;
                salidas[infodato.Direccion - this.RegistroInicialSalidas] = ProcesarByte(salidalocal[infodato.Direccion - this.RegistroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                salidalocal[infodato.Direccion - this.RegistroInicialSalidas] = salidas[infodato.Direccion - this.RegistroInicialSalidas];
            }
            return salidas;
        }
        /// <summary>
        /// Método que encola trama GateData.
        /// </summary>
        /// <param name="trama"></param>
        protected void EsEncolar(byte[] trama)
        {
            // Bloquear la cola sincronizada.
            lock (this.QEntradaSalida.SyncRoot)
            {
                // Encolar la trama de ES recibida.
                this.QEntradaSalida.Enqueue(trama);

                // Despertar el hilo 'ESProcesarHilo' aletargado en la línea: 'this._eReset.Dormir(1)'
                this.Reset.Despertar(1);
            }
        }
        /// <summary>
        /// Método que desencola trama GateData.
        /// </summary>
        /// <returns>Objeto GateData</returns>
        protected byte[] EsDesencolar()
        {
            // Bloquear la cola sincronizada.
            lock (this.QEntradaSalida.SyncRoot)
            {
                byte[] mensaje = null;
                if (this.QEntradaSalida.Count > 0)
                {
                    // Desencolar el objeto Trama encolado en wsk_DataArrival.
                    mensaje = ((byte[])this.QEntradaSalida.Dequeue());
                }
                else
                {
                    this.Reset.Resetear(1);
                }
                return mensaje;
            }
        }
        /// <summary>
        /// Hilo de proceso de ES
        /// </summary>
        protected virtual void EsProcesarHilo() { }
        /// <summary>
        /// Enviar datos al dispositivo
        /// </summary>
        /// <param name="data"></param>
        private void Enviar(Object data)
        {
            this.Winsock.Send(data);
        }
        #endregion ES

        #endregion

        #region Eventos Socket
        /// <summary>
        /// Evento de recepción de datos
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void Winsock_DataArrival(object sender, WinsockDataArrivalEventArgs e)
        {
            try
            {
                // El método Get de winsock solo devuelve datos de tipo objeto.
                var datos = Winsock.Get<object>();

                string res = "";
                var recibido = (byte[])datos;
                this.ProcesarMensajeRecibido(recibido);

                if (recibido != null)
                {
                    res = recibido.Aggregate(res, (current, t) => current + ("[" + t + "]"));
                }
                Wrapper.Debug("ODispositivoSiemens1200ES [Winsock_DataArrival]: " + res);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ES [Winsock_DataArrival]: " + ex);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha enviado toda la información
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
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
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
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
        /// Evento de errores en la comunicación TCP
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
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
                    TimeSpan t = DateTime.Now.Subtract(_fechaErrorWrapperWinsock);
                    if (t.TotalSeconds > this.LogErrorComunicacionSg)
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
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador del mensaje.
        /// </summary>
        protected byte IdMensaje
        {
            get { return _idMensaje; }
            set
            {
                if (this._idMensaje > 255)
                {
                    _idMensaje = 1;
                }
                else
                {
                    _idMensaje++;
                }
            }
        }
        #endregion
    }
}