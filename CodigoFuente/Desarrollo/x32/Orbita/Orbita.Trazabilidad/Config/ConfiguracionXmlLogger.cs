//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************

using System.Linq;
using System.Xml;

namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Una clase para configurar Logger desde un archivo de configuración XML.
    /// </summary>
    [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
    public class ConfiguracionXmlLogger : ConfiguracionLogger
    {
        #region Atributos
        /// <summary>
        /// Colección de ficheros de configuración.
        /// </summary>
        private readonly System.Collections.Specialized.StringDictionary _ficherosVisitados = new System.Collections.Specialized.StringDictionary();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs a new instance of <see cref="ConfiguracionXmlLogger" />
        /// class and reads the configuration from the specified config file.
        /// </summary>
        /// <param name="fichero">Configuration file to be read.</param>
        public ConfiguracionXmlLogger(string fichero)
        {
            ConfigurarDesdeFichero(fichero);
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Configurar de loggers desde el fichero Xml correspondiente.
        /// </summary>
        /// <param name="fichero">Fichero de logger.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        private void ConfigurarDesdeFichero(string fichero)
        {
            string clave = System.IO.Path.GetFullPath(fichero);
            if (_ficherosVisitados.ContainsKey(clave))
            {
                return;
            }
            _ficherosVisitados[clave] = clave;

            var documento = new XmlDocument();
            documento.Load(fichero);
            if (documento.DocumentElement != null && 0 == string.Compare(documento.DocumentElement.LocalName, "configuracion", System.StringComparison.CurrentCulture))
            {
                foreach (XmlElement elemento in documento.DocumentElement.GetElementsByTagName("otrazabilidad"))
                {
                    ConfigurarDesdeElementoXml(elemento);
                }
            }
            else
            {
                ConfigurarDesdeElementoXml(documento.DocumentElement);
            }
        }
        /// <summary>
        /// Configurar desde elemento dado.
        /// </summary>
        /// <param name="elemento">Elemento Xml.</param>
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        private void ConfigurarDesdeElementoXml(XmlElement elemento)
        {
            foreach (XmlElement elementoXml in elemento.ChildNodes.OfType<XmlElement>())
            {
                switch (elementoXml.LocalName)
                {
                    case "loggers":
                        ConfigurarLoggersDesdeElementoXml(elementoXml);
                        break;
                    case "propiedades":
                        ConfigurarPropiedadesDesdeElementoXml(this, elementoXml);
                        break;
                }
            }
        }
        /// <summary>
        /// Configurar desde elemento dado.
        /// </summary>
        /// <param name="elemento">Elemento Xml.</param>
        private void ConfigurarLoggersDesdeElementoXml(XmlNode elemento)
        {
            if (elemento == null)
            {
                return;
            }
            foreach (XmlNode nodo in elemento.ChildNodes)
            {
                var elementoXml = nodo as XmlElement;
                if (elementoXml == null)
                {
                    continue;
                }
                if (0 != string.Compare(elementoXml.LocalName, "logger", System.StringComparison.CurrentCulture))
                    continue;
                ILogger logger = FactoryLogger.CreateTarget(GetCaseInsensitiveAttribute(elementoXml, "type"));
                if (logger == null) continue;
                ConfigureLoggerFiltersFromXmlElement(logger, nodo);
                AddLogger(logger.Identificador, logger);
                if (logger.GetType() == typeof(WrapperLogger))
                {
                    ConfigurarLoggersDesdeElementoXml(logger, elementoXml);
                }
            }
        }
        /// <summary>
        /// Configurar desde elemento dado.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="elemento">Elemento Xml.</param>
        private void ConfigurarLoggersDesdeElementoXml(ILogger logger, XmlNode elemento)
        {
            var wrapper = logger as WrapperLogger;
            foreach (XmlNode nodo in elemento.ChildNodes)
            {
                var elementoXml = nodo as XmlElement;
                if (elementoXml == null) continue;
                if (elementoXml.LocalName != "logger") continue;
                string type = GetCaseInsensitiveAttribute(elementoXml, "type");
                ILogger nuevoLogger = FactoryLogger.CreateTarget(type);
                if (nuevoLogger == null) continue;
                ConfigureLoggerFiltersFromXmlElement(nuevoLogger, nodo);
                AddLogger(nuevoLogger.Identificador, nuevoLogger);
                if (wrapper != null) wrapper.Loggers.Add(nuevoLogger);
            }
        }
        #endregion

        #region Métodos privados estáticos
        [System.Security.Permissions.EnvironmentPermissionAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Unrestricted = true)]
        private static void ConfigurarPropiedadesDesdeElementoXml(ConfiguracionLogger config, XmlNode elemento)
        {
            if (elemento == null)
            {
                return;
            }
            foreach (XmlNode nodo in elemento.ChildNodes)
            {
                var elementoXml = nodo as XmlElement;
                if (elementoXml == null)
                {
                    continue;
                }
                if (0 != string.Compare(elementoXml.LocalName, "path", System.StringComparison.CurrentCulture) &&
                    0 != string.Compare(elementoXml.LocalName, "backup", System.StringComparison.CurrentCulture) &&
                    0 != string.Compare(elementoXml.LocalName, "timer", System.StringComparison.CurrentCulture) &&
                    0 != string.Compare(elementoXml.LocalName, "remoting", System.StringComparison.CurrentCulture))
                    continue;
                string nombre = GetCaseInsensitiveAttribute(elementoXml, "logger");
                string tipo = elementoXml.LocalName;
                ILogger logger = config.FindLoggerByName(nombre);
                if (logger == null) continue;
                if (tipo == "remoting")
                {
                    var remoting = ((RemotingLogger)logger);
                    ConfigureLoggerFiltersFromXmlElement(remoting, nodo);
                    remoting.SetTcpClientChannel();
                }
                else
                {
                    var debug = ((DebugLogger)logger);
                    if (0 == string.Compare(elementoXml.LocalName, "path", System.StringComparison.CurrentCulture))
                    {
                        PathLogger pathLogger = debug.PathLogger;
                        ConfigurePathFiltersFromXmlElement(pathLogger, nodo);
                        debug.SetPathLogger(pathLogger);
                    }
                    else if (0 == string.Compare(elementoXml.LocalName, "backup", System.StringComparison.CurrentCulture))
                    {
                        PathBackup pathBackup = debug.PathBackup ?? new PathBackup();
                        // Asignar atributos del objeto PathLogger.
                        ConfigurePathFiltersFromXmlElement(pathBackup, nodo);
                        debug.SetPathBackup(pathBackup);

                        // Asignar atributo SizeBackup del objeto DebugLogger.
                        ConfigureLoggerFiltersFromXmlElement(debug, nodo);
                        long sizeBackup = debug.SizeBackup;
                        if (sizeBackup > 0)
                        {
                            debug.SetFileSystemWatcher(sizeBackup);
                        }
                    }
                    else if (0 == string.Compare(elementoXml.LocalName, "timer", System.StringComparison.CurrentCulture))
                    {
                        var timerBackup = new TimerBackup();
                        ConfigurePathFiltersFromXmlElement(timerBackup, nodo);
                        debug.SetTimerBackup(timerBackup);
                    }
                }
            }
        }
        private static void ConfigureLoggerFiltersFromXmlElement(ILogger logger, XmlNode nodo)
        {
            if (nodo == null)
            {
                return;
            }
            if (!(nodo is XmlElement)) return;
            if (nodo.Attributes == null) return;
            foreach (XmlAttribute atributo in nodo.Attributes)
            {
                var sb = new System.Text.StringBuilder(atributo.LocalName);
                sb.Replace("nombre", "identificador");
                sb.Replace("nivel", "nivellog");
                sb.Replace("bytes", "sizeBackup");
                string nombre = sb.ToString();
                string valor = atributo.InnerText;
                PropertyHelper.SetPropertyFromString(logger, nombre, valor);
            }
        }
        private static void ConfigurePathFiltersFromXmlElement(object obj, XmlNode nodo)
        {
            if (nodo == null)
            {
                return;
            }
            if (!(nodo is XmlElement)) return;
            if (nodo.Attributes == null) return;
            foreach (XmlAttribute atributo in nodo.Attributes)
            {
                var sb = new System.Text.StringBuilder(atributo.LocalName);
                sb.Replace("ruta", "path");
                sb.Replace("subruta", "subpath");
                string nombre = sb.ToString();
                string valor = atributo.InnerText;
                if (nombre.ToUpperInvariant() != "logger".ToUpperInvariant())
                {
                    PropertyHelper.SetPropertyFromString(obj, nombre, valor);
                }
            }
        }
        private static string GetCaseInsensitiveAttribute(XmlElement elemento, string nombre)
        {
            string atributoXml = elemento.GetAttribute(nombre);
            if (!string.IsNullOrEmpty(atributoXml))
            {
                return PropertyHelper.ExpandVariables(atributoXml);
            }
            foreach (XmlAttribute atributo in elemento.Attributes.Cast<XmlAttribute>().Where(atributo => 0 == string.Compare(atributo.LocalName, nombre, System.StringComparison.CurrentCulture)))
            {
                return PropertyHelper.ExpandVariables(atributo.Value);
            }
            return atributoXml;
        }
        #endregion
    }
}