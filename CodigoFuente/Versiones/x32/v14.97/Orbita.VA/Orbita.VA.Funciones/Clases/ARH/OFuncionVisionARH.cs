//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : fhernandez
// Created          : 13-05-2013
//
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Orbita.VA.Comun;
using System.Data;
using System.Collections.Generic;
using Orbita.Utiles;
using System.IO;
using Orbita.Xml;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase que ejecuta continuamente el
    /// </summary>
    internal static class OARHManager
    {
        #region Constantes
        /// <summary>
        /// Constante que indica si se ha de realizar una traza del OCR
        /// </summary>
        private const bool TraceWrapper = true;
        /// <summary>
        /// Constante que indica el número máximo de núcleos a utilizar
        /// </summary>
        private const int Cores = 1;
        #endregion

        #region Campos
        /// <summary>
        /// Thread de ejecución continua del módulo OCR
        /// </summary>
        public static ThreadEjecucionARH ThreadARHEjecucionOCR;

        /// <summary>
        /// Indica si alguna función de visión ha demandado el uso del OCR
        /// </summary>
        private static bool UsoDemandado = false;
        #endregion

        #region Métodos privados
        /// <summary>
        /// Construye los objetos
        /// </summary>
        private static void Constructor()
        {
            ThreadARHEjecucionOCR = new ThreadEjecucionARH("OCR", ThreadPriority.Normal);
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        private static void Destructor()
        {
            ThreadARHEjecucionOCR = null;
        }

        /// <summary>
        /// Carga las propiedades de la base de datos
        /// </summary>
        private static void Inicializar()
        {
            try
            {
                // Inicializamos el manejador de threads
                OThreadManager.Constructor();
                OThreadManager.Inicializar();

                // Inicializamos el motor de búsqueda de OCR
                int id = OMTInterfaceARH.Init(TraceWrapper, Cores);

                // Almacenamos el valor de incio
                if (id == 1)
                {
                    OLogsVAFunciones.ARH.Debug("Iniciado correctamente");
                }
                else
                {
                    OLogsVAFunciones.ARH.Error("Error de inicialización");
                }                
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception,"Error de inicialización");
            }

            ThreadARHEjecucionOCR.Start();
        }

        /// <summary>
        /// Finaliza la ejecución
        /// </summary>
        private static void Finalizar()
        {
            // Inicializamos el manejador de threads
            OThreadManager.Finalizar();
            OThreadManager.Destructor();

            ThreadARHEjecucionOCR.Stop(1000);

            // Liberamos memoria reservada para la libreria de OCR, cuando termina de procesar las imagenes
            OMTInterfaceARH.QueryEnd();
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Resetea la función de visión OCR
        /// </summary>
        public static void Reset()
        {
            // Detenemos el Hilo
            ThreadARHEjecucionOCR.Pause();

            int id = OMTInterfaceARH.Reset();
            // Almacenamos el valor de incio
            if (id == 0)
            {
                OLogsVAFunciones.ARH.Debug("Error reseteando el wrapper ARH");
                // Liberamos memoria reservada para la libreria de OCR, cuando termina de procesar las imagenes
                OMTInterfaceARH.QueryEnd();
                // Inicializamos el motor de búsqueda de OCR
                OMTInterfaceARH.Init(TraceWrapper, Cores);
            }
            // Reiniciamos el hilo
            ThreadARHEjecucionOCR.Resume();
        }

        /// <summary>
        /// Se demanda el uso del OCR, por lo que se necesita iniciar las librerías correspondientes
        /// </summary>
        public static void DemandaUso()
        {
            if (!UsoDemandado)
            {
                UsoDemandado = true;

                // Constructor de las funciones OCR
                OARHManager.Constructor();

                // Inicialización de las funciones OCR
                OARHManager.Inicializar();
            }
        }

        /// <summary>
        /// Se elimina la demanda el uso del OCR, por lo que se necesita finalizar las librerías correspondientes
        /// </summary>
        public static void FinDemandaUso()
        {
            if (UsoDemandado)
            {
                UsoDemandado = false;

                // Finalización de las funciones OCR
                OARHManager.Finalizar();

                // Destructor de las funciones OCR
                OARHManager.Destructor();
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase que ejecuta el reconocimiento de los codigos en un thread
    /// </summary>
    internal class ThreadEjecucionARH : OThreadLoop
    {
        #region Campos
        /// <summary>
        /// Indica si se ha de finalizar la ejecución del thread
        /// </summary>
        public bool Finalizar;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionARH(string codigo)
            : base(codigo)
        {
            this.Finalizar = false;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ThreadEjecucionARH(string codigo, ThreadPriority threadPriority)
            : base(codigo, 1, threadPriority)
        {
            this.Finalizar = false;
        }
        #endregion

        #region Métodos privados
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

        #region Delegados
        /// <summary>
        /// Delegado de ejecución del callback
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="argumentoEvento"></param>
        private delegate void DelegadoCallBack(CallBackResultadoParcial callBack, EventArgsResultadoParcial argumentoEvento);
        #endregion

        #region Métodos heredados
        /// <summary>
        /// Método a heredar para implementar la ejecución del thread.
        /// Este método se está ejecutando en un bucle. Para salir del bucle hay que devolver finalize a true.
        /// </summary>
        protected override void Ejecucion(ref bool finalize)
        {
            finalize = this.Finalizar;

            try
            {
                if (!this.Finalizar)
                {
                    OPair<OARHCodeInfo, OARHData> resultado = OMTInterfaceARH.GetResultado();

                    if (resultado != null)
                    {
                        // Guardamos la traza
                        //LogsRuntime.Debug(ModulosFunciones.Vision, this.Codigo, "Ejecución de la función OCR de ARH" + this.Codigo);
                        OLogsVAFunciones.ARH.Debug("Ejecución de la función OCR de ARH" + this.Codigo);

                        OARHCodeInfo info = resultado.First;

                        OInfoInspeccionCCR infoInspeccionOCR = (OInfoInspeccionCCR)resultado.Second.Info; // Obtengo la información de entrada de la inspección
                        OResultadoARH resultadoParcial = new OResultadoARH(info, info.GetDate); // Obtengo el resultado parcial
                        // TODO: Ya veremos esto
                        //infoInspeccionOCR.Resultados = resultadoParcial; // Añado el resultado a la información de la inspección

                        EventArgsResultadoParcial argumentoEvento = new EventArgsResultadoParcial(infoInspeccionOCR); // Creación del argumento del evento
                        CallBackResultadoParcial callBack = infoInspeccionOCR.Info.CallBackResultadoParcial; // Obtención del callback
                        this.CallBack(callBack, argumentoEvento); // Llamada al callback

                        // Guardamos en la traza el resultado
                        String codeNumber = info.GetCodeNumber;
                        String fcode = info.ToString();
                        fcode += "(FC:" + Math.Round(info.GetConfidence, 1) + ")";
                        fcode += "(AC:" + info.GetAverageCharacterHeigth + ")";
                        fcode += "(T:" + info.GetProcessingTime + ")";
                        OLogsVAFunciones.ARH.Debug("Resultado recibido:" + fcode);

                        if (info != null)
                        {
                            info.Dispose();
                        }
                        resultado = null;
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
                OLogsVAFunciones.ARH.Debug(exception);            
            }
        }
        #endregion
    }

    #region Clase OFuncionVisionARH
    /// <summary>
    /// Clase que realizara la función de reconocimiento de OCR
    /// </summary>
    public class OFuncionVisionARH : OFuncionVisionEncolada
    {
        #region Constantes
        /// <summary>
        /// Número máximo de inspecciones en la cola de ejecución
        /// </summary>
        private const int MaxInspeccionesEnCola = 100;
        #endregion

        #region Campos
        /// <summary>
        /// Parametros de entrada a procesar en el OCR
        /// </summary>
        private OParametrosARH ParametrosOCR;        
        /// <summary>
        /// Siguiente imágen a procesar en el OCR
        /// </summary>
        private OImagenBitmap Imagen;
        /// <summary>
        /// Siguiente ruta de imágen a procesar en el OCR
        /// </summary>
        private string RutaImagen;
        /// <summary>
        /// Maxima prioridad añadiendo a la cola
        /// </summary>
        private bool MaxPrioridad;
        /// <summary>
        /// Lista de información adicional incorporada por el controlador externo
        /// </summary>
        private Dictionary<string, object> InformacionAdicional;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OFuncionVisionARH(string codFuncionVision)
            : base(codFuncionVision)
        {
            try
            {
                this.TipoFuncionVision = TipoFuncionVision.ARH;

                // Demanda del uso de OCR
                OARHManager.DemandaUso();

                this.Valido = true;
                this.ParametrosOCR = new OParametrosARH();

                // Cargamos valores de la base de datos
                DataTable dtFuncionVision = AppBD.GetFuncionVision(this.Codigo);
                if (dtFuncionVision.Rows.Count == 1)
                {
                    this.ParametrosOCR.bAplicarCorreccion = OBooleano.Validar(dtFuncionVision.Rows[0]["ARH_ActivadaCorreccion"],false);
                    this.ParametrosOCR.size_min = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_AlturaMin"], 1, 10000, 30);
                    this.ParametrosOCR.size_max = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_AlturaMax"], 1, 10000, 60);
                    this.ParametrosOCR.timeout = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_Timeout"], 0, 1000000, 0);
                    this.ParametrosOCR.slope_min = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_Slope_min"], 0, 10000, 0);
                    this.ParametrosOCR.slope_max = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_Slope_max"], 0, 10000, 0);
                    this.ParametrosOCR.slant = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_Slant"], 0, 10000, 0);
                    this.ParametrosOCR.xtoyres = OEntero.Validar(dtFuncionVision.Rows[0]["ARH_Xtoyres"], 0, 10000, 0);
                    this.ParametrosOCR.isocode = OBooleano.Validar(dtFuncionVision.Rows[0]["ARH_ActivadoIsoCode"], true);
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception);
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Cargamos la configuracion de los parametros pasados por parámetro en caso de necesidad
        /// </summary>
        private void EstablecerConfiguracion(OParametrosARH parametros)
        {
            // Ejecutamos la configuración
            OMTInterfaceARH.SetConfiguracion(parametros);
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
        /// Realiza un reset de la función de visión de OCR que esta en ejecución
        /// </summary>
        public void Reset()
        {
            // Guardamos la traza
            OLogsVAFunciones.ARH.Debug("Se procede a resetear la función de visión ARH" + this.Codigo);

            OARHManager.Reset();

            // Ya no existen inspecciones pendientes
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;

            // Se finaliza la ejecución de la función de visión
            this.FuncionEjecutada();

            // Guardamos la traza
            OLogsVAFunciones.ARH.Debug("Reset de la función de visión " + this.Codigo + " realizado con éxito");
        }
      
        #endregion

        #region Métodos heredados
        /// <summary>
        /// Ejecución de la función de OCR de forma encolada
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
                if (OMTInterfaceARH.IsRunning())
                {
                    if (OMTInterfaceARH.GetQueueSize() < MaxInspeccionesEnCola)
                    {
                        // Se aumenta el número de inspecciones en cola
                        this.ContInspeccionesEnCola++;
                        this.IndiceFotografia++;

                        // Creamos el objeto con la información que nos interesa, no le pasamos la imagen para que no crezca la memoria
                        OInfoInspeccionARH infoInspeccionOCR = new OInfoInspeccionARH(
                                null,
                                //new OInfoImagenCCR(this.IdEjecucionActual, this.Codigo, this.IndiceFotografia, DateTime.Now,string.Empty, AñadirResultadoParcial),
                                this.ParametrosOCR,
                                null,
                                new OResultadoARH(),
                                this.InformacionAdicional);

                        // Se carga la configuración
                        this.EstablecerConfiguracion(this.ParametrosOCR);

                        // Se carga la imagen
                        object info = infoInspeccionOCR;

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
                                if (this.MaxPrioridad)
                                {
                                    OMTInterfaceARH.Add(this.RutaImagen, info, this.MaxPrioridad);
                                }
                                else
                                {
                                    OMTInterfaceARH.Add(this.RutaImagen, info);
                                }
                            }
                        }
                        else
                        {
                            if (this.MaxPrioridad)
                            {
                                OMTInterfaceARH.Add(this.Imagen.Image, info, true);
                            }
                            else
                            {
                                OMTInterfaceARH.Add(this.Imagen.Image, info);
                            }
                        }
                    }
                    else
                    {
                        OLogsVAFunciones.ARH.Info("FuncionOCR: Sobrepasado el limite de imagenes en cola");
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception);
            }

            return resultado;
        }

        /// <summary>
        /// Indica que hay inspecciones pendientes de ejecución
        /// </summary>
        /// <returns></returns>
        public override bool HayInspeccionesPendientes()
        {
            bool resultado = base.HayInspeccionesPendientes();

            resultado |= (OMTInterfaceARH.GetQueueSize() > 0);
            resultado |= this.ContInspeccionesEnCola > 0;

            return resultado;
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
                if (tipoVariable == OEnumTipoDato.Imagen)
                {
                    this.Imagen = (OImagenBitmap)valor;
                }
                else if (codigo == "Parametros")
                {
                    this.ParametrosOCR = (OParametrosARH)valor;
                }
                else if (codigo == "RutaImagen")
                {
                    this.RutaImagen = (string)valor;
                }
                else if (codigo == "MaxPrioridad")
                {
                    this.MaxPrioridad = (bool)valor;
                }
                else
                {
                    throw new Exception("Error en la asignación del parámetro '" + codigo + "' a la función '" + this.Codigo + "'. No se admite este tipo de parámetros.");
                }
                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.ARH.Error(exception);
            }
            return resultado;
        }
        #endregion
    }
    #endregion

    /// <summary>
    /// Clase que contiene la información referente a la inspección
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TParametros"></typeparam>
    /// <typeparam name="TResultados"></typeparam>
    public class OInfoInspeccionARH : OInfoInspeccion<OImagenBitmap, OParametrosARH, OInfoImagenARH, OResultadoARH>
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OInfoInspeccionARH()
            : base()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="info"></param>
        /// <param name="parametros"></param>
        /// <param name="resultados"></param>
        public OInfoInspeccionARH(OImagenBitmap imagen, OParametrosARH parametros, OInfoImagenARH info, OResultadoARH resultados, Dictionary<string, object> informacionAdicional)
            : base(imagen, parametros, info, resultados, informacionAdicional)
        {
        }
        #endregion
    }

    /// <summary>
    /// Esta clase contendra la información que queremos pasar con la imagen al CCR para recogerla cuando tengamos el resultado
    /// </summary>
    public class OInfoImagenARH : OConvertibleXML
    {
        #region Atributo(s)
        /// <summary>
        /// Contiene la información de la identificacion a la que pertenece
        /// </summary>
        public long IdEjecucionActual;
        /// <summary>
        /// Contiene la información de la cámara que se le pasa en la imagen
        /// </summary>
        public string CodigoCamara;
        /// <summary>
        /// Contiene el indice de la imagen añadida
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
        public OInfoImagenARH()
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
        public OInfoImagenARH(long idEjecucionActual, string codCamara, int indice, DateTime momentoImagen, CallBackResultadoParcial callBackResultadoParcial)
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
    /// Clase que contiene los resultados que se reciben del OCR para una imagen pasada anteriormente
    /// </summary>
    public class OResultadoARH : OConvertibleXML
    {
        #region Campos
        /// <summary>
        /// Contiene la cadena del codigo del contenedor
        /// </summary>
        public string CodigoContenedor;
        /// <summary>
        /// Contiene la información extra del código del contenedor
        /// </summary>
        public string ExtaInfoCodigo;
        /// <summary>
        /// Si esta verificado el digito de control
        /// </summary>
        public bool CodigoVerificado;
        /// <summary>
        /// Fiabilidad Código
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
        /// Fecha en la que se encolo a la cola de OCR (dada por él)
        /// </summary>
        public DateTime FechaEncolamiento;
        /// <summary>
        /// Tiempo de proceso
        /// </summary>
        public int TiempoDeProceso;
        #endregion     

        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public OResultadoARH()
        {
            this.CodigoContenedor = "";
            this.ExtaInfoCodigo = "";
            this.CodigoVerificado = false;
            this.FiabilidadCodigo = 0;
            this.FiabilidadExtraInfo = 0;
            this.AlturaLetrasCodigo = 0;
            this.TiempoDeProceso = 0;
            this.FechaEncolamiento = new DateTime();            
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        public OResultadoARH(OARHCodeInfo resultadoImagen, DateTime fechaEncola)
        {
            try
            {
                if (resultadoImagen != null)
                {
                    this.CodigoContenedor = resultadoImagen.GetCodeNumber;

                    // Si tenemos código identificado , obtenemos las fiabilidades de cada una de las letras y su código
                    if (!(this.CodigoContenedor != string.Empty))
                    {
                        this.CodigoContenedor = string.Empty;
                    }

                    // Si tenemos información extra la obtenemos
                    if (resultadoImagen.GetExtraInfoCodeNumber != null)
                    {
                        this.ExtaInfoCodigo = (string)resultadoImagen.GetExtraInfoCodeNumber.ToString().Clone();
                    }
                    else
                    {
                        this.ExtaInfoCodigo = "";
                    }
                    // Obtenemos el resto de resultados independientes
                    this.FiabilidadCodigo = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetConfidence)).ToString().Clone());
                    this.AlturaLetrasCodigo = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetAverageCharacterHeigth)).ToString().Clone());
                    this.TiempoDeProceso = Convert.ToInt32((Convert.ToInt32(resultadoImagen.GetProcessingTime)).ToString().Clone());
                    this.CodigoVerificado = Convert.ToBoolean(resultadoImagen.IsVerificated);
                    this.FechaEncolamiento = fechaEncola;
                }
                else
                {
                    this.CodigoContenedor = "";
                    this.ExtaInfoCodigo = "";
                    this.CodigoVerificado = false;
                    this.FiabilidadCodigo = 0;
                    this.FiabilidadExtraInfo = 0;
                    this.AlturaLetrasCodigo = 0;
                    this.TiempoDeProceso = 0;
                    this.FechaEncolamiento = new DateTime();
                    this.FechaEncolamiento = DateTime.Now;
                }
            }
            catch (Exception exception)
            {
                // En caso de que se produzca cualquier error no contemplado, descartaremos el resultado recibido permitiendo continuar la ejecución
                OLogsVAFunciones.ARH.Error(exception, "CREANDO RESULTADO ARH");
            }
        }
        /// <summary>
        /// Clase que contiene la información referente a la inspección
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <typeparam name="TParametros"></typeparam>
        /// <typeparam name="TResultados"></typeparam>
        #endregion
    }
    
}