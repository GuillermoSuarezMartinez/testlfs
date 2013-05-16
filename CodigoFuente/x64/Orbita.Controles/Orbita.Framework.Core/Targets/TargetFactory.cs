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
using System.Reflection;
using System.Globalization;
using System.Collections;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// A factory of logging targets. Creates new targets based on their names.
    /// </summary>
    public sealed class TargetFactory
    {
        private static TypeDictionary _targets = new TypeDictionary();

        static TargetFactory()
        {
            foreach (Assembly a in Utiles.GetExtensionAssemblies())
            {
                AddTargetsFromAssembly(a, "");
            }
        }

        private TargetFactory() { }

        /// <summary>
        /// Removes all target information from the factory.
        /// </summary>
        public static void Clear()
        {
            _targets.Clear();
        }

        /// <summary>
        /// Removes all targets and reloads them from NLog assembly and default extension assemblies.
        /// </summary>
        public static void Reset()
        {
            Clear();
            AddDefaultTargets();
        }

        /// <summary>
        /// Scans the specified assembly for types marked with <see cref="TargetAttribute" /> and adds
        /// them to the factory. Optionally it prepends the specified text to the target names to avoid
        /// naming collisions.
        /// </summary>
        /// <param name="theAssembly">The assembly to be scanned for targets.</param>
        /// <param name="prefix">The prefix to be prepended to target names.</param>
        public static void AddTargetsFromAssembly(Assembly theAssembly, string prefix)
        {
            try
            {
                foreach (Type t in theAssembly.GetTypes())
                {
                    TargetAttribute[] attributes = (TargetAttribute[])t.GetCustomAttributes(typeof(TargetAttribute), false);
                    if (attributes != null)
                    {
                        foreach (TargetAttribute attr in attributes)
                        {
                            AddTarget(prefix + attr.Name, t);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Adds default targets from the NLog.dll assembly.
        /// </summary>
        private static void AddDefaultTargets()
        {
            AddTargetsFromAssembly(typeof(TargetFactory).Assembly, String.Empty);
        }

        /// <summary>
        /// Registers the specified target type to the factory under a specified name.
        /// </summary>
        /// <param name="targetName">The name of the target (e.g. <code>File</code> or <code>Console</code>)</param>
        /// <param name="targetType">The type of the new target</param>
        /// <remarks>
        /// The name specified in the targetName parameter can then be used
        /// to create target.
        /// </remarks>
        public static void AddTarget(string targetName, Type targetType)
        {
            string hashKey = targetName.ToLower(CultureInfo.InvariantCulture);
            _targets[hashKey] = targetType;
        }

        /// <summary>
        /// Creates the target object based on its target name.
        /// </summary>
        /// <param name="name">The name of the target (e.g. <code>File</code> or <code>Console</code>)</param>
        /// <returns>A new instance of the Target object.</returns>
        public static Target CreateTarget(string name)
        {
            Type t = _targets[name.ToLower(CultureInfo.InvariantCulture)];
            if (t != null)
            {
                Target la = FactoryHelper.CreateInstance(t) as Target;
                if (la != null)
                    return la;
            }
            throw new ArgumentException("Target " + name + " not found.");
        }

        /// <summary>
        /// Collection of target types added to the factory.
        /// </summary>
        public static ICollection TargetTypes
        {
            get { return _targets.Values; }
        }
    }
}