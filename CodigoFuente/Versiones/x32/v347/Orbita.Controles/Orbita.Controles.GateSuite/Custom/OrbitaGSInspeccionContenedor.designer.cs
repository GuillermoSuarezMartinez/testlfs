using Orbita.Controles.Comunes;
namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSInspeccionContenedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSInspeccionContenedor));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.tlpContenedor = new System.Windows.Forms.TableLayoutPanel();
            this.lblPorcentajeISO = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblPorcentajeMatricula = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblFiabilidadISO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblFiabilidadMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblMatricula = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblISO = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblContenedor = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecodTOSMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecodMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblInspeccionMatricula = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRecodTOSISO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblRecodISO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblInspeccionISO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.tlpContenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContenedor
            // 
            this.tlpContenedor.BackColor = System.Drawing.SystemColors.Control;
            this.tlpContenedor.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpContenedor.ColumnCount = 4;
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpContenedor.Controls.Add(this.lblPorcentajeISO, 3, 2);
            this.tlpContenedor.Controls.Add(this.lblPorcentajeMatricula, 3, 1);
            this.tlpContenedor.Controls.Add(this.lblFiabilidadISO, 2, 2);
            this.tlpContenedor.Controls.Add(this.lblFiabilidadMatricula, 2, 1);
            this.tlpContenedor.Controls.Add(this.lblMatricula, 0, 1);
            this.tlpContenedor.Controls.Add(this.lblISO, 0, 2);
            this.tlpContenedor.Controls.Add(this.lblContenedor, 0, 0);
            this.tlpContenedor.Controls.Add(this.panel1, 1, 1);
            this.tlpContenedor.Controls.Add(this.panel2, 1, 2);
            this.tlpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenedor.Location = new System.Drawing.Point(0, 0);
            this.tlpContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContenedor.Name = "tlpContenedor";
            this.tlpContenedor.RowCount = 3;
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpContenedor.Size = new System.Drawing.Size(241, 80);
            this.tlpContenedor.TabIndex = 53;
            // 
            // lblPorcentajeISO
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblPorcentajeISO.Appearance = appearance1;
            this.lblPorcentajeISO.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPorcentajeISO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPorcentajeISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeISO.Location = new System.Drawing.Point(220, 54);
            this.lblPorcentajeISO.Name = "lblPorcentajeISO";
            this.lblPorcentajeISO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblPorcentajeISO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblPorcentajeISO.Size = new System.Drawing.Size(17, 22);
            this.lblPorcentajeISO.TabIndex = 51;
            this.lblPorcentajeISO.Text = "%";
            this.lblPorcentajeISO.UseMnemonic = false;
            // 
            // lblPorcentajeMatricula
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPorcentajeMatricula.Appearance = appearance2;
            this.lblPorcentajeMatricula.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPorcentajeMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPorcentajeMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeMatricula.Location = new System.Drawing.Point(220, 25);
            this.lblPorcentajeMatricula.Name = "lblPorcentajeMatricula";
            this.lblPorcentajeMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblPorcentajeMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblPorcentajeMatricula.Size = new System.Drawing.Size(17, 22);
            this.lblPorcentajeMatricula.TabIndex = 50;
            this.lblPorcentajeMatricula.Text = "%";
            this.lblPorcentajeMatricula.UseMnemonic = false;
            // 
            // lblFiabilidadISO
            // 
            this.lblFiabilidadISO.BackColor = System.Drawing.Color.White;
            this.lblFiabilidadISO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiabilidadISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiabilidadISO.Location = new System.Drawing.Point(179, 51);
            this.lblFiabilidadISO.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiabilidadISO.Name = "lblFiabilidadISO";
            this.lblFiabilidadISO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblFiabilidadISO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblFiabilidadISO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblFiabilidadISO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblFiabilidadISO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblFiabilidadISO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblFiabilidadISO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblFiabilidadISO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.lblFiabilidadISO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblFiabilidadISO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.lblFiabilidadISO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblFiabilidadISO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblFiabilidadISO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblFiabilidadISO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblFiabilidadISO.Size = new System.Drawing.Size(37, 28);
            this.lblFiabilidadISO.TabIndex = 47;
            this.lblFiabilidadISO.Tag = "";
            this.lblFiabilidadISO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblFiabilidadISO_OnCambioDato);
            this.lblFiabilidadISO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblFiabilidadISO_OnAlarma);
            this.lblFiabilidadISO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblFiabilidadISO_OnComunicacion);
            // 
            // lblFiabilidadMatricula
            // 
            this.lblFiabilidadMatricula.BackColor = System.Drawing.Color.White;
            this.lblFiabilidadMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiabilidadMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiabilidadMatricula.Location = new System.Drawing.Point(179, 22);
            this.lblFiabilidadMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiabilidadMatricula.Name = "lblFiabilidadMatricula";
            this.lblFiabilidadMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblFiabilidadMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblFiabilidadMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblFiabilidadMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblFiabilidadMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblFiabilidadMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblFiabilidadMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblFiabilidadMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas1")));
            this.lblFiabilidadMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblFiabilidadMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios1")));
            this.lblFiabilidadMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblFiabilidadMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblFiabilidadMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblFiabilidadMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblFiabilidadMatricula.Size = new System.Drawing.Size(37, 28);
            this.lblFiabilidadMatricula.TabIndex = 47;
            this.lblFiabilidadMatricula.Tag = "";
            this.lblFiabilidadMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblFiabilidadMatricula_OnCambioDato);
            this.lblFiabilidadMatricula.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblFiabilidadMatricula_OnAlarma);
            this.lblFiabilidadMatricula.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblFiabilidadMatricula_OnComunicacion);
            // 
            // lblMatricula
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblMatricula.Appearance = appearance3;
            this.lblMatricula.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Location = new System.Drawing.Point(4, 25);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblMatricula.Size = new System.Drawing.Size(45, 22);
            this.lblMatricula.TabIndex = 49;
            this.lblMatricula.Tag = "";
            this.lblMatricula.Text = "COD";
            this.lblMatricula.UseMnemonic = false;
            // 
            // lblISO
            // 
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.lblISO.Appearance = appearance4;
            this.lblISO.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblISO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblISO.Location = new System.Drawing.Point(4, 54);
            this.lblISO.Name = "lblISO";
            this.lblISO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblISO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblISO.Size = new System.Drawing.Size(45, 22);
            this.lblISO.TabIndex = 44;
            this.lblISO.Tag = "";
            this.lblISO.Text = "ISO";
            this.lblISO.UseMnemonic = false;
            // 
            // lblContenedor
            // 
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.lblContenedor.Appearance = appearance5;
            this.lblContenedor.BackColorInternal = System.Drawing.Color.Navy;
            this.tlpContenedor.SetColumnSpan(this.lblContenedor, 4);
            this.lblContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenedor.ForeColor = System.Drawing.Color.White;
            this.lblContenedor.Location = new System.Drawing.Point(1, 1);
            this.lblContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.lblContenedor.Name = "lblContenedor";
            this.lblContenedor.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblContenedor.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblContenedor.Size = new System.Drawing.Size(239, 20);
            this.lblContenedor.TabIndex = 44;
            this.lblContenedor.Tag = "";
            this.lblContenedor.Text = "CONTENEDOR";
            this.lblContenedor.UseMnemonic = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecodTOSMatricula);
            this.panel1.Controls.Add(this.lblRecodMatricula);
            this.panel1.Controls.Add(this.lblInspeccionMatricula);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(53, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 28);
            this.panel1.TabIndex = 52;
            // 
            // lblRecodTOSMatricula
            // 
            this.lblRecodTOSMatricula.BackColor = System.Drawing.Color.White;
            this.lblRecodTOSMatricula.ContextMenuStrip = this.contextMenuStrip1;
            this.lblRecodTOSMatricula.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodTOSMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodTOSMatricula.Location = new System.Drawing.Point(88, 0);
            this.lblRecodTOSMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodTOSMatricula.Name = "lblRecodTOSMatricula";
            this.lblRecodTOSMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodTOSMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodTOSMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodTOSMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodTOSMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodTOSMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodTOSMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodTOSMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas2")));
            this.lblRecodTOSMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodTOSMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios2")));
            this.lblRecodTOSMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodTOSMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodTOSMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodTOSMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodTOSMatricula.Size = new System.Drawing.Size(37, 28);
            this.lblRecodTOSMatricula.TabIndex = 49;
            this.lblRecodTOSMatricula.Tag = "";
            this.lblRecodTOSMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodTOSMatricula_OnCambioDato);
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
            this.lblRecodMatricula.Location = new System.Drawing.Point(45, 0);
            this.lblRecodMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodMatricula.Name = "lblRecodMatricula";
            this.lblRecodMatricula.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodMatricula.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodMatricula.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodMatricula.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodMatricula.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodMatricula.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodMatricula.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas3")));
            this.lblRecodMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios3")));
            this.lblRecodMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodMatricula.Size = new System.Drawing.Size(43, 28);
            this.lblRecodMatricula.TabIndex = 48;
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
            this.lblInspeccionMatricula.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas4")));
            this.lblInspeccionMatricula.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblInspeccionMatricula.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios4")));
            this.lblInspeccionMatricula.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblInspeccionMatricula.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblInspeccionMatricula.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblInspeccionMatricula.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblInspeccionMatricula.Size = new System.Drawing.Size(45, 28);
            this.lblInspeccionMatricula.TabIndex = 47;
            this.lblInspeccionMatricula.Tag = "";
            this.lblInspeccionMatricula.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblInspeccionMatricula_OnCambioDato);
            this.lblInspeccionMatricula.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblInspeccionMatricula_OnAlarma);
            this.lblInspeccionMatricula.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblInspeccionMatricula_OnComunicacion);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRecodTOSISO);
            this.panel2.Controls.Add(this.lblRecodISO);
            this.panel2.Controls.Add(this.lblInspeccionISO);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(53, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 28);
            this.panel2.TabIndex = 53;
            // 
            // lblRecodTOSISO
            // 
            this.lblRecodTOSISO.BackColor = System.Drawing.Color.White;
            this.lblRecodTOSISO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodTOSISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodTOSISO.Location = new System.Drawing.Point(88, 0);
            this.lblRecodTOSISO.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodTOSISO.Name = "lblRecodTOSISO";
            this.lblRecodTOSISO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodTOSISO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodTOSISO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodTOSISO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodTOSISO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodTOSISO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodTOSISO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodTOSISO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas5")));
            this.lblRecodTOSISO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodTOSISO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios5")));
            this.lblRecodTOSISO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodTOSISO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodTOSISO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodTOSISO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodTOSISO.Size = new System.Drawing.Size(37, 28);
            this.lblRecodTOSISO.TabIndex = 49;
            this.lblRecodTOSISO.Tag = "";
            this.lblRecodTOSISO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodTOSISO_OnCambioDato);
            this.lblRecodTOSISO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodTOSISO_OnAlarma);
            this.lblRecodTOSISO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodTOSISO_OnComunicacion);
            // 
            // lblRecodISO
            // 
            this.lblRecodISO.BackColor = System.Drawing.Color.White;
            this.lblRecodISO.ContextMenuStrip = this.contextMenuStrip1;
            this.lblRecodISO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodISO.Location = new System.Drawing.Point(45, 0);
            this.lblRecodISO.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodISO.Name = "lblRecodISO";
            this.lblRecodISO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodISO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodISO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodISO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodISO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodISO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodISO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodISO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas6")));
            this.lblRecodISO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodISO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios6")));
            this.lblRecodISO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodISO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodISO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodISO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodISO.Size = new System.Drawing.Size(43, 28);
            this.lblRecodISO.TabIndex = 48;
            this.lblRecodISO.Tag = "";
            this.lblRecodISO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodISO_OnCambioDato);
            this.lblRecodISO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodISO_OnAlarma);
            this.lblRecodISO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodISO_OnComunicacion);
            // 
            // lblInspeccionISO
            // 
            this.lblInspeccionISO.BackColor = System.Drawing.Color.White;
            this.lblInspeccionISO.ContextMenuStrip = this.contextMenuStrip1;
            this.lblInspeccionISO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInspeccionISO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspeccionISO.Location = new System.Drawing.Point(0, 0);
            this.lblInspeccionISO.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspeccionISO.Name = "lblInspeccionISO";
            this.lblInspeccionISO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblInspeccionISO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblInspeccionISO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblInspeccionISO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblInspeccionISO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblInspeccionISO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblInspeccionISO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblInspeccionISO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas7")));
            this.lblInspeccionISO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblInspeccionISO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios7")));
            this.lblInspeccionISO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblInspeccionISO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblInspeccionISO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblInspeccionISO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblInspeccionISO.Size = new System.Drawing.Size(45, 28);
            this.lblInspeccionISO.TabIndex = 47;
            this.lblInspeccionISO.Tag = "";
            this.lblInspeccionISO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblInspeccionISO_OnCambioDato);
            this.lblInspeccionISO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblInspeccionISO_OnAlarma);
            this.lblInspeccionISO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblInspeccionISO_OnComunicacion);
            // 
            // OrbitaGSInspeccionContenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpContenedor);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(241, 80);
            this.MinimumSize = new System.Drawing.Size(241, 80);
            this.Name = "OrbitaGSInspeccionContenedor";          
            this.Size = new System.Drawing.Size(241, 80);
            this.tlpContenedor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OrbitaUltraLabel lblPorcentajeISO;
        private OrbitaUltraLabel lblPorcentajeMatricula;
        public OrbitaGSLabel lblFiabilidadISO;
        public OrbitaGSLabel lblFiabilidadMatricula;
        private OrbitaUltraLabel lblMatricula;
        private OrbitaUltraLabel lblISO;
        private System.Windows.Forms.TableLayoutPanel tlpContenedor;
        public OrbitaUltraLabel lblContenedor;
        private System.Windows.Forms.Panel panel1;
        public OrbitaGSLabel lblInspeccionMatricula;
        public OrbitaGSLabel lblRecodMatricula;
        private System.Windows.Forms.Panel panel2;
        public OrbitaGSLabel lblRecodISO;
        public OrbitaGSLabel lblInspeccionISO;
        public OrbitaGSLabel lblRecodTOSMatricula;
        public OrbitaGSLabel lblRecodTOSISO;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;

    }
}
