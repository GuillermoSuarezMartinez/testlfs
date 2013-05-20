using System;
using System.Windows.Forms;
using Orbita.Trazabilidad;
using Orbita.Winsock;

namespace WindowsFormsApplication1
{
    public class OrbitaClienteTCP
    {

        #region Variables
        /// <summary>
        /// Objeto para establecer el canal TCP
        /// </summary>
        OWinsockBase _winsock;
        /// <summary>
        /// Log de la aplicación
        /// </summary>
        ILogger _log;
        /// <summary>
        /// Servidor de conexión
        /// </summary>
        string _servidor;
        /// <summary>
        /// Puerto de conexión
        /// </summary>
        int _puerto;
        #endregion

        /// <summary>
        /// Cosntructor del control
        /// </summary>
        public OrbitaClienteTCP(string servidor, int puerto, ILogger log)
        {
            this._servidor= servidor;
            this._puerto= puerto;
            this._log = log;
        }

        #region Metodos
        /// <summary>
        /// Inicializa las variables de la comunicación TCP
        /// </summary>
        private void Inicializar()
        {
            try
            {
                this._winsock = new OWinsockBase();
                this._winsock.LegacySupport = true;

                this._winsock.DataArrival += new IWinsock.DataArrivalEventHandler(_winsock_DataArrival);
                this._winsock.StateChanged += new IWinsock.StateChangedEventHandler(_winsock_StateChanged);
                this._winsock.SendComplete += new IWinsock.SendCompleteEventHandler(_winsock_SendComplete);
                this._winsock.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsock_ErrorReceived);

                this.Conectar();
            }
            catch (Exception ex)
            {
                this._log.Error("Error Inicializar: ", ex);
            }
        }
        /// <summary>
        /// Conecta con el servidor TCP
        /// </summary>
        private void Conectar()
        {
            this._winsock.Connect(this._servidor, this._puerto);
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
                byte[] recibido = (byte[])dat;
                if (recibido != null)
                {
                    for (int i = 0; i < recibido.Length; i++)
                    {
                        ret += "[" + recibido[i].ToString() + "]";
                    }
                }
                this._log.Debug("recibido; " + ret);

            }
            catch (Exception ex)
            {
                string error = "Error Data Arrival: " + ex.ToString();
                this._log.Error(error);
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
                this._log.Debug("Enviado; " + enviado);

            }
            catch (Exception ex)
            {
                string error = "Error Send Complete: " + ex.ToString();
                this._log.Error(error);
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
                string estado = "State Changed. Cambia de " + e.Old_State.ToString() + " a " + e.New_State.ToString();
                this._log.Debug(estado);
            }
            catch (Exception ex)
            {
                string error = "Error State Changed: " + ex.ToString();
                this._log.Error(error);
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
                string error = "Error Received: " + e.Message;
                this._log.Error(error);
            }
            catch (Exception ex)
            {
                string error = "Error Received: " + ex.ToString();
                this._log.Error(error);
            }
        }
        #endregion

    }
}
