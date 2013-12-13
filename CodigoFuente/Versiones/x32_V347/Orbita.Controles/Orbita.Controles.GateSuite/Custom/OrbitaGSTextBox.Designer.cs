namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSTextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSTextBox));
            this.txtEventosComs = new Orbita.Controles.Comunes.OrbitaTextBox();
            this.SuspendLayout();
            // 
            // txtEventosComs
            // 
            this.txtEventosComs.BackColor = System.Drawing.Color.White;
            this.txtEventosComs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEventosComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEventosComs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventosComs.Location = new System.Drawing.Point(0, 0);
            this.txtEventosComs.Name = "txtEventosComs";
            this.txtEventosComs.Size = new System.Drawing.Size(105, 14);
            this.txtEventosComs.TabIndex = 0;
            this.txtEventosComs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OrbitaGSTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtEventosComs);
            this.Name = "OrbitaGSTextBox";           
            this.Size = new System.Drawing.Size(105, 14);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion  

        public Comunes.OrbitaTextBox txtEventosComs;







       
    }
}
