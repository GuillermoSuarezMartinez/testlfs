//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using System.IO;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Listener
{
    /// <summary>
    /// Representa una escucha de comunicaciones.
    /// Una conexión oyente (listener) se utiliza para aceptar peticiones de conexión entrantes de clientes.
    /// </summary>
    internal interface IListener
    {
        /// <summary>
        /// Este evento se produce cuando se establece la escucha de conexiones entrantes con éxito.
        /// </summary>
        event EventHandler<EventArgs> Escuchando;
        /// <summary>
        /// Este evento se produce cuando se cierra el agente de escucha de conexiones entrantes con éxito.
        /// </summary>
        event EventHandler<EventArgs> NoEscuchando;
        /// <summary>
        /// Este evento se produce cuando se produce un error de conexión.
        /// </summary>
        event EventHandler<ErrorEventArgs> ErrorConexion;
        /// <summary>
        /// Este evento se produce cuando se conecta un nuevo canal de comunicación. Es decir,
        /// cuando un nuevo cliente acepta una comunicación de escucha.
        /// </summary>
        event EventHandler<CanalComunicacionEventArgs> CanalComunicacionConectado;
        /// <summary>
        /// Flag que permite establecer la reconexión de escuchas si se produce una excepción en el proceso de escucha.
        /// </summary>
        bool ReConexion { get; set; }
        /// <summary>
        /// Iniciar la escucha de peticiones de conexiones entrantes de clientes.
        /// </summary>
        void Iniciar();
        /// <summary>
        /// Terminar la escucha de peticiones de conexiones entrantes de clientes.
        /// </summary>
        void Terminar();
    }
}