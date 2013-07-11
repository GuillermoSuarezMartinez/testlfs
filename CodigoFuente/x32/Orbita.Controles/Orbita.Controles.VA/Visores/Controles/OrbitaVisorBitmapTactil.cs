//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 07-07-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Orbita.VA.Comun;
using Orbita.VA.Hardware;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Display genérico para bitmaps
    /// </summary>
    public partial class OrbitaVisorBitmapTactil : OrbitaVisorBase
    {
        #region Atributo(s)
        /// <summary>
        /// Indica la posición actual del scroll
        /// </summary>
        private Point CurrentScrollPosition;
        /// <summary>
        /// Indica la velocidad de adquisición actual
        /// </summary>
        private double CurrentFps;
        /// <summary>
        /// Tamaño previo del control
        /// </summary>
        private Size PreviousSize;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Muestra el botón de modo puntero
        /// </summary>
        private bool _MostrarBtnModoPuntero = false;
        /// <summary>
        /// Muestra el botón de modo puntero
        /// </summary>
        [Browsable(false),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de modo puntero"),
        DefaultValue(false)]
        protected bool MostrarBtnModoPuntero
        {
            get { return _MostrarBtnModoPuntero; }
            set
            {
                this._MostrarBtnModoPuntero = value;
                this.btnPointer.Visible = value;
                this.separadorZoom.Visible = this._MostrarBtnModoPuntero || this._MostrarBtnModoDeslizar || this._MostrarBtnModoZoom || this._MostrarBtnModoZoomFit;
            }
        }

        /// <summary>
        /// Muestra el botón de modo deslizar
        /// </summary>
        private bool _MostrarBtnModoDeslizar = false;
        /// <summary>
        /// Muestra el botón de modo deslizar
        /// </summary>
        [Browsable(false),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de modo deslizar"),
        DefaultValue(false)]
        protected bool MostrarBtnModoDeslizar
        {
            get { return _MostrarBtnModoDeslizar; }
            set
            {
                this._MostrarBtnModoDeslizar = value;
                this.btnHand.Visible = value;
                this.separadorZoom.Visible = this._MostrarBtnModoPuntero || this._MostrarBtnModoDeslizar || this._MostrarBtnModoZoom || this._MostrarBtnModoZoomFit;
            }
        }

        /// <summary>
        /// Muestra el botón de modo zoom in
        /// </summary>
        private bool _MostrarBtnModoZoom = true;
        /// <summary>
        /// Muestra el botón de modo zoom in
        /// </summary>
        [Browsable(false),
        Category("Orbita"),
        Description("Indica si se ha de mostrar los botones de modo zoon"),
        DefaultValue(true)]
        protected bool MostrarBtnModoZoom
        {
            get { return _MostrarBtnModoZoom; }
            set
            {
                this._MostrarBtnModoZoom = value;
                this.btnZoomIn.Visible = value;
                this.btnZoomOut.Visible = value;
                this.separadorZoom.Visible = this._MostrarBtnModoPuntero || this._MostrarBtnModoDeslizar || this._MostrarBtnModoZoom || this._MostrarBtnModoZoomFit;
            }
        }

        /// <summary>
        /// Muestra el botón de modo zoom fit
        /// </summary>
        private bool _MostrarBtnModoZoomFit = true;
        /// <summary>
        /// Muestra el botón de modo zoom fit
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de modo zoon fit"),
        DefaultValue(true)]
        protected bool MostrarBtnModoZoomFit
        {
            get { return _MostrarBtnModoZoomFit; }
            set
            {
                this._MostrarBtnModoZoomFit = value;
                this.BtnFit.Visible = value;
                this.separadorZoom.Visible = this._MostrarBtnModoPuntero || this._MostrarBtnModoDeslizar || this._MostrarBtnModoZoom || this._MostrarBtnModoZoomFit;
            }
        }

        /// <summary>
        /// Muestra el la información de posición en la barra de estado
        /// </summary>
        private bool _MostrarStatusPosicion = true;
        /// <summary>
        /// Muestra el la información de posición en la barra de estado
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la información de posición en la barra de estado"),
        DefaultValue(true)]
        protected bool MostrarStatusPosicion
        {
            get { return _MostrarStatusPosicion; }
            set
            {
                this._MostrarStatusPosicion = value;
                this.lblCursor.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el la información de tamaño de la imagen en la barra de estado
        /// </summary>
        private bool _MostrarStatusTamaño = false;
        /// <summary>
        /// Muestra el la información de tamaño de la imagen en la barra de estado
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la información de tamaño de la imagen en la barra de estado"),
        DefaultValue(false)]
        protected bool MostrarStatusTamaño
        {
            get { return _MostrarStatusTamaño; }
            set
            {
                this._MostrarStatusTamaño = value;
                this.lblViewArea.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el la información del zoom actual en la barra de estado
        /// </summary>
        private bool _MostrarStatusZoom = true;
        /// <summary>
        /// Muestra el la información del zoom actual en la barra de estado
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la información del zoom actual en la barra de estado"),
        DefaultValue(true)]
        protected bool MostrarStatusZoom
        {
            get { return _MostrarStatusZoom; }
            set
            {
                this._MostrarStatusZoom = value;
                this.lblZoom.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el la información del desplazamiento actual del visor
        /// </summary>
        private bool _MostrarStatusPosicionScroll = false;
        /// <summary>
        /// Muestra el la información del desplazamiento actual del visor
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la información del desplazamiento actual del visor"),
        DefaultValue(false)]
        protected bool MostrarStatusPosicionScroll
        {
            get { return _MostrarStatusPosicionScroll; }
            set
            {
                this._MostrarStatusPosicionScroll = value;
                this.lblAutoScrollPosition.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el la información de la selección actual
        /// </summary>
        private bool _MostrarStatusSeleccion = false;
        /// <summary>
        /// Muestra el la información de la selección actual
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la información de la selección actual"),
        DefaultValue(false)]
        protected bool MostrarStatusSeleccion
        {
            get { return _MostrarStatusSeleccion; }
            set
            {
                this._MostrarStatusSeleccion = value;
                this.lblSelection.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el la información sobre el valor del píxel actual
        /// </summary>
        private bool _MostrarStatusValorPixel = true;
        /// <summary>
        /// Muestra el la información sobre el valor del píxel actual
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar información sobre el valor del píxel actual"),
        DefaultValue(true)]
        public bool MostrarStatusValorPixel
        {
            get { return _MostrarStatusValorPixel; }
            set
            {
                this._MostrarStatusValorPixel = value;
                this.lblPixelValue.Visible = value;
            }
        }

        /// <summary>
        /// Opciones del arraster del botón izquierdo
        /// </summary>
        [Browsable(true),
        Category("Opciones Ratón"),
        Description("Indica la acción de arrastrar el botón izquierdo"),
        DefaultValue(OpcionMantenerClickBotones.Pan)]
        public OpcionMantenerClickBotones MantenerBotonIzquierdo
        {
            get { return this.VisorImagenes._botonIZQ.OpcionArrastrarClick; }
            set { this.VisorImagenes._botonIZQ.OpcionArrastrarClick = value; }
        }

        /// <summary>
        /// Opciones del arrastrar del botón izquierdo
        /// </summary>
        [Browsable(true),
        Category("Opciones Ratón"),
        Description("Indica la acción de arrastrar el botón derecho"),
        DefaultValue(OpcionMantenerClickBotones.Pan)]
        public OpcionMantenerClickBotones MantenerBotonDerecho
        {
            get { return this.VisorImagenes._botonDER.OpcionArrastrarClick; }
            set { this.VisorImagenes._botonDER.OpcionArrastrarClick = value; }
        }

        /// <summary>
        /// Opciones del arrastrar del botón central
        /// </summary>
        [Browsable(true),
        Category("Opciones Ratón"),
        Description("Indica la acción de arrastrar el botón central"),
        DefaultValue(OpcionMantenerClickBotones.Nada)]
        public OpcionMantenerClickBotones MantenerBotonCentral
        {
            get { return this.VisorImagenes._botonMED.OpcionArrastrarClick; }
            set { this.VisorImagenes._botonMED.OpcionArrastrarClick = value; }
        }

        /// <summary>
        /// Opciones del clic del botón izquierdo
        /// </summary>
        [Browsable(true),
        Category("Opciones Ratón"),
        Description("Indica la acción de clic con el botón izquierdo"),
        DefaultValue(OpcionClickBotones.ZoomMas)]
        public OpcionClickBotones ClickBotonIzquierdo
        {
            get { return this.VisorImagenes._botonIZQ.OpcionClick; }
            set { this.VisorImagenes._botonIZQ.OpcionClick = value; }
        }

        /// <summary>
        /// Opciones del clic del botón derecho
        /// </summary>
        [Browsable(true),
        Category("Opciones Ratón"),
        Description("Indica la acción de clic con el botón derecho"),
        DefaultValue(OpcionClickBotones.ZoomMenos)]
        public OpcionClickBotones ClickBotonDerecho
        {
            get { return this.VisorImagenes._botonDER.OpcionClick; }
            set { this.VisorImagenes._botonDER.OpcionClick = value; }
        }

        /// <summary>
        /// Opciones del clic del botón central
        /// </summary>
        [Browsable(true),
        Category("Opciones Ratón"),
        Description("Indica la acción de clic con el botón central"),
        DefaultValue(OpcionClickBotones.AutoCenter)]
        public OpcionClickBotones ClickBotonCentral
        {
            get { return this.VisorImagenes._botonMED.OpcionClick; }
            set { this.VisorImagenes._botonMED.OpcionClick = value; }
        }

        /// <summary>
        /// Permite zoom al hacer click
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Permite zoom al hacer click")]
        public bool PermitirClickZoom
        {
            get { return this.VisorImagenes.AllowClickZoom; }
            set { this.VisorImagenes.AllowClickZoom = value; }
        }

        /// <summary>
        /// Permite cambiar el zoom
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Permite cambiar el zoom")]
        public bool PermitirZoom
        {
            get { return this.VisorImagenes.AllowZoom; }
            set { this.VisorImagenes.AllowZoom = value; }
        }

        /// <summary>
        /// Centra automáticamente la imagen al realizar el zoom
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Centra automáticamente la imagen al realizar el zoom")]
        public bool AutoCenter
        {
            get { return this.VisorImagenes.AutoCenter; }
            set { this.VisorImagenes.AutoCenter = value; }
        }

        /// <summary>
        /// Permite desplazar la imagen
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Permite desplazar la imagen")]
        public bool AutoPan
        {
            get { return this.VisorImagenes.AutoPan; }
            set { this.VisorImagenes.AutoPan = value; }
        }

        /// <summary>
        /// Tamaño del grid de fondo
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Tamaño del grid de fondo"),
        DefaultValue(8)]
        public int GridCellSize
        {
            get { return this.VisorImagenes.GridCellSize; }
            set { this.VisorImagenes.GridCellSize = value; }
        }

        /// <summary>
        /// Color del grid de fondo
        /// </summary>
        [Browsable(true),
        Category("Color del grid de fondo"),
        DefaultValue(typeof(Color), "Gainsboro")]
        public Color GridColor
        {
            get { return this.VisorImagenes.GridColor; }
            set { this.VisorImagenes.GridColor = value; }
        }

        /// <summary>
        /// Color alternativo del grid de fondo
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Color alternativo del grid de fondo"),
        DefaultValue(typeof(Color), "White")]
        public Color GridColorAlternate
        {
            get { return this.VisorImagenes.GridColorAlternate; }
            set { this.VisorImagenes.GridColorAlternate = value; }
        }

        /// <summary>
        /// Modo de visualización del fondo
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Modo de visualización del fondo"),
        DefaultValue(VisorImagenesGridDisplayMode.Client)]
        public VisorImagenesGridDisplayMode GridDisplayMode
        {
            get { return this.VisorImagenes.GridDisplayMode; }
            set { this.VisorImagenes.GridDisplayMode = value; }
        }

        /// <summary>
        /// Escala del grid de fondo
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Escala del grid de fondo"),
        DefaultValue(typeof(VisorImagenesGridScale), "Small")]
        public VisorImagenesGridScale GridScale
        {
            get { return this.VisorImagenes.GridScale; }
            set { this.VisorImagenes.GridScale = value; }
        }

        [Browsable(true),
        Category("Appearance"),
        Description("Estilo del borde"),
        DefaultValue(typeof(VisorImagenesBorderStyle), "None")]
        public VisorImagenesBorderStyle ImageBorderStyle
        {
            get { return this.VisorImagenes.ImageBorderStyle; }
            set { this.VisorImagenes.ImageBorderStyle = value; }
        }

        [Browsable(true),
        Category("Appearance"),
        Description("Modo de interpolación"),
        DefaultValue(InterpolationMode.NearestNeighbor)]
        public InterpolationMode InterpolationMode
        {
            get { return this.VisorImagenes.InterpolationMode; }
            set { this.VisorImagenes.InterpolationMode = value; }
        }

        [Browsable(true),
        Category("Behavior"),
        Description("Invertir el ratón")]
        public bool InvertMouse
        {
            get { return this.VisorImagenes.InvertMouse; }
            set { this.VisorImagenes.InvertMouse = value; }
        }
        #endregion

        #region Propiedad(es) heredada(s)
        /// <summary>
        /// Propieadad a heredar donde se accede a la imagen
        /// </summary>
        public override OImagen ImagenActual
        {
            get { return (OImagenBitmap)this._ImagenActual; }
            set
            {
                if (value is OImagenBitmap)
                {
                    this._ImagenActual = value;
                }
                else if (value is OImagen)
                {
                    OImagenBitmap valueConverted;
                    if (value.Convert<OImagenBitmap>(out valueConverted))
                    {
                        this._ImagenActual = valueConverted;
                    }
                }
            }
        }

        /// <summary>
        /// Muestra la barra superior de botones
        /// </summary>
        public override bool MostrarToolStrip
        {
            get { return _MostrarToolStrip; }
            set
            {
                this._MostrarToolStrip = value;
                this.ToolStripTop.Visible = value;
            }
        }

        /// <summary>
        /// Muestra la barra inferior de estado
        /// </summary>
        public override bool MostrarStatusBar
        {
            get { return _MostrarStatusBar; }
            set
            {
                this._MostrarStatusBar = value;
                this.StatusStripBottom.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el botón de abrir fotografía
        /// </summary>
        public override bool MostrarBtnAbrir
        {
            get { return _MostrarBtnAbrir; }
            set
            {
                this._MostrarBtnAbrir = value;
                this.btnOpen.Visible = value;
                this.separadorArchivos.Visible = this._MostrarBtnGuardar || this._MostrarBtnAbrir;
            }
        }

        /// <summary>
        /// Muestra el botón de guardar fotografía
        /// </summary>
        public override bool MostrarbtnGuardar
        {
            set
            {
                this._MostrarBtnGuardar = value;
                this.btnSave.Visible = value;
                this.separadorArchivos.Visible = this._MostrarBtnGuardar || this._MostrarBtnAbrir;
            }
        }

        /// <summary>
        /// Muestra el botón de play/stop
        /// </summary>
        public override bool MostrarBtnReproduccion
        {
            set
            {
                this._MostrarBtnReproduccion = value;
                this.btnPlayStop.Visible = value;
                this.separadorReproduccion.Visible = this._MostrarBtnReproduccion | this._MostrarBtnSnap;
            }
        }

        /// <summary>
        /// Muestra el botón de snap
        /// </summary>
        public override bool MostrarBtnSnap
        {
            set
            {
                this._MostrarBtnSnap = value;
                this.btnSnap.Visible = value;
                this.separadorReproduccion.Visible = this._MostrarBtnReproduccion | this._MostrarBtnSnap;
            }
        }

        /// <summary>
        /// Muestra la etiqueta del título
        /// </summary>
        public override bool MostrarLblTitulo
        {
            set
            {
                this._MostrarLblTitulo = value;
                this.lblTituloDisplay.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el botón de información del visor
        /// </summary>
        public override bool MostrarBtnInfo
        {
            set
            {
                this._MostrarBtnInfo = value;
                this.btnInfo.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el botón de maximizar/minimizar
        /// </summary>
        public override bool MostrarBtnMaximinzar
        {
            set
            {
                this._MostrarBtnMaximinzar = value;
                this.btnMaximize.Visible = value;
            }
        }

        /// <summary>
        /// Muestra los botones de siguiente/anterior dispositivo
        /// </summary>
        public override bool MostrarBtnSiguienteAnterior
        {
            set
            {
                this._MostrarBtnSiguienteAnterior = value;
            }
        }

        /// <summary>
        /// Muestra el la información adicional de la imagen visualizada
        /// </summary>
        public override bool MostrarStatusMensaje
        {
            get { return _MostrarStatusMensaje; }
            set
            {
                this._MostrarStatusMensaje = value;
                this.lblMensaje.Visible = value;
            }
        }

        /// <summary>
        /// Muestra el la información de la velocidad de adquisición de la cámara asociada
        /// </summary>
        public override bool MostrarStatusFps
        {
            get { return _MostrarStatusFps; }
            set
            {
                this._MostrarStatusFps = value;
                this.lblFps.Visible = value;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaVisorBitmapTactil()
            : base()
        {
            InitializeComponent();

            this._CurrentCursorPosition = new PointF();
            this.CurrentScrollPosition = new Point();
            this.PreviousSize = this.Size;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="titulo">Titulo a visualizar en el display</param>
        public OrbitaVisorBitmapTactil(string titulo, string codCamara, double maxFrameIntervalVisualizacion, bool asociarCamara, bool visualizarEnVivo) :
            base(titulo, codCamara, maxFrameIntervalVisualizacion, asociarCamara, visualizarEnVivo)
        {
            InitializeComponent();

            // Título del display
            this.lblTituloDisplay.Text = titulo;

            this._CurrentCursorPosition = new PointF();
            this.CurrentScrollPosition = new Point();
            this.PreviousSize = this.Size;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Formatea un punto como texto para ser visualizado
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private string FormatPoint(Point point)
        {
            return string.Format("X:{0}, Y:{1}", point.X, point.Y);
        }

        /// <summary>
        /// Formatea un punto como texto para ser visualizado
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private string FormatPointF(PointF point)
        {
            return string.Format("X:{0:0.00}, Y:{1:0.00}", point.X, point.Y);
        }

        /// <summary>
        /// Formatea un rectangulo como texto para ser visualizado
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private string FormatRectangle(RectangleF rect)
        {
            return string.Format("X:{0:0.00}, Y:{1:0.00}, W:{2:0.00}, H:{3:0.00}", (int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }

        /// <summary>
        /// Formatea un rectangulo como texto para ser visualizado
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private string FormatColor(int red, int green, int blue)
        {
            return string.Format("R:{0}, G:{1}, B:{2}", red, green, blue);
        }

        /// <summary>
        /// Formatea un rectangulo como texto para ser visualizado
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private string FormatGray(int gray)
        {
            return string.Format("G:{0}", gray);
        }

        /// <summary>
        /// Visualiza la posición del cursor en la statusbar
        /// </summary>
        /// <param name="location"></param>
        private void UpdateCursorPosition(PointF location)
        {
            this.lblCursor.Text = location != Point.Empty ? this.FormatPointF(location) : string.Empty;
        }

        /// <summary>
        /// Visualiza la posición del scroll
        /// </summary>
        /// <param name="scrollPosition"></param>
        private void UpdateAutoScrollPosition(Point scrollPosition)
        {
            this.lblAutoScrollPosition.Text = this.FormatPoint(scrollPosition);
        }

        /// <summary>
        /// Visualiza el tamaño de la imagen
        /// </summary>
        /// <param name="scrollPosition"></param>
        private void UpdateViewArea(RectangleF imageSize)
        {
            this.lblViewArea.Text = imageSize != RectangleF.Empty ? this.FormatRectangle(imageSize) : string.Empty;
        }

        /// <summary>
        /// Visualiza el nivel de zoom
        /// </summary>
        /// <param name="scrollPosition"></param>
        private void UpdateZoomLevel(int zoomLevel)
        {
            this.lblZoom.Text = string.Format("{0}%", zoomLevel);
        }

        /// <summary>
        /// Visualiza la selección actual
        /// </summary>
        /// <param name="selectedRegion"></param>
        private void UpdateSelectedRegion(RectangleF selectedRegion)
        {
            this.lblSelection.Text = selectedRegion == RectangleF.Empty ? string.Empty : this.FormatRectangle(selectedRegion);
        }

        /// <summary>
        /// Visualiza la selección actual
        /// </summary>
        /// <param name="selectedRegion"></param>
        private void UpdateFps()
        {
            this.lblFps.Text = "fps: " + this.CurrentFps.ToString("#0.0");
        }

        /// <summary>
        /// Visualiza el valor de color actual
        /// </summary>
        /// <param name="selectedRegion"></param>
        private void UpdatePixelValue(int red, int green, int blue)
        {
            this.lblPixelValue.Text = this.FormatColor(red, green, blue);
        }

        /// <summary>
        /// Visualiza el valor de color actual
        /// </summary>
        /// <param name="selectedRegion"></param>
        private void UpdatePixelValue(int gray)
        {
            this.lblPixelValue.Text = this.FormatGray(gray);
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Aumentamos el zoom de la imagen
        /// </summary>
        public void ZoomIn()
        {
            this.VisorImagenes.ZoomIn();
        }

        /// <summary>
        /// Disminuimos el zoom de la imagen
        /// </summary>
        public void ZoomOut()
        {
            this.VisorImagenes.ZoomOut();
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga los valores de la cámara
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();
        }

        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();
        }

        /// <summary>
        /// Carga una imagen de disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se encuentra la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool CargarImagenDeDisco(string ruta)
        {
            bool resultado = false;

            if (this.ImagenActual != null)
            {
                this.ImagenActual = null;
            }

            this.ImagenActual = new OImagenBitmap();
            resultado = this.ImagenActual.Cargar(ruta);

            if (resultado)
            {
                this.VisualizarInterno();
            }

            return resultado;
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool GuardarImagenADisco(string ruta)
        {
            bool resultado = false;

            if (this.ImagenActual is OImagenBitmap)
            {
                resultado = this.ImagenActual.Guardar(ruta);
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve una nueva imagen del tipo adecuado al trabajo con el display
        /// </summary>
        /// <returns>Imagen del tipo adecuado al trabajo con el display</returns>
        public override OImagen NuevaImagen()
        {
            return new OImagenBitmap();
        }

        /// <summary>
        /// Visualiza una imagen en el display
        /// </summary>
        /// <param name="imagen">Imagen a visualizar</param>
        protected override void VisualizarInterno()
        {
            base.VisualizarInterno();

            // Se carga la imagen y los gráficos siguiendo las recomendaciones de cognex para optimizar el rendimiento
            if (this.ImagenActual is OImagenBitmap)
            {
                Bitmap bmpAnterior = this.VisorImagenes.Image as Bitmap;
                Bitmap bmpNuevo = ((OImagenBitmap)this.ImagenActual).Image;

                bool debeAjustar = !BitmapFactory.IsCompatible(bmpAnterior, bmpNuevo);

                this.VisorImagenes.Image = ((OImagenBitmap)this.ImagenActual).Image;
                //this.VisorImagenes.Refresh();

                if (debeAjustar)
                {
                    this.ZoomFit();
                    this.TimerUpdateAutoScrollPosition.Start();
                    this.TimerUpdateViewSize.Start();
                    this.TimerUpdateZoomLevel.Start();
                }
            }
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        public override void ZoomFit()
        {
            this.VisorImagenes.ZoomToFit();
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        public override void ZoomFull()
        {
            this.VisorImagenes.Zoom = 100;
        }

        /// <summary>
        /// Se aplica un factor de escalado
        /// </summary>
        public override void ZoomValue(double value)
        {
            this.VisorImagenes.Zoom = (int)Math.Truncate(value);
        }

        /// <summary>
        /// Muestra un mensaje de información sobre el dispositivo origen
        /// </summary>
        public override void MostrarMensaje(string mensaje)
        {
            this.lblMensaje.Text = mensaje;
        }

        /// <summary>
        /// Muestra la velocidad de adquisición de la cámara asociada
        /// </summary>
        public override void MostrarFps(double framePerSecond)
        {
            this.CurrentFps = framePerSecond;
            this.TimerUpdateFps.Start();
        }

        /// <summary>
        /// Maximizamos o restauramos la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void AccionMaximizarMinimizar(FormWindowState estadoVentana)
        {
            base.AccionMaximizarMinimizar(estadoVentana);
            switch (this.EstadoVentana)
            {
                case FormWindowState.Normal:
                    this.btnMaximize.Image = Properties.Resources.imgFullScreen24Blanco;
                    this.btnNext.Visible = false;
                    this.btnPrev.Visible = false;
                    break;
                case FormWindowState.Maximized:
                default:
                    this.btnMaximize.Image = Properties.Resources.ImgNoFullScreen24Blanco;
                    this.btnNext.Visible = this._MostrarBtnSiguienteAnterior;
                    this.btnPrev.Visible = this._MostrarBtnSiguienteAnterior;
                    break;
            }
        }

        /// <summary>
        /// Método que indica que la cámara ha cambiado su modo de reproducción
        /// </summary>
        /// <param name="modoReproduccionContinua"></param>
        protected override void CambioModoReproduccionCamara(object sender, CambioEstadoReproduccionCamaraEventArgs e)
        {
            this.btnPlayStop.Image = e.ModoReproduccionContinua ? Properties.Resources.ImgStop24Blanco : Properties.Resources.ImgPlay24Blanco;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Carga del control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlDisplayBitmap_Load(object sender, EventArgs e)
        {
            try
            {
                //this.MostrarBtnModoPuntero = false;
                //this.MostrarBtnModoDeslizar = false;
                //this.MostrarBtnModoZoom = true;
                //this.MostrarBtnModoZoomFit = true;
                //this.MostrarStatusPosicion = true;
                //this.MostrarStatusTamaño = true;
                //this.MostrarStatusZoom = true;
                //this.MostrarStatusPosicionScroll = true;
                //this.MostrarStatusSeleccion = true;
                //this.MostrarStatusValorPixel = false;

                this.VisorImagenes.SelectionMode = VisorImagenesSelectionMode.Zoom;
                this.VisorImagenes.AllowClickZoom = true;
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Carga la imagen actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarImagenDialogo();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Guarda la imagen actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.GuardarImagenDialogo();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Se aumenta el zoom
        /// </summary>
        protected void btnZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ZoomIn();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Se disminuye el zoom
        /// </summary>
        protected void btnZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.ZoomOut();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        protected void btnZoomFit_Click(object sender, EventArgs e)
        {
            try
            {
                this.ZoomFit();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Mostramos el formulario de información de la cámara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInfoDispositivo();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Maximizamos o restauramos la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMaximize_Click(object sender, EventArgs e)
        {
            try
            {
                FormWindowState estadoVentana = this.EstadoVentana == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                this.AccionMaximizarMinimizar(estadoVentana);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Avanzamos al siguiente visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.EstadoVentana == FormWindowState.Maximized)
                {
                    this.CambioVisor(EventDeviceViewerChangedArgs.DeviceViewerChangeOrder.next);
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Retrocedemos al visor anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.EstadoVentana == FormWindowState.Maximized)
                {
                    this.CambioVisor(EventDeviceViewerChangedArgs.DeviceViewerChangeOrder.previous);
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Botón de play/stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.BotonPlayStopPulsado();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Botón de Snap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                this.BotonSnapPulsado();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Zoom cambiado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_ZoomChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ImagenActual is OImagenBitmap)
                {
                    this.TimerUpdateZoomLevel.Start();
                    this.TimerUpdateViewSize.Start();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Región seleccionada cambiada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_SelectionRegionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ImagenActual is OImagenBitmap)
                {
                    this.TimerUpdateSelecction.Start();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Scroll cambiado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (this.ImagenActual is OImagenBitmap)
                {
                    this.CurrentScrollPosition = this.VisorImagenes.AutoScrollPosition;
                    this.TimerUpdateAutoScrollPosition.Start();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Visor cambia de tamaño
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_Resize(object sender, EventArgs e)
        {
            try
            {
                if ((this.ImagenActual is OImagenBitmap) && ((this.Size.Width != this.PreviousSize.Width) || (this.Size.Height != this.PreviousSize.Height)))
                {
                    this.TimerUpdateZoomLevel.Start();
                    this.TimerUpdateViewSize.Start();
                    this.CurrentScrollPosition = this.VisorImagenes.AutoScrollPosition;
                    this.TimerUpdateAutoScrollPosition.Start();
                    this.ZoomFit();
                }

                this.PreviousSize = this.Size;
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Ratón movido en el visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.ImagenActual is OImagenBitmap)
                {
                    this._CurrentCursorPosition = this.VisorImagenes.GetCurrentPosition(e.Location);
                    this.TimerUpdateCursorPosition.Start();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Click en el visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.ImagenActual is OImagenBitmap)
                {
                    this.OnMouseClick(e);
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Ratón sale del visor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorImagenes_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (this.ImagenActual is OImagenBitmap)
                {
                    this._CurrentCursorPosition = PointF.Empty;
                    this.TimerUpdateCursorPosition.Start();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Timer encargado de refrescar la posición del scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateAutoScrollPosition_Tick(object sender, EventArgs e)
        {
            try
            {
                this.UpdateAutoScrollPosition(this.CurrentScrollPosition);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
            this.TimerUpdateAutoScrollPosition.Stop();
        }

        /// <summary>
        /// Timer encargado de refrescar la posición del cursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateCursorPosition_Tick(object sender, EventArgs e)
        {
            try
            {
                this.UpdateCursorPosition(this._CurrentCursorPosition);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
            this.TimerUpdateCursorPosition.Stop();
        }

        /// <summary>
        /// Timer encaragdo de refrescar el nivel de zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateZoomLevel_Tick(object sender, EventArgs e)
        {
            try
            {
                this.UpdateZoomLevel(this.VisorImagenes.Zoom);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
            this.TimerUpdateZoomLevel.Stop();
        }

        /// <summary>
        /// Timer encargado de refrescar la información sobre el tamaño de la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateViewSize_Tick(object sender, EventArgs e)
        {
            try
            {
                this.UpdateViewArea(this.VisorImagenes.GetImageViewPort());
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
            this.TimerUpdateViewSize.Stop();
        }

        /// <summary>
        /// Timer encargado de refrescar la información sobre la selección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateSelecction_Tick(object sender, EventArgs e)
        {
            try
            {
                this.UpdateSelectedRegion(this.VisorImagenes.SelectionRegion);
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
            this.TimerUpdateSelecction.Stop();
        }

        /// <summary>
        /// Timer encargado de refrescar la información sobre la selección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateFps_Tick(object sender, EventArgs e)
        {
            try
            {
                this.UpdateFps();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
            this.TimerUpdateFps.Stop();
        }
        #endregion

        #region Evento(s) heredado(es)
        /// <summary>
        /// Delegado de cambio de estaco de conexión de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        public override void OnCambioEstadoConexionCamara(object sender, CambioEstadoConexionCamaraEventArgs e)
        {
            base.OnCambioEstadoConexionCamara(sender, e);

            try
            {
                switch (e.EstadoConexionActual)
                {
                    case EstadoConexion.Desconectado:
                    case EstadoConexion.ErrorConexion:
                    default:
                        this.btnPlayStop.Enabled = false;
                        this.btnSnap.Enabled = false;
                        break;
                    case EstadoConexion.Conectado:
                        this.btnPlayStop.Enabled = true;
                        this.btnSnap.Enabled = true;
                        break;
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }
        #endregion
    }
}