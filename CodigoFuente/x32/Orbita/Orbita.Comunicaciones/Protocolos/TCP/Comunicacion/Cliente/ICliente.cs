//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Representa un cliente para conectarse al servidor.
    /// </summary>
    public interface ICliente : IMensajero, IClienteConectable
    {
        /// <summary>
        /// Endpoint del servidor.
        /// </summary>
        TcpEndPoint EndPointRemoto { get; }
        ///// <summary>
        ///// Obtener el objeto IMensajero subyacente.
        ///// </summary>
        //IMensajero Mensajero { get; set; }
    }
}