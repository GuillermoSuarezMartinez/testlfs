//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Editor
{
    /// <summary>
    /// Orbita.Controles.Comunes.OrbitaTextEditor.
    /// </summary>
    public partial class OrbitaTextEditor : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        /// <summary>
        /// Indica si el control será de solo lectura o no.
        /// </summary>
        bool readOnly = false;
        /// <summary>
        /// Indica si ha cambiado se ha escrito algo en el editor desde que se cargó.
        /// </summary>
        bool modified = false;
        bool cambiandoValorTexto = false;
        /// <summary>
        /// Color del documento.
        /// </summary>
        System.Drawing.Color colorDoc = System.Drawing.Color.White;
        /// <summary>
        /// Visibilidad de la barra cuando se cambia el valor de la propiedad SoloLectura.
        /// </summary>
        bool oldToolbarVisible = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaTextEditor.
        /// </summary>
        public OrbitaTextEditor()
            : base()
        {
            InitializeComponent();
            this.rtbDoc.Font = this.Font;
            //Además del código en el designer.cs deberemos de volver a forzar su inclusión en un OptionSet.
            Infragistics.Win.UltraWinToolbars.StateButtonTool btAlinearIzq = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Izquierda"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            btAlinearIzq.Checked = true;
            this.tlbOrbitaTextEditor.OptionSets.Add(false, "AlinearOS");
            this.tlbOrbitaTextEditor.OptionSets["AlinearOS"].Tools.AddToolRange(new string[] { "Izquierda", "Derecha", "Centrado", "Justificado" });
            // Guardar la visibilidad de la ToolBar.
            this.oldToolbarVisible = this.OrbToolBarVisible;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Indica si el control será de solo lectura o no.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Indica si el control será de solo lectura o no.")]
        public bool OrbSoloLectura
        {
            get { return this.readOnly; }
            set
            {
                this.readOnly = value;
                if (this.readOnly)
                {
                    this.rtbDoc.BackColor = System.Drawing.SystemColors.Control;
                    this.OrbToolBarVisible = false;
                }
                else
                {
                    this.rtbDoc.BackColor = this.OrbColorDocumento;
                    this.OrbToolBarVisible = this.oldToolbarVisible;
                }
                this.rtbDoc.ReadOnly = this.readOnly;
            }
        }
        /// <summary>
        /// Indica el color del documento.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Color del documento")]
        public System.Drawing.Color OrbColorDocumento
        {
            get { return this.colorDoc; }
            set
            {
                this.colorDoc = value;
                this.rtbDoc.BackColor = value;
            }
        }
        /// <summary>
        /// Indica si se verá el boton Abrir.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Indica si se verá el botón abrir.")]
        public bool OrbBotonAbrirVisible
        {

            get { return this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Abrir"].SharedProps.Visible; }
            set { this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Abrir"].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Indica si se verá el boton Guardar.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Indica si se verá el botón guardar.")]
        public bool OrbBotonGuardarVisible
        {
            get { return this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["BtnGuardar"].SharedProps.Visible; }
            set { this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["BtnGuardar"].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Indica si se verá la toolbar.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Indica si se verá la toolbar.")]
        public bool OrbToolBarVisible
        {
            // Ocultamos el control completo.
            get { return this.tlbOrbitaTextEditor.Visible; }
            set { this.tlbOrbitaTextEditor.Visible = value; }
        }
        /// <summary>
        /// Indica si se verá el boton insertar imagen.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Indica si se verá el boton insertar imagen.")]
        public bool OrbBotonImagenVisible
        {
            get { return this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Insertar Imagen"].SharedProps.Visible; }
            set { this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Insertar Imagen"].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Indica si se dará formato automático a las urls.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Indica si se dará formato automático a las Uris.")]
        public bool OrbDetectarUrls
        {
            get { return this.rtbDoc.DetectUrls; }
            set { this.rtbDoc.DetectUrls = value; }
        }
        /// <summary>
        /// Texto plano que contiene el editor.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Description("Texto plano que contiene el editor.")]
        public string OrbTexto
        {
            get { return this.rtbDoc.Text; }
            set
            {
                this.cambiandoValorTexto = true;
                this.rtbDoc.Text = value;
                this.cambiandoValorTexto = false;
            }
        }
        /// <summary>
        /// Hay que tener cuidado al asignar la propiedad rtf:
        /// si no la hemos tomado de otro control rtf lanzará 
        /// una excepción que no he podido capturar porque va
        /// muy rápido.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.Description("Documento en formato rtf contenido en el editor. Para asignar este valor hay que pasarle siempre un documento rtf en formato válido.")]
        public string OrbRtf
        {
            get { return this.rtbDoc.Rtf; }
            set
            {
                if (value == null)
                {
                    return;
                }
                this.cambiandoValorTexto = true;
                if (value.StartsWith("{\\rtf", System.StringComparison.CurrentCulture))
                {
                    System.IO.Stream s = new System.IO.MemoryStream(System.Text.UTF8Encoding.Default.GetBytes(value));
                    rtbDoc.LoadFile(s, System.Windows.Forms.RichTextBoxStreamType.RichText);
                }
                else
                {
                    this.OrbTexto = value;
                }
                this.cambiandoValorTexto = false;
            }
        }
        /// <summary>
        /// Indica si ha cambiado se ha escrito algo en el editor desde que se cargó.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Indica si ha cambiado se ha escrito algo en el editor desde que se cargó")]
        public bool OrbModified
        {
            get { return this.modified; }
            set { this.modified = value; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Establecer el texto en negrita.
        /// </summary>
        void Negrita()
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool btNegrita = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Negrita"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            try
            {
                if (rtbDoc.SelectionFont != null)
                {
                    switch (rtbDoc.SelectionFont.Bold)
                    {
                        #region Quitar Negrita
                        case true:
                            #region El estilo de la fuente es negrita y se queda en regular
                            if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Italic == false)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                            }
                            #endregion
                            #region El estilo de la fuente es negrita, itálica y subrayado y se queda en itálica y subrayado
                            if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Italic == true)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Italic);
                            }
                            #endregion
                            #region El estilo de la fuente es negrita e itálica y se queda en itálica
                            if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Italic == true)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic);
                            }
                            #endregion
                            #region El estilo de la fuente es negrita y subrayado y se queda en subrayado
                            if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Italic == false)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Underline);
                            }
                            #endregion
                            break;
                        #endregion
                        #region Añadir Negrita
                        case false:
                            #region El estilo de la fuente es regular y se pone en negrita
                            if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Italic == false)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold);
                            }
                            #endregion
                            #region El estilo de la fuente es subrayado e itálica y se añade negrita
                            if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Italic == true)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Italic);
                            }
                            #endregion
                            #region El estilo de la fuente es itálica y se añade negrita
                            if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Italic == true)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                            }
                            #endregion
                            #region El estilo de la fuente es subrayado y se añade negrita
                            if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Italic == false)
                            {
                                rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
                            }
                            #endregion
                            break;
                        #endregion
                    }
                }
            }
            catch
            {
                // Ignorar el error.
            }
        }
        /// <summary>
        /// Establecer el texto en italica.
        /// </summary>
        void Italic()
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool btCursiva = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Cursiva"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            if (rtbDoc.SelectionFont != null)
            {
                switch (rtbDoc.SelectionFont.Italic)
                {
                    #region Quitar Itálica
                    case true:
                        #region El estilo de la fuente es itálica y se queda en regular
                        if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica, negrita y subrayado y se queda en subrayado y negrita
                        if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica y negrita y se queda en negrita
                        if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica y subrayado y se queda en subrayado
                        if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Underline);
                        }
                        #endregion
                        break;
                    #endregion
                    #region Añadir Itálica
                    case false:
                        #region El estilo de la fuente es regular y se pone en itálica
                        if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic);
                        }
                        #endregion
                        #region El estilo de la fuente es subrayado y negrita y se añade itálica
                        if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold);
                        }
                        #endregion
                        #region El estilo de la fuente es negrita y se añade itálica
                        if (rtbDoc.SelectionFont.Underline == false && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                        }
                        #endregion
                        #region El estilo de la fuente es subrayado y se añade itálica
                        if (rtbDoc.SelectionFont.Underline == true && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline);
                        }
                        #endregion
                        break;
                    #endregion
                }
            }
        }
        /// <summary>
        /// Establecer el texto subrayado.
        /// </summary>
        void Underline()
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool btsubrayado = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Subrayado"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            if (rtbDoc.SelectionFont != null)
            {
                switch (rtbDoc.SelectionFont.Underline)
                {
                    #region Quitar Subrayado
                    case true:
                        #region El estilo de la fuente es subrayado y se queda en regular
                        if (rtbDoc.SelectionFont.Italic == false && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Regular);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica, negrita y subrayado y se queda en itálica y negrita
                        if (rtbDoc.SelectionFont.Italic == true && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold);
                        }
                        #endregion
                        #region El estilo de la fuente es subrayado y negrita y se queda en negrita
                        if (rtbDoc.SelectionFont.Italic == false && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica y subrayado y se queda en itálica
                        if (rtbDoc.SelectionFont.Italic == true && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic);
                        }
                        #endregion
                        break;
                    #endregion
                    #region Añadir Subrayado
                    case false:
                        #region El estilo de la fuente es regular y se pone en subrayado
                        if (rtbDoc.SelectionFont.Italic == false && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Underline);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica y negrita y se añade subrayado
                        if (rtbDoc.SelectionFont.Italic == true && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold);
                        }
                        #endregion
                        #region El estilo de la fuente es negrita y se añade subrayado
                        if (rtbDoc.SelectionFont.Italic == false && rtbDoc.SelectionFont.Bold == true)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
                        }
                        #endregion
                        #region El estilo de la fuente es itálica y se añade subrayado
                        if (rtbDoc.SelectionFont.Italic == true && rtbDoc.SelectionFont.Bold == false)
                        {
                            rtbDoc.SelectionFont = new System.Drawing.Font(rtbDoc.SelectionFont.FontFamily, rtbDoc.SelectionFont.Size, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline);
                        }
                        #endregion
                        break;
                    #endregion
                }
            }
        }
        /// <summary>
        /// Establecer color de texto.
        /// </summary>
        void SeleccionarForeColor()
        {
            colorDialog.Color = rtbDoc.ForeColor;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtbDoc.SelectionColor = colorDialog.Color;
            }
        }
        /// <summary>
        /// Establecer color de fondo del texto.
        /// </summary>
        void SeleccionarBackColor()
        {
            colorDialog.Color = rtbDoc.SelectionBackColor;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtbDoc.SelectionBackColor = colorDialog.Color;
            }
        }
        /// <summary>
        /// Insertar imagen.
        /// </summary>
        void InsertarImagen()
        {
            openFileDialog.Title = "Insertar imagen";
            openFileDialog.DefaultExt = "rtf";
            openFileDialog.Filter = "Fichero JPG|*.jpg|Fichero BMP|*.bmp|Fichero GIF|*.gif|Todos los ficheros|*.*";
            System.Windows.Forms.DialogResult resultado = openFileDialog.ShowDialog();
            if (resultado != System.Windows.Forms.DialogResult.Cancel)
            {
                using (System.Drawing.Image img = System.Drawing.Image.FromFile(openFileDialog.FileName))
                {
                    System.Windows.Forms.Clipboard.SetDataObject(img);
                    System.Windows.Forms.DataFormats.Format df = System.Windows.Forms.DataFormats.GetFormat(System.Windows.Forms.DataFormats.Bitmap);
                    if (rtbDoc.CanPaste(df))
                    {
                        rtbDoc.Paste(df);
                    }
                }
            }
        }
        /// <summary>
        /// Abrir archivo.
        /// </summary>
        void AbrirArchivo()
        {
            openFileDialog.Title = "Abrir fichero";
            openFileDialog.DefaultExt = "rtf";
            openFileDialog.Filter = "RtfFiltro";
            openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                string strExt = System.IO.Path.GetExtension(openFileDialog.FileName);
                strExt = strExt.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
                if (strExt == ".RTF")
                {
                    rtbDoc.LoadFile(openFileDialog.FileName, System.Windows.Forms.RichTextBoxStreamType.RichText);
                }
                else
                {
                    using (System.IO.StreamReader txtReader = new System.IO.StreamReader(openFileDialog.FileName))
                    {
                        rtbDoc.Text = txtReader.ReadToEnd();
                    }
                    rtbDoc.SelectionStart = 0;
                    rtbDoc.SelectionLength = 0;
                }
            }
        }
        /// <summary>
        /// Guardar archivo.
        /// </summary>
        void Guardar()
        {
            saveFileDialog.Title = "Guardar fichero";
            saveFileDialog.DefaultExt = "rtf";
            saveFileDialog.Filter = "RtfFiltro";
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                string strExt = System.IO.Path.GetExtension(saveFileDialog.FileName);
                strExt = strExt.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
                if (strExt == ".RTF")
                {
                    rtbDoc.SaveFile(saveFileDialog.FileName, System.Windows.Forms.RichTextBoxStreamType.RichText);
                }
                else
                {
                    using (System.IO.StreamWriter txtWriter = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        txtWriter.Write(rtbDoc.Text);
                    }
                    rtbDoc.SelectionStart = 0;
                    rtbDoc.SelectionLength = 0;
                }
            }
        }
        /// <summary>
        /// Cambiar fuente de texto.
        /// </summary>
        void CambiarFuente()
        {
            if (rtbDoc.SelectionFont != null)
            {
                fontDialog.Font = rtbDoc.SelectionFont;
            }
            else
            {
                fontDialog.Font = null;
            }
            fontDialog.ShowApply = true;
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtbDoc.SelectionFont = fontDialog.Font;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// BoldButtonClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BoldButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                Negrita();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// ItalicButtonClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void ItalicButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                Italic();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// UnderlineButtonClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void UnderlineButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                Underline();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// ColorButtonClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void ColorButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                SeleccionarForeColor();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BackColorButtonClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BackColorButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                SeleccionarBackColor();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// ImageButtonClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void ImageButtonClick(object sender, System.EventArgs e)
        {
            try
            {
                InsertarImagen();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BtnChangeFontClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BtnChangeFontClick(object sender, System.EventArgs e)
        {
            try
            {
                CambiarFuente();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BtnInsertarImagenClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BtnInsertarImagenClick(object sender, System.EventArgs e)
        {
            try
            {
                InsertarImagen();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BtnUnorderedListClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BtnUnorderedListClick(object sender, System.EventArgs e)
        {
            try
            {
                rtbDoc.SelectionBullet = !rtbDoc.SelectionBullet;
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BtnOutdentClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BtnOutdentClick(object sender, System.EventArgs e)
        {
            try
            {
                if (rtbDoc.SelectionIndent >= 20)
                {
                    rtbDoc.SelectionIndent = rtbDoc.SelectionIndent - 20;
                }
                else
                {
                    rtbDoc.SelectionIndent = 0;
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BtnGuardarClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BtnGuardarClick(object sender, System.EventArgs e)
        {
            try
            {
                Guardar();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BtnAbrirClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void BtnAbrirClick(object sender, System.EventArgs e)
        {
            try
            {
                AbrirArchivo();
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// RtbTextChanged.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void RtbTextChanged(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinToolbars.StateButtonTool btNegrita = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Negrita"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            Infragistics.Win.UltraWinToolbars.StateButtonTool btCursiva = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Cursiva"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            Infragistics.Win.UltraWinToolbars.StateButtonTool btsubrayado = this.tlbOrbitaTextEditor.Toolbars["tlbOrbitaTextEditorPro"].Tools["Subrayado"] as Infragistics.Win.UltraWinToolbars.StateButtonTool;
            try
            {
                if (!this.cambiandoValorTexto)
                {
                    this.modified = true;
                    #region Negrita
                    if (this.rtbDoc.SelectionFont.Bold == true)
                    {
                        btNegrita.Checked = true;
                    }
                    else
                    {
                        btNegrita.Checked = false;
                    }
                    #endregion
                    #region Cursiva
                    if (this.rtbDoc.SelectionFont.Italic == true)
                    {
                        btCursiva.Checked = true;
                    }
                    else
                    {
                        btCursiva.Checked = false;
                    }
                    #endregion
                    #region Subrayado
                    if (this.rtbDoc.SelectionFont.Underline == true)
                    {
                        btsubrayado.Checked = true;
                    }
                    else
                    {
                        btsubrayado.Checked = false;
                    }
                    #endregion
                }
            }
            catch
            {
                // Ignorar el error de formato.
            }
        }
        /// <summary>
        /// ReadOnly.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void Evento_ReadOnly(object sender, System.EventArgs e)
        {
            this.OrbSoloLectura = this.readOnly;
        }
        /// <summary>
        /// ToolClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        protected void OrbitaUltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case "Abrir":
                        AbrirArchivo();
                        break;
                    case "Guardar":
                        Guardar();
                        break;
                    case "Fuente":
                        CambiarFuente();
                        break;
                    case "Negrita":
                        Negrita();
                        break;
                    case "Cursiva":
                        Italic();
                        break;
                    case "Subrayado":
                        Underline();
                        break;
                    case "Color Fuente":
                        SeleccionarForeColor();
                        break;
                    case "Color Marcador":
                        SeleccionarBackColor();
                        break;
                    case "Insertar Imagen":
                        InsertarImagen();
                        break;
                    case "Derecha":
                        rtbDoc.SelectionAlignment = TextAlign.Right;
                        break;
                    case "Centrado":
                        rtbDoc.SelectionAlignment = TextAlign.Center;
                        break;
                    case "Izquierda":
                        rtbDoc.SelectionAlignment = TextAlign.Left;
                        break;
                    case "Justificado":
                        rtbDoc.SelectionAlignment = TextAlign.Justify;
                        break;
                    case "Vinetas":
                        rtbDoc.SelectionBullet = !rtbDoc.SelectionBullet;
                        break;
                    case "Aumentar Sangria":
                        rtbDoc.SelectionIndent = rtbDoc.SelectionIndent + 20;
                        break;
                    case "Disminuir Sangria":
                        if (rtbDoc.SelectionIndent >= 20)
                        {
                            rtbDoc.SelectionIndent = rtbDoc.SelectionIndent - 20;
                        }
                        else
                        {
                            rtbDoc.SelectionIndent = 0;
                        }
                        break;
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "ExcepcionError", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        #endregion
    }
}