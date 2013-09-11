using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace Orbita.MS
{
    /// <summary>
    /// Mensaje con Objeto XML
    /// </summary>
    public class OObjetoXMLMensaje
    {
        #region Atributos
        /// <summary>
        /// Objeto serializado XML como cadena
        /// </summary>
        private string _objetoXML = "";
        /// <summary>
        /// ClassName del objeto para su deserialización
        /// </summary>
        private List<Type> _className = new List<Type>() { };
        /// <summary>
        /// Objeto serializado como cadena y cifrado a posteriori
        /// </summary>
        private string _objetoXMLCifrado = "";

        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Objeto serializado XML como cadena
        /// </summary>
        [XmlIgnore()]
        public string ObjetoXML
        {
            get { return _objetoXML; }
            //set { _objetoXML = value; }
        }
        /// <summary>
        /// Objeto serializado como cadena y cifrado a posteriori
        /// </summary>

        public string ObjetoXMLCifrado
        {
            get { return _objetoXMLCifrado; }
            set { _objetoXMLCifrado = value; }
        }
        /// <summary>
        /// Tipos de objetos
        /// </summary>
        public List<Type> ClassNames
        {
            get { return _className; }
            set { _className = value; }
        }
        #endregion Propiedades
        #region Constructor
        /// <summary>
        /// Serializa objeto y muestra sus valores como cadenas (cifradas y en texto plano).
        /// </summary>
        /// <param name="objeto">Objeto a serializar</param>
        /// <param name="tiposAuxiliares">Tipos auxiliares</param>
        public OObjetoXMLMensaje(object objeto, List<Type> tiposAuxiliares = null)
        {
            Type tipoPrincipal = objeto.GetType();
            if (tiposAuxiliares == null)
            {
                tiposAuxiliares = new List<Type>() { };
            }
            tiposAuxiliares.Add(tipoPrincipal);
            if (tipoPrincipal == typeof(OObjetoXMLMensaje))
            {
                OObjetoXMLMensaje incluido = objeto as OObjetoXMLMensaje;
                foreach (Type tipo in incluido.ClassNames)
                {
                    if (tipo != tipoPrincipal) tiposAuxiliares.Add(tipo);
                }
            }
            string xml = OGestionXML.SerializarArrayListCadena(new ArrayList() { objeto }, tiposAuxiliares.ToArray());
            this._objetoXML = xml;
            this._className = tiposAuxiliares;
            CifrarContenidoObjetoSerializado();
        }

        public OObjetoXMLMensaje()
        {
            //Constructor vacío para la serialización.
        }


        #endregion Constructor
        #region Métodos privados
        /// <summary>
        /// Cifra el contenido del objeto XML en base al algoritmo y clave de Orbita.MS.OCifrado
        /// </summary>
        private void CifrarContenidoObjetoSerializado()
        {

            this._objetoXMLCifrado = Orbita.MS.OCifrado.EncriptarTexto(this._objetoXML);
        }
        #endregion Métodos privados
        #region Métodos públicos
        /// <summary>
        /// Descifra el contenido del objeto XML en base al algoritmo y clave de Orbita.MS.OCifrado
        /// </summary>
        /// <param name="xml"></param>
        public void DesCifrarContenidoObjetoSerializado(string xml)
        {

            this._objetoXMLCifrado = xml;
            this._objetoXML = Orbita.MS.OCifrado.DesencriptarTexto(xml);
        }
        /// <summary>
        /// Obtiene el objeto deserializado
        /// </summary>
        public ArrayList ObtenerObjetoXMLDeserializado()
        {
            object res = null;
            try
            {
                res = OGestionXML.DeSerializarArrayListCadena(this._objetoXML, this._className.ToArray());
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
                throw e1;
            }
            return res as ArrayList;
        }
        #endregion Métodos públicos
    }
}
