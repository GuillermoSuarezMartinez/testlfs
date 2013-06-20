using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Clase base para los controles de comunicaciones con el servidor de comunicaciones
    /// </summary>
    public partial class OrbitaTCPServidor : UserControl
    {
        #region Variables
        /// <summary>
        /// delegado para la escritura
        /// </summary>
        /// <param name="Elemento"></param>
        internal delegate void Delegado(string Elemento);
        /// <summary>
        /// Listener principal
        /// </summary>
        OTCPListener _listenerPrincipal;
        /// <summary>
        /// Log de la aplicación
        /// </summary>
        ILogger _logPrincipal;
        /// <summary>
        /// Colección de hilos.
        /// </summary>
        OHilos hilos;
        /// <summary>
        /// Fecha del último envío al cliente
        /// </summary>
        DateTime fechaUltimoEnvio;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public OrbitaTCPServidor()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Inicializa las variables de la comunicación TCP
        /// </summary>
        private void Inicializar()
        {
            _logPrincipal = LogManager.SetDebugLogger("loggerPrincipal", NivelLog.Debug);
            this._listenerPrincipal = new OTCPListener(_logPrincipal, Convert.ToInt32(this.txtPuerto.Text), "Principal");
            this._listenerPrincipal.WskConnectionRequest += new OManejadorEventoComm(_listenerPrincipal_WskConnectionRequest);
            this._listenerPrincipal.WskErrorReceived += new OManejadorEventoComm(_listenerPrincipal_WskErrorReceived);
            this._listenerPrincipal.WskStateChanged += new OManejadorEventoComm(_listenerPrincipal_WskStateChanged);
            this._listenerPrincipal.WskClientDataArrival += new OManejadorEventoComm(_listenerPrincipal_WskClientDataArrival);
            this._listenerPrincipal.WskClientErrorReceived += new OManejadorEventoComm(_listenerPrincipal_WskClientErrorReceived);
            this._listenerPrincipal.WskClientSendComplete += new OManejadorEventoComm(_listenerPrincipal_WskClientSendComplete);
            this._listenerPrincipal.WskClientStateChanged += new OManejadorEventoComm(_listenerPrincipal_WskClientStateChanged);
            fechaUltimoEnvio = DateTime.Now;
        }
        /// <summary>
        /// Obtiene el canal cliente de la conexión
        /// </summary>
        /// <param name="pool">Colección de canales</param>
        /// <returns></returns>
        private OWinSockCliente[] GetClientes(Hashtable pool)
        {
            OWinSockCliente[] winsock = new OWinSockCliente[pool.Count];
            int i = 0;
            foreach (DictionaryEntry item in pool)
            {
                winsock[i] = (OWinSockCliente)item.Value;
                i++;
            }


            return winsock;
        }
        /// <summary>
        /// Enviar el mensaje a pantalla
        /// </summary>
        /// <param name="e">parametros del evento</param>
        private void EnviarMensaje(OEventArgs e)
        {
            OMensajeCanalTCP mensaje = (OMensajeCanalTCP)e.Argumento;

            this.EscribirMensaje(mensaje.Mensaje);
        }

        #region Hilo Vida
        private void InicHiloVida()
        {
            hilos = new OHilos();
            hilos.OnDespuesAdicionar += new ManejadorEvento(hilos_OnDespuesAdicionar);
            OHilo hilo = hilos.Add(new ThreadStart(ProcesarHiloVida), true);
            hilo.Iniciar();
        }

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

        void hilo_OnDespuesAccion(object sender, OEventArgs e)
        {
            //traza hilo
        }

        private void ProcesarHiloVida()
        {
            while (true)
            {
                DateTime fechaActual = DateTime.Now;
                TimeSpan t = fechaActual.Subtract(this.fechaUltimoEnvio);
                if (t.TotalSeconds > 60)
                {
                    //try
                    //{

                    //}
                    //catch (Exception ex)
                    //{

                    //}
                    this.fechaUltimoEnvio = DateTime.Now;
                }
                Thread.Sleep(1000);
            }
        }
        #endregion

        #endregion

        #region Eventos

        /// <summary>
        /// Mensaje desde el listener principal
        /// </summary>
        /// <param name="e">parametro del mensaje</param>
        void _listenerPrincipal_WskClientStateChanged(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        void _listenerPrincipal_WskClientSendComplete(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        void _listenerPrincipal_WskClientErrorReceived(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        void _listenerPrincipal_WskClientDataArrival(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        void _listenerPrincipal_WskStateChanged(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        void _listenerPrincipal_WskErrorReceived(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        void _listenerPrincipal_WskConnectionRequest(OEventArgs e)
        {
            this.EnviarMensaje(e);
        }

        #endregion

        #region Eventos Control

        /// <summary>
        /// Escribe el mensaje por pantalla
        /// </summary>
        /// <param name="mensaje"></param>
        private void EscribirMensaje(string mensaje)
        {
            try
            {
                if (this.txtRecepcionDatos.InvokeRequired)
                {
                    Delegado MyDelegado = new Delegado(EscribirMensaje);
                    this.Invoke(MyDelegado, new object[] { mensaje });
                }
                else
                {
                    this.txtRecepcionDatos.Text += "\n" + mensaje;
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error: " + ex.ToString());
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(this.txtPuerto.Text);
                this.Inicializar();
            }
            catch (Exception ex)
            {
                OMensajes.MostrarAviso("No se puede iniciar la aplicación: " + ex.ToString());
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                OWinSockCliente[] winsock = this.GetClientes(this._listenerPrincipal.PoolCliente);

                for (int i = 0; i < winsock.Length; i++)
                {
                    winsock[i].Enviar(this.txtEnvioDatos.Text);
                }

            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error al enviar mensaje: " + ex.ToString());
            }
        }
        #endregion
    }
}