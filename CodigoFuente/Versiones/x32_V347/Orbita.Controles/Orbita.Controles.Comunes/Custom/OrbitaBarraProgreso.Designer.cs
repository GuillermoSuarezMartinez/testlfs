namespace Orbita.Controles.Comunes
{
    partial class OrbitaBarraProgreso
    {
        /// <summary> 
        /// Proporciona funcionalidad para contenedores. Los contenedores son objetos que contienen cero o m�s componentes de forma l�gica.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
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
            // OrbitaBarraProgreso
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Name = "OrbitaBarraProgreso";
            this.Size = new System.Drawing.Size(426, 17);
            this.ResumeLayout(false);
        }
        #endregion
    }
}
