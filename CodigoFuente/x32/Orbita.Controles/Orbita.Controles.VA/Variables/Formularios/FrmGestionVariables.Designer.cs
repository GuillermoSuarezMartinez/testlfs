namespace Orbita.Controles.VA
{
    partial class FrmGestionVariables
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.gridVariables = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.gridVariables);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(970, 415);
            // 
            // btnCancelar
            // 
            this.btnCancelar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 33);
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 425);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(970, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(768, 0);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(970, 433);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(10, 10);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(970, 458);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // gridVariables
            // 
            this.gridVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVariables.Location = new System.Drawing.Point(0, 0);
            this.gridVariables.Name = "gridVariables";
            this.gridVariables.OI.CampoPosicionable = null;
            this.gridVariables.OI.Filas.TipoSeleccion = null;
            this.gridVariables.OI.MostrarToolCiclico = false;
            this.gridVariables.OI.MostrarToolEliminar = true;
            this.gridVariables.OI.MostrarToolEstilo = true;
            this.gridVariables.OI.MostrarToolLimpiarFiltros = false;
            this.gridVariables.OI.MostrarToolModificar = true;
            this.gridVariables.OI.MostrarToolVer = true;
            this.gridVariables.Size = new System.Drawing.Size(970, 415);
            this.gridVariables.TabIndex = 3;
            this.gridVariables.ToolModificarClick += new Orbita.Controles.Grid.OrbitaUltraGridToolBar.ToolModificarClickEventHandler(this.gridVariables_OrbBotonModificarClick);
            this.gridVariables.ToolAñadirClick += new Orbita.Controles.Grid.OrbitaUltraGridToolBar.ToolAñadirClickEventHandler(this.gridVariables_OrbBotonAñadirClick);
            this.gridVariables.ToolEliminarClick += new Orbita.Controles.Grid.OrbitaUltraGridToolBar.ToolEliminarClickEventHandler(this.gridVariables_OrbBotonEliminarFilaClick);
            this.gridVariables.ToolRefrescarClick += new Orbita.Controles.Grid.OrbitaUltraGridToolBar.ToolRefrescarClickEventHandler(this.gridVariables_OrbBotonRefrescarClick);
            // 
            // FrmGestionVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 478);
            this.Controls.Add(this.toolStripContainer1);
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Modificacion;
            this.Name = "FrmGestionVariables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Gestión de variables";
            this.Controls.SetChildIndex(this.toolStripContainer1, 0);
            this.Controls.SetChildIndex(this.PnlInferiorPadre, 0);
            this.Controls.SetChildIndex(this.PnlPanelPrincipalPadre, 0);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVariableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codVariableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreVariableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitadoVariableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn guardarTrazabilidadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descVariableDataGridViewTextBoxColumn;
        private Orbita.Controles.Grid.OrbitaUltraGridToolBar gridVariables;
    }
}