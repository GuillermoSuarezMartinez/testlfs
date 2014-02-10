namespace Orbita.Controles.Comunes
{
    partial class OrbitaTactilListButton
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
            this.botonTactil1 = new Orbita.Controles.Comunes.OrbitaTactilButton();
            this.SuspendLayout();
            // 
            // botonTactil1
            // 
            this.botonTactil1.BackColor = System.Drawing.Color.Transparent;
            this.botonTactil1.Botonera = null;
            this.botonTactil1.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonTactil1.Location = new System.Drawing.Point(10, 40);
            this.botonTactil1.Margin = new System.Windows.Forms.Padding(0);
            this.botonTactil1.Name = "botonTactil1";
            this.botonTactil1.Seleccionado = false;
            this.botonTactil1.Size = new System.Drawing.Size(227, 46);
            this.botonTactil1.TabIndex = 0;
            // 
            // OrbitaTactilListButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OrbitaTactilListButton";
            this.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            this.Size = new System.Drawing.Size(247, 777);
            this.ResumeLayout(false);

        }

        #endregion

        private OrbitaTactilButton botonTactil1;



    }
}
