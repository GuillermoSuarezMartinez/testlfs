using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Excepciones
{
    public class OExcepcionLicenciaHASP : Exception
    {
        public OExcepcionLicenciaHASP()
            : base("Ha ocurrido un error al procesar los dipositivos HASP en el sistema.")
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Motivo", "Desconocido");
            this.Data.Add("Consulta", "Desconocido");
            this.Data.Add("Estado", "Desconocido");
        }

        public OExcepcionLicenciaHASP(string mensaje)
            : base("Ha ocurrido un error al procesar los dipositivos HASP en el sistema." + mensaje)
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Motivo", "Desconocido");
            this.Data.Add("Consulta", "Desconocido");
            this.Data.Add("Estado", "Desconocido");
        }

        public OExcepcionLicenciaHASP(string elemento, string estado = "Sin definir", string consulta = "Sin definir", string motivo = "Desconocido")
            : base("Ha ocurrido un error al procesar los dipositivos HASP en el sistema. Estado: " + estado + ". Elemento:" + elemento + ". Motivo: " + motivo)
        {
            this.Data.Add("Elemento", elemento);
            this.Data.Add("Motivo", motivo);
            this.Data.Add("Consulta", consulta);
            this.Data.Add("Estado", estado);
        }

    }
}
