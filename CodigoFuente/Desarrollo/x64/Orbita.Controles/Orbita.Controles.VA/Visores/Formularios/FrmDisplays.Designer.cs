namespace Orbita.Controles.VA
{
    partial class FrmDisplays
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
            this.layFondoVisores = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.layFondoVisores);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(514, 187);
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
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 197);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(514, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Location = new System.Drawing.Point(312, 0);
            // 
            // layFondoVisores
            // 
            this.layFondoVisores.ColumnCount = 1;
            this.layFondoVisores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layFondoVisores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layFondoVisores.Location = new System.Drawing.Point(0, 0);
            this.layFondoVisores.Name = "layFondoVisores";
            this.layFondoVisores.RowCount = 1;
            this.layFondoVisores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layFondoVisores.Size = new System.Drawing.Size(514, 187);
            this.layFondoVisores.TabIndex = 0;
            // 
            // FrmDisplays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 250);
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Monitorizacion;
            this.MostrarBotones = false;
            this.Name = "FrmDisplays";
            this.OI.NumeroMaximoFormulariosAbiertos = 0;
            this.RecordarPosicion = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Monitorización de cámaras";
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Contenedores.OrbitaTableLayoutPanel layFondoVisores;
    }
}