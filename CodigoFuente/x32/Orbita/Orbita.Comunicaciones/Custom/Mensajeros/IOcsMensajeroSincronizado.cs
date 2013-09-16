//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Representa un objeto que puede enviar y recibir mensajes.
    /// </summary>
    public interface IOcsMensajeroSincronizado
    {
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de variables.
        /// </summary>
        event EventHandler<OcsMensajeLecturaEventArgs> MensajeEnviadoLectura;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de datos.
        /// </summary>
        event EventHandler<OcsMensajeEventArgs> MensajeEnviadoLecturaDatos;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de alarmas activas.
        /// </summary>
        event EventHandler<OcsMensajeEventArgs> MensajeEnviadoLecturaAlarmasActivas;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de dispositivos.
        /// </summary>
        event EventHandler<MensajeEventArgs> MensajeEnviadoLecturaDispositivos;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de escritura de variables.
        /// </summary>
        event EventHandler<OcsMensajeEscrituraEventArgs> MensajeEnviadoEscritura;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de cambio de dato.
        /// </summary>
        event EventHandler<OcsMensajeInfoDatoEventArgs> MensajeRecibidoCambioDato;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de alarma.
        /// </summary>
        event EventHandler<OcsMensajeInfoDatoEventArgs> MensajeRecibidoAlarma;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de comunicaciones.
        /// </summary>
        event EventHandler<OcsMensajeComunicacionesEventArgs> MensajeRecibidoComunicaciones;
        /// <summary>
        /// Leer la colección de valores de variables demandadas en el dispositivo.
        /// </summary>
        IOcsMensajeLectura Leer(int dispositivo, string[] variables, bool demanda, int timeoutMs = 60000);
        /// <summary>
        /// Leer la colección de datos del dispositivo especificado.
        /// </summary>
        IOcsMensajeLecturaDatos LeerDatos(int dispositivo, int timeoutMs = 60000);
        /// <summary>
        /// Leer la colección de alarmas activas del dispositivo especificado.
        /// </summary>
        IOcsMensajeLecturaAlarmasActivas LeerAlarmasActivas(int dispositivo, int timeoutMs = 60000);
        /// <summary>
        /// Leer la colección de dispositivos.
        /// </summary>
        IOcsMensajeLecturaDispositivos LeerDispositivos(int timeoutMs = 60000);
        /// <summary>
        /// Escribir la colección de valores de variables en el dispositivo identificando el canal.
        /// </summary>
        IOcsMensajeEscritura Escribir(int dispositivo, string[] variables, object[] valores, string canal, int timeoutMs = 60000);
    }
}