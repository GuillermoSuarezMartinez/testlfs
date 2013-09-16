//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Mensajeros
{
    /// <summary>
    /// Representa un objeto que puede enviar y recibir mensajes.
    /// </summary>
    public interface IMensajero
    {
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje.
        /// </summary>
        event EventHandler<MensajeEventArgs> MensajeRecibido;
        /// <summary>
        /// Este evento se produce cuando un nuevo mensaje es enviado sin ningún error.
        /// Esto no garantiza que el mensaje es obtenido y procesado por la aplicación remota correctamente.
        /// </summary>
        event EventHandler<MensajeEventArgs> MensajeEnviado;
        /// <summary>
        /// Obtener/establecer el telegrama que se utiliza durante la lectura y escritura de mensajes.
        /// </summary>
        ITelegrama Telegrama { get; set; }
        /// <summary>
        /// Obtener la fecha del último mensaje recibido satisfactoriamente.
        /// </summary>
        DateTime FechaUltimoMensajeRecibido { get; }
        /// <summary>
        /// Obtener la fecha del último mensaje enviado satisfactoriamente.
        /// </summary>
        DateTime FechaUltimoMensajeEnviado { get; }
        /// <summary>
        /// Enviar un mensaje a la aplicación remota.
        /// </summary>
        /// <param name="mensaje">Mensaje enviado.</param>
        void EnviarMensaje(IMensaje mensaje);
    }
}