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
        public static OXml ToXML(this Dictionary<string, object> datos, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "DocumentoXML", string nombreEtiqueta = "RegistroXML")
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
        public static void ToXML(this Dictionary<string, object> datos, ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            switch (modoGeneracionXML)
            {
                case ModoGeneracionXML.XMLNormal:
                default:
                    OExtensionXML.ToXMLNormal(datos, ref xml, crearDocumento, crearEtiqueta, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
                    break;
                case ModoGeneracionXML.XMLEnseriado:
                    OExtensionXML.ToXMLEnseriado(datos, ref xml, crearDocumento, crearEtiqueta, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
                    break;
            }
        }


        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        public static OXml ToXML(this List<Dictionary<string, object>> listadoDatos, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "DocumentoXML", string nombreEtiqueta = "RegistroXML")
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
        public static void ToXML(this List<Dictionary<string, object>> listadoDatos, ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, ModoGeneracionXML modoGeneracionXML = ModoGeneracionXML.XMLNormal, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            switch (modoGeneracionXML)
            {
                case ModoGeneracionXML.XMLNormal:
                default:
                    OExtensionXML.ToXMLNormal(listadoDatos, ref xml, crearDocumento, crearEtiqueta, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
                    break;
                case ModoGeneracionXML.XMLEnseriado:
                    OExtensionXML.ToXMLEnseriado(listadoDatos, ref xml, crearDocumento, crearEtiqueta, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
                    break;
            }
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLNormal(Dictionary<string, object> datos, string nombreDocumento = "DocumentoXML", string nombreEtiqueta = "RegistroXML")
        {
            return OExtensionXML.ToXMLNormal(new List<Dictionary<string, object>>() { datos }, nombreDocumento, nombreEtiqueta);
        }
        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static void ToXMLNormal(Dictionary<string, object> datos, ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            OExtensionXML.ToXMLNormal(new List<Dictionary<string, object>>() { datos }, ref xml, crearDocumento, crearEtiqueta, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLNormal(List<Dictionary<string, object>> listadoDatos, string nombreDocumento = "DocumentoXML", string nombreEtiqueta = "RegistroXML")
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
        private static void ToXMLNormal(List<Dictionary<string, object>> listadoDatos, ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            if (xml == null)
            {
                xml = new OXml();
            }

            if (crearDocumento)
            {
                xml.AbrirDocumento(nombreDocumento);
            }

            foreach (Dictionary<string, object> datos in listadoDatos)
            {
                if (crearEtiqueta)
                {
                    xml.AbrirEtiqueta(nombreRegistro);
                }

                foreach (KeyValuePair<string, object> dato in datos)
                {
                    object valor = dato.Value;
                    if (valor != null)
                    {
                        xml.Add(dato.Key, valor);
                    }
                }

                if (crearEtiqueta)
                {
                    xml.CerrarEtiqueta();
                }
            }

            if (crearDocumento)
            {
                xml.CerrarDocumento();
            }
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLEnseriado(Dictionary<string, object> datos, string nombreDocumento = "DocumentoXML", string nombreEtiqueta = "RegistroXML")
        {
            return OExtensionXML.ToXMLEnseriado(new List<Dictionary<string, object>>() { datos }, nombreDocumento, nombreEtiqueta);
        }
        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static void ToXMLEnseriado(Dictionary<string, object> datos, ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            OExtensionXML.ToXMLEnseriado(new List<Dictionary<string, object>>() { datos }, ref xml, crearDocumento, crearEtiqueta, nombreDocumento, nombreRegistro, nombrePropiedad, nombreDetalle);
        }

        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static OXml ToXMLEnseriado(List<Dictionary<string, object>> listadoDatos, string nombreDocumento = "DocumentoXML", string nombreEtiqueta = "RegistroXML")
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
                            oXML.AbrirEtiqueta(nombreEtiqueta);
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
                        oXML.AbrirEtiqueta(nombreEtiqueta);
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
        /// <summary>
        /// Formatea el diccionario para ser almacenado en un XML
        /// </summary>
        /// <param name="listadoDatos">Listado de datos a almacenar en el XML</param>
        /// <returns>Objeto de la clase OXml con los datos formateados.</returns>
        private static void ToXMLEnseriado(List<Dictionary<string, object>> listadoDatos, ref OXml xml, bool crearDocumento = true, bool crearEtiqueta = true, string nombreDocumento = "DocumentoXML", string nombreRegistro = "RegistroXML", string nombrePropiedad = "PropiedadXML", string nombreDetalle = "DetalleXML")
        {
            if (xml == null)
            {
                xml = new OXml();
            }

            if (crearDocumento)
            {
                xml.AbrirDocumento(nombreDocumento);
            }

            foreach (Dictionary<string, object> datos in listadoDatos)
            {
                foreach (KeyValuePair<string, object> dato in datos)
                {
                    object valor = dato.Value;
                    if (valor != null)
                    {
                        if (valor is int)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Entero);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", (int)valor);
                            xml.Add("ValorDecimal", 0.0);
                            xml.Add("ValorTexto", string.Empty);
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is double)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Decimal);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", (double)valor);
                            xml.Add("ValorTexto", string.Empty);
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is bool)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Bit);
                            xml.Add("ValorBit", (bool)valor);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", 0.0);
                            xml.Add("ValorTexto", string.Empty);
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is string)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Texto);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", 0.0);
                            xml.Add("ValorTexto", (string)valor);
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is DateTime)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Fecha);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", 0.0);
                            xml.Add("ValorTexto", string.Empty);
                            xml.Add("ValorFecha", ((DateTime)valor).ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is TimeSpan)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key.ToString());
                            xml.Add("IdTipo", (int)OEnumTipoDato.Decimal);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", ((TimeSpan)valor).TotalMilliseconds);
                            xml.Add("ValorTexto", string.Empty);
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is ArrayList)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Texto);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", 0.0);
                            xml.Add("ValorTexto", ((ArrayList)valor).Colection2String(';'));
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                        else if (valor is Array)
                        {
                            xml.AbrirEtiqueta(nombrePropiedad);
                            xml.Add("Codigo", dato.Key);
                            xml.Add("IdTipo", (int)OEnumTipoDato.Texto);
                            xml.Add("ValorBit", false);
                            xml.Add("ValorEntero", 0);
                            xml.Add("ValorDecimal", 0.0);
                            xml.Add("ValorTexto", ((Array)valor).Colection2String(';'));
                            xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                            xml.CerrarEtiqueta();
                        }
                    }
                    else
                    {
                        xml.AbrirEtiqueta(nombrePropiedad);
                        xml.Add("CodHistoricoDetalle", dato.Key);
                        xml.Add("IdTipoHistoricoDetalle", (int)OEnumTipoDato.SinDefinir);
                        xml.Add("ValorBit", false);
                        xml.Add("ValorEntero", 0);
                        xml.Add("ValorDecimal", 0.0);
                        xml.Add("ValorTexto", string.Empty);
                        xml.Add("ValorFecha", DateTime.Parse("1/1/2000").ToString());
                        xml.CerrarEtiqueta();
                    }
                }
            }

            if (crearDocumento)
            {
                xml.CerrarDocumento();
            }
        }
        #endregion
    }
}
