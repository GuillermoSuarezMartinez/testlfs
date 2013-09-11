using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Winsock;
using Orbita.Utiles;
using System.Threading;
using Orbita.MS;

namespace Orbita.Comunicaciones
{
    public class OWinSockClienteBase : IDisposable
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
        /// Dirección IP de conexión
        /// </summary>
        string _ip;
        /// <summary>
        /// Puerto de conexión
        /// </summary>
        int _puerto;
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
        /// <param name="nombre">nombre del canal</param>
        public OWinSockClienteBase(string listener, string nombre, ILogger log)
        {
            this._estado = WinsockStates.Closed;
            this._nombre = nombre;
            this._listener = listener;
            this.log = log;
            this._winsock = new OWinsockBase();
            this._winsock.LegacySupport = true;

            this._winsock.DataArrival += new IWinsock.DataArrivalEventHandler(_winsock_DataArrival);
            this._winsock.StateChanged += new IWinsock.StateChangedEventHandler(_winsock_StateChanged);
            this._winsock.SendComplete += new IWinsock.SendCompleteEventHandler(_winsock_SendComplete);
            this._winsock.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsock_ErrorReceived);
        }
        /// <summary>
        /// Constructor de la clase (permite Connect)
        /// </summary>
        /// <param name="log"></param>
        /// <param name="ip"></param>
        /// <param name="puerto"></param>
        /// <param name="nombre"></param>
        public OWinSockClienteBase(ILogger log, string ip, int puerto, string nombre)
        {
            this._estado = WinsockStates.Closed;
            this._nombre = nombre;
            this._listener = "";
            this._ip = ip;
            this._puerto = puerto;
            this.log = log;
            this._winsock = new OWinsockBase();
            this._winsock.LegacySupport = true;

            this._winsock.DataArrival += new IWinsock.DataArrivalEventHandler(_winsock_DataArrival);
            this._winsock.StateChanged += new IWinsock.StateChangedEventHandler(_winsock_StateChanged);
            this._winsock.SendComplete += new IWinsock.SendCompleteEventHandler(_winsock_SendComplete);
            this._winsock.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsock_ErrorReceived);
        }
        #endregion Constructor

        #region Metodos públicos
        /// <summary>
        /// Permite conectar con un listener remoto
        /// </summary>
        public void Conectar()
        {

            this._winsock.Connect(_ip, _puerto);
        }

        /// <summary>
        /// Cierra la conexión activa
        /// </summary>
        public void CerrarConexion()
        {
            this._winsock.Close();
        }
        /// <summary>
        /// Permite enviar una cadena
        /// </summary>
        /// <param name="mensaje"></param>
        public void EnviarMensaje(string mensaje = "Mensaje de prueba")
        {
            bool enviar = false;

            byte[] mbase = OMensajeXML.StringAByteArray(mensaje);
            while (!enviar)
            {
                if (this._winsock.State == WinsockStates.Connected)
                {
                    this._winsock.Send(mbase);
                    enviar = true;
                }
                else
                {
                    string conectar = "Conectando";
                    Console.WriteLine("Conectando");
                    log.Error(conectar);
                    this.Conectar();
                    Thread.Sleep(50);
                }
            }
        }

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
                byte[] recibido = (byte[])dat;
                if (recibido != null)
                {
                    for (int i = 0; i < recibido.Length; i++)
                    {
                        ret += "[" + recibido[i].ToString() + "]";
                    }
                }

                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, ret);
                mensaje.Data = dat;
                OEventArgs ev = new OEventArgs(mensaje);
                this.ODataArrival(ev);
                log.Debug(this._nombre + " Data Arrival: " + ret);
            }
            catch (Exception ex)
            {
                string error = "Data Arrival Error: " + ex.ToString();
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
                string error = "State Changed Cliente Error: " + ex.ToString();
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
                string error = "Error Received Cliente: " + e.Message.ToString();
                OMensajeCanalTCP mensaje = new OMensajeCanalTCP(this._listener, this._nombre, error);
                OEventArgs ev = new OEventArgs(mensaje);
                this.OErrorReceived(ev);
                log.Error(this._nombre + " " + error);
            }
            catch (Exception ex)
            {
                string error = "Error Received Cliente: " + ex.ToString();
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
                string error = "Send Complete Error: " + ex.ToString();
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

        public void Dispose()
        {
            //No nos interesa obtener errores en el dispose del objeto.
            try{CerrarConexion();}catch(Exception){}
        }
    }
}
