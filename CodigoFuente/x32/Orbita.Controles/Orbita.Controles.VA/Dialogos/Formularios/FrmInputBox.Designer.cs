using System.Windows.Forms;
namespace Orbita.Controles.VA
{
    partial class FrmInputBox
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
            this.GrpFondo = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.TxtInput = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.NumericEditorInput = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.LblExplicacion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PictureBox = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpFondo)).BeginInit();
            this.GrpFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 115);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(403, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(201, 0);
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
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(403, 105);
            // 
            // GrpFondo
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.GrpFondo.Appearance = appearance1;
            this.GrpFondo.Controls.Add(this.TxtInput);
            this.GrpFondo.Controls.Add(this.NumericEditorInput);
            this.GrpFondo.Controls.Add(this.LblExplicacion);
            this.GrpFondo.Controls.Add(this.PictureBox);
            this.GrpFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpFondo.Location = new System.Drawing.Point(0, 0);
            this.GrpFondo.Name = "GrpFondo";
            this.GrpFondo.Size = new System.Drawing.Size(403, 105);
            this.GrpFondo.TabIndex = 15;
            this.GrpFondo.Text = "Imputación manual de valor";
            // 
            // TxtInput
            // 
            this.TxtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtInput.Location = new System.Drawing.Point(13, 68);
            this.TxtInput.Name = "TxtInput";
            this.TxtInput.Size = new System.Drawing.Size(378, 20);
            this.TxtInput.TabIndex = 19;
            // 
            // NumericEditorInput
            // 
            this.NumericEditorInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericEditorInput.FormatString = "";
            this.NumericEditorInput.Location = new System.Drawing.Point(13, 68);
            this.NumericEditorInput.Name = "NumericEditorInput";
            this.NumericEditorInput.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.NumericEditorInput.PromptChar = ' ';
            this.NumericEditorInput.Size = new System.Drawing.Size(378, 21);
            this.NumericEditorInput.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.NumericEditorInput.TabIndex = 1;
            // 
            // LblExplicacion
            // 
            this.LblExplicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.LblExplicacion.Appearance = appearance2;
            this.LblExplicacion.Location = new System.Drawing.Point(62, 33);
            this.LblExplicacion.Name = "LblExplicacion";
            this.LblExplicacion.Size = new System.Drawing.Size(329, 31);
            this.LblExplicacion.TabIndex = 17;
            this.LblExplicacion.Text = "Mensaje explicativo";
            this.LblExplicacion.UseMnemonic = false;
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Orbita.Controles.VA.Properties.Resources.ImgInputText32;
            this.PictureBox.Location = new System.Drawing.Point(13, 25);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(32, 32);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox.TabIndex = 14;
            this.PictureBox.TabStop = false;
            // 
            // FrmInputBox
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(423, 168);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Modificacion;
            this.Name = "FrmInputBox";
            this.OI.NumeroMaximoFormulariosAbiertos = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imputación manual";
            this.Activated += new System.EventHandler(this.FrmInputTextBox_Activated);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrpFondo)).EndInit();
            this.GrpFondo.ResumeLayout(false);
            this.GrpFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Contenedores.OrbitaUltraGroupBox  GrpFondo;
        private Comunes.OrbitaPictureBox PictureBox;
        private Comunes.OrbitaUltraLabel LblExplicacion;
        private Comunes.OrbitaUltraNumericEditor NumericEditorInput;
        private Comunes.OrbitaTextBox TxtInput;

    }
}