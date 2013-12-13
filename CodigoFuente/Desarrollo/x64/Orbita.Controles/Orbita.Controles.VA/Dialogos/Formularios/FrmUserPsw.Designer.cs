namespace Orbita.Controles.VA
{
    partial class FrmUserPsw
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.GrpFondo = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.LblErrorContraseña = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.OrbitaPictureBox = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.ComboUsuario = new Orbita.Controles.Combo.OrbitaUltraCombo();
            this.LblContraseña = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.LblUsuario = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.TxtContraseña = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpFondo)).BeginInit();
            this.GrpFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrbitaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 144);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(408, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(206, 0);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 33);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.GrpFondo);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(408, 134);
            // 
            // GrpFondo
            // 
            this.GrpFondo.ContentPadding.Bottom = 2;
            this.GrpFondo.ContentPadding.Left = 2;
            this.GrpFondo.ContentPadding.Right = 2;
            this.GrpFondo.ContentPadding.Top = 2;
            this.GrpFondo.Controls.Add(this.LblErrorContraseña);
            this.GrpFondo.Controls.Add(this.OrbitaPictureBox);
            this.GrpFondo.Controls.Add(this.ComboUsuario);
            this.GrpFondo.Controls.Add(this.LblContraseña);
            this.GrpFondo.Controls.Add(this.LblUsuario);
            this.GrpFondo.Controls.Add(this.TxtContraseña);
            this.GrpFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpFondo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GrpFondo.Location = new System.Drawing.Point(0, 0);
            this.GrpFondo.Name = "GrpFondo";
            this.GrpFondo.Size = new System.Drawing.Size(408, 134);
            this.GrpFondo.TabIndex = 3;
            this.GrpFondo.Text = "Introducción de usuario y contraseña";
            // 
            // LblErrorContraseña
            // 
            this.LblErrorContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.Red;
            appearance1.TextHAlignAsString = "Center";
            this.LblErrorContraseña.Appearance = appearance1;
            this.LblErrorContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LblErrorContraseña.Location = new System.Drawing.Point(20, 107);
            this.LblErrorContraseña.Name = "LblErrorContraseña";
            this.LblErrorContraseña.Size = new System.Drawing.Size(363, 18);
            this.LblErrorContraseña.TabIndex = 4;
            this.LblErrorContraseña.Text = "Contraseña incorrecta";
            this.LblErrorContraseña.UseMnemonic = false;
            this.LblErrorContraseña.Visible = false;
            // 
            // OrbitaPictureBox
            // 
            this.OrbitaPictureBox.Image = global::Orbita.Controles.VA.Properties.Resources.ImgUsuarios48;
            this.OrbitaPictureBox.Location = new System.Drawing.Point(20, 25);
            this.OrbitaPictureBox.Name = "OrbitaPictureBox";
            this.OrbitaPictureBox.Size = new System.Drawing.Size(48, 48);
            this.OrbitaPictureBox.TabIndex = 3;
            this.OrbitaPictureBox.TabStop = false;
            // 
            // ComboUsuario
            // 
            this.ComboUsuario.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.ComboUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboUsuario.Location = new System.Drawing.Point(159, 40);
            this.ComboUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.ComboUsuario.Name = "ComboUsuario";
            this.ComboUsuario.Size = new System.Drawing.Size(224, 23);
            this.ComboUsuario.TabIndex = 1;
            // 
            // LblContraseña
            // 
            this.LblContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            this.LblContraseña.Appearance = appearance2;
            this.LblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LblContraseña.Location = new System.Drawing.Point(78, 78);
            this.LblContraseña.Name = "LblContraseña";
            this.LblContraseña.Size = new System.Drawing.Size(75, 18);
            this.LblContraseña.TabIndex = 1;
            this.LblContraseña.Text = "Contraseña";
            this.LblContraseña.UseMnemonic = false;
            // 
            // LblUsuario
            // 
            this.LblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.LblUsuario.Appearance = appearance3;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LblUsuario.Location = new System.Drawing.Point(78, 43);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(75, 18);
            this.LblUsuario.TabIndex = 1;
            this.LblUsuario.Text = "Usuario";
            this.LblUsuario.UseMnemonic = false;
            // 
            // TxtContraseña
            // 
            this.TxtContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtContraseña.Location = new System.Drawing.Point(159, 75);
            this.TxtContraseña.Name = "TxtContraseña";
            this.TxtContraseña.PasswordChar = '*';
            this.TxtContraseña.Size = new System.Drawing.Size(224, 20);
            this.TxtContraseña.TabIndex = 2;
            // 
            // FrmUserPsw
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(428, 197);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Modificacion;
            this.Name = "FrmUserPsw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de usuario";
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrpFondo)).EndInit();
            this.GrpFondo.ResumeLayout(false);
            this.GrpFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrbitaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Comunes.OrbitaTextBox TxtContraseña;
        private Orbita.Controles.Combo.OrbitaUltraCombo ComboUsuario;
        private Orbita.Controles.Comunes.OrbitaPictureBox OrbitaPictureBox;
        private Orbita.Controles.Contenedores.OrbitaUltraGroupBox  GrpFondo;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblContraseña;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblUsuario;
        private Orbita.Controles.Comunes.OrbitaUltraLabel LblErrorContraseña;
    }
}