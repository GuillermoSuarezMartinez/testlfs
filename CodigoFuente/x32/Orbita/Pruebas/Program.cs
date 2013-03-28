using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Orbita.Trazabilidad;

namespace Pruebas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string fichero = @"C:\TFS\OrbitaSoftware\Librerias\CodigoFuente\x32\Orbita\Orbita.Trazabilidad\Config\Ejemplos\Wrapper2.full.config.xml";
            string fichero = @"C:\TFS\OrbitaSoftware\Librerias\CodigoFuente\x32\Orbita\Orbita.Trazabilidad\Config\Ejemplos\Debug.config.xml";
            LogManager.ConfiguracionLogger(fichero);
            Application.Run(new Form1());
        }
    }
}
