namespace Orbita.Controles.Comunes
{
    partial class OrbitaUltraNumericEditorWithFilter
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
            this.Leave -= new System.EventHandler(this.orbitaYearFilter_Leave);
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
            this.neAnyoB = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.neAnyoA = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            ((System.ComponentModel.ISupportInitialize)(this.neAnyoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neAnyoA)).BeginInit();
            this.SuspendLayout();
            // 
            // neAnyoB
            // 
            this.neAnyoB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neAnyoB.Location = new System.Drawing.Point(66, 3);
            this.neAnyoB.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.neAnyoB.MaskInput = "nnnn";
            this.neAnyoB.MaxValue = 9999;
            this.neAnyoB.MinValue = 0;
            this.neAnyoB.Name = "neAnyoB";
            this.neAnyoB.PromptChar = ' ';
            this.neAnyoB.Size = new System.Drawing.Size(59, 21);
            this.neAnyoB.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
            this.neAnyoB.TabIndex = 50;
            // 
            // neAnyoA
            // 
            this.neAnyoA.Location = new System.Drawing.Point(3, 3);
            this.neAnyoA.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.neAnyoA.MaskInput = "nnnn";
            this.neAnyoA.MaxValue = 9999;
            this.neAnyoA.MinValue = 0;
            this.neAnyoA.Name = "neAnyoA";
            this.neAnyoA.PromptChar = ' ';
            this.neAnyoA.Size = new System.Drawing.Size(59, 21);
            this.neAnyoA.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter;
            this.neAnyoA.TabIndex = 48;
            // 
            // OrbitaUltraNumericEditorWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.neAnyoB);
            this.Controls.Add(this.neAnyoA);
            this.MaximumSize = new System.Drawing.Size(129, 27);
            this.MinimumSize = new System.Drawing.Size(129, 27);
            this.Name = "OrbitaUltraNumericEditorWithFilter";
            this.Size = new System.Drawing.Size(129, 27);
            this.Leave += new System.EventHandler(this.orbitaYearFilter_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.neAnyoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neAnyoA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        OrbitaUltraNumericEditor neAnyoA;
        OrbitaUltraNumericEditor neAnyoB;
    }
}
