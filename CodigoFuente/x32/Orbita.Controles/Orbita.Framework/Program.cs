using System;
using System.Windows.Forms;
using Orbita.BBDD;
namespace Orbita.Framework
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
            string fichero = Application.StartupPath + @"\ConfiguracionBBDD.xml";
            OBBDDManager.LeerFicheroConfig(fichero);
            BDatos.FW = (OSqlServer)OBBDDManager.GetBBDD("basedatosfw");
            Application.Run(new Main());
        }
    }
}