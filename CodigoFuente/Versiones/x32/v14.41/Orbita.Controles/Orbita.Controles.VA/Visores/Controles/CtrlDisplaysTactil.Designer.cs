namespace Orbita.Controles.VA
{
    partial class CtrlDisplaysTactil
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
            this.layFondoVisores = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.PnlSuperiorPadre.SuspendLayout();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.layFondoVisores);
            // 
            // LblMensaje
            // 
            this.LblMensaje.Text = "Visor";
            // 
            // PicIcono
            // 
            this.PicIcono.BackgroundImage = global::Orbita.Controles.VA.Properties.Resources.ImgCamara24;
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
            this.layFondoVisores.Size = new System.Drawing.Size(670, 317);
            this.layFondoVisores.TabIndex = 1;
            // 
            // CtrlDisplaysTactil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtrlDisplaysTactil";
            this.Titulo = "Visor";
            this.PnlSuperiorPadre.ResumeLayout(false);
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Contenedores.OrbitaTableLayoutPanel layFondoVisores;
    }
}
