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
namespace Orbita.Framework.Core
{
    public class IdiomaChangedEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Idioma.
        /// </summary>
        SelectorIdioma idioma;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.IdiomaChangedEventArgs.
        /// </summary>
        public IdiomaChangedEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.IdiomaChangedEventArgs.
        /// </summary>
        /// <param name="cadena">Nombre de la propiedad.</param>
        public IdiomaChangedEventArgs(SelectorIdioma idioma)
            : this()
        {
            this.idioma = idioma;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Idioma.
        /// </summary>
        public SelectorIdioma Idioma
        {
            get { return this.idioma; }
            set { this.idioma = value; }
        }
        #endregion
    }
}