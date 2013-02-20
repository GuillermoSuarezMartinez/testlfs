namespace Orbita.Test
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.orbitaPuertoSerie1 = new Orbita.Controles.Comunicaciones.OrbitaPuertoSerie();
            this.SuspendLayout();
            // 
            // orbitaPuertoSerie1
            // 
            this.orbitaPuertoSerie1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orbitaPuertoSerie1.Location = new System.Drawing.Point(0, 0);
            this.orbitaPuertoSerie1.Name = "orbitaPuertoSerie1";
            this.orbitaPuertoSerie1.Padding = new System.Windows.Forms.Padding(5);
            this.orbitaPuertoSerie1.Size = new System.Drawing.Size(563, 530);
            this.orbitaPuertoSerie1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 530);
            this.Controls.Add(this.orbitaPuertoSerie1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.Comunicaciones.OrbitaPuertoSerie orbitaPuertoSerie1;
    }
}

