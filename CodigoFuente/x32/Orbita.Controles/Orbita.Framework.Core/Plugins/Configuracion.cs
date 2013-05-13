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
using System.Collections.Generic;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Configuración general de Plugins del Framework.
    /// </summary>
    public class Configuracion
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.Configuracion.
        /// </summary>
        public Configuracion()
        {
            Plugins = new PluginConfiguracionCollection();
        }
        #endregion

        #region Propiedades
        [System.Xml.Serialization.XmlElement(ElementName = "Plugin")]
        public PluginConfiguracionCollection Plugins { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Cargar el fichero de configuración deserializado.
        /// </summary>
        /// <param name="fichero">Nombre del fichero.</param>
        /// <returns>Fichero deserializado.</returns>
        public static Configuracion Cargar(string fichero)
        {
            return ExtendedFile.Leer(fichero).XmlDeserialize<Configuracion>();
        }
        /// <summary>
        /// Guardar el fichero de configuración serializado.
        /// </summary>
        /// <param name="fichero">Nombre del fichero.</param>
        public void Guardar(string fichero)
        {
            this.XmlSerialize(fichero);
        }
        #endregion
    }
}