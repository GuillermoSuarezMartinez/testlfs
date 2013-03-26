﻿//***********************************************************************
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
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Contiene datos de eventos relativos a escritura en logger.
    /// </summary>
    public class LoggerEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Item de entrada.
        /// </summary>
        ItemLog item;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        public LoggerEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        public LoggerEventArgs(ItemLog item)
            : this()
        {
            this.item = item;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Item de entrada.
        /// </summary>
        public ItemLog Item
        {
            get { return this.item; }
        }
        #endregion
    }
}