using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// oOPCEnlaces.
    /// </summary>
    [Serializable]
    public class OOPCEnlaces
    {
        #region Atributos
        /// <summary>
        /// Nombre.
        /// </summary>
        private string _nombre;
        /// <summary>
        /// Reintento.
        /// </summary>
        private int _reintento;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Nombre.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Reintento.
        /// </summary>
        public int Reintento
        {
            get { return _reintento; }
            set { _reintento = value; }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// OOPCEnlaces.
        /// </summary>
        /// <param name="nombre"></param>
        public OOPCEnlaces(string nombre)
        {
            _nombre = nombre;
            _reintento = 0;
        }
        #endregion Métodos públicos
    }
}