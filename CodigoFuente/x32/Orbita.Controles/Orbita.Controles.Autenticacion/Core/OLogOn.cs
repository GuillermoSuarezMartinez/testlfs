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
    public abstract class OLogon
    {
        #region Atributos internos
        internal string dominio;
        internal string usuario;
        internal string password;
        #endregion

        #region Métodos virtuales
        /// <summary>
        /// Método abstracto de validación.
        /// </summary>
        /// <returns>Mensaje de validación de argumento Orbita.Controles.Autenticacion.EstadoAutenticacion.</returns>
        public abstract EstadoAutenticacion Validar();
        #endregion
    }
}