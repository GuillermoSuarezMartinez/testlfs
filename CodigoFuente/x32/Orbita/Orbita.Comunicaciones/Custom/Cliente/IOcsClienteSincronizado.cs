﻿//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Representa un cliente para conectarse al servidor.
    /// </summary>
    public interface IOcsClienteSincronizado : IOcsMensajeroSincronizado
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
        /// Conectar al servidor.
        /// </summary>
        void Conectar();
        /// <summary>
        /// Desconectar del servidor.
        /// No hace nada si ya se encuentra desconectado.
        /// </summary>
        void Desconectar();
        /// <summary>
        /// Obtener el estado actual de comunicación.
        /// </summary>
        EstadoComunicacion EstadoComunicacion { get; }
    }
}