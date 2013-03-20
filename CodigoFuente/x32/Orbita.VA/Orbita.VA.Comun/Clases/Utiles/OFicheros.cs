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
using System.Collections.Generic;
using System.Text;
using System.IO;
using Orbita.VA.Comun;
using System.Windows.Forms;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Métodos genéricos para el trabajo con ficheros y carpetas
    /// </summary>
    public static class OFicheros
    {
        #region Método(s) utilizados para el trabajo con carpetas
        /// <summary>
        /// Se comprueba la existencia del directorio y si no existe se intenta crear
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static bool CreacionDirectorio(string ruta)
        {
            try
            {
                if (Path.IsPathRooted(ruta))
                {
                    if (Directory.Exists(ruta))
                    {
                        return true;
                    }
                    else
                    {
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(ruta);
                        if (directoryInfo.Exists)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Comun, "CreacionDirectorio", exception);
            }

            return false;
        }

        /// <summary>
        /// Calcula el tamaño de un directorio
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static long GetDirectorySize(string ruta, SearchOption searchOption)
        {
            // Get array of all file names.
            string[] files = Directory.GetFiles(ruta, "*.*", searchOption);

            // Calculate total bytes of all files in a loop.
            long totalSize = 0;
            foreach (string name in files)
            {
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                totalSize += info.Length;
            }
            // Return total size
            return totalSize;
        }

        /// <summary>
        /// Copia una carpeta
        /// </summary>
        /// <param name="sourceDirName">Ruta origen</param>
        /// <param name="destDirName">Ruta destino</param>
        /// <param name="copySubDirs">Opciones de la copi</param>
        public static bool DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool overwrite)
        {
            bool resultado = false;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                // If the source directory does not exist, throw an exception.
                if (dir.Exists)
                {
                    // If the destination directory does not exist, create it.
                    if (!Directory.Exists(destDirName))
                    {
                        Directory.CreateDirectory(destDirName);
                    }

                    // Get the file contents of the directory to copy.
                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        // Create the path to the new copy of the file.
                        string temppath = Path.Combine(destDirName, file.Name);

                        // Copy the file.
                        if (overwrite || !File.Exists(temppath))
                        {
                            file.CopyTo(temppath, overwrite);
                        }
                    }

                    // If copySubDirs is true, copy the subdirectories.
                    if (copySubDirs)
                    {
                        foreach (DirectoryInfo subdir in dirs)
                        {
                            // Create the subdirectory.
                            string temppath = Path.Combine(destDirName, subdir.Name);

                            // Copy the subdirectories.
                            DirectoryCopy(subdir.FullName, temppath, copySubDirs, overwrite);
                        }
                    }

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Comun, "DirectoryCopy", exception);
            }
            return resultado;
        }

        /// <summary>
        /// Mueve una carpeta
        /// </summary>
        /// <param name="sourceDirName">Ruta origen</param>
        /// <param name="destDirName">Ruta destino</param>
        /// <param name="copySubDirs">Opciones de la copi</param>
        public static bool DirectoryMove(string sourceDirName, string destDirName, bool moveSubDirs)
        {
            bool resultado = false;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                // If the source directory does not exist, throw an exception.
                if (dir.Exists)
                {
                    // Get the file contents of the directory to copy.
                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        if (!Directory.Exists(destDirName))
                        {
                            Directory.CreateDirectory(destDirName);
                        }
                        // Create the path to the new copy of the file.
                        string temppath = Path.Combine(destDirName, file.Name);

                        // Move the file.
                        file.MoveTo(temppath);
                    }

                    // If copySubDirs is true, copy the subdirectories.
                    if (moveSubDirs)
                    {
                        foreach (DirectoryInfo subdir in dirs)
                        {
                            // Create the subdirectory.
                            string temppath = Path.Combine(destDirName, subdir.Name);

                            // Move the subdirectories.
                            DirectoryMove(subdir.FullName, temppath, moveSubDirs);
                        }
                    }

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Comun, "DirectoryMove", exception);
            }
            return resultado;
        }
        #endregion

        #region Método(s) utilizados para el trabajo con URIs
        /// <summary>
        /// Indica si la ruta es local o remota
        /// </summary>
        /// <param name="ruta">Cadena de texto indicativa de la ruta</param>
        /// <param name="esLocal">Indica si la ruta es local o remota</param>
        /// <returns>Verdadero si se trata de una ruta válida</returns>
        public static bool Ruta2Uri(string ruta, out bool esLocal, out Uri uri)
        {
            bool resultado = false;
            esLocal = true;

            // Se identifica si se trta de una ruta local o remota
            resultado = Uri.TryCreate(ruta, UriKind.Absolute, out uri);

            if (resultado)
            {
                esLocal &= !uri.IsUnc;
            }

            return resultado;
        }
        #endregion
    }

    #region Clase ComposicionRuta: Compone una ruta permitiendo la utilización de parametros
    /// <summary>
    /// Clase utilizada para componer la ruta de almacenamiento de las imágenes
    /// </summary>
    public static class ORutaParametrizable
    {
        #region Constante(s)
        /// <summary>
        /// Ruta de la aplicación
        /// </summary>
        public const string RutaApp = @"%APP_PATH%";
        /// <summary>
        /// Fecha actual
        /// </summary>
        public const string Fecha = @"%FECHA%";
        /// <summary>
        /// Fecha y hora actual
        /// </summary>
        public const string FechaHora = @"%FECHA_HORA%";
        /// <summary>
        /// Año actual
        /// </summary>
        public const string Año = @"%AÑO%";
        /// <summary>
        /// Mes actual
        /// </summary>
        public const string Mes = @"%MES%";
        /// <summary>
        /// Día actual
        /// </summary>
        public const string Dia = @"%DIA%";
        /// <summary>
        /// Día juliano actual
        /// </summary>
        public const string DiaJuliano = @"%DIA_JULIANO%";
        /// <summary>
        /// Hora actual
        /// </summary>
        public const string Hora = @"%HORA%";
        /// <summary>
        /// Minuto actual
        /// </summary>
        public const string Minuto = @"%MINUTO%";
        /// <summary>
        /// Segundo actual
        /// </summary>
        public const string Segundo = @"%SEGUNDO%";
        /// <summary>
        /// Milisegundo actual
        /// </summary>
        public const string Milisegundo = @"%MILISEGUNDO%";
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Devuelve la ruta de la aplicación
        /// </summary>
        public static string AppPath
        {
            get
            {
                return Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            }
        }

        /// <summary>
        /// Devuelve la carpeta de la aplicación
        /// </summary>
        public static string AppFolder
        {
            get
            {
                return Path.GetDirectoryName(Application.ExecutablePath);
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Devuelve una cadena de texto identificativa del día actual (utilizada para indexar ficheros)
        /// </summary>
        /// <returns></returns>
        public static string DateString(DateTime fecha)
        {
            string resultado = string.Empty;

            resultado += fecha.Year.ToString("0000");
            resultado += fecha.Month.ToString("00");
            resultado += fecha.Day.ToString("00");

            return resultado;
        }

        /// <summary>
        /// Devuelve una cadena de texto identificativa del momento actual (utilizada para indexar ficheros)
        /// </summary>
        /// <returns></returns>
        public static string DateTimeString(DateTime fecha)
        {
            string resultado = string.Empty;

            resultado += fecha.Year.ToString("0000");
            resultado += fecha.Month.ToString("00");
            resultado += fecha.Day.ToString("00");
            resultado += fecha.Hour.ToString("00");
            resultado += fecha.Minute.ToString("00");
            resultado += fecha.Second.ToString("00");
            resultado += fecha.Millisecond.ToString("000");

            return resultado;
        }

        /// <summary>
        /// Composición de rutas a partir de parámetros
        /// </summary>
        /// <returns></returns>
        public static string ComponerRuta(string ruta, Dictionary<string, object> listaParametrosRuta)
        {
            return ComponerRuta(ruta, listaParametrosRuta, DateTime.Now);
        }

        /// <summary>
        /// Composición de rutas a partir de parámetros
        /// </summary>
        /// <returns></returns>
        public static string ComponerRuta(string ruta, Dictionary<string, object> listaParametrosRuta, DateTime momento)
        {
            string resultado = ruta;

            // Sustitución de parámetros propios
            resultado = resultado.Replace(RutaApp, AppFolder);
            resultado = resultado.Replace(Fecha, DateString(momento));
            resultado = resultado.Replace(FechaHora, DateTimeString(momento));
            resultado = resultado.Replace(Año, momento.Year.ToString("0000"));
            resultado = resultado.Replace(Mes, momento.Month.ToString("00"));
            resultado = resultado.Replace(Dia, momento.Day.ToString("00"));
            resultado = resultado.Replace(DiaJuliano, OFechaHora.GregorianoAJuliano(momento.Year, momento.Month, momento.Day).ToString("0000000"));
            resultado = resultado.Replace(Hora, momento.Hour.ToString("00"));
            resultado = resultado.Replace(Minuto, momento.Minute.ToString("00"));
            resultado = resultado.Replace(Segundo, momento.Second.ToString("00"));
            resultado = resultado.Replace(Milisegundo, momento.Millisecond.ToString("000"));

            // Sustitución de parámetros a medida
            foreach (KeyValuePair<string, object> parametroRuta in listaParametrosRuta)
            {
                resultado = resultado.Replace(parametroRuta.Key, OObjeto.ToString(parametroRuta.Value));
            }

            return resultado;
        }
        #endregion
    }
    #endregion
}
