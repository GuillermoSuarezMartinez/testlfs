//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
// Author           : jljuan
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
    /// Clase base para el login de usuarios.
    /// </summary>
    public abstract class OLogOn
    {
        #region Atributos internos
        internal string dominio;
        internal string usuario;
        internal string password;
        #endregion

        #region Métodos virtuales
        /// <summary>
        /// Clase base de validación.
        /// </summary>
        /// <returns>Mensaje de validación de argumento Orbita.Controles.Autenticacion.OEstadoValidacion.</returns>
        public abstract AutenticacionChangedEventArgs Validar();
        #endregion
    }
}