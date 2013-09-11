//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion
{
    /// <summary>
    /// Esta clase es utiliza para crear telegramas serializados. 
    /// </summary>
    public class SerializacionFactory : ITelegramaFactory
    {
        /// <summary>
        /// Crear un nuevo telegrama.
        /// </summary>
        /// <returns>Nuevo telegrama.</returns>
        public ITelegrama CrearTelegrama()
        {
            return new Serializacion();
        }
    }
}