//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 12-12-2012
// Description      : Adaptada la forma de trabajar con el thread
// Last Modified By : fhernandez
// Last Modified On : 13-05-2013
// Description      : Adaptada para funcionar con wrapper propio
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.Xml;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase que ejecuta continuamente el
    /// </summary>
    internal static class OCCRManager
    {
        #region Atributo(s)
        /// <summary>
        /// Constante que indica si se limitan los núcleos a utilizar
        /// </summary>
        public static bool LimitCores = false;
        /// <summary>
        /// Constante que indica el número máximo de núcleos a utilizar
        /// </summary>
        public static int Cores = 12;
        /// <summary>
        /// Constante de altura del caracter
        /// </summary>
        public static int AvCharHeight = -1;
        /// <summary>
        /// Parámetro de cidar
        /// </summary>
        public static int DuplicateLines = 0;
        /// <summary>
        /// Trazabilidad
        /// </summary>
        public static int Trace = 0;
        /// <summary>
        /// Thread de ejecución continua del módulo CCR
        /// </summary>
        public static ThreadEjecucionCCR ThreadEjecucionCCR;
        /// <summary>
        /// Indica si alguna función de visión ha demandado el uso del CCR
        /// </summary>
        private static bool UsoDemandado = false;
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        private static void Constructor()
        {
            ThreadEjecucionCCR = new ThreadEjecucionCCR("CCR", ThreadPriority.Normal);

            // Cargamos valores de la base de datos
            DataTable dtCCR = AppBD.GetConfiguracionCCR();
            if (dtCCR.Rows.Count == 1)
            {
                LimitCores = OBooleano.Validar(dtCCR.Rows[0]["LimitCores"], false);
                Cores = OEntero.Validar(dtCCR.Rows[0]["Cores"], 1, 10000, 12);
                AvCharHeight = OEntero.Validar(dtCCR.Rows[0]["AvCharHeight"], -1, 10000, -1);
                DuplicateLines = OEntero.Validar(dtCCR.Rows[0]["DuplicateLines"], 0, 10000, 0);
                Trace = OEntero.Validar(dtCCR.Rows[0]["Trace"], 0, 1, 0);
            }
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        private static void Destructor()
        {
            ThreadEjecucionCCR.Stop(1000);
            ThreadEjecucionCCR = null;
        }

        /// <summary>
        /// Carga las propiedades de la base de datos
        /// </summary>
        private static void Inicializar()
        {
            try
            {
                // Inicializamos el motor de CCR
                OMTInterfaceCCR.Inicializar();
                // Inicializamos el motor de búsqueda de CCR
                int id = OMTInterfaceCCR.Init(OCCRManager.AvCharHeight, OCCRManager.DuplicateLines, OCCRManager.Trace, 1);
                // Almacenamos el valor de incio
                if (id == 1)
                {
                    OLogsVAFunciones.CCR.Debug("CCR", "Iniciado correctamente");
                }
                else
                {
                    OLogsVAFunciones.CCR.Error("CCR", "Error de inicialización");
                }
                // Si hemos de limitar los núcleos los limitamos
                if (OCCRManager.LimitCores)
                {
                    id = OMTInterfaceCCR.LimitCores(OCCRManager.Cores);
                    // Almacenamos el valor de incio
                    if (id == 0)
                    {
                        OLogsVAFunciones.CCR.Error("CCR", "Error limitando Cores");
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "CCR");
            }

            //ThreadEjecucionCCR.Start();
            ThreadEjecucionCCR.StartPaused();
        }

        /// <summary>
        /// Finaliza la ejecución
        /// </summary>
        private static void Finalizar()
        {
            ThreadEjecucionCCR.Stop(1000);

            // Liberamos memoria reservada para la libreria de CCR, cuando termina de procesar las imagenes
            OMTInterfaceCCR.QueryEnd();
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Resetea la función de visión CCR
        /// </summary>
        internal static void Reset()
        {
            // Detenemos el Hilo
            ThreadEjecucionCCR.Pause();

            int id = OMTInterfaceCCR.Reset();
            // Almacenamos el valor de incio
            if (id == 0)
            {
                OLogsVAFunciones.CCR.Debug("CCR", "Error reseteando el wrapper");
                // Lo realizamos a lo bestia como antes
                // Liberamos memoria reservada para la libreria de CCR, cuando termina de procesar las imagenes
                OMTInterfaceCCR.QueryEnd();
                // Inicializamos el motor de búsqueda de CCR
                OMTInterfaceCCR.Init(OCCRManager.AvCharHeight, OCCRManager.DuplicateLines, OCCRManager.Trace, 1);
            }
            // Reiniciamos el hilo
            ThreadEjecucionCCR.Resume();
        }

        /// <summary>
        /// Se demanda el uso del CCR, por lo que se necesita iniciar las librerías correspondientes
        /// </summary>
        internal static void DemandaUso()
        {
            if (!UsoDemandado)
            {
                UsoDemandado = true;

                // Constructor de las funciones CCR
                OCCRManager.Constructor();

                // Inicialización de las funciones CCR
                OCCRManager.Inicializar();
            }
        }

        /// <summary>
        /// Se elimina la demanda el uso del CCR, por lo que se necesita finalizar las librerías correspondientes
        /// </summary>
        internal static void FinDemandaUso()
        {
            if (UsoDemandado)
            {
                UsoDemandado = false;

                // Finalización de las funciones CCR
                OCCRManager.Finalizar();

                // Destructor de las funciones CCR
                OCCRManager.Destructor();
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que ejecuta el reconocimiento de los codigos en un thread
    /// </summary>
    internal class ThreadEjecucionCCR : OThreadLoop
    {
        #region Atributo(s)
        /// <summary>
        /// Indica si se ha de finalizar la ejecución del thread
        /// </summary>
        public bool Finalizar;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionCCR(string codigo)
            : base(codigo)
        {
            this.Finalizar = false;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionCCR(string codigo, ThreadPriority threadPriority)
            : base(codigo, 1, threadPriority)
        {
            this.Finalizar = false;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Ejecuta el callback en el mismo thread que la Applicación principal
        /// </summary>
        private void CallBack(CallBackResultadoParcial callBack, EventArgsResultadoParcial argumentoEvento)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                OThreadManager.SincronizarConThreadPrincipal(new DelegadoCallBack(this.CallBack), new object[] { callBack, argumentoEvento });
                return;
            }

            // Llamada al callback
            if (callBack != null)
            {
                callBack(this, argumentoEvento);
            }
        }
        #endregion

        #region Definición de delegado(s)
        /// <summary>
        /// Delegado de ejecución del callback
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="argumentoEvento"></param>
        private delegate void DelegadoCallBack(CallBackResultadoParcial callBack, EventArgsResultadoParcial argumentoEvento);
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método heredado para implementar la ejecución del thread.
        /// Este método se está ejecutando en un bucle. Para salir del bucle hay que devolver finalize a true.
        /// </summary>
        protected override void Ejecucion(ref bool finalize)
        {
            finalize = this.Finalizar;

            try
            {
                if (!this.Finalizar)
                {
                    OPair<OCCRCodeInfo, OCCRData> resultado = OMTInterfaceCCR.GetResultado();

                    if (resultado != null)
                    {
                        // Guardamos la traza
                        OLogsVAFunciones.Vision.Debug(this.Codigo, "Ejecución de la función CCR " + this.Codigo, "Número de elementos pendientes: " + OMTInterfaceCCR.GetQueueSizeCIDARMT() + OMTInterfaceCCR.GetQueueSize());

                        OCCRCodeInfo info = resultado.First;
                        OInfoInspeccionCCR infoInspeccionCCR = (OInfoInspeccionCCR)resultado.Second.ImageInformation.GetObject; // Obtengo la información de entrada de la inspección
                        OResultadoCCR resultadoParcial = new OResultadoCCR(info, resultado.Second.ImageInformation.GetTimestamp); // Obtengo el resultado parcial
                        infoInspeccionCCR.Resultados = resultadoParcial; // Añado el resultado a la información de la inspección

                        EventArgsResultadoParcial argumentoEvento = new EventArgsResultadoParcial(infoInspeccionCCR); // Creación del argumento del evento
                        CallBackResultadoParcial callBack = infoInspeccionCCR.Info.CallBackResultadoParcial; // Obtención del callback
                        this.CallBack(callBack, argumentoEvento); // Llamada al callback

                        // Eliminamos la imagen temporal 
                        if (infoInspeccionCCR.Parametros.RealizarProcesoPorDisco)
                        {
                            try
                            {
                                File.Delete(infoInspeccionCCR.Info.RutaImagenTemporal);
                            }
                            catch (Exception exception)
                            {
                                OLogsVAFunciones.CCR.Error(exception, "Eliminando imagen temporal de la ruta :" + infoInspeccionCCR.Info.RutaImagenTemporal);
                            }
                        }

                        // Guardamos en la traza el resultado
                        String codeNumber = info.GetCodeNumber;
                        String fcode = info.ToString();
                        fcode += "(FC:" + Math.Round(info.GetGlobalConfidence, 1) + ")";
                        fcode += "(FI:" + Math.Round(info.GetExtraInfoConfidence, 1) + ")";
                        fcode += "(AC:" + info.GetAverageCharacterHeigth + ")";
                        fcode += "(T:" + info.GetProcessingTime + ")";
                        OLogsVAFunciones.CCR.Debug(this.Codigo, "Resultado recibido:" + fcode);

                        if (info != null)
                        {
                            info.Dispose();
                        }
                        resultado.First.Dispose();
                        resultado.Second.Dispose();
                        resultado = null;
                    }

                    // Se suspende el thread si no hay más elementos que inspeccionar
                    if ((OMTInterfaceCCR.GetQueueSizeCIDARMT() == 0) && (OMTInterfaceCCR.GetQueueSize() == 0) && (OMTInterfaceCCR.GetUsedCores() == 0))
                    {
                        OLogsVAFunciones.CCR.Debug("Thread de procesado de CCR pausado por no haber imagenes que procesar");
                        this.Pause();
                    }
                }
            }
            catch (ThreadAbortException)
            {
                // TODO Do nothing
            }
            catch (ApplicationException)
            {
                // TODO Do nothing
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, this.Codigo);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que realizara la función de reconocimiento de CCR
    /// </summary>
    public class OFuncionVisionCCR : OFuncionVisionEncolada
    {
        #region Constante(s)
        /// <summary>
        /// Número máximo de inspecciones en la cola de ejecución
        /// </summary>
        private const int MaxInspeccionesEnCola = 100;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Siguiente parametros de entrada a procesar en el CCR
        /// </summary>
        private OParametrosCCR ParametrosCCR;
        /// <summary>
        /// Siguiente imágen a procesar en el CCR
        /// </summary>
        private OImagenBitmap Imagen;
        /// <summary>
        /// Siguiente ruta de imágen a procesar en el CCR
        /// </summary>
        private string RutaImagenTemporal;
        /// <summary>
        /// Lista de información adicional incorporada por el controlador externo
        /// </summary>
        private Dictionary<string, object> InformacionAdicional;
        /// <summary>
        /// Para saber la cantidad de imagenes guardadas por disco en cada ejecucion
        /// </summary>
        private int ContadorImagenesPorDisco;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OFuncionVisionCCR(string codFuncionVision)
            : base(codFuncionVision)
        {
            try
            {
                // Demanda del uso de CCR
                OCCRManager.DemandaUso();

                this.Valido = true;
                this.ParametrosCCR = new OParametrosCCR();
                this.InformacionAdicional = new Dictionary<string, object>();
                this.ContadorImagenesPorDisco = 0;

                // Cargamos valores de la base de datos
                DataTable dtFuncionVision = AppBD.GetFuncionVision(this.Codigo);
                if (dtFuncionVision.Rows.Count == 1)
                {
                    this.ParametrosCCR.Altura = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Altura"], -1, 10000, -1);
                    this.ParametrosCCR.ActivadoRangoAlturas = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadoRangoAlturas"], 0, 1, 0);
                    this.ParametrosCCR.AlturaMin = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaMin"], 1, 10000, 30);
                    this.ParametrosCCR.AlturaMax = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaMax"], 1, 10000, 60);
                    this.ParametrosCCR.VectorAlturas = new int[2] { this.ParametrosCCR.AlturaMin, this.ParametrosCCR.AlturaMax };
                    this.ParametrosCCR.TimeOut = OEntero.Validar(dtFuncionVision.Rows[0]["NL_TimeOut"], 0, 1000000, 0);
                    this.ParametrosCCR.ActivadaAjusteCorreccion = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadaAjusteCorrecion"], 0, 1, 0);
                    this.ParametrosCCR.CoeficienteHorizontal = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteHorizontal"], -100000, +100000, 0);
                    this.ParametrosCCR.CoeficienteVertical = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteVertical"], -100000, +100000, 0);
                    this.ParametrosCCR.CoeficienteRadial = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteRadial"], -100000, +100000, 0);
                    this.ParametrosCCR.AnguloRotacion = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_AnguloRotacion"], -100000, +100000, 0);
                    this.ParametrosCCR.InclinacionVertical = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_InclinacionVertical"], -100000, +100000, 0);
                    this.ParametrosCCR.InclinacionHorizontal = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_InclinacionHorizontal"], -100000, +100000, 0);
                    this.ParametrosCCR.Distancia = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_Distancia"], 0, +100000, 0);
                    this.ParametrosCCR.CoordIzq = OEntero.Validar(dtFuncionVision.Rows[0]["NL_CoordIzq"], 0, 10000, 0);
                    this.ParametrosCCR.CoordArriba = OEntero.Validar(dtFuncionVision.Rows[0]["NL_CoordArriba"], 0, 10000, 0);
                    this.ParametrosCCR.AlturaVentanaBusqueda = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaVentanaBusqueda"], 0, 10000, 0);
                    this.ParametrosCCR.AnchuraVentanaBusqueda = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AnchuraVentanaBusqueda"], 0, 10000, 0);
                    this.ParametrosCCR.ActivadaMasInformacion = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadaMasInformacion"], 0, 10000, 1);
                    this.ParametrosCCR.Escala = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_Escala"], 0, +100000, 0);
                    this.ParametrosCCR.Param1 = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Param1"], 0, 10000, 1);
                    this.ParametrosCCR.Param2 = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Param2"], 0, 10000, 1);
                    this.ParametrosCCR.OrbitaCorreccionPerspectiva = new OCorreccionPerspectiva(dtFuncionVision.Rows[0]);
                    this.ParametrosCCR.RealizarProcesoPorDisco = OBooleano.Validar(dtFuncionVision.Rows[0]["NL_EjecucionPorDisco"], false);
                    this.ParametrosCCR.RutaEjecucionPorDisco = OTexto.Validar(dtFuncionVision.Rows[0]["NL_RutaTemporalEjecucion"], int.MaxValue, true, false, string.Empty);
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "FuncionCCR");
            }
        }       
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Cargamos la configuracion de los parametros pasados por parámetro en caso de necesidad
        /// </summary>
        private void EstablecerConfiguracion(OParametrosCCR parametros)
        {
            // Ejecutamos la configuración
            OMTInterfaceCCR.SetConfiguracion(parametros);
        }
        /// <summary>
        /// Comprueba que el archivo no este en uso
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        #endregion

        #region Método publicos
        /// <summary>
        /// Realiza un reset de la función de visión de CCR que esta en ejecución
        /// </summary>
        public void Reset()
        {
            // Guardamos la traza
            OLogsVAFunciones.CCR.Debug(this.Codigo, "Se procede a resetear la función de visión " + this.Codigo);

            OCCRManager.Reset();

            // Ya no existen inspecciones pendientes
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;

            // Se finaliza la ejecución de la función de visión
            this.FuncionEjecutada();

            // Guardamos la traza
            OLogsVAFunciones.CCR.Debug(this.Codigo, "Reset de la función de visión " + this.Codigo + " realizado con éxito");
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Ejecución de la función de CCR de forma encolada
        /// </summary>
        /// <returns></returns>
        protected override bool EjecucionEncolada()
        {
            bool resultado = false;
            resultado = base.EjecucionEncolada();

            // Se añade una nueva inspección a la cola
            try
            {
                // Añadimos inspecciones de forma bloqueante
                if (OMTInterfaceCCR.IsRunning())
                {
                    if (OMTInterfaceCCR.GetQueueSize() < MaxInspeccionesEnCola)
                    {
                        // Se aumenta el número de inspecciones en cola
                        this.ContInspeccionesEnCola++;
                        this.IndiceFotografia++;
                        // Si vamos por disco tenemos que rellenar la ruta
                        if (this.ParametrosCCR.RealizarProcesoPorDisco)
                        {
                            this.RutaImagenTemporal = Path.Combine(this.ParametrosCCR.RutaEjecucionPorDisco, this.Codigo + "_" + this.ContadorImagenesPorDisco.ToString() + ".bmp");
                            this.ContadorImagenesPorDisco++;
                        }
                        // Creamos el objeto con la información que nos interesa, no le pasamos la imagen para que no crezca la memoria
                        OInfoInspeccionCCR infoInspeccionCCR = new OInfoInspeccionCCR(
                                this.Imagen,
                                this.ParametrosCCR,
                                new OInfoImagenCCR(this.IdEjecucionActual, this.Codigo, this.IndiceFotografia, DateTime.Now, this.RutaImagenTemporal, AñadirResultadoParcial),
                                new OResultadoCCR(),
                                this.InformacionAdicional);

                        // Se carga la configuración
                        this.EstablecerConfiguracion((OParametrosCCR)this.ParametrosCCR);
                        object info = infoInspeccionCCR;
                       
                        // Se carga la imagen
                        //  Si tenemos ruta y imagenes es null, pasamos la ruta y sino viceversa
                        if (this.Imagen == null)
                        {
                            // Corrección de distorsión
                            ONerualLabsUtils.CorreccionPerspectivaDisco(this.RutaImagenTemporal, this.ParametrosCCR.OrbitaCorreccionPerspectiva);

                            // adición de imagen
                            if (!OFicheros.FicheroBloqueado(this.RutaImagenTemporal, 5000))
                            {
                                OMTInterfaceCCR.Add(this.Codigo,this.RutaImagenTemporal, false, info);
                            }
                            else
                            {
                                OLogsVAFunciones.CCR.Info("FuncionCCR: Fichero de imagen bloqueada");
                            }
                        }
                        else
                        {
                            // Corrección de distorsión
                            OImagenBitmap imagenTrabajo = ONerualLabsUtils.CorreccionPerspectivaMemoria(this.Imagen, this.ParametrosCCR.OrbitaCorreccionPerspectiva);

                            // En caso de tener que pasar las imagenes al motor por disco antes tenemos que guardarlas
                            if (this.ParametrosCCR.RealizarProcesoPorDisco)
                            {
                                imagenTrabajo.Image.Save(this.RutaImagenTemporal);
                                if (!OFicheros.FicheroBloqueado(this.RutaImagenTemporal, 5000))
                                {
                                    OMTInterfaceCCR.Add(this.Codigo,this.RutaImagenTemporal, true, info);
                                }
                            }
                            else
                            {
                                // adición de imagen
                                OMTInterfaceCCR.Add(this.Codigo,imagenTrabajo.Image, info);
                            }
                            
                        }

                        // Se despierta el thread
                        OLogsVAFunciones.CCR.Debug("Imagen añadida", "Número de imagenes encoladas: " + OMTInterfaceCCR.GetQueueSize() + OMTInterfaceCCR.GetQueueSizeCIDARMT());
                        OCCRManager.ThreadEjecucionCCR.Resume();
                    }
                    else
                    {
                        // Temporal hasta que lo soluccionen
                        OLogsVAFunciones.CCR.Info("FuncionCCR: Sobrepasado el limite de imagenes en cola");
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "FuncionCCR");
            }

            // Se reseta el diccionario de informacción adicional
            this.InformacionAdicional = new Dictionary<string, object>();

            return resultado;
        }

        /// <summary>
        /// Indica que hay inspecciones pendientes de ejecución
        /// </summary>
        /// <returns></returns>
        public override bool HayInspeccionesPendientes()
        {
            bool resultado = base.HayInspeccionesPendientes();

            resultado |= OMTInterfaceCCR.GetQueueSize(this.Codigo) > 0;
            resultado |= this.ContInspeccionesEnCola > 0;

            return resultado;
        }

        /// <summary>
        /// Resetea la cola de ejecución
        /// </summary>
        public override void ResetearColaEjecucion()
        {
            base.ResetearColaEjecucion();
            OMTInterfaceCCR.Reset();
            this.InformacionAdicional = new Dictionary<string, object>();
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            bool resultado = false;

            try
            {
                if (codigo == "Imagen")
                {
                    this.Imagen = (OImagenBitmap)valor;
                }
                else if (codigo == "Parametros")
                {
                    this.ParametrosCCR = (OParametrosCCR)valor;
                }
                else if (codigo == "RutaImagen")
                {
                    this.RutaImagenTemporal = (string)valor;
                }
                else
                {
                    this.InformacionAdicional[codigo] = valor;
                    //throw new Exception("Error en la asignación del parámetro '" + entrada.Nombre + "' a la función '" + this.Codigo + "'. No se admite este tipo de parámetros.");
                }
                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, this.Codigo);
            }
            return resultado;
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(EnumTipoEntradaFuncionVision tipoEntrada, object valor, OEnumTipoDato tipoVariable)
        {
            return SetEntrada(tipoEntrada.Nombre, valor, tipoVariable);
        }
        #endregion
    }


    /// <summary>
    /// Clase que contiene la información referente a la inspección
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TParametros"></typeparam>
    /// <typeparam name="TResultados"></typeparam>
    public class OInfoInspeccionCCR : OInfoInspeccion<OImagenBitmap, OParametrosCCR, OInfoImagenCCR, OResultadoCCR>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OInfoInspeccionCCR()
            : base()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="info"></param>
        /// <param name="parametros"></param>
        /// <param name="resultados"></param>
        public OInfoInspeccionCCR(OImagenBitmap imagen, OParametrosCCR parametros, OInfoImagenCCR info, OResultadoCCR resultados, Dictionary<string, object> informacionAdicional)
            : base(imagen, parametros, info, resultados, informacionAdicional)
        {
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene los parametros de configuracion del CCR
    /// </summary>
    public class OParametrosCCR
    {
        #region Atributo(s)
        /// <summary>
        /// Altura del caracter
        /// </summary>
        public int Altura;
        /// <summary>
        /// Para tener en cuenta el rango de alturas
        /// </summary>
        public int ActivadoRangoAlturas;
        /// <summary>
        /// Altura Minima
        /// </summary>
        public int AlturaMin;
        /// <summary>
        /// Altura Máxima
        /// </summary>
        public int AlturaMax;
        /// <summary>
        /// Vector que contendra las alturas
        /// </summary>
        public Int32[] VectorAlturas;
        /// <summary>
        /// timeout de ejecución
        /// </summary>
        public int TimeOut;
        /// <summary>
        /// activa el ajuste de la correcion
        /// </summary>
        public int ActivadaAjusteCorreccion;
        /// <summary>
        /// Coeficiente de Correccion de la perspectiva Horizontal
        /// </summary>
        public float CoeficienteHorizontal;
        /// <summary>
        /// Coeficiente de Correccion de la perspectiva Vertical
        /// </summary>
        public float CoeficienteVertical;
        /// <summary>
        /// Coeficiente para el ojo de pez
        /// </summary>
        public float CoeficienteRadial;
        /// <summary>
        /// Coeficiente de la corrección del ángulo de rotación
        /// </summary>
        public float AnguloRotacion;
        /// <summary>
        /// Inclinación vertical
        /// </summary>
        public float InclinacionVertical;
        /// <summary>
        /// Inclinación vertical
        /// </summary>
        public float InclinacionHorizontal;
        /// <summary>
        /// Distancia al código desde la camara en metros
        /// </summary>
        public float Distancia;
        /// <summary>
        /// Coordenada izquierda ventana
        /// </summary>
        public int CoordIzq;
        /// <summary>
        /// Coordenada superior ventana
        /// </summary>
        public int CoordArriba;
        /// <summary>
        /// Altura de la ventana de búsqueda
        /// </summary>
        public int AlturaVentanaBusqueda;
        /// <summary>
        /// Anchura de la ventana de búsqueda
        /// </summary>
        public int AnchuraVentanaBusqueda;
        /// <summary>
        /// Se le indica si se desea buscar más información extra en la imagén
        /// </summary>
        public int ActivadaMasInformacion;
        /// <summary>
        /// Escala 
        /// </summary>
        public float Escala;
        /// <summary>
        /// Parámetro1
        /// </summary>
        public int Param1;
        /// <summary>
        /// Parámetro2
        /// </summary>
        public int Param2;
        /// <summary>
        /// Parámetros de corrección de perspectiva de Orbita
        /// </summary>
        public OCorreccionPerspectiva OrbitaCorreccionPerspectiva;
        /// <summary>
        /// Para pasar a las librerias una ruta de imagen y no el bitmap
        /// </summary>
        public bool RealizarProcesoPorDisco;
        /// <summary>
        /// Ruta utilizada para pasar la imagen por disco
        /// </summary>
        public string RutaEjecucionPorDisco;
        #endregion Campos

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase sin parámetros
        /// </summary>
        public OParametrosCCR()
        {
            this.Altura = -1;
            this.ActivadoRangoAlturas = 0;
            this.AlturaMin = 30;
            this.AlturaMax = 60;
            this.VectorAlturas = new Int32[2];
            this.VectorAlturas[0] = AlturaMin;
            this.VectorAlturas[1] = AlturaMax;
            this.TimeOut = 5000;
            this.ActivadaAjusteCorreccion = 0;
            this.CoeficienteHorizontal = 0;
            this.CoeficienteVertical = 0;
            this.CoeficienteRadial = 0;
            this.AnguloRotacion = 0;
            this.InclinacionVertical = 0;
            this.InclinacionHorizontal = 0;
            this.Distancia = 0;
            this.CoordArriba = 0;
            this.CoordIzq = 0;
            this.AlturaVentanaBusqueda = 0;
            this.AnchuraVentanaBusqueda = 0;
            this.ActivadaMasInformacion = 1;
            this.Escala = 0;
            this.Param1 = 0;
            this.Param2 = 0;
            this.OrbitaCorreccionPerspectiva = new OCorreccionPerspectiva();
            this.RealizarProcesoPorDisco = false;
            this.RutaEjecucionPorDisco = Path.GetTempPath(); 
        }
        #endregion Constructores
    }

    /// <summary>
    /// Esta clase contendra la información que queremos pasar con la imagen al CCR para recogerla cuando tengamos el resultado
    /// </summary>
    public class OInfoImagenCCR : OConvertibleXML
    {
        #region Propiedades(s)
        /// <summary>
        /// Contiene la información de la identificacion a la que pertenece
        /// </summary>
        private long _IdEjecucionActual;
        /// <summary>
        /// Contiene la información de la identificacion a la que pertenece
        /// </summary>
        public long IdEjecucionActual
        {
            get { return _IdEjecucionActual; }
            set
            {
                this._IdEjecucionActual = value;
                this.Propiedades["IdEjecucionActual"] = value;
            }
        }

        /// <summary>
        /// Contiene la información de la cámara que se le pasa en la imagen
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Contiene la información de la cámara que se le pasa en la imagen
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set
            {
                this._Codigo = value;
                this.Propiedades["CodigoCamara"] = value;
            }
        }

        /// <summary>
        /// Contiene el indice de la imagen añadida
        /// </summary>
        private int _IndiceImagen;
        /// <summary>
        /// Contiene el indice de la imagen añadida
        /// </summary>
        public int IndiceImagen
        {
            get { return _IndiceImagen; }
            set
            {
                this._IndiceImagen = value;
                this.Propiedades["IndiceImagen"] = value;
            }
        }

        /// <summary>
        /// Contiene la fecha exacta en la que se adquirio la imagen
        /// </summary>
        private DateTime _MomentoImagen;
        /// <summary>
        /// Contiene la fecha exacta en la que se adquirio la imagen
        /// </summary>
        public DateTime MomentoImagen
        {
            get { return _MomentoImagen; }
            set
            {
                this._MomentoImagen = value;
                this.Propiedades["MomentoImagen"] = value;
            }
        }

        /// <summary>
        /// Ruta de la imagen temporal
        /// </summary>
        private string _RutaImagenTemporal;
        /// <summary>
        /// Ruta de la imagen temporal
        /// </summary>
        public string RutaImagenTemporal
        {
            get { return _RutaImagenTemporal; }
            set
            {
                this._RutaImagenTemporal = value;
                this.Propiedades["RutaImagenTemporal"] = value;
            }
        }

        /// <summary>
        /// CallBack donde mandar el resultado parcial
        /// </summary>
        internal CallBackResultadoParcial CallBackResultadoParcial;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OInfoImagenCCR()
        {
            this.IdEjecucionActual = 0;
            this.Codigo = string.Empty;
            this.IndiceImagen = 0;
            this.MomentoImagen = DateTime.Now;
            this.RutaImagenTemporal = string.Empty;
            this.CallBackResultadoParcial = null;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="camara">camara que adquiere la imagen</param>
        public OInfoImagenCCR(long idEjecucionActual, string codCamara, int indice, DateTime momentoImagen, string rutaImagenTemporal, CallBackResultadoParcial callBackResultadoParcial)
        {
            this.IdEjecucionActual = idEjecucionActual;
            this.Codigo = codCamara;
            this.IndiceImagen = indice;
            this.MomentoImagen = momentoImagen;
            this.RutaImagenTemporal = rutaImagenTemporal;
            this.CallBackResultadoParcial = callBackResultadoParcial;
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene los resultados que se reciben del CCR para una imagen pasada anteriormente
    /// </summary>
    public class OResultadoCCR : OConvertibleXML
    {
        #region Propiedades(s)
        /// <summary>
        /// Contiene la cadena del codigo del contenedor
        /// </summary>
        private string _CodigoContenedor;
        /// <summary>
        /// Contiene la cadena del codigo del contenedor
        /// </summary>
        public string CodigoContenedor
        {
            get { return _CodigoContenedor; }
            set
            {
                this._CodigoContenedor = value;
                this.Propiedades["CodigoContenedor"] = value;
            }
        }

        /// <summary>
        /// Contiene la información extra del código del contenedor
        /// </summary>
        private string _ExtaInfoCodigo;
        /// <summary>
        /// Contiene la información extra del código del contenedor
        /// </summary>
        public string ExtaInfoCodigo
        {
            get { return _ExtaInfoCodigo; }
            set
            {
                this._ExtaInfoCodigo = value;
                this.Propiedades["ExtaInfoCodigo"] = value;
            }
        }

        /// <summary>
        /// Si esta verificado el digito de control
        /// </summary>
        private bool _CodigoVerificado;
        /// <summary>
        /// Si esta verificado el digito de control
        /// </summary>
        public bool CodigoVerificado
        {
            get { return _CodigoVerificado; }
            set
            {
                this._CodigoVerificado = value;
                this.Propiedades["CodigoVerificado"] = value;
            }
        }

        /// <summary>
        /// Fiabilidad Código
        /// </summary>
        private int _FiabilidadCodigo;
        /// <summary>
        /// Fiabilidad Código
        /// </summary>
        public int FiabilidadCodigo
        {
            get { return _FiabilidadCodigo; }
            set
            {
                this._FiabilidadCodigo = value;
                this.Propiedades["FiabilidadCodigo"] = value;
            }
        }

        /// <summary>
        /// Fiabilidad ExtraInfo
        /// </summary>
        private int _FiabilidadExtraInfo;
        /// <summary>
        /// Fiabilidad ExtraInfo
        /// </summary>
        public int FiabilidadExtraInfo
        {
            get { return _FiabilidadExtraInfo; }
            set
            {
                this._FiabilidadExtraInfo = value;
                this.Propiedades["FiabilidadExtraInfo"] = value;
            }
        }

        /// <summary>
        /// Altura letras
        /// </summary>
        private int _AlturaLetrasCodigo;
        /// <summary>
        /// Altura letras
        /// </summary>
        public int AlturaLetrasCodigo
        {
            get { return _AlturaLetrasCodigo; }
            set
            {
                this._AlturaLetrasCodigo = value;
                this.Propiedades["AlturaLetrasCodigo"] = value;
            }
        }
        /// <summary>
        /// Fecha en la que se encolo a la cola de CCR (dada por él)
        /// </summary>
        private DateTime _FechaEncolamiento;
        /// <summary>
        /// Fecha en la que se encolo a la cola de CCR (dada por él)
        /// </summary>
        public DateTime FechaEncolamiento
        {
            get { return _FechaEncolamiento; }
            set
            {
                this._FechaEncolamiento = value;
                this.Propiedades["FechaEncolamiento"] = value;
            }
        }

        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        private int _TiempoDeProceso;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        public int TiempoDeProceso
        {
            get { return _TiempoDeProceso; }
            set
            {
                this._TiempoDeProceso = value;
                this.Propiedades["TiempoDeProceso"] = value;
            }
        }

        /// <summary>
        /// Contiene las fiabilidades de cada letra individual
        /// </summary>
        private float[] _FiabilidadesLetras;
        /// <summary>
        /// Contiene las fiabilidades de cada letra individual
        /// </summary>
        public float[] FiabilidadesLetras
        {
            get { return _FiabilidadesLetras; }
            set
            {
                this._FiabilidadesLetras = value;
                this.Propiedades["FiabilidadesLetras"] = value;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OResultadoCCR()
        {
            this.CodigoContenedor = "";
            this.ExtaInfoCodigo = "";
            this.CodigoVerificado = false;
            this.FiabilidadCodigo = 0;
            this.FiabilidadExtraInfo = 0;
            this.AlturaLetrasCodigo = 0;
            this.TiempoDeProceso = 0;
            this.FechaEncolamiento = new DateTime();
            this.FiabilidadesLetras = new float[11];
            for (int i = 0; i < this.FiabilidadesLetras.Length; i++)
            {
                this.FiabilidadesLetras[i] = 0;
            }
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        public OResultadoCCR(OCCRCodeInfo resultadoImagen, DateTime fechaEncola)
        {
            try
            {
                // Código del contenedor
                this.CodigoContenedor = OTexto.Validar(resultadoImagen.GetCodeNumber);

                // Si tenemos código identificado , obtenemos las fiabilidades de cada una de las letras
                float[] fiabilidadesLetras = new float[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                if (!string.IsNullOrEmpty(this.CodigoContenedor) && (resultadoImagen.GetCharConfidence != null) && (resultadoImagen.GetCharConfidence.Length > 0) && (resultadoImagen.GetCharConfidence.Length <= fiabilidadesLetras.Length))
                {
                    float[] fiabilidades = resultadoImagen.GetCharConfidence;
                    for (int i = 0; i < fiabilidades.Length; i++)
                    {
                        fiabilidadesLetras[i] = (float)ODecimal.Validar(fiabilidades[i]);
                    }
                }
                this.FiabilidadesLetras = fiabilidadesLetras;

                // Si tenemos información extra la obtenemos
                this.ExtaInfoCodigo = OTexto.Validar(resultadoImagen.GetExtraInfoCodeNumber);
                this.FiabilidadExtraInfo = OEntero.Validar(resultadoImagen.GetExtraInfoConfidence);

                // Obtenemos el resto de resultados independientes
                this.CodigoVerificado = OBooleano.Validar(resultadoImagen.IsCodeVerified);
                this.FiabilidadCodigo = OEntero.Validar(resultadoImagen.GetGlobalConfidence);
                this.AlturaLetrasCodigo = OEntero.Validar(resultadoImagen.GetAverageCharacterHeigth);
                this.TiempoDeProceso = OEntero.Validar(resultadoImagen.GetProcessingTime);
                this.FechaEncolamiento = fechaEncola;
            }
            catch (Exception exception)
            {
                // En caso de que se produzca cualquier error no contemplado, descartaremos el resultado recibido permitiendo continuar la ejecución
                this.CodigoContenedor = string.Empty;
                this.ExtaInfoCodigo = string.Empty;
                this.CodigoVerificado = false;
                this.FiabilidadCodigo = 0;
                this.FiabilidadExtraInfo = 0;
                this.AlturaLetrasCodigo = 0;
                this.TiempoDeProceso = 0;
                this.FechaEncolamiento = new DateTime();
                this.FechaEncolamiento = DateTime.Now;
                this.FiabilidadesLetras = new float[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                OLogsVAFunciones.CCR.Info(exception, "FuncionCCR:" + resultadoImagen.GetAverageCharacterHeigth
                     + " " + resultadoImagen.GetGlobalConfidence
                        + " " + resultadoImagen.GetExtraInfoConfidence);
            }
        }
        #endregion
    }

    /// <summary>
    /// Define el conjunto de tipos de entradas de las funciones de visión CCR
    /// </summary>
    public class EntradasFuncionesVisionCCR : TipoEntradasFuncionesVision
    {
        #region Atributo(s)
        /// <summary>
        /// Ruta en disco de la imagen de entrada
        /// </summary>
        public static EnumTipoEntradaFuncionVision RutaImagen = new EnumTipoEntradaFuncionVision("RutaImagen", "Ruta en disco de la imagen de entrada", 202);
        #endregion
    }
}




