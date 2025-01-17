namespace Orbita.Controles.VA
{
    partial class FrmBase
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.PnlPanelPrincipalPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlInferiorPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlBotonesPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnGuardar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.ChkDock = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.ChkToolTip = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPanelPrincipalPadre.Location = new System.Drawing.Point(10, 10);
            this.PnlPanelPrincipalPadre.Name = "PnlPanelPrincipalPadre";
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(772, 403);
            this.PnlPanelPrincipalPadre.TabIndex = 0;
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Controls.Add(this.PnlBotonesPadre);
            this.PnlInferiorPadre.Controls.Add(this.ChkDock);
            this.PnlInferiorPadre.Controls.Add(this.ChkToolTip);
            this.PnlInferiorPadre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 413);
            this.PnlInferiorPadre.Name = "PnlInferiorPadre";
            this.PnlInferiorPadre.Size = new System.Drawing.Size(772, 43);
            this.PnlInferiorPadre.TabIndex = 21;
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Controls.Add(this.btnCancelar);
            this.PnlBotonesPadre.Controls.Add(this.btnGuardar);
            this.PnlBotonesPadre.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlBotonesPadre.Location = new System.Drawing.Point(570, 0);
            this.PnlBotonesPadre.Name = "PnlBotonesPadre";
            this.PnlBotonesPadre.Size = new System.Drawing.Size(202, 43);
            this.PnlBotonesPadre.TabIndex = 32;
            // 
            // btnCancelar
            // 
            appearance1.Image = global::Orbita.Controles.VA.Properties.Resources.BtnNok24;
            this.btnCancelar.Appearance = appearance1;
            this.btnCancelar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancelar.Location = new System.Drawing.Point(104, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 34);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            appearance2.Image = global::Orbita.Controles.VA.Properties.Resources.btnOk24;
            this.btnGuardar.Appearance = appearance2;
            this.btnGuardar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnGuardar.Location = new System.Drawing.Point(0, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 34);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ChkDock
            // 
            appearance3.Image = global::Orbita.Controles.VA.Properties.Resources.btnAncla24;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ChkDock.Appearance = appearance3;
            this.ChkDock.Location = new System.Drawing.Point(39, 9);
            this.ChkDock.Name = "ChkDock";
            this.ChkDock.Size = new System.Drawing.Size(34, 34);
            this.ChkDock.Style = Infragistics.Win.EditCheckStyle.Button;
            this.ChkDock.TabIndex = 31;
            this.ChkDock.CheckedChanged += new System.EventHandler(this.ChkDock_CheckedChanged);
            // 
            // ChkToolTip
            // 
            appearance4.Image = global::Orbita.Controles.VA.Properties.Resources.BtnToolTips24;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ChkToolTip.Appearance = appearance4;
            this.ChkToolTip.Location = new System.Drawing.Point(0, 9);
            this.ChkToolTip.Name = "ChkToolTip";
            this.ChkToolTip.Size = new System.Drawing.Size(34, 34);
            this.ChkToolTip.Style = Infragistics.Win.EditCheckStyle.Button;
            this.ChkToolTip.TabIndex = 30;
            this.ChkToolTip.CheckedChanged += new System.EventHandler(this.ChkToolTip_CheckedChanged);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.PnlPanelPrincipalPadre);
            this.Controls.Add(this.PnlInferiorPadre);
            this.Name = "FrmBase";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formulario base del que heredarán el resto de formularios de la aplicación";
            this.Activated += new System.EventHandler(this.FrmBase_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBase_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBase_FormClosed);
            this.Load += new System.EventHandler(this.FrmBase_Load);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Contenedores.OrbitaPanel PnlPanelPrincipalPadre;
        protected Comunes.OrbitaUltraButton btnCancelar;
        protected Comunes.OrbitaUltraButton btnGuardar;
        protected Contenedores.OrbitaPanel PnlInferiorPadre;
        protected Contenedores.OrbitaPanel PnlBotonesPadre;
        protected Comunes.OrbitaUltraCheckEditor ChkDock;
        protected Comunes.OrbitaUltraCheckEditor ChkToolTip;
    }
}