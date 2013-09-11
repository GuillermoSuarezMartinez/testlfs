//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Esta clase se utiliza para crear un servidor TCP.
    /// </summary>
    internal class TcpServidor : ServidorBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpServidor.
        /// </summary>
        /// <param name="endPoint">Dirección endpoint del servidor para escuchar las conexiones entrantes.</param>
        public TcpServidor(TcpEndPoint endPoint)
        {
            EndPoint = endPoint;
        }
        #endregion

        #region Métodos protegidos
        /// <summary>
        /// Crear un listener TCP.
        /// </summary>
        /// <returns>TcpListener.</returns>
        protected override IListener CrearListener()
        {
            return new TcpListenerConexion(EndPoint);
        }
        #endregion
    }
}