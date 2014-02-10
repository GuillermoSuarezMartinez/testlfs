namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSVisorBitmap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSVisorBitmap));
            this.pctEventosComs = new Orbita.Controles.VA.OrbitaVisorBitmap();
            this.SuspendLayout();
            // 
            // pctEventosComs
            // 
            this.pctEventosComs.AutoCenter = true;
            this.pctEventosComs.AutoPan = true;
            this.pctEventosComs.BackColor = System.Drawing.SystemColors.Control;
            this.pctEventosComs.Codigo = null;
            this.pctEventosComs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctEventosComs.GraficoActual = null;
            this.pctEventosComs.ImagenActual = null;
            this.pctEventosComs.InvertMouse = false;
            this.pctEventosComs.Location = new System.Drawing.Point(0, 0);
            this.pctEventosComs.MantenerBotonDerecho = Orbita.Controles.VA.OpcionMantenerClickBotones.Rectangulo;
            this.pctEventosComs.MostrarBtnAbrir = false;
            this.pctEventosComs.MostrarbtnGuardar = false;
            this.pctEventosComs.MostrarBtnInfo = false;
            this.pctEventosComs.MostrarBtnMaximinzar = false;
            this.pctEventosComs.MostrarBtnReproduccion = false;
            this.pctEventosComs.MostrarBtnSiguienteAnterior = false;
            this.pctEventosComs.MostrarBtnSnap = false;
            this.pctEventosComs.MostrarLblTitulo = false;
            this.pctEventosComs.MostrarStatusBar = false;
            this.pctEventosComs.MostrarStatusFps = false;
            this.pctEventosComs.MostrarStatusMensaje = false;
            this.pctEventosComs.MostrarStatusValorPixel = false;
            this.pctEventosComs.MostrarToolStrip = false;
            this.pctEventosComs.Name = "pctEventosComs";
            this.pctEventosComs.PermitirClickZoom = true;
            this.pctEventosComs.PermitirZoom = true;
            this.pctEventosComs.Size = new System.Drawing.Size(150, 150);
            this.pctEventosComs.TabIndex = 0;
            // 
            // OrbitaGSVisorBitmap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.pctEventosComs);
            this.Name = "OrbitaGSVisorBitmap";            
            this.ResumeLayout(false);

        }
        #endregion

        public VA.OrbitaVisorBitmap pctEventosComs;





    }
}
