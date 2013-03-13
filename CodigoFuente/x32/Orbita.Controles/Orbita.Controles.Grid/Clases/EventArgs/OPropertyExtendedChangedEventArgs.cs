//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    public class OPropertyExtendedChangedEventArgs : OPropiedadEventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Valor de la propiedad.
        /// </summary>
        object valor;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OPropiedadEventArgs.
        /// </summary>
        public OPropertyExtendedChangedEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OPropiedadEventArgs.
        /// </summary>
        public OPropertyExtendedChangedEventArgs(string nombre)
            : base(nombre) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OPropiedadEventArgs.
        /// </summary>
        /// <param name="nombre">Nombre de la propiedad.</param>
        /// <param name="valor">Empty.</param>
        public OPropertyExtendedChangedEventArgs(string nombre, object valor)
            : this(nombre)
        {
            this.valor = valor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        public object Valor
        {
            get { return this.valor; }
        }
        #endregion
    }
}