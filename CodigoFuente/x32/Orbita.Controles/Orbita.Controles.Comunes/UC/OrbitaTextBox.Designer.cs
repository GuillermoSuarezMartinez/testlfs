namespace Orbita.Controles.Comunes
{
    partial class OrbitaTextBox
    {
        /// <summary> 
        /// Variable del dise�ador requerida.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se est�n utilizando.
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

        #region C�digo generado por el Dise�ador de componentes
        /// <summary>
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar el contenido del m�todo con el editor de c�digo.
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