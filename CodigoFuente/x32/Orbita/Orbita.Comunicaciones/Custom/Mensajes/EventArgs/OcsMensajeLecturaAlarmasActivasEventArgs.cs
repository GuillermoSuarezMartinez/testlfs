//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Almacena el mensaje que será utilizado por el evento de suscripción.
    /// </summary>
    public class OcsMensajeLecturaAlarmasActivasEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeAlarmasActivasEventArgs.
        /// </summary>
        /// <param name="mensaje">Mensaje que está suscrito a este evento.</param>
        public OcsMensajeLecturaAlarmasActivasEventArgs(IOcsMensajeLecturaAlarmasActivas mensaje)
        {
            Mensaje = mensaje;
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Mensaje que está suscrito a este evento.
        /// </summary>
        public IOcsMensajeLecturaAlarmasActivas Mensaje { get; private set; }
        #endregion
    }
}