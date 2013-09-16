//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Colecciones;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;
using System.IO;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para todas las clases servidor.
    /// </summary>
    internal abstract class ServidorBase : IServidor
    {
        #region Eventos públicos
        /// <summary>
        /// Este evento se produce cuando se establece la escucha de conexiones entrantes con éxito.
        /// </summary>
        public event EventHandler<EventArgs> Conectado;
        /// <summary>
        /// Este evento se produce cuando se cierra el agente de escucha de conexiones entrantes con éxito.
        /// </summary>
        public event EventHandler<EventArgs> Desconectado;
        /// <summary>
        /// Este evento se produce cuando se conecta un nuevo cliente.
        /// </summary>
        public event EventHandler<ServidorClienteEventArgs> ClienteConectado;
        /// <summary>
        /// Este evento se produce cuando un cliente se desconecta del servidor.
        /// </summary>
        public event EventHandler<ServidorClienteEventArgs> ClienteDesconectado;
        /// <summary>
        /// Este evento se produce cuando un cliente no puede conectar al servidor.
        /// </summary>
        public event EventHandler<ServidorErrorEventArgs> ErrorConexion;
        #endregion Eventos públicos

        #region Atributos
        /// <summary>
        /// Este objeto se utiliza para escuchar (listener) conexiones entrantes.
        /// </summary>
        private IListener _listener;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ServidorBase.
        /// </summary>
        protected ServidorBase()
        {
            Clientes = new ThreadSafeSortedList<long, IServidorCliente>();
            TelegramaFactory = TelegramaManager.GetTelegramaFactoryPredeterminado();
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Obtener/establecer el telegrama que se utiliza durante la lectura y escritura de mensajes.
        /// </summary>
        public ITelegramaFactory TelegramaFactory { get; set; }
        /// <summary>
        /// Colección de clientes que están conectados al servidor.
        /// </summary>
        public ThreadSafeSortedList<long, IServidorCliente> Clientes { get; private set; }
        /// <summary>
        /// Flag que permite establecer la reconexión de escuchas si se produce una excepción en el proceso de escucha.
        /// Establecer el valor previo a Iniciar(...) el servidor.
        /// </summary>
        public bool ReConexion { get; set; }
        /// <summary>
        /// Dirección endpoint del servidor para escuchar las conexiones entrantes.
        /// </summary>
        public TcpEndPoint EndPoint { get; internal set; }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Iniciar el servidor.
        /// </summary>
        public virtual void Iniciar()
        {
            _listener = CrearListener();
            _listener.ReConexion = ReConexion;
            _listener.Escuchando += Listener_Escuchando;
            _listener.NoEscuchando += Listener_NoEscuchando;
            _listener.CanalComunicacionConectado += Listener_CanalComunicacionConectado;
            _listener.ErrorConexion += Listener_ErrorConexion;
            _listener.Iniciar();
        }
        /// <summary>
        /// Parar el servidor.
        /// </summary>
        public virtual void Parar()
        {
            if (_listener != null)
            {
                _listener.Terminar();
            }
            foreach (var cliente in Clientes.ObtenerTodosLosElementos())
            {
                cliente.Desconectar();
            }
        }
        /// <summary>
        /// Enviar un mensaje a todos los clientes conectados.
        /// </summary>
        public virtual void Broadcast(IMensaje mensaje)
        {
            foreach (var cliente in Clientes.ObtenerTodosLosElementos())
            {
                cliente.EnviarMensaje(mensaje);
            }
        }
        #endregion Métodos públicos

        #region Métodos protegidos abstractos
        /// <summary>
        /// Este método es implementado por las clases derivadas para crear un oyente (listener) 
        /// que escucha las solicitudes de petición de conexiones entrantes.
        /// </summary>
        /// <returns></returns>
        protected abstract IListener CrearListener();
        #endregion Métodos protegidos abstractos

        #region Manejadores de eventos
        /// <summary>
        /// Manejador del evento Escuchando.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void Listener_Escuchando(object sender, EventArgs e)
        {
            OnConectado();
        }
        /// <summary>
        /// Manejador del evento NoEscuchando.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void Listener_NoEscuchando(object sender, EventArgs e)
        {
            OnDesconectado();
        }
        /// <summary>
        /// Manejador del evento ErrorConexion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void Listener_ErrorConexion(object sender, ErrorEventArgs e)
        {
            _listener.Escuchando -= Listener_Escuchando;
            _listener.NoEscuchando -= Listener_NoEscuchando;
            _listener.CanalComunicacionConectado -= Listener_CanalComunicacionConectado;
            _listener.ErrorConexion -= Listener_ErrorConexion;
            OnErrorConexion(e.GetException());
        }
        /// <summary>
        /// Manejador del evento CanalComunicacionConectado.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">CanalComunicacionEventArgs que contiene los datos del evento.</param>
        private void Listener_CanalComunicacionConectado(object sender, CanalComunicacionEventArgs e)
        {
            var cliente = new ServidorCliente(e.Canal)
            {
                IdentificadorAutoincremental = ServidorManager.GetIdentificadorAutoincremental(),
                Telegrama = TelegramaFactory.CrearTelegrama()
            };
            cliente.Conectado += Cliente_Conectado;
            cliente.Desconectado += Cliente_Desconectado;
            Clientes[cliente.IdentificadorAutoincremental] = cliente;

            e.Canal.Iniciar();
        }
        /// <summary>
        /// Manejador del evento Conectado para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void Cliente_Conectado(object sender, EventArgs e)
        {
            var cliente = (IServidorCliente)sender;
            OnClienteConectado(cliente);
        }
        /// <summary>
        /// Manejador del evento Desconectado para todos los clientes conectados.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void Cliente_Desconectado(object sender, EventArgs e)
        {
            var cliente = (IServidorCliente)sender;
            Clientes.Eliminar(cliente.IdentificadorAutoincremental);
            OnClienteDesconectado(cliente);
        }
        #endregion Manejadores de eventos

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
        /// Elevar el evento ClienteConectado.
        /// </summary>
        /// <param name="cliente">Cliente conectado.</param>
        protected virtual void OnClienteConectado(IServidorCliente cliente)
        {
            var handler = ClienteConectado;
            if (handler != null)
            {
                handler(this, new ServidorClienteEventArgs(cliente));
            }
        }
        /// <summary>
        /// Elevar el evento ClienteDesconectado.
        /// </summary>
        /// <param name="cliente">Cliente desconectado.</param>
        protected virtual void OnClienteDesconectado(IServidorCliente cliente)
        {
            var handler = ClienteDesconectado;
            if (handler != null)
            {
                handler(this, new ServidorClienteEventArgs(cliente));
            }
        }
        protected virtual void OnErrorConexion(Exception ex)
        {
            var handler = ErrorConexion;
            if (handler != null)
            {
                handler(this, new ServidorErrorEventArgs(EndPoint, ex));
            }
        }
        #endregion Métodos protegidos de eventos elevados
    }
}