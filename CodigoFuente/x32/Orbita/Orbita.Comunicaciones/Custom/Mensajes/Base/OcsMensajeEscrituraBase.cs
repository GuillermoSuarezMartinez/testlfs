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
    /// Representa el mensaje que se enviará y recibirá entre cliente y servidor.
    /// Esta es la clase base para todos los mensajes de este tipo.
    /// </summary>
    [Serializable]
    public abstract class OcsMensajeEscrituraBase : OcsMensajeBase, IOcsMensajeEscritura
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeEscrituraBase.
        /// </summary>
        protected OcsMensajeEscrituraBase() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeEscrituraBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal">Identificador del canal cliente.</param>
        protected OcsMensajeEscrituraBase(int dispositivo, string[] variables, object[] valores, string canal)
            : base(dispositivo, variables, valores)
        {
            Canal = canal;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeEscrituraBase.
        /// </summary>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeEscrituraBase(string idMensajeRespuesta)
        {
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Resultado de la escritura en el dispositivo.
        /// </summary>
        public bool Respuesta { get; set; }
        /// <summary>
        /// Identificador del canal cliente.
        /// </summary>
        public string Canal { get; private set; }
        #endregion
    }
}