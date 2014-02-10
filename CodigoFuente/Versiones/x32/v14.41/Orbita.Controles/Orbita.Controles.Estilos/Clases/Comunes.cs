//***********************************************************************
// Assembly         : Orbita.Controles.Estilos
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.IO;
using System.Reflection;
using System.Text;
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