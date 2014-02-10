using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.XPath;
namespace Orbita.Xml
{
    /// <summary>
    /// Clase utilizada para componer XML en memoria.
    /// </summary>
    public sealed class CXml : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Se ha ejecutado el dispose.
        /// </summary>
        bool _disposed = false;
        /// <summary>
        /// Variable escrita en el Xml.
        /// </summary>
        StringWriter m_swXml;
        /// <summary>
        /// Variable para escribir el XML.
        /// </summary>
        XmlTextWriter m_escritorXml;
        /// <summary>
        /// Variable para contener el XML para lectura, NO carga el xml en memoria, almacena el string.
        /// </summary>
        public OXml m_xml;
        #endregion Atributos

        #region Constructores
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CXml()
        {
            // Para escritura.
            this.m_swXml = new StringWriter(CultureInfo.CurrentCulture);
            this.m_escritorXml = new XmlTextWriter(this.m_swXml);
            // Para lectura.
            m_xml = new OXml();
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Propiedad para acceder al Stringwriter.
        /// </summary>
        public StringWriter SWXml
        {
            get { return this.m_swXml; }
            set { this.m_swXml = value; }
        }
        /// <summary>
        /// Propiedad para acceder al XmlTextWriter.
        /// </summary>
        public XmlTextWriter EscritorXml
        {
            get { return this.m_escritorXml; }
            set { this.m_escritorXml = value; }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Para abrir una nueva etiqueta del Xml.
        /// </summary>
        /// <param name="etiqueta">Nombre Etiqueta a abrir</param>
        public void AbrirEtiqueta(string etiqueta)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
            }
        }
        /// <summary>
        /// Funcion para añadir una propiedad tipo string.
        /// </summary>
        /// <param name="etiqueta"></param>
        public void Add(string etiqueta)
        {
            this.m_escritorXml.WriteStartElement(etiqueta.ToString());
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo object.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, object valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo int.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, int valor)
        {
            this.m_escritorXml.WriteStartElement(etiqueta.ToString());
            this.m_escritorXml.WriteValue(valor);
            this.m_escritorXml.WriteEndElement();
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo bool.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, bool valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo null.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, DBNull valor)
        {
            this.m_escritorXml.WriteStartElement(etiqueta.ToString());
            this.m_escritorXml.WriteValue(null); //No funciona!! Para pasar un valor NULL, hay que utilizar string.Empty como argumento al llamar al método Add
            this.m_escritorXml.WriteEndElement();
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo datetime.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, DateTime valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo short.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, short valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo double.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, double valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo decimal.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, decimal valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para añadir un campo tipo pasandole un balor tipo string.
        /// </summary>
        /// <param name="etiqueta"></param>
        /// <param name="valor"></param>
        public void Add(string etiqueta, string valor)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
                this.m_escritorXml.WriteValue(valor);
                this.m_escritorXml.WriteEndElement();
            }
        }
        /// <summary>
        /// Función para cerrar la etiqueta abierta.
        /// </summary>
        public void CerrarEtiqueta()
        {
            this.m_escritorXml.WriteEndElement();
        }
        /// <summary>
        /// Función para abrir el documento.
        /// </summary>
        public void AbrirDocumento()
        {
            this.m_escritorXml.WriteStartDocument();
        }
        /// <summary>
        /// Función para abrir el documento incluyendole una etiqueta inicial.
        /// </summary>
        /// <param name="etiqueta"></param>
        public void AbrirDocumento(string etiqueta)
        {
            if (!string.IsNullOrEmpty(etiqueta))
            {
                this.m_escritorXml.WriteStartDocument();
                this.m_escritorXml.WriteStartElement(etiqueta.ToString());
            }
        }
        /// <summary>
        /// Función para cerrar el documento abierto.
        /// </summary>
        public void CerrarDocumento()
        {
            this.m_escritorXml.WriteEndElement();
            this.m_escritorXml.Flush();
            this.m_escritorXml.Close();
            this.m_swXml.Flush();
        }
        /// <summary>
        /// Función para leer el documento almacenado. 
        /// </summary>
        /// <returns></returns>
        public XPathDocument LeerXml()
        {
            StringReader sr = new StringReader(this.m_swXml.ToString());
            XPathDocument xpathDoc = new XPathDocument(sr);
            sr.Close();
            return (xpathDoc);
        }
        #endregion

        #region Métodos públicos lectura
        /// <summary>
        /// Cargamos el Xml con el string pasado por parámetro.
        /// </summary>
        /// <param name="datoXml">String con el XML</param>
        /// <returns>Carga correcta.</returns>
        public bool CargarXml(string datoXml)
        {
            return this.m_xml.LoadXml(datoXml);
        }
        /// <summary>
        /// Para obtener el valor de un nodo a través de su ruta separadas las etiquetas por |.
        /// </summary>
        /// <param name="rutaPath">Relativa a las etiquetas tipo "Presupuesto|Partida|IdPartida", sin añadimos "Presupuesto|Partida[2]|IdPartida iriamos al 3 elemento</param>
        /// <returns>Nodo.</returns>
        public string ObtenerNodo(string rutaPathEtiquetas)
        {
            return this.m_xml.GetNodo(rutaPathEtiquetas);
        }
        /// <summary>
        /// Para obtener el valor de un nodo en double a través de su ruta separadas las etiquetas por |.
        /// </summary>
        /// <param name="rutaPath">Relativa a las etiquetas tipo "Presupuesto|Partida|IdPartida", sin añadimos "Presupuesto|Partida[2]|IdPartida iriamos al 3 elemento</param>
        /// <returns>Valor double nodo.</returns>
        public double ObtenerNodoDouble(string rutaPathEtiquetas)
        {
            string cadena = this.m_xml.GetNodo(rutaPathEtiquetas);
            if (cadena == null)
            {
                return 0;
            }
            cadena = cadena.Replace(".", ",");
            double aux = Convert.ToDouble(cadena);
            return aux;
        }
        /// <summary>
        /// Para obtener el valor de un nodo en boolean a través de su ruta separadas las etiquetas por |.
        /// </summary>
        /// <param name="rutaPath">Relativa a las etiquetas tipo "Presupuesto|Partida|IdPartida", sin añadimos "Presupuesto|Partida[2]|IdPartida iriamos al 3 elemento</param>
        /// <returns>Valor nodo bool.</returns>
        public bool ObtenerNodoBool(string rutaPathEtiquetas)
        {
            if (this.m_xml.GetNodo(rutaPathEtiquetas) == "1")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Obtenemos el subarbol con la etiqueta pasada por parametro como nodo raiz.
        /// </summary>
        /// <param name="etiqueta">Etiqueta deseada para el subarbol.</param>
        /// <returns>Objeto oxml con subarbol.</returns>
        public OXml ObtenerSubArbol(string etiqueta)
        {
            return new OXml(this.m_xml.ObtenerNodoHijo(etiqueta), true);
        }
        /// <summary>
        /// Obtenemos el subarbol con el indice pasado por parámetro.
        /// </summary>
        /// <param name="etiqueta">Etiqueta deseada para el subarbol</param>
        /// <returns>Objeto oxml con subarbol.</returns>
        public OXml ObtenerSubArbol(int id)
        {
            return new OXml(this.m_xml.ObtenerNodoHijo(id), true);
        }
        /// <summary>
        /// Devuelve el numero de hijos que contiene el árbol.
        /// </summary>
        /// <returns>Numero hijos.</returns>
        public int NumeroHijos()
        {
            return this.m_xml.NumChildren;
        }
        /// <summary>
        /// Comprueba si el XML tiene un subnodo (nodo hijo) con el nombre pasado como parámetro.
        /// </summary>
        /// <param name="etiqueta">Nombre nodo a buscar.</param>
        /// <returns>Si el nodo existe.</returns>
        public bool TieneSubarbol(string etiqueta)
        {
            return this.m_xml.ContieneNodo(etiqueta);
        }
        /// <summary>
        /// Comprobación para saber si tiene un campo dentro con la etiqueta pasada por parametro.
        /// </summary>
        /// <param name="etiqueta">Campo a buscar.</param>
        /// <returns></returns>
        public bool TieneCampo(string etiqueta)
        {
            return this.m_xml.ContieneAtributo(etiqueta);
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Finalizador de la clase, llama a dispose
        /// </summary>
        ~CXml()
        {
            Dispose(false);
        }
        /// <summary>
        /// Elimina los recursos utilizados
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            //se gestiona la cola de objetos a eliminar, el objeto se saca de la cola
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Elimina los recursos utilizados, se comprueba si se ha llamado para no realizarlo 2 veces
        /// </summary>
        /// <param name="disposing">ejecutar dispose (si/no)</param>
        void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (this.m_escritorXml != null)
                    {
                        this.m_escritorXml.Close();
                    }
                    if (this.m_swXml != null)
                    {
                        this.m_swXml.Close();
                        this.m_swXml.Dispose();
                    }
                    if (this.m_xml != null)
                    {
                        this.m_xml.Dispose();
                    }

                }
                _disposed = true;
            }
        }
        #endregion
    }
}