//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System.Collections;

namespace Orbita.Comunicaciones
{
    ///<summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    ///</summary>
    public interface IOcsMensajeLecturaAlarmasActivas : IOcsMensaje
    {
        /// <summary>
        /// Colección de datos de alarmas activas.
        /// </summary>
        ArrayList Datos { get; }
    }
}