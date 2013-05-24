//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : crodriguez
// Created          : 03-03-2011
//
// Last Modified By : aibañez
// Last Modified On : 21-12-2012
// Description      : Añadidos métodos:
//                    AddFechaUniveral: Añade al xml una fecha en 
//                     formato universal para no tener problemas 
//                     con la configuración regional
//                    Add(Timespan): Añade un valor de tipo timespan al
//                     xml conviertiendolo en double mediante el método TotalMilliseconds
//
// Last Modified By : crodriguez
// Last Modified On : 03-03-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.XPath;
namespace Orbita.Xml
{
    /// <summary>
    /// Clase Xml de Orbita.
    /// </summary>
    public class OXml : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Variable escrita en el Xml.
        /// NOTA: EL SIGUIENTE COMENTARIO SE HA MOVIDO DE OTRA UBICACIÓN, PERO CREO QUE SE REFIERE A ESTE ATRIBUTO (Vnicolau, 07/02/2011)
        /// Este atributo indica 'QUE VARIABLES' se van a escribir en Base de datos,
        /// es decir, contiene cada uno de los registros que se van a insertar.
        /// </summary>
        StringWriter swXml;
        /// <summary>
        /// Variable para escribir el XML
        /// </summary>
        XmlTextWriter escritorXml;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public OXml()
        {
            // Para escritura.
            this.swXml = new StringWriter(CultureInfo.CurrentCulture);
            this.escritorXml = new XmlTextWriter(this.swXml);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para acceder al Stringwriter.
        /// </summary>
        public StringWriter SWXml
        {
            get { return this.swXml; }
            set { this.swXml = value; }
        }
        /// <summary>
        /// Propiedad para acceder al XmlTextWriter.
        /// </summary>
        public XmlTextWriter EscritorXml
        {
            get { return this.escritorXml; }
            set { this.escritorXml = value; }
        }
        #endregion Propiedades

        #region Métodos públicos escritura
        /// <summary>
        /// Para abrir una nueva etiqueta del Xml
        /// </summary>
        /// <param name="etiqueta"></param>
        public void AbrirEtiqueta(string etiqueta)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
            }
        }
        /// <summary>
        /// Funcion para añadir una propiedad tipo string.
        /// </summary>
        /// <param name="etiqueta"></param>
        public void Add(string etiqueta)
        {
            this.escritorXml.WriteStartElement(etiqueta.ToString());
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo object.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, object valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                if (valor is DateTime)
                {
                    this.AddFechaUniversal(etiqueta, (DateTime)valor);
                }
                else if (valor is TimeSpan)
                {
                    this.Add(etiqueta, (TimeSpan)valor);
                }
                else
                {
                    this.escritorXml.WriteStartElement(etiqueta.ToString());
                    this.escritorXml.WriteValue(valor);
                    this.escritorXml.WriteEndElement();
                }
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo int.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, int valor)
        {
            this.escritorXml.WriteStartElement(etiqueta.ToString());
            this.escritorXml.WriteValue(valor);
            this.escritorXml.WriteEndElement();
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo bool.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, bool valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo null.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, DBNull valor)
        {
            this.escritorXml.WriteStartElement(etiqueta.ToString());
            this.escritorXml.WriteValue(null); //No funciona!! Para pasar un valor NULL, hay que utilizar string.Empty como argumento al llamar al método Add
            this.escritorXml.WriteEndElement();
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo datetime.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, DateTime valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo datetime.
        /// En el SQLServer se ha de utilizar la instrucción "convert(fecha, 126)"
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void AddFechaUniversal(string etiqueta, DateTime valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor.ToString("yyyyMMdd' 'HH':'mm':'ss.fff", DateTimeFormatInfo.InvariantInfo));
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo short.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, short valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo double.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, double valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo decimal.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, decimal valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un balor tipo string.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, string valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un valor tipo timespan.
        /// En el SQLServer se ha de utilizar un float puesto que se indica en milisegundos
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, TimeSpan valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartElement(etiqueta.ToString());
                this.escritorXml.WriteValue(valor.TotalMilliseconds);
                this.escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Funcion para añadir un campo tipo pasandole un valor tipo string
        /// </summary>
        /// <param name="etiqueta"></param>
        public void AddNull(string etiqueta)
        {
            this.escritorXml.WriteStartElement(etiqueta.ToString());
            this.escritorXml.WriteValue(@"xsi:nil=""true""");
            this.escritorXml.WriteEndElement();
        }

        /// <summary>
        /// Función para cerrar la etiqueta abierta.
        /// </summary>
        public void CerrarEtiqueta()
        {
            this.escritorXml.WriteEndElement();
        }
        /// <summary>
        /// Función para abrir el documento.
        /// </summary>
        public void AbrirDocumento()
        {
            this.escritorXml.WriteStartDocument();
        }
        /// <summary>
        /// Función para abrir el documento incluyendole una etiqueta inicial.
        /// </summary>
        /// <param name="etiqueta"></param>
        public void AbrirDocumento(string etiqueta)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.escritorXml.WriteStartDocument();
                this.escritorXml.WriteStartElement(etiqueta.ToString());
            }
        }
        /// <summary>
        /// Función para cerrar el documento abierto.
        /// </summary>
        public void CerrarDocumento()
        {
            this.escritorXml.WriteEndElement();
            this.escritorXml.Flush();
            this.escritorXml.Close();
            this.swXml.Flush();
        }
        /// <summary>
        /// Función para leer el documento almacenado. 
        /// </summary>
        /// <returns></returns>
        public XPathDocument LeerXml()
        {
            StringReader sr = new StringReader(this.swXml.ToString());
            XPathDocument xpathDoc = new XPathDocument(sr);
            sr.Close();
            return (xpathDoc);
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Elimina los recursos utilizados
        /// </summary>
        public void Dispose()
        {
            if (this.escritorXml != null)
            {
                this.escritorXml.Close();
                this.escritorXml = null;
            }
            if (this.swXml != null)
            {
                this.swXml.Close();
                this.swXml.Dispose();
                this.swXml = null;
            }
        }
        #endregion
    }
}