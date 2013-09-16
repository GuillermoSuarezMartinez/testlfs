//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    ///<summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    ///</summary>
    public interface IOcsMensajeLecturaDatos : IOcsMensaje
    {
        /// <summary>
        /// Colección de datos.
        /// </summary>
        OHashtable Datos { get; }
    }
}