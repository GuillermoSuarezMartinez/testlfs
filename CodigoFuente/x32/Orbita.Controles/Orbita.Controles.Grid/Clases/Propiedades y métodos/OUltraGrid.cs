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
using System;
using System.ComponentModel;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
namespace Orbita.Controles.Grid
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OUltraGrid : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Configuración de filas.
        /// </summary>
        OFilas filas;
        /// <summary>
        /// Configuración de cabecera.
        /// </summary>
        OCabecera cabecera;
        /// <summary>
        /// Configuración de celdas.
        /// </summary>
        OCeldas celdas;
        /// <summary>
        /// Configuración de columnas.
        /// </summary>
        OColumnas columnas;
        /// <summary>
        /// Configuración de filtros.
        /// </summary>
        OFiltros filtros;
        /// <summary>
        /// Sumario de columnas.
        /// </summary>
        OSumario sumario;
        /// <summary>
        /// Indica la característica editable del control.
        /// </summary>
        protected bool editable;
        /// <summary>
        /// Determina la posibilidad de ocultar el componente del control agrupador de filas (GroupByBox).
        /// </summary>
        bool ocultarAgrupadorFilas;
        /// <summary>
        /// Determina la posibilidad de cancelar la pulsación de la tecla Return.
        /// </summary>
        bool cancelarTeclaReturn;
        ModoActualizacion modoActualizacion;
        bool mostrarTitulo;
        bool formateado = false;
        bool activarPrimeraFilaAlFormatear = true;
        #endregion

        #region Constructor
        public OUltraGrid()
            : base()
        {
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OUltraGrid.
        /// </summary>
        public OUltraGrid(object control)
            : base(control)
        {
        }
        #endregion

        #region Propiedades
        [Browsable(false)]
        public bool Formateado
        {
            get { return this.formateado; }
            set { this.formateado = value; }
        }
        [Browsable(false)]
        public object DataSource
        {
            get { return this.Control.DataSource; }
            set
            {
                if (value != null)
                {
                    System.Windows.Forms.BindingSource binding = new System.Windows.Forms.BindingSource();
                    binding.DataSource = value;
                    this.Control.DataSource = binding;
                }
            }
        }
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public bool ActivarPrimeraFilaAlFormatear
        {
            get { return this.activarPrimeraFilaAlFormatear; }
            set { this.activarPrimeraFilaAlFormatear = value; }
        }
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public bool MostrarTitulo
        {
            get { return this.mostrarTitulo; }
            set
            {
                this.mostrarTitulo = value;
                this.OnChanged(new OPropiedadEventArgs("MostrarTitulo"));
            }
        }
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public bool Editable
        {
            get { return this.editable; }
            set
            {
                this.editable = value;
                this.OnChanged(new OPropiedadEventArgs("Editable"));
            }
        }
        [System.ComponentModel.Description("Determina la posibilidad de ocultar el componente del control agrupador de filas (GroupByBox).")]
        public bool OcultarAgrupadorFilas
        {
            get { return this.ocultarAgrupadorFilas; }
            set
            {
                this.ocultarAgrupadorFilas = value;
                this.OnChanged(new OPropiedadEventArgs("OcultarAgrupadorFilas"));
            }
        }
        [System.ComponentModel.Description("Determina la posibilidad de cancelar la pulsación de la tecla Return.")]
        public bool CancelarTeclaReturn
        {
            get { return this.cancelarTeclaReturn; }
            set { this.cancelarTeclaReturn = value; }
        }
        [System.ComponentModel.Description("Determina la posibilidad de cancelar la pulsación de la tecla Return.")]
        public ModoActualizacion ModoActualizacion
        {
            get { return this.modoActualizacion; }
            set
            {
                this.modoActualizacion = value;
                this.OnChanged(new OPropiedadEventArgs("ModoActualizacion"));
            }
        }
        [System.ComponentModel.Description("Determina la apariencia de OrbitaUltraCombo.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las filas.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OFilas Filas
        {
            get
            {
                if (this.filas == null)
                {
                    this.filas = new OFilas(this.Control);
                    this.filas.PropertyChanged += new EventHandler<OPropiedadEventArgs>(FilasChanged);
                    this.filas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaFilasChanged);
                    this.filas.Activas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaFilasActivasChanged);
                    this.filas.Alternas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaFilasAlternasChanged);
                    this.filas.Nuevas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaFilasNuevasChanged);
                    this.filas.Alto = Configuracion.DefectoAlto;
                    this.filas.ConfirmarBorrado = Configuracion.DefectoConfirmarBorrado;
                    this.filas.MostrarIndicador = Configuracion.DefectoMostrarIndicador;
                    this.filas.Multiseleccion = Configuracion.DefectoMultiseleccion;
                    this.filas.PermitirBorrar = Configuracion.DefectoPermitirBorrar;
                }
                return this.filas;
            }
            set { this.filas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la cabecera.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OCabecera Cabecera
        {
            get
            {
                if (this.cabecera == null)
                {
                    this.cabecera = new OCabecera();
                    this.cabecera.PropertyChanged += new EventHandler<OPropiedadEventArgs>(CabeceraChanged);
                    this.cabecera.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaCabeceraChanged);
                    this.cabecera.Estilo = Configuracion.DefectoEstiloCabecera;
                    this.cabecera.Multilinea = Configuracion.DefectoCabeceraMultilinea;
                }
                return this.cabecera;
            }
            set { this.cabecera = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las celdas.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OCeldas Celdas
        {
            get
            {
                if (this.celdas == null)
                {
                    this.celdas = new OCeldas();
                    this.celdas.PropertyChanged += new EventHandler<OPropiedadEventArgs>(CeldasChanged);
                    this.celdas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaCeldasChanged);
                    this.celdas.TipoSeleccion = Configuracion.DefectoTipoSeleccionCelda;
                }
                return this.celdas;
            }
            set { this.celdas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las columnas.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OColumnas Columnas
        {
            get
            {
                if (this.columnas == null)
                {
                    this.columnas = new OColumnas(this.Control);
                    this.columnas.PropertyChanged += new EventHandler<OPropiedadEventArgs>(ColumnasChanged);
                    this.columnas.PermitirOrdenar = Configuracion.DefectoPermitirOrdenar;
                    this.columnas.Estilo = Configuracion.DefectoAutoAjustarEstilo;
                    this.columnas.TipoSeleccion = Configuracion.DefectoTipoSeleccionColumna;
                }
                return this.columnas;
            }
            set { this.columnas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila de filtros.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OFiltros Filtros
        {
            get
            {
                if (this.filtros == null)
                {
                    this.filtros = new OFiltros();
                    this.filtros.PropertyChanged += new EventHandler<OPropiedadEventArgs>(FiltrosChanged);
                    this.filtros.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(AparienciaFiltrosChanged);
                    this.filtros.Mostrar = Configuracion.DefectoMostrarFiltros;
                    this.filtros.Tipo = Configuracion.DefectoTipoFiltro;
                }
                return this.filtros;
            }
            set { this.filtros = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la fila de filtros.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OSumario Sumario
        {
            get
            {
                if (this.sumario == null)
                {
                    this.sumario = new OSumario();
                    this.sumario.PropertyChanged += new EventHandler<OPropiedadEventArgs>(SumarioChanged);
                    this.sumario.MostrarRecuentoFilas = Configuracion.DefectoMostrarRecuentoFilas;
                    this.sumario.Posicion = Configuracion.DefectoPosicionSumario;
                }
                return this.sumario;
            }
            set { this.sumario = value; }
        }
        #endregion

        #region Manejadores de eventos
        protected virtual void OnChanged(OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "Editable":
                        if (this.Editable)
                        {
                            this.Control.DisplayLayout.Override.AllowMultiCellOperations =
                                Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy |
                                Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut |
                                Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste |
                                Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo |
                                Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo;
                            this.Control.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                            this.Control.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                        }
                        else
                        {
                            this.Control.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy;
                            this.Control.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
                            this.Control.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                        }
                        break;
                    case "OcultarAgrupadorFilas":
                        this.Control.DisplayLayout.GroupByBox.Hidden = this.OcultarAgrupadorFilas;
                        break;
                    case "ModoActualizacion":
                        if (this.ModoActualizacion == Grid.ModoActualizacion.CambioDeCelda)
                        {
                            this.Control.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
                        }
                        else if (this.ModoActualizacion == Grid.ModoActualizacion.CambioDeCeldaOsinFoco)
                        {
                            this.Control.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
                        }
                        else if (this.ModoActualizacion == Grid.ModoActualizacion.CambioDeFila)
                        {
                            this.Control.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange;
                        }
                        else if (this.ModoActualizacion == Grid.ModoActualizacion.CambioDeFilaOsinFoco)
                        {
                            this.Control.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChangeOrLostFocus;
                        }
                        else if (this.ModoActualizacion == Grid.ModoActualizacion.AlActualizar)
                        {
                            this.Control.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnUpdate;
                        }
                        break;
                    case "MostrarTitulo":
                        this.Control.DisplayLayout.CaptionVisible = (DefaultableBoolean)Enum.Parse(typeof(DefaultableBoolean), this.MostrarTitulo.ToString(), true);
                        break;
                }
            }
        }
        protected virtual void FilasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "MostrarIndicador":
                        this.Control.DisplayLayout.Override.RowSelectors = (DefaultableBoolean)Enum.Parse(typeof(DefaultableBoolean), this.Filas.MostrarIndicador.ToString(), true);
                        break;
                    case "Multiseleccion":
                        if (this.Filas.Multiseleccion)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
                            this.Control.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard;
                        }
                        else
                        {
                            this.Control.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
                            this.Control.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Default;
                        }
                        break;
                    case "Alto":
                        int alto = this.Filas.Alto;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.Control.DisplayLayout.Bands)
                        {
                            ugb.Override.DefaultRowHeight = alto;
                        }
                        break;
                    case "PermitirBorrar":
                        this.Control.DisplayLayout.Override.AllowDelete = (DefaultableBoolean)Enum.Parse(typeof(DefaultableBoolean), this.Filas.PermitirBorrar.ToString(), true);
                        break;
                }
            }
        }
        protected virtual void CabeceraChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "Estilo":
                        this.Control.DisplayLayout.Override.HeaderStyle = (Infragistics.Win.HeaderStyle)(int)this.Cabecera.Estilo;
                        break;
                    case "Multilinea":
                        this.Control.DisplayLayout.Override.WrapHeaderText = (DefaultableBoolean)Enum.Parse(typeof(DefaultableBoolean), this.Cabecera.Multilinea.ToString(), true);
                        break;
                }
            }
        }
        protected virtual void CeldasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "TipoSeleccion":
                        if (this.celdas.TipoSeleccion == TipoSeleccion.Ninguna)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
                        }
                        else if (this.celdas.TipoSeleccion == TipoSeleccion.Simple)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        }
                        else if (this.celdas.TipoSeleccion == TipoSeleccion.SimpleAutoArrastre)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
                        }
                        else if (this.celdas.TipoSeleccion == TipoSeleccion.Extendida)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended;
                        }
                        else if (this.celdas.TipoSeleccion == TipoSeleccion.ExtendidaAutoArrastre)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
                        }
                        break;
                }
            }
        }
        protected virtual void FiltrosChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "Mostrar":
                        this.Control.DisplayLayout.Override.AllowRowFiltering = (DefaultableBoolean)Enum.Parse(typeof(DefaultableBoolean), this.Filtros.Mostrar.ToString(), true);
                        break;
                    case "Tipo":
                        if (this.Filtros.Tipo == TipoFiltro.Cabecera)
                        {
                            this.Control.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.HeaderIcons;
                        }
                        else if (this.Filtros.Tipo == TipoFiltro.Fila)
                        {
                            this.Control.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
                        }
                        break;
                }
            }
        }
        protected virtual void SumarioChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "Posicion":
                        if (this.Sumario.Posicion == AreaSumario.Abajo)
                        {
                            this.Control.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.Bottom;
                        }
                        else if (this.Sumario.Posicion == AreaSumario.AbajoFijo)
                        {
                            this.Control.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
                        }
                        else if (this.Sumario.Posicion == AreaSumario.Arriba)
                        {
                            this.Control.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.Top;
                        }
                        else if (this.Sumario.Posicion == AreaSumario.ArribaFijo)
                        {
                            this.Control.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed;
                        }
                        else if (this.Sumario.Posicion == AreaSumario.Ninguna)
                        {
                            this.Control.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.None;
                        }
                        break;
                }
            }
        }
        protected virtual void ColumnasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "PermitirOrdenar":
                        if (this.columnas.PermitirOrdenar)
                        {
                            this.Control.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
                        }
                        else
                        {
                            this.Control.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                        }
                        break;
                    case "Estilo":
                        if (this.columnas.Estilo == AutoAjustarEstilo.ExtenderUltimaColumna)
                        {
                            this.Control.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                        }
                        else if (this.columnas.Estilo == AutoAjustarEstilo.RedimensionarTodasLasColumnas)
                        {
                            this.Control.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                        }
                        else if (this.columnas.Estilo == AutoAjustarEstilo.SinAutoajusteColumnas)
                        {
                            this.Control.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                        }
                        break;

                    case "TipoSeleccion":
                        if (this.columnas.TipoSeleccion == TipoSeleccion.Ninguna)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
                        }
                        else if (this.columnas.TipoSeleccion == TipoSeleccion.Simple)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        }
                        else if (this.columnas.TipoSeleccion == TipoSeleccion.SimpleAutoArrastre)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
                        }
                        else if (this.columnas.TipoSeleccion == TipoSeleccion.Extendida)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Extended;
                        }
                        else if (this.columnas.TipoSeleccion == TipoSeleccion.ExtendidaAutoArrastre)
                        {
                            this.Control.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
                        }
                        break;
                }
            }
        }
        protected override void AparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Appearance.BackColor = this.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Appearance.BorderColor = this.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Appearance.ForeColor = this.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Appearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Appearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Appearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.Apariencia.AdornoTexto;
            //this.Control.DisplayLayout.BorderStyle = (Infragistics.Win.UIElementBorderStyle)(int)this.Apariencia.EstiloBorde;
        }
        protected virtual void AparienciaCeldasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.CellAppearance.BackColor = this.celdas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.CellAppearance.BorderColor = this.celdas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.CellAppearance.ForeColor = this.celdas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.CellAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.celdas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.CellAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.celdas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.CellAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.celdas.Apariencia.AdornoTexto;
            //this.Control.DisplayLayout.Override.BorderStyleCell = (Infragistics.Win.UIElementBorderStyle)(int)this.celdas.Apariencia.EstiloBorde;
        }
        protected virtual void AparienciaCabeceraChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.HeaderAppearance.BackColor = this.cabecera.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.HeaderAppearance.BorderColor = this.cabecera.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.HeaderAppearance.ForeColor = this.cabecera.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.HeaderAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.cabecera.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.HeaderAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.cabecera.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.HeaderAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.cabecera.Apariencia.AdornoTexto;
            //this.Control.DisplayLayout.Override.BorderStyleHeader = (Infragistics.Win.UIElementBorderStyle)(int)this.cabecera.Apariencia.EstiloBorde;
        }
        protected virtual void AparienciaFilasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.RowAppearance.BackColor = this.filas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.RowAppearance.BorderColor = this.filas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.RowAppearance.ForeColor = this.filas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.RowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.RowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.RowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Apariencia.AdornoTexto;
            // this.Control.DisplayLayout.Override.BorderStyleRow = (Infragistics.Win.UIElementBorderStyle)(int)this.filas.Apariencia.EstiloBorde;
        }
        protected virtual void AparienciaFilasActivasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.ActiveRowAppearance.BackColor = this.filas.Activas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.ActiveRowAppearance.BorderColor = this.filas.Activas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.ActiveRowAppearance.ForeColor = this.filas.Activas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.ActiveRowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.ActiveRowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.ActiveRowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Activas.Apariencia.AdornoTexto;
        }
        protected virtual void AparienciaFilasAlternasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.RowAlternateAppearance.BackColor = this.filas.Alternas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.BorderColor = this.filas.Alternas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.ForeColor = this.filas.Alternas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Alternas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Alternas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Alternas.Apariencia.AdornoTexto;
        }
        protected virtual void AparienciaFilasNuevasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.TemplateAddRowAppearance.BackColor = this.filas.Activas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.TemplateAddRowAppearance.BorderColor = this.filas.Activas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.TemplateAddRowAppearance.ForeColor = this.filas.Activas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.TemplateAddRowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.TemplateAddRowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.TemplateAddRowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Activas.Apariencia.AdornoTexto;

        }
        protected virtual void AparienciaFiltrosChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.FilterCellAppearance.BackColor = this.filas.Activas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.FilterCellAppearance.BorderColor = this.filas.Activas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.FilterCellAppearance.ForeColor = this.filas.Activas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.FilterCellAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.FilterCellAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.FilterCellAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Activas.Apariencia.AdornoTexto;

        }
        #endregion

        #region Métodos públicos
        public void Formatear(System.Data.DataTable dt)
        {
            this.formateado = true;
            this.Formatear(dt, null);
        }
        public void Formatear(System.Data.DataTable dt, System.Collections.ArrayList columnas)
        {
            // Guardar la lista de columnas.
            this.Columnas.Visibles = columnas;
            // Asignar DataSource del Grid.
            this.DataSource = dt;
            // Comprobar el formateo previo, o la carga de la colección de plantillas.
            // La única posición donde se modifica este atributo a False (no formateado)
            if (!this.formateado)
            {
                // Formatear columnas.
                // this.columnaBloqueadas = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.Control.DisplayLayout.Bands)
                {
                    // Eliminar los sumarios si existen.
                    if (banda.Summaries.Count > 0)
                    {
                        banda.Summaries.Clear();
                    }
                    // Ocultar todas las columnas de cada una de las bandas.
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in banda.Columns)
                    {
                        ugc.Hidden = true;
                    }
                    if (columnas != null)
                    {
                        // Definir estilos de columnas.
                        foreach (OEstiloColumna columna in columnas)
                        {
                            if (banda.Columns.Exists(columna.Campo))
                            {
                                // Asignar estilos a las columnas.
                                AsignarEstiloColumna(banda, columna, columnas.IndexOf(columna));
                                // Asignar máscaras a las columnas.
                                AsignarMascaraColumna(banda, columna);
                                // Asignar sumario a las columnas.
                                AsignarSumarioColumna(banda, columna);
                                // Bloquear o no el acceso a la columna.
                                // Asignar estilo (bloqueado) a la columna bloqueada y la celda de filtro.
                                AsignarEstiloColumnaBloqueada(banda, columna);
                            }
                        }
                        // Llamar al método para mostrar el recuento de filas. Resumen del recuento.
                        if (this.Sumario.MostrarRecuentoFilas)
                        {
                            if (dt != null && dt.Rows.Count > 0 && columnas.Count > 0)
                            {
                                AsignarSumarioRecuento(banda, (columnas[0] as OEstiloColumna));
                            }
                        }
                    }
                }
                // Una vez formateado, modificar el atributo.
                this.formateado = true;
            }
            if (this.ActivarPrimeraFilaAlFormatear)
            {
                // Seleccionar y activar la primera fila (ActiveRow).
                this.Filas.Activar(1);
            }
        }
        public void Limpiar()
        {
            if (this.DataSource != null)
            {
                if (this.Control.Rows.Count > 0)
                {
                    if (this.DataSource.GetType() == typeof(System.Data.DataTable))
                    {
                        ((System.Data.DataTable)this.DataSource).Rows.Clear();
                    }
                    else
                    {
                        if (this.DataSource.GetType() == typeof(System.Data.DataSet))
                        {
                            ((System.Data.DataSet)this.DataSource).Tables[0].Rows.Clear();
                        }
                    }
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetActivarPrimeraFilaAlFormatear()
        {
            this.ActivarPrimeraFilaAlFormatear = true;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarTitulo()
        {
            this.MostrarTitulo = Configuracion.DefectoMostrarTitulo;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEditable()
        {
            this.Editable = Configuracion.DefectoEditable;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetOcultarAgrupadorFilas()
        {
            this.OcultarAgrupadorFilas = Configuracion.DefectoOcultarAgrupadorFilas;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetCancelarTeclaReturn()
        {
            this.CancelarTeclaReturn = Configuracion.DefectoCancelarTeclaReturn;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetModoActualizacion()
        {
            this.ModoActualizacion = Configuracion.DefectoModoActualizacion;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEditable()
        {
            return (this.Editable != Configuracion.DefectoEditable);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeOcultarAgrupadorFilas()
        {
            return (this.OcultarAgrupadorFilas != Configuracion.DefectoOcultarAgrupadorFilas);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeCancelarTeclaReturn()
        {
            return (this.CancelarTeclaReturn != Configuracion.DefectoCancelarTeclaReturn);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeModoActualizacion()
        {
            return (this.ModoActualizacion != Configuracion.DefectoModoActualizacion);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarTitulo()
        {
            return (this.MostrarTitulo != Configuracion.DefectoMostrarTitulo);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeActivarPrimeraFilaAlFormatear()
        {
            return (this.ActivarPrimeraFilaAlFormatear != true);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeFormateado()
        {
            return (this.Formateado != false);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeDataSource()
        {
            return (this.DataSource != null);
        }
        #endregion

        #region Métodos privados
        static void AsignarEstiloColumna(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna, int posicionColumna)
        {
            OColumnas.AsignarEstilo(banda, columna, posicionColumna);
        }
        void AsignarEstiloColumnaBloqueada(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            this.Columnas.Bloqueadas.AsignarEstilo(banda, columna);
        }
        static void AsignarMascaraColumna(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            OColumnas.AsignarMascara(banda, columna);
        }
        static void AsignarSumarioColumna(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            OColumnas.AsignarSumario(banda, columna);
        }
        static void AsignarSumarioRecuento(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            OColumnas.AsignarSumarioRecuento(banda, columna);
        }
        #endregion
    }
}

