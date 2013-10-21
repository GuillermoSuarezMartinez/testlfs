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
            switch (tipo.ToLower())
            {
                case "osqlserver":
                    if (mirror.Length == 0)
                    {
                        OInfoConexion info = new OInfoConexion(instancia, basedatos, usuario, password);
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
