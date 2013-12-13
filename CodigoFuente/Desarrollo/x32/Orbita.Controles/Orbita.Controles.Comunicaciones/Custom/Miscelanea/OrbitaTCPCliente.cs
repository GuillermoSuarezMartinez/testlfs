using System;
using System.Windows.Forms;
using Orbita.Trazabilidad;
using Orbita.Winsock;
namespace Orbita.Controles.Comunicaciones.Custom
{
    /// <summary>
    /// Código base para clientes TCP
    /// </summary>
    public partial class OrbitaTCPCliente : UserControl
    {
        #region Atributos
        /// <summary>
        /// Objeto para establecer el canal TCP
        /// </summary>
        OWinsockBase _winsock;
        /// <summary>
        /// Log de la aplicación
        /// </summary>
        ILogger log;
        #endregion

        /// <summary>
        /// Cosntructor del control
        /// </summary>
        public OrbitaTCPCliente()
        {
            InitializeComponent();
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

                log = LogManager.SetDebugLogger("logger", NivelLog.Debug);

                this._winsock.DataArrival += new IWinsock.DataArrivalEventHandler(_winsock_DataArrival);
                this._winsock.StateChanged += new IWinsock.StateChangedEventHandler(_winsock_StateChanged);
                this._winsock.SendComplete += new IWinsock.SendCompleteEventHandler(_winsock_SendComplete);
                this._winsock.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsock_ErrorReceived);

                this.Conectar();
            }
            catch (Exception ex)
            {
                log.Error("Error Inicializar: ", ex);
            }
        }
        /// <summary>
        /// Conecta con el servidor TCP
        /// </summary>
        private void Conectar()
        {
            string IP = this.txtIP.Text;
            int Puerto = Convert.ToInt32(this.txtPuerto.Text);

            this._winsock.Connect(IP, Puerto);
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
                log.Debug("recibido; " + ret);

                this.txtRecepcionDatos.Text += "\n" + "Data Arrival: " + ret;
            }
            catch (Exception ex)
            {
                string error = "Error Data Arrival: " + ex.ToString();
                this.txtRecepcionDatos.Text += "\n" + error;
                log.Error(error);
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
                log.Debug("Enviado; " + enviado);

                this.txtEnvioDatos.Text += "\n" + "Send Complete: " + enviado;

            }
            catch (Exception ex)
            {
                string error = "Error Send Complete: " + ex.ToString();
                this.txtEnvioDatos.Text += "\n" + error;
                log.Error(error);
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
                this.txtRecepcionDatos.Text += "\n" + estado;
                log.Debug(estado);
            }
            catch (Exception ex)
            {
                string error = "Error State Changed: " + ex.ToString();
                this.txtRecepcionDatos.Text += "\n" + error;
                log.Error(error);
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
                this.txtRecepcionDatos.Text += "\n" + error;
                log.Error(error);
            }
            catch (Exception ex)
            {
                string error = "Error Received: " + ex.ToString();
                this.txtRecepcionDatos.Text += "\n" + error;
                log.Error(error);
            }
        }
        #endregion

        #region Eventos Control
        private void btnConectar_Click(object sender, EventArgs e)
        {

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}