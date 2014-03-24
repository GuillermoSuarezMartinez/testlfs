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
    /// <summary>
    /// Alineación de texto.
    /// </summary>
    public enum Alineacion
    {
        /// <summary>
        /// Alineación por defecto. Sin alineación.
        /// </summary>
        None = Infragistics.Win.HAlign.Default,
        /// <summary>
        /// Alineación de texto centrada.
        /// </summary>
        Centrado = Infragistics.Win.HAlign.Center,
        /// <summary>
        /// Alineación de texto izquierda.
        /// </summary>
        Izquierda = Infragistics.Win.HAlign.Left,
        /// <summary>
        /// Alineación de texto derecha.
        /// </summary>
        Derecha = Infragistics.Win.HAlign.Right
    }
}
