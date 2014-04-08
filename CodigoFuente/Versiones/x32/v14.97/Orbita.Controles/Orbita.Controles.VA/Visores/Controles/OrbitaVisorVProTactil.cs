//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 11-12-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using Cognex.VisionPro;
using System.Windows.Forms;
using System.ComponentModel;
using Orbita.VA.Comun;
using Orbita.VA.Hardware;
using System.Drawing;
using Cognex.VisionPro.Display;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Display de Vision Pro
    /// </summary>
    public partial class OrbitaVisorVProTactil : OrbitaVisorBase
    {
        #region Atributo(s)
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
        #endregion

        #region Propiedad(es) heredada(s)
        /// <summary>
        /// Propieadad a heredar donde se accede a la imagen
        /// </summary>
        public override OImagen ImagenActual
        {
            get { return (OImagenVisionPro)this._ImagenActual; }
            set
            {
                if (value is OImagenVisionPro)
                {
                    this._ImagenActual = value;
                }
                else if (value is OImagen)
                {
                    OImagenVisionPro valueConverted;
                    if (value.Convert<OImagenVisionPro>(out valueConverted))
                    {
                        this._ImagenActual = valueConverted;
                    }
                }
            }
        }

        /// <summary>
        /// Propiedad a heredar donde se accede al gráfico
        /// </summary>
        public new OVisionProGrafico GraficoActual
        {
            get { return (OVisionProGrafico)this._GraficoActual; }
            set { this._GraficoActual = value; }
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
                this.PnlStatusBottom.Visible = value;
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
        public OrbitaVisorVProTactil()
            : base()
        {
            InitializeComponent();

            this._CurrentCursorPosition = new PointF();
            this.PreviousSize = this.Size;


            // Se asigna el statusbar y el toolbar
            this.DisplayStatusBar.Display = Display;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="titulo">Titulo a visualizar en el display</param>
        public OrbitaVisorVProTactil(string titulo, string codCamara, double maxFrameIntervalVisualizacion, bool asociarCamara, bool visualizarEnVivo) :
            base(titulo, codCamara, maxFrameIntervalVisualizacion, asociarCamara, visualizarEnVivo)
        {
            InitializeComponent();

            // Título del display
            this.lblTituloDisplay.Text = titulo;

            this._CurrentCursorPosition = new PointF();
            this.PreviousSize = this.Size;

            // Se asigna el statusbar y el toolbar
            this.DisplayStatusBar.Display = Display;
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
        private string FormatSize(Size rect)
        {
            return string.Format("W:{0:0.00}, H:{1:0.00}", (int)rect.Width, (int)rect.Height);
        }

        /// <summary>
        /// Visualiza el tamaño de la imagen
        /// </summary>
        /// <param name="scrollPosition"></param>
        private void UpdateViewArea(Size imageSize)
        {
            this.lblViewArea.Text = imageSize != Size.Empty ? this.FormatSize(imageSize) : string.Empty;
        }
        /// <summary>
        /// Visualiza la selección actual
        /// </summary>
        private void UpdateFps()
        {
            this.lblFps.Text = "fps: " + this.CurrentFps.ToString("#0.0");
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Aumentamos el zoom de la imagen
        /// </summary>
        public void ZoomIn()
        {
            this.Display.Zoom *= 2;
        }
        /// <summary>
        /// Disminuimos el zoom de la imagen
        /// </summary>
        public void ZoomOut()
        {
            this.Display.Zoom /= 2;
        }

        /// <summary>
        /// Inicia la visualización en vivo
        /// </summary>
        public void StartLiveDisplay(object acqFifo, bool own)
        {
            this.Display.StartLiveDisplay(acqFifo, own);
        }
        /// <summary>
        /// Detiene la visualización en vivo
        /// </summary>
        public void StopLiveDisplay()
        {
            this.Display.StopLiveDisplay();
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

            this.ImagenActual = new OImagenVisionPro();
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

            if (this.ImagenActual is OImagenVisionPro)
            {
                resultado = this.ImagenActual.Guardar(ruta);
            }

            return resultado;
        }

        /// <summary>
        /// Carga un grafico de disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se encuentra el grafico</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool CargarGraficoDeDisco(string ruta)
        {
            bool resultado = false;

            if (this.GraficoActual != null)
            {
                this.GraficoActual.Dispose();
                this.GraficoActual = null;
            }

            this.GraficoActual = new OVisionProGrafico();
            resultado = this.GraficoActual.Cargar(ruta);

            //this.VisualizarImagen(this.ImagenActual, this.GraficoActual);

            return resultado;
        }

        /// <summary>
        /// Guarda un objeto gráfico en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar el objeto gráfico</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool GuardarGraficoADisco(string ruta)
        {
            bool resultado = false;

            if (this.GraficoActual is OVisionProGrafico)
            {
                resultado = this.GraficoActual.Guardar(ruta);
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve una nueva imagen del tipo adecuado al trabajo con el display
        /// </summary>
        /// <returns>Imagen del tipo adecuado al trabajo con el display</returns>
        public override OImagen NuevaImagen()
        {
            return new OImagenVisionPro();
        }

        /// <summary>
        /// Devuelve un nuevo gráfico del tipo adecuado al trabajo con el display
        /// </summary>
        /// <returns>Grafico del tipo adecuado al trabajo con el display</returns>
        public override OGrafico NuevoGrafico()
        {
            return new OVisionProGrafico();
        }

        /// <summary>
        /// Visualiza una imagen en el display
        /// </summary>
        /// <param name="imagen">Imagen a visualizar</param>
        /// <param name="graficos">Objeto que contiene los gráficos a visualizar (letras, rectas, circulos, etc)</param>
        protected override void VisualizarInterno()
        {
            base.VisualizarInterno();

            // Se carga la imagen y los gráficos siguiendo las recomendaciones de cognex para optimizar el rendimiento
            if (this.ImagenActual is OImagenVisionPro)
            {
                // Disable display updates 
                this.Display.DrawingEnabled = false;

                // Remove all graphics from the display
                this.Display.StaticGraphics.Clear();

                // Update the display with the new image
                bool debeAjustar = (this.Display.Image == null);
                if (!debeAjustar)
                {
                    if ((this.ImagenActual is OImagenVisionPro) && (((OImagenVisionPro)this.ImagenActual).Image != null))
                    {
                        debeAjustar |= this.Display.Image.Width != ((OImagenVisionPro)this.ImagenActual).Image.Width;
                        debeAjustar |= this.Display.Image.Height != ((OImagenVisionPro)this.ImagenActual).Image.Height;
                    }
                }

                this.Display.Image = ((OImagenVisionPro)this.ImagenActual).Image;
                if (debeAjustar)
                {
                    // Fit the image to the display 
                    this.ZoomFit();
                }

                if (this.GraficoActual is OVisionProGrafico)
                {
                    OVisionProGrafico OVisionProGrafico = (OVisionProGrafico)this.GraficoActual;
                    if (OVisionProGrafico.Grafico is CogGraphicCollection)
                    {
                        this.Display.StaticGraphics.AddList(OVisionProGrafico.Grafico, "features");
                    }
                }

                // Enable display updates 
                this.Display.DrawingEnabled = true;
            }
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        public override void ZoomFit()
        {
            this.Display.Fit(false);
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        public override void ZoomFull()
        {
            this.Display.Zoom = 1;
        }

        /// <summary>
        /// Se aplica un factor de escalado
        /// </summary>
        public override void ZoomValue(double value)
        {
            this.Display.Zoom = value;
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
        
        /// <summary>
        /// Obtiene el manejador del display para que las librerías de visión puedan acceder directamente a él
        /// </summary>
        /// <returns></returns>
        public override object ObtenerManejador()
        {
            return this.Display;
        }   
        #endregion

        #region Eventos
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
        /// Botón de Puntero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPointer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Display.MouseMode = CogDisplayMouseModeConstants.Pointer;
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Botón de Mano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHand_Click(object sender, EventArgs e)
        {
            try
            {
                this.Display.MouseMode = CogDisplayMouseModeConstants.Pan;
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
                if ((this.ImagenActual is OImagenVisionPro) && ((this.Size.Width != this.PreviousSize.Width) || (this.Size.Height != this.PreviousSize.Height)))
                {
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
        /// Timer encargado de refrescar la información sobre el tamaño de la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdateViewSize_Tick(object sender, EventArgs e)
        {
            try
            { 
                if ((this.ImagenActual is OImagenVisionPro) && ((this.Size.Width != this.PreviousSize.Width) || (this.Size.Height != this.PreviousSize.Height)))
                {
                    this.UpdateViewArea(new Size(this.Display.Image.Width, this.Display.Image.Height));
                }
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