//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Contiene datos de eventos relativos a escritura en logger.
    /// </summary>
    public class LoggerEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Cadena de entrada a escribir en logger.
        /// </summary>
        string cadena;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        public LoggerEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        /// <param name="cadena">Cadena de entrada a escribir en logger.</param>
        public LoggerEventArgs(string cadena)
            : this()
        {
            this.cadena = cadena;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Cadena de entrada a escribir en logger.
        /// </summary>
        public string Cadena
        {
            get { return this.cadena; }
        }
        #endregion
    }
}
