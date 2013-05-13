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
using System.Linq;
namespace Orbita.Controles.Grid
{
    public partial class OrbitaUltraGridToolBar : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OUltraGridToolBar
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OrbitaUltraGridToolBar.ControlNuevaDefinicion.
            /// </summary>
            /// <param name="sender">Representa un control para mostrar una lista de elementos.</param>
            public ControlNuevaDefinicion(OrbitaUltraGridToolBar sender)
                : base(sender) { }
            #endregion
        }
        #endregion Nueva definición

        #region Atributos privados
        System.Resources.ResourceManager stringManager;
        ControlNuevaDefinicion definicion;
        FrmBuscar frmBuscar;
        Infragistics.Win.UltraWinGrid.UltraGridRow fila = null;
        object customNodoSeleccionado = null;
        OTimerEventArgs ciclo;

        #region Atributos privados Toolbar
        ToolGestionarClickEventHandler onToolGestionarClick;
        ToolVerClickEventHandler onToolVerClick;
        ToolModificarClickEventHandler onToolModificarClick;
        ToolAñadirClickEventHandler onToolAñadirClick;
        ToolEliminarClickEventHandler onToolEliminarClick;
        ToolExportarClickEventHandler onToolExportarClick;
        ToolImprimirClickEventHandler onToolImprimirClick;
        ToolRefrescarClickEventHandler onToolRefrescarClick;
        ToolCiclicoClickEventHandler onToolCiclicoClick;
        ToolEditarBeforeToolDropDownEventHandler onToolEditarBeforeToolDropDown;
        ToolEstiloBeforeToolDropDownEventHandler onToolEstiloBeforeToolDropDown;
        #endregion Atributos privados Toolbar

        #endregion Atributos privados

        #region Atributos internos
        internal OCollectionEventHandler eventos;
        #endregion Atributos internos

        #region Delegados
        public delegate void ToolGestionarClickEventHandler(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        public delegate void ToolVerClickEventHandler(object sender, OToolClickEventArgs e);
        public delegate void ToolModificarClickEventHandler(object sender, OToolClickEventArgs e);
        public delegate void ToolAñadirClickEventHandler(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        public delegate void ToolEliminarClickEventHandler(object sender, OToolClickCollectionEventArgs e);
        public delegate void ToolExportarClickEventHandler(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        public delegate void ToolImprimirClickEventHandler(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        public delegate void ToolRefrescarClickEventHandler(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        public delegate void ToolCiclicoClickEventHandler(object sender, OTimerEventArgs e);
        public delegate void ToolEditarBeforeToolDropDownEventHandler(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e);
        public delegate void ToolEstiloBeforeToolDropDownEventHandler(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e);
        #endregion Delegados

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OrbitaUltraGridToolBar.
        /// </summary>
        public OrbitaUltraGridToolBar()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
            InitializeEvents();
            InitializeEventsToolbar();
        }
        #endregion Constructor

        #region Propiedades
        [System.ComponentModel.Description("El control interno OrbitaUltraToolBarsManager.")]
        [System.ComponentModel.Category("Controles internos")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public Orbita.Controles.Menu.OrbitaUltraToolbarsManager Toolbar
        {
            get { return this.toolbar; }
        }
        [System.ComponentModel.Description("El control interno OrbitaUltraGrid.")]
        [System.ComponentModel.Category("Controles internos")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public OrbitaUltraGrid Grid
        {
            get { return this.grid; }
        }
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion Propiedades

        #region Métodos privados

        #region Initialize
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
            //this.stringManager = new System.Resources.ResourceManager("es-ES", System.Reflection.Assembly.GetExecutingAssembly());
            this.eventos = new OCollectionEventHandler();
        }
        void InitializeProperties()
        {
            this.OI.Editable = Configuracion.DefectoEditable;
            this.OI.OcultarAgrupadorFilas = Configuracion.DefectoOcultarAgrupadorFilas;
            this.OI.CancelarTeclaReturn = Configuracion.DefectoCancelarTeclaReturn;
            this.OI.ModoActualizacion = Configuracion.DefectoModoActualizacion;
            this.OI.MostrarTitulo = Configuracion.DefectoMostrarTitulo;
            this.OI.MostrarToolGestionar = Configuracion.DefectoMostrarToolGestionar;
            this.OI.MostrarToolVer = Configuracion.DefectoMostrarToolVer;
            this.OI.MostrarToolModificar = Configuracion.DefectoMostrarToolModificar;
            this.OI.MostrarToolAñadir = Configuracion.DefectoMostrarToolAñadir;
            this.OI.MostrarToolEliminar = Configuracion.DefectoMostrarToolEliminar;
            this.OI.MostrarToolLimpiarFiltros = Configuracion.DefectoMostrarFiltros;
            this.OI.MostrarToolEditar = Configuracion.DefectoMostrarToolEditar;
            this.OI.MostrarToolExportar = Configuracion.DefectoMostrarToolExportar;
            this.OI.MostrarToolImprimir = Configuracion.DefectoMostrarToolImprimir;
            this.OI.MostrarToolEstilo = Configuracion.DefectoMostrarToolEstilo;
            this.OI.MostrarToolRefrescar = Configuracion.DefectoMostrarToolRefrescar;
            this.OI.MostrarToolCiclico = Configuracion.DefectoMostrarToolCiclico;
        }
        void InitializeEvents()
        {
            this.definicion.PropertyChanged += new System.EventHandler<OPropertyExtendedChangedEventArgs>(ControlChanged);
            this.definicion.Filas.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(FilasChanged);
        }
        void InitializeEventsToolbar()
        {
            foreach (var item in this.toolbar.Toolbars)
            {
                foreach (Infragistics.Win.UltraWinToolbars.ToolBase tool in this.toolbar.Toolbars[item.Index].Tools)
                {
                    if (tool is Infragistics.Win.UltraWinToolbars.PopupMenuTool)
                    {
                        this.ToolbarAsignarEventoPorReflexion(tool, "BeforeToolDropdown", "_BeforeToolDropdown");
                        this.InitializeEventsToolbar((Infragistics.Win.UltraWinToolbars.PopupMenuTool)tool);
                    }
                    else if (tool is Infragistics.Win.UltraWinToolbars.ButtonTool)
                    {
                        this.ToolbarAsignarEventoPorReflexion(tool, "ToolClick", "_Click");
                    }
                }
            }
        }
        void InitializeEventsToolbar(Infragistics.Win.UltraWinToolbars.PopupMenuTool toolPopup)
        {
            foreach (Infragistics.Win.UltraWinToolbars.ToolBase tool in toolPopup.Tools)
            {
                if (tool is Infragistics.Win.UltraWinToolbars.PopupMenuTool)
                {
                    this.ToolbarAsignarEventoPorReflexion(tool, "BeforeToolDropdown", "_BeforeToolDropdown");
                    this.InitializeEventsToolbar((Infragistics.Win.UltraWinToolbars.PopupMenuTool)tool);
                }
                else if (tool is Infragistics.Win.UltraWinToolbars.ButtonTool)
                {
                    this.ToolbarAsignarEventoPorReflexion(tool, "ToolClick", "_Click");
                }
            }
        }
        #endregion Initialize

        #region Toolbar
        void ToolbarAsignarEventoPorReflexion(Infragistics.Win.UltraWinToolbars.ToolBase tool, string evento, string metodo)
        {
            System.Reflection.EventInfo infoEvento = typeof(Infragistics.Win.UltraWinToolbars.ToolBase).GetEvent(evento);
            System.Reflection.MethodInfo infoMetodo = typeof(OrbitaUltraGridToolBar).GetMethod(tool.Key + metodo, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (infoMetodo != null)
            {
                System.Delegate handler = System.Delegate.CreateDelegate(infoEvento.EventHandlerType, this, infoMetodo);
                infoEvento.AddEventHandler(tool, handler);
            }
        }
        bool ToolbarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction action)
        {
            return this.grid.KeyActionMappings.IsActionAllowed(action, (long)this.grid.CurrentState);
        }
        void ToolbarToolEditarDeshacer()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Undo);
        }
        void ToolbarToolEditarRehacer()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Redo);
        }
        void ToolbarToolEditarCortar()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Cut);
        }
        void ToolbarToolEditarCopiar()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
        }
        void ToolbarToolEditarPegar()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
        }
        void ToolbarToolEditarPrimero()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand);
        }
        void ToolbarToolEditarAnterior()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevRow);
        }
        void ToolbarToolEditarSiguiente()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
        }
        void ToolbarToolEditarUltimo()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInBand);
        }
        void ToolbarToolEditarSeleccionarTodo()
        {
            this.grid.Selected.Rows.AddRange((Infragistics.Win.UltraWinGrid.UltraGridRow[])this.grid.Rows.All);
        }
        void ToolbarToolEditarDeseleccionarTodo()
        {
            this.grid.Selected.Rows.Clear();
        }
        void ToolbarToolEditarBuscar()
        {
            if (this.frmBuscar == null)
            {
                frmBuscar = new FrmBuscar(this);
            }
            frmBuscar.ShowDialog();
        }
        void ToolbarToolLimpiarFiltros()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.grid.DisplayLayout.Bands)
            {
                banda.ColumnFilters.ClearAllFilters();
            }
        }
        void ToolbarToolExportar()
        {
            using (System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveDialog.Filter = "Archivo de Excel (*.xls)|*.xls|Todos los ficheros (*.*)|*.*";
                saveDialog.DefaultExt = "xls";
                saveDialog.FileName = "Informe (fecha " + System.DateTime.Now.ToString("yyyy-MM-dd)", System.Globalization.CultureInfo.CurrentCulture) + " (hora " + System.DateTime.Now.ToString("HH-mm-ss)", System.Globalization.CultureInfo.CurrentCulture);
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(saveDialog.FileName))
                {
                    Infragistics.Documents.Excel.Workbook excelWorkbook = new Infragistics.Documents.Excel.Workbook();
                    Infragistics.Documents.Excel.Worksheet excelWorksheet = excelWorkbook.Worksheets.Add("Exportado por Órbita Ingeniería");

                    excelWorksheet.Rows[1].Cells[4].CellFormat.Font.Height = 400;
                    excelWorksheet.Rows[1].Cells[4].CellFormat.Font.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                    excelWorksheet.Rows[1].Cells[4].Value = "Informe";
                    excelWorksheet.Rows[3].Cells[2].CellFormat.Font.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                    excelWorksheet.Rows[3].Cells[2].Value = "Informe elaborado el " + System.DateTime.Now.ToString();

                    this.excel.Export(this.grid, excelWorksheet, 5, 2);
                    excelWorkbook.Save(saveDialog.FileName);

                    System.Diagnostics.ProcessStartInfo psiExcel = new System.Diagnostics.ProcessStartInfo(saveDialog.FileName);
                    System.Diagnostics.Process.Start(psiExcel);

                    excelWorkbook = null;
                    excelWorksheet = null;
                }
            }
        }
        void ToolbarToolImprimir()
        {
            if (this.OI.DataSource != null)
            {
                this.imprimir.Grid = this.grid;
                this.preview.Document = imprimir;
                this.preview.Document.DefaultPageSettings.Landscape = true;
                this.preview.ShowDialog();
            }
        }
        void ToolbarToolIrPrimero()
        {
            this.ToolbarToolIrAnterior(0, true);
        }
        void ToolbarToolIrAnterior()
        {
            this.ToolbarToolIrAnterior(1, false);
        }
        void ToolbarToolIrAnterior(int x, bool principio)
        {
            if (string.IsNullOrEmpty(this.OI.CampoPosicionable))
            {
                return;
            }
            this.grid.SuspendLayout();
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.grid.DisplayLayout.Bands)
                {
                    bool añadirColumnaOrdenada = false;
                    if (!banda.SortedColumns.Exists(this.OI.CampoPosicionable))
                    {
                        banda.SortedColumns.Clear();
                        añadirColumnaOrdenada = true;
                    }
                    if (banda.Columns.Exists(this.OI.CampoPosicionable))
                    {
                        if (añadirColumnaOrdenada)
                        {
                            banda.SortedColumns.Add(banda.Columns[this.OI.CampoPosicionable], false);
                            this.OI.Columnas.PermitirOrdenar = true;
                        }
                        Infragistics.Win.UltraWinGrid.UltraGridRow filaActiva = this.grid.ActiveRow;
                        int contador = 0;
                        bool fin = false;
                        while (!fin && (contador < x || principio))
                        {
                            contador++;
                            if (filaActiva != null &&
                                filaActiva.IsDataRow &&
                               !filaActiva.IsFilteredOut &&
                               !filaActiva.IsAddRow &&
                              !(this.OI.Filtros.Mostrar && filaActiva.VisibleIndex == 1) &&
                                filaActiva.Cells[this.OI.CampoPosicionable].Value != null)
                            {
                                int ordenFila;
                                if (int.TryParse(filaActiva.Cells[this.OI.CampoPosicionable].Value.ToString(), out ordenFila))
                                {
                                    int indiceMayor = filaActiva.VisibleIndex;
                                    int ajusteFilas = 0;
                                    if (this.OI.Filtros.Mostrar)
                                    {
                                        ajusteFilas = 1;
                                    }
                                    if (indiceMayor > ajusteFilas)
                                    {
                                        Infragistics.Win.UltraWinGrid.UltraGridRow fila = this.grid.Rows.GetRowAtVisibleIndex(indiceMayor - 1);
                                        if (fila != null)
                                        {
                                            fila.Cells[this.OI.CampoPosicionable].Value = ordenFila;
                                            fila.Update();
                                            filaActiva.Cells[this.OI.CampoPosicionable].Value = ordenFila - 1;
                                            filaActiva.Update();
                                            filaActiva.RefreshSortPosition();
                                            this.grid.UpdateData();
                                        }
                                    }
                                    else
                                    {
                                        fin = true;
                                    }
                                }
                                else
                                {
                                    fin = true;
                                }
                            }
                            else
                            {
                                fin = true;
                            }
                        }
                        if (contador > 0)
                        {
                            this.grid.ActiveRowScrollRegion.ScrollRowIntoView(filaActiva);
                        }
                    }
                    else
                    {
                        this.OI.Columnas.PermitirOrdenar = false;
                    }
                }
            }
            finally
            {
                this.grid.ResumeLayout();
            }
        }
        void ToolbarToolIrSiguiente()
        {
            this.ToolbarToolIrSiguiente(1, false);
        }
        void ToolbarToolIrSiguiente(int x, bool final)
        {
            if (string.IsNullOrEmpty(this.OI.CampoPosicionable))
            {
                return;
            }
            this.grid.SuspendLayout();
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.grid.DisplayLayout.Bands)
                {
                    bool añadirColumnaOrdenada = false;
                    if (!banda.SortedColumns.Exists(this.OI.CampoPosicionable))
                    {
                        banda.SortedColumns.Clear();
                        añadirColumnaOrdenada = true;
                    }
                    if (banda.Columns.Exists(this.OI.CampoPosicionable))
                    {
                        if (añadirColumnaOrdenada)
                        {
                            banda.SortedColumns.Add(banda.Columns[this.OI.CampoPosicionable], false);
                            this.OI.Columnas.PermitirOrdenar = true;
                        }
                        Infragistics.Win.UltraWinGrid.UltraGridRow filaActiva = this.grid.ActiveRow;
                        int contador = 0;
                        bool fin = false;
                        while (!fin && (contador < x || final))
                        {
                            contador++;
                            if (filaActiva != null &&
                                filaActiva.IsDataRow &&
                               !filaActiva.IsFilteredOut &&
                               !filaActiva.IsAddRow &&
                                filaActiva.Cells[this.OI.CampoPosicionable].Value != null)
                            {
                                int ordenFila;
                                if (int.TryParse(filaActiva.Cells[this.OI.CampoPosicionable].Value.ToString(), out ordenFila))
                                {
                                    int indiceMayor = filaActiva.VisibleIndex;
                                    int ajusteFilas = 0;
                                    if (!this.OI.Filtros.Mostrar)
                                    {
                                        ajusteFilas = 1;
                                    }
                                    if (indiceMayor < this.grid.Rows.Count - ajusteFilas)
                                    {
                                        Infragistics.Win.UltraWinGrid.UltraGridRow fila = this.grid.Rows.GetRowAtVisibleIndex(indiceMayor + 1);
                                        if (fila != null)
                                        {
                                            fila.Cells[this.OI.CampoPosicionable].Value = ordenFila;
                                            fila.Update();
                                            filaActiva.Cells[this.OI.CampoPosicionable].Value = ordenFila + 1;
                                            filaActiva.Update();
                                            filaActiva.RefreshSortPosition();
                                            filaActiva.Activate();
                                            this.grid.UpdateData();
                                        }
                                    }
                                    else
                                    {
                                        fin = true;
                                    }
                                }
                                else
                                {
                                    fin = true;
                                }
                            }
                            else
                            {
                                fin = true;
                            }
                        }
                        if (contador > 0)
                        {
                            this.grid.ActiveRowScrollRegion.ScrollRowIntoView(filaActiva);
                        }
                    }
                    else
                    {
                        this.OI.Columnas.PermitirOrdenar = false;
                    }
                }
            }
            finally
            {
                this.grid.ResumeLayout();
            }
        }
        void ToolbarToolIrUltimo()
        {
            this.ToolbarToolIrSiguiente(0, true);
        }
        void ToolbarActualizarEstadoToolPrincipal(bool estado)
        {
            this.toolbar.Tools["Ver"].SharedProps.Enabled = estado;
            this.toolbar.Tools["Modificar"].SharedProps.Enabled = estado;
            this.toolbar.Tools["Eliminar"].SharedProps.Enabled = estado;
        }
        void ToolbarActualizarEstadoToolNavegacion(bool estado)
        {
            if (!string.IsNullOrEmpty(this.OI.CampoPosicionable))
            {
                this.toolbar.Tools["IrPrimero"].SharedProps.Enabled = estado;
                this.toolbar.Tools["IrAnterior"].SharedProps.Enabled = estado;
                this.toolbar.Tools["IrSiguiente"].SharedProps.Enabled = estado;
                this.toolbar.Tools["IrUltimo"].SharedProps.Enabled = estado;
                this.toolbar.Tools["IrAposicion"].SharedProps.Enabled = estado;
            }
        }
        void ToolbarActualizarEstadoToolEditar()
        {
            this.toolbar.Tools["Deshacer"].SharedProps.Enabled = this.ToolbarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Undo);
            this.toolbar.Tools["Rehacer"].SharedProps.Enabled = this.ToolbarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Redo);
            this.toolbar.Tools["Cortar"].SharedProps.Enabled = this.ToolbarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Cut);
            this.toolbar.Tools["Copiar"].SharedProps.Enabled = this.ToolbarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            this.toolbar.Tools["Pegar"].SharedProps.Enabled = this.ToolbarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
        }
        void ToolbarActualizarEstadoTodosToolEditar()
        {
            this.grid.DisplayLayout.Override.AllowMultiCellOperations =
                             Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy |
                             Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut |
                             Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste |
                             Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo |
                             Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo;
        }
        void ToolbarActualizarEstadoCopiarToolEditar()
        {
            this.grid.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy;
        }
        void ToolbarToolPersonalizar()
        {
            using (FrmPersonalizar form = new FrmPersonalizar(customNodoSeleccionado))
            {
                form.IndiceSeleccionado += new System.EventHandler<System.EventArgs>(IndiceSeleccionado_Change);
                FrmPersonalizar.Grid = this.grid;
                form.ShowDialog();
            }
        }
        #endregion Toolbar

        #endregion Métodos privados

        #region Manejadores de eventos

        #region Eventos Toolbar

        #region Toolbar Base
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        public event Infragistics.Win.UltraWinToolbars.ToolClickEventHandler ToolClick
        {
            add
            {
                this.Toolbar.ToolClick += value;
                OEventHandler handler = new OEventHandler("ToolClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.Toolbar.ToolClick -= value;
                this.eventos.Remove("ToolClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Gestionar.")]
        public event ToolGestionarClickEventHandler ToolGestionarClick
        {
            add
            {
                this.onToolGestionarClick += value;
                OEventHandler handler = new OEventHandler("ToolGestionarClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolGestionarClick -= value;
                this.eventos.Remove("ToolGestionarClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Ver.")]
        public event ToolVerClickEventHandler ToolVerClick
        {
            add
            {
                this.onToolVerClick += value;
                OEventHandler handler = new OEventHandler("ToolVerClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolVerClick -= value;
                this.eventos.Remove("ToolVerClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Modificar.")]
        public event ToolModificarClickEventHandler ToolModificarClick
        {
            add
            {
                this.onToolModificarClick += value;
                OEventHandler handler = new OEventHandler("ToolModificarClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolModificarClick -= value;
                this.eventos.Remove("ToolModificarClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Añadir.")]
        public event ToolAñadirClickEventHandler ToolAñadirClick
        {
            add
            {
                this.onToolAñadirClick += value;
                OEventHandler handler = new OEventHandler("ToolAñadirClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolAñadirClick -= value;
                this.eventos.Remove("ToolAñadirClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Eliminar.")]
        public event ToolEliminarClickEventHandler ToolEliminarClick
        {
            add
            {
                this.onToolEliminarClick += value;
                OEventHandler handler = new OEventHandler("ToolEliminarClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolEliminarClick -= value;
                this.eventos.Remove("ToolEliminarClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Exportar.")]
        public event ToolExportarClickEventHandler ToolExportarClick
        {
            add
            {
                this.onToolExportarClick += value;
                OEventHandler handler = new OEventHandler("ToolExportarClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolExportarClick -= value;
                this.eventos.Remove("ToolExportarClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Imprimir.")]
        public event ToolImprimirClickEventHandler ToolImprimirClick
        {
            add
            {
                this.onToolImprimirClick += value;
                OEventHandler handler = new OEventHandler("ToolImprimirClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolImprimirClick -= value;
                this.eventos.Remove("ToolImprimirClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Refrescar.")]
        public event ToolRefrescarClickEventHandler ToolRefrescarClick
        {
            add
            {
                this.onToolRefrescarClick += value;
                OEventHandler handler = new OEventHandler("ToolRefrescarClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolRefrescarClick -= value;
                this.eventos.Remove("ToolRefrescarClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Refrescar cíclico.")]
        public event ToolCiclicoClickEventHandler ToolCiclicoClick
        {
            add
            {
                this.onToolCiclicoClick += value;
                OEventHandler handler = new OEventHandler("ToolCiclicoClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolCiclicoClick -= value;
                this.eventos.Remove("ToolCiclicoClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Editar.")]
        public event ToolEditarBeforeToolDropDownEventHandler ToolEditarBeforeToolDropDown
        {
            add
            {
                this.onToolEditarBeforeToolDropDown += value;
                OEventHandler handler = new OEventHandler("ToolEditarBeforeToolDropDown", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolEditarBeforeToolDropDown -= value;
                this.eventos.Remove("ToolEditarBeforeToolDropDown");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Estilo.")]
        public event ToolEstiloBeforeToolDropDownEventHandler ToolEstiloBeforeToolDropDown
        {
            add
            {
                this.onToolEstiloBeforeToolDropDown += value;
                OEventHandler handler = new OEventHandler("ToolEstiloBeforeToolDropDown", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.onToolEstiloBeforeToolDropDown -= value;
                this.eventos.Remove("ToolEstiloBeforeToolDropDown");
            }
        }
        #endregion Toolbar Base

        #region Toolbar Principal
        protected void Gestionar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (this.onToolGestionarClick != null)
                {
                    this.onToolGestionarClick(this, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Ver_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow filaActiva = this.grid.ActiveRow;
                if (!filaActiva.IsDataRow)
                {
                    return;
                }
                if (this.onToolVerClick != null)
                {
                    OToolClickEventArgs nuevoEventArgs = new OToolClickEventArgs(e.Tool, e.ListToolItem);
                    nuevoEventArgs.Fila = filaActiva;
                    this.onToolVerClick(this, nuevoEventArgs);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Modificar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow filaActiva = this.grid.ActiveRow;
                if (!filaActiva.IsDataRow)
                {
                    return;
                }
                if (this.onToolModificarClick != null)
                {
                    OToolClickEventArgs nuevoEventArgs = new OToolClickEventArgs(e.Tool, e.ListToolItem);
                    nuevoEventArgs.Fila = filaActiva;
                    this.onToolModificarClick(this, nuevoEventArgs);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Añadir_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (this.onToolAñadirClick != null)
                {
                    this.onToolAñadirClick(this, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Eliminar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                // Colección de filas que se van a eliminar y que se va a pasar como argumento del evento.
                System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> lista = null;
                // Recorrer la colección de filas seleccionadas, que es diferente a la fila activa.
                // Filas seleccionadas = Selected.Rows.
                // Fila activa = ActiveRow.
                if (this.grid.Selected.Rows.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow fila in this.grid.Selected.Rows)
                    {
                        if (fila.IsDataRow)
                        {
                            if (lista == null)
                            {
                                lista = new System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
                            }
                            if (!lista.Contains(fila))
                            {
                                lista.Add(fila);
                            }
                        }
                    }
                }
                // Añadir a la colección la fila activa.
                Infragistics.Win.UltraWinGrid.UltraGridRow filaActiva = this.grid.ActiveRow;
                if (filaActiva != null)
                {
                    if (fila.IsDataRow)
                    {
                        if (lista == null)
                        {
                            lista = new System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow>();
                        }
                        if (!lista.Contains(filaActiva))
                        {
                            lista.Add(filaActiva);
                        }
                    }
                }
                if (lista != null)
                {
                    // En función de las opciones de seleccionar y a partir del delegado dinámico se va a crear
                    // el objeto con la llamada al método eliminar adecuado según el caso.
                    if (this.grid.Selected.Rows.Count > 0 && this.grid.Selected.Rows.Count < lista.Count)
                    {
                        // Se ha seleccionado filas múltiples y deseleccionado la fila activa.
                        this.definicion.Filas.TipoSeleccion = new OFilas.TipoSeleccionFila(this.definicion.Filas.Eliminar);
                    }
                    else if (this.grid.Selected.Rows.Count > 0 && this.grid.Selected.Rows.Count == lista.Count)
                    {
                        // Se ha seleccionado filas múltiples y la fila activa.
                        this.definicion.Filas.TipoSeleccion = new OFilas.TipoSeleccionFila(this.definicion.Filas.Seleccionadas.Eliminar);
                    }
                    else if (this.grid.Selected.Rows.Count == 0 && this.grid.ActiveRow != null)
                    {
                        // No existe multiselección.
                        this.definicion.Filas.TipoSeleccion = new OFilas.TipoSeleccionFila(this.definicion.Filas.Activas.Eliminar);
                    }
                    if (this.definicion.Filas.TipoSeleccion())
                    {
                        if (this.onToolEliminarClick != null)
                        {
                            OToolClickCollectionEventArgs nuevoEventArgs = new OToolClickCollectionEventArgs(e.Tool, e.ListToolItem);
                            nuevoEventArgs.Filas = lista.ToArray();
                            this.onToolEliminarClick(this, nuevoEventArgs);
                        }
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void LimpiarFiltros_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolLimpiarFiltros();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Exportar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (this.onToolExportarClick != null)
                {
                    this.onToolExportarClick(this, e);
                }
                else
                {
                    this.ToolbarToolExportar();
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Imprimir_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (this.onToolImprimirClick != null)
                {
                    this.onToolImprimirClick(this, e);
                }
                else
                {
                    this.ToolbarToolImprimir();
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Refrescar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (this.onToolRefrescarClick != null)
                {
                    this.onToolRefrescarClick(this, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Ciclico_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                if (this.onToolCiclicoClick != null)
                {
                    bool activo = (e.Tool as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked;
                    if (activo)
                    {
                        Infragistics.Win.UltraWinToolbars.ControlContainerTool tool = this.Toolbar.Tools["PeriodoCiclico"] as Infragistics.Win.UltraWinToolbars.ControlContainerTool;
                        Orbita.Controles.Comunes.OrbitaUltraNumericEditor periodo = tool.Control as Orbita.Controles.Comunes.OrbitaUltraNumericEditor;
                        object valor = string.IsNullOrEmpty(periodo.Value.ToString()) ? periodo.NullText : periodo.Value;
                        ciclo = new OTimerEventArgs((int)valor);
                        timer.Interval = ciclo.Intervalo * 1000;
                    }
                    timer.Enabled = activo;
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Deshacer_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarDeshacer();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Rehacer_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarRehacer();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Cortar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarCortar();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Copiar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarCopiar();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Pegar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarPegar();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Primero_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.grid.SuspendLayout();
            try
            {
                this.ToolbarToolEditarPrimero();
                if (this.OI.Filtros.Mostrar)
                {
                    this.ToolbarToolEditarSiguiente();
                }
            }
            catch (System.Exception)
            {
            }
            finally
            {
                this.grid.ResumeLayout();
            }
        }
        protected void Anterior_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarAnterior();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Siguiente_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarSiguiente();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Ultimo_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarUltimo();
            }
            catch (System.Exception)
            {
            }
        }
        protected void SeleccionarTodo_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarSeleccionarTodo();
            }
            catch (System.Exception)
            {
            }
        }
        protected void DeseleccionarTodo_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarDeseleccionarTodo();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Buscar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarBuscar();
            }
            catch (System.Exception)
            {
            }
        }
        protected void Personalizar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolPersonalizar();
            }
            catch (System.Exception)
            {
            }
        }
        protected void GuardarPlantilla_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
            }
            catch (System.Exception)
            {
            }
        }
        protected void GuardarPlantillaComo_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
            }
            catch (System.Exception)
            {
            }
        }
        protected void EliminarPlantillasLocales_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
            }
            catch (System.Exception)
            {
            }
        }
        protected void EliminarPlantillasPublicas_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
            }
            catch (System.Exception)
            {
            }
        }
        protected void PublicarPlantillaPublicas_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
            }
            catch (System.Exception)
            {
            }
        }
        protected void ImportarPlantillaPublicas_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
            }
            catch (System.Exception)
            {
            }
        }
        protected void Editar_BeforeToolDropdown(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e)
        {
            try
            {
                this.ToolbarActualizarEstadoToolEditar();
                if (this.onToolEditarBeforeToolDropDown != null)
                {
                    this.onToolEditarBeforeToolDropDown(this, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void Estilo_BeforeToolDropdown(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e)
        {
            try
            {
                if (this.onToolEstiloBeforeToolDropDown != null)
                {
                    this.onToolEstiloBeforeToolDropDown(this, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        protected void IndiceSeleccionado_Change(object sender, System.EventArgs e)
        {
            System.Windows.Forms.TreeView trv = (System.Windows.Forms.TreeView)sender;
            customNodoSeleccionado = trv.SelectedNode.Tag;
        }
        #endregion Toolbar Principal

        #region Toolbar Navegacion
        protected void ControlChanged(object sender, OPropertyExtendedChangedEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "CampoPosicionable":
                        if (e.Valor != null)
                        {
                            if (e.Valor.ToString() == string.Empty)
                            {
                                this.Toolbar.Toolbars["ToolBarNavegacion"].Visible = false;
                            }
                            else
                            {
                                this.Toolbar.Toolbars["ToolBarNavegacion"].Visible = true;
                                Infragistics.Win.UltraWinToolbars.PopupControlContainerTool tool = this.Toolbar.Toolbars["ToolBarNavegacion"].Tools["IrAposicion"] as Infragistics.Win.UltraWinToolbars.PopupControlContainerTool;
                                if (tool.Control == null)
                                {
                                    Posicion posicion = new Posicion();
                                    posicion.AceptarClick += new System.EventHandler<OPropiedadEventArgs>(PosicionAceptar_Click);
                                    tool.Control = posicion;
                                }
                            }
                        }
                        break;
                }
            }
        }
        protected void IrPrimero_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrPrimero();
            }
            catch (System.Exception)
            {
            }
        }
        protected void IrAnterior_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrAnterior();
            }
            catch (System.Exception)
            {
            }
        }
        protected void IrSiguiente_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrSiguiente();
            }
            catch (System.Exception)
            {
            }
        }
        protected void IrUltimo_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrUltimo();
            }
            catch (System.Exception)
            {
            }
        }
        protected void PosicionAceptar_Click(object sender, OPropiedadEventArgs e)
        {
            try
            {
                int posicion;
                int ajusteFila = -1;
                if (this.OI.Filtros.Mostrar)
                {
                    ajusteFila = 0;
                }
                if (int.TryParse(e.Nombre, out posicion))
                {
                    if (posicion < this.grid.Rows.VisibleRowCount)
                    {
                        posicion += ajusteFila;
                        Infragistics.Win.UltraWinGrid.UltraGridRow filaActiva = this.grid.ActiveRow;
                        if (posicion > filaActiva.VisibleIndex)
                        {
                            this.ToolbarToolIrSiguiente(posicion - filaActiva.VisibleIndex, false);
                        }
                        else if (posicion < filaActiva.VisibleIndex)
                        {
                            this.ToolbarToolIrAnterior(filaActiva.VisibleIndex - posicion, false);
                        }
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }
        #endregion Toolbar Navegacion

        #endregion Eventos Toolbar

        #region Eventos Grid

        protected virtual void FilasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "Multiseleccion":
                        this.toolbar.Tools["SeleccionarTodo"].SharedProps.Enabled = this.definicion.Filas.Multiseleccion;
                        this.toolbar.Tools["DeseleccionarTodo"].SharedProps.Enabled = this.toolbar.Tools["SeleccionarTodo"].SharedProps.Enabled;
                        break;
                }
            }
        }
        private void timer_Tick(object sender, System.EventArgs e)
        {
            this.onToolCiclicoClick(this, ciclo);
        }

        #region Grid Base

        void grid_AfterDataRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (fila == null || !fila.IsDataRow)
            {
                this.ToolbarActualizarEstadoToolPrincipal(true);
                this.ToolbarActualizarEstadoToolNavegacion(true);
                this.ToolbarActualizarEstadoCopiarToolEditar();
            }
            this.fila = e.Row;
        }
        void grid_AfterFilterRowActivate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            if (fila == null || !fila.IsFilterRow)
            {
                this.ToolbarActualizarEstadoToolPrincipal(false);
                this.ToolbarActualizarEstadoToolNavegacion(false);
                this.ToolbarActualizarEstadoTodosToolEditar();
            }
            this.fila = e.Row;
        }

        #region Eventos After
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterBandHiddenChangedEventHandler AfterBandHiddenChanged
        {
            add
            {
                this.grid.AfterBandHiddenChanged += value;
                OEventHandler handler = new OEventHandler("AfterBandHiddenChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterBandHiddenChanged -= value;
                this.eventos.Remove("AfterBandHiddenChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterCardCompressedStateChangedEventHandler AfterCardCompressedStateChanged
        {
            add
            {
                this.grid.AfterCardCompressedStateChanged += value;
                OEventHandler handler = new OEventHandler("AfterCardCompressedStateChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterCardCompressedStateChanged -= value;
                this.eventos.Remove("AfterCardCompressedStateChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterCardsScrollEventHandler AfterCardsScroll
        {
            add
            {
                this.grid.AfterCardsScroll += value;
                OEventHandler handler = new OEventHandler("AfterCardsScroll", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterCardsScroll -= value;
                this.eventos.Remove("AfterCardsScroll");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.EventHandler AfterCellActivate
        {
            add
            {
                this.grid.AfterCellActivate += value;
                OEventHandler handler = new OEventHandler("AfterCellActivate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterCellActivate -= value;
                this.eventos.Remove("AfterCellActivate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellEventHandler AfterCellCancelUpdate
        {
            add
            {
                this.grid.AfterCellCancelUpdate += value;
                OEventHandler handler = new OEventHandler("AfterCellCancelUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterCellCancelUpdate -= value;
                this.eventos.Remove("AfterCellCancelUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellEventHandler AfterCellListCloseUp
        {
            add
            {
                this.grid.AfterCellListCloseUp += value;
                OEventHandler handler = new OEventHandler("AfterCellListCloseUp", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterCellListCloseUp -= value;
                this.eventos.Remove("AfterCellListCloseUp");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellEventHandler AfterCellUpdate
        {
            add
            {
                this.grid.AfterCellUpdate += value;
                OEventHandler handler = new OEventHandler("AfterCellUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterCellUpdate -= value;
                this.eventos.Remove("AfterCellUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterColPosChangedEventHandler AfterColPosChanged
        {
            add
            {
                this.grid.AfterColPosChanged += value;
                OEventHandler handler = new OEventHandler("AfterColPosChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterColPosChanged -= value;
                this.eventos.Remove("AfterColPosChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.ColScrollRegionEventHandler AfterColRegionScroll
        {
            add
            {
                this.grid.AfterColRegionScroll += value;
                OEventHandler handler = new OEventHandler("AfterColRegionScroll", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterColRegionScroll -= value;
                this.eventos.Remove("AfterColRegionScroll");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.ColScrollRegionEventHandler AfterColRegionSize
        {
            add
            {
                this.grid.AfterColRegionSize += value;
                OEventHandler handler = new OEventHandler("AfterColRegionSize", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterColRegionSize -= value;
                this.eventos.Remove("AfterColRegionSize");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.EventHandler AfterEnterEditMode
        {
            add
            {
                this.grid.AfterEnterEditMode += value;
                OEventHandler handler = new OEventHandler("AfterEnterEditMode", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterEnterEditMode -= value;
                this.eventos.Remove("AfterEnterEditMode");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.EventHandler AfterExitEditMode
        {
            add
            {
                this.grid.AfterExitEditMode += value;
                OEventHandler handler = new OEventHandler("AfterExitEditMode", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterExitEditMode -= value;
                this.eventos.Remove("AfterExitEditMode");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterGroupPosChangedEventHandler AfterGroupPosChanged
        {
            add
            {
                this.grid.AfterGroupPosChanged += value;
                OEventHandler handler = new OEventHandler("AfterGroupPosChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterGroupPosChanged -= value;
                this.eventos.Remove("AfterGroupPosChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterHeaderCheckStateChangedEventHandler AfterHeaderCheckStateChanged
        {
            add
            {
                this.grid.AfterHeaderCheckStateChanged += value;
                OEventHandler handler = new OEventHandler("AfterHeaderCheckStateChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterHeaderCheckStateChanged -= value;
                this.eventos.Remove("AfterHeaderCheckStateChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler AfterPerformAction
        {
            add
            {
                this.grid.AfterPerformAction += value;
                OEventHandler handler = new OEventHandler("AfterPerformAction", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterPerformAction -= value;
                this.eventos.Remove("AfterPerformAction");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.EventHandler AfterRowActivate
        {
            add
            {
                this.grid.AfterRowActivate += value;
                OEventHandler handler = new OEventHandler("AfterRowActivate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowActivate -= value;
                this.eventos.Remove("AfterRowActivate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterRowCancelUpdate
        {
            add
            {
                this.grid.AfterRowCancelUpdate += value;
                OEventHandler handler = new OEventHandler("AfterRowCancelUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowCancelUpdate -= value;
                this.eventos.Remove("AfterRowCancelUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterRowCollapsed
        {
            add
            {
                this.grid.AfterRowCollapsed += value;
                OEventHandler handler = new OEventHandler("AfterRowCollapsed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowCollapsed -= value;
                this.eventos.Remove("AfterRowCollapsed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterRowEditTemplateClosedEventHandler AfterRowEditTemplateClosed
        {
            add
            {
                this.grid.AfterRowEditTemplateClosed += value;
                OEventHandler handler = new OEventHandler("AfterRowEditTemplateClosed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowEditTemplateClosed -= value;
                this.eventos.Remove("AfterRowEditTemplateClosed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterRowEditTemplateDisplayedEventHandler AfterRowEditTemplateDisplayed
        {
            add
            {
                this.grid.AfterRowEditTemplateDisplayed += value;
                OEventHandler handler = new OEventHandler("AfterRowEditTemplateDisplayed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowEditTemplateDisplayed -= value;
                this.eventos.Remove("AfterRowEditTemplateDisplayed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterRowExpanded
        {
            add
            {
                this.grid.AfterRowExpanded += value;
                OEventHandler handler = new OEventHandler("AfterRowExpanded", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowExpanded -= value;
                this.eventos.Remove("AfterRowExpanded");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler AfterRowFilterChanged
        {
            add
            {
                this.grid.AfterRowFilterChanged += value;
                OEventHandler handler = new OEventHandler("AfterRowFilterChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowFilterChanged -= value;
                this.eventos.Remove("AfterRowFilterChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterRowFilterDropDownPopulateEventHandler AfterRowFilterDropDownPopulated
        {
            add
            {
                this.grid.AfterRowFilterDropDownPopulate += value;
                OEventHandler handler = new OEventHandler("AfterRowFilterDropDownPopulated", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowFilterDropDownPopulate -= value;
                this.eventos.Remove("AfterRowFilterDropDownPopulated");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterRowFixedStateChangedEventHandler AfterRowFixedStateChanged
        {
            add
            {
                this.grid.AfterRowFixedStateChanged += value;
                OEventHandler handler = new OEventHandler("AfterRowFixedStateChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowFixedStateChanged -= value;
                this.eventos.Remove("AfterRowFixedStateChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterRowInsert
        {
            add
            {
                this.grid.AfterRowInsert += value;
                OEventHandler handler = new OEventHandler("AfterRowInsert", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowInsert -= value;
                this.eventos.Remove("AfterRowInsert");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterRowLayoutItemResizedEventHandler AfterRowLayoutItemResized
        {
            add
            {
                this.grid.AfterRowLayoutItemResized += value;
                OEventHandler handler = new OEventHandler("AfterRowLayoutItemResized", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowLayoutItemResized -= value;
                this.eventos.Remove("AfterRowLayoutItemResized");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowScrollRegionEventHandler AfterRowRegionScroll
        {
            add
            {
                this.grid.AfterRowRegionScroll += value;
                OEventHandler handler = new OEventHandler("AfterRowRegionScroll", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowRegionScroll -= value;
                this.eventos.Remove("AfterRowRegionScroll");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowScrollRegionEventHandler AfterRowRegionSize
        {
            add
            {
                this.grid.AfterRowRegionSize += value;
                OEventHandler handler = new OEventHandler("AfterRowRegionSize", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowRegionSize -= value;
                this.eventos.Remove("AfterRowRegionSize");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterRowResize
        {
            add
            {
                this.grid.AfterRowResize += value;
                OEventHandler handler = new OEventHandler("AfterRowResize", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowResize -= value;
                this.eventos.Remove("AfterRowResize");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.EventHandler AfterRowsDeleted
        {
            add
            {
                this.grid.AfterRowsDeleted += value;
                OEventHandler handler = new OEventHandler("AfterRowsDeleted", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowsDeleted -= value;
                this.eventos.Remove("AfterRowsDeleted");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterRowUpdate
        {
            add
            {
                this.grid.AfterRowUpdate += value;
                OEventHandler handler = new OEventHandler("AfterRowUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterRowUpdate -= value;
                this.eventos.Remove("AfterRowUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler AfterSelectChange
        {
            add
            {
                this.grid.AfterSelectChange += value;
                OEventHandler handler = new OEventHandler("AfterSelectChange", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterSelectChange -= value;
                this.eventos.Remove("AfterSelectChange");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BandEventHandler AfterSortChange
        {
            add
            {
                this.grid.AfterSortChange += value;
                OEventHandler handler = new OEventHandler("AfterSortChange", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterSortChange -= value;
                this.eventos.Remove("AfterSortChange");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.AfterSummaryDialogEventHandler AfterSummaryDialog
        {
            add
            {
                this.grid.AfterSummaryDialog += value;
                OEventHandler handler = new OEventHandler("AfterSummaryDialog", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.AfterSummaryDialog -= value;
                this.eventos.Remove("AfterSummaryDialog");
            }
        }
        #endregion Eventos After

        #region Eventos Before
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableAutoSizeEditEventHandler BeforeAutoSizeEdit
        {
            add
            {
                this.grid.BeforeAutoSizeEdit += value;
                OEventHandler handler = new OEventHandler("BeforeAutoSizeEdit", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeAutoSizeEdit -= value;
                this.eventos.Remove("BeforeAutoSizeEdit");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeBandHiddenChangedEventHandler BeforeBandHiddenChanged
        {
            add
            {
                this.grid.BeforeBandHiddenChanged += value;
                OEventHandler handler = new OEventHandler("BeforeBandHiddenChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeBandHiddenChanged -= value;
                this.eventos.Remove("BeforeBandHiddenChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeCardCompressedStateChangedEventHandler BeforeCardCompressedStateChanged
        {
            add
            {
                this.grid.BeforeCardCompressedStateChanged += value;
                OEventHandler handler = new OEventHandler("BeforeCardCompressedStateChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCardCompressedStateChanged -= value;
                this.eventos.Remove("BeforeCardCompressedStateChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableCellEventHandler BeforeCellActivate
        {
            add
            {
                this.grid.BeforeCellActivate += value;
                OEventHandler handler = new OEventHandler("BeforeCellActivate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCellActivate -= value;
                this.eventos.Remove("BeforeCellActivate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableCellEventHandler BeforeCellCancelUpdate
        {
            add
            {
                this.grid.BeforeCellCancelUpdate += value;
                OEventHandler handler = new OEventHandler("BeforeCellCancelUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCellCancelUpdate -= value;
                this.eventos.Remove("BeforeCellCancelUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.ComponentModel.CancelEventHandler BeforeCellDeactivate
        {
            add
            {
                this.grid.BeforeCellDeactivate += value;
                OEventHandler handler = new OEventHandler("BeforeCellDeactivate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCellDeactivate -= value;
                this.eventos.Remove("BeforeCellDeactivate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableCellEventHandler BeforeCellListDropDown
        {
            add
            {
                this.grid.BeforeCellListDropDown += value;
                OEventHandler handler = new OEventHandler("BeforeCellListDropDown", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCellListDropDown -= value;
                this.eventos.Remove("BeforeCellListDropDown");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler BeforeCellUpdate
        {
            add
            {
                this.grid.BeforeCellUpdate += value;
                OEventHandler handler = new OEventHandler("BeforeCellUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCellUpdate -= value;
                this.eventos.Remove("BeforeCellUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeColPosChangedEventHandler BeforeColPosChanged
        {
            add
            {
                this.grid.BeforeColPosChanged += value;
                OEventHandler handler = new OEventHandler("BeforeColPosChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeColPosChanged -= value;
                this.eventos.Remove("BeforeColPosChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeColRegionRemovedEventHandler BeforeColRegionRemoved
        {
            add
            {
                this.grid.BeforeColRegionRemoved += value;
                OEventHandler handler = new OEventHandler("BeforeColRegionRemoved", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeColRegionRemoved -= value;
                this.eventos.Remove("BeforeColRegionRemoved");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeColRegionScrollEventHandler BeforeColRegionScroll
        {
            add
            {
                this.grid.BeforeColRegionScroll += value;
                OEventHandler handler = new OEventHandler("BeforeColRegionScroll", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeColRegionScroll -= value;
                this.eventos.Remove("BeforeColRegionScroll");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeColRegionSizeEventHandler BeforeColRegionSize
        {
            add
            {
                this.grid.BeforeColRegionSize += value;
                OEventHandler handler = new OEventHandler("BeforeColRegionSize", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeColRegionSize -= value;
                this.eventos.Remove("BeforeColRegionSize");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeColRegionSplitEventHandler BeforeColRegionSplit
        {
            add
            {
                this.grid.BeforeColRegionSplit += value;
                OEventHandler handler = new OEventHandler("BeforeColRegionSplit", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeColRegionSplit -= value;
                this.eventos.Remove("BeforeColRegionSplit");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeColumnChooserDisplayedEventHandler BeforeColumnChooserDisplayed
        {
            add
            {
                this.grid.BeforeColumnChooserDisplayed += value;
                OEventHandler handler = new OEventHandler("BeforeColumnChooserDisplayed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeColumnChooserDisplayed -= value;
                this.eventos.Remove("BeforeColumnChooserDisplayed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeCustomRowFilterDialogEventHandler BeforeCustomRowFilterDialog
        {
            add
            {
                this.grid.BeforeCustomRowFilterDialog += value;
                OEventHandler handler = new OEventHandler("BeforeCustomRowFilterDialog", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeCustomRowFilterDialog -= value;
                this.eventos.Remove("BeforeCustomRowFilterDialog");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeDisplayDataErrorTooltipEventHandler BeforeDisplayDataErrorTooltip
        {
            add
            {
                this.grid.BeforeDisplayDataErrorTooltip += value;
                OEventHandler handler = new OEventHandler("BeforeDisplayDataErrorTooltip", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeDisplayDataErrorTooltip -= value;
                this.eventos.Remove("BeforeDisplayDataErrorTooltip");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.ComponentModel.CancelEventHandler BeforeEnterEditMode
        {
            add
            {
                this.grid.BeforeEnterEditMode += value;
                OEventHandler handler = new OEventHandler("BeforeEnterEditMode", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeEnterEditMode -= value;
                this.eventos.Remove("BeforeEnterEditMode");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler BeforeExitEditMode
        {
            add
            {
                this.grid.BeforeExitEditMode += value;
                OEventHandler handler = new OEventHandler("BeforeExitEditMode", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeExitEditMode -= value;
                this.eventos.Remove("BeforeExitEditMode");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeGroupPosChangedEventHandler BeforeGroupPosChanged
        {
            add
            {
                this.grid.BeforeGroupPosChanged += value;
                OEventHandler handler = new OEventHandler("BeforeGroupPosChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeGroupPosChanged -= value;
                this.eventos.Remove("BeforeGroupPosChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeHeaderCheckStateChangedEventHandler BeforeHeaderCheckStateChanged
        {
            add
            {
                this.grid.BeforeHeaderCheckStateChanged += value;
                OEventHandler handler = new OEventHandler("BeforeHeaderCheckStateChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeHeaderCheckStateChanged -= value;
                this.eventos.Remove("BeforeHeaderCheckStateChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventHandler BeforeMultiCellOperation
        {
            add
            {
                this.grid.BeforeMultiCellOperation += value;
                OEventHandler handler = new OEventHandler("BeforeMultiCellOperation", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeMultiCellOperation -= value;
                this.eventos.Remove("BeforeMultiCellOperation");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeUltraGridPerformActionEventHandler BeforePerformAction
        {
            add
            {
                this.grid.BeforePerformAction += value;
                OEventHandler handler = new OEventHandler("BeforePerformAction", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforePerformAction -= value;
                this.eventos.Remove("BeforePerformAction");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforePrintEventHandler BeforePrint
        {
            add
            {
                this.grid.BeforePrint += value;
                OEventHandler handler = new OEventHandler("BeforePrint", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforePrint -= value;
                this.eventos.Remove("BeforePrint");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler BeforeRowActivate
        {
            add
            {
                this.grid.BeforeRowActivate += value;
                OEventHandler handler = new OEventHandler("BeforeRowActivate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowActivate -= value;
                this.eventos.Remove("BeforeRowActivate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableRowEventHandler BeforeRowCancelUpdate
        {
            add
            {
                this.grid.BeforeRowCancelUpdate += value;
                OEventHandler handler = new OEventHandler("BeforeRowCancelUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowCancelUpdate -= value;
                this.eventos.Remove("BeforeRowCancelUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableRowEventHandler BeforeRowCollapsed
        {
            add
            {
                this.grid.BeforeRowCollapsed += value;
                OEventHandler handler = new OEventHandler("BeforeRowCollapsed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowCollapsed -= value;
                this.eventos.Remove("BeforeRowCollapsed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.ComponentModel.CancelEventHandler BeforeRowDeactivate
        {
            add
            {
                this.grid.BeforeRowDeactivate += value;
                OEventHandler handler = new OEventHandler("BeforeRowDeactivate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowDeactivate -= value;
                this.eventos.Remove("BeforeRowDeactivate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowEditTemplateClosedEventHandler BeforeRowEditTemplateClosed
        {
            add
            {
                this.grid.BeforeRowEditTemplateClosed += value;
                OEventHandler handler = new OEventHandler("BeforeRowEditTemplateClosed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowEditTemplateClosed -= value;
                this.eventos.Remove("BeforeRowEditTemplateClosed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowEditTemplateDisplayedEventHandler BeforeRowEditTemplateDisplayed
        {
            add
            {
                this.grid.BeforeRowEditTemplateDisplayed += value;
                OEventHandler handler = new OEventHandler("BeforeRowEditTemplateDisplayed", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowEditTemplateDisplayed -= value;
                this.eventos.Remove("BeforeRowEditTemplateDisplayed");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableRowEventHandler BeforeRowExpanded
        {
            add
            {
                this.grid.BeforeRowExpanded += value;
                OEventHandler handler = new OEventHandler("BeforeRowExpanded", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowExpanded -= value;
                this.eventos.Remove("BeforeRowExpanded");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowFilterChangedEventHandler BeforeRowFilterChanged
        {
            add
            {
                this.grid.BeforeRowFilterChanged += value;
                OEventHandler handler = new OEventHandler("BeforeRowFilterChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowFilterChanged -= value;
                this.eventos.Remove("BeforeRowFilterChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventHandler BeforeRowFilterDropDown
        {
            add
            {
                this.grid.BeforeRowFilterDropDown += value;
                OEventHandler handler = new OEventHandler("BeforeRowFilterDropDown", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowFilterDropDown -= value;
                this.eventos.Remove("BeforeRowFilterDropDown");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownPopulateEventHandler BeforeRowFilterDropDownPopulate
        {
            add
            {
                this.grid.BeforeRowFilterDropDownPopulate += value;
                OEventHandler handler = new OEventHandler("BeforeRowFilterDropDownPopulate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowFilterDropDownPopulate -= value;
                this.eventos.Remove("BeforeRowFilterDropDownPopulate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowFixedStateChangedEventHandler BeforeRowFixedStateChanged
        {
            add
            {
                this.grid.BeforeRowFixedStateChanged += value;
                OEventHandler handler = new OEventHandler("BeforeRowFixedStateChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowFixedStateChanged -= value;
                this.eventos.Remove("BeforeRowFixedStateChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowInsertEventHandler BeforeRowInsert
        {
            add
            {
                this.grid.BeforeRowInsert += value;
                OEventHandler handler = new OEventHandler("BeforeRowInsert", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowInsert -= value;
                this.eventos.Remove("BeforeRowInsert");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowLayoutItemResizedEventHandler BeforeRowLayoutItemResized
        {
            add
            {
                this.grid.BeforeRowLayoutItemResized += value;
                OEventHandler handler = new OEventHandler("BeforeRowLayoutItemResized", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowLayoutItemResized -= value;
                this.eventos.Remove("BeforeRowLayoutItemResized");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowRegionRemovedEventHandler BeforeRowRegionRemoved
        {
            add
            {
                this.grid.BeforeRowRegionRemoved += value;
                OEventHandler handler = new OEventHandler("BeforeRowRegionRemoved", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowRegionRemoved -= value;
                this.eventos.Remove("BeforeRowRegionRemoved");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowRegionScrollEventHandler BeforeRowRegionScroll
        {
            add
            {
                this.grid.BeforeRowRegionScroll += value;
                OEventHandler handler = new OEventHandler("BeforeRowRegionScroll", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowRegionScroll -= value;
                this.eventos.Remove("BeforeRowRegionScroll");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowRegionSizeEventHandler BeforeRowRegionSize
        {
            add
            {
                this.grid.BeforeRowRegionSize += value;
                OEventHandler handler = new OEventHandler("BeforeRowRegionSize", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowRegionSize -= value;
                this.eventos.Remove("BeforeRowRegionSize");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowRegionSplitEventHandler BeforeRowRegionSplit
        {
            add
            {
                this.grid.BeforeRowRegionSplit += value;
                OEventHandler handler = new OEventHandler("BeforeRowRegionSplit", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowRegionSplit -= value;
                this.eventos.Remove("BeforeRowRegionSplit");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowResizeEventHandler BeforeRowResize
        {
            add
            {
                this.grid.BeforeRowResize += value;
                OEventHandler handler = new OEventHandler("BeforeRowResize", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowResize -= value;
                this.eventos.Remove("BeforeRowResize");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler BeforeRowsDeleted
        {
            add
            {
                this.grid.BeforeRowsDeleted += value;
                OEventHandler handler = new OEventHandler("BeforeRowsDeleted", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowsDeleted -= value;
                this.eventos.Remove("BeforeRowsDeleted");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CancelableRowEventHandler BeforeRowUpdate
        {
            add
            {
                this.grid.BeforeRowUpdate += value;
                OEventHandler handler = new OEventHandler("BeforeRowUpdate", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeRowUpdate -= value;
                this.eventos.Remove("BeforeRowUpdate");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler BeforeSelectChange
        {
            add
            {
                this.grid.BeforeSelectChange += value;
                OEventHandler handler = new OEventHandler("BeforeSelectChange", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeSelectChange -= value;
                this.eventos.Remove("BeforeSelectChange");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeSortChangeEventHandler BeforeSortChange
        {
            add
            {
                this.grid.BeforeSortChange += value;
                OEventHandler handler = new OEventHandler("BeforeSortChange", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeSortChange -= value;
                this.eventos.Remove("BeforeSortChange");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.BeforeSummaryDialogEventHandler BeforeSummaryDialog
        {
            add
            {
                this.grid.BeforeSummaryDialog += value;
                OEventHandler handler = new OEventHandler("BeforeSummaryDialog", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.BeforeSummaryDialog -= value;
                this.eventos.Remove("BeforeSummaryDialog");
            }
        }
        #endregion Eventos Before

        #region Eventos Cell
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellEventHandler CellChange
        {
            add
            {
                this.grid.CellChange += value;
                OEventHandler handler = new OEventHandler("CellChange", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.CellChange -= value;
                this.eventos.Remove("CellChange");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler CellDataError
        {
            add
            {
                this.grid.CellDataError += value;
                OEventHandler handler = new OEventHandler("CellDataError", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.CellDataError -= value;
                this.eventos.Remove("CellDataError");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellEventHandler CellListSelect
        {
            add
            {
                this.grid.CellListSelect += value;
                OEventHandler handler = new OEventHandler("CellListSelect", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.CellListSelect -= value;
                this.eventos.Remove("CellListSelect");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.ClickCellEventHandler ClickCell
        {
            add
            {
                this.grid.ClickCell += value;
                OEventHandler handler = new OEventHandler("ClickCell", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.ClickCell -= value;
                this.eventos.Remove("ClickCell");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.CellEventHandler ClickCellButton
        {
            add
            {
                this.grid.ClickCellButton += value;
                OEventHandler handler = new OEventHandler("ClickCellButton", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.ClickCellButton -= value;
                this.eventos.Remove("ClickCellButton");
            }
        }
        #endregion Eventos Cell

        #region Eventos DoubleClick
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public new event System.EventHandler DoubleClick
        {
            add
            {
                this.grid.DoubleClick += value;
                OEventHandler handler = new OEventHandler("DoubleClick", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.DoubleClick -= value;
                this.eventos.Remove("DoubleClick");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler DoubleClickCell
        {
            add
            {
                this.grid.DoubleClickCell += value;
                OEventHandler handler = new OEventHandler("DoubleClickCell", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.DoubleClickCell -= value;
                this.eventos.Remove("DoubleClickCell");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.DoubleClickHeaderEventHandler DoubleClickHeader
        {
            add
            {
                this.grid.DoubleClickHeader += value;
                OEventHandler handler = new OEventHandler("DoubleClickHeader", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.DoubleClickHeader -= value;
                this.eventos.Remove("DoubleClickHeader");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler DoubleClickRow
        {
            add
            {
                this.grid.DoubleClickRow += value;
                OEventHandler handler = new OEventHandler("DoubleClickRow", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.DoubleClickRow -= value;
                this.eventos.Remove("DoubleClickRow");
            }
        }
        #endregion Eventos DoubleClick

        #region Evento Error
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.ErrorEventHandler Error
        {
            add
            {
                this.grid.Error += value;
                OEventHandler handler = new OEventHandler("Error", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.Error -= value;
                this.eventos.Remove("Error");
            }
        }
        #endregion Evento Error

        #region Eventos Filter
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.FilterCellValueChangedEventHandler FilterCellValueChanged
        {
            add
            {
                this.grid.FilterCellValueChanged += value;
                OEventHandler handler = new OEventHandler("FilterCellValueChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.FilterCellValueChanged -= value;
                this.eventos.Remove("FilterCellValueChanged");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.FilterRowEventHandler FilterRow
        {
            add
            {
                this.grid.FilterRow += value;
                OEventHandler handler = new OEventHandler("FilterRow", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.FilterRow -= value;
                this.eventos.Remove("FilterRow");
            }
        }
        #endregion Eventos Filter

        #region Eventos Initialize
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializeGroupByRowEventHandler InitializeGroupByRow
        {
            add
            {
                this.grid.InitializeGroupByRow += value;
                OEventHandler handler = new OEventHandler("InitializeGroupByRow", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializeGroupByRow -= value;
                this.eventos.Remove("InitializeGroupByRow");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler InitializeLayout
        {
            add
            {
                this.grid.InitializeLayout += value;
                OEventHandler handler = new OEventHandler("InitializeLayout", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializeLayout -= value;
                this.eventos.Remove("InitializeLayout");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializeLogicalPrintPageEventHandler InitializeLogicalPrintPage
        {
            add
            {
                this.grid.InitializeLogicalPrintPage += value;
                OEventHandler handler = new OEventHandler("InitializeLogicalPrintPage", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializeLogicalPrintPage -= value;
                this.eventos.Remove("InitializeLogicalPrintPage");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializePrintEventHandler InitializePrint
        {
            add
            {
                this.grid.InitializePrint += value;
                OEventHandler handler = new OEventHandler("InitializePrint", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializePrint -= value;
                this.eventos.Remove("InitializePrint");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializePrintPreviewEventHandler InitializePrintPreview
        {
            add
            {
                this.grid.InitializePrintPreview += value;
                OEventHandler handler = new OEventHandler("InitializePrintPreview", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializePrintPreview -= value;
                this.eventos.Remove("InitializePrintPreview");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializeRowEventHandler InitializeRow
        {
            add
            {
                this.grid.InitializeRow += value;
                OEventHandler handler = new OEventHandler("InitializeRow", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializeRow -= value;
                this.eventos.Remove("InitializeRow");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializeRowsCollectionEventHandler InitializeRowsCollection
        {
            add
            {
                this.grid.InitializeRowsCollection += value;
                OEventHandler handler = new OEventHandler("InitializeRowsCollection", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializeRowsCollection -= value;
                this.eventos.Remove("InitializeRowsCollection");
            }
        }
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventHandler InitializeTemplateAddRow
        {
            add
            {
                this.grid.InitializeTemplateAddRow += value;
                OEventHandler handler = new OEventHandler("InitializeTemplateAddRow", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.InitializeTemplateAddRow -= value;
                this.eventos.Remove("InitializeTemplateAddRow");
            }
        }
        #endregion Eventos Initialize

        #region Evento RowEdit
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEditTemplateRequestedEventHandler RowEditTemplateRequested
        {
            add
            {
                this.grid.RowEditTemplateRequested += value;
                OEventHandler handler = new OEventHandler("RowEditTemplateRequested", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.RowEditTemplateRequested -= value;
                this.eventos.Remove("RowEditTemplateRequested");
            }
        }
        #endregion Evento RowEdit

        #region Evento Selection
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event System.ComponentModel.CancelEventHandler SelectionDrag
        {
            add
            {
                this.grid.SelectionDrag += value;
                OEventHandler handler = new OEventHandler("SelectionDrag", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.SelectionDrag -= value;
                this.eventos.Remove("SelectionDrag");
            }
        }
        #endregion Evento Selection

        #region Evento Summary
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.SummaryValueChangedEventHandler SummaryValueChanged
        {
            add
            {
                this.grid.SummaryValueChanged += value;
                OEventHandler handler = new OEventHandler("SummaryValueChanged", value);
                this.eventos.Add(handler.Evento, handler);
            }
            remove
            {
                this.grid.SummaryValueChanged -= value;
                this.eventos.Remove("SummaryValueChanged");
            }
        }
        #endregion

        #endregion Grid Base

        #endregion Eventos Grid

        #endregion Manejadores de eventos

        #region Métodos internos
        public void FlushAllEvents()
        {
            if (this.eventos.Keys.Count > 0)
            {
                var claves = this.eventos.Keys.ToList();
                foreach (string item in claves)
                {
                    this.GetType().GetEvent(this.eventos[item].Evento).RemoveEventHandler(this, this.eventos[item].Delegado);
                }
                claves.Clear();
            }
        }
        #endregion
    }
}