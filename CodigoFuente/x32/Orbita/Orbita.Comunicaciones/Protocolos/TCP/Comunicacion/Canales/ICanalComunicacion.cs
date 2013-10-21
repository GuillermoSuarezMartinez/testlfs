//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
{
    /// <summary>
    /// Representa un canal de comunicación.
    /// Un canal de comunicación se utiliza para comunicar (enviar/recibir mensajes) con una aplicación remota.
    /// </summary>
    internal interface ICanalComunicacion : IMensajero
    {
        /// <summary>
        /// Este evento se produce cuando se conecta el canal de comunicación con el cliente.
        /// </summary>
        event EventHandler Conectado;
        /// <summary>
        /// Este evento se produce cuando se cierra el canal de comunicación con el cliente.
        /// </summary>
        event EventHandler Desconectado;
        ///<summary>
        /// Obtener el endpoint de la aplicación remota.
        ///</summary>
        EndPoint EndPointRemoto { get; }
        /// <summary>
        /// Obtener el estado actual de la comunicación.
        /// </summary>
        EstadoComunicacion EstadoComunicacion { get; }
        /// <summary>
        /// Iniciar la comunicación con la aplicación remota.
        /// </summary>
        void Iniciar();
        /// <summary>
        /// Desconectar mensajero.
        /// </summary>
        void Desconectar();
    }
}