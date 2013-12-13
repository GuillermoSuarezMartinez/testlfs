using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
namespace Orbita
{
    /// <summary>
    /// Clase que se encarga de verificar si hay otro servicio o proceso abierto con el mismo nombre
    /// </summary>
    public class OrbitaClaseAplicacionUnica
    {
        #region Atributos
        /// <summary>
        /// Metex de aplicacion
        /// </summary>
        static Mutex mutex;
        /// <summary>
        /// Constante
        /// </summary>
        const int SW_RESTORE = 9;
        #endregion

        #region Importaciones
        [DllImport("user32.dll")]
        static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int IsIconic(IntPtr hWnd);
        #endregion

        #region Constructor
        OrbitaClaseAplicacionUnica() { }
        #endregion

        #region Métodos privados
        static IntPtr GetCurrentInstanceWindowHandle()
        {
            IntPtr hWnd = IntPtr.Zero;

            Process process = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(process.ProcessName);

            foreach (Process _process in processes)
            {
                if (_process.Id != process.Id &&
                _process.MainModule.FileName == process.MainModule.FileName &&
                _process.MainWindowHandle != IntPtr.Zero)
                {
                    hWnd = _process.MainWindowHandle;
                    break;
                }
            }
            return hWnd;
        }
        #endregion

        #region Métodos públicos
        public static void SwitchToCurrentInstance()
        {
            IntPtr hWnd = GetCurrentInstanceWindowHandle();

            if (hWnd != IntPtr.Zero)
            {
                //Si la ventana es minimizada la restauramos
                if (IsIconic(hWnd) != 0)
                {
                    ShowWindow(hWnd, SW_RESTORE);
                }

                //La traemos al frente
                SetForegroundWindow(hWnd);
            }
        }
        public static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;

            FileSystemInfo fileInfo = new FileInfo(strLoc);

            string sExeName = fileInfo.Name;

            bool bCreatedNew;

            mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);

            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }
        #endregion
    }
}