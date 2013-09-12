//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;
using Orbita.Comunicaciones.Protocolos.Tcp.Threading;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para todas las clases de clientes.
    /// </summary>
    internal abstract class ClienteBase : ICliente
    {
        #region Eventos públicos
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje.
        /// </summary>
        public event EventHandler<MensajeEventArgs> MensajeRecibido;
        /// <summary>
        /// Este evento se produce cuando un nuevo mensaje es enviado sin ningún error.
        /// Esto no garantiza que el mensaje es obtenido y procesado por la aplicación remota correctamente.
        /// </summary>
        public event EventHandler<MensajeEventArgs> MensajeEnviado;
        /// <summary>
        /// Este evento se produce cuando el cliente se conecta al servidor.
        /// </summary>
        public event EventHandler Conectado;
        /// <summary>
        /// Este evento se produce cuando el cliente se desconecta del servidor.
        /// </summary>
        public event EventHandler Desconectado;
        #endregion

        #region Atributos privados
        /// <summary>
        /// Valor timeout predeterminado para la conexión a un servidor.
        /// </summary>
        private const int TimeoutMsConexionPredeterminado = 15000; // 15 segundos.
        /// <summary>
        /// Canal de comunicación que se utiliza por el cliente para enviar y recibir mensajes.
        /// </summary>
        private ICanalComunicacion _canalComunicacion;
        /// <summary>
        /// Temporizador (timer) que se utiliza para enviar Ping (KeepAlive) al servidor periódicamente.
        /// </summary>
        private readonly Timer _timerPing;
        /// <summary>
        /// Telegrama de comunicación.
        /// </summary>
        private ITelegrama _telegrama;
        #endregion

        #region Constructor protegido
        /// <summary>
        /// Inicializar una nueva instancia de la clase ClienteBase.
        /// </summary>
        protected ClienteBase()
        {
            _timerPing = new Timer(30000);
            _timerPing.Elapsed += PingTimer_Elapsed;
            TimeoutMsConexion = TimeoutMsConexionPredeterminado;
            Telegrama = TelegramaManager.GetTelegramaPredeterminado();
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Endpoint del servidor.
        /// </summary>
        public TcpEndPoint EndPointRemoto { get; protected set; }
        ///// <summary>
        ///// Obtener el objeto IMensajero subyacente.
        ///// </summary>
        //public IMensajero Mensajero { get; set; }
        /// <summary>
        /// Endpoint del cliente.
        /// </summary>
        public TcpEndPoint EndPointLocal { get; set; }
        /// <summary>
        /// Timeout para la conexión a un servidor (en milisegundos).
        /// Valor predeterminado: 15 segundos (15000 ms).
        /// </summary>
        public int TimeoutMsConexion { get; set; }
        /// <summary>
        /// Obtener/establecer el telegrama que se utiliza durante la lectura y escritura de mensajes.
        /// </summary>
        public ITelegrama Telegrama
        {
            get { return _telegrama; }
            set
            {
                if (EstadoComunicacion == EstadoComunicacion.Conectado)
                {
                    throw new ApplicationException("Telegrama no puede ser modificado miestras está conectado al servidor.");
                }
                _telegrama = value;
            }
        }
        /// <summary>
        /// Obtener el estado de comunicación del cliente.
        /// </summary>
        public EstadoComunicacion EstadoComunicacion
        {
            get
            {
                return _canalComunicacion != null
                           ? _canalComunicacion.EstadoComunicacion
                           : EstadoComunicacion.Desconectado;
            }
        }
        /// <summary>
        /// Obtener la fecha del último mensaje recibido satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeRecibido
        {
            get
            {
                return _canalComunicacion != null
                           ? _canalComunicacion.FechaUltimoMensajeRecibido
                           : DateTime.MinValue;
            }
        }
        /// <summary>
        /// Obtener la fecha del último mensaje enviado satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeEnviado
        {
            get
            {
                return _canalComunicacion != null
                           ? _canalComunicacion.FechaUltimoMensajeEnviado
                           : DateTime.MinValue;
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Conectar al servidor.
        /// </summary>
        public void Conectar()
        {
            Telegrama.Resetear();
            _canalComunicacion = CrearCanalComunicacion();
            _canalComunicacion.Telegrama = Telegrama;
            _canalComunicacion.Desconectado += CanalComunicacion_Desconectado;
            _canalComunicacion.MensajeRecibido += CanalComunicacion_MensajeRecibido;
            _canalComunicacion.MensajeEnviado += CanalComunicacion_MensajeEnviado;
            _canalComunicacion.Iniciar();
            //_timerPing.Iniciar();
            OnConectado();
        }
        /// <summary>
        /// Desconectar del servidor.
        /// No hace nada si ya está desconectado.
        /// </summary>
        public void Desconectar()
        {
            if (EstadoComunicacion != EstadoComunicacion.Conectado)
            {
                return;
            }
            _canalComunicacion.Desconectar();
        }
        /// <summary>
        /// Dispose de este objeto y cierre de la conexión subyacente.
        /// </summary>
        public void Dispose()
        {
            Desconectar();
        }
        /// <summary>
        /// Enviar un mensaje al servidor.
        /// </summary>
        /// <param name="mensaje">Mensaje que será enviado.</param>
        /// <exception cref="ExcepcionEstadoComunicacion">Throws ExcepcionEstadoComunicacion si el cliente no está conectado al servidor.</exception>
        public void EnviarMensaje(IMensaje mensaje)
        {
            if (EstadoComunicacion != EstadoComunicacion.Conectado)
            {
                throw new ExcepcionEstadoComunicacion("Cliente desconectado del servidor.");
            }
            _canalComunicacion.EnviarMensaje(mensaje);
        }
        #endregion

        #region Métodos protegidos abstractos
        /// <summary>
        /// Este método es implementado por las clases derivadas para crear el canal de comunicación apropiado.
        /// </summary>
        /// <returns>Canal de comunicación.</returns>
        protected abstract ICanalComunicacion CrearCanalComunicacion();
        #endregion

        #region Métodos privados
        /// <summary>
        /// Manejador del evento MensajeRecibido del objeto _canalComunicacion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void CanalComunicacion_MensajeRecibido(object sender, MensajeEventArgs e)
        {
            //if (e.Mensaje is MensajePing)
            //{
            //    return;
            //}
            OnMensajeRecibido(e.Mensaje);
        }
        /// <summary>
        /// Manejador del evento MensajeEnviado del objeto _canalComunicacion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void CanalComunicacion_MensajeEnviado(object sender, MensajeEventArgs e)
        {
            OnMensajeEnviado(e.Mensaje);
        }
        /// <summary>
        /// Manejador del evento Desconectado del objeto _canalComunicacion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void CanalComunicacion_Desconectado(object sender, EventArgs e)
        {
            _timerPing.Parar();
            OnDesconectado();
        }
        /// <summary>
        /// Manejador del evento Elapsed del objeto _timerPing.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void PingTimer_Elapsed(object sender, EventArgs e)
        {
            if (EstadoComunicacion != EstadoComunicacion.Conectado)
            {
                return;
            }
            try
            {
                var ultimoMinuto = DateTime.Now.AddMinutes(-1);
                if (_canalComunicacion.FechaUltimoMensajeRecibido > ultimoMinuto || _canalComunicacion.FechaUltimoMensajeEnviado > ultimoMinuto)
                {
                    return;
                }
                _canalComunicacion.EnviarMensaje(new MensajePing());
            }
            catch
            {
                //  Empty.
            }
        }
        #endregion

        #region Métodos protegidos de eventos elevados
        /// <summary>
        /// Elevar el evento Conectado.
        /// </summary>
        protected virtual void OnConectado()
        {
            var handler = Conectado;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Elevar el evento Desconectado.
        /// </summary>
        protected virtual void OnDesconectado()
        {
            var handler = Desconectado;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibido.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibido(IMensaje mensaje)
        {
            var handler = MensajeRecibido;
            if (handler != null)
            {
                handler(this, new MensajeEventArgs(mensaje));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeEnviado.
        /// </summary>
        /// <param name="mensaje">Mensaje enviado.</param>
        protected virtual void OnMensajeEnviado(IMensaje mensaje)
        {
            var handler = MensajeEnviado;
            if (handler != null)
            {
                handler(this, new MensajeEventArgs(mensaje));
            }
        }
        #endregion
    }
}