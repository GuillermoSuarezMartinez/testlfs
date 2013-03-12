namespace Orbita.Controles.Contenedores
{
    partial class OrbitaForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaForm));
            this.toolTip = new Orbita.Controles.Comunes.OrbitaToolTip(this.components);
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // OrbitaForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrbitaForm";
            this.Text = this.Name;
            this.ResumeLayout(false);
        }
        #endregion

        protected Comunes.OrbitaToolTip toolTip;
    }
}