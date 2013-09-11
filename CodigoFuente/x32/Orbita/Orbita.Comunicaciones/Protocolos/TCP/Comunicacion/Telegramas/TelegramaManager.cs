//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas.Serializacion;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Telegramas
{
    /// <summary>
    /// Esta clase se utiliza para obtener los telegramas predeterminados.
    /// </summary>
    internal static class TelegramaManager
    {
        #region Métodos públicos
        /// <summary>
        /// Crear un telegrama predeterminado que se utilizará en la comunicación de las solicitudes.
        /// </summary>
        /// <returns>Nueva instancia de telegrama predeterminada.</returns>
        public static ITelegramaFactory GetTelegramaFactoryPredeterminado()
        {
            return new SerializacionFactory();
        }
        /// <summary>
        /// Crear un telegrama predeterminado que se utilizará en la comunicación de las solicitudes.
        /// </summary>
        /// <returns>Nueva instancia de telegrama predeterminada.</returns>
        public static ITelegrama GetTelegramaPredeterminado()
        {
            return new Serializacion.Serializacion();
        }
        #endregion
    }
}