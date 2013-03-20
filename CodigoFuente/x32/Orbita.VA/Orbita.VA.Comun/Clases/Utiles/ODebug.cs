//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 20-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Incluye métodos utilizados en la depuración de la aplicación
    /// </summary>
    public static class ODebug
    {
        /// <summary>
        /// Permite la depuración del sistema
        /// </summary>
        public static void WaitRemoteDebug()
        {
            if (Environment.UserInteractive)
            {
                if (!Debugger.IsAttached)
                {
                    OMensajes.MostrarInfo("Esperando la conexión de depuración remota");
                }
            }
            else
            {
                Debugger.Break();
                while (!Debugger.IsAttached)
                {
                    Thread.Sleep(1);
                }
            }
        }

        /// <summary>
        /// Devuelve información sobre el método que efectua la llamada
        /// </summary>
        /// <param name="ordenLlamada">0 es la información del método GetCallingMethod, 1 la del método que ha llamado, 2 la del metodo que ha llamado al que ha llamado al actual, etc....</param>
        public static void GetCallingMethod(int ordenLlamada, out string assembly, out string file, out string className, out string methode, out int line, out string pilaLlamadas)
        {
            assembly = string.Empty;
            file = string.Empty;
            className = string.Empty;
            methode = string.Empty;
            pilaLlamadas = string.Empty;
            line = 0;

            StackTrace stackTrace = new StackTrace(true);
            if (stackTrace.FrameCount > ordenLlamada)
            {
                StackFrame stackFrame = stackTrace.GetFrame(ordenLlamada);
                MethodBase methodeBase = stackFrame.GetMethod();

                pilaLlamadas = stackFrame.ToString();
                assembly = methodeBase.Module.Assembly.GetName().Name;
                file = Path.GetFileName(stackFrame.GetFileName());
                className = methodeBase.DeclaringType.ToString();
                methode = methodeBase.Name;
                line = stackFrame.GetFileLineNumber();
            }
        }

        /// <summary>
        /// Extrae la información de la excepción
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="assembly"></param>
        /// <param name="file"></param>
        /// <param name="className"></param>
        /// <param name="methode"></param>
        /// <param name="line"></param>
        /// <param name="pilaLlamadas"></param>
        public static void GetExceptionInfo(Exception exception, out string assembly, out string file, out string className, out string methode, out int line, out string pilaLlamadas)
        {
            assembly = string.Empty;
            file = string.Empty;
            className = string.Empty;
            methode = string.Empty;
            pilaLlamadas = string.Empty;
            line = 0;

            StackTrace st = new StackTrace(exception, true);
            foreach (StackFrame sf in st.GetFrames())
            {
                if (!string.IsNullOrEmpty(sf.GetFileName()))
                {
                    assembly = sf.GetMethod().Module.Assembly.GetName().Name;
                    file = sf.GetFileName();
                    className = sf.GetMethod().ReflectedType.FullName;
                    methode = sf.GetMethod().Name;
                    line = sf.GetFileLineNumber();
                    break;
                }
            }
            pilaLlamadas = exception.StackTrace;
        }

        /// <summary>
        /// Determina si la aplicación es de tipo consola
        /// </summary>
        /// <returns></returns>
        public static bool IsConsole()
        {
            return Console.In != StreamReader.Null;
        }

        /// <summary>
        /// Determina si la aplicación es de tipo Windows Forms
        /// </summary>
        /// <returns></returns>
        public static bool IsWinForms()
        {
            return !IsConsole() && Environment.UserInteractive; // && (Application.OpenForms.Count != 0);
        }
    }
}
