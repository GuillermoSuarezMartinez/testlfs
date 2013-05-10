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
using System.Linq;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Colección de configuración de Plugin.
    /// </summary>
    public class CollectionPluginConfiguracion : System.Collections.Generic.List<PluginConfiguracion>
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.CollectionPluginConfiguracion.
        /// </summary>
        public CollectionPluginConfiguracion()
            : base() { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtener los Plugins del título especificado.
        /// </summary>
        /// <param name="titulo">Título del Plugin.</param>
        /// <returns>Un único elemento que cumple la condición especificada de título de Plugin.</returns>
        public PluginConfiguracion this[string titulo]
        {
            get { return this.SingleOrDefault(x => x.Titulo == titulo); }
        }

        #endregion

        #region Métodos públicos
        /// <summary>
        /// Comprueba si existe el título en la colección.
        /// </summary>
        /// <param name="titulo">Título del Plugin.</param>
        /// <returns>La condición de existencia del Plugin en la colección.</returns>
        public bool Existe(string titulo)
        {
            return this[titulo] != null;
        }
        #endregion
    }
}
