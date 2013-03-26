//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : crodriguez
// Created          : 03-03-2011
//
// Last Modified By : crodriguez
// Last Modified On : 03-03-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
namespace Orbita.Utiles
{
    /// <summary>
    /// Clase que representa eventos con argumentos
    /// adicionales tipados (EventArgs).
    /// </summary>
    [Serializable]
    public class OEventArgs : EventArgs
    {
        #region Atributos
        /// <summary>
        /// Argumento adicional desarrollado en el evento.
        /// </summary>
        object arg;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OEventArgs.
        /// </summary>
        public OEventArgs() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OEventArgs.
        /// </summary>
        /// <param name="arg">Argumento adicional.</param>
        public OEventArgs(object arg)
        {
            this.arg = arg;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Argumento adicional desarrollado en el evento.
        /// </summary>
        public object Argumento
        {
            get { return this.arg; }
            set { this.arg = value; }
        }
        #endregion
    }
}