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
using Orbita.Controles.Grid;
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
        internal const bool DefectoMostrarFiltros = true;
        internal const bool DefectoMostrarRecuentoFilas = true;
        internal const bool DefectoMostrarIndicador = false;
        internal const bool DefectoMultiseleccion = false;
        internal const bool DefectoCabeceraMultilinea = false;
        internal const bool DefectoConfirmarBorrado = true;
        internal const AreaSumario DefectoPosicionSumario = AreaSumario.AbajoFijo;
        internal const int DefectoAlto = -1;
        internal const bool DefectoPermitirBorrar = true;
        internal const bool DefectoOcultarAgrupadorFilas = false;
        internal const bool DefectoCancelarTeclaReturn = true;
        internal const EstiloCeldasAgrupadas DefectoEstiloCeldasAgrupadas = EstiloCeldasAgrupadas.NoAgrupar;
        internal const TipoFiltro DefectoTipoFiltro = TipoFiltro.Fila;
        internal const TipoSeleccion DefectoTipoSeleccionCelda = TipoSeleccion.Ninguna;
        internal const TipoSeleccion DefectoTipoSeleccionColumna = TipoSeleccion.Ninguna;
        internal const ModoActualizacion DefectoModoActualizacion = ModoActualizacion.CambioDeCeldaOsinFoco;
        internal const bool DefectoMostrarTitulo = false;
        internal const string DefectoColorFondoColumnasBloqueadas = "Control";
        #endregion
    }
}