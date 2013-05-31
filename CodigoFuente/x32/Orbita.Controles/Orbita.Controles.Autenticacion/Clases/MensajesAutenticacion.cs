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
    /// Mensajes internos de autenticación.
    /// </summary>
    internal static class MensajesAutenticacion
    {
        #region Atributos internos constantes
        /// <summary>
        /// La contraseña introducida es incorrecta.
        /// </summary>
        internal const string ContraseñaIncorrecta = "La contraseña introducida es incorrecta.";
        /// <summary>
        /// El nombre del usuario introducido es incorrecto.
        /// </summary>
        internal const string UsuarioIncorrecto = "El nombre del usuario introducido es incorrecto.";
        /// <summary>
        /// No hay establecido un método de autenticación.
        /// </summary>
        internal const string SinAutenticacion = "No hay establecido un método de autenticación.";
        #endregion
    }
}