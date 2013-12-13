namespace Orbita.Controles.VA
{
    partial class CtrlContenedorFormularios
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
            this.TabContenedor = new Orbita.Controles.Contenedores.OrbitaUltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            ((System.ComponentModel.ISupportInitialize)(this.TabContenedor)).BeginInit();
            this.TabContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabContenedor
            // 
            this.TabContenedor.Controls.Add(this.ultraTabSharedControlsPage1);
            this.TabContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabContenedor.Location = new System.Drawing.Point(0, 0);
            this.TabContenedor.Name = "TabContenedor";
            this.TabContenedor.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.TabContenedor.ShowPartialTabs = Infragistics.Win.DefaultableBoolean.False;
            this.TabContenedor.ShowTabListButton = Infragistics.Win.DefaultableBoolean.False;
            this.TabContenedor.ShowToolTips = false;
            this.TabContenedor.Size = new System.Drawing.Size(636, 359);
            this.TabContenedor.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
            this.TabContenedor.TabIndex = 3;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(636, 359);
            // 
            // CtrlContenedorFormularios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabContenedor);
            this.Name = "CtrlContenedorFormularios";
            this.Size = new System.Drawing.Size(636, 359);
            ((System.ComponentModel.ISupportInitialize)(this.TabContenedor)).EndInit();
            this.TabContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Orbita.Controles.Contenedores.OrbitaUltraTabControl TabContenedor;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
    }
}
