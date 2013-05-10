//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 05-11-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Heredado de la clase CamaraBitmap
//                    Modificada la forma de conexión desconexión
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Data;
using System.Drawing;
using System.Net;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase que implementa las funciones de manejo de la cámara IP
    /// </summary>
    public class OCamaraIP : OCamaraBitmap
    {
        #region Contante(s)
        public const int TimeOutPrimeraConexionMs = 20000;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Dirección URL original del grab
        /// </summary>
        protected string URLOriginal;
        /// <summary>
        /// Dirección URL del grab
        /// </summary>
        protected string URL;
        /// <summary>
        /// Dirección IP de la cámara
        /// </summary>
        protected IPAddress IP;
        /// <summary>
        /// Puerto de conexión con la cámara
        /// </summary>
        protected int Puerto;
        /// <summary>
        /// Usuario para el acceso a la cámara
        /// </summary>
        protected string Usuario;
        /// <summary>
        /// Contraseña para el acceso a la cámara
        /// </summary>
        protected string Contraseña;
        /// <summary>
        /// Fuente de video
        /// </summary>
        private IVideoSource VideoSource;
        /// <summary>
        /// Inervalo entre comprobaciones de conectividad con la cámara IP
        /// </summary>
        protected int IntervaloComprobacionConectividadMS;
        /// <summary>
        /// Timepo máximo de comunicación CGI
        /// </summary>
        protected int TimeOutCGIMS;
        #endregion

        #region Constructor(es)
       /// <summary>
        /// Constructor de la clase
        /// </summary>        
        public OCamaraIP(string codigo)
            : base(codigo)
        {
            try
            {
                // No hay ninguna imagen adquirida
                this.HayNuevaImagen = false;

                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(codigo);
                if (dt.Rows.Count == 1)
                {
                    this.IP = IPAddress.Parse(dt.Rows[0]["IPCam_IP"].ToString());
                    this.Puerto = OEntero.Validar(dt.Rows[0]["IPCam_Puerto"], 0, int.MaxValue, 80);
                    this.Usuario = dt.Rows[0]["IPCam_Usuario"].ToString();
                    this.Contraseña = dt.Rows[0]["IPCam_Contraseña"].ToString();
                    this.URLOriginal = dt.Rows[0]["IPCam_URL"].ToString();
                    this.IntervaloComprobacionConectividadMS = OEntero.Validar(dt.Rows[0]["IPCam_IntervaloComprobacionConectividadMS"], 1, int.MaxValue, 100);
                    this.TimeOutCGIMS = OEntero.Validar(dt.Rows[0]["IPCam_TimeOutCGIMS"], 1, int.MaxValue, 1000);

                    // Construcción de la url
                    this.URL = this.ComponerURL(this.URLOriginal);

                    // Creación del vido source
                    string strVideoSource = dt.Rows[0]["IPCam_OrigenVideo"].ToString();
                    TipoOrigenVideo tipoOrigenVideo = OEnumerado<TipoOrigenVideo>.Validar(strVideoSource, TipoOrigenVideo.JPG);
                    switch (tipoOrigenVideo)
                    {
                        case TipoOrigenVideo.MJPG:
                            this.VideoSource = new MJPEGSource();
                            break;
                        case TipoOrigenVideo.JPG:
                        default:
                            this.VideoSource = new JPEGSource();
                            break;
                    }

                    this.Existe = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
            }
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Compone la dirección url a partir de una url con comodines
        /// </summary>
        /// <param name="url">Dirección url con comodines</param>
        /// <returns></returns>
        protected virtual string ComponerURL(string url)
        {
            // Construcción de la url del Grab
            url = OTexto.Reemplazar(url, @"%IPCam_IP%", this.IP.ToString(), StringComparison.OrdinalIgnoreCase);
            url = OTexto.Reemplazar(url, @"%IPCam_Puerto%", this.Puerto.ToString(), StringComparison.OrdinalIgnoreCase);
            url = OTexto.Reemplazar(url, @"%IPCam_Usuario%", this.Usuario, StringComparison.OrdinalIgnoreCase);
            url = OTexto.Reemplazar(url, @"%IPCam_Contraseña%", this.Contraseña, StringComparison.OrdinalIgnoreCase);
            url = OTexto.Reemplazar(url, @"%ResolucionX%", this.Resolucion.Width.ToString(), StringComparison.OrdinalIgnoreCase);
            url = OTexto.Reemplazar(url, @"%ResolucionY%", this.Resolucion.Height.ToString(), StringComparison.OrdinalIgnoreCase);
            int fps = (int)Math.Ceiling(this.ExpectedFrameRate);
            url = OTexto.Reemplazar(url, @"%FrameIntervalMs%", fps.ToString(), StringComparison.OrdinalIgnoreCase);
            url = OTexto.Reemplazar(url, @"%fps%", fps.ToString(), StringComparison.OrdinalIgnoreCase);
            return url;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Se toma el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool ConectarInterno(bool reconexion)
        {
            bool resultado = base.ConectarInterno(reconexion);
            try
            {
                // Parametrización del videosource
                this.VideoSource.Login = this.Usuario;
                this.VideoSource.Password = this.Contraseña;
                this.VideoSource.VideoSource = this.URL;
                this.VideoSource.ReadTimeOutMs = this.TimeOutCGIMS;

                // Detengo videosource actual
                this.VideoSource.SignalToStop();
                OThreadManager.Espera(delegate() { return !this.VideoSource.Running; }, 1000);
                this.VideoSource.Stop();

                // Nos suscribimos a la recepción de imágenes de la cámara
                this.VideoSource.NewFrame += this.ImagenAdquirida;
                this.VideoSource.OnCameraError += ErrorAdquisicion;

                // Debido a que la primera conexión CGI tiene una duración superior a lo normal, 
                // realizamos una conexión/desconexión simple para evitar problemas de timeouts vencidos
                // durante el proceso de trabajo normal con el CGI
                OComunicacionCGIDummy dummy = new OComunicacionCGIDummy(this.URL, this.Usuario, this.Contraseña, "dummy", true, TimeOutPrimeraConexionMs, HttpStatusCode.NoContent);
                dummy.Ejecuta();

                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
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
                // Nos dessuscribimos a la recepción de imágenes de la cámara
                this.VideoSource.NewFrame -= this.ImagenAdquirida;
                this.VideoSource.OnCameraError -= ErrorAdquisicion;

                // Detengo videosource actual
                this.VideoSource.SignalToStop();
                OThreadManager.Espera(delegate() { return !this.VideoSource.Running; }, 1000);
                this.VideoSource.Stop();

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

                    this.HayNuevaImagen = false;
                    this.VideoSource.MaxNumFrames = -1;
                    this.VideoSource.Start();

                    resultado = true;
                }
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
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    // Detengo videosource actual
                    this.VideoSource.SignalToStop();
                    OThreadManager.Espera(delegate() { return !this.VideoSource.Running; }, 1000);
                    this.VideoSource.Stop();

                    base.StopInterno();

                    resultado = true;
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
                    resultado = base.SnapInterno();

                    // Verificamos que la cámara está preparada para adquirir la imagen
                    if (this.VideoSource.Running)
                    {
                        OLogsVAHardware.Camaras.Debug(this.Codigo, "La cámara no está preparada para adquirir imágenes");
                        return false;
                    }

                    this.HayNuevaImagen = false;
                    this.VideoSource.MaxNumFrames = 1;
                    this.VideoSource.Start();

                    resultado = true;
                }

                return resultado;
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
            // Creación de la comprobación de la conexión con la cámara IP
            this.Conectividad = new OConectividadIP(this.IP, this.IntervaloComprobacionConectividadMS);
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento de recepción de nueva imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagenAdquirida(object sender, CameraEventArgs e)
        {
            try
            {
                // Se realiza la tarea asíncronamente
                //if (!OThreadManager.EjecucionEnTrheadPrincipal())
                //{
                    //OThreadManager.SincronizarConThreadPrincipal(new CameraEventHandler(this.ImagenAdquirida), new object[] { sender, e });
                    //return;
                //}

                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    this.ImagenActual = new OImagenBitmap(this.Codigo, e.Bitmap);
                    this.HayNuevaImagen = true;

                    // Lanamos el evento de adquisición
                    this.AdquisicionCompletada(this.ImagenActual);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Evento de recepción de nueva imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorAdquisicion(object sender, CameraErrorEventArgs e)
        {
            this.EstadoConexion = EstadoConexion.ErrorConexion;
        }
        #endregion

        #region Evento(s) heredado(s)
        /// <summary>
        /// Evento de error en la conexión con la cámara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnCambioEstadoConectividadCamara(string codigo, EstadoConexion estadoConexionActual, EstadoConexion estadoConexionAnterior)
        {
            try
            {
                // Se realiza la tarea asíncronamente
                //if (!OThreadManager.EjecucionEnTrheadPrincipal())
                //{
                //    OThreadManager.SincronizarConThreadPrincipal(new DelegadoCambioEstadoConexionCamara(this.OnCambioEstadoConectividadCamara), new object[] {codigo, estadoConexionActal, estadoConexionAnterior});
                //    return;
                //}
                base.OnCambioEstadoConectividadCamara(codigo, estadoConexionActual, estadoConexionAnterior);

                if ((estadoConexionActual == EstadoConexion.Reconectado) && (estadoConexionAnterior == EstadoConexion.Reconectando))
                {
                    this.Conectar(true);
                }
                else 
                if ((estadoConexionActual == EstadoConexion.ErrorConexion) && (estadoConexionAnterior == EstadoConexion.Conectado))
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
}
