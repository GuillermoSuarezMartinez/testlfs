//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Este mensaje se utiliza para enviar/recibir un array de bytes como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeEscritura : OcsMensajeEscrituraBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeEscritura.
        /// </summary>
        public OcsMensajeEscritura() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeEscritura.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal">Identificador del canal cliente.</param>
        public OcsMensajeEscritura(int dispositivo, string[] variables, object[] valores, string canal)
            : base(dispositivo, variables, valores, canal) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeEscritura.
        /// </summary>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeEscritura(string idMensajeRespuesta)
            : base(idMensajeRespuesta) { }
        #endregion Constructores
    }
}