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
    /// Este mensaje se utiliza para enviar/recibir una cadena de texto como mensaje de datos.
    /// </summary>
    [Serializable]
    public class MensajeTexto : Mensaje
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeTexto.
        /// </summary>
        public MensajeTexto() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeTexto.
        /// </summary>
        /// <param name="texto">Mensaje de texto que será transmitido.</param>
        public MensajeTexto(string texto)
        {
            Texto = texto;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeTexto.
        /// </summary>
        /// <param name="texto">Mensaje de texto que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public MensajeTexto(string texto, string idMensajeRespuesta)
            : this(texto)
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// El texto del mensaje que se está transmitiendo.
        /// </summary>
        public string Texto { get; set; }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>Una cadena (string) que representa este objeto.</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(IdMensajeRespuesta)
                       ? string.Format("MensajeTexto [{0}]: {1}", IdMensaje, Texto)
                       : string.Format("MensajeTexto [{0}] Respuesta de [{1}]: {2}", IdMensaje, IdMensajeRespuesta, Texto);
        }
        #endregion Métodos públicos
    }
}