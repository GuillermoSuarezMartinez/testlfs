//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones
{
    ///<summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    ///</summary>
    public interface IOcsMensajeErrorBase : IMensaje
    {
        /// <summary>
        /// Representa el error que se produce durante la ejecución de una aplicación.
        /// </summary>
        Exception Error { get; }
    }
}