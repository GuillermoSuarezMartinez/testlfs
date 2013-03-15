namespace Orbita.Test
{
    partial class Form2
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            this.orbitaUltraGridToolBar1 = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            this.button1 = new System.Windows.Forms.Button();
            this.orbitaUltraToolbarsManager1 = new Orbita.Controles.Menu.OrbitaUltraToolbarsManager(this.components);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.orbitaUltraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // orbitaUltraGridToolBar1
            // 
            this.orbitaUltraGridToolBar1.Location = new System.Drawing.Point(36, 89);
            this.orbitaUltraGridToolBar1.Name = "orbitaUltraGridToolBar1";
            this.orbitaUltraGridToolBar1.OI.CampoPosicionable = null;
            this.orbitaUltraGridToolBar1.OI.Filas.TipoSeleccion = null;
            this.orbitaUltraGridToolBar1.OI.MostrarToolCiclico = true;
            this.orbitaUltraGridToolBar1.Size = new System.Drawing.Size(410, 175);
            this.orbitaUltraGridToolBar1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.orbitaUltraButton1_Click);
            // 
            // orbitaUltraToolbarsManager1
            // 
            this.orbitaUltraToolbarsManager1.DesignerFlags = 1;
            this.orbitaUltraToolbarsManager1.DockWithinContainer = this;
            this.orbitaUltraToolbarsManager1.DockWithinContainerBaseType = typeof(Orbita.Controles.Contenedores.OrbitaMdiContainerForm);
            this.orbitaUltraToolbarsManager1.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "UltraToolbar1";
            this.orbitaUltraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            // 
            // _OrbitaMdiForm_Toolbars_Dock_Area_Left
            // 
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 23);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.Name = "_OrbitaMdiForm_Toolbars_Dock_Area_Left";
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 410);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.orbitaUltraToolbarsManager1;
            // 
            // _OrbitaMdiForm_Toolbars_Dock_Area_Right
            // 
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(482, 23);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.Name = "_OrbitaMdiForm_Toolbars_Dock_Area_Right";
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 410);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.orbitaUltraToolbarsManager1;
            // 
            // _OrbitaMdiForm_Toolbars_Dock_Area_Top
            // 
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.Name = "_OrbitaMdiForm_Toolbars_Dock_Area_Top";
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(482, 23);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.orbitaUltraToolbarsManager1;
            // 
            // _OrbitaMdiForm_Toolbars_Dock_Area_Bottom
            // 
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 433);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.Name = "_OrbitaMdiForm_Toolbars_Dock_Area_Bottom";
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(482, 0);
            this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.orbitaUltraToolbarsManager1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 433);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.orbitaUltraGridToolBar1);
            this.Controls.Add(this._OrbitaMdiForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._OrbitaMdiForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._OrbitaMdiForm_Toolbars_Dock_Area_Top);
            this.Name = "Form2";
            this.OI.MostrarFondoCorporativo = false;
            this.Text = "Form2";
            this.Controls.SetChildIndex(this._OrbitaMdiForm_Toolbars_Dock_Area_Top, 0);
            this.Controls.SetChildIndex(this._OrbitaMdiForm_Toolbars_Dock_Area_Bottom, 0);
            this.Controls.SetChildIndex(this._OrbitaMdiForm_Toolbars_Dock_Area_Right, 0);
            this.Controls.SetChildIndex(this._OrbitaMdiForm_Toolbars_Dock_Area_Left, 0);
            this.Controls.SetChildIndex(this.orbitaUltraGridToolBar1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.orbitaUltraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.Grid.OrbitaUltraGridToolBar orbitaUltraGridToolBar1;
        private System.Windows.Forms.Button button1;
        private Controles.Menu.OrbitaUltraToolbarsManager orbitaUltraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaMdiForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaMdiForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaMdiForm_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _OrbitaMdiForm_Toolbars_Dock_Area_Top;
    }
}