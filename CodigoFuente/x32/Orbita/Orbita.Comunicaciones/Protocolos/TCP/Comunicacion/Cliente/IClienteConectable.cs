//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Representa un cliente conectable a servidores.
    /// </summary>
    public interface IClienteConectable : IDisposable
    {
        /// <summary>
        /// Timeout para la conexión a un servidor (en milisegundos).
        /// Valor predeterminado: 15 segundos (15000 ms).
        /// </summary>
        int TimeoutConexionMs { get; set; }
        /// <summary>
        /// Endpoint del cliente.
        /// </summary>
        TcpEndPoint EndPointLocal { get; set; }
        /// <summary>
        /// Obtener el estado actual de comunicación.
        /// </summary>
        EstadoComunicacion EstadoComunicacion { get; }
        /// <summary>
        /// Este evento se produce cuando el cliente se conecta al servidor.
        /// </summary>
        event EventHandler Conectado;
        /// <summary>
        /// Este evento se produce cuando el cliente se desconecta del servidor.
        /// </summary>
        event EventHandler Desconectado;
        /// <summary>
        /// Conectar al servidor.
        /// </summary>
        void Conectar();
        /// <summary>
        /// Desconectar del servidor.
        /// No hace nada si ya se encuentra desconectado.
        /// </summary>
        void Desconectar();
    }
}