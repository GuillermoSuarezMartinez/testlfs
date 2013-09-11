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
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática que manejará la librería CIDAR de reconocimiento de matrículas
    /// </summary>
    public static class OMTInterfaceCCR
    {
        #region Constantes
        /// <summary>
        /// Numero máximo de imagenes en cola para ser procesador
        /// </summary>
        private const int MAX_QUEUE = 100;
        #endregion

        #region Campos
        /// <summary>
        /// Recepción del resultado por parte de cidarmt.dll
        /// </summary>
        private static CidarCallback CidarMtCallbackResult;
        /// <summary>
        /// Variable que nos indicará que esta en proceso
        /// </summary>
        private static bool CIDARIsRunning;
        /// <summary>
        /// Cola que contiene los resultados
        /// </summary>
        private static Queue<OPair<OCCRCodeInfo, OCCRData>> ColaDeResultados;
        /// <summary>
        /// Clase que gestionara la añadición y ejecución de resultados
        /// </summary>
        private static OProductorConsumidorThread<OCCRData> ProductorConsumidor;
        /// <summary>
        /// Elementos enviados al motor, para poder asociar con los resultados
        /// </summary>
        private static Dictionary<long, OCCRData> ElementosEnviados;
        /// <summary>
        /// Objeto bloqueante
        /// </summary>
        private static object LockObject = new object();
        /// <summary>
        /// Parametros de configuracion del motor
        /// </summary> 
        private static CIDARMtConfiguration Configuracion;
        /// <summary>
        /// Contador de identificación
        /// </summary>
        private static long ContId;
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Inicializa el wraper
        /// </summary>
        public static void Inicializar()
        {
            // Asociamos él metodo de recepción
            CidarMtCallbackResult = new CidarCallback(CallbackResultFunction);
            // Creamos las colas , pilas y diccionarios
            ColaDeResultados = new Queue<OPair<OCCRCodeInfo, OCCRData>>();
            ElementosEnviados = new Dictionary<long, OCCRData>();
            ProductorConsumidor = new OProductorConsumidorThread<OCCRData>("CIDAR PC", 1, 1, ThreadPriority.Normal, MAX_QUEUE);
            ProductorConsumidor.CrearSuscripcionConsumidor(EjecutarConsumidor, true);
            ProductorConsumidor.Start();
            CIDARIsRunning = false;
        }
        /// <summary>
        /// Finaliza el wrapper
        /// </summary>
        public static void Finalizar()
        {
            ColaDeResultados = null;
            ProductorConsumidor.Dispose();
            ElementosEnviados = null;
        }
        /// <summary>
        /// Inicializamos el motor de busqueda
        /// </summary>
        /// <param name="AvCharHeight"></param>
        /// <param name="DuplicateLines"></param>
        /// <param name="Trace"></param>
        /// <param name="numThreads"></param>
        /// <returns></returns>
        public static int Init(int AvCharHeight, int DuplicateLines, int Trace, uint numThreads)
        {
            try
            {
                // Si ya esta en funcionamiento no hacemos nada
                if (!CIDARIsRunning)
                {
                    // INICIAMOS EL MOTOR cidarmt.dll
                    if (cidarmtInit(CidarMtCallbackResult, AvCharHeight, DuplicateLines, Trace) == 1)
                    {
                        // Inicializamos el contador
                        ContId = 0;

                        // Indicamos que el motor esta en funcionamiento
                        CIDARIsRunning = true;
                        OLogsVAFunciones.CCR.Info("CCR", "Inicializado correctamente el motor CIDAR");
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Inicializando el motor CCR:" + exception.ToString());
                return -1;
            }
        }
        /// <summary>
        /// Finaliza el motor de búsqueda
        /// </summary>
        /// <returns></returns>
        public static bool QueryEnd()
        {
            try
            {
                ColaDeResultados.Clear();
                ProductorConsumidor.Clear();
                ElementosEnviados.Clear();
                cidarmtEnd();
                CIDARIsRunning = false;
                GC.Collect();
                return true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Finalizando el motor CCR:" + exception.ToString());
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
                ColaDeResultados.Clear();
                ProductorConsumidor.Clear();
                ElementosEnviados.Clear();
                GC.Collect();
                return 1;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Reseteando el wrapper CCR:" + exception.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Resetea las colas
        /// </summary>
        /// <returns></returns>
        public static int Reset(string codFuncion)
        {
            try
            {
                lock (LockObject)
                {
                    var nuevo = ElementosEnviados.Where(kvp => kvp.Value.GetCodFuncion == codFuncion).ToArray();
                    if ((nuevo != null) && (nuevo.Count() > 0))
                    {
                        foreach (var valor in nuevo)
                        {
                            long ident = valor.Key;
                            bool borrarFicheroTemporal = valor.Value.ImageInformation.GetAutoBorradoFicheroTemporal;
                            string rutaFicheroTemporal = valor.Value.ImageInformation.GetPath;
                            ElementosEnviados.Remove(ident);
                            if (borrarFicheroTemporal)
                            {
                                ONerualLabsUtils.EliminarFicheroTemporal(rutaFicheroTemporal);
                            }
                        }
                    }
                    GC.Collect();
                }
                return 1;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Reseteando el motor CCR:" + exception.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Establece la configuración
        /// </summary>
        /// <returns></returns>
        public static void SetConfiguracion(OParametrosCCR param)
        {
            try
            {
                lock (LockObject)
                {
                    Configuracion.vlSteps = new int[8];
                    Configuracion.bAplicarCorreccion = param.ActivadaAjusteCorreccion;
                    Configuracion.bEnableExtraInfo = param.ActivadaMasInformacion;
                    Configuracion.fAngle = param.AnguloRotacion;
                    Configuracion.fDistance = param.Distancia;
                    Configuracion.fHorizontalCoeff = param.CoeficienteHorizontal;
                    Configuracion.fVerticalCoeff = param.CoeficienteVertical;
                    Configuracion.fRadialCoeff = param.CoeficienteRadial;
                    Configuracion.lHeight = param.AlturaVentanaBusqueda;
                    Configuracion.lLeft = param.CoordIzq;
                    Configuracion.lMiliseconds = param.TimeOut;
                    Configuracion.lTop = param.CoordArriba;
                    Configuracion.lWidth = param.AnchuraVentanaBusqueda;
                    Configuracion.lNumSteps = param.VectorAlturas.Length;
                    Configuracion.fScale = param.Escala;
                    Configuracion.lUserParam1 = param.Param1;
                    Configuracion.lUserParam2 = param.Param2;
                    if (param.VectorAlturas.Length > 0)
                    {
                        int num = param.VectorAlturas.Length - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            Configuracion.vlSteps[i] = param.VectorAlturas[i];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Estableciendo configuración del motor CCR:" + exception.ToString());
            }
        }
        /// <summary>
        /// Devuelve si el motor esta activo
        /// </summary>
        /// <returns></returns>
        public static bool IsRunning()
        {
            return CIDARIsRunning;
        }
        /// <summary>
        /// Devuelve la cantidad de imagenes en la cola del wrapper
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
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Obteniendo cantidad de elementos en cola:" + exception.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Devuelve la cantidad de imagenes en la cola del wrapper para una determinada funcion
        /// </summary>
        /// <returns></returns>
        public static int GetQueueSize(string codFunc)
        {
            try
            {
                int cantidad = 0;
                lock (LockObject)
                {
                    foreach (KeyValuePair<long, OCCRData> elemento in ElementosEnviados)
                    {
                        // do something with entry.Value or entry.Key
                        OCCRData datos = elemento.Value;
                        long ident = elemento.Key;
                        if (datos.GetCodFuncion == codFunc)
                        {
                            cantidad++;
                        }
                    }
                }
                return cantidad;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Obteniendo cantidad de elementos en cola:" + exception.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Devuelve un resultado de la cola
        /// </summary>
        /// <returns></returns>
        public static OPair<OCCRCodeInfo, OCCRData> GetResultado()
        {
            OPair<OCCRCodeInfo, OCCRData> result = new OPair<OCCRCodeInfo, OCCRData>();
            try
            {
                lock (LockObject)
                {
                    if (ColaDeResultados != null && ColaDeResultados.Count > 0)
                    {
                        result = ColaDeResultados.Dequeue();
                        return result;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Obteniendo resultado:" + exception.ToString());
                return null;
            }
        }
        /// <summary>
        /// Añade una imagen para su reconocimiento
        /// </summary>
        /// <param name="bitmap">imagen</param>
        /// <param name="obj">información de la imagen</param>
        /// <param name="bFront">Si es prioritaria</param>
        public static bool Add(string codFunc,Bitmap bitmap, object obj, bool bFront)
        {
            try
            {
                lock (LockObject)
                {
                    // Si hemos superaado el tamaño de la cola no la incluimos
                    if (!CIDARIsRunning | (GetQueueSize() > MAX_QUEUE))
                    {
                        return false;
                    }

                    OCCRInfoImagen informacion = new OCCRInfoImagen(bitmap, string.Empty, false, ref obj);

                    // Establece la prioridad en la cola para la imagen
                    if (bFront)
                    {
                        ProductorConsumidor.Encolar(new OCCRData(ContId, codFunc, Configuracion, ref informacion), -1);
                    }
                    else
                    {
                        ProductorConsumidor.Encolar(new OCCRData(ContId, codFunc, Configuracion, ref informacion));
                    }

                    // Incrementamos el contador
                    ContId++;
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Añadiendo imagen a la cola:" + exception.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// Añade una imagen para su reconocimiento por ruta
        /// </summary>
        /// <param name="rutaBitmap">imagen</param>
        /// <param name="obj">información de la imagen</param>
        /// <param name="bFront">Si es prioritaria</param>
        public static bool Add(string codFunc, string rutaBitmap, bool autoBorradoFicheroTemporal, object obj, bool bFront)
        {
            try
            {
                lock (LockObject)
                {
                    // Si hemos superaado el tamaño de la cola no la incluimos
                    if (!CIDARIsRunning | (GetQueueSize() > MAX_QUEUE))
                    {
                        return false;
                    }

                    OCCRInfoImagen informacion = new OCCRInfoImagen(null, rutaBitmap, autoBorradoFicheroTemporal, ref obj);

                    // Establece la prioridad en la cola para la imagen
                    if (bFront)
                    {
                        ProductorConsumidor.Encolar(new OCCRData(ContId, codFunc, Configuracion, ref informacion), -1);
                    }
                    else
                    {
                        ProductorConsumidor.Encolar(new OCCRData(ContId, codFunc, Configuracion, ref informacion));
                    }

                    // Incrementamos el contador
                    ContId++;
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Añadiendo imagen a la cola:" + exception.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// Limita el número de núcleos a utilizar por cidarmt.dll
        /// </summary>
        /// <param name="numCores"></param>
        /// <returns></returns>
        public static int LimitCores(int numCores)
        {
            return cidarLimitLicensedCores(numCores);
        }
        /// <summary>
        /// Devuelve los núcleos disponibles
        /// </summary>
        public static int GetFreeCores()
        {
            return cidarmtFreeCores();
        }
        /// <summary>
        /// Devuelve el número de núcleos de la licencia
        /// </summary>
        public static int GetLicensedCores()
        {
            return cidarmtNumLicenseCores();
        }
        /// <summary>
        /// Devuelve la cantida de objetos en la cola de cidarmt.dll
        /// </summary>
        public static int GetQueueSizeCIDARMT()
        {
            return cidarmtQueueSize();
        }
        /// <summary>
        /// Devuelve la cantidad de núcleos en uso
        /// </summary>
        public static int GetUsedCores()
        {
            return (cidarmtNumLicenseCores() - cidarmtFreeCores());
        }
        /// <summary>
        /// Reinicia el contador de identificacion
        /// </summary>
        public static void ReiniciarContID()
        {
           ContId = 0;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Método que ejecuta la acción del consumidor.
        /// </summary>
        /// <param name="valor"></param>
        public static void EjecutarConsumidor(OCCRData valor)
        {
            try
            {
                if (valor != null)
                {
                    long identificador = valor.GetId;

                    lock (LockObject)
                    {
                        if (valor.ImageInformation.GetPath == string.Empty)
                        {
                            // Pasamos la imagen al motor, dependiendo de su formato
                            Bitmap currentImage = (Bitmap)valor.ImageInformation.GetImage.Clone();
                            //Bitmap otra = new Bitmap(valor.ImageInformation.GetImage);
                            //Rectangle rect2 = new Rectangle(0, 0, otra.Width, otra.Height);
                            Rectangle rect = new Rectangle(0, 0, currentImage.Width, currentImage.Height);
                            BitmapData bmpData = currentImage.LockBits(rect, ImageLockMode.ReadWrite, currentImage.PixelFormat);
                            // Cogemos la dirección de la primera línea
                            IntPtr ptr = bmpData.Scan0;
                            // Desbloqueamos los bits
                            currentImage.UnlockBits(bmpData);
                            // Dependiendo de ll tipo utilizamos una función de paso
                            switch (currentImage.PixelFormat)
                            {
                                case PixelFormat.Format24bppRgb:
                                    cidarmtReadRGB24(ref Configuracion, currentImage.Width, currentImage.Height, ptr, 0, 0);
                                    break;
                                case PixelFormat.Format32bppArgb:
                                    cidarmtReadRGB32(ref Configuracion, currentImage.Width, currentImage.Height, ptr, 0, 0);
                                    break;
                                case PixelFormat.Format8bppIndexed:
                                    cidarmtRead(ref Configuracion, currentImage.Width, currentImage.Height, ptr, 0);
                                    break;
                                default:
                                    OLogsVAFunciones.CCR.Error("CCR", "El Pixel Format de la imagen no es soportado");
                                    break;
                            }
                        }
                        else
                        {
                            // Pasamos la ruta de la imagen al motor, dependiendo de si se trata de una imagen JPG o BMP
                            string ruta = valor.ImageInformation.GetPath;
                            if ((Path.GetExtension(ruta).ToUpper(new CultureInfo("en-US")) == ".JPG") | (Path.GetExtension(ruta).ToUpper(new CultureInfo("en-US")) == ".JPEG"))
                            {
                                cidarmtReadJpg(ref Configuracion, ref ruta, 0);
                            }
                            else if (Path.GetExtension(ruta).ToUpper(new CultureInfo("en-US")) == ".BMP")
                            {
                                cidarmtReadBmp(ref Configuracion, ref ruta, 0);
                            }
                            else
                            {
                                OLogsVAFunciones.CCR.Error("CCR", "Procesando la cola de CCR con ruta de imagen con extensión incorrecta " + ruta);
                            }
                        }
                        try
                        {
                            ElementosEnviados.Add(identificador, valor);
                        }
                        catch (Exception exception)
                        {
                            OLogsVAFunciones.CCR.Error(exception, "CCR", "Añadiendo identificador duplicado al diccionario de datos");
                        }
                        OLogsVAFunciones.CCR.Debug("CCR", string.Format(new CultureInfo("en-US"), "Introducido ResultadoCCR, id = {0}", new object[] { valor.GetId }));
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR", "Procesando la cola de CCR: " + exception.ToString());
            }
        }
        /// <summary>
        /// Función recepción resultados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static int CallbackResultFunction(int id, ref CIDARMtResult res)
        {
            lock (LockObject)
            {
                OLogsVAFunciones.CCR.Debug("CCR", string.Format(new CultureInfo("en-US"), "Callback ResultadoCCR (id = {0}) : Resultado = {1}", new object[] { id, res.lNumberOfCodes }));
                
                // Obtenemos la información almacenada para el resultaado recibido, y lo eliminamos del diccionario
                OCCRData datoEnviado;
                ElementosEnviados.TryGetValue(id, out datoEnviado);
                ElementosEnviados.Remove(id);
                try
                {
                    if (datoEnviado != null)
                    {
                        OCCRCodeInfo resultadoCCR = null;
                        if (res.lNumberOfCodes == 0)
                        {
                            resultadoCCR = new OCCRCodeInfo(string.Empty, 0, res.lProcessingTime, 0f, 0, 0, 0, 0, 0f, string.Empty, id, 0, null, 0, null,
                                0, 0f, 0, 0, 0, 0, null, 0, false, false, res.lUserParam1.ToInt32(), res.lUserParam2.ToInt32());
                        }
                        else if (res.lNumberOfCodes > 0)
                        {
                            // Inicializamos variables para obtener los datos
                            int posBottomISO = 0;
                            int posLeftISO = 0;
                            int posRightISO = 0;
                            int posTopISO = 0;
                            float calidadISO = 0;
                            int numCaracISO = 0;
                            bool esInvertido = false;
                            bool esVertical = false;
                            string codigo = null;
                            string extraInfo = null;
                            float fia = res.vlGlobalConfidence[0];
                            int bpos = res.vlBottom[0];
                            int lpos = res.vlLeft[0];
                            int rpos = res.vlRight[0];
                            int tpos = res.vlTop[0];
                            float avgChar = res.vfAverageCharacterHeight[0];
                            float[] destinationArray = null;
                            float[] numArray = null;
                            numArray = new float[(res.vlNumbersOfCharacters[0] - 1) + 1];
                            Array.Copy(res.vfCharacterConfidence, numArray, res.vlNumbersOfCharacters[0]);
                            int nLines = res.lNumLines[0];
                            if (res.bIsInverted[0] == 1) { esInvertido = true; }
                            if (res.bIsVertical[0] == 1) { esVertical = true; }

                            // Obtenemos el código
                            try
                            {
                                codigo = Encoding.UTF8.GetString(res.strResult, 0, res.vlNumbersOfCharacters[0]);
                                OLogsVAFunciones.CCR.Debug("CCR", string.Format(new CultureInfo("en-US"), "Callback ResultadoCCR (id = {0}) : CODIGO {1}, FIABILIDAD {2}", new object[] { id, codigo, fia }));
                            }
                            catch (Exception exception)
                            {
                                OLogsVAFunciones.CCR.Error(exception, "CCR", string.Format(new CultureInfo("en-US"), "Callback ResultadoCCR (id = {0}) : Numero carácteres {1}", new object[] { id, res.vlNumbersOfCharacters[0] }));
                            }

                            // Obtenemos el ISO
                            if (res.lExtraInfoFound == 1)
                            {
                                posBottomISO = res.vlExtraInfoBottom[0];
                                posLeftISO = res.vlExtraInfoLeft[0];
                                posRightISO = res.vlExtraInfoRight[0];
                                posTopISO = res.vlExtraInfoTop[0];
                                numCaracISO = res.vlExtraInfoNumberOfCharacters[0];
                                extraInfo = Encoding.UTF8.GetString(res.strExtraInfo, 0, numCaracISO);
                                calidadISO = res.vfExtraInfoConfidence[0];
                                destinationArray = new float[(res.vlExtraInfoNumberOfCharacters[0] - 1) + 1];
                                Array.Copy(res.vfExtraInfoCharacterConfidence, destinationArray, res.vlExtraInfoNumberOfCharacters[0]);
                                OLogsVAFunciones.CCR.Debug("CCR", string.Format(new CultureInfo("en-US"), "Callback ResultadoCCR ISO (id = {0}): ISO {1}", new object[] { id, extraInfo }));
                            }

                            // Creamos el resultado y lo añadimos a la cola
                            resultadoCCR = new OCCRCodeInfo(codigo, res.lCodeVerified, res.lProcessingTime, avgChar, lpos, tpos, rpos, bpos, fia, datoEnviado.ImageInformation.GetPath, id, codigo.Length,
                                numArray, res.lExtraInfoFound, extraInfo, numCaracISO, calidadISO, posLeftISO, posTopISO, posRightISO, posBottomISO, destinationArray, nLines, esInvertido, esVertical, res.lUserParam1.ToInt32(), res.lUserParam2.ToInt32());
                        }
                        ColaDeResultados.Enqueue(new OPair<OCCRCodeInfo, OCCRData>(resultadoCCR, datoEnviado));

                        // Eliminamos la imagen temporal 
                        if ((datoEnviado.ImageInformation != null) && (datoEnviado.ImageInformation.GetAutoBorradoFicheroTemporal))
                        {
                            string rutaFicheroTemporal = datoEnviado.ImageInformation.GetPath;
                            ONerualLabsUtils.EliminarFicheroTemporal(rutaFicheroTemporal);
                        }
                    }
                }
                catch (Exception exception)
                {
                    OLogsVAFunciones.CCR.Error(exception, "CCR", string.Format(new CultureInfo("en-US"), "ERROR CallbackCCR Exception, {0}", new object[] { exception.Message }));
                    OCCRCodeInfo resultadoVacioError = new OCCRCodeInfo(string.Empty, 0, res.lProcessingTime, 0f, 0, 0, 0, 0, 0f, string.Empty, id, 0, null, 0, null, 
                        0, 0f, 0, 0, 0, 0, null, 0, false, false, res.lUserParam1.ToInt32(), res.lUserParam2.ToInt32());
                    ColaDeResultados.Enqueue(new OPair<OCCRCodeInfo, OCCRData>(resultadoVacioError, datoEnviado));
                }
            }            
            return 0;
        }
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado de recepción de resultados de Cidar
        /// </summary>
        /// <param name="identificador">Identificador</param>
        /// <param name="resultado">resultado</param>
        /// <returns></returns>
        public delegate int CidarCallback(int identificador, ref CIDARMtResult resultado);
        #endregion

        #region Llamadas al cidarmt.dll ubicado en System
        [DllImport("cidarmt.dll", EntryPoint = "_LimitLicensedCores@4", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarLimitLicensedCores(int numcores);
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtEnd@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern void cidarmtEnd();
        [DllImport("cidarmt.dll", EntryPoint = "_FreeCores@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtFreeCores();
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtInit@16", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtInit(CidarCallback callbackFunction, int AvCharHeight, int DuplicateLines, int Trace);
        [DllImport("cidarmt.dll", EntryPoint = "_NumLicenseCores@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtNumLicenseCores();
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtQueueSize@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtQueueSize();
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtRead@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtRead(ref CIDARMtConfiguration configuracion, int lWidth, int lHeight, IntPtr pbImageData, int bFront);
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtReadBMP@12", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtReadBmp(ref CIDARMtConfiguration configuracion, [MarshalAs(UnmanagedType.VBByRefStr)] ref string BmpFile, int bFront);
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtReadJPG@12", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtReadJpg(ref CIDARMtConfiguration configuracion, [MarshalAs(UnmanagedType.VBByRefStr)] ref string JPGFile, int bFront);
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtReadRGB24@24", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtReadRGB24(ref CIDARMtConfiguration configuracion, int lWidth, int lHeight, IntPtr pbImageData, int bVerticalFlip, int bFront);
        [DllImport("cidarmt.dll", EntryPoint = "_cidarmtReadRGB32@24", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarmtReadRGB32(ref CIDARMtConfiguration configuracion, int lWidth, int lHeight, IntPtr pbImageData, int bVerticalFlip, int bFront);
        [DllImport("cidarmt.dll", EntryPoint = "_Reset@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int cidarReset();
        #endregion
    }

    #region Clases y estructuras utilizadas en cidarmt.dll

    #region Estructuras
    /// <summary>
    /// Estructura del resultado  devuelto
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CIDARMtResult
    {
        [FieldOffset(0)]
        public Int32 lRes;
        [FieldOffset(4)]
        public Int32 lNumberOfCodes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        [FieldOffset(8)]
        public byte[] strResult;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(88)]
        public Int32[] vlNumbersOfCharacters;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(120)]
        public float[] vlGlobalConfidence;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(152)]
        public float[] vfAverageCharacterHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        [FieldOffset(184)]
        public float[] vfCharacterConfidence;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(504)]
        public Int32[] vlLeft;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(536)]
        public Int32[] vlTop;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(568)]
        public Int32[] vlRight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(600)]
        public Int32[] vlBottom;
        [FieldOffset(632)]
        public Int32 lProcessingTime;
        [FieldOffset(636)]
        public Int32 lCodeVerified;
        [FieldOffset(640)]
        public Int32 lExtraInfoFound;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        [FieldOffset(644)]
        public byte[] strExtraInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(724)]
        public Int32[] vlExtraInfoNumberOfCharacters;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(756)]
        public float[] vfExtraInfoConfidence;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(788)]
        public Int32[] vlExtraInfoLeft;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(820)]
        public Int32[] vlExtraInfoTop;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(852)]
        public Int32[] vlExtraInfoRight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(884)]
        public Int32[] vlExtraInfoBottom;
        //New fields 2011/09/01
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        [FieldOffset(916)]
        public float[] vfExtraInfoCharacterConfidence;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(1236)]
        public Int32[] lNumLines;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(1268)]
        public Int32[] bIsInverted;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(1300)]
        public Int32[] bIsVertical;
        [FieldOffset(1332)]
        public IntPtr lUserParam1; 
        [FieldOffset(1336)]
        public IntPtr lUserParam2;
    }
    /// <summary>
    /// Estructura de la configuración
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CIDARMtConfiguration
    {
        [FieldOffset(0)]
        public Int32 lMiliseconds;
        //Correction Coefficients
        [FieldOffset(4)]
        //En caso de poner este booleano a true, los 4 parametros siguientes se aplicaran
        public Int32 bAplicarCorreccion;
        [FieldOffset(8)]
        public float fDistance;
        [FieldOffset(12)]
        public float fVerticalCoeff;
        [FieldOffset(16)]
        public float fHorizontalCoeff;
        [FieldOffset(20)]
        public float fRadialCoeff;
        [FieldOffset(24)]
        public float fAngle;
        [FieldOffset(28)]
        public float fVerticalSkew;
        [FieldOffset(32)]
        public float FHorizontalSkew;
        [FieldOffset(36)]
        //En caso de poner este booleano a true se usaran las aturas del vector siguiente
        public Int32 lNumSteps;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(40)]
        public Int32[] vlSteps;
        //Rectangle
        [FieldOffset(72)]
        public Int32 lLeft;
        [FieldOffset(76)]
        public Int32 lTop;
        [FieldOffset(80)]
        public Int32 lWidth;
        [FieldOffset(84)]
        public Int32 lHeight;
        [FieldOffset(88)]
        public Int32 bEnableExtraInfo;
        [FieldOffset(92)]
        public float fScale;
        [FieldOffset(96)]
        public Int32 lUserParam1; 
        [FieldOffset(100)]
        public Int32 lUserParam2;
    }
    #endregion

    #region Clases
    /// <summary>
    /// Información de la imagen que se va a pasar al motor de CIDAR
    /// </summary>
    public class OCCRInfoImagen : IDisposable
    {
        #region Campos
        /// <summary>
        /// Si el valor ha sido borrado
        /// </summary>
        private bool DisposedValue;
        /// <summary>
        /// Imagen
        /// </summary>
        private Bitmap Imagen;
        /// <summary>
        /// Objeto
        /// </summary>
        private object Obj;
        /// <summary>
        /// Ruta
        /// </summary>
        private string Ruta;
        /// <summary>
        /// Indica si se ha de borrar el fichero temporal
        /// </summary>
        private bool AutoBorradoFicheroTemporal;
        /// <summary>
        /// Fecha
        /// </summary>
        private DateTime Timestamp;
        /// <summary>
        /// Fecha universal
        /// </summary>
        private DateTime TimestampUTC;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene la imagen
        /// </summary>
        public Bitmap GetImage
        {
            get
            {
                return this.Imagen;
            }
        }
        /// <summary>
        /// Obtiene el objeto
        /// </summary>
        public object GetObject
        {
            get
            {
                return this.Obj;
            }
        }
        /// <summary>
        /// Obtiene la ruta
        /// </summary>
        public string GetPath
        {
            get
            {
                return this.Ruta;
            }
        }
        /// <summary>
        /// Indica si se ha de borrar el fichero temporal
        /// </summary>
        public bool GetAutoBorradoFicheroTemporal
        {
            get
            {
                return this.AutoBorradoFicheroTemporal;
            }
        }
        /// <summary>
        /// Obtiene la fecha
        /// </summary>
        public DateTime GetTimestamp
        {
            get
            {
                return this.Timestamp;
            }
        }
        /// <summary>
        /// Obtiene la fecha universal
        /// </summary>
        public DateTime GetUTCTimestamp
        {
            get
            {
                return this.TimestampUTC;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="image"></param>
        /// <param name="path"></param>
        /// <param name="objInfo"></param>
        public OCCRInfoImagen(Bitmap image, string path, bool autoBorradoFicheroTemporal, ref object objInfo)
        {
            this.DisposedValue = false;
            if (image != null) { this.Imagen = (Bitmap)image.Clone(); }
            this.Ruta = path;
            this.AutoBorradoFicheroTemporal = autoBorradoFicheroTemporal;
            this.Obj = RuntimeHelpers.GetObjectValue(objInfo);
            this.Timestamp = DateTime.Now;
            this.TimestampUTC = DateTime.Now.ToUniversalTime();
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Borra la imagen
        /// </summary>
        public void ClearImage()
        {
            if (this.Imagen != null)
            {
                this.Imagen.Dispose();
                this.Imagen = null;
            }
        }
        /// <summary>
        /// Elimina la clase
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Establece la ruta
        /// </summary>
        /// <param name="value"></param>
        public void SetPath(string value)
        {
            this.Ruta = value;
        }
        #endregion

        #region Métodos Heredados
        /// <summary>
        /// Método hererado para eliminar la clase
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.DisposedValue)
            {
                if (this.Imagen != null)
                {
                    this.Imagen.Dispose();
                    this.Imagen = null;
                }
                this.Ruta = null;
                this.Timestamp = new DateTime();
                this.TimestampUTC = new DateTime();
            }
            this.DisposedValue = true;
        }
        #endregion
    }
    /// <summary>
    /// Datos de la identificación a realizar
    /// </summary>
    public class OCCRData : IDisposable
    {
        #region Campos
        /// <summary>
        /// Identificador del dato
        /// </summary>
        private long Identificador;
        /// Codigo de la función que llama
        /// </summary>
        private string CodFuncionVision;
        /// <summary>
        /// <summary>
        /// Si el valor ha sido borrado
        /// </summary>
        private bool DisposedValue;
        /// <summary>
        /// Configuración a utilizar para el dato
        /// </summary>
        private CIDARMtConfiguration Configuracion;
        /// <summary>
        /// Información de la imagen
        /// </summary>
        private OCCRInfoImagen InformacionImagen;
        /// <summary>
        /// Lista con los resultados
        /// </summary>
        private List<OCCRCodeInfo> ListaResultados = new List<OCCRCodeInfo>();
        /// <summary>
        /// Cantidad de lecturas
        /// </summary>
        private int TotalReadItems;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el identificador del dato
        /// </summary>
        public long GetId
        {
            get
            {
                return this.Identificador;
            }
        }
        /// <summary>
        /// Obtiene el codigo de la función de visión
        /// </summary>
        public string GetCodFuncion
        {
            get
            {
                return this.CodFuncionVision;
            }
        }
        /// <summary>
        /// Propiedad de configuración
        /// </summary>
        public CIDARMtConfiguration Configuration
        {
            get
            {
                return this.Configuracion;
            }
            set
            {
                this.Configuracion = value;
            }
        }
        /// <summary>
        /// Obtiene el primer resultado
        /// </summary>
        public OCCRCodeInfo GetFirstItem
        {
            get
            {
                OCCRCodeInfo info = null;
                if (this.ListaResultados.Count > 0)
                {
                    info = this.ListaResultados[0];
                }
                if (info != null)
                {
                    this.ListaResultados.RemoveAt(0);
                    this.ListaResultados.TrimExcess();
                }
                return info;
            }
        }
        /// <summary>
        /// Propiedad de la información de la imagen
        /// </summary>
        public OCCRInfoImagen ImageInformation
        {
            get
            {
                return this.InformacionImagen;
            }
            set
            {
                this.InformacionImagen = value;
            }
        }
        /// <summary>
        /// Cantidad de resultados
        /// </summary>
        public int ItemCount
        {
            get
            {
                return this.ListaResultados.Count;
            }
        }
        /// <summary>
        /// Cantidad de items leidos
        /// </summary>
        public int ReadItems
        {
            get
            {
                return this.TotalReadItems;
            }
            set
            {
                this.TotalReadItems = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="cfg"></param>
        /// <param name="pi"></param>
        public OCCRData(long ident,string codFuncion, CIDARMtConfiguration cfg, ref OCCRInfoImagen pi)
        {
            this.Identificador = ident;
            this.CodFuncionVision = codFuncion;
            this.Configuracion = cfg;
            this.InformacionImagen = pi;
            this.TotalReadItems = -1;
            this.DisposedValue = false;
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Le añade un resultado
        /// </summary>
        /// <param name="value"></param>
        public void AddResultado(ref OCCRCodeInfo value)
        {
            this.ListaResultados.Add(value);
        }
        /// <summary>
        /// Eliminado
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Métodos Heredados
        /// <summary>
        /// Método hererado para eliminar la clase
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.DisposedValue)
            {
                this.Configuracion = new CIDARMtConfiguration();
                this.ListaResultados.Clear();
                this.ListaResultados = null;
                this.InformacionImagen.Dispose();
                this.InformacionImagen = null;
                this.TotalReadItems = 0;
            }
            this.DisposedValue = true;
        }
        #endregion
    }
    /// <summary>
    /// Resultado de la identificación
    /// </summary>
    public class OCCRCodeInfo : IDisposable
    {
        #region Campos
        /// <summary>
        /// Media de altura del caracter
        /// </summary>
        private float averageCharHeigth;
        /// <summary>
        /// Calidad de los caracteres
        /// </summary>
        private float[] charConfidence;
        /// <summary>
        /// Código identificado
        /// </summary>
        private string code;
        /// <summary>
        /// Indica si esta verificado
        /// </summary>
        private int codeVerification;
        /// <summary>
        /// Calidad del código
        /// </summary>
        private float confidence;
        /// <summary>
        /// Si ha sido eliminado
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// Código ISO
        /// </summary>
        private string extraCode;
        /// <summary>
        /// Posición inferior código ISO
        /// </summary>
        private int extraCodeBottom;
        /// <summary>
        /// Calidad del ISOCode
        /// </summary>
        private float extraCodeConfidence;
        /// <summary>
        /// Si ha encontrado el código ISO
        /// </summary>
        private int extraCodeFound;
        /// <summary>
        /// Posición inquierda del código ISO
        /// </summary>
        private int extraCodeLeft;
        /// <summary>
        /// Número de caracteres del ISO
        /// </summary>
        private int extraCodeNumCharacters;
        /// <summary>
        /// Posición derecha del ISO localizado
        /// </summary>
        private int extraCodeRight;
        /// <summary>
        /// Posición superior del ISO localizado
        /// </summary>
        private int extraCodeTop;
        /// <summary>
        /// Calidad de los caracteres del ISO
        /// </summary>
        private float[] extraInfoCharConfidence;
        /// <summary>
        /// Identificador asociado 
        /// </summary>
        private int id;
        /// <summary>
        /// Si esta invertido el código
        /// </summary>
        private bool isInverted;
        /// <summary>
        /// Si es vertical el código
        /// </summary>
        private bool isVertical;
        /// <summary>
        /// Posición derecha del código
        /// </summary>
        private int rPosition;
        /// <summary>
        /// Posición izquierda del código
        /// </summary>
        private int lPosition;
        /// <summary>
        /// Posición inferior del código
        /// </summary>
        private int bPosition;
        /// <summary>
        /// Posición superior del código
        /// </summary>
        private int tPosition;
        /// <summary>
        /// Número de caracteres del código
        /// </summary>
        private int numCharacters;
        /// <summary>
        /// Número de líneas que componen el código
        /// </summary>
        private int numLines;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        private int processingTime;
        /// <summary>
        /// Ruta asocada
        /// </summary>
        private string sourcePath;
        /// <summary>
        /// Parámetro de usuario 1
        /// </summary>
        private int userParam1;
        /// <summary>
        /// Parámetro de usuario 2
        /// </summary>
        private int userParam2;
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve la altura media
        /// </summary>
        public float GetAverageCharacterHeigth
        {
            get
            {
                return this.averageCharHeigth;
            }
        }
        /// <summary>
        /// Devuelve la posición inferior del código
        /// </summary>
        public int GetBottomCodePosition
        {
            get
            {
                return this.bPosition;
            }
        }
        /// <summary>
        /// Array con las calidades individuales de cada carácter
        /// </summary>
        public float[] GetCharConfidence
        {
            get
            {
                return this.charConfidence;
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
        /// Contiene la calidad de cara carácter del ISO
        /// </summary>
        public float[] GetExtraInfoCharConfidence
        {
            get
            {
                return this.extraInfoCharConfidence;
            }
        }
        /// <summary>
        /// Obtiene el ISO
        /// </summary>
        public string GetExtraInfoCodeNumber
        {
            get
            {
                return this.extraCode;
            }
        }
        /// <summary>
        /// Obtiene la calidad del ISO
        /// </summary>
        public float GetExtraInfoConfidence
        {
            get
            {
                return this.extraCodeConfidence;
            }
        }
        /// <summary>
        /// Obtiene la cantidad de caracteres del ISO
        /// </summary>
        public int GetExtraInfoNumCharacters
        {
            get
            {
                return this.extraCodeNumCharacters;
            }
        }
        /// <summary>
        /// Obtiene la calidad del Código
        /// </summary>
        public float GetGlobalConfidence
        {
            get
            {
                return this.confidence;
            }
        }
        /// <summary>
        /// Obtiene el identificador
        /// </summary>
        public int GetId
        {
            get
            {
                return this.id;
            }
        }
        /// <summary>
        /// Devuelve la posición izquierda del código
        /// </summary>
        public int GetLeftCodePosition
        {
            get
            {
                return this.lPosition;
            }
        }
        /// <summary>
        /// Devuelve el número de caracteres del código
        /// </summary>
        public int GetNumCharacters
        {
            get
            {
                return this.numCharacters;
            }
        }
        /// <summary>
        /// Devuelve la cantidad de líneas del código localizado
        /// </summary>
        public int GetnumLines
        {
            get
            {
                return this.numLines;
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
        /// Devuelve la posición derecha del código
        /// </summary>
        public int GetRightCodePosition
        {
            get
            {
                return this.rPosition;
            }
        }
        /// <summary>
        /// Devuelve la ruta origen
        /// </summary>
        public string GetSourcePath
        {
            get
            {
                return this.sourcePath;
            }
        }
        /// <summary>
        /// Devuelve la posición superior del código
        /// </summary>
        public int GetTopCodePosition
        {
            get
            {
                return this.tPosition;
            }
        }
        /// <summary>
        /// Obtiene el valor del param1
        /// </summary>
        public int GetUserParam1
        {
            get
            {
                return this.userParam1;
            }
        }
        /// <summary>
        /// Obtiene el valor del param2
        /// </summary>
        public int GetUserParam2
        {
            get
            {
                return this.userParam2;
            }
        }
        /// <summary>
        /// Obtiene si el código se encontraba invertido
        /// </summary>
        public bool isCodeInverted
        {
            get
            {
                return this.isInverted;
            }
        }
        /// <summary>
        /// Devuelve si el código ha sido verificado
        /// </summary>
        public int IsCodeVerified
        {
            get
            {
                return this.codeVerification;
            }
        }
        /// <summary>
        /// Devuelve si el código identificado era vertical
        /// </summary>
        public bool isCodeVertical
        {
            get
            {
                return this.isVertical;
            }
        }
        /// <summary>
        /// Devuelve si ha identificado el código ISO
        /// </summary>
        public int IsExtraInfoFound
        {
            get
            {
                return this.extraCodeFound;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="ccode"></param>
        /// <param name="verified"></param>
        /// <param name="ptime"></param>
        /// <param name="avgChar"></param>
        /// <param name="lpos"></param>
        /// <param name="tpos"></param>
        /// <param name="rpos"></param>
        /// <param name="bpos"></param>
        /// <param name="fia"></param>
        /// <param name="path"></param>
        /// <param name="ident"></param>
        /// <param name="nchars"></param>
        /// <param name="cConf"></param>
        /// <param name="eInfoFound"></param>
        /// <param name="eInfo"></param>
        /// <param name="eInfoNumChars"></param>
        /// <param name="eInfoConf"></param>
        /// <param name="eInfoLeft"></param>
        /// <param name="eInfoTop"></param>
        /// <param name="eInfoRight"></param>
        /// <param name="eInfoBottom"></param>
        /// <param name="eInfocConf"></param>
        /// <param name="nLines"></param>
        /// <param name="inverted"></param>
        /// <param name="vertical"></param>
        /// <param name="luserParam1"></param>
        /// <param name="luserParam2"></param>
        public OCCRCodeInfo(string ccode, int verified, int ptime, float avgChar, int lpos, int tpos, int rpos, int bpos, float fia, string path, int ident, int nchars, float[] cConf, int eInfoFound, string eInfo, int eInfoNumChars, float eInfoConf, int eInfoLeft, int eInfoTop, int eInfoRight, int eInfoBottom, float[] eInfocConf, int nLines, bool inverted, bool vertical, int luserParam1, int luserParam2)
        {
            this.code = ccode;
            this.lPosition = lpos;
            this.tPosition = tpos;
            this.rPosition = rpos;
            this.bPosition = bpos;
            this.confidence = fia;
            this.sourcePath = path;
            this.averageCharHeigth = avgChar;
            this.id = ident;
            this.numCharacters = nchars;
            this.charConfidence = cConf;
            this.processingTime = ptime;
            this.codeVerification = verified;
            this.extraCodeFound = eInfoFound;
            this.extraCode = eInfo;
            this.extraCodeNumCharacters = eInfoNumChars;
            this.extraCodeConfidence = eInfoConf;
            this.extraCodeLeft = eInfoLeft;
            this.extraCodeTop = eInfoTop;
            this.extraCodeRight = eInfoRight;
            this.extraCodeBottom = eInfoBottom;
            this.extraInfoCharConfidence = eInfocConf;
            this.numLines = nLines;
            this.isInverted = inverted;
            this.isVertical = vertical;
            this.userParam1 = luserParam1;
            this.userParam2 = luserParam2;
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Eliminado 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Devuelve la posición del códgio identificado
        /// </summary>
        /// <param name="plLeft"></param>
        /// <param name="plTop"></param>
        /// <param name="plRight"></param>
        /// <param name="plBottom"></param>
        public void GetCodePosition(ref int plLeft, ref int plTop, ref int plRight, ref int plBottom)
        {
            plLeft = this.lPosition;
            plTop = this.tPosition;
            plRight = this.rPosition;
            plBottom = this.bPosition;
        }
        /// <summary>
        /// Devuelve la posición del ISO identificado
        /// </summary>
        /// <param name="plLeft"></param>
        /// <param name="plTop"></param>
        /// <param name="plRight"></param>
        /// <param name="plBottom"></param>
        public void GetExtraInfoCodePosition(ref int plLeft, ref int plTop, ref int plRight, ref int plBottom)
        {
            plLeft = this.extraCodeLeft;
            plTop = this.extraCodeTop;
            plRight = this.extraCodeRight;
            plBottom = this.extraCodeBottom;
        }
        /// <summary>
        /// Actualiza la ruta
        /// </summary>
        /// <param name="sp"></param>
        public void SetSourcePath(string sp)
        {
            this.sourcePath = sp;
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Eliminado
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.lPosition = 0;
                this.tPosition = 0;
                this.rPosition = 0;
                this.bPosition = 0;
                this.code = null;
                this.confidence = 0f;
                this.sourcePath = null;
                this.averageCharHeigth = 0f;
                this.id = 0;
                this.numCharacters = 0;
                this.charConfidence = null;
                this.processingTime = 0;
                this.codeVerification = 0;
                this.extraCodeFound = 0;
                this.extraCode = null;
                this.extraCodeNumCharacters = 0;
                this.extraCodeConfidence = 0f;
                this.extraCodeLeft = 0;
                this.extraCodeTop = 0;
                this.extraCodeRight = 0;
                this.extraCodeBottom = 0;
                this.extraInfoCharConfidence = null;
                this.numLines = 0;
                this.isInverted = false;
                this.isVertical = false;
                this.userParam1 = 0;
                this.userParam2 = 0;
            }
            this.disposed = true;
        }
        #endregion

        #region Métodos Heredados
        /// <summary>
        /// Transforma el resultado en un string de Código(ISO)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.code + "(" + this.extraCode + ")";
        }
        #endregion
    }
    #endregion

    #endregion
}