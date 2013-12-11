//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System.Net.Sockets;
using System.Threading;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener
{
    /// <summary>
    /// Esta clase se utiliza para escuchar (listener) y aceptar peticiones de conexiones entrantes de clientes, en un puerto Tcp.
    /// </summary>
    internal class TcpListenerConexion : ListenerBase
    {
        #region Atributos
        /// <summary>
        /// La dirección endpoint del servidor para escuchar las peticiones de conexiones entrantes.
        /// </summary>
        private readonly TcpEndPoint _endPoint;
        /// <summary>
        /// Socket del lado del servidor (TcpListener) para escuchar peticiones de conexiones entrantes.
        /// </summary>
        private TcpListener _socketListener;
        /// <summary>
        /// Hilo (thread) del proceso de escucha.
        /// </summary>
        private Thread _thread;
        /// <summary>
        /// Flag para el control de funcionamiento del hilo (thread).
        /// </summary>
        private volatile bool _iniciado;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpListenerConexion.
        /// </summary>
        /// <param name="endPoint">La dirección endpoint del servidor para escuchar las conexiones entrantes.</param>
        public TcpListenerConexion(TcpEndPoint endPoint)
        {
            _endPoint = endPoint;
        }
        #endregion Constructor

        #region Métodos públicos
        /// <summary>
        /// Iniciar el proceso (thread) de escucha de peticiones de conexiones entrantes.
        /// </summary>
        public override void Iniciar()
        {
            if (!Escuchar()) return;
            _iniciado = true;
            _thread = new Thread(ProcesoEscucha);
            _thread.Start();
        }
        /// <summary>
        /// Terminar la escucha de peticiones de conexiones entrantes.
        /// </summary>
        public override void Terminar()
        {
            NoEscuchar();
            _iniciado = false;
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Iniciar la escucha de peticiones de conexiones entrantes (new TcpListener).
        /// </summary>
        private bool Escuchar()
        {
            try
            {
                _socketListener = new TcpListener(System.Net.IPAddress.Any, _endPoint.PuertoTcp);
                _socketListener.Start();
                OnEscuchando();
                return true;
            }
            catch (SocketException ex)
            {
                OnErrorConexion(ex);
                return false;
            }
        }
        /// <summary>
        /// Cerrar el agente de escucha.
        /// </summary>
        private void NoEscuchar()
        {
            if (!_iniciado) return;
            _socketListener.Stop();
            OnNoEscuchando();
        }
        /// <summary>
        /// Proceso de entrada del hilo (thread).
        /// Este método es utilizado por el hilo (thread) para escuchar peticiones de conexiones entrantes.
        /// </summary>
        private void ProcesoEscucha()
        {
            while (_iniciado)
            {
                try
                {
                    var socketCliente = _socketListener.AcceptSocket();
                    if (socketCliente.Connected)
                    {
                        OnCanalComunicacionConectado(new TcpCanalComunicacion(socketCliente));
                    }
                }
                catch
                {
                    if (!ReConexion) return;

                    //  Desconectar, esperar un tiempo y volver a conectar según la activación del flag.
                    NoEscuchar();
                    Thread.Sleep(500);
                    try
                    {
                        Escuchar();
                        _iniciado = true;
                    }
                    catch
                    {
                        //  Empty.
                    }
                }
                //  Establecer un micro tiempo de retardo adecuado en este tipo de hilos (threads).
                Thread.Sleep(10);
            }
        }
        #endregion Métodos privados
    }
}