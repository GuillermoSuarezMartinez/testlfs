namespace Orbita.Controles.Contenedores
{
    partial class OrbitaDialog
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
            this.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar el contenido del método con el editor de código.
        /// </summary>
        void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.OrbToolTip = new Orbita.Controles.Comunes.OrbitaToolTip(this.components);
            this.SuspendLayout();
            // 
            // OrbToolTip
            // 
            this.OrbToolTip.AutomaticDelay = 1000;
            this.OrbToolTip.ShowAlways = true;
            // 
            // OrbitaDialog
            // 
            this.ClientSize = new System.Drawing.Size(294, 276);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "OrbitaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.ResumeLayout(false);
        }
        #endregion

        Comunes.OrbitaToolTip OrbToolTip;
    }
}