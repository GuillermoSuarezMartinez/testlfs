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
using System.Xml.Linq;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Configuración de plugin.
    /// </summary>
    public class PluginConfiguracion
    {
        #region Propiedades
        /// <summary>
        /// Título del ensamblado.
        /// </summary>
        [System.Xml.Serialization.XmlAttribute(AttributeName = "Titulo")]
        public string Titulo { get; set; }
        /// <summary>
        /// Configuración del ensamblado.
        /// </summary>
        [System.Xml.Serialization.XmlElement(ElementName = "Configuracion")]
        public XElement Configuracion { get; set; }
        /// <summary>
        /// Ruta del ensamblado.
        /// </summary>
        [System.Xml.Serialization.XmlAttribute(AttributeName = "AssemblyPath")]
        public string Ensamblado { get; set; }
        #endregion
    }
}