namespace Orbita.Controles.VA
{
    partial class OrbitaCtrlTactilBase
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
            this.PnlPanelPrincipalPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.PnlSuperiorPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.LblMensaje = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.PicIcono = new Orbita.Controles.Comunes.OrbitaPictureBox();
            this.PnlBotonesPadre = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.btnGuardar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.btnCancelar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.toolTip = new Orbita.Controles.Shared.OrbitaToolTip(this.components);
            this.PnlSuperiorPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).BeginInit();
            this.PnlBotonesPadre.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPanelPrincipalPadre.Location = new System.Drawing.Point(10, 53);
            this.PnlPanelPrincipalPadre.Name = "PnlPanelPrincipalPadre";
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(670, 317);
            this.PnlPanelPrincipalPadre.TabIndex = 24;
            // 
            // PnlSuperiorPadre
            // 
            this.PnlSuperiorPadre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PnlSuperiorPadre.Controls.Add(this.LblMensaje);
            this.PnlSuperiorPadre.Controls.Add(this.PicIcono);
            this.PnlSuperiorPadre.Controls.Add(this.PnlBotonesPadre);
            this.PnlSuperiorPadre.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperiorPadre.Location = new System.Drawing.Point(10, 10);
            this.PnlSuperiorPadre.Name = "PnlSuperiorPadre";
            this.PnlSuperiorPadre.Size = new System.Drawing.Size(670, 43);
            this.PnlSuperiorPadre.TabIndex = 23;
            // 
            // LblMensaje
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.SizeInPoints = 14F;
            appearance1.ForeColor = System.Drawing.Color.WhiteSmoke;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.LblMensaje.Appearance = appearance1;
            this.LblMensaje.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensaje.ImageSize = new System.Drawing.Size(24, 24);
            this.LblMensaje.Location = new System.Drawing.Point(40, 0);
            this.LblMensaje.Margin = new System.Windows.Forms.Padding(0);
            this.LblMensaje.Name = "LblMensaje";
            this.LblMensaje.Padding = new System.Drawing.Size(10, 0);
            this.LblMensaje.Size = new System.Drawing.Size(550, 43);
            this.LblMensaje.TabIndex = 33;
            this.LblMensaje.Text = "Título del formulario";
            this.LblMensaje.UseMnemonic = false;
            // 
            // PicIcono
            // 
            this.PicIcono.BackgroundImage = global::Orbita.Controles.VA.Properties.Resources.ImgEjemplo24Blanco;
            this.PicIcono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PicIcono.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicIcono.ImageLocation = "";
            this.PicIcono.Location = new System.Drawing.Point(0, 0);
            this.PicIcono.Name = "PicIcono";
            this.PicIcono.Size = new System.Drawing.Size(40, 43);
            this.PicIcono.TabIndex = 34;
            this.PicIcono.TabStop = false;
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.BackColor = System.Drawing.Color.Transparent;
            this.PnlBotonesPadre.Controls.Add(this.btnGuardar);
            this.PnlBotonesPadre.Controls.Add(this.btnCancelar);
            this.PnlBotonesPadre.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlBotonesPadre.Location = new System.Drawing.Point(590, 0);
            this.PnlBotonesPadre.Name = "PnlBotonesPadre";
            this.PnlBotonesPadre.Size = new System.Drawing.Size(80, 43);
            this.PnlBotonesPadre.TabIndex = 32;
            // 
            // btnGuardar
            // 
            appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance2.ImageBackground = global::Orbita.Controles.VA.Properties.Resources.btnOk24Blanco;
            appearance2.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 5);
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered;
            appearance2.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.btnGuardar.Appearance = appearance2;
            this.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupBorderless;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ShowFocusRect = false;
            this.btnGuardar.Size = new System.Drawing.Size(40, 43);
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance3.ImageBackground = global::Orbita.Controles.VA.Properties.Resources.BtnNok24Blanco;
            appearance3.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 5);
            appearance3.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.btnCancelar.Appearance = appearance3;
            this.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupBorderless;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Location = new System.Drawing.Point(40, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.ShowFocusRect = false;
            this.btnCancelar.Size = new System.Drawing.Size(40, 43);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.ShowAlways = true;
            // 
            // OrbitaCtrlTactilBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.PnlPanelPrincipalPadre);
            this.Controls.Add(this.PnlSuperiorPadre);
            this.Name = "OrbitaCtrlTactilBase";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(690, 380);
            this.PnlSuperiorPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).EndInit();
            this.PnlBotonesPadre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Shared.OrbitaToolTip toolTip;
        protected Orbita.Controles.Contenedores.OrbitaPanel PnlSuperiorPadre;
        protected Contenedores.OrbitaPanel PnlPanelPrincipalPadre;
        protected Contenedores.OrbitaPanel PnlBotonesPadre;
        protected Comunes.OrbitaUltraButton btnCancelar;
        protected Comunes.OrbitaUltraButton btnGuardar;
        protected Comunes.OrbitaUltraLabel LblMensaje;
        protected Comunes.OrbitaPictureBox PicIcono;
    }
}
