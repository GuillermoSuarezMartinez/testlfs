//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Representa un cliente desde la perspectiva de un servidor.
    /// </summary>
    public interface IServidorCliente : IMensajero
    {
        /// <summary>
        /// Este evento se produce cuando el cliente se conecta al servidor.
        /// </summary>
        event EventHandler Conectado;
        /// <summary>
        /// Este evento se produce cuando el cliente se desconecta del servidor.
        /// </summary>
        event EventHandler Desconectado;
        /// <summary>
        /// Identificador único para este cliente en el servidor.
        /// </summary>
        long IdentificadorAutoincremental { get; }
        ///<summary>
        /// Obtener el endpoint del servidor.
        ///</summary>
        EndPoint EndPointRemoto { get; }
        /// <summary>
        /// Obtener el estado de la comunicación actual.
        /// </summary>
        EstadoComunicacion EstadoComunicacion { get; }
        /// <summary>
        /// Desconectar del servidor.
        /// </summary>
        void Desconectar();
    }
}