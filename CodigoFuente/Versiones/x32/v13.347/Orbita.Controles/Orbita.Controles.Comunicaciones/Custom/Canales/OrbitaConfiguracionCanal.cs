using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
namespace Orbita.Controles.Comunicaciones
{
    #region Delegados
    public delegate void EventoClienteComs(OEventArgs e, string canal);
    public delegate void EventoClienteCambioDato(OEventArgs e, string canal);
    public delegate void EventoClienteAlarma(OEventArgs e, string canal);
    public delegate void EventoClienteEstadoCabal(OEventArgs e, string canal);
    public delegate void EventoCanalTCP(OEventArgs e);
    #endregion

    public partial class OrbitaConfiguracionCanal : Component
    {
        #region Atributos
        /// <summary>
        /// Canal comunicaciones remoto
        /// </summary>
        private string _nombreCanal = "CanalRemoting";
        /// <summary>
        /// Puerto de comunicación de remoting
        /// </summary>
        private int _remotingPuerto = 1852;
        /// <summary>
        /// Servidor de comunicaciones.
        /// </summary>
        private IOCommRemoting _servidor;
        /// <summary>
        /// Servidor remoting
        /// </summary>
        private string _remotingServidor = "localhost";
        /// <summary>
        /// Evento para los cambios de comunicaciones
        /// </summary>
        public static event EventoClienteComs OEventoClienteComs;
        /// <summary>
        /// Evento para los cambios de dato
        /// </summary>
        public static event EventoClienteCambioDato OEventoClienteCambioDato;
        /// <summary>
        /// Evento para las alarmas
        /// </summary>
        public static event EventoClienteAlarma OEventoClienteAlarma;
        /// <summary>
        /// Evento para el estado del canal
        /// </summary>
        public static event EventoClienteAlarma OEventoEstadoCanal;
        /// <summary>
        /// Wrapper de comunicaciones
        /// </summary>
        private OBroadcastEventWrapper _eventWrapper;
        /// <summary>
        /// Wrapper del log
        /// </summary>
        public static ILogger _wrapper;
        /// <summary>
        /// Hilos de estado
        /// </summary>
        private OHilos HilosEstado;
        /// <summary>
        /// Fecha de recepción del mensaje de comunicaciones
        /// </summary>
        private DateTime _fechaRecepcionMensajeComs;
        /// <summary>
        /// Segundos para la reconexión del canal
        /// </summary>
        private int _segundosReconexion;
        /// <summary>
        /// Reintentos antes de empezar la reconexión
        /// </summary>
        private int _reintentosReconexion;
        /// <summary>
        /// Segundos para el evento de estado
        /// </summary>
        private int _segundosEventoEstado;
        /// <summary>
        /// Ruta del logger
        /// </summary>
        private string _nombreLogger;
        /// <summary>
        /// Estado del canal
        /// </summary>
        private Winsock.WinsockStates _estado;
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _qCambioDato;
        /// <summary>
        /// Cola de recepción de tramas de alarmas.
        /// </summary>
        private Queue _qAlarmas;
        /// <summary>
        /// Cola de recepción de tramas de comunicaciones.
        /// </summary>
        private Queue _qComunicaciones;
        /// <summary>
        /// Sincronización de colas
        /// </summary>
        private OResetManual _eReset;  //0-cambio dato;1-alarmas;2-comunicaciones;3escrituras
        /// <summary>
        /// Hilos para desencolar
        /// </summary>
        private static OHilos _hiloCambioDato;
        /// <summary>
        /// Tamaño máximo de colas
        /// </summary>
        private int _bufferCola = 256;
        /// <summary>
        /// Número del servidor de remoting
        /// </summary>
        private int _numeroServidor;
        #endregion

        #region Constructor
        public OrbitaConfiguracionCanal()
        {
            InitializeComponent();
        }
        public OrbitaConfiguracionCanal(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Puerto de comunicación de remoting
        /// </summary>
        public int RemotingPuerto
        {
            get { return _remotingPuerto; }
            set { _remotingPuerto = value; }
        }
        /// <summary>
        /// Servidor de comunicaciones.
        /// </summary>
        public string ServidorRemoting
        {
            get { return _remotingServidor; }
            set { _remotingServidor = value; }
        }
        /// <summary>
        /// Canal comunicaciones remoto
        /// </summary>
        public string NombreCanal
        {
            get { return _nombreCanal; }
            set { _nombreCanal = value; }
        }
        /// <summary>
        /// Segundos para la reconexión del canal
        /// </summary>
        public int SegundosReconexion
        {
            get { return _segundosReconexion; }
            set { _segundosReconexion = value; }
        }
        /// <summary>
        /// Reintentos antes de empezar la reconexión
        /// </summary>
        public int ReintentosReconexion
        {
            get { return _reintentosReconexion; }
            set { _reintentosReconexion = value; }
        }
        /// <summary>
        /// Segundos para el evento de estado
        /// </summary>
        public int SegundosEventoEstado
        {
            get { return _segundosEventoEstado; }
            set { _segundosEventoEstado = value; }
        }
        /// <summary>
        /// Ruta del logger
        /// </summary>
        public string NombreLogger
        {
            get { return _nombreLogger; }
            set { _nombreLogger = value; }
        }
        /// <summary>
        /// Número de servidor de remoting
        /// </summary>
        public int NumeroServidor
        {
            get { return _numeroServidor; }
            set { _numeroServidor = value; }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaCambioDato(OEventArgs e)
        {
            try
            {
                if (OEventoClienteCambioDato != null)
                {
                    this.EncolarCambioDato(e);
                }
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal eventWrapper_OrbitaCambioDato ", ex);
            }
        }
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaAlarma(OEventArgs e)
        {
            try
            {
                if (OEventoClienteAlarma != null)
                {
                    OEventoClienteAlarma(e, this._nombreCanal);
                }
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal eventWrapper_OrbitaAlarma ", ex);
            }
        }
        /// <summary>
        /// Evento de comunicaciones.
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaComm(OEventArgs e)
        {
            try
            {
                this._fechaRecepcionMensajeComs = DateTime.Now;

                if (OEventoClienteComs != null)
                {
                    OEventoClienteComs(e, this._nombreCanal);
                }
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal eventWrapper_OrbitaComm ", ex);
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Incia las comunicaciones con el dispositivo remoto
        /// </summary>
        public void Iniciar()
        {
            try
            {
                this._qCambioDato = new Queue(this._bufferCola);
                this._qComunicaciones = new Queue(this._bufferCola);
                this._qAlarmas = new Queue(this._bufferCola);

                this._eReset = new OResetManual(3);

                _hiloCambioDato = new OHilos();
                _hiloCambioDato.OnDespuesAdicionar += new ManejadorEvento(hilos_OnDespuesAdicionar);
                OHilo hiloCambioDato = _hiloCambioDato.Add(new ThreadStart(ProcesarHiloColaCambioDato), true);
                hiloCambioDato.Iniciar();

                LogManager.ConfiguracionLogger(Application.StartupPath + @"\" + this._nombreLogger + ".xml");
                _wrapper = LogManager.GetLogger("wrapperdebug");
                OrbitaConfiguracionCanal._wrapper.Info("Log creado");

                // Establecer la configuración Remoting entre procesos.
                this._fechaRecepcionMensajeComs = DateTime.Now;

                this._servidor = ORemoting.getServidor(this._numeroServidor);
                this.ConectarWrapper();

                //this.IniciarHiloEstadoCanal();
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal Iniciar ", ex);
            }
        }

        #region Remoting
        /// <summary>
        /// Conecta con el wrapper de remoting
        /// </summary>
        public void ConectarWrapper()
        {
            try
            {
                // Eventwrapper de comunicaciones.
                this._eventWrapper = new Orbita.Comunicaciones.OBroadcastEventWrapper();

                //Eventos locales.
                //...cambio de dato.
                this._eventWrapper.OrbitaCambioDato += new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                this._eventWrapper.OrbitaAlarma += new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                this._eventWrapper.OrbitaComm += new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato += new OManejadorEventoComm(_eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma += new OManejadorEventoComm(_eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm += new OManejadorEventoComm(_eventWrapper.OnComm);

                // Establecer conexión con el servidor.
                Conectar(true);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal ConectarWrapper Error al conectar el wrapper del canal de comunicación: ", ex);
            }
        }
        /// <summary>
        /// Desconectar del wrapper de remoting
        /// </summary>
        public void DesconectarWrapper()
        {
            try
            {
                Conectar(false);
                //Eventos locales.
                //...cambio de dato.
                this._eventWrapper.OrbitaCambioDato -= new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                this._eventWrapper.OrbitaAlarma -= new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                this._eventWrapper.OrbitaComm -= new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato -= new OManejadorEventoComm(_eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma -= new OManejadorEventoComm(_eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm -= new OManejadorEventoComm(_eventWrapper.OnComm);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal DesconectarWrapper Error al desconectar el wrapper del canal de comunicación: ", ex);
            }
        }
        /// <summary>
        /// Conectar al servidor vía Remoting.
        /// </summary>
        /// <param name="estado">Estado de conexión.</param>
        private void Conectar(bool estado)
        {
            try
            {
                string strHostName = "";
                strHostName = System.Net.Dns.GetHostName();
                string canal = ORemoting.GetCanal(strHostName, this.RemotingPuerto.ToString());
                this._servidor.OrbitaConectar(canal, estado);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal Conectar Error al conectar el canal de comunicación: ", ex);
            }
        }
        #endregion Remoting

        /// <summary>
        /// Escritura en el servidor de comunicaciones
        /// </summary>
        /// <param name="idDispositivo">identificador de dispositivo</param>
        /// <param name="variables">variables</param>
        /// <param name="valores">valores</param>
        /// <returns></returns>
        public bool SetEscribirComs(int idDispositivo, string[] variables, object[] valores)
        {
            bool ret = false;
            try
            {
                ret = this._servidor.OrbitaEscribir(idDispositivo, variables, valores);

            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal SetEscribirComs ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Metodo para leer en el Servidor de comunicaciones
        /// </summary>
        /// <param name="idDispositivo">ID de dispositivo</param>
        /// <param name="variables">Nombre de la variable</param>
        /// <returns>Valor leido</returns>
        public object[] GetLeerComs(int idDispositivo, string[] variables)
        {
            object[] ret = null;

            try
            {
                ret = this._servidor.OrbitaLeer(idDispositivo, variables, true);

            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetLeerComs ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las variables del Servidor de comunicaciones
        /// </summary>
        /// <param name="idDispositivo"></param>
        /// <returns></returns>
        public OHashtable GetVariables(int idDispositivo)
        {
            OHashtable ret = null;
            try
            {
                ret = this._servidor.OrbitaGetDatos(idDispositivo);

            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetVariables ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las alarmas del Servidor de comunicaciones
        /// </summary>
        /// <param name="idDispositivo"></param>
        /// <returns></returns>
        public OHashtable GetAlarmas(int idDispositivo)
        {
            OHashtable ret = null;
            try
            {
                ret = this._servidor.OrbitaGetAlarmas(idDispositivo);

            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetAlarmas ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene los dispositivos del Servidor de comunicaciones
        /// </summary>
        /// <returns></returns>
        public int[] GetDispositivos()
        {
            int[] ret = null;

            try
            {
                ret = this._servidor.OrbitaGetDispositivos();
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetDispositivos ", ex);
            }
            return ret;
        }

        #region Hilo Control Canal
        /// <summary>
        /// Iniciamos el hilo del estado del canal
        /// </summary>
        private void IniciarHiloEstadoCanal()
        {
            HilosEstado = new OHilos();
            HilosEstado.OnDespuesAdicionar += new ManejadorEvento(hilos_OnDespuesAdicionar);
            OHilo hiloEsado = HilosEstado.Add(new ThreadStart(GestionEstados), true);
        }
        /// <summary>
        /// Arranca el hilo de lectura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void hilos_OnDespuesAdicionar(object sender, OEventArgs e)
        {
            OHilo hilo = sender as OHilo;

            if (hilo != null)
            {
                hilo.OnDespuesAccion += new ManejadorEvento(hilo_OnDespuesAccion);
                if (hilo.Iniciarlo)
                {
                    hilo.Iniciar();
                }
            }
        }
        /// <summary>
        /// Traza el hilo de lectura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void hilo_OnDespuesAccion(object sender, OEventArgs e)
        {
            //  traza hilo
        }
        /// <summary>
        /// Proceso para la gestión de estados del componente
        /// </summary>
        private void GestionEstados()
        {
            int reintentos = 0;
            OEventArgs arg = new OEventArgs();
            DateTime fechaUltimaRecepcion = DateTime.Now;
            while (true)
            {
                TimeSpan ts = DateTime.Now.Subtract(this._fechaRecepcionMensajeComs);
                if (ts.Seconds > this._segundosReconexion)
                {
                    if (reintentos > _reintentosReconexion)
                    {
                        this._estado = Winsock.WinsockStates.Connecting;
                        this.DesconectarWrapper();
                        this.ConectarWrapper();
                    }
                    else
                    {
                        this._estado = Winsock.WinsockStates.ResolvingHost;
                        reintentos++;
                    }
                }
                else
                {
                    this._estado = Winsock.WinsockStates.Connected;
                    reintentos = 0;
                }

                TimeSpan tsEvento = DateTime.Now.Subtract(fechaUltimaRecepcion);
                if (tsEvento.Seconds > this._segundosEventoEstado)
                {
                    arg.Argumento = this._estado;
                    if (OEventoEstadoCanal != null)
                    {
                        OEventoEstadoCanal(arg, this._nombreCanal);
                    }
                    fechaUltimaRecepcion = DateTime.Now;
                }
                Thread.Sleep(100);
            }
        }
        #endregion Hilo Control Canal

        #region Configuracion Colas
        /// <summary>
        /// Procesa los cambios de dato remotos
        /// </summary>
        void ProcesarHiloColaCambioDato()
        {
            while (true)
            {
                OEventArgs msg = this.DesencolarCambioDato();
                if (msg != null)
                {
                    try
                    {
                        OEventoClienteCambioDato(msg, this._nombreCanal);
                        OInfoDato dato = (OInfoDato)msg.Argumento;
                        OrbitaConfiguracionCanal._wrapper.Info("OrbitaConfiguracionCanal CDato ", dato.Texto);
                    }
                    catch (Exception ex)
                    {
                        OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal ProcesarHiloColaCambioDato: ", ex);
                    }
                }
                else
                {
                    this._eReset.Dormir(0);
                }
            }
        }
        /// <summary>
        /// Desencola los mensajes de la cola de cambio de dato
        /// </summary>
        /// <returns></returns>
        private OEventArgs DesencolarCambioDato()
        {
            // Bloquear la cola sincronizada.
            lock (this._qCambioDato.SyncRoot)
            {
                OEventArgs mensaje = null;
                if (this._qCambioDato.Count > 0)
                {
                    try
                    {
                        mensaje = ((OEventArgs)this._qCambioDato.Dequeue());
                    }
                    catch (Exception ex)
                    {
                        OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal DesencolarCambioDato: ", ex);
                    }
                }
                else
                {
                    this._eReset.Resetear(0);
                }
                return mensaje;
            }
        }
        /// <summary>
        /// Encola los mensajes de cambio de dato
        /// </summary>
        /// <param name="trama"></param>
        private void EncolarCambioDato(OEventArgs trama)
        {
            // Bloquear la cola sincronizada.
            lock (this._qCambioDato.SyncRoot)
            {
                // Encolar la trama de ES recibida.
                OEventArgs e = new OEventArgs();
                e.Argumento = trama.Argumento;

                if (this._qCambioDato.Count == this._bufferCola)
                {
                    this._qCambioDato.Clear();
                }

                this._qCambioDato.Enqueue(e);
                this._eReset.Despertar(0);
            }
        }
        #endregion Configuracion Colas

        #endregion
    }
}