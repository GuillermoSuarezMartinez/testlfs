//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : fhernandez
// Created          : 13-05-2013
//
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Orbita.VA.Comun;
using cm;
using Orbita.Utiles;
using gx;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática que manejará la librería CARMEN de reconocimiento de matrículas
    /// </summary>
    public static class OMTInterfaceARH
    {
        #region Constantes
        /// <summary>
        /// Numero máximo de imagenes en cola
        /// </summary>
        private const int MAX_QUEUE = 100;
        #endregion

        #region Campos
        /// <summary>
        /// Motor de reconocimiento de CARMEN
        /// </summary>
        private static cmAccr Accr;
        /// <summary>
        /// Variable que nos indicará que esta en proceso
        /// </summary>
        private static bool ACCRIsRunning;
        /// <summary>
        /// Si esta activo el Log
        /// </summary>
        private static bool ActivoLog;       
        /// <summary>
        /// Cola que contiene los resultados
        /// </summary>
        private static Queue<OPair<OARHCodeInfo,OARHData>> ColaDeResultados;
        /// <summary>
        /// Lista de threads de ejecución
        /// </summary>
        private static OHilos HilosEjecucion;
        /// <summary>
        /// Clase que gestionara la añadición y ejecución de resultados
        /// </summary>
        private static OProductorConsumidorThread<OARHData> ProductorConsumidor;
        /// <summary>
        /// Objeto bloqueante
        /// </summary>
        private static object LockObject;
        #endregion        

        #region Métodos Públicos
        /// <summary>
        /// Inicializamos el motor de busqueda
        /// </summary>
        /// <param name="AvCharHeight"></param>
        /// <param name="DuplicateLines"></param>
        /// <param name="Trace"></param>
        /// <param name="traceWrapper"></param>
        /// <returns></returns>
        public static int Init(bool traceWrapper, uint numThreads)
        {
            try
            {
                // Indicamos si se almacenaran los logs
                if (traceWrapper)
                {
                    ActivoLog = true;
                }

                // Si ya esta en funcionamiento no hacemos nada
                if (ACCRIsRunning)
                {
                    return 0;
                }

                // Creamos el modulo 
                Accr = new cmAccr();

                // Reseteamos el modulo de busqueda
                Accr.Reset();

                // Indicamos que el motor esta en funcionamiento
                ACCRIsRunning = true;
                
                // Creamos las colas y pilas
                ColaDeResultados = new Queue<OPair<OARHCodeInfo,OARHData>>();

                LockObject = new object();

                ProductorConsumidor = new OProductorConsumidorThread<OARHData>("ARH PC", numThreads, 1, ThreadPriority.Normal, MAX_QUEUE);
                ProductorConsumidor.CrearSuscripcionConsumidor(EjecutarConsumidor, true);
                ProductorConsumidor.Start();
                               
                if (traceWrapper)
                {
                    //LogsRuntime.Info(ModulosFunciones.OCRContainer, "OCR ARH", "Inicializado correctamente el motor ACCR");
                    OLogsVAFunciones.ARH.Info("Inicializado correctamente el motor ARH");
                }
            }
            catch (Exception exception)
            {
                //LogsRuntime.Error(ModulosFunciones.OCRContainer, "OCR ARH", "Inicializando el motor ACCR:" + exception.ToString());
                OLogsVAFunciones.ARH.Error(exception, "Inicializando el motor ARH");
                
                return 0;
            }
            return 1;
        }
        /// <summary>
        /// Finaliza el motor de búsqueda
        /// </summary>
        /// <returns></returns>
        public static bool QueryEnd()
        {
            try
            {
                HilosEjecucion.Suspender();
                HilosEjecucion.Destruir();
                HilosEjecucion = null;
                ColaDeResultados.Clear();
                ColaDeResultados = null;
                ProductorConsumidor.Clear();
                ProductorConsumidor.Dispose();
                ACCRIsRunning = false;
                Accr.Dispose();
                GC.Collect();
                return true;
            }
            catch (Exception exception)
            {
                //LogsRuntime.Error(ModulosFunciones.OCRContainer, "OCR ARH", "Finalizando el motor ACCR:" + exception.ToString());
                OLogsVAFunciones.ARH.Error(exception, "Finalizando el motor ARH");
                return false;
            }
        }
        /// <summary>
        /// Resetea las colas
        /// </summary>
        /// <returns></returns>
        public static int Reset()
        {
            try
            {
                HilosEjecucion.Suspender();
                HilosEjecucion.Destruir();
                HilosEjecucion = null;
                ColaDeResultados.Clear();
                ColaDeResultados = null;
                ProductorConsumidor.Clear();
                GC.Collect();
                return 1;
            }
            catch (Exception exception)
            {
                //LogsRuntime.Error(ModulosFunciones.OCRContainer, "OCR ARH", "Reseteando el motor ACCR:" + exception.ToString());
                OLogsVAFunciones.ARH.Error(exception, "Reseteando el motor ARH");
                return 0;
            }
        }
        /// <summary>
        /// Resetea las colas
        /// </summary>
        /// <returns></returns>
        public static void SetConfiguracion(OParametrosARH param)
        {
            try
            {
                if (param.bAplicarCorreccion)
                {
                    Accr.SetProperty("size_min", param.size_min);
                    Accr.SetProperty("size_max", param.size_max);
                    Accr.SetProperty("timeout", param.timeout);
                    Accr.SetProperty("slope_min", param.slope_min);
                    Accr.SetProperty("slope_max", param.slope_max);
                    Accr.SetProperty("slant", param.slant);
                    Accr.SetProperty("xtoyres", param.xtoyres);
                    Accr.SetProperty("isocode", Convert.ToInt16(param.isocode));
                }
            }
            catch (Exception exception)
            {
                //LogsRuntime.Error(ModulosFunciones.OCRContainer, "OCR ARH", "Estableciendo configuración del motor ACCR:" + exception.ToString());
                OLogsVAFunciones.ARH.Error(exception, "Reseteando el motor ARH");
            }
        }
        /// <summary>
        /// Devuelve si el motor esta activo
        /// </summary>
        /// <returns></returns>
        public static bool IsRunning()
        {
            return ACCRIsRunning;
        }
        /// <summary>
        /// Devuelve la cantidad de imagenes en la cola
        /// </summary>
        /// <returns></returns>
        public static int GetQueueSize()
        {
            try
            {
                return ProductorConsumidor.Count;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception, "Obteniendo cantidad de elementos en cola");
                return 0;
            }
        }
        /// <summary>
        /// Devuelve la cantidad de imagenes en la cola
        /// </summary>
        /// <returns></returns>
        public static OPair<OARHCodeInfo, OARHData> GetResultado()
        {
            OPair<OARHCodeInfo, OARHData> result = new OPair<OARHCodeInfo, OARHData>();
            try
            {
                lock (LockObject)
                {
                    if (ColaDeResultados.Count > 0)
                    {
                        result = ColaDeResultados.Dequeue();
                        return result;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception, "Obteniendo resultado");
                return null;
            }
        }
         /// <summary>
        /// <summary>
        /// Añade una imagen para su reconocimiento
        /// </summary>
        /// <param name="bitmap">imagen</param>
        /// <param name="obj">información de la imagen</param>
        /// <param name="bFront">Si es prioritaria</param>
        public static bool Add(object bitmap, object obj, bool bFront = false)
        {
            try
            {
                if (!ACCRIsRunning | (GetQueueSize() > MAX_QUEUE))
                {
                    return false;
                }

                if (bFront)
                {
                    ProductorConsumidor.Encolar(new OARHData(bitmap, obj),-1);                   
                }
                else
                {
                    ProductorConsumidor.Encolar(new OARHData(bitmap, obj));
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception, "Añadiendo imagen a la cola");
                return false;
            }
            return true;
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Método que ejecuta la acción del consumidor.
        /// </summary>
        /// <param name="valor"></param>
        public static void EjecutarConsumidor(OARHData valor)
        {
            try
            {
                if (valor != null)
                {
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    // Reset the container module
                    Accr.Reset();
                    // Creates the image object
                    using (gxImage image = new gxImage("default"))
                    {
                        if (valor.Imagen is string)
                        {
                            image.Load(valor.Imagen.ToString());
                        }
                        else
                        {
                            if ((valor.Imagen is Bitmap) && valor.Imagen != null)
                            {
                                MemoryStream ms = new MemoryStream();
                                ((Bitmap)valor.Imagen).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                                byte[] bmpBytes = ms.GetBuffer();
                                image.LoadFromMem(bmpBytes, (int)GX_IMGFILEFORMATS.GX_JPEG);
                                ((Bitmap)valor.Imagen).Dispose();
                                ms.Close();
                            }
                        }
                        if (image.IsValid())
                        {
                            // Add image to the module
                            Accr.AddImage(image, 0);
                            // Inspecciona la imagen
                            bool ejecutado = Accr.ReadPublicCode();

                            sw.Stop();

                            // Obtenemos el resultado
                            int tproceso = Convert.ToInt32(sw.ElapsedMilliseconds);
                            string codigo = string.Empty;
                            float fiab = 0;
                            float altura = 0;
                            string iso = string.Empty;
                            int verifica = 0;
                            if (Accr.IsValid())
                            {
                                codigo = Accr.GetCode();
                                fiab = Accr.GetConfidence();
                                gxPG4 caracter = Accr.GetCharFrame(0, 0);
                                altura = caracter.y4 - caracter.y1;
                                if (codigo.Length == 15)
                                {
                                    iso = codigo.Substring(11, 4);
                                    codigo = codigo.Substring(0, 11);
                                }
                                try
                                {
                                    verifica = Accr.ChecksumIsValid();
                                }
                                catch
                                {
                                }
                            }
                            OARHCodeInfo resultado = new OARHCodeInfo(codigo, tproceso, altura, fiab, iso, verifica, DateTime.Now);
                            lock (LockObject)
                            {
                                ColaDeResultados.Enqueue(new OPair<OARHCodeInfo, OARHData>(resultado, valor));
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception, "Procesando la cola de ARH");
            }
        }
        #endregion

    }

    #region Clases y estructuras utilizadas
    /// <summary>
    /// Clase de resultados
    /// </summary>
    public class OARHCodeInfo : IDisposable
    {
        #region Campos
        /// <summary>
        /// Altura en pixeles
        /// </summary>
        private float averageCharHeigth;
        /// <summary>
        /// Código
        /// </summary>
        private string code;
        /// <summary>
        /// Calidad
        /// </summary>
        private float confidence;
        /// <summary>
        /// Disposed
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// Código ISO
        /// </summary>
        private string extraCode;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        private int processingTime;
        /// <summary>
        ///  Verificado
        /// </summary>
        private int verificado;
        /// <summary>
        /// Fecha 
        /// </summary>
        private DateTime fecha;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="ccode"></param>
        /// <param name="ptime"></param>
        /// <param name="averageCharHeigth"></param>
        /// <param name="fia"></param>
        /// <param name="eInfo"></param>
        public OARHCodeInfo(string ccode,int ptime, float averageCharHeigth,float fia, string eInfo,int veri,DateTime fech)
        {
            this.code = ccode;
            this.confidence = fia;
            this.processingTime = ptime;
            this.extraCode = eInfo;
            this.averageCharHeigth = averageCharHeigth;
            this.verificado = veri;
            this.fecha = fech;
        }       
        #endregion

        #region Interfaz Idisposable
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.code = null;
                this.confidence = 0f;
                this.averageCharHeigth = 0f;
                this.processingTime = 0;
                this.extraCode = null;
            }
            this.disposed = true;
        }

        protected void Finalize()
        {
            this.Dispose(false);
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Obtiene la fecha
        /// </summary>
        public DateTime GetDate
        {
            get
            {
                return this.fecha;
            }
        }
        /// <summary>
        /// Obtiene la altura Media en pixeles del caracter
        /// </summary>
        public float GetAverageCharacterHeigth
        {
            get
            {
                return this.averageCharHeigth;
            }
        }
        /// <summary>
        /// Obtiene el código 
        /// </summary>
        public string GetCodeNumber
        {
            get
            {
                return this.code;
            }
        }
        /// <summary>
        /// Obtiene la fiabilidad 
        /// </summary>
        public float GetConfidence
        {
            get
            {
                return this.confidence;
            }
        }
        /// <summary>
        /// Obtiene el código ISO
        /// </summary>
        public string GetExtraInfoCodeNumber
        {
            get
            {
                return this.extraCode;
            }
        }        
        /// <summary>
        /// Obtiene el tiempo de proceso
        /// </summary>     
        public int GetProcessingTime
        {
            get
            {
                return this.processingTime;
            }
        }
        /// <summary>
        /// Obtiene si ha sido verificado el código
        /// </summary>     
        public int IsVerificated
        {
            get
            {
                return this.verificado;
            }
        }
    }
    #endregion

    /// <summary>
    /// Dato pasado al motor para su proceso
    /// </summary>
    public class OARHData : IDisposable
    {
        #region Campos
        /// <summary>
        ///  Imagen a inspección
        /// </summary>
        public object Imagen;
        /// <summary>
        /// Información asociada a la imagen
        /// </summary>
        public object Info;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OARHData()
        {
            Imagen = null;
            Info = new object();
        }
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="imagen">imagen</param>
        /// <param name="info">información de la imagen</param>

        public OARHData(object imagen,object info)
        {
            if (imagen is Bitmap)
            {
                Imagen = ((Bitmap)imagen).Clone();
            }
            else
            {
                Imagen = imagen;
            }
            Info = info;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Interfaz dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~OARHData()
        {
            Dispose(false);
        }
        /// <summary>
        /// Derived classes need to override this appropriately
        /// </summary>
        /// <param name="disposing">Indicates whether this is a dispose call
        /// or a call invoked from the finalzier</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Imagen = null;
                Info = null;
            }
        }

        #endregion
    }
    /// <summary>
    /// Estructura de configuración del sistema
    /// </summary>
    public class OParametrosARH
    {
        /// <summary>
        /// Utilizar ajuste
        /// </summary>
        public bool bAplicarCorreccion;
        public int size_min;
        public int size_max;
        public int slope_min;
        public int slope_max;
        public int slant;
        public int xtoyres;
        public int checksum;
        public bool FilterLongCodes;
        public bool isocode;
        public int timeout;

        public OParametrosARH(bool aplicarC, int s_min, int s_max, int sl_min, int sl_max, int slt, int xtoy, int check, bool filterLongCodes, bool lookisocode, int timeo)
        {
            bAplicarCorreccion = aplicarC;
            size_min = s_min;
            size_max = s_max;
            slope_min = sl_min;
            slope_max = sl_max;
            slant = slt;
            xtoyres = xtoy;
            checksum = check;
            FilterLongCodes = filterLongCodes;
            isocode = lookisocode;
            timeout = timeo;
        }
        public OParametrosARH()
        {
            bAplicarCorreccion = false;
            size_min = 0;
            size_max = 0;
            slope_min = 0;
            slope_max = 0;
            slant = 0;
            xtoyres = 0;
            checksum = 0;
            FilterLongCodes = true;
            isocode = true;
            timeout = 0;
        }
    }    
    #endregion
    
}
