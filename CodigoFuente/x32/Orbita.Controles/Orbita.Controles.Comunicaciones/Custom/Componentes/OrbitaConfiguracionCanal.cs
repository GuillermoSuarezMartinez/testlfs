using System;
using System.ComponentModel;
using Orbita.Comunicaciones;
using Orbita.Utiles;
using Orbita.Trazabilidad;
using System.Windows.Forms;
using System.Threading;

namespace Orbita.Controles.Comunicaciones
{
    #region Delegados

    public delegate void EventoClienteComs(OEventArgs e, string canal);
    public delegate void EventoClienteCambioDato(OEventArgs e, string canal);
    public delegate void EventoClienteAlarma(OEventArgs e, string canal);
    public delegate void EventoClienteEstadoCabal(OEventArgs e, string canal);

    #endregion

    #region Enumeración

    enum OEstadoCanalCliente
    {
        Conectado,
        PendienteReconectar,
        Reconectando
    }

    #endregion

    public partial class OrbitaConfiguracionCanal : Component
    {

        #region Variables

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
        private string _servidorRemoting = "localhost";
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
        /// Argumento mensaje de comunicaciones
        /// </summary>
        private OEventArgs _argumentoMensajeComs;
        /// <summary>
        /// Segundos para la reconexión del canal
        /// </summary>
        private int _segundosReconexion;
        /// <summary>
        /// Reintentos antes de empezar la reconexión
        /// </summary>
        private int _reintentosReconexion;
        /// <summary>
        /// Estado canal
        /// </summary>
        private OEstadoCanalCliente _estado;
        /// <summary>
        /// Segundos para el evento de estado
        /// </summary>
        private int _segundosEventoEstado;
        /// <summary>
        /// Ruta del logger
        /// </summary>
        private string _nombreLogger;
        
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
            get { return _servidorRemoting; }
            set { _servidorRemoting = value; }
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
        /// Estado canal
        /// </summary>
        internal OEstadoCanalCliente Estado
        {
            get { return _estado; }
            set { _estado = value; }
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
        #endregion

        #region Eventos

        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e"></param>
        public virtual void eventWrapper_OrbitaCambioDato(OEventArgs e)
        {
            try
            {
                OEventoClienteCambioDato(e, this._nombreCanal);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error en eventWrapper_OrbitaCambioDato: ", ex);
            }

        }
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        /// <param name="e"></param>
        void eventWrapper_OrbitaAlarma(OEventArgs e)
        {
            try
            {
                OEventoClienteAlarma(e, this._nombreCanal);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error en eventWrapper_OrbitaAlarma: ", ex);
            }

        }
        /// <summary>
        /// Evento de comunicaciones.
        /// </summary>
        /// <param name="e"></param>
        public void eventWrapper_OrbitaComm(OEventArgs e)
        {
            try
            {
                OEventoClienteComs(e, this._nombreCanal);
                this._fechaRecepcionMensajeComs = DateTime.Now;
                this._argumentoMensajeComs = e;
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error en eventWrapper_OrbitaComm: ", ex);
            }
        }

        #endregion

        public OrbitaConfiguracionCanal()
        {
            InitializeComponent();
        }

        public OrbitaConfiguracionCanal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        /// Incia las comunicaciones con el dispositivo remoto
        /// </summary>
        public void Iniciar()
        {
            try
            {
                LogManager.ConfiguracionLogger(Application.StartupPath + @"\" + this._nombreLogger + ".xml");
                _wrapper = LogManager.GetLogger("wrapper");
                OrbitaConfiguracionCanal._wrapper.Info("Log creado");
                this.IniciarHiloEstadoCanal();
                // Establecer la configuración Remoting entre procesos.
                ORemoting.InicConfiguracionCliente(this._remotingPuerto, this._servidorRemoting);
                this._servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));
                this.ConectarWrapper();
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al iniciar el canal de comunicación: ", ex);
            }
        }
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
                OrbitaConfiguracionCanal._wrapper.Error("Error al conectar el wrapper del canal de comunicación: ", ex);
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
                OrbitaConfiguracionCanal._wrapper.Error("Error al desconectar el wrapper del canal de comunicación: ", ex);
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

                string canal = "canal" + strHostName + ":" + this._remotingPuerto.ToString();
                this._servidor.OrbitaConectar(canal, estado);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al conectar el canal de comunicación: ", ex);
            }

        }
        /// <summary>
        /// Metodo para escribir en el Servidor de Comunicaciones
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <param name="valor">Valor a escribir</param>
        public bool EscribirComs(int idDispositivo, string[] variables, object[] valores)
        {
            bool ret = false;
            try
            {
                ret = this._servidor.OrbitaEscribir(idDispositivo, variables, valores);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al escribir en el servidor de comunicaciones: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Metodo para leer en el Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <returns>Valor leido</returns>
        public object[] LeerComs(int idDispositivo, string[] variables)
        {
            object[] ret = null;

            try
            {
                ret = this._servidor.OrbitaLeer(idDispositivo, variables, true);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al leer del servidor de comunicaciones: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las variables del Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable Variables(int idDispositivo)
        {
            OHashtable ret = null;

            try
            {
                ret = this._servidor.OrbitaGetDatos(idDispositivo);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al obtener las variables del servidor de comunicaciones: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las alarmas del Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable Alarmas(int idDispositivo)
        {
            OHashtable ret = null;

            try
            {
                ret = this._servidor.OrbitaGetAlarmas(idDispositivo);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al obtener las alarmas del servidor de comunicaciones: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene los dispositivos del Servidor de comunicaciones
        /// </summary>
        /// <returns></returns>
        public int[] Dispositivos()
        {
            int[] ret = null;

            try
            {
                ret = this._servidor.OrbitaGetDispositivos();
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("Error al obtener los dispositivos del servidor de comunicaciones: ", ex);
            }
            return ret;
        }
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
            //traza hilo
        }
        /// <summary>
        /// Proceso para la gestión de estados del componente
        /// </summary>
        private void GestionEstados()
        {
            int reintentos = 0;
            this._estado = OEstadoCanalCliente.Conectado;
            OEventArgs arg = new OEventArgs();
            DateTime fechaUltimaRecepcion = DateTime.Now;

            while (true)
            {
                TimeSpan ts = DateTime.Now.Subtract(this._fechaRecepcionMensajeComs);

                if (ts.Seconds > this._segundosReconexion)
                {
                    if (reintentos > _reintentosReconexion)
                    {
                        this._estado = OEstadoCanalCliente.Reconectando;
                        this.DesconectarWrapper();
                        this.ConectarWrapper();
                    }
                    else
                    {
                        this._estado = OEstadoCanalCliente.PendienteReconectar;
                        reintentos++;
                    }
                }
                else
                {
                    this._estado = OEstadoCanalCliente.Conectado;
                    reintentos = 0;
                }

                TimeSpan tsEvento = DateTime.Now.Subtract(fechaUltimaRecepcion);

                if (tsEvento.Seconds > this._segundosEventoEstado)
                {
                    arg.Argumento = this._estado;
                    OEventoEstadoCanal(arg, this._nombreCanal);
                    fechaUltimaRecepcion = DateTime.Now;
                }

                Thread.Sleep(100);
            }
        }

        #endregion
    }
}