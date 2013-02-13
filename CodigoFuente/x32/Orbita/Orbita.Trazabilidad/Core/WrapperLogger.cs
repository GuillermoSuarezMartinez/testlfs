//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Wrapper Logger.
    /// </summary>
    [Target("Wrapper", ESWrapper = true)]
    public class WrapperLogger : BaseLogger
    {
        #region Atributos privados
        /// <summary>
        /// Colecci�n de loggers.
        /// </summary>
        System.Collections.Generic.List<ILogger> loggers;
        #endregion

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
        /// <param name="loggers">Colecci�n de loggers.</param>
        public WrapperLogger(string identificador, params ILogger[] loggers)
            : this(identificador, NivelLog.Debug, loggers) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.WrapperLogger.
        /// Por defecto, <c>Puerto=1440</c>.
        /// </summary>
        /// <param name="identificador">Identificador de logger.</param>
        /// <param name="nivelLog">Nivel de logger.</param>
        /// <param name="loggers">Colecci�n de loggers.</param>
        public WrapperLogger(string identificador, NivelLog nivelLog, params ILogger[] loggers)
            : base(identificador, nivelLog)
        {
            // Crear la colecci�n de loggers.
            this.loggers = new System.Collections.Generic.List<ILogger>(loggers);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colecci�n de loggers.
        /// </summary>
        public System.Collections.Generic.List<ILogger> Loggers
        {
            get { return this.loggers; }
            set { this.loggers = value; }
        }
        #endregion

        #region M�todos p�blicos
        /// <summary>
        /// Registra un elemento determinado.
        /// </summary>
        /// <param name="item">Entrada de registro.</param>
        public override void Log(ItemLog item)
        {
            // Recorrer la colecci�n de loggers.
            foreach (BaseLogger logger in this.loggers)
            {
                if (item.NivelLog >= logger.NivelLog)
                {
                    // Registrar cada item de la colecci�n.
                    logger.Log(item);
                }
            }
        }
        /// <summary>
        /// Registra un elemento determinado con par�metros adicionales.
        /// </summary>
        /// <param name="item">Entrada de registro.</param>
        /// <param name="args">Par�metros adicionales.</param>
        public override void Log(ItemLog item, object[] args)
        {
            // Recorrer la colecci�n de loggers.
            foreach (BaseLogger logger in this.loggers)
            {
                if (item.NivelLog >= logger.NivelLog)
                {
                    // Registrar cada item de la colecci�n.
                    logger.Log(item, args);
                }
            }
        }
        #endregion
    }
}
