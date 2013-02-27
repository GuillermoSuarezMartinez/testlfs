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
    public static class OConfiguracion
    {
        #region Atributos

        #region Cabecera
        /// <summary>
        /// Cabecera alineación.
        /// </summary>
        public const Infragistics.Win.HAlign OrbGridCabeceraAlineacion = Infragistics.Win.HAlign.Left;
        /// <summary>
        /// Cabecera estilo.
        /// </summary>
        public const Infragistics.Win.HeaderStyle OrbGridCabeceraEstilo = Infragistics.Win.HeaderStyle.XPThemed;
        /// <summary>
        /// Cabecera multilínea.
        /// </summary>
        public const bool OrbGridCabeceraMultilinea = false;
        #endregion

        #region Celda
        /// <summary>
        /// Establece la edición de celdas en un grid (Grid editable).
        /// </summary>
        public const bool OrbGridCeldaEditable = false;
        #endregion

        #region Columna
        /// <summary>
        /// Autoajuste de columnas.
        /// </summary>
        public const Infragistics.Win.UltraWinGrid.AutoFitStyle OrbGridColumnaAutoajuste = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
        #endregion

        #region Fila
        /// <summary>
        /// Texto en negrita de fila activa.
        /// </summary>
        public const bool OrbGridFilaActivaTextoNegrita = true;
        /// <summary>
        /// Alto de fila.
        /// </summary>
        public const int OrbGridFilaAlto = 18;
        /// <summary>
        /// Alto de fila mínimo.
        /// </summary>
        public const int OrbGridFilaAltoMinimo = 5;
        /// <summary>
        /// Confirmación de borrado de filas.
        /// </summary>
        public const bool OrbGridFilaConfirmarBorrar = true;
        /// <summary>
        /// Mostrar indicador de fila.
        /// </summary>
        public const bool OrbGridFilaMostrarIndicador = false;
        /// <summary>
        /// Permitir borrar filas.
        /// </summary>
        public const bool OrbGridFilaPermitirBorrar = false;
        /// <summary>
        /// Permitir multiselección de filas.
        /// </summary>
        public const bool OrbGridFilaPermitirMultiSeleccion = false;
        #endregion

        #region Filtro
        /// <summary>
        /// Mostrar Filtros.
        /// </summary>
        public const bool OrbGridFiltroMostrar = true;
        #endregion

        #region Grid
        /// <summary>
        /// Esconder drag column.
        /// </summary>
        public const bool OrbGridEsconderDragColumn = true;
        /// <summary>
        /// 
        /// </summary>
        public const bool OrbGridIgnorarReturn = false;
        #endregion

        #region Separador
        /// <summary>
        /// Separador.
        /// </summary>
        public const Infragistics.Win.UltraWinGrid.SpecialRowSeparator OrbGridSeparador = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.FilterRow;
        /// <summary>
        /// Alto del Separador.
        /// </summary>
        public const int OrbGridSeparadorAlto = 5;
        #endregion

        #region Sumario
        /// <summary>
        /// Mostrar recuento de filas.
        /// </summary>
        public const bool OrbGridSumarioMostrarRecuentoFilas = false;
        #endregion

        #region ToolBar
        /// <summary>
        /// Estilo de Tool de la ToolBar.
        /// </summary>
        public const Infragistics.Win.UltraWinToolbars.ToolDisplayStyle OrbGridToolBarToolEstilo = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
        /// <summary>
        /// Mostrar ToolBar arriba.
        /// </summary>
        public const bool OrbGridToolBarMostrarArriba = true;
        /// <summary>
        /// Mostrar ToolBar arriba extendida.
        /// </summary>
        public const bool OrbGridToolBarMostrarArribaExtendida = false;
        /// <summary>
        /// Mostrar ToolBar derecha.
        /// </summary>
        public const bool OrbGridToolBarMostrarDerecha = false;
        #region Tools
        /// <summary>
        /// Tool Gestionar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolGestionar = false;
        /// <summary>
        /// Tool Ver.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolVer = false;
        /// <summary>
        /// Tool Modificar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolModificar = false;
        /// <summary>
        /// Tool Añadir.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolAñadir = false;
        /// <summary>
        /// Tool Eliminar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolEliminar = false;
        /// <summary>
        /// Tool Editar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolEditar = true;
        /// <summary>
        /// Tool Exportar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolExportar = true;
        /// <summary>
        /// Tool Imprimir.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolImprimir = false;
        /// <summary>
        /// Tool Estilo.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolEstilo = false;
        /// <summary>
        /// Tool Refrescar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolRefrescar = true;
        /// <summary>
        /// Tool Filtrar.
        /// </summary>
        public const bool OrbGridToolBarMostrarToolFiltrar = false;
        #endregion
        #endregion

        #region Colores
        /// <summary>
        /// Color de borde.
        /// </summary>
        public const string ColorBorde = "DimGray";
        /// <summary>
        /// Color de filtros.
        /// </summary>
        public const string ColorFiltros = "SandyBrown";
        /// <summary>
        /// Color de fondo.
        /// </summary>
        public const string ColorFondo = "0xF8C581";
        /// <summary>
        /// Color de fuente.
        /// </summary>
        public const string ColorFuente = "Black";
        /// <summary>
        /// Color de cabecera.
        /// </summary>
        public const string ColorCabecera = "DarkOrange";
        /// <summary>
        /// Color entre líneas.
        /// </summary>
        public const string ColorEntreLinea = "Silver";
        /// <summary>
        /// Color de fila.
        /// </summary>
        public const string ColorFila = "White";
        /// <summary>
        /// Color de fila alterna.
        /// </summary>
        public const string ColorFilaAlterna = "0xFFF3DF";
        /// <summary>
        /// Color de fila activa.
        /// </summary>
        public const string ColorFilaActiva = "DarkOrange";
        /// <summary>
        /// Color de celda activa.
        /// </summary>
        public const string ColorCeldaActiva = "0xFFA940";
        /// <summary>
        /// Color de texto de la fila.
        /// </summary>
        public const string ColorTextoFila = "Black";
        /// <summary>
        /// Color de texto de la fila alterna.
        /// </summary>
        public const string ColorTextoFilaAlterna = "Black";
        /// <summary>
        /// Color de textos de fila activa.
        /// </summary>
        public const string ColorTextoFilaActiva = "White";
        /// <summary>
        /// Color de texto de celda activa.
        /// </summary>
        public const string ColorTextoCeldaActiva = "Black";
        /// <summary>
        /// Color de columna bloqueada.
        /// </summary>
        public const string ColorColumnaBloqueada = "Control";
        /// <summary>
        /// Color de texto de la columna bloqueada.
        /// </summary>
        public const string ColorTextoColumnaBloqueada = "Black";
        /// <summary>
        /// Color de fila nueva.
        /// </summary>
        public const string ColorFilaNueva = "Moccasin";
        /// <summary>
        /// Color de texto de fila nueva.
        /// </summary>
        public const string ColorTextoFilaNueva = "Black";
        /// <summary>
        /// Color de separador.
        /// </summary>
        public const string ColorSeparador = "BurlyWood";
        static System.Drawing.Color GridColorBorde = OProvider.GetDrawingColor(ColorBorde);
        static System.Drawing.Color GridColorFiltros = OProvider.GetDrawingColor(ColorFiltros);
        static System.Drawing.Color GridColorFondo = OProvider.GetDrawingColor(ColorFondo);
        static System.Drawing.Color GridColorFuente = OProvider.GetDrawingColor(ColorFuente);
        static System.Drawing.Color GridColorCabecera = OProvider.GetDrawingColor(ColorCabecera);
        static System.Drawing.Color GridColorEntreLinea = OProvider.GetDrawingColor(ColorEntreLinea);
        static System.Drawing.Color GridColorFila = OProvider.GetDrawingColor(ColorFila);
        static System.Drawing.Color GridColorFilaAlterna = OProvider.GetDrawingColor(ColorFilaAlterna);
        static System.Drawing.Color GridColorFilaActiva = OProvider.GetDrawingColor(ColorFilaActiva);
        static System.Drawing.Color GridColorCeldaActiva = OProvider.GetDrawingColor(ColorCeldaActiva);
        static System.Drawing.Color GridColorTextoFila = OProvider.GetDrawingColor(ColorTextoFila);
        static System.Drawing.Color GridColorTextoFilaAlterna = OProvider.GetDrawingColor(ColorTextoFilaAlterna);
        static System.Drawing.Color GridColorTextoFilaActiva = OProvider.GetDrawingColor(ColorTextoFilaActiva);
        static System.Drawing.Color GridColorTextoCeldaActiva = OProvider.GetDrawingColor(ColorTextoCeldaActiva);
        static System.Drawing.Color GridColorColumnaBloqueada = OProvider.GetDrawingColor(ColorColumnaBloqueada);
        static System.Drawing.Color GridColorTextoColumnaBloqueada = OProvider.GetDrawingColor(ColorTextoColumnaBloqueada);
        static System.Drawing.Color GridColorFilaNueva = OProvider.GetDrawingColor(ColorFilaNueva);
        static System.Drawing.Color GridColorTextoFilaNueva = OProvider.GetDrawingColor(ColorTextoFilaNueva);
        static System.Drawing.Color GridColorSeparador = OProvider.GetDrawingColor(ColorSeparador);
        #endregion

        /// <summary>
        /// Establecer la persistencia entre el control y las aplicaciones externas.
        /// </summary>
        static OPersistencia Persistencia { get; set; }

        #endregion

        #region Propiedades

        /// <summary>
        /// Color de borde.
        /// </summary>
        public static System.Drawing.Color OrbGridColorBorde
        {
            get { return OConfiguracion.GridColorBorde; }
            set { OConfiguracion.GridColorBorde = value; }
        }
        /// <summary>
        /// Color de filtros.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFiltros
        {
            get { return OConfiguracion.GridColorFiltros; }
            set { OConfiguracion.GridColorFiltros = value; }
        }
        /// <summary>
        /// Color de fondo.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFondo
        {
            get { return OConfiguracion.GridColorFondo; }
            set { OConfiguracion.GridColorFondo = value; }
        }
        /// <summary>
        /// Color de fuente.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFuente
        {
            get { return OConfiguracion.GridColorFuente; }
            set { OConfiguracion.GridColorFuente = value; }
        }
        /// <summary>
        /// Color de cabecera.
        /// </summary>
        public static System.Drawing.Color OrbGridColorCabecera
        {
            get { return OConfiguracion.GridColorCabecera; }
            set { OConfiguracion.GridColorCabecera = value; }
        }
        /// <summary>
        /// Color entre líneas.
        /// </summary>
        public static System.Drawing.Color OrbGridColorEntreLinea
        {
            get { return OConfiguracion.GridColorEntreLinea; }
            set { OConfiguracion.GridColorEntreLinea = value; }
        }
        /// <summary>
        /// Color de fila.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFila
        {
            get { return OConfiguracion.GridColorFila; }
            set { OConfiguracion.GridColorFila = value; }
        }
        /// <summary>
        /// Color de fila alterna.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFilaAlterna
        {
            get { return OConfiguracion.GridColorFilaAlterna; }
            set { OConfiguracion.GridColorFilaAlterna = value; }
        }
        /// <summary>
        /// Color de fila activa.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFilaActiva
        {
            get { return OConfiguracion.GridColorFilaActiva; }
            set { OConfiguracion.GridColorFilaActiva = value; }
        }
        /// <summary>
        /// Color de celda activa.
        /// </summary>
        public static System.Drawing.Color OrbGridColorCeldaActiva
        {
            get { return OConfiguracion.GridColorCeldaActiva; }
            set { OConfiguracion.GridColorCeldaActiva = value; }
        }
        /// <summary>
        /// Color de texto de fila.
        /// </summary>
        public static System.Drawing.Color OrbGridColorTextoFila
        {
            get { return OConfiguracion.GridColorTextoFila; }
            set { OConfiguracion.GridColorTextoFila = value; }
        }
        /// <summary>
        /// Color de texto de fila alterna.
        /// </summary>
        public static System.Drawing.Color OrbGridColorTextoFilaAlterna
        {
            get { return OConfiguracion.GridColorTextoFilaAlterna; }
            set { OConfiguracion.GridColorTextoFilaAlterna = value; }
        }
        /// <summary>
        /// Color de texto de fila activa.
        /// </summary>
        public static System.Drawing.Color OrbGridColorTextoFilaActiva
        {
            get { return OConfiguracion.GridColorTextoFilaActiva; }
            set { OConfiguracion.GridColorTextoFilaActiva = value; }
        }
        /// <summary>
        /// Color de texto de celda activa.
        /// </summary>
        public static System.Drawing.Color OrbGridColorTextoCeldaActiva
        {
            get { return OConfiguracion.GridColorTextoCeldaActiva; }
            set { OConfiguracion.GridColorTextoCeldaActiva = value; }
        }
        /// <summary>
        /// Color de columna bloqueada.
        /// </summary>
        public static System.Drawing.Color OrbGridColorColumnaBloqueada
        {
            get { return OConfiguracion.GridColorColumnaBloqueada; }
            set { OConfiguracion.GridColorColumnaBloqueada = value; }
        }
        /// <summary>
        /// Color de texto de columna bloqueada.
        /// </summary>
        public static System.Drawing.Color OrbGridColorTextoColumnaBloqueada
        {
            get { return OConfiguracion.GridColorTextoColumnaBloqueada; }
            set { OConfiguracion.GridColorTextoColumnaBloqueada = value; }
        }
        /// <summary>
        /// Color de fila nueva.
        /// </summary>
        public static System.Drawing.Color OrbGridColorFilaNueva
        {
            get { return OConfiguracion.GridColorFilaNueva; }
            set { OConfiguracion.GridColorFilaNueva = value; }
        }
        /// <summary>
        /// Color de texto de fila nueva.
        /// </summary>
        public static System.Drawing.Color OrbGridColorTextoFilaNueva
        {
            get { return OConfiguracion.GridColorTextoFilaNueva; }
            set { OConfiguracion.GridColorTextoFilaNueva = value; }
        }
        /// <summary>
        /// Color de separador.
        /// </summary>
        public static System.Drawing.Color OrbGridColorSeparador
        {
            get { return OConfiguracion.GridColorSeparador; }
            set { OConfiguracion.GridColorSeparador = value; }
        }
        /// <summary>
        /// Establecer la persistencia entre el control y las aplicaciones externas.
        /// </summary>
        public static OPersistencia OrbPersistencia
        {
            get { return OConfiguracion.Persistencia; }
            set { OConfiguracion.Persistencia = value; }
        }
        #endregion
    }
}