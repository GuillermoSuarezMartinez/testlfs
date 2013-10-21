//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// A factory of logging targets. Creates new targets based on their names.
    /// </summary>
    public static class FactoryLogger
    {
        #region Atributos privados estáticos
        /// <summary>
        /// Colección de loggers.
        /// </summary>
        private static TypeDictionary _loggers = AddDefaultTargets();
        #endregion

        #region Métodos públicos estáticos
        /// <summary>
        /// Removes all target information from the factory.
        /// </summary>
        public static void Clear()
        {
            _loggers.Clear();
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
        /// <param name="ensamblado">The assembly to be scanned for targets.</param>
        /// <param name="prefijo">The prefix to be prepended to target names.</param>
        public static void AddTargetsFromAssembly(System.Reflection.Assembly ensamblado, string prefijo)
        {
            if (ensamblado == null) return;
            foreach (System.Type tipo in ensamblado.GetTypes())
            {
                var atributos = (TargetAttribute[])tipo.GetCustomAttributes(typeof(TargetAttribute), false);
                foreach (TargetAttribute atributo in atributos)
                {
                    AddTarget(prefijo + atributo.Nombre, tipo);
                }
            }
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
        public static void AddTarget(string targetName, System.Type targetType)
        {
            if (!string.IsNullOrEmpty(targetName))
            {
                string hashKey = targetName;
                _loggers[hashKey] = targetType;
            }
        }
        /// <summary>
        /// Creates the target object based on its target name.
        /// </summary>
        /// <param name="tipo">The name of the target (e.g. <code>File</code> or <code>Console</code>)</param>
        /// <returns>A new instance of the Target object.</returns>
        public static ILogger CreateTarget(string tipo)
        {
            if (!string.IsNullOrEmpty(tipo))
            {
                System.Type t = _loggers[tipo];
                if (t != null)
                {
                    var logger = FactoryHelper.CreateInstance(t) as ILogger;
                    if (logger != null)
                    {
                        return logger;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Collection of target types added to the factory.
        /// </summary>
        public static System.Collections.ICollection TargetTypes
        {
            get { return _loggers.Values; }
        }
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// Adds default targets from the Orbita.Trazabilidad.dll assembly.
        /// </summary>
        private static TypeDictionary AddDefaultTargets()
        {
            _loggers = new TypeDictionary();
            foreach (System.Reflection.Assembly ensamblado in ExtensionUtiles.GetEnsamblados)
            {
                AddTargetsFromAssembly(ensamblado, "");
            }
            return _loggers;
        }
        #endregion
    }
}