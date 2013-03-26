//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 12-12-2012
// Description      : Adaptada la forma de trabajar con el thread
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
using CIDARMTWrapper;
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
        /// Thread de ejecuci�n continua del m�dulo CCR
        /// </summary>
        public static ThreadEjecucionCCR ThreadEjecucionCCR;

        /// <summary>
        /// Indica si alguna funci�n de visi�n ha demandado el uso del CCR
        /// </summary>
        private static bool UsoDemandado = false;

        /// <summary>
        /// Par�metros de configuraci�n del CCR
        /// </summary>
        private static ConfiguracionCCR Configuracion;
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        private static void Constructor()
        {
            ThreadEjecucionCCR = new ThreadEjecucionCCR("CCR", ThreadPriority.Normal);
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
                try
                {
                    OCCRManager.Configuracion = (ConfiguracionCCR)(new ConfiguracionCCR().CargarDatos());
                }
                catch (FileNotFoundException exception)
                {
                    OLogsVAFunciones.CCR.Error(exception, "CCR");
                    OCCRManager.Configuracion = new ConfiguracionCCR();
                    OCCRManager.Configuracion.Guardar();
                }

                // Inicializamos el motor de b�squeda de CCR
                int id = MTInterface.Init(OCCRManager.Configuracion.AvCharHeight, OCCRManager.Configuracion.DuplicateLines, OCCRManager.Configuracion.Trace, OCCRManager.Configuracion.TraceWrapper);
                // Almacenamos el valor de incio
                if (id == 1)
                {
                    OLogsVAFunciones.CCR.Debug("CCR", "Iniciado correctamente");
                }
                else
                {
                    OLogsVAFunciones.CCR.Error("CCR", "Error de inicializaci�n");
                }
                // Si hemos de limitar los n�cleos los limitamos
                if (OCCRManager.Configuracion.LimitCores)
                {
                    id = MTInterface.LimitCores(OCCRManager.Configuracion.Cores);
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

            ThreadEjecucionCCR.Start();
        }

        /// <summary>
        /// Finaliza la ejecuci�n
        /// </summary>
        private static void Finalizar()
        {
            ThreadEjecucionCCR.Stop(1000);

            // Liberamos memoria reservada para la libreria de CCR, cuando termina de procesar las imagenes
            MTInterface.QueryEnd();
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Resetea la funci�n de visi�n CCR
        /// </summary>
        public static void Reset()
        {
            // Detenemos el Hilo
            ThreadEjecucionCCR.Pause();
            
            int id = MTInterface.Reset();
            // Almacenamos el valor de incio
            if (id == 0)
            {
                OLogsVAFunciones.CCR.Debug("CCR", "Error reseteando el wrapper");
                // Lo realizamos a lo bestia como antes
                // Liberamos memoria reservada para la libreria de CCR, cuando termina de procesar las imagenes
                MTInterface.QueryEnd();
                // Inicializamos el motor de b�squeda de CCR
                MTInterface.Init(OCCRManager.Configuracion.AvCharHeight, OCCRManager.Configuracion.DuplicateLines, OCCRManager.Configuracion.Trace, OCCRManager.Configuracion.TraceWrapper);
            }
            // Reiniciamos el hilo
            ThreadEjecucionCCR.Resume();
        }

        /// <summary>
        /// Se demanda el uso del CCR, por lo que se necesita iniciar las librer�as correspondientes
        /// </summary>
        public static void DemandaUso()
        {
            if (!UsoDemandado)
            {
                UsoDemandado = true;

                // Constructor de las funciones CCR
                OCCRManager.Constructor();

                // Inicializaci�n de las funciones CCR
                OCCRManager.Inicializar();
            }
        }

        /// <summary>
        /// Se elimina la demanda el uso del CCR, por lo que se necesita finalizar las librer�as correspondientes
        /// </summary>
        public static void FinDemandaUso()
        {
            if (UsoDemandado)
            {
                UsoDemandado = false;

                // Finalizaci�n de las funciones CCR
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
        /// Indica si se ha de finalizar la ejecuci�n del thread
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

        #region M�todo(s) privado(s)
        /// <summary>
        /// Ejecuta el callback en el mismo thread que la Applicaci�n principal
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

        #region Definici�n de delegado(s)
        /// <summary>
        /// Delegado de ejecuci�n del callback
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="argumentoEvento"></param>
        private delegate void DelegadoCallBack(CallBackResultadoParcial callBack, EventArgsResultadoParcial argumentoEvento);
        #endregion

        #region M�todo(s) heredado(s)
        /// <summary>
        /// M�todo a heredar para implementar la ejecuci�n del thread.
        /// Este m�todo se est� ejecutando en un bucle. Para salir del bucle hay que devolver finalize a true.
        /// </summary>
        protected override void Ejecucion(ref bool finalize)
        {
            finalize = this.Finalizar;

            try
            {
                if (!this.Finalizar)
                {
                    NLInfo element = MTInterface.GetFirstElement;

                    if (element != null)
                    {
                        // Guardamos la traza
                        OLogsVAFunciones.Vision.Debug(this.Codigo, "Ejecuci�n de la funci�n LPR " + this.Codigo);

                        CodeInfo info = element.GetFirstItem;
                        OInfoInspeccionCCR infoInspeccionCCR = (OInfoInspeccionCCR)element.ImageInformation.GetObject; // Obtengo la informaci�n de entrada de la inspecci�n
                        OResultadoCCR resultadoParcial = new OResultadoCCR(info, element.ImageInformation.GetTimestamp); // Obtengo el resultado parcial
                        infoInspeccionCCR.Resultados = resultadoParcial; // A�ado el resultado a la informaci�n de la inspecci�n

                        EventArgsResultadoParcial argumentoEvento = new EventArgsResultadoParcial(infoInspeccionCCR); // Creaci�n del argumento del evento
                        CallBackResultadoParcial callBack = infoInspeccionCCR.Info.CallBackResultadoParcial; // Obtenci�n del callback
                        this.CallBack(callBack, argumentoEvento); // Llamada al callback

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
                        element.ImageInformation.ClearImage();
                        element.ImageInformation.Dispose();
                        element.Dispose();
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
    /// Clase que realizara la funci�n de reconocimiento de CCR
    /// </summary>
    public class OFuncionVisionCCR : OFuncionVisionEncolada
    {
        #region Constante(s)
        /// <summary>
        /// N�mero m�ximo de inspecciones en la cola de ejecuci�n
        /// </summary>
        private const int MaxInspeccionesEnCola = 100;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Siguiente parametros de entrada a procesar en el CCR
        /// </summary>
        private OParametrosCCR ParametrosCCR;
        /// <summary>
        /// Lista de imagenes pendientes de ejecutar
        /// </summary>
        private List<Bitmap> ListaImagenesPendientes;
        /// <summary>
        /// Siguiente im�gen a procesar en el CCR
        /// </summary>
        private OImagenBitmap Imagen;
        /// <summary>
        /// Siguiente ruta de im�gen a procesar en el CCR
        /// </summary>
        private string RutaImagen;
        /// <summary>
        /// Lista de informaci�n adicional incorporada por el controlador externo
        /// </summary>
        private Dictionary<string, object> InformacionAdicional;
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
                    // Columnas a�adidas posteriormente
                    try
                    {
                        this.ParametrosCCR.Escala = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_Escala"], 0, +100000, 0);
                        this.ParametrosCCR.Param1 = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Param1"], 0, 10000, 1);
                        this.ParametrosCCR.Param2 = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Param2"], 0, 10000, 1);
                    }
                    catch (Exception ex)
                    {
                        OLogsVAFunciones.CCR.Error("FuncionCCR", ex);
                    }
                }
                this.ListaImagenesPendientes = new List<Bitmap>();
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "FuncionCCR");
            }
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Cargamos la configuracion de los parametros pasados por par�metro en caso de necesidad
        /// </summary>
        private void EstablecerConfiguracion(OParametrosCCR parametros)
        {
            // Ejecutamos la configuraci�n
            MTInterface.SetConfiguration(parametros.TimeOut, parametros.ActivadaAjusteCorreccion,
                    parametros.Distancia, parametros.CoeficienteVertical, parametros.CoeficienteHorizontal, parametros.CoeficienteRadial,
                    parametros.AnguloRotacion, parametros.InclinacionVertical, parametros.InclinacionHorizontal, parametros.CoordIzq, parametros.CoordArriba,
                    parametros.AnchuraVentanaBusqueda, parametros.AlturaVentanaBusqueda, parametros.ActivadoRangoAlturas,
                    parametros.VectorAlturas, parametros.ActivadaMasInformacion,parametros.Escala,parametros.Param1,parametros.Param2);
        }
        /// <summary>
        /// Comprueba que el archivo no este en uso
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private  bool IsFileLocked(FileInfo file)
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

        #region M�todo publicos
        /// <summary>
        /// Realiza un reset de la funci�n de visi�n de CCR que esta en ejecuci�n
        /// </summary>
        public void Reset()
        {
            // Guardamos la traza
            OLogsVAFunciones.CCR.Debug(this.Codigo, "Se procede a resetear la funci�n de visi�n " + this.Codigo);

            OCCRManager.Reset();

            // Ya no existen inspecciones pendientes
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;

            // Se finaliza la ejecuci�n de la funci�n de visi�n
            this.FuncionEjecutada();

            // Guardamos la traza
            OLogsVAFunciones.CCR.Debug(this.Codigo, "Reset de la funci�n de visi�n " + this.Codigo + " realizado con �xito");
        }
        #endregion

        #region M�todo(s) heredado(s)
        /// <summary>
        /// Ejecuci�n de la funci�n de CCR de forma encolada
        /// </summary>
        /// <returns></returns>
        protected override bool EjecucionEncolada()
        {
            bool resultado = false;
            resultado = base.EjecucionEncolada();

            // Se a�ade una nueva inspecci�n a la cola
            try
            {
                // A�adimos inspecciones de forma bloqueante
                if (MTInterface.IsRunning())
                {
                    if (MTInterface.GetQueueSize < MaxInspeccionesEnCola)
                    {
                        // Se aumenta el n�mero de inspecciones en cola
                        this.ContInspeccionesEnCola++;
                        this.IndiceFotografia++;

                        // Creamos el objeto con la informaci�n que nos interesa, no le pasamos la imagen para que no crezca la memoria
                        OInfoInspeccionCCR infoInspeccionCCR = new OInfoInspeccionCCR(
                                null,
                                new OInfoImagenCCR(this.IdEjecucionActual, this.Codigo, this.IndiceFotografia, DateTime.Now, A�adirResultadoParcial),
                                this.ParametrosCCR,
                                new OResultadoCCR(),
                                this.InformacionAdicional);

                        // Se carga la configuraci�n
                        this.EstablecerConfiguracion((OParametrosCCR)this.ParametrosCCR);

                        // Se carga la imagen
                        object info = infoInspeccionCCR;

                        //  Si tenemos ruta y imagenes es null, pasamos la ruta y sino viceversa
                        if (this.Imagen == null)
                        {
                            if (File.Exists(this.RutaImagen))
                            {
                                FileInfo fileInfo = new FileInfo(this.RutaImagen);
                                while (this.IsFileLocked(fileInfo))
                                {
                                    // Esperamos a poder utilizar el archivo
                                    Application.DoEvents();
                                    Thread.Sleep(1);
                                }
                                MTInterface.Add(this.RutaImagen, info);
                            }
                        }
                        else
                        {
                            MTInterface.Add(this.Imagen.Image, info);
                        }
                    }
                    else
                    {
                        // Temporal hasta que lo soluccionen
                        //this.ListaImagenesPendientes.Add(this.Imagen.Image);
                        OLogsVAFunciones.CCR.Info("FuncionCCR: Sobrepasado el limite de imagenes en cola", "");
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, "FuncionCCR");
            }

            return resultado;
        }

        /// <summary>
        /// Indica que hay inspecciones pendientes de ejecuci�n
        /// </summary>
        /// <returns></returns>
        public override bool HayInspeccionesPendientes()
        {
            bool resultado = base.HayInspeccionesPendientes();

            resultado |= (MTInterface.GetNumberOfElements > 0);
            resultado |= this.ContInspeccionesEnCola > 0;

            return resultado;
        }

        /// <summary>
        /// Funci�n para la actualizaci�n de par�metros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            bool resultado = false;

            try
            {
                if (tipoVariable == OEnumTipoDato.Imagen)
                {
                    this.Imagen = (OImagenBitmap)valor;
                }
                else if (codigo == "Parametros")
                {
                    this.ParametrosCCR = (OParametrosCCR)valor;
                }
                else if (codigo == "RutaImagen")
                {
                    this.RutaImagen = (string)valor;
                }
                else
                {
                    this.InformacionAdicional[codigo] = valor;
                    //throw new Exception("Error en la asignaci�n del par�metro '" + entrada.Nombre + "' a la funci�n '" + this.Codigo + "'. No se admite este tipo de par�metros.");
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
        /// Funci�n para la actualizaci�n de par�metros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool SetEntrada(EnumEntradaFuncionVision entrada, object valor, OEnumTipoDato tipoVariable)
        {
            bool resultado = false;

            try
            {
                if (entrada == EntradasFuncionesVisionCCR.Imagen)
                {
                    this.Imagen = (OImagenBitmap)valor;
                }
                else if (entrada == EntradasFuncionesVisionCCR.ParametrosCCR)
                {
                    this.ParametrosCCR = (OParametrosCCR)valor;
                }
                else if (entrada == EntradasFuncionesVisionCCR.RutaImagen)
                {
                    this.RutaImagen = (string)valor;
                }
                else
                {
                    this.InformacionAdicional[entrada.Nombre] = valor;
                    //throw new Exception("Error en la asignaci�n del par�metro '" + entrada.Nombre + "' a la funci�n '" + this.Codigo + "'. No se admite este tipo de par�metros.");
                }
                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.CCR.Error(exception, this.Codigo);
            }
            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene la informaci�n referente a la inspecci�n
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TParametros"></typeparam>
    /// <typeparam name="TResultados"></typeparam>
    public class OInfoInspeccionCCR : OInfoInspeccion<OImagenBitmap, OInfoImagenCCR, OParametrosCCR, OResultadoCCR>
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
        public OInfoInspeccionCCR(OImagenBitmap imagen, OInfoImagenCCR info, OParametrosCCR parametros, OResultadoCCR resultados, Dictionary<string, object> informacionAdicional)
            : base(imagen, info, parametros, resultados, informacionAdicional)
        {
        }
        #endregion
    }

    /// <summary>
    /// Esta clase contendra la informaci�n que queremos pasar con la imagen al CCR para recogerla cuando tengamos el resultado
    /// </summary>
    public class OInfoImagenCCR
    {
        #region Atributo(s)
        /// <summary>
        /// Contiene la informaci�n de la identificacion a la que pertenece
        /// </summary>
        public long IdEjecucionActual;
        /// <summary>
        /// Contiene la informaci�n de la c�mara que se le pasa en la imagen
        /// </summary>
        public string CodigoCamara;
        /// <summary>
        /// Contiene el indice de la imagen a�adida
        /// </summary>
        public int IndiceImagen;
        /// <summary>
        /// Contiene la fecha exacta en la que se adquirio la imagen
        /// </summary>
        public DateTime MomentoImagen;
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
            this.CodigoCamara = "";
            this.IndiceImagen = 0;
            this.MomentoImagen = DateTime.Now;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="camara">camara que adquiere la imagen</param>
        public OInfoImagenCCR(long idEjecucionActual,string codCamara, int indice, DateTime momentoImagen, CallBackResultadoParcial callBackResultadoParcial)
        {
            this.IdEjecucionActual = idEjecucionActual;
            this.CodigoCamara = codCamara;
            this.IndiceImagen = indice;
            this.MomentoImagen = momentoImagen;
            this.CallBackResultadoParcial = callBackResultadoParcial;
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
        /// Altura M�xima
        /// </summary>
        public int AlturaMax;
        /// <summary>
        /// Vector que contendra las alturas
        /// </summary>
        public Int32[] VectorAlturas;
        /// <summary>
        /// timeout de ejecuci�n
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
        /// Coeficiente de la correcci�n del �ngulo de rotaci�n
        /// </summary>
        public float AnguloRotacion;
        /// <summary>
        /// Inclinaci�n vertical
        /// </summary>
        public float InclinacionVertical;
        /// <summary>
        /// Inclinaci�n vertical
        /// </summary>
        public float InclinacionHorizontal;
        /// <summary>
        /// Distancia al c�digo desde la camara en metros
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
        /// Altura de la ventana de b�squeda
        /// </summary>
        public int AlturaVentanaBusqueda;
        /// <summary>
        /// Anchura de la ventana de b�squeda
        /// </summary>
        public int AnchuraVentanaBusqueda;
        /// <summary>
        /// Se le indica si se desea buscar m�s informaci�n extra en la imag�n
        /// </summary>
        public int ActivadaMasInformacion;
        /// <summary>
        /// Escala 
        /// </summary>
        public float Escala;
        /// <summary>
        /// Par�metro1
        /// </summary>
        public int Param1;
        /// <summary>
        /// Par�metro2
        /// </summary>
        public int Param2;
        #endregion Campos

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase sin par�metros
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
        }
        #endregion Constructores
    }

    /// <summary>
    /// Clase que contiene los resultados que se reciben del CCR para una imagen pasada anteriormente
    /// </summary>
    public class OResultadoCCR
    {
        #region Atributo(s)
        /// <summary>
        /// Contiene la cadena del codigo del contenedor
        /// </summary>
        public string CodigoContenedor;
        /// <summary>
        /// Contiene la informaci�n extra del c�digo del contenedor
        /// </summary>
        public string ExtaInfoCodigo;
        /// <summary>
        /// Si esta verificado el digito de control
        /// </summary>
        public bool CodigoVerificado;
        /// <summary>
        /// Fiabilidad C�digo
        /// </summary>
        public int FiabilidadCodigo;
        /// <summary>
        /// Fiabilidad ExtraInfo
        /// </summary>
        public int FiabilidadExtraInfo;
        /// <summary>
        /// Altura letras
        /// </summary>
        public int AlturaLetrasCodigo;       
        /// <summary>
        /// Fecha en la que se encolo a la cola de CCR (dada por �l)
        /// </summary>
        public DateTime FechaEncolamiento;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        public int TiempoDeProceso;
        /// <summary>
        /// Contiene las fiabilidades de cada letra individual
        /// </summary>
        public int[] FiabilidadesLetras;
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
            this.FiabilidadesLetras = new int[11];
            for (int i = 0; i < this.FiabilidadesLetras.Length; i++)
            {
                this.FiabilidadesLetras[i] = 0;
            }
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        public OResultadoCCR(CIDARMTWrapper.CodeInfo resultadoImagen, DateTime fechaEncola)
        {
            try
            {
                // Inicializamos el vector de fiabilidades de las letras
                this.FiabilidadesLetras = new int[11];
                for (int i = 0; i < this.FiabilidadesLetras.Length; i++)
                {
                    this.FiabilidadesLetras[i] = 0;
                }
                this.CodigoContenedor = (string)resultadoImagen.GetCodeNumber.ToString().Clone();
                // Si tenemos c�digo identificado , obtenemos las fiabilidades de cada una de las letras
                if (this.CodigoContenedor != "")
                {
                    float[] fiabilidades = resultadoImagen.GetCharConfidence;
                    for (int i = 0; i < fiabilidades.Length; i++)
                    {
                        this.FiabilidadesLetras[i] = Convert.ToInt32(fiabilidades[i]);
                    }
                }
                // Si tenemos informaci�n extra la obtenemos
                if (resultadoImagen.GetExtraInfoCodeNumber != null)
                {
                    this.ExtaInfoCodigo = (string)resultadoImagen.GetExtraInfoCodeNumber.ToString().Clone();
                    this.FiabilidadExtraInfo = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetExtraInfoConfidence)).ToString().Clone());
                }
                else
                {
                    this.ExtaInfoCodigo = "";
                }
                // Obtenemos el resto de resultados independientes
                this.CodigoVerificado = Convert.ToBoolean((Convert.ToBoolean(resultadoImagen.IsCodeVerified)).ToString().Clone());
                this.FiabilidadCodigo = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetGlobalConfidence)).ToString().Clone());
                this.AlturaLetrasCodigo = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetAverageCharacterHeigth)).ToString().Clone());
                this.TiempoDeProceso = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetProcessingTime)).ToString().Clone());
                this.FechaEncolamiento = fechaEncola;
            }
            catch (Exception exception)
            {
                // En caso de que se produzca cualquier error no contemplado, descartaremos el resultado recibido permitiendo continuar la ejecuci�n
                this.CodigoContenedor = "";
                this.ExtaInfoCodigo = "";
                this.CodigoVerificado = false;
                this.FiabilidadCodigo = 0;
                this.FiabilidadExtraInfo = 0;
                this.AlturaLetrasCodigo = 0;
                this.TiempoDeProceso = 0;
                this.FechaEncolamiento = new DateTime();
                this.FechaEncolamiento = DateTime.Now;
                for (int i = 0; i < this.FiabilidadesLetras.Length; i++)
                {
                    this.FiabilidadesLetras[i] = 0;
                }
                OLogsVAFunciones.CCR.Info("FuncionCCR:" + resultadoImagen.GetAverageCharacterHeigth.ToString()
                     + " " + resultadoImagen.GetGlobalConfidence.ToString()
                        + " " + resultadoImagen.GetExtraInfoConfidence.ToString(), exception);
            }
        }
        #endregion
    }

    /// <summary>
    /// Par�metros de la aplicaci�n
    /// </summary>
    [Serializable]
    public class ConfiguracionCCR : OAlmacenXML
    {
        #region Atributo(s) est�ticos
        /// <summary>
        /// Ruta por defecto del fichero xml de configuraci�n
        /// </summary>
        public static string ConfFile = Path.Combine(ORutaParametrizable.AppFolder, "ConfiguracionCCR.xml");
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Constante que indica si se ha de realizar una traza del CCR
        /// </summary>
        public bool TraceWrapper = true;
        /// <summary>
        /// Constante que indica si se limitan los n�cleos a utilizar
        /// </summary>
        public bool LimitCores = false;
        /// <summary>
        /// Constante que indica el n�mero m�ximo de n�cleos a utilizar
        /// </summary>
        public int Cores = 12;
        /// <summary>
        /// Constante de altura del caracter
        /// </summary>
        public int AvCharHeight = -1;
        /// <summary>
        /// Par�metro de cidar
        /// </summary>
        public int DuplicateLines = 0;
        /// <summary>
        /// Trazabilidad
        /// </summary>
        public int Trace = 1;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ConfiguracionCCR()
            : base(ConfFile)
        {
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ConfiguracionCCR(string rutaFichero)
            : base(rutaFichero)
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Define el conjunto de tipos de entradas de las funciones de visi�n CCR
    /// </summary>
    public class EntradasFuncionesVisionCCR : EntradasFuncionesVision
    {
        #region Atributo(s)
        /// <summary>
        /// Parametros de configuraci�n del CCR
        /// </summary>
        public static EnumEntradaFuncionVision ParametrosCCR = new EnumEntradaFuncionVision("ParametrosLPR", "Parametros de configuraci�n del CCR", 201);
        /// <summary>
        /// Ruta en disco de la imagen de entrada
        /// </summary>
        public static EnumEntradaFuncionVision RutaImagen = new EnumEntradaFuncionVision("RutaImagen", "Ruta en disco de la imagen de entrada", 202);
        #endregion
    }
}