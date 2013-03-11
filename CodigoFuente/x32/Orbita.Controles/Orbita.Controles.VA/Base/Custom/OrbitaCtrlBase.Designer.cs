namespace Orbita.Controles.VA
{
    partial class OrbitaCtrlBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.toolTip = new Orbita.Controles.Comunes.OrbitaToolTip(this.components);
            this.PnlInferiorPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlBotonesPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnGuardar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.ChkToolTip = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            this.PnlPanelPrincipalPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.ShowAlways = true;
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Controls.Add(this.PnlBotonesPadre);
            this.PnlInferiorPadre.Controls.Add(this.ChkToolTip);
            this.PnlInferiorPadre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 327);
            this.PnlInferiorPadre.Name = "PnlInferiorPadre";
            this.PnlInferiorPadre.Size = new System.Drawing.Size(670, 43);
            this.PnlInferiorPadre.TabIndex = 23;
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Controls.Add(this.btnCancelar);
            this.PnlBotonesPadre.Controls.Add(this.btnGuardar);
            this.PnlBotonesPadre.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlBotonesPadre.Location = new System.Drawing.Point(468, 0);
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
            this.btnCancelar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
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
            this.btnGuardar.OI.Estilo = global::Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 34);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ChkToolTip
            // 
            appearance3.Image = global::Orbita.Controles.VA.Properties.Resources.BtnToolTips24;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ChkToolTip.Appearance = appearance3;
            this.ChkToolTip.Location = new System.Drawing.Point(0, 9);
            this.ChkToolTip.Name = "ChkToolTip";
            this.ChkToolTip.Size = new System.Drawing.Size(34, 34);
            this.ChkToolTip.Style = Infragistics.Win.EditCheckStyle.Button;
            this.ChkToolTip.TabIndex = 30;
            this.ChkToolTip.CheckedChanged += new System.EventHandler(this.ChkToolTip_CheckedChanged);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPanelPrincipalPadre.Location = new System.Drawing.Point(10, 10);
            this.PnlPanelPrincipalPadre.Name = "PnlPanelPrincipalPadre";
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(670, 317);
            this.PnlPanelPrincipalPadre.TabIndex = 24;
            // 
            // OrbitaCtrlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlPanelPrincipalPadre);
            this.Controls.Add(this.PnlInferiorPadre);
            this.Name = "OrbitaCtrlBase";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(690, 380);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Comunes.OrbitaToolTip toolTip;
        protected Contenedores.OrbitaPanel PnlInferiorPadre;
        protected Contenedores.OrbitaPanel PnlBotonesPadre;
        protected Comunes.OrbitaUltraButton btnCancelar;
        protected Comunes.OrbitaUltraButton btnGuardar;
        protected Comunes.OrbitaUltraCheckEditor ChkToolTip;
        protected Contenedores.OrbitaPanel PnlPanelPrincipalPadre;
    }
}
