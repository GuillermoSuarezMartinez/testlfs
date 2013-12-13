//***********************************************************************
// Assembly         : Orbita.Framework.Core
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Proporciona datos para los eventos WaitWindow.
    /// </summary>
    public class WaitWindowEventArgs : System.EventArgs
    {
        #region Atributos
        /// <summary>
        /// Acceso a los métodos de la clase Orbita.Framework.Core.WaitWindow.
        /// </summary>
        private WaitWindow ventanaEspera;
        /// <summary>
        /// Colección de argumentos.
        /// </summary>
        private System.Collections.Generic.IList<object> args;
        /// <summary>
        /// Resultado del método de ejecución.
        /// </summary>
        private object resultado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.WaitWindowEventArgs.
        /// </summary>
        /// <param name="GUI">Instancia Orbita.Framework.Core.WaitWindow asociada.</param>
        /// <param name="args">Lista de argumentos.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Naming violations are too many right now")]
        public WaitWindowEventArgs(WaitWindow GUI, System.Collections.Generic.IList<object> args)
            : base()
        {
            this.ventanaEspera = GUI;
            this.args = args;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Acceso a los métodos de la clase Orbita.Framework.Core.WaitWindow.
        /// </summary>
        public WaitWindow Window
        {
            get { return this.ventanaEspera; }
        }
        /// <summary>
        /// Colección de argumentos.
        /// </summary>
        public System.Collections.Generic.IList<object> Argumentos
        {
            get { return this.args; }
        }
        /// <summary>
        /// Resultado del método de ejecución.
        /// </summary>
        public object Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
        #endregion
    }
}