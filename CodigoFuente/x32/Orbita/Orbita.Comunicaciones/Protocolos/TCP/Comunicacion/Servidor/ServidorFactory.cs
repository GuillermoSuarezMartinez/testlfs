//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Esta clase se utiliza para crear servidores.
    /// </summary>
    public static class ServidorFactory
    {
        #region Métodos públicos
        /// <summary>
        /// Crear un nuevo servidor utilizando endpoint.
        /// </summary>
        /// <param name="endPoint">Endpoint que representa la dirección del servidor.</param>
        /// <returns>Servidor Tcp.</returns>
        public static IServidor Crear(EndPoint endPoint)
        {
            return endPoint.CrearServidor();
        }
        #endregion Métodos públicos
    }
}