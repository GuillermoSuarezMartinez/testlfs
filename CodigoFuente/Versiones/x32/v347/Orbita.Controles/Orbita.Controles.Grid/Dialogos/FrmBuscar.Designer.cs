namespace Orbita.Controles.Grid
{
    partial class FrmBuscar
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
            this.chkMayusculasMinisculas = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscarSiguiente = new System.Windows.Forms.Button();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkMayusculasMinisculas
            // 
            this.chkMayusculasMinisculas.AutoSize = true;
            this.chkMayusculasMinisculas.Location = new System.Drawing.Point(25, 52);
            this.chkMayusculasMinisculas.Name = "chkMayusculasMinisculas";
            this.chkMayusculasMinisculas.Size = new System.Drawing.Size(185, 17);
            this.chkMayusculasMinisculas.TabIndex = 31;
            this.chkMayusculasMinisculas.Text = "Coincidir mayúsculas y minísculas";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(349, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscarSiguiente
            // 
            this.btnBuscarSiguiente.Location = new System.Drawing.Point(349, 17);
            this.btnBuscarSiguiente.Name = "btnBuscarSiguiente";
            this.btnBuscarSiguiente.Size = new System.Drawing.Size(107, 23);
            this.btnBuscarSiguiente.TabIndex = 24;
            this.btnBuscarSiguiente.Text = "Buscar siguiente";
            this.btnBuscarSiguiente.Click += new System.EventHandler(this.btnBuscarSiguiente_Click);
            // 
            // cboBuscar
            // 
            this.cboBuscar.Location = new System.Drawing.Point(84, 17);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Size = new System.Drawing.Size(248, 21);
            this.cboBuscar.TabIndex = 23;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(22, 20);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 22;
            this.lblBuscar.Text = "Buscar:";
            // 
            // FrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 95);
            this.Controls.Add(this.chkMayusculasMinisculas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscarSiguiente);
            this.Controls.Add(this.cboBuscar);
            this.Controls.Add(this.lblBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscar";
            this.Text = "Buscar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkMayusculasMinisculas;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnBuscarSiguiente;
        internal System.Windows.Forms.ComboBox cboBuscar;
        internal System.Windows.Forms.Label lblBuscar;
    }
}