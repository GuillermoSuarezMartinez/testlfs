using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Excepciones
{
    public class OExcepcionLicenciaNoDisponible : Exception
    {
        public OExcepcionLicenciaNoDisponible()
            : base("No hay licencias registradas disponibles para el elemento indicado.")
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Motivo", "Desconocido");
        }

        public OExcepcionLicenciaNoDisponible(string mensaje)
            : base("No hay licencias registradas disponibles para el elemento indicado." + mensaje)
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Motivo", "Desconocido");
        }

        public OExcepcionLicenciaNoDisponible(string elemento, string motivo = "Desconocido")
            : base("No hay licencias registradas disponibles para " + elemento + ". Motivo: " + motivo)
        {
            this.Data.Add("Elemento", elemento);
            this.Data.Add("Motivo", motivo);
        }

    }
}
