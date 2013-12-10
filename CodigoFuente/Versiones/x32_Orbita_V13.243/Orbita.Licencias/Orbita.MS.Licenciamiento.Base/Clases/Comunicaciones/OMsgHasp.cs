using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS
{
    /// <summary>
    /// oOPCComms.
    /// </summary>
    [Serializable]
    public class oMsgHasp : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Producto.
        /// </summary>
        string _producto;
        /// <summary>
        /// Estado.
        /// </summary>
        string _estado;
        /// <summary>
        /// Mensaje.
        /// </summary>
        string _mensaje;
        #endregion

        #region Propiedades
        /// <summary>
        /// Estado.
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        /// <summary>
        /// Producto.
        /// </summary>
        public string Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        /// <summary>
        /// Mensaje.
        /// </summary>
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
