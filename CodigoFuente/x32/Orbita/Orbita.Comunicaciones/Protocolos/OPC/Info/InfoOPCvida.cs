//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase para la generación de eventos de bit de vida
    /// </summary>
    public class OInfoOPCvida
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase InfoVida.
        /// </summary>
        /// <param name="contador">Número de elementos.</param>
        /// <param name="enlaces">Descripción del enlace.</param>
        public OInfoOPCvida(int contador, string[] enlaces)
        {
            Variables = new int[contador];
            Valores = new string[contador];
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
        public int[] Variables { get; set; }
        /// <summary>
        /// Colección de valores.
        /// </summary>
        public string[] Valores { get; set; }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Obtener la colección de variables.
        /// </summary>
        /// <returns></returns>
        public int[] GetVariables()
        {
            return Variables;
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
            return Variables[indice];
        }
        /// <summary>
        /// Asignar la colección de variables.
        /// </summary>
        /// <param name="indice">Indice de la colección.</param>
        /// <param name="variable">Variable a almacenar.</param>
        public void SetVariables(int indice, int variable)
        {
            Variables[indice] = variable;
        }
        /// <summary>
        /// Obtener la colección de valores.
        /// </summary>
        /// <returns></returns>
        public string[] GetValores()
        {
            return Valores;
        }
        /// <summary>
        /// Asignar la colección de valores.
        /// </summary>
        public void SetValores(string[] valores)
        {
            Valores = valores;
        }
        #endregion Métodos públicos
    }
}