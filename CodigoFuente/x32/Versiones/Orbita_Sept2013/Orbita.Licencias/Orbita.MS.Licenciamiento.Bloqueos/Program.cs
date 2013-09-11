using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Orbita.MS.Licenciamiento;
using Orbita.MS;
using Orbita.Trazabilidad;
using System.Diagnostics;
namespace Orbita.MS.Licenciamiento.Bloqueos
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
            ILogger log = LogManager.GetLogger("MSLC");
            //Creamos la información de licenciamiento
            OAplicacion aplicacion = new OAplicacion();
            aplicacion.IdProductos.Add(2);
            OGestorLicenciasCliente gestor = new OGestorLicenciasCliente("127.0.0.1", 3625, log, aplicacion);
            gestor.LicenciaInvalida += new OGestorLicenciasCliente.OManejadorEventoLicenciaCliente(gestor_LicenciaInvalida);
            gestor.ServiciosAsociados.Add("Themes");
            gestor.ServiciosAsociados.Add("MSSQL$SQLEXPRESS");
            Process.Start(new ProcessStartInfo("C:\\WINDOWS\\notepad.exe"));
            gestor.ProcesoControladoCierreAplicacion();
            DialogResult dr = MessageBox.Show("La aplicación ha sido bloqueada al no disponer de las licencias adecuadas en su sistema.\r\nContacte con Órbita Ingeniería (+34 961 433 995) para obtener soporte.", "Aplicación bloqueada", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            Application.Run(new Form1());
        }

        static void gestor_LicenciaInvalida(OLicenciaClienteEventArgs e)
        {
            MessageBox.Show("Licencia inválida.");
        }

    }
}
