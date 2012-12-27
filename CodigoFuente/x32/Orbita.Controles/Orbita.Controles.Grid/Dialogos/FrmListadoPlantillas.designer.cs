namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Colección de plantillas.
    /// </summary>
    partial class FrmListadoPlantillas
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
            this.nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.identificador = ((Orbita.Controles.Comunes.OColumnHeader)(new Orbita.Controles.Comunes.OColumnHeader()));
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCabecera
            // 
            this.lblCabecera.Size = new System.Drawing.Size(504, 21);
            // 
            // lstView
            // 
            this.lstView.AllowColumnReorder = true;
            this.lstView.CheckBoxes = true;
            this.lstView.Size = new System.Drawing.Size(432, 253);
            // 
            // pnlBotones
            // 
            this.pnlBotones.Location = new System.Drawing.Point(439, 26);
            this.pnlBotones.Size = new System.Drawing.Size(70, 268);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Size = new System.Drawing.Size(434, 268);
            // 
            // lblSinElementos
            // 
            this.lblSinElementos.Size = new System.Drawing.Size(432, 13);
            // 
            // nombre
            // 
            this.nombre.Text = "Nombre";
            this.nombre.Width = 184;
            // 
            // descripcion
            // 
            this.descripcion.Text = "Descripción";
            this.descripcion.Width = 356;
            // 
            // identificador
            // 
            this.identificador.Text = "Identificador";
            this.identificador.Visible = true;
            this.identificador.Width = 0;
            // 
            // ListadoPlantillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 299);
            this.Name = "ListadoPlantillas";
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        System.Windows.Forms.ColumnHeader nombre;
        System.Windows.Forms.ColumnHeader descripcion;
        Orbita.Controles.Comunes.OColumnHeader identificador;
    }
}