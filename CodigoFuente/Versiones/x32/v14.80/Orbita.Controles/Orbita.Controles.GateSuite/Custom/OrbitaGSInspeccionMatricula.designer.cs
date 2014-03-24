using Orbita.Controles.Comunes;
namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSInspeccionMatricula
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSInspeccionMatricula));
            this.tlpMatricula = new System.Windows.Forms.TableLayoutPanel();
            this.lblMatricula = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblPorcentajeMatricula = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblFiabilidadMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecodTOSMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecodMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblInspeccionMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.tlpMatricula.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMatricula
            // 
            this.tlpMatricula.BackColor = System.Drawing.SystemColors.Control;
            this.tlpMatricula.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMatricula.ColumnCount = 3;
            this.tlpMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpMatricula.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpMatricula.Controls.Add(this.lblMatricula, 0, 0);
            this.tlpMatricula.Controls.Add(this.lblPorcentajeMatricula, 2, 1);
            this.tlpMatricula.Controls.Add(this.lblFiabilidadMatricula, 1, 1);
            this.tlpMatricula.Controls.Add(this.panel1, 0, 1);
            this.tlpMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMatricula.Location = new System.Drawing.Point(0, 0);
            this.tlpMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMatricula.Name = "tlpMatricula";
            this.tlpMatricula.RowCount = 3;
            this.tlpMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMatricula.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMatricula.Size = new System.Drawing.Size(152, 53);
            this.tlpMatricula.TabIndex = 54;
            // 
            // lblMatricula
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblMatricula.Appearance = appearance1;
            this.lblMatricula.BackColorInternal = System.Drawing.Color.Navy;
            this.tlpMatricula.SetColumnSpan(this.lblMatricula, 3);
            this.lblMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.ForeColor = System.Drawing.Color.White;
            this.lblMatricula.Location = new System.Drawing.Point(1, 1);
            this.lblMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblMatricula.Size = new System.Drawing.Size(150, 20);
            this.lblMatricula.TabIndex = 44;
            this.lblMatricula.Tag = "";
            this.lblMatricula.Text = "MATRÍCULA";
            this.lblMatricula.UseMnemonic = false;
            // 
            // lblPorcentajeMatricula
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPorcentajeMatricula.Appearance = appearance2;
            this.lblPorcentajeMatricula.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPorcentajeMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPorcentajeMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeMatricula.Location = new System.Drawing.Point(120, 22);
            this.lblPorcentajeMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblPorcentajeMatricula.Name = "lblPorcentajeMatricula";
            this.lblPorcentajeMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblPorcentajeMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblPorcentajeMatricula.Size = new System.Drawing.Size(31, 30);
            this.lblPorcentajeMatricula.TabIndex = 45;
            this.lblPorcentajeMatricula.Text = "%";
            this.lblPorcentajeMatricula.UseMnemonic = false;
            // 
            // lblFiabilidadMatricula
            // 
            this.lblFiabilidadMatricula.BackColor = System.Drawing.Color.White;
            this.lblFiabilidadMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiabilidadMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiabilidadMatricula.Location = new System.Drawing.Point(82, 22);
            this.lblFiabilidadMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiabilidadMatricula.Name = "lblFiabilidadMatricula";
            this.lblFiabilidadMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblFiabilidadMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblFiabilidadMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblFiabilidadMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblFiabilidadMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblFiabilidadMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblFiabilidadMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblFiabilidadMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.lblFiabilidadMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblFiabilidadMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.lblFiabilidadMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblFiabilidadMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblFiabilidadMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblFiabilidadMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblFiabilidadMatricula.Size = new System.Drawing.Size(37, 30);
            this.lblFiabilidadMatricula.TabIndex = 47;
            this.lblFiabilidadMatricula.Tag = "";
            this.lblFiabilidadMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblFiabilidadMatricula_OnCambioDato);
            this.lblFiabilidadMatricula.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblFiabilidadMatricula_OnAlarma);
            this.lblFiabilidadMatricula.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblFiabilidadMatricula_OnComunicacion);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecodTOSMatricula);
            this.panel1.Controls.Add(this.lblRecodMatricula);
            this.panel1.Controls.Add(this.lblInspeccionMatricula);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 30);
            this.panel1.TabIndex = 49;
            // 
            // lblRecodTOSMatricula
            // 
            this.lblRecodTOSMatricula.BackColor = System.Drawing.Color.White;
            this.lblRecodTOSMatricula.ContextMenuStrip = this.contextMenuStrip1;
            this.lblRecodTOSMatricula.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodTOSMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodTOSMatricula.Location = new System.Drawing.Point(53, 0);
            this.lblRecodTOSMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodTOSMatricula.Name = "lblRecodTOSMatricula";
            this.lblRecodTOSMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodTOSMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodTOSMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodTOSMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodTOSMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodTOSMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodTOSMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodTOSMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas1")));
            this.lblRecodTOSMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodTOSMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios1")));
            this.lblRecodTOSMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodTOSMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodTOSMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodTOSMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodTOSMatricula.Size = new System.Drawing.Size(27, 30);
            this.lblRecodTOSMatricula.TabIndex = 48;
            this.lblRecodTOSMatricula.Tag = "";
            this.lblRecodTOSMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodMatricula_OnCambioDato);
            this.lblRecodTOSMatricula.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodTOSMatricula_OnAlarma);
            this.lblRecodTOSMatricula.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodTOSMatricula_OnComunicacion);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 48);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cmsCopiar_Closing);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCopiar_Opening);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // lblRecodMatricula
            // 
            this.lblRecodMatricula.BackColor = System.Drawing.Color.White;
            this.lblRecodMatricula.ContextMenuStrip = this.contextMenuStrip1;
            this.lblRecodMatricula.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodMatricula.Location = new System.Drawing.Point(27, 0);
            this.lblRecodMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodMatricula.Name = "lblRecodMatricula";
            this.lblRecodMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas2")));
            this.lblRecodMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios2")));
            this.lblRecodMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodMatricula.Size = new System.Drawing.Size(26, 30);
            this.lblRecodMatricula.TabIndex = 49;
            this.lblRecodMatricula.Tag = "";
            this.lblRecodMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodMatricula_OnCambioDato);
            this.lblRecodMatricula.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodMatricula_OnAlarma);
            this.lblRecodMatricula.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodMatricula_OnComunicacion);
            // 
            // lblInspeccionMatricula
            // 
            this.lblInspeccionMatricula.BackColor = System.Drawing.Color.White;
            this.lblInspeccionMatricula.ContextMenuStrip = this.contextMenuStrip1;
            this.lblInspeccionMatricula.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInspeccionMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspeccionMatricula.Location = new System.Drawing.Point(0, 0);
            this.lblInspeccionMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspeccionMatricula.Name = "lblInspeccionMatricula";
            this.lblInspeccionMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblInspeccionMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblInspeccionMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblInspeccionMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblInspeccionMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblInspeccionMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblInspeccionMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblInspeccionMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas3")));
            this.lblInspeccionMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblInspeccionMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios3")));
            this.lblInspeccionMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblInspeccionMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblInspeccionMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblInspeccionMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblInspeccionMatricula.Size = new System.Drawing.Size(27, 30);
            this.lblInspeccionMatricula.TabIndex = 47;
            this.lblInspeccionMatricula.Tag = "";
            this.lblInspeccionMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblInspeccionMatricula_OnCambioDato);
            this.lblInspeccionMatricula.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblInspeccionMatricula_OnAlarma);
            this.lblInspeccionMatricula.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblInspeccionMatricula_OnComunicacion);
            // 
            // OrbitaGSInspeccionMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMatricula);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(152, 53);
            this.MinimumSize = new System.Drawing.Size(152, 53);
            this.Name = "OrbitaGSInspeccionMatricula";
           
            this.Size = new System.Drawing.Size(152, 53);
            this.tlpMatricula.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public OrbitaGSLabel lblFiabilidadMatricula;
        private OrbitaUltraLabel lblPorcentajeMatricula;
        private OrbitaUltraLabel lblMatricula;
        private System.Windows.Forms.TableLayoutPanel tlpMatricula;
        private System.Windows.Forms.Panel panel1;
        public OrbitaGSLabel lblRecodTOSMatricula;
        public OrbitaGSLabel lblInspeccionMatricula;
        public OrbitaGSLabel lblRecodMatricula;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
    }
}
