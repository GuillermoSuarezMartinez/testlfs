using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
namespace Orbita.MS
{
    public class OConexionCliente : OWinSockClienteBase
    {
        public OConexionCliente(ILogger logger, string ip, int puerto, string nombre):base(logger,ip, puerto, nombre)
        {

        }

        
    }
}
