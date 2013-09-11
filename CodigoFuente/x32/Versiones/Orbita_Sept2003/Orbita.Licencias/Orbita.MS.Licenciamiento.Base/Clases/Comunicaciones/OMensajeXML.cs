using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.MS.Comunicaciones;
using System.Xml.Serialization;
using System.Collections;
namespace Orbita.MS
{
    /// <summary>
    /// Objeto de tipo mensaje usado para la comunicación.
    /// Los atributos ya están cifrados, y para su envío final se cifra de nuevo todo el paquete.
    /// </summary>
     [XmlRootAttribute("MensajeLic", Namespace = "http://orbitaingenieria.es/orbita/ms", IsNullable = false)]
    public class OMensajeXML
    {
        #region Atributos
        [XmlAttribute("Operacion")]
        public OMensajeXMLOperacion _operacion = OMensajeXMLOperacion.Indefinido;
        [XmlAttribute("Atributos")]
        public List<string> _atributos = new List<string>();
        [XmlAttribute("Creado")]
        public DateTime _creado = DateTime.Now;
        [XmlAttribute("Generado")]
        public DateTime _generado = DateTime.MinValue;
        [XmlAttribute("Version")]
        public string _versionMensaje = "1.1";
        [XmlAttribute("TipoMensaje")]
        public OMensajeXMLTipoMensaje _tipo = OMensajeXMLTipoMensaje.Indefinido;
        #endregion Atributos
        #region Propiedades
        public OMensajeXMLOperacion Operacion
        {
            get { return _operacion; }
        }
        public List<string> Atributos
        {
            get { return _atributos; }
        }
        public DateTime Creado
        {
            get { return _creado; }
        }
        public DateTime Generado
        {
            get { return _generado; }
        }
        #endregion Propiedades
        #region Constructor
         /// <summary>
         /// Constructor vacío para la serialización.
         /// </summary>
        public OMensajeXML()
        { }
         /// <summary>
         /// Genera un mensaje XML
         /// </summary>
         /// <param name="operacion">Operación</param>
         /// <param name="atributosMensaje">Atributos dinámicos</param>
         /// <param name="tipo">Solicitud, respuesta</param>
        public OMensajeXML(OMensajeXMLOperacion operacion, List<OObjetoXMLMensaje> atributosMensaje, OMensajeXMLTipoMensaje tipo = OMensajeXMLTipoMensaje.Solicitud)
        {
            this._operacion = operacion;
            this._tipo = tipo;
            foreach (OObjetoXMLMensaje atrib in atributosMensaje)
            {
                _atributos.Add(atrib.ObjetoXMLCifrado);
            }
        }
         /// <summary>
         /// Genera un mensaje XML
         /// </summary>
        /// <param name="operacion">Operación</param>
        /// <param name="atributosMensaje">Atributos dinámicos</param>
        /// <param name="tipo">Solicitud, respuesta</param>
        public OMensajeXML(OMensajeXMLOperacion operacion, List<string> atributosMensaje, OMensajeXMLTipoMensaje tipo = OMensajeXMLTipoMensaje.Solicitud)
        {
            this._operacion = operacion;
            this._atributos = atributosMensaje;
            this._tipo = tipo;
        }
        #endregion Constructor
        #region Métodos públicos
         /// <summary>
         /// Obtiene el mensaje como cadena de carácteres sin cifrar
         /// </summary>
         /// <returns></returns>
        private string ObtenerMensajeSinCifrar()
        {
            _generado = DateTime.Now;
            OObjetoXMLMensaje obj = new OObjetoXMLMensaje(this);
            string mensaje = obj.ObjetoXML;
            return mensaje;
        }
         /// <summary>
         /// Obtiene el mensaje como cadena de carácteres cifrada
         /// </summary>
         /// <returns></returns>
        public string ObtenerMensajeCifrado()
        {
            return Orbita.MS.OCifrado.EncriptarTexto(ObtenerMensajeSinCifrar());
        }
         /// <summary>
         /// Descifra el mensaje dada una cadena cifrada.
         /// </summary>
         /// <param name="xmlMensaje"></param>
         /// <returns></returns>
        public static OMensajeXML DescifrarMensajeXML(string xmlMensaje)
        {
            OMensajeXML mensaje = new OMensajeXML();
           // string xml = Orbita.MS.OCifrado.DesencriptarTexto(xmlMensaje);
            OObjetoXMLMensaje oxml = new OObjetoXMLMensaje();
            oxml.ClassNames.Add(typeof(OMensajeXML));
            oxml.DesCifrarContenidoObjetoSerializado(xmlMensaje);
            ArrayList cmensaje = oxml.ObtenerObjetoXMLDeserializado();
            foreach (OMensajeXML omen in cmensaje)
            {
                return omen;
            }
            return mensaje;
        }
         /// <summary>
         /// Permite descifrar atributos de tipado dinámico de un mensaje
         /// </summary>
         /// <param name="atributo"></param>
         /// <param name="tiposInterfaz"></param>
         /// <returns></returns>
        public static ArrayList DescifrarAtributoMensajeXML(string atributo, List<Type> tiposInterfaz)
        {
            ArrayList res = new ArrayList();
            string atributoD = Orbita.MS.OCifrado.DesencriptarTexto(atributo);

            OObjetoXMLMensaje oxml = new OObjetoXMLMensaje();
            foreach (Type tipo in tiposInterfaz)
            {
                oxml.ClassNames.Add(tipo);
            }
            oxml.DesCifrarContenidoObjetoSerializado(atributo);
            res = oxml.ObtenerObjetoXMLDeserializado();

            //res = OGestionXML.DeSerializarArrayListCadena(atributoD, tiposInterfaz.ToArray());
            return res;
        }
         /// <summary>
         /// Convierte de array de bytes (base64) a cadena.
         /// </summary>
         /// <param name="cadena"></param>
         /// <returns></returns>
         public static string ByteArrayAString(byte[] cadena)
        {

            return System.Text.Encoding.ASCII.GetString(cadena);
        }
         /// <summary>
         /// Convierte una cadena a un array de bytes (base64)
         /// </summary>
         /// <param name="cadena"></param>
         /// <returns></returns>
         public static byte[] StringAByteArray(string cadena)
         {
             //return Convert.FromBase64String(System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(cadena)));
             return Encoding.ASCII.GetBytes(cadena);
         }
        #endregion Métodos públicos
    }
}
