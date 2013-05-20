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
using Orbita.Controles.Comunicaciones;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Clase abstracta que indica la persistencia de acuerdo al idioma seleccionado.
    /// </summary>
    public interface IConfiguracion
    {
        /// <summary>
        /// Obtener la configuración principal del Framework relativa a estilo de borde, visualización de menú, etc.
        /// </summary>
        /// <returns></returns>
        void InicializarEntorno(object sender, System.EventArgs e);
        /// <summary>
        /// Obtener la colección de controles desde un origen que se refieren al idioma seleccionado.
        /// </summary>
        /// <param name="idioma">Enumerado de idioma que determina el rango de controles al que hacen referencia.</param>
        /// <returns>Colección de controles que se refieren al idioma seleccionado.</returns>
        System.Collections.Generic.IDictionary<string, ControlInfo> GetControlesPlugin(SelectorIdioma idioma);
        System.Collections.Generic.IList<OrbitaConfiguracionCanal> GetConfiguracionCanal();
    }
}