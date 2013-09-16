//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros
{
    /// <summary>
    /// Esta clase es un contenedor para IMessenger y se utiliza para sincronizar la operación de recepción de mensaje.
    /// Es una extensión de MensajeroPeticionRespuesta.
    /// Es adecuado su uso en aplicaciones donde se quiera recibir mensajes producidos por llamadas de métodos
    /// sincronizados, en vez de, eventos de mensajes de recepción asincronos.
    /// </summary>
    public class MensajeroSincronizado<T> : MensajeroPeticionRespuesta<T> where T : IMensajero
    {
        #region Atributos
        /// <summary>
        /// Cola que se utiliza para almacenar mensajes recibidos.
        /// </summary>
        private readonly Queue<IMensaje> _colaMensajesRecibidos;
        /// <summary>
        /// Este objeto se utiliza para sincronizar esperas de hilos (threads).
        /// </summary>
        private readonly ManualResetEventSlim _eventoEspera;
        /// <summary>
        /// Flag para el control de funcionamiento de la clase.
        /// </summary>
        private volatile bool _iniciado;
        #endregion Atributos

        #region Constructores
        ///<summary>
        /// Inicializar una nueva instancia de la clase MensajeroSincronizado.
        ///</summary>
        ///<param name="mensajero">Mensajero que se utiliza para enviar/recibir mensajes.</param>
        public MensajeroSincronizado(T mensajero)
            : this(mensajero, int.MaxValue) { }
        ///<summary>
        /// Inicializar una nueva instancia de la clase MensajeroSincronizado.
        ///</summary>
        ///<param name="mensajero">Mensajero que se utiliza para enviar/recibir mensajes.</param>
        ///<param name="tamañoColaMensajesEntrantes">Tamaño de la cola de entrada de mensajes.</param>
        public MensajeroSincronizado(T mensajero, int tamañoColaMensajesEntrantes)
            : base(mensajero)
        {
            _eventoEspera = new ManualResetEventSlim();
            _colaMensajesRecibidos = new Queue<IMensaje>();
            TamañoColaMensajesEntrantes = tamañoColaMensajesEntrantes;
        }
        #endregion Constructores

        #region Propiedades públicas
        ///<summary>
        /// Obtener/establecer el tamaño de la cola de entrada de mensajes.
        /// No se recibe ningún mensaje de la aplicación remota si el número de mensajes en la cola interna excede este valor.
        /// Valor predeterminado: int.MaxValue (2147483647).
        ///</summary>
        public int TamañoColaMensajesEntrantes { get; set; }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Iniciar el mensajero.
        /// </summary>
        public override void Iniciar()
        {
            lock (_colaMensajesRecibidos)
            {
                _iniciado = true;
            }
            base.Iniciar();
        }
        /// <summary>
        /// Parar el mensajero.
        /// </summary>
        public override void Parar()
        {
            base.Parar();
            lock (_colaMensajesRecibidos)
            {
                _iniciado = false;
                _eventoEspera.Set();
            }
        }
        /// <summary>
        /// Este método se utiliza para recibir un mensaje de aplicación remota.
        /// Espera infinito hasta que se recibe un mensaje.
        /// </summary>
        /// <returns>Mensaje recibido.</returns>
        public IMensaje RecibirMensaje()
        {
            return RecibirMensaje(Timeout.Infinite);
        }
        /// <summary>
        /// Este método se utiliza para recibir un mensaje de aplicación remota.
        /// Espera hasta que se recibe un mensaje o se produce el tiempo de espera.
        /// </summary>
        /// <param name="timeout">
        /// Valor de tiempo de espera que espera hasta recibir un mensaje.
        /// Utilizar -1 para esperar indefinidamente.
        /// </param>
        /// <returns>Mensaje recibido.</returns>
        /// <exception cref="TimeoutException">Throws TimeoutException; si ha sobrepasado el tiempo de espera (timeout).</exception>
        /// <exception cref="Exception">Throws Exception; si la clase MensajeroSincronizado termina antes que el mensaje se ha recibido.</exception>
        public IMensaje RecibirMensaje(int timeout)
        {
            while (_iniciado)
            {
                lock (_colaMensajesRecibidos)
                {
                    // Recibe un mensaje inmediatamente.
                    if (_colaMensajesRecibidos.Count > 0)
                    {
                        return _colaMensajesRecibidos.Dequeue();
                    }
                    _eventoEspera.Reset();
                }

                // Bloquea el subproceso actual.
                var resultado = _eventoEspera.Wait(timeout);

                //  Es true si se estableció el objeto System.Threading.ManualResetEventSlim;
                //  de lo contrario, es false.
                if (!resultado)
                {
                    throw new TimeoutException("Tiempo de espera caducado. No se puede recibir ningún mensaje.");
                }
            }
            throw new Exception("MensajeroSincronizado parado. No se puede recibir ningún mensaje.");
        }
        /// <summary>
        /// Este método se utiliza para recibir un tipo específico de mensaje de aplicación remota.
        /// Espera infinito hasta que se recibe un mensaje.
        /// </summary>
        /// <returns>Mensaje recibido.</returns>
        public TMensaje RecibirMensaje<TMensaje>() where TMensaje : IMensaje
        {
            return RecibirMensaje<TMensaje>(Timeout.Infinite);
        }
        /// <summary>
        /// Este método se utiliza para recibir un tipo específico de mensaje de aplicación remota.
        /// Espera hasta que se recibe un mensaje o se produce el tiempo de espera.
        /// </summary>
        /// <param name="timeout">
        /// Valor de tiempo de espera que espera hasta recibir un mensaje.
        /// Utilizar -1 para esperar indefinidamente.
        /// </param>
        /// <returns>Mensaje recibido.</returns>
        public TMensaje RecibirMensaje<TMensaje>(int timeout) where TMensaje : IMensaje
        {
            var mensajeRecibido = RecibirMensaje(timeout);
            if (!(mensajeRecibido is TMensaje))
            {
                throw new Exception("Se ha recibido un mensajes inesperado." +
                                    " Tipo esperado: " + typeof(TMensaje).Name +
                                    ". Tipo de mensaje recibido: " + mensajeRecibido.GetType().Name);
            }
            return (TMensaje)mensajeRecibido;
        }
        #endregion Métodos públicos

        #region Métodos protegidos
        /// <summary>
        /// Evento MensajeRecibido.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected override void OnMensajeRecibido(IMensaje mensaje)
        {
            lock (_colaMensajesRecibidos)
            {
                if (_colaMensajesRecibidos.Count < TamañoColaMensajesEntrantes)
                {
                    _colaMensajesRecibidos.Enqueue(mensaje);
                }
                _eventoEspera.Set();
            }
        }
        #endregion Métodos protegidos
    }
}