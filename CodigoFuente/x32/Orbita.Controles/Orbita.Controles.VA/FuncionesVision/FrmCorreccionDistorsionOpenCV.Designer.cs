namespace Orbita.Controles.VA
{
    partial class FrmCorreccionDistorsionOpenCV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.orbitaTableLayoutPanel1 = new Orbita.Controles.Contenedores.OrbitaTableLayoutPanel();
            this.VisorBitmapOriginal = new Orbita.Controles.VA.OrbitaVisorBitmap();
            this.VisorBitmapDestino = new Orbita.Controles.VA.OrbitaVisorBitmap();
            this.PnlParametrosOrigen = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.GroupBoxAreaOrigen = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.RadioButtonPuntoOriginal4 = new System.Windows.Forms.RadioButton();
            this.RadioButtonPuntoOriginal3 = new System.Windows.Forms.RadioButton();
            this.RadioButtonPuntoOriginal2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonPuntoOriginal1 = new System.Windows.Forms.RadioButton();
            this.PnlParametrosDestino = new Orbita.Controles.Contenedores.OrbitaPanel();
            this.GroupBoxAreaDestino = new Orbita.Controles.Contenedores.OrbitaUltraGroupBox();
            this.NumericEditorAlto = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.NumericEditorAncho = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.NumericEditorY = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.NumericEditorX = new Orbita.Controles.Comunes.OrbitaUltraNumericEditor();
            this.LabelAlto = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.LabelAncho = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.LabelY = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.LabelX = new Orbita.Controles.Comunes.OrbitaUltraLabel();
            this.BtnProcesar = new Orbita.Controles.Comunes.OrbitaUltraButton();
            this.PnlPanelPrincipalPadre.SuspendLayout();
            this.PnlInferiorPadre.SuspendLayout();
            this.PnlBotonesPadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).BeginInit();
            this.orbitaTableLayoutPanel1.SuspendLayout();
            this.PnlParametrosOrigen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBoxAreaOrigen)).BeginInit();
            this.GroupBoxAreaOrigen.SuspendLayout();
            this.PnlParametrosDestino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBoxAreaDestino)).BeginInit();
            this.GroupBoxAreaDestino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorX)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlPanelPrincipalPadre
            // 
            this.PnlPanelPrincipalPadre.Controls.Add(this.orbitaTableLayoutPanel1);
            this.PnlPanelPrincipalPadre.Size = new System.Drawing.Size(942, 456);
            // 
            // btnCancelar
            // 
            this.btnCancelar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnCancelar.Size = new System.Drawing.Size(98, 33);
            // 
            // btnGuardar
            // 
            this.btnGuardar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.btnGuardar.Size = new System.Drawing.Size(98, 33);
            // 
            // PnlInferiorPadre
            // 
            this.PnlInferiorPadre.Location = new System.Drawing.Point(10, 466);
            this.PnlInferiorPadre.Size = new System.Drawing.Size(942, 43);
            // 
            // PnlBotonesPadre
            // 
            this.PnlBotonesPadre.Controls.Add(this.BtnProcesar);
            this.PnlBotonesPadre.Location = new System.Drawing.Point(740, 0);
            this.PnlBotonesPadre.Controls.SetChildIndex(this.btnGuardar, 0);
            this.PnlBotonesPadre.Controls.SetChildIndex(this.BtnProcesar, 0);
            this.PnlBotonesPadre.Controls.SetChildIndex(this.btnCancelar, 0);
            // 
            // orbitaTableLayoutPanel1
            // 
            this.orbitaTableLayoutPanel1.ColumnCount = 2;
            this.orbitaTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.orbitaTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.orbitaTableLayoutPanel1.Controls.Add(this.VisorBitmapOriginal, 0, 0);
            this.orbitaTableLayoutPanel1.Controls.Add(this.VisorBitmapDestino, 1, 0);
            this.orbitaTableLayoutPanel1.Controls.Add(this.PnlParametrosOrigen, 0, 1);
            this.orbitaTableLayoutPanel1.Controls.Add(this.PnlParametrosDestino, 1, 1);
            this.orbitaTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orbitaTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.orbitaTableLayoutPanel1.Name = "orbitaTableLayoutPanel1";
            this.orbitaTableLayoutPanel1.RowCount = 2;
            this.orbitaTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orbitaTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.orbitaTableLayoutPanel1.Size = new System.Drawing.Size(942, 456);
            this.orbitaTableLayoutPanel1.TabIndex = 1;
            // 
            // VisorBitmapOriginal
            // 
            this.VisorBitmapOriginal.AutoCenter = true;
            this.VisorBitmapOriginal.AutoPan = true;
            this.VisorBitmapOriginal.BackColor = System.Drawing.SystemColors.Control;
            this.VisorBitmapOriginal.ClickBotonDerecho = Orbita.Controles.VA.OpcionClickBotones.Nada;
            this.VisorBitmapOriginal.ClickBotonIzquierdo = Orbita.Controles.VA.OpcionClickBotones.Nada;
            this.VisorBitmapOriginal.Codigo = "Imagen Original";
            this.VisorBitmapOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorBitmapOriginal.GraficoActual = null;
            this.VisorBitmapOriginal.ImagenActual = null;
            this.VisorBitmapOriginal.InvertMouse = false;
            this.VisorBitmapOriginal.Location = new System.Drawing.Point(3, 3);
            this.VisorBitmapOriginal.MantenerBotonDerecho = Orbita.Controles.VA.OpcionMantenerClickBotones.Rectangulo;
            this.VisorBitmapOriginal.MostrarBtnAbrir = true;
            this.VisorBitmapOriginal.MostrarbtnGuardar = false;
            this.VisorBitmapOriginal.MostrarBtnInfo = false;
            this.VisorBitmapOriginal.MostrarBtnMaximinzar = false;
            this.VisorBitmapOriginal.MostrarBtnReproduccion = false;
            this.VisorBitmapOriginal.MostrarBtnSiguienteAnterior = false;
            this.VisorBitmapOriginal.MostrarBtnSnap = false;
            this.VisorBitmapOriginal.MostrarLblTitulo = true;
            this.VisorBitmapOriginal.MostrarStatusBar = true;
            this.VisorBitmapOriginal.MostrarStatusFps = false;
            this.VisorBitmapOriginal.MostrarStatusMensaje = false;
            this.VisorBitmapOriginal.MostrarStatusValorPixel = false;
            this.VisorBitmapOriginal.MostrarToolStrip = true;
            this.VisorBitmapOriginal.Name = "VisorBitmapOriginal";
            this.VisorBitmapOriginal.PermitirClickZoom = true;
            this.VisorBitmapOriginal.PermitirZoom = true;
            this.VisorBitmapOriginal.Size = new System.Drawing.Size(465, 309);
            this.VisorBitmapOriginal.TabIndex = 36;
            this.VisorBitmapOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VisorBitmapOriginal_MouseClick);
            // 
            // VisorBitmapDestino
            // 
            this.VisorBitmapDestino.AutoCenter = true;
            this.VisorBitmapDestino.AutoPan = true;
            this.VisorBitmapDestino.BackColor = System.Drawing.SystemColors.Control;
            this.VisorBitmapDestino.ClickBotonDerecho = Orbita.Controles.VA.OpcionClickBotones.Nada;
            this.VisorBitmapDestino.ClickBotonIzquierdo = Orbita.Controles.VA.OpcionClickBotones.Nada;
            this.VisorBitmapDestino.Codigo = "Imagen Original";
            this.VisorBitmapDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorBitmapDestino.GraficoActual = null;
            this.VisorBitmapDestino.ImagenActual = null;
            this.VisorBitmapDestino.InvertMouse = false;
            this.VisorBitmapDestino.Location = new System.Drawing.Point(474, 3);
            this.VisorBitmapDestino.MantenerBotonDerecho = Orbita.Controles.VA.OpcionMantenerClickBotones.Rectangulo;
            this.VisorBitmapDestino.MostrarBtnAbrir = false;
            this.VisorBitmapDestino.MostrarbtnGuardar = true;
            this.VisorBitmapDestino.MostrarBtnInfo = false;
            this.VisorBitmapDestino.MostrarBtnMaximinzar = false;
            this.VisorBitmapDestino.MostrarBtnReproduccion = false;
            this.VisorBitmapDestino.MostrarBtnSiguienteAnterior = false;
            this.VisorBitmapDestino.MostrarBtnSnap = false;
            this.VisorBitmapDestino.MostrarLblTitulo = true;
            this.VisorBitmapDestino.MostrarStatusBar = true;
            this.VisorBitmapDestino.MostrarStatusFps = false;
            this.VisorBitmapDestino.MostrarStatusMensaje = false;
            this.VisorBitmapDestino.MostrarStatusValorPixel = false;
            this.VisorBitmapDestino.MostrarToolStrip = true;
            this.VisorBitmapDestino.Name = "VisorBitmapDestino";
            this.VisorBitmapDestino.PermitirClickZoom = true;
            this.VisorBitmapDestino.PermitirZoom = true;
            this.VisorBitmapDestino.Size = new System.Drawing.Size(465, 309);
            this.VisorBitmapDestino.TabIndex = 37;
            // 
            // PnlParametrosOrigen
            // 
            this.PnlParametrosOrigen.Controls.Add(this.GroupBoxAreaOrigen);
            this.PnlParametrosOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlParametrosOrigen.Location = new System.Drawing.Point(3, 318);
            this.PnlParametrosOrigen.Name = "PnlParametrosOrigen";
            this.PnlParametrosOrigen.Size = new System.Drawing.Size(465, 135);
            this.PnlParametrosOrigen.TabIndex = 34;
            // 
            // GroupBoxAreaOrigen
            // 
            this.GroupBoxAreaOrigen.Controls.Add(this.RadioButtonPuntoOriginal4);
            this.GroupBoxAreaOrigen.Controls.Add(this.RadioButtonPuntoOriginal3);
            this.GroupBoxAreaOrigen.Controls.Add(this.RadioButtonPuntoOriginal2);
            this.GroupBoxAreaOrigen.Controls.Add(this.RadioButtonPuntoOriginal1);
            this.GroupBoxAreaOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxAreaOrigen.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxAreaOrigen.Name = "GroupBoxAreaOrigen";
            this.GroupBoxAreaOrigen.Size = new System.Drawing.Size(465, 135);
            this.GroupBoxAreaOrigen.TabIndex = 32;
            this.GroupBoxAreaOrigen.Text = "Área origen";
            // 
            // RadioButtonPuntoOriginal4
            // 
            this.RadioButtonPuntoOriginal4.AutoSize = true;
            this.RadioButtonPuntoOriginal4.Location = new System.Drawing.Point(6, 88);
            this.RadioButtonPuntoOriginal4.Name = "RadioButtonPuntoOriginal4";
            this.RadioButtonPuntoOriginal4.Size = new System.Drawing.Size(67, 17);
            this.RadioButtonPuntoOriginal4.TabIndex = 30;
            this.RadioButtonPuntoOriginal4.Text = "4o punto";
            this.RadioButtonPuntoOriginal4.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPuntoOriginal3
            // 
            this.RadioButtonPuntoOriginal3.AutoSize = true;
            this.RadioButtonPuntoOriginal3.Location = new System.Drawing.Point(6, 65);
            this.RadioButtonPuntoOriginal3.Name = "RadioButtonPuntoOriginal3";
            this.RadioButtonPuntoOriginal3.Size = new System.Drawing.Size(70, 17);
            this.RadioButtonPuntoOriginal3.TabIndex = 29;
            this.RadioButtonPuntoOriginal3.Text = "3er punto";
            this.RadioButtonPuntoOriginal3.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPuntoOriginal2
            // 
            this.RadioButtonPuntoOriginal2.AutoSize = true;
            this.RadioButtonPuntoOriginal2.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonPuntoOriginal2.Name = "RadioButtonPuntoOriginal2";
            this.RadioButtonPuntoOriginal2.Size = new System.Drawing.Size(67, 17);
            this.RadioButtonPuntoOriginal2.TabIndex = 28;
            this.RadioButtonPuntoOriginal2.Text = "2o punto";
            this.RadioButtonPuntoOriginal2.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPuntoOriginal1
            // 
            this.RadioButtonPuntoOriginal1.AutoSize = true;
            this.RadioButtonPuntoOriginal1.Checked = true;
            this.RadioButtonPuntoOriginal1.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonPuntoOriginal1.Name = "RadioButtonPuntoOriginal1";
            this.RadioButtonPuntoOriginal1.Size = new System.Drawing.Size(70, 17);
            this.RadioButtonPuntoOriginal1.TabIndex = 27;
            this.RadioButtonPuntoOriginal1.TabStop = true;
            this.RadioButtonPuntoOriginal1.Text = "1er punto";
            this.RadioButtonPuntoOriginal1.UseVisualStyleBackColor = true;
            // 
            // PnlParametrosDestino
            // 
            this.PnlParametrosDestino.Controls.Add(this.GroupBoxAreaDestino);
            this.PnlParametrosDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlParametrosDestino.Location = new System.Drawing.Point(474, 318);
            this.PnlParametrosDestino.Name = "PnlParametrosDestino";
            this.PnlParametrosDestino.Size = new System.Drawing.Size(465, 135);
            this.PnlParametrosDestino.TabIndex = 35;
            // 
            // GroupBoxAreaDestino
            // 
            this.GroupBoxAreaDestino.Controls.Add(this.NumericEditorAlto);
            this.GroupBoxAreaDestino.Controls.Add(this.NumericEditorAncho);
            this.GroupBoxAreaDestino.Controls.Add(this.NumericEditorY);
            this.GroupBoxAreaDestino.Controls.Add(this.NumericEditorX);
            this.GroupBoxAreaDestino.Controls.Add(this.LabelAlto);
            this.GroupBoxAreaDestino.Controls.Add(this.LabelAncho);
            this.GroupBoxAreaDestino.Controls.Add(this.LabelY);
            this.GroupBoxAreaDestino.Controls.Add(this.LabelX);
            this.GroupBoxAreaDestino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxAreaDestino.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxAreaDestino.Name = "GroupBoxAreaDestino";
            this.GroupBoxAreaDestino.Size = new System.Drawing.Size(465, 135);
            this.GroupBoxAreaDestino.TabIndex = 33;
            this.GroupBoxAreaDestino.Text = "Destino";
            // 
            // NumericEditorAlto
            // 
            this.NumericEditorAlto.AlwaysInEditMode = true;
            this.NumericEditorAlto.Location = new System.Drawing.Point(56, 98);
            this.NumericEditorAlto.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.NumericEditorAlto.MaskInput = "{double:9.4}";
            this.NumericEditorAlto.MaxValue = 10000;
            this.NumericEditorAlto.MinValue = 1;
            this.NumericEditorAlto.Name = "NumericEditorAlto";
            this.NumericEditorAlto.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.NumericEditorAlto.PromptChar = ' ';
            this.NumericEditorAlto.Size = new System.Drawing.Size(84, 21);
            this.NumericEditorAlto.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.NumericEditorAlto.SpinIncrement = 1;
            this.NumericEditorAlto.TabIndex = 7;
            this.NumericEditorAlto.Value = 600D;
            // 
            // NumericEditorAncho
            // 
            this.NumericEditorAncho.AlwaysInEditMode = true;
            this.NumericEditorAncho.Location = new System.Drawing.Point(56, 71);
            this.NumericEditorAncho.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludePromptChars;
            this.NumericEditorAncho.MaskInput = "{double:9.4}";
            this.NumericEditorAncho.MaxValue = 10000;
            this.NumericEditorAncho.MinValue = 1;
            this.NumericEditorAncho.Name = "NumericEditorAncho";
            this.NumericEditorAncho.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.NumericEditorAncho.PromptChar = ' ';
            this.NumericEditorAncho.Size = new System.Drawing.Size(84, 21);
            this.NumericEditorAncho.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.NumericEditorAncho.SpinIncrement = 1;
            this.NumericEditorAncho.TabIndex = 6;
            this.NumericEditorAncho.Value = 800D;
            // 
            // NumericEditorY
            // 
            this.NumericEditorY.AlwaysInEditMode = true;
            this.NumericEditorY.Location = new System.Drawing.Point(56, 44);
            this.NumericEditorY.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            this.NumericEditorY.MaskInput = "{double:-9.4}";
            this.NumericEditorY.MaxValue = 10000;
            this.NumericEditorY.MinValue = -10000;
            this.NumericEditorY.Name = "NumericEditorY";
            this.NumericEditorY.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.NumericEditorY.PromptChar = ' ';
            this.NumericEditorY.Size = new System.Drawing.Size(84, 21);
            this.NumericEditorY.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.NumericEditorY.SpinIncrement = 1;
            this.NumericEditorY.TabIndex = 5;
            // 
            // NumericEditorX
            // 
            this.NumericEditorX.AlwaysInEditMode = true;
            this.NumericEditorX.Location = new System.Drawing.Point(56, 17);
            this.NumericEditorX.MaskInput = "{double:-9.4}";
            this.NumericEditorX.MaxValue = 10000;
            this.NumericEditorX.MinValue = -10000;
            this.NumericEditorX.Name = "NumericEditorX";
            this.NumericEditorX.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.NumericEditorX.PromptChar = ' ';
            this.NumericEditorX.Size = new System.Drawing.Size(84, 21);
            this.NumericEditorX.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.NumericEditorX.SpinIncrement = 1;
            this.NumericEditorX.TabIndex = 4;
            // 
            // LabelAlto
            // 
            appearance1.TextHAlignAsString = "Right";
            this.LabelAlto.Appearance = appearance1;
            this.LabelAlto.Location = new System.Drawing.Point(6, 102);
            this.LabelAlto.Name = "LabelAlto";
            this.LabelAlto.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Derecha;
            this.LabelAlto.Size = new System.Drawing.Size(44, 15);
            this.LabelAlto.TabIndex = 3;
            this.LabelAlto.Text = "Alto";
            this.LabelAlto.UseMnemonic = false;
            // 
            // LabelAncho
            // 
            appearance2.TextHAlignAsString = "Right";
            this.LabelAncho.Appearance = appearance2;
            this.LabelAncho.Location = new System.Drawing.Point(6, 75);
            this.LabelAncho.Name = "LabelAncho";
            this.LabelAncho.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Derecha;
            this.LabelAncho.Size = new System.Drawing.Size(44, 15);
            this.LabelAncho.TabIndex = 2;
            this.LabelAncho.Text = "Ancho";
            this.LabelAncho.UseMnemonic = false;
            // 
            // LabelY
            // 
            appearance3.TextHAlignAsString = "Right";
            this.LabelY.Appearance = appearance3;
            this.LabelY.Location = new System.Drawing.Point(6, 48);
            this.LabelY.Name = "LabelY";
            this.LabelY.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Derecha;
            this.LabelY.Size = new System.Drawing.Size(44, 15);
            this.LabelY.TabIndex = 1;
            this.LabelY.Text = "Y";
            this.LabelY.UseMnemonic = false;
            // 
            // LabelX
            // 
            appearance4.TextHAlignAsString = "Right";
            this.LabelX.Appearance = appearance4;
            this.LabelX.Location = new System.Drawing.Point(6, 21);
            this.LabelX.Name = "LabelX";
            this.LabelX.OI.Apariencia.AlineacionTextoHorizontal = Orbita.Controles.Comunes.AlineacionHorizontal.Derecha;
            this.LabelX.Size = new System.Drawing.Size(44, 15);
            this.LabelX.TabIndex = 0;
            this.LabelX.Text = "X";
            this.LabelX.UseMnemonic = false;
            // 
            // BtnProcesar
            // 
            appearance5.Image = global::Orbita.Controles.VA.Properties.Resources.BtnAplicar24;
            this.BtnProcesar.Appearance = appearance5;
            this.BtnProcesar.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnProcesar.Location = new System.Drawing.Point(0, 10);
            this.BtnProcesar.Name = "BtnProcesar";
            this.BtnProcesar.OI.Estilo = Orbita.Controles.Comunes.EstiloBoton.Extragrande;
            this.BtnProcesar.Size = new System.Drawing.Size(98, 33);
            this.BtnProcesar.TabIndex = 33;
            this.BtnProcesar.Text = "Procesar";
            this.BtnProcesar.Click += new System.EventHandler(this.BtnProcesar_Click);
            // 
            // FrmCorreccionDistorsionOpenCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 519);
            this.ModoAperturaFormulario = Orbita.Controles.VA.ModoAperturaFormulario.Monitorizacion;
            this.MultiplesInstancias = true;
            this.Name = "FrmCorreccionDistorsionOpenCV";
            this.Text = "Formulario de corrección de distorsión mediante OpenCV";
            this.PnlPanelPrincipalPadre.ResumeLayout(false);
            this.PnlInferiorPadre.ResumeLayout(false);
            this.PnlBotonesPadre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChkDock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChkToolTip)).EndInit();
            this.orbitaTableLayoutPanel1.ResumeLayout(false);
            this.PnlParametrosOrigen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupBoxAreaOrigen)).EndInit();
            this.GroupBoxAreaOrigen.ResumeLayout(false);
            this.GroupBoxAreaOrigen.PerformLayout();
            this.PnlParametrosDestino.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupBoxAreaDestino)).EndInit();
            this.GroupBoxAreaDestino.ResumeLayout(false);
            this.GroupBoxAreaDestino.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEditorX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Contenedores.OrbitaTableLayoutPanel orbitaTableLayoutPanel1;
        private Comunes.OrbitaUltraButton BtnProcesar;
        private Contenedores.OrbitaUltraGroupBox GroupBoxAreaDestino;
        private Contenedores.OrbitaUltraGroupBox GroupBoxAreaOrigen;
        private System.Windows.Forms.RadioButton RadioButtonPuntoOriginal4;
        private System.Windows.Forms.RadioButton RadioButtonPuntoOriginal3;
        private System.Windows.Forms.RadioButton RadioButtonPuntoOriginal2;
        private System.Windows.Forms.RadioButton RadioButtonPuntoOriginal1;
        private Contenedores.OrbitaPanel PnlParametrosOrigen;
        private Contenedores.OrbitaPanel PnlParametrosDestino;
        private OrbitaVisorBitmap VisorBitmapOriginal;
        private OrbitaVisorBitmap VisorBitmapDestino;
        private Comunes.OrbitaUltraLabel LabelY;
        private Comunes.OrbitaUltraLabel LabelX;
        private Comunes.OrbitaUltraLabel LabelAlto;
        private Comunes.OrbitaUltraLabel LabelAncho;
        private Comunes.OrbitaUltraNumericEditor NumericEditorX;
        private Comunes.OrbitaUltraNumericEditor NumericEditorAlto;
        private Comunes.OrbitaUltraNumericEditor NumericEditorAncho;
        private Comunes.OrbitaUltraNumericEditor NumericEditorY;
    }
}