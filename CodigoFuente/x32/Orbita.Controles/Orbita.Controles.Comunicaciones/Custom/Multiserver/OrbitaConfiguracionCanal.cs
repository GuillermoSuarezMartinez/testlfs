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

    public delegate void EventoCanalTCP(OEventArgs e);
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
        /// Segundos para el evento de estado
        /// </summary>
        private int _segundosEventoEstado;
        /// <summary>
        /// Ruta del logger
        /// </summary>
        private string _nombreLogger;
        /// <summary>
        /// Servidor de remoting
        /// </summary>
        OClienteTCPRemoting remoting;
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
                if (OEventoClienteCambioDato!=null)
                {
                    OEventoClienteCambioDato(e, this._nombreCanal);
                }               
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal eventWrapper_OrbitaCambioDato: ", ex);
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
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal eventWrapper_OrbitaAlarma: ", ex);
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

                if (OEventoClienteComs!=null)
                {
                    OEventoClienteComs(e, this._nombreCanal); 
                }                                               
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal eventWrapper_OrbitaComm: ", ex);
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
                _wrapper = LogManager.GetLogger("wrapperCanal");
                OrbitaConfiguracionCanal._wrapper.Info("Log creado");                
                // Establecer la configuración Remoting entre procesos.                
                this.remoting = new OClienteTCPRemoting(this._remotingServidor, this._remotingPuerto, _wrapper);
                remoting.OEventoTCPCambioDato += new EventoCanalTCP(eventWrapper_OrbitaCambioDato);
                remoting.OEventoTCPAlarma += new EventoCanalTCP(eventWrapper_OrbitaAlarma);
                remoting.OEventoTCPComunicaciones += new EventoCanalTCP(eventWrapper_OrbitaComm);
                remoting.Inicializar();
                this.IniciarHiloEstadoCanal();
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal Iniciar: ", ex);
            }
        }
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
                ret = this.remoting.SetValores(idDispositivo, variables, valores);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal SetEscribirComs: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Metodo para leer en el Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <returns>Valor leido</returns>
        public object[] GetLeerComs(int idDispositivo, string[] variables)
        {
            object[] ret = null;

            try
            {
                ret = this.remoting.GetValores(idDispositivo, variables);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetLeerComs: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las variables del Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable GetVariables(int idDispositivo)
        {
            OHashtable ret = null;

            try
            {
                ret = this.remoting.GetVariables(idDispositivo);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetVariables: ", ex);
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las alarmas del Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable GetAlarmas(int idDispositivo)
        {
            OHashtable ret = null;

            try
            {
                ret = this.remoting.GetAlarmas(idDispositivo);
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetAlarmas: ", ex);
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
                ret = this.remoting.GetDispositivos();
            }
            catch (Exception ex)
            {
                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GetDispositivos: ", ex);
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
            //traza hilo
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
                        if (this.remoting.Estado!=Winsock.WinsockStates.Connected)
                        {
                            try
                            {
                                this.remoting.Conectar();
                            }
                            catch (Exception ex)
                            {
                                OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GestionEstados: ", ex);
                            }
                        }
                        else
                        {
                            OrbitaConfiguracionCanal._wrapper.Error("OrbitaConfiguracionCanal GestionEstados: canal conectado sin recepción de eventos del servidor ");
                        }
                    }
                    else
                    {
                        reintentos++;
                    }
                }
                else
                {
                    reintentos = 0;
                }

                TimeSpan tsEvento = DateTime.Now.Subtract(fechaUltimaRecepcion);

                if (tsEvento.Seconds > this._segundosEventoEstado)
                {
                    arg.Argumento = this.remoting.Estado;
                    if (OEventoEstadoCanal != null)
                    {
                        OEventoEstadoCanal(arg, this._nombreCanal);
                    }
                    fechaUltimaRecepcion = DateTime.Now;
                }

                Thread.Sleep(100);
            }
        }

        #endregion

        #endregion
    }
}