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
    public class ORowEventArgs : Infragistics.Win.UltraWinGrid.RowEventArgs
    {
        #region Atributos privados
        Infragistics.Win.UltraWinGrid.UltraGridRow anterior;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.ORowEventArgs.
        /// </summary>
        /// <param name="fila"></param>
        public ORowEventArgs(Infragistics.Win.UltraWinGrid.UltraGridRow fila)
            : base(fila) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.ORowEventArgs.
        /// </summary>
        /// <param name="fila">Empty.</param>
        /// <param name="anterior">Empty.</param>
        public ORowEventArgs(Infragistics.Win.UltraWinGrid.UltraGridRow fila, Infragistics.Win.UltraWinGrid.UltraGridRow anterior)
            : this(fila)
        {
            this.anterior = anterior;
        }
        #endregion

        #region Propiedades
        public Infragistics.Win.UltraWinGrid.UltraGridRow FilaAnterior
        {
            get { return this.anterior; }
            set { this.anterior = value; }
        }
        #endregion
    }
}