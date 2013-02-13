//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 05-11-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// MJPEGSource - MJPEG stream support
    /// </summary>
    internal class MJPEGSource : IVideoSource
    {
        #region Constante(s)
        /// <summary>
        /// Tamaño del buffer
        /// </summary>
        private const int bufSize = 512 * 1024;	// buffer size

        /// <summary>
        /// Tamaño de la lectura
        /// </summary>
        private const int readSize = 1024;		// portion size to read
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Thread de captura de datos
        /// </summary>
        private Thread thread = null;

        /// <summary>
        /// Evento de stop del thread de captura de datos
        /// </summary>
        private ManualResetEvent stopEvent = null;

        /// <summary>
        /// Evento de recarga del thread de captura de datos
        /// </summary>
        private ManualResetEvent reloadEvent = null;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Cadena de conexión con el origen del video
        /// </summary>
        private string Source;
        /// <summary>
        /// VideoSource property
        /// </summary>
        public string VideoSource
        {
            get { return Source; }
            set
            {
                Source = value;
                // signal to reload
                if (thread != null)
                    reloadEvent.Set();
            }
        }

        /// <summary>
        /// Usuario
        /// </summary>
        private string _Login = null;
        /// <summary>
        /// Login property
        /// </summary>
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        /// <summary>
        /// Constraseña
        /// </summary>
        private string _Password = null;
        /// <summary>
        /// Password property
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Frames
        /// </summary>
        private int _FramesReceived;
        /// <summary>
        /// FramesReceived property
        /// </summary>
        public int FramesReceived
        {
            get
            {
                int frames = _FramesReceived;
                _FramesReceived = 0;
                return frames;
            }
        }

        /// <summary>
        /// Bytes recibidos
        /// </summary>
        private int _BytesReceived;
        /// <summary>
        /// BytesReceived property
        /// </summary>
        public int BytesReceived
        {
            get
            {
                int bytes = _BytesReceived;
                _BytesReceived = 0;
                return bytes;
            }
        }

        /// <summary>
        /// Datos del usuario
        /// </summary>
        private object _UserData = null;
        /// <summary>
        /// UserData property
        /// </summary>
        public object UserData
        {
            get { return _UserData; }
            set { _UserData = value; }
        }

        /// <summary>
        /// Get state of the video source thread
        /// </summary>
        public bool Running
        {
            get
            {
                if (thread != null)
                {
                    if (thread.Join(0) == false)
                        return true;

                    // the thread is not running, so free resources
                    Free();
                }
                return false;
            }
        }

        /// <summary>
        /// Timeout en milisegundos de la lectura
        /// </summary>
        private int _ReadTimeOutMs = 1000;
        /// <summary>
        /// Timeout en milisegundos de la lectura
        /// </summary>
        public int ReadTimeOutMs
        {
            get { return _ReadTimeOutMs; }
            set { _ReadTimeOutMs = value; }
        }

        /// <summary>
        /// Uso de grupo de conexión separada
        /// </summary>
        private bool _SeparateConnectionGroup = true;
        /// <summary>
        /// SeparateConnectioGroup property indicates to open WebRequest in separate connection group
        /// </summary>
        public bool SeparateConnectionGroup
        {
            get { return _SeparateConnectionGroup; }
            set { _SeparateConnectionGroup = value; }
        }

        /// <summary>
        /// Indica el número de fotografías a realizar.
        /// -1 indica que no hay limite
        /// </summary>
        private int _MaxNumFrames = -1;
        /// <summary>
        /// Indica el número de fotografías a realizar.
        /// -1 indica que no hay limite
        /// </summary>
        public int MaxNumFrames
        {
            get { return _MaxNumFrames; }
            set { _MaxNumFrames = value; }
        }
        #endregion

        #region Definicion(es) de evento(s)
        /// <summary>
        /// Evento de nuevo frame
        /// </summary>
        public event CameraEventHandler NewFrame;

        /// <summary>
        /// Error de adquisición
        /// </summary>
        public event CameraErrorEventHandler OnCameraError;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor
        /// </summary>
        public MJPEGSource()
        {
        } 
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Start work
        /// </summary>
        public void Start()
        {
            if ((thread == null) || (thread.ThreadState == ThreadState.Stopped))
            {
                _FramesReceived = 0;
                _BytesReceived = 0;

                // create events
                stopEvent = new ManualResetEvent(false);
                reloadEvent = new ManualResetEvent(false);

                // create and start new thread
                thread = new Thread(new ThreadStart(WorkerThread));
                thread.Name = Source;
                thread.Start();
            }
        }

        /// <summary>
        /// Signal thread to stop work
        /// </summary>
        public void SignalToStop()
        {
            // stop thread
            if (thread != null)
            {
                // signal to stop
                stopEvent.Set();
            }
        }

        /// <summary>
        /// Wait for thread stop
        /// </summary>
        public void WaitForStop()
        {
            if (thread != null)
            {
                // wait for thread stop
                //thread.Join();
                bool cerrado = false;
                while (!cerrado)
                {
                    cerrado = this.thread.Join(10);
                    Application.DoEvents();
                }

                Free();
            }
        }

        /// <summary>
        /// Abort thread
        /// </summary>
        public void Stop()
        {
            if (this.Running)
            {
                thread.Abort();
                WaitForStop();
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Thread entry point
        /// </summary>
        private void WorkerThread()
        {
            byte[] buffer = new byte[bufSize];	// buffer to read stream

            OComunicacionCGI comunicacionCGI = new OComunicacionCGI(this.Source, this._Login, this._Password, this.GetHashCode().ToString(), this._SeparateConnectionGroup, this._ReadTimeOutMs);

            // Salida por número de capturas máxima superada
            bool forzarSalida = false;
            this._FramesReceived = 0;
            while (!forzarSalida)
            {
                try
                {
                    // reset reload event
                    reloadEvent.Reset();

                    byte[] delimiter = null;
                    byte[] delimiter2 = null;
                    byte[] boundary = null;
                    int boundaryLen, delimiterLen = 0, delimiter2Len = 0;
                    int read, todo = 0, total = 0, pos = 0, align = 1;
                    int start = 0, stop = 0;

                    // align
                    //  1 = searching for image start
                    //  2 = searching for image end
                    try
                    {
                        if (!comunicacionCGI.Start())
                            throw new ApplicationException("Invalid URL");

                        if (comunicacionCGI.TipoContenido != OComunicacionCGI.TipoContenidoRespuestaCGI.MultipartXMixedReplace)
                            throw new ApplicationException("Invalid CGI response format");

                        boundary = comunicacionCGI.Delimitador;
                        boundaryLen = boundary.Length;
                        if (boundaryLen == 0)
                            throw new ApplicationException("Invalid boundary");

                        // loop
                        while ((!stopEvent.WaitOne(0, true)) && (!reloadEvent.WaitOne(0, true)) && (!forzarSalida))
                        {
                            // check total read
                            if (total > bufSize - readSize)
                            {
                                total = pos = todo = 0;
                            }

                            // read next portion from stream
                            if ((read = comunicacionCGI.Stream.Read(buffer, total, readSize)) == 0)
                                throw new ApplicationException();

                            total += read;
                            todo += read;

                            // increment received bytes counter
                            _BytesReceived += read;

                            // does we know the delimiter ?
                            if (delimiter == null)
                            {
                                // find boundary
                                pos = ByteArrayUtils.Find(buffer, boundary, pos, todo);

                                if (pos == -1)
                                {
                                    // was not found
                                    todo = boundaryLen - 1;
                                    pos = total - todo;
                                    continue;
                                }

                                todo = total - pos;

                                if (todo < 2)
                                    continue;

                                // check new line delimiter type
                                if (buffer[pos + boundaryLen] == 10)
                                {
                                    delimiterLen = 2;
                                    delimiter = new byte[2] { 10, 10 };
                                    delimiter2Len = 1;
                                    delimiter2 = new byte[1] { 10 };
                                }
                                else
                                {
                                    delimiterLen = 4;
                                    delimiter = new byte[4] { 13, 10, 13, 10 };
                                    delimiter2Len = 2;
                                    delimiter2 = new byte[2] { 13, 10 };
                                }

                                pos += boundaryLen + delimiter2Len;
                                todo = total - pos;
                            }

                            // search for image
                            if (align == 1)
                            {
                                start = ByteArrayUtils.Find(buffer, delimiter, pos, todo);
                                if (start != -1)
                                {
                                    // found delimiter
                                    start += delimiterLen;
                                    pos = start;
                                    todo = total - pos;
                                    align = 2;
                                }
                                else
                                {
                                    // delimiter not found
                                    todo = delimiterLen - 1;
                                    pos = total - todo;
                                }
                            }

                            // search for image end
                            while ((align == 2) && (todo >= boundaryLen) && (!forzarSalida))
                            {
                                stop = ByteArrayUtils.Find(buffer, boundary, pos, todo);
                                if (stop != -1)
                                {
                                    pos = stop;
                                    todo = total - pos;

                                    // increment frames counter
                                    _FramesReceived++;

                                    // image at stop
                                    if (NewFrame != null)
                                    {
                                        MemoryStream memStream = new MemoryStream(buffer, start, stop - start);
                                        Bitmap bmp = (Bitmap)Bitmap.FromStream(memStream);
                                        // notify client
                                        NewFrame(this, new CameraEventArgs(bmp));
                                        // release the image
                                        bmp.Dispose();
                                        bmp = null;
                                    }

                                    // Evaluación de salida por número máximo de fotos superado
                                    if ((this._MaxNumFrames > 0) && (this._FramesReceived >= this._MaxNumFrames))
                                    {
                                        forzarSalida = true;
                                    }

                                    // shift array
                                    pos = stop + boundaryLen;
                                    todo = total - pos;
                                    Array.Copy(buffer, pos, buffer, 0, todo);

                                    total = todo;
                                    pos = 0;
                                    align = 1;
                                }
                                else
                                {
                                    // delimiter not found
                                    todo = boundaryLen - 1;
                                    pos = total - todo;
                                }
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        OVALogsManager.Info(ModulosHardware.Camaras, "Thread de MJPG", ex);
                        // wait for a while before the next try
                        Thread.Sleep(250);
                    }
                    catch (ApplicationException ex)
                    {
                        OVALogsManager.Info(ModulosHardware.Camaras, "Thread de MJPG", ex);
                        // wait for a while before the next try
                        Thread.Sleep(250);
                    }
                    catch (ThreadAbortException ex)
                    {
                    }
                    catch (Exception ex)
                    {
                        OVALogsManager.Info(ModulosHardware.Camaras, "Thread de MJPG", ex);
                    }
                    finally
                    {
                        // abort request
                        if (comunicacionCGI != null)
                        {
                            comunicacionCGI.Stop();
                        }
                    }

                    // need to stop ?
                    if (stopEvent.WaitOne(0, true))
                        break;
                }
                catch (Exception ex)
                {
                    OVALogsManager.Info(ModulosHardware.Camaras, "Thread de MJPG", ex);
                }
            }
        }
        
        /// <summary>
        /// Free resources
        /// </summary>
        private void Free()
        {
            thread = null;

            // release events
            stopEvent.Close();
            stopEvent = null;
            reloadEvent.Close();
            reloadEvent = null;
        }

        /// <summary>
        /// Lanza el evetno de error
        /// </summary>
        /// <param name="exception"></param>
        private void LanzarError(Exception exception)
        {
            if (this.OnCameraError != null)
            {
                CameraErrorEventArgs cameraErrorEventArgs = new CameraErrorEventArgs(exception);
                this.OnCameraError(this, cameraErrorEventArgs);
            }
        }
        #endregion
    }
}