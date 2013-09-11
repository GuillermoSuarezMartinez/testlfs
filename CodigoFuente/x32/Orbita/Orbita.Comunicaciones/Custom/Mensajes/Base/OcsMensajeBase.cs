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
    public abstract class OcsMensajeBase : Mensaje
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeBase.
        /// </summary>
        protected OcsMensajeBase() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        protected OcsMensajeBase(int dispositivo, string[] variables)
        {
            Dispositivo = dispositivo;
            Variables = variables;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        protected OcsMensajeBase(int dispositivo, string[] variables, object[] valores)
            : this(dispositivo, variables)
        {
            Valores = valores;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeBase(int dispositivo, string[] variables, object[] valores, string idMensajeRespuesta)
            : this(dispositivo, variables)
        {
            Valores = valores;
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Dispositivo de conexión.
        /// </summary>
        public int Dispositivo { get; private set; }
        /// <summary>
        /// Colección de variables.
        /// </summary>
        public string[] Variables { get; private set; }
        /// <summary>
        /// Colección de valores.
        /// </summary>
        public object[] Valores { get; private set; }
        #endregion
    }
}