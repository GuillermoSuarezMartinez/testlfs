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
    /// Mantiene la configuración del registro y proporciona una API sencilla.
    /// </summary>
    public class ConfiguracionLogger
    {
        #region Atributos privados internos
        /// <summary>
        /// Colección de loggers.
        /// </summary>
        internal DictionaryLogger Loggers = new DictionaryLogger();
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Registers the specified target object under a given name.
        /// </summary>
        /// <param name="nombre">Name of the target.</param>
        /// <param name="logger">The target object.</param>
        public void AddLogger(string nombre, ILogger logger)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                Loggers[nombre] = logger;
            }
        }
        /// <summary>
        /// Finds the target with the specified name.
        /// </summary>
        /// <param name="nombre">The name of the target to be found.</param>
        /// <returns>Found target or <see langword="null" /> when the target is not found.</returns>
        public ILogger FindLoggerByName(string nombre)
        {
            return !string.IsNullOrEmpty(nombre) ? Loggers[nombre] : null;
        }
        #endregion
    }
}