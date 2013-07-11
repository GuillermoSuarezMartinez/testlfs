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
    /// Indica la persistencia de acuerdo al idioma seleccionado.
    /// </summary>
    public abstract class Configuracion : IConfiguracion
    {
        #region Propiedades
        /// <summary>
        /// Usuario validado.
        /// </summary>
        public string Usuario { get; set; }
        #endregion

        #region Métodos públicos abstractos
        /// <summary>
        /// Obtener la configuración principal del Framework relativa a estilo de borde, visualización de menú, etc., así como
        /// las propiedades que integra la propiedad OI.
        /// </summary>
        /// <returns></returns>
        public abstract void InicializarEntorno(object sender, System.EventArgs e);
        /// <summary>
        /// Obtener la colección de controles desde un origen que se refieren al idioma seleccionado.
        /// </summary>
        /// <param name="idioma">Enumerado de idioma que determina el rango de controles al que hacen referencia.</param>
        /// <returns>Colección de controles que se refieren al idioma seleccionado.</returns>
        public abstract System.Collections.Generic.IDictionary<string, ControlInfo> GetControlesPlugin(SelectorIdioma idioma);
        /// <summary>
        /// Obtener la configuración de canales de comunicación para posteriormente iniciarlos.
        /// </summary>
        /// <returns>Colección de canales de comunicación.</returns>
        public abstract System.Collections.Generic.IList<Controles.Comunicaciones.OrbitaConfiguracionCanal> GetConfiguracionCanal();
        #endregion
    }
}