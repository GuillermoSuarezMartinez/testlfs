//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Este mensaje se utiliza para enviar/recibir un objeto de tipo OEstadoComms como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeComunicaciones : Mensaje, IOcsMensajeComunicaciones
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeComunicaciones.
        /// </summary>
        /// <param name="infoComm">Información del estado de comunicaciones.</param>
        public OcsMensajeComunicaciones(OEstadoComms infoComm)
        {
            InfoComm = infoComm;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeComunicaciones.
        /// </summary>
        /// <param name="infoComm">Información del estado de comunicaciones.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeComunicaciones(OEstadoComms infoComm, string idMensajeRespuesta)
            : this(infoComm)
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// Información del estado de comunicaciones.
        /// </summary>
        public OEstadoComms InfoComm { get; private set; }
        #endregion Propiedades públicas
    }
}