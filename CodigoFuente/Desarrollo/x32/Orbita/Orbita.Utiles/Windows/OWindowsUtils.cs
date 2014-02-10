using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Orbita.Utiles
{
    /// <summary>
    /// Librería de utilidades para el SO Windows
    /// </summary>
    public static class OWindowsUtils
    {
        #region Ejecución de procesos
        [DllImport("Shell32.dll")]
        private static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd);
        [DllImport("kernel32.dll")]
        private static extern bool Wow64EnableWow64FsRedirection(bool enable);
        #endregion

        #region Llamadas a ventanas
        public const int CONST_SHOW = 5;
        public const int CONST_HIDE = 0;
        public const uint SWP_NOSIZE = 0x0001;
        public const int HWND_TOP = 0;

        public delegate bool EnumThreadProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EnumThreadWindows(int threadId, EnumThreadProc pfnEnum, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd); 

        [DllImport("user32.dll")]
        public static extern int ShowWindowAsync(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        #endregion

        #region Métodos manejo de memoria
        /// <summary>
        /// memcpy - copy a block of memery
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("ntdll.dll")]
        public static extern IntPtr memcpy(
            IntPtr dst,
            IntPtr src,
            int count);
        /// <summary>
        /// memcpy - copy a block of memery
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("ntdll.dll")]
        public static extern int memcpy(
            int dst,
            int src,
            int count);
        #endregion

        #region Métodos de red
        /// <summary>
        /// API to get list of connections 
        /// </summary>
        /// <param name="pTcpTable"></param>
        /// <param name="pdwSize"></param>
        /// <param name="bOrder"></param>
        /// <returns></returns>
        [DllImport("iphlpapi.dll")]
        public static extern int GetTcpTable(IntPtr pTcpTable, ref int pdwSize, bool bOrder);

        /// <summary>
        /// API to change status of connection 
        /// </summary>
        /// <param name="pTcprow"></param>
        /// <returns></returns>
        [DllImport("iphlpapi.dll")]
        //private static extern int SetTcpEntry(MIB_TCPROW tcprow);
        public static extern int SetTcpEntry(IntPtr pTcprow);

        /// <summary>
        /// Convert 16-bit value from network to host byte order 
        /// </summary>
        /// <param name="netshort"></param>
        /// <returns></returns>
        [DllImport("wsock32.dll")]
        public static extern int ntohs(int netshort);

        /// <summary>
        /// Convert 16-bit value back again 
        /// </summary>
        /// <param name="netshort"></param>
        /// <returns></returns>
        [DllImport("wsock32.dll")]
        public static extern int htons(int netshort);
        #endregion

        #region Método(s) estático(s) público(s)
        /// <summary>
        /// desplega el menu de inicio de windows
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        public static void ShowStartMenu(int x, int y, int cx, int cy)
        {
            IntPtr StartMenu = FindWindow("DV2ControlHost", null);
            SetWindowPos(StartMenu, new IntPtr(HWND_TOP), x, y, cx, cy, SWP_NOSIZE);

            ShowWindowAsync(StartMenu, 1);
        }
        /// <summary>
        /// Ejecución del teclado en pantalla
        /// </summary>
        public static void ShowScreenKeyboard(IntPtr handle)
        {
            int SW_SHOWNORMAL = 1;
            Wow64EnableWow64FsRedirection(false);
            ShellExecute(handle, "open", "osk.exe", "", Environment.CurrentDirectory, SW_SHOWNORMAL);
            Wow64EnableWow64FsRedirection(true);
        }
	    #endregion
    }
}
