using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
namespace Orbita.Controles.VA
{
    public partial class OrbitaControlVideo : UserControl
    {
        #region Campos
        private bool _cerrarZoomVideo = true;
        /// <summary>
        /// Contendra el video a visualizar
        /// </summary>
        private Video VideoActual = null;
        /// <summary>
        /// Timer para controlar el tiempo de reproducción y la barra de progreso.
        /// </summary>
        private Timer timer = new Timer();
        /// <summary>
        /// TimeSpan para obtener los minutos y segundos durante la reproducción;
        /// </summary>
        private TimeSpan tiempoReproduccion;
        /// <summary>
        /// TimeSpan para obtener los minutos y segundos de la duración completa del video.
        /// </summary>
        private TimeSpan tiempoVideo;
        /// <summary>
        /// Flag para saber si es la primera reproducción, si está a true generaremos los eventos del video.
        /// </summary>
        bool primeraReproduccion = true;
        /// <summary>
        /// 
        /// </summary>
        string ruta = "";
        bool bEstadoAnteriorPausado = false;
        private string _rutaVideo;
        private string _nombreVideo;
        private bool _panelGrande = true;
        private bool _mantenerRelacionAspecto = true;
        private bool _reproduccionEnBucle = false;
        private bool _zoomVideo = true;
        #endregion

        #region Propiedades

        public string RutaVideo
        {
            get { return _rutaVideo; }
            set { _rutaVideo = value; }
        }

        /// <summary>
        /// Propiedad para añadir título al video.
        /// </summary>
        [DefaultValue("Nombre del video")]
        public string NombreVideo
        {
            get { return _nombreVideo; }
            set { _nombreVideo = value; }
        }

        /// <summary>
        /// Propiedad para mostrar el panel con los botones grandes. True para mostrarlo.
        /// </summary>
        [DefaultValue(true)]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool PanelGrande
        {
            get { return _panelGrande; }
            set
            {
                _panelGrande = value;
                this.pnlInferior24.Visible = _panelGrande;
                this.pnlInferior16.Visible = !_panelGrande;
            }
        }

        /// <summary>
        /// Propiedad para mantener la relación aspecto. True para mantener la relación aspecto.
        /// </summary>
        [DefaultValue(true)]
        public bool MantenerRelacionAspecto
        {
            get { return _mantenerRelacionAspecto; }
            set { this._mantenerRelacionAspecto = value; }
        }

        /// <summary>
        /// Propiedad para poner el video en bucle. True para activar estado en bucle.
        /// </summary>
        [DefaultValue(false)]
        public bool ReproduccionEnBucle
        {
            get { return _reproduccionEnBucle; }
            set { this._reproduccionEnBucle = value; }
        }

        /// <summary>
        /// Propiedad para mostrar el zoom del video. True para mostrarlo.
        /// </summary>
        [DefaultValue(true)]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool ZoomVideo
        {
            get { return _zoomVideo; }
            set
            {
                _zoomVideo = value;
                this.pctZoomVideo.Visible = _zoomVideo;
            }
        }

        /// <summary>
        /// Propiedad para mostrar cerrar el zoom del video. True para mostrarlo.
        /// </summary>
        [DefaultValue(true)]
        [RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool CerrarZoomVideo
        {
            get { return _cerrarZoomVideo; }
            set
            {
                _cerrarZoomVideo = value;
                this.pctCerrarZoomVideo.Visible = _cerrarZoomVideo;
            }
        }

        #endregion

        #region Delegados
        /// <summary>
        /// Generamos el evento del video que nos indicará que ha finalizado
        /// </summary>
        public delegate void VideoFinHandler(Object sender, EventArgs e);
        public delegate void ZommCerrarHandler(Object sender, EventArgs e);
        public delegate void ZommHandler(Object sender, EventArgs e);
        #endregion

        #region Manejadores de Eventos

        /// <summary>
        /// Generamos el evento del video que nos indicará que ha finalizado
        /// </summary>
        public event VideoFinHandler VideoFinEventHandler;
        public event ZommCerrarHandler OnCerrarZoom;
        public event ZommHandler OnZoom;
        #endregion

        #region Constructores

        public OrbitaControlVideo()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        #region Botones de control

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Start();
                //FileInfo fichero = new FileInfo(this.RutaVideo);
                if (System.IO.File.Exists(this.RutaVideo))
                {
                    this.ActivarBotonesEnPlay();
                    //Se comprueba la propiedad "Nombre de Video", en caso de no estar
                    //mostramos "Video sin nombre".
                    if (_nombreVideo != "")
                    {
                        this.lblNombreVideo.Text = _nombreVideo;
                    }
                    else
                    {
                        this.lblNombreVideo.Text = "Video sin nombre";
                    }

                    //Comparamos la ruta anterior con la ruta actual. De esta forma podemos reproducir
                    //varios video sin necesidad de "recargar" el control de nuevo.
                    if (ruta != this.RutaVideo)
                    {
                        ruta = this.RutaVideo;

                        // Detenemos el timer para que no falle.
                        // Limpiamos el video anterior y creamos el nuevo
                        timer.Enabled = false;
                        if (this.VideoActual != null)
                        {
                            this.VideoActual.Dispose();
                            this.VideoActual = null;
                        }
                        // Creamos el nuevo video (comrpbar si se libera la memoria)
                        this.VideoActual = new Video(this.RutaVideo);

                        //Comprobamos si es la primera reproducción para inicializar los eventos del video
                        //Starting, Pausing y Ending.
                        if (primeraReproduccion)
                        {
                            InicializaEventos();
                            primeraReproduccion = false;
                        }

                        this.pnlVideo.Dock = DockStyle.Fill;

                        // Asignamos al control correspondiente          
                        this.VideoActual.Owner = this.pnlVideo;

                        // Redimensiona el video al tamaño del control
                        Redimensionar();

                        //// Asignamos al control correspondiente          
                        //this.VideoActual.Owner = this.pnlVideo;
                        this.lblResolucion.Text = this.VideoActual.DefaultSize.Width.ToString() + "x" + this.VideoActual.DefaultSize.Height.ToString();
                        this.trckBarraProgreso.Maximum = (int)(this.VideoActual.Duration * (1 / this.VideoActual.AverageTimePerFrame) + 1);
                        this.ConfigurarTimerDeEjecucion();
                    }
                    else
                    {
                        if (this.trckBarraProgreso.Value == this.trckBarraProgreso.Maximum)
                        {
                            //this.ActivarBotonesEnStop();
                            if (this.VideoActual != null && !this.VideoActual.Stopped) this.VideoActual.Stop();
                            ActualizaLabels(false);
                        }
                    }
                    // Iniciamos el timer
                    timer.Start();
                    // Lo ponemos en play
                    this.VideoActual.Play();

                }
            }
            catch (Exception)
            {
                //Core.Logger.Error(ex.ToString());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActivarBotonesEnFin();
                if (this.VideoActual != null && !this.VideoActual.Stopped) this.VideoActual.Stop();
                ActualizaLabels(false);
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en btnStop_Click, OVideo", ex);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActivarBotonesEnStop();
                if (this.VideoActual != null && !this.VideoActual.Paused) this.VideoActual.Pause();
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en btnPause_Click, OVideo", ex);
            }
        }

        private void btnStepUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VideoActual != null)
                {
                    this.VideoActual.Pause();
                    double dd = this.VideoActual.CurrentPosition;
                    if (dd < this.VideoActual.Duration) this.VideoActual.CurrentPosition += this.VideoActual.AverageTimePerFrame;
                    this.ActualizaLabels(false);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en btnStepUp_Click, OVideo", ex);
            }
        }

        private void btnStepDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VideoActual != null)
                {
                    this.VideoActual.Pause();
                    double dd = this.VideoActual.CurrentPosition;
                    if (dd > 0) this.VideoActual.CurrentPosition -= this.VideoActual.AverageTimePerFrame;
                    this.ActualizaLabels(false);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en btnStepDown_Click, OVideo", ex);
            }
        }

        private void btnIrInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VideoActual != null)
                {

                    this.VideoActual.CurrentPosition = 0;
                    this.trckBarraProgreso.Value = this.trckBarraProgreso.Minimum;

                    ActualizaLabels(false);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en btnIrInicio_Click, OVideo", ex);
            }
        }

        private void btnIrFinal_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VideoActual != null)
                {
                    this.VideoActual.CurrentPosition = this.VideoActual.Duration;
                    this.trckBarraProgreso.Scroll -= new System.EventHandler(this.trckBarraProgreso_Scroll);
                    this.trckBarraProgreso.Value = this.trckBarraProgreso.Maximum;
                    ActualizaLabels(true);
                    this.trckBarraProgreso.Scroll += new System.EventHandler(this.trckBarraProgreso_Scroll);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en btnIrFinal_Click, OVideo", ex);
            }
        }

        #endregion

        #region Eventos de video
        private void VideoActual_Pausing(object sender, EventArgs e)
        {
            try
            {
                this.ActivarBotonesEnStop();
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en VideoActual_Pausing, OVideo", ex);
            }
        }

        private void VideoActual_Ending(object sender, EventArgs e)
        {
            try
            {
                //Colocamos el marcador del estado de la barra de progreso al final de la barra.
                this.trckBarraProgreso.Value = this.trckBarraProgreso.Maximum;
                if (_reproduccionEnBucle && !this.VideoActual.Paused)
                {
                    this.VideoActual.Stop();
                    this.VideoActual.Play();
                }
                else
                {
                    this.ActivarBotonesEnFin();
                    timer.Stop();
                }

                if (VideoFinEventHandler != null)
                {
                    this.VideoFinEventHandler(this, new EventArgs());
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en VideoActual_Ending, OVideo", ex);
            }
        }

        private void VideoActual_Starting(object sender, EventArgs e)
        {
            try
            {
                this.ActivarBotonesEnPlay();
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en VideoActual_Starting, OVideo", ex);
            }
        }

        #endregion

        #region Eventos de la barra de progreso

        private void trckBarraProgreso_Scroll(object sender, EventArgs e)
        {
            try
            {
                this.VideoActual.CurrentPosition = (double)this.trckBarraProgreso.Value * this.VideoActual.AverageTimePerFrame;
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en trckBarraProgreso_Scroll, OVideo", ex);
            }
        }

        private void trckBarraProgreso_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                bEstadoAnteriorPausado = this.VideoActual.Paused;
                this.VideoActual.Pause();
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en trckBarraProgreso_MouseDown, OVideo", ex);
            }
        }

        private void trckBarraProgreso_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (!bEstadoAnteriorPausado) this.VideoActual.Play();
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en trckBarraProgreso_MouseUp, OVideo", ex);
            }
        }

        #endregion

        #region Timer

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                ActualizaLabels(false);
                //Comprobamos si el tiempo de reproducción y la duración del video son iguales
                //si son iguales lanzamos el evento Ending, de esta manera nos aseguramos que el evento
                //Ending se active siempre, ya que por redondeo no siempre se consigue.
                if (tiempoReproduccion == tiempoVideo)
                {
                    this.VideoActual_Ending(this, new EventArgs());
                }
            }
            catch (Exception)
            {
                timer.Stop();
                //Core.Logger.Error("Error en timer_Tick, OVideo", ex);
            }
        }

        #endregion

        #region Redimensionado

        private void OVideo_Resize(object sender, EventArgs e)
        {
            try
            {
                // Redimensiona el video al tamaño del control
                Redimensionar();
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en OVideo_Resize, OVideo", ex);
            }
        }
        #endregion

        #region Zoom
        private void pctZoomVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnZoom != null)
                {
                    this.OnZoom(this, e);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en pctZoomVideo, OVideo", ex);
            }
        }

        private void pctCerrarZoomVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnCerrarZoom != null)
                {
                    this.OnCerrarZoom(this, e);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en pctCerrarZoomVideo, OVideo", ex);
            }
        }
        #endregion

        /// <summary>
        /// Dispose para liberar cada unos de los componentes del control, entre ellos el video.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                timer.Stop();

                // Cuando se cierra el control libero la memoria del Video
                if (this.VideoActual != null)
                {
                    this.VideoActual.Stop();
                    this.VideoActual.Dispose();
                    this.VideoActual = null;
                }

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en Dispose, OVideo", ex);
            }
        }
        /// <summary>
        /// Dispose para liberar  el video.
        /// </summary>
        /// <param name="disposing"></param>
        public void DisposeVideo()
        {
            try
            {
                timer.Stop();

                // Cuando se cierra el control libero la memoria del Video

                if (this.VideoActual != null)
                {
                    this.VideoActual.Stop();
                    this.VideoActual.Dispose();
                    this.VideoActual = null;
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error("Error en DisposeVideo, OVideo", ex);
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializamos los eventos de Starting, Ending y Pausing;
        /// </summary>
        private void InicializaEventos()
        {
            this.VideoActual.Starting += new System.EventHandler(VideoActual_Starting);
            this.VideoActual.Ending += new System.EventHandler(VideoActual_Ending);
            this.VideoActual.Pausing += new System.EventHandler(VideoActual_Pausing);
        }
        /// <summary>
        /// Configuración del timer.
        /// </summary>
        private void ConfigurarTimerDeEjecucion()
        {
            timer.Tick += new EventHandler(timer_Tick);
            // Tiempo en el que se ejecutará el timer
            timer.Interval = 250;
            //Habilitamos e iniciamos el timer;
            timer.Enabled = true;
        }
        /// <summary>
        /// Escalamos y ajustamos el video para mantener relación aspecto.
        /// </summary>
        /// <param name="target">Tamaño del contenedor donde queremos adaptar el video</param>
        /// <param name="original">Tamaño del video a escalar</param>
        /// <returns>El tamaño ajustado al panel</returns>
        private static Size scaleToFit(Size target, Size original)
        {
            if (target.Height * original.Width > target.Width * original.Height)
                target.Height = target.Width * original.Height / original.Width;
            else
                target.Width = target.Height * original.Width / original.Height;

            return target;
        }
        /// <summary>
        /// Escalado y ajuste inteligente.
        /// </summary>
        /// <param name="target">Tamaño del contenedor donde queremos adaptar el video</param>
        /// <param name="original">Tamaño del video a escalar</param>
        /// <returns>El tamaño ajustado al contenedor. En caso de que el escalado y el ajuste 
        /// sean mayores que el original devolvemos el original.</returns>
        private static Size scaleToFitSmart(Size target, Size original)
        {
            target = scaleToFit(target, original);

            if (target.Width > original.Width || target.Height > original.Height)
                return original;

            return target;
        }
        /// <summary>
        /// Activamos el botó de "Pause" y desactivamos el botón de "Play"
        /// </summary>
        private void ActivarBotonesEnPlay()
        {
            //Comprobamos si la propiedad PanelGrande está habilitada, para activar los botones
            //correspondientes.
            if (!this.PanelGrande)
            {
                this.btnPlay16.Enabled = false;
                this.btnPause16.Enabled = true;
                this.btnStop16.Enabled = true;
            }
            else
            {
                this.btnPlay24.Enabled = false;
                this.btnPause24.Enabled = true;
                this.btnStop24.Enabled = true;
            }
        }
        /// <summary>
        /// Desactivamos el botón pause y activamos el botón de "Play"
        /// </summary>
        private void ActivarBotonesEnStop()
        {
            //Comprobamos si la propiedad PanelGrande está habilitada, para activar los botones
            //correspondientes.
            if (!this.PanelGrande)
            {
                this.btnPlay16.Enabled = true;
                this.btnPause16.Enabled = false;
            }
            else
            {
                this.btnPlay24.Enabled = true;
                this.btnPause24.Enabled = false;
            }
        }
        /// <summary>
        /// Desactivamos los botones stop y pause y activamos el botón de "Play"
        /// </summary>
        private void ActivarBotonesEnFin()
        {
            //Comprobamos si la propiedad PanelGrande está habilitada, para activar los botones
            //correspondientes.
            if (!this.PanelGrande)
            {
                this.btnPlay16.Enabled = true;
                this.btnPause16.Enabled = false;
                this.btnStop16.Enabled = false;
            }
            else
            {
                this.btnPlay24.Enabled = true;
                this.btnPause24.Enabled = false;
                this.btnStop24.Enabled = false;
            }
        }
        /// <summary>
        /// Redimensionamos el video según la propiedad "MantenerRelacionAspecto".
        /// </summary>
        private void Redimensionar()
        {
            if (VideoActual != null)
            {
                Suspender(this, true);
                this.pnlVideo.Dock = DockStyle.None;
                //Si la relación aspecto está activada, redimensionamos el video.
                if (MantenerRelacionAspecto)
                {

                    this.pnlRedimension.Size = scaleToFitSmart(this.pnlContenedorVideo.Size, this.VideoActual.DefaultSize);
                    this.pnlRedimension.Location = new Point((this.pnlContenedorVideo.Width - this.pnlRedimension.Width) / 2, (this.pnlContenedorVideo.Height - this.pnlRedimension.Height) / 2);
                    this.pnlVideo.Dock = DockStyle.Fill;
                }
                else
                {
                    this.pnlVideo.Dock = DockStyle.Fill;
                    this.pnlRedimension.Dock = DockStyle.Fill;
                }
                Suspender(this, false);
            }
        }
        /// <summary>
        /// Suspendemos cada uno de los componentes del control.
        /// </summary>
        /// <param name="controlSuspender"></param>
        /// <param name="suspender"></param>
        private void Suspender(Control controlSuspender, bool suspender)
        {
            if (suspender)
            {
                controlSuspender.SuspendLayout();
            }
            else
            {
                controlSuspender.ResumeLayout();
            }
            foreach (Control controlHijo in controlSuspender.Controls)
            {
                this.Suspender(controlHijo, suspender);
            }
        }
        /// <summary>
        /// Actualizamos la barra de progreso, el título, la etiqueta de dimensiones y los temporizadores.
        /// </summary>
        /// <param name="final"></param>
        private void ActualizaLabels(bool final)
        {
            if (this.VideoActual != null)
            {
                if (final)
                {
                    this.trckBarraProgreso.Value = this.trckBarraProgreso.Maximum;
                }
                else
                {
                    this.trckBarraProgreso.Value = (int)(this.VideoActual.CurrentPosition * (1 / this.VideoActual.AverageTimePerFrame));
                }

                //Convertimos la duración del video y la posición actual del video en segundos para
                //mostrar el tiempo total del video y el tiempo transcurrido durante la reproducción.
                tiempoReproduccion = TimeSpan.FromSeconds(this.VideoActual.CurrentPosition);
                tiempoVideo = TimeSpan.FromSeconds(this.VideoActual.Duration);
                this.lblDuracion.Text = string.Format("{0:D2}:{1:D2} / {2:D2}:{3:D2}",
                                                    tiempoReproduccion.Minutes,
                                                    tiempoReproduccion.Seconds,
                                                    tiempoVideo.Minutes,
                                                    tiempoVideo.Seconds);
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Inicializamos el video llamando a play
        /// </summary>
        public void InicializarVideo()
        {
            // Debemos liberar la memoria del que tenia cargado antes...
            if (ruta != this.RutaVideo && this.VideoActual != null)
            {
                this.VideoActual.Dispose();
                this.VideoActual = null;
            }
            this.btnPlay_Click(this, null);
        }
        #endregion
    }
}