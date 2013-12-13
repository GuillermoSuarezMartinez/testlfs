using Orbita.Controles.Comunes;
namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSInspeccionOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSInspeccionOrdenes));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpOrdenes = new System.Windows.Forms.TableLayoutPanel();
            this.lblEtiquetaOrden1 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblOrden1 = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblOrden4 = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblEtiquetaOrden2 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblEtiquetaOrden4 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblOrden3 = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblOrden2 = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblEtiquetaOrden3 = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.tlpOrdenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(85, 26);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cmsCopiar_Closing);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCopiar_Opening);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // tlpOrdenes
            // 
            this.tlpOrdenes.BackColor = System.Drawing.SystemColors.Control;
            this.tlpOrdenes.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpOrdenes.ColumnCount = 2;
            this.tlpOrdenes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.62191F));
            this.tlpOrdenes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.37809F));
            this.tlpOrdenes.Controls.Add(this.lblEtiquetaOrden1, 0, 0);
            this.tlpOrdenes.Controls.Add(this.lblOrden1, 1, 0);
            this.tlpOrdenes.Controls.Add(this.lblOrden4, 1, 3);
            this.tlpOrdenes.Controls.Add(this.lblEtiquetaOrden2, 0, 1);
            this.tlpOrdenes.Controls.Add(this.lblEtiquetaOrden4, 0, 3);
            this.tlpOrdenes.Controls.Add(this.lblOrden3, 1, 2);
            this.tlpOrdenes.Controls.Add(this.lblOrden2, 1, 1);
            this.tlpOrdenes.Controls.Add(this.lblEtiquetaOrden3, 0, 2);
            this.tlpOrdenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOrdenes.Location = new System.Drawing.Point(0, 0);
            this.tlpOrdenes.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOrdenes.Name = "tlpOrdenes";
            this.tlpOrdenes.RowCount = 4;
            this.tlpOrdenes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOrdenes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.5814F));
            this.tlpOrdenes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.5814F));
            this.tlpOrdenes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.25581F));
            this.tlpOrdenes.Size = new System.Drawing.Size(283, 87);
            this.tlpOrdenes.TabIndex = 55;
            // 
            // lblEtiquetaOrden1
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblEtiquetaOrden1.Appearance = appearance1;
            this.lblEtiquetaOrden1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblEtiquetaOrden1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEtiquetaOrden1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaOrden1.Location = new System.Drawing.Point(4, 4);
            this.lblEtiquetaOrden1.Name = "lblEtiquetaOrden1";
            this.lblEtiquetaOrden1.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblEtiquetaOrden1.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblEtiquetaOrden1.Size = new System.Drawing.Size(74, 14);
            this.lblEtiquetaOrden1.TabIndex = 49;
            this.lblEtiquetaOrden1.Text = "Orden 1:";
            this.lblEtiquetaOrden1.UseMnemonic = false;
            // 
            // lblOrden1
            // 
            this.lblOrden1.BackColor = System.Drawing.Color.White;
            this.lblOrden1.ContextMenuStrip = this.contextMenuStrip1;
            this.lblOrden1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrden1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrden1.Location = new System.Drawing.Point(82, 1);
            this.lblOrden1.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrden1.Name = "lblOrden1";
            this.lblOrden1.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblOrden1.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblOrden1.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblOrden1.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblOrden1.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblOrden1.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblOrden1.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblOrden1.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.lblOrden1.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblOrden1.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.lblOrden1.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblOrden1.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblOrden1.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblOrden1.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblOrden1.Size = new System.Drawing.Size(200, 20);
            this.lblOrden1.TabIndex = 45;
            this.lblOrden1.Tag = "";
            this.lblOrden1.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblOrden1_OnCambioDato);
            this.lblOrden1.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblOrden1_OnAlarma);
            this.lblOrden1.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblOrden1_OnComunicacion);
            // 
            // lblOrden4
            // 
            this.lblOrden4.BackColor = System.Drawing.Color.White;
            this.lblOrden4.ContextMenuStrip = this.contextMenuStrip1;
            this.lblOrden4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrden4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrden4.Location = new System.Drawing.Point(82, 66);
            this.lblOrden4.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrden4.Name = "lblOrden4";
            this.lblOrden4.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblOrden4.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblOrden4.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblOrden4.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblOrden4.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblOrden4.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblOrden4.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblOrden4.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas1")));
            this.lblOrden4.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblOrden4.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios1")));
            this.lblOrden4.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblOrden4.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblOrden4.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblOrden4.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblOrden4.Size = new System.Drawing.Size(200, 20);
            this.lblOrden4.TabIndex = 48;
            this.lblOrden4.Tag = "";
            this.lblOrden4.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblOrden4_OnCambioDato);
            this.lblOrden4.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblOrden4_OnAlarma);
            this.lblOrden4.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblOrden4_OnComunicacion);
            // 
            // lblEtiquetaOrden2
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblEtiquetaOrden2.Appearance = appearance2;
            this.lblEtiquetaOrden2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblEtiquetaOrden2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEtiquetaOrden2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaOrden2.Location = new System.Drawing.Point(4, 25);
            this.lblEtiquetaOrden2.Name = "lblEtiquetaOrden2";
            this.lblEtiquetaOrden2.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblEtiquetaOrden2.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblEtiquetaOrden2.Size = new System.Drawing.Size(74, 15);
            this.lblEtiquetaOrden2.TabIndex = 50;
            this.lblEtiquetaOrden2.Text = "Orden 2:";
            this.lblEtiquetaOrden2.UseMnemonic = false;
            // 
            // lblEtiquetaOrden4
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblEtiquetaOrden4.Appearance = appearance3;
            this.lblEtiquetaOrden4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblEtiquetaOrden4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEtiquetaOrden4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaOrden4.Location = new System.Drawing.Point(4, 69);
            this.lblEtiquetaOrden4.Name = "lblEtiquetaOrden4";
            this.lblEtiquetaOrden4.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblEtiquetaOrden4.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblEtiquetaOrden4.Size = new System.Drawing.Size(74, 14);
            this.lblEtiquetaOrden4.TabIndex = 52;
            this.lblEtiquetaOrden4.Text = "Orden 4:";
            this.lblEtiquetaOrden4.UseMnemonic = false;
            // 
            // lblOrden3
            // 
            this.lblOrden3.BackColor = System.Drawing.Color.White;
            this.lblOrden3.ContextMenuStrip = this.contextMenuStrip1;
            this.lblOrden3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrden3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrden3.Location = new System.Drawing.Point(82, 44);
            this.lblOrden3.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrden3.Name = "lblOrden3";
            this.lblOrden3.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblOrden3.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblOrden3.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblOrden3.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblOrden3.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblOrden3.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblOrden3.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblOrden3.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas2")));
            this.lblOrden3.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblOrden3.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios2")));
            this.lblOrden3.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblOrden3.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblOrden3.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblOrden3.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblOrden3.Size = new System.Drawing.Size(200, 21);
            this.lblOrden3.TabIndex = 47;
            this.lblOrden3.Tag = "";
            this.lblOrden3.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblOrden3_OnCambioDato);
            this.lblOrden3.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblOrden3_OnAlarma);
            this.lblOrden3.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblOrden3_OnComunicacion);
            // 
            // lblOrden2
            // 
            this.lblOrden2.BackColor = System.Drawing.Color.White;
            this.lblOrden2.ContextMenuStrip = this.contextMenuStrip1;
            this.lblOrden2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrden2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrden2.Location = new System.Drawing.Point(82, 22);
            this.lblOrden2.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrden2.Name = "lblOrden2";
            this.lblOrden2.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblOrden2.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblOrden2.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblOrden2.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblOrden2.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblOrden2.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblOrden2.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblOrden2.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas3")));
            this.lblOrden2.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblOrden2.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios3")));
            this.lblOrden2.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblOrden2.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblOrden2.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblOrden2.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblOrden2.Size = new System.Drawing.Size(200, 21);
            this.lblOrden2.TabIndex = 46;
            this.lblOrden2.Tag = "";
            this.lblOrden2.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblOrden2_OnCambioDato);
            this.lblOrden2.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblOrden2_OnAlarma);
            this.lblOrden2.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblOrden2_OnComunicacion);
            // 
            // lblEtiquetaOrden3
            // 
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.lblEtiquetaOrden3.Appearance = appearance4;
            this.lblEtiquetaOrden3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblEtiquetaOrden3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEtiquetaOrden3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetaOrden3.Location = new System.Drawing.Point(4, 47);
            this.lblEtiquetaOrden3.Name = "lblEtiquetaOrden3";
            this.lblEtiquetaOrden3.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblEtiquetaOrden3.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblEtiquetaOrden3.Size = new System.Drawing.Size(74, 15);
            this.lblEtiquetaOrden3.TabIndex = 51;
            this.lblEtiquetaOrden3.Text = "Orden 3:";
            this.lblEtiquetaOrden3.UseMnemonic = false;
            // 
            // OrbitaGSInspeccionOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpOrdenes);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(283, 87);
            this.MinimumSize = new System.Drawing.Size(283, 87);
            this.Name = "OrbitaGSInspeccionOrdenes";            
            this.Size = new System.Drawing.Size(283, 87);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tlpOrdenes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOrdenes;
        private OrbitaUltraLabel lblEtiquetaOrden1;
        public OrbitaGSLabel lblOrden1;
        public OrbitaGSLabel lblOrden4;
        private OrbitaUltraLabel lblEtiquetaOrden2;
        private OrbitaUltraLabel lblEtiquetaOrden4;
        public OrbitaGSLabel lblOrden3;
        public OrbitaGSLabel lblOrden2;
        private OrbitaUltraLabel lblEtiquetaOrden3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
    }
}
