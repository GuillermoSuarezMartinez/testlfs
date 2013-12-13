namespace Orbita.Controles.Grid
{
    partial class FrmListadoPlantillasPublicas
    {
        /// <summary>
        /// Required designer variable.
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
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCabecera
            // 
            this.lblCabecera.Text = "Marque la plantilla pública que desea importar:";
            // 
            // lstView
            // 
            this.lstView.FullRowSelect = true;
            this.lstView.HideSelection = false;
            // 
            // FrmListadoPlantillasPublicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(647, 351);
            this.Name = "FrmListadoPlantillasPublicas";
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}