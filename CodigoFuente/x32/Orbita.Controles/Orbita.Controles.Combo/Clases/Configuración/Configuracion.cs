//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Combo
{
    /// <summary>
    /// Orbita.Controles.Combo.Configuracion.
    /// </summary>
    internal static class Configuracion
    {
        #region Atributos internos constantes
        internal const EstiloBorde DefectoEstiloBorde = EstiloBorde.Solido;
        internal const AlineacionHorizontal DefectoAlineacionTextoHorizontal = AlineacionHorizontal.Izquierda;
        internal const AlineacionVertical DefectoAlineacionTextoVertical = AlineacionVertical.Arriba;
        internal const AdornoTexto DefectoAdornoTexto = AdornoTexto.Ninguno;
        internal const EstiloCabecera DefectoEstiloCabecera = EstiloCabecera.Standard;
        internal const bool DefectoPermitirOrdenar = true;
        internal const bool DefectoMostrarFiltro = true;
        internal const AutoAjustarEstilo DefectoAutoAjustarEstilo = AutoAjustarEstilo.ExtenderUltimaColumna;
        internal const bool DefectoEditable = false;
        internal const object DefectoValor = null;
        internal const string DefectoTexto = "";
        internal const bool DefectoNullablePorTeclado = true;
        #endregion
    }
}