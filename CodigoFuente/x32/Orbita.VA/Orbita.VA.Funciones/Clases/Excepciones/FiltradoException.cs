using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Excepción de filtrado
    /// </summary>
    public class FiltradoException : ApplicationException
    {
        public FiltradoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
