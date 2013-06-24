//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : fhernandez
// Created          : 13-05-2013
//
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Orbita.VA.Comun;
using Orbita.Utiles;
using System.Runtime.InteropServices;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase estática que manejará la librería VPAR de reconocimiento de matrículas
    /// </summary>
    public static class OMTInterfaceLPR
    {
        #region Constantes
        /// <summary>
        /// Numero máximo de imagenes en cola para ser procesador
        /// </summary>
        private const int MAX_QUEUE = 100;
        #endregion

        #region Campos
        /// <summary>
        /// Recepción del resultado por parte de vparmt.dll
        /// </summary>
        private static VPARCallback VPARMtCallbackResult;
        /// <summary>
        /// Variable que nos indicará que esta en proceso
        /// </summary>
        private static bool VPARIsRunning;
        /// <summary>
        /// Cola que contiene los resultados
        /// </summary>
        private static Queue<OPair<OLPRCodeInfo, OLPRData>> ColaDeResultados;
        /// <summary>
        /// Clase que gestionara la añadición y ejecución de resultados
        /// </summary>
        private static OProductorConsumidorThread<OLPRData> ProductorConsumidor;
        /// <summary>
        /// Elementos enviados al motor, para poder asociar con los resultados
        /// </summary>
        private static Dictionary<long, OLPRData> ElementosEnviados;
        /// <summary>
        /// Objeto bloqueante
        /// </summary>
        private static object LockObject = new object();
        /// <summary>
        /// Parametros de configuracion del motor
        /// </summary> 
        private static VPARMtConfiguration Configuracion;
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
            VPARMtCallbackResult = new VPARCallback(CallbackResultFunction);
            // Creamos las colas , pilas y diccionarios
            ColaDeResultados = new Queue<OPair<OLPRCodeInfo, OLPRData>>();
            ElementosEnviados = new Dictionary<long, OLPRData>();
            ProductorConsumidor = new OProductorConsumidorThread<OLPRData>("VPAR PC", 1, 1, ThreadPriority.Normal, MAX_QUEUE);
            ProductorConsumidor.CrearSuscripcionConsumidor(EjecutarConsumidor, true);
            ProductorConsumidor.Start();            
            VPARIsRunning = false;
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
        public static int Init(int countryCode, int AvCharHeight, int DuplicateLines, int Reordenar, int filterColor, int TraceVpar)
        {
            try
            {
                // Si ya esta en funcionamiento no hacemos nada
                if (!VPARIsRunning)
                {
                    // INICIAMOS EL MOTOR cidarmt.dll
                    if (vparmtInit(VPARMtCallbackResult, countryCode, AvCharHeight, DuplicateLines, Reordenar, filterColor, TraceVpar) == 1)
                    {
                        // Inicializamos el contador
                        ContId = 0;

                        // Indicamos que el motor esta en funcionamiento
                        VPARIsRunning = true;
                        OLogsVAFunciones.LPR.Info("LPR", "Iniciado correctamente");
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Inicializando el motor LPR:" + exception.ToString());
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
                vparmtEnd();
                VPARIsRunning = false;
                GC.Collect();
                return true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Finalizando el motor LPR:" + exception.ToString());
                return false;
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
                    var nuevo = ElementosEnviados.Where(kvp => kvp.Value.GetCodFuncion == codFuncion);
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

                    //    Dictionary<long, OLPRData> nuevo = new Dictionary<long, OLPRData>();
                    //    foreach (KeyValuePair<long, OLPRData> elemento in ElementosEnviados)
                    //    {
                    //        // do something with entry.Value or entry.Key
                    //        OLPRData datos = elemento.Value;
                    //        long ident = elemento.Key;
                    //        if (datos.GetCodFuncion != codFuncion)
                    //        {
                    //            nuevo.Add(ident, datos);
                    //        }
                    //    }
                    //ElementosEnviados.Clear();
                    //    ElementosEnviados = new Dictionary<long,OLPRData>(nuevo);
                    //    nuevo.Clear();
                    GC.Collect();
                }
                return 1;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Reseteando el motor LPR:" + exception.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Establece la configuración
        /// </summary>
        /// <returns></returns>
        public static void SetConfiguracion(OParametrosLPR param)
        {
            try
            {
                lock (LockObject)
                {
                    Configuracion.vlSteps = new int[8];
                    Configuracion.bAplicarCorreccion = param.ActivadaAjusteCorreccion;
                    Configuracion.fAngle = param.AnguloRotacion;
                    Configuracion.fDistance = param.Distancia;
                    Configuracion.fHorizontalCoeff = param.CoeficienteHorizontal;
                    Configuracion.fVerticalCoeff = param.CoeficienteVertical;
                    Configuracion.lHeight = param.AlturaVentanaBusqueda;
                    Configuracion.lLeft = param.CoordIzq;
                    Configuracion.lMiliseconds = param.TimeOut;
                    Configuracion.lTop = param.CoordArriba;
                    Configuracion.lWidth = param.AnchuraVentanaBusqueda;
                    Configuracion.fScale = param.Escala;
                    Configuracion.lNumSteps = param.VectorAlturas.Length;
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
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Estableciendo configuración del motor LPR:" + exception.ToString());
            }
        }
        /// <summary>
        /// Devuelve si el motor esta activo
        /// </summary>
        /// <returns></returns>
        public static bool IsRunning()
        {
            return VPARIsRunning;
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
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Obteniendo cantidad de elementos en cola:" + exception.ToString());
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
                    foreach (KeyValuePair<long, OLPRData> elemento in ElementosEnviados)
                    {
                        // do something with entry.Value or entry.Key
                        OLPRData datos = elemento.Value;
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
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Obteniendo cantidad de elementos en cola:" + exception.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Devuelve un resultado de la cola
        /// </summary>
        /// <returns></returns>
        public static OPair<OLPRCodeInfo, OLPRData> GetResultado()
        {
            OPair<OLPRCodeInfo, OLPRData> result = new OPair<OLPRCodeInfo, OLPRData>();
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
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Obteniendo resultado:" + exception.ToString());
                return null;
            }
        }
        /// <summary>
        /// Añade una imagen para su reconocimiento
        /// </summary>
        /// <param name="codFunc">funcion que lo añade</param>
        /// <param name="bitmap">imagen</param>
        /// <param name="obj">información de la imagen</param>
        /// <param name="bFront">Si es prioritaria</param>
        public static bool Add(string codFunc,Bitmap bitmap, object obj, bool bFront = false)
        {
            try
            {
                lock (LockObject)
                {
                    // Si hemos superaado el tamaño de la cola no la incluimos
                    if (!VPARIsRunning | (GetQueueSize() > MAX_QUEUE))
                    {
                        return false;
                    }

                    OLPRInfoImagen informacion = new OLPRInfoImagen(bitmap, string.Empty, false, ref obj);

                    // Establece la prioridad en la cola para la imagen
                    if (bFront)
                    {
                        ProductorConsumidor.Encolar(new OLPRData(ContId,codFunc, Configuracion, ref informacion), -1);
                    }
                    else
                    {
                        ProductorConsumidor.Encolar(new OLPRData(ContId,codFunc, Configuracion, ref informacion));
                    }

                    // Incrementamos el contador
                    ContId++;
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Añadiendo imagen a la cola:" + exception.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// Añade una imagen para su reconocimiento por ruta
        /// </summary>
        /// <param name="codFunc">funcion que lo añade</param>
        /// <param name="rutaBitmap">imagen</param>
        /// <param name="obj">información de la imagen</param>
        /// <param name="bFront">Si es prioritaria</param>
        public static bool Add(string codFunc,string rutaBitmap, bool autoBorradoFicheroTemporal, object obj, bool bFront = false)
        {
            try
            {
                lock (LockObject)
                {
                    // Si hemos superaado el tamaño de la cola no la incluimos
                    if (!VPARIsRunning | (GetQueueSize() > MAX_QUEUE))
                    {
                        return false;
                    }

                    OLPRInfoImagen informacion = new OLPRInfoImagen(null, rutaBitmap, autoBorradoFicheroTemporal, ref obj);

                    // Establece la prioridad en la cola para la imagen
                    if (bFront)
                    {
                        ProductorConsumidor.Encolar(new OLPRData(ContId, codFunc, Configuracion, ref informacion), -1);
                    }
                    else
                    {
                        ProductorConsumidor.Encolar(new OLPRData(ContId, codFunc, Configuracion, ref informacion));
                    }

                    // Incrementamos el contador
                    ContId++;
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Añadiendo imagen a la cola:" + exception.ToString());
                return false;
            }
            return true;
        }
        /// <summary>
        /// Devuelve los núcleos disponibles
        /// </summary>
        public static int GetFreeCores()
        {
            return FreeCores();
        }
        /// <summary>
        /// Devuelve el número de núcleos de la licencia
        /// </summary>
        public static int GetLicensedCores()
        {
            return NumLicenseCores();
        }
        /// <summary>
        /// Devuelve la cantida de objetos en la cola de cidarmt.dll
        /// </summary>
        public static int GetQueueSizeVPARMT()
        {
            return vparmtQueueSize();
        }
        /// <summary>
        /// Devuelve la cantidad de núcleos en uso
        /// </summary>
        public static int GetUsedCores()
        {
            return (NumLicenseCores() - FreeCores());
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
        public static void EjecutarConsumidor(OLPRData valor)
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
                                    vparmtReadRGB24(ref Configuracion, currentImage.Width, currentImage.Height, ptr, 0);
                                    break;
                                case PixelFormat.Format32bppArgb:
                                    vparmtReadRGB32(ref Configuracion, currentImage.Width, currentImage.Height, ptr, 0);
                                    break;
                                case PixelFormat.Format8bppIndexed:
                                    vparmtRead(ref Configuracion, currentImage.Width, currentImage.Height, ptr);
                                    break;
                                default:
                                    OLogsVAFunciones.LPR.Error("LPR", "El Pixel Format de la imagen no es soportado");
                                    break;
                            }
                        }
                        else
                        {
                            // Pasamos la ruta de la imagen al motor, dependiendo de si se trata de una imagen JPG o BMP
                            string ruta = valor.ImageInformation.GetPath;
                            if ((Path.GetExtension(ruta).ToUpper(new CultureInfo("en-US")) == ".JPG") | (Path.GetExtension(ruta).ToUpper(new CultureInfo("en-US")) == ".JPEG"))
                            {
                                vparmtReadJPG(ref Configuracion, ruta);
                            }
                            else if (Path.GetExtension(ruta).ToUpper(new CultureInfo("en-US")) == ".BMP")
                            {
                                vparmtReadBMP(ref Configuracion, ruta);
                            }
                            else
                            {
                                OLogsVAFunciones.LPR.Error("LPR", "Procesando la cola de VPAR con ruta de imagen con extensión incorrecta " + ruta);
                            }
                        }

                        try
                        {
                            ElementosEnviados.Add(identificador, valor);
                        }
                        catch (Exception exception)
                        {
                            OLogsVAFunciones.LPR.Error(exception, "LPR", "Añadiendo identificador duplicado al diccionario de datos");
                        }

                        OLogsVAFunciones.LPR.Debug("LPR", string.Format(new CultureInfo("en-US"), "Introducido ResultadoLPR, id = {0}", new object[] { valor.GetId }));
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR", "Procesando la cola de LPR: " + exception.ToString());
            }
        }
        /// <summary>
        /// Función recepción resultados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static int CallbackResultFunction(int id, ref VPARMtResult res)
        {
            lock (LockObject)
            {
                OLogsVAFunciones.LPR.Debug("LPR", string.Format(new CultureInfo("en-US"), "Callback ResultadoLPR (id = {0}) : Resultado = {1}", new object[] { id, res.lNumberOfPlates }));

                // Obtenemos la información almacenada para el resultaado recibido, y lo eliminamos del diccionario
                OLPRData datoEnviado;
                ElementosEnviados.TryGetValue(id, out datoEnviado);
                ElementosEnviados.Remove(id);
                try
                {
                    if (datoEnviado != null)
                    {
                        OLPRCodeInfo resultadoLPR = null;
                        if (res.lNumberOfPlates == 0)
                        {
                            resultadoLPR = new OLPRCodeInfo(string.Empty, res.lProcessingTime, 0f, 0, 0, 0, 0, 0f, string.Empty, id, 0, null, 0);
                        }
                        else if (res.lNumberOfPlates > 0)
                        {
                            for (int i = 0; i < res.lNumberOfPlates; i++)
                            {
                                //OLPRCodeInfo sd = res[0];
                                // Inicializamos variables para obtener los datos
                                string matricula = null;
                                float fia = res.vlGlobalConfidence[i];
                                int bpos = res.vlBottom[i];
                                int lpos = res.vlLeft[i];
                                int rpos = res.vlRight[i];
                                int tpos = res.vlTop[i];
                                float avgChar = res.vfAverageCharacterHeight[i];
                                float[] destinationArray = new float[(res.vlNumbersOfCharacters[i] - 1) + 1];
                                Array.Copy(res.vfCharacterConfidence, destinationArray, res.vlNumbersOfCharacters[i]);

                                // Obtenemos el código
                                try
                                {
                                    matricula = Encoding.UTF7.GetString(res.strResult, i * 10, res.vlNumbersOfCharacters[i]);
                                    OLogsVAFunciones.LPR.Debug("LPR", string.Format(new CultureInfo("en-US"), "Callback ResultadoCCR (id = {0}) : CODIGO {1}", new object[] { id, matricula }));
                                }
                                catch (Exception exception)
                                {
                                    OLogsVAFunciones.LPR.Error(exception, "LPR", string.Format(new CultureInfo("en-US"), "Callback ResultadoCCR (id = {0}) : Numero carácteres {1}", new object[] { id, res.vlNumbersOfCharacters[i] }));
                                }

                                resultadoLPR = new OLPRCodeInfo(matricula, res.lProcessingTime, (double)avgChar, lpos, tpos, rpos, bpos, (double)fia,
                                    datoEnviado.ImageInformation.GetPath, id, matricula.Length, destinationArray, res.vlFormat[0]);
                                datoEnviado.AddResultado(ref resultadoLPR);
                            }
                        }

                        // Encolamos el resultado
                        ColaDeResultados.Enqueue(new OPair<OLPRCodeInfo, OLPRData>(resultadoLPR, datoEnviado));

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
                    OLogsVAFunciones.LPR.Error(exception, "LPR", string.Format(new CultureInfo("en-US"), "ERROR CallbackCCR Exception, {0}", new object[] { exception.Message }));
                    OLPRCodeInfo resultadoVacioError = new OLPRCodeInfo(string.Empty, res.lProcessingTime, 0f, 0, 0, 0, 0, 0f, string.Empty, id, 0, null, 0);
                    ColaDeResultados.Enqueue(new OPair<OLPRCodeInfo, OLPRData>(resultadoVacioError, datoEnviado));
                }
            }
            return 0;
        }
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado de recepción de resultados de Vpar
        /// </summary>
        /// <param name="identificador">Identificador</param>
        /// <param name="resultado">resultado</param>
        /// <returns></returns>
        public delegate int VPARCallback(int identificador, ref VPARMtResult resultado);
        #endregion

        #region Llamadas al vparmt.dll ubicado en System

        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtInit@28", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtInit(VPARCallback callbackFunction, Int32 countryCode, Int32 AvCharHeight, Int32 DuplicateLines, Int32 Reordenar, Int32 filterColor, Int32 Trace);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtEnd@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern void vparmtEnd();
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtRead@16", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtRead(ref VPARMtConfiguration configuracion, Int32 lWidth, Int32 lHeight, IntPtr pbImageData);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadRGB24@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadRGB24(ref VPARMtConfiguration configuracion, Int32 lWidth, Int32 lHeight, IntPtr pbImageData, Int32 bVerticalFlip);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadRGB32@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadRGB32(ref VPARMtConfiguration configuracion, Int32 lWidth, Int32 lHeight, IntPtr pbImageData, Int32 bVerticalFlip);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadBMP@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadBMP(ref VPARMtConfiguration configuracion, String BmpFile);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadJPG@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadJPG(ref VPARMtConfiguration configuracion, String JPGFile);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtRead_sync@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtRead(ref VPARMtConfiguration configuracion, Int32 lWidth, Int32 lHeight, IntPtr pbImageData, ref VPARMtResult resultados);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadRGB24_sync@24", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadRGB24(ref VPARMtConfiguration configuracion, Int32 lWidth, Int32 lHeight, IntPtr pbImageData, ref VPARMtResult resultados, Int32 bVerticalFlip);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadRGB32_sync@24", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadRGB32(ref VPARMtConfiguration configuracion, Int32 lWidth, Int32 lHeight, IntPtr pbImageData, ref VPARMtResult resultados, Int32 bVerticalFlip);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadBMP_sync@12", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadBMP(ref VPARMtConfiguration configuracion, String BmpFile, ref VPARMtResult resultados);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadJPG_sync@12", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtReadJPG(ref VPARMtConfiguration configuracion, String JPGFile, ref VPARMtResult resultados);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtFindCandidateRegionsFromGreyscale@28", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtFindCandidateRegionsFromGreyscale(Int32 lWidth,
                                                                                             Int32 lHeight,
                                                                                             IntPtr pbImageData,
                                                                                             IntPtr plNumRegions,
                                                                                             ref CandidateRegion pRegions,
                                                                                             Int32 lMaxRegions,
                                                                                             bool zPreciseCoordinates
                                                                                             );
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtFindCandidateRegionsFromRGB24@32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtFindCandidateRegionsFromRGB24(Int32 lWidth,
                                                                                             Int32 lHeight,
                                                                                             IntPtr pbImageData,
                                                                                             bool bflip,
                                                                                             IntPtr plNumRegions,
                                                                                             ref CandidateRegion pRegions,
                                                                                             Int32 lMaxRegions,
                                                                                             bool zPreciseCoordinates
                                                                                             );
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtFindCandidateRegionsFromRGB32@32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtFindCandidateRegionsFromRGB32(Int32 lWidth,
                                                                                             Int32 lHeight,
                                                                                             IntPtr pbImageData,
                                                                                             bool bflip,
                                                                                             IntPtr plNumRegions,
                                                                                             ref CandidateRegion pRegions,
                                                                                             Int32 lMaxRegions,
                                                                                             bool zPreciseCoordinates
                                                                                             );
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtFindCandidateRegionsFromBMP@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtFindCandidateRegionsFromBMP(String strFilename,
                                                                                       IntPtr plNumRegions,
                                                                                       ref CandidateRegion pRegions,
                                                                                       Int32 lMaxRegions,
                                                                                       bool zPreciseCoordinates);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtFindCandidateRegionsFromJPG@20", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 _vparmtFindCandidateRegionsFromJPG(String strFilename,
                                                                                      IntPtr plNumRegions,
                                                                                      ref CandidateRegion pRegions,
                                                                                      Int32 lMaxRegions,
                                                                                      bool zPreciseCoordinates);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtQueueSize@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vparmtQueueSize();
        [DllImport("vparmtEX.dll", EntryPoint = "_FreeCores@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 FreeCores();
        [DllImport("vparmtEX.dll", EntryPoint = "_NumLicenseCores@0", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 NumLicenseCores();
        [DllImport("vparmtEX.dll", EntryPoint = "_vparComparePlates@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vpmrComparePlates(String plate1, String plate2);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtReadHasp@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vpmrReadHasp(ref byte pData, Int32 size);
        [DllImport("vparmtEX.dll", EntryPoint = "_vparmtWriteHasp@8", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern Int32 vpmrWriteHasp(ref byte pData, Int32 size);
        #endregion
    }

    #region Clases y estructuras utilizadas en vparmt.dll

    #region Estructuras
    /// <summary>
    /// Estructura del resultado  devuelto
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct VPARMtResult
    {
        [FieldOffset(0)]
        public Int32 lRes;
        [FieldOffset(4)]
        public Int32 lNumberOfPlates;
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        [FieldOffset(636)]
        public Int32[] vlFormat;
        [FieldOffset(668)]
        public Int32 lUserParam1;
        [FieldOffset(672)]
        public Int32 lUserParam2;
        [FieldOffset(676)]
        public Int32 lUserParam3;
        [FieldOffset(680)]
        public Int32 lUserParam4;
        [FieldOffset(684)]
        public Int32 lUserParam5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        [FieldOffset(688)]
        public byte[] strPathCorrectedImage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 320)]
        [FieldOffset(888)]
        public Int32[] vlCharacterPosition;
    }

    /// <summary>
    /// Estructura de la configuración
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct VPARMtConfiguration
    {
        [FieldOffset(0)]
        public Int32 lMiliseconds;
        //Correction Coefficients
        [FieldOffset(4)]
        public Int32 bAplicarCorreccion;
        [FieldOffset(8)]
        public float fDistance;
        [FieldOffset(12)]
        public float fVerticalCoeff;
        [FieldOffset(16)]
        public float fHorizontalCoeff;
        [FieldOffset(20)]
        public float fAngle;
        [FieldOffset(24)]
        public float fRadialCoeff;
        [FieldOffset(28)]
        public float fVerticalSkew;
        [FieldOffset(32)]
        public float fHorizontalSkew;
        [FieldOffset(36)]
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
        public float fScale;
        [FieldOffset(92)]
        public Int32 lUserParam1;
        [FieldOffset(96)]
        public Int32 lUserParam2;
        [FieldOffset(100)]
        public Int32 lUserParam3;
        [FieldOffset(104)]
        public Int32 lUserParam4;
        [FieldOffset(108)]
        public Int32 lUserParam5;
        [FieldOffset(112)]

        public bool CharacterRectangle;
    }
    /// <summary>
    /// Region Candidata
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CandidateRegion
    {
        [FieldOffset(0)]
        public Int32 left;	// Left coordinate of region within image (in pixels).
        [FieldOffset(4)]
        public Int32 top;		// Top coordinate of region within image (in pixels).
        [FieldOffset(8)]
        public Int32 right;	// Right coordinate of region within image (in pixels).
        [FieldOffset(12)]
        public Int32 bottom;	// Bottom coordinate of region within image (in pixels).
        [FieldOffset(16)]
        public Int32 ach;		// Approximate Average Character Height of region (in pixels).
    } 
    #endregion

    #region Clases
    /// <summary>
    /// Información de la imagen que se va a pasar al motor de VPAR
    /// </summary>
    public class OLPRInfoImagen : IDisposable
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
        public OLPRInfoImagen(Bitmap image, string path, bool autoBorradoFicheroTemporal, ref object objInfo)
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
    public class OLPRData : IDisposable
    {
        #region Campos
        /// <summary>
        /// Identificador del dato
        /// </summary>
        private long Identificador;
        /// <summary>
        /// Codigo de la función que llama
        /// </summary>
        private string CodFuncionVision;
        /// <summary>
        /// Si el valor ha sido borrado
        /// </summary>
        private bool DisposedValue;
        /// <summary>
        /// Configuración a utilizar para el dato
        /// </summary>
        private VPARMtConfiguration Configuracion;
        /// <summary>
        /// Información de la imagen
        /// </summary>
        private OLPRInfoImagen InformacionImagen;
        /// <summary>
        /// Lista con los resultados
        /// </summary>
        private List<OLPRCodeInfo> ListaResultados = new List<OLPRCodeInfo>();
        /// <summary>
        /// Cantidad de lecturas
        /// </summary>
        private int TotalReadItems;
        /// <summary>
        /// Codigo funcion
        /// </summary>
        private string codFunc;
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
        public VPARMtConfiguration Configuration
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
        public OLPRCodeInfo GetFirstItem
        {
            get
            {
                OLPRCodeInfo info = null;
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
        public OLPRInfoImagen ImageInformation
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
        public OLPRData(long ident, string codFuncion, VPARMtConfiguration cfg, ref OLPRInfoImagen pi)
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
        public void AddResultado(ref OLPRCodeInfo value)
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
                this.Configuracion = new VPARMtConfiguration();
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
    public class OLPRCodeInfo : IDisposable
    {
        #region Campos
        /// <summary>
        /// Media de altura del caracter
        /// </summary>
        private double averageCharHeigth;
        /// <summary>
        /// Posición inferior 
        /// </summary>
        private int bPosition;
        /// <summary>
        /// Vector de calidad de los caracteres
        /// </summary>
        private float[] charConfidence;
        /// <summary>
        /// Calidad global
        /// </summary>
        private double confidence;
        /// <summary>
        /// Eliminación
        /// </summary>
        private bool disposedValue = false;
        /// <summary>
        /// Identificador
        /// </summary>
        private int id;
        /// <summary>
        /// Posición izquierda
        /// </summary>
        private int lPosition;
        /// <summary>
        /// Número de caracteres reconocidos
        /// </summary>
        private int numCharacters;
        /// <summary>
        /// Matrícula
        /// </summary>
        private string plate;
        /// <summary>
        /// Formato de la matrícula reconocida
        /// </summary>
        private int plateFormat;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        private int processingTime;
        /// <summary>
        /// Posición derecha
        /// </summary>
        private int rPosition;
        /// <summary>
        /// Ruta de la imagen origen
        /// </summary>
        private string sourcePath;
        /// <summary>
        /// Posición superior
        /// </summary>
        private int tPosition;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene la altura media
        /// </summary>
        public double GetAverageCharacterHeigth
        {
            get
            {
                return this.averageCharHeigth;
            }
        }
        /// <summary>
        /// Obtiene la posición inferior
        /// </summary>
        public int GetBottomPlatePosition
        {
            get
            {
                return this.bPosition;
            }
        }
        /// <summary>
        /// Obtiene la calidad globar
        /// </summary>
        public double GetGlobalConfidence
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
        /// Obtiene la posición izquierda
        /// </summary>
        public int GetLeftPlatePosition
        {
            get
            {
                return this.lPosition;
            }
        }
        /// <summary>
        /// Obtiene el número de caracteres
        /// </summary>
        public int GetNumCharacters
        {
            get
            {
                return this.numCharacters;
            }
        }
        /// <summary>
        /// Obtiene el formato de la matrícula
        /// </summary>
        public int GetPlateFormat
        {
            get
            {
                return this.plateFormat;
            }
        }
        /// <summary>
        /// Obtiene la matrícula
        /// </summary>
        public string GetPlateNumber
        {
            get
            {
                return this.plate;
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
        /// Obtiene la posición derecha
        /// </summary>
        public int GetRightPlatePosition
        {
            get
            {
                return this.rPosition;
            }
        }
        /// <summary>
        /// Obtiene la ruta de la imagen original
        /// </summary>
        public string GetSourcePath
        {
            get
            {
                if (this.sourcePath == null)
                {
                    return "";
                }
                return this.sourcePath;
            }
        }
        /// <summary>
        /// Obtiene la posición superior
        /// </summary>
        public int GetTopPlatePosition
        {
            get
            {
                return this.tPosition;
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
        public OLPRCodeInfo(string mat, int ptime, double avgChar, int lpos, int tpos, int rpos, int bpos, double fia, string path, int ident, int nchars, float[] cConf, int frmt)
        {
            this.plate = mat;
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
            this.plateFormat = frmt;
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
        public void GetPlatePosition(ref int plLeft, ref int plTop, ref int plRight, ref int plBottom)
        {
            plLeft = this.lPosition;
            plTop = this.tPosition;
            plRight = this.rPosition;
            plBottom = this.bPosition;
        }
        /// <summary>
        /// Actualiza la ruta
        /// </summary>
        /// <param name="sp"></param>
        public void SetSourcePath(string sp)
        {
            this.sourcePath = sp;
        }
        /// <summary>
        /// Obtiene la calidad de los caracteres
        /// </summary>
        /// <returns></returns>
        public float[] GetCharConfidence()
        {
            return this.charConfidence;
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Eliminado
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                this.lPosition = 0;
                this.tPosition = 0;
                this.rPosition = 0;
                this.bPosition = 0;
                this.plate = null;
                this.confidence = 0.0;
                this.sourcePath = null;
                this.averageCharHeigth = 0.0;
                this.id = 0;
                this.numCharacters = 0;
                this.charConfidence = null;
                this.processingTime = 0;
                this.plateFormat = 0;
            }
            this.disposedValue = true;
        }
        #endregion

        #region Métodos Heredados
        /// <summary>
        /// Transforma el resultado en un string de Código(ISO)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.plate;
        }
        #endregion
    }
    #endregion

    #endregion
}