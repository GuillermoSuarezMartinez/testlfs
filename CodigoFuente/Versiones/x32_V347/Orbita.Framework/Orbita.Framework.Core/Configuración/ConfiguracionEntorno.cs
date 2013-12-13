//***********************************************************************
// Assembly         : Orbita.Framework
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
    /// Configuración general del entorno de trabajo.
    /// </summary>
    internal static class ConfiguracionEntorno
    {
        #region Atributos internos constantes
        /// <summary>
        /// Número máximo de formularios abiertos.
        /// </summary>
        internal const int DefectoNumeroMaximoFormulariosAbiertos = 50;
        /// <summary>
        /// Mostrar formulario de autenticación.
        /// </summary>
        internal const bool DefectoAutenticación = false;
        /// <summary>
        /// Selector del idioma de cada uno de los controles.
        /// </summary>
        internal const SelectorIdioma DefectoIdioma = SelectorIdioma.Español;
        #endregion
    }
}