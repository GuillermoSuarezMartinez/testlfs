//***********************************************************************
// Assembly         : Orbita.Trazabilidad
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
    /// Contiene datos de eventos relativos a escritura en logger más argumentos.
    /// </summary>
    public class LoggerArgsEventArgs : LoggerEventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Argumentos adicionales que puede contener el item, además del mensaje propiamente dicho.
        /// </summary>
        object[] args;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        public LoggerArgsEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        public LoggerArgsEventArgs(ItemLog item)
            : base(item) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.LoggerEventArgs.
        /// </summary>
        /// <param name="item">Item de entrada.</param>
        /// <param name="excepcion">Excepción.</param>
        public LoggerArgsEventArgs(ItemLog item, System.Exception excepcion)
            : base(item, excepcion) { }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtener argumentos adicionales que puede contener el item, además del mensaje propiamente dicho.
        /// </summary>
        /// <returns>Colección de object.</returns>
        public object[] GetArgumentos()
        {
            return this.args;
        }
        /// <summary>
        /// Asignar argumentos adicionales que puede contener el item, además del mensaje propiamente dicho.
        /// </summary>
        public void SetArgumentos(object[] argumentos)
        {
            this.args = argumentos;
        }
        #endregion
    }
}