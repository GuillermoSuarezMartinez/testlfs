using Orbita.Controles.Comunes;
namespace Orbita.Controles.GateSuite
{
    partial class OrbitaGSInspeccionIMO
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrbitaGSInspeccionIMO));
            this.tlpIMO = new System.Windows.Forms.TableLayoutPanel();
            this.lblPresencia = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblPorcentajeIMO = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblIMO = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.lblFiabilidadIMO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRecodTOSIMO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecodIMO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblInspeccionIMO = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRecodPresencia = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.lblInspeccionPresencia = new Orbita.Controles.GateSuite.OrbitaGSLabel();
            this.tlpIMO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpIMO
            // 
            this.tlpIMO.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpIMO.ColumnCount = 3;
            this.tlpIMO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpIMO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tlpIMO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlpIMO.Controls.Add(this.lblPresencia, 0, 2);
            this.tlpIMO.Controls.Add(this.lblPorcentajeIMO, 2, 1);
            this.tlpIMO.Controls.Add(this.lblIMO, 0, 0);
            this.tlpIMO.Controls.Add(this.lblFiabilidadIMO, 1, 1);
            this.tlpIMO.Controls.Add(this.panel1, 0, 1);
            this.tlpIMO.Controls.Add(this.panel2, 1, 2);
            this.tlpIMO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpIMO.Location = new System.Drawing.Point(0, 0);
            this.tlpIMO.Margin = new System.Windows.Forms.Padding(0);
            this.tlpIMO.MaximumSize = new System.Drawing.Size(278, 80);
            this.tlpIMO.MinimumSize = new System.Drawing.Size(278, 80);
            this.tlpIMO.Name = "tlpIMO";
            this.tlpIMO.RowCount = 3;
            this.tlpIMO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpIMO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpIMO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpIMO.Size = new System.Drawing.Size(278, 80);
            this.tlpIMO.TabIndex = 54;
            // 
            // lblPresencia
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblPresencia.Appearance = appearance1;
            this.lblPresencia.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPresencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPresencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresencia.Location = new System.Drawing.Point(1, 51);
            this.lblPresencia.Margin = new System.Windows.Forms.Padding(0);
            this.lblPresencia.Name = "lblPresencia";
            this.lblPresencia.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblPresencia.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblPresencia.Size = new System.Drawing.Size(120, 28);
            this.lblPresencia.TabIndex = 50;
            this.lblPresencia.Tag = "";
            this.lblPresencia.Text = "PRESENCIA";
            this.lblPresencia.UseMnemonic = false;
            // 
            // lblPorcentajeIMO
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPorcentajeIMO.Appearance = appearance2;
            this.lblPorcentajeIMO.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPorcentajeIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeIMO.Location = new System.Drawing.Point(260, 22);
            this.lblPorcentajeIMO.Margin = new System.Windows.Forms.Padding(0);
            this.lblPorcentajeIMO.Name = "lblPorcentajeIMO";
            this.lblPorcentajeIMO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblPorcentajeIMO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblPorcentajeIMO.Size = new System.Drawing.Size(17, 28);
            this.lblPorcentajeIMO.TabIndex = 45;
            this.lblPorcentajeIMO.Text = "%";
            this.lblPorcentajeIMO.UseMnemonic = false;
            // 
            // lblIMO
            // 
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblIMO.Appearance = appearance3;
            this.lblIMO.BackColorInternal = System.Drawing.Color.Navy;
            this.tlpIMO.SetColumnSpan(this.lblIMO, 3);
            this.lblIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMO.ForeColor = System.Drawing.Color.White;
            this.lblIMO.Location = new System.Drawing.Point(1, 1);
            this.lblIMO.Margin = new System.Windows.Forms.Padding(0);
            this.lblIMO.Name = "lblIMO";
            this.lblIMO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblIMO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblIMO.Size = new System.Drawing.Size(276, 20);
            this.lblIMO.TabIndex = 44;
            this.lblIMO.Tag = "";
            this.lblIMO.Text = "ETIQUETA IMO";
            this.lblIMO.UseMnemonic = false;
            // 
            // lblFiabilidadIMO
            // 
            this.lblFiabilidadIMO.BackColor = System.Drawing.Color.White;
            this.lblFiabilidadIMO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiabilidadIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiabilidadIMO.Location = new System.Drawing.Point(122, 22);
            this.lblFiabilidadIMO.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiabilidadIMO.Name = "lblFiabilidadIMO";
            this.lblFiabilidadIMO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblFiabilidadIMO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblFiabilidadIMO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblFiabilidadIMO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblFiabilidadIMO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblFiabilidadIMO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblFiabilidadIMO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblFiabilidadIMO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas")));
            this.lblFiabilidadIMO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblFiabilidadIMO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios")));
            this.lblFiabilidadIMO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblFiabilidadIMO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblFiabilidadIMO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblFiabilidadIMO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblFiabilidadIMO.Size = new System.Drawing.Size(137, 28);
            this.lblFiabilidadIMO.TabIndex = 47;
            this.lblFiabilidadIMO.Tag = "";
            this.lblFiabilidadIMO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblFiabilidadIMO_OnCambioDato);
            this.lblFiabilidadIMO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblFiabilidadIMO_OnAlarma);
            this.lblFiabilidadIMO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblFiabilidadIMO_OnComunicacion);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRecodTOSIMO);
            this.panel1.Controls.Add(this.lblRecodIMO);
            this.panel1.Controls.Add(this.lblInspeccionIMO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 28);
            this.panel1.TabIndex = 52;
            // 
            // lblRecodTOSIMO
            // 
            this.lblRecodTOSIMO.BackColor = System.Drawing.Color.White;
            this.lblRecodTOSIMO.ContextMenuStrip = this.contextMenuStrip1;
            this.lblRecodTOSIMO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodTOSIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodTOSIMO.Location = new System.Drawing.Point(85, 0);
            this.lblRecodTOSIMO.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodTOSIMO.Name = "lblRecodTOSIMO";
            this.lblRecodTOSIMO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodTOSIMO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodTOSIMO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodTOSIMO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodTOSIMO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodTOSIMO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodTOSIMO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodTOSIMO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas1")));
            this.lblRecodTOSIMO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodTOSIMO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios1")));
            this.lblRecodTOSIMO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodTOSIMO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodTOSIMO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodTOSIMO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodTOSIMO.Size = new System.Drawing.Size(35, 28);
            this.lblRecodTOSIMO.TabIndex = 49;
            this.lblRecodTOSIMO.Tag = "";
            this.lblRecodTOSIMO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodTOSIMO_OnCambioDato);
            this.lblRecodTOSIMO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodTOSIMO_OnAlarma);
            this.lblRecodTOSIMO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodTOSIMO_OnComunicacion);
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
            // lblRecodIMO
            // 
            this.lblRecodIMO.BackColor = System.Drawing.Color.White;
            this.lblRecodIMO.ContextMenuStrip = this.contextMenuStrip1;
            this.lblRecodIMO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodIMO.Location = new System.Drawing.Point(43, 0);
            this.lblRecodIMO.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodIMO.Name = "lblRecodIMO";
            this.lblRecodIMO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodIMO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodIMO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodIMO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodIMO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodIMO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodIMO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodIMO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas2")));
            this.lblRecodIMO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodIMO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios2")));
            this.lblRecodIMO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodIMO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodIMO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodIMO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodIMO.Size = new System.Drawing.Size(42, 28);
            this.lblRecodIMO.TabIndex = 48;
            this.lblRecodIMO.Tag = "";
            this.lblRecodIMO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodIMO_OnCambioDato);
            this.lblRecodIMO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodIMO_OnAlarma);
            this.lblRecodIMO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodIMO_OnComunicacion);
            // 
            // lblInspeccionIMO
            // 
            this.lblInspeccionIMO.BackColor = System.Drawing.Color.White;
            this.lblInspeccionIMO.ContextMenuStrip = this.contextMenuStrip1;
            this.lblInspeccionIMO.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInspeccionIMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspeccionIMO.Location = new System.Drawing.Point(0, 0);
            this.lblInspeccionIMO.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspeccionIMO.Name = "lblInspeccionIMO";
            this.lblInspeccionIMO.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblInspeccionIMO.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblInspeccionIMO.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblInspeccionIMO.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblInspeccionIMO.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblInspeccionIMO.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblInspeccionIMO.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblInspeccionIMO.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas3")));
            this.lblInspeccionIMO.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblInspeccionIMO.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios3")));
            this.lblInspeccionIMO.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblInspeccionIMO.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblInspeccionIMO.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblInspeccionIMO.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblInspeccionIMO.Size = new System.Drawing.Size(43, 28);
            this.lblInspeccionIMO.TabIndex = 47;
            this.lblInspeccionIMO.Tag = "";
            this.lblInspeccionIMO.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblInspeccionIMO_OnCambioDato);
            this.lblInspeccionIMO.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblInspeccionIMO_OnAlarma);
            this.lblInspeccionIMO.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblInspeccionIMO_OnComunicacion);
            // 
            // panel2
            // 
            this.tlpIMO.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.lblRecodPresencia);
            this.panel2.Controls.Add(this.lblInspeccionPresencia);
            this.panel2.Location = new System.Drawing.Point(122, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 28);
            this.panel2.TabIndex = 53;
            // 
            // lblRecodPresencia
            // 
            this.lblRecodPresencia.BackColor = System.Drawing.Color.White;
            this.lblRecodPresencia.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRecodPresencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecodPresencia.Location = new System.Drawing.Point(82, 0);
            this.lblRecodPresencia.Margin = new System.Windows.Forms.Padding(0);
            this.lblRecodPresencia.Name = "lblRecodPresencia";
            this.lblRecodPresencia.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblRecodPresencia.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblRecodPresencia.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblRecodPresencia.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblRecodPresencia.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblRecodPresencia.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblRecodPresencia.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblRecodPresencia.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas4")));
            this.lblRecodPresencia.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblRecodPresencia.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios4")));
            this.lblRecodPresencia.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblRecodPresencia.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblRecodPresencia.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblRecodPresencia.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblRecodPresencia.Size = new System.Drawing.Size(73, 28);
            this.lblRecodPresencia.TabIndex = 53;
            this.lblRecodPresencia.Tag = "";
            this.lblRecodPresencia.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblRecodPresencia_OnCambioDato);
            this.lblRecodPresencia.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblRecodPresencia_OnAlarma);
            this.lblRecodPresencia.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblRecodPresencia_OnComunicacion);
            // 
            // lblInspeccionPresencia
            // 
            this.lblInspeccionPresencia.BackColor = System.Drawing.Color.White;
            this.lblInspeccionPresencia.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInspeccionPresencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspeccionPresencia.Location = new System.Drawing.Point(0, 0);
            this.lblInspeccionPresencia.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspeccionPresencia.Name = "lblInspeccionPresencia";
            this.lblInspeccionPresencia.OI.Apariencia.AdornoTexto = Orbita.Controles.Comunes.AdornoTexto.Ninguno;
            this.lblInspeccionPresencia.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Centro;
            this.lblInspeccionPresencia.OI.Apariencia.AlineacionTextoVertical = Orbita.Controles.Comunes.AlineacionVertical.Medio;
            this.lblInspeccionPresencia.OI.Apariencia.ColorBorde = System.Drawing.Color.Empty;
            this.lblInspeccionPresencia.OI.Apariencia.ColorFondo = System.Drawing.Color.Empty;
            this.lblInspeccionPresencia.OI.Apariencia.ColorTexto = System.Drawing.Color.Empty;
            this.lblInspeccionPresencia.OI.Apariencia.EstiloBorde = Orbita.Controles.Comunes.EstiloBorde.Solido;
            this.lblInspeccionPresencia.OI.Comunicaciones.Alarmas.Alarmas = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Alarmas5")));
            this.lblInspeccionPresencia.OI.Comunicaciones.Alarmas.AlarmasArray = new string[0];
            this.lblInspeccionPresencia.OI.Comunicaciones.CambioDato.Cambios = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.Cambios5")));
            this.lblInspeccionPresencia.OI.Comunicaciones.CambioDato.CambiosArray = new string[0];
            this.lblInspeccionPresencia.OI.Comunicaciones.CambioDato.Variable = null;
            this.lblInspeccionPresencia.OI.Comunicaciones.Comunicacion.IdDispositivo = 0;
            this.lblInspeccionPresencia.OI.Comunicaciones.Comunicacion.NombreCanal = "";
            this.lblInspeccionPresencia.Size = new System.Drawing.Size(82, 28);
            this.lblInspeccionPresencia.TabIndex = 52;
            this.lblInspeccionPresencia.Tag = "";
            this.lblInspeccionPresencia.OnCambioDato += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoCambioDato(this.lblInspeccionPresencia_OnCambioDato);
            this.lblInspeccionPresencia.OnAlarma += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoAlarma(this.lblInspeccionPresencia_OnAlarma);
            this.lblInspeccionPresencia.OnComunicacion += new Orbita.Controles.GateSuite.OrbitaGSLabel.DelegadoComunicacion(this.lblInspeccionPresencia_OnComunicacion);
            // 
            // OrbitaGSInspeccionIMO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpIMO);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(278, 80);
            this.MinimumSize = new System.Drawing.Size(278, 80);
            this.Name = "OrbitaGSInspeccionIMO";           
            this.Size = new System.Drawing.Size(278, 80);
            this.tlpIMO.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public OrbitaGSLabel lblFiabilidadIMO;
        private OrbitaUltraLabel lblPorcentajeIMO;
        private OrbitaUltraLabel lblIMO;
        private System.Windows.Forms.TableLayoutPanel tlpIMO;
        private OrbitaUltraLabel lblPresencia;
        private System.Windows.Forms.Panel panel1;
        public OrbitaGSLabel lblRecodIMO;
        public OrbitaGSLabel lblInspeccionIMO;
        private System.Windows.Forms.Panel panel2;
        public OrbitaGSLabel lblRecodPresencia;
        public OrbitaGSLabel lblInspeccionPresencia;
        public OrbitaGSLabel lblRecodTOSIMO;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
    }
}
