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

using System;

namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Contiene datos de eventos relativos a escritura en logger.
    /// </summary>
    public class LoggerEventArgs : EventArgs
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        public LoggerEventArgs() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        public LoggerEventArgs(ItemLog item)
            : this()
        {
            Item = item;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        /// <param name="excepcion">Excepción.</param>
        public LoggerEventArgs(ItemLog item, Exception excepcion)
            : this(item)
        {
            Excepcion = excepcion;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Item de entrada.
        /// </summary>
        public ItemLog Item { get; set; }
        /// <summary>
        /// Excepción.
        /// </summary>
        public Exception Excepcion { get; set; }
        #endregion
    }
}