//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
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
    /// Este mensaje se utiliza para enviar/recibir mensajes de tipo ping.
    /// Mensajes de ping se utiliza para mantener viva la conexión entre el servidor y el cliente.
    /// </summary>
    [Serializable]
    public sealed class MensajePing : Mensaje
    {
        #region Constructores
        ///<summary>
        /// Inicializar una nueva instancia de la clase MensajePing.
        ///</summary>
        public MensajePing() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase MensajePing.
        /// </summary>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public MensajePing(string idMensajeRespuesta)
            : this()
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>Una cadena (string) que representa este objeto.</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(IdMensajeRespuesta)
                       ? string.Format("MensajePing [{0}]", IdMensaje)
                       : string.Format("MensajePing [{0}] Respuesta de [{1}]", IdMensaje, IdMensajeRespuesta);
        }
        #endregion
    }
}