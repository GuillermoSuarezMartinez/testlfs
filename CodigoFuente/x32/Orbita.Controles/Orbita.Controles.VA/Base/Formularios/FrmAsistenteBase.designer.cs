namespace Orbita.Controles.VA
{
    partial class FrmAsistenteBase
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
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenteBase));
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.PnlPanelPrincipalPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.TabControl = new Orbita.Controles.Contenedores.OrbitaUltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.PnlSuperior = new Infragistics.Win.Misc.UltraPanel();
            this.lblTitulo = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PictureBox = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.PnlInferiorPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.LblNumeroPaso = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PnlBotonesPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.BtnAnterior = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnSiguienteFinalizar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.ChkToolTip = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            this.PnlSuperior.ClientArea.SuspendLayout();
            this.PnlSuperior.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(603, 338);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.TabControl);
            this.PnlPanelPrincipalPadre.Controls.Add(this.PnlSuperior);
            this.PnlPanelPrincipalPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPanelPrincipalPadre.Location = new System.Drawing.Point(0, 0);
            this.PnlPanelPrincipalPadre.Name = "PnlPanelPrincipalPadre";
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(603, 378);
            this.PnlPanelPrincipalPadre.TabIndex = 0;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.TabControl.Controls.Add(this.ultraTabPageControl1);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 40);
            this.TabControl.Name = "TabControl";
            this.TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.TabControl.Size = new System.Drawing.Size(603, 338);
            this.TabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.TabControl.TabIndex = 0;
            ultraTab5.TabPage = this.ultraTabPageControl1;
            ultraTab5.Text = "tab1";
            this.TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab5});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(603, 338);
            // 
            // PnlSuperior
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(52)))), ((int)(((byte)(47)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(83)))), ((int)(((byte)(5)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            this.PnlSuperior.Appearance = appearance1;
            // 
            // PnlSuperior.ClientArea
            // 
            this.PnlSuperior.ClientArea.Controls.Add(this.lblTitulo);
            this.PnlSuperior.ClientArea.Controls.Add(this.PictureBox);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(603, 40);
            this.PnlSuperior.TabIndex = 1;
            // 
            // lblTitulo
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BorderColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance2.TextVAlignAsString = "Middle";
            this.lblTitulo.Appearance = appearance2;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(100, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblTitulo.OI.Apariencia.ColorBorde = System.Drawing.Color.Transparent;
            this.lblTitulo.OI.Apariencia.ColorFondo = System.Drawing.Color.Transparent;
            this.lblTitulo.OI.Apariencia.ColorTexto = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.SinBorde;
            this.lblTitulo.Size = new System.Drawing.Size(503, 40);
            this.lblTitulo.TabIndex = 19;
            this.lblTitulo.Text = "Asistente de configuración";
            this.lblTitulo.UseMnemonic = false;
            this.lblTitulo.WrapText = false;
            // 
            // PictureBox
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.PictureBox.Appearance = appearance3;
            this.PictureBox.BorderShadowColor = System.Drawing.Color.Empty;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureBox.Image = ((object)(resources.GetObject("PictureBox.Image")));
            this.PictureBox.ImageTransparentColor = System.Drawing.Color.White;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(100, 40);
            this.PictureBox.TabIndex = 20;
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Controls.Add(this.LblNumeroPaso);
            this.PnlInferiorPadre.Controls.Add(this.PnlBotonesPadre);
            this.PnlInferiorPadre.Controls.Add(this.ChkToolTip);
            this.PnlInferiorPadre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInferiorPadre.Location = new System.Drawing.Point(0, 378);
            this.PnlInferiorPadre.Name = "PnlInferiorPadre";
            this.PnlInferiorPadre.Size = new System.Drawing.Size(603, 43);
            this.PnlInferiorPadre.TabIndex = 21;
            // 
            // LblNumeroPaso
            // 
            this.LblNumeroPaso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNumeroPaso.Location = new System.Drawing.Point(56, 19);
            this.LblNumeroPaso.Name = "LblNumeroPaso";
            this.LblNumeroPaso.Size = new System.Drawing.Size(231, 23);
            this.LblNumeroPaso.TabIndex = 33;
            this.LblNumeroPaso.Text = "Paso 1 de 1";
            this.LblNumeroPaso.UseMnemonic = false;
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Controls.Add(this.BtnAnterior);
            this.PnlBotonesPadre.Controls.Add(this.btnCancelar);
            this.PnlBotonesPadre.Controls.Add(this.btnSiguienteFinalizar);
            this.PnlBotonesPadre.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlBotonesPadre.Location = new System.Drawing.Point(293, 0);
            this.PnlBotonesPadre.Name = "PnlBotonesPadre";
            this.PnlBotonesPadre.Size = new System.Drawing.Size(310, 43);
            this.PnlBotonesPadre.TabIndex = 32;
            // 
            // BtnAnterior
            // 
            appearance4.Image = global::Orbita.Controles.VA.Properties.Resources.BtnAnterior24;
            this.BtnAnterior.Appearance = appearance4;
            this.BtnAnterior.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnAnterior.Location = new System.Drawing.Point(3, 9);
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.BtnAnterior.Size = new System.Drawing.Size(98, 34);
            this.BtnAnterior.TabIndex = 32;
            this.BtnAnterior.Text = "Anterior";
            this.BtnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            // 
            // btnCancelar
            // 
            appearance5.Image = global::Orbita.Controles.VA.Properties.Resources.BtnNok24;
            this.btnCancelar.Appearance = appearance5;
            this.btnCancelar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancelar.Location = new System.Drawing.Point(211, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 34);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSiguienteFinalizar
            // 
            appearance6.Image = global::Orbita.Controles.VA.Properties.Resources.BtnSiguiente24;
            this.btnSiguienteFinalizar.Appearance = appearance6;
            this.btnSiguienteFinalizar.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSiguienteFinalizar.Location = new System.Drawing.Point(107, 9);
            this.btnSiguienteFinalizar.Name = "btnSiguienteFinalizar";
            this.btnSiguienteFinalizar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnSiguienteFinalizar.Size = new System.Drawing.Size(98, 34);
            this.btnSiguienteFinalizar.TabIndex = 31;
            this.btnSiguienteFinalizar.Text = "Siguiente";
            this.btnSiguienteFinalizar.Click += new System.EventHandler(this.btnSiguienteFinalizar_Click);
            // 
            // ChkToolTip
            // 
            appearance7.Image = global::Orbita.Controles.VA.Properties.Resources.BtnToolTips24;
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ChkToolTip.Appearance = appearance7;
            this.ChkToolTip.Location = new System.Drawing.Point(0, 9);
            this.ChkToolTip.Name = "ChkToolTip";
            this.ChkToolTip.Size = new System.Drawing.Size(34, 34);
            this.ChkToolTip.Style = Infragistics.Win.EditCheckStyle.Button;
            this.ChkToolTip.TabIndex = 30;
            this.ChkToolTip.CheckedChanged += new System.EventHandler(this.ChkToolTip_CheckedChanged);
            // 
            // FrmAsistenteBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 421);
            this.Controls.Add(this.PnlPanelPrincipalPadre);
            this.Controls.Add(this.PnlInferiorPadre);
            this.Name = "FrmAsistenteBase";
            this.OI.NumeroMaximoFormulariosAbiertos = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formulario del que heredarán los asistentes de la aplicación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBase_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBase_FormClosed);
            this.Load += new System.EventHandler(this.FrmBase_Load);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.PnlSuperior.ClientArea.ResumeLayout(false);
            this.PnlSuperior.ClientArea.PerformLayout();
            this.PnlSuperior.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Contenedores.OrbitaPanel PnlPanelPrincipalPadre;
        protected Comunes.OrbitaUltraButton btnCancelar;
        protected Comunes.OrbitaUltraButton btnSiguienteFinalizar;
        protected Contenedores.OrbitaPanel PnlInferiorPadre;
        protected Contenedores.OrbitaPanel PnlBotonesPadre;
        protected Comunes.OrbitaUltraCheckEditor ChkToolTip;
        protected Comunes.OrbitaUltraButton BtnAnterior;
        protected Infragistics.Win.Misc.UltraPanel PnlSuperior;
        protected Comunes.OrbitaUltraLabel lblTitulo;
        protected Comunes.OrbitaUltraLabel LblNumeroPaso;
        protected Infragistics.Win.UltraWinEditors.UltraPictureBox PictureBox;
        protected Contenedores.OrbitaUltraTabControl TabControl;
        protected Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        protected Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
    }
}