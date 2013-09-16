//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using System.Net;
using System.Net.Sockets;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
{
    /// <summary>
    /// Esta clase se utiliza para comunicarse con una aplicación remotamente (canl de comunicación) a través de Tcp / IP.
    /// </summary>
    internal class TcpCanalComunicacion : CanalComunicacionBase
    {
        #region Atributos
        /// <summary>
        /// Tamaño del búfer que se utiliza para recibir bytes del socket Tcp.
        /// </summary>
        private const int TamañoBufferRecepcion = 4 * 1024; // 4 KB
        /// <summary>
        /// Búfer para recibir bytes.
        /// </summary>
        private readonly byte[] _bufferRecepcion;
        /// <summary>
        /// Socket para enviar/recibir mensajes.
        /// </summary>
        private readonly Socket _socketCliente;
        /// <summary>
        /// Flag para el control de funcionamiento del hilo (thread).
        /// </summary>
        private volatile bool _iniciado;
        /// <summary>
        /// Este objeto sólo se utiliza para la sincronización de threads (bloqueo).
        /// </summary>
        private readonly object _objSincronizacion;
        /// <summary>
        /// Endpoint de la aplicación remota.
        /// </summary>
        private readonly TcpEndPoint _endPointRemoto;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpCanalComunicacion.
        /// </summary>
        /// <param name="socketCliente">Un objeto socket conectado que se utiliza para comunicarse a través de la red.</param>
        public TcpCanalComunicacion(Socket socketCliente)
        {
            _socketCliente = socketCliente;
            _socketCliente.NoDelay = true;

            var ipEndPoint = (IPEndPoint)_socketCliente.RemoteEndPoint;
            _endPointRemoto = new TcpEndPoint(ipEndPoint.Address.ToString(), ipEndPoint.Port);

            _bufferRecepcion = new byte[TamañoBufferRecepcion];
            _objSincronizacion = new object();
        }
        #endregion Constructor

        #region Propiedades públicas
        ///<summary>
        /// Obtener el endpoint de la aplicación remota.
        ///</summary>
        public override EndPoints.EndPoint EndPointRemoto
        {
            get { return _endPointRemoto; }
        }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Desconectar de la aplicación remota y cerrar el canal.
        /// </summary>
        public override void Desconectar()
        {
            if (EstadoComunicacion != EstadoComunicacion.Conectado)
            {
                return;
            }
            _iniciado = false;
            try
            {
                if (_socketCliente.Connected)
                {
                    _socketCliente.Close();
                }
                _socketCliente.Dispose();
            }
            catch
            {
                //  Empty.
            }
            EstadoComunicacion = EstadoComunicacion.Desconectado;
            OnDesconectado();
        }
        #endregion Métodos públicos

        #region Métodos protegidos
        /// <summary>
        /// Iniciar el hilo (thread/callback) para enviar/recibir mensajes de socket.
        /// </summary>
        protected override void IniciarCanalComunicacion()
        {
            _iniciado = true;
            _socketCliente.BeginReceive(_bufferRecepcion, 0, _bufferRecepcion.Length, 0, RecepcionMensajes, null);
        }
        /// <summary>
        /// Enviar un mensaje a la aplicación remota.
        /// </summary>
        /// <param name="mensaje">Mensaje que se enviará.</param>
        protected override void EnviarMensajePorCanalComunicacion(IMensaje mensaje)
        {
            var totalBytesEnviados = 0;
            lock (_objSincronizacion)
            {
                var bytesMensaje = Telegrama.GetBytes(mensaje);
                while (totalBytesEnviados < bytesMensaje.Length)
                {
                    var bytesEnviados = _socketCliente.Send(bytesMensaje, totalBytesEnviados, bytesMensaje.Length - totalBytesEnviados, SocketFlags.None);
                    if (bytesEnviados <= 0)
                    {
                        throw new ExcepcionComunicacion(
                            "El mensaje no pudo ser enviado a través del socket Tcp. Se han enviado " +
                            totalBytesEnviados + " bytes de " + bytesMensaje.Length + " bytes.");
                    }

                    totalBytesEnviados += bytesEnviados;
                }

                FechaUltimoMensajeEnviado = DateTime.Now;
                OnMensajeEnviado(mensaje);
            }
        }
        #endregion Métodos protegidos

        #region Métodos privados
        /// <summary>
        /// Este método se utiliza como método de devolución de llamada (callback) en el método BeginReceive de _socketCliente.
        /// </summary>
        /// <param name="resultadoAsincrono">Representa el estado de una operación asíncrona.</param>
        private void RecepcionMensajes(IAsyncResult resultadoAsincrono)
        {
            if (!_iniciado)
            {
                return;
            }
            try
            {
                //  Obtener el número de bytes recibidos tras la finalización de una lectura asíncrona pendiente.
                var bytesLeidos = _socketCliente.EndReceive(resultadoAsincrono);
                if (bytesLeidos > 0)
                {
                    FechaUltimoMensajeRecibido = DateTime.Now;

                    //  Copiar los bytes recibidos al nuevo array de bytes.
                    var bytesRecibidos = new byte[bytesLeidos];
                    Array.Copy(_bufferRecepcion, 0, bytesRecibidos, 0, bytesLeidos);

                    //  Leer los mensajes de acuerdo al actual telegrama.
                    var mensajes = Telegrama.CrearMensajes(bytesRecibidos);

                    //  Elevar el evento MensajeRecibido para todos los mensajes recibidos.
                    foreach (var mensaje in mensajes)
                    {
                        OnMensajeRecibido(mensaje);
                    }
                }
                else
                {
                    throw new ExcepcionComunicacion("Socket Tcp está cerrado.");
                }
                //  Leer más bytes si aún está recibiendo.
                _socketCliente.BeginReceive(_bufferRecepcion, 0, _bufferRecepcion.Length, 0, RecepcionMensajes, null);
            }
            catch
            {
                Desconectar();
            }
        }
        #endregion Métodos privados
    }
}