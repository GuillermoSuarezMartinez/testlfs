namespace Orbita.Controles.Autenticacion
{
    partial class FrmAutenticacion
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblMayusculasActivada = new System.Windows.Forms.Label();
            this.lblCredencialesIncorrectas = new System.Windows.Forms.Label();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(124, 131);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(93, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(120, 37);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(191, 20);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.UseSystemPasswordChar = true;
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(120, 11);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(191, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(222, 131);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(48, 14);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(30, 37);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.txtContraseña);
            this.pnlSuperior.Controls.Add(this.txtUsuario);
            this.pnlSuperior.Controls.Add(this.lblUsuario);
            this.pnlSuperior.Controls.Add(this.lblContraseña);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(4, 4);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(313, 70);
            this.pnlSuperior.TabIndex = 0;
            // 
            // lblMayusculasActivada
            // 
            this.lblMayusculasActivada.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMayusculasActivada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMayusculasActivada.ForeColor = System.Drawing.Color.Navy;
            this.lblMayusculasActivada.Location = new System.Drawing.Point(4, 74);
            this.lblMayusculasActivada.Name = "lblMayusculasActivada";
            this.lblMayusculasActivada.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.lblMayusculasActivada.Size = new System.Drawing.Size(313, 20);
            this.lblMayusculasActivada.TabIndex = 4;
            this.lblMayusculasActivada.Text = "La tecla Bloq Mayús esta activada.";
            this.lblMayusculasActivada.Visible = false;
            // 
            // lblCredencialesIncorrectas
            // 
            this.lblCredencialesIncorrectas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCredencialesIncorrectas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredencialesIncorrectas.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCredencialesIncorrectas.Location = new System.Drawing.Point(4, 94);
            this.lblCredencialesIncorrectas.Name = "lblCredencialesIncorrectas";
            this.lblCredencialesIncorrectas.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.lblCredencialesIncorrectas.Size = new System.Drawing.Size(313, 36);
            this.lblCredencialesIncorrectas.TabIndex = 5;
            this.lblCredencialesIncorrectas.Text = "El nombre de usuario o la contraseña introducidos no son correctos.";
            this.lblCredencialesIncorrectas.Visible = false;
            // 
            // FrmAutenticacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 165);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCredencialesIncorrectas);
            this.Controls.Add(this.lblMayusculasActivada);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutenticacion";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Autenticación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmValidar_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmValidar_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmValidar_KeyUp);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblMayusculasActivada;
        private System.Windows.Forms.Label lblCredencialesIncorrectas;
    }
}