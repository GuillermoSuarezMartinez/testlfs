//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Representa un mensaje que se envía y recibe por el servidor y el cliente.
    /// </summary>
    public interface IMensaje
    {
        /// <summary>
        /// Identificador único para este mensaje. 
        /// </summary>
        string IdMensaje { get; }
        /// <summary>
        /// Identificador único para este mensaje de respuesta. 
        /// </summary>
        string IdMensajeRespuesta { get; set; }
    }
}