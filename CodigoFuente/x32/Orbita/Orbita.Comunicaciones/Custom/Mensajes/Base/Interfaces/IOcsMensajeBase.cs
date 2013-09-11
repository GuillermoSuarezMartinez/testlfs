//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

namespace Orbita.Comunicaciones
{
    ///<summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    ///</summary>
    public interface IOcsMensajeBase : IOcsMensaje
    {
        /// <summary>
        /// Colección de variables del dispositivo.
        /// </summary>
        string[] Variables { get; }
        /// <summary>
        /// Colección de valores resultado de la colección de variables vinculada.
        /// </summary>
        object[] Valores { get; }
    }
}