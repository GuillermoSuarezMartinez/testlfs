using System.ComponentModel;
using System.Runtime.InteropServices;
namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Clase para la gestión remota de la pantalla
    /// </summary>
    public partial class OrbitaComponenteMonitor : Component, IMonitor
    {
        public OrbitaComponenteMonitor()
        {
            InitializeComponent();
        }

        public OrbitaComponenteMonitor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// envía el mensaje a user.dll
        /// </summary>
        /// <param name="hWnd">formulario</param>
        /// <param name="hMsg">comando del sistema</param>
        /// <param name="wParam">parámetrod predefinido por MSDN para el envío de mensaje</param>
        /// <param name="lParam">parámetro para encender o apagar</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        /// <summary>
        /// método que apaga la pantalla
        /// </summary>
        /// <param name="formulario">formulario</param>
        public void ApagaPantalla(System.Windows.Forms.Form formulario)
        {
            SendMessage(formulario.Handle.ToInt32(), 274, 61808, 2);//DLL function
        }
        /// <summary>
        /// método que enciende la pantalla
        /// </summary>
        /// <param name="formulario">formulario</param>
        public void EncenderPantalla(System.Windows.Forms.Form formulario)
        {
            SendMessage(formulario.Handle.ToInt32(), 274, 61808, -1);//DLL function
        }
        #endregion
    }
}