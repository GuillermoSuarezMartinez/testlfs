//***********************************************************************
// Assembly         : Orbita.Framework.PluginManager
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
        /// Interface de plugin.
        /// </summary>
        public IPlugin Plugin { get; set; }
        /// <summary>
        /// Interface de menú.
        /// </summary>
        public IItemMenu ItemMenu { get; set; }
        /// <summary>
        /// Delegado de cambio de idioma de controles.
        /// </summary>
        public System.EventHandler<IdiomaChangedEventArgs> CambiarIdioma;
        /// <summary>
        /// Delegado de manejador de cierre de aplicación.
        /// </summary>
        public System.EventHandler<System.Windows.Forms.FormClosedEventArgs> ManejadorCierreAplicacion;
        #endregion
    }
}