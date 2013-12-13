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
    /// Información del control de usuario incluido en el plugin.
    /// </summary>
    public struct ControlInfo
    {
        #region Atributos
        /// <summary>
        /// Valor del control.
        /// </summary>
        private string valor;
        /// <summary>
        /// Tipo de control { tooltip, text, message }.
        /// </summary>
        private string tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// Valor del control.
        /// </summary>
        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }
        /// <summary>
        /// Tipo de control { tooltip, text, message }.
        /// </summary>
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Sobreescritura del método Equals.
        /// </summary>
        /// <param name="obj">Objeto de comparación.</param>
        /// <returns>Si la instancia y el objeto son iguales.</returns>
        public override bool Equals(System.Object obj)
        {
            return false;
        }
        /// <summary>
        /// Sobreescritura del método GetHashCode.
        /// </summary>
        /// <returns>El código Hash de esta instancia.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Operador de igualdad.
        /// </summary>
        /// <param name="info">Información del control.</param>
        /// <param name="cadena">Cadena de comparación.</param>
        /// <returns>La igualdad de la cadena de comparación con el tipo.</returns>
        public static bool operator ==(ControlInfo info, string cadena)
        {
            return info.Equals(cadena);
        }
        /// <summary>
        /// Operador de desigualdad.
        /// </summary>
        /// <param name="info">Información del control.</param>
        /// <param name="cadena">Cadena de comparación.</param>
        /// <returns>La desigualdad de la cadena de comparación con el tipo.</returns>
        public static bool operator !=(ControlInfo info, string cadena)
        {
            return !info.Equals(cadena);
        }
        #endregion
    }
}