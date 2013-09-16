using System;
using System.Collections;
using System.Threading;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo entradas salidas ILBKPhoenix
    /// </summary>
    public class ODispositivoILBKPhoenix : ODispositivoES
    {
        #region Atributos
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _qEntradaSalida;
        /// <summary>
        /// Evento reset de recepción de tramas KeepAlive, 
        /// Entrada/Salida.
        /// </summary>
        private OResetManual _eReset;  // 0-KeepAlive; 1-lecturas
        /// <summary>
        /// Colección para la búsqueda de lecturas. La clave es la dupla "dirección-bit"
        /// </summary>
        private OHashtable _almacenLecturas;
        /// <summary>
        /// Colección para la búsqueda de escrituras. La clave es la dupla "dirección-bit"
        /// </summary>
        private OHashtable _almacenEscrituras;
        /// <summary>
        /// Número de lecturas a realizar
        /// </summary>
        private int _numLecturas;
        /// <summary>
        /// Número de bytes de entradas
        /// </summary>
        private int _numeroBytesEntradas;
        /// <summary>
        /// Número de bytes de salidas
        /// </summary>
        private int _numeroBytesSalidas;
        /// <summary>
        /// Valor de las lecturas
        /// </summary>
        private byte[] _lecturas;
        /// <summary>
        /// Valor inicial del registro de lecturas
        /// </summary>
        private int _registroInicialEntradas;
        /// <summary>
        /// Valor inicial del registro de escrituras
        /// </summary>
        private int _registroInicialSalidas;
        /// <summary>
        /// Fecha del ultimo wrapper de error
        /// </summary>
        private DateTime _fechaErrorWrapperWinsock = DateTime.MaxValue;
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _qEscrituras;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoILBKPhoenix.
        /// </summary>
        /// <param name="tags">variables</param>
        /// <param name="hilos">hilos del dispositivo</param>
        /// <param name="dispositivo">dispositivo</param>
        public ODispositivoILBKPhoenix(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo)
        {
            //Inicialización de objetos
            this.IniciarObjetos();
            Wrapper.Info("ODispositivoILBKPhoenix Constructor Objetos del dispositivo de ES Phoenix creados.");
            //Inicio de los parámetros TCP
            try
            {
                this.CrearParametrosConexionTcp();
                Hilos.Add(new ThreadStart(EsColaVariables), true);
                Wrapper.Info("ODispositivoILBKPhoenix Constructor. Comunicaciones TCP del dispositivo de ES Phoenix arrancadas correctamente.");
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoILBKPhoenix Constructor. No se pudo crear la conexión TCP con el dispositivo de ES Phoenix." + ex);
            }
        }
        #endregion Constructor

        #region Métodos públicos
        /// <summary>
        /// Procesa las lecturas del dispositivo
        /// </summary>
        public override void ProcesarHiloVida()
        {
            OEstadoComms estado = new OEstadoComms();
            estado.Nombre = this.Nombre;
            estado.Id = this.Identificador;
            estado.Enlace = this.Tags.HtVida.Enlaces[0].ToString();
            Boolean responde = true;
            DateTime fechaErrorWrapper = DateTime.MaxValue;

            int reintento = 0;
            int maxReintentos = 3;
            TimeSpan ts;

            bool modoKeepAlive = true;
            bool ini = true;
            while (true)
            {
                #region Conectar
                if (this.Winsock.State != WinsockStates.Connected)
                {
                    try
                    {
                        this.Conectar();
                        int segReconexion = Convert.ToInt32(this.ReConexionSg * 1000);
                        Thread.Sleep(segReconexion);
                        estado.Estado = "NOK";
                    }
                    catch (Exception ex)
                    {
                        if (fechaErrorWrapper == DateTime.MaxValue)
                        {
                            Wrapper.Error("ODispositivoILBKPhoenix ProcesarHiloVida error para KeepAlive: ", ex);
                            fechaErrorWrapper = DateTime.Now;
                        }
                        else
                        {
                            TimeSpan t = DateTime.Now.Subtract(fechaErrorWrapper);
                            if (t.TotalSeconds > this.LogErrorComunicacionSg)
                            {
                                Wrapper.Error("ODispositivoILBKPhoenix ProcesarHiloVida error para KeepAlive: ", ex);
                                fechaErrorWrapper = DateTime.Now;
                            }
                        }
                    }
                }
                #endregion
                else
                {
                    try
                    {
                        using (OProtocoloTCPPhoenixES phoenixTCP = new OProtocoloTCPPhoenixES(
                            this._registroInicialEntradas, this._numeroBytesEntradas, this._registroInicialSalidas, this._numeroBytesSalidas))
                        {
                            #region Escrituras
                            if (modoKeepAlive && !ini)
                            {
                                modoKeepAlive = false;
                                if (this._qEscrituras.Count > 0)
                                {
                                    lock (this._qEscrituras.SyncRoot)
                                    {
                                        DispositivoEscrituras de = null;
                                        de = ((DispositivoEscrituras)this._qEscrituras.Dequeue());
                                        this.Enviar(phoenixTCP.SalidasEnviar(this.ProcesarEscritura(de.Variables, de.Valores)));
                                        Thread.Sleep(10);
                                    }

                                }
                            }
                            #endregion

                            #region KeepAlive
                            else
                            {
                                ini = false;
                                modoKeepAlive = true;
                                this.Enviar(phoenixTCP.KeepAliveEnviar());

                                // Letargo del hilo hasta t-tiempo, o bien, hasta recibir respuesta, el cual realiza el Set sobre
                                // el eventReset del evento 'wsk_DataArrival'.
                                if (!this._eReset.Dormir(0, TimeSpan.FromSeconds(this.ConfigDispositivo.TiempoVida / 1000)))
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
                                    Wrapper.Warn("ODispositivoILBKPhoenix ProcesarHiloVida Timeout en el KeepAlive del dispositivo de ES Phoenix.");
                                }

                                // Resetear el evento.
                                this._eReset.Resetear(0);

                                // Letargo del hilo en función de la respuesta.
                                if (responde)
                                {
                                    estado.Estado = "OK";
                                    reintento = 0;
                                    Thread.Sleep(this.ConfigDispositivo.TiempoVida);
                                }
                                else
                                {
                                    responde = true;
                                    // Establecer un micro tiempo de letargo, necesario en este tipo de hilos.
                                    // Realizar un envio inmediato tras la no respuesta anterior.
                                    Thread.Sleep(10);
                                }
                            }
                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        estado.Estado = "NOK";
                        Wrapper.Error("ODispositivoILBKPhoenix ProcesarHiloVida: ", ex);
                    }
                }
                try
                {
                    ts = DateTime.Now.Subtract(this.FechaUltimoEventoComm);
                    if (ts.TotalSeconds > (double)this.ConfigDispositivo.SegEventoComs)
                    {
                        this.Eventargs.Argumento = estado;
                        this.OnComm(this.Eventargs);
                        this.FechaUltimoEventoComm = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    Wrapper.Error("ODispositivoILBKPhoenix ProcesarHiloVida Error en envío de evento de comunicaciones: ", ex);
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

                    // Asignar a la colección resultado el número
                    // de variables de la colección de variables.
                    resultado = new object[contador];
                    for (int i = 0; i < contador; i++)
                    {
                        object res = this.Tags.GetDB(variables[i]).Valor;
                        resultado[i] = res;
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoILBKPhoenix Leer Error al leer en el dispositivo de ES Phoenix. ", ex);
                throw ex;
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
                DispositivoEscrituras de = null;

                if (this._qEscrituras.Count > 0)
                {
                    de = ((DispositivoEscrituras)this._qEscrituras.Dequeue());
                }

                int longitud = 0;

                if (de != null)
                {
                    longitud = de.Valores.Length;
                }

                longitud = longitud + variables.Length;

                string[] vars = new string[longitud];
                object[] vals = new object[longitud];

                for (int i = 0; i < longitud; i++)
                {
                    if (i < variables.Length)
                    {
                        vars[i] = variables[i];
                        vals[i] = valores[i];
                    }
                    else
                    {
                        vars[i] = de.Variables[longitud - variables.Length - i];
                        vals[i] = de.Valores[longitud - variables.Length - i];
                    }

                }
                DispositivoEscrituras disp = new DispositivoEscrituras(vars, vals);

                this._qEscrituras.Enqueue(disp);
            }

            return true;
        }
        #endregion Métodos públicos

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
                this.Winsock.DataArrival += _winsock_DataArrival;
                this.Winsock.StateChanged += _winsock_StateChanged;
                this.Winsock.SendComplete += _winsock_SendComplete;
                this.Winsock.ErrorReceived += _winsock_ErrorReceived;
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoILBKPhoenix CrearParametrosConexionTCP Error al crear la conexión TCP con el dispositivo de ES Phoenix. " + ex);
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
        private void IniciarObjetos()
        {
            // Cola de envío/recepción de tramas.
            this._qEntradaSalida = new Queue();
            this._qEscrituras = new Queue();
            // Evento reset de envío/recepción de tramas KeepAlive y Entrada/Salida.
            this._eReset = new OResetManual(3);
            // Iniciamos los datos 
            ArrayList listEntradas = new ArrayList();
            ArrayList listSalidas = new ArrayList();

            this._almacenLecturas = new OHashtable();
            this._almacenEscrituras = new OHashtable();
            foreach (DictionaryEntry item in this.Tags.GetDatos())
            {
                OInfoDato infodato = (OInfoDato)item.Value;
                infodato.Valor = 0;
                string key = infodato.Direccion.ToString() + "-" + infodato.Bit.ToString();
                if (infodato.EsEntrada)
                {
                    this._almacenLecturas.Add(key, infodato);
                    if (!listEntradas.Contains(infodato.Direccion))
                    {
                        listEntradas.Add(infodato.Direccion);
                    }
                }
                else
                {
                    this._almacenEscrituras.Add(key, infodato);
                    if (!listSalidas.Contains(infodato.Direccion))
                    {
                        listSalidas.Add(infodato.Direccion);
                    }
                }
            }

            listEntradas.Sort();
            listSalidas.Sort();

            this._numLecturas = listEntradas.Count + listSalidas.Count;//Para el ILBKPhoenix48 tiene 2 lecturas
            this._numeroBytesEntradas = listEntradas.Count;//Para el ILBKPhoenix48 tiene 1 byte para entradas
            this._numeroBytesSalidas = listSalidas.Count;//Para el ILBKPhoenix48 tiene 1 byte para salidas
            this._registroInicialEntradas = Convert.ToInt32(listEntradas[0]);//Para el ILBKPhoenix48 es el 8000 
            this._registroInicialSalidas = Convert.ToInt32(listSalidas[0]);//Para el ILBKPhoenix48 es el 8001   

            this.Entradas = new byte[this._numeroBytesEntradas];
            this.Salidas = new byte[this._numeroBytesSalidas];

            this._lecturas = new byte[_numLecturas];
        }
        /// <summary>
        /// Procesa los mensajes recibidos en el data arrival
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarMensajeRecibido(byte[] mensaje)
        {
            using (OProtocoloTCPPhoenixES phoenixTCP = new OProtocoloTCPPhoenixES(this._registroInicialEntradas, this._numeroBytesEntradas, this._registroInicialSalidas, this._numeroBytesSalidas))
            {
                lock (Bloqueo)
                {
                    byte[] lecturas;
                    if (mensaje[7] == 3)//respuesta para la lectura
                    {

                        if (phoenixTCP.KeepAliveProcesar(mensaje, out lecturas))
                        {
                            for (int i = 0; i < this._numLecturas; i++)
                            {
                                if (this._lecturas[i] != lecturas[i])
                                {
                                    this.EsEncolar(lecturas);
                                    break;
                                }
                            }
                            this._lecturas = lecturas;
                            // Despertar el hilo en la línea:
                            // this._eReset.Dormir de ProcesarHiloKeepAlive.                        
                            this._eReset.Despertar(0);
                        }
                    }
                    else if (mensaje[7] == 16)//respuesta para la escritura
                    {
                        Wrapper.Info("ODispositivoILBKPhoenix ProcesarMensajeRecibido escritura procesada");
                        lecturas = new byte[this._numLecturas];
                        for (int i = 0; i < this._numLecturas; i++)
                        {
                            lecturas[i] = this._lecturas[i];
                        }
                        this.EsEncolar(lecturas);
                        //this._eReset.Despertar(2);
                    }
                }
            }
        }
        /// <summary>
        /// Procesa los bits poniendo a 1 o 0 el bit correspondiente
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="bit"></param>
        /// <param name="valorBit"></param>
        /// <returns></returns>
        private static byte ProcesarByte(byte valor, int bit, int valorBit)
        {
            byte ret = 0;
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
        /// <summary>
        /// Enviar datos al dispositivo
        /// </summary>
        /// <param name="data"></param>
        private void Enviar(Object data)
        {
            this.Winsock.Send(data);
        }
        #endregion Comunes

        #region ES
        /// <summary>
        /// Calcula el valor de las salidas para enviar al dispositivo.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores"></param>
        /// <returns></returns>
        private byte[] ProcesarEscritura(string[] variables, Object[] valores)
        {
            byte[] salidas = new byte[_numeroBytesSalidas];
            byte[] salidalocal = new byte[_numeroBytesSalidas];

            for (int i = 0; i < _numeroBytesSalidas; i++)
            {
                salidalocal[i] = this._lecturas[i + 1];
            }
            for (int i = 0; i < variables.Length; i++)
            {
                OInfoDato infodato = this.Tags.GetDB(variables[i]);
                if (!infodato.EsEntrada)
                {
                    salidas[infodato.Direccion - this._registroInicialSalidas] = ProcesarByte(salidalocal[infodato.Direccion - this._registroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                    salidalocal[infodato.Direccion - this._registroInicialSalidas] = salidas[infodato.Direccion - this._registroInicialSalidas];
                }
            }

            //Configuramos las salidas en dos bytes
            Array.Resize(ref salidas, 2);
            Array.Reverse(salidas);

            return salidas;
        }
        /// <summary>
        /// Método que encola las lecturas para que se procesen.
        /// </summary>
        /// <param name="trama"></param>
        private void EsEncolar(byte[] trama)
        {
            // Bloquear la cola sincronizada.
            lock (this._qEntradaSalida.SyncRoot)
            {
                // Encolar la trama de ES recibida.
                this._qEntradaSalida.Enqueue(trama);

                // Despertar el hilo 'ESProcesarHilo' aletargado
                // en la línea: 'this._eReset.Dormir(1)'
                this._eReset.Despertar(1);
            }
        }
        /// <summary>
        /// Método que desencola las lecturas para ser procesadas.
        /// </summary>
        /// <returns>Objeto GateData</returns>
        private byte[] EsDesencolar()
        {
            // Bloquear la cola sincronizada.
            lock (this._qEntradaSalida.SyncRoot)
            {
                byte[] mensaje = null;
                if (this._qEntradaSalida.Count > 0)
                {
                    // Desencolar el objeto Trama encolado en wsk_DataArrival.
                    mensaje = ((byte[])this._qEntradaSalida.Dequeue());
                }
                else
                {
                    // Reset para la siguiente vez que se mande un Set.
                    // Es necesario invocarlo por haber utilizado ManualResetEvent.
                    this._eReset.Resetear(1);
                }
                return mensaje;
            }
        }
        /// <summary>
        /// Hilo de proceso de ES
        /// </summary>
        private void EsColaVariables()
        {
            while (true)
            {
                byte[] mensaje = this.EsDesencolar();

                if (mensaje != null)
                {
                    lock (this)
                    {
                        try
                        {
                            using (OProtocoloTCPPhoenixES phoenixTCP = new OProtocoloTCPPhoenixES(
                                this._registroInicialEntradas, this._numeroBytesEntradas, this._registroInicialSalidas, this._numeroBytesSalidas))
                            {
                                byte[] entradas;
                                byte[] salidas;
                                if (phoenixTCP.ESprocesar(mensaje, out entradas, out salidas))
                                {
                                    this.EsProcesar(entradas, salidas);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Wrapper.Fatal("ODispositivoILBKPhoenix ESColaVariables Error al procesar las ES en el dispositivo de ES Phoenix. " + ex);
                        }
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    this._eReset.Dormir(1);
                }
            }
        }
        /// <summary>
        /// Procesa los bytes de entradas y salidas para actualizar los valores de las variables
        /// </summary>
        /// <param name="entradas">byte de entradas recibido</param>
        /// <param name="salidas">byte de salidas recibido</param>
        private void EsProcesar(byte[] entradas, byte[] salidas)
        {
            try
            {
                for (int i = 0; i < entradas.Length; i++)
                {
                    if (entradas[i] != this.Entradas[i])
                    {
                        this.EsActualizarVariablesEntradas(entradas[i], i + this._registroInicialEntradas);
                    }
                    if (salidas[i] != this.Salidas[i])
                    {
                        this.EsActualizarVariablesSalidas(salidas[i], i + this._registroInicialSalidas);
                    }
                }
                this.Entradas = entradas;
                this.Salidas = salidas;
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoILBKPhoenix ESProcesar " + ex);
                throw;
            }
        }
        /// <summary>
        /// Actualiza los valores de las entradas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void EsActualizarVariablesEntradas(byte valor, int posicion)
        {
            OEventArgs ev = new OEventArgs();
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    OInfoDato infodato = (OInfoDato)this._almacenLecturas[posicion.ToString() + "-" + i.ToString()];
                    //Comprobamos el valor nuevo 
                    if (infodato != null)
                    {
                        int resultado = 0;
                        if ((valor & (1 << i)) != 0)
                        {
                            resultado = 1;
                        }

                        if (resultado != Convert.ToInt32(infodato.Valor))
                        {
                            infodato.Valor = resultado;
                            ev.Argumento = infodato;
                            this.OnCambioDato(ev);

                            if (this.Tags.GetAlarmas(infodato.Identificador) != null)
                            {
                                if (Convert.ToInt32(infodato.Valor) == 1)
                                {
                                    if (!AlarmasActivas.Contains(infodato.Texto))
                                    {
                                        this.AlarmasActivas.Add(infodato.Texto);
                                    }
                                }
                                else
                                {
                                    if (AlarmasActivas.Contains(infodato.Texto))
                                    {
                                        this.AlarmasActivas.Remove(infodato.Texto);
                                    }
                                }

                                this.OnAlarma(ev);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Wrapper.Error("ODispositivoILBKPhoenix ESActualizarVariablesEntradas " + ex);
                }
            }
        }
        /// <summary>
        /// Actualiza los valores de las salidas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void EsActualizarVariablesSalidas(byte valor, int posicion)
        {
            OEventArgs ev = new OEventArgs();
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    OInfoDato infodato = (OInfoDato)this._almacenEscrituras[posicion.ToString() + "-" + i.ToString()];
                    //Comprobamos el valor nuevo 
                    if (infodato != null)
                    {
                        int resultado = 0;
                        if ((valor & (1 << i)) != 0)
                        {
                            resultado = 1;
                        }

                        if (resultado != Convert.ToInt32(infodato.Valor))
                        {
                            infodato.Valor = resultado;
                            ev.Argumento = infodato;
                            this.OnCambioDato(ev);

                            if (this.Tags.GetAlarmas(infodato.Identificador) != null)
                            {
                                if (Convert.ToInt32(infodato.Valor) == 1)
                                {
                                    if (!AlarmasActivas.Contains(infodato.Texto))
                                    {
                                        this.AlarmasActivas.Add(infodato.Texto);
                                    }
                                }
                                else
                                {
                                    if (AlarmasActivas.Contains(infodato.Texto))
                                    {
                                        this.AlarmasActivas.Remove(infodato.Texto);
                                    }
                                }

                                this.OnAlarma(ev);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Wrapper.Error("ODispositivoILBKPhoenix ESActualizarVariablesSalidas " + ex);
                }
            }
        }
        #endregion ES

        #endregion Métodos privados

        #region Eventos Socket
        /// <summary>
        /// Evento de recepción de datos
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _winsock_DataArrival(object sender, WinsockDataArrivalEventArgs e)
        {
            try
            {
                object dat = Winsock.Get<object>();
                string ret = "";
                byte[] recibido = (byte[])dat;
                if (recibido != null)
                {
                    for (int i = 0; i < recibido.Length; i++)
                    {
                        ret += "[" + recibido[i].ToString() + "]";
                    }
                }
                this.ProcesarMensajeRecibido(recibido);
                Wrapper.Debug("ODispositivoILBKPhoenix _winsock_DataArrival: " + ret);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoILBKPhoenix _winsock_DataArrival: " + ex);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha enviado toda la información
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _winsock_SendComplete(object sender, WinsockSendEventArgs e)
        {
            //verificamos la llegada
            try
            {
                string enviado = "";
                if (e.DataSent != null)
                {
                    for (int i = 0; i < e.DataSent.Length; i++)
                    {
                        enviado += "[" + e.DataSent[i].ToString() + "]";
                    }
                }
                Wrapper.Debug("ODispositivoILBKPhoenix _winsock_SendComplete: " + enviado);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoILBKPhoenix _winsock_SendComplete: " + ex);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha cambiado de estado. Trazabilidad del canal.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _winsock_StateChanged(object sender, WinsockStateChangedEventArgs e)
        {
            try
            {
                string estado = "ODispositivoILBKPhoenix _winsock_StateChanged. Cambia de " + e.Old_State.ToString() + " a " + e.New_State.ToString();
                Wrapper.Debug(estado);
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoILBKPhoenix _winsock_StateChanged: " + ex);
            }
        }
        /// <summary>
        /// Evento de errores en la comunicación TCP
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _winsock_ErrorReceived(object sender, WinsockErrorReceivedEventArgs e)
        {
            try
            {
                string error = "ODispositivoILBKPhoenix _winsock_ErrorReceived: " + e.Message;
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
                Wrapper.Error("ODispositivoILBKPhoenix _winsock_ErrorReceived catch: " + ex);
            }
        }
        #endregion Eventos Socket
    }
}