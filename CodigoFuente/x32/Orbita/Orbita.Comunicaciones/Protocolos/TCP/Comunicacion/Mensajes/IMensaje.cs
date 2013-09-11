//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
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