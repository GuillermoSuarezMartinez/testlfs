namespace Orbita.Controles.VA
{
    partial class FrmGestionCamaraAxis
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.webBrowser);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(1204, 509);
            // 
            // btnCancelar
            // 
            this.btnCancelar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 519);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(1204, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(1002, 0);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1204, 509);
            this.webBrowser.TabIndex = 0;
            // 
            // FrmGestionCamaraAxis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 572);
            this.Name = "FrmGestionCamaraAxis";
            this.ShowInTaskbar = false;
            this.Text = "Mantenimiento cámara AXIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
    }
}