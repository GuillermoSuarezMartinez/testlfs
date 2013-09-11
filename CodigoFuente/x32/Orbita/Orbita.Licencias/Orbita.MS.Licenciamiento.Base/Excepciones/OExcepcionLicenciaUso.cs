using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Excepciones
{
    public class OExcepcionLicenciaUso : Exception
    {
        public OExcepcionLicenciaUso()
            : base("Se han superado los recursos disponibles")
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Disponibles", -1);
            this.Data.Add("Requeridos", -1);
        }

        public OExcepcionLicenciaUso(string mensaje):base(mensaje)
        {
            this.Data.Add("Elemento", "Desconocido");
            this.Data.Add("Disponibles", -1);
            this.Data.Add("Requeridos", -1);
        }

        public OExcepcionLicenciaUso(int requeridos, int disponibles, string elemento = "Desconocido")
            :base("Solamente hay disponibles " + disponibles + " usos de " + elemento + ", se han solicitado " + requeridos)
        {
            this.Data.Add("Elemento", elemento);
            this.Data.Add("Disponibles", disponibles);
            this.Data.Add("Requeridos", requeridos);
        }

    }
}
