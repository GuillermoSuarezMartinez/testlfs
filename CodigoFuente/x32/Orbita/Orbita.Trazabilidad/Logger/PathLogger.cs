//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Path Logger.
    /// </summary>
    public class PathLogger : FullPath
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathLogger.
        /// </summary>
        public PathLogger()
            : this(string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}\{1}", System.Windows.Forms.Application.StartupPath, Ruta.Debug)) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathLogger.
        /// </summary>
        /// <param name="path">Ruta de almacenamiento de ficheros de logger.</param>
        public PathLogger(string path)
            : this(path, Trazabilidad.Fichero.Debug) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathLogger.
        /// </summary>
        /// <param name="path">Ruta de almacenamiento de ficheros de logger.</param>
        /// <param name="fichero">Nombre del fichero de logger.</param>
        public PathLogger(string path, string fichero)
            : this(path, fichero, Trazabilidad.Extension.Log) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathLogger.
        /// </summary>
        /// <param name="path">Ruta de almacenamiento de ficheros de logger.</param>
        /// <param name="fichero">Nombre del fichero de logger.</param>
        /// <param name="extension">Extensión del fichero de logger.</param>
        public PathLogger(string path, string fichero, string extension)
            : base(path)
        {
            Fichero = fichero;
            Extension = extension;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre del fichero de logger.
        /// </summary>
        public string Fichero { get; set; }
        /// <summary>
        /// Extensión del fichero de logger.
        /// </summary>
        public string Extension { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Sobreescritura del método ToString().
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}\{1}.{2}", Path, Fichero, Extension);
        }
        /// <summary>
        /// Comprobar la existencia del fichero.
        /// </summary>
        /// <returns>True/False.</returns>
        public bool ExisteFichero()
        {
            return System.IO.File.Exists(ToString());
        }
        /// <summary>
        /// Borrar fichero.
        /// </summary>
        /// <returns>True/False.</returns>
        public bool BorrarFichero()
        {
            string archivo = ToString();
            if (System.IO.File.Exists(archivo))
            {
                // Elimina el archivo especificado. Si el archivo no existe, no produce una excepción.
                System.IO.File.Delete(archivo);
                return true;
            }
            return false;
        }
        #endregion
    }
}