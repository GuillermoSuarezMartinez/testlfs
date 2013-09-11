//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Almacena el mensaje que será utilizado por el evento de suscripción.
    /// </summary>
    public class OcsMensajeComunicacionesEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeComunicacionesEventArgs.
        /// </summary>
        /// <param name="mensaje">Mensaje que está suscrito a este evento.</param>
        public OcsMensajeComunicacionesEventArgs(IOcsMensajeComunicaciones mensaje)
        {
            Mensaje = mensaje;
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Mensaje que está suscrito a este evento.
        /// </summary>
        public IOcsMensajeComunicaciones Mensaje { get; private set; }
        #endregion
    }
}