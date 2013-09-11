using System;
using System.Collections;
using System.Linq;
using System.Text;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Winsock;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    public class OTCPListenerBase
    {
        #region Atributos
        /// <summary>
        /// Objeto para establecer el canal TCP principal
        /// </summary>
        OWinsockBase _winsockListener;
        /// <summary>
        /// Log de la aplicación
        /// </summary>
        ILogger _log;
        /// <summary>
        /// Pool de clientes
        /// </summary>
        Hashtable _poolCliente;
        /// <summary>
        /// Evento Listener para petición de conexión
        /// </summary>
        public event OManejadorEventoComm WskConnectionRequest;
        /// <summary>
        /// Evento Listener para canvio de estado
        /// </summary>
        public event OManejadorEventoComm WskStateChanged;
        /// <summary>
        /// Evento Listener para error de recepción
        /// </summary>
        public event OManejadorEventoComm WskErrorReceived;
        /// <summary>
        /// Evento Cliente Listener para recepción de datos
        /// </summary>
        public event OManejadorEventoComm WskClientDataArrival;
        /// <summary>
        /// Evento Cliente Listener para error de recepción
        /// </summary>
        public event OManejadorEventoComm WskClientErrorReceived;
        /// <summary>
        /// Evento Cliente Listener para send complete
        /// </summary>
        public event OManejadorEventoComm WskClientSendComplete;
        /// <summary>
        /// Evento Cliente Listener para cambio de estado
        /// </summary>
        public event OManejadorEventoComm WskClientStateChanged;
        /// <summary>
        /// Puerto TCP
        /// </summary>
        int _puerto;
        /// <summary>
        /// Nombre del canal
        /// </summary>
        string _nombre;
        /// <summary>
        /// Estado del listener
        /// </summary>
        WinsockStates _estadoListener;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public OTCPListenerBase(ILogger log, int puerto, string nombre)
        {
            _log = log;
            this._puerto = puerto;
            this._nombre = nombre;
            this.Inicializar();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Inicializa las variables de la comunicación TCP
        /// </summary>
        private void Inicializar()
        {
            this._estadoListener = WinsockStates.Closed;
            this._poolCliente = new Hashtable();
            this._winsockListener = new OWinsockBase();
            this._winsockListener.LegacySupport = true;

            this._winsockListener.ConnectionRequest += new IWinsock.ConnectionRequestEventHandler(this._wskListener_ConnectionRequest);
            this._winsockListener.StateChanged += new IWinsock.StateChangedEventHandler(this._wskListener_StateChanged);
            this._winsockListener.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(this._wskListener_ErrorReceived);

            this._winsockListener.LocalPort = this._puerto;
            this._winsockListener.Listen();
        }

        public WinsockStates GetEstadoCanal(string ip)
        {
            WinsockStates retorno = WinsockStates.Closed;
            if (this._poolCliente.Contains(ip))
            {
                OWinSockCliente wks = (OWinSockCliente)this._poolCliente[ip];
                retorno = wks.Estado;
            }

            return retorno;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Indica que el objeto winsock principal ha cambiado de estado. Trazabilidad del canal.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _wskListener_StateChanged(object sender, WinsockStateChangedEventArgs e)
        {
            try
            {
                OWinsockBase winsock = (OWinsockBase)sender;
                int puerto = winsock.LocalPort;
                string estado = "State Changed: Cambia de " + e.Old_State.ToString() + " a " + e.New_State.ToString();
                this._estadoListener = e.New_State;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", estado);
                OEventArgs ev = new OEventArgs(mensaje);
                if (WskStateChanged != null)
                {
                    this.WskStateChanged(ev);
                }

                _log.Debug(this._nombre + " " + estado);
            }
            catch (Exception ex)
            {
                string error = "State Changed Error: " + ex.ToString();
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                if (WskStateChanged != null)
                {
                    this.WskStateChanged(ev);
                }
                _log.Error(this._nombre + " " + error);
            }
        }
        /// <summary>
        /// Indica que se ha conectado un cliente al canal principal
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _wskListener_ConnectionRequest(object sender, WinsockConnectionRequestEventArgs e)
        {
            try
            {
                if (e.ClientIP == "bad IP")
                {
                    string error = "Connection Request Bad IP";
                    OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", error);
                    OEventArgs ev = new OEventArgs(mensaje);
                    this.WskConnectionRequest(ev);
                    _log.Error(this._nombre + " " + error);
                    e.Cancel = true;
                }

                string ip = e.ClientIP;
                OWinSockCliente winsockCliente = null;

                if (!this._poolCliente.ContainsKey(ip))
                {
                    winsockCliente = new OWinSockCliente(this._nombre, ip + ":" + this._puerto, _log);

                    winsockCliente.ODataArrival += new OManejadorEventoComm(_winsockCliente_ODataArrival);
                    winsockCliente.OErrorReceived += new OManejadorEventoComm(_winsockCliente_OErrorReceived);
                    winsockCliente.OSendComplete += new OManejadorEventoComm(_winsockCliente_OSendComplete);
                    winsockCliente.OStateChanged += new OManejadorEventoComm(_winsockCliente_OStateChanged);

                    this._poolCliente.Add(ip, winsockCliente);
                }
                else
                {
                    foreach (DictionaryEntry item in this._poolCliente)
                    {
                        if (item.Key.ToString() == ip)
                        {
                            winsockCliente = (OWinSockCliente)item.Value;
                        }
                    }
                }

                if (!winsockCliente.AceptarConexion(e.Client))
                {
                    string error = this._nombre + " Connection Request no se pudo establecer la conexión con la IP " + ip;
                    OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", error);
                    OEventArgs ev = new OEventArgs(mensaje);
                    this.WskConnectionRequest(ev);
                    _log.Error(this._nombre + " " + error);
                }
                else
                {
                    string conexion = this._nombre + " Connection Request " + e.ClientIP.ToString() + " EndPoint " + e.Client.RemoteEndPoint.ToString();
                    OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", conexion);
                    OEventArgs ev = new OEventArgs(mensaje);
                    this.WskConnectionRequest(ev);
                    _log.Debug(this._nombre + " " + conexion);
                }
            }
            catch (Exception ex)
            {
                string error = "Connection Request Error: " + ex.ToString();
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.WskConnectionRequest(ev);
                _log.Error(this._nombre + " " + error);
            }

        }
        /// <summary>
        /// Evento de errores en la comunicación TCP
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void _wskListener_ErrorReceived(object sender, WinsockErrorReceivedEventArgs e)
        {
            try
            {
                string error = "Error Received: " + e.Message;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.WskErrorReceived(ev);
                _log.Error(this._nombre + " " + error);
            }
            catch (Exception ex)
            {
                string error = "Error Received: " + ex.ToString();
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.WskErrorReceived(ev);
                _log.Error(this._nombre + " " + error);
            }
        }

        #region Eventos Cliente
        /// <summary>
        /// Cambio de estado en el canal TCP
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        void _winsockCliente_OStateChanged(Orbita.Utiles.OEventArgs e)
        {
            this.WskClientStateChanged(e);
        }
        /// <summary>
        /// Envío de datos en el canal TCP
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        void _winsockCliente_OSendComplete(Orbita.Utiles.OEventArgs e)
        {
            this.WskClientSendComplete(e);
        }
        /// <summary>
        /// Error en el canal TCP
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        void _winsockCliente_OErrorReceived(Orbita.Utiles.OEventArgs e)
        {
            this.WskClientErrorReceived(e);
        }
        /// <summary>
        /// Datos de recepción en el canal TCP
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        void _winsockCliente_ODataArrival(Orbita.Utiles.OEventArgs e)
        {
            this.WskClientDataArrival(e);
        }
        #endregion

        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de canales
        /// </summary>
        public Hashtable PoolCliente
        {
            get { return _poolCliente; }
            set { _poolCliente = value; }
        }
        /// <summary>
        /// Puerto TCP
        /// </summary>
        public int Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }
        /// <summary>
        /// Nombre del canal
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public WinsockStates EstadoListener
        {
            get { return _estadoListener; }
            set { _estadoListener = value; }
        }
        #endregion
    }
}
