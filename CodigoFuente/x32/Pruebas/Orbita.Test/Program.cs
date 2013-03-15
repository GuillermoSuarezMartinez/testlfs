using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Orbita.Trazabilidad;

namespace Orbita.Test
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
            string fichero = @"C:\TFS\OrbitaSoftware\Librerias\CodigoFuente\x32\Orbita\Orbita.Trazabilidad\Config\Ejemplos\Wrapper.config.xml";
            LogManager.ConfiguracionLogger(fichero);
            Application.Run(new Form2());
        }
    }
}
