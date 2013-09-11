using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Excepciones
{
    public class OExcepcionLicenciaPeriodoGraciaExcedido : Exception
    {
        public OExcepcionLicenciaPeriodoGraciaExcedido()
            : base("Ha caducado el tiempo de espera indicado y no se han reconectado licencias válidas para los productos a licenciar.")
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Tiempo", -1);
            this.Data.Add("Motivo", "Desconocido");
        }

        public OExcepcionLicenciaPeriodoGraciaExcedido(string mensaje)
            : base("No hay licencias registradas disponibles para el elemento indicado." + mensaje)
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Tiempo", -1);
            this.Data.Add("Motivo", "Desconocido");
        }

        public OExcepcionLicenciaPeriodoGraciaExcedido(string elemento, int tiempo = -1, string motivo = "Desconocido")
            :base("Ha caducado el tiempo de espera indicado (" + tiempo + ") y no se han reconectado licencias válidas para " + elemento + " Motivo :" + motivo)
            
        {
            this.Data.Add("Elemento", elemento);
            this.Data.Add("Tiempo", -1);
            this.Data.Add("Motivo", motivo);
        }

    }
}
