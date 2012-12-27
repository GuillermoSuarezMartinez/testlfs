namespace Orbita.Controles.Comunes
{
    partial class OrbitaUltraMaskedEdit
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
            this.Enter -= new System.EventHandler(this.OrbitaUltraMaskedEdit_Enter);
            this.Click -= new System.EventHandler(this.OrbitaUltraMaskedEdit_Click);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes
        /// <summary> 
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // OrbitaUltraMaskedEdit
            // 
            this.Enter += new System.EventHandler(this.OrbitaUltraMaskedEdit_Enter);
            this.Click += new System.EventHandler(this.OrbitaUltraMaskedEdit_Click);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
