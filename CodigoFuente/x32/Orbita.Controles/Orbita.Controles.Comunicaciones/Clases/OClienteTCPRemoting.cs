using System;
using System.Windows.Forms;
using Orbita.Trazabilidad;
using Orbita.Winsock;
using Orbita.Utiles;
using Orbita.Comunicaciones;

namespace Orbita.Controles.Comunicaciones
{
    public class OClienteTCPRemoting
    {

        #region Variables
        /// <summary>
        /// Objeto para establecer el canal TCP
        /// </summary>
        OWinsockBase _winsock;
        /// <summary>
        /// Objeto para establecer el canal TCP
        /// </summary>
        OWinsockBase _winsockPeticiones;
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
        /// <summary>
        /// Estado del canal
        /// </summary>
        WinsockStates _estado;
        /// <summary>
        /// Estado del canal
        /// </summary>
        WinsockStates _estadoPeticiones;
        /// <summary>
        /// Evento para los cambios de dato
        /// </summary>
        public event EventoCanalTCP OEventoTCPCambioDato;
        /// <summary>
        /// Evento para las alarmas
        /// </summary>
        public event EventoCanalTCP OEventoTCPAlarma;
        /// <summary>
        /// Evento para el estado de las comunicaciones con el servidor
        /// </summary>
        public event EventoCanalTCP OEventoTCPComunicaciones;
        /// <summary>
        /// Evento reset de recepción de tramas KeepAlive, 
        /// Entrada/Salida.
        /// </summary>
        private OResetManual _eReset;  //0-getdispositivos;1-getAlarmas;2-getVariables;3-getValores;4-setValores
        /// <summary>
        /// Tiempo de respuesta del servidor antes de dar tiemout
        /// </summary>
        private int _segundosRespuestaServer = 2;
        /// <summary>
        /// Respuesta de los dispositivos
        /// </summary>
        OEventArgs _eGetDispositivos;
        /// <summary>
        /// Respuesta de las alarmas
        /// </summary>
        OEventArgs _eGetAlarmas;
        /// <summary>
        /// Respuesta con las variables
        /// </summary>
        OEventArgs _eGetVariables;
        /// <summary>
        /// Respuesta con los valores
        /// </summary>
        OEventArgs _eGetValores;
        /// <summary>
        /// Respuesta con el set de las variables
        /// </summary>
        OEventArgs _eSetValores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Estado del canal
        /// </summary>
        public WinsockStates Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        #endregion

        /// <summary>
        /// Cosntructor del control
        /// </summary>
        public OClienteTCPRemoting(string servidor, int puerto, ILogger log)
        {
            this._servidor = servidor;
            this._puerto = puerto;
            this._log = log;
        }

        #region Metodos
        /// <summary>
        /// Inicializa las variables de la comunicación TCP
        /// </summary>
        public void Inicializar()
        {
            try
            {
                this._estado = WinsockStates.Closed;
                this._estadoPeticiones = WinsockStates.Closed;

                this._winsock = new OWinsockBase();
                this._winsockPeticiones = new OWinsockBase();

                this._winsock.LegacySupport = true;
                this._winsockPeticiones.LegacySupport = true;

                this._winsock.DataArrival += new IWinsock.DataArrivalEventHandler(_winsock_DataArrival);
                this._winsock.StateChanged += new IWinsock.StateChangedEventHandler(_winsock_StateChanged);
                this._winsock.SendComplete += new IWinsock.SendCompleteEventHandler(_winsock_SendComplete);
                this._winsock.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsock_ErrorReceived);

                this._winsockPeticiones.DataArrival += new IWinsock.DataArrivalEventHandler(_winsockPeticiones_DataArrival);
                this._winsockPeticiones.StateChanged += new IWinsock.StateChangedEventHandler(_winsockPeticiones_StateChanged);
                this._winsockPeticiones.SendComplete += new IWinsock.SendCompleteEventHandler(_winsockPeticiones_SendComplete);
                this._winsockPeticiones.ErrorReceived += new IWinsock.ErrorReceivedEventHandler(_winsockPeticiones_ErrorReceived);

                this._eReset = new OResetManual(5);
                this._eGetDispositivos = new OEventArgs();
                this._eGetAlarmas = new OEventArgs();
                this._eGetVariables = new OEventArgs();
                this._eGetValores = new OEventArgs();
                this._eSetValores = new OEventArgs();

                this.Conectar();
            }
            catch (Exception ex)
            {
                this._log.Error("OClienteTCPRemoting Inicializar: ", ex);
            }
        }

        
        /// <summary>
        /// Conecta con el servidor TCP
        /// </summary>
        public void Conectar()
        {
            try
            {
                this._winsock.Connect(this._servidor, this._puerto);
                this._winsockPeticiones.Connect(this._servidor, this._puerto + 1);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        /// <summary>
        /// Enviar datos
        /// </summary>
        /// <param name="data"></param>
        private void Enviar(Object data)
        {
            try
            {
                this._winsock.Send(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Enviar datos
        /// </summary>
        /// <param name="data"></param>
        private void EnviarPeticion(Object data)
        {
            try
            {
                this._winsockPeticiones.Send(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Procesamiento de los datos del canal
        /// </summary>
        /// <param name="e"></param>
        private void ProcesarDatos(OEventArgs e)
        {
            switch (e.Id)
            {
                case 1:
                    if (OEventoTCPCambioDato!=null)
                    {
                        this.OEventoTCPCambioDato(e);
                    }                    
                    break;
                case 2:
                    if (OEventoTCPAlarma != null)
                    {
                        this.OEventoTCPAlarma(e);
                    }
                    break;
                case 3:
                    if (OEventoTCPComunicaciones != null)
                    {
                        this.OEventoTCPComunicaciones(e);
                    }
                    break;
                case 4:
                    this._eGetDispositivos = e;
                    this._eReset.Despertar(0);
                    break;
                case 5:
                    this._eGetAlarmas = e;
                    this._eReset.Despertar(1);
                    break;
                case 6:
                    this._eGetVariables = e;
                    this._eReset.Despertar(2);
                    break;
                case 7:
                    this._eGetValores = e;
                    this._eReset.Despertar(3);
                    break;
                case 8:
                    this._eSetValores = e;
                    this._eReset.Despertar(4);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Procesamiento de los datos del canal
        /// </summary>
        /// <param name="e"></param>
        private void ProcesarDatosPeticiones(OEventArgs e)
        {
            switch (e.Id)
            {
                case 1:
                    if (OEventoTCPCambioDato != null)
                    {
                        this.OEventoTCPCambioDato(e);
                    }
                    break;
                case 2:
                    if (OEventoTCPAlarma != null)
                    {
                        this.OEventoTCPAlarma(e);
                    }
                    break;
                case 3:
                    if (OEventoTCPComunicaciones != null)
                    {
                        this.OEventoTCPComunicaciones(e);
                    }
                    break;
                case 4:
                    this._eGetDispositivos = e;
                    this._eReset.Despertar(0);
                    break;
                case 5:
                    this._eGetAlarmas = e;
                    this._eReset.Despertar(1);
                    break;
                case 6:
                    this._eGetVariables = e;
                    this._eReset.Despertar(2);
                    break;
                case 7:
                    this._eGetValores = e;
                    this._eReset.Despertar(3);
                    break;
                case 8:
                    this._eSetValores = e;
                    this._eReset.Despertar(4);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Devuelve los dispositivos del servidor
        /// </summary>
        /// <returns></returns>
        public int[] GetDispositivos()
        {
            int[] ret = null;
            int reintento = 0;
            int maxReintentos = 3;
            OEventArgs comando = new OEventArgs();
            comando.Id = 4;
            this._eGetDispositivos.Argumento = null;

            while (reintento<maxReintentos)
            {
                this.EnviarPeticion(comando);
                if (!this._eReset.Dormir(0, TimeSpan.FromSeconds(this._segundosRespuestaServer)))
                {
                    reintento++;
                    this._log.Warn("OClienteTCPRemoting GetDispositivos Timeout");
                }
                else
                {
                    reintento = maxReintentos;
                }
                // Resetear el evento.
                this._eReset.Resetear(0);
            }
            ret = (int[])this._eGetDispositivos.Argumento;
            return ret;
        }
        /// <summary>
        /// Devuelve las alarmas del servidor
        /// </summary>
        /// <returns></returns>
        public OHashtable GetAlarmas(int idDispositivo)
        {
            OHashtable ret = null;
            int reintento = 0;
            int maxReintentos = 3;
            OEventArgs comando = new OEventArgs();
            comando.Id = 5;
            comando.Argumento = idDispositivo;
            this._eGetAlarmas.Argumento = null;

            while (reintento < maxReintentos)
            {
                this.EnviarPeticion(comando);
                if (!this._eReset.Dormir(1, TimeSpan.FromSeconds(this._segundosRespuestaServer)))
                {
                    reintento++;
                    this._log.Warn("OClienteTCPRemoting GetAlarmas Timeout");
                }
                else
                {
                    reintento = maxReintentos;
                }
                // Resetear el evento.
                this._eReset.Resetear(1);
            }
            ret = (OHashtable)this._eGetAlarmas.Argumento;
            return ret;
        }
        /// <summary>
        /// Devuelve las variables del servidor
        /// </summary>
        /// <returns></returns>
        public OHashtable GetVariables(int idDispositivo)
        {
            OHashtable ret = null;
            int reintento = 0;
            int maxReintentos = 3;
            OEventArgs comando = new OEventArgs();
            comando.Id = 6;
            comando.Argumento = idDispositivo;
            this._eGetVariables.Argumento = null;

            while (reintento < maxReintentos)
            {
                this.EnviarPeticion(comando);
                if (!this._eReset.Dormir(2, TimeSpan.FromSeconds(this._segundosRespuestaServer)))
                {
                    reintento++;
                    this._log.Warn("OClienteTCPRemoting GetVariables Timeout");
                }
                else
                {
                    reintento = maxReintentos;
                }
                // Resetear el evento.
                this._eReset.Resetear(2);
            }
            ret = (OHashtable)this._eGetVariables.Argumento;
            return ret;
        }
        /// <summary>
        /// Devuelve los valores de las variables del servidor
        /// </summary>
        /// <returns></returns>
        public Object[] GetValores(int idDispositivo, string[] variables)
        {
            Object[] ret = null;
            int reintento = 0;
            int maxReintentos = 3;
            OEventArgsComs valor = new OEventArgsComs();
            valor.Id = 7;
            valor.IdDispositivo = idDispositivo;
            valor.Variables = variables;
            OEventArgs comando = new OEventArgs();
            comando.Id = 7;
            comando.Argumento = valor;

            this._eGetValores.Argumento = null;

            //while (reintento < maxReintentos)
            //{
                this.EnviarPeticion(comando);
                if (!this._eReset.Dormir(3, TimeSpan.FromSeconds(this._segundosRespuestaServer)))
                {
                    reintento++;
                    this._log.Warn("OClienteTCPRemoting GetValores Timeout");
                }
                else
                {
                    reintento = maxReintentos;
                }
                // Resetear el evento.
                this._eReset.Resetear(3);
            //}
            ret = (Object[])this._eGetValores.Argumento;
            return ret;
        }
        /// <summary>
        /// Escribe las variables en el  servidor
        /// </summary>
        /// <returns></returns>
        public bool SetValores(int idDispositivo, string[] variables,object[] valores)
        {
            bool ret = false;
            int reintento = 0;
            int maxReintentos = 3;
            OEventArgsComs valor = new OEventArgsComs();
            valor.Id = 8;
            valor.IdDispositivo = idDispositivo;
            valor.Variables = variables;
            valor.Valores = valores;

            OEventArgs comando = new OEventArgs();
            comando.Id = 8;
            comando.Argumento = valor;

            this._eGetValores.Argumento = null;

            //while (reintento < maxReintentos)
            //{
                this.EnviarPeticion(comando);
                if (!this._eReset.Dormir(4, TimeSpan.FromSeconds(this._segundosRespuestaServer)))
                {
                    reintento++;
                    this._log.Warn("OClienteTCPRemoting SetValores Timeout");
                }
                else
                {
                    reintento = maxReintentos;
                }
                //Resetear el evento.
                this._eReset.Resetear(4);
            //}
            ret = (bool)this._eSetValores.Argumento;
            return ret;
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
                OEventArgs recibido = (OEventArgs)dat;
                this._log.Debug("TCP remoting recibido " + recibido.ToString());
                this.ProcesarDatos(recibido);

            }
            catch (Exception ex)
            {
                string error = "TCP remoting Error Data Arrival: " + ex.ToString();
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
                this._estadoPeticiones = e.New_State;
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

        /// <summary>
        /// Evento de recepción de datos
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsockPeticiones_DataArrival(object sender, WinsockDataArrivalEventArgs e)
        {
            try
            {
                String data = "";   
                Object dat = (object)data; 
                

                dat = _winsockPeticiones.Get<object>();
                OEventArgs recibido = (OEventArgs)dat;
                this._log.Debug("TCP remoting recibido peticiones " + recibido.ToString());
                this.ProcesarDatosPeticiones(recibido);

            }
            catch (Exception ex)
            {
                string error = "TCP remoting Error Data Arrival peticiones: " + ex.ToString();
                this._log.Error(error);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha enviado toda la información
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsockPeticiones_SendComplete(object sender, WinsockSendEventArgs e)
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
                this._log.Debug("Enviado Peticiones; " + enviado);

            }
            catch (Exception ex)
            {
                string error = "Error Send Complete Peticiones: " + ex.ToString();
                this._log.Error(error);
            }
        }
        /// <summary>
        /// Indica que el objeto winsock ha cambiado de estado. Trazabilidad del canal.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsockPeticiones_StateChanged(object sender, WinsockStateChangedEventArgs e)
        {
            try
            {
                string estado = "State Changed Peticiones. Cambia de " + e.Old_State.ToString() + " a " + e.New_State.ToString();
                this._estado = e.New_State;
                this._log.Debug(estado);
            }
            catch (Exception ex)
            {
                string error = "Error State Changed Peticiones: " + ex.ToString();
                this._log.Error(error);
            }
        }
        /// <summary>
        /// Evento de errores en la comunicación TCP
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        void _winsockPeticiones_ErrorReceived(object sender, WinsockErrorReceivedEventArgs e)
        {
            try
            {
                string error = "Error Received Peticiones: " + e.Message;
                this._log.Error(error);
            }
            catch (Exception ex)
            {
                string error = "Error Received Peticiones: " + ex.ToString();
                this._log.Error(error);
            }
        }
        #endregion
    }
}
