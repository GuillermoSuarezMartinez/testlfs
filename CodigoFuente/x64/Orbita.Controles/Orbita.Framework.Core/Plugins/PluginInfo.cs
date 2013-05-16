//***********************************************************************
// Assembly         : Orbita.Framework.Core
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Información del plugin.
    /// </summary>
    public class PluginInfo
    {
        #region Propiedades
        /// <summary>
        /// Objeto plugin.
        /// </summary>
        public IPlugin Plugin { get; set; }
        /// <summary>
        /// Nombre del ensamblado.
        /// </summary>
        public string Ensamblado { get; set; }
        #endregion
    }
}