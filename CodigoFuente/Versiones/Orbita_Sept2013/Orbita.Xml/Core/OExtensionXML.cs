using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Utiles;
using System.Collections;

namespace Orbita.Xml
{
    /// <summary>
    /// Métodos de extensión de diccionarios a XML
    /// </summary>
    public static class OExtensionXML
    {
        #region Método(s) estático(s)
        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        public static OXml ToXML(this Dictionary<string, object> datos, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            OXml oxml = null;
            switch (modoGeneracionXML)
            {
                case ModoGeneracionXML.XMLNormal:
                default:
                    oxml = OExtensionXML.ToXMLNormal(datos, nombreDocumento, nombreEtiqueta);
                    break;
                case ModoGeneracionXML.XMLEnseriado:
                    oxml = OExtensionXML.ToXMLEnseriado(datos, nombreDocumento, nombreEtiqueta);
                    break;
            }

            return oxml;
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        public static OXml ToXML(this List<Dictionary<string, object>> listadoDatos, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            OXml oxml = null;
            switch (modoGeneracionXML)
            {
                case ModoGeneracionXML.XMLNormal:
                default:
                    oxml = OExtensionXML.ToXMLNormal(listadoDatos, nombreDocumento, nombreEtiqueta);
                    break;
                case ModoGeneracionXML.XMLEnseriado:
                    oxml = OExtensionXML.ToXMLEnseriado(listadoDatos, nombreDocumento, nombreEtiqueta);
                    break;
            }

            return oxml;
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLNormal(Dictionary<string, object> datos, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            return OExtensionXML.ToXMLNormal(new List<Dictionary<string, object>>() { datos }, nombreDocumento, nombreEtiqueta);
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLNormal(List<Dictionary<string, object>> listadoDatos, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            OXml oXML = new OXml();
            oXML.AbrirDocumento(nombreDocumento);

            foreach (Dictionary<string, object> datos in listadoDatos)
            {
                oXML.AbrirEtiqueta(nombreEtiqueta);
                foreach (KeyValuePair<string, object> dato in datos)
                {
                    object valor = dato.Value;
                    if (valor != null)
                    {
                        oXML.Add(dato.Key, valor);
                    }
                }
                oXML.CerrarEtiqueta();
            }
            oXML.CerrarDocumento();

            return oXML;
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLEnseriado(Dictionary<string, object> datos, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            return OExtensionXML.ToXMLEnseriado(new List<Dictionary<string, object>>() { datos }, nombreDocumento, nombreEtiqueta);
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLEnseriado(List<Dictionary<string, object>> listadoDatos, string nombreDocumento = "ParametrosXML", string nombreEtiqueta = "ParametroXML")
        {
            OXml oXML = new OXml();
            oXML.AbrirDocumento(nombreDocumento);

            foreach (Dictionary<string, object> datos in listadoDatos)
            {
                foreach (KeyValuePair<string, object> dato in datos)
                {
                    object valor = dato.Value;
                    if (valor != null)
                    {
                        if (valor is int)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Entero);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", (int)valor);
                            oXML.Add("ValorDecimal", 0.0);
                            oXML.Add("ValorTexto", string.Empty);
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is double)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Decimal);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", (double)valor);
                            oXML.Add("ValorTexto", string.Empty);
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is bool)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Bit);
                            oXML.Add("ValorBit", (bool)valor);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", 0.0);
                            oXML.Add("ValorTexto", string.Empty);
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is string)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Texto);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", 0.0);
                            oXML.Add("ValorTexto", (string)valor);
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is DateTime)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Fecha);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", 0.0);
                            oXML.Add("ValorTexto", string.Empty);
                            oXML.Add("ValorFecha", ((DateTime)valor).ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is TimeSpan)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key.ToString());
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Decimal);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", ((TimeSpan)valor).TotalMilliseconds);
                            oXML.Add("ValorTexto", string.Empty);
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is ArrayList)
                        {
                            oXML.AbrirEtiqueta(nombreEtiqueta);
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Texto);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", 0.0);
                            oXML.Add("ValorTexto", ((ArrayList)valor).Colection2String(';'));
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                        else if (valor is Array)
                        {
                            oXML.AbrirEtiqueta("ParametroXML");
                            oXML.Add("Codigo", dato.Key);
                            oXML.Add("IdTipo", (int)OEnumTipoDato.Texto);
                            oXML.Add("ValorBit", false);
                            oXML.Add("ValorEntero", 0);
                            oXML.Add("ValorDecimal", 0.0);
                            oXML.Add("ValorTexto", ((Array)valor).Colection2String(';'));
                            oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            oXML.CerrarEtiqueta();
                        }
                    }
                    else
                    {
                        oXML.AbrirEtiqueta("ParametroXML");
                        oXML.Add("CodHistoricoDetalle", dato.Key);
                        oXML.Add("IdTipoHistoricoDetalle", (int)OEnumTipoDato.SinDefinir);
                        oXML.Add("ValorBit", false);
                        oXML.Add("ValorEntero", 0);
                        oXML.Add("ValorDecimal", 0.0);
                        oXML.Add("ValorTexto", string.Empty);
                        oXML.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                        oXML.CerrarEtiqueta();
                    }
                }
            }
            oXML.CerrarDocumento();

            return oXML;
        }
        #endregion
    }
}
