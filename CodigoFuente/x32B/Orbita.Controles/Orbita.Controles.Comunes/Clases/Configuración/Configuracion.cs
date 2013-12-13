//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Comunes
{
    internal static class Configuración
    {
        #region Atributos internos constantes
        internal static System.Drawing.Color DefectoColorBorde = System.Drawing.Color.Empty;
        internal static System.Drawing.Color DefectoColorFondo = System.Drawing.Color.Empty;
        internal static System.Drawing.Color DefectoColorTexto = System.Drawing.Color.Empty;
        internal const EstiloBorde DefectoEstiloBorde = EstiloBorde.Solido;
        internal const AlineacionHorizontal DefectoAlineacionTextoHorizontal = AlineacionHorizontal.Izquierda;
        internal const AlineacionVertical DefectoAlineacionTextoVertical = AlineacionVertical.Arriba;
        internal const AdornoTexto DefectoAdornoTexto = AdornoTexto.Ninguno;
        internal const bool DefectoAutoScrollBar = true;
        #endregion
    }
}