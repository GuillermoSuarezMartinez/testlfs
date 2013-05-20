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
namespace Orbita.Framework.PluginManager
{
    /// <summary>
    /// Información del plugin.
    /// </summary>
    public class PluginInfo
    {
        #region Propiedades
        /// <summary>
        /// Nombre del ensamblado asociado al plugin.
        /// </summary>
        public string Ensamblado { get; set; }
        /// <summary>
        /// Objeto control plugin.
        /// </summary>
        public IPlugin Plugin { get; set; }
        public IItemMenu ItemMenu { get; set; }
        [System.CLSCompliantAttribute(false)]
        public IFormIdioma Idioma { get; set; }
        #endregion
    }
}