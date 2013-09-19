using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Orbita.MS.Clases
{
    public static class OGestionSistema
    {

        #region Declaraciones Interop - Dll
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool IsDebuggerPresent();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetCurrentProcess();
        /// <summary>
        /// CheckRemoteDebuggerPresent
        /// </summary>
        /// <param name="ProcessHandle"></param>
        /// <param name="DebuggerPresent"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckRemoteDebuggerPresent(
            [In] IntPtr ProcessHandle,
            [MarshalAs(UnmanagedType.Bool)] ref bool DebuggerPresent
         );
        #endregion
        #region Propiedades
        #region (Depuración)
        /// <summary>
        /// Indica si hay alguien conectado
        /// </summary>
        private static bool DepuradorAsociado
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached;
            }
        }
        /// <summary>
        /// Indica si se ejecuta en local
        /// </summary>
        private static bool DepuradorLocal
        {
            get
            {
                return IsDebuggerPresent();
            }
        }
        /// <summary>
        /// Indica si se ejecuta en remoto
        /// </summary>
        private static bool DepuradorRemoto
        {
            get
            {
                bool presente = false;
                CheckRemoteDebuggerPresent(GetCurrentProcess(), ref presente);
                return presente;
            }
        }
#endregion (Depuración)
        #endregion Propiedades 
        #region Métodos públicos
        /// <summary>
        /// Detiene el servicio
        /// </summary>
        /// <returns></returns>
        public static bool DetenerServicio()
        {
            try
            {
                return true;
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                return false;
            }
        }
        #region (Depuración)
        public static void InhibirDepuracionAplicacion()
        {
            ImpedirDepurador();
        }
        /// <summary>
        /// Impide la depuración del código
        /// </summary>
        private static void ImpedirDepurador()
        {
            Thread thread = new Thread(new ThreadStart(ThreadImpedirDepurador));
            thread.Start();
        }
        /// <summary>
        /// Impide la depuración del código
        /// </summary>
        private static void ThreadImpedirDepurador()
        {
            while (EsperarDepurador(5000, false))
            {
                FinalizarTodo(-1);
            }
        }
        /// <summary>
        /// Finaliza el depurador
        /// </summary>
        public static void FinalizarTodo(int codigo = -1)
        {
            System.Environment.Exit(codigo);
        }
        /// <summary>
        /// Espera la ejecución del depurador
        /// </summary>
        private static bool EsperarDepurador(int espera = 1000, bool mensaje = true)
        {
            while (!DepuradorAsociado && !DepuradorLocal && !DepuradorRemoto)
            {
                Thread.Sleep(espera);
            }
            return true;
        }


        #endregion (Depuración)

        #endregion Métodos públicos
    }
}
