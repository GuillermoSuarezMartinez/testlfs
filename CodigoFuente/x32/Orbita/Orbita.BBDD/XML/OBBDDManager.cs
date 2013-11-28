//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : crodiguez
// Created          : 28-11-2013
//
// Last Modified By : crodiguez
// Last Modified On : 28-11-2013
// Description      : Solucionado bug de timeout de conexión. Ahora existe un parámetro opcional en el XML de configuración
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Collections;
using System.Linq;
using System.Xml;

namespace Orbita.BBDD
{
    public class OBBDDManager
    {
        /// <summary>
        /// Colección con las conexiones a las bases de datos
        /// </summary>
        private static Hashtable _coleccionBBDD;
        /// <summary>
        /// Devuelve el objeto de conexión a la base de datos
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>Nombre de la conexión definido en el archivo xml</returns>
        public static OCoreBBDD GetBBDD(string nombre)
        {
            OCoreBBDD BBDD = (OCoreBBDD)_coleccionBBDD[nombre];
            return BBDD;
        }
        /// <summary>
        /// Lee el fichero de configuración XML
        /// </summary>
        /// <param name="ruta">ruta del archivo XML</param>
        public static void LeerFicheroConfig(string ruta)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ruta);
            ConfigurarXML(doc.DocumentElement);
        }
        /// <summary>
        /// Busca las conexiones del archivo XML
        /// </summary>
        /// <param name="element"></param>
        private static void ConfigurarXML(XmlElement element)
        {
            _coleccionBBDD = new Hashtable();
            foreach (XmlElement elementoXml in element.ChildNodes.OfType<XmlElement>())
            {
                switch (elementoXml.LocalName)
                {
                    case "BBDD":
                        ConfigurarColeccion(elementoXml);
                        break;
                }
            }
        }
        /// <summary>
        /// Inserta las conexiones de base de datos en la colección
        /// </summary>
        /// <param name="elementoXml"></param>
        private static void ConfigurarColeccion(XmlElement elementoXml)
        {
            string nombre = elementoXml.GetAttribute("nombre");
            string instancia = elementoXml.GetAttribute("Instancia");
            string basedatos = elementoXml.GetAttribute("BaseDatos");
            string usuario = elementoXml.GetAttribute("Usuario");
            string password = elementoXml.GetAttribute("Password");
            string tipo = elementoXml.GetAttribute("Tipo");
            string mirror = elementoXml.GetAttribute("Mirror");
            string timeout = string.Empty;
            if (elementoXml.HasAttribute("Timeout"))
            {
                timeout = elementoXml.GetAttribute("Timeout");
            }
            switch (tipo.ToLower())
            {
                case "osqlserver":
                    if (mirror.Length == 0)
                    {
                        OInfoConexion info;
                        int timeoutSg;
                        if (string.IsNullOrEmpty(timeout) || !int.TryParse(timeout, out timeoutSg))
                        {
                            info = new OInfoConexion(instancia, basedatos, usuario, password);
                        }
                        else
                        {
                            info = new OInfoConexion(instancia, basedatos, usuario, password, timeoutSg);
                        }
                        OSqlServer sql = new OSqlServer(info);
                        _coleccionBBDD.Add(nombre, sql);
                    }
                    else
                    {
                        OInfoMirroring info = new OInfoMirroring(instancia, basedatos, usuario, password, 120, mirror);
                        OSqlServer sql = new OSqlServer(info);
                        _coleccionBBDD.Add(nombre, sql);
                    }
                    break;
            }
        }
    }
}
