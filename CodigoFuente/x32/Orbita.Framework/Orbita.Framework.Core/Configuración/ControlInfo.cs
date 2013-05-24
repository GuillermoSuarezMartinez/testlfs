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
    public struct ControlInfo
    {
        #region Atributos
        string valor;
        string tipo;
        #endregion

        #region Propiedades
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
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
        /// <param name="info">Estado de tipo contenedor.</param>
        /// <param name="cadena">Cadena de comparación.</param>
        /// <returns>La igualdad de la cadena de comparación con el tipo.</returns>
        public static bool operator ==(ControlInfo info, string cadena)
        {
            return info.Equals(cadena);
        }
        /// <summary>
        /// Operador de desigualdad.
        /// </summary>
        /// <param name="info">Estado de tipo contenedor.</param>
        /// <param name="cadena">Cadena de comparación.</param>
        /// <returns>La desigualdad de la cadena de comparación con el tipo.</returns>
        public static bool operator !=(ControlInfo info, string cadena)
        {
            return !info.Equals(cadena);
        }
        #endregion
    }
}