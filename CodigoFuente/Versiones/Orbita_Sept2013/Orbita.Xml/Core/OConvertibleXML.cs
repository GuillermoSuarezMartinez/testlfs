using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Orbita.Xml
{
    /// <summary>
    /// Clase que incluye funcionalidad de conversión automática a XML compatible para su proceso por un 
    /// procedimiento almacenado de base de datos
    /// </summary>
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
    /// Indica la forma de generar el fichero XML a partir de un diccionario
    /// </summary>
    public enum ModoGeneracionXML
    {
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
}