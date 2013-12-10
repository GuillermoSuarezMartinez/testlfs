using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS
{
    /// <summary>
    /// Argumentos de un evento relativo a la gestión de licencias en las aplicaciones cliente.
    /// </summary>
    public class OLicenciaClienteEventArgs : EventArgs
    {
        #region Atributos
        public string Mensaje = "";
        public List<object> Datos = new List<object>() { };
        #endregion Atributos
        #region Constructor
        public OLicenciaClienteEventArgs(string mensaje = ""):base()
        {
            this.Mensaje = mensaje;
        }        
        #endregion Constructor
    }
}
