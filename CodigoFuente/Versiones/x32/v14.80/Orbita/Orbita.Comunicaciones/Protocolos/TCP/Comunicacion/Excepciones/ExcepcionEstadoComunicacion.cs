//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.Runtime.Serialization;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones
{
    /// <summary>
    /// Representa los errores que se producen ante un estado inesperado de comunicación.
    /// </summary>
    [Serializable]
    public class ExcepcionEstadoComunicacion : ExcepcionComunicacion
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionEstadoComunicacion.
        /// </summary>
        public ExcepcionEstadoComunicacion() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionEstadoComunicacion con datos serializados.
        /// </summary>
        public ExcepcionEstadoComunicacion(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase ExcepcionEstadoComunicacion con un mensaje
        /// de error especificado.
        /// </summary>
        /// <param name="message">Mensaje de error que explica la razón de la excepción.</param>
        public ExcepcionEstadoComunicacion(string message)
            : base(message) { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase ExcepcionEstadoComunicacion con un mensaje
        /// de error especificado y una referencia a la excepción interna que representa
        /// la causa de esta excepción.
        /// </summary>
        /// <param name="message">Mensaje de error que explica la razón de la excepción.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual o una referencia nula
        /// (null) si no se especifica ninguna excepción interna.</param>
        public ExcepcionEstadoComunicacion(string message, Exception innerException)
            : base(message, innerException) { }
        #endregion Constructores
    }
}