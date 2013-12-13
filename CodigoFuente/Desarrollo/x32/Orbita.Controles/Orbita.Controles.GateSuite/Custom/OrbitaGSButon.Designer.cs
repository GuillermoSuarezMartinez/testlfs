namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSButon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSButon));
            this.bEventosComs = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.SuspendLayout();
            // 
            // bEventosComs
            // 
            appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.bEventosComs.Appearance = appearance1;
            this.bEventosComs.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.bEventosComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bEventosComs.ImageSize = new System.Drawing.Size(18, 18);
            this.bEventosComs.Location = new System.Drawing.Point(0, 0);
            this.bEventosComs.Name = "bEventosComs";
            this.bEventosComs.Size = new System.Drawing.Size(97, 26);
            this.bEventosComs.TabIndex = 0;
            // 
            // OrbitaGSButon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.bEventosComs);
            this.Name = "OrbitaGSButon";            
            this.Size = new System.Drawing.Size(97, 26);
            this.ResumeLayout(false);

        }

        #endregion  

        public Comunes.OrbitaUltraButton bEventosComs;



       
    }
}
