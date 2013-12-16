﻿//***********************************************************************
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
    /// Full Path.
    /// </summary>
    public class FullPath
    {
        #region Atributos privados
        /// <summary>
        /// Ruta de almacenamiento de ficheros.
        /// </summary>
        string path;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.FullPath.
        /// </summary>
        public FullPath() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.FullPath.
        /// </summary>
        /// <param name="path">Ruta de almacenamiento de ficheros.</param>
        public FullPath(string path)
        {
            //this.Path = path;
            this.path = path;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Ruta de almacenamiento de ficheros.
        /// </summary>
        public string Path
        {
            get { return this.path; }
            set
            {
                this.path = value;
                if (!this.Existe())
                {
                    this.Crear();
                }
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Comprobar la existencia del directorio.
        /// </summary>
        /// <returns>True/False.</returns>
        public bool Existe()
        {
            return System.IO.Directory.Exists(this.path);
        }
        /// <summary>
        /// Crear el directorio en la ruta del objeto.
        /// </summary>
        public void Crear()
        {
            System.IO.Directory.CreateDirectory(this.path);
        }
        #endregion
    }
}