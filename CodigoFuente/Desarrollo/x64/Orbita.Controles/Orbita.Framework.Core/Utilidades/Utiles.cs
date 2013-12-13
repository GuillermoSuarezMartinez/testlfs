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
using System;
using System.Collections;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// A class that loads and manages NLog extension assemblies.
    /// </summary>
    public class Utiles
    {
        private static ArrayList _extensionAssemblies = new ArrayList();

        static Utiles()
        {
            // load default targets, filters and layout renderers.
            _extensionAssemblies.Add(typeof(Orbita.Framework.Core.IPlugin).Assembly);
        }

        /// <summary>
        /// Gets the list of loaded NLog extension assemblies.
        /// </summary>
        /// <returns>An <see cref="ArrayList"/> containing all NLog extension assemblies that have been loaded.</returns>
        public static ArrayList GetExtensionAssemblies()
        {
            return _extensionAssemblies;
        }
    }
}