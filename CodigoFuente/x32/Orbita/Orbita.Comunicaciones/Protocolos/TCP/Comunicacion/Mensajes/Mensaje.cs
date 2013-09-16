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
    /// Representa el mensaje que se enviará y recibirá entre cliente y servidor.
    /// Esta es la clase base para todos los mensajes.
    /// </summary>
    [Serializable]
    public class Mensaje : IMensaje
    {
        #region Atributos
        //private static long _ultimoIdentificador;
        #endregion Atributos

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Mensaje.
        /// </summary>
        public Mensaje()
        {
            IdMensaje = Guid.NewGuid().ToString();
            //IdMensaje = Interlocked.Increment(ref _ultimoIdentificador).ToString();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Mensaje.
        /// </summary>
        /// <param name="idMensajeRespuesta">Mensaje de respuesta a un mensaje.</param>
        public Mensaje(string idMensajeRespuesta)
            : this()
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Identificador único para este mensaje.
        /// Valor predeterminado: Nuevo GUID.
        /// No establecer si no se quieren hacer cambios a más bajo nivel, como por ejemplo, telegramas personalizados.
        /// </summary>
        public string IdMensaje { get; set; }
        /// <summary>
        /// Esta propiedad se utiliza para indicar que se trata de un mensaje de respuesta a un mensaje.
        /// Puede ser nulo (null) si no se trata de un mensaje de respuesta.
        /// </summary>
        public string IdMensajeRespuesta { get; set; }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>Una cadena (string) que representa este objeto.</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(IdMensajeRespuesta)
                       ? string.Format("Mensaje [{0}]", IdMensaje)
                       : string.Format("Mensaje [{0}] Respuesta de [{1}]", IdMensaje, IdMensajeRespuesta);
        }
        #endregion Métodos públicos
    }
}