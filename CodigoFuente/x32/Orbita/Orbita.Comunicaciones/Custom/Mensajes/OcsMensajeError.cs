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
    /// Este mensaje se utiliza para enviar/recibir una excepción como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeError : Mensaje, IOcsMensajeErrorBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeError.
        /// </summary>
        /// <param name="error">Representa el error que se produce durante la ejecución de una aplicación.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeError(string error, string idMensajeRespuesta)
            : this(new Exception(error), idMensajeRespuesta) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeError.
        /// </summary>
        /// <param name="error">Representa el error que se produce durante la ejecución de una aplicación.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeError(Exception error, string idMensajeRespuesta)
        {
            Error = error;
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// Representa el error que se produce durante la ejecución de una aplicación.
        /// </summary>
        public Exception Error { get; private set; }
        #endregion Propiedades públicas
    }
}