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
    public enum EstiloColumna
    {
        None = Infragistics.Win.UltraWinGrid.ColumnStyle.Default,
        Calendar = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownCalendar,
        EditButton = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton,
        Boton = Infragistics.Win.UltraWinGrid.ColumnStyle.Button,
        Check = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox,
        CheckTriestado = Infragistics.Win.UltraWinGrid.ColumnStyle.TriStateCheckBox,
        Combo = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList,
        Color = Infragistics.Win.UltraWinGrid.ColumnStyle.Color,
        Fecha = Infragistics.Win.UltraWinGrid.ColumnStyle.DateWithoutDropDown,
        FechaHora = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTimeWithoutDropDown,
        Fuente = Infragistics.Win.UltraWinGrid.ColumnStyle.Font,
        Imagen = Infragistics.Win.UltraWinGrid.ColumnStyle.Image,
        HiperLink = Infragistics.Win.UltraWinGrid.ColumnStyle.URL,
        Moneda = Infragistics.Win.UltraWinGrid.ColumnStyle.Currency,
        Numerico = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer,
        NumericoDecimal = Infragistics.Win.UltraWinGrid.ColumnStyle.Double,
        Texto = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
    }
}
