//***********************************************************************
// Assembly         : Orbita.Controles.Contenedores
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Contenedores
{
    public static class OConfiguracion
    {
        #region Atributos
        /// <summary>
        /// VerTooltips.
        /// </summary>
        static bool FormVerToolTips = true;
        #endregion

        #region Propiedades
        /// <summary>
        /// VerTooltips.
        /// </summary>
        public static bool OrbFormVerToolTips
        {
            get { return OConfiguracion.FormVerToolTips; }
            set { OConfiguracion.FormVerToolTips = value; }
        }
        #endregion
    }
}