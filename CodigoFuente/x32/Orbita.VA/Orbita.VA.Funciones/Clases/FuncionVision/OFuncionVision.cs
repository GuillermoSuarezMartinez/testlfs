//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 26-11-2013
// Last Modified On : aibañez
// Description      : Añadida propiedad de cronómetro
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Orbita.Utiles;
using Orbita.VA.Comun;
using Orbita.Xml;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase de acceso estático que contiene la lista de funciones de visión
    /// </summary>
    public static class OFuncionesVisionManager
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de funciones de visión funcionando en el sistema
        /// </summary>
        private static Dictionary<string, OFuncionVisionBase> ListaFuncionesVision;

        /// <summary>
        /// Lista de todas las escenarios de las funciones de visión del sistema
        /// </summary>
        public static Dictionary<string, OEscenarioFuncionVision> Escenarios;
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Método para acceder a una función de visión
        /// </summary>
        /// <param name="codEscenario">Escenario</param>
        /// <param name="codAlias">Código o alias de la función de visión</param>
        /// <param name="hardware">Función de visión devuelta</param>
        /// <returns>Verdadero si se ha encontrado la función de visión</returns>
        private static bool TryGetFuncionVision(string codEscenario, string codAlias, out OFuncionVisionBase funcionVision)
        {
            // Inicialización de resultados
            bool resultado = false;
            funcionVision = null;

            if (OSistemaManager.IntegraMaquinaEstados)
            {
                string alias = codAlias;

                // Cambio el alias al del escenario
                if ((codEscenario != string.Empty) && (OSistemaManager.IntegraMaquinaEstados) && (Escenarios is Dictionary<string, OEscenarioFuncionVision>))
                {
                    // Cambio el alias
                    OEscenarioFuncionVision escenarioFuncionVision;
                    if (Escenarios.TryGetValue(codEscenario, out escenarioFuncionVision))
                    {
                        string codHardware;
                        if (escenarioFuncionVision.ListaAlias.TryGetValue(codAlias, out codHardware))
                        {
                            alias = codHardware;
                        }
                    }
                }

                if (ListaFuncionesVision is Dictionary<string, OFuncionVisionBase>)
                {
                    resultado = ListaFuncionesVision.TryGetValue(alias, out funcionVision);
                }
            }

            return resultado;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        public static void Constructor()
        {
            // Construyo la lista de funciones de visión
            ListaFuncionesVision = new Dictionary<string, OFuncionVisionBase>();

            // Consulta a la base de datos
            DataTable dt = AppBD.GetFuncionesVision();
            if (dt.Rows.Count > 0)
            {
                // Cargamos todas las funciones de visión existentes en el sistema
                foreach (DataRow dr in dt.Rows)
                {
                    string codFuncionVision = dr["CodFuncionVision"].ToString();
                    if (!codFuncionVision.ValidarNomenclaturaPropiedadNet())
                    {
                        throw new ONomenclaturaNetException(codFuncionVision);
                    }

                    string ensambladoClaseImplementadora = dr["EnsambladoClaseImplementadora"].ToString();
                    if (!ensambladoClaseImplementadora.ValidarNomenclaturaEnsambladoNet())
                    {
                        throw new ONomenclaturaNetException(ensambladoClaseImplementadora);
                    }

                    string claseImplementadora = dr["ClaseImplementadora"].ToString();
                    if (!claseImplementadora.ValidarNomenclaturaPropiedadNet())
                    {
                        throw new ONomenclaturaNetException(claseImplementadora);
                    }

                    object objetoImplementado;
                    if (App.ConstruirClase(ensambladoClaseImplementadora, string.Format("{0}.{1}", ensambladoClaseImplementadora, claseImplementadora), out objetoImplementado, codFuncionVision))
                    {
                        OFuncionVisionBase funcionVision = (OFuncionVisionBase)objetoImplementado;
                        ListaFuncionesVision.Add(codFuncionVision, funcionVision);
                    }
                }
            }

            // Consulta de todas las escenarios existentes en el sistema
            if (OSistemaManager.IntegraMaquinaEstados)
            {
                Escenarios = new Dictionary<string, OEscenarioFuncionVision>();

                DataTable dtEscenario = Orbita.VA.Comun.AppBD.GetEscenarios();
                if (dtEscenario.Rows.Count > 0)
                {
                    // Cargamos todas las escenarios existentes en el sistema
                    OEscenarioFuncionVision escenario;
                    foreach (DataRow drEscenario in dtEscenario.Rows)
                    {
                        // Creamos cada una de los escenarios del sistema
                        string codEscenario = drEscenario["CodEscenario"].ToString();
                        escenario = new OEscenarioFuncionVision(codEscenario);
                        Escenarios.Add(codEscenario, escenario);
                    }
                }
            }
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        public static void Destructor()
        {
            // Destruyo la lista de máquinas de estados
            ListaFuncionesVision = null;

            // Se elimina la demanda del uso de LPR
            OLPRManager.FinDemandaUso();

            // Se elimina la demanda del uso de OCR
            OCCRManager.FinDemandaUso();
        }

        /// <summary>
        /// Carga las propiedades de la base de datos
        /// </summary>
        public static void Inicializar()
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision.Values)
            {
                visionFunction.Inicializar();
            }
        }

        /// <summary>
        /// Finaliza la ejecución
        /// </summary>
        public static void Finalizar()
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision.Values)
            {
                visionFunction.Finalizar();
            }
        }

        /// <summary>
        /// Inicia la ejecución de determinada función de visión.
        /// Se debe ejecutar a esta función desde el hilo principal de la aplicación, de lo contrario ocurrirán excepciones.
        /// </summary>
        public static void IniciarEjecucion(string codFuncionVision)
        {
            IniciarEjecucion(string.Empty, codFuncionVision);
        }
        /// <summary>
        /// Inicia la ejecución de determinada función de visión.
        /// Se debe ejecutar a esta función desde el hilo principal de la aplicación, de lo contrario ocurrirán excepciones.
        /// </summary>
        public static void IniciarEjecucion(string escenario, string codFuncionVision)
        {
            OFuncionVisionBase funcionVision;
            if (TryGetFuncionVision(escenario, codFuncionVision, out funcionVision))
            {
                funcionVision.IniciarEjecucion();
            }
        }

        /// <summary>
        /// Inicia la ejecución de determinada función de visión de forma síncrona
        /// Se debe ejecutar a esta función desde el hilo principal de la aplicación, de lo contrario ocurrirán excepciones.
        /// </summary>
        public static void IniciarEjecucionSincrona(string codFuncionVision)
        {
            IniciarEjecucionSincrona(string.Empty, codFuncionVision);
        }
        /// <summary>
        /// Inicia la ejecución de determinada función de visión de forma síncrona
        /// Se debe ejecutar a esta función desde el hilo principal de la aplicación, de lo contrario ocurrirán excepciones.
        /// </summary>
        public static void IniciarEjecucionSincrona(string escenario, string codFuncionVision)
        {
            OFuncionVisionBase funcionVision;
            if (TryGetFuncionVision(escenario, codFuncionVision, out funcionVision))
            {
                funcionVision.IniciarEjecucionSincrona();
            }
        }

        /// <summary>
        /// Inicia la ejecución de determinada función de visión de forma asíncrona
        /// Se debe ejecutar a esta función desde el hilo principal de la aplicación, de lo contrario ocurrirán excepciones.
        /// </summary>
        /// 
        public static void IniciarEjecucionAsincrona(string codFuncionVision)
        {
            IniciarEjecucionAsincrona(string.Empty, codFuncionVision);
        }
        /// <summary>
        /// Inicia la ejecución de determinada función de visión de forma asíncrona
        /// Se debe ejecutar a esta función desde el hilo principal de la aplicación, de lo contrario ocurrirán excepciones.
        /// </summary>
        /// 
        public static void IniciarEjecucionAsincrona(string escenario, string codFuncionVision)
        {
            OFuncionVisionBase funcionVision;
            if (TryGetFuncionVision(escenario, codFuncionVision, out funcionVision))
            {
                funcionVision.IniciarEjecucionAsincrona();
            }
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="codFuncionVision">Código identificador de la función de vision</param>
        /// <param name="codPieza">Código identificador de la pieza</param>
        /// <param name="codParametro">Código identificador del parámetro</param>
        /// <param name="valor">Nuevo valor del parámetro</param>
        /// <param name="tipoVariable">Tipo del parámetro</param>
        /// <returns>Verdadero si la función se ha ejecutado correctamente</returns>
        public static bool SetEntrada(string codFuncionVision, string codParametro, object valor, OEnumTipoDato tipoVariable)
        {
            return SetEntrada(string.Empty, codFuncionVision, codParametro, valor, tipoVariable);
        }
        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="codFuncionVision">Código identificador de la función de vision</param>
        /// <param name="codPieza">Código identificador de la pieza</param>
        /// <param name="codParametro">Código identificador del parámetro</param>
        /// <param name="valor">Nuevo valor del parámetro</param>
        /// <param name="tipoVariable">Tipo del parámetro</param>
        /// <returns>Verdadero si la función se ha ejecutado correctamente</returns>
        public static bool SetEntrada(string escenario, string codFuncionVision, string codParametro, object valor, OEnumTipoDato tipoVariable)
        {
            OFuncionVisionBase funcionVision;
            if (TryGetFuncionVision(escenario, codFuncionVision, out funcionVision))
            {
                return funcionVision.SetEntrada(codParametro, valor, tipoVariable);
            }

            return false;
        }

        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="codFuncionVision">Código identificador de la función de vision</param>
        /// <param name="codPieza">Código identificador de la pieza</param>
        /// <param name="codParametro">Código identificador del parámetro</param>
        /// <param name="valor">Valor del parámetro devuelto por la función</param>
        /// <param name="tipoVariable">Tipo del parámetro</param>
        /// <returns>Verdadero si la función se ha ejecutado correctamente</returns>
        public static bool GetSalida(string codFuncionVision, string codParametro, out object valor, OEnumTipoDato tipoVariable)
        {
            return GetSalida(string.Empty, codFuncionVision, codParametro, out valor, tipoVariable);
        }
        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="codFuncionVision">Código identificador de la función de vision</param>
        /// <param name="codPieza">Código identificador de la pieza</param>
        /// <param name="codParametro">Código identificador del parámetro</param>
        /// <param name="valor">Valor del parámetro devuelto por la función</param>
        /// <param name="tipoVariable">Tipo del parámetro</param>
        /// <returns>Verdadero si la función se ha ejecutado correctamente</returns>
        public static bool GetSalida(string escenario, string codFuncionVision, string codParametro, out object valor, OEnumTipoDato tipoVariable)
        {
            OFuncionVisionBase funcionVision;
            valor = null;
            if (TryGetFuncionVision(escenario, codFuncionVision, out funcionVision))
            {
                return funcionVision.GetSalida(codParametro, out valor, tipoVariable);
            }

            return false;
        }

        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="listaSalidas">Lista de objetos que respresentan el conjunto de salidas de la función de visión</param>
        /// <returns></returns>
        public static bool GetSalidas(string codFuncionVision, out Dictionary<string, object> listaSalidas)
        {
            return GetSalidas(string.Empty, codFuncionVision, out listaSalidas);
        }
        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="listaSalidas">Lista de objetos que respresentan el conjunto de salidas de la función de visión</param>
        /// <returns></returns>
        public static bool GetSalidas(string escenario, string codFuncionVision, out Dictionary<string, object> listaSalidas)
        {
            OFuncionVisionBase funcionVision;
            listaSalidas = null;
            if (TryGetFuncionVision(escenario, codFuncionVision, out funcionVision))
            {
                return funcionVision.GetSalidas(out listaSalidas);
            }

            return false;
        }

        /// <summary>
        /// Obtiene la función de visión mediante las claves
        /// </summary>
        /// <returns></returns>
        public static OFuncionVisionBase GetFuncionVision(OClaves claves)
        {
            OFuncionVisionBase resultado = null;

            foreach (OFuncionVisionBase funcionVision in ListaFuncionesVision.Values)
            {
                if (funcionVision.Claves.CompararClaves(claves))
                {
                    resultado = funcionVision;
                    break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene la función de visión mediante las claves
        /// </summary>
        /// <returns></returns>
        public static OFuncionVisionBase GetFuncionVision(string codigo)
        {
            return GetFuncionVision(string.Empty, codigo);
        }

        /// <summary>
        /// Obtiene la función de visión mediante las claves
        /// </summary>
        /// <param name="escenario">Escenario utilizada</param>
        /// <param name="codigo">Código de la función de visión</param>
        /// <returns>Hardware encontrado</returns>
        public static OFuncionVisionBase GetFuncionVision(string escenario, string codigo)
        {
            OFuncionVisionBase funcionVisionBase;
            if (TryGetFuncionVision(escenario, codigo, out funcionVisionBase))
            {
                return funcionVisionBase;
            }
            return null;
        }

        /// <summary>
        /// Obtiene el código de la función de visión mediante las claves
        /// </summary>
        /// <returns></returns>
        public static string GetCodigoFuncionVision(OClaves claves)
        {
            string resultado = string.Empty;

            foreach (OFuncionVisionBase funcionVision in ListaFuncionesVision.Values)
            {
                if (funcionVision.Claves.CompararClaves(claves))
                {
                    resultado = funcionVision.Codigo;
                    break;
                }
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase que implementa los escenarios de las funciones de visión
    /// </summary>
    public class OEscenarioFuncionVision
    {
        #region Atributo(s)
        /// <summary>
        /// Código del escenario
        /// </summary>
        public string Codigo;

        /// <summary>
        /// Lista de todos los alias del escenario
        /// </summary>
        public Dictionary<string, string> ListaAlias;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codEscenario">Código del escenario</param>
        public OEscenarioFuncionVision(string codEscenario)
        {
            this.Codigo = codEscenario;

            this.ListaAlias = new Dictionary<string, string>();
            this.RellenarAlias(codEscenario);
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Rellena la lista de alias del escenario
        /// </summary>
        private void RellenarAlias(string codEscenario)
        {
            // Consulta de todos los alias existentes en el sistema
            DataTable dtVar = AppBD.GetAliasEscenarioFuncionesVision(codEscenario);
            if (dtVar.Rows.Count > 0)
            {
                // Cargamos todos los alias existentes en el sistema
                foreach (DataRow drVar in dtVar.Rows)
                {
                    // Creamos cada una de las variables del sistema
                    string codAlias = drVar["CodAlias"].ToString();
                    string codFuncionVision = drVar["CodFuncionVision"].ToString();
                    ListaAlias.Add(codAlias, codFuncionVision);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase base para todas las funciones de visión
    /// </summary>
    public class OFuncionVisionBase
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de entradas de la funcion
        /// </summary>
        internal List<OParametroFuncionVision> ListaParametrosEntrada;

        /// <summary>
        /// Lista de salidas de la función
        /// </summary>
        internal List<OParametroFuncionVision> ListaParametrosSalida;

        /// <summary>
        /// Informa del estado de la ejecución
        /// </summary>
        public bool EjecucionTerminada;

        /// <summary>
        /// Claves de la función de visión
        /// </summary>
        public OClaves Claves;

        /// <summary>
        /// Cronómetro de la duración de las ejecuciones
        /// </summary>
        public OCronometro Cronometro;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Id de la ejecucion Actual
        /// </summary>
        private long _IdEjecucionActual;
        /// <summary>
        /// d de la ejecucion Actual
        /// </summary>
        public long IdEjecucionActual
        {
            get { return _IdEjecucionActual; }
            set { _IdEjecucionActual = value; }
        }

        /// <summary>
        /// Ruta del fichero a cargar
        /// </summary>
        private string _RutaFichero;
        /// <summary>
        /// Ruta del fichero a cargar
        /// </summary>
        public string RutaFichero
        {
            get { return _RutaFichero; }
            set { _RutaFichero = value; }
        }

        /// <summary>
        /// Código identificativo de la función
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo de la función
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nombre identificativo de la función
        /// </summary>
        private string _Nombre;
        /// <summary>
        /// Nombre identificativo de la función
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        /// Descripción de la función
        /// </summary>
        private string _Descripcion;
        /// <summary>
        /// Descripción de la función
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        /// Indica que la función ha sido cargada correctamente
        /// </summary>
        private bool _Valido;
        /// <summary>
        /// Indica que la función ha sido cargada correctamente
        /// </summary>
        public bool Valido
        {
            get { return _Valido; }
            set { _Valido = value; }
        }

        /// <summary>
        /// Tipo de función de visión
        /// </summary>
        private TipoFuncionVision _TipoFuncionVision;
        /// <summary>
        /// Tipo de función de visión
        /// </summary>
        public TipoFuncionVision TipoFuncionVision
        {
            get { return _TipoFuncionVision; }
            set { _TipoFuncionVision = value; }
        }

        /// <summary>
        /// Indica si la ejecución se realiza por defecto en el mismo hilo de ejecución que la
        /// applicación principal o en un hijo de ejecución distinto
        /// </summary>
        private TipoEjecucionFuncionVision _TipoEjecucionFuncionVision;
        /// <summary>
        /// Indica si la ejecución se realiza por defecto en el mismo hilo de ejecución que la
        /// applicación principal o en un hijo de ejecución distinto
        /// </summary>
        public TipoEjecucionFuncionVision TipoEjecucionFuncionVision
        {
            get { return _TipoEjecucionFuncionVision; }
            set { _TipoEjecucionFuncionVision = value; }
        }

        /// <summary>
        /// Código identificativo de la variable que se activa
        /// </summary>
        private string _CodVariableEnEjecucion;
        /// <summary>
        /// Código identificativo de la función
        /// </summary>
        public string CodVariableEnEjecucion
        {
            get { return _CodVariableEnEjecucion; }
            set { _CodVariableEnEjecucion = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OFuncionVisionBase(string codFuncionVision)
        {
            // Inicialiamos los valores
            this._Codigo = codFuncionVision;
            this.ListaParametrosEntrada = new List<OParametroFuncionVision>();
            this.ListaParametrosSalida = new List<OParametroFuncionVision>();
            this._Valido = false;
            this._IdEjecucionActual = 0;
            this.EjecucionTerminada = true;

            // Cargamos valores de la base de datos
            DataTable dtFuncionVision = AppBD.GetFuncionVision(this._Codigo);
            if (dtFuncionVision.Rows.Count == 1)
            {
                this._Nombre = dtFuncionVision.Rows[0]["NombreFuncionVision"].ToString();
                this._Descripcion = dtFuncionVision.Rows[0]["DescFuncionVision"].ToString();
                this._RutaFichero = dtFuncionVision.Rows[0]["RutaFichero"].ToString();

                int intTipoFuncion = OEntero.Validar(dtFuncionVision.Rows[0]["IdTipoFuncionVision"], 1, 3, 1);
                this._TipoFuncionVision = (TipoFuncionVision)intTipoFuncion;

                this._TipoEjecucionFuncionVision = OEnumerado<TipoEjecucionFuncionVision>.Validar(dtFuncionVision.Rows[0]["TipoEjecucion"].ToString(), TipoEjecucionFuncionVision.EjecucionSincrona);
                //this._TipoEjecucionFuncionVision = (OTipoEjecucionFuncionVision)App.EnumParse(typeof(OTipoEjecucionFuncionVision), dtFuncionVision.Rows[0]["TipoEjecucion"].ToString(), OTipoEjecucionFuncionVision.EjecucionSincrona);

                this._CodVariableEnEjecucion = dtFuncionVision.Rows[0]["CodVariable"].ToString();

                // Consulta las claves de una determinada escenario
                this.Claves = new OClaves();
                DataTable dt = AppBD.GetClavesDeFuncionVision(this.Codigo);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Claves.Add(new OClave(dr));
                    }
                }

                // Cargamos el código de las variables de entrada que se utilizan en la funcion
                DataTable dtParametrosEntrada = AppBD.GetParametrosFuncionesVision(this._Codigo, true);
                if (dtParametrosEntrada.Rows.Count > 0)
                {
                    object codParametroEntradaAux;
                    foreach (DataRow dr in dtParametrosEntrada.Rows)
                    {
                        codParametroEntradaAux = dr["CodParametroFuncionVision"];
                        if ((codParametroEntradaAux is string) && ((string)codParametroEntradaAux != string.Empty))
                        {
                            OParametroFuncionVision parametro = new OParametroFuncionVision(this._Codigo, (string)codParametroEntradaAux);
                            this.ListaParametrosEntrada.Add(parametro);
                        }
                    }
                }

                // Cargamos el código de las variables de salida que se utilizan en la funcion
                DataTable dtParametrosSalida = AppBD.GetParametrosFuncionesVision(this._Codigo, false);
                if (dtParametrosSalida.Rows.Count > 0)
                {
                    object codParametroSalidaAux;
                    foreach (DataRow dr in dtParametrosSalida.Rows)
                    {
                        codParametroSalidaAux = dr["CodParametroFuncionVision"];
                        if ((codParametroSalidaAux is string) && ((string)codParametroSalidaAux != string.Empty))
                        {
                            OParametroFuncionVision parametro = new OParametroFuncionVision(this._Codigo, (string)codParametroSalidaAux);
                            this.ListaParametrosSalida.Add(parametro);
                        }
                    }
                }

                // Creación del cronómetro
                this.Cronometro = OCronometrosManager.NuevoCronometro(this._Codigo, "Ejecución función " + this.Nombre, "Ejecución de la función de visión " + this.Nombre);
            }
        }

        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Llamada a la ejecución de la función
        /// </summary>
        public virtual void IniciarEjecucion()
        {
            switch (this._TipoEjecucionFuncionVision)
            {
                case TipoEjecucionFuncionVision.EjecucionSincrona:
                default:
                    this.IniciarEjecucionSincrona();
                    break;
                case TipoEjecucionFuncionVision.EjecucionAsincrona:
                    this.IniciarEjecucionAsincrona();
                    break;
            }
        }

        /// <summary>
        /// Llamada a la ejecución de la función de forma síncrona
        /// </summary>
        internal void IniciarEjecucionSincrona()
        {
            if (this._Valido)
            {
                // Cronometramos la duración de la ejecución
                OCronometrosManager.Start(this._Codigo);

                // Guardamos la traza
                OLogsVAFunciones.Vision.Info(this._Codigo, "Inicio de la ejecución síncrona de la función " + this._Codigo);

                this.EjecucionTerminada = false;

                // Llamada a la variable que indica el estado de ejecución de la función
                OVariablesManager.SetValue(this._CodVariableEnEjecucion, true, "Vision", this.Codigo);

                this.SetEntradasVariables();
                this.EjecucionSincrona();
            }
        }

        /// <summary>
        /// Llamada a la ejecución de la función de forma asíncrona
        /// </summary>
        internal void IniciarEjecucionAsincrona()
        {
            if (this._Valido)
            {
                // Cronometramos la duración de la ejecución
                OCronometrosManager.Start(this._Codigo);

                // Guardamos la traza
                OLogsVAFunciones.Vision.Info(this._Codigo, "Inicio de la ejecución asíncrona de la función " + this._Codigo);

                this.EjecucionTerminada = false;

                // Llamada a la variable que indica el estado de ejecución de la función
                OVariablesManager.SetValue(this._CodVariableEnEjecucion, true, "Vision", this.Codigo);

                this.SetEntradasVariables();
                this.EjecucionAsincrona();
            }
        }

        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="listaSalidas">Lista de objetos que respresentan el conjunto de salidas de la función de visión</param>
        /// <returns></returns>
        public bool GetSalidas(out Dictionary<string, object> listaSalidas)
        {
            listaSalidas = new Dictionary<string, object>();

            foreach (OParametroFuncionVision parametro in this.ListaParametrosSalida)
            {
                switch (parametro.OrigenValorParametro)
                {
                    case OrigenValorParametro.ValorPorCodigo:
                        object valorSalida;

                        if (this.GetSalida(parametro.Codigo, out valorSalida, parametro.Tipo))
                        {
                            listaSalidas.Add(parametro.Codigo, valorSalida);
                        }
                        break;
                }
            }

            return listaSalidas.Count > 0;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Método donde se cargan las entradas a la función de visión
        /// </summary>
        protected void SetEntradasVariables()
        {
            object valorEntrada;
            foreach (OParametroFuncionVision parametro in this.ListaParametrosEntrada)
            {
                switch (parametro.OrigenValorParametro)
                {
                    case OrigenValorParametro.ValorVariable:
                        valorEntrada = OVariablesManager.GetValue(parametro.CodVariable);
                        this.SetEntrada(parametro.Codigo, valorEntrada, parametro.Tipo);
                        break;
                }
            }
        }

        /// <summary>
        /// Método donde se cargan las entradas a la función de visión
        /// </summary>
        protected void SetEntradasFijas()
        {
            object valorEntrada;
            foreach (OParametroFuncionVision parametro in this.ListaParametrosEntrada)
            {
                switch (parametro.OrigenValorParametro)
                {
                    case OrigenValorParametro.ValorFijo:
                        valorEntrada = parametro.Valor;
                        this.SetEntrada(parametro.Codigo, valorEntrada, parametro.Tipo);
                        break;
                }
            }
        }

        /// <summary>
        /// Método donde se leen las salidas de la función de visión
        /// </summary>
        protected void GetSalidasVariables()
        {
            object valorSalida = null;
            foreach (OParametroFuncionVision parametro in this.ListaParametrosSalida)
            {
                switch (parametro.OrigenValorParametro)
                {
                    case OrigenValorParametro.ValorVariable:
                        if (this.GetSalida(parametro.Codigo, out valorSalida, parametro.Tipo))
                        {
                            OVariablesManager.SetValue(parametro.CodVariable, valorSalida, "VisionFunction", this.Codigo);
                        }
                        break;
                }
            }
        }
        #endregion

        #region Método(s) virtual(es)

        /// <summary>
        /// Método a heredar donde se carga el fichero de la función de visión
        /// </summary>
        public virtual void Inicializar()
        {
            if (this.Valido)
            {
                this.SetEntradasFijas();
            }
        }

        /// <summary>
        /// Método a heredar donde se descarga el fichero de la función de visión
        /// </summary>
        public virtual void Finalizar()
        {
            this._Valido = false;
        }

        /// <summary>
        /// Metodo virtual donde se ejecuta la función de visión de forma síncrona
        /// </summary>
        /// <returns></returns>
        protected virtual bool EjecucionSincrona()
        {
            return false;
        }

        /// <summary>
        /// Metodo virtual donde se ejecuta la función de visión de forma asíncrona
        /// </summary>
        /// <returns></returns>
        protected virtual bool EjecucionAsincrona()
        {
            return false;
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool SetEntrada(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            return false;
        }

        /// <summary>
        /// Función para la actualización de parámetros de entrada
        /// </summary>
        /// <param name="tipoEntrada">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool SetEntrada(EnumTipoEntradaFuncionVision tipoEntrada, object valor, OEnumTipoDato tipoVariable)
        {
            return false;
        }

        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool GetSalida(string codigo, out object valor, OEnumTipoDato tipoVariable)
        {
            valor = null;
            return false;
        }

        /// <summary>
        /// Función para la consulta de parámetros de salida
        /// </summary>
        /// <param name="ParamName">Nombre identificador del parámetro</param>
        /// <param name="ParamValue">Nuevo valor del parámetro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool GetSalida(EnumTipoSalidaFuncionVision salida, out object valor, OEnumTipoDato tipoVariable)
        {
            valor = null;
            return false;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento que se ejecuta cuando finaliza la ejecución de la función
        /// </summary>
        /// <param name="sender">Objeto que envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void FuncionEjecutada()
        {
            try
            {
                this.GetSalidasVariables();

                // Paramos el cronometro de la duración de la ejecución
                OCronometrosManager.Stop(this._Codigo);

                // Guardamos la traza
                OLogsVAFunciones.Vision.Info(this._Codigo, "Fin de la ejecución de la función " + this._Codigo + ". Duración: " + OCronometrosManager.DuracionUltimaEjecucion(this._Codigo).ToString());

                // Llamada a la variable que indica el estado de ejecución de la función
                OVariablesManager.SetValue(this._CodVariableEnEjecucion, false, "Vision", this.Codigo);

                this.EjecucionTerminada = true;
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.Vision.Error(exception, this._Codigo);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase base para todas las funciones de visión
    /// </summary>
    public class OFuncionVisionEncolada : OFuncionVisionBase
    {
        #region Atributo(s)
        /// <summary>
        /// Cola donde iremos almacenando los resultados parciales
        /// </summary>
        public Queue<object> ResultadosParciales;

        /// <summary>
        /// Contador de imágenes
        /// </summary>
        public int ContInspeccionesEnCola;

        /// <summary>
        /// Indice de la última fotografía añadida a la cola de proceso
        /// </summary>
        public int IndiceFotografia;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica que la función ha de dejar de ejecutarse si se encuentra en ejecución continúa
        /// </summary>
        private bool _Abortar;
        /// <summary>
        /// Indica que la función ha de dejar de ejecutarse si se encuentra en ejecución continúa
        /// </summary>
        public bool Abortar
        {
            get { return _Abortar; }
            set { _Abortar = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OFuncionVisionEncolada(string codFuncionVision)
            : base(codFuncionVision)
        {
            // Inicialiamos los valores
            this._Abortar = false;
            this.ResultadosParciales = new Queue<object>();
            this.OnResultadoParcial = null;
        }

        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicializa la configuración del LPR
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();

            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;
        }

        /// <summary>
        /// Método a heredar donde se descarga el fichero de la función de visión
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Llamada a la ejecución de la función
        /// </summary>
        public new void IniciarEjecucion()
        {
            this.IniciarEjecucionEncolada();
        }

        /// <summary>
        /// Llamada a la ejecución de la función
        /// </summary>
        public void IniciarEjecucion(EntradasFuncionesVision listaEntradas)
        {
            foreach (OTriplet<string, object, OEnumTipoDato> tripleteEntrada in listaEntradas)
            {
                this.SetEntrada(tripleteEntrada.First, tripleteEntrada.Second, tripleteEntrada.Third);
            }

            this.IniciarEjecucionEncolada();
        }

        /// <summary>
        /// Llamada a la ejecución de la función de forma encolada
        /// </summary>
        internal void IniciarEjecucionEncolada()
        {
            if (this.Valido)
            {
                // Cronometramos la duración de la ejecución
                OCronometrosManager.Start(this.Codigo);

                // Guardamos la traza
                OLogsVAFunciones.Vision.Info(this.Codigo, "Inicio de la ejecución encolada de la función " + this.Codigo);

                this.EjecucionTerminada = false;

                // Llamada a la variable que indica el estado de ejecución de la función
                OVariablesManager.SetValue(this.CodVariableEnEjecucion, true, "Vision", this.Codigo);

                this.EjecucionEncolada();
            }
        }

        /// <summary>
        /// Llamada para saber si se dispone de resultados parciales
        /// </summary>
        /// <returns></returns>
        public bool HayResultadosParciales()
        {
            return (this.ResultadosParciales.Count > 0);
        }

        /// <summary>
        /// Devuelve un resultado parcial
        /// </summary>
        /// <returns></returns>
        public object ExtraerResultadoParcial()
        {
            object resultado = new object();
            if (this.ResultadosParciales.Count > 0)
            {
                resultado = this.ResultadosParciales.Dequeue();
            }
            return resultado;
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Indica que hay inspecciones pendientes de ejecución
        /// </summary>
        /// <returns></returns>
        public virtual bool HayInspeccionesPendientes()
        {
            return false;
        }

        /// <summary>
        /// Metodo virtual asociado al delegado donde se recibe un resultado parcial
        /// </summary>
        /// <returns></returns>
        internal virtual void AñadirResultadoParcial(object sender, EventArgsResultadoParcial e)
        {
            try
            {
                this.ContInspeccionesEnCola--;

                // Evento de llegada de resultado parcial
                if (this.OnResultadoParcial != null)
                {
                    this.OnResultadoParcial(sender, e);
                }

                // Se realizan las acciones de fin de inspección
                this.ResultadosParciales.Enqueue(e.InfoInspeccion);
                if (!this.HayInspeccionesPendientes())
                {
                    this.FuncionEjecutada();
                }
            }
            catch (Exception exception)
            {
                OLogsVAFunciones.Vision.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Resetea la cola de ejecución
        /// </summary>
        public virtual void ResetearColaEjecucion()
        {
            this.ResultadosParciales.Clear();
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;
        }

        /// <summary>
        /// Metodo virtual donde se ejecuta la función de visión de forma encolada
        /// </summary>
        /// <returns></returns>
        protected virtual bool EjecucionEncolada()
        {
            return false;
            // Ejecutado en heredados
        }        
        #endregion

        #region Definición de delegado(s)
        /// <summary>
        /// CallBack donde mandar el resultado parcial
        /// </summary>
        public CallBackResultadoParcial OnResultadoParcial;
        #endregion
    }

    /// <summary>
    /// Clase que representa a un parámetro de entrada o de salida de una función de visión
    /// </summary>
    internal class OParametroFuncionVision
    {
        #region Propiedad(es)
        /// <summary>
        /// Código identificativo del parámetro
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo del parámetro
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nombre identificativo del parámetro
        /// </summary>
        private string _Nombre;
        /// <summary>
        /// Nombre identificativo del parámetro
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        /// Descripción del parámetro
        /// </summary>
        private string _Descripcion;
        /// <summary>
        /// Descripción del parámetro
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        /// Indica si el parámetro de la función de visión es una entrada o una salida
        /// </summary>
        private bool _EsEntrada;
        /// <summary>
        /// Indica si el parámetro de la función de visión es una entrada o una salida
        /// </summary>
        public bool EsEntrada
        {
            get { return _EsEntrada; }
            set { _EsEntrada = value; }
        }

        /// <summary>
        /// Indica si se trata de un parámetro fijo o es una variable
        /// </summary>
        private OrigenValorParametro _OrigenValorParametro;
        /// <summary>
        /// Indica si se trata de un parámetro fijo o es una variable
        /// </summary>
        public OrigenValorParametro OrigenValorParametro
        {
            get { return _OrigenValorParametro; }
            set { _OrigenValorParametro = value; }
        }

        /// <summary>
        /// Tipo del parámetro de la función
        /// </summary>
        private OEnumTipoDato _Tipo;
        /// <summary>
        /// Tipo del parámetro de la función
        /// </summary>
        public OEnumTipoDato Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        /// <summary>
        /// Propiedad opcional que indica el código de la variable asociada al parámetro
        /// </summary>
        private string _CodVariable;
        /// <summary>
        /// Propiedad opcional que indica el código de la variable asociada al parámetro
        /// </summary>
        public string CodVariable
        {
            get { return _CodVariable; }
            set { _CodVariable = value; }
        }

        /// <summary>
        /// Propiedad opcional que indica el valor fijo del parámetro
        /// </summary>
        private object _Valor;
        /// <summary>
        /// Propiedad opcional que indica el valor fijo del parámetro
        /// </summary>
        public object Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OParametroFuncionVision(string codFuncionVision, string codParametroFuncionVision)
        {
            // Inicialiamos los valores
            this._Codigo = codParametroFuncionVision;

            // Cargamos valores de la base de datos
            DataTable dtParametro = AppBD.GetParametroFuncionVision(codFuncionVision, this._Codigo);
            if (dtParametro.Rows.Count == 1)
            {
                this._Nombre = dtParametro.Rows[0]["NombreParametroFuncionVision"].ToString();
                this._Descripcion = dtParametro.Rows[0]["DescParametroFuncionVision"].ToString();
                this._CodVariable = dtParametro.Rows[0]["CodVariable"].ToString();
                this._EsEntrada = (bool)dtParametro.Rows[0]["EsEntrada"];
                this._OrigenValorParametro = OEnumerado<OrigenValorParametro>.Validar(dtParametro.Rows[0]["OrigenValorParametro"].ToString(), OrigenValorParametro.ValorPorCodigo);
                //this._OrigenValorParametro = (OOrigenValorParametro)App.EnumParse(typeof(OOrigenValorParametro), dtParametro.Rows[0]["OrigenValorParametro"].ToString(), OOrigenValorParametro.ValorPorCodigo);
                this._Tipo = (OEnumTipoDato)OEntero.Validar(dtParametro.Rows[0]["IdTipoParametroFuncionVision"], 0, 99, 0);

                if (this._OrigenValorParametro == OrigenValorParametro.ValorFijo)
                {
                    switch (this._Tipo)
                    {
                        case OEnumTipoDato.Bit:
                            this._Valor = OBooleano.Validar(dtParametro.Rows[0]["ValorBit"], false);
                            break;
                        case OEnumTipoDato.Entero:
                            this._Valor = OEntero.Validar(dtParametro.Rows[0]["ValorEntero"], int.MinValue, int.MaxValue, 0);
                            break;
                        case OEnumTipoDato.Texto:
                            this._Valor = dtParametro.Rows[0]["ValorTexto"].ToString();
                            break;
                        case OEnumTipoDato.Decimal:
                            this._Valor = ODecimal.Validar(dtParametro.Rows[0]["ValorDecimal"], double.MinValue, double.MaxValue, 0);
                            break;
                    }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Enumerado que identifica a los tipos de funciones de visión
    /// </summary>
    public enum TipoFuncionVision
    {
        /// <summary>
        /// Función propia
        /// </summary>
        Orbita = 1,
        /// <summary>
        /// Función de las librerías VisionPro de Cognex
        /// </summary>
        VisionPro = 2,
        /// <summary>
        /// Función de las librerías de reconocimiento de la matricula de los contenedores
        /// </summary>
        CCR = 3,
        /// <summary>
        /// Función de las librerías de lectura de matrículas de vehículos
        /// </summary>
        LPR = 4
    }

    /// <summary>
    /// Indica el tipo de ejecución que se realizará en la función de visión
    /// </summary>
    public enum TipoEjecucionFuncionVision
    {
        /// <summary>
        /// Ejecución sincrona de la función de visión
        /// </summary>
        EjecucionSincrona = 1,
        /// <summary>
        /// Ejecución de la función de visión en un hilo separado
        /// </summary>
        EjecucionAsincrona = 2,
        /// <summary>
        /// Ejecución multiple de la función de visión
        /// </summary>
        EjecucionEncolada = 3
    }

    /// <summary>
    /// Enumerado que informa sobre el origen del valor de un parámetro
    /// </summary>
    public enum OrigenValorParametro
    {
        /// <summary>
        /// Valor fijado en la base de datos (únicamente válido para las entradas)
        /// </summary>
        ValorFijo = 1,
        /// <summary>
        /// Valor asignado por/a variable (válido tanto para entradas com para salidas)
        /// </summary>
        ValorVariable = 2,
        /// <summary>
        /// Valor asignado por/a código (válido tanto para entradas com para salidas)
        /// </summary>
        ValorPorCodigo = 3
    }

    /// <summary>
    /// Clase que contiene la información referente a la inspección
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TParametros"></typeparam>
    /// <typeparam name="TResultados"></typeparam>
    public class OInfoInspeccion<TImagen, TParametros, TInfo, TResultados>
        where TImagen: OImagen, new()
        where TParametros : new()
        where TInfo : OConvertibleXML, new()
        where TResultados : OConvertibleXML, new()
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen inspeccionada
        /// </summary>
        public TImagen Imagen;
        /// <summary>
        /// Información sobre la inspección
        /// </summary>
        public TInfo Info;
        /// <summary>
        /// Parametros de entarda de la inspección
        /// </summary>
        public TParametros Parametros;
        /// <summary>
        /// Resultados de la inspección
        /// </summary>
        public TResultados Resultados;
        /// <summary>
        /// Lista de información adicional incorporada por el controlador externo
        /// </summary>
        public Dictionary<string, object> InformacionAdicional;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OInfoInspeccion()
        {
            this.Imagen = new TImagen();
            this.Info = new TInfo();
            this.Parametros = new TParametros();
            this.Resultados = new TResultados();
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OInfoInspeccion(TImagen imagen, TParametros parametros, TInfo info, TResultados resultados, Dictionary<string, object> informacionAdicional)
        {
            this.Imagen = imagen;
            this.Info = info;
            this.Parametros = parametros;
            this.Resultados = resultados;
            this.InformacionAdicional = informacionAdicional;
        }
        #endregion
    }

    #region Definición de delegado(s)
    /// <summary>
    /// Parametros de retorno del evento que indica de la llegada de un mensaje actualizacion
    /// </summary>
    public class EventArgsResultadoParcial : EventArgs
    {
        #region Atributo(s)
        /// <summary>
        /// Resultado parcial
        /// </summary>
        public object InfoInspeccion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public EventArgsResultadoParcial()
        {
            this.InfoInspeccion = new object();
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public EventArgsResultadoParcial(object infoInspeccion)
        {
            this.InfoInspeccion = infoInspeccion;
        }
        #endregion
    }

    /// <summary>
    /// Delegado que indica de la llegada de un nuevo resultado parcial
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CallBackResultadoParcial(object sender, EventArgsResultadoParcial e);
    #endregion

    #region Enumerados de tipos de parámetros de entrada o salida
    public class EntradasFuncionesVision : List<OTriplet<string, object, OEnumTipoDato>>
    {
        #region Método(s) público(s)
        /// <summary>
        /// Añade un parámetro de entrada
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="valor"></param>
        /// <param name="tipoVariable"></param>
        public new void Add(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            this.Add(new OTriplet<string, object, OEnumTipoDato>(codigo, valor, tipoVariable));
        }

        /// <summary>
        /// Añade un parámetro de entrada
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="valor"></param>
        /// <param name="tipoVariable"></param>
        public new void Add(EnumTipoEntradaFuncionVision tipoEntrada, object valor, OEnumTipoDato tipoVariable)
        {
            this.Add(new OTriplet<string, object, OEnumTipoDato>(tipoEntrada.Nombre, valor, tipoVariable));
        }
        #endregion
    }

    /// <summary>
    /// Define el conjunto de tipos de entradas de las funciones de visión
    /// </summary>
    public class TipoEntradasFuncionesVision : OEnumeradosHeredable
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen de entrada
        /// </summary>
        public static EnumTipoEntradaFuncionVision Imagen = new EnumTipoEntradaFuncionVision("Imagen", "Imagen de entrada", 1);
        /// <summary>
        /// Parametros de configuración
        /// </summary>
        public static EnumTipoEntradaFuncionVision Parametros = new EnumTipoEntradaFuncionVision("Parametros", "Parametros de configuración", 2);
        #endregion
    }

    /// <summary>
    /// Clase que implementa el enumerado de las entradas de las funciones de visión
    /// </summary>
    public class EnumTipoEntradaFuncionVision : OEnumeradoHeredable
    {
        #region Constructor
        /// <summary>
        /// Constuctor de la clase
        /// </summary>
        public EnumTipoEntradaFuncionVision(string nombre, string descripcion, int valor) :
            base(nombre, descripcion, valor)
        { }
        #endregion
    }

    /// <summary>
    /// Define el conjunto de tipos de salidas de las funciones de visión
    /// </summary>
    public class TipoSalidasFuncionesVision : OEnumeradosHeredable
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen de salida
        /// </summary>
        public static EnumTipoSalidaFuncionVision Imagen = new EnumTipoSalidaFuncionVision("Imagen", "Imagen de salida", 1);
        #endregion
    }

    /// <summary>
    /// Clase que implementa el enumerado de las salidas de las funciones de visión
    /// </summary>
    public class EnumTipoSalidaFuncionVision : OEnumeradoHeredable
    {
        #region Constructor
        /// <summary>
        /// Constuctor de la clase
        /// </summary>
        public EnumTipoSalidaFuncionVision(string nombre, string descripcion, int valor) :
            base(nombre, descripcion, valor)
        { }
        #endregion
    }
    #endregion
}
