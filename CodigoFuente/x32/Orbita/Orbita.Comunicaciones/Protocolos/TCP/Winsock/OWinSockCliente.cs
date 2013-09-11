using System;
using System.Net.Sockets;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    public class OWinSockCliente
    {
        #region Atributos
        /// <summary>
        /// objeto para establecer el canal TCP
        /// </summary>
        OWinsockBase _winsock;
        /// <summary>
        /// Log de la aplicación
        /// </summary>
        ILogger log;
        /// <summary>
        /// evento para la recepción de datos en el canal
        /// </summary>
        public event OManejadorEventoComm ODataArrival;
        /// <summary>
        /// evento para la recepción de errores en el canal
        /// </summary>
        public event OManejadorEventoComm OErrorReceived;
        /// <summary>
        /// evento para el envío de datos en el canal
        /// </summary>
        public event OManejadorEventoComm OSendComplete;
        /// <summary>
        /// evento para el cambio de estado en el canal
        /// </summary>
        public event OManejadorEventoComm OStateChanged;
        /// <summary>
        /// nombre del canal
        /// </summary>
        string _nombre;
        /// <summary>
        /// Nombre del listener
        /// </summary>
        string _listener;
        /// <summary>
        /// Estado del canal
        /// </summary>
        WinsockStates _estado;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="nombre">nombre del canal</param>
        /// <param name="log"></param>
        public OWinSockCliente(string listener, string nombre, ILogger log)
        {
            this._estado = WinsockStates.Closed;
            this._nombre = nombre;
            this._listener = listener;
            this.log = log;
            this._winsock = new OWinsockBase();
            this._winsock.LegacySupport = true;

            this._winsock.DataArrival += _winsock_DataArrival;
            this._winsock.StateChanged += _winsock_StateChanged;
            this._winsock.SendComplete += _winsock_SendComplete;
            this._winsock.ErrorReceived += _winsock_ErrorReceived;
        }

        #endregion

        #region Métodos públicos
        /// <summary>
        /// Conexión del canal
        /// </summary>
        /// <param name="cliente">socket del cliente</param>
        /// <returns></returns>
        public bool AceptarConexion(Socket cliente)
        {
            bool retorno = false;
            try
            {
                this._winsock.Close();
                this._winsock.Accept(cliente);
                retorno = true;
            }
            catch (Exception ex)
            {
                log.Error(this._nombre + " Error Aceptar Conexión: " + ex);
                retorno = false;
            }
            return retorno;
        }
        /// <summary>
        /// Envia los datos por el canal
        /// </summary>
        /// <param name="data"></param>
        public void Enviar(object data)
        {
            this._winsock.Send(data);
        }
        #endregion

        #region Eventos
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

                dat = _winsock.Get<object>();

                string ret = "";
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, ret);
                mensaje.Data = dat;
                OEventArgs ev = new OEventArgs(mensaje);
                this.ODataArrival(ev);
                log.Debug(this._nombre + " Data Arrival: " + ret);
            }
            catch (Exception ex)
            {
                string error = "Data Arrival Error: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.ODataArrival(ev);
                log.Error(this._nombre + " " + error);
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
                string estado = "State Changed Cliente. Cambia de " + e.Old_State.ToString() + " a " + e.New_State.ToString();
                this._estado = e.New_State;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, estado);
                OEventArgs ev = new OEventArgs(mensaje);
                this.OStateChanged(ev);
                log.Debug(this._nombre + " " + estado);
            }
            catch (Exception ex)
            {
                string error = "State Changed Cliente Error: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.OStateChanged(ev);
                log.Error(this._nombre + " " + error);
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
                string error = "Error Received Cliente: " + e.Message;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.OErrorReceived(ev);
                log.Error(this._nombre + " " + error);
            }
            catch (Exception ex)
            {
                string error = "Error Received Cliente: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.OErrorReceived(ev);
                log.Error(this._nombre + " " + error);
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
                enviado = "Send Complete: " + enviado;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, enviado);
                mensaje.Data = e.DataSent;
                OEventArgs ev = new OEventArgs(mensaje);
                this.OSendComplete(ev);
                log.Debug(this._nombre + " " + enviado);
            }
            catch (Exception ex)
            {
                string error = "Send Complete Error: " + ex;
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.OSendComplete(ev);
                log.Error(this._nombre + " " + error);
            }
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// nombre del listener
        /// </summary>
        public string Listener
        {
            get { return _listener; }
            set { _listener = value; }
        }
        /// <summary>
        /// Estado del canal
        /// </summary>
        public WinsockStates Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        #endregion
    }
}