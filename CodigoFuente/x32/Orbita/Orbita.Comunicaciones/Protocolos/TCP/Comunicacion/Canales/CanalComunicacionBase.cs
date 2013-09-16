//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para todas las clases de los canales de comunicación.
    /// </summary>
    internal abstract class CanalComunicacionBase : ICanalComunicacion
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
        /// Este evento se produce cuando se conecta el canal de comunicación con el cliente.
        /// </summary>
        public event EventHandler Conectado;
        /// <summary>
        /// Este evento se produce cuando se cierra el canal de comunicación con el cliente.
        /// </summary>
        public event EventHandler Desconectado;
        #endregion Eventos públicos

        #region Constructor protegido
        /// <summary>
        /// Inicializar una nueva instancia de la clase CanalComunicacionBase.
        /// </summary>
        protected CanalComunicacionBase()
        {
            EstadoComunicacion = EstadoComunicacion.Desconectado;
            FechaUltimoMensajeRecibido = DateTime.MinValue;
            FechaUltimoMensajeEnviado = DateTime.MinValue;
        }
        #endregion Constructor protegido

        #region Propiedades públicas abstractas
        ///<summary>
        /// Obtener endpoint de la aplicación remota.
        ///</summary>
        public abstract EndPoint EndPointRemoto { get; }
        #endregion Propiedades públicas abstractas

        #region Propiedades públicas
        /// <summary>
        /// Obtener el estado actual de la comunicación.
        /// </summary>
        public EstadoComunicacion EstadoComunicacion { get; protected set; }
        /// <summary>
        /// Obtener la fecha del último mensaje recibido satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeRecibido { get; protected set; }
        /// <summary>
        /// Obtener la fecha del último mensaje enviado satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeEnviado { get; protected set; }
        /// <summary>
        /// Obtener/establecer el telegrama que se utiliza en este canal.
        /// Esta propiedad se debe definir antes de la primera comunicación.
        /// </summary>
        public ITelegrama Telegrama { get; set; }
        #endregion Propiedades públicas

        #region Métodos públicos abstractos
        /// <summary>
        /// Desconectar de la aplicación remota y cerrar este canal.
        /// </summary>
        public abstract void Desconectar();
        #endregion Métodos públicos abstractos

        #region Métodos públicos
        /// <summary>
        /// Iniciar la comunicación con aplicaciones remotas.
        /// </summary>
        public void Iniciar()
        {
            IniciarCanalComunicacion();
            EstadoComunicacion = EstadoComunicacion.Conectado;
            OnConectado();
        }
        /// <summary>
        /// Enviar mensaje a las aplicaciones remotas.
        /// </summary>
        /// <param name="mensaje">Mensaje que será enviado.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException; si mensaje es nulo (null).</exception>
        public void EnviarMensaje(IMensaje mensaje)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("mensaje");
            }
            EnviarMensajePorCanalComunicacion(mensaje);
        }
        #endregion Métodos públicos

        #region Métodos protegidos
        /// <summary>
        /// Iniciar la comunicación con aplicaciones remotas.
        /// </summary>
        protected abstract void IniciarCanalComunicacion();
        /// <summary>
        /// Envíar un mensaje a la aplicación remota.
        /// Este método será sobreescrito por las clases derivadas para enviar realmente el mensaje.
        /// </summary>
        /// <param name="mensaje">Mensaje que será enviado.</param>
        protected abstract void EnviarMensajePorCanalComunicacion(IMensaje mensaje);
        #endregion Métodos protegidos

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
        #endregion Métodos protegidos de eventos elevados
    }
}