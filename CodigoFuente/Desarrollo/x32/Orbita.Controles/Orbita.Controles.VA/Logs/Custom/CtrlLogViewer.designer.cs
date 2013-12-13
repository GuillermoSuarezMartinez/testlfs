namespace Orbita.Controles.VA
{
    partial class CtrlLogViewerTactil
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.PnlLogs = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.TimerRefresco = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.PnlSuperiorPadre.SuspendLayout();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSuperiorPadre
            // 
            this.PnlSuperiorPadre.Size = new System.Drawing.Size(628, 43);
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.PnlLogs);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(628, 336);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Controls.Add(this.btnClear);
            this.PnlBotonesPadre.Location = new System.Drawing.Point(548, 0);
            this.PnlBotonesPadre.Controls.SetChildIndex(this.btnCancelar, 0);
            this.PnlBotonesPadre.Controls.SetChildIndex(this.btnGuardar, 0);
            this.PnlBotonesPadre.Controls.SetChildIndex(this.btnClear, 0);
            // 
            // LblMensaje
            // 
            this.LblMensaje.Size = new System.Drawing.Size(508, 43);
            this.LblMensaje.Text = "Visor de eventos";
            // 
            // PicIcono
            // 
            this.PicIcono.BackgroundImage = global::Orbita.Controles.VA.Properties.Resources.ImgLog24;
            // 
            // PnlLogs
            // 
            this.PnlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlLogs.Location = new System.Drawing.Point(0, 0);
            this.PnlLogs.Name = "PnlLogs";
            this.PnlLogs.Size = new System.Drawing.Size(628, 336);
            this.PnlLogs.TabIndex = 5;
            // 
            // TimerRefresco
            // 
            this.TimerRefresco.Interval = 1000;
            this.TimerRefresco.Tick += new System.EventHandler(this.TimerRefresco_Tick);
            // 
            // btnClear
            // 
            appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            appearance1.ImageBackground = global::Orbita.Controles.VA.Properties.Resources.ImgBorrar24;
            appearance1.ImageBackgroundStretchMargins = new Infragistics.Win.ImageBackgroundStretchMargins(5, 5, 5, 5);
            appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered;
            appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.btnClear.Appearance = appearance1;
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupBorderless;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowFocusRect = false;
            this.btnClear.Size = new System.Drawing.Size(40, 43);
            this.btnClear.TabIndex = 32;
            this.btnClear.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // CtrlLogViewerTactil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Monitorizacion;
            this.Name = "CtrlLogViewerTactil";
            this.Size = new System.Drawing.Size(648, 399);
            this.Titulo = "Visor de eventos";
            this.PnlSuperiorPadre.ResumeLayout(false);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Contenedores.OrbitaPanel PnlLogs;
        private System.Windows.Forms.Timer TimerRefresco;
        protected Orbita.Controles.Comunes.OrbitaUltraButton btnClear;
    }
}
