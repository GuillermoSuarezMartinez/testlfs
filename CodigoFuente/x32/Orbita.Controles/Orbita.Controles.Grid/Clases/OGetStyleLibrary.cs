//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public class OGetStyleLibrary
    {
        #region Constructor
        public OGetStyleLibrary() { }
        #endregion Constructor

        #region Private Members
        private string islFileName = "";

        public string IslFileName
        {
            get { return islFileName; }
            set { islFileName = value; }
        }
        #endregion Private Members

        #region styleLibraryPath
        /// <summary>
        /// Path to the Style Library folder installed by the install.
        /// </summary>
        private static string styleLibraryPath
        {
            get { return System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Temas"); }
        }
        #endregion

        #region Private Methods
        public string GetIsl(string isl)
        {
            this.islFileName = string.Format(System.Globalization.CultureInfo.CurrentCulture, @"C:\Proyectos\ISL\GestionNet2013\{0}.isl", isl);
            return islFileName;
            //return System.IO.Path.Combine(styleLibraryPath, islFileName);
        }
        #endregion Private Methods
    }
}