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
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Orbita.Controles.Menu;
namespace Orbita.Controles.Grid
{
    public partial class OrbitaUltraGridToolBar : UserControl
    {
        #region Nueva definicion
        public class ControlNuevaDefinicion : OUltraGridToolBar
        {
            public ControlNuevaDefinicion(OrbitaUltraGridToolBar sender)
                : base(sender)
            { }
        };
        #endregion Nueva definicion

        #region Atributos
        /// <summary>
        /// Proporciona un acceso a los recursos específicos de cada referencia cultural en tiempo de ejecución.
        /// </summary>
        System.Resources.ResourceManager stringManager;
        ControlNuevaDefinicion definicion;
        FrmBuscar frmBuscar;
        UltraGridRow fila = null;
        object customNodoSeleccionado = null;
        #endregion Atributos

        #region Delegados
        public delegate void ToolGestionarClickEventHandler(object sender, ToolClickEventArgs e);
        public delegate void ToolVerClickEventHandler(object sender, OToolClickEventArgs e);
        public delegate void ToolModificarClickEventHandler(object sender, OToolClickEventArgs e);
        public delegate void ToolAñadirClickEventHandler(object sender, ToolClickEventArgs e);
        public delegate void ToolEliminarClickEventHandler(object sender, OToolClickCollectionEventArgs e);
        public delegate void ToolExportarClickEventHandler(object sender, ToolClickEventArgs e);
        public delegate void ToolImprimirClickEventHandler(object sender, ToolClickEventArgs e);
        public delegate void ToolRefrescarClickEventHandler(object sender, ToolClickEventArgs e);
        public delegate void ToolEditarBeforeToolDropDownEventHandler(object sender, BeforeToolDropdownEventArgs e);
        public delegate void ToolEstiloBeforeToolDropDownEventHandler(object sender, BeforeToolDropdownEventArgs e);
        #endregion Delegados

        #region Eventos
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Gestionar.")]
        public event ToolGestionarClickEventHandler ToolGestionarClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Ver.")]
        public event ToolVerClickEventHandler ToolVerClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Modificar.")]
        public event ToolModificarClickEventHandler ToolModificarClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Añadir.")]
        public event ToolAñadirClickEventHandler ToolAñadirClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Eliminar.")]
        public event ToolEliminarClickEventHandler ToolEliminarClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Exportar.")]
        public event ToolExportarClickEventHandler ToolExportarClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Imprimir.")]
        public event ToolImprimirClickEventHandler ToolImprimirClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Refrescar.")]
        public event ToolRefrescarClickEventHandler ToolRefrescarClick;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Editar.")]
        public event ToolEditarBeforeToolDropDownEventHandler ToolEditarBeforeToolDropDown;
        [System.ComponentModel.Category("OrbitaUltraToolbarsManager")]
        [System.ComponentModel.Description("Estilo.")]
        public event ToolEstiloBeforeToolDropDownEventHandler ToolEstiloBeforeToolDropDown;
        #endregion Eventos

        #region Constructor
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
        [Description("El control interno OrbitaUltraToolBarsManager.")]
        [Category("Controles internos")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public OrbitaUltraToolbarsManager Toolbar
        {
            get { return this.toolbar; }
        }
        [Description("El control interno OrbitaUltraGrid.")]
        [Category("Controles internos")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public OrbitaUltraGrid Grid
        {
            get { return this.grid; }
        }
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion Orbita
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
            this.stringManager = new System.Resources.ResourceManager("es-ES", System.Reflection.Assembly.GetExecutingAssembly());
        }
        void InitializeProperties()
        {
            this.Orbita.Editable = Configuracion.DefectoEditable;
            this.Orbita.OcultarAgrupadorFilas = Configuracion.DefectoOcultarAgrupadorFilas;
            this.Orbita.CancelarTeclaReturn = Configuracion.DefectoCancelarTeclaReturn;
            this.Orbita.ModoActualizacion = Configuracion.DefectoModoActualizacion;
            this.Orbita.MostrarTitulo = Configuracion.DefectoMostrarTitulo;
            this.Orbita.MostrarToolGestionar = Configuracion.DefectoMostrarToolGestionar;
            this.Orbita.MostrarToolVer = Configuracion.DefectoMostrarToolVer;
            this.Orbita.MostrarToolModificar = Configuracion.DefectoMostrarToolModificar;
            this.Orbita.MostrarToolAñadir = Configuracion.DefectoMostrarToolAñadir;
            this.Orbita.MostrarToolEliminar = Configuracion.DefectoMostrarToolEliminar;
            this.Orbita.MostrarToolLimpiarFiltros = Configuracion.DefectoMostrarFiltros;
            this.Orbita.MostrarToolEditar = Configuracion.DefectoMostrarToolEditar;
            this.Orbita.MostrarToolExportar = Configuracion.DefectoMostrarToolExportar;
            this.Orbita.MostrarToolImprimir = Configuracion.DefectoMostrarToolImprimir;
            this.Orbita.MostrarToolEstilo = Configuracion.DefectoMostrarToolEstilo;
            this.Orbita.MostrarToolRefrescar = Configuracion.DefectoMostrarToolRefrescar;
        }
        void InitializeEvents()
        {
            this.definicion.PropertyChanged += new EventHandler<OPropertyExtendedChangedEventArgs>(ControlChanged);
            this.definicion.Filas.PropertyChanged += new EventHandler<OPropiedadEventArgs>(FilasChanged);
        }
        void InitializeEventsToolbar()
        {
            foreach (var item in this.toolbar.Toolbars)
            {
                foreach (Infragistics.Win.UltraWinToolbars.ToolBase tool in this.toolbar.Toolbars[item.Index].Tools)
                {
                    if (tool is PopupMenuTool)
                    {
                        this.ToolbarAsignarEventoPorReflexion(tool, "BeforeToolDropdown", "_BeforeToolDropdown");
                        this.InitializeEventsToolbar((PopupMenuTool)tool);
                    }
                    else if (tool is ButtonTool)
                    {
                        this.ToolbarAsignarEventoPorReflexion(tool, "ToolClick", "_Click");
                    }
                }
            }
        }
        void InitializeEventsToolbar(PopupMenuTool toolPopup)
        {
            foreach (Infragistics.Win.UltraWinToolbars.ToolBase tool in toolPopup.Tools)
            {
                if (tool is PopupMenuTool)
                {
                    this.ToolbarAsignarEventoPorReflexion(tool, "BeforeToolDropdown", "_BeforeToolDropdown");
                    this.InitializeEventsToolbar((PopupMenuTool)tool);
                }
                else if (tool is ButtonTool)
                {
                    this.ToolbarAsignarEventoPorReflexion(tool, "ToolClick", "_Click");
                }
            }
        }
        #endregion Initialize

        #region Toolbar
        void ToolbarAsignarEventoPorReflexion(ToolBase tool, string evento, string metodo)
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
            this.grid.Selected.Rows.AddRange((UltraGridRow[])this.grid.Rows.All);
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
            if (this.Orbita.DataSource != null)
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
            if (string.IsNullOrEmpty(this.Orbita.CampoPosicionable))
            {
                return;
            }
            this.grid.SuspendLayout();
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.grid.DisplayLayout.Bands)
                {
                    bool añadirColumnaOrdenada = false;
                    if (!banda.SortedColumns.Exists(this.Orbita.CampoPosicionable))
                    {
                        banda.SortedColumns.Clear();
                        añadirColumnaOrdenada = true;
                    }
                    if (banda.Columns.Exists(this.Orbita.CampoPosicionable))
                    {
                        if (añadirColumnaOrdenada)
                        {
                            banda.SortedColumns.Add(banda.Columns[this.Orbita.CampoPosicionable], false);
                            this.Orbita.Columnas.PermitirOrdenar = true;
                        }
                        UltraGridRow filaActiva = this.grid.ActiveRow;
                        int contador = 0;
                        bool fin = false;
                        while (!fin && (contador < x || principio))
                        {
                            contador++;
                            if (filaActiva != null &&
                                filaActiva.IsDataRow &&
                               !filaActiva.IsFilteredOut &&
                               !filaActiva.IsAddRow &&
                              !(this.Orbita.Filtros.Mostrar && filaActiva.VisibleIndex == 1) &&
                                filaActiva.Cells[this.Orbita.CampoPosicionable].Value != null)
                            {
                                int ordenFila;
                                if (int.TryParse(filaActiva.Cells[this.Orbita.CampoPosicionable].Value.ToString(), out ordenFila))
                                {
                                    int indiceMayor = filaActiva.VisibleIndex;
                                    int ajusteFilas = 0;
                                    if (this.Orbita.Filtros.Mostrar)
                                    {
                                        ajusteFilas = 1;
                                    }
                                    if (indiceMayor > ajusteFilas)
                                    {
                                        UltraGridRow fila = this.grid.Rows.GetRowAtVisibleIndex(indiceMayor - 1);
                                        if (fila != null)
                                        {
                                            fila.Cells[this.Orbita.CampoPosicionable].Value = ordenFila;
                                            fila.Update();
                                            filaActiva.Cells[this.Orbita.CampoPosicionable].Value = ordenFila - 1;
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
                        this.Orbita.Columnas.PermitirOrdenar = false;
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
            if (string.IsNullOrEmpty(this.Orbita.CampoPosicionable))
            {
                return;
            }
            this.grid.SuspendLayout();
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.grid.DisplayLayout.Bands)
                {
                    bool añadirColumnaOrdenada = false;
                    if (!banda.SortedColumns.Exists(this.Orbita.CampoPosicionable))
                    {
                        banda.SortedColumns.Clear();
                        añadirColumnaOrdenada = true;
                    }
                    if (banda.Columns.Exists(this.Orbita.CampoPosicionable))
                    {
                        if (añadirColumnaOrdenada)
                        {
                            banda.SortedColumns.Add(banda.Columns[this.Orbita.CampoPosicionable], false);
                            this.Orbita.Columnas.PermitirOrdenar = true;
                        }
                        UltraGridRow filaActiva = this.grid.ActiveRow;
                        int contador = 0;
                        bool fin = false;
                        while (!fin && (contador < x || final))
                        {
                            contador++;
                            if (filaActiva != null &&
                                filaActiva.IsDataRow &&
                               !filaActiva.IsFilteredOut &&
                               !filaActiva.IsAddRow &&
                                filaActiva.Cells[this.Orbita.CampoPosicionable].Value != null)
                            {
                                int ordenFila;
                                if (int.TryParse(filaActiva.Cells[this.Orbita.CampoPosicionable].Value.ToString(), out ordenFila))
                                {
                                    int indiceMayor = filaActiva.VisibleIndex;
                                    int ajusteFilas = 0;
                                    if (!this.Orbita.Filtros.Mostrar)
                                    {
                                        ajusteFilas = 1;
                                    }
                                    if (indiceMayor < this.grid.Rows.Count - ajusteFilas)
                                    {
                                        UltraGridRow fila = this.grid.Rows.GetRowAtVisibleIndex(indiceMayor + 1);
                                        if (fila != null)
                                        {
                                            fila.Cells[this.Orbita.CampoPosicionable].Value = ordenFila;
                                            fila.Update();
                                            filaActiva.Cells[this.Orbita.CampoPosicionable].Value = ordenFila + 1;
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
                        this.Orbita.Columnas.PermitirOrdenar = false;
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
            if (!string.IsNullOrEmpty(this.Orbita.CampoPosicionable))
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
        [Category("OrbitaUltraToolbarsManager")]
        public event ToolClickEventHandler ToolClick
        {
            add { this.Toolbar.ToolClick += value; }
            remove { this.Toolbar.ToolClick -= value; }
        }
        #endregion Toolbar Base

        #region Toolbar Principal
        protected void Gestionar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                if (this.ToolGestionarClick != null)
                {
                    this.ToolGestionarClick(this, e);
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Ver_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                UltraGridRow filaActiva = this.grid.ActiveRow;
                if (!filaActiva.IsDataRow)
                {
                    return;
                }
                if (this.ToolVerClick != null)
                {
                    OToolClickEventArgs nuevoEventArgs = new OToolClickEventArgs(e.Tool, e.ListToolItem);
                    nuevoEventArgs.Fila = filaActiva;
                    this.ToolVerClick(this, nuevoEventArgs);
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Modificar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                UltraGridRow filaActiva = this.grid.ActiveRow;
                if (!filaActiva.IsDataRow)
                {
                    return;
                }
                if (this.ToolModificarClick != null)
                {
                    OToolClickEventArgs nuevoEventArgs = new OToolClickEventArgs(e.Tool, e.ListToolItem);
                    nuevoEventArgs.Fila = filaActiva;
                    this.ToolModificarClick(this, nuevoEventArgs);
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Añadir_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                if (this.ToolAñadirClick != null)
                {
                    this.ToolAñadirClick(this, e);
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Eliminar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                UltraGridRow[] filasActivas = null;
                int indice = 0;
                foreach (UltraGridRow item in this.grid.Selected.Rows)
                {
                    if (item.IsDataRow)
                    {
                        filasActivas[indice++] = item;
                    }
                }
                if (filasActivas == null)
                { 
                    return;
                }
                if (this.definicion.Filas.Eliminar())
                {
                    if (this.ToolEliminarClick != null)
                    {
                        OToolClickCollectionEventArgs nuevoEventArgs = new OToolClickCollectionEventArgs(e.Tool, e.ListToolItem);
                        nuevoEventArgs.Filas = filasActivas;
                        this.ToolEliminarClick(this, nuevoEventArgs);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void LimpiarFiltros_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolLimpiarFiltros();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Exportar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                if (this.ToolExportarClick != null)
                {
                    this.ToolExportarClick(this, e);
                }
                else
                {
                    this.ToolbarToolExportar();
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Imprimir_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                if (this.ToolImprimirClick != null)
                {
                    this.ToolImprimirClick(this, e);
                }
                else
                {
                    this.ToolbarToolImprimir();
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Refrescar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                if (this.ToolRefrescarClick != null)
                {
                    this.ToolRefrescarClick(this, e);
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Deshacer_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarDeshacer();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Rehacer_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarRehacer();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Cortar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarCortar();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Copiar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarCopiar();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Pegar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarPegar();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Primero_Click(object sender, ToolClickEventArgs e)
        {
            this.grid.SuspendLayout();
            try
            {
                this.ToolbarToolEditarPrimero();
                if (this.Orbita.Filtros.Mostrar)
                {
                    this.ToolbarToolEditarSiguiente();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.grid.ResumeLayout();
            }
        }
        protected void Anterior_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarAnterior();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Siguiente_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarSiguiente();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Ultimo_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarUltimo();
            }
            catch (Exception ex)
            {
            }
        }
        protected void SeleccionarTodo_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarSeleccionarTodo();
            }
            catch (Exception ex)
            {
            }
        }
        protected void DeseleccionarTodo_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarDeseleccionarTodo();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Buscar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolEditarBuscar();
            }
            catch (Exception ex)
            {
            }
        }
        protected void Personalizar_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolPersonalizar();
            }
            catch (Exception ex)
            {
            }
        }
        protected void GuardarPlantilla_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }
        protected void GuardarPlantillaComo_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }
        protected void EliminarPlantillasLocales_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }
        protected void EliminarPlantillasPublicas_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }
        protected void PublicarPlantillaPublicas_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }
        protected void ImportarPlantillaPublicas_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }
        protected void Editar_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
        {
            try
            {
                this.ToolbarActualizarEstadoToolEditar();
                if (this.ToolEditarBeforeToolDropDown != null)
                {
                    this.ToolEditarBeforeToolDropDown(this, e);
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void Estilo_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
        {
            try
            {
                if (this.ToolEstiloBeforeToolDropDown != null)
                {
                    this.ToolEstiloBeforeToolDropDown(this, e);
                }
            }
            catch (Exception ex)
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
                                Infragistics.Win.UltraWinToolbars.PopupControlContainerTool tool = this.Toolbar.Toolbars["ToolBarNavegacion"].Tools["IrAposicion"] as PopupControlContainerTool;
                                if (tool.Control == null)
                                {
                                    Posicion posicion = new Posicion();
                                    posicion.AceptarClick += new EventHandler<OPropiedadEventArgs>(PosicionAceptar_Click);
                                    tool.Control = posicion;
                                }
                            }
                        }
                        break;
                }
            }
        }
        protected void IrPrimero_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrPrimero();
            }
            catch (Exception ex)
            {
            }
        }
        protected void IrAnterior_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrAnterior();
            }
            catch (Exception ex)
            {
            }
        }
        protected void IrSiguiente_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrSiguiente();
            }
            catch (Exception ex)
            {
            }
        }
        protected void IrUltimo_Click(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.ToolbarToolIrUltimo();
            }
            catch (Exception ex)
            {
            }
        }
        protected void PosicionAceptar_Click(object sender, OPropiedadEventArgs e)
        {
            try
            {
                int posicion;
                int ajusteFila = -1;
                if (this.Orbita.Filtros.Mostrar)
                {
                    ajusteFila = 0;
                }
                if (int.TryParse(e.Nombre, out posicion))
                {
                    if (posicion < this.grid.Rows.VisibleRowCount)
                    {
                        posicion += ajusteFila;
                        UltraGridRow filaActiva = this.grid.ActiveRow;
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
            catch (Exception ex)
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

        #region Grid Base

        #region Eventos After
        void grid_AfterDataRowActivate(object sender, RowEventArgs e)
        {
            if (fila == null || !fila.IsDataRow)
            {
                this.ToolbarActualizarEstadoToolPrincipal(true);
                this.ToolbarActualizarEstadoToolNavegacion(true);
                this.ToolbarActualizarEstadoCopiarToolEditar();
            }
            this.fila = e.Row;
        }
        void grid_AfterFilterRowActivate(object sender, RowEventArgs e)
        {
            if (fila == null || !fila.IsFilterRow)
            {
                this.ToolbarActualizarEstadoToolPrincipal(false);
                this.ToolbarActualizarEstadoToolNavegacion(false);
                this.ToolbarActualizarEstadoTodosToolEditar();
            }
            this.fila = e.Row;
        }
        [Category("OrbitaUltraGrid")]
        public event AfterBandHiddenChangedEventHandler AfterBandHiddenChanged
        {
            add { this.grid.AfterBandHiddenChanged += value; }
            remove { this.grid.AfterBandHiddenChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterCardCompressedStateChangedEventHandler AfterCardCompressedStateChanged
        {
            add { this.grid.AfterCardCompressedStateChanged += value; }
            remove { this.grid.AfterCardCompressedStateChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterCardsScrollEventHandler AfterCardsScroll
        {
            add { this.grid.AfterCardsScroll += value; }
            remove { this.grid.AfterCardsScroll -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event EventHandler AfterCellActivate
        {
            add { this.grid.AfterCellActivate += value; }
            remove { this.grid.AfterCellActivate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CellEventHandler AfterCellCancelUpdate
        {
            add { this.grid.AfterCellCancelUpdate += value; }
            remove { this.grid.AfterCellCancelUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CellEventHandler AfterCellListCloseUp
        {
            add { this.grid.AfterCellListCloseUp += value; }
            remove { this.grid.AfterCellListCloseUp -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CellEventHandler AfterCellUpdate
        {
            add { this.grid.AfterCellUpdate += value; }
            remove { this.grid.AfterCellUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterColPosChangedEventHandler AfterColPosChanged
        {
            add { this.grid.AfterColPosChanged += value; }
            remove { this.grid.AfterColPosChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event ColScrollRegionEventHandler AfterColRegionScroll
        {
            add { this.grid.AfterColRegionScroll += value; }
            remove { this.grid.AfterColRegionScroll -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event ColScrollRegionEventHandler AfterColRegionSize
        {
            add { this.grid.AfterColRegionSize += value; }
            remove { this.grid.AfterColRegionSize -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event EventHandler AfterEnterEditMode
        {
            add { this.grid.AfterEnterEditMode += value; }
            remove { this.grid.AfterEnterEditMode -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event EventHandler AfterExitEditMode
        {
            add { this.grid.AfterExitEditMode += value; }
            remove { this.grid.AfterExitEditMode -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterGroupPosChangedEventHandler AfterGroupPosChanged
        {
            add { this.grid.AfterGroupPosChanged += value; }
            remove { this.grid.AfterGroupPosChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterHeaderCheckStateChangedEventHandler AfterHeaderCheckStateChanged
        {
            add { this.grid.AfterHeaderCheckStateChanged += value; }
            remove { this.grid.AfterHeaderCheckStateChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterUltraGridPerformActionEventHandler AfterPerformAction
        {
            add { this.grid.AfterPerformAction += value; }
            remove { this.grid.AfterPerformAction -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event EventHandler AfterRowActivate
        {
            add { this.grid.AfterRowActivate += value; }
            remove { this.grid.AfterRowActivate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler AfterRowCancelUpdate
        {
            add { this.grid.AfterRowCancelUpdate += value; }
            remove { this.grid.AfterRowCancelUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler AfterRowCollapsed
        {
            add { this.grid.AfterRowCollapsed += value; }
            remove { this.grid.AfterRowCollapsed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterRowEditTemplateClosedEventHandler AfterRowEditTemplateClosed
        {
            add { this.grid.AfterRowEditTemplateClosed += value; }
            remove { this.grid.AfterRowEditTemplateClosed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterRowEditTemplateDisplayedEventHandler AfterRowEditTemplateDisplayed
        {
            add { this.grid.AfterRowEditTemplateDisplayed += value; }
            remove { this.grid.AfterRowEditTemplateDisplayed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler AfterRowExpanded
        {
            add { this.grid.AfterRowExpanded += value; }
            remove { this.grid.AfterRowExpanded -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterRowFilterChangedEventHandler AfterRowFilterChanged
        {
            add { this.grid.AfterRowFilterChanged += value; }
            remove { this.grid.AfterRowFilterChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterRowFilterDropDownPopulateEventHandler AfterRowFilterDropDownPopulated
        {
            add { this.grid.AfterRowFilterDropDownPopulate += value; }
            remove { this.grid.AfterRowFilterDropDownPopulate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterRowFixedStateChangedEventHandler AfterRowFixedStateChanged
        {
            add { this.grid.AfterRowFixedStateChanged += value; }
            remove { this.grid.AfterRowFixedStateChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler AfterRowInsert
        {
            add { this.grid.AfterRowInsert += value; }
            remove { this.grid.AfterRowInsert -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterRowLayoutItemResizedEventHandler AfterRowLayoutItemResized
        {
            add { this.grid.AfterRowLayoutItemResized += value; }
            remove { this.grid.AfterRowLayoutItemResized -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowScrollRegionEventHandler AfterRowRegionScroll
        {
            add { this.grid.AfterRowRegionScroll += value; }
            remove { this.grid.AfterRowRegionScroll -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowScrollRegionEventHandler AfterRowRegionSize
        {
            add { this.grid.AfterRowRegionSize += value; }
            remove { this.grid.AfterRowRegionSize -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler AfterRowResize
        {
            add { this.grid.AfterRowResize += value; }
            remove { this.grid.AfterRowResize -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event EventHandler AfterRowsDeleted
        {
            add { this.grid.AfterRowsDeleted += value; }
            remove { this.grid.AfterRowsDeleted -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler AfterRowUpdate
        {
            add { this.grid.AfterRowUpdate += value; }
            remove { this.grid.AfterRowUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterSelectChangeEventHandler AfterSelectChange
        {
            add { this.grid.AfterSelectChange += value; }
            remove { this.grid.AfterSelectChange -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BandEventHandler AfterSortChange
        {
            add { this.grid.AfterSortChange += value; }
            remove { this.grid.AfterSortChange -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event AfterSummaryDialogEventHandler AfterSummaryDialog
        {
            add { this.grid.AfterSummaryDialog += value; }
            remove { this.grid.AfterSummaryDialog -= value; }
        }
        #endregion

        #region Eventos Before
        [Category("OrbitaUltraGrid")]
        public event CancelableAutoSizeEditEventHandler BeforeAutoSizeEdit
        {
            add { this.grid.BeforeAutoSizeEdit += value; }
            remove { this.grid.BeforeAutoSizeEdit -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeBandHiddenChangedEventHandler BeforeBandHiddenChanged
        {
            add { this.grid.BeforeBandHiddenChanged += value; }
            remove { this.grid.BeforeBandHiddenChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeCardCompressedStateChangedEventHandler BeforeCardCompressedStateChanged
        {
            add { this.grid.BeforeCardCompressedStateChanged += value; }
            remove { this.grid.BeforeCardCompressedStateChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableCellEventHandler BeforeCellActivate
        {
            add { this.grid.BeforeCellActivate += value; }
            remove { this.grid.BeforeCellActivate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableCellEventHandler BeforeCellCancelUpdate
        {
            add { this.grid.BeforeCellCancelUpdate += value; }
            remove { this.grid.BeforeCellCancelUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelEventHandler BeforeCellDeactivate
        {
            add { this.grid.BeforeCellDeactivate += value; }
            remove { this.grid.BeforeCellDeactivate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableCellEventHandler BeforeCellListDropDown
        {
            add { this.grid.BeforeCellListDropDown += value; }
            remove { this.grid.BeforeCellListDropDown -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeCellUpdateEventHandler BeforeCellUpdate
        {
            add { this.grid.BeforeCellUpdate += value; }
            remove { this.grid.BeforeCellUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeColPosChangedEventHandler BeforeColPosChanged
        {
            add { this.grid.BeforeColPosChanged += value; }
            remove { this.grid.BeforeColPosChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeColRegionRemovedEventHandler BeforeColRegionRemoved
        {
            add { this.grid.BeforeColRegionRemoved += value; }
            remove { this.grid.BeforeColRegionRemoved -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeColRegionScrollEventHandler BeforeColRegionScroll
        {
            add { this.grid.BeforeColRegionScroll += value; }
            remove { this.grid.BeforeColRegionScroll -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeColRegionSizeEventHandler BeforeColRegionSize
        {
            add { this.grid.BeforeColRegionSize += value; }
            remove { this.grid.BeforeColRegionSize -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeColRegionSplitEventHandler BeforeColRegionSplit
        {
            add { this.grid.BeforeColRegionSplit += value; }
            remove { this.grid.BeforeColRegionSplit -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeColumnChooserDisplayedEventHandler BeforeColumnChooserDisplayed
        {
            add { this.grid.BeforeColumnChooserDisplayed += value; }
            remove { this.grid.BeforeColumnChooserDisplayed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeCustomRowFilterDialogEventHandler BeforeCustomRowFilterDialog
        {
            add { this.grid.BeforeCustomRowFilterDialog += value; }
            remove { this.grid.BeforeCustomRowFilterDialog -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeDisplayDataErrorTooltipEventHandler BeforeDisplayDataErrorTooltip
        {
            add { this.grid.BeforeDisplayDataErrorTooltip += value; }
            remove { this.grid.BeforeDisplayDataErrorTooltip -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelEventHandler BeforeEnterEditMode
        {
            add { this.grid.BeforeEnterEditMode += value; }
            remove { this.grid.BeforeEnterEditMode -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeExitEditModeEventHandler BeforeExitEditMode
        {
            add { this.grid.BeforeExitEditMode += value; }
            remove { this.grid.BeforeExitEditMode -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeGroupPosChangedEventHandler BeforeGroupPosChanged
        {
            add { this.grid.BeforeGroupPosChanged += value; }
            remove { this.grid.BeforeGroupPosChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeHeaderCheckStateChangedEventHandler BeforeHeaderCheckStateChanged
        {
            add { this.grid.BeforeHeaderCheckStateChanged += value; }
            remove { this.grid.BeforeHeaderCheckStateChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeMultiCellOperationEventHandler BeforeMultiCellOperation
        {
            add { this.grid.BeforeMultiCellOperation += value; }
            remove { this.grid.BeforeMultiCellOperation -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeUltraGridPerformActionEventHandler BeforePerformAction
        {
            add { this.grid.BeforePerformAction += value; }
            remove { this.grid.BeforePerformAction -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforePrintEventHandler BeforePrint
        {
            add { this.grid.BeforePrint += value; }
            remove { this.grid.BeforePrint -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event RowEventHandler BeforeRowActivate
        {
            add { this.grid.BeforeRowActivate += value; }
            remove { this.grid.BeforeRowActivate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableRowEventHandler BeforeRowCancelUpdate
        {
            add { this.grid.BeforeRowCancelUpdate += value; }
            remove { this.grid.BeforeRowCancelUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableRowEventHandler BeforeRowCollapsed
        {
            add { this.grid.BeforeRowCollapsed += value; }
            remove { this.grid.BeforeRowCollapsed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelEventHandler BeforeRowDeactivate
        {
            add { this.grid.BeforeRowDeactivate += value; }
            remove { this.grid.BeforeRowDeactivate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowEditTemplateClosedEventHandler BeforeRowEditTemplateClosed
        {
            add { this.grid.BeforeRowEditTemplateClosed += value; }
            remove { this.grid.BeforeRowEditTemplateClosed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowEditTemplateDisplayedEventHandler BeforeRowEditTemplateDisplayed
        {
            add { this.grid.BeforeRowEditTemplateDisplayed += value; }
            remove { this.grid.BeforeRowEditTemplateDisplayed -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableRowEventHandler BeforeRowExpanded
        {
            add { this.grid.BeforeRowExpanded += value; }
            remove { this.grid.BeforeRowExpanded -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowFilterChangedEventHandler BeforeRowFilterChanged
        {
            add { this.grid.BeforeRowFilterChanged += value; }
            remove { this.grid.BeforeRowFilterChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowFilterDropDownEventHandler BeforeRowFilterDropDown
        {
            add { this.grid.BeforeRowFilterDropDown += value; }
            remove { this.grid.BeforeRowFilterDropDown -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowFilterDropDownPopulateEventHandler BeforeRowFilterDropDownPopulate
        {
            add { this.grid.BeforeRowFilterDropDownPopulate += value; }
            remove { this.grid.BeforeRowFilterDropDownPopulate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowFixedStateChangedEventHandler BeforeRowFixedStateChanged
        {
            add { this.grid.BeforeRowFixedStateChanged += value; }
            remove { this.grid.BeforeRowFixedStateChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowInsertEventHandler BeforeRowInsert
        {
            add { this.grid.BeforeRowInsert += value; }
            remove { this.grid.BeforeRowInsert -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowLayoutItemResizedEventHandler BeforeRowLayoutItemResized
        {
            add { this.grid.BeforeRowLayoutItemResized += value; }
            remove { this.grid.BeforeRowLayoutItemResized -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowRegionRemovedEventHandler BeforeRowRegionRemoved
        {
            add { this.grid.BeforeRowRegionRemoved += value; }
            remove { this.grid.BeforeRowRegionRemoved -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowRegionScrollEventHandler BeforeRowRegionScroll
        {
            add { this.grid.BeforeRowRegionScroll += value; }
            remove { this.grid.BeforeRowRegionScroll -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowRegionSizeEventHandler BeforeRowRegionSize
        {
            add { this.grid.BeforeRowRegionSize += value; }
            remove { this.grid.BeforeRowRegionSize -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowRegionSplitEventHandler BeforeRowRegionSplit
        {
            add { this.grid.BeforeRowRegionSplit += value; }
            remove { this.grid.BeforeRowRegionSplit -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowResizeEventHandler BeforeRowResize
        {
            add { this.grid.BeforeRowResize += value; }
            remove { this.grid.BeforeRowResize -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeRowsDeletedEventHandler BeforeRowsDeleted
        {
            add { this.grid.BeforeRowsDeleted += value; }
            remove { this.grid.BeforeRowsDeleted -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CancelableRowEventHandler BeforeRowUpdate
        {
            add { this.grid.BeforeRowUpdate += value; }
            remove { this.grid.BeforeRowUpdate -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeSelectChangeEventHandler BeforeSelectChange
        {
            add { this.grid.BeforeSelectChange += value; }
            remove { this.grid.BeforeSelectChange -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeSortChangeEventHandler BeforeSortChange
        {
            add { this.grid.BeforeSortChange += value; }
            remove { this.grid.BeforeSortChange -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event BeforeSummaryDialogEventHandler BeforeSummaryDialog
        {
            add { this.grid.BeforeSummaryDialog += value; }
            remove { this.grid.BeforeSummaryDialog -= value; }
        }
        #endregion

        #region Eventos Cell
        [Category("OrbitaUltraGrid")]
        public event CellEventHandler CellChange
        {
            add { this.grid.CellChange += value; }
            remove { this.grid.CellChange -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CellDataErrorEventHandler CellDataError
        {
            add { this.grid.CellDataError += value; }
            remove { this.grid.CellDataError -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CellEventHandler CellListSelect
        {
            add { this.grid.CellListSelect += value; }
            remove { this.grid.CellListSelect -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event ClickCellEventHandler ClickCell
        {
            add { this.grid.ClickCell += value; }
            remove { this.grid.ClickCell -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event CellEventHandler ClickCellButton
        {
            add { this.grid.ClickCellButton += value; }
            remove { this.grid.ClickCellButton -= value; }
        }
        #endregion

        #region Eventos DoubleClick
        [Category("OrbitaUltraGrid")]
        public new event EventHandler DoubleClick
        {
            add { this.grid.DoubleClick += value; }
            remove { this.grid.DoubleClick -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event DoubleClickCellEventHandler DoubleClickCell
        {
            add { this.grid.DoubleClickCell += value; }
            remove { this.grid.DoubleClickCell -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event DoubleClickHeaderEventHandler DoubleClickHeader
        {
            add { this.grid.DoubleClickHeader += value; }
            remove { this.grid.DoubleClickHeader -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event DoubleClickRowEventHandler DoubleClickRow
        {
            add { this.grid.DoubleClickRow += value; }
            remove { this.grid.DoubleClickRow -= value; }
        }
        #endregion

        #region Evento Error
        [Category("OrbitaUltraGrid")]
        public event ErrorEventHandler Error
        {
            add { this.grid.Error += value; }
            remove { this.grid.Error -= value; }
        }
        #endregion

        #region Eventos Filter
        [Category("OrbitaUltraGrid")]
        public event FilterCellValueChangedEventHandler FilterCellValueChanged
        {
            add { this.grid.FilterCellValueChanged += value; }
            remove { this.grid.FilterCellValueChanged -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event FilterRowEventHandler FilterRow
        {
            add { this.grid.FilterRow += value; }
            remove { this.grid.FilterRow -= value; }
        }
        #endregion

        #region Eventos Initialize
        [Category("OrbitaUltraGrid")]
        public event InitializeGroupByRowEventHandler InitializeGroupByRow
        {
            add { this.grid.InitializeGroupByRow += value; }
            remove { this.grid.InitializeGroupByRow -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializeLayoutEventHandler InitializeLayout
        {
            add { this.grid.InitializeLayout += value; }
            remove { this.grid.InitializeLayout -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializeLogicalPrintPageEventHandler InitializeLogicalPrintPage
        {
            add { this.grid.InitializeLogicalPrintPage += value; }
            remove { this.grid.InitializeLogicalPrintPage -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializePrintEventHandler InitializePrint
        {
            add { this.grid.InitializePrint += value; }
            remove { this.grid.InitializePrint -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializePrintPreviewEventHandler InitializePrintPreview
        {
            add { this.grid.InitializePrintPreview += value; }
            remove { this.grid.InitializePrintPreview -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializeRowEventHandler InitializeRow
        {
            add { this.grid.InitializeRow += value; }
            remove { this.grid.InitializeRow -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializeRowsCollectionEventHandler InitializeRowsCollection
        {
            add { this.grid.InitializeRowsCollection += value; }
            remove { this.grid.InitializeRowsCollection -= value; }
        }
        [Category("OrbitaUltraGrid")]
        public event InitializeTemplateAddRowEventHandler InitializeTemplateAddRow
        {
            add { this.grid.InitializeTemplateAddRow += value; }
            remove { this.grid.InitializeTemplateAddRow -= value; }
        }
        #endregion

        #region Evento RowEdit
        [Category("OrbitaUltraGrid")]
        public event RowEditTemplateRequestedEventHandler RowEditTemplateRequested
        {
            add { this.grid.RowEditTemplateRequested += value; }
            remove { this.grid.RowEditTemplateRequested -= value; }
        }
        #endregion

        #region Evento Selection
        [Category("OrbitaUltraGrid")]
        public event CancelEventHandler SelectionDrag
        {
            add { this.grid.SelectionDrag += value; }
            remove { this.grid.SelectionDrag -= value; }
        }
        #endregion

        #region Evento Summary
        [Category("OrbitaUltraGrid")]
        public event SummaryValueChangedEventHandler SummaryValueChanged
        {
            add { this.grid.SummaryValueChanged += value; }
            remove { this.grid.SummaryValueChanged -= value; }
        }
        #endregion

        #endregion Grid Base

        #endregion Eventos Grid

        #endregion Manejadores de eventos
    }
}