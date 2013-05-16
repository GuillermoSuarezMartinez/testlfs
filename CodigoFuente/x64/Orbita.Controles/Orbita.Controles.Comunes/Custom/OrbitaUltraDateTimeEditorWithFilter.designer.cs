namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// OrbitaUltraDateTimeEditorFilterCustom
    /// </summary>
    partial class OrbitaUltraDateTimeEditorWithFilter
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.dttDesde.ValueChanged -= new System.EventHandler(this.dtDesde_ValueChanged);
            this.dttHasta.ValueChanged -= new System.EventHandler(this.dtHasta_ValueChanged);
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
            this.dttDesde = new Orbita.Controles.Comunes.OrbitaUltraDateTimeEditor();
            this.dttHasta = new Orbita.Controles.Comunes.OrbitaUltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.dttDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // dttDesde
            // 
            this.dttDesde.Location = new System.Drawing.Point(3, 3);
            this.dttDesde.MaskInput = "{date} {time}";
            this.dttDesde.Name = "dttDesde";
            this.dttDesde.Size = new System.Drawing.Size(123, 21);
            this.dttDesde.TabIndex = 5;
            this.dttDesde.ValueChanged += new System.EventHandler(this.dtDesde_ValueChanged);
            // 
            // dttHasta
            // 
            this.dttHasta.Location = new System.Drawing.Point(128, 3);
            this.dttHasta.MaskInput = "{date} {time}";
            this.dttHasta.Name = "dttHasta";
            this.dttHasta.Size = new System.Drawing.Size(123, 21);
            this.dttHasta.TabIndex = 6;
            this.dttHasta.ValueChanged += new System.EventHandler(this.dtHasta_ValueChanged);
            // 
            // OrbitaUltraDateTimeEditorWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.dttHasta);
            this.Controls.Add(this.dttDesde);
            this.MaximumSize = new System.Drawing.Size(254, 26);
            this.MinimumSize = new System.Drawing.Size(254, 26);
            this.Name = "OrbitaUltraDateTimeEditorWithFilter";
            this.Size = new System.Drawing.Size(254, 26);
            ((System.ComponentModel.ISupportInitialize)(this.dttDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttHasta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        OrbitaUltraDateTimeEditor dttDesde;
        OrbitaUltraDateTimeEditor dttHasta;
    }
}
