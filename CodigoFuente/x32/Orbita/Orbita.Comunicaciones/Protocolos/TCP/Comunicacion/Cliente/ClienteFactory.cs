//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Esta clase se utiliza para crear clientes para conectarse a un servidor.
    /// </summary>
    public static class ClienteFactory
    {
        #region Métodos públicos
        /// <summary>
        /// Crear un nuevo cliente para conectarse a un servidor utilizando un endpoint.
        /// </summary>
        /// <param name="endPointRemoto">Endpoint del servidor a conectarse.</param>
        /// <returns>Cliente Tcp.</returns>
        public static ICliente Crear(EndPoint endPointRemoto)
        {
            return endPointRemoto.CrearCliente();
        }
        /// <summary>
        /// Crear un nuevo cliente para conectarse a un servidor utilizando un endpoint.
        /// </summary>
        /// <param name="direccionEndpoint">Dirección endpoint del servidor a conectarse.</param>
        /// <returns>Cliente Tcp.</returns>
        public static ICliente Crear(string direccionEndpoint)
        {
            return Crear(EndPoint.CrearEndPoint(direccionEndpoint));
        }
        #endregion Métodos públicos
    }
}