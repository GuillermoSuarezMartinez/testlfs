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
    /// Representa el mensaje que se enviará y recibirá entre cliente y servidor.
    /// Esta es la clase base para todos los mensajes de este tipo.
    /// </summary>
    [Serializable]
    public abstract class OcsMensajeLecturaDispositivosBase : Mensaje, IOcsMensajeLecturaDispositivos
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDispositivosBase.
        /// </summary>
        protected OcsMensajeLecturaDispositivosBase() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDispositivosBase.
        /// </summary>
        /// <param name="dispositivos">Colección de dispositivos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeLecturaDispositivosBase(int[] dispositivos, string idMensajeRespuesta)
            : this()
        {
            Dispositivos = dispositivos;
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Colección de dispositivos.
        /// </summary>
        public int[] Dispositivos { get; private set; }
        #endregion
    }
}