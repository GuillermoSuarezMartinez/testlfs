//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales
{
    /// <summary>
    /// Almacena información del canal de comunicación que será utilizada por el evento de suscripción.
    /// </summary>
    internal class CanalComunicacionEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase CanalComunicacionEventArgs.
        /// </summary>
        /// <param name="canal">Canal de comunicación que será suscrito por este evento.</param>
        public CanalComunicacionEventArgs(ICanalComunicacion canal)
        {
            Canal = canal;
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Canal de comunicación que será suscrito por este evento.
        /// </summary>
        public ICanalComunicacion Canal { get; private set; }
        #endregion Propiedades públicas
    }
}