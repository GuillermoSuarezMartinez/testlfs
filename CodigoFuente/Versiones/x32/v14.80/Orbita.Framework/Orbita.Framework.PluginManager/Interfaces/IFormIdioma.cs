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
    /// Interface de idioma.
    /// </summary>
    public interface IFormIdioma
    {
        /// <summary>
        /// Evento relacionado con el cambio de idioma desde los plugins.
        /// </summary>
        event System.EventHandler<IdiomaChangedEventArgs> OnCambiarIdioma;
    }
}