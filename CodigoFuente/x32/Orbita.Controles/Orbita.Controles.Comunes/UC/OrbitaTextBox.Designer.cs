namespace Orbita.Controles.Comunes
{
    partial class OrbitaTextBox
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
            this.TextChanged -= new System.EventHandler(this.OrbitaTextChanged);
            this.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.OrbitaKeyPress);
            this.fuente.Dispose();
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
            components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // OrbitaTextBox
            // 
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 9F);
            this.TextChanged += new System.EventHandler(this.OrbitaTextChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrbitaKeyPress);
            this.ResumeLayout(false);
        }
        #endregion
    }
}