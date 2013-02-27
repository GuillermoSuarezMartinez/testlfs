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
using Infragistics.Win.UltraWinGrid;
namespace Orbita.Controles.Grid
{
    public class ORowEventArgs : RowEventArgs
    {
        #region Atributos privados
        UltraGridRow anterior;
        #endregion

        #region Constructores
        public ORowEventArgs(UltraGridRow fila)
            : base(fila) { }
        public ORowEventArgs(UltraGridRow fila, UltraGridRow anterior)
            : this(fila)
        {
            this.anterior = anterior;
        }
        #endregion

        #region Propiedades
        public UltraGridRow FilaAnterior
        {
            get { return this.anterior; }
            set { this.anterior = value; }
        }
        #endregion
    }
}