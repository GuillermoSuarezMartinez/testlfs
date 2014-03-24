//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 03-02-2012
//
// Last Modified By : aibañez
// Last Modified On : 13-12-2013
// Description      : Solucionada excepción al abrir el fichero de video con multihilo
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using AForge.Video.FFMPEG;

namespace Orbita.VA.Comun
{
    /// <summary>
    /// Clase utilizada para cargar y guardar videos de disco
    /// </summary>
	public class OVideoFile
	{
        #region Atributo(s)
        /// <summary>
        /// Thread de consumición de imagenes para guardado en disco
        /// </summary>
        private OProductorConsumidorThread<OImagen> ThreadConsumidor;

        /// <summary>
        /// Escritor de ficheros AVI
        /// </summary>
        private VideoFileWriter AVIWriter;

        /// <summary>
        /// Crónometro de la duración de la grabación
        /// </summary>
        private Stopwatch CronometroDuracion;

        /// <summary>
        /// Momento exacto de la realización de la primera captura del video.
        /// Se utiliza la diferencia de tiempo de las capturas con respecto a la primera para espaciar el video.
        /// </summary>
        private DateTime MomentoPrimeraCaptura;

        /// <summary>
        /// Momento exacto de la última captura realizada.
        /// Se utiliza la diferencia de tiempo con la última captura para verificar si se cumple el FrameRate.
        /// Si está por debajo del FrameRate especificado la imagen se desprecia
        /// </summary>
        private DateTime MomentoAnteriorCaptura;

        /// <summary>
        /// Bloqueo de la escritura del video
        /// </summary>
        private static object LockAvi = new object();

        /// <summary>
        /// Indica al thread de codificación de video que se ha de crear un nuevo archivo
        /// </summary>
        private bool CrearVideo = false;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la clase.
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Ruta del archivo a guardar
        /// </summary>
        private string _Ruta;
        /// <summary>
        /// Ruta del archivo a guardar
        /// </summary>
        public string Ruta
        {
            get { return _Ruta; }
            set 
            { 
                this._Ruta = value;

                try
                {
                    string dir = Path.GetDirectoryName(value);
                    this._Valido = Path.IsPathRooted(dir);
                }
                catch (Exception exception)
                {
                    OLogsVAComun.Multimedia.Error(exception, "Consultar la validez de la ruta: ", this.Codigo);
                }
            }
        }

        /// <summary>
        /// Duración máxima de la grabación
        /// </summary>
        private TimeSpan _TiempoMaxGrabacion;
        /// <summary>
        /// Duración máxima de la grabación
        /// </summary>
        public TimeSpan TiempoMaxGrabacion
        {
            get { return _TiempoMaxGrabacion; }
            set { _TiempoMaxGrabacion = value; }
        }

        /// <summary>
        /// Indica el tamaño de la imagen a guardar
        /// </summary>
        private Size _Resolucion;
        /// <summary>
        /// Indica el tamaño de la imagen a guardar
        /// </summary>
        public Size Resolucion
        {
            get { return _Resolucion; }
            set { _Resolucion = value; }
        }

        /// <summary>
        /// Informa si la grabación está preparda para realizarse
        /// </summary>
        private bool _Valido;
        /// <summary>
        /// Informa si la grabación está preparda para realizarse
        /// </summary>
        public bool Valido
        {
            get { return _Valido; }
        }

        /// <summary>
        /// Intervalo entre capturas
        /// </summary>
        private TimeSpan _FrameInterval;
        /// <summary>
        /// Intervalo entre capturas
        /// </summary>
        public TimeSpan FrameInterval
        {
            get { return _FrameInterval; }
            set { _FrameInterval = value; }
        }

        /// <summary>
        /// Intervalo entre capturas
        /// </summary>
        public int FrameRate
        {
            get { return (int)Math.Ceiling(1000 / FrameInterval.TotalMilliseconds); }
        }

        /// <summary>
        /// Tasa de transferencia
        /// </summary>
        private int _BitRate;
        /// <summary>
        /// Tasa de transferencia
        /// </summary>
        public int BitRate
        {
            get { return _BitRate; }
            set { _BitRate = value; }
        }
        
        /// <summary>
        /// Codec utilizado para la codificación del video
        /// </summary>
        private OVideoCodec _Codec;
        /// <summary>
        /// Codec utilizado para la codificación del video
        /// </summary>
        public OVideoCodec Codec
        {
            get { return _Codec; }
            set { _Codec = value; }
        }
        
        /// <summary>
        /// Estado de la ejecución de la grabación de video
        /// </summary>
        public EstadoProductorConsumidor Estado
        {
            get 
            {
                if (this.ThreadConsumidor != null)
                {
                    return this.ThreadConsumidor.Estado; 
        }
                return EstadoProductorConsumidor.Detenido;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OVideoFile(string codigo, Size resolucion, TimeSpan tiempoMaxGrabacion, double frameIntervalMs, int bitRate, OVideoCodec codec)
        {
            this.Codigo = codigo;
            this._TiempoMaxGrabacion = tiempoMaxGrabacion;
            this.Resolucion = resolucion;
            frameIntervalMs = frameIntervalMs == 0 ? 1 : frameIntervalMs;
            this.FrameInterval = TimeSpan.FromMilliseconds(frameIntervalMs);
            this.Codec = codec;
            this.BitRate = bitRate;
            this.MomentoPrimeraCaptura = DateTime.Now;
            this.MomentoAnteriorCaptura = DateTime.Now;

            this.CronometroDuracion = new Stopwatch();
            this.AVIWriter = new VideoFileWriter();

            int tiempoSleep = (int)Math.Ceiling(frameIntervalMs / 2);
            this.ThreadConsumidor = new OProductorConsumidorThread<OImagen>(codigo, 1, tiempoSleep, ThreadPriority.Lowest, 20);
            this.ThreadConsumidor.CrearSuscripcionConsumidor(this.ConsumidorRun, true);
            this.ThreadConsumidor.CrearSuscripcionMonitorizacion(this.Monitorizacion, true);
            this.ThreadConsumidor.CrearSuscripcionFin(this.FinEjecucion, true);
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Añade una imagen a la cola de guardado del video
        /// </summary>
        /// <param name="imagen">Imagen a añadir al video</param>
        /// <returns>Verdadero si se ha podido añadir la imagen al video</returns>
        public bool Add(OImagen imagen)
        {
            bool resultado = false;

            if (((this.Estado == EstadoProductorConsumidor.EnEjecucion) || (this.Estado == EstadoProductorConsumidor.Pausado)) && (imagen is OImagen))
            {
                DateTime momentoCapturaActual = imagen.MomentoCreacion;
                bool primeraCaptura = this.ThreadConsumidor.Total == 0;

                // Si se cumple el tiempo del frame rate especificado
                if (primeraCaptura)
                {
                    // Guardo el momento actual de captura
                    this.MomentoPrimeraCaptura = momentoCapturaActual;
                    resultado = true;
                }
                else
                {
                    TimeSpan difAnteriorCaptura = momentoCapturaActual - this.MomentoAnteriorCaptura;
                    if (difAnteriorCaptura > this.FrameInterval)
                    {
                        resultado = true;
                    }
                }

                if (resultado)
                {
                    // Guardo el momento actual de captura
                    this.MomentoAnteriorCaptura = momentoCapturaActual;

                    // Se procede al encolamiento de la imagen
                    OImagen imagenAux = imagen;
                    if ((this.Resolucion.Width != imagen.Width) || (this.Resolucion.Height != imagen.Height))
                    {
                        imagenAux = imagen.EscalarImagen(imagen, this.Resolucion.Width, this.Resolucion.Height);
                    }
                    else // NUEVO: Se hace un clon de la imagen antes de guardarla en la cola
                    {
                        imagenAux = (OImagen)imagen.Clone();
                    }
                    resultado = this.ThreadConsumidor.Encolar(imagenAux);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Inicia el guardado del video
        /// </summary>
        public bool Start()
        {
            bool resultado = false;

            try
            {
                if ((this.Estado == EstadoProductorConsumidor.Detenido) &&
                    this.Valido)
                {
                    this.CrearVideo = true;

                    this.CronometroDuracion.Reset();
                    this.CronometroDuracion.Start();
                    this.ThreadConsumidor.Start();

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Multimedia.Error(exception, "Inicio de la grabación de video: " + this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Inicia el guardado del video de forma pausada
        /// </summary>
        public bool StartPaused()
        {
            bool resultado = false;

            try
            {
                if ((this.Estado == EstadoProductorConsumidor.Detenido) &&
                    this.Valido)
                {
                    this.CrearVideo = true;

                    this.CronometroDuracion.Reset();
                    this.ThreadConsumidor.StartPaused();

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Multimedia.Error(exception, "Inicio pausado de la grabación de video: " + this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Reanuda la generación del video
        /// </summary>
        public bool Resume()
        {
            bool resultado = false;

            try
            {
                if ((this.Estado == EstadoProductorConsumidor.Pausado) &&
                    this.Valido)
                {
                    this.CronometroDuracion.Start();
                    this.ThreadConsumidor.Resume();

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Multimedia.Error(exception, "Reanudación de la grabación de video: " + this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Finaliza el guardado del video
        /// </summary>
        public void Stop()
        {
            try
            {
                if ((this.Estado == EstadoProductorConsumidor.EnEjecucion) || (this.Estado == EstadoProductorConsumidor.Pausado))
                {
                    this.ThreadConsumidor.Stop();
                }
            }
            catch (Exception exception)
            {
                OLogsVAComun.Multimedia.Error(exception, "Fin de la grabación de video: " + this.Codigo);
            }
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Ejecución del consumidor
        /// </summary>
        private void ConsumidorRun(OImagen valor)
        {
            try
            {
                if (this.CrearVideo)
                {
                    this.CrearVideo = false;
                    lock (LockAvi)
                    {
                        if (this.AVIWriter != null)
                        {
                            if (this.AVIWriter.IsOpen)
                            {
                                this.AVIWriter.Close();
                            }
                            this.AVIWriter.Dispose();
                            this.AVIWriter = null;
                        }
                        this.AVIWriter = new VideoFileWriter();

                        this.AVIWriter.Open(this._Ruta, this.Resolucion.Width, this.Resolucion.Height, this.FrameRate, (VideoCodec)this.Codec, this.BitRate);
                        if (!this.AVIWriter.IsOpen)
                        {
                            OLogsVAComun.Multimedia.Warn("Imposible crear el archivo de video");
                        }
                        else
                        {
                            OLogsVAComun.Multimedia.Warn("Archivo de video creado");
                        }
                    }
                }


                // Diferencia de tiempo entre la primera captura y la actual
                TimeSpan difTiempo = valor.MomentoCreacion - this.MomentoPrimeraCaptura;

                // Adición del nuevo frame
                lock (LockAvi)
                {
                    if (this.AVIWriter.IsOpen)
                    {
                        Bitmap bmp = valor.ConvertToBitmap();
                        this.AVIWriter.WriteVideoFrame(bmp, difTiempo);
                    }
                    else
                    {
                        OLogsVAComun.Multimedia.Warn("Se ha intentado añadir un frame a un fichero de video no abierto");
                    }
                } 
            }
            catch (Exception exception)
            {
                OLogsVAComun.Multimedia.Warn(exception, "Añadir Frame al video: " + this.Codigo);
            }
        }

        /// <summary>
        /// Monitorización de la ejecución
        /// </summary>
        /// <param name="finalize"></param>
        private void Monitorizacion(ref bool finalize)
        {
            finalize = false;

            if (((this.Estado == EstadoProductorConsumidor.Deteniendo) && (this.ThreadConsumidor.Count == 0)) || 
                (this.CronometroDuracion.Elapsed > this._TiempoMaxGrabacion))
            {
                finalize = true;
            }
        }

        /// <summary>
        /// Fin de la ejecución del consumidor
        /// </summary>
        private void FinEjecucion()
        {
            try
            {
                lock (LockAvi)
                {
                    if (this.AVIWriter.IsOpen)
                    {
                        this.AVIWriter.Close();
                        if (this.AVIWriter.IsOpen)
                        {
                            OLogsVAComun.Multimedia.Warn("Archivo de video no cerrado");
                        }
                        else
                        {
                            OLogsVAComun.Multimedia.Info("Archivo de video cerrado");
                        }
                    }
                }
                this.ThreadConsumidor.Clear();
                this.CronometroDuracion.Stop();
            }
            catch (Exception exception)
            {
                OLogsVAComun.Multimedia.Info(exception, "Guardado en disco del video: " + this.Codigo);
            }
        }
        #endregion
	}

    // Resumen:
    //     Enumeration of some video codecs from FFmpeg library, which are available
    //     for writing video files.
    public enum OVideoCodec
    {
        // Resumen:
        //     Default video codec, which FFmpeg library selects for the specified file
        //     format.
        Default = -1,
        //
        // Resumen:
        //     MPEG-4 part 2.
        MPEG4 = 0,
        //
        // Resumen:
        //     Windows Media Video 7.
        WMV1 = 1,
        //
        // Resumen:
        //     Windows Media Video 8.
        WMV2 = 2,
        //
        // Resumen:
        //     MPEG-4 part 2 Microsoft variant version 2.
        MSMPEG4v2 = 3,
        //
        // Resumen:
        //     MPEG-4 part 2 Microsoft variant version 3.
        MSMPEG4v3 = 4,
        //
        // Resumen:
        //     H.263+ / H.263-1998 / H.263 version 2.
        H263P = 5,
        //
        // Resumen:
        //     Flash Video (FLV) / Sorenson Spark / Sorenson H.263.
        FLV1 = 6,
        //
        // Resumen:
        //     MPEG-2 part 2.
        MPEG2 = 7,
        //
        // Resumen:
        //     Raw (uncompressed) video.
        Raw = 8,
    }

}
