namespace Orbita.Controles.Comunicaciones
{
    partial class OrbitaVisorTCP
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaVisorTCP));
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pnlArbol = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.ArbolLogs = new System.Windows.Forms.TreeView();
            this.imgArbol = new System.Windows.Forms.ImageList(this.components);
            this.oVisorDiferido1 = new OrbitaVisorDiferido();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.splitContenedorTrazas = new Orbita.Controles.Contenedores.OrbitaSplitContainer();
            this.gridTrazas = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            this.gridTrazasError = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tabDiferido = new Orbita.Controles.Contenedores.OrbitaUltraTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.spl = new Infragistics.Win.Misc.UltraSplitter();
            this.ebArbol = new Orbita.Controles.Menu.OrbitaUltraExplorerBar();
            this.stEstadoApp = new Orbita.Controles.Comunes.OrbitaUltraStatusBar();
            this.mnPrincipal = new Orbita.Controles.Menu.OrbitaMenuStrip();
            this.mnVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerTrazasErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerLogsErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.tbControles = new Orbita.Controles.Contenedores.OrbitaUltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.cmnTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAbrirEnPrincipal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbrirEnOtraPestaña = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraTabPageControl3.SuspendLayout();
            this.pnlArbol.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContenedorTrazas)).BeginInit();
            this.splitContenedorTrazas.Panel1.SuspendLayout();
            this.splitContenedorTrazas.Panel2.SuspendLayout();
            this.splitContenedorTrazas.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDiferido)).BeginInit();
            this.tabDiferido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ebArbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stEstadoApp)).BeginInit();
            this.mnPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbControles)).BeginInit();
            this.tbControles.SuspendLayout();
            this.cmnTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.pnlArbol);
            this.ultraTabPageControl3.Controls.Add(this.oVisorDiferido1);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(23, 1);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(808, 566);
            // 
            // pnlArbol
            // 
            this.pnlArbol.Controls.Add(this.ArbolLogs);
            this.pnlArbol.Location = new System.Drawing.Point(2, 57);
            this.pnlArbol.Name = "pnlArbol";
            this.pnlArbol.Size = new System.Drawing.Size(200, 100);
            this.pnlArbol.TabIndex = 5;
            // 
            // ArbolLogs
            // 
            this.ArbolLogs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ArbolLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArbolLogs.ImageIndex = 0;
            this.ArbolLogs.ImageList = this.imgArbol;
            this.ArbolLogs.Location = new System.Drawing.Point(0, 0);
            this.ArbolLogs.Name = "ArbolLogs";
            this.ArbolLogs.SelectedImageIndex = 0;
            this.ArbolLogs.Size = new System.Drawing.Size(200, 100);
            this.ArbolLogs.TabIndex = 1;
            this.ArbolLogs.DoubleClick += new System.EventHandler(this.btnAbrirEnPrincipal_Click);
            // 
            // imgArbol
            // 
            this.imgArbol.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgArbol.ImageStream")));
            this.imgArbol.TransparentColor = System.Drawing.Color.Transparent;
            this.imgArbol.Images.SetKeyName(0, "folder.png");
            this.imgArbol.Images.SetKeyName(1, "folder_closed.png");
            this.imgArbol.Images.SetKeyName(2, "document.png");
            this.imgArbol.Images.SetKeyName(3, "document_plain_green.png");
            // 
            // oVisorDiferido1
            // 
            this.oVisorDiferido1.BackColor = System.Drawing.Color.White;
            this.oVisorDiferido1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oVisorDiferido1.Location = new System.Drawing.Point(0, 0);
            this.oVisorDiferido1.Name = "oVisorDiferido1";
            this.oVisorDiferido1.Size = new System.Drawing.Size(808, 566);
            this.oVisorDiferido1.TabIndex = 0;
            this.oVisorDiferido1.VerVisorErrores = false;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.splitContenedorTrazas);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(996, 570);
            // 
            // splitContenedorTrazas
            // 
            this.splitContenedorTrazas.BackColor = System.Drawing.Color.Transparent;
            this.splitContenedorTrazas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContenedorTrazas.Location = new System.Drawing.Point(0, 0);
            this.splitContenedorTrazas.Name = "splitContenedorTrazas";
            this.splitContenedorTrazas.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContenedorTrazas.Panel1
            // 
            this.splitContenedorTrazas.Panel1.Controls.Add(this.gridTrazas);
            this.splitContenedorTrazas.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContenedorTrazas.Panel2
            // 
            this.splitContenedorTrazas.Panel2.Controls.Add(this.gridTrazasError);
            this.splitContenedorTrazas.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContenedorTrazas.Size = new System.Drawing.Size(996, 570);
            this.splitContenedorTrazas.SplitterDistance = 370;
            this.splitContenedorTrazas.TabIndex = 0;
            // 
            // gridTrazas
            // 
            this.gridTrazas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrazas.Location = new System.Drawing.Point(2, 2);
            this.gridTrazas.Name = "gridTrazas";
            this.gridTrazas.OI.CampoPosicionable = null;
            this.gridTrazas.Size = new System.Drawing.Size(992, 366);
            this.gridTrazas.TabIndex = 1;
            this.gridTrazas.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolClick);
            this.gridTrazas.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.DoubleClickRow);
            this.gridTrazas.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.InitializeLayoutWithHeader);
            this.gridTrazas.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.InitializeRow);
            // 
            // gridTrazasError
            // 
            this.gridTrazasError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrazasError.Location = new System.Drawing.Point(2, 2);
            this.gridTrazasError.Name = "gridTrazasError";
            this.gridTrazasError.OI.CampoPosicionable = null;
            this.gridTrazasError.Size = new System.Drawing.Size(992, 192);
            this.gridTrazasError.TabIndex = 2;
            this.gridTrazasError.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolClick);
            this.gridTrazasError.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.DoubleClickRow);
            this.gridTrazasError.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.InitializeLayoutWithoutHeader);
            this.gridTrazasError.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.InitializeRow);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.tabDiferido);
            this.ultraTabPageControl2.Controls.Add(this.spl);
            this.ultraTabPageControl2.Controls.Add(this.ebArbol);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(996, 570);
            // 
            // tabDiferido
            // 
            this.tabDiferido.CloseButtonLocation = Infragistics.Win.UltraWinTabs.TabCloseButtonLocation.Tab;
            this.tabDiferido.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabDiferido.Controls.Add(this.ultraTabPageControl3);
            this.tabDiferido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDiferido.Location = new System.Drawing.Point(162, 0);
            this.tabDiferido.Name = "tabDiferido";
            this.tabDiferido.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabDiferido.Size = new System.Drawing.Size(834, 570);
            this.tabDiferido.TabIndex = 5;
            this.tabDiferido.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.LeftTop;
            ultraTab1.AllowClosing = Infragistics.Win.DefaultableBoolean.False;
            ultraTab1.CloseButtonVisibility = Infragistics.Win.UltraWinTabs.TabCloseButtonVisibility.Never;
            ultraTab1.TabPage = this.ultraTabPageControl3;
            ultraTab1.Text = "Fichero log";
            this.tabDiferido.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            this.tabDiferido.TabClosed += new Infragistics.Win.UltraWinTabControl.TabClosedEventHandler(this.tabDiferido_TabClosed);
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(808, 566);
            // 
            // spl
            // 
            this.spl.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance1.BackColor = System.Drawing.SystemColors.ControlDark;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            this.spl.ButtonAppearance = appearance1;
            this.spl.ButtonExtent = 50;
            this.spl.CollapseUIType = Infragistics.Win.Misc.CollapseUIType.None;
            this.spl.Location = new System.Drawing.Point(152, 0);
            this.spl.Name = "spl";
            this.spl.RestoreExtent = 0;
            this.spl.Size = new System.Drawing.Size(10, 570);
            this.spl.TabIndex = 4;
            // 
            // ebArbol
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(183)))));
            this.ebArbol.Appearance = appearance2;
            this.ebArbol.Dock = System.Windows.Forms.DockStyle.Left;
            this.ebArbol.Location = new System.Drawing.Point(0, 0);
            this.ebArbol.Margins.Top = 3;
            this.ebArbol.Name = "ebArbol";
            this.ebArbol.NavigationMaxGroupHeaders = 0;
            this.ebArbol.NavigationOverflowButtonAreaVisible = false;
            this.ebArbol.Size = new System.Drawing.Size(152, 570);
            this.ebArbol.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
            this.ebArbol.TabIndex = 0;
            this.ebArbol.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ebArbol.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
            // 
            // stEstadoApp
            // 
            this.stEstadoApp.Location = new System.Drawing.Point(0, 620);
            this.stEstadoApp.Name = "stEstadoApp";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "TextoPuerto";
            ultraStatusPanel1.Text = "Puerto canal TCP:";
            ultraStatusPanel1.ToolTipText = "Puerto de conexión TCP remoting.";
            ultraStatusPanel1.Width = 93;
            appearance3.FontData.BoldAsString = "True";
            ultraStatusPanel2.Appearance = appearance3;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Key = "Puerto";
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.Text = "1440";
            ultraStatusPanel2.Width = 700;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            ultraStatusPanel3.Appearance = appearance4;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel3.Key = "Estado";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.AutoStatusText;
            ultraStatusPanel3.Width = 25;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Key = "EstadoTexto";
            ultraStatusPanel4.Text = "Detenido";
            ultraStatusPanel4.Width = 60;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel5.Key = "Fecha";
            ultraStatusPanel5.Text = "26/02/2013 16:20";
            ultraStatusPanel5.Visible = false;
            this.stEstadoApp.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5});
            this.stEstadoApp.ScaledImageSize = new System.Drawing.Size(24, 24);
            this.stEstadoApp.ScaleImages = Infragistics.Win.ScaleImage.Never;
            this.stEstadoApp.Size = new System.Drawing.Size(1000, 30);
            this.stEstadoApp.SizeGripVisible = Infragistics.Win.DefaultableBoolean.False;
            this.stEstadoApp.TabIndex = 0;
            this.stEstadoApp.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.VisualStudio2005;
            // 
            // mnPrincipal
            // 
            this.mnPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnVer,
            this.mnConfiguracion});
            this.mnPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnPrincipal.Name = "mnPrincipal";
            this.mnPrincipal.Size = new System.Drawing.Size(1000, 24);
            this.mnPrincipal.TabIndex = 1;
            this.mnPrincipal.Text = "orbitaMenuStrip1";
            // 
            // mnVer
            // 
            this.mnVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVerTrazasErrores,
            this.tsmiVerLogsErrores});
            this.mnVer.Name = "mnVer";
            this.mnVer.Size = new System.Drawing.Size(36, 20);
            this.mnVer.Text = "Ver";
            // 
            // tsmiVerTrazasErrores
            // 
            this.tsmiVerTrazasErrores.Checked = true;
            this.tsmiVerTrazasErrores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiVerTrazasErrores.Name = "tsmiVerTrazasErrores";
            this.tsmiVerTrazasErrores.Size = new System.Drawing.Size(203, 22);
            this.tsmiVerTrazasErrores.Text = "Ver ventana traza errores";
            this.tsmiVerTrazasErrores.Click += new System.EventHandler(this.tsmiVerTrazasErrores_Click);
            // 
            // tsmiVerLogsErrores
            // 
            this.tsmiVerLogsErrores.Checked = true;
            this.tsmiVerLogsErrores.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiVerLogsErrores.Name = "tsmiVerLogsErrores";
            this.tsmiVerLogsErrores.Size = new System.Drawing.Size(203, 22);
            this.tsmiVerLogsErrores.Text = "Ver ventana log errores";
            this.tsmiVerLogsErrores.Click += new System.EventHandler(this.tsmiVerLogsErrores_Click);
            // 
            // mnConfiguracion
            // 
            this.mnConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGeneral});
            this.mnConfiguracion.Name = "mnConfiguracion";
            this.mnConfiguracion.Size = new System.Drawing.Size(95, 20);
            this.mnConfiguracion.Text = "Configuración";
            // 
            // btnGeneral
            // 
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(114, 22);
            this.btnGeneral.Text = "General";
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // tbControles
            // 
            this.tbControles.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tbControles.Controls.Add(this.ultraTabPageControl1);
            this.tbControles.Controls.Add(this.ultraTabPageControl2);
            this.tbControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControles.Location = new System.Drawing.Point(0, 24);
            this.tbControles.Name = "tbControles";
            this.tbControles.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.tbControles.Size = new System.Drawing.Size(1000, 596);
            this.tbControles.TabIndex = 4;
            this.tbControles.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowSizeToFit;
            ultraTab3.AllowClosing = Infragistics.Win.DefaultableBoolean.True;
            ultraTab3.CloseButtonVisibility = Infragistics.Win.UltraWinTabs.TabCloseButtonVisibility.Always;
            ultraTab3.TabPage = this.ultraTabPageControl1;
            ultraTab3.Text = "Trazas";
            ultraTab4.TabPage = this.ultraTabPageControl2;
            ultraTab4.Text = "Logs diferidos";
            this.tbControles.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab4});
            this.tbControles.UseAppStyling = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(996, 570);
            // 
            // cmnTreeView
            // 
            this.cmnTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrirEnPrincipal,
            this.btnAbrirEnOtraPestaña});
            this.cmnTreeView.Name = "cmnTreeView";
            this.cmnTreeView.Size = new System.Drawing.Size(185, 48);
            // 
            // btnAbrirEnPrincipal
            // 
            this.btnAbrirEnPrincipal.Name = "btnAbrirEnPrincipal";
            this.btnAbrirEnPrincipal.Size = new System.Drawing.Size(184, 22);
            this.btnAbrirEnPrincipal.Text = "Abrir en principal";
            this.btnAbrirEnPrincipal.Click += new System.EventHandler(this.btnAbrirEnPrincipal_Click);
            // 
            // btnAbrirEnOtraPestaña
            // 
            this.btnAbrirEnOtraPestaña.Name = "btnAbrirEnOtraPestaña";
            this.btnAbrirEnOtraPestaña.Size = new System.Drawing.Size(184, 22);
            this.btnAbrirEnOtraPestaña.Text = "Abrir en otra pestaña";
            this.btnAbrirEnOtraPestaña.Click += new System.EventHandler(this.btnAbrirEnOtraPestaña_Click);
            // 
            // oVisorTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbControles);
            this.Controls.Add(this.stEstadoApp);
            this.Controls.Add(this.mnPrincipal);
            this.Name = "oVisorTCP";
            this.Size = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.oVisorTCP_Load);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.pnlArbol.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.splitContenedorTrazas.Panel1.ResumeLayout(false);
            this.splitContenedorTrazas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContenedorTrazas)).EndInit();
            this.splitContenedorTrazas.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabDiferido)).EndInit();
            this.tabDiferido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ebArbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stEstadoApp)).EndInit();
            this.mnPrincipal.ResumeLayout(false);
            this.mnPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbControles)).EndInit();
            this.tbControles.ResumeLayout(false);
            this.cmnTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Orbita.Controles.Comunes.OrbitaUltraStatusBar stEstadoApp;
        private Orbita.Controles.Menu.OrbitaMenuStrip mnPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnVer;
        private System.Windows.Forms.ToolStripMenuItem mnConfiguracion;
        private Orbita.Controles.Contenedores.OrbitaUltraTabControl tbControles;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerTrazasErrores;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerLogsErrores;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Orbita.Controles.Contenedores.OrbitaSplitContainer splitContenedorTrazas;
        private Orbita.Controles.Grid.OrbitaUltraGridToolBar gridTrazas;
        private Orbita.Controles.Grid.OrbitaUltraGridToolBar gridTrazasError;
        private Orbita.Controles.Menu.OrbitaUltraExplorerBar ebArbol;
        private System.Windows.Forms.ToolStripMenuItem btnGeneral;
        private System.Windows.Forms.ImageList imgArbol;
        private Infragistics.Win.Misc.UltraSplitter spl;
        private Orbita.Controles.Contenedores.OrbitaUltraTabControl tabDiferido;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private OrbitaVisorDiferido oVisorDiferido1;
        private Orbita.Controles.Contenedores.OrbitaPanel pnlArbol;
        private System.Windows.Forms.TreeView ArbolLogs;
        private System.Windows.Forms.ContextMenuStrip cmnTreeView;
        private System.Windows.Forms.ToolStripMenuItem btnAbrirEnOtraPestaña;
        private System.Windows.Forms.ToolStripMenuItem btnAbrirEnPrincipal;

    }
}
