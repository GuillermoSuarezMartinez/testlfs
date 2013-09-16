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
    /// Este mensaje se utiliza para enviar/recibir un array de bytes como mensaje de datos.
    /// </summary>
    [Serializable]
    public class MensajeDatos : Mensaje
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeDatos.
        /// </summary>
        public MensajeDatos() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeDatos.
        /// </summary>
        /// <param name="datos">Mensaje de datos que será transmitido.</param>
        public MensajeDatos(byte[] datos)
        {
            Datos = datos;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajeDatos.
        /// </summary>
        /// <param name="datos">Mensaje de datos que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public MensajeDatos(byte[] datos, string idMensajeRespuesta)
            : this(datos)
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// Los datos del mensaje que se está transmitiendo.
        /// </summary>
        public byte[] Datos { get; set; }
        #endregion Propiedades públicas

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>Una cadena (string) que representa este objeto.</returns>
        public override string ToString()
        {
            var longitudMensaje = Datos == null ? 0 : Datos.Length;
            return string.IsNullOrEmpty(IdMensajeRespuesta)
                       ? string.Format("MensajeDatos [{0}]: {1} bytes", IdMensaje, longitudMensaje)
                       : string.Format("MensajeDatos [{0}] Respuesta [{1}]: {2} bytes", IdMensaje, IdMensajeRespuesta, longitudMensaje);
        }
        #endregion Métodos públicos
    }
}