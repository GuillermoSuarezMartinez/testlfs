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
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
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
                    OVALogsManager.Error(ModulosFunciones.LPR, "LPR", exception);
                    OLPRManager.Configuracion = new ConfiguracionLPR();
                    OLPRManager.Configuracion.Guardar();
                }

                // Inicializamos el motor de b�squeda de LPR             
                int id = MTInterface.Init(OLPRManager.Configuracion.CountryCode, OLPRManager.Configuracion.AvCharHeight, OLPRManager.Configuracion.DuplicateLines, OLPRManager.Configuracion.Reordenar, OLPRManager.Configuracion.filterColor, OLPRManager.Configuracion.TraceVpar, OLPRManager.Configuracion.TraceWrapper);
                // Almacenamos el valor de incio
                if (id == 1)
                {
                    OVALogsManager.Debug(ModulosFunciones.LPR, "LPR", "Iniciado correctamente");
                }
                else
                {
                    OVALogsManager.Error(ModulosFunciones.LPR, "LPR", "Error de inicializaci�n");
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.LPR, "LPR", exception);
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
        private void CallBack(NLInfo element, PlateInfo plateInfo)
        {
            try
            {
                if ((element != null))
                {
                    OInfoInspeccionLPR infoInspeccionLPR = (OInfoInspeccionLPR)element.ImageInformation.GetObject; // Obtengo la informaci�n de entrada de la inspecci�n
                    OResultadoLPR resultadoParcial = new OResultadoLPR(plateInfo, element.ImageInformation.GetTimestamp); // Obtengo el resultado parcial
                    infoInspeccionLPR.Resultados = resultadoParcial; // A�ado el resultado a la informaci�n de la inspecci�n

                    EventArgsResultadoParcial argumentoEvento = new EventArgsResultadoParcial(infoInspeccionLPR); // Creaci�n del argumento del evento
                    CallBackResultadoParcial callBack = infoInspeccionLPR.Info.CallBackResultadoParcial; // Obtenci�n del callback

                    // Llamada al callback
                    if (callBack != null)
                    {
                        // Llamada desde el thread principal
                        OThreadManager.SincronizarConThreadPrincipal(new CallBackResultadoParcial(callBack), new object[] { this, argumentoEvento });
                    }
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.LPR, this.Codigo, exception);
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
                    OVALogsManager.Info(ModulosFunciones.LPR, this.Codigo, "Eliminada imagen de la cola VPAR. Total im�genes: " + MTInterface.GetQueueSize.ToString());
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
                        PlateInfo info = element.GetFirstPlate;

                        this.CallBack(element, info); // Llamada al callback
                        if (info != null)
                        {
                            info.Dispose();
                        }
                        element.Dispose();

                        // Guardamos la traza
                        OVALogsManager.Debug(ModulosFunciones.LPR, this.Codigo, "Fin de ejecuci�n de la funci�n " + this.Codigo);
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
        /// Para ir alternando la configuraci�n, si tiene distorisi�n tambien es �til combinarla con la configuraci�n estandar
        /// </summary>
        private bool AlternarConfiguracion;

        /// <summary>
        /// Siguiente ruta de im�gen a procesar en el LPR
        /// </summary>
        private string RutaImagen;
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
                this.AlternarConfiguracion = false;

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
                OVALogsManager.Error(ModulosFunciones.LPR, "FuncionLPR", exception);
            }
        }
        #endregion

        #region M�todo(s) privado(s)
        /// <summary>
        /// Cargamos la configuracion de los parametros definidos como entrada, es m�s eficiente alternar con los de por defecto, para tener mejor tasa de acierto
        /// </summary>
        private void EstablecerConfiguracion(OParametrosLPR parametros,bool usarPorDefecto)
        {
            bool resultCode;
            if (usarPorDefecto)
            {
                // Ejecutamos la configuraci�n por defecto
                resultCode = MTInterface.SetConfiguration(0,0,10,0,0,0,0,0,0,0,0,new int[3]);
            }
            else
            {
                // Ejecutamos la configuraci�n
                resultCode = MTInterface.SetConfiguration(parametros.TimeOut, parametros.ActivadaAjusteCorreccion,
                    parametros.Distancia, parametros.CoeficienteVertical, parametros.CoeficienteHorizontal,
                    parametros.AnguloRotacion, parametros.CoordIzq, parametros.CoordArriba,
                    parametros.AnchuraVentanaBusqueda, parametros.AlturaVentanaBusqueda, parametros.ActivadoRangoAlturas,
                    parametros.VectorAlturas);
            }
            if (!resultCode)
            {
                OVALogsManager.Error(ModulosFunciones.LPR, "FuncionLPR", "Error al establecer la configuraci�n del VPAR");
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
            OVALogsManager.Debug(ModulosFunciones.LPR, this.Codigo, "Se procede a resetear la funci�n de visi�n " + this.Codigo);

            OLPRManager.Reset();

            // Ya no existen inspecciones pendientes
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;

            // Se finaliza la ejecuci�n de la funci�n de visi�n
            this.FuncionEjecutada();

            // Guardamos la traza
            OVALogsManager.Debug(ModulosFunciones.LPR, this.Codigo, "Reset de la funci�n de visi�n " + this.Codigo + " realizado con �xito");
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
                                new OResultadoLPR());

                        // Se carga la configuraci�n
                        this.EstablecerConfiguracion((OParametrosLPR)this.ParametrosLPR, this.AlternarConfiguracion);
                        // Variamos la configuraci�n para la siguiente 
                        this.AlternarConfiguracion = !this.AlternarConfiguracion;
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
                            OVALogsManager.Error(ModulosFunciones.LPR, "FuncionLPR", "Error al a�adir imagen a la cola VPAR. Total im�genes: " + MTInterface.GetQueueSize.ToString());
                        }

                        OVALogsManager.Info(ModulosFunciones.LPR, "FuncionLPR", "A�adida imagen a la cola VPAR. Total im�genes: " + MTInterface.GetQueueSize.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.LPR, "FuncionLPR", exception);
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
                    throw new Exception("Error en la asignaci�n del par�metro '" + codigo + "' a la funci�n '" + this.Codigo + "'. No se admite este tipo de par�metros.");
                }
                resultado = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.LPR, this.Codigo, exception);
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
        public OInfoInspeccionLPR(OImagenBitmap imagen, OInfoImagenLPR info, OParametrosLPR parametros, OResultadoLPR resultados)
            : base(imagen, info, parametros, resultados)
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
    /// Clase que contiene los resultados que se reciben de la funcion LPR para una imagen pasada 
    /// </summary>
    public class OResultadoLPR
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
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OResultadoLPR()
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
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        public OResultadoLPR(PlateInfo resultadoImagen, DateTime fechaEncola)
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
                OVALogsManager.Info(ModulosFunciones.LPR, "FuncionLPR", exception);
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
}
