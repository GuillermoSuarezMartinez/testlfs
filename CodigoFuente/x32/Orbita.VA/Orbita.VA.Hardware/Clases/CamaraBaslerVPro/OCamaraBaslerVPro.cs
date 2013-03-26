//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Métodos de reconexión separados en una nueva clase
//
// Last Modified By : aibañez
// Last Modified On : 05-11-2012
// Description      : Adaptada a la utilización de los nuevos controles display
//
// Last Modified By : aibañez
// Last Modified On : 27-09-2012
// Description      : Número de entradas y salidas configurable por base de datos
//                    Bug solucionado: Timer de escaneo de entradas se paraba al detener el modo adquisición continuo
//
// Last Modified By : aibañez
// Last Modified On : 08-10-2012
// Description      : Por compatibilidad con las cámaras axis, también se emplea el parámetro configurado en  
//                    BBDD LanzarEventoAlSnap para lanzar el cambio de variable.
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.FGGigE.Implementation.Internal;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase que implementa las funciones de manejo de la cámara BaslerVPro
    /// </summary>
    public class OCamaraBaslerVPro : OCamaraBase
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Listado de todas las cámaras de tipo GigE
        /// </summary>
        private static CogFrameGrabberGigEs FrameGrabbersGigEs;
        /// <summary>
        /// Booleano que evita que se construya varias veces el listado de cámaras de tipo GigE
        /// </summary>
        public static bool PrimeraInstancia = true;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Objeto de cognex para el acceso a la cámara
        /// </summary>
        private CogFrameGrabberGigE FrameGrabber;
        /// <summary>
        /// Acceso a los parámetros internos de la cámara
        /// </summary>
        public OVProGigEFeatures Ajustes;
        /// <summary>
        /// Buffer fifo de adquisición
        /// </summary>
        private CogAcqFifoGigE AcqFifo;
        /// <summary>
        /// Timer de escaneo de las entradas
        /// </summary>
        private OThreadLoop ThreadScan;
        /// <summary>
        /// Inervalo entre comprobaciones de conectividad con la cámara IP
        /// </summary>
        private int IntervaloComprobacionConectividadMS;
        /// <summary>
        /// Indica que la adquisición está siendo procesada en el momento actual
        /// </summary>
        public bool AdquisicionEnProceso;
        /// <summary>
        /// Tiempo máximo de acceso a la parametrización GigE
        /// </summary>
        private int TimeOutAccesoGigEFeatures;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Identificador interno de la cámara
        /// </summary>
        private string _DeviceId;
        /// <summary>
        /// Identificador interno de la cámara
        /// </summary>
        public string DeviceId
        {
            get { return _DeviceId; }
            set { _DeviceId = value; }
        }
        #endregion

        #region Propiedad(es) heredada(s)
        /// <summary>
        /// Propieadad a heredar donde se accede a la imagen
        /// </summary>
        public new OImagenVisionPro ImagenActual
        {
            get { return (OImagenVisionPro)this._ImagenActual; }
            set { this._ImagenActual = value; }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCamaraBaslerVPro(string codigo)
            : base(codigo)
        {
            try
            {
                // Inicialización de variables
                this.AdquisicionEnProceso = false;
                this._TipoImagen = TipoImagen.VisionPro;

                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(codigo);
                if (dt.Rows.Count == 1)
                {
                    // Rellenamos la información propia de la cámara
                    this._DeviceId = dt.Rows[0]["Basler_Pilot_DeviceID"].ToString();
                    // Creación de la comprobación de la conexión con la cámara IP
                    this.IntervaloComprobacionConectividadMS = OEntero.Validar(dt.Rows[0]["IPCam_IntervaloComprobacionConectividadMS"], 1, int.MaxValue, 100);
                    // Tiempo máximo de acceso a la parametrización GigE
                    this.TimeOutAccesoGigEFeatures = OEntero.Validar(dt.Rows[0]["Basler_Pilot_TimeOutGigE"], 1, int.MaxValue, 100);

                    // Rellenamos los terminales dinámicamente
                    this._ListaTerminales = new Dictionary<string, OTerminalIOBase>();
                    DataTable dtTerminales = AppBD.GetTerminalesIO(codigo);
                    if (dtTerminales.Rows.Count > 0)
                    {
                        foreach (DataRow drTerminales in dtTerminales.Rows)
                        {
                            string codigoTerminalIO = drTerminales["CodTerminalIO"].ToString();
                            this._ListaTerminales.Add(codigoTerminalIO, new OTerminalIOBaslerVproBit(codigo, codigoTerminalIO));
                        }
                    }

                    // Creamos el thread de consulta de las E/S
                    this.ThreadScan = new OThreadLoop(this.Codigo, this.IOTiempoScanMS, ThreadPriority.BelowNormal);
                    this.ThreadScan.CrearSuscripcionRun(EventoScan, true);

                    // Se construye la lista de cámaras GigE
                    if (PrimeraInstancia)
                    {
                        // Get a reference to a collection of all the GigE Vision Camaras found by this system.
                        FrameGrabbersGigEs = new CogFrameGrabberGigEs();
                        PrimeraInstancia = false;
                    }

                    // Se busca la cámara con su número de serie
                    this.Existe = this.BuscarCamaraPorNumeroSerie();

                    // Creación de los parámetros internos de las cámaras
                    this.Ajustes = new OVProGigEFeatures(this.Codigo, this.TimeOutAccesoGigEFeatures);
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " \r\nde la base de datos.");
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Fatal(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
            }
        }
        #endregion

        #region Método(s) privado(s)

        /// <summary>
        /// Busca la frame grabber cuyo número de serie coincide con el indicado
        /// </summary>
        /// <param name="numeroDeSerie">Número de serie de la cámara a buscar</param>
        /// <param name="frameGrabber">FrameGrabber encontrado</param>
        /// <returns>Veradero si se ha encontrado el número de serie</returns>
        private bool BuscarCamaraPorNumeroSerie()
        {
            bool resultado = false;

            try
            {
                // Get a reference to a JAI CM-*GE series Camara's Frame Grabber 
                // object if one is attached to this PC.
                foreach (CogFrameGrabberGigE frameGrabberLoop in FrameGrabbersGigEs)
                {
                    string deviceId = frameGrabberLoop.SerialNumber;

                    if (this._DeviceId == deviceId)
                    {
                        this.FrameGrabber = frameGrabberLoop;
                        resultado = true;
                        break;
                    }
                }
            }
            catch (COMException exception)
            {
                OMensajes.MostrarError("La cámara con número de serie " + this._DeviceId + "\n no se encuetra o está actualmente en uso.");
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.DeviceId, exception);
            }

            return resultado;
        }

        /// <summary>
        /// Vacia el buffer de adquisición
        /// </summary>
        /// <returns></returns>
        private bool VaciarBuffer()
        {
            bool resultado = false;

            try
            {
                int numPending = 0;
                int numReady = 0;
                bool busy = false;
                Stopwatch cronometro = new Stopwatch();

                cronometro.Start();
                do
                {
                    Application.DoEvents();
                    this.AcqFifo.GetFifoState(out numPending, out numReady, out busy);
                }
                while ((busy || (numPending > 0) || this.AdquisicionEnProceso) && (cronometro.Elapsed.TotalMilliseconds < 2000));

                this.AcqFifo.Flush();
                resultado = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }

            return resultado;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();

            this.Ajustes = null;

            this.AcqFifo = null;
            this.FrameGrabber.Disconnect(true);
            this.FrameGrabber = null;
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public override bool SetAjuste(string codAjuste, object valor)
        {
            return this.Ajustes.SetAjuste(codAjuste, valor);
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public override bool GetAjuste(string codAjuste, out object valor)
        {
            return this.Ajustes.GetAjuste(codAjuste, out valor);
        }

        /// <summary>
        /// Se toma el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool ConectarInterno(bool reconexion)
        {
            bool resultado = base.ConectarInterno(reconexion);
            try
            {
                if (this.FrameGrabber.OwnedGigEAccess == null) // Check for GigE Access support.
                {
                    throw new Exception("No hay soporte para cámaras GigE"); // Exit if no GigE Access support on this Frame-Grabber.
                }

                // Create a CogAcqFifo object for this Camara.
                this.AcqFifo = (CogAcqFifoGigE)this.FrameGrabber.CreateAcqFifo(this.Ajustes.AcquisitionFormat.Valor, this.Ajustes.ImageFormat.Valor, 0, false);

                this.AcqFifo.TimeoutEnabled = true; // Opcional

                // Inicialización de los ajustes
                this.Ajustes.Inicializar(this.FrameGrabber.OwnedGigEAccess, this.AcqFifo);

                // Se configuran los terminales dinamicamente
                foreach (OTerminalIOBaslerVproBit terminalIO in this._ListaTerminales.Values)
                {
                    terminalIO.Inicializar(this.Conectividad, this.Ajustes.LineSelector, this.Ajustes.LineSource, this.Ajustes.LineStatusAll, this.Ajustes.UserOutputSelector, this.Ajustes.UserOutputValue);
                }

                // Ponemos en marcha el thread de escaneo
                this.ThreadScan.Start();

                OImagen inicio = new OImagen();

                resultado = true;
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Error al conectarse a la cámara " + this.Codigo + ": " + exception.ToString());
            }

            return resultado;
        }

        /// <summary>
        /// Se deja el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool DesconectarInterno(bool errorConexion)
        {
            bool resultado = base.DesconectarInterno(errorConexion);

            try
            {
                // Paramos el thread de escaneo
                this.ThreadScan.Stop(250);

                // Se finalizan los ajustes
                this.Ajustes.Finalizar();

                this.VaciarBuffer();

                resultado = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }

            return resultado;
        }

        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected override bool StartInterno()
        {
            bool resultado = false;

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.StartInterno();

                    // Indicamos que no existe ninguna adquisición ejecutandose en estos momentos
                    this.AdquisicionEnProceso = false;

                    // Nos suscribimos al evento de adquisición de imagen
                    this.AcqFifo.Complete += this.CompleteAcquisition;

                    // Acquisition configuration
                    this.Ajustes.Start();

                    resultado = true;
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }

            return resultado;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected override bool StopInterno()
        {
            bool resultado = false;

            try
            {

                if (this.EstadoConexion != EstadoConexion.Desconectado)
                {
                    // Nos desuscribimos al evento de adquisición de imagen
                    this.AcqFifo.Complete -= this.CompleteAcquisition;

                    // Se configuran los ajustes
                    this.Ajustes.Stop();

                    // Se vacia el buffer interno
                    this.VaciarBuffer();

                    // Indicamos que no existe ninguna adquisición ejecutandose en estos momentos
                    this.AdquisicionEnProceso = false;

                    base.StopInterno();

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        protected override bool SnapInterno()
        {
            bool resultado = false;
            try
            {
                if ((this.EstadoConexion == EstadoConexion.Conectado) && (this.Ajustes.AcquisitionMode.Valor == ModoAdquisicion.DisparoSoftware))
                {
                    base.SnapInterno();

                    this.AcqFifo.StartAcquire();

                    resultado = true;
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }
            return resultado;
        }

        /// <summary>
        /// Carga una imagen de disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se encuentra la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool CargarImagenDeDisco(out OImagen imagen, string ruta)
        {
            bool resultado = false;

            if (this.ImagenActual != null)
            {
                this.ImagenActual = null;
            }

            imagen = new OImagenVisionPro();
            bool imagenok = imagen.Cargar(ruta);
            if (imagenok)
            {
                this.ImagenActual = (OImagenVisionPro)imagen;
                resultado = true;
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
        /// Guarda un objeto gráfico en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar el objeto gráfico</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool GuardarGraficoADisco(OGrafico graficos, string ruta)
        {
            bool resultado = false;

            if (graficos is OVisionProGrafico)
            {
                resultado = graficos.Guardar(ruta);
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve una nueva imagen del tipo adecuado al trabajo con la cámara
        /// </summary>
        /// <returns>Imagen del tipo adecuado al trabajo con la cámara</returns>
        public override OImagen NuevaImagen()
        {
            return new OImagenVisionPro();
        }

        /// <summary>
        /// Crea el objeto de conectividad adecuado para la cámara
        /// </summary>
        protected override void CrearConectividad()
        {
            // Creación de la comprobación de la conexión con la cámara Basler
            this.Conectividad = new OConectividadGigEVPro(this.Codigo, this.Ajustes.LineStatusAll, this.IntervaloComprobacionConectividadMS);
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento de recepción de nueva imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteAcquisition(object sender, CogCompleteEventArgs e)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new CogCompleteEventHandler(this.CompleteAcquisition), new object[] { sender, e });
                return;
            }

            // indicamos que se está procesando una adquisición
            this.AdquisicionEnProceso = true;

            // Este evento se realiza desde un subproceso por lo que es necesario llamar al proceso padre
            try
            {
                if (this.Ajustes.AcquisitionMode.Valor != ModoAdquisicion.Continuo)
                {
                    OVALogsManager.Debug(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Imagen adquirida", NivelLog.Info);
                }

                if (this.LanzarEventoAlSnap && (this.EstadoConexion == EstadoConexion.Conectado))
                {
                    int triggerNumber;
                    int ticket;

                    // Adquisición de la imagen
                    if (this.ImagenActual != null)
                    {
                        this.ImagenActual = null;
                    }
                    this.ImagenActual = new OImagenVisionPro(this.Codigo);
                    this.ImagenActual.Image = this.AcqFifo.CompleteAcquire(-1, out ticket, out triggerNumber);

                    // Comprobación de que la imagen recibida de la cámara es correcta
                    if ((this.ImagenActual.Image == null) || (!this.ImagenActual.Image.Allocated) || (this.ImagenActual.Image.Width <= 0) || (this.ImagenActual.Image.Height <= 0))
                    {
                        throw new Exception(string.Format("La imagen recibida de la cámara {0} está corrupta.", this.Codigo));
                    }

                    //// Actualizo la conectividad
                    //this.Conectividad.EstadoConexion = EstadoConexion.Conectado;

                    //// Actualizo el Frame Rate
                    //this.MedidorVelocidadAdquisicion.NuevaCaptura();

                    // Lanamos el evento de adquisición
                    this.AdquisicionCompletada(this.ImagenActual);

                    //// Se asigna el valor de la variable asociada
                    //if (this.LanzarEventoAlSnap && (ImagenActual.EsValida()))
                    //{
                    //    this.EstablecerVariableImagenAsociada(ImagenActual);
                    //}
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (CogAcqException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }

            // indicamos se ha finalizado la adquisición
            this.AdquisicionEnProceso = false;
        }

        /// <summary>
        /// Evento del timer de ejecución
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void EventoScan(ref bool finalize)
        {
            finalize = false;

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    // Lectura dinámica
                    foreach (OTerminalIOBaslerVproBit terminalIO in this._ListaTerminales.Values)
                    {
                        terminalIO.LeerEntrada();
                    }
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, exception);
            }
        }
        #endregion

        #region Evento(s) heredado(s)
        /// <summary>
        /// Evento de ping completado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCambioEstadoConectividadCamara(string codigo, EstadoConexion estadoConexionActal, EstadoConexion estadoConexionAnterior)
        {
            try
            {
                base.OnCambioEstadoConectividadCamara(codigo, estadoConexionActal, estadoConexionAnterior);

                if ((estadoConexionActal == EstadoConexion.Reconectado) && (estadoConexionAnterior == EstadoConexion.Reconectando))
                {
                    this.Conectar(true);
                }
                else
                    if ((estadoConexionActal == EstadoConexion.ErrorConexion) && (estadoConexionAnterior == EstadoConexion.Conectado))
                    {
                        this.Stop();
                        this.Desconectar(true);
                    }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.Camaras, this.Codigo, exception);
            }
        }
        #endregion
    }

    #region  Clases para el acceso a los parámeteros internos de las cámaras Basler Pylon
    /// <summary>
    /// Listado de todas las caracteríticas de la cámara
    /// </summary>
    public class OVProGigEFeatures
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de propiedades GigE
        /// </summary>
        public Dictionary<string, IVProCamFeature> ListGigEFeatures;
        /// <summary>
        /// Código identificativo de la cámara
        /// </summary>
        private string CodCamara;
        /// <summary>
        /// Clase cognex que permite el acceso a los parámetros internos de la cámara
        /// </summary>
        public ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// Tiempo máximo de acceso a la parametrización GigE
        /// </summary>
        private int TimeOutAccesoGigEFeatures;
        #endregion

        #region Propiedad(es)
        private OVProGigEIntFeature _AOIWidth_;
        public OVProGigEIntFeature AOIWidth
        {
            get
            {
                return _AOIWidth_;
            }
            set
            {
                _AOIWidth_ = value;
                this.ListGigEFeatures.Add("Width", value);
            }
        }

        private OVProGigEIntFeature _AOIHeight_;
        public OVProGigEIntFeature AOIHeight
        {
            get
            {
                return _AOIHeight_;
            }
            set
            {
                _AOIHeight_ = value;
                this.ListGigEFeatures.Add("Height", value);
            }
        }

        // Área de interés												
        private OVProGigEIntFeature _AOIOffsetX_;
        public OVProGigEIntFeature AOIOffsetX
        {
            get
            {
                return _AOIOffsetX_;
            }
            set
            {
                _AOIOffsetX_ = value;
                this.ListGigEFeatures.Add("OffsetX", value);
            }
        }

        private OVProGigEIntFeature _AOIOffsetY_;
        public OVProGigEIntFeature AOIOffsetY
        {
            get
            {
                return _AOIOffsetY_;
            }
            set
            {
                _AOIOffsetY_ = value;
                this.ListGigEFeatures.Add("OffsetY", value);
            }
        }

        private OVProAOI _AOI_;
        public OVProAOI AOI
        {
            get
            {
                return _AOI_;
            }
            set
            {
                _AOI_ = value;
                this.ListGigEFeatures.Add("AOI", value);
            }
        }

        // Configuración del Trigger													
        private OVProGigEEnumFeature _TriggerSource_;
        public OVProGigEEnumFeature TriggerSource
        {
            get
            {
                return _TriggerSource_;
            }
            set
            {
                _TriggerSource_ = value;
                this.ListGigEFeatures.Add("TriggerSource", value);
            }
        }

        private OVProGigEEnumFeature _TriggerMode_;
        public OVProGigEEnumFeature TriggerMode
        {
            get
            {
                return _TriggerMode_;
            }
            set
            {
                _TriggerMode_ = value;
                this.ListGigEFeatures.Add("TriggerMode", value);
            }
        }

        private OVProTriggerActivation _TriggerActivation_;
        public OVProTriggerActivation TriggerActivation
        {
            get
            {
                return _TriggerActivation_;
            }
            set
            {
                _TriggerActivation_ = value;
                this.ListGigEFeatures.Add("TriggerActivation", value);
            }
        }

        private OVProAcquisitionMode _AcquisitionMode_;
        public OVProAcquisitionMode AcquisitionMode
        {
            get
            {
                return _AcquisitionMode_;
            }
            set
            {
                _AcquisitionMode_ = value;
                this.ListGigEFeatures.Add("AcquisitionMode", value);
            }
        }

        // Transferencia													
        private OVProGigEIntFeature _PacketSize_;
        public OVProGigEIntFeature PacketSize
        {
            get
            {
                return _PacketSize_;
            }
            set
            {
                _PacketSize_ = value;
                this.ListGigEFeatures.Add("PacketSize", value);
            }
        }

        private OVProGigEIntFeature _ReserveBandwidth_;
        public OVProGigEIntFeature ReserveBandwidth
        {
            get
            {
                return _ReserveBandwidth_;
            }
            set
            {
                _ReserveBandwidth_ = value;
                this.ListGigEFeatures.Add("ReserveBandwidth", value);
            }
        }

        private OVProGigEIntFeature _InterPacketDelay_;
        public OVProGigEIntFeature InterPacketDelay
        {
            get
            {
                return _InterPacketDelay_;
            }
            set
            {
                _InterPacketDelay_ = value;
                this.ListGigEFeatures.Add("InterPacketDelay", value);
            }
        }

        private OVProTransferAdjust _TransferAdjust_;
        public OVProTransferAdjust TransferAdjust
        {
            get
            {
                return _TransferAdjust_;
            }
            set
            {
                _TransferAdjust_ = value;
                this.ListGigEFeatures.Add("TransferAdjust", value);
            }
        }

        // Iluminación
        private OVProExposure _ExposureTime_;
        public OVProExposure ExposureTime
        {
            get
            {
                return _ExposureTime_;
            }
            set
            {
                _ExposureTime_ = value;
                this.ListGigEFeatures.Add("ExposureTime", value);
            }
        }

        private OVProGigEEnumFeature _GainAuto_;
        public OVProGigEEnumFeature GainAuto
        {
            get
            {
                return _GainAuto_;
            }
            set
            {
                _GainAuto_ = value;
                this.ListGigEFeatures.Add("GainAuto", value);
            }
        }

        private OVProGain _Gain_;
        public OVProGain Gain
        {
            get
            {
                return _Gain_;
            }
            set
            {
                _Gain_ = value;
                this.ListGigEFeatures.Add("Gain", value);
            }
        }

        private OVProGigEIntFeature _BlackLevelRaw_;
        public OVProGigEIntFeature BlackLevelRaw
        {
            get
            {
                return _BlackLevelRaw_;
            }
            set
            {
                _BlackLevelRaw_ = value;
                this.ListGigEFeatures.Add("BlackLevelRaw", value);
            }
        }

        private OVProGigEEnumFeature _BalanceRatioSelector_;
        public OVProGigEEnumFeature BalanceRatioSelector
        {
            get
            {
                return _BalanceRatioSelector_;
            }
            set
            {
                _BalanceRatioSelector_ = value;
                this.ListGigEFeatures.Add("BalanceRatioSelector", value);
            }
        }

        private OVProGigEIntFeature _BalanceRatioRaw_;
        public OVProGigEIntFeature BalanceRatioRaw
        {
            get
            {
                return _BalanceRatioRaw_;
            }
            set
            {
                _BalanceRatioRaw_ = value;
                this.ListGigEFeatures.Add("BalanceRatioRaw", value);
            }
        }

        private OVProWhiteBalance _BalanceRatioRed_;
        public OVProWhiteBalance BalanceRatioRed
        {
            get
            {
                return _BalanceRatioRed_;
            }
            set
            {
                _BalanceRatioRed_ = value;
                this.ListGigEFeatures.Add("BalanceRatioRed", value);
            }
        }

        private OVProWhiteBalance _BalanceRatioGreen_;
        public OVProWhiteBalance BalanceRatioGreen
        {
            get
            {
                return _BalanceRatioGreen_;
            }
            set
            {
                _BalanceRatioGreen_ = value;
                this.ListGigEFeatures.Add("BalanceRatioGreen", value);
            }
        }

        private OVProWhiteBalance _BalanceRatioBlue_;
        public OVProWhiteBalance BalanceRatioBlue
        {
            get
            {
                return _BalanceRatioBlue_;
            }
            set
            {
                _BalanceRatioBlue_ = value;
                this.ListGigEFeatures.Add("BalanceRatioBlue", value);
            }
        }

        private OVProGigEBoolFeature _GammaEnable_;
        public OVProGigEBoolFeature GammaEnable
        {
            get
            {
                return _GammaEnable_;
            }
            set
            {
                _GammaEnable_ = value;
                this.ListGigEFeatures.Add("GammaEnable", value);
            }
        }

        private OVProGigEDoubleFeature _Gamma_;
        public OVProGigEDoubleFeature Gamma
        {
            get
            {
                return _Gamma_;
            }
            set
            {
                _Gamma_ = value;
                this.ListGigEFeatures.Add("Gamma", value);
            }
        }

        // Formato									
        private OVProAcquisitionFormat _AcquisitionFormat;
        public OVProAcquisitionFormat AcquisitionFormat
	    {
		    get 
            { 
                return _AcquisitionFormat;
            }
		    set 
            { 
                _AcquisitionFormat = value;
                this.ListGigEFeatures.Add("AcquisitionFormat", value);
            }
	    }
		
        private OVProImageFormat _ImageFormat_;
        public OVProImageFormat ImageFormat
        {
            get
            {
                return _ImageFormat_;
            }
            set
            {
                _ImageFormat_ = value;
                this.ListGigEFeatures.Add("ImageFormat", value);
            }
        }

        private OVProGigEEnumFeature _PixelFormat_;
        public OVProGigEEnumFeature PixelFormat
        {
            get
            {
                return _PixelFormat_;
            }
            set
            {
                _PixelFormat_ = value;
                this.ListGigEFeatures.Add("PixelFormat", value);
            }
        }

        // Entrada / Salida													
        private OVProGigEEnumFeature _LineSelector_;
        public OVProGigEEnumFeature LineSelector
        {
            get
            {
                return _LineSelector_;
            }
            set
            {
                _LineSelector_ = value;
                this.ListGigEFeatures.Add("LineSelector", value);
            }
        }

        private OVProGigEEnumFeature _LineSource_;
        public OVProGigEEnumFeature LineSource
        {
            get
            {
                return _LineSource_;
            }
            set
            {
                _LineSource_ = value;
                this.ListGigEFeatures.Add("LineSource", value);
            }
        }

        private OVProGigEIntFeature _LineStatusAll_;
        public OVProGigEIntFeature LineStatusAll
        {
            get
            {
                return _LineStatusAll_;
            }
            set
            {
                _LineStatusAll_ = value;
                this.ListGigEFeatures.Add("LineStatusAll", value);
            }
        }

        private OVProGigEEnumFeature _UserOutputSelector_;
        public OVProGigEEnumFeature UserOutputSelector
        {
            get
            {
                return _UserOutputSelector_;
            }
            set
            {
                _UserOutputSelector_ = value;
                this.ListGigEFeatures.Add("UserOutputSelector", value);
            }
        }

        private OVProGigEEnumFeature _UserOutputValue_;
        public OVProGigEEnumFeature UserOutputValue
        {
            get
            {
                return _UserOutputValue_;
            }
            set
            {
                _UserOutputValue_ = value;
                this.ListGigEFeatures.Add("UserOutputValue", value);
            }
        }

        private OVProGigEDoubleFeature _LineDebouncerTimeAbs_;
        public OVProGigEDoubleFeature LineDebouncerTimeAbs
        {
            get
            {
                return _LineDebouncerTimeAbs_;
            }
            set
            {
                _LineDebouncerTimeAbs_ = value;
                this.ListGigEFeatures.Add("LineDebouncerTimeAbs", value);
            }
        }

        private OVProGigEDoubleFeature _TemperatureAbs_;
        public OVProGigEDoubleFeature TemperatureAbs
        {
            get
            {
                return _TemperatureAbs_;
            }
            set
            {
                _TemperatureAbs_ = value;
                this.ListGigEFeatures.Add("TemperatureAbs", value);
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGigEFeatures(string codigo, int timeOutAccesoGigEFeatures)
        {
            this.ListGigEFeatures = new Dictionary<string, IVProCamFeature>();

            this.CodCamara = codigo;
            this.TimeOutAccesoGigEFeatures = timeOutAccesoGigEFeatures;

            try
            {
                // Área de interés
                this.AOIWidth = new OVProGigEIntFeature("Width", 2, 10000, 2454, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_Width");
                this.AOIHeight = new OVProGigEIntFeature("Height", 2, 10000, 2056, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_Height");
                this.AOIOffsetX = new OVProGigEIntFeature("OffsetX", 0, 10000, 2454, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_X");
                this.AOIOffsetY = new OVProGigEIntFeature("OffsetY", 0, 10000, 2454, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_Y");
                this.AOI = new OVProAOI("AOI", this.AOIOffsetX, this.AOIOffsetY, this.AOIWidth, this.AOIHeight);
                // Configuración del Trigger
                this.TriggerSource = new OVProGigEEnumFeature("TriggerSource", new string[] { "Line1", "Line2", "Software" }, "Line1", timeOutAccesoGigEFeatures, true, "Basler_Pilot_TriggerSource");
                this.TriggerMode = new OVProGigEEnumFeature("TriggerMode", new string[] { "Off", "On" }, "Off", timeOutAccesoGigEFeatures, false, string.Empty);
                this.TriggerActivation = new OVProTriggerActivation("TriggerActivation", new string[] { "RisingEdge", "FallingEdge" }, "RisingEdge", "Basler_Pilot_TriggerActivation");
                this.AcquisitionMode = new OVProAcquisitionMode("AcquisitionMode", ModoAdquisicion.DisparoSoftware, this.TriggerMode, "Basler_Pilot_AcquisitionMode");
                // Transferencia
                this.PacketSize = new OVProGigEIntFeature("GevSCPSPacketSize", 220, 16404, 1500, timeOutAccesoGigEFeatures, true, "Basler_Pilot_PacketSize");
                this.InterPacketDelay = new OVProGigEIntFeature("GevSCPD", 0, 904, 0, timeOutAccesoGigEFeatures, false, string.Empty);
                this.ReserveBandwidth = new OVProGigEIntFeature("GevSCBWR", 0, 99, 10, timeOutAccesoGigEFeatures, false, string.Empty);
                this.TransferAdjust = new OVProTransferAdjust("TransferAdjust", 0.001, 1, 1, this.ReserveBandwidth, this.PacketSize, this.InterPacketDelay,  "Basler_Pilot_Bandwidth");
                // Iluminación
                this.ExposureTime = new OVProExposure("ExposureTime", 0.04, 81.9, 0.1, "Basler_Pilot_Shutter");
                this.GainAuto = new OVProGigEEnumFeature("GainAuto", new string[] { "Off", "Once", "Continuous" }, "Off", timeOutAccesoGigEFeatures, true, "Basler_Pilot_GainAuto");
                this.Gain = new OVProGain("Gain", 0, 1, 0.2, "Basler_Pilot_Gain");
                this.BlackLevelRaw = new OVProGigEIntFeature("BlackLevelRaw", 0, 600, 32, timeOutAccesoGigEFeatures, true, "Basler_Pilot_BlackLevel");
                this.BalanceRatioSelector = new OVProGigEEnumFeature("BalanceRatioSelector", new string[] { "Red", "Green", "Blue" }, "Red", timeOutAccesoGigEFeatures, false, string.Empty);
                this.BalanceRatioRaw = new OVProGigEIntFeature("BalanceRatioRaw", 0, 255, 50, timeOutAccesoGigEFeatures, false, string.Empty);
                this.BalanceRatioRed = new OVProWhiteBalance("WhiteBalanceRed", 0, 255, 50, "Red", this.BalanceRatioRaw, this.BalanceRatioSelector, "Basler_Pilot_WhiteBalanceRed");
                this.BalanceRatioGreen = new OVProWhiteBalance("BalanceRatioGreen", 0, 255, 50, "Green", this.BalanceRatioRaw, this.BalanceRatioSelector, "Basler_Pilot_WhiteBalanceGreen");
                this.BalanceRatioBlue = new OVProWhiteBalance("BalanceRatioBlue", 0, 255, 50, "Blue", this.BalanceRatioRaw, this.BalanceRatioSelector, "Basler_Pilot_WhiteBalanceBlue");
                this.GammaEnable = new OVProGigEBoolFeature("GammaEnable", false, timeOutAccesoGigEFeatures, true, "Basler_Pilot_GammaEnable");
                this.Gamma = new OVProGigEDoubleFeature("Gamma", 0, 3.99902, 1, timeOutAccesoGigEFeatures, true, "Basler_Pilot_Gamma");
                // Formato
                this.AcquisitionFormat = new OVProAcquisitionFormat("AcquisitionFormat", new string[] { "Generic GigEVision (Bayer Color)", "Generic GigEVision (Mono)" }, "Generic GigEVision (Mono)", "Basler_Pilot_AcquisitionFormat");
                this.ImageFormat = new OVProImageFormat("ImageFormat", CogAcqFifoPixelFormatConstants.Format8Grey, "Basler_Pilot_ImageFormat");
                this.PixelFormat = new OVProGigEEnumFeature("PixelFormat", new string[] { "Mono8", "BayerBG8", "YUV422Packed", "YUV422_YUYV_Packed", "BayerBG12Packed", "BayerBG16" }, "Mono8", timeOutAccesoGigEFeatures, true, "Basler_Pilot_TransferFormat");
                // Entrada / Salida
                this.LineSelector = new OVProGigEEnumFeature("LineSelector", new string[] { "Line1", "Line2", "Out1", "Out2", "Out3", "Out4" }, "Line1", timeOutAccesoGigEFeatures, false, string.Empty);
                this.LineSource = new OVProGigEEnumFeature("LineSource", new string[] { "UserOutput", "ExposureActive", "TimerActive", "TriggerReady", "AcquisitionTriggerReady" }, "UserOutput", timeOutAccesoGigEFeatures, false, string.Empty);
                this.LineStatusAll = new OVProGigEIntFeature("LineStatusAll", 0, int.MaxValue, 0, timeOutAccesoGigEFeatures, false, string.Empty);
                this.UserOutputSelector = new OVProGigEEnumFeature("UserOutputSelector", new string[] { "UserOutput1", "UserOutput2", "UserOutput3", "UserOutput4" }, "UserOutput1", timeOutAccesoGigEFeatures, false, string.Empty);
                this.UserOutputValue = new OVProGigEEnumFeature("UserOutputValue", new string[] { "0", "1" }, "0", timeOutAccesoGigEFeatures, false, string.Empty);
                this.LineDebouncerTimeAbs = new OVProGigEDoubleFeature("LineDebouncerTimeAbs", 0, double.MaxValue, 0, timeOutAccesoGigEFeatures, false, "Basler_Pilot_DebouncerTime");
                this.TemperatureAbs = new OVProGigEDoubleFeature("TemperatureAbs", double.MinValue, double.MaxValue, 0, timeOutAccesoGigEFeatures, false, string.Empty);

                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(this.CodCamara);
                if (dt.Rows.Count == 1)
                {
                    foreach (KeyValuePair<string, IVProCamFeature> pair in this.ListGigEFeatures)
                    {
                        pair.Value.LoadBD(dt.Rows[0]);
                    }
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de los parámetros de la cámara " + codigo + " en la base de datos.");
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.CodCamara, exception);
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// One of the default features of a JAI CM-*GE series Camara needs
        /// to be changed before VisionPro can interact with it.
        /// This function needs to be called before a CogAcqFifo is created.
        /// </summary>
        /// <param name="gigEAccess"></param>
        private void InitializeForCompatibility()
        {
            try
            {
                // Loading a user set, which VisionPro does at start up, takes
                // longer than the VisionPro default Camara write timeout for
                // JAI CM-*GE series Camaras.  Increase the VisionPro Camara write
                // timeout before creating an acqFifo.
                this.GigEFeatureAccess.SetFeatureWriteTimeout(this.TimeOutAccesoGigEFeatures);
                this.GigEFeatureAccess.SetFeatureReadTimeout(this.TimeOutAccesoGigEFeatures);
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "InitializeForCompatibility", exception);
            }
        }

        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicialización del acceso a los parámetros de la cámara
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            // Asignación de los campos
            this.GigEFeatureAccess = gigEFeatureAccess;

            this.InitializeForCompatibility();

            foreach (KeyValuePair<string, IVProCamFeature> pair in this.ListGigEFeatures)
            {
                pair.Value.Inicializar(gigEFeatureAccess, acqFifo);
                pair.Value.Send(false, ModoAjuste.Inicializacion);
            }
        }
        /// <summary>
        /// Finalización del acceso a los parámetros de la cámara
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Finalizar()
        {
            foreach (KeyValuePair<string, IVProCamFeature> pair in this.ListGigEFeatures)
            {
                pair.Value.Send(false, ModoAjuste.Finalizacion);
            }
        }
        /// <summary>
        /// Inicio de la reproducción de la cámara
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Start()
        {
            foreach (KeyValuePair<string, IVProCamFeature> pair in this.ListGigEFeatures)
            {
                pair.Value.Send(false, ModoAjuste.Start);
            }
        }
        /// <summary>
        /// Fin de la reproducción de la cámara
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Stop()
        {
            foreach (KeyValuePair<string, IVProCamFeature> pair in this.ListGigEFeatures)
            {
                pair.Value.Send(false, ModoAjuste.Stop);
            }
        }
        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codAjuste, object valor)
        {
            IVProCamFeature feature;
            if (this.ListGigEFeatures.TryGetValue(codAjuste, out feature))
            {
                feature.ValorGenerico = valor;
                return feature.Send(false, ModoAjuste.Ejecucion);
            }

            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codAjuste, out object valor)
        {
            valor = null;
            IVProCamFeature feature;
            if (this.ListGigEFeatures.TryGetValue(codAjuste, out feature))
            {
                bool ok = feature.Receive();
                valor = feature.ValorGenerico;
                return ok;
            }

            return false;
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo string
    /// </summary>
    public class OVProGigEStringFeature : OTexto, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// TimeOut de envio o recepción
        /// </summary>
        private int TimeOut;
        /// <summary>
        /// Informa de la validez de la propiedad para su lectura
        /// </summary>
        private bool ValidForRead;
        /// <summary>
        /// Informa de la validez de la propiedad para su escritura
        /// </summary>
        private bool ValidForWrite;
        /// <summary>
        /// La propiedad ataca directamente contra la cámara
        /// </summary>
        private bool AccesoDirecto;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGigEStringFeature(string codigo, int maxLength, bool admiteVacio, bool limitarLongitud, string defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
            : base(codigo, maxLength, admiteVacio, true, defaultValue, false)
        {
            this.TimeOut = timeOutMilis;
            this.AccesoDirecto = accesoDirecto;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.GigEFeatureAccess = gigEFeatureAccess;
            this.ValidForRead = this.GigEFeatureAccess.IsReadable(this.Codigo);
            this.ValidForWrite = this.GigEFeatureAccess.IsWriteable(this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    string strValue = (string)this.Valor;
                    string strOutValue = string.Empty;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        this.GigEFeatureAccess.SetFeature(this.Codigo, strValue);
                        strOutValue = this.GigEFeatureAccess.GetFeature(this.Codigo);
                        ok = (strValue == strOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && (this.ValidForRead))
                {
                    this.Valor = this.GigEFeatureAccess.GetFeature(this.Codigo);
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo enumerado (aunque internamente trabaja como un string)
    /// </summary>
    public class OVProGigEEnumFeature : OEnumeradoTexto, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// TimeOut de envio o recepción
        /// </summary>
        private int TimeOut;
        /// <summary>
        /// Informa de la validez de la propiedad para su lectura
        /// </summary>
        private bool ValidForRead;
        /// <summary>
        /// Informa de la validez de la propiedad para su escritura
        /// </summary>
        private bool ValidForWrite;
        /// <summary>
        /// La propiedad ataca directamente contra la cámara
        /// </summary>
        private bool AccesoDirecto;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGigEEnumFeature(string codigo, string[] valoresPermitidos, string defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
            : base(codigo, valoresPermitidos, defaultValue, false)
        {
            this.TimeOut = timeOutMilis;
            this.AccesoDirecto = accesoDirecto;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.GigEFeatureAccess = gigEFeatureAccess;
            this.ValidForRead = this.GigEFeatureAccess.IsReadable(this.Codigo);
            this.ValidForWrite = this.GigEFeatureAccess.IsWriteable(this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    string strValue = (string)this.Valor;
                    string strOutValue = string.Empty;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        this.GigEFeatureAccess.SetFeature(this.Codigo, strValue);
                        strOutValue = this.GigEFeatureAccess.GetFeature(this.Codigo);
                        ok = (strValue == strOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && (this.ValidForRead))
                {
                    this.Valor = this.GigEFeatureAccess.GetFeature(this.Codigo);
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo entero
    /// </summary>
    public class OVProGigEIntFeature : OEntero, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// TimeOut de envio o recepción
        /// </summary>
        private int TimeOut;
        /// <summary>
        /// Informa de la validez de la propiedad para su lectura
        /// </summary>
        private bool ValidForRead;
        /// <summary>
        /// Informa de la validez de la propiedad para su escritura
        /// </summary>
        private bool ValidForWrite;
        /// <summary>
        /// La propiedad ataca directamente contra la cámara
        /// </summary>
        private bool AccesoDirecto;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGigEIntFeature(string codigo, int minValue, int maxValue, int defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
            : base(codigo, minValue, maxValue, defaultValue, false)
        {
            this.TimeOut = timeOutMilis;
            this.AccesoDirecto = accesoDirecto;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.GigEFeatureAccess = gigEFeatureAccess;
            this.ValidForRead = this.GigEFeatureAccess.IsReadable(this.Codigo);
            this.ValidForWrite = this.GigEFeatureAccess.IsWriteable(this.Codigo);
        }
        /// <summary>
        /// Aplica el parámetro a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    uint intValue = (uint)this.Valor;
                    uint intOutValue = uint.MaxValue;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        this.GigEFeatureAccess.SetIntegerFeature(this.Codigo, intValue);
                        intOutValue = this.GigEFeatureAccess.GetIntegerFeature(this.Codigo);
                        ok = (intValue == intOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor del parámetro a la cámara
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && (this.ValidForRead))
                {
                    this.Valor = (int)this.GigEFeatureAccess.GetIntegerFeature(this.Codigo);
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo entero
    /// </summary>
    public class OVProGigEDoubleFeature : ODecimal, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// TimeOut de envio o recepción
        /// </summary>
        private int TimeOut;
        /// <summary>
        /// Informa de la validez de la propiedad para su lectura
        /// </summary>
        private bool ValidForRead;
        /// <summary>
        /// Informa de la validez de la propiedad para su escritura
        /// </summary>
        private bool ValidForWrite;
        /// <summary>
        /// La propiedad ataca directamente contra la cámara
        /// </summary>
        private bool AccesoDirecto;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGigEDoubleFeature(string codigo, double minValue, double maxValue, double defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
            : base(codigo, minValue, maxValue, defaultValue, false)
        {
            this.TimeOut = timeOutMilis;
            this.AccesoDirecto = accesoDirecto;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.GigEFeatureAccess = gigEFeatureAccess;
            this.ValidForRead = this.GigEFeatureAccess.IsReadable(this.Codigo);
            this.ValidForWrite = this.GigEFeatureAccess.IsWriteable(this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    double doubleValue = (double)this.Valor;
                    double doubleOutValue = double.MaxValue;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        this.GigEFeatureAccess.SetDoubleFeature(this.Codigo, doubleValue);
                        doubleOutValue = this.GigEFeatureAccess.GetDoubleFeature(this.Codigo);
                        ok = ODecimal.EnTolerancia(doubleValue, doubleOutValue, 0.01);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && (this.ValidForRead))
                {
                    this.Valor = this.GigEFeatureAccess.GetDoubleFeature(this.Codigo);
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo entero
    /// </summary>
    public class OVProGigEBoolFeature : OBooleano, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// TimeOut de envio o recepción
        /// </summary>
        private int TimeOut;
        /// <summary>
        /// Informa de la validez de la propiedad para su lectura
        /// </summary>
        private bool ValidForRead;
        /// <summary>
        /// Informa de la validez de la propiedad para su escritura
        /// </summary>
        private bool ValidForWrite;
        /// <summary>
        /// La propiedad ataca directamente contra la cámara
        /// </summary>
        private bool AccesoDirecto;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGigEBoolFeature(string codigo, bool defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
            : base(codigo, defaultValue, false)
        {
            this.TimeOut = timeOutMilis;
            this.AccesoDirecto = accesoDirecto;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.GigEFeatureAccess = gigEFeatureAccess;
            this.ValidForRead = this.GigEFeatureAccess.IsReadable(this.Codigo);
            this.ValidForWrite = this.GigEFeatureAccess.IsWriteable(this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    bool boolValue = (bool)this.Valor;
                    bool boolOutValue = false;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        string strSendValue = boolValue ? "true" : "false";
                        this.GigEFeatureAccess.SetFeature(this.Codigo, strSendValue);

                        string strValue = this.GigEFeatureAccess.GetFeature(this.Codigo);
                        boolOutValue = (strValue == "true");

                        ok = (boolValue == boolOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && (this.ValidForRead))
                {
                    string strValue = this.GigEFeatureAccess.GetFeature(this.Codigo);
                    this.Valor = (strValue == "true");
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo entero
    /// </summary>
    public class OVProExposure : ODecimal, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Buffer fifo de adquisición
        /// </summary>
        private CogAcqFifoGigE AcqFifo;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProExposure(string codigo, double minValue, double maxValue, double defaultValue, string nombreColumna)
            : base(codigo, minValue, maxValue, defaultValue, false)
        {
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.AcqFifo = acqFifo;
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.AcqFifo != null) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    // Get a reference to the ExposureParams interface of the AcqFifo.
                    ICogAcqExposure exposureParams = this.AcqFifo.OwnedExposureParams;
                    // Always check to see an "Owned" property is supported
                    // before using it.
                    if (exposureParams != null)  // Check for exposure support.
                    {
                        exposureParams.Exposure = this.Valor;  // sets ExposureTimeAbs
                        this.AcqFifo.Prepare();  // writes the properties to the Camara.
                        resultado = true;
                    }
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if (this.AcqFifo != null)
                {
                    this.Valor = this.AcqFifo.OwnedExposureParams.Exposure;
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara de tipo entero
    /// </summary>
    public class OVProGain : ODecimal, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Buffer fifo de adquisición
        /// </summary>
        private CogAcqFifoGigE AcqFifo;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProGain(string codigo, double minValue, double maxValue, double defaultValue, string nombreColumna)
            : base(codigo, minValue, maxValue, defaultValue, false)
        {
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) implementado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.AcqFifo = acqFifo;
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.AcqFifo != null) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    this.AcqFifo.OwnedContrastParams.Contrast = (double)this.Valor;
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if (this.AcqFifo != null)
                {
                    this.Valor = this.AcqFifo.OwnedContrastParams.Contrast;
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProWhiteBalance : OEntero, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Nombre del plano de color
        /// </summary>
        private string Color;
        /// <summary>
        /// Propiedad del balance de blancos
        /// </summary>
        private IVProCamFeature FeatureBalanceRatio;
        /// <summary>
        /// Propiedad del balance de blancos
        /// </summary>
        private IVProCamFeature FeatureBalanceRatioSelector;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProWhiteBalance(string codigo, int minValor, int maxValor, int valorDefecto, string color, IVProCamFeature featureBalanceRatio, IVProCamFeature featureBalanceRatioSelector, string nombreColumna)
            : base(codigo, minValor, maxValor, valorDefecto, false)
        {
            this.Color = color;
            this.FeatureBalanceRatioSelector = featureBalanceRatioSelector;
            this.FeatureBalanceRatio = featureBalanceRatio;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion))
                {
                    this.FeatureBalanceRatioSelector.ValorGenerico = this.Color;
                    this.FeatureBalanceRatioSelector.Send(true, modoAjuste);

                    this.FeatureBalanceRatio.ValorGenerico = this.Valor;
                    resultado = this.FeatureBalanceRatio.Send(true, modoAjuste);
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                this.FeatureBalanceRatioSelector.ValorGenerico = this.Color;
                this.FeatureBalanceRatioSelector.Send(true, ModoAjuste.Ejecucion);

                resultado = this.FeatureBalanceRatio.Receive();
                if (resultado)
                {
                    this.ValorGenerico = this.FeatureBalanceRatio.ValorGenerico;
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProAOI : OObjetoBase<Rectangle>, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Buffer fifo de adquisición
        /// </summary>
        private CogAcqFifoGigE AcqFifo;
        /// <summary>
        /// Propiedad del AOI X
        /// </summary>
        private IVProCamFeature FeatureOffsetX;
        /// <summary>
        /// Propiedad del AOI Y
        /// </summary>
        private IVProCamFeature FeatureOffsetY;
        /// <summary>
        /// Propiedad del AOI Width
        /// </summary>
        private IVProCamFeature FeatureWidth;
        /// <summary>
        /// Propiedad del AOI Height
        /// </summary>
        private IVProCamFeature FeatureHeight;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProAOI(string codigo, IVProCamFeature featureOffsetX, IVProCamFeature featureOffsetY, IVProCamFeature featureWidth, IVProCamFeature featureHeight)
            : base(codigo, default(Rectangle), false)
        {
            this.FeatureOffsetX = featureOffsetX;
            this.FeatureOffsetY = featureOffsetY;
            this.FeatureWidth = featureWidth;
            this.FeatureHeight = featureHeight;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.AcqFifo = acqFifo;
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion))
                {
                    this.Valor = new Rectangle((int)this.FeatureOffsetX.ValorGenerico, (int)this.FeatureOffsetY.ValorGenerico, (int)this.FeatureWidth.ValorGenerico, (int)this.FeatureHeight.ValorGenerico);

                    // Get a reference to the ROIParams interface of the AcqFifo.
                    ICogAcqROI mROIParams = this.AcqFifo.OwnedROIParams;
                    // Always check to see an "Owned" property is supported before using it.
                    if (mROIParams != null)  // Check for ROI support.
                    {
                        // sets the ROI
                        mROIParams.SetROIXYWidthHeight(this.Valor.Left, this.Valor.Top, this.Valor.Width, this.Valor.Height);
                        this.AcqFifo.Prepare();  // writes the properties to the Camara.

                        resultado = true;
                    }
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                bool okX = this.FeatureOffsetX.Receive();
                bool okY = this.FeatureOffsetY.Receive();
                bool okW = this.FeatureWidth.Receive();
                bool okH = this.FeatureHeight.Receive();
                resultado = okX & okY & okW & okH;
                if (resultado)
                {
                    this.Valor = new Rectangle((int)this.FeatureOffsetX.ValorGenerico, (int)this.FeatureOffsetY.ValorGenerico, (int)this.FeatureWidth.ValorGenerico, (int)this.FeatureHeight.ValorGenerico);
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProAcquisitionMode : OEnumerado<ModoAdquisicion>, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Buffer fifo de adquisición
        /// </summary>
        private CogAcqFifoGigE AcqFifo;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Activación del trigger externo
        /// </summary>
        private IVProCamFeature FeatureTriggerMode;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProAcquisitionMode(string codigo, ModoAdquisicion defaultValue, IVProCamFeature featureTriggerMode, string nombreColumna)
            : base(codigo, defaultValue, false)
        {
            this.FeatureTriggerMode = featureTriggerMode;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.AcqFifo = acqFifo;
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if (this.AcqFifo != null)
                {
                    // Trigger Configuration
                    ICogAcqTrigger triggerOperator = this.AcqFifo.OwnedTriggerParams;

                    switch (modoAjuste)
                    {
                        case ModoAjuste.Inicializacion:
                            triggerOperator.TriggerEnabled = false;
                            switch (this.Valor)
                            {
                                case ModoAdquisicion.Continuo:
                                    triggerOperator.TriggerModel = CogAcqTriggerModelConstants.FreeRun;
                                    break;
                                case ModoAdquisicion.DisparoSoftware:
                                    triggerOperator.TriggerModel = CogAcqTriggerModelConstants.Manual;
                                    break;
                                case ModoAdquisicion.DisparoHardware:
                                    triggerOperator.TriggerModel = CogAcqTriggerModelConstants.Auto;
                                    break;
                            }
                            this.FeatureTriggerMode.ValorGenerico = "Off";
                            break;
                        case ModoAjuste.Start:
                        case ModoAjuste.Ejecucion:
                            switch (this.Valor)
                            {
                                case ModoAdquisicion.Continuo:
                                case ModoAdquisicion.DisparoSoftware:
                                    this.FeatureTriggerMode.ValorGenerico = "Off";
                                    break;
                                case ModoAdquisicion.DisparoHardware:
                                    this.FeatureTriggerMode.ValorGenerico = "On";
                                    break;
                            }
                            triggerOperator.TriggerEnabled = true;
                            this.AcqFifo.Prepare();
                            break;
                        case ModoAjuste.Stop:
                        case ModoAjuste.Finalizacion:
                            this.FeatureTriggerMode.ValorGenerico = "Off";
                            triggerOperator.TriggerEnabled = false;
                            break;
                    }
                    resultado = this.FeatureTriggerMode.Send(true, ModoAjuste.Ejecucion);
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if (this.AcqFifo != null)
                {
                    // Trigger Configuration
                    ICogAcqTrigger triggerOperator = this.AcqFifo.OwnedTriggerParams;

                    switch (triggerOperator.TriggerModel)
                    {
                        case CogAcqTriggerModelConstants.FreeRun:
                            this.Valor = ModoAdquisicion.Continuo;
                            break;
                        case CogAcqTriggerModelConstants.Manual:
                        default:
                            this.Valor = ModoAdquisicion.DisparoSoftware;
                            break;
                        case CogAcqTriggerModelConstants.Auto:
                            this.Valor = ModoAdquisicion.DisparoHardware;
                            break;
                    }

                    resultado = this.FeatureTriggerMode.Receive();
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProTriggerActivation : OEnumeradoTexto, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Buffer fifo de adquisición
        /// </summary>
        private CogAcqFifoGigE AcqFifo;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProTriggerActivation(string codigo, string[] valoresPermitidos, string defaultValue, string nombreColumna)
            : base(codigo, valoresPermitidos, defaultValue, false)
        {
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.AcqFifo = acqFifo;
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.AcqFifo != null) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    // Trigger Configuration
                    ICogAcqTrigger triggerOperator = this.AcqFifo.OwnedTriggerParams;

                    // Setup the trigger edge.
                    triggerOperator.TriggerLowToHigh = this.Valor == "RisingEdge";
                    
                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            bool resultado = false;

            try
            {
                if (this.AcqFifo != null)
                {
                    // Trigger Configuration
                    ICogAcqTrigger triggerOperator = this.AcqFifo.OwnedTriggerParams;

                    this.Valor = triggerOperator.TriggerLowToHigh ? "RisingEdge" : "FallingEdge";
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "ReceiveFeature:" + this.Codigo, exception);
            }

            return resultado;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProAcquisitionFormat : OEnumeradoTexto, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProAcquisitionFormat(string codigo, string[] valoresPermitidos, string defaultValue, string nombreColumna)
            : base(codigo, valoresPermitidos, defaultValue, false)
        {
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            return false;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            return false;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }


    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProImageFormat : OEnumerado<CogAcqFifoPixelFormatConstants>, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProImageFormat(string codigo, CogAcqFifoPixelFormatConstants defaultValue, string nombreColumna)
            : base(codigo, defaultValue, false)
        {
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            return false;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            return false;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para modificar el Balance de blancos
    /// </summary>
    public class OVProTransferAdjust : ODecimal, IVProCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private ICogGigEAccess GigEFeatureAccess;
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Propiedad del ancho de banda utilizado
        /// </summary>
        private IVProCamFeature FeatureReserveBandwidth;
        /// <summary>
        /// Propiedad del tamaño de la trama de comunicación
        /// </summary>
        private IVProCamFeature FeaturePacketSize;
        /// <summary>
        /// Propiedad del tiempo de espera entre paquetes
        /// </summary>
        private IVProCamFeature FeatureInterPacketDelay;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVProTransferAdjust(string codigo, double minValor, double maxValor, double valorDefecto, IVProCamFeature featureReserveBandwidth, IVProCamFeature featurePacketSize, IVProCamFeature featureInterPacketDelay, string nombreColumna)
            : base(codigo, minValor, maxValor, valorDefecto, false)
        {
            this.FeatureReserveBandwidth = featureReserveBandwidth;
            this.FeaturePacketSize = featurePacketSize;
            this.FeatureInterPacketDelay = featureInterPacketDelay;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo)
        {
            this.GigEFeatureAccess = gigEFeatureAccess;
        }
        /// <summary>
        /// When using multiple Camaras, it is possible that the
        /// total data rate of the Camaras will exceed the bandwidth of the 
        /// GigE network.  Acquisition can still be successfully performed
        /// if the data rate of the Camaras is reduced to fit within the 
        /// available bandwidth.
        /// The general idea is that if you have an n Camara
        /// application, you set each Camara's bandwidth to 1/n and the data
        /// rate will be reduced as needed to allow all Camaras to work
        /// simultaneously.  See additional comments on the SetBandwidth
        /// function.
        /// Note that this code will only work if the Camara supports
        /// the required GigE Vision registers.  You can discover if these
        /// are supported by looking over the XML description file for
        /// the Camara. 
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.GigEFeatureAccess != null) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    // Envio del BandWidth
                    double reserveBandWith = 100 - (100 / this.Valor);
                    this.FeatureReserveBandwidth.ValorGenerico = ODecimal.AsegurarRango(reserveBandWith, 0.0, 99.0);
                    this.FeatureReserveBandwidth.Send(true, modoAjuste);

                    // 1000 MBytes / sec overall throughput. Suponemos que usamos una red GigE
                    Double maxRate = 1000 * 1024 * 1024;
                    int packetSize = (int)this.FeaturePacketSize.ValorGenerico; // Valor cargado de BBDD
                    double packetTime = packetSize / maxRate;

                    // Use the bandwidth setting to calculate the time it should require to
                    // transmit each packet to achieve the desired bandwidth.  For example, a
                    // bandwidth setting of 0.25 means we want each packet to take 4 times
                    // longer than it would at full speed.
                    double desiredTime = packetTime / this.Valor;

                    // The difference between the desired and actual times is the delay we want
                    // between each packet.  Note that until the delay becomes larger than the
                    // intrinsic delay between each packet sent by the Camara, changes in
                    // bandwidth won't have any effect on the data rate.
                    double delaySec = desiredTime - packetTime;

                    // Consulta de la frecuencia de reloj
                    ulong timeStampFreq = (ulong)this.GigEFeatureAccess.TimeStampFrequency;

                    int delay = (int)(delaySec * timeStampFreq);
                    this.FeatureInterPacketDelay.ValorGenerico = delay;
                    resultado = this.FeatureInterPacketDelay.Send(true, modoAjuste);
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, "SendBandwidth", exception);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria.
        /// </summary>
        public bool Receive()
        {
            return false;
        }
        /// <summary>
        /// Carga la información de la base de datos
        /// </summary>
        /// <param name="dataRow">Row</param>
        public void LoadBD(DataRow dataRow)
        {
            if (this.NombreColumna != string.Empty)
            {
                this.ValorGenerico = dataRow[this.NombreColumna];
            }
        }
        #endregion
    }

    /// <summary>
    /// Acceso a una característica de la cámara VisionPro
    /// </summary>
    public interface IVProCamFeature : ICamFeature, IObjetoBase
    {
        #region Método(s)
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        void Inicializar(ICogGigEAccess gigEFeatureAccess, CogAcqFifoGigE acqFifo);
        #endregion
    }
    #endregion

    #region Terminales de Entrada/Salida
    /// <summary>
    /// Terminal de tipo bit que simboliza un bit de un puerto
    /// </summary>
    internal class OTerminalIOBaslerVproBit : OTerminalIOBase
    {
        #region Atributo(s)
        /// <summary>
        /// Cámara asociada
        /// </summary>
        private OConectividad Conectividad;
        /// <summary>
        /// Selector del termial
        /// </summary>
        private OVProGigEEnumFeature FeatureLineSelector;
        /// <summary>
        /// Tipo de terminal
        /// </summary>
        private OVProGigEEnumFeature FeatureLineSource;
        /// <summary>
        /// Estado de los terminales (activados o desactivados)
        /// </summary>
        private OVProGigEIntFeature FeatureLineStatusAll;
        /// <summary>
        /// Selector de salida de usuario
        /// </summary>
        private OVProGigEEnumFeature FeatureUserOutputSelector;
        /// <summary>
        /// Valor de salida
        /// </summary>
        private OVProGigEEnumFeature FeatureUserOutputValue;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Valor del terminal
        /// </summary>
        public new bool Valor
        {
            get
            {
                bool boolValor;
                if (this.ComprobarValor(base.Valor, out boolValor))
                {
                    return boolValor;
                }
                return false;
            }
            set
            {
                base.Valor = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OTerminalIOBaslerVproBit(string codTarjetaIO, string codTerminalIO)
            : base(codTarjetaIO, codTerminalIO)
        {
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a heredar donde se inicializan los terminales
        /// </summary>
        public new void Inicializar(OConectividad conectividad, OVProGigEEnumFeature lineSelector, OVProGigEEnumFeature lineSource, OVProGigEIntFeature lineStatusAll, OVProGigEEnumFeature userOutputSelector, OVProGigEEnumFeature userOutputValue)
        {
            try
            {
                base.Inicializar();

                this.Conectividad = conectividad;

                this.FeatureLineSelector = lineSelector;
                this.FeatureLineSource = lineSource;
                this.FeatureLineStatusAll = lineStatusAll;
                this.FeatureUserOutputSelector = userOutputSelector;
                this.FeatureUserOutputValue = userOutputValue;

                if (this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital)
                {
                    this.FeatureLineSelector.Valor = this.Codigo;
                    this.FeatureLineSelector.Send(true, ModoAjuste.Inicializacion);

                    this.FeatureLineSource.Valor = "UserOutput";
                    this.FeatureLineSource.Send(true, ModoAjuste.Inicializacion);
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.Conectividad.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.CodTarjeta, exception);
            }
        }

        /// <summary>
        /// Lectura de la entrada física
        /// </summary>
        public override void LeerEntrada()
        {
            try
            {
                if (this.Conectividad.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.LeerEntrada();

                    if (this.Habilitado && (this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital))
                    {
                        // Leo la entrada fisica
                        this.FeatureLineStatusAll.Receive();
                        uint intValor = (uint)this.FeatureLineStatusAll.Valor;
                        bool boolValor = OBinario.GetBit(intValor, this.Numero);

                        if (this.Valor != boolValor)
                        {
                            this.Valor = boolValor;
                            this.LanzarCambioValor();
                        }
                    }
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.Conectividad.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.CodTarjeta, exception);
            }
        }

        /// <summary>
        /// Escritura de la salida física
        /// </summary>
        public override void EscribirSalida(string codigoVariable, object valor)
        {
            try
            {
                if (this.Conectividad.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.EscribirSalida(codigoVariable, valor);

                    // Se comprueba que el valor a escribir sea correcto
                    bool boolValor;
                    if (this.ComprobarValor(valor, out boolValor))
                    {
                        // Si el valor es correcto se escribe la salida física
                        if (this.Habilitado && (this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital))
                        {
                            // Se escribe la entrada física
                            this.FeatureUserOutputSelector.Valor = "UserOutput" + (this.Numero + 1).ToString();
                            this.FeatureUserOutputSelector.Send(true, ModoAjuste.Ejecucion);

                            if (boolValor)
                            {
                                this.FeatureUserOutputValue.Valor = "1";
                                this.FeatureUserOutputValue.Send(true, ModoAjuste.Ejecucion);
                            }
                            else
                            {
                                this.FeatureUserOutputValue.Valor = "0";
                                this.FeatureUserOutputValue.Send(true, ModoAjuste.Ejecucion);
                            }
                        }
                        this.Valor = boolValor;
                    }
                }
            }
            catch (OCameraConectionException exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": " + exception.ToString());
                this.Conectividad.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraBaslerVPro, this.CodTarjeta, exception);
            }

        }

        /// <summary>
        /// Se comprueba que el valor a escribir sea del tipo correcto
        /// </summary>
        /// <param name="valor">Valor a escribir</param>
        /// <param name="byteValor">Valor a escribir del tipo correcto</param>
        /// <returns>Devuelve verdadero si el valor a escribir es válido</returns>
        private bool ComprobarValor(object valor, out bool boolValor)
        {
            boolValor = false;

            // Se comprueba que el valor sea correcto
            bool valorOK = false;
            if (valor is bool)
            {
                boolValor = (bool)valor;
                valorOK = true;
            }
            return valorOK;
        }
        #endregion
    }
    #endregion
}
