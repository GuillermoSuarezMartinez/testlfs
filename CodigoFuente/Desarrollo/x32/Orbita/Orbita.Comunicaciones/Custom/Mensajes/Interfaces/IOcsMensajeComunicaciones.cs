﻿//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

namespace Orbita.Comunicaciones
{
    ///<summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    ///</summary>
    public interface IOcsMensajeComunicaciones : IMensaje
    {
        /// <summary>
        /// Información del estado del servidor de comunicaciones.
        /// </summary>
        OEstadoComms InfoComm { get; }
    }
}