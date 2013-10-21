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
    /// Path Backup.
    /// </summary>
    public class PathBackup : FullPath
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathBackup.
        /// </summary>
        public PathBackup()
            : this(string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}\{1}", System.Windows.Forms.Application.StartupPath, Ruta.Backup)) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathBackup.
        /// </summary>
        /// <param name="path">Ruta de almacenamiento de ficheros de backup de logger.</param>
        public PathBackup(string path)
            : this(path, Trazabilidad.Mascara.AñoMes) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathBackup.
        /// </summary>
        /// <param name="subPath">Subruta de almacenamiento de ficheros de backup de logger.</param>
        public PathBackup(Mascara subPath)
            : this(string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}\{1}", System.Windows.Forms.Application.StartupPath, Ruta.Backup), subPath) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PathBackup.
        /// </summary>
        /// <param name="path">Ruta de almacenamiento de ficheros de backup de logger.</param>
        /// <param name="subPath">Subruta de almacenamiento de ficheros de backup de logger.</param>
        public PathBackup(string path, Mascara subPath)
            : base(path)
        {
            SubPath = subPath;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Subruta de almacenamiento de ficheros de backup de logger.
        /// </summary>
        public Mascara SubPath { get; set; }
        /// <summary>
        /// Subruta string de almacenamiento de ficheros de backup de logger. Propiedad de solo lectura.
        /// </summary>
        public string Mascara
        {
            get
            {
                switch (SubPath)
                {
                    case Trazabilidad.Mascara.Año:
                        return Formato.Año;
                    case Trazabilidad.Mascara.Mes:
                        return Formato.Mes;
                    case Trazabilidad.Mascara.MesDia:
                        return Formato.MesDia;
                    case Trazabilidad.Mascara.AñoMes:
                        return Formato.AñoMes;
                    case Trazabilidad.Mascara.AñoMesDia:
                        return Formato.AñoMesDia;
                    default:
                        return null;
                }
            }
        }
        #endregion
    }
}