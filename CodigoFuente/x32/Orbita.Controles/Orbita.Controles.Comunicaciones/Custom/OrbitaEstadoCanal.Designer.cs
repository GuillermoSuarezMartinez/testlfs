namespace Orbita.Controles.Comunicaciones
{
    partial class OrbitaEstadoCanal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaEstadoCanal));
            this.lblEstadoCanal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEstadoCanal
            // 
            this.lblEstadoCanal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstadoCanal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstadoCanal.Location = new System.Drawing.Point(0, 0);
            this.lblEstadoCanal.Name = "lblEstadoCanal";
            this.lblEstadoCanal.Size = new System.Drawing.Size(150, 24);
            this.lblEstadoCanal.TabIndex = 0;
            // 
            // OrbitaEstadoCanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEstadoCanal);
            this.Name = "OrbitaEstadoCanal";            
            this.Size = new System.Drawing.Size(150, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEstadoCanal;
    }
}
