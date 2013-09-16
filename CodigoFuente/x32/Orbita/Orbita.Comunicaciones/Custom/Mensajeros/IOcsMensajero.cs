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
    public interface IOcsMensajero
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
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura alarmas activas.
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
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de variables.
        /// </summary>
        event EventHandler<OcsMensajeLecturaEventArgs> MensajeRecibidoLectura;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de datos.
        /// </summary>
        event EventHandler<OcsMensajeLecturaDatosEventArgs> MensajeRecibidoLecturaDatos;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de alarmas activas.
        /// </summary>
        event EventHandler<OcsMensajeLecturaAlarmasActivasEventArgs> MensajeRecibidoLecturaAlarmasActivas;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de dispositivos.
        /// </summary>
        event EventHandler<OcsMensajeLecturaDispositivosEventArgs> MensajeRecibidoLecturaDispositivos;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de escritura de variables.
        /// </summary>
        event EventHandler<OcsMensajeEscrituraEventArgs> MensajeRecibidoEscritura;
        /// <summary>
        /// Leer la colección de valores de variables.
        /// </summary>
        void Leer(int dispositivo, string[] variables, bool demanda);
        /// <summary>
        /// Leer la colección de datos del dispositivo especificado.
        /// </summary>
        void LeerDatos(int dispositivo);
        /// <summary>
        /// Leer la colección de alarmas activas del dispositivo especificado.
        /// </summary>
        void LeerAlarmasActivas(int dispositivo);
        /// <summary>
        /// Leer la colección de dispositivos.
        /// </summary>
        void LeerDispositivos();
        /// <summary>
        /// Escribir la colección de valores de variables en el dispositivo identificando el canal.
        /// </summary>
        void Escribir(int dispositivo, string[] variables, object[] valores, string canal);
    }
}