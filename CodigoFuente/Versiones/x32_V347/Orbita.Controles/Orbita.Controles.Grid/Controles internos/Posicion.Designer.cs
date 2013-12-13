namespace Orbita.Controles.Grid
{
    partial class Posicion
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnAceptar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.numPosicion = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.lblPosicion = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numPosicion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageSize = new System.Drawing.Size(18, 18);
            this.btnAceptar.Location = new System.Drawing.Point(91, 30);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(64, 25);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAceptar_KeyPress);
            // 
            // numPosicion
            // 
            this.numPosicion.Location = new System.Drawing.Point(20, 31);
            this.numPosicion.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.numPosicion.MaskInput = "nnnn";
            this.numPosicion.MaxValue = 9999;
            this.numPosicion.MinValue = 1;
            this.numPosicion.Name = "numPosicion";
            this.numPosicion.NullText = "1";
            this.numPosicion.PromptChar = ' ';
            this.numPosicion.Size = new System.Drawing.Size(56, 21);
            this.numPosicion.SpinIncrement = 1;
            this.numPosicion.TabIndex = 5;
            this.numPosicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numPosicion_KeyPress);
            // 
            // lblPosicion
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblPosicion.Appearance = appearance1;
            this.lblPosicion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPosicion.Location = new System.Drawing.Point(0, 0);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblPosicion.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblPosicion.OI.Apariencia.ColorFondo = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPosicion.Size = new System.Drawing.Size(175, 17);
            this.lblPosicion.TabIndex = 2;
            this.lblPosicion.Text = "Nueva posición";
            this.lblPosicion.UseMnemonic = false;
            // 
            // Posicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.numPosicion);
            this.Controls.Add(this.lblPosicion);
            this.Name = "Posicion";
            this.Size = new System.Drawing.Size(175, 74);
            ((System.ComponentModel.ISupportInitialize)(this.numPosicion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Comunes.OrbitaUltraLabel lblPosicion;
        private Comunes.OrbitaUltraNumericEditor numPosicion;
        private Comunes.OrbitaUltraButton btnAceptar;
    }
}
