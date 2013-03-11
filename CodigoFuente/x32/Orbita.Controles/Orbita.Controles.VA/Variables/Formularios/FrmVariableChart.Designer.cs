namespace Orbita.Controles.VA
{
    partial class FrmVariableChart
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
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(531, 83);
            // 
            // btnCancelar
            // 
            this.btnCancelar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 33);
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 93);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(531, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(329, 0);
            // 
            // FrmVariableChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 146);
            this.ModoAperturaFormulario = global::Orbita.Controles.VA.ModoAperturaFormulario.Monitorizacion;
            this.MultiplesInstancias = true;
            this.Name = "FrmVariableChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Monitorización temporal de variables";
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}