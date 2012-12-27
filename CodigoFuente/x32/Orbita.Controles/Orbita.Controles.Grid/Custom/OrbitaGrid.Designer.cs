namespace Orbita.Controles.Grid
{
    partial class OrbitaGrid
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.tlbGrid.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolBar_Click);
            this.grid.AfterCellUpdate -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            this.grid.AfterRowActivate -= new System.EventHandler(this.Grid_AfterRowActivate);
            this.grid.AfterRowFilterChanged -= new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.Grid_AfterRowFilterChanged);
            this.grid.BeforeCellActivate -= new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.Grid_BeforeCellActivate);
            this.grid.BeforeCellUpdate -= new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.Grid_BeforeCellUpdate);
            this.grid.CellChange -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_CellChange);
            this.grid.CellDataError -= new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.Grid_CellDataError);
            this.grid.ClickCellButton -= new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_ClickCellButton);
            this.grid.Error -= new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.Grid_Error);
            this.grid.DoubleClickCell -= new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.Grid_DoubleClickCell);
            this.grid.DoubleClickRow -= new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.Grid_DoubleClickRow);
            this.grid.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Grid_InitializeLayout);
            this.grid.InitializeRow -= new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.Grid_InitializeRow);
            this.grid.InitializeTemplateAddRow -= new Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventHandler(this.Grid_InitializeTemplateAddRow);
            this.grid.FilterRow -= new Infragistics.Win.UltraWinGrid.FilterRowEventHandler(this.Grid_FilterRow);
            this.grid.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes
        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido del método con el editor de código.
        /// </summary>
        void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGrid));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("OrbToolBarArriba");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbGestionar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbVer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbModificar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbAñadir");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbEliminar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("OrbEditar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbExportar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbImprimir");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("OrbEstilo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbRefrescar");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("OrbToolBarDerecha");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbLimpiarFiltros");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrPrimero");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrAnterior");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrSiguiente");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrUltimo");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool2 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("OrbOrdenIrA");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool3 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("OrbOrdenIrA");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbImprimir");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbRefrescar");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbEliminar");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbAñadir");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbModificar");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbVer");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbLimpiarFiltros");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrSiguiente");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrUltimo");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("OrbEditar");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbDeshacer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbRehacer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbCortar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbCopiar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbPegar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbCopiar");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbGestionar");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbDeshacer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbRehacer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbCortar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbPegar");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool1 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("OrbOrdenIrA");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrPrimero");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbIrAnterior");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("OrbEstilo");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbPersonalizar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbGuardarPlantilla");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbGuardarPlantillaComo");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool15 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("OrbEliminarPlantillas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbPublicarPlantilla");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbImportarPlantillas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbGuardarPlantillaComo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbGuardarPlantilla");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbPublicarPlantilla");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbImportarPlantillas");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool16 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("OrbEliminarPlantillas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbEliminarPlantillasLocales");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbEliminarPlantillasPublicas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbEliminarPlantillasLocales");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbEliminarPlantillasPublicas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbPersonalizar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OrbExportar");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            this.ugeeGrid = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.ugpdGrid = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.uppdGrid = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pnlIrA = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.lblIrA = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.nePosicion = new Orbita.Controles.Comunes.OrbitaUltraNumbericEditor();
            this.btnAceptar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this._OrbitaGrid_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tlbGrid = new Orbita.Controles.Menu.OrbitaUltraToolBarsManager(this.components);
            this._OrbitaGrid_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaGrid_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlIrA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nePosicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uppdGrid
            // 
            this.uppdGrid.Name = "OrbPrintPreviewDialog";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Empty;
            this.imageList.Images.SetKeyName(0, "up.png");
            this.imageList.Images.SetKeyName(1, "down.png");
            this.imageList.Images.SetKeyName(2, "top.png");
            this.imageList.Images.SetKeyName(3, "bottom.png");
            this.imageList.Images.SetKeyName(4, "attachment.png");
            this.imageList.Images.SetKeyName(5, "view_record.png");
            this.imageList.Images.SetKeyName(6, "edit_record.png");
            this.imageList.Images.SetKeyName(7, "add_record.png");
            this.imageList.Images.SetKeyName(8, "delete_record.png");
            this.imageList.Images.SetKeyName(9, "printer.png");
            this.imageList.Images.SetKeyName(10, "refresh.png");
            this.imageList.Images.SetKeyName(11, "export.png");
            this.imageList.Images.SetKeyName(12, "edit.png");
            this.imageList.Images.SetKeyName(13, "preferences.png");
            this.imageList.Images.SetKeyName(14, "save.png");
            this.imageList.Images.SetKeyName(15, "copy.png");
            this.imageList.Images.SetKeyName(16, "paste.png");
            this.imageList.Images.SetKeyName(17, "filter.png");
            // 
            // grid
            // 
            this.grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 29);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(647, 225);
            this.grid.TabIndex = 5;
            this.grid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_AfterCellUpdate);
            this.grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Grid_InitializeLayout);
            this.grid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.Grid_InitializeRow);
            this.grid.InitializeTemplateAddRow += new Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventHandler(this.Grid_InitializeTemplateAddRow);
            this.grid.AfterRowActivate += new System.EventHandler(this.Grid_AfterRowActivate);
            this.grid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_CellChange);
            this.grid.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Grid_ClickCellButton);
            this.grid.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.Grid_BeforeCellActivate);
            this.grid.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.Grid_BeforeCellUpdate);
            this.grid.Error += new Infragistics.Win.UltraWinGrid.ErrorEventHandler(this.Grid_Error);
            this.grid.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.Grid_CellDataError);
            this.grid.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.Grid_DoubleClickCell);
            this.grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.Grid_DoubleClickRow);
            this.grid.FilterRow += new Infragistics.Win.UltraWinGrid.FilterRowEventHandler(this.Grid_FilterRow);
            this.grid.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.Grid_AfterRowFilterChanged);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // pnlIrA
            // 
            this.pnlIrA.Controls.Add(this.lblIrA);
            this.pnlIrA.Controls.Add(this.nePosicion);
            this.pnlIrA.Controls.Add(this.btnAceptar);
            this.pnlIrA.Location = new System.Drawing.Point(12, 139);
            this.pnlIrA.Name = "pnlIrA";
            this.pnlIrA.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlIrA.Size = new System.Drawing.Size(121, 60);
            this.pnlIrA.TabIndex = 0;
            this.pnlIrA.Visible = false;
            // 
            // lblIrA
            // 
            appearance1.BackColor = System.Drawing.SystemColors.ControlDark;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblIrA.Appearance = appearance1;
            this.lblIrA.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIrA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIrA.Location = new System.Drawing.Point(0, 1);
            this.lblIrA.Name = "lblIrA";
            this.lblIrA.OrbColorFondo = System.Drawing.SystemColors.ControlDark;
            this.lblIrA.OrbColorFuente = System.Drawing.Color.White;
            this.lblIrA.Size = new System.Drawing.Size(121, 15);
            this.lblIrA.TabIndex = 0;
            this.lblIrA.Text = "Posición";
            this.lblIrA.UseMnemonic = false;
            // 
            // nePosicion
            // 
            this.nePosicion.Location = new System.Drawing.Point(10, 25);
            this.nePosicion.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.nePosicion.MaskInput = "nnnn";
            this.nePosicion.MaxValue = 9999;
            this.nePosicion.MinValue = 1;
            this.nePosicion.Name = "nePosicion";
            this.nePosicion.PromptChar = ' ';
            this.nePosicion.Size = new System.Drawing.Size(36, 21);
            this.nePosicion.TabIndex = 1;
            this.nePosicion.Value = 1;
            this.nePosicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nePosicion_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Empty;
            this.btnAceptar.Location = new System.Drawing.Point(49, 24);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(64, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // _OrbitaGrid_Toolbars_Dock_Area_Left
            // 
            this._OrbitaGrid_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGrid_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGrid_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._OrbitaGrid_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGrid_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._OrbitaGrid_Toolbars_Dock_Area_Left.Name = "_OrbitaGrid_Toolbars_Dock_Area_Left";
            this._OrbitaGrid_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 225);
            this._OrbitaGrid_Toolbars_Dock_Area_Left.ToolbarsManager = this.tlbGrid;
            // 
            // tlbGrid
            // 
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            this.tlbGrid.Appearance = appearance2;
            this.tlbGrid.DesignerFlags = 1;
            this.tlbGrid.DockWithinContainer = this;
            this.tlbGrid.ImageListSmall = this.imageList;
            this.tlbGrid.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.tlbGrid.ShowFullMenusDelay = 500;
            this.tlbGrid.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingSize = new System.Drawing.Size(107, 294);
            buttonTool1.InstanceProps.RecentlyUsed = false;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.RecentlyUsed = false;
            buttonTool4.InstanceProps.RecentlyUsed = false;
            buttonTool5.InstanceProps.RecentlyUsed = false;
            popupMenuTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool33.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            popupMenuTool1,
            buttonTool33,
            buttonTool7,
            popupMenuTool2,
            buttonTool8});
            ultraToolbar1.Settings.PaddingBottom = 1;
            ultraToolbar1.Settings.PaddingTop = 1;
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool39,
            buttonTool41,
            buttonTool53,
            buttonTool54,
            popupControlContainerTool2,
            popupControlContainerTool3});
            ultraToolbar2.ShowInToolbarList = false;
            this.tlbGrid.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.tlbGrid.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.tlbGrid.ToolbarSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.False;
            appearance3.Image = 9;
            buttonTool11.SharedPropsInternal.AppearancesSmall.Appearance = appearance3;
            buttonTool11.SharedPropsInternal.Caption = "&Imprimir";
            buttonTool11.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance4.Image = 10;
            buttonTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance4;
            buttonTool12.SharedPropsInternal.Caption = "&Refrescar";
            buttonTool12.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance5.Image = 8;
            buttonTool13.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool13.SharedPropsInternal.Caption = "&Eliminar";
            buttonTool13.SharedPropsInternal.Category = "Gestion";
            buttonTool13.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance6.Image = 7;
            buttonTool14.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            buttonTool14.SharedPropsInternal.Caption = "&Añadir";
            buttonTool14.SharedPropsInternal.Category = "Gestion";
            buttonTool14.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance7.Image = 6;
            buttonTool15.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            buttonTool15.SharedPropsInternal.Caption = "&Modificar";
            buttonTool15.SharedPropsInternal.Category = "Gestion";
            buttonTool15.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance8.Image = 5;
            buttonTool16.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            buttonTool16.SharedPropsInternal.Caption = "&Ver";
            buttonTool16.SharedPropsInternal.Category = "Gestion";
            buttonTool16.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance9.Image = 17;
            buttonTool17.SharedPropsInternal.AppearancesSmall.Appearance = appearance9;
            buttonTool17.SharedPropsInternal.Caption = "Filtrar";
            buttonTool17.SharedPropsInternal.Category = "Posición";
            buttonTool17.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance10.Image = 1;
            buttonTool18.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
            buttonTool18.SharedPropsInternal.Caption = "Ir a la posición siguiente";
            buttonTool18.SharedPropsInternal.Category = "Posición";
            appearance11.Image = 3;
            buttonTool19.SharedPropsInternal.AppearancesSmall.Appearance = appearance11;
            buttonTool19.SharedPropsInternal.Caption = "Ir a la última posición";
            buttonTool19.SharedPropsInternal.Category = "Posición";
            appearance12.Image = 12;
            popupMenuTool5.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
            popupMenuTool5.SharedPropsInternal.Caption = "E&ditar";
            popupMenuTool5.SharedPropsInternal.Category = "Edición";
            popupMenuTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars;
            popupMenuTool5.SharedPropsInternal.Tag = "OrbCopiar";
            buttonTool22.InstanceProps.IsFirstInGroup = true;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool20,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24});
            appearance13.Image = 15;
            buttonTool25.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
            buttonTool25.SharedPropsInternal.Caption = "&Copiar";
            buttonTool25.SharedPropsInternal.Category = "Edición";
            buttonTool25.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            appearance14.Image = 4;
            buttonTool26.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool26.SharedPropsInternal.Caption = "&Gestionar";
            buttonTool26.SharedPropsInternal.Category = "Gestionar";
            buttonTool26.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedPropsInternal.Caption = "Deshacer";
            buttonTool27.SharedPropsInternal.Category = "Edición";
            buttonTool27.SharedPropsInternal.Enabled = false;
            buttonTool27.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            buttonTool28.SharedPropsInternal.Caption = "Rehacer";
            buttonTool28.SharedPropsInternal.Category = "Edición";
            buttonTool28.SharedPropsInternal.Enabled = false;
            buttonTool28.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            buttonTool29.SharedPropsInternal.Caption = "Cortar";
            buttonTool29.SharedPropsInternal.Category = "Edición";
            buttonTool29.SharedPropsInternal.Enabled = false;
            buttonTool29.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            appearance15.Image = 16;
            buttonTool30.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool30.SharedPropsInternal.Caption = "Pegar";
            buttonTool30.SharedPropsInternal.Category = "Edición";
            buttonTool30.SharedPropsInternal.Enabled = false;
            buttonTool30.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            popupControlContainerTool1.ControlName = "pnlIrA";
            popupControlContainerTool1.DropDownArrowStyle = Infragistics.Win.UltraWinToolbars.DropDownArrowStyle.None;
            popupControlContainerTool1.SharedPropsInternal.Caption = "Ir a posición";
            popupControlContainerTool1.SharedPropsInternal.Category = "Posición";
            popupControlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            appearance16.Image = 2;
            buttonTool35.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool35.SharedPropsInternal.Caption = "Ir a la primera posición";
            buttonTool35.SharedPropsInternal.Category = "Posición";
            appearance17.Image = 0;
            buttonTool36.SharedPropsInternal.AppearancesSmall.Appearance = appearance17;
            buttonTool36.SharedPropsInternal.Caption = "Ir a la posición anterior";
            buttonTool36.SharedPropsInternal.Category = "Posición";
            appearance18.Image = 13;
            popupMenuTool8.SharedPropsInternal.AppearancesSmall.Appearance = appearance18;
            popupMenuTool8.SharedPropsInternal.Caption = "E&stilo";
            popupMenuTool8.SharedPropsInternal.Category = "Estilo";
            popupMenuTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool37.InstanceProps.IsFirstInGroup = true;
            popupMenuTool15.InstanceProps.IsFirstInGroup = true;
            buttonTool45.InstanceProps.IsFirstInGroup = true;
            popupMenuTool8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool31,
            buttonTool37,
            buttonTool38,
            popupMenuTool15,
            buttonTool45,
            buttonTool46});
            buttonTool40.SharedPropsInternal.Caption = "Guardar plantilla como...";
            buttonTool40.SharedPropsInternal.Category = "Estilo";
            appearance19.Image = 14;
            buttonTool42.SharedPropsInternal.AppearancesSmall.Appearance = appearance19;
            buttonTool42.SharedPropsInternal.Caption = "Guardar plantilla";
            buttonTool42.SharedPropsInternal.Category = "Estilo";
            buttonTool42.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            buttonTool47.SharedPropsInternal.Caption = "Publicar plantilla";
            buttonTool47.SharedPropsInternal.Category = "Estilo";
            buttonTool48.SharedPropsInternal.Caption = "Importar plantilla...";
            buttonTool48.SharedPropsInternal.Category = "Estilo";
            popupMenuTool16.SharedPropsInternal.Caption = "Eliminar plantillas";
            popupMenuTool16.SharedPropsInternal.Category = "Estilo";
            popupMenuTool16.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool49,
            buttonTool50});
            buttonTool51.SharedPropsInternal.Caption = "Locales";
            buttonTool51.SharedPropsInternal.Category = "Estilo";
            buttonTool52.SharedPropsInternal.Caption = "Públicas";
            buttonTool52.SharedPropsInternal.Category = "Estilo";
            buttonTool32.SharedPropsInternal.Caption = "Personalizar...";
            appearance20.Image = 11;
            buttonTool34.SharedPropsInternal.AppearancesSmall.Appearance = appearance20;
            buttonTool34.SharedPropsInternal.Caption = "E&xportar";
            buttonTool34.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool34.SharedPropsInternal.ShowInCustomizer = false;
            buttonTool34.SharedPropsInternal.Tag = "OrbExportarExcel";
            this.tlbGrid.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19,
            popupMenuTool5,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            buttonTool28,
            buttonTool29,
            buttonTool30,
            popupControlContainerTool1,
            buttonTool35,
            buttonTool36,
            popupMenuTool8,
            buttonTool40,
            buttonTool42,
            buttonTool47,
            buttonTool48,
            popupMenuTool16,
            buttonTool51,
            buttonTool52,
            buttonTool32,
            buttonTool34});
            this.tlbGrid.BeforeShortcutKeyProcessed += new Infragistics.Win.UltraWinToolbars.BeforeShortcutKeyProcessedEventHandler(this.ToolBar_BeforeShortcutKeyProcessed);
            this.tlbGrid.BeforeToolDropdown += new Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventHandler(this.ToolBar_BeforeToolDropdown);
            this.tlbGrid.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolBar_Click);
            // 
            // _OrbitaGrid_Toolbars_Dock_Area_Right
            // 
            this._OrbitaGrid_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGrid_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGrid_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._OrbitaGrid_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGrid_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(647, 29);
            this._OrbitaGrid_Toolbars_Dock_Area_Right.Name = "_OrbitaGrid_Toolbars_Dock_Area_Right";
            this._OrbitaGrid_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(27, 225);
            this._OrbitaGrid_Toolbars_Dock_Area_Right.ToolbarsManager = this.tlbGrid;
            // 
            // _OrbitaGrid_Toolbars_Dock_Area_Top
            // 
            this._OrbitaGrid_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGrid_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGrid_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._OrbitaGrid_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGrid_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._OrbitaGrid_Toolbars_Dock_Area_Top.Name = "_OrbitaGrid_Toolbars_Dock_Area_Top";
            this._OrbitaGrid_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(674, 29);
            this._OrbitaGrid_Toolbars_Dock_Area_Top.ToolbarsManager = this.tlbGrid;
            // 
            // _OrbitaGrid_Toolbars_Dock_Area_Bottom
            // 
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 254);
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.Name = "_OrbitaGrid_Toolbars_Dock_Area_Bottom";
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(674, 0);
            this._OrbitaGrid_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tlbGrid;
            // 
            // OrbitaGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlIrA);
            this.Controls.Add(this.grid);
            this.Controls.Add(this._OrbitaGrid_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._OrbitaGrid_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._OrbitaGrid_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._OrbitaGrid_Toolbars_Dock_Area_Top);
            this.Name = "OrbitaGrid";
            this.Size = new System.Drawing.Size(674, 254);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlIrA.ResumeLayout(false);
            this.pnlIrA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nePosicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlbGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        Orbita.Controles.Menu.OrbitaUltraToolBarsManager tlbGrid;
        Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter ugeeGrid;
        Infragistics.Win.UltraWinGrid.UltraGridPrintDocument ugpdGrid;
        Infragistics.Win.Printing.UltraPrintPreviewDialog uppdGrid;
        Infragistics.Win.UltraWinGrid.UltraGrid grid;
        Orbita.Controles.Contenedores.OrbitaPanel pnlIrA;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGrid_Toolbars_Dock_Area_Left;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGrid_Toolbars_Dock_Area_Right;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGrid_Toolbars_Dock_Area_Bottom;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGrid_Toolbars_Dock_Area_Top;
        Orbita.Controles.Comunes.OrbitaUltraNumbericEditor nePosicion;
        Orbita.Controles.Comunes.OrbitaUltraButton btnAceptar;
        Orbita.Controles.Comunes.OrbitaUltraLabel lblIrA;
        System.Windows.Forms.ImageList imageList;
    }
}
