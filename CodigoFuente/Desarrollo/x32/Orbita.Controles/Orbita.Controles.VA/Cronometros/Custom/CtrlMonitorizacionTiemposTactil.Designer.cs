namespace Orbita.Controles.VA
{
    partial class CtrlMonitorizacionTiemposTactil
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("ToolbarGeneral");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Monitorizar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool MenuVistas = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Vistas");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnIconosGrandes = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosGrandes");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnIconosPequeños = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosPequeños");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnLista = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyLista");
            Infragistics.Win.UltraWinToolbars.ButtonTool BtnDetalles = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyDetalles");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Vistas");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosGrandes");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyIconosPequeños");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyLista");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KeyDetalles");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Monitorizar");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this._FrmBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ToolbarsManager = new Orbita.Controles.Menu.OrbitaUltraToolbarsManager(this.components);
            this.ListView = new Orbita.Controles.Comunes.OrbitaListView();
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Contador = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UltimaEjecucion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Promedio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.ImageListSmall = new System.Windows.Forms.ImageList(this.components);
            this._FrmBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FrmBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FrmBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.PnlFondo = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.grbPrincipal = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.TimerRefresco = new System.Windows.Forms.Timer(this.components);
            this.PnlSuperiorPadre.SuspendLayout();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            this.PnlFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbPrincipal)).BeginInit();
            this.grbPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlSuperiorPadre
            // 
            this.PnlSuperiorPadre.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Right);
            this.PnlSuperiorPadre.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Top);
            this.PnlSuperiorPadre.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Bottom);
            this.PnlSuperiorPadre.Controls.Add(this._FrmBase_Toolbars_Dock_Area_Left);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this.PicIcono, 0);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this.LblMensaje, 0);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this.PnlBotonesPadre, 0);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Left, 0);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Bottom, 0);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Top, 0);
            this.PnlSuperiorPadre.Controls.SetChildIndex(this._FrmBase_Toolbars_Dock_Area_Right, 0);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.PnlFondo);
            // 
            // LblMensaje
            // 
            this.LblMensaje.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblMensaje.Size = new System.Drawing.Size(263, 43);
            this.LblMensaje.Text = "Monitor de cronómetros";
            // 
            // PicIcono
            // 
            this.PicIcono.BackgroundImage = global::Orbita.Controles.VA.Properties.Resources.ImgCronometro24;
            // 
            // _FrmBase_Toolbars_Dock_Area_Right
            // 
            this._FrmBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent;
            this._FrmBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._FrmBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(590, 43);
            this._FrmBase_Toolbars_Dock_Area_Right.Name = "_FrmBase_Toolbars_Dock_Area_Right";
            this._FrmBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 0);
            this._FrmBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager;
            // 
            // ToolbarsManager
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ToolbarsManager.Appearance = appearance1;
            this.ToolbarsManager.DesignerFlags = 1;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.LockToolbars = true;
            this.ToolbarsManager.MdiMergeable = false;
            this.ToolbarsManager.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Unfold;
            this.ToolbarsManager.Office2007UICompatibility = false;
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            this.ToolbarsManager.ShowMenuShadows = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            MenuVistas});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            appearance2.FontData.SizeInPoints = 12F;
            appearance2.ForeColor = System.Drawing.Color.WhiteSmoke;
            ultraToolbar1.Settings.Appearance = appearance2;
            ultraToolbar1.Settings.PaddingBottom = 0;
            ultraToolbar1.Settings.PaddingLeft = 0;
            ultraToolbar1.Settings.PaddingRight = 0;
            ultraToolbar1.Settings.PaddingTop = 0;
            ultraToolbar1.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.True;
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            BtnIconosGrandes.SharedPropsInternal.Caption = "Iconos grandes";
            BtnIconosPequeños.SharedPropsInternal.Caption = "Iconos pequeños";
            BtnLista.SharedPropsInternal.Caption = "Lista";
            BtnDetalles.SharedPropsInternal.Caption = "Detalles";
            appearance3.Image = global::Orbita.Controles.VA.Properties.Resources.ImgVistas24;
            popupMenuTool1.Settings.Appearance = appearance3;
            popupMenuTool1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyInMenus;
            popupMenuTool1.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.False;
            appearance4.Image = global::Orbita.Controles.VA.Properties.Resources.ImgVistas24;
            popupMenuTool1.SharedPropsInternal.AppearancesLarge.Appearance = appearance4;
            appearance5.Image = global::Orbita.Controles.VA.Properties.Resources.ImgVistas24;
            popupMenuTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            popupMenuTool1.SharedPropsInternal.Caption = "Vistas";
            popupMenuTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            appearance6.Image = global::Orbita.Controles.VA.Properties.Resources.ImgZoom24;
            buttonTool10.SharedPropsInternal.AppearancesLarge.Appearance = appearance6;
            appearance7.Image = global::Orbita.Controles.VA.Properties.Resources.ImgZoom24;
            buttonTool10.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
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
            this.ToolbarsManager.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.Descripcion,
            this.Contador,
            this.UltimaEjecucion,
            this.Promedio,
            this.Total});
            this.ToolbarsManager.SetContextMenuUltra(this.ListView, "Acciones");
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.LargeImageList = this.ImageListLarge;
            this.ListView.Location = new System.Drawing.Point(3, 24);
            this.ListView.Name = "ListView";
            this.ListView.ShowItemToolTips = true;
            this.ListView.Size = new System.Drawing.Size(660, 286);
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
            // Descripcion
            // 
            this.Descripcion.Text = "Descripción";
            this.Descripcion.Width = 450;
            // 
            // Contador
            // 
            this.Contador.Text = "Contador";
            this.Contador.Width = 65;
            // 
            // UltimaEjecucion
            // 
            this.UltimaEjecucion.Text = "Última Ejecución";
            this.UltimaEjecucion.Width = 105;
            // 
            // Promedio
            // 
            this.Promedio.Text = "Promedio";
            this.Promedio.Width = 105;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 105;
            // 
            // ImageListLarge
            // 
            this.ImageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageListLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ImageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImageListSmall
            // 
            this.ImageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageListSmall.ImageSize = new System.Drawing.Size(24, 24);
            this.ImageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // _FrmBase_Toolbars_Dock_Area_Top
            // 
            this._FrmBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent;
            this._FrmBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._FrmBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(303, 0);
            this._FrmBase_Toolbars_Dock_Area_Top.Name = "_FrmBase_Toolbars_Dock_Area_Top";
            this._FrmBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(287, 43);
            this._FrmBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _FrmBase_Toolbars_Dock_Area_Bottom
            // 
            this._FrmBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent;
            this._FrmBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._FrmBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(303, 43);
            this._FrmBase_Toolbars_Dock_Area_Bottom.Name = "_FrmBase_Toolbars_Dock_Area_Bottom";
            this._FrmBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(287, 0);
            this._FrmBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // _FrmBase_Toolbars_Dock_Area_Left
            // 
            this._FrmBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FrmBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent;
            this._FrmBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._FrmBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FrmBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(303, 0);
            this._FrmBase_Toolbars_Dock_Area_Left.Name = "_FrmBase_Toolbars_Dock_Area_Left";
            this._FrmBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 43);
            this._FrmBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // PnlFondo
            // 
            this.PnlFondo.Controls.Add(this.grbPrincipal);
            this.PnlFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlFondo.Location = new System.Drawing.Point(0, 0);
            this.PnlFondo.Name = "PnlFondo";
            this.PnlFondo.Padding = new System.Windows.Forms.Padding(2);
            this.PnlFondo.Size = new System.Drawing.Size(670, 317);
            this.PnlFondo.TabIndex = 0;
            // 
            // grbPrincipal
            // 
            this.grbPrincipal.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grbPrincipal.ContentAreaAppearance = appearance8;
            this.grbPrincipal.ContentPadding.Bottom = 1;
            this.grbPrincipal.ContentPadding.Left = 1;
            this.grbPrincipal.ContentPadding.Right = 1;
            this.grbPrincipal.ContentPadding.Top = 1;
            this.grbPrincipal.Controls.Add(this.ListView);
            this.grbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPrincipal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPrincipal.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grbPrincipal.HeaderAppearance = appearance9;
            this.grbPrincipal.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder;
            this.grbPrincipal.Location = new System.Drawing.Point(2, 2);
            this.grbPrincipal.Margin = new System.Windows.Forms.Padding(7);
            this.grbPrincipal.Name = "grbPrincipal";
            this.grbPrincipal.Size = new System.Drawing.Size(666, 313);
            this.grbPrincipal.TabIndex = 2;
            this.grbPrincipal.Text = "Listado de elementos";
            // 
            // TimerRefresco
            // 
            this.TimerRefresco.Interval = 250;
            this.TimerRefresco.Tick += new System.EventHandler(this.timerRefresco_Tick);
            // 
            // CtrlMonitorizacionTiemposTactil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CtrlMonitorizacionTiemposTactil";
            this.Titulo = "Monitor de cronómetros";
            this.PnlSuperiorPadre.ResumeLayout(false);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            this.PnlFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbPrincipal)).EndInit();
            this.grbPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Right;
        protected Menu.OrbitaUltraToolbarsManager ToolbarsManager;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Top;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Bottom;
        protected Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FrmBase_Toolbars_Dock_Area_Left;
        protected System.Windows.Forms.ImageList ImageListSmall;
        protected System.Windows.Forms.ImageList ImageListLarge;
        private Contenedores.OrbitaPanel PnlFondo;
        protected Contenedores.OrbitaUltraGroupBox grbPrincipal;
        protected Comunes.OrbitaListView ListView;
        protected System.Windows.Forms.ColumnHeader Codigo;
        protected System.Windows.Forms.ColumnHeader Descripcion;
        protected System.Windows.Forms.Timer TimerRefresco;
        private System.Windows.Forms.ColumnHeader Contador;
        private System.Windows.Forms.ColumnHeader UltimaEjecucion;
        private System.Windows.Forms.ColumnHeader Promedio;
        private System.Windows.Forms.ColumnHeader Total;
    }
}
