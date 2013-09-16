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
    /// <summary>
    /// Representa un objeto que puede enviar y recibir mensajes.
    /// </summary>
    public interface IOcsMensajeroServidor
    {
        /// <summary>
        /// Enviar un mensaje de tipo cambio de dato a la aplicación remota.
        /// </summary>
        /// <param name="infoDato">Información del dato que se está transmitiendo.</param>
        void CambioDato(OInfoDato infoDato);
        /// <summary>
        /// Enviar un mensaje de tipo alarma a la aplicación remota.
        /// </summary>
        /// <param name="infoDato">Información del dato que se está transmitiendo.</param>
        void Alarma(OInfoDato infoDato);
        /// <summary>
        /// Enviar un mensaje de tipo estado de las comunicaciones a la aplicación remota.
        /// </summary>
        /// <param name="estadoComm">Información del estado de las comunicaciones que se están transmitiendo.</param>
        void Comunicaciones(OEstadoComms estadoComm);
    }
}