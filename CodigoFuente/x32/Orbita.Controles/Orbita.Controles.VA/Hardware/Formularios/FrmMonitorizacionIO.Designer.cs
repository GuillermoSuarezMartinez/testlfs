namespace Orbita.Controles.VA
{
    partial class FrmMonitorizacionIO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("ToolbarGeneral");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnMonitorizar = new Infragistics.Win.UltraWinToolbars.ButtonTool("Monitorizar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool MenuVistas = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Vistas");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnIconosGrandes = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosGrandes");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnIconosPequeños = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosPequeños");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnLista = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyLista");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnDetalles = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyDetalles");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Vistas");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosGrandes");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosPequeños");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyLista");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyDetalles");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Monitorizar");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.TimerRefresco = new System.Windows.Forms.Timer(this.components);
            this.ImageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.ImageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.ToolbarsManager = new Orbita.Controles.Menu.OrbitaUltraToolbarsManager(this.components);
            this._FrmBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FrmBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FrmBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FrmBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.grbPrincipal = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.ListView = new Orbita.Controles.Comunes.OrbitaListView();
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Habilitado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbPrincipal)).BeginInit();
            this.grbPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.grbPrincipal);
            this.PnlPanelPrincipalPadre.Location = new System.Drawing.Point(10, 53);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(772, 360);
            // 
            // btnCancelar
            // 
            this.btnCancelar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 33);
            // 
            // TimerRefresco
            // 
            this.TimerRefresco.Interval = 250;
            this.TimerRefresco.Tick += new System.EventHandler(this.timerRefresco_Tick);
            // 
            // ImageListSmall
            // 
            this.ImageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageListSmall.ImageSize = new System.Drawing.Size(24, 24);
            this.ImageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImageListLarge
            // 
            this.ImageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageListLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ImageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ToolbarsManager
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolbarsManager.Appearance = appearance1;
            this.ToolbarsManager.DesignerFlags = 1;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.DockWithinContainerBaseType = typeof(Orbita.Controles.VA.FrmBase);
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            MenuVistas.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            BtnMonitorizar,
            MenuVistas});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Text = "ToolbarGeneral";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            BtnIconosGrandes.SharedPropsInternal.Caption = "Iconos grandes";
            BtnIconosPequeños.SharedPropsInternal.Caption = "Iconos pequeños";
            BtnLista.SharedPropsInternal.Caption = "Lista";
            BtnDetalles.SharedPropsInternal.Caption = "Detalles";
            appearance2.Image = global::Orbita.Controles.VA.Properties.Resources.imgVistasVariables24;
            popupMenuTool1.Settings.Appearance = appearance2;
            popupMenuTool1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyInMenus;
            popupMenuTool1.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.False;
            appearance3.Image = global::Orbita.Controles.VA.Properties.Resources.imgVistasVariables24;
            popupMenuTool1.SharedPropsInternal.AppearancesLarge.Appearance = appearance3;
            appearance4.Image = global::Orbita.Controles.VA.Properties.Resources.imgVistasVariables24;
            popupMenuTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance4;
            popupMenuTool1.SharedPropsInternal.Caption = "Vistas";
            popupMenuTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            appearance5.Image = global::Orbita.Controles.VA.Properties.Resources.ImgLupa24;
            buttonTool10.SharedPropsInternal.AppearancesLarge.Appearance = appearance5;
            buttonTool10.SharedPropsInternal.Caption = "Monitorizar";
            buttonTool10.SharedPropsInternal.CustomizerCaption = "Monitorizar";
            buttonTool10.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            BtnIconosGrandes,
            BtnIconosPequeños,
            BtnLista,
            BtnDetalles,
            popupMenuTool1,
            buttonTool10});
            this.ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager_ToolClick);
            // 
            // _FrmBase_Toolbars_Dock_Area_Top
            // 
            this._FrmBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._FrmBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._FrmBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(10, 10);
            this._FrmBase_Toolbars_Dock_Area_Top.Name = "_FrmBase_Toolbars_Dock_Area_Top";
            this._FrmBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(772, 43);
            this._FrmBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _FrmBase_Toolbars_Dock_Area_Bottom
            // 
            this._FrmBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._FrmBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._FrmBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(10, 456);
            this._FrmBase_Toolbars_Dock_Area_Bottom.Name = "_FrmBase_Toolbars_Dock_Area_Bottom";
            this._FrmBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(772, 0);
            this._FrmBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // _FrmBase_Toolbars_Dock_Area_Left
            // 
            this._FrmBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._FrmBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._FrmBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(10, 53);
            this._FrmBase_Toolbars_Dock_Area_Left.Name = "_FrmBase_Toolbars_Dock_Area_Left";
            this._FrmBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 403);
            this._FrmBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // _FrmBase_Toolbars_Dock_Area_Right
            // 
            this._FrmBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._FrmBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._FrmBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(782, 53);
            this._FrmBase_Toolbars_Dock_Area_Right.Name = "_FrmBase_Toolbars_Dock_Area_Right";
            this._FrmBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 403);
            this._FrmBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager;
            // 
            // grbPrincipal
            // 
            this.grbPrincipal.ContentPadding.Bottom = 2;
            this.grbPrincipal.ContentPadding.Left = 2;
            this.grbPrincipal.ContentPadding.Right = 2;
            this.grbPrincipal.ContentPadding.Top = 2;
            this.grbPrincipal.Controls.Add(this.ListView);
            this.grbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPrincipal.Location = new System.Drawing.Point(0, 0);
            this.grbPrincipal.Name = "grbPrincipal";
            this.grbPrincipal.Size = new System.Drawing.Size(772, 360);
            this.grbPrincipal.TabIndex = 2;
            this.grbPrincipal.Text = "Listado de elementos";
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.Valor,
            this.Descripcion,
            this.Habilitado,
            this.Tipo});
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.LargeImageList = this.ImageListLarge;
            this.ListView.Location = new System.Drawing.Point(5, 17);
            this.ListView.Name = "ListView";
            this.ListView.ShowItemToolTips = true;
            this.ListView.Size = new System.Drawing.Size(762, 338);
            this.ListView.SmallImageList = this.ImageListSmall;
            this.ListView.TabIndex = 16;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            // 
            // Codigo
            // 
            this.Codigo.Text = "Código";
            this.Codigo.Width = 150;
            // 
            // Valor
            // 
            this.Valor.Text = "Valor";
            this.Valor.Width = 180;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripción";
            this.Descripcion.Width = 450;
            // 
            // Habilitado
            // 
            this.Habilitado.Text = "Habilitado";
            this.Habilitado.Width = 110;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo Terminal";
            this.Tipo.Width = 110;
            // 
            // FrmMonitorizacionIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Top);
            this.Name = "FrmMonitorizacionIO";
            this.Text = "Monitorización de Entradas / Salidas";
            this.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Top, 0);
            this.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Bottom, 0);
            this.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Right, 0);
            this.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Left, 0);
            this.Controls.SetChildIndex(this.PnlInferiorPadre, 0);
            this.Controls.SetChildIndex(this.PnlPanelPrincipalPadre, 0);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbPrincipal)).EndInit();
            this.grbPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Timer TimerRefresco;
        protected System.Windows.Forms.ImageList ImageListSmall;
        protected System.Windows.Forms.ImageList ImageListLarge;
        protected Menu.OrbitaUltraToolbarsManager ToolbarsManager;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Top;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Bottom;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Left;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Right;
        protected Contenedores.OrbitaUltraGroupBox grbPrincipal;
        protected Comunes.OrbitaListView ListView;
        protected System.Windows.Forms.ColumnHeader Codigo;
        protected System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader Valor;
        private System.Windows.Forms.ColumnHeader Habilitado;
        private System.Windows.Forms.ColumnHeader Tipo;
    }
}