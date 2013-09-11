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
using Orbita.Comunicaciones.Protocolos.Tcp.Colecciones;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Representa un servidor que se utiliza para aceptar y gestionar las conexiones de clientes.
    /// </summary>
    public interface IServidor
    {
        /// <summary>
        /// Este evento se produce cuando se establece la escucha de conexiones entrantes con éxito.
        /// </summary>
        event EventHandler<EventArgs> Conectado;
        /// <summary>
        /// Este evento se produce cuando se cierra el agente de escucha de conexiones entrantes con éxito.
        /// </summary>
        event EventHandler<EventArgs> Desconectado;
        /// <summary>
        /// Este evento se produce cuando un nuevo cliente se conecta al servidor.
        /// </summary>
        event EventHandler<ServidorClienteEventArgs> ClienteConectado;
        /// <summary>
        /// Este evento se produce cuando un cliente se desconecta del servidor.
        /// </summary>
        event EventHandler<ServidorClienteEventArgs> ClienteDesconectado;
        /// <summary>
        /// Este evento se produce cuando un cliente no puede conectar al servidor.
        /// </summary>
        event EventHandler<ServidorErrorEventArgs> ErrorConexion;
        /// <summary>
        /// Obtener/establecer el TelegramaFactory para crear objectos ITelegrama.
        /// </summary>
        ITelegramaFactory TelegramaFactory { get; set; }
        /// <summary>
        /// Colección de clientes que están conectados al servidor.
        /// </summary>
        ThreadSafeSortedList<long, IServidorCliente> Clientes { get; }
        /// <summary>
        /// Flag que permite establecer la reconexión de escuchas si se produce una excepción en el proceso de escucha.
        /// </summary>
        bool ReConexion { get; set; }
        /// <summary>
        /// Dirección endpoint del servidor para escuchar las conexiones entrantes.
        /// </summary>
        TcpEndPoint EndPoint { get; }
        /// <summary>
        /// Iniciar el servidor.
        /// </summary>
        void Iniciar();
        /// <summary>
        /// Parar el servidor.
        /// </summary>
        void Parar();
    }
}