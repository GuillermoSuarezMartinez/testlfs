namespace Orbita.Controles.Editor
{
    partial class OrbitaTextEditor
    {
        /// <summary> 
        /// Variable del dise�ador requerida.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.rtbDoc.TextChanged -= new System.EventHandler(this.RtbTextChanged);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region C�digo generado por el Dise�ador de componentes
        /// <summary> 
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar el contenido del m�todo con el editor de c�digo.
        /// </summary>
        void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("tlbOrbitaTextEditorPro");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Abrir");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guardar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Fuente");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Negrita", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Cursiva", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Subrayado", "");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Color Fuente");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Color Marcador");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insertar Imagen");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Izquierda", "Align");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Centrado", "Align");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool6 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Derecha", "Align");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool7 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Justificado", "Align");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Vinetas");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Aumentar Sangria");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Disminuir Sangria");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Vinetas");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Aumentar Sangria");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Disminuir Sangria");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool8 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Negrita", "");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool9 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Cursiva", "");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool10 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Subrayado", "");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool11 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Izquierda", "Align");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool12 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Centrado", "Align");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool13 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Derecha", "Align");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool14 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Justificado", "Align");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Abrir");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guardar");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Fuente");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Color Fuente");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Color Marcador");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insertar Imagen");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaTextEditor));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tlbOrbitaTextEditor = new Orbita.Controles.Menu.OrbitaUltraToolBarsManager(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this._OrbitaUserControl_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaUserControl_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaUserControl_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.rtbDoc = new Orbita.Controles.Editor.OrbitaRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tlbOrbitaTextEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbOrbitaTextEditor
            // 
            this.tlbOrbitaTextEditor.DesignerFlags = 1;
            this.tlbOrbitaTextEditor.DockWithinContainer = this;
            this.tlbOrbitaTextEditor.ImageListSmall = this.imageList;
            this.tlbOrbitaTextEditor.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            stateButtonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            stateButtonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool7.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool19,
            buttonTool2,
            buttonTool3,
            stateButtonTool1,
            stateButtonTool2,
            stateButtonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            stateButtonTool4,
            stateButtonTool5,
            stateButtonTool6,
            stateButtonTool7,
            buttonTool7,
            buttonTool8,
            buttonTool9});
            ultraToolbar1.Text = "Men� principal";
            this.tlbOrbitaTextEditor.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            appearance1.Image = 13;
            buttonTool10.SharedPropsInternal.AppearancesSmall.Appearance = appearance1;
            buttonTool10.SharedPropsInternal.Caption = "&Vi�etas";
            appearance2.Image = 14;
            buttonTool11.SharedPropsInternal.AppearancesSmall.Appearance = appearance2;
            buttonTool11.SharedPropsInternal.Caption = "&Aumentar Sangria";
            appearance3.Image = 15;
            buttonTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance3;
            buttonTool12.SharedPropsInternal.Caption = "Dis&minuir Sangria";
            appearance4.Image = 3;
            stateButtonTool8.SharedPropsInternal.AppearancesSmall.Appearance = appearance4;
            stateButtonTool8.SharedPropsInternal.Caption = "&Negrita";
            appearance5.Image = 4;
            stateButtonTool9.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            stateButtonTool9.SharedPropsInternal.Caption = "&Cursiva";
            appearance6.Image = 5;
            stateButtonTool10.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            stateButtonTool10.SharedPropsInternal.Caption = "&Subrayado";
            stateButtonTool11.OptionSetKey = "Align";
            appearance7.Image = 9;
            stateButtonTool11.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            stateButtonTool11.SharedPropsInternal.Caption = "Iz&quierda";
            stateButtonTool12.OptionSetKey = "Align";
            appearance8.Image = 10;
            stateButtonTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            stateButtonTool12.SharedPropsInternal.Caption = "&Centrado";
            stateButtonTool13.OptionSetKey = "Align";
            appearance9.Image = 11;
            stateButtonTool13.SharedPropsInternal.AppearancesSmall.Appearance = appearance9;
            stateButtonTool13.SharedPropsInternal.Caption = "&Derecha";
            stateButtonTool14.OptionSetKey = "Align";
            appearance10.Image = 12;
            stateButtonTool14.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
            stateButtonTool14.SharedPropsInternal.Caption = "&Justificado";
            appearance11.Image = 0;
            buttonTool13.SharedPropsInternal.AppearancesSmall.Appearance = appearance11;
            buttonTool13.SharedPropsInternal.Caption = "&Abrir";
            appearance12.Image = 1;
            buttonTool14.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
            buttonTool14.SharedPropsInternal.Caption = "&Guardar";
            appearance13.Image = 2;
            buttonTool15.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
            buttonTool15.SharedPropsInternal.Caption = "&Fuente";
            appearance14.Image = 6;
            buttonTool16.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool16.SharedPropsInternal.Caption = "C&olor Fuente";
            appearance15.Image = 7;
            buttonTool17.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool17.SharedPropsInternal.Caption = "Color &Marcador";
            appearance16.Image = 8;
            buttonTool18.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool18.SharedPropsInternal.Caption = "Insertar Ima&gen";
            this.tlbOrbitaTextEditor.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12,
            stateButtonTool8,
            stateButtonTool9,
            stateButtonTool10,
            stateButtonTool11,
            stateButtonTool12,
            stateButtonTool13,
            stateButtonTool14,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18});
            this.tlbOrbitaTextEditor.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.OrbitaUltraToolbarsManager1_ToolClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "open.bmp");
            this.imageList.Images.SetKeyName(1, "save.bmp");
            this.imageList.Images.SetKeyName(2, "font.bmp");
            this.imageList.Images.SetKeyName(3, "bold.bmp");
            this.imageList.Images.SetKeyName(4, "italic.bmp");
            this.imageList.Images.SetKeyName(5, "underscore.bmp");
            this.imageList.Images.SetKeyName(6, "fontcolor.bmp");
            this.imageList.Images.SetKeyName(7, "backcolor.bmp");
            this.imageList.Images.SetKeyName(8, "image.bmp");
            this.imageList.Images.SetKeyName(9, "left.bmp");
            this.imageList.Images.SetKeyName(10, "center.bmp");
            this.imageList.Images.SetKeyName(11, "right.bmp");
            this.imageList.Images.SetKeyName(12, "justify.bmp");
            this.imageList.Images.SetKeyName(13, "btnUol.bmp");
            this.imageList.Images.SetKeyName(14, "indent.bmp");
            this.imageList.Images.SetKeyName(15, "outdent.bmp");
            this.imageList.Images.SetKeyName(16, "oi.bmp");
            // 
            // _OrbitaUserControl_Toolbars_Dock_Area_Left
            // 
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.Name = "_OrbitaUserControl_Toolbars_Dock_Area_Left";
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 123);
            this._OrbitaUserControl_Toolbars_Dock_Area_Left.ToolbarsManager = this.tlbOrbitaTextEditor;
            // 
            // _OrbitaUserControl_Toolbars_Dock_Area_Right
            // 
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(594, 27);
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.Name = "_OrbitaUserControl_Toolbars_Dock_Area_Right";
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 123);
            this._OrbitaUserControl_Toolbars_Dock_Area_Right.ToolbarsManager = this.tlbOrbitaTextEditor;
            // 
            // _OrbitaUserControl_Toolbars_Dock_Area_Top
            // 
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.Name = "_OrbitaUserControl_Toolbars_Dock_Area_Top";
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(594, 27);
            this._OrbitaUserControl_Toolbars_Dock_Area_Top.ToolbarsManager = this.tlbOrbitaTextEditor;
            // 
            // _OrbitaUserControl_Toolbars_Dock_Area_Bottom
            // 
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 150);
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.Name = "_OrbitaUserControl_Toolbars_Dock_Area_Bottom";
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(594, 0);
            this._OrbitaUserControl_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tlbOrbitaTextEditor;
            // 
            // rtbDoc
            // 
            this.rtbDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDoc.Location = new System.Drawing.Point(0, 27);
            this.rtbDoc.Name = "rtbDoc";
            this.rtbDoc.Size = new System.Drawing.Size(594, 123);
            this.rtbDoc.TabIndex = 11;
            this.rtbDoc.Text = "";
            this.rtbDoc.ReadOnlyChanged += new System.EventHandler(this.Evento_ReadOnly);
            this.rtbDoc.TextChanged += new System.EventHandler(this.RtbTextChanged);
            // 
            // OrbitaTextEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.rtbDoc);
            this.Controls.Add(this._OrbitaUserControl_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._OrbitaUserControl_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._OrbitaUserControl_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._OrbitaUserControl_Toolbars_Dock_Area_Top);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrbitaTextEditor";
            this.Size = new System.Drawing.Size(594, 150);
            ((System.ComponentModel.ISupportInitialize)(this.tlbOrbitaTextEditor)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        internal System.Windows.Forms.OpenFileDialog openFileDialog;
        internal System.Windows.Forms.ColorDialog colorDialog;
        internal System.Windows.Forms.FontDialog fontDialog;
        internal System.Windows.Forms.SaveFileDialog saveFileDialog;
        Orbita.Controles.Menu.OrbitaUltraToolBarsManager tlbOrbitaTextEditor;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaUserControl_Toolbars_Dock_Area_Left;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaUserControl_Toolbars_Dock_Area_Right;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaUserControl_Toolbars_Dock_Area_Top;
        Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaUserControl_Toolbars_Dock_Area_Bottom;
        System.Windows.Forms.ImageList imageList;
        OrbitaRichTextBox rtbDoc;
    }
}
