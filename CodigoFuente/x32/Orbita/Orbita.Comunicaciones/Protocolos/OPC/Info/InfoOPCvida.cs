//***********************************************************************
// Assembly         : OrbitaComunicaciones
// Author           : crodriguez
// Created          : 03-11-2011
//
// Last Modified By : crodriguez
// Last Modified On : 03-14-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase para la generación de eventos de bit de vida
    /// </summary>
    public class OInfoOPCvida
    {
        #region Atributos
        /// <summary>
        /// Identificador de variables.
        /// </summary>
        private int[] _variables;
        /// <summary>
        /// Valor de las variables.
        /// </summary>
        private string[] _valores;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoVida.
        /// </summary>
        /// <param name="contador">Número de elementos.</param>
        /// <param name="enlaces">Descripción del enlace.</param>
        public OInfoOPCvida(int contador, string[] enlaces)
        {
            _variables = new int[contador];
            _valores = new string[contador];
            Enlaces = enlaces;
        }
        #endregion Constructor

        #region Propiedades
        /// <summary>
        /// Enlace de conexión.
        /// </summary>
        public string[] Enlaces { get; set; }
        /// <summary>
        /// Colección de variables.
        /// </summary>
        public int[] Variables
        {
            get { return _variables; }
            set { _variables = value; }
        }
        /// <summary>
        /// Colección de valores.
        /// </summary>
        public string[] Valores
        {
            get { return _valores; }
            set { _valores = value; }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Obtener la colección de variables.
        /// </summary>
        /// <returns></returns>
        public int[] GetVariables()
        {
            return _variables;
        }
        /// <summary>
        /// Obtener el elemento i-esimo de la
        /// colección de variables.
        /// </summary>
        /// <param name="indice">Indice de la
        /// colección de variables.</param>
        /// <returns>El objeto de la colección.</returns>
        public object GetVariables(int indice)
        {
            return _variables[indice];
        }
        /// <summary>
        /// Asignar la colección de variables.
        /// </summary>
        /// <param name="indice">Indice de la colección.</param>
        /// <param name="variable">Variable a almacenar.</param>
        public void SetVariables(int indice, int variable)
        {
            _variables[indice] = variable;
        }
        /// <summary>
        /// Obtener la colección de valores.
        /// </summary>
        /// <returns></returns>
        public string[] GetValores()
        {
            return _valores;
        }
        /// <summary>
        /// Asignar la colección de valores.
        /// </summary>
        public void SetValores(string[] valores)
        {
            _valores = valores;
        }
        #endregion Métodos públicos
    }
}