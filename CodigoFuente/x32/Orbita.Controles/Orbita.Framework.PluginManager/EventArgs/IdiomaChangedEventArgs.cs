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
    /// Clase que contiene datos de eventos de cambio de idioma.
    /// </summary>
    public class IdiomaChangedEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Atributo relativo al idioma actual de controles.
        /// </summary>
        Orbita.Framework.Core.SelectorIdioma idioma;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.PluginManager.IdiomaChangedEventArgs.
        /// </summary>
        public IdiomaChangedEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.PluginManager.IdiomaChangedEventArgs.
        /// </summary>
        /// <param name="idioma">Nombre de la propiedad.</param>
        public IdiomaChangedEventArgs(Orbita.Framework.Core.SelectorIdioma idioma)
            : this()
        {
            this.idioma = idioma;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Relativo al idioma actual de controles.
        /// </summary>
        public Orbita.Framework.Core.SelectorIdioma Idioma
        {
            get { return this.idioma; }
            set { this.idioma = value; }
        }
        #endregion
    }
}