namespace Orbita.Controles.Comunes
{
    partial class OrbitaUltraDateTimeEditorAboveFilter
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.Load -= new System.EventHandler(this.OrbitaUltraDateTimeEditorAboveFilter_Load); 
            this.dttHasta.ValueChanged -= new System.EventHandler(this.dttHasta_ValueChanged);
            this.dttDesde.ValueChanged -= new System.EventHandler(this.dttDesde_ValueChanged);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes
        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido del método con el editor de código.
        /// </summary>
        void InitializeComponent()
        {
            this.lblDesde = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.dttDesde = new Orbita.Controles.Comunes.OrbitaUltraDateTimeEditor();
            this.lblHasta = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.dttHasta = new Orbita.Controles.Comunes.OrbitaUltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.dttDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.Location = new System.Drawing.Point(7, 8);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.UseMnemonic = false;
            // 
            // dttDesde
            // 
            this.dttDesde.AutoSize = false;
            this.dttDesde.Location = new System.Drawing.Point(51, 4);
            this.dttDesde.Name = "dttDesde";
            this.dttDesde.Size = new System.Drawing.Size(144, 21);
            this.dttDesde.TabIndex = 0;
            this.dttDesde.ValueChanged += new System.EventHandler(this.dttDesde_ValueChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.Location = new System.Drawing.Point(10, 31);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.UseMnemonic = false;
            // 
            // dttHasta
            // 
            this.dttHasta.AutoSize = false;
            this.dttHasta.Location = new System.Drawing.Point(51, 28);
            this.dttHasta.Name = "dttHasta";
            this.dttHasta.Size = new System.Drawing.Size(144, 21);
            this.dttHasta.TabIndex = 1;
            this.dttHasta.ValueChanged += new System.EventHandler(this.dttHasta_ValueChanged);
            // 
            // OrbitaUltraDateTimeEditorAboveFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dttDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dttHasta);
            this.MaximumSize = new System.Drawing.Size(203, 54);
            this.MinimumSize = new System.Drawing.Size(203, 54);
            this.Name = "OrbitaUltraDateTimeEditorAboveFilter";
            this.Size = new System.Drawing.Size(203, 54);
            this.Load += new System.EventHandler(this.OrbitaUltraDateTimeEditorAboveFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dttDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttHasta)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        OrbitaUltraDateTimeEditor dttDesde;
        OrbitaUltraDateTimeEditor dttHasta;
        OrbitaUltraLabel lblDesde;
        OrbitaUltraLabel lblHasta;
    }
}
