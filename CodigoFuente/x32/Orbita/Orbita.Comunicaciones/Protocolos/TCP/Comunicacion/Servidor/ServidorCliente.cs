//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Esta clase representa a un cliente en el servidor.
    /// </summary>
    internal class ServidorCliente : IServidorCliente
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
        #endregion Eventos públicos

        #region Atributos
        /// <summary>
        /// El canal de comunicación que se utiliza por el cliente para enviar y recibir mensajes.
        /// </summary>
        private readonly ICanalComunicacion _canalComunicacion;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ServidorCliente.
        /// </summary>
        /// <param name="canalComunicacion">El canal de comunicación que se utiliza por el cliente para enviar y recibir mensajes.</param>
        public ServidorCliente(ICanalComunicacion canalComunicacion)
        {
            _canalComunicacion = canalComunicacion;
            _canalComunicacion.MensajeRecibido += CanalComunicacion_MensajeRecibido;
            _canalComunicacion.MensajeEnviado += CanalComunicacion_MensajeEnviado;
            _canalComunicacion.Conectado += CanalComunicacion_Conectado;
            _canalComunicacion.Desconectado += CanalComunicacion_Desconectado;
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Identificador único para este cliente en el servidor.
        /// </summary>
        public long IdentificadorAutoincremental { get; set; }
        /// <summary>
        /// Obtener el estado de comunicación del cliente.
        /// </summary>
        public EstadoComunicacion EstadoComunicacion
        {
            get { return _canalComunicacion.EstadoComunicacion; }
        }
        /// <summary>
        /// Obtener/establecer el telegrama que se utiliza durante la lectura y escritura de mensajes.
        /// </summary>
        public ITelegrama Telegrama
        {
            get { return _canalComunicacion.Telegrama; }
            set { _canalComunicacion.Telegrama = value; }
        }
        ///<summary>
        /// Obtener el endpoint del servidor.
        ///</summary>
        public EndPoint EndPointRemoto
        {
            get { return _canalComunicacion.EndPointRemoto; }
        }
        /// <summary>
        /// Obtener la fecha del último mensaje recibido satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeRecibido
        {
            get { return _canalComunicacion.FechaUltimoMensajeRecibido; }
        }
        /// <summary>
        /// Obtener la fecha del último mensaje enviado satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeEnviado
        {
            get { return _canalComunicacion.FechaUltimoMensajeEnviado; }
        }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Desconectar del cliente y cerrar el canal de comunicación subyacente.
        /// </summary>
        public void Desconectar()
        {
            _canalComunicacion.Desconectar();
        }
        /// <summary>
        /// Envíar un mensaje al cliente.
        /// </summary>
        /// <param name="mensaje">Mensaje que será enviado.</param>
        public void EnviarMensaje(IMensaje mensaje)
        {
            _canalComunicacion.EnviarMensaje(mensaje);
        }
        #endregion Métodos públicos

        #region Manejadores de eventos
        /// <summary>
        /// Manejador del evento Conectado del objeto _canalComunicacion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void CanalComunicacion_Conectado(object sender, EventArgs e)
        {
            OnConectado();
        }
        /// <summary>
        /// Manejador del evento Desconectado del objeto _canalComunicacion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void CanalComunicacion_Desconectado(object sender, EventArgs e)
        {
            OnDesconectado();
        }
        /// <summary>
        /// Manejador del evento MensajeRecibido del objeto _canalComunicacion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void CanalComunicacion_MensajeRecibido(object sender, MensajeEventArgs e)
        {
            //var mensaje = e.Mensaje;
            //if (mensaje is MensajePing)
            //{
            //    _canalComunicacion.EnviarMensaje(new MensajePing { IdMensajeRespuesta = mensaje.IdMensaje });
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
        #endregion Manejadores de eventos

        #region Métodos protegidos de eventos elevados
        /// <summary>
        /// Elevar el evento Conectado.
        /// </summary>
        private void OnConectado()
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
        private void OnDesconectado()
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
        private void OnMensajeRecibido(IMensaje mensaje)
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
        #endregion Métodos protegidos de eventos elevados
    }
}