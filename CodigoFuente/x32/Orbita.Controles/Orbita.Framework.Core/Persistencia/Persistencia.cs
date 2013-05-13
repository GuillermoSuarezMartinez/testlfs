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
    /// Clase abstracta que indica la persistencia de acuerdo al idioma seleccionado.
    /// </summary>
    public abstract class Persistencia : IIdioma
    {
        /// <summary>
        /// Obtener la configuración principal del Framework relativa a estilo de borde, visualización de menú, etc.
        /// </summary>
        /// <returns></returns>
        public abstract IFormConfigurador GetConfiguracion();
        /// <summary>
        /// Obtener la colección de controles desde un origen que se refieren al idioma seleccionado.
        /// </summary>
        /// <param name="idioma">Enumerado que determina el idioma al que hace referencia.</param>
        /// <returns>Colección de controles que se refieren al idioma seleccionado.</returns>
        public abstract System.Collections.Generic.IDictionary<string, ControlInfo> GetControles(SelectorIdioma idioma);
    }
}