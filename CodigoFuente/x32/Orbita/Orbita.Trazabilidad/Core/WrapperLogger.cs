//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Wrapper Logger.
    /// </summary>
    [Target("Wrapper", EsWrapper = true)]
    public class WrapperLogger : BaseLogger
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.WrapperLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Puerto=1440</c>.
        /// </summary>
        public WrapperLogger() : this(string.Empty) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.WrapperLogger.
        /// Por defecto, <c>NivelLog=Debug</c>, <c>Puerto=1440</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="loggers">Colección de loggers.</param>
        public WrapperLogger(string identificador, params ILogger[] loggers)
            : this(identificador, NivelLog.Debug, loggers) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.WrapperLogger.
        /// Por defecto, <c>Puerto=1440</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="loggers">Colección de loggers.</param>
        public WrapperLogger(string identificador, NivelLog nivelLog, params ILogger[] loggers)
            : base(identificador, nivelLog)
        {
            // Crear la colección de loggers.
            Loggers = new List<ILogger>(loggers);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de loggers.
        /// </summary>
        public List<ILogger> Loggers { get; private set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Registra un elemento determinado.
        /// </summary>
        /// <param name="item">Entrada de registro.</param>
        public override void Log(ItemLog item)
        {
            // Validar el parámetro 'item' antes de utilizarlo.
            if (item == null) return;
            // Recorrer la colección de loggers.
            foreach (BaseLogger logger in Loggers.Cast<BaseLogger>().Where(logger => item.NivelLog >= logger.NivelLog))
            {
                // Registrar cada item de la colección.
                logger.Log(item);
            }
        }
        /// <summary>
        /// Registra un elemento determinado con parámetros adicionales.
        /// </summary>
        /// <param name="item">Entrada de registro.</param>
        /// <param name="args">Parámetros adicionales.</param>
        public override void Log(ItemLog item, object[] args)
        {
            // Validar el parámetro 'item' antes de utilizarlo.
            if (item == null) return;
            // Recorrer la colección de loggers.
            foreach (BaseLogger logger in Loggers.Cast<BaseLogger>().Where(logger => item.NivelLog >= logger.NivelLog))
            {
                // Registrar cada item de la colección.
                logger.Log(item, args);
            }
        }
        #endregion
    }
}