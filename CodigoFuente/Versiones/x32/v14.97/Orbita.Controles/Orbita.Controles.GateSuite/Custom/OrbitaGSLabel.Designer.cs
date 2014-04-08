using Orbita;
namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSLabel));
            this.lblEventosComs = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.SuspendLayout();
            // 
            // lblEventosComs
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblEventosComs.Appearance = appearance1;
            this.lblEventosComs.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblEventosComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEventosComs.Location = new System.Drawing.Point(0, 0);
            this.lblEventosComs.Name = "lblEventosComs";
            this.lblEventosComs.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblEventosComs.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblEventosComs.Size = new System.Drawing.Size(105, 18);
            this.lblEventosComs.TabIndex = 0;
            this.lblEventosComs.UseMnemonic = false;
            // 
            // OrbitaGSLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEventosComs);
            this.Name = "OrbitaGSLabel";          
            this.Size = new System.Drawing.Size(105, 18);
            this.ResumeLayout(false);

        }

        #endregion  

        public Comunes.OrbitaUltraLabel lblEventosComs;       
    }
}
