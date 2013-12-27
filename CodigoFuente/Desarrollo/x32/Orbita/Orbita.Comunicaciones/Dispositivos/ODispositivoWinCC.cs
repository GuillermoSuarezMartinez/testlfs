using System;
using Orbita.Trazabilidad;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo pra comunicar con WinCC. Es necesario que este dispositivo esté en la misma máquina que WinCC.
    /// </summary>
    public class ODispositivoWinCC : ODispositivo
    {
        #region Atributos
        /// <summary>
        /// Objeto para comunicar con WinCC.
        /// </summary>
        private OProtocoloWinCCDataManager _oDataManager;
        /// <summary>
        /// Tipo de variable para escribir.
        /// </summary>
        private Type _mCurVarType;
        /// <summary>
        /// Logger del sistema.
        /// </summary>
        private readonly ILogger _logger;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="logger">Log de la clase</param>
        public ODispositivoWinCC(ILogger logger)
        {
            this._logger = logger;
            _oDataManager = new OProtocoloWinCCDataManager();
            _oDataManager.Connect();
        }
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="logger">Log de la clase</param>
        public ODispositivoWinCC()
        {
            _oDataManager = new OProtocoloWinCCDataManager();
            _oDataManager.Connect();
        }
        #endregion Constructor

        #region Destructor
        /// <summary>
        /// Destruye el objeto
        /// </summary>
        ~ODispositivoWinCC()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }
        #endregion Destructor

        #region Métodos públicos
        /// <summary>
        /// Inicia el dispositivo
        /// </summary>
        public override void Iniciar() { }
        /// <summary>
        /// limpia los objetos en memoria
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called. 
            if (this.Disposed) return;
            // If disposing equals true, dispose all managed 
            // and unmanaged resources. 
            if (disposing) { }
            // Note disposing has been done.
            _oDataManager = null;
            Disposed = true;
        }
        /// <summary>
        /// Leer las variables de WinCC. El método de lectura es variable a variable.
        /// </summary>
        /// <param name="variables">nombre de las variables</param>
        /// <param name="demanda">indica que la llamada al dispositivo se hace de forma inmediata</param>
        /// <returns></returns>
        public override object[] Leer(string[] variables, bool demanda)
        {
            object[] retorno = new object[variables.Length];
            demanda = true;
            if (demanda)
            {
                for (int i = 0; i < retorno.Length; i++)
                {
                    object valor;
                    if (this.Leer(variables[i], out  valor))
                    {
                        retorno[i] = valor;
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Escribe las variables en WinCC. El método de escritura es variable a variable
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores"></param>
        /// <returns></returns>
        public override bool Escribir(string[] variables, object[] valores)
        {
            bool retorno = true;
            for (int i = 0; i < variables.Length; i++)
            {
                if (!this.Escribir(variables[i], valores[i]))
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Escribir el valor de los identificadores de variables de la colección.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal"></param>
        /// <returns></returns>
        public override bool Escribir(string[] variables, object[] valores, string canal)
        {
            return this.Escribir(variables, valores);
        }
        #endregion Métodos públicos

        #region Métodos privados
        /// <summary>
        /// Lee la variable de wincc
        /// </summary>
        /// <param name="variable">Variable que se quiere leer</param>
        /// <param name="valor">Valor leído</param>
        /// <returns>Verdadero si se lee y falso si no se lee</returns>
        private bool Leer(string variable, out object valor)
        {
            bool retorno = false;
            valor = null;
            try
            {
                UInt32 calidad;
                retorno = _oDataManager.GetVarValue(variable, out valor, out calidad);
            }
            catch (Exception ex)
            {
                if (this._logger!=null)
                {
                    this._logger.Fatal("Error al leer: ", ex);
                }
                
            }
            return retorno;
        }
        /// <summary>
        /// Escribe en la variable de wincc
        /// </summary>
        /// <param name="variable">Variable que se quiere escribir</param>
        /// <param name="valor">Valor que se quiere escribir</param>
        /// <returns>Verdadero si se escribe y falso si no se escribe</returns>
        private bool Escribir(string variable, object valor)
        {
            bool retorno = false;
            try
            {
                _mCurVarType = valor.GetType();
                Object objNewValue = Convert.ChangeType(valor, _mCurVarType);
                retorno = _oDataManager.SetVarValue(variable, objNewValue);
            }
            catch (Exception ex)
            {
                if (this._logger != null)
                {
                    this._logger.Fatal("Error al escribir: ", ex);
                }
            }
            return retorno;
        }
        #endregion Métodos privados
    }
}