//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase añade EnviarMensajeEsperarRespuesta (...) y los métodos Enviar(...) y Recibir(...)
    /// mensajes a un IMensajero para peticiones/respuestas síncronas.
    /// Agrega procesamiento en cola de los mensajes entrantes.
    /// </summary>
    /// <typeparam name="T">El tipo de objeto IMensajero que utiliza la comunicación subyacente.</typeparam>
    public class OcsMensajeroPeticionRespuesta<T> : IMensajero, IDisposable where T : IMensajero
    {
        #region Eventos públicos
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje desde el mensajero subyacente.
        /// </summary>
        public event EventHandler<MensajeEventArgs> MensajeRecibido;
        /// <summary>
        /// Este evento se produce cuando un nuevo mensaje es enviado sin ningún error.
        /// Esto no garantiza que el mensaje es obtenido y procesado por la aplicación remota correctamente.
        /// </summary>
        public event EventHandler<MensajeEventArgs> MensajeEnviado;
        #endregion Eventos públicos

        #region Atributos privados
        /// <summary>
        /// Valor predeterminado del timeout.
        /// </summary>
        private const int TimeoutMsPredeterminado = 60000;
        /// <summary>
        /// Estos mensajes están a la espera de una respuesta.
        /// Clave: IdMensaje.
        /// Valor: instancia de MensajeEnEspera.
        /// </summary>
        private readonly SortedList<string, MensajeEnEspera> _mensajesEnEspera;
        /// <summary>
        /// Este objeto sólo se utiliza para la sincronización de threads (bloqueo).
        /// </summary>
        private readonly object _objSincronizacion = new object();
        #endregion Atributos privados

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeroPeticionRespuesta.
        /// </summary>
        /// <param name="mensajero">Mensajero que se usa en la comunicación subyacente.</param>
        public OcsMensajeroPeticionRespuesta(T mensajero)
        {
            Mensajero = mensajero;
            mensajero.MensajeRecibido += Mensajero_MensajeRecibido;
            mensajero.MensajeEnviado += Mensajero_MensajeEnviado;
            _mensajesEnEspera = new SortedList<string, MensajeEnEspera>();
            TimeoutMs = TimeoutMsPredeterminado;
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Obtener/establecer el telegrama que se utiliza durante la lectura y escritura de mensajes.
        /// </summary>
        public ITelegrama Telegrama
        {
            get { return Mensajero.Telegrama; }
            set { Mensajero.Telegrama = value; }
        }
        /// <summary>
        /// Obtener la fecha del último mensaje recibido satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeRecibido
        {
            get { return Mensajero.FechaUltimoMensajeRecibido; }
        }
        /// <summary>
        /// Obtener la fecha del último mensaje enviado satisfactoriamente.
        /// </summary>
        public DateTime FechaUltimoMensajeEnviado
        {
            get { return Mensajero.FechaUltimoMensajeEnviado; }
        }
        /// <summary>
        /// Obtener el objeto IMensajero subyacente.
        /// </summary>
        public T Mensajero { get; private set; }
        /// <summary>
        /// Valor de tiempo de espera en milisegundos para esperar recibir un mensaje de la llamada al método EnviarMensajeEsperarRespuesta(...).
        /// Valor predeterminado: 60000 ms (1 minuto).
        /// </summary>
        public int TimeoutMs { get; set; }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Parar el mensajero.
        /// Cancelar todos los hilos (threads) esperando en el método EnviarMensajeEsperarRespuesta y detener la cola de mensajes.
        /// El método EnviarMensajeEsperarRespuesta lanza una excepción si hay un hilo que está a la espera de mensaje de respuesta.
        /// También se detiene el procesamiento de mensajes entrantes y elimina todos los mensajes en la cola de entrada.
        /// </summary>
        public virtual void Parar()
        {
            //  Pulso de subprocesos en espera para los mensajes entrantes, desde el mensajero subyacente 
            //  se desconecta y no puede recibir más mensajes.
            lock (_objSincronizacion)
            {
                foreach (var mensajeEnEspera in _mensajesEnEspera.Values)
                {
                    mensajeEnEspera.Estado = EstadoMensajeEnEspera.Cancelado;
                    mensajeEnEspera.EventoEspera.Set();
                }
                _mensajesEnEspera.Clear();
            }
        }
        /// <summary>
        /// Llamar al método Parar(...) en este método.
        /// </summary>
        public void Dispose()
        {
            Parar();
        }
        /// <summary>
        /// Enviar un mensaje.
        /// </summary>
        /// <param name="mensaje">Mensaje que será enviado.</param>
        public void EnviarMensaje(IMensaje mensaje)
        {
            Mensajero.EnviarMensaje(mensaje);
        }
        /// <summary>
        /// Envíar un mensaje y esperar una respuesta para este mensaje.
        /// </summary>
        /// <remarks>
        /// El mensaje de respuesta se corresponde con la propiedad IdMensajeRespuesta, por lo que si
        /// cualquier otro mensaje se recibe (que no se responderá por mensaje enviado)
        /// de aplicación remota, no se considera como una respuesta y no se
        /// devuelve como valor de retorno de este método.
        /// 
        /// El evento MensajeRecibido no se lanza para mensajes de respuesta.
        /// </remarks>
        /// <param name="mensaje">Mensaje a enviar.</param>
        /// <returns>Mensaje de respuesta.</returns>
        public IMensaje EnviarMensajeEsperarRespuesta(IMensaje mensaje)
        {
            return EnviarMensajeEsperarRespuesta(mensaje, TimeoutMs);
        }
        /// <summary>
        /// Envíar un mensaje y esperar una respuesta para este mensaje.
        /// </summary>
        /// <remarks>
        /// El mensaje de respuesta se corresponde con la propiedad IdMensajeRespuesta, por lo que si
        /// cualquier otro mensaje se recibe (que no se responderá por mensaje enviado)
        /// de aplicación remota, no se considera como una respuesta y no se
        /// devuelve como valor de retorno de este método.
        /// 
        /// El eventoMensajeRecibido no se lanza para mensajes de respuesta.
        /// </remarks>
        /// <param name="mensaje">Mensaje a enviar.</param>
        /// <param name="timeoutMs">Duración del timeout en milisegundos.</param>
        /// <returns>Mensaje de respuesta.</returns>
        /// <exception cref="TimeoutException">Throws TimeoutException si no se ha podido recibir el mensaje de respuesta en tiempo.</exception>
        /// <exception cref="ExcepcionComunicacion">Throws ExcepcionComunicacion si la comunicación falla antes del mensaje de respuesta.</exception>
        public IMensaje EnviarMensajeEsperarRespuesta(IMensaje mensaje, int timeoutMs)
        {
            //  Crear un objeto de mensaje en espera que añade a la colección.
            var mensajeEnEspera = new MensajeEnEspera();
            lock (_objSincronizacion)
            {
                _mensajesEnEspera[mensaje.IdMensaje] = mensajeEnEspera;
            }
            try
            {
                //  Enviar mensaje.
                Mensajero.EnviarMensaje(mensaje);

                //  Esperar respuesta.
                mensajeEnEspera.EventoEspera.Wait(timeoutMs);

                //  Comprobación de excepciones.
                switch (mensajeEnEspera.Estado)
                {
                    case EstadoMensajeEnEspera.EsperandoRespuesta:
                        throw new TimeoutException("Tiempo de espera caducado. No recibió respuesta.");
                    case EstadoMensajeEnEspera.Cancelado:
                        throw new ExcepcionComunicacion("Desconectado antes de recibir respuesta.");
                }

                //  Devolver la respuesta del mensaje.
                return mensajeEnEspera.MensajeRespuesta;
            }
            finally
            {
                //  Eliminar mensaje de la colección de mensajes en espera.
                lock (_objSincronizacion)
                {
                    if (_mensajesEnEspera.ContainsKey(mensaje.IdMensaje))
                    {
                        _mensajesEnEspera.Remove(mensaje.IdMensaje);
                    }
                }
            }
        }
        #endregion Métodos públicos

        #region Manejadores de eventos
        /// <summary>
        /// Manejador del evento MensajeRecibido del objeto mensajero.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void Mensajero_MensajeRecibido(object sender, MensajeEventArgs e)
        {
            //  Comprobar si hay un hilo esperando este mensaje en el método EnviarMensajeEsperarRespuesta.
            if (string.IsNullOrEmpty(e.Mensaje.IdMensajeRespuesta)) return;
            MensajeEnEspera mensajeEnEspera = null;
            lock (_objSincronizacion)
            {
                if (_mensajesEnEspera.ContainsKey(e.Mensaje.IdMensajeRespuesta))
                {
                    mensajeEnEspera = _mensajesEnEspera[e.Mensaje.IdMensajeRespuesta];
                }
            }
            //  Si hay un hilo de espera para este mensaje de respuesta, establecerlo.
            if (mensajeEnEspera == null)
            {
                return;
            }
            mensajeEnEspera.MensajeRespuesta = e.Mensaje;
            mensajeEnEspera.Estado = EstadoMensajeEnEspera.RespuestaRecibida;
            mensajeEnEspera.EventoEspera.Set();
        }
        /// <summary>
        /// Manejador del evento MensajeEnviado del objeto mensajero.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        private void Mensajero_MensajeEnviado(object sender, MensajeEventArgs e)
        {
            OnMensajeEnviado(e.Mensaje);
        }
        #endregion Manejadores de eventos

        #region Métodos protegidos de eventos elevados
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

        #region Clase MensajeEnEspera
        /// <summary>
        /// Esta clase se utiliza para almacenar mensajería en espera (contexto) para un mensaje de petición hasta que se recibe la respuesta.
        /// </summary>
        private sealed class MensajeEnEspera
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase MensajeEnEspera.
            /// </summary>
            public MensajeEnEspera()
            {
                EventoEspera = new ManualResetEventSlim(false);
                Estado = EstadoMensajeEnEspera.EsperandoRespuesta;
            }
            #endregion

            #region Propiedades públicas
            /// <summary>
            /// Mensaje de respuesta para el mensaje de petición.
            /// (Null si la respuesta aún no se ha recibido).
            /// </summary>
            public IMensaje MensajeRespuesta { get; set; }
            /// <summary>
            /// ManualResetEvent para bloquear el hilo (thread) hasta que se ha recibido la respuesta.
            /// (ManualResetEventSlim proporciona una versión reducida de ManualResetEvent).
            /// </summary>
            public ManualResetEventSlim EventoEspera { get; private set; }
            /// <summary>
            /// Estado del mensaje de solicitud.
            /// </summary>
            public EstadoMensajeEnEspera Estado { get; set; }
            #endregion
        }
        /// <summary>
        /// Esta enumeración se utiliza para almacenar el estado de un mensaje en espera.
        /// </summary>
        private enum EstadoMensajeEnEspera
        {
            /// <summary>
            /// A la espera de respuesta.
            /// </summary>
            EsperandoRespuesta,
            /// <summary>
            /// Se cancela el envio de mensajes.
            /// </summary>
            Cancelado,
            /// <summary>
            /// La respuesta se recibió correctamente.
            /// </summary>
            RespuestaRecibida
        }
        #endregion Clase MensajeEnEspera
    }
}