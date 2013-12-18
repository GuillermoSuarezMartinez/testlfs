using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using Orbita.Utiles;

namespace Orbita.Xml
{
    /// <summary>
    /// Clase que incluye funcionalidad de conversión automática a XML compatible para su proceso por un 
    /// procedimiento almacenado de base de datos
    /// </summary>
    [Obsolete]
    public class OConvertibleXML
    {
        #region Propiedad(es)
        /// <summary>
        /// Propiedades a almacenar en XML
        /// </summary>
        protected Dictionary<string, object> _Propiedades;
        /// <summary>
        /// Propiedades a almacenar en XML
        /// </summary>
        public Dictionary<string, object> Propiedades
        {
            get { return _Propiedades; }
        }
        
        /// <summary>
        /// Resultados propios en serie
        /// </summary>
        public List<Dictionary<string, object>> PropiedadesDetalle
        {
            get
            {
                return this._Detalles.Select(prop => prop.Propiedades).ToList();
            }
        }
        #endregion

        #region Propiedad(es) virtual(es)
        /// <summary>
        /// Desglose de detalle
        /// </summary>
        protected List<OConvertibleXML> _Detalles;
        /// <summary>
        /// Desglose de detalle
        /// </summary>
        public virtual List<OConvertibleXML> Detalles
        {
            get { return _Detalles; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OConvertibleXML()
            : base()
        {
            this._Propiedades = new Dictionary<string, object>();
            this._Detalles = new List<OConvertibleXML>();
        }
        #endregion

        #region Operador(es)
        /// <summary>
        /// Operador de adición de propiedades. ¡No de detalles!
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static OConvertibleXML operator +(OConvertibleXML g1, OConvertibleXML g2)
        {
            OConvertibleXML resultado = new OConvertibleXML();

            foreach (var prop in g1._Propiedades)
            {
                resultado._Propiedades.Add(prop.Key, prop.Value);
            }

            foreach (var prop in g2._Propiedades)
            {
                resultado._Propiedades.Add(prop.Key, prop.Value);
            }

            return resultado;
        }
        #endregion

        #region Métodos virtuales
        /// <summary>
        /// Añade un detalle a la lista de detalles
        /// </summary>
        public virtual OConvertibleXML AñadirNuevoDetalle()
        {
            OConvertibleXML detalle = new OConvertibleXML();
            this._Detalles.Add(detalle);

            return detalle;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Añade un detalle a la lista de detalles
        /// </summary>
        public void AñadirDetalle(OConvertibleXML detalle)
        {
            this._Detalles.Add(detalle);
        }

        /// <summary>
        /// Elimina un detalle a la lista de detalles
        /// </summary>
        public void EliminarDetalle(OConvertibleXML detalle)
        {
            this._Detalles.Remove(detalle);
        }

        /// <summary>
        /// Añade un detalle a la lista de detalles
        /// </summary>
        public void AñadirPropiedad(string clave, object valor)
        {
            this._Propiedades.Add(clave, valor);
        }

        /// <summary>
        /// Elimina un detalle a la lista de detalles
        /// </summary>
        public void EliminarPropiedad(string clave, object valor)
        {
            this._Propiedades.Remove(clave);
        }

        /// <summary>
        /// Formatea el contenido para ser almacenado en un XML
        /// </summary>
        /// <param name="modoGeneracionXML"></param>
        /// <param name="nombreDocumento"></param>
        /// <param name="nombreEtiqueta"></param>
        /// <returns></returns>
        public OXml ToXML(ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            return this.Propiedades.ToXML(modoGeneracionXML, nombreDocumento, nombreEtiqueta);
        }

        /// <summary>
        /// Formatea el contenido para ser almacenado en un XML
        /// </summary>
        /// <param name="modoGeneracionXML"></param>
        /// <param name="nombreDocumento"></param>
        /// <param name="nombreEtiqueta"></param>
        /// <returns></returns>
        public OXml ToXMLDetalles(ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            return this.PropiedadesDetalle.ToXML(modoGeneracionXML, nombreDocumento, nombreEtiqueta);
        }

        /// <summary>
        /// Convierte el contenido en un diccionario. Se permite el formateo del texto
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,object> ToDictionary(Func<string, string> formateador)
        {
            Dictionary<string, object> resultado = new Dictionary<string, object>();

            // Añadimos los detalles
            foreach (KeyValuePair<string, object> pair in this.Propiedades)
            {
                string clave = formateador(pair.Key);
                resultado.Add(clave, pair.Value);
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase que incluye funcionalidad de conversión automática a XML compatible para su proceso por un 
    /// procedimiento almacenado de base de datos
    /// </summary>
    public class OConvertibleXMLEx
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de propiedades internas de la clase
        /// </summary>
        private Dictionary<string, OTriplet<ModoGeneracionXML, Type, PropertyInfo>> PropertiesList;
        /// <summary>
        /// Función formateador de las claves de las propiedades
        /// </summary>
        private Func<string, string> Formateador;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Propiedades a almacenar en XML
        /// </summary>
        protected Dictionary<string, object> _Propiedades;
        /// <summary>
        /// Propiedades a almacenar en XML
        /// </summary>
        [OAtributoConversionXML(Xml.ModoGeneracionXML.XMLIgnore, "Propiedades")]
        protected Dictionary<string, object> Propiedades
        {
            get { return _Propiedades; }
        }

        /// <summary>
        /// Resultados propios en serie
        /// </summary>
        [OAtributoConversionXML(Xml.ModoGeneracionXML.XMLIgnore, "PropiedadesDetalle")]
        protected List<Dictionary<string, object>> PropiedadesDetalle
        {
            get
            {
                return this._Detalles.Select(prop => prop.Propiedades).ToList();
            }
        }
        #endregion

        #region Propiedad(es) virtual(es)
        /// <summary>
        /// Desglose de detalle
        /// </summary>
        protected List<OConvertibleXMLEx> _Detalles;
        /// <summary>
        /// Desglose de detalle
        /// </summary>
        [OAtributoConversionXML(Xml.ModoGeneracionXML.XMLIgnore, "Detalles")]
        public virtual List<OConvertibleXMLEx> Detalles
        {
            get { return _Detalles; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OConvertibleXMLEx(Func<string, string> formateador = null)
            : base()
        {
            this._Propiedades = new Dictionary<string, object>();
            this._Detalles = new List<OConvertibleXMLEx>();
            this.PropertiesList = this.GetProperties();
            this.Formateador = formateador;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="listaPropiedades">Lista de propiedades a añadir</param>
        public OConvertibleXMLEx(Dictionary<string, object> listaPropiedades, Func<string, string> formateador = null)
            : this(formateador)
        {
            this.RellenarPropiedades(listaPropiedades);
        }
        #endregion

        #region Operador(es)
        /// <summary>
        /// Operador de adición de propiedades. ¡No de detalles!
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static OConvertibleXMLEx operator +(OConvertibleXMLEx g1, OConvertibleXMLEx g2)
        {
            OConvertibleXMLEx resultado = new OConvertibleXMLEx();

            foreach (var prop in g1._Propiedades)
            {
                resultado._Propiedades.Add(prop.Key, prop.Value);
            }

            foreach (var prop in g2._Propiedades)
            {
                resultado._Propiedades.Add(prop.Key, prop.Value);
            }

            return resultado;
        }
        #endregion

        #region Métodos virtuales
        /// <summary>
        /// Añade un detalle a la lista de detalles
        /// </summary>
        public virtual OConvertibleXMLEx AñadirNuevoDetalle()
        {
            OConvertibleXMLEx detalle = new OConvertibleXMLEx();
            this._Detalles.Add(detalle);

            return detalle;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True if successfull</returns>
        private Dictionary<string, OTriplet<ModoGeneracionXML, Type, PropertyInfo>> GetProperties()
        {
            Dictionary<string, OTriplet<ModoGeneracionXML, Type, PropertyInfo>> resultado = new Dictionary<string, OTriplet<ModoGeneracionXML, Type, PropertyInfo>>();

            PropertyInfo[] propiedades = this.GetType().GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                object[] atributos = propiedad.GetCustomAttributes(true);
                OAtributoConversionXML atributoConversionXML = null;
                string codigo = propiedad.Name;
                ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLDefecto;
                foreach (object atributo in atributos)
                {
                    if (atributo is OAtributoConversionXML)
                    {
                        atributoConversionXML = (OAtributoConversionXML)atributo;
                        codigo = atributoConversionXML.Codigo;
                        modoGeneracionXML = atributoConversionXML.ModoGeneracionXML;
                        break;
                    }
                }
                resultado[codigo] = new OTriplet<ModoGeneracionXML, Type, PropertyInfo>(modoGeneracionXML, propiedad.PropertyType, propiedad);
            }

            return resultado;
        }

        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True if successfull</returns>
        private bool SetProperty(string nombrePropiedad, object valor)
        {
            bool resultado = false;

            OTriplet<ModoGeneracionXML, Type, PropertyInfo> triplete;
            if (this.PropertiesList.TryGetValue(nombrePropiedad, out triplete))
            {
                Type tipo = triplete.Second;
                if (tipo == valor.GetType())
                {
                    triplete.Third.SetValue(this, valor, null);
                    resultado = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>String Value associated via a <see cref="OAtributoEnumeradoAttribute"/> attribute, or null if not found.</returns>
        private  Dictionary<string, object> GetPropiedades(ModoGeneracionXML modoGeneracionXML)
        {
            Dictionary<string, object> resultado = new Dictionary<string, object>();

            foreach(KeyValuePair<string,OTriplet<ModoGeneracionXML, Type, PropertyInfo>> keyValue in this.PropertiesList)
	        {
                if (keyValue.Value.First == modoGeneracionXML)
                {
                    resultado[keyValue.Key] = keyValue.Value.Third.GetValue(this, null);
                }
	        }

            return resultado;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Añade un detalle a la lista de detalles
        /// </summary>
        public void AñadirDetalle(OConvertibleXMLEx detalle)
        {
            this._Detalles.Add(detalle);
        }

        /// <summary>
        /// Elimina un detalle a la lista de detalles
        /// </summary>
        public void EliminarDetalle(OConvertibleXMLEx detalle)
        {
            this._Detalles.Remove(detalle);
        }

        /// <summary>
        /// Añade un detalle a la lista de detalles
        /// </summary>
        public void AñadirPropiedad(string clave, object valor)
        {
            // Si existe la propiedad la modifico por reflexión
            if (!this.SetProperty(clave, valor))
            {
                // Sino, la añado al diccionario de propiedades
                this._Propiedades[clave] = valor;
            }
        }

        /// <summary>
        /// Elimina un detalle a la lista de detalles
        /// </summary>
        public void EliminarPropiedad(string clave, object valor)
        {
            this._Propiedades.Remove(clave);
        }

        /// <summary>
        /// Rellena el conjunto de propiedades
        /// </summary>
        /// <param name="propiedades"></param>
        public void RellenarPropiedades(Dictionary<string, object> propiedades)
        {
            this._Propiedades = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> pair in propiedades)
            {
                this.AñadirPropiedad(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Convierte el contenido en un diccionario. Se permite el formateo del texto
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ObtenerPropiedades()
        {
            return this.ObtenerPropiedades(this.Formateador);
        }
        /// <summary>
        /// Convierte el contenido en un diccionario. Se permite el formateo del texto
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ObtenerPropiedades(Func<string, string> formateador)
        {
            Dictionary<string, object> resultado = new Dictionary<string, object>();

            // Añadimos las propiedades de lista
            foreach (KeyValuePair<string, object> pair in this.Propiedades)
            {
                string clave = pair.Key;

                if (formateador != null)
                {
                    clave = formateador(pair.Key);
                }

                resultado.Add(clave, pair.Value);
            }

            // Añadimos las propiedades intrinsecas
            foreach (KeyValuePair<string, OTriplet<ModoGeneracionXML, Type, PropertyInfo>> keyValue in this.PropertiesList)
            {
                if (keyValue.Value.First != ModoGeneracionXML.XMLIgnore)
                {
                    string clave = keyValue.Key;

                    if (formateador != null)
                    {
                        clave = formateador(keyValue.Key);
                    }
                    resultado.Add(clave, keyValue.Value.Third.GetValue(this, null));
                }
            }

            return resultado;
        }

        /// <summary>
        /// Convierte el contenido en un diccionario. Se permite el formateo del texto
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ObtenerPropiedadesDetalles()
        {
            Dictionary<string, object> resultado = this.ObtenerPropiedades();

            foreach (OConvertibleXMLEx detalle in this.Detalles)
            {
                resultado.AddRange(detalle.ObtenerPropiedadesDetalles());
            }

            return resultado;
        }

        /// <summary>
        /// Formatea el contenido para ser almacenado en un XML
        /// </summary>
        /// <param name="modoGeneracionXML"></param>
        /// <param name="nombreDocumento"></param>
        /// <param name="nombrePropiedad"></param>
        /// <returns></returns>
        public void ToXML(ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            Dictionary<string, object> propiedadesXMLDefecto = this.GetPropiedades(ModoGeneracionXML.XMLDefecto);
            propiedadesXMLDefecto.AddRange(this.Propiedades);
            Dictionary<string, object> propiedadesXMLNormal = this.GetPropiedades(ModoGeneracionXML.XMLNormal);
            Dictionary<string, object> propiedadesXMLEnseriado = this.GetPropiedades(ModoGeneracionXML.XMLEnseriado);

            if (xml == null)
            {
                xml = new OXml();
            }

            if (crearDocumento)
            {
                xml.AbrirDocumento(nombreDocumento);
            }

            if (crearEtiqueta)
            {
                xml.AbrirEtiqueta(nombreRegistro);
            }

            propiedadesXMLNormal.ToXML(ref xml, false, false, ModoGeneracionXML.XMLNormal, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
            propiedadesXMLDefecto.ToXML(ref xml, false, false, modoGeneracionXML, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
            propiedadesXMLEnseriado.ToXML(ref xml, false, false, ModoGeneracionXML.XMLEnseriado, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);

            foreach (OConvertibleXMLEx detalle in this._Detalles)
            {
                xml.AbrirEtiqueta(nombreDetalle);

                detalle.ToXML(ref xml, false, false, modoGeneracionXML, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);

                xml.CerrarEtiqueta();
            }

            if (crearEtiqueta)
            {
                xml.CerrarEtiqueta();
            }

            if (crearDocumento)
            {
                xml.CerrarDocumento();
            }
        }
        #endregion
    }

    /// <summary>
    /// Indica la forma de generar el fichero XML a partir de un diccionario
    /// </summary>
    public enum ModoGeneracionXML
    {
        /// <summary>
        /// Ignorar en el XML
        /// </summary>
        XMLIgnore,
        /// <summary>
        /// Opción por defecto
        /// </summary>
        XMLDefecto,
        /// <summary>
        /// El diccionario supondría un registro, y cada elemento del mismo correspondería a un campo de la base de datos
        /// Ejemplo:
        ///   <NombreDocumento>
        ///     <NombreEtiqueta>Clave1=Valor1</NombreEtiqueta>
        ///     <NombreEtiqueta>Clave2=Valor2</NombreEtiqueta>
        ///     <NombreEtiqueta>Clave3=Valor3</NombreEtiqueta>
        ///     <NombreEtiqueta>Clave4=Valor4</NombreEtiqueta>
        ///   </NombreDocumento>
        /// </summary>
        XMLNormal,
        /// <summary>
        /// Cada elemento del diccionario correspondería a un registro de la base de datos
        /// Ejemplo:
        ///   <NombreDocumento>
        ///     <NombreEtiqueta>
        ///         Codigo=string
        ///         IdTipo=OEnumTipoDato
        ///         ValorBit=bool
        ///         ValorEntero=int
        ///         ValorDecimal=double
        ///         ValorTexto=string
        ///         ValorFecha=DateTime
        ///     </NombreEtiqueta>
        ///     <NombreEtiqueta>
        ///         Codigo=string
        ///         IdTipo=OEnumTipoDato
        ///         ValorBit=bool
        ///         ValorEntero=int
        ///         ValorDecimal=double
        ///         ValorTexto=string
        ///         ValorFecha=DateTime
        ///     </NombreEtiqueta>
        ///   </NombreDocumento>
        /// </summary>
        XMLEnseriado
    }

    /// <summary>
    /// Clases para dotar de atributos a los tipos enumerados.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Property, Inherited = true)]
    public sealed class OAtributoConversionXML : Attribute
    {
        #region Propiedades
        /// <summary>
        /// Valor del enumerado.
        /// </summary>
        ModoGeneracionXML _ModoGeneracionXML;
        /// <summary>
        /// Obtiene el valor.
        /// </summary>
        /// <value></value>
        public ModoGeneracionXML ModoGeneracionXML
        {
            get { return this._ModoGeneracionXML; }
        }

        /// <summary>
        /// Código identificativo del atributo
        /// </summary>
        private string _Codigo;
        /// <summary>
        /// Código identificativo del atributo
        /// </summary>
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OAtributoEnumerado.
        /// </summary>
        public OAtributoConversionXML() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OAtributoEnumerado.
        /// </summary>
        /// <param name="valor">valor.</param>
        public OAtributoConversionXML(ModoGeneracionXML modoGeneracionXML, string codigo)
        {
            this._ModoGeneracionXML = modoGeneracionXML;
            this._Codigo = codigo;
        }
        #endregion
    }
}
