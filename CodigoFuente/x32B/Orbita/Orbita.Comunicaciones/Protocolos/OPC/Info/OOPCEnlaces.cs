using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// oOPCEnlaces.
    /// </summary>
    [Serializable]
    public class OOPCEnlaces
    {
        #region Propiedades
        /// <summary>
        /// Nombre.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Reintento.
        /// </summary>
        public int Reintento { get; set; }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// OOPCEnlaces.
        /// </summary>
        /// <param name="nombre"></param>
        public OOPCEnlaces(string nombre)
        {
            Nombre = nombre;
            Reintento = 0;
        }
        #endregion Métodos públicos
    }
}