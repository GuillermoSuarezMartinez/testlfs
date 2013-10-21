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
    public class OcsMensajeLectura : OcsMensajeLecturaBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLectura.
        /// </summary>
        public OcsMensajeLectura() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLectura.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se realiza bajo demanda al dispositivo.</param>
        public OcsMensajeLectura(int dispositivo, string[] variables, bool demanda)
            : base(dispositivo, variables, demanda) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLectura.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeLectura(int dispositivo, string[] variables, object[] valores, string idMensajeRespuesta)
            : base(dispositivo, variables, valores, idMensajeRespuesta) { }
        #endregion Constructores
    }
}