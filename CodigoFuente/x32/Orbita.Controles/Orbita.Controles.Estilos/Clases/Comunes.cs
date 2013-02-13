using System;
using System.IO;
using System.Text;
using System.Reflection;
namespace Orbita.Controles.Estilos
{
    public static class Comunes
    {
        public static Stream GetIsl(string nombre)
        {
            System.Reflection.Assembly ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            string[] nombres = ensamblado.GetManifestResourceNames();
            AssemblyName nombreEnsamblado = new AssemblyName(ensamblado.FullName);
            StringBuilder path = new StringBuilder();
            path.Append(nombreEnsamblado.Name);
            path.Append(".Resources.");
            path.Append(nombre);
            path.Append(".isl");
            return ensamblado.GetManifestResourceStream(path.ToString());
        }
    }
}
