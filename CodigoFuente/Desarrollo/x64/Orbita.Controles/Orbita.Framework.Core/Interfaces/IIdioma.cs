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
    /// Interface idioma con cada uno de los métodos relativos a la interface.
    /// </summary>
    public interface IIdioma
    {
        #region Métodos interface
        /// <summary>
        /// Obtener la colección de controles del control implementando la interface.
        /// </summary>
        /// <param name="idioma">Enumerable relativo al idioma seleccionado.</param>
        /// <returns>Diccionario de controles.</returns>
        System.Collections.Generic.IDictionary<string, ControlInfo> GetControles(SelectorIdioma idioma);
        #endregion
    }
}