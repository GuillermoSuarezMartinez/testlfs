﻿using System;
using System.Diagnostics;
using System.IO;
namespace Orbita.Utiles
{
    public static class OProcesos
    {
        /// <summary>
        /// Mata determinado proceso
        /// </summary>
        /// <param name="nombre">Nombre del proceso</param>
        /// <returns>Verdadero si el proceso ha sido matado</returns>
        public static Process EncontrarProceso(string nombre, string ruta)
        {
            Process resultado = null;
            try
            {
                Process[] asProccess = Process.GetProcessesByName(nombre);
                foreach (Process pProccess in asProccess)
                {
                    if (pProccess.MainModule.FileName == ruta)
                    {
                        resultado = pProccess;
                        break;
                    }
                }
            }
            catch (Exception) { }
            return resultado;
        }
        /// <summary>
        /// Mata determinado proceso
        /// </summary>
        /// <param name="nombre">Nombre del proceso</param>
        /// <returns>Verdadero si el proceso ha sido matado</returns>
        public static bool MatarProceso(string nombre, string ruta)
        {
            bool resultado = false;
            try
            {
                bool procesoEncontrado;
                // Matamos el proceso de depuración
                procesoEncontrado = true;
                while (procesoEncontrado)
                {
                    procesoEncontrado = false;
                    Process[] asProccess = Process.GetProcessesByName("dw20");
                    foreach (Process pProccess in asProccess)
                    {
                        pProccess.Kill();
                        pProccess.WaitForExit(1000);
                        procesoEncontrado = true;
                    }
                }
                // Matamos el proceso principal
                procesoEncontrado = true;
                while (procesoEncontrado)
                {
                    procesoEncontrado = false;
                    Process[] asProccess = Process.GetProcessesByName(nombre);
                    foreach (Process pProccess in asProccess)
                    {
                        if (pProccess.MainModule.FileName == ruta)
                        {
                            pProccess.Kill();
                            pProccess.WaitForExit(1000);
                            procesoEncontrado = true;
                        }
                    }
                }
                resultado = !procesoEncontrado;
            }
            catch (Exception) { }
            return resultado;
        }
        /// <summary>
        /// Inicia una aplicación
        /// </summary>
        /// <param name="ruta">Ruta del ejecutable</param>
        /// <returns>Verdadero si la aplicación se ha ejecutado con éxito</returns>
        public static bool IniciarProceso(string ruta)
        {
            bool resultado = false;
            try
            {
                if (Path.IsPathRooted(ruta) && File.Exists(ruta))
                {
                    ProcessStartInfo info = new ProcessStartInfo(ruta);
                    Process programa = Process.Start(info);
                    resultado = true;
                }
            }
            catch (Exception) { }
            return resultado;
        }
    }
}