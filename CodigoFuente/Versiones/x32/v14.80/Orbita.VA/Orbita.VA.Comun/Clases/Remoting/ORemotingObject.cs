using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase compartida por remoting
    /// </summary>
    [Serializable]
    public class ORemotingObject : MarshalByRefObject
    {
        #region Método(s) público(s)
        /// <summary>
        /// Inicializa el tiempo de vida para que el objeto no pueda morir
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            // Este objeto no puede morir.
            return null;
        }
        #endregion
    }
}
