using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// OEstadoComms.
    /// </summary>
    [Serializable]
    public class OEstadoComms
    {
        #region Propiedades
        /// <summary>
        /// Estado.
        /// </summary>
        public string Estado { get; set; }
        /// <summary>
        /// Enlace.
        /// </summary>
        public string Enlace { get; set; }
        /// <summary>
        /// Nombre.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Identificador OPC.
        /// </summary>
        public int Id { get; set; }
        #endregion Propiedades
    }
}