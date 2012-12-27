namespace Orbita.Controles.Combo
{
    partial class OrbitaUltraCombo 
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
            this.InitializeLayout -= new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.OrbitaUltraCombo_InitializeLayout);
            this.ValueChanged -= new System.EventHandler(this.OrbitaUltraCombo_ValueChanged);
            this.AfterSortChange -= new Infragistics.Win.UltraWinGrid.BandEventHandler(this.OrbitaUltraCombo_AfterSortChange);
            this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.OrbitaUltraCombo_KeyDown);
            this.Validating -= new System.ComponentModel.CancelEventHandler(this.OrbitaUltraCombo_Validating);
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
            components = new System.ComponentModel.Container();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // OrbitaUltraCombo
            // 
            this.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.OrbitaUltraCombo_InitializeLayout);
            this.ValueChanged += new System.EventHandler(this.OrbitaUltraCombo_ValueChanged);
            this.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.OrbitaUltraCombo_AfterSortChange);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrbitaUltraCombo_KeyDown);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.OrbitaUltraCombo_Validating);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
