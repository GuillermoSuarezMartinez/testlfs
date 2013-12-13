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
using System;
using System.Xml;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
namespace Orbita.Framework.Core
{
    /// <summary>
    /// A class for configuring NLog through an XML configuration file 
    /// (App.config style or App.nlog style)
    /// </summary>
    public class XmlLoggingConfiguration : TargetConfiguration
    {
#if NET_2_API
        private NameValueCollection _variables = new NameValueCollection(StringComparer.InvariantCultureIgnoreCase);
#else
        private NameValueCollection _variables = new NameValueCollection(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
#endif

        private bool _autoReload = false;
        private string _originalFileName = null;

        /// <summary>
        /// Gets or sets the value indicating whether the configuration files
        /// should be watched for changes and reloaded automatically when changed.
        /// </summary>
        public bool AutoReload
        {
            get { return _autoReload; }
            set { _autoReload = value; }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="XmlLoggingConfiguration" />
        /// class and reads the configuration from the specified config file.
        /// </summary>
        /// <param name="fileName">Configuration file to be read.</param>
        public XmlLoggingConfiguration(string fileName)
        {
            _originalFileName = fileName;
            ConfigureFromFile(fileName);
        }

        /// <summary>
        /// Constructs a new instance of <see cref="XmlLoggingConfiguration" />
        /// class and reads the configuration from the specified XML element.
        /// </summary>
        /// <param name="configElement"><see cref="XmlElement" /> containing the configuration section.</param>
        /// <param name="fileName">Name of the file that contains the element (to be used as a base for including other files).</param>
        public XmlLoggingConfiguration(XmlElement configElement, string fileName)
        {
            if (fileName != null)
            {
                string key = Path.GetFullPath(fileName).ToLower(CultureInfo.InvariantCulture);
                _originalFileName = fileName;
                ConfigureFromXmlElement(configElement, Path.GetDirectoryName(fileName));
            }
            else
            {
                ConfigureFromXmlElement(configElement, null);
            }
        }

        /// <summary>
        /// Re-reads the original configuration file and returns the new <see cref="LoggingConfiguration" /> object.
        /// </summary>
        /// <returns>The new <see cref="XmlLoggingConfiguration" /> object.</returns>
        public override TargetConfiguration Reload()
        {
            return new XmlLoggingConfiguration(_originalFileName);
        }

        private void ConfigureFromFile(string fileName)
        {
            string key = Path.GetFullPath(fileName).ToLower(CultureInfo.InvariantCulture);
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            if (0 == String.Compare(doc.DocumentElement.LocalName, "configuration", true))
            {
                foreach (XmlElement el in doc.DocumentElement.GetElementsByTagName("nlog"))
                {
                    ConfigureFromXmlElement(el, Path.GetDirectoryName(fileName));
                }
            }
            else
            {
                ConfigureFromXmlElement(doc.DocumentElement, Path.GetDirectoryName(fileName));
            }
        }

        private string GetCaseInsensitiveAttribute(XmlElement element, string name)
        {
            // first try a case-sensitive match
            string s = element.GetAttribute(name);
            if (s != null && s != "")
                return PropertyHelper.ExpandVariables(s, _variables);

            // then look through all attributes and do a case-insensitive compare
            // this isn't very fast, but we don't need ultra speed here

            foreach (XmlAttribute a in element.Attributes)
            {
                if (0 == String.Compare(a.LocalName, name, true))
                    return PropertyHelper.ExpandVariables(a.Value, _variables);
            }

            return null;
        }

        private static bool HasCaseInsensitiveAttribute(XmlElement element, string name)
        {
            // first try a case-sensitive match
            if (element.HasAttribute(name))
                return true;

            // then look through all attributes and do a case-insensitive compare
            // this isn't very fast, but we don't need ultra speed here because usually we have about
            // 3 attributes per element

            foreach (XmlAttribute a in element.Attributes)
            {
                if (0 == String.Compare(a.LocalName, name, true))
                    return true;
            }

            return false;
        }

        private void ConfigureFromXmlElement(XmlElement configElement, string baseDirectory)
        {
            foreach (XmlNode node in configElement.ChildNodes)
            {
                XmlElement el = node as XmlElement;
                if (el == null)
                    continue;

                switch (el.LocalName.ToLower())
                {
                    case "targets":
                        ConfigureTargetsFromElement(el);
                        break;
                }
            }
        }


#if !NETCF
        /// <summary>
        /// Gets the default <see cref="LoggingConfiguration" /> object by parsing 
        /// the application configuration file (<c>app.exe.config</c>).
        /// </summary>
        public static TargetConfiguration AppConfig
        {
            get
            {
#if DOTNET_2_0
                object o = System.Configuration.ConfigurationManager.GetSection("nlog");
#else
                object o = System.Configuration.ConfigurationSettings.GetConfig("nlog");
#endif
                return o as TargetConfiguration;
            }
        }
#endif

        // implementation details

        private static string CleanWhitespace(string s)
        {
            s = s.Replace(" ", ""); // get rid of the whitespace
            return s;
        }

        private void ConfigureTargetsFromElement(XmlElement element)
        {
            if (element == null)
                return;

            bool asyncWrap = 0 == String.Compare(GetCaseInsensitiveAttribute(element, "async"), "true", true);
            foreach (XmlNode n in element.ChildNodes)
            {
                XmlElement targetElement = n as XmlElement;

                if (targetElement == null)
                    continue;

                if (0 == String.Compare(targetElement.LocalName, "target", true))
                {
                    string type = GetCaseInsensitiveAttribute(targetElement, "type");
                    Target newTarget = TargetFactory.CreateTarget(type);
                    if (newTarget != null)
                    {
                        ConfigureTargetFromXmlElement(newTarget, targetElement);
                        AddTarget(newTarget.Name, newTarget);
                    }
                }
            }
        }

        private void ConfigureTargetFromXmlElement(Target target, XmlElement element)
        {
            Type targetType = target.GetType();
            foreach (XmlAttribute attrib in element.Attributes)
            {
                string name = attrib.LocalName;
                string value = attrib.InnerText;

                if (0 == String.Compare(name, "type", true))
                    continue;

                PropertyHelper.SetPropertyFromString(target, name, value, _variables);
            }

            foreach (XmlNode node in element.ChildNodes)
            {
                if (node is XmlElement)
                {
                    XmlElement el = (XmlElement)node;
                    string name = el.LocalName;

                    if (name == "target")
                    {
                        string type = GetCaseInsensitiveAttribute(el, "type");
                        Target newTarget = TargetFactory.CreateTarget(type);
                        if (newTarget != null)
                        {
                            ConfigureTargetFromXmlElement(newTarget, el);
                            if (newTarget.Name != null)
                            {
                                // if the new target has name, register it
                                AddTarget(newTarget.Name, newTarget);
                            }
                        }
                        continue;
                    }

                    if (PropertyHelper.IsArrayProperty(targetType, name))
                    {
                        PropertyHelper.AddArrayItemFromElement(target, el, _variables);
                    }
                    else
                    {
                        string value = el.InnerXml;
                        PropertyHelper.SetPropertyFromString(target, name, value, _variables);
                    }
                }
            }
        }
    }
}