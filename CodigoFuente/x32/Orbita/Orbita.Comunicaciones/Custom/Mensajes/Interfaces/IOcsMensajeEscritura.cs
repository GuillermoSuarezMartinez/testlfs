//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

namespace Orbita.Comunicaciones
{
    ///<summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    ///</summary>
    public interface IOcsMensajeEscritura : IOcsMensajeBase
    {
        /// <summary>
        /// Resultado de la escritura en el dispositivo.
        /// </summary>
        bool Respuesta { get; set; }
        /// <summary>
        /// Identificador del canal cliente.
        /// </summary>
        string Canal { get; }
    }
}