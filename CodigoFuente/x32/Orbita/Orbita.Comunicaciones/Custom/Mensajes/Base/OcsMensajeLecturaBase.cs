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
    /// Esta es la clase base para todos los mensajes de este tipo.
    /// </summary>
    [Serializable]
    public abstract class OcsMensajeLecturaBase : OcsMensajeBase, IOcsMensajeLectura
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaBase.
        /// </summary>
        protected OcsMensajeLecturaBase() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se realiza bajo demanda al dispositivo.</param>
        protected OcsMensajeLecturaBase(int dispositivo, string[] variables, bool demanda)
            : base (dispositivo, variables)
        {
            Demanda = demanda;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeLecturaBase(int dispositivo, string[] variables, object[] valores, string idMensajeRespuesta)
            : base(dispositivo, variables, valores, idMensajeRespuesta)  { }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// Indica si la lectura se realiza bajo demanda al dispositivo.
        /// </summary>
        public bool Demanda { get; private set; }
        #endregion Propiedades públicas
    }
}