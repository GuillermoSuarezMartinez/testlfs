using System;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// oOPCEnlaces.
    /// </summary>
    [Serializable]
    public class OOPCEnlaces
    {
        #region Atributos privados
        /// <summary>
        /// Nombre.
        /// </summary>
        private string _nombre;
        /// <summary>
        /// Reintento.
        /// </summary>
        private int _reintento;
        #endregion

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
        #endregion

        #region Métodos públicos
        /// <summary>
        /// oOPCEnlaces.
        /// </summary>
        /// <param name="nombre"></param>
        public OOPCEnlaces(string nombre)
        {
            _nombre = nombre;
            _reintento = 0;
        }
        #endregion
    }
}