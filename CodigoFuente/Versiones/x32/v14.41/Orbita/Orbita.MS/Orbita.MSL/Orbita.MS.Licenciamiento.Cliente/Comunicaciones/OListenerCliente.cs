using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;

namespace Orbita.MS
{
    public class OListenerCliente : OTCPListener
    {
        public OListenerCliente(ILogger logger, int puerto, string nombreInstancia):base(logger, puerto, nombreInstancia)
        {

        }
    }
}
