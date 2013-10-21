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
    /// Representa el mensaje que se enviará y recibirá entre cliente y servidor.
    /// Esta es la clase base para todos los mensajes de este tipo.
    /// </summary>
    [Serializable]
    public abstract class OcsMensajeInfoDatoBase : Mensaje, IOcsMensajeInfoDato
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeInfoDatoBase.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        protected OcsMensajeInfoDatoBase(OInfoDato infoDato)
        {
            InfoDato = infoDato;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeInfoDatoBase.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeInfoDatoBase(OInfoDato infoDato, string idMensajeRespuesta)
            : this(infoDato)
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// Información del dato que se está transmitiendo.
        /// </summary>
        public OInfoDato InfoDato { get; private set; }
        #endregion Propiedades públicas
    }
}