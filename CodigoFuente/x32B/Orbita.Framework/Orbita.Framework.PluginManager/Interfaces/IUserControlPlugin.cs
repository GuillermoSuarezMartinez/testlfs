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
    /// Interface de plugins de tipo controles de usuario (Controles.Shared.OrbitaUserControl).
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public interface IUserControlPlugin : IPlugin
    {
        /// <summary>
        /// Control de usuario (OrbitaUserControl).
        /// </summary>
        Controles.Shared.OrbitaUserControl Control { get; }
    }
}