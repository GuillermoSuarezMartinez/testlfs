namespace Orbita.Test
{
    partial class Form3
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
            this.orbitaMenuStrip1 = new Orbita.Controles.Menu.OrbitaMenuStrip();
            this.aaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orbitaUltraGridToolBar1 = new Orbita.Controles.Grid.OrbitaUltraGridToolBar();
            this.orbitaMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orbitaMenuStrip1
            // 
            this.orbitaMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaToolStripMenuItem,
            this.aaToolStripMenuItem1});
            this.orbitaMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.orbitaMenuStrip1.Name = "orbitaMenuStrip1";
            this.orbitaMenuStrip1.Size = new System.Drawing.Size(690, 24);
            this.orbitaMenuStrip1.TabIndex = 1;
            this.orbitaMenuStrip1.Text = "orbitaMenuStrip1";
            // 
            // aaToolStripMenuItem
            // 
            this.aaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddToolStripMenuItem});
            this.aaToolStripMenuItem.Name = "aaToolStripMenuItem";
            this.aaToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.aaToolStripMenuItem.Text = "aa";
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.ddToolStripMenuItem.Text = "dd";
            this.ddToolStripMenuItem.Click += new System.EventHandler(this.ddToolStripMenuItem_Click);
            // 
            // aaToolStripMenuItem1
            // 
            this.aaToolStripMenuItem1.Name = "aaToolStripMenuItem1";
            this.aaToolStripMenuItem1.Size = new System.Drawing.Size(31, 20);
            this.aaToolStripMenuItem1.Text = "aa";
            // 
            // orbitaUltraGridToolBar1
            // 
            this.orbitaUltraGridToolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orbitaUltraGridToolBar1.Location = new System.Drawing.Point(0, 24);
            this.orbitaUltraGridToolBar1.Name = "orbitaUltraGridToolBar1";
            this.orbitaUltraGridToolBar1.OI.CampoPosicionable = null;
            this.orbitaUltraGridToolBar1.OI.Filas.TipoSeleccion = null;
            this.orbitaUltraGridToolBar1.OI.MostrarTitulo = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolAñadir = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolCiclico = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolEditar = false;
            this.orbitaUltraGridToolBar1.OI.MostrarToolEliminar = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolEstilo = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolGestionar = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolImprimir = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolModificar = true;
            this.orbitaUltraGridToolBar1.OI.MostrarToolVer = true;
            this.orbitaUltraGridToolBar1.OI.OcultarAgrupadorFilas = true;
            this.orbitaUltraGridToolBar1.Size = new System.Drawing.Size(690, 413);
            this.orbitaUltraGridToolBar1.TabIndex = 2;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 437);
            this.Controls.Add(this.orbitaUltraGridToolBar1);
            this.Controls.Add(this.orbitaMenuStrip1);
            this.MainMenuStrip = this.orbitaMenuStrip1;
            this.Name = "Form3";
            this.Text = "Form3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.orbitaMenuStrip1, 0);
            this.Controls.SetChildIndex(this.orbitaUltraGridToolBar1, 0);
            this.orbitaMenuStrip1.ResumeLayout(false);
            this.orbitaMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.Menu.OrbitaMenuStrip orbitaMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aaToolStripMenuItem1;
        private Controles.Grid.OrbitaUltraGridToolBar orbitaUltraGridToolBar1;
    }
}