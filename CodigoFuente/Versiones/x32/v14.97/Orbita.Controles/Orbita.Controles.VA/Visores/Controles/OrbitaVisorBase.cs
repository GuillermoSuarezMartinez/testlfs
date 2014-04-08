//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Se muestra información sobre los nuevos estado de conexión
//                    Conectando, Desconectando y Reconectando
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Movido al proyecto Orbita.Controles.VA
//
// Last Modified By : aibañez
// Last Modified On : 29/10/2012
// Description      : Cambiado a ensamblado de VAComun
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Orbita.Controles.Shared;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.VA.Hardware;
using System.Drawing;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Control base para todos los tipos de displays
    /// </summary>
    public partial class OrbitaVisorBase : UserControl
    {
        #region Atributos
        /// <summary>
        /// Estado de visualización del control (maximizado o normal)
        /// </summary>
        protected FormWindowState EstadoVentana;

        /// <summary>
        /// Indica que se trata de la primera foto después de la conexión de la cámara;
        /// </summary>
        protected bool PrimeraFoto;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica si la velocidad de visualización de imagenes está limitada y por lo tanto se ha de visualizar de forma retrasada con un timer
        /// </summary>
        protected bool _FrameRateVisualizacionLimitado = false;
        /// <summary>
        /// Indica si la velocidad de visualización de imagenes está limitada y por lo tanto se ha de visualizar de forma retrasada con un timer
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si la velocidad de visualización de imagenes está limitada y por lo tanto se ha de visualizar de forma retrasada con un timer"),
        DefaultValue(false)]
        public bool FrameRateVisualizacionLimitado
        {
            get { return _FrameRateVisualizacionLimitado; }
            set { _FrameRateVisualizacionLimitado = value; }
        }

        /// <summary>
        /// Velocidad máxima de visualización en milisegundos
        /// </summary>
        protected double _MaxFrameIntervalVisualizacion = 0.0;
        /// <summary>
        /// Velocidad máxima de visualización en milisegundos
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Velocidad máxima de visualización en milisegundos"),
        DefaultValue(0.0)]
        public double MaxFrameIntervalVisualizacion
        {
            get 
            {
                return _MaxFrameIntervalVisualizacion; 
            }
            set 
            { 
                _MaxFrameIntervalVisualizacion = value;
                if (this.TimerRetrasoVisualizacionUltimaImagen is Timer)
                {
                    this.TimerRetrasoVisualizacionUltimaImagen.Interval = OEntero.Validar((int)Math.Truncate(_MaxFrameIntervalVisualizacion), 1, 1000000, 100);
                }
            }
        }        
        
        /// <summary>
        /// Cámara Asociada al Visor
        /// </summary>
        protected OCamaraBase _CamaraAsociada = null;
        /// <summary>
        /// Cámara Asociada al Visor
        /// </summary>
        [Browsable(false)]
        public OCamaraBase CamaraAsociada
        {
            get { return _CamaraAsociada; }
            set { _CamaraAsociada = value; }
        }

        /// <summary>
        /// Indica que se ha de visualizar en vivo la imagen de la cámara
        /// </summary>
        public bool _VisualizarEnVivo;
        /// <summary>
        /// Indica que se ha de visualizar en vivo la imagen de la cámara
        /// </summary>
        [Browsable(false)]
        public bool VisualizarEnVivo
        {
            get { return _VisualizarEnVivo; }
            set { _VisualizarEnVivo = value; }
        }

        /// <summary>
        /// Código identificativo del visor o de la cámara asociada al display
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo del visor o de la cámara asociada al display
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Código identificativo del visor o de la cámara asociada en el caso de que exista"),
        DefaultValue("")]
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Obtiene la posición actual del raton
        /// </summary>
        protected PointF _CurrentCursorPosition;
        /// <summary>
        /// Obtiene la posición actual del raton
        /// </summary>
        [Browsable(false)]
        public PointF CurrentCursorPosition
        {
            get { return _CurrentCursorPosition; }
        }

        /// <summary>
        /// Imagen de la cámara conectada
        /// </summary>
        private Bitmap _ImagenCamaraConectada = global::Orbita.Controles.VA.Properties.Resources.CamaraConectada;
        /// <summary>
        /// Imagen de la cámara conectada
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Imagen a mostrar cuando la cámara está conectada")]
        public Bitmap ImagenCamaraConectada
        {
            get { return _ImagenCamaraConectada; }
            set { _ImagenCamaraConectada = value; }
        }

        /// <summary>
        /// Imagen de la cámara desconectada
        /// </summary>
        private Bitmap _ImagenCamaraDesConectada = global::Orbita.Controles.VA.Properties.Resources.CamaraDesConectada;
        /// <summary>
        /// Imagen de la cámara desconectada
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Imagen a mostrar cuando la cámara está desconectada")]
        public Bitmap ImagenCamaraDesConectada
        {
            get { return _ImagenCamaraDesConectada; }
            set { _ImagenCamaraDesConectada = value; }
        }
        #endregion

        #region Propiedad(es) Virtuales
        /// <summary>
        /// Muestra la barra superior de botones
        /// </summary>
        protected bool _MostrarToolStrip;
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la barra superior de botones")]
        public virtual bool MostrarToolStrip
        {
            get { return _MostrarToolStrip; }
            set { _MostrarToolStrip = value; }
        }

        /// <summary>
        /// Muestra la barra inferior de estado
        /// </summary>
        protected bool _MostrarStatusBar;
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la barra inferior de estado")]
        public virtual bool MostrarStatusBar
        {
            get { return _MostrarStatusBar; }
            set { _MostrarStatusBar = value; }
        }

        /// <summary>
        /// Muestra el botón de abrir fotografía
        /// </summary>
        protected bool _MostrarBtnAbrir;
        /// <summary>
        /// Muestra el botón de abrir fotografía
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de cargar imagen")]
        public virtual bool MostrarBtnAbrir
        {
            get { return _MostrarBtnAbrir; }
            set
            {
                this._MostrarBtnAbrir = value;
            }
        }

        /// <summary>
        /// Muestra el botón de guardar fotografía
        /// </summary>
        protected bool _MostrarBtnGuardar;
        /// <summary>
        /// Muestra el botón de guardar fotografía
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de guardar imagen")]
        public virtual bool MostrarbtnGuardar
        {
            get { return _MostrarBtnGuardar; }
            set
            {
                this._MostrarBtnGuardar = value;
            }
        }

        /// <summary>
        /// Muestra el botón de play/stop
        /// </summary>
        protected bool _MostrarBtnReproduccion;
        /// <summary>
        /// Muestra el botón de play/stop
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de play/stop")]
        public virtual bool MostrarBtnReproduccion
        {
            get { return _MostrarBtnReproduccion; }
            set
            {
                this._MostrarBtnReproduccion = value;
            }
        }

        /// <summary>
        /// Muestra el botón de play/stop
        /// </summary>
        protected bool _MostrarBtnSnap;
        /// <summary>
        /// Muestra el botón de snap
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de snap")]
        public virtual bool MostrarBtnSnap
        {
            get { return _MostrarBtnSnap; }
            set
            {
                this._MostrarBtnSnap = value;
            }
        }

        /// <summary>
        /// Muestra la etiqueta del título
        /// </summary>
        protected bool _MostrarLblTitulo;
        /// <summary>
        /// Muestra la etiqueta del título
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar la etiqueta con el título del visor")]
        public virtual bool MostrarLblTitulo
        {
            get { return _MostrarLblTitulo; }
            set
            {
                this._MostrarLblTitulo = value;
            }
        }

        /// <summary>
        /// Muestra el botón de información del visor
        /// </summary>
        protected bool _MostrarBtnInfo;
        /// <summary>
        /// Muestra el botón de información del visor
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de información del visor")]
        public virtual bool MostrarBtnInfo
        {
            get { return _MostrarBtnInfo; }
            set
            {
                this._MostrarBtnInfo = value;
            }
        }

        /// <summary>
        /// Muestra el botón de maximizar/minimizar
        /// </summary>
        protected bool _MostrarBtnMaximinzar;
        /// <summary>
        /// Muestra el botón de maximizar/minimizar
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar el botón de maximizar/minimizar")]
        public virtual bool MostrarBtnMaximinzar
        {
            get { return _MostrarBtnMaximinzar; }
            set
            {
                this._MostrarBtnMaximinzar = value;
            }
        }

        /// <summary>
        /// Muestra los botones de siguiente/anterior dispositivo
        /// </summary>
        protected bool _MostrarBtnSiguienteAnterior;
        /// <summary>
        /// Muestra los botones de siguiente/anterior dispositivo
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar los botones de siguiente/anterior dispositivo")]
        public virtual bool MostrarBtnSiguienteAnterior
        {
            get { return _MostrarBtnSiguienteAnterior; }
            set
            {
                this._MostrarBtnSiguienteAnterior = value;
            }
        }

        /// <summary>
        /// Muestra el la información adicional de la imagen visualizada
        /// </summary>
        protected bool _MostrarStatusMensaje;
        /// <summary>
        /// Muestra el la información adicional de la imagen visualizada
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar información adicional sobre la imagen visualizada")]
        public virtual bool MostrarStatusMensaje
        {
            get { return _MostrarStatusMensaje; }
            set
            {
                this._MostrarStatusMensaje = value;
            }
        }

        /// <summary>
        /// Muestra el la información de la velocidad de adquisición de la cámara asociada
        /// </summary>
        protected bool _MostrarStatusFps;
        /// <summary>
        /// Muestra el la información de la velocidad de adquisición de la cámara asociada
        /// </summary>
        [Browsable(true),
        Category("Orbita"),
        Description("Indica si se ha de mostrar información de la velocidad de adquisición de la cámara asociada")]
        public virtual bool MostrarStatusFps
        {
            get { return _MostrarStatusFps; }
            set
            {
                this._MostrarStatusFps = value;
            }
        }

        /// <summary>
        /// Imagen actual visualizada
        /// </summary>
        protected OImagen _ImagenActual;
        /// <summary>
        /// Imagen actual visualizada
        /// </summary>
        [Browsable(false)]
        public virtual OImagen ImagenActual
        {
            get { return this._ImagenActual; }
            set { this._ImagenActual = value; }
        }

        /// <summary>
        /// Gráfico actual visualizado
        /// </summary>
        protected OGrafico _GraficoActual;
        /// <summary>
        /// Gráfico actual visualizado
        /// </summary>
        [Browsable(false)]
        public virtual OGrafico GraficoActual
        {
            get { return this._GraficoActual; }
            set { this._GraficoActual = value; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaVisorBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="titulo">Titulo a visualizar en el display</param>
        public OrbitaVisorBase(string titulo, string codCamara, double maxFrameIntervalVisualizacion, bool asociarCamara, bool visualizarEnVivo)
        {
            InitializeComponent();

            // Recogemos los parametros
            this.Codigo = codCamara;
            this.CamaraAsociada = asociarCamara ? OCamaraManager.GetCamara(this.Codigo) : null;
            this.VisualizarEnVivo = visualizarEnVivo && (this.CamaraAsociada is OCamaraBase);

            // Temas de visualización
            this.EstadoVentana = FormWindowState.Normal;

            // Creamos el timer de retraso de visualización
            this.FrameRateVisualizacionLimitado = maxFrameIntervalVisualizacion > 0;
            this._MaxFrameIntervalVisualizacion = maxFrameIntervalVisualizacion;
            this.TimerRetrasoVisualizacionUltimaImagen.Interval = OEntero.Validar((int)Math.Truncate(maxFrameIntervalVisualizacion), 1, 1000000, 100);
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Carga la imagen acutal mediante una ventana de diálogo
        /// </summary>
        protected void CargarImagenDialogo()
        {
            string rutaArchivo = ORutaParametrizable.AppFolder;
            bool archivoSeleccionadoOK = OTrabajoControles.FormularioSeleccionArchivo(this.openFileDialog, ref rutaArchivo);
            if (archivoSeleccionadoOK)
            {
                this.CargarImagenDeDisco(rutaArchivo);
            }
        }

        /// <summary>
        /// Guarda la imagen actual mediante una ventana de diálogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GuardarImagenDialogo()
        {
            string rutaArchivo = ORutaParametrizable.AppFolder;
            bool archivoSeleccionadoOK = OTrabajoControles.FormularioGuardarArchivo(this.saveFileDialog, ref rutaArchivo);
            if (archivoSeleccionadoOK)
            {
                this.GuardarImagenADisco(rutaArchivo);
            }
        }

        /// <summary>
        /// Muestra un formuario con información sobre el dispositivo origen de la imagen
        /// </summary>
        protected void MostrarInfoDispositivo()
        {
            if (this.OnInfoDemandada != null)
            {
                this.OnInfoDemandada(this, new EventVisorClickButtonArgs(this.Codigo));
            }
        }

        /// <summary>
        /// Lanza el evento de botón de play/stop pulsado
        /// </summary>
        protected void BotonPlayStopPulsado()
        {
            if (this.CamaraAsociada is OCamaraBase)
            {
                if (this.CamaraAsociada.EstadoConexion == EstadoConexion.Conectado)
                {
                    this.CamaraAsociada.Play = !this.CamaraAsociada.Play;
                }
            }
        }

        /// <summary>
        /// Lanza el evento de botón de play/stop pulsado
        /// </summary>
        protected void BotonSnapPulsado()
        {
            if (this.CamaraAsociada.EstadoConexion == EstadoConexion.Conectado)
            {
                this.CamaraAsociada.Snap();
            }
        }

        /// <summary>
        /// Método que lanza el evento de cambio de visor
        /// </summary>
        /// <param name="ordenCambioVisor"></param>
        protected void CambioVisor(EventDeviceViewerChangedArgs.DeviceViewerChangeOrder ordenCambioVisor)
        {
            if (this.OnVisorDispositivoCambiado != null)
            {
                this.OnVisorDispositivoCambiado(this, new EventDeviceViewerChangedArgs(this._Codigo, ordenCambioVisor));
            }
        }

        /// <summary>
        /// Evento que indica el clic en el visor (devolviendo la información de X e Y de la imagen)
        /// </summary>
        /// <param name="e">Información sobre la posición del cursor sobre la imagen</param>
        protected void OnImageMouseClick(EventImageMouseHandlerArgs e)
        {
            if (this.ImageMouseClick != null)
            {
                this.ImageMouseClick(this, e);
            }
        }

        /// <summary>
        /// Evento que indica el movimiento del cursor sobre el visor (devolviendo la información de X e Y de la imagen)
        /// </summary>
        /// <param name="e">Información sobre la posición del cursor sobre la imagen</param>
        protected void OnImageMouseMove(EventImageMouseHandlerArgs e)
        {
            if (this.ImageMouseMove != null)
            {
                this.ImageMouseMove(this, e);
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Visualiza una imagen en el display
        /// </summary>
        /// <param name="imagen">Imagen a visualizar</param>
        public void Visualizar(OImagen imagen)
        {
            this.ImagenActual = imagen;
            if (this.FrameRateVisualizacionLimitado)
            {
                this.TimerRetrasoVisualizacionUltimaImagen.Start();
            }
            else
            {
                this.VisualizarInterno();
            }
        }

        /// <summary>
        /// Visualiza una imagen en el display
        /// </summary>
        /// <param name="imagen">Imagen a visualizar</param>
        /// <param name="graficos">Objeto que contiene los gráficos a visualizar (letras, rectas, circulos, etc)</param>
        public void Visualizar(OImagen imagen, OGrafico graficos)
        {
            this.ImagenActual = imagen;
            this.GraficoActual = graficos;
            if (FrameRateVisualizacionLimitado)
            {
                this.TimerRetrasoVisualizacionUltimaImagen.Start();
            }
            else
            {
                this.VisualizarInterno();
            }
        }

        /// <summary>
        /// Visualiza una imagen en el display
        /// </summary>
        /// <param name="graficos">Objeto que contiene los gráficos a visualizar (letras, rectas, circulos, etc)</param>
        public void Visualizar(OGrafico graficos)
        {
            this.GraficoActual = graficos;
            if (FrameRateVisualizacionLimitado)
            {
                this.TimerRetrasoVisualizacionUltimaImagen.Start();
            }
            else
            {
                this.VisualizarInterno();
            }
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Carga los valores de la cámara
        /// </summary>
        public virtual void Inicializar()
        {
            //this.ImagenActual = new OImagen();
            //this.GraficoActual = new OGrafico();

            if (this.CamaraAsociada is OCamaraBase)
            {
                this.CamaraAsociada.OnMensaje += this.OnMensajeCamara;
                this.CamaraAsociada.OnCambioEstadoConexionCamaraSincrono += this.OnCambioEstadoConexionCamara;
                this.CamaraAsociada.OnCambioEstadoReproduccionCamaraSincrono += this.CambioModoReproduccionCamara;
                if (this.VisualizarEnVivo)
                {
                    this.CamaraAsociada.OnNuevaFotografiaCamaraSincrona += this.OnNuevaFotografiaCamara;
                }

                // Obtener las propiedades actuales de la cámara
                this.OnCambioEstadoConexionCamara(null, new CambioEstadoConexionCamaraEventArgs(this.CamaraAsociada.Codigo, this.CamaraAsociada.EstadoConexion, this.CamaraAsociada.EstadoConexion));
                this.CambioModoReproduccionCamara(null, new CambioEstadoReproduccionCamaraEventArgs(this.CamaraAsociada.Codigo, this.CamaraAsociada.Play));
            }
        }

        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public virtual void Finalizar()
        {
            if (this.CamaraAsociada is OCamaraBase)
            {
                this.CamaraAsociada.OnMensaje -= this.OnMensajeCamara;
                this.CamaraAsociada.OnCambioEstadoConexionCamaraSincrono -= this.OnCambioEstadoConexionCamara;
                this.CamaraAsociada.OnCambioEstadoReproduccionCamaraSincrono -= this.CambioModoReproduccionCamara;
                if (this.VisualizarEnVivo)
                {
                    this.CamaraAsociada.OnNuevaFotografiaCamaraSincrona -= this.OnNuevaFotografiaCamara;
                }
            }

            if (this.ImagenActual != null)
            {
                this.ImagenActual = null;
            }
            if (this.GraficoActual != null)
            {
                this.GraficoActual = null;
            }
        }

        /// <summary>
        /// Carga una imagen de disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se encuentra la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public virtual bool CargarImagenDeDisco(string ruta)
        {
            // Método implementado en las clases hijas
            return false;
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public virtual bool GuardarImagenADisco(string ruta)
        {
            // Método implementado en las clases hijas
            return false;
        }

        /// <summary>
        /// Carga un grafico de disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se encuentra el grafico</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public virtual bool CargarGraficoDeDisco(string ruta)
        {
            // Método implementado en las clases hijas
            return false;
        }

        /// <summary>
        /// Guarda un objeto gráfico en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar el objeto gráfico</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public virtual bool GuardarGraficoADisco(string ruta)
        {
            // Método implementado en las clases hijas
            return false;
        }

        /// <summary>
        /// Devuelve una nueva imagen del tipo adecuado al trabajo con el display
        /// </summary>
        /// <returns>Imagen del tipo adecuado al trabajo con el display</returns>
        public virtual OImagen NuevaImagen()
        {
            return null;
        }

        /// <summary>
        /// Devuelve un nuevo gráfico del tipo adecuado al trabajo con el display
        /// </summary>
        /// <returns>Grafico del tipo adecuado al trabajo con el display</returns>
        public virtual OGrafico NuevoGrafico()
        {
            return null;
        }

        /// <summary>
        /// Visualiza una imagen en el display
        /// </summary>
        /// <param name="imagen">Imagen a visualizar</param>
        protected virtual void VisualizarInterno()
        {
            // Método a implementar en heredados
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        public virtual void ZoomFit()
        {
            // Método a implementar en heredados
        }

        /// <summary>
        /// La imagen se encaja en pantalla
        /// </summary>
        public virtual void ZoomFull()
        {
            // Método a implementar en heredados
        }

        /// <summary>
        /// Se aplica un factor de escalado
        /// </summary>
        public virtual void ZoomValue(double value)
        {
            // Método a implementar en heredados
        }

        /// <summary>
        /// Muestra un mensaje de información sobre el dispositivo origen
        /// </summary>
        public virtual void MostrarMensaje(string mensaje)
        {
            // Método a implementar en heredados
        }

        /// <summary>
        /// Muestra la velocidad de adquisición de la cámara asociada
        /// </summary>
        public virtual void MostrarFps(double framePerSecond)
        {
            // Método a implementar en heredados
        }

        /// <summary>
        /// Maximizamos o restauramos la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void AccionMaximizarMinimizar(FormWindowState estadoVentana)
        {
            if (this.EstadoVentana != estadoVentana)
            {
                this.EstadoVentana = estadoVentana;

                if (this.OnEstadoVentanaCambiado != null)
                {
                    this.OnEstadoVentanaCambiado(this, new EventStateMaximizedArgs(this._Codigo, estadoVentana));
                }

                this.ZoomFit();
            }
        }

        /// <summary>
        /// Método que indica que la cámara ha cambiado su modo de reproducción
        /// </summary>
        /// <param name="modoReproduccionContinua"></param>
        protected virtual void CambioModoReproduccionCamara(object sender, CambioEstadoReproduccionCamaraEventArgs e)
        {
            // Implementado en heredados
        }

        /// <summary>
        /// Obtiene el manejador del display para que las librerías de visión puedan acceder directamente a él
        /// </summary>
        /// <returns></returns>
        public virtual object ObtenerManejador()
        {
            // Implementado en heredados
            return null;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento del timer de visualización de la última imágen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerVisualizacionUltimaImagen(object sender, EventArgs e)
        {
            try
            {
                this.TimerRetrasoVisualizacionUltimaImagen.Stop();
                this.VisualizarInterno();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Delegado de nueva fotografía
        /// </summary>
        /// <param name="OEstadoConexion"></param>
        public void OnNuevaFotografiaCamara(object sender, NuevaFotografiaCamaraEventArgs e)
        {
            try
            {
                this.Visualizar(e.Imagen);
                this.MostrarFps(e.VelocidadAdquisicion);
                if (!this.PrimeraFoto)
                {
                    this.PrimeraFoto = true;
                    this.ZoomFit();
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Muestra un mensaje de información sobre el dispositivo origen
        /// </summary>
        public void OnMensajeCamara(object sender, OMessageEventArgs e)
        {
            this.MostrarMensaje(e.Mensaje);
        }
        #endregion

        #region Evento(s) virtual(es)
        /// <summary>
        /// Delegado de cambio de estaco de conexión de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        public virtual void OnCambioEstadoConexionCamara(object sender, CambioEstadoConexionCamaraEventArgs e)
        {
            try
            {
                switch (e.EstadoConexionActual)
                {
                    case EstadoConexion.Desconectado:
                    default:
                        this.ImagenActual = this.NuevaImagen();
                        this.ImagenActual.ConvertFromBitmap(this.ImagenCamaraDesConectada);
                        this.Visualizar(this.ImagenActual);
                        this.ZoomFit();
                        this.MostrarMensaje("Desconectada");
                        break;
                    case EstadoConexion.Desconectando:
                        this.MostrarMensaje("En proceso de desconexión");
                        break;
                    case EstadoConexion.Conectado:
                        this.ImagenActual = this.NuevaImagen();
                        this.ImagenActual.ConvertFromBitmap(this.ImagenCamaraConectada);
                        this.Visualizar(this.ImagenActual);
                        this.ZoomFit();
                        this.MostrarMensaje("Conectada");
                        this.PrimeraFoto = false;
                        break;
                    case EstadoConexion.Conectando:
                        this.MostrarMensaje("En proceso de conexión");
                        break;
                    case EstadoConexion.ErrorConexion:
                        this.MostrarMensaje("Error de conexión");
                        break;
                    case EstadoConexion.Reconectando:
                        this.ImagenActual = this.NuevaImagen();
                        this.ImagenActual.ConvertFromBitmap(this.ImagenCamaraDesConectada);
                        this.Visualizar(this.ImagenActual);
                        this.ZoomFit();
                        this.MostrarMensaje("Intentando reconexión");
                        break;
                    case EstadoConexion.Reconectado:
                        this.MostrarMensaje("Reconexión realizada");
                        break;
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }
        #endregion

        #region Definición de eventos(s)
        /// <summary>
        /// Evento que indica el cambio de estado de visualización de la ventana (maximizado o normal)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Category("Orbita")]
        [Description("Se dispara cuando se produce una maximización o restauración del control.")]
        public event EstadoVentanaCambiado OnEstadoVentanaCambiado;

        /// <summary>
        /// Evento que indica el cambio de visualización al siguiente/anterior dispositivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Category("Orbita")]
        [Description("Se dispara cuando el usuario desea visualizar imagenes del siguiente o anterior dispositivo.")]
        public event VisorDispositivoCambiado OnVisorDispositivoCambiado;

        /// <summary>
        /// Evento que indica el cambio de estado de visualización de la ventana (maximizado o normal)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Category("Orbita")]
        [Description("Se dispara cuando el usuario desea ver más información sobre el dispositivo origen de la imagen.")]
        public event VisorClicBoton OnInfoDemandada;

        /// <summary>
        /// Evento que indica el clic en el visor (devolviendo la información de X e Y de la imagen)
        /// </summary>
        [Category("Orbita")]
        [Description("Se dispara al hacer clic sobre el visor. Retorna iformación XY de la imagen.")]
        public event ImageMouseHandler ImageMouseClick;

        /// <summary>
        /// Evento que indica el movimiento del cursor sobre el visor (devolviendo la información de X e Y de la imagen)
        /// </summary>
        [Category("Orbita")]
        [Description("Se dispara al mover el cursor sobre el visor. Retorna iformación XY de la imagen.")]
        public event ImageMouseHandler ImageMouseMove;
        #endregion
    }

    #region Definición de eventos(s)
    /// <summary>
    /// Delegado que indica el cambio de estado de visualización de la ventana (maximizado o normal)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void EstadoVentanaCambiado(object sender, EventStateMaximizedArgs e);

    /// <summary>
    /// Parametros de retorno del evento de cambio de maximizado o restaurado de la ventana
    /// </summary>
    public class EventStateMaximizedArgs : EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Código de la cámara
        /// </summary>
        public string CodCamara;
        /// <summary>
        /// Estado actual de la ventana
        /// </summary>
        public FormWindowState EstadoVentana;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codEstado">Código del estado visual</param>
        /// <param name="posicion">Posición del estado visual</param>
        public EventStateMaximizedArgs(string codCamara, FormWindowState estadoVentana)
        {
            this.CodCamara = codCamara;
            this.EstadoVentana = estadoVentana;
        }
        #endregion
    }

    /// <summary>
    /// Delegado que indica el cambio de visualización al siguiente o anterior dispositivo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void VisorDispositivoCambiado(object sender, EventDeviceViewerChangedArgs e);

    /// <summary>
    /// Parametros de retorno del evento de cambio de visualización al siguiente o anterior dispositivo
    /// </summary>
    public class EventDeviceViewerChangedArgs : EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Código de la cámara
        /// </summary>
        public string CodCamara;
        /// <summary>
        /// Estado actual de la ventana
        /// </summary>
        public DeviceViewerChangeOrder OrdenSiguienteDispositivoAVisualizar;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codEstado">Código del estado visual</param>
        /// <param name="posicion">Posición del estado visual</param>
        public EventDeviceViewerChangedArgs(string codCamara, DeviceViewerChangeOrder ordenSiguienteDispositivoAVisualizar)
        {
            this.CodCamara = codCamara;
            this.OrdenSiguienteDispositivoAVisualizar = ordenSiguienteDispositivoAVisualizar;
        }
        #endregion

        #region Enumerado(s)
        /// <summary>
        /// Enumerado que indica el orden del siguiente dispositivo a visualizar 
        /// </summary>
        public enum DeviceViewerChangeOrder
        {
            next,
            previous
        }
        #endregion
    }

    /// <summary>
    /// Delegado que indica el cambio de estado de visualización de la ventana (maximizado o normal)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void VisorClicBoton(object sender, EventVisorClickButtonArgs e);

    /// <summary>
    /// Parametros de retorno del evento de cambio de maximizado o restaurado de la ventana
    /// </summary>
    public class EventVisorClickButtonArgs : EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Código de la cámara
        /// </summary>
        public string CodCamara;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codEstado">Código del estado visual</param>
        /// <param name="posicion">Posición del estado visual</param>
        public EventVisorClickButtonArgs(string codCamara)
        {
            this.CodCamara = codCamara;
        }
        #endregion
    }

    /// <summary>
    /// Delegado que indica el cambio de estado de visualización de la ventana (maximizado o normal)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ImageMouseHandler(object sender, EventImageMouseHandlerArgs e);

    /// <summary>
    /// Parametros de retorno del evento de cambio de maximizado o restaurado de la ventana
    /// </summary>
    public class EventImageMouseHandlerArgs : EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Código de la cámara
        /// </summary>
        public string CodCamara;
        /// <summary>
        /// Posición del cursor en la imagen
        /// </summary>
        public PointF Location;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codEstado">Código del visor</param>
        /// <param name="posicion">Posición del cursor en la imagen</param>
        public EventImageMouseHandlerArgs(string codCamara, PointF location)
        {
            this.CodCamara = codCamara;
            this.Location = location;
        }
        #endregion
    }
    #endregion
}