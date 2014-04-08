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
    /// Representa los errores que se producen durante la ejecución de una comunicación.
    /// </summary>
    [Serializable]
    public class ExcepcionComunicacion : Exception
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionComunicacion.
        /// </summary>
        public ExcepcionComunicacion() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionComunicacion con datos serializados.
        /// </summary>
        public ExcepcionComunicacion(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionComunicacion con un mensaje
        /// de error especificado.
        /// </summary>
        /// <param name="message">Mensaje de error que explica la razón de la excepción.</param>
        public ExcepcionComunicacion(string message)
            : base(message) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionComunicacion con una referencia a la excepción 
        /// interna que representa la causa de esta excepción.
        /// </summary>
        /// <param name="innerException">La excepción que es la causa de la excepción actual o una referencia nula
        /// (null) si no se especifica ninguna excepción interna.</param>
        public ExcepcionComunicacion(Exception innerException)
            : base(null, innerException) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase ExcepcionComunicacion con un mensaje
        /// de error especificado y una referencia a la excepción interna que representa
        /// la causa de esta excepción.
        /// </summary>
        /// <param name="message">Mensaje de error que explica la razón de la excepción.</param>
        /// <param name="innerException">La excepción que es la causa de la excepción actual o una referencia nula
        /// (null) si no se especifica ninguna excepción interna.</param>
        public ExcepcionComunicacion(string message, Exception innerException)
            : base(message, innerException) { }
        #endregion Constructores
    }
}