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
    public class OcsMensajeLecturaDatosEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeDatosEventArgs.
        /// </summary>
        /// <param name="mensaje">Mensaje que está suscrito a este evento.</param>
        public OcsMensajeLecturaDatosEventArgs(IOcsMensajeLecturaDatos mensaje)
        {
            Mensaje = mensaje;
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Mensaje que está suscrito a este evento.
        /// </summary>
        public IOcsMensajeLecturaDatos Mensaje { get; private set; }
        #endregion
    }
}