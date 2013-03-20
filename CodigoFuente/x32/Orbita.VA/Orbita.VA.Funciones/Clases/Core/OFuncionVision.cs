//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Clase de acceso est�tico que contiene la lista de funciones de visi�n
    /// </summary>
    public static class OFuncionesVisionManager
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de funciones de visi�n funcionando en el sistema
        /// </summary>
        private static List<OFuncionVisionBase> ListaFuncionesVision;

        #endregion

        #region M�todo(s) p�blico(s)

        /// <summary>
        /// Construye los objetos
        /// </summary>
        public static void Constructor()
        {
            // Construyo la lista de funciones de visi�n
            ListaFuncionesVision = new List<OFuncionVisionBase>();

            // Consulta a la base de datos
            DataTable dt = AppBD.GetFuncionesVision();
            if (dt.Rows.Count > 0)
            {
                // Cargamos todas las funciones de visi�n existentes en el sistema
                foreach (DataRow dr in dt.Rows)
                {
                    string codFuncionVision = dr["CodFuncionVision"].ToString();
                    string ensambladoClaseImplementadora = dr["EnsambladoClaseImplementadora"].ToString();
                    string claseImplementadora = string.Format("{0}.{1}", ensambladoClaseImplementadora, dr["ClaseImplementadora"].ToString());

                    object objetoImplementado;
                    if (App.ConstruirClase(ensambladoClaseImplementadora, claseImplementadora, out objetoImplementado, codFuncionVision))
                    {
                        OFuncionVisionBase funcionVision = (OFuncionVisionBase)objetoImplementado;
                        ListaFuncionesVision.Add(funcionVision);
                    }
                }
            }
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        public static void Destructor()
        {
            // Destruyo la lista de m�quinas de estados
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
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                visionFunction.Inicializar();
            }
        }

        /// <summary>
        /// Finaliza la ejecuci�n
        /// </summary>
        public static void Finalizar()
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                visionFunction.Finalizar();
            }
        }

        /// <summary>
        /// Inicia la ejecuci�n de determinada funci�n de visi�n.
        /// Se debe ejecutar a esta funci�n desde el hilo principal de la aplicaci�n, de lo contrario ocurrir�n excepciones.
        /// </summary>
        public static void IniciarEjecucion(string codFuncionVision)
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                if (visionFunction.Codigo == codFuncionVision)
                {
                    visionFunction.IniciarEjecucion();
                }
            }
        }

        /// <summary>
        /// Inicia la ejecuci�n de determinada funci�n de visi�n de forma s�ncrona
        /// Se debe ejecutar a esta funci�n desde el hilo principal de la aplicaci�n, de lo contrario ocurrir�n excepciones.
        /// </summary>
        public static void IniciarEjecucionSincrona(string codFuncionVision)
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                if (visionFunction.Codigo == codFuncionVision)
                {
                    visionFunction.IniciarEjecucionSincrona();
                }
            }
        }

        /// <summary>
        /// Inicia la ejecuci�n de determinada funci�n de visi�n de forma as�ncrona
        /// Se debe ejecutar a esta funci�n desde el hilo principal de la aplicaci�n, de lo contrario ocurrir�n excepciones.
        /// </summary>
        /// 
        public static void IniciarEjecucionAsincrona(string codFuncionVision)
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                if (visionFunction.Codigo == codFuncionVision)
                {
                    visionFunction.IniciarEjecucionAsincrona();
                }
            }
        }

        /// <summary>
        /// Funci�n para la actualizaci�n de par�metros de entrada
        /// </summary>
        /// <param name="codFuncionVision">C�digo identificador de la funci�n de vision</param>
        /// <param name="codPieza">C�digo identificador de la pieza</param>
        /// <param name="codParametro">C�digo identificador del par�metro</param>
        /// <param name="valor">Nuevo valor del par�metro</param>
        /// <param name="tipoVariable">Tipo del par�metro</param>
        /// <returns>Verdadero si la funci�n se ha ejecutado correctamente</returns>
        public static bool SetEntrada(string codFuncionVision, string codParametro, object valor, OEnumTipoDato tipoVariable)
        {
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                if (visionFunction.Codigo == codFuncionVision)
                {
                    return visionFunction.SetEntrada(codParametro, valor, tipoVariable);
                }
            }
            return false;
        }

        /// <summary>
        /// Funci�n para la consulta de par�metros de salida
        /// </summary>
        /// <param name="codFuncionVision">C�digo identificador de la funci�n de vision</param>
        /// <param name="codPieza">C�digo identificador de la pieza</param>
        /// <param name="codParametro">C�digo identificador del par�metro</param>
        /// <param name="valor">Valor del par�metro devuelto por la funci�n</param>
        /// <param name="tipoVariable">Tipo del par�metro</param>
        /// <returns>Verdadero si la funci�n se ha ejecutado correctamente</returns>
        public static bool GetSalida(string codFuncionVision, string codParametro, out object valor, OEnumTipoDato tipoVariable)
        {
            valor = null;
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                if (visionFunction.Codigo == codFuncionVision)
                {
                    return visionFunction.GetSalida(codParametro, out valor, tipoVariable);
                }
            }
            return false;
        }

        /// <summary>
        /// Funci�n para la consulta de par�metros de salida
        /// </summary>
        /// <param name="listaSalidas">Lista de objetos que respresentan el conjunto de salidas de la funci�n de visi�n</param>
        /// <returns></returns>
        public static bool GetSalidas(string codFuncionVision, out Dictionary<string, object> listaSalidas)
        {
            listaSalidas = null;
            foreach (OFuncionVisionBase visionFunction in ListaFuncionesVision)
            {
                if (visionFunction.Codigo == codFuncionVision)
                {
                    return visionFunction.GetSalidas(out listaSalidas);
                }
            }
            return false;
        }

        /// <summary>
        /// Obtiene la funci�n de visi�n mediante las claves
        /// </summary>
        /// <returns></returns>
        public static OFuncionVisionBase GetFuncionVision(OClaves claves)
        {
            OFuncionVisionBase resultado = null;

            foreach (OFuncionVisionBase funcionVision in ListaFuncionesVision)
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
        /// Obtiene el c�digo de la funci�n de visi�n mediante las claves
        /// </summary>
        /// <returns></returns>
        public static string GetCodigoFuncionVision(OClaves claves)
        {
            string resultado = string.Empty;

            foreach (OFuncionVisionBase funcionVision in ListaFuncionesVision)
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
    /// Clase base para todas las funciones de visi�n
    /// </summary>
    public class OFuncionVisionBase
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de entradas de la funcion
        /// </summary>
        public List<OParametroFuncionVision> ListaParametrosEntrada;

        /// <summary>
        /// Lista de salidas de la funci�n
        /// </summary>
        public List<OParametroFuncionVision> ListaParametrosSalida;

        /// <summary>
        /// Informa del estado de la ejecuci�n
        /// </summary>
        public bool EjecucionTerminada;

        /// <summary>
        /// Claves de la funci�n de visi�n
        /// </summary>
        public OClaves Claves;
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
        /// C�digo identificativo de la funci�n
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// C�digo identificativo de la funci�n
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nombre identificativo de la funci�n
        /// </summary>
        private string _Nombre;
        /// <summary>
        /// Nombre identificativo de la funci�n
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        /// Descripci�n de la funci�n
        /// </summary>
        private string _Descripcion;
        /// <summary>
        /// Descripci�n de la funci�n
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        /// Indica que la funci�n ha sido cargada correctamente
        /// </summary>
        private bool _Valido;
        /// <summary>
        /// Indica que la funci�n ha sido cargada correctamente
        /// </summary>
        public bool Valido
        {
            get { return _Valido; }
            set { _Valido = value; }
        }

        /// <summary>
        /// Tipo de funci�n de visi�n
        /// </summary>
        private TipoFuncionVision _TipoFuncionVision;
        /// <summary>
        /// Tipo de funci�n de visi�n
        /// </summary>
        public TipoFuncionVision TipoFuncionVision
        {
            get { return _TipoFuncionVision; }
            set { _TipoFuncionVision = value; }
        }

        /// <summary>
        /// Indica si la ejecuci�n se realiza por defecto en el mismo hilo de ejecuci�n que la
        /// applicaci�n principal o en un hijo de ejecuci�n distinto
        /// </summary>
        private TipoEjecucionFuncionVision _TipoEjecucionFuncionVision;
        /// <summary>
        /// Indica si la ejecuci�n se realiza por defecto en el mismo hilo de ejecuci�n que la
        /// applicaci�n principal o en un hijo de ejecuci�n distinto
        /// </summary>
        public TipoEjecucionFuncionVision TipoEjecucionFuncionVision
        {
            get { return _TipoEjecucionFuncionVision; }
            set { _TipoEjecucionFuncionVision = value; }
        }

        /// <summary>
        /// C�digo identificativo de la variable que se activa
        /// </summary>
        private string _CodVariableEnEjecucion;
        /// <summary>
        /// C�digo identificativo de la funci�n
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

                // Cargamos el c�digo de las variables de entrada que se utilizan en la funcion
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

                // Cargamos el c�digo de las variables de salida que se utilizan en la funcion
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

                // Creaci�n del cron�metro
                OCronometrosManager.NuevoCronometro(this._Codigo, "Ejecuci�n funci�n " + this.Nombre, "Ejecuci�n de la funci�n de visi�n " + this.Nombre);
            }
        }

        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Llamada a la ejecuci�n de la funci�n
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
        /// Llamada a la ejecuci�n de la funci�n de forma s�ncrona
        /// </summary>
        internal void IniciarEjecucionSincrona()
        {
            if (this._Valido)
            {
                // Cronometramos la duraci�n de la ejecuci�n
                OCronometrosManager.Start(this._Codigo);

                // Guardamos la traza
                OVALogsManager.Info(ModulosFunciones.Vision, this._Codigo, "Inicio de la ejecuci�n s�ncrona de la funci�n " + this._Codigo);

                this.EjecucionTerminada = false;

                // Llamada a la variable que indica el estado de ejecuci�n de la funci�n
                OVariablesManager.SetValue(this._CodVariableEnEjecucion, true, "Vision", this.Codigo);

                this.SetEntradasVariables();
                this.EjecucionSincrona();
            }
        }

        /// <summary>
        /// Llamada a la ejecuci�n de la funci�n de forma as�ncrona
        /// </summary>
        internal void IniciarEjecucionAsincrona()
        {
            if (this._Valido)
            {
                // Cronometramos la duraci�n de la ejecuci�n
                OCronometrosManager.Start(this._Codigo);

                // Guardamos la traza
                OVALogsManager.Info(ModulosFunciones.Vision, this._Codigo, "Inicio de la ejecuci�n as�ncrona de la funci�n " + this._Codigo);

                this.EjecucionTerminada = false;

                // Llamada a la variable que indica el estado de ejecuci�n de la funci�n
                OVariablesManager.SetValue(this._CodVariableEnEjecucion, true, "Vision", this.Codigo);

                this.SetEntradasVariables();
                this.EjecucionAsincrona();
            }
        }

        /// <summary>
        /// Funci�n para la consulta de par�metros de salida
        /// </summary>
        /// <param name="listaSalidas">Lista de objetos que respresentan el conjunto de salidas de la funci�n de visi�n</param>
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

        #region M�todo(s) privado(s)
        /// <summary>
        /// M�todo donde se cargan las entradas a la funci�n de visi�n
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
        /// M�todo donde se cargan las entradas a la funci�n de visi�n
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
        /// M�todo donde se leen las salidas de la funci�n de visi�n
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

        #region M�todo(s) virtual(es)

        /// <summary>
        /// M�todo a heredar donde se carga el fichero de la funci�n de visi�n
        /// </summary>
        public virtual void Inicializar()
        {
            if (this.Valido)
            {
                this.SetEntradasFijas();
            }
        }

        /// <summary>
        /// M�todo a heredar donde se descarga el fichero de la funci�n de visi�n
        /// </summary>
        public virtual void Finalizar()
        {
            this._Valido = false;
        }

        /// <summary>
        /// Metodo virtual donde se ejecuta la funci�n de visi�n de forma s�ncrona
        /// </summary>
        /// <returns></returns>
        protected virtual bool EjecucionSincrona()
        {
            return false;
        }

        /// <summary>
        /// Metodo virtual donde se ejecuta la funci�n de visi�n de forma as�ncrona
        /// </summary>
        /// <returns></returns>
        protected virtual bool EjecucionAsincrona()
        {
            return false;
        }

        /// <summary>
        /// Funci�n para la actualizaci�n de par�metros de entrada
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool SetEntrada(string codigo, object valor, OEnumTipoDato tipoVariable)
        {
            return false;
        }

        /// <summary>
        /// Funci�n para la actualizaci�n de par�metros de entrada
        /// </summary>
        /// <param name="entrada">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool SetEntrada(EnumEntradaFuncionVision entrada, object valor, OEnumTipoDato tipoVariable)
        {
            return false;
        }

        /// <summary>
        /// Funci�n para la consulta de par�metros de salida
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool GetSalida(string codigo, out object valor, OEnumTipoDato tipoVariable)
        {
            valor = null;
            return false;
        }

        /// <summary>
        /// Funci�n para la consulta de par�metros de salida
        /// </summary>
        /// <param name="ParamName">Nombre identificador del par�metro</param>
        /// <param name="ParamValue">Nuevo valor del par�metro</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual bool GetSalida(EnumSalidaFuncionVision salida, out object valor, OEnumTipoDato tipoVariable)
        {
            valor = null;
            return false;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento que se ejecuta cuando finaliza la ejecuci�n de la funci�n
        /// </summary>
        /// <param name="sender">Objeto que env�a el evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void FuncionEjecutada()
        {
            try
            {
                this.GetSalidasVariables();

                // Paramos el cronometro de la duraci�n de la ejecuci�n
                OCronometrosManager.Stop(this._Codigo);

                // Guardamos la traza
                OVALogsManager.Info(ModulosFunciones.Vision, this._Codigo, "Fin de la ejecuci�n de la funci�n " + this._Codigo + ". Duraci�n: " + OCronometrosManager.DuracionUltimaEjecucion(this._Codigo).ToString());

                // Llamada a la variable que indica el estado de ejecuci�n de la funci�n
                OVariablesManager.SetValue(this._CodVariableEnEjecucion, false, "Vision", this.Codigo);

                this.EjecucionTerminada = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.Vision, this._Codigo, exception);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase base para todas las funciones de visi�n
    /// </summary>
    public class OFuncionVisionEncolada : OFuncionVisionBase
    {
        #region Atributo(s)
        /// <summary>
        /// Cola donde iremos almacenando los resultados parciales
        /// </summary>
        public Queue<object> ResultadosParciales;

        /// <summary>
        /// Contador de im�genes
        /// </summary>
        public int ContInspeccionesEnCola;

        /// <summary>
        /// Indice de la �ltima fotograf�a a�adida a la cola de proceso
        /// </summary>
        public int IndiceFotografia;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica que la funci�n ha de dejar de ejecutarse si se encuentra en ejecuci�n contin�a
        /// </summary>
        private bool _Abortar;
        /// <summary>
        /// Indica que la funci�n ha de dejar de ejecutarse si se encuentra en ejecuci�n contin�a
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

        #region M�todo(s) heredado(s)
        /// <summary>
        /// Inicializa la configuraci�n del LPR
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();

            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;
        }

        /// <summary>
        /// M�todo a heredar donde se descarga el fichero de la funci�n de visi�n
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();
        }
        #endregion

        #region M�todo(s) p�blico(s)
        /// <summary>
        /// Llamada a la ejecuci�n de la funci�n
        /// </summary>
        public new void IniciarEjecucion()
        {
            this.IniciarEjecucionEncolada();
        }

        /// <summary>
        /// Llamada a la ejecuci�n de la funci�n de forma encolada
        /// </summary>
        internal void IniciarEjecucionEncolada()
        {
            if (this.Valido)
            {
                // Cronometramos la duraci�n de la ejecuci�n
                OCronometrosManager.Start(this.Codigo);

                // Guardamos la traza
                OVALogsManager.Info(ModulosFunciones.Vision, this.Codigo, "Inicio de la ejecuci�n encolada de la funci�n " + this.Codigo);

                this.EjecucionTerminada = false;

                // Llamada a la variable que indica el estado de ejecuci�n de la funci�n
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

        #region M�todo(s) virtual(es)
        /// <summary>
        /// Indica que hay inspecciones pendientes de ejecuci�n
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
        internal virtual void A�adirResultadoParcial(object sender, EventArgsResultadoParcial e)
        {
            try
            {
                this.ContInspeccionesEnCola--;

                // Evento de llegada de resultado parcial
                if (this.OnResultadoParcial != null)
                {
                    this.OnResultadoParcial(sender, e);
                }

                // Se realizan las acciones de fin de inspecci�n
                this.ResultadosParciales.Enqueue(e.InfoInspeccion);
                if (!this.HayInspeccionesPendientes())
                {
                    this.FuncionEjecutada();
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosFunciones.Vision, this.Codigo, exception);
            }
        }

        /// <summary>
        /// Resetea la cola de ejecuci�n
        /// </summary>
        public virtual void ResetearColaEjecucion()
        {
            this.ResultadosParciales.Clear();
            this.ContInspeccionesEnCola = 0;
            this.IndiceFotografia = 0;
        }

        /// <summary>
        /// Metodo virtual donde se ejecuta la funci�n de visi�n de forma encolada
        /// </summary>
        /// <returns></returns>
        protected virtual bool EjecucionEncolada()
        {
            return false;
            // Ejecutado en heredados
        }        
        #endregion

        #region Definici�n de delegado(s)
        /// <summary>
        /// CallBack donde mandar el resultado parcial
        /// </summary>
        public CallBackResultadoParcial OnResultadoParcial;

        #endregion
    }

    /// <summary>
    /// Clase que representa a un par�metro de entrada o de salida de una funci�n de visi�n
    /// </summary>
    public class OParametroFuncionVision
    {
        #region Propiedad(es)
        /// <summary>
        /// C�digo identificativo del par�metro
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// C�digo identificativo del par�metro
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        /// <summary>
        /// Nombre identificativo del par�metro
        /// </summary>
        private string _Nombre;
        /// <summary>
        /// Nombre identificativo del par�metro
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        /// Descripci�n del par�metro
        /// </summary>
        private string _Descripcion;
        /// <summary>
        /// Descripci�n del par�metro
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        /// Indica si el par�metro de la funci�n de visi�n es una entrada o una salida
        /// </summary>
        private bool _EsEntrada;
        /// <summary>
        /// Indica si el par�metro de la funci�n de visi�n es una entrada o una salida
        /// </summary>
        public bool EsEntrada
        {
            get { return _EsEntrada; }
            set { _EsEntrada = value; }
        }

        /// <summary>
        /// Indica si se trata de un par�metro fijo o es una variable
        /// </summary>
        private OrigenValorParametro _OrigenValorParametro;
        /// <summary>
        /// Indica si se trata de un par�metro fijo o es una variable
        /// </summary>
        public OrigenValorParametro OrigenValorParametro
        {
            get { return _OrigenValorParametro; }
            set { _OrigenValorParametro = value; }
        }

        /// <summary>
        /// Tipo del par�metro de la funci�n
        /// </summary>
        private OEnumTipoDato _Tipo;
        /// <summary>
        /// Tipo del par�metro de la funci�n
        /// </summary>
        public OEnumTipoDato Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        /// <summary>
        /// Propiedad opcional que indica el c�digo de la variable asociada al par�metro
        /// </summary>
        private string _CodVariable;
        /// <summary>
        /// Propiedad opcional que indica el c�digo de la variable asociada al par�metro
        /// </summary>
        public string CodVariable
        {
            get { return _CodVariable; }
            set { _CodVariable = value; }
        }

        /// <summary>
        /// Propiedad opcional que indica el valor fijo del par�metro
        /// </summary>
        private object _Valor;
        /// <summary>
        /// Propiedad opcional que indica el valor fijo del par�metro
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
    /// Enumerado que identifica a los tipos de funciones de visi�n
    /// </summary>
    public enum TipoFuncionVision
    {
        /// <summary>
        /// Funci�n propia
        /// </summary>
        Orbita = 1,
        /// <summary>
        /// Funci�n de las librer�as VisionPro de Cognex
        /// </summary>
        VisionPro = 2,
        /// <summary>
        /// Funci�n de las librer�as de reconocimiento de la matricula de los contenedores
        /// </summary>
        OCRContainer = 3,
        /// <summary>
        /// Funci�n de las librer�as de lectura de matr�culas de veh�culos
        /// </summary>
        LPR = 4
    }

    /// <summary>
    /// Indica el tipo de ejecuci�n que se realizar� en la funci�n de visi�n
    /// </summary>
    public enum TipoEjecucionFuncionVision
    {
        /// <summary>
        /// Ejecuci�n sincrona de la funci�n de visi�n
        /// </summary>
        EjecucionSincrona = 1,
        /// <summary>
        /// Ejecuci�n de la funci�n de visi�n en un hilo separado
        /// </summary>
        EjecucionAsincrona = 2,
        /// <summary>
        /// Ejecuci�n multiple de la funci�n de visi�n
        /// </summary>
        EjecucionEncolada = 3
    }

    /// <summary>
    /// Enumerado que informa sobre el origen del valor de un par�metro
    /// </summary>
    public enum OrigenValorParametro
    {
        /// <summary>
        /// Valor fijado en la base de datos (�nicamente v�lido para las entradas)
        /// </summary>
        ValorFijo = 1,
        /// <summary>
        /// Valor asignado por/a variable (v�lido tanto para entradas com para salidas)
        /// </summary>
        ValorVariable = 2,
        /// <summary>
        /// Valor asignado por/a c�digo (v�lido tanto para entradas com para salidas)
        /// </summary>
        ValorPorCodigo = 3
    }

    /// <summary>
    /// Clase que contiene la informaci�n referente a la inspecci�n
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TParametros"></typeparam>
    /// <typeparam name="TResultados"></typeparam>
    public class OInfoInspeccion<TImagen, TInfo, TParametros, TResultados>
        where TImagen: OImagen, new()
        where TInfo : new()
        where TParametros : new()
        where TResultados : new()
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen inspeccionada
        /// </summary>
        public TImagen Imagen;
        /// <summary>
        /// Informaci�n sobre la inspecci�n
        /// </summary>
        public TInfo Info;
        /// <summary>
        /// Parametros de entarda de la inspecci�n
        /// </summary>
        public TParametros Parametros;
        /// <summary>
        /// Resultados de la inspecci�n
        /// </summary>
        public TResultados Resultados;
        /// <summary>
        /// Lista de informaci�n adicional incorporada por el controlador externo
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
        public OInfoInspeccion(TImagen imagen, TInfo info, TParametros parametros, TResultados resultados, Dictionary<string, object> informacionAdicional)
        {
            this.Imagen = imagen;
            this.Info = info;
            this.Parametros = parametros;
            this.Resultados = resultados;
            this.InformacionAdicional = informacionAdicional;
        }
        #endregion
    }

    #region Definici�n de delegado(s)
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

    #region Enumerados de Tipos de Entrada o Salida
    /// <summary>
    /// Define el conjunto de tipos de entradas de las funciones de visi�n
    /// </summary>
    public class EntradasFuncionesVision : OEnumeradosHeredable
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen de entrada
        /// </summary>
        public static EnumEntradaFuncionVision Imagen = new EnumEntradaFuncionVision("Imagen", "Imagen de entrada", 1);
        #endregion
    }

    /// <summary>
    /// Clase que implementa el enumerado de las entradas de las funciones de visi�n
    /// </summary>
    public class EnumEntradaFuncionVision : OEnumeradoHeredable
    {
        #region Constructor
        /// <summary>
        /// Constuctor de la clase
        /// </summary>
        public EnumEntradaFuncionVision(string nombre, string descripcion, int valor) :
            base(nombre, descripcion, valor)
        { }
        #endregion
    }

    /// <summary>
    /// Define el conjunto de tipos de salidas de las funciones de visi�n
    /// </summary>
    public class SalidasFuncionesVision : OEnumeradosHeredable
    {
        #region Atributo(s)
        /// <summary>
        /// Imagen de salida
        /// </summary>
        public static EnumSalidaFuncionVision Imagen = new EnumSalidaFuncionVision("Imagen", "Imagen de salida", 1);
        #endregion
    }

    /// <summary>
    /// Clase que implementa el enumerado de las salidas de las funciones de visi�n
    /// </summary>
    public class EnumSalidaFuncionVision : OEnumeradoHeredable
    {
        #region Constructor
        /// <summary>
        /// Constuctor de la clase
        /// </summary>
        public EnumSalidaFuncionVision(string nombre, string descripcion, int valor) :
            base(nombre, descripcion, valor)
        { }
        #endregion
    }
    #endregion
}
