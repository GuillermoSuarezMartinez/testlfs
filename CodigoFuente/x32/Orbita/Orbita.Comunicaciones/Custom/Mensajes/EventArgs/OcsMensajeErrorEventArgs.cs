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
using System.IO;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Almacena el mensaje que será utilizado por el evento de suscripción.
    /// </summary>
    public class OcsMensajeErrorEventArgs : ErrorEventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeErrorEventArgs.
        /// </summary>
        /// <param name="mensaje">Mensaje que ha producido el error.</param>
        /// <param name="error">Representa el error que se produce durante la ejecución de una aplicación.</param>
        public OcsMensajeErrorEventArgs(IMensaje mensaje, Exception error)
            : base(error)
        {
            Mensaje = mensaje;
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Mensaje que está suscrito a este evento.
        /// </summary>
        public IMensaje Mensaje { get; private set; }
        #endregion
    }
}