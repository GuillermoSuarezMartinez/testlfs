namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSCheckBox   {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSCheckBox));
            this.chkEventosComs = new Orbita.Controles.Comunes.OrbitaUltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.chkEventosComs)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEventosComs
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.chkEventosComs.Appearance = appearance1;
            this.chkEventosComs.BackColor = System.Drawing.Color.White;
            this.chkEventosComs.BackColorInternal = System.Drawing.Color.White;
            this.chkEventosComs.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEventosComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEventosComs.Location = new System.Drawing.Point(0, 0);
            this.chkEventosComs.Name = "chkEventosComs";
            this.chkEventosComs.Size = new System.Drawing.Size(105, 18);
            this.chkEventosComs.TabIndex = 0;
            // 
            // OrbitaGSCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkEventosComs);
            this.Name = "OrbitaGSCheckBox";           
            this.Size = new System.Drawing.Size(105, 18);
            ((System.ComponentModel.ISupportInitialize)(this.chkEventosComs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion  

        public Comunes.OrbitaUltraCheckEditor chkEventosComs;





       
    }
}
