namespace Orbita.Controles.Comunes
{
    partial class OrbitaBarraProgreso
    {
        /// <summary> 
        /// Proporciona funcionalidad para contenedores. Los contenedores son objetos que contienen cero o más componentes de forma lógica.
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

        #region Código generado por el Diseñador de componentes
        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido del método con el editor de código.
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
