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
    public static class OProvider
    {
        #region Métodos públicos estáticos
        /// <summary>
        /// Obtener el System.Drawing.Color a partir de un valor de color de tipo String. 
        /// </summary>
        /// <param name="color">Color de tipo string.</param>
        /// <returns>Color traducido en el tipo System.Drawing.Color.</returns>
        public static System.Drawing.Color GetDrawingColor(string color)
        {
            return System.Drawing.ColorTranslator.FromHtml(color);
        }
        #endregion
    }
}