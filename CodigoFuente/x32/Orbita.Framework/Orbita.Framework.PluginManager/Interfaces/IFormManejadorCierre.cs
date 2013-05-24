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
    /// Interface de cierre.
    /// </summary>
    public interface IFormManejadorCierre
    {
        /// <summary>
        /// Evento de cierre.
        /// </summary>
        event System.EventHandler<System.Windows.Forms.FormClosedEventArgs> OnClose;
    }
}