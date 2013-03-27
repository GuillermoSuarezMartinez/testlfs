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
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.Xml;
using VPARMTWrapper;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase que ejecuta continuamente el
    /// </summary>
    internal static class OLPRManager
    {
        #region Atributo(s)
        /// <summary>
        /// Thread de ejecuci�n continua del m�dulo LPR
        /// </summary>
        public static ThreadEjecucionLPR ThreadEjecucionLPR;

        /// <summary>
        /// Indica si alguna funci�n de visi�n ha demandado el uso del LPR
        /// </summary>
        private static bool UsoDemandado = false;

        /// <summary>
        /// Par�metros de configuraci�n del LPR
        /// </summary>
        private static ConfiguracionLPR Configuracion;

        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        private static void Constructor()
        {
            ThreadEjecucionLPR = new ThreadEjecucionLPR("LPR", ThreadPriority.Normal);
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        private static void Destructor()
        {
            ThreadEjecucionLPR.Stop(1000);
            ThreadEjecucionLPR = null;
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
                    OLPRManager.Configuracion = (ConfiguracionLPR)(new ConfiguracionLPR().CargarDatos());
                }
                catch (FileNotFoundException exception)
                {
                    OLogsVAFunciones.LPR.Error(exception, "LPR");
                    OLPRManager.Configuracion = new ConfiguracionLPR();
                    OLPRManager.Configuracion.Guardar();
                }

                // Inicializamos el motor de b�squeda de LPR             
                int id = MTInterface.Init(OLPRManager.Configuracion.CountryCode, OLPRManager.Configuracion.AvCharHeight, OLPRManager.Configuracion.DuplicateLines, OLPRManager.Configuracion.Reordenar, OLPRManager.Configuracion.filterColor, OLPRManager.Configuracion.TraceVpar, OLPRManager.Configuracion.TraceWrapper);
                // Almacenamos el valor de incio
                if (id == 1)
                {
                    OLogsVAFunciones.LPR.Debug("LPR", "Iniciado correctamente");
                }
                else
                {
                    OLogsVAFunciones.LPR.Error("LPR", "Error de inicializaci�n");
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "LPR");
            }

            ThreadEjecucionLPR.Start();
        }

        /// <summary>
        /// Finaliza la ejecuci�n
        /// </summary>
        private static void Finalizar()
        {
            ThreadEjecucionLPR.Dispose(1000);

            // Liberamos memoria reservada para la libreria de LPR, cuando termina de procesar las imagenes
            MTInterface.QueryEnd();
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Resetea la funci�n de visi�n LPR
        /// </summary>
        public static void Reset()
        {
            // Detenemos el hilo 
            ThreadEjecucionLPR.Pause();
            // Liberamos memoria reservada para la libreria de LPR, cuando termina de procesar las imagenes
            MTInterface.QueryEnd();
            // Inicializamos el motor de b�squeda de LPR
            MTInterface.Init(OLPRManager.Configuracion.CountryCode, OLPRManager.Configuracion.AvCharHeight, OLPRManager.Configuracion.DuplicateLines, OLPRManager.Configuracion.Reordenar, OLPRManager.Configuracion.filterColor, OLPRManager.Configuracion.TraceVpar, OLPRManager.Configuracion.TraceWrapper);
            // Reiniciamos el hilo
            ThreadEjecucionLPR.Resume();
        }

        /// <summary>
        /// Se demanda el uso del LPR, por lo que se necesita iniciar las librer�as correspondientes
        /// </summary>
        public static void DemandaUso()
        {
            if (!UsoDemandado)
            {
                UsoDemandado = true;

                // Constructor de las funciones LPR
                OLPRManager.Constructor();

                // Inicializaci�n de las funciones LPR
                OLPRManager.Inicializar();
            }
        }

        /// <summary>
        /// Se elimina la demanda el uso del LPR, por lo que se necesita finalizar las librer�as correspondientes
        /// </summary>
        public static void FinDemandaUso()
        {
            if (UsoDemandado)
            {
                UsoDemandado = false;

                // Finalizaci�n de las funciones LPR
                OLPRManager.Finalizar();

                // Destructor de las funciones LPR
                OLPRManager.Destructor();
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que ejecuta el reconocimiento de las matr�culas en un thread
    /// </summary>
    internal class ThreadEjecucionLPR : OThreadLoop
    {
        #region Atributo(s)
        /// <summary>
        /// Indica si se ha de finalizar la ejecuci�n del thread
        /// </summary>
        public bool Finalizar;

        /// <summary>
        /// Cola de elementos a procesar en MTInterface
        /// </summary>
        private int QueueSize = -1;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionLPR(string codigo)
            : base(codigo)
        {
            this.Finalizar = false;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionLPR(string codigo, ThreadPriority threadPriority)
            : base(codigo, 1, threadPriority)
        {
            this.Finalizar = false;
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Ejecuta el callback en el mismo thread que la Applicaci�n principal
        /// </summary>
        private void CallBack(OInfoInspeccionLPR infoInspeccionLPR)
        {
            try
            {
                EventArgsResultadoParcial argumentoEvento = new EventArgsResultadoParcial(infoInspeccionLPR); // Creaci�n del argumento del evento
                CallBackResultadoParcial callBack = infoInspeccionLPR.Info.CallBackResultadoParcial; // Obtenci�n del callback

                // Llamada al callback
                if (callBack != null)
                {
                    // Llamada desde el thread principal
                    OThreadManager.SincronizarConThreadPrincipal(new CallBackResultadoParcial(callBack), new object[] { this, argumentoEvento });
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, this.Codigo);
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
        protected override void Ejecucion(ref bool finalize)
        {
            finalize = this.Finalizar;

            if (!this.Finalizar)
            {
                // Guardamos la traza �nicamente cuando hay un cambio en el tama�o de la cola de elementos a procesar en MTInterface
                if (this.QueueSize != MTInterface.GetQueueSize)
                {
                    OLogsVAFunciones.LPR.Info(this.Codigo, "Eliminada imagen de la cola VPAR. Total im�genes: " + MTInterface.GetQueueSize.ToString());
                    this.QueueSize = MTInterface.GetQueueSize;
                }

                // Consulta de resultados
                NLInfo element = null;
                do
                {
                    //Get firs element where all results are ready
                    element = MTInterface.GetFirstElement();
                    if (element != null)
                    {
                        // Obtengo la informaci�n de entrada de la inspecci�n
                        OInfoInspeccionLPR infoInspeccionLPR = (OInfoInspeccionLPR)element.ImageInformation.GetObject; 
                        infoInspeccionLPR.Resultados = new OResultadoLPR(); // Inicializo los resultados

                        PlateInfo plateInfo = null;
                        do
                        {
                            plateInfo = element.GetFirstPlate;
                            if (plateInfo != null)
                            {
                                // Obtengo el resultado de una matricula
                                OResultadoSimpleLPR resultadoParcial = new OResultadoSimpleLPR(plateInfo, element.ImageInformation.GetTimestamp);
                                // A�ado el resultado de la matricula a la lista de matriculas reconocidas de la imagen
                                infoInspeccionLPR.Resultados.Add(resultadoParcial); 

                                plateInfo.Dispose();
                            }
                        }
                        while (plateInfo != null);

                        this.CallBack(infoInspeccionLPR); // Llamada al callback

                        // Guardamos la traza
                        OLogsVAFunciones.LPR.Debug(this.Codigo, "Fin de ejecuci�n de la funci�n " + this.Codigo);

                        element.Dispose();
                    }
                }
                while (element != null);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que realizara la funci�n de reconocimiento de LPR
    /// </summary>
    public class OFuncionVisionLPR : OFuncionVisionEncolada
    {
        #region Constante(s)
        /// <summary>
        /// N�mero m�ximo de inspecciones en la cola de ejecuci�n
        /// </summary>
        private const int MaxInspeccionesEnCola = 8;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Siguiente parametros de entrada a procesar en el LPR
        /// </summary>
        private OParametrosLPR ParametrosLPR;

        /// <summary>
        /// Siguiente im�gen a procesar en el LPR
        /// </summary>
        private OImagenBitmap Imagen;

        /// <summary>
        /// Siguiente ruta de im�gen a procesar en el LPR
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
        public OFuncionVisionLPR(string codFuncionVision)
            : base(codFuncionVision)
        {
            try
            {
                // Demanda del uso de LPR
                OLPRManager.DemandaUso();

                this.Valido = true;
                this.ParametrosLPR = new OParametrosLPR();
                this.InformacionAdicional = new Dictionary<string, object>();

                // Cargamos valores de la base de datos
                DataTable dtFuncionVision = AppBD.GetFuncionVision(this.Codigo);
                if (dtFuncionVision.Rows.Count == 1)
                {
                    this.ParametrosLPR.Altura = OEntero.Validar(dtFuncionVision.Rows[0]["NL_Altura"], -1, 10000, -1);
                    this.ParametrosLPR.ActivadoRangoAlturas = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadoRangoAlturas"], 0, 1, 0);
                    this.ParametrosLPR.AlturaMin = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaMin"], 1, 10000, 30);
                    this.ParametrosLPR.AlturaMax = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaMax"], 1, 10000, 60);
                    this.ParametrosLPR.VectorAlturas = new int[2] { this.ParametrosLPR.AlturaMin, this.ParametrosLPR.AlturaMax };
                    this.ParametrosLPR.TimeOut = OEntero.Validar(dtFuncionVision.Rows[0]["NL_TimeOut"], 0, 1000000, 0);
                    this.ParametrosLPR.ActivadaAjusteCorreccion = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadaAjusteCorrecion"], 0, 1, 0);
                    this.ParametrosLPR.CoeficienteHorizontal = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteHorizontal"], -100000, +100000, 0);
                    this.ParametrosLPR.CoeficienteVertical = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteVertical"], -100000, +100000, 0);
                    this.ParametrosLPR.CoeficienteRadial = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_CoeficienteRadial"], -100000, +100000, 0);
                    this.ParametrosLPR.AnguloRotacion = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_AnguloRotacion"], -100000, +100000, 0);
                    this.ParametrosLPR.Distancia = (float)ODecimal.Validar(dtFuncionVision.Rows[0]["NL_Distancia"], 0, +100000, 0);
                    this.ParametrosLPR.CoordIzq = OEntero.Validar(dtFuncionVision.Rows[0]["NL_CoordIzq"], 0, 10000, 0);
                    this.ParametrosLPR.CoordArriba = OEntero.Validar(dtFuncionVision.Rows[0]["NL_CoordArriba"], 0, 10000, 0);
                    this.ParametrosLPR.AlturaVentanaBusqueda = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AlturaVentanaBusqueda"], 0, 10000, 0);
                    this.ParametrosLPR.AnchuraVentanaBusqueda = OEntero.Validar(dtFuncionVision.Rows[0]["NL_AnchuraVentanaBusqueda"], 0, 10000, 0);
                    this.ParametrosLPR.ActivadaMasInformacion = OEntero.Validar(dtFuncionVision.Rows[0]["NL_ActivadaMasInformacion"], 0, 10000, 1);
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "FuncionLPR");
            }
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Cargamos la configuracion de los parametros definidos como entrada, es m�s eficiente alternar con los de por defecto, para tener mejor tasa de acierto
        /// </summary>
        private void EstablecerConfiguracion(OParametrosLPR parametros)
        {
            // Ejecutamos la configuraci�n
            bool resultCode = MTInterface.SetConfiguration(parametros.TimeOut, parametros.ActivadaAjusteCorreccion,
                parametros.Distancia, parametros.CoeficienteVertical, parametros.CoeficienteHorizontal,
                parametros.AnguloRotacion, parametros.CoordIzq, parametros.CoordArriba,
                parametros.AnchuraVentanaBusqueda, parametros.AlturaVentanaBusqueda, parametros.ActivadoRangoAlturas,
                parametros.VectorAlturas);
            if (!resultCode)
            {
                OLogsVAFunciones.LPR.Error("FuncionLPR", "Error al establecer la configuraci�n del VPAR");
            }
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

        #region M�todo publicos
        /// <summary>
        /// Realiza un reset de la funci�n de visi�n de LPR que esta en ejecuci�n
        /// </summary>
        public void Reset()
        {
            // Guardamos la traza
            OLogsVAFunciones.LPR.Debug(this.Codigo, "Se procede a resetear la funci�n de visi�n " + this.Codigo);

            OLPRManager.Reset();

            // Ya no existen inspecciones pendientes
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;

            // Se finaliza la ejecuci�n de la funci�n de visi�n
            this.FuncionEjecutada();

            // Guardamos la traza
            OLogsVAFunciones.LPR.Debug(this.Codigo, "Reset de la funci�n de visi�n " + this.Codigo + " realizado con �xito");
        }
        #endregion

        #region M�todo(s) heredado(s)
        /// <summary>
        /// Ejecuci�n de la funci�n de Vision Pro de forma s�ncrona
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

                        OInfoInspeccionLPR infoInspeccionLPR = new OInfoInspeccionLPR(
                                this.Imagen,
                                new OInfoImagenLPR(this.IdEjecucionActual,this.Codigo, this.IndiceFotografia, DateTime.Now, A�adirResultadoParcial),
                                this.ParametrosLPR,
                                new OResultadoLPR(),
                                this.InformacionAdicional);

                        // Se carga la configuraci�n
                        this.EstablecerConfiguracion((OParametrosLPR)this.ParametrosLPR);
                        // Variamos la configuraci�n para la siguiente 
                        // Se carga la imagen
                        object info = infoInspeccionLPR;
                        int resultCode = 0;
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
                                resultCode = MTInterface.Add(this.RutaImagen,ref info);
                            }
                        }
                        else
                        {
                            resultCode = MTInterface.Add(this.Imagen.Image, ref info);
                        }
                        

                        if (resultCode == -1)
                        {
                            OLogsVAFunciones.LPR.Error("FuncionLPR", "Error al a�adir imagen a la cola VPAR. Total im�genes: " + MTInterface.GetQueueSize.ToString());
                        }

                        OLogsVAFunciones.LPR.Info("FuncionLPR", "A�adida imagen a la cola VPAR. Total im�genes: " + MTInterface.GetQueueSize.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.LPR.Error(exception, "FuncionLPR");
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

            resultado |= (MTInterface.GetNumberOfElements() > 0);
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
                    this.ParametrosLPR = (OParametrosLPR)valor;
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
                OLogsVAFunciones.LPR.Error(exception, this.Codigo);
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
                if (entrada == EntradasFuncionesVisionLPR.Imagen)
                {
                    this.Imagen = (OImagenBitmap)valor;
                }
                else if (entrada == EntradasFuncionesVisionLPR.ParametrosLPR)
                {
                    this.ParametrosLPR = (OParametrosLPR)valor;
                }
                else if (entrada == EntradasFuncionesVisionLPR.RutaImagen)
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
                OLogsVAFunciones.LPR.Error(exception, this.Codigo);
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
    public class OInfoInspeccionLPR : OInfoInspeccion<OImagenBitmap, OInfoImagenLPR, OParametrosLPR, OResultadoLPR>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OInfoInspeccionLPR()
            : base()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="info"></param>
        /// <param name="parametros"></param>
        /// <param name="resultados"></param>
        public OInfoInspeccionLPR(OImagenBitmap imagen, OInfoImagenLPR info, OParametrosLPR parametros, OResultadoLPR resultados, Dictionary<string,object> informacionAdicional)
            : base(imagen, info, parametros, resultados, informacionAdicional)
        {
        }
        #endregion
    }

    /// <summary>
    /// Esta clase contendra la informaci�n que queremos pasar con la imagen a la funci�n LPR para recogerla cuando tengamos el resultado
    /// </summary>
    public class OInfoImagenLPR
    {
        #region Atributo(s)
        /// <summary>
        /// Contiene la informaci�n de la identificacion a la que pertenece
        /// </summary>
        public long IdEjecucionActual;
        /// <summary>
        /// Contiene la informaci�n de la c�mara que se le pasa en la imagen
        /// </summary>
        public string Codigo;
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
        public OInfoImagenLPR()
        {
            this.IdEjecucionActual = 0;
            this.Codigo = "";
            this.IndiceImagen = 0;
            this.MomentoImagen = DateTime.Now;
            this.CallBackResultadoParcial = null;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="codigo">camara que adquiere la imagen</param>
        public OInfoImagenLPR(long idEjecucionActual,string codigo, int indice, DateTime momentoImagen, CallBackResultadoParcial callBackResultadoParcial)
        {
            this.IdEjecucionActual = idEjecucionActual;            
            this.Codigo = codigo;
            this.IndiceImagen = indice;
            this.MomentoImagen = momentoImagen;
            this.CallBackResultadoParcial = callBackResultadoParcial;
        }
        #endregion
    }

    /// <summary>
    /// Clase que contiene los parametros de configuracion del LPR
    /// </summary>
    public class OParametrosLPR
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
        /// Para saber si han habido modificaciones
        /// </summary>
        public bool Modificado;

        #endregion Campos

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase sin par�metros
        /// </summary>
        public OParametrosLPR()
        {
            this.Altura = -1;
            this.ActivadoRangoAlturas = 0;
            this.AlturaMin = 30;
            this.AlturaMax = 60;
            this.VectorAlturas = new Int32[2];
            this.VectorAlturas[0] = AlturaMin;
            this.VectorAlturas[1] = AlturaMax;
            this.TimeOut = 0;
            this.ActivadaAjusteCorreccion = 0;
            this.CoeficienteHorizontal = 0;
            this.CoeficienteVertical = 0;
            this.CoeficienteRadial = 0;
            this.AnguloRotacion = 0;
            this.Distancia = 0;
            this.CoordArriba = 0;
            this.CoordIzq = 0;
            this.AlturaVentanaBusqueda = 0;
            this.AnchuraVentanaBusqueda = 0;
            this.ActivadaMasInformacion = 1;
            this.Modificado = true;
        }
        #endregion Constructores
    }

    /// <summary>
    /// Lista de resultados de todas las matriculas de una imagen
    /// </summary>
    public class OResultadoLPR: List<OResultadoSimpleLPR>
    {
    }

    /// <summary>
    /// Clase que contiene los resultados que se reciben de la funcion LPR para una imagen pasada 
    /// </summary>
    public class OResultadoSimpleLPR
    {
        #region Atributo(s)
        /// <summary>
        /// Contiene la cadena la matr�cula del veh�culo
        /// </summary>
        public string Matricula;
        /// <summary>
        /// Fiabilidad de la matr�cula
        /// </summary>
        public int FiabilidadMatricula;
        /// <summary>
        /// Altura letras
        /// </summary>
        public int AlturaLetrasMatricula;
        /// <summary>
        /// Fecha en la que se encolo a la cola de LPR (dada por �l)
        /// </summary>
        public DateTime FechaEncolamiento;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        public int TiempoDeProceso;
        /// <summary>
        /// Posicion Top matricula
        /// </summary>
        public int TopPosicionMatricula;
        /// <summary>
        /// Posicion Bottom matricula
        /// </summary>
        public int BottomPosicionMatricula;
        /// <summary>
        /// Posicion Right matricula
        /// </summary>
        public int RightPosicionMatricula;
        /// <summary>
        /// Posicion Left matricula
        /// </summary>
        public int LeftPosicionMatricula;
        /// <summary>
        /// <summary>Codigo del pais de la matr�culaPosicion Left matricula
        /// </summary>
        public int CodigoPais;
        /// <summary>
        /// <summary>Devuelve el pais que cumple la sint�xis
        /// </summary>
        public int PaisSintaxis;
        /// <summary>
        /// N�mero de car�cters de la matr�cula
        /// </summary>
        public int NumCaracteres;
        /// <summary>
        /// Contiene las fiabilidades de cada letra individual
        /// </summary>
        public float[] FiabilidadesLetras;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OResultadoSimpleLPR()
        {
            this.Matricula = string.Empty;
            this.FiabilidadMatricula = 0;
            this.AlturaLetrasMatricula = 0;
            this.TiempoDeProceso = 0;
            this.TopPosicionMatricula = 0;
            this.BottomPosicionMatricula = 0;
            this.LeftPosicionMatricula = 0;
            this.RightPosicionMatricula = 0;
            this.CodigoPais = 0;
            this.FechaEncolamiento = DateTime.Now;
            this.PaisSintaxis = 0;
            this.NumCaracteres = 0;
            this.FiabilidadesLetras = new float[0];
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        public OResultadoSimpleLPR(PlateInfo resultadoImagen, DateTime fechaEncola)
        {
            try
            {
                this.Matricula = (string)resultadoImagen.GetPlateNumber.ToString().Clone();
                this.FiabilidadMatricula = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetGlobalConfidence)).ToString().Clone());
                this.AlturaLetrasMatricula = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetAverageCharacterHeigth)).ToString().Clone());
                this.TiempoDeProceso = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetProcessingTime)).ToString().Clone());
                this.TopPosicionMatricula = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetTopPlatePosition)).ToString().Clone());
                this.BottomPosicionMatricula = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetBottomPlatePosition)).ToString().Clone());
                this.LeftPosicionMatricula = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetLeftPlatePosition)).ToString().Clone());
                this.RightPosicionMatricula = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetRightPlatePosition)).ToString().Clone());
                this.CodigoPais = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetPlateFormat)).ToString().Clone());
                this.FechaEncolamiento = fechaEncola;
                this.PaisSintaxis = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetPlateFormat)).ToString().Clone());
                this.NumCaracteres = Convert.ToInt16((Convert.ToInt16(resultadoImagen.GetNumCharacters)).ToString().Clone());

                // Si tenemos c�digo identificado , obtenemos las fiabilidades de cada una de las letras
                if (this.NumCaracteres > 0)
                {
                    float[] fiabilidades = resultadoImagen.GetCharConfidence();
                    for (int i = 0; i < fiabilidades.Length; i++)
                    {
                        this.FiabilidadesLetras[i] = Convert.ToSingle(fiabilidades[i]);
                    }
                }
            }
            catch (Exception exception)
            {
                // En caso de que se produzca cualquier error no contemplado, descartaremos el resultado recibido permitiendo continuar la ejecuci�n
                this.Matricula = string.Empty;
                this.FiabilidadMatricula = 0;
                this.AlturaLetrasMatricula = 0;
                this.TiempoDeProceso = 0;
                this.TopPosicionMatricula = 0;
                this.BottomPosicionMatricula = 0;
                this.LeftPosicionMatricula = 0;
                this.RightPosicionMatricula = 0;
                this.CodigoPais = 0;
                this.FechaEncolamiento = DateTime.Now;
                OLogsVAFunciones.LPR.Info(exception, "FuncionLPR");
            }
        }
        #endregion
    }

    /// <summary>
    /// Par�metros de la aplicaci�n
    /// </summary>
    [Serializable]
    internal class ConfiguracionLPR : OAlmacenXML
    {
        #region Atributo(s) est�ticos
        /// <summary>
        /// Ruta por defecto del fichero xml de configuraci�n
        /// </summary>
        public static string ConfFile = Path.Combine(ORutaParametrizable.AppFolder, "ConfiguracionLPR.xml");
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Constante que indica el pais o paises a identificar la matricula
        /// </summary>
        public int CountryCode = 101;
        /// <summary>
        /// Constante de altura del caracter
        /// </summary>
        public int AvCharHeight = -1;
        /// <summary>
        /// Par�metro de Vpar
        /// </summary>
        public int DuplicateLines = 0;
        /// <summary>
        /// Parametro de Vpar
        /// </summary>
        public int Reordenar = 0;
        /// <summary>
        /// Parametro de Vpar
        /// </summary>
        public int filterColor = 0;
        /// <summary>
        /// Trazabilidad
        /// </summary>
        public int TraceVpar = 1;
        /// <summary>
        /// Indica si se ha de realizar una traza del LPR
        /// </summary>
        public bool TraceWrapper = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ConfiguracionLPR()
            : base(ConfFile)
        {
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ConfiguracionLPR(string rutaFichero)
            : base(rutaFichero)
        {
        }
        #endregion Constructor
    }

    /// <summary>
    /// Define el conjunto de tipos de entradas de las funciones de visi�n LPR
    /// </summary>
    public class EntradasFuncionesVisionLPR : EntradasFuncionesVision
    {
        #region Atributo(s)
        /// <summary>
        /// Parametros de configuraci�n del LPR
        /// </summary>
        public static EnumEntradaFuncionVision ParametrosLPR = new EnumEntradaFuncionVision("ParametrosLPR", "Parametros de configuraci�n del LPR", 101);
        /// <summary>
        /// Ruta en disco de la imagen de entrada
        /// </summary>
        public static EnumEntradaFuncionVision RutaImagen = new EnumEntradaFuncionVision("RutaImagen", "Ruta en disco de la imagen de entrada", 102);
        #endregion
    }
}