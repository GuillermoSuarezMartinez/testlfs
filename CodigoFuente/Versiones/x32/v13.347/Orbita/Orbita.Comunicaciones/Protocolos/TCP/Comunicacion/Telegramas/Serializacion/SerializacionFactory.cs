//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion
{
    /// <summary>
    /// Esta clase es utiliza para crear telegramas serializados. 
    /// </summary>
    public class SerializacionFactory : ITelegramaFactory
    {
        #region Métodos públicos
        /// <summary>
        /// Crear un nuevo telegrama.
        /// </summary>
        /// <returns>Nuevo telegrama.</returns>
        public ITelegrama CrearTelegrama()
        {
            return new Serializacion();
        }
        #endregion Métodos públicos
    }
}