using System;
using System.Collections;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    public class OTCPListener
    {
        #region Eventos
        /// <summary>
        /// Evento Listener para petición de conexión.
        /// </summary>
        public event OManejadorEventoComm WskConnectionRequest;
        /// <summary>
        /// Evento Listener para canvio de estado.
        /// </summary>
        public event OManejadorEventoComm WskStateChanged;
        /// <summary>
        /// Evento Listener para error de recepción.
        /// </summary>
        public event OManejadorEventoComm WskErrorReceived;
        /// <summary>
        /// Evento Cliente Listener para recepción de datos.
        /// </summary>
        public event OManejadorEventoComm WskClientDataArrival;
        /// <summary>
        /// Evento Cliente Listener para error de recepción.
        /// </summary>
        public event OManejadorEventoComm WskClientErrorReceived;
        /// <summary>
        /// Evento Cliente Listener para send complete.
        /// </summary>
        public event OManejadorEventoComm WskClientSendComplete;
        /// <summary>
        /// Evento Cliente Listener para cambio de estado.
        /// </summary>
        public event OManejadorEventoComm WskClientStateChanged;
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto para establecer el canal Tcp principal.
        /// </summary>
        private OWinsockBase _winsockListener;
        /// <summary>
        /// Log de la aplicación.
        /// </summary>
        private readonly ILogger _log;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public OTCPListener(ILogger log, int puerto, string nombre)
        {
            _log = log;
            this.Puerto = puerto;
            this.Nombre = nombre;
            this.Inicializar();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de canales.
        /// </summary>
        public Hashtable PoolCliente { get; set; }
        /// <summary>
        /// Puerto TCP.
        /// </summary>
        public int Puerto { get; set; }
        /// <summary>
        /// Nombre del canal.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Estado del listener.
        /// </summary>
        public WinsockStates EstadoListener { get; set; }
        #endregion

        #region Metodos
        /// <summary>
        /// Inicializa las variables de la comunicación Tcp.
        /// </summary>
        private void Inicializar()
        {
            this.EstadoListener = WinsockStates.Closed;
            this.PoolCliente = new Hashtable();
            this._winsockListener = new OWinsockBase { LegacySupport = true };

            this._winsockListener.ConnectionRequest += this.WskListener_ConnectionRequest;
            this._winsockListener.StateChanged += this.WskListener_StateChanged;
            this._winsockListener.ErrorReceived += this.wskListener_ErrorReceived;

            this._winsockListener.LocalPort = this.Puerto;
            this._winsockListener.Listen();
        }
        /// <summary>
        /// Obtener el estado del canal.
        /// </summary>
        /// <param name="direccionIp"></param>
        /// <returns></returns>
        public WinsockStates GetEstadoCanal(string direccionIp)
        {
            WinsockStates retorno = WinsockStates.Closed;
            if (this.PoolCliente.Contains(direccionIp))
            {
                OWinSockCliente wks = (OWinSockCliente)this.PoolCliente[direccionIp];
                retorno = wks.Estado;
            }
            return retorno;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Indica que el objeto winsock principal ha cambiado de estado. Trazabilidad del canal.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void WskListener_StateChanged(object sender, WinsockStateChangedEventArgs e)
        {
            try
            {
                string estado = "State Changed: Cambia de " + e.Old_State + " a " + e.New_State;
                this.EstadoListener = e.New_State;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", estado);
                OEventArgs ev = new OEventArgs(mensaje);
                if (WskStateChanged != null)
                {
                    this.WskStateChanged(ev);
                }
                _log.Debug(this.Nombre + " " + estado);
            }
            catch (Exception ex)
            {
                string error = "State Changed Error: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                if (WskStateChanged != null)
                {
                    this.WskStateChanged(ev);
                }
                _log.Error(this.Nombre + " " + error);
            }
        }
        /// <summary>
        /// Indica que se ha conectado un cliente al canal principal.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void WskListener_ConnectionRequest(object sender, WinsockConnectionRequestEventArgs e)
        {
            try
            {
                if (e.ClientIP == "bad IP")
                {
                    const string error = "Connection Request Bad IP";
                    OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", error);
                    OEventArgs ev = new OEventArgs(mensaje);
                    this.WskConnectionRequest(ev);
                    _log.Error(this.Nombre + " " + error);
                    e.Cancel = true;
                }

                string ip = e.ClientIP;
                OWinSockCliente winsockCliente = null;

                if (!this.PoolCliente.ContainsKey(ip))
                {
                    winsockCliente = new OWinSockCliente(this.Nombre, ip + ":" + this.Puerto, _log);
                    winsockCliente.ODataArrival += _winsockCliente_ODataArrival;
                    winsockCliente.OErrorReceived += _winsockCliente_OErrorReceived;
                    winsockCliente.OSendComplete += _winsockCliente_OSendComplete;
                    winsockCliente.OStateChanged += _winsockCliente_OStateChanged;
                    this.PoolCliente.Add(ip, winsockCliente);
                }
                else
                {
                    foreach (DictionaryEntry item in this.PoolCliente)
                    {
                        if (item.Key.ToString() == ip)
                        {
                            winsockCliente = (OWinSockCliente)item.Value;
                        }
                    }
                }

                if (!winsockCliente.AceptarConexion(e.Client))
                {
                    string error = this.Nombre + " Connection Request no se pudo establecer la conexión con la IP " + ip;
                    OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", error);
                    OEventArgs ev = new OEventArgs(mensaje);
                    if (this.WskConnectionRequest != null)
                    {
                        this.WskConnectionRequest(ev);
                    }
                    _log.Error(this.Nombre + " " + error);
                }
                else
                {
                    string conexion = this.Nombre + " Connection Request " + e.ClientIP.ToString() + " EndPoint " + e.Client.RemoteEndPoint.ToString();
                    OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", conexion);
                    OEventArgs ev = new OEventArgs(mensaje);
                    if (this.WskConnectionRequest != null)
                    {
                        this.WskConnectionRequest(ev);
                    }
                    _log.Debug(this.Nombre + " " + conexion);
                }
            }
            catch (Exception ex)
            {
                string error = "Connection Request Error: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                if (this.WskConnectionRequest != null)
                {
                    this.WskConnectionRequest(ev);
                }
                _log.Error(this.Nombre + " " + error);
            }
        }
        /// <summary>
        /// Evento de errores en la comunicación TCP.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void wskListener_ErrorReceived(object sender, WinsockErrorReceivedEventArgs e)
        {
            try
            {
                string error = "Error Received: " + e.Message;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                if (this.WskErrorReceived != null)
                {
                    this.WskErrorReceived(ev);
                }
                _log.Error(this.Nombre + " " + error);
            }
            catch (Exception ex)
            {
                string error = "Error Received: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this.Nombre, "", error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.WskErrorReceived(ev);
                _log.Error(this.Nombre + " " + error);
            }
        }

        #region Eventos Cliente
        /// <summary>
        /// Cambio de estado en el canal TCP.
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        private void _winsockCliente_OStateChanged(OEventArgs e)
        {
            if (this.WskClientStateChanged != null)
            {
                this.WskClientStateChanged(e);
            }
        }
        /// <summary>
        /// Envío de datos en el canal TCP.
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        private void _winsockCliente_OSendComplete(OEventArgs e)
        {
            if (this.WskClientSendComplete != null)
            {
                this.WskClientSendComplete(e);
            }
        }
        /// <summary>
        /// Error en el canal TCP.
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        private void _winsockCliente_OErrorReceived(OEventArgs e)
        {
            if (this.WskClientSendComplete != null)
            {
                this.WskClientErrorReceived(e);
            }
        }
        /// <summary>
        /// Datos de recepción en el canal TCP.
        /// </summary>
        /// <param name="e">Argumento del objeto cliente</param>
        private void _winsockCliente_ODataArrival(OEventArgs e)
        {
            if (this.WskClientSendComplete != null)
            {
                this.WskClientDataArrival(e);
            }
        }
        #endregion

        #endregion
    }
}