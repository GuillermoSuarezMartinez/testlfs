using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Orbita.Trazabilidad;

namespace Orbita.MS.Licenciamiento.Servidor
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

            //Inicializamos el log principal
            try
            {
                string fichero = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Log.config.xml";
                LogManager.ConfiguracionLogger(fichero);
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
            }

            Application.Run(new OGestorLicenciasServidor());
        }
    }
}
