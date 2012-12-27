namespace Orbita.Controles.Gantt
{
    partial class OrbitaGantt
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
            Orbita.Controles.Gantt.OColumnHeaderCollection oColumnHeaderCollection1 = new Orbita.Controles.Gantt.OColumnHeaderCollection();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGantt));
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("OrbToolbarArriba");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Volver");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Ampliar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reducir");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Volver");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Ampliar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reducir");
            this.OrbitaGanttPro_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.orbitaGantt1 = new Orbita.Controles.Gantt.OrbitaUltraGanttView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.OrbitaUltraToolbarsManager1 = new Orbita.Controles.Menu.OrbitaUltraToolBarsManager(this.components);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.OrbitaGanttPro_Fill_Panel.ClientArea.SuspendLayout();
            this.OrbitaGanttPro_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orbitaGantt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrbitaUltraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // OrbitaGanttPro_Fill_Panel
            // 
            // 
            // OrbitaGanttPro_Fill_Panel.ClientArea
            // 
            this.OrbitaGanttPro_Fill_Panel.ClientArea.Controls.Add(this.orbitaGantt1);
            this.OrbitaGanttPro_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.OrbitaGanttPro_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrbitaGanttPro_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.OrbitaGanttPro_Fill_Panel.Name = "OrbitaGanttPro_Fill_Panel";
            this.OrbitaGanttPro_Fill_Panel.Size = new System.Drawing.Size(677, 403);
            this.OrbitaGanttPro_Fill_Panel.TabIndex = 0;
            // 
            // orbitaGantt1
            // 
            this.orbitaGantt1.AutoDisplayDefaultContextMenu = Infragistics.Win.UltraWinGanttView.AutoDisplayDefaultContextMenu.No;
            this.orbitaGantt1.AutoDisplayTaskDialog = Infragistics.Win.UltraWinGanttView.AutoDisplayTaskDialog.No;
            oColumnHeaderCollection1.Comentarios = null;
            oColumnHeaderCollection1.Completado = null;
            oColumnHeaderCollection1.Descripcion = null;
            oColumnHeaderCollection1.Duracion = null;
            oColumnHeaderCollection1.Fin = null;
            oColumnHeaderCollection1.Info1 = null;
            oColumnHeaderCollection1.Info2 = null;
            oColumnHeaderCollection1.Info3 = null;
            oColumnHeaderCollection1.Info4 = null;
            oColumnHeaderCollection1.Info5 = null;
            oColumnHeaderCollection1.Info6 = null;
            oColumnHeaderCollection1.Info7 = null;
            oColumnHeaderCollection1.Info8 = null;
            oColumnHeaderCollection1.Info9 = null;
            oColumnHeaderCollection1.Inicio = null;
            oColumnHeaderCollection1.Limite = null;
            this.orbitaGantt1.Columnas = oColumnHeaderCollection1;
            this.orbitaGantt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Constraint").VisiblePosition = 6;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("ConstraintDateTime").VisiblePosition = 7;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Dependencies").VisiblePosition = 4;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Deadline").VisiblePosition = 8;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Duration").VisiblePosition = 1;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("EndDateTime").VisiblePosition = 3;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Milestone").VisiblePosition = 9;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Name").VisiblePosition = 0;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Notes").VisiblePosition = 10;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("PercentComplete").VisiblePosition = 11;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("Resources").VisiblePosition = 5;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("StartDateTime").VisiblePosition = 2;
            this.orbitaGantt1.GridSettings.ColumnSettings.GetValue("RowNumber").VisiblePosition = 12;
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.orbitaGantt1.GridSettings.RowAppearance = appearance1;
            this.orbitaGantt1.Location = new System.Drawing.Point(0, 0);
            this.orbitaGantt1.Name = "orbitaGantt1";
            this.orbitaGantt1.Resolucion = Orbita.Controles.Gantt.Resoluciones.Dia;
            this.orbitaGantt1.Size = new System.Drawing.Size(677, 403);
            this.orbitaGantt1.TabIndex = 0;
            this.orbitaGantt1.TaskSettings.AllowAddNew = Infragistics.Win.DefaultableBoolean.False;
            this.orbitaGantt1.TaskSettings.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.orbitaGantt1.TaskSettings.AllowEditDeadline = Infragistics.Win.DefaultableBoolean.False;
            this.orbitaGantt1.TaskSettings.AllowEditDuration = Infragistics.Win.DefaultableBoolean.False;
            this.orbitaGantt1.TaskSettings.AllowEditPercentComplete = Infragistics.Win.DefaultableBoolean.False;
            this.orbitaGantt1.TaskSettings.AllowEditStartDateTime = Infragistics.Win.DefaultableBoolean.False;
            this.orbitaGantt1.TaskSettings.ReadOnly = Infragistics.Win.DefaultableBoolean.True;
            this.orbitaGantt1.Text = "orbitaGantt1";
            this.orbitaGantt1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.orbitaGantt1.VerticalSplitterMinimumResizeWidth = 10;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Empty;
            this.imageList.Images.SetKeyName(0, "go-previous.png");
            // 
            // _OrbitaGanttPro_Toolbars_Dock_Area_Left
            // 
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.Name = "_OrbitaGanttPro_Toolbars_Dock_Area_Left";
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 403);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Left.ToolbarsManager = this.OrbitaUltraToolbarsManager1;
            // 
            // OrbitaUltraToolbarsManager1
            // 
            this.OrbitaUltraToolbarsManager1.DesignerFlags = 1;
            this.OrbitaUltraToolbarsManager1.DockWithinContainer = this;
            this.OrbitaUltraToolbarsManager1.ImageListSmall = this.imageList;
            this.OrbitaUltraToolbarsManager1.ShowQuickCustomizeButton = false;
            this.OrbitaUltraToolbarsManager1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool3,
            buttonTool4});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            ultraToolbar1.Settings.Appearance = appearance2;
            ultraToolbar1.Settings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Settings.GrabHandleStyle = Infragistics.Win.UltraWinToolbars.GrabHandleStyle.None;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "OrbToolbarArriba";
            this.OrbitaUltraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.OrbitaUltraToolbarsManager1.ToolbarSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.Image = 0;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance3;
            buttonTool2.SharedPropsInternal.Caption = "V&olver";
            buttonTool5.SharedPropsInternal.Caption = "Ampliar";
            buttonTool6.SharedPropsInternal.Caption = "Reducir";
            this.OrbitaUltraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool5,
            buttonTool6});
            this.OrbitaUltraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.OrbitaUltraToolbarsManager1_ToolClick);
            // 
            // _OrbitaGanttPro_Toolbars_Dock_Area_Right
            // 
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(677, 27);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.Name = "_OrbitaGanttPro_Toolbars_Dock_Area_Right";
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 403);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Right.ToolbarsManager = this.OrbitaUltraToolbarsManager1;
            // 
            // _OrbitaGanttPro_Toolbars_Dock_Area_Bottom
            // 
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 430);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.Name = "_OrbitaGanttPro_Toolbars_Dock_Area_Bottom";
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(677, 0);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.OrbitaUltraToolbarsManager1;
            // 
            // _OrbitaGanttPro_Toolbars_Dock_Area_Top
            // 
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.Name = "_OrbitaGanttPro_Toolbars_Dock_Area_Top";
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(677, 27);
            this._OrbitaGanttPro_Toolbars_Dock_Area_Top.ToolbarsManager = this.OrbitaUltraToolbarsManager1;
            // 
            // OrbitaGantt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OrbitaGanttPro_Fill_Panel);
            this.Controls.Add(this._OrbitaGanttPro_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._OrbitaGanttPro_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._OrbitaGanttPro_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._OrbitaGanttPro_Toolbars_Dock_Area_Top);
            this.Name = "OrbitaGantt";
            this.Size = new System.Drawing.Size(677, 430);
            this.OrbitaGanttPro_Fill_Panel.ClientArea.ResumeLayout(false);
            this.OrbitaGanttPro_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orbitaGantt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrbitaUltraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        OrbitaUltraGanttView orbitaGantt1;
        Orbita.Controles.Menu.OrbitaUltraToolBarsManager OrbitaUltraToolbarsManager1;
        Infragistics.Win.Misc.UltraPanel OrbitaGanttPro_Fill_Panel;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGanttPro_Toolbars_Dock_Area_Left;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGanttPro_Toolbars_Dock_Area_Right;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGanttPro_Toolbars_Dock_Area_Bottom;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaGanttPro_Toolbars_Dock_Area_Top;
        System.Windows.Forms.ImageList imageList;
    }
}
