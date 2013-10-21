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
    /// Este mensaje se utiliza para enviar/recibir un objeto OInfoDato como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeAlarma : OcsMensajeInfoDatoBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeAlarma.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        public OcsMensajeAlarma(OInfoDato infoDato)
            : base(infoDato) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeAlarma.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeAlarma(OInfoDato infoDato, string idMensajeRespuesta)
            : base(infoDato, idMensajeRespuesta) { }
        #endregion Constructores
    }
}