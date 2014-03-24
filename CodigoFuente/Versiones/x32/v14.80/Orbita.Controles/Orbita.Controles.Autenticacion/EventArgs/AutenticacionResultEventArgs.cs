//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Argumentos de resultado de autenticación.
    /// </summary>
    public class AutenticacionResultEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Resultado del formulario de autenticación.
        /// </summary>
        private System.Windows.Forms.DialogResult resultado;
        /// <summary>
        /// Usuario validado.
        /// </summary>
        private string usuario;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.AutenticacionResultEventArgs.
        /// </summary>
        public AutenticacionResultEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.AutenticacionResultEventArgs.
        /// </summary>
        /// <param name="resultado">Resultado del formulario de autenticación.</param>
        public AutenticacionResultEventArgs(System.Windows.Forms.DialogResult resultado)
            : this()
        {
            this.resultado = resultado;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Resultado del formulario de autenticación.
        /// </summary>
        public System.Windows.Forms.DialogResult Resultado
        {
            get { return this.resultado; }
        }
        /// <summary>
        /// Usuario validado.
        /// </summary>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        #endregion
    }
}