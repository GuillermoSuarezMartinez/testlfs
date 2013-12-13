//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 18-12-2012
//
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using Orbita.Utiles;
using Orbita.VA.Comun;
using PylonC.NET;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase que implementa las funciones de manejo de la cámara BaslerPylon
    /// </summary>
    public class OCamaraBaslerPylon : OCamaraBitmap
    {
        #region Atributo(s) estático(s)
        private static List<DeviceEnumerator.Device> ListaDispositivos;
        /// <summary>
        /// Booleano que evita que se construya varias veces el listado de cámaras de tipo GigE
        /// </summary>
        public static bool PrimeraInstancia = true;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Acceso a los parámetros internos de la cámara
        /// </summary>
        public OPylonGigEFeatures Ajustes;
        /// <summary>
        /// Proveedor de imagenes
        /// </summary>
        private ImageProvider ImageProvider;
        /// <summary>
        /// Bitmap temporal de guardado de imágenes
        /// </summary>
        private Bitmap TempBitmap;
        /// <summary>
        /// The friendly name of the device.
        /// </summary>
        public string Name;
        /// <summary>
        /// The index of the device.
        /// </summary>
        public uint Index;
        /// <summary>
        /// The serial of the device.
        /// </summary>
        public string Serial;
        /// <summary>
        /// The type of device of the device.
        /// </summary>
        public string DeviceClass;
        /// <summary>
        /// The factory number of the device.
        /// </summary>
        public string DeviceFactory;
        /// <summary>
        /// The version number of the device.
        /// </summary>
        public string DeviceVersion;
        /// <summary>
        /// The full name of the device.
        /// </summary>
        public string FullName;
        /// <summary>
        /// The model name of the device.
        /// </summary>
        public string ModelName;
        /// <summary>
        /// The user defined name of the device.
        /// </summary>
        public string UserDefinedName;
        /// <summary>
        /// The vendor name of the device.
        /// </summary>
        public string VendorName;
        /// <summary>
        /// Timer de escaneo de las entradas
        /// </summary>
        private OThreadLoop ThreadScan;
        /// <summary>
        /// Inervalo entre comprobaciones de conectividad con la cámara IP
        /// </summary>
        private int IntervaloComprobacionConectividadMS;
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

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCamaraBaslerPylon(string codigo)
            : base(codigo)
        {
            try
            {
                // Create one image provider.
                this.ImageProvider = new ImageProvider();

                Pylon.Initialize();

                /* Register for the events of the image provider needed for proper operation. */
                this.ImageProvider.GrabErrorEvent += new ImageProvider.GrabErrorEventHandler(OnGrabErrorEventCallback);
                this.ImageProvider.DeviceRemovedEvent += new ImageProvider.DeviceRemovedEventHandler(OnDeviceRemovedEventCallback);
                this.ImageProvider.DeviceOpenedEvent += new ImageProvider.DeviceOpenedEventHandler(OnDeviceOpenedEventCallback);
                this.ImageProvider.DeviceClosedEvent += new ImageProvider.DeviceClosedEventHandler(OnDeviceClosedEventCallback);
                this.ImageProvider.GrabbingStartedEvent += new ImageProvider.GrabbingStartedEventHandler(OnGrabbingStartedEventCallback);
                this.ImageProvider.ImageReadyEvent += new ImageProvider.ImageReadyEventHandler(OnImageReadyEventCallback);
                this.ImageProvider.GrabbingStoppedEvent += new ImageProvider.GrabbingStoppedEventHandler(OnGrabbingStoppedEventCallback);

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
                            this._ListaTerminales.Add(codigoTerminalIO, new OTerminalIOBaslerPylonBit(codigo, codigoTerminalIO));
                        }
                    }

                    // Creamos el thread de consulta de las E/S
                    this.ThreadScan = new OThreadLoop(this.Codigo, this.IOTiempoScanMS, ThreadPriority.BelowNormal);
                    this.ThreadScan.CrearSuscripcionRun(EventoScan, true);

                    // Se construye la lista de cámaras GigE
                    if (PrimeraInstancia)
                    {
                        // Se crea una lista de dispositivos
                        ListaDispositivos = DeviceEnumerator.EnumerateDevices();
                        PrimeraInstancia = false;
                    }

                    // Se busca la cámara con su número de serie
                    this.Existe = this.BuscarCamaraPorNumeroSerie();

                    // Creación de los parámetros internos de las cámaras
                    this.Ajustes = new OPylonGigEFeatures(this.Codigo, this.TimeOutAccesoGigEFeatures);
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " \r\nde la base de datos.");
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
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

            /* Fore each device to the list. */
            foreach (DeviceEnumerator.Device dispositivo in ListaDispositivos)
            {
                if (this._DeviceId == dispositivo.Serial)
                {
                    this.Name = dispositivo.Name;
                    this.Index = dispositivo.Index;
                    this.Serial = dispositivo.Serial;
                    this.DeviceClass = dispositivo.DeviceClass;
                    this.DeviceFactory = dispositivo.DeviceFactory;
                    this.DeviceVersion = dispositivo.DeviceVersion;
                    this.FullName = dispositivo.FullName;
                    this.ModelName = dispositivo.ModelName;
                    this.UserDefinedName = dispositivo.UserDefinedName;
                    this.VendorName = dispositivo.VendorName;

                    resultado = true;
                    break;
                }
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
                /* Open the image provider using the index from the device data. */
                this.ImageProvider.Open(this.Index);

                // Heart Bit
                this.ImageProvider.setHeartbeatTimeout(this.IntervaloComprobacionConectividadMS);

                // Inicialización de los ajustes
                this.Ajustes.Inicializar(this.ImageProvider.m_hDevice);

                // Se configuran los terminales dinamicamente
                foreach (OTerminalIOBaslerPylonBit terminalIO in this._ListaTerminales.Values)
                {
                    terminalIO.Inicializar(this.Conectividad,
                        this.Ajustes.LineSelector,
                        this.Ajustes.LineSource,
                        this.Ajustes.LineStatusAll,
                        this.Ajustes.UserOutputSelector,
                        this.Ajustes.UserOutputValue);
                }

                // Ponemos en marcha el thread de escaneo
                this.ThreadScan.Start();

                OImagen inicio = new OImagen();

                resultado = true;
            }
            catch (OCameraConectionException exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": ".ToString());
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, "Error al conectarse a la cámara " + this.Codigo + ": ".ToString());
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

                this.ImageProvider.Stop();
                if (!errorConexion)
                {
                    this.ImageProvider.Close();
                }

                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
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

                    // Acquisition configuration
                    this.Ajustes.Start();

                    /* Start the grabbing of images until grabbing is stopped. */
                    this.ImageProvider.ContinuousShot();

                    resultado = true;
                }
            }
            catch (OCameraConectionException exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": ".ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
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
                    this.ImageProvider.Stop();

                    // Se configuran los ajustes
                    this.Ajustes.Stop();

                    base.StopInterno();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
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
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.SnapInterno();

                    this.ImageProvider.OneShot(); /* Starts the grabbing of one image. */
                }
            }
            catch (OCameraConectionException exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, "Problema de conexión con la cámara " + this.Codigo + ": ".ToString());
                this.EstadoConexion = EstadoConexion.ErrorConexion;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
            return resultado;
        }

        /// <summary>
        /// Crea el objeto de conectividad adecuado para la cámara
        /// </summary>
        protected override void CrearConectividad()
        {
            // Creación de la comprobación de la conexión con la cámara Basler
            this.Conectividad = new OConectividadBaslerPylon(this.Codigo, this._DeviceId, this.IntervaloComprobacionConectividadMS);
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Handles the event related to the occurrence of an error while grabbing proceeds.
        /// </summary>
        /// <param name="grabException"></param>
        /// <param name="additionalErrorMessage"></param>
        private void OnGrabErrorEventCallback(Exception grabException, string additionalErrorMessage)
        {
            OLogsVAHardware.Camaras.Error("Error de adquisición", grabException, additionalErrorMessage);
        }

        /// <summary>
        /// Handles the event related to the removal of a currently open device.
        /// </summary>
        private void OnDeviceRemovedEventCallback()
        {
            // Se realiza la tarea asíncronamente
            //if (!OThreadManager.EjecucionEnTrheadPrincipal())
            //{
            //    OThreadManager.SincronizarConThreadPrincipal(new ImageProvider.DeviceRemovedEventHandler(OnDeviceRemovedEventCallback), null);
            //    return;
            //}

            OLogsVAHardware.Camaras.Error(this.Codigo, "Problema de conexión con la cámara " + this.Codigo);
            this.EstadoConexion = EstadoConexion.ErrorConexion;
        }

        /// <summary>
        /// Handles the event related to a device being open.
        /// </summary>
        private void OnDeviceOpenedEventCallback()
        {
            OLogsVAHardware.Camaras.Info("Pylon", "Device Opened: " + this.Codigo);
        }

        /// <summary>
        /// Handles the event related to a device being closed.
        /// </summary>
        private void OnDeviceClosedEventCallback()
        {
            OLogsVAHardware.Camaras.Info("Pylon", "Device Closed: " + this.Codigo);
        }

        /// <summary>
        /// Handles the event related to the image provider executing grabbing.
        /// </summary>
        private void OnGrabbingStartedEventCallback()
        {
            OLogsVAHardware.Camaras.Info("Pylon", "Device Grabbing Started: " + this.Codigo);
        }

        /// <summary>
        /// Handles the event related to an image having been taken and waiting for processing.
        /// </summary>
        private void OnImageReadyEventCallback()
        {
            // Se realiza la tarea asíncronamente
            //if (!OThreadManager.EjecucionEnTrheadPrincipal())
            //{
            //    OThreadManager.SincronizarConThreadPrincipal(new ImageProvider.ImageReadyEventHandler(OnImageReadyEventCallback), null);
            //    return;
            //}

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    /* Acquire the image from the image provider. */
                    ImagePylon image = this.ImageProvider.GetCurrentImage();

                    ///* Check if the image has been removed in the meantime. */
                    //if (image != null)
                    //{
                    //    /* Check if the image is compatible with the currently used bitmap. */
                    //    if (BitmapFactory.IsCompatible(this.TempBitmap, image.Width, image.Height, image.Profundidad))
                    //    {
                    //        /* Update the bitmap with the image data. */
                    //        BitmapFactory.UpdateBitmap(this.TempBitmap, image.Buffer, image.Width, image.Height, image.Profundidad);
                    //    }
                    //    else /* A new bitmap is required. */
                    //    {
                    //        BitmapFactory.CreateBitmap(out this.TempBitmap, image.Width, image.Height, image.Profundidad);
                    //        BitmapFactory.UpdateBitmap(this.TempBitmap, image.Buffer, image.Width, image.Height, image.Profundidad);
                    //    }
                    //    /* The processing of the image is done. Release the image buffer. */
                    //    this.ImageProvider.ReleaseImage();
                    //    /* The buffer can be used for the next image grabs. 
                    //     If another image is in the output queue it can be acquired now using GetCurrentImage(). */
                    //}

                    /* Check if the image has been removed in the meantime. */
                    if (image != null)
                    {
                        BitmapFactory.CreateBitmap(out this.TempBitmap, image.Width, image.Height, image.Profundidad);
                        BitmapFactory.UpdateBitmap(this.TempBitmap, image.Buffer, image.Width, image.Height, image.Profundidad);

                        /* The processing of the image is done. Release the image buffer. */
                        this.ImageProvider.ReleaseImage();
                        /* The buffer can be used for the next image grabs. 
                         If another image is in the output queue it can be acquired now using GetCurrentImage(). */
                    }

                    // Antes
                    //this.ImagenActual = new OImagenBitmap(this.Codigo);
                    //this.ImagenActual.Image = (Bitmap)this.TempBitmap.Clone(); // Ojo!! comprobar!!

                    // Comprobación de que la imagen recibida de la cámara es correcta
                    if ((this.ImagenActual.Image == null) || (this.ImagenActual.Image.Width <= 0) || (this.ImagenActual.Image.Height <= 0))
                    {
                        throw new Exception(string.Format("La imagen recibida de la cámara {0} está corrupta.", this.Codigo));
                    }

                    // Lanamos el evento de adquisición
                    this.AdquisicionCompletada(this.ImagenActual);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, this.ImageProvider.GetLastErrorMessage());
            }
        }

        /// <summary>
        /// Handles the event related to the image provider having stopped grabbing.
        /// </summary>
        private void OnGrabbingStoppedEventCallback()
        {
            OLogsVAHardware.Camaras.Info("Pylon", "Device Grabbing Stopped: " + this.Codigo);
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
                    foreach (OTerminalIOBaslerPylonBit terminalIO in this._ListaTerminales.Values)
                    {
                        terminalIO.LeerEntrada();
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
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
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }
        #endregion
    }

    #region  Clases para el acceso a los parámeteros internos de las cámaras Basler Pylon
    /// <summary>
    /// Listado de todas las caracteríticas de la cámara
    /// </summary>
    public class OPylonGigEFeatures
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de propiedades GigE
        /// </summary>
        public Dictionary<string, IPylonCamFeature> ListGigEFeatures;
        /// <summary>
        /// Código identificativo de la cámara
        /// </summary>
        private string CodCamara;
        /// <summary>
        /// Clase cognex que permite el acceso a los parámetros internos de la cámara
        /// </summary>
        public PYLON_DEVICE_HANDLE PylonDeviceHandle;
        #endregion

        #region Propiedad(es)
        // Área de interés
        private OPylonGigEIntFeature _AOIWidth;
        public OPylonGigEIntFeature AOIWidth
        {
            get
            {
                return _AOIWidth;
            }
            set
            {
                _AOIWidth = value;
                this.ListGigEFeatures.Add("Width", value);
            }
        }

        private OPylonGigEIntFeature _AOIHeight;
        public OPylonGigEIntFeature AOIHeight
        {
            get
            {
                return _AOIHeight;
            }
            set
            {
                _AOIHeight = value;
                this.ListGigEFeatures.Add("Height", value);
            }
        }

        private OPylonGigEIntFeature _AOIOffsetX;
        public OPylonGigEIntFeature AOIOffsetX
        {
            get
            {
                return _AOIOffsetX;
            }
            set
            {
                _AOIOffsetX = value;
                this.ListGigEFeatures.Add("OffsetX", value);
            }
        }

        private OPylonGigEIntFeature _AOIOffsetY;
        public OPylonGigEIntFeature AOIOffsetY
        {
            get
            {
                return _AOIOffsetY;
            }
            set
            {
                _AOIOffsetY = value;
                this.ListGigEFeatures.Add("OffsetY", value);
            }
        }

        private OPylonAOI _AOI;
        public OPylonAOI AOI
        {
            get
            {
                return _AOI;
            }
            set
            {
                _AOI = value;
                this.ListGigEFeatures.Add("AOI", value);
            }
        }
        // Configuración del Trigger
        private OPylonGigEEnumFeature _TriggerSource;
        public OPylonGigEEnumFeature TriggerSource
        {
            get
            {
                return _TriggerSource;
            }
            set
            {
                _TriggerSource = value;
                this.ListGigEFeatures.Add("TriggerSource", value);
            }
        }

        private OPylonGigEEnumFeature _TriggerMode;
        public OPylonGigEEnumFeature TriggerMode
        {
            get
            {
                return _TriggerMode;
            }
            set
            {
                _TriggerMode = value;
                this.ListGigEFeatures.Add("TriggerMode", value);
            }
        }

        private OPylonAcquisitionMode _AcquisitionMode;
        public OPylonAcquisitionMode AcquisitionMode
        {
            get
            {
                return _AcquisitionMode;
            }
            set
            {
                _AcquisitionMode = value;
                this.ListGigEFeatures.Add("AcquisitionMode", value);
            }
        }

        private OPylonGigEEnumFeature _TriggerActivation;
        public OPylonGigEEnumFeature TriggerActivation
        {
            get
            {
                return _TriggerActivation;
            }
            set
            {
                _TriggerActivation = value;
                this.ListGigEFeatures.Add("TriggerActivation", value);
            }
        }

        // Transferencia
        private OPylonGigEIntFeature _PacketSize;
        public OPylonGigEIntFeature PacketSize
        {
            get
            {
                return _PacketSize;
            }
            set
            {
                _PacketSize = value;
                this.ListGigEFeatures.Add("PacketSize", value);
            }
        }

        private OPylonGigEIntFeature _InterPacketDelay;
        public OPylonGigEIntFeature InterPacketDelay
        {
            get
            {
                return _InterPacketDelay;
            }
            set
            {
                _InterPacketDelay = value;
                this.ListGigEFeatures.Add("InterPacketDelay", value);
            }
        }

        private OPylonGigEIntFeature _ReserveBandwidth;
        public OPylonGigEIntFeature ReserveBandwidth
        {
            get
            {
                return _ReserveBandwidth;
            }
            set
            {
                _ReserveBandwidth = value;
                this.ListGigEFeatures.Add("ReserveBandwidth", value);
            }
        }

        private OPylonGigEIntFeature _TimeStampFrequency;
        public OPylonGigEIntFeature TimeStampFrequency
        {
            get
            {
                return _TimeStampFrequency;
            }
            set
            {
                _TimeStampFrequency = value;
                this.ListGigEFeatures.Add("TimeStampFrequency", value);
            }
        }

        private OPylonTransferAdjust _TransferAdjust;
        public OPylonTransferAdjust TransferAdjust
        {
            get
            {
                return _TransferAdjust;
            }
            set
            {
                _TransferAdjust = value;
                this.ListGigEFeatures.Add("TransferAdjust", value);
            }
        }

        // Iluminación
        private OPylonGigEDoubleFeature _ExposureTimeAbs;
        public OPylonGigEDoubleFeature ExposureTimeAbs
        {
            get
            {
                return _ExposureTimeAbs;
            }
            set
            {
                _ExposureTimeAbs = value;
                this.ListGigEFeatures.Add("ExposureTimeAbs", value);
            }
        }

        private OPylonGigEEnumFeature _GainAuto;
        public OPylonGigEEnumFeature GainAuto
        {
            get
            {
                return _GainAuto;
            }
            set
            {
                _GainAuto = value;
                this.ListGigEFeatures.Add("GainAuto", value);
            }
        }

        private OPylonGigEIntFeature _GainRaw;
        public OPylonGigEIntFeature GainRaw
        {
            get
            {
                return _GainRaw;
            }
            set
            {
                _GainRaw = value;
                this.ListGigEFeatures.Add("GainRaw", value);
            }
        }

        private OPylonGigEIntFeature _BlackLevelRaw;
        public OPylonGigEIntFeature BlackLevelRaw
        {
            get
            {
                return _BlackLevelRaw;
            }
            set
            {
                _BlackLevelRaw = value;
                this.ListGigEFeatures.Add("BlackLevelRaw", value);
            }
        }

        private OPylonGigEEnumFeature _BalanceRatioSelector;
        public OPylonGigEEnumFeature BalanceRatioSelector
        {
            get
            {
                return _BalanceRatioSelector;
            }
            set
            {
                _BalanceRatioSelector = value;
                this.ListGigEFeatures.Add("BalanceRatioSelector", value);
            }
        }

        private OPylonGigEIntFeature _BalanceRatioRaw;
        public OPylonGigEIntFeature BalanceRatioRaw
        {
            get
            {
                return _BalanceRatioRaw;
            }
            set
            {
                _BalanceRatioRaw = value;
                this.ListGigEFeatures.Add("BalanceRatioRaw", value);
            }
        }

        private OPylonWhiteBalance _BalanceRatioRed;
        public OPylonWhiteBalance BalanceRatioRed
        {
            get
            {
                return _BalanceRatioRed;
            }
            set
            {
                _BalanceRatioRed = value;
                this.ListGigEFeatures.Add("BalanceRatioRed", value);
            }
        }

        private OPylonWhiteBalance _BalanceRatioGreen;
        public OPylonWhiteBalance BalanceRatioGreen
        {
            get
            {
                return _BalanceRatioGreen;
            }
            set
            {
                _BalanceRatioGreen = value;
                this.ListGigEFeatures.Add("BalanceRatioGreen", value);
            }
        }

        private OPylonWhiteBalance _BalanceRatioBlue;
        public OPylonWhiteBalance BalanceRatioBlue
        {
            get
            {
                return _BalanceRatioBlue;
            }
            set
            {
                _BalanceRatioBlue = value;
                this.ListGigEFeatures.Add("BalanceRatioBlue", value);
            }
        }

        private OPylonGigEBoolFeature _GammaEnable;
        public OPylonGigEBoolFeature GammaEnable
        {
            get
            {
                return _GammaEnable;
            }
            set
            {
                _GammaEnable = value;
                this.ListGigEFeatures.Add("GammaEnable", value);
            }
        }

        private OPylonGigEDoubleFeature _Gamma;
        public OPylonGigEDoubleFeature Gamma
        {
            get
            {
                return _Gamma;
            }
            set
            {
                _Gamma = value;
                this.ListGigEFeatures.Add("Gamma", value);
            }
        }

        // Formato
        private OPylonGigEEnumFeature _PixelFormat;
        public OPylonGigEEnumFeature PixelFormat
        {
            get
            {
                return _PixelFormat;
            }
            set
            {
                _PixelFormat = value;
                this.ListGigEFeatures.Add("PixelFormat", value);
            }
        }

        // Entrada / Salida
        private OPylonGigEEnumFeature _LineSelector;
        public OPylonGigEEnumFeature LineSelector
        {
            get
            {
                return _LineSelector;
            }
            set
            {
                _LineSelector = value;
                this.ListGigEFeatures.Add("LineSelector", value);
            }
        }

        private OPylonGigEEnumFeature _LineSource;
        public OPylonGigEEnumFeature LineSource
        {
            get
            {
                return _LineSource;
            }
            set
            {
                _LineSource = value;
                this.ListGigEFeatures.Add("LineSource", value);
            }
        }

        private OPylonGigEIntFeature _LineStatusAll;
        public OPylonGigEIntFeature LineStatusAll
        {
            get
            {
                return _LineStatusAll;
            }
            set
            {
                _LineStatusAll = value;
                this.ListGigEFeatures.Add("LineStatusAll", value);
            }
        }

        private OPylonGigEEnumFeature _UserOutputSelector;
        public OPylonGigEEnumFeature UserOutputSelector
        {
            get
            {
                return _UserOutputSelector;
            }
            set
            {
                _UserOutputSelector = value;
                this.ListGigEFeatures.Add("UserOutputSelector", value);
            }
        }

        private OPylonGigEBoolFeature _UserOutputValue;
        public OPylonGigEBoolFeature UserOutputValue
        {
            get
            {
                return _UserOutputValue;
            }
            set
            {
                _UserOutputValue = value;
                this.ListGigEFeatures.Add("UserOutputValue", value);
            }
        }

        private OPylonGigEDoubleFeature _LineDebouncerTimeAbs;
        public OPylonGigEDoubleFeature LineDebouncerTimeAbs
        {
            get
            {
                return _LineDebouncerTimeAbs;
            }
            set
            {
                _LineDebouncerTimeAbs = value;
                this.ListGigEFeatures.Add("LineDebouncerTimeAbs", value);
            }
        }

        private OPylonGigEDoubleFeature _TemperatureAbs;
        public OPylonGigEDoubleFeature TemperatureAbs
        {
            get
            {
                return _TemperatureAbs;
            }
            set
            {
                _TemperatureAbs = value;
                this.ListGigEFeatures.Add("TemperatureAbs", value);
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPylonGigEFeatures(string codigo, int timeOutAccesoGigEFeatures)
        {
            this.ListGigEFeatures = new Dictionary<string, IPylonCamFeature>();

            this.CodCamara = codigo;

            try
            {
                // Área de interés
                this.AOIWidth = new OPylonGigEIntFeature("Width", 2, 10000, 2454, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_Width");
                this.AOIHeight = new OPylonGigEIntFeature("Height", 2, 10000, 2056, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_Height");
                this.AOIOffsetX = new OPylonGigEIntFeature("OffsetX", 0, 10000, 2454, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_X");
                this.AOIOffsetY = new OPylonGigEIntFeature("OffsetY", 0, 10000, 2454, timeOutAccesoGigEFeatures, false, "Basler_Pilot_AOI_Y");
                this.AOI = new OPylonAOI("AOI", this.AOIOffsetX, this.AOIOffsetY, this.AOIWidth, this.AOIHeight);
                // Configuración del Trigger
                this.TriggerSource = new OPylonGigEEnumFeature("TriggerSource", new string[] { "Line1", "Line2", "Software" }, "Line1", timeOutAccesoGigEFeatures, true, "Basler_Pilot_TriggerSource");
                this.TriggerMode = new OPylonGigEEnumFeature("TriggerMode", new string[] { "Off", "On" }, "Off", timeOutAccesoGigEFeatures, false, string.Empty);
                this.AcquisitionMode = new OPylonAcquisitionMode("AcquisitionMode", ModoAdquisicion.DisparoSoftware, this.TriggerMode, "Basler_Pilot_AcquisitionMode");
                this.TriggerActivation = new OPylonGigEEnumFeature("TriggerActivation", new string[] { "RisingEdge", "FallingEdge" }, "RisingEdge", timeOutAccesoGigEFeatures, true, "Basler_Pilot_TriggerActivation");
                // Transferencia
                this.PacketSize = new OPylonGigEIntFeature("GevSCPSPacketSize", 220, 16404, 1500, timeOutAccesoGigEFeatures, true, "Basler_Pilot_PacketSize");
                this.InterPacketDelay = new OPylonGigEIntFeature("GevSCPD", 0, 904, 0, timeOutAccesoGigEFeatures, false, string.Empty);
                this.ReserveBandwidth = new OPylonGigEIntFeature("GevSCBWR", 0, 99, 10, timeOutAccesoGigEFeatures, false, string.Empty);
                this.TimeStampFrequency = new OPylonGigEIntFeature("GevTimestampTickFrequency", 0, int.MaxValue, 0, 125000000, false, string.Empty);
                this.TransferAdjust = new OPylonTransferAdjust("TransferAdjust", 0.001, 1, 1,
                    this.ReserveBandwidth,
                    this.PacketSize,
                    this.TimeStampFrequency,
                    this.InterPacketDelay,
                    "Basler_Pilot_Bandwidth");
                // Iluminación
                this.ExposureTimeAbs = new OPylonGigEDoubleFeature("ExposureTimeAbs", 40, 818900, 400, timeOutAccesoGigEFeatures, true, "Basler_Pilot_Shutter");
                this.GainAuto = new OPylonGigEEnumFeature("GainAuto", new string[] { "Off", "Once", "Continuous" }, "Off", timeOutAccesoGigEFeatures, true, "Basler_Pilot_GainAuto");
                this.GainRaw = new OPylonGigEIntFeature("GainRaw", 0, 500, 180, timeOutAccesoGigEFeatures, true, "Basler_Pilot_Gain");
                this.BlackLevelRaw = new OPylonGigEIntFeature("BlackLevelRaw", 0, 600, 32, timeOutAccesoGigEFeatures, true, "Basler_Pilot_BlackLevel");
                this.BalanceRatioSelector = new OPylonGigEEnumFeature("BalanceRatioSelector", new string[] { "Red", "Green", "Blue" }, "Red", timeOutAccesoGigEFeatures, false, string.Empty);
                this.BalanceRatioRaw = new OPylonGigEIntFeature("BalanceRatioRaw", 0, 255, 50, timeOutAccesoGigEFeatures, false, string.Empty);
                this.BalanceRatioRed = new OPylonWhiteBalance("WhiteBalanceRed", 0, 255, 50, "Red", this.BalanceRatioRaw, this.BalanceRatioSelector, "Basler_Pilot_WhiteBalanceRed");
                this.BalanceRatioGreen = new OPylonWhiteBalance("BalanceRatioGreen", 0, 255, 50, "Green", this.BalanceRatioRaw, this.BalanceRatioSelector, "Basler_Pilot_WhiteBalanceGreen");
                this.BalanceRatioBlue = new OPylonWhiteBalance("BalanceRatioBlue", 0, 255, 50, "Blue", this.BalanceRatioRaw, this.BalanceRatioSelector, "Basler_Pilot_WhiteBalanceBlue");
                this.GammaEnable = new OPylonGigEBoolFeature("GammaEnable", false, timeOutAccesoGigEFeatures, true, "Basler_Pilot_GammaEnable");
                this.Gamma = new OPylonGigEDoubleFeature("Gamma", 0, 3.99902, 1, timeOutAccesoGigEFeatures, true, "Basler_Pilot_Gamma");
                // Formato
                this.PixelFormat = new OPylonGigEEnumFeature("PixelFormat", new string[] { "Mono8", "BayerBG8", "YUV422Packed", "YUV422_YUYV_Packed", "BayerBG12Packed", "BayerBG16" }, "Mono8", timeOutAccesoGigEFeatures, true, "Basler_Pilot_TransferFormat");
                // Entrada / Salida
                this.LineSelector = new OPylonGigEEnumFeature("LineSelector", new string[] { "Line1", "Line2", "Out1", "Out2", "Out3", "Out4" }, "Line1", 100, false, string.Empty);
                this.LineSource = new OPylonGigEEnumFeature("LineSource", new string[] { "UserOutput", "ExposureActive", "TimerActive", "TriggerReady", "AcquisitionTriggerReady" }, "UserOutput", timeOutAccesoGigEFeatures, false, string.Empty);
                this.LineStatusAll = new OPylonGigEIntFeature("LineStatusAll", 0, int.MaxValue, 0, timeOutAccesoGigEFeatures, false, string.Empty);
                this.UserOutputSelector = new OPylonGigEEnumFeature("UserOutputSelector", new string[] { "UserOutput1", "UserOutput2", "UserOutput3", "UserOutput4" }, "UserOutput1", timeOutAccesoGigEFeatures, false, string.Empty);
                this.UserOutputValue = new OPylonGigEBoolFeature("UserOutputValue", false, timeOutAccesoGigEFeatures, false, string.Empty);
                this.LineDebouncerTimeAbs = new OPylonGigEDoubleFeature("LineDebouncerTimeAbs", 0, double.MaxValue, 0, timeOutAccesoGigEFeatures, false, "Basler_Pilot_DebouncerTime");
                this.TemperatureAbs = new OPylonGigEDoubleFeature("TemperatureAbs", double.MinValue, double.MaxValue, 0, timeOutAccesoGigEFeatures, false, string.Empty);

                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(this.CodCamara);
                if (dt.Rows.Count == 1)
                {
                    foreach (KeyValuePair<string, IPylonCamFeature> pair in this.ListGigEFeatures)
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
                OLogsVAHardware.Camaras.Error(exception, this.CodCamara);
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Inicialización del acceso a los parámetros de la cámara
        /// </summary>
        /// <param name="pylonDeviceHandle"></param>
        /// <param name="frameGrabberGigE"></param>
        /// <param name="acqFifo"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
            // Asignación de los campos
            this.PylonDeviceHandle = pylonDeviceHandle;

            foreach (KeyValuePair<string, IPylonCamFeature> pair in this.ListGigEFeatures)
            {
                pair.Value.Inicializar(pylonDeviceHandle);
                pair.Value.Send(false, ModoAjuste.Inicializacion);
            }
        }
        /// <summary>
        /// Finalización del acceso a los parámetros de la cámara
        /// </summary>
        /// <param name="gigEFeatureAccess"></param>
        public void Finalizar()
        {
            foreach (KeyValuePair<string, IPylonCamFeature> pair in this.ListGigEFeatures)
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
            foreach (KeyValuePair<string, IPylonCamFeature> pair in this.ListGigEFeatures)
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
            foreach (KeyValuePair<string, IPylonCamFeature> pair in this.ListGigEFeatures)
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
            IPylonCamFeature feature;
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
            IPylonCamFeature feature;
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
    public class OPylonGigEStringFeature : OTexto, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private PYLON_DEVICE_HANDLE PylonDeviceHandle;
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
        public OPylonGigEStringFeature(string codigo, int maxLength, bool admiteVacio, bool limitarLongitud, string defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
            this.PylonDeviceHandle = pylonDeviceHandle;
            bool valid = Pylon.DeviceFeatureIsAvailable(this.PylonDeviceHandle, this.Codigo) &&
                         Pylon.DeviceFeatureIsImplemented(this.PylonDeviceHandle, this.Codigo);
            this.ValidForRead = valid && Pylon.DeviceFeatureIsReadable(this.PylonDeviceHandle, this.Codigo);
            this.ValidForWrite = valid && Pylon.DeviceFeatureIsWritable(this.PylonDeviceHandle, this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.PylonDeviceHandle != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    string strValue = (string)this.Valor;
                    string strOutValue = string.Empty;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        Pylon.DeviceFeatureFromString(this.PylonDeviceHandle, this.Codigo, strValue);
                        strOutValue = Pylon.DeviceFeatureToString(this.PylonDeviceHandle, this.Codigo);
                        ok = (strValue == strOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SetFeature:" + this.Codigo);
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
                if ((this.PylonDeviceHandle != null) && (this.ValidForRead))
                {
                    this.Valor = Pylon.DeviceFeatureToString(this.PylonDeviceHandle, this.Codigo);
                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "GetFeature:" + this.Codigo);
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
    public class OPylonGigEEnumFeature : OEnumeradoTexto, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private PYLON_DEVICE_HANDLE PylonDeviceHandle;
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
        public OPylonGigEEnumFeature(string codigo, string[] valoresPermitidos, string defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
            this.PylonDeviceHandle = pylonDeviceHandle;
            bool valid = Pylon.DeviceFeatureIsAvailable(this.PylonDeviceHandle, this.Codigo) &&
                         Pylon.DeviceFeatureIsImplemented(this.PylonDeviceHandle, this.Codigo);
            this.ValidForRead = valid && Pylon.DeviceFeatureIsReadable(this.PylonDeviceHandle, this.Codigo);
            this.ValidForWrite = valid && Pylon.DeviceFeatureIsWritable(this.PylonDeviceHandle, this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.PylonDeviceHandle != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    string strValue = (string)this.Valor;
                    string strOutValue = string.Empty;
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        Pylon.DeviceFeatureFromString(this.PylonDeviceHandle, this.Codigo, strValue);
                        strOutValue = Pylon.DeviceFeatureToString(this.PylonDeviceHandle, this.Codigo);
                        ok = (strValue == strOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SetFeature:" + this.Codigo);
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
                if (this.PylonDeviceHandle != null)
                {
                    if (this.ValidForRead)
                    {
                        this.Valor = Pylon.DeviceFeatureToString(this.PylonDeviceHandle, this.Codigo);
                        resultado = true;
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "GetFeature:" + this.Codigo);
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
    public class OPylonGigEIntFeature : OEntero, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private PYLON_DEVICE_HANDLE PylonDeviceHandle;
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
        public OPylonGigEIntFeature(string codigo, int minValue, int maxValue, int defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
            this.PylonDeviceHandle = pylonDeviceHandle;
            bool valid = Pylon.DeviceFeatureIsAvailable(this.PylonDeviceHandle, this.Codigo) &&
                         Pylon.DeviceFeatureIsImplemented(this.PylonDeviceHandle, this.Codigo);
            this.ValidForRead = valid && Pylon.DeviceFeatureIsReadable(this.PylonDeviceHandle, this.Codigo);
            this.ValidForWrite = valid && Pylon.DeviceFeatureIsWritable(this.PylonDeviceHandle, this.Codigo);
        }
        /// <summary>
        /// Aplica el parámetro a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.PylonDeviceHandle != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    long intValue = (long)this.Valor;
                    long intOutValue = default(long);
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        Pylon.DeviceSetIntegerFeature(this.PylonDeviceHandle, this.Codigo, intValue);
                        intOutValue = Pylon.DeviceGetIntegerFeature(this.PylonDeviceHandle, this.Codigo);
                        ok = (intValue == intOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SetFeature:" + this.Codigo);
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
                if (this.PylonDeviceHandle != null)
                {
                    if (this.ValidForRead)
                    {
                        this.Valor = (int)Pylon.DeviceGetIntegerFeature(this.PylonDeviceHandle, this.Codigo);
                        resultado = true;
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "GetFeature:" + this.Codigo);
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
    public class OPylonGigEDoubleFeature : ODecimal, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private PYLON_DEVICE_HANDLE PylonDeviceHandle;
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
        public OPylonGigEDoubleFeature(string codigo, double minValue, double maxValue, double defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
            this.PylonDeviceHandle = pylonDeviceHandle;
            bool valid = Pylon.DeviceFeatureIsAvailable(this.PylonDeviceHandle, this.Codigo) &&
                         Pylon.DeviceFeatureIsImplemented(this.PylonDeviceHandle, this.Codigo);
            this.ValidForRead = valid && Pylon.DeviceFeatureIsReadable(this.PylonDeviceHandle, this.Codigo);
            this.ValidForWrite = valid && Pylon.DeviceFeatureIsWritable(this.PylonDeviceHandle, this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.PylonDeviceHandle != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    double doubleValue = (double)this.Valor;
                    double doubleOutValue = default(double);
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        Pylon.DeviceSetFloatFeature(this.PylonDeviceHandle, this.Codigo, doubleValue);
                        doubleOutValue = Pylon.DeviceGetFloatFeature(this.PylonDeviceHandle, this.Codigo);
                        ok = ODecimal.EnTolerancia(doubleValue, doubleOutValue, 0.01);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SetFeature:" + this.Codigo);
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
                if ((this.PylonDeviceHandle != null) && (this.ValidForRead))
                {
                    this.Valor = Pylon.DeviceGetFloatFeature(this.PylonDeviceHandle, this.Codigo);
                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "GetFeature:" + this.Codigo);
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
    public class OPylonGigEBoolFeature : OBooleano, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Clase cognex para el acceso a los parámetros de la cámara
        /// </summary>
        private PYLON_DEVICE_HANDLE PylonDeviceHandle;
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
        public OPylonGigEBoolFeature(string codigo, bool defaultValue, int timeOutMilis, bool accesoDirecto, string nombreColumna)
            : base(codigo, defaultValue, false)
        {
            this.TimeOut = timeOutMilis;
            this.AccesoDirecto = accesoDirecto;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
            this.PylonDeviceHandle = pylonDeviceHandle;
            bool valid = Pylon.DeviceFeatureIsAvailable(this.PylonDeviceHandle, this.Codigo) &&
                         Pylon.DeviceFeatureIsImplemented(this.PylonDeviceHandle, this.Codigo);
            this.ValidForRead = valid && Pylon.DeviceFeatureIsReadable(this.PylonDeviceHandle, this.Codigo);
            this.ValidForWrite = valid && Pylon.DeviceFeatureIsWritable(this.PylonDeviceHandle, this.Codigo);
        }
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        public bool Send(bool force, ModoAjuste modoAjuste)
        {
            bool resultado = false;

            try
            {
                if ((this.PylonDeviceHandle != null) && this.ValidForWrite && (this.AccesoDirecto || force) && ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion)))
                {
                    bool boolValue = (bool)this.Valor;
                    bool boolOutValue = default(bool);
                    bool ok = false;

                    OThreadManager.Espera(delegate()
                    {
                        Pylon.DeviceSetBooleanFeature(this.PylonDeviceHandle, this.Codigo, boolValue);
                        boolOutValue = Pylon.DeviceGetBooleanFeature(this.PylonDeviceHandle, this.Codigo);
                        ok = (boolValue == boolOutValue);
                        return ok;
                    }, this.TimeOut);
                    resultado = ok;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SetFeature:" + this.Codigo);
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
                if (this.PylonDeviceHandle != null)
                {
                    if (this.ValidForRead)
                    {
                        this.Valor = Pylon.DeviceGetBooleanFeature(this.PylonDeviceHandle, this.Codigo);
                        resultado = true;
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "GetFeature:" + this.Codigo);
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
    /// Clase utilizada para modificar el modo de trigger
    /// </summary>
    public class OPylonAcquisitionMode : OEnumerado<ModoAdquisicion>, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Propiedad del modo de disparo de la cámara
        /// </summary>
        private IPylonCamFeature FeatureTriggerMode;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPylonAcquisitionMode(string codigo, ModoAdquisicion defaultValue, IPylonCamFeature featureTriggerMode, string nombreColumna)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
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
                switch (modoAjuste)
                {
                    case ModoAjuste.Inicializacion:
                    case ModoAjuste.Stop:
                    case ModoAjuste.Finalizacion:
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
                        break;
                }
                resultado = this.FeatureTriggerMode.Send(true, ModoAjuste.Ejecucion);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SendFeature:" + this.Codigo);
            }

            return resultado;
        }
        /// <summary>
        /// Consulta el valor de la cámara y lo guarda en memoria
        /// </summary>
        public bool Receive()
        {
            // No hay comando de recepción
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
    public class OPylonWhiteBalance : OEntero, IPylonCamFeature
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
        private IPylonCamFeature FeatureBalanceRatio;
        /// <summary>
        /// Propiedad del balance de blancos
        /// </summary>
        private IPylonCamFeature FeatureBalanceRatioSelector;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPylonWhiteBalance(string codigo, int minValor, int maxValor, int valorDefecto, string color, IPylonCamFeature featureBalanceRatio, IPylonCamFeature featureBalanceRatioSelector, string nombreColumna)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
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
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SendFeature:" + this.Codigo);
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
                OLogsVAHardware.Camaras.Error(exception, "ReceiveFeature:" + this.Codigo);
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
    public class OPylonAOI : OObjetoBase<Rectangle>, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Propiedad del AOI X
        /// </summary>
        private IPylonCamFeature FeatureOffsetX;
        /// <summary>
        /// Propiedad del AOI Y
        /// </summary>
        private IPylonCamFeature FeatureOffsetY;
        /// <summary>
        /// Propiedad del AOI Width
        /// </summary>
        private IPylonCamFeature FeatureWidth;
        /// <summary>
        /// Propiedad del AOI Height
        /// </summary>
        private IPylonCamFeature FeatureHeight;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPylonAOI(string codigo, IPylonCamFeature featureOffsetX, IPylonCamFeature featureOffsetY, IPylonCamFeature featureWidth, IPylonCamFeature featureHeight)
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
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
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
                    this.Valor = new Rectangle((int)this.FeatureOffsetX.ValorGenerico, (int)this.FeatureOffsetY.ValorGenerico, (int)this.FeatureWidth.ValorGenerico, (int)this.FeatureHeight.ValorGenerico);

                    // Envio de valores mínimos
                    this.FeatureOffsetX.ValorGenerico = 0;
                    this.FeatureOffsetX.Send(true, modoAjuste);
                    this.FeatureOffsetY.ValorGenerico = 0;
                    this.FeatureOffsetY.Send(true, modoAjuste);

                    // Envio de parámetros
                    this.FeatureWidth.Send(true, modoAjuste);
                    this.FeatureHeight.Send(true, modoAjuste);
                    this.FeatureOffsetX.ValorGenerico = this.Valor.X;
                    this.FeatureOffsetX.Send(true, modoAjuste);
                    this.FeatureOffsetY.ValorGenerico = this.Valor.Y;
                    this.FeatureOffsetY.Send(true, modoAjuste);

                    resultado = true;
                }
            }
            catch (COMException)
            {
                throw new OCameraConectionException();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SendFeature:" + this.Codigo);
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
                OLogsVAHardware.Camaras.Error(exception, "ReceiveFeature:" + this.Codigo);
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
    public class OPylonTransferAdjust : ODecimal, IPylonCamFeature
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        private string NombreColumna;
        /// <summary>
        /// Propiedad del ancho de banda utilizado
        /// </summary>
        private IPylonCamFeature FeatureReserveBandwidth;
        /// <summary>
        /// Propiedad del tamaño de la trama de comunicación
        /// </summary>
        private IPylonCamFeature FeaturePacketSize;
        /// <summary>
        /// Propiedad de la frecuencia del reloj interno
        /// </summary>
        private IPylonCamFeature FeatureTimeStampFrequency;
        /// <summary>
        /// Propiedad del tiempo de espera entre paquetes
        /// </summary>
        private IPylonCamFeature FeatureInterPacketDelay;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPylonTransferAdjust(string codigo, double minValor, double maxValor, double valorDefecto, IPylonCamFeature featureReserveBandwidth, IPylonCamFeature featurePacketSize, IPylonCamFeature featureTimeStampFrequency, IPylonCamFeature featureInterPacketDelay, string nombreColumna)
            : base(codigo, minValor, maxValor, valorDefecto, false)
        {
            this.FeatureReserveBandwidth = featureReserveBandwidth;
            this.FeaturePacketSize = featurePacketSize;
            this.FeatureTimeStampFrequency = featureTimeStampFrequency;
            this.FeatureInterPacketDelay = featureInterPacketDelay;
            this.NombreColumna = nombreColumna;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización del objeto
        /// </summary>
        /// <param name="pylonDeviceHandle"></param>
        public void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle)
        {
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
                if ((modoAjuste == ModoAjuste.Inicializacion) || (modoAjuste == ModoAjuste.Ejecucion))
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
                    this.FeatureTimeStampFrequency.Receive();
                    int timeStampFreq = (int)this.FeatureTimeStampFrequency.ValorGenerico;

                    int delay = (int)(delaySec * timeStampFreq);
                    this.FeatureInterPacketDelay.ValorGenerico = delay;
                    resultado = this.FeatureInterPacketDelay.Send(true, modoAjuste);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "SendBandwidth");
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
    /// Acceso a una característica de la cámara Pylon
    /// </summary>
    public interface IPylonCamFeature : ICamFeature, IObjetoBase
    {
        #region Método(s)
        /// <summary>
        /// Aplica el valor de memoria a la cámara
        /// </summary>
        void Inicializar(PYLON_DEVICE_HANDLE pylonDeviceHandle);
        #endregion
    }
    #endregion

    #region Terminales de Entrada/Salida
    /// <summary>
    /// Terminal de tipo bit que simboliza un bit de un puerto
    /// </summary>
    internal class OTerminalIOBaslerPylonBit : OTerminalIOBase
    {
        #region Atributo(s)
        /// <summary>
        /// Cámara perteneciente
        /// </summary>
        OConectividad Conectividad;
        /// <summary>
        /// Selector del termial
        /// </summary>
        private OPylonGigEEnumFeature FeatureLineSelector;
        /// <summary>
        /// Tipo de terminal
        /// </summary>
        private OPylonGigEEnumFeature FeatureLineSource;
        /// <summary>
        /// Estado de los terminales (activados o desactivados)
        /// </summary>
        private OPylonGigEIntFeature FeatureLineStatusAll;
        /// <summary>
        /// Selector de salida de usuario
        /// </summary>
        private OPylonGigEEnumFeature FeatureUserOutputSelector;
        /// <summary>
        /// Valor de salida
        /// </summary>
        private OPylonGigEBoolFeature FeatureUserOutputValue;
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
        public OTerminalIOBaslerPylonBit(string codTarjetaIO, string codTerminalIO)
            : base(codTarjetaIO, codTerminalIO)
        {
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a heredar donde se inicializan los terminales
        /// </summary>
        public new void Inicializar(OConectividad conectividad, OPylonGigEEnumFeature lineSelector, OPylonGigEEnumFeature lineSource, OPylonGigEIntFeature lineStatusAll, OPylonGigEEnumFeature userOutputSelector, OPylonGigEBoolFeature userOutputValue)
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
                    this.FeatureLineSelector.Send(true, ModoAjuste.Ejecucion);

                    this.FeatureLineSource.Valor = "UserOutput";
                    this.FeatureLineSource.Send(true, ModoAjuste.Ejecucion);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
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
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
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

                            this.FeatureUserOutputValue.Valor = boolValor;
                            this.FeatureUserOutputValue.Send(true, ModoAjuste.Ejecucion);
                        }
                        this.Valor = boolValor;
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodTarjeta);
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
