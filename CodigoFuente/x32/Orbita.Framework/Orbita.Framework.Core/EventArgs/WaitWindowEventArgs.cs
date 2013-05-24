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
        WaitWindow window;
        System.Collections.Generic.List<object> args;
        object resultado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.WaitWindowEventArgs.
        /// </summary>
        /// <param name="GUI">La instancia Orbita.Framework.Core.WaitWindow asociada.</param>
        /// <param name="args">La lista de argumentos.</param>
        public WaitWindowEventArgs(WaitWindow GUI, System.Collections.Generic.List<object> args)
            : base()
        {
            this.window = GUI;
            this.args = args;
        }
        #endregion

        #region Propiedades
        public WaitWindow Window
        {
            get { return this.window; }
        }
        public System.Collections.Generic.List<object> Argumentos
        {
            get { return this.args; }
        }
        public object Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
        #endregion
    }
}