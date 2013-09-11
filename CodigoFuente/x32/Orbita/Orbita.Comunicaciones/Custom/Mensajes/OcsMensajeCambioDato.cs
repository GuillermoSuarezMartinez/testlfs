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
    /// Este mensaje se utiliza para enviar/recibir un objeto de tipo OInfoDato como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeCambioDato : OcsMensajeInfoDatoBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeCambioDato.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        public OcsMensajeCambioDato(OInfoDato infoDato)
            : base(infoDato) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeCambioDato.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeCambioDato(OInfoDato infoDato, string idMensajeRespuesta)
            : base(infoDato, idMensajeRespuesta) { }
        #endregion
    }
}