using System;
using System.Collections;
using System.Text;
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
        protected Queue _qEntradaSalida;
        /// <summary>
        /// Evento reset de recepción de tramas KeepAlive, 
        /// Entrada/Salida.
        /// </summary>
        protected OResetManual _eReset;  //0-keep alive;1-lecturas;2-escrituras
        /// <summary>
        /// Colección para la búsqueda de lecturas. La clave es la dupla "dirección-bit"
        /// </summary>
        protected OHashtable _almacenLecturas;
        /// <summary>
        /// Colección para la búsqueda de escrituras. La clave es la dupla "dirección-bit"
        /// </summary>
        protected OHashtable _almacenEscrituras;
        /// <summary>
        /// Número de lecturas a realizar
        /// </summary>
        protected int _numLecturas;
        /// <summary>
        /// Número de bytes de entradas
        /// </summary>
        protected int _numeroBytesEntradas;
        /// <summary>
        /// Número de bytes de salidas
        /// </summary>
        protected int _numeroBytesSalidas;
        /// <summary>
        /// Valor de las lecturas
        /// </summary>
        protected byte[] _lecturas;
        /// <summary>
        /// Valor inicial del registro de lecturas
        /// </summary>
        protected int _registroInicialEntradas;
        /// <summary>
        /// Valor inicial del registro de escrituras
        /// </summary>
        protected int _registroInicialSalidas;
        /// <summary>
        /// identificador del mensaje
        /// </summary>
        byte idMensaje = 0;
        /// <summary>
        /// Protocolo comunicación usado para el hilo vida
        /// </summary>
        protected OProtocoloTCPSiemens protocoloHiloVida;
        /// <summary>
        /// Protocolo comunicación usado para la escritura
        /// </summary>
        protected OProtocoloTCPSiemens protocoloEscritura;
        /// <summary>
        /// Protocolo comunicación usado para el proceso del mensaje
        /// </summary>
        protected OProtocoloTCPSiemens protocoloProcesoMensaje;
        /// <summary>
        /// Protocolo de comunicación usado para el proceso del hilo
        /// </summary>
        protected OProtocoloTCPSiemens protocoloProcesoHilo;
        /// <summary>
        /// Valor devuelto tras la escritura del PLC
        /// </summary>
        protected byte[] _valorEscritura;
        /// <summary>
        /// Fecha del ultimo wrapper de error
        /// </summary>
        DateTime fechaErrorWrapperWinsock = DateTime.MaxValue;
        /// <summary>
        /// Identificador del mensaje a enviar para la escritura
        /// </summary>
        private byte _idMens = 1;
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _qEscrituras;

        internal int _lecturaInicialSalida;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de clase de Siemens1200
        /// </summary>
        public ODispositivoSiemens1200ES(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo)
        {
            //Inicialización de objetos
            this.IniciarObjetos();
            wrapper.Info("ODispositivo1200ES Constructor Objetos del dispositivo de ES Siemens creados.");
            //Inicio de los parámetros TCP
            try
            {
                this.CrearParametrosConexionTCP();
                Hilos.Add(new ThreadStart(ESProcesarHilo), true);
            }
            catch (Exception ex)
            {
                wrapper.Error("ODispositivoSiemens1200 Constructor." + ex.ToString());
            }
            wrapper.Info("ODispositivo1200ES Constructor Comunicaciones TCP del dispositivo de ES Siemens arrancadas correctamente.");
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
                        int segReconexion = Convert.ToInt32(this.SegReconexion * 1000);
                        Thread.Sleep(segReconexion);
                        estado.Estado = "NOK";
                    }
                    catch (Exception ex)
                    {
                        if (fechaErrorWrapper == DateTime.MaxValue)
                        {
                            wrapper.Error("ODispositivoSiemens1200 ProcesarHiloVida error para keep alive: ", ex);
                            fechaErrorWrapper = DateTime.Now;
                        }
                        else
                        {
                            TimeSpan t = DateTime.Now.Subtract(fechaErrorWrapper);
                            if (t.TotalSeconds > this._segundosLogErrorComunicacion)
                            {
                                wrapper.Error("ODispositivoSiemens1200 ProcesarHiloVida error para keep alive: ", ex);
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
                        using (protocoloHiloVida)
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
                                        wrapper.Info("ODispositivoSiemens1200 ProcesarHiloVida Escritura de " + de.Variables.Length.ToString());
                                        this.Enviar(protocoloEscritura.SalidasEnviar(this.ProcesarEscritura(de.Variables, de.Valores), this._idMens));
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
                                this.Enviar(protocoloHiloVida.KeepAliveEnviar());

                                // Letargo del hilo hasta t-tiempo, o bien, hasta recibir respuesta, el cual realiza el Set sobre
                                // el eventReset del evento 'wsk_DataArrival'.
                                if (!this._eReset.Dormir(0, TimeSpan.FromSeconds(this._config.TiempoVida / 1000)))
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
                                    wrapper.Warn("ODispositivoSiemens1200 Timeout en el keep alive.");
                                }

                                // Resetear el evento.
                                this._eReset.Resetear(0);

                                // Letargo del hilo en función de la respuesta.
                                if (responde)
                                {
                                    estado.Estado = "OK";
                                    reintento = 0;
                                    Thread.Sleep(this._config.TiempoVida);
                                }
                                else
                                {
                                    responde = true;
                                    // Establecer un micro tiempo de letargo, necesario en este tipo de hilos.
                                    // Realizar un envio inmediato tras la no respuesta anterior.
                                    Thread.Sleep(10);
                                }
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        estado.Estado = "NOK";
                        wrapper.Error("ODispositivoSiemens1200 ProcesarHiloVida: ", ex);
                    }
                }

                try
                {
                    ts = DateTime.Now.Subtract(this._fechaUltimoEventoComs);
                    if (ts.TotalSeconds > (double)this._config.SegEventoComs)
                    {
                        this._oEventargs.Argumento = estado;
                        this.OnComm(this._oEventargs);
                        this._fechaUltimoEventoComs = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    wrapper.Error("ODispositivoSiemens1200 ProcesarHiloVida Error en envío de evento de comunicaciones: ", ex);
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
                wrapper.Fatal("ODispositivoSiemens1200 Leer: ", ex);
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

                if (this._qEscrituras.Count>0)
                {
                    de = ((DispositivoEscrituras)this._qEscrituras.Dequeue());
                }

                int longitud = 0;

                if (de!=null)
                {
                    longitud = de.Valores.Length;
                }

                longitud = longitud + variables.Length;

                string[] vars = new string[longitud];
                object[] vals = new object[longitud];

                for (int i = 0; i < longitud; i++)
                {
                    if (i<variables.Length)
                    {
                        vars[i] = variables[i];
                        vals[i] = valores[i];
                    }
                    else
                    {
                        vars[i] = de.Variables[longitud-variables.Length-i];
                        vals[i] = de.Valores[longitud - variables.Length - i];
                    }
                    
                }
                DispositivoEscrituras disp = new DispositivoEscrituras(vars, vals);

                this._qEscrituras.Enqueue(disp);
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
            handler = null;
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
            handler = null;
        }
        #endregion

        #region Métodos privados

        #region Comunes
        /// <summary>
        /// Publica los eventos de socket
        /// </summary>
        private void CrearParametrosConexionTCP()
        {
            try
            {
                this.Winsock = new OWinsockBase();
                this.Winsock.LegacySupport = true;
                this.Winsock.DataArrival += new IWinsock.DataArrivalEventHandler(_winsock_DataArrival);
                this.Winsock.StateChanged += new IWinsock.StateChangedEventHandler(_winsock_StateChanged);
                this.Winsock.SendComplete += new IWinsock.SendCompleteEventHandler(_winsock_SendComplete);
                this.Winsock.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsock_ErrorReceived);
            }
            catch (Exception ex)
            {
                wrapper.Fatal("ODispositivoSiemens1200 CrearParametrosConexionTCP Error al crear la conexión TCP con el dispositivo de ES Siemens. " + ex.ToString());
                throw ex;
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
        }
        /// <summary>
        /// Procesa los mensajes recibidos en el data arrival
        /// </summary>
        /// <param name="mensaje"></param>
        protected virtual void ProcesarMensajeRecibido(byte[] mensaje)
        {

        }
        /// <summary>
        /// Procesa los bits poniendo a 1 o 0 el bit correspondiente
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="bit"></param>
        /// <param name="valorBit"></param>
        /// <returns></returns>
        private byte ProcesarByte(byte valor, int bit, int valorBit)
        {
            byte ret = 0;

            try
            {
                if (valorBit == 1)
                {
                    ret = (byte)((valor) | (byte)(Math.Pow(2, bit)));
                }
                else
                {
                    ret = (byte)(valor & ~(byte)(Math.Pow(2, bit)));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        #endregion

        #region ES
        /// <summary>
        /// Calcula el valor de las salidas para enviar al dispositivo
        /// </summary>
        /// <param name="variables"></param>
        /// <param name="valores"></param>
        /// <returns></returns>
        private byte[] ProcesarEscritura(string[] variables, Object[] valores)
        {
            byte[] salidas = new byte[_numeroBytesSalidas];
            byte[] salidalocal = new byte[_numeroBytesSalidas];

            for (int i = 0; i < _numeroBytesSalidas; i++)
            {
                salidalocal[i] = this._lecturas[this._lecturaInicialSalida + i];
            }
            for (int i = 0; i < variables.Length; i++)
            {
                OInfoDato infodato = this.Tags.GetDB(variables[i]);

                if (!infodato.EsEntrada)
                {
                    salidas[infodato.Direccion - this._registroInicialSalidas] = this.ProcesarByte(salidalocal[infodato.Direccion - this._registroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                    salidalocal[infodato.Direccion - this._registroInicialSalidas] = salidas[infodato.Direccion - this._registroInicialSalidas];
                }
            }

            return salidas;
        }

        /// <summary>
        /// Método que encola trama GateData.
        /// </summary>
        /// <param name="trama"></param>
        protected void ESEncolar(byte[] trama)
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
        /// Método que desencola trama GateData.
        /// </summary>
        /// <returns>Objeto GateData</returns>
        protected byte[] ESDesencolar()
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
                    this._eReset.Resetear(1);
                }
                return mensaje;
            }
        }
        /// <summary>
        /// Hilo de proceso de ES
        /// </summary>
        protected virtual void ESProcesarHilo()
        {

        }

        /// <summary>
        /// Enviar datos al dispositivo
        /// </summary>
        /// <param name="data"></param>
        private void Enviar(Object data)
        {
            try
            {
                this.Winsock.Send(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Eventos Socket
        /// <summary>
        /// Evento de recepción de datos
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsock_DataArrival(object sender, WinsockDataArrivalEventArgs e)
        {
            try
            {
                String data = "";   // data es la variable donde guardaremos el mensaje recibido
                Object dat = (object)data;  // dat es una variable tipo objeto
                // el metodo Get de winsock solo devuelve datos de tipo objeto.

                dat = Winsock.Get<object>();

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
                wrapper.Debug("ODispositivo1200ES _winsock_DataArrival Data Arrival en el dispositivo de ES Siemens: " + ret);
            }
            catch (Exception ex)
            {
                string error = "ODispositivo1200ES _winsock_DataArrival Error Data Arrival en el dispositivo de ES Siemens: " + ex.ToString();
                wrapper.Error(error);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha enviado toda la información
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsock_SendComplete(object sender, WinsockSendEventArgs e)
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

                wrapper.Debug("ODispositivo1200ES _winsock_SendComplete Send Complete en el dispositivo de ES Siemens: " + enviado);

            }
            catch (Exception ex)
            {
                string error = "ODispositivo1200ES _winsock_SendComplete Error Send Complete en el dispositivo de ES Siemens: " + ex.ToString();
                wrapper.Error(error);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha cambiado de estado. Trazabilidad del canal.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsock_StateChanged(object sender, WinsockStateChangedEventArgs e)
        {
            try
            {
                string estado = "ODispositivo1200ES _winsock_StateChanged State Changed en el dispositivo de ES Siemens. Cambia de " + e.Old_State.ToString() + " a " + e.New_State.ToString();
                wrapper.Debug(estado);
            }
            catch (Exception ex)
            {
                string error = "ODispositivo1200ES _winsock_StateChanged Error State Changed en el dispositivo de ES Siemens: " + ex.ToString();
                wrapper.Error(error);
            }
        }
        /// <summary>
        /// Evento de errores en la comunicación TCP
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsock_ErrorReceived(object sender, WinsockErrorReceivedEventArgs e)
        {
            try
            {
                string error = "ODispositivoSiemens1200ES _winsock_ErrorReceived: " + e.Message;
                if (fechaErrorWrapperWinsock == DateTime.MaxValue)
                {
                    wrapper.Error(error);
                    fechaErrorWrapperWinsock = DateTime.Now;
                }
                else
                {
                    TimeSpan t = DateTime.Now.Subtract(fechaErrorWrapperWinsock);
                    if (t.TotalSeconds > this._segundosLogErrorComunicacion)
                    {
                        wrapper.Error(error);
                        fechaErrorWrapperWinsock = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = "ODispositivoSiemens1200ES _winsock_ErrorReceived catch: " + ex.ToString();
                wrapper.Error(error);
            }
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        protected byte IdMens
        {
            get { return _idMens; }
            set
            {
                if (this._idMens > 255)
                {
                    _idMens = 1;
                }
                else
                {
                    _idMens++;
                }
            }
        }
        #endregion
    }
}