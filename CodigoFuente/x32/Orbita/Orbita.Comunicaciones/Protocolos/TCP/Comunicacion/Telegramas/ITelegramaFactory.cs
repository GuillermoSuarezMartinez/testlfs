//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas
{
    ///<summary>
    /// Define una clase Factory que se utiliza para crear objectos de tipo telegrama.
    ///</summary>
    public interface ITelegramaFactory
    {
        /// <summary>
        /// Crear un nuevo objeto de tipo telegrama.
        /// </summary>
        /// <returns>Telegrama.</returns>
        ITelegrama CrearTelegrama();
    }
}