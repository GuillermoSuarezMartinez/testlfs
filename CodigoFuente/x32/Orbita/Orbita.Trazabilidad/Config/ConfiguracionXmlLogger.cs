//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Security.Permissions;
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Una clase para configurar Logger desde un archivo de configuración XML.
    /// </summary>
    [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
    public class ConfiguracionXmlLogger : ConfiguracionLogger
    {
        #region Atributos
        /// <summary>
        /// Colección de ficheros de configuración.
        /// </summary>
        System.Collections.Specialized.StringDictionary ficherosVisitados = new System.Collections.Specialized.StringDictionary();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs a new instance of <see cref="ConfiguracionXmlLogger" />
        /// class and reads the configuration from the specified config file.
        /// </summary>
        /// <param name="fichero">Configuration file to be read.</param>
        public ConfiguracionXmlLogger(string fichero)
        {
            this.ConfigurarDesdeFichero(fichero);
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Configurar de loggers desde el fichero Xml correspondiente.
        /// </summary>
        /// <param name="fichero">Fichero de logger.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        void ConfigurarDesdeFichero(string fichero)
        {
            string clave = System.IO.Path.GetFullPath(fichero);
            if (this.ficherosVisitados.ContainsKey(clave))
            {
                return;
            }
            this.ficherosVisitados[clave] = clave;

            System.Xml.XmlDocument documento = new System.Xml.XmlDocument();
            documento.Load(fichero);
            if (0 == string.Compare(documento.DocumentElement.LocalName, "configuracion", System.StringComparison.CurrentCulture))
            {
                foreach (System.Xml.XmlElement elemento in documento.DocumentElement.GetElementsByTagName("otrazabilidad"))
                {
                    this.ConfigurarDesdeElementoXml(elemento);
                }
            }
            else
            {
                this.ConfigurarDesdeElementoXml(documento.DocumentElement);
            }
        }
        /// <summary>
        /// Configurar desde elemento dado.
        /// </summary>
        /// <param name="elemento">Elemento Xml.</param>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        void ConfigurarDesdeElementoXml(System.Xml.XmlElement elemento)
        {
            foreach (System.Xml.XmlNode nodo in elemento.ChildNodes)
            {
                System.Xml.XmlElement elementoXml = nodo as System.Xml.XmlElement;
                if (elementoXml == null)
                {
                    continue;
                }
                switch (elementoXml.LocalName)
                {
                    case "loggers":
                        this.ConfigurarLoggersDesdeElementoXml(elementoXml);
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
        void ConfigurarLoggersDesdeElementoXml(System.Xml.XmlElement elemento)
        {
            if (elemento == null)
            {
                return;
            }
            foreach (System.Xml.XmlNode nodo in elemento.ChildNodes)
            {
                System.Xml.XmlElement elementoXml = nodo as System.Xml.XmlElement;
                if (elementoXml == null)
                {
                    continue;
                }
                if (0 == string.Compare(elementoXml.LocalName, "logger", System.StringComparison.CurrentCulture))
                {
                    ILogger logger = FactoryLogger.CreateTarget(GetCaseInsensitiveAttribute(elementoXml, "type"));
                    if (logger != null)
                    {
                        ConfigureLoggerFiltersFromXmlElement(logger, nodo);
                        this.AddLogger(logger.Identificador, logger);
                        if (logger.GetType() == typeof(Orbita.Trazabilidad.WrapperLogger))
                        {
                            ConfigurarLoggersDesdeElementoXml(logger, elementoXml);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Configurar desde elemento dado.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="elemento">Elemento Xml.</param>
        void ConfigurarLoggersDesdeElementoXml(ILogger logger, System.Xml.XmlElement elemento)
        {
            Orbita.Trazabilidad.WrapperLogger wrapper = logger as Orbita.Trazabilidad.WrapperLogger;
            foreach (System.Xml.XmlNode nodo in elemento.ChildNodes)
            {
                System.Xml.XmlElement elementoXml = nodo as System.Xml.XmlElement;
                if (elementoXml != null)
                {
                    if (elementoXml.LocalName == "logger")
                    {
                        string type = GetCaseInsensitiveAttribute(elementoXml, "type");
                        ILogger nuevoLogger = FactoryLogger.CreateTarget(type);
                        if (nuevoLogger != null)
                        {
                            ConfigureLoggerFiltersFromXmlElement(nuevoLogger, nodo);
                            AddLogger(nuevoLogger.Identificador, nuevoLogger);
                            wrapper.Loggers.Add(nuevoLogger);
                        }
                    }
                }
            }
        }
        #endregion

        #region Métodos privados estáticos
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        static void ConfigurarPropiedadesDesdeElementoXml(ConfiguracionLogger config, System.Xml.XmlElement elemento)
        {
            if (elemento == null)
            {
                return;
            }
            Orbita.Trazabilidad.PathLogger pathLogger = null;
            Orbita.Trazabilidad.PathBackup pathBackup = null;
            Orbita.Trazabilidad.TimerBackup timerBackup = null;
            foreach (System.Xml.XmlNode nodo in elemento.ChildNodes)
            {
                System.Xml.XmlElement elementoXml = nodo as System.Xml.XmlElement;
                if (elementoXml == null)
                {
                    continue;
                }
                if (0 == string.Compare(elementoXml.LocalName, "path", System.StringComparison.CurrentCulture) ||
                    0 == string.Compare(elementoXml.LocalName, "backup", System.StringComparison.CurrentCulture) ||
                    0 == string.Compare(elementoXml.LocalName, "timer", System.StringComparison.CurrentCulture) ||
                    0 == string.Compare(elementoXml.LocalName, "remoting", System.StringComparison.CurrentCulture))
                {
                    string nombre = GetCaseInsensitiveAttribute(elementoXml, "logger");
                    string tipo = elementoXml.LocalName;
                    ILogger logger = config.FindLoggerByName(nombre);
                    if (logger != null)
                    {
                        if (tipo == "remoting")
                        {
                            RemotingLogger remoting = ((RemotingLogger)logger);
                            ConfigureLoggerFiltersFromXmlElement(remoting, nodo);
                            remoting.SetTcpClientChannel();
                        }
                        else
                        {
                            DebugLogger debug = ((DebugLogger)logger);
                            if (0 == string.Compare(elementoXml.LocalName, "path", System.StringComparison.CurrentCulture))
                            {
                                pathLogger = debug.PathLogger;
                                ConfigurePathFiltersFromXmlElement(pathLogger, nodo);
                                debug.SetPathLogger(pathLogger);
                            }
                            else if (0 == string.Compare(elementoXml.LocalName, "backup", System.StringComparison.CurrentCulture))
                            {
                                pathBackup = debug.PathBackup;
                                if (pathBackup == null)
                                {
                                    pathBackup = new Orbita.Trazabilidad.PathBackup();
                                }
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
                                timerBackup = new TimerBackup();
                                if (timerBackup == null)
                                {
                                    timerBackup = new Orbita.Trazabilidad.TimerBackup();
                                }
                                ConfigurePathFiltersFromXmlElement(timerBackup, nodo);
                                debug.SetTimerBackup(timerBackup);
                            }
                        }
                    }
                }
            }
        }
        static void ConfigureLoggerFiltersFromXmlElement(ILogger logger, System.Xml.XmlNode nodo)
        {
            if (nodo == null)
            {
                return;
            }
            if (nodo is System.Xml.XmlElement)
            {
                foreach (System.Xml.XmlAttribute atributo in nodo.Attributes)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(atributo.LocalName);
                    sb.Replace("nombre", "identificador");
                    sb.Replace("nivel", "nivellog");
                    sb.Replace("bytes", "sizeBackup");
                    string nombre = sb.ToString();
                    string valor = atributo.InnerText;
                    PropertyHelper.SetPropertyFromString(logger, nombre, valor);
                }
            }
        }
        static void ConfigurePathFiltersFromXmlElement(object obj, System.Xml.XmlNode nodo)
        {
            if (nodo == null)
            {
                return;
            }
            if (nodo is System.Xml.XmlElement)
            {
                foreach (System.Xml.XmlAttribute atributo in nodo.Attributes)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(atributo.LocalName);
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
        }
        static string GetCaseInsensitiveAttribute(System.Xml.XmlElement elemento, string nombre)
        {
            string atributoXml = elemento.GetAttribute(nombre);
            if (!string.IsNullOrEmpty(atributoXml))
            {
                return PropertyHelper.ExpandVariables(atributoXml);
            }
            foreach (System.Xml.XmlAttribute atributo in elemento.Attributes)
            {
                if (0 == string.Compare(atributo.LocalName, nombre, System.StringComparison.CurrentCulture))
                {
                    return PropertyHelper.ExpandVariables(atributo.Value);
                }
            }
            return atributoXml;
        }
        #endregion
    }
}