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
using System.Net;
using System.Net.Sockets;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Esta clase se utiliza para simplificar las operaciones del socket TCP.
    /// </summary>
    internal static class TcpHelper
    {
        #region Métodos públicos
        /// <summary>
        /// Este código se utiliza para conectarse a un socket TCP con el parámetro tiempo de espera en milisegundos.
        /// </summary>
        /// <param name="endPointRemoto">IP endpoint del servidor remoto.</param>
        /// <param name="timeoutMs">Timeout de espera hasta conectar.</param>
        /// <returns>Objeto socket conectado al servidor.</returns>
        /// <exception cref="SocketException">Throws SocketException si no puede conectar.</exception>
        /// <exception cref="TimeoutException">Throws TimeoutException si no puede conectar dentro del timeoutMs especificado.</exception>
        public static Socket ConectarAlServidor(EndPoint endPointRemoto, int timeoutMs)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Blocking = false;
                socket.Connect(endPointRemoto);
                socket.Blocking = true;
                return socket;
            }
            catch (SocketException ex)
            {
                //  Resource temporarily unavailable. This error is returned from operations on nonblocking 
                //  sockets that cannot be completed immediately, for example recv when no data is queued to 
                //  be read from the socket. It is a nonfatal error, and the operation should be retried later. 
                //  It is normal for WSAEWOULDBLOCK to be reported as the result from calling connect (Windows Sockets)
                //  on a nonblocking SOCK_STREAM socket, since some time must elapse for the connection to be established.
                if (ex.ErrorCode != 10035)
                {
                    socket.Close();
                    throw;
                }
                if (!socket.Poll(timeoutMs * 1000, SelectMode.SelectWrite))
                {
                    socket.Close();
                    throw new TimeoutException("El host falló al conectar. Tiempo de espera agotado.");
                }
                socket.Blocking = true;
                return socket;
            }
        }
        /// <summary>
        /// Este código se utiliza para conectarse a un socket TCP con el parámetro tiempo de espera en milisegundos.
        /// </summary>
        /// <param name="endPointRemoto">Endpoint del servidor.</param>
        /// <param name="endPointLocal">Endpoint del cliente.</param>
        /// <param name="timeoutMs">Timeout de espera hasta conectar.</param>
        /// <returns>Objeto socket conectado al servidor.</returns>
        /// <exception cref="SocketException">Throws SocketException si no puede conectar.</exception>
        /// <exception cref="TimeoutException">Throws TimeoutException si no puede conectar dentro del timeoutMs especificado.</exception>
        public static Socket ConectarAlServidor(EndPoint endPointRemoto, EndPoint endPointLocal, int timeoutMs)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Blocking = false;
                socket.Bind(endPointLocal);
                socket.Connect(endPointRemoto);
                socket.Blocking = true;
                return socket;
            }
            catch (SocketException ex)
            {
                //  Resource temporarily unavailable. This error is returned from operations on nonblocking 
                //  sockets that cannot be completed immediately, for example recv when no data is queued to 
                //  be read from the socket. It is a nonfatal error, and the operation should be retried later. 
                //  It is normal for WSAEWOULDBLOCK to be reported as the result from calling connect (Windows Sockets)
                //  on a nonblocking SOCK_STREAM socket, since some time must elapse for the connection to be established.
                if (ex.ErrorCode != 10035)
                {
                    socket.Close();
                    throw;
                }
                if (!socket.Poll(timeoutMs * 1000, SelectMode.SelectWrite))
                {
                    socket.Close();
                    throw new TimeoutException("El host falló al conectar. Tiempo de espera agotado.");
                }
                socket.Blocking = true;
                return socket;
            }
        }
        #endregion
    }
}