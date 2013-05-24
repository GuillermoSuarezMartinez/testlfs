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
    /// Interface de controles de usuario.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public interface IUserControlPlugin : IPlugin
    {
        /// <summary>
        /// Control de usuario (OrbitaUserControl).
        /// </summary>
        Orbita.Controles.Shared.OrbitaUserControl Control { get; }
    }
}