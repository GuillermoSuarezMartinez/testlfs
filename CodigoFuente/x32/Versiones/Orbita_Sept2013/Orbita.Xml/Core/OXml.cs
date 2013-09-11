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
using System.Collections.Generic;
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
        /// <summary>
        /// Se ha ejecutado el dispose
        /// </summary>
        bool _disposed = false;
        /// <summary>
        /// String con xml almacenado
        /// </summary>
        string _xmlDato;
        /// <summary>
        /// Propiedades del reader
        /// </summary>
        XmlReaderSettings _settings;
        /// <summary>
        /// Listado de Subnodos del nodo principal del objeto
        /// </summary>
        Dictionary<string, string> _subNodos;
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
            this._xmlDato = string.Empty;
            this._subNodos = new Dictionary<string, string>();
            //asignamos las propiedades del reader para procesar el xml
            _settings = new XmlReaderSettings();
            //se ignoran los comentarios
            _settings.IgnoreComments = true;
            //se ignoran los espacios en blanco
            _settings.IgnoreWhitespace = true;
            _settings.ValidationType = ValidationType.None;
            _settings.IgnoreProcessingInstructions = true;
            _settings.CheckCharacters = false;
        }
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="_xmlDato">xml a procesar</param>
        public OXml(string _xmlDato)
        {
            this.swXml = new StringWriter(CultureInfo.CurrentCulture);
            this.escritorXml = new XmlTextWriter(this.swXml);
            this._xmlDato = _xmlDato;
            this._subNodos = new Dictionary<string, string>();
            //asignamos las propiedades del reader para procesar el xml
            _settings = new XmlReaderSettings();
            //se ignoran los comentarios
            _settings.IgnoreComments = true;
            //se ignoran los espacios en blanco
            _settings.IgnoreWhitespace = true;
            _settings.ValidationType = ValidationType.None;
            _settings.IgnoreProcessingInstructions = true;
            _settings.CheckCharacters = false;
        }
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="_xmlDato">xml a procesar</param>
        /// <param name="carga" > si se va ha realizar recarga </param>
        public OXml(string _xmlDato, bool carga)
        {
            this.swXml = new StringWriter(CultureInfo.CurrentCulture);
            this.escritorXml = new XmlTextWriter(this.swXml);
            this._subNodos = new Dictionary<string, string>();
            //asignamos las propiedades del reader para procesar el xml
            _settings = new XmlReaderSettings();
            //se ignoran los comentarios
            _settings.IgnoreComments = true;
            //se ignoran los espacios en blanco
            _settings.IgnoreWhitespace = true;
            _settings.ValidationType = ValidationType.None;
            _settings.IgnoreProcessingInstructions = true;
            _settings.CheckCharacters = false;
            if (carga)
                LoadXml(_xmlDato);
            else
                this._xmlDato = _xmlDato;
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
        /// <summary>
        /// Devuelve el número de hijos del arbol
        /// </summary>
        public int NumChildren
        {
            get { return NumeroHijos(); }
        }
        /// <summary>
        /// Devuelve el string del xml
        /// </summary>
        public string XmlDato
        {
            get { return this._xmlDato; }
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
        /// <summary>
        /// Carga el xml, realiza acciones iniciales
        /// </summary>
        /// <param name="datoXML">dato xml como string</param>
        /// <returns>carga correcta</returns>
        public bool LoadXml(string datoXML)
        {
            try
            {
                _subNodos.Clear();
                this._xmlDato = datoXML;
                //cuenta el número de hijos, se obtiene su nombre y el xml asociado
                using (XmlReader reader = XmlReader.Create(new StringReader(datoXML), _settings))
                {
                    int profundidadHijo = reader.Depth + 1;
                    //la variable iteraciones se utiliza por si hay subnodos con el mismo nombre (para diferenciarlos en el diccionario)
                    int iteraciones = 0;
                    //Se inicia el recorrido del xml, en la carga inicial se gestionan los subnodos
                    reader.MoveToContent();
                    if (reader.Read())
                    {
                        while (true)
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                //si es un hijo
                                if (reader.Depth == profundidadHijo)
                                {
                                    iteraciones++;
                                    string key = string.Empty;
                                    //se añade al diccionario y se salta al siguiente hijo
                                    //comprueba si existe un nodo en el diccionario con el mismo nombre para añadir índice
                                    //el indíce es interno, no afecta a las búsquedas
                                    if (_subNodos.TryGetValue(reader.Name, out key))
                                        _subNodos.Add(reader.Name + "[" + iteraciones.ToString() + "]", reader.ReadOuterXml());
                                    else
                                        _subNodos.Add(reader.Name, reader.ReadOuterXml());
                                }
                                else//si se ha profundizado mas de lo necesario salimos del bucle
                                {
                                    break;
                                }
                            }
                            else if (!reader.Read())//si no hay mas elementos a leer salimos del bucle
                            {
                                break;
                            }
                        }
                    }
                    reader.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Obtiene un nodo a partir de una ruta pasada como parámetro, separadas las etiquetas por |.
        /// </summary>
        /// <param name="rutaPathEtiquetas">Relativa a las etiquetas tipo "Presupuesto|Partida|IdPartida", sin añadimos "Presupuesto|Partida[2]|IdPartida iriamos al 3 elemento</param>
        /// <returns>valor del nodo a buscar</returns>
        public string GetNodo(string rutaPathEtiquetas)
        {
            int i = 0;
            //Array con la ruta del nodo a buscar, cada etiqúeta separada por símbolo '|'
            string[] r = rutaPathEtiquetas.Split('|');
            string valor = string.Empty;
            //indica índice del nodo (si hay varios con el mismo nombre buscara el nodo numero...)
            int nodo = 0;

            using (XmlReader reader = XmlReader.Create(new StringReader(this._xmlDato), _settings))
            {
                reader.MoveToContent();

                //se recorre el array buscando los elementos (se avanza en el reader cuando es necesario)
                while (i < r.Length)
                {
                    //se comprueba si el nodo tiene índice
                    if (r[i].Contains("["))
                    {
                        nodo = Convert.ToInt32(r[i].Substring(r[i].IndexOf("[") + 1, 1));
                        r[i] = r[i].Substring(0, r[i].IndexOf("["));
                    }
                    //se busca el siguiente nodo con nombre de elemento en array
                    if (reader.ReadToFollowing(r[i]))
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            //si es el último elemento se obtiene el valor
                            if (i == r.Length - 1)
                            {
                                valor = reader.ReadString();
                                break;
                            }//si no es el último elemento se avanza al siguiente
                            else if (nodo == 0)
                            {
                                reader.MoveToElement();
                                i++;
                            }
                            else//si el nodo tiene índice (ej. [2]) se avanza al siguiente nodo con mismo nombre (i no se incrementa)
                                nodo--;
                        }
                    }
                    else
                        break;
                }

                reader.Close();
            }

            return valor != string.Empty ? valor : null;
        }
        /// <summary>
        /// Comprueba si el xml contiene un nodo con un nombre dado
        /// </summary>
        /// <param name="etiqueta">nombre del nodo</param>
        /// <returns>nodo existe</returns>
        public bool ContieneNodo(string etiqueta)
        {
            string key = string.Empty;
            //se busca la etiqueta en el diccionario de subnodos
            if (_subNodos.TryGetValue(etiqueta, out key))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Comprueba si el xml contiene un atributo con un nombre dado
        /// </summary>
        /// <param name="valor">Nombre del Atributo</param>
        /// <returns>atributo existe</returns>
        public bool ContieneAtributo(string valor)
        {
            string atributo = string.Empty;
            using (XmlTextReader reader = new XmlTextReader(new StringReader(this._xmlDato)))
            {
                reader.MoveToContent();
                bool att = reader.HasAttributes;
                atributo = reader.GetAttribute(valor);
                reader.Close();
            }
            return atributo != string.Empty && atributo != null ? true : false;
        }
        /// <summary>
        /// Calcula el número de hijos de un nodo
        /// </summary>
        /// <returns>numero de hijos</returns>
        public int NumeroHijos()
        {
            return _subNodos.Count;
        }
        /// <summary>
        /// Obtiene el subarbol con el indice pasado por parámetro (desde nodo raiz).
        /// </summary>
        /// <param name="id">indice del subarbol</param>
        /// <returns></returns>
        public string ObtenerNodoHijo(int id)
        {
            string resultado = null;
            if (_subNodos.Count >= id + 1)
            {
                //Como el diccionario no utiliza índices estos se gestionan desde un array
                string[] keys = new string[_subNodos.Count];
                _subNodos.Keys.CopyTo(keys, 0);
                resultado = _subNodos[keys[id]].ToString();
            }
            return resultado;
        }
        /// <summary>
        /// Obtiene el subarbol con el nombre pasado por parámetro(desde nodo raiz).
        /// </summary>
        /// <param name="etiqueta">indice del subarbol</param>
        /// <returns></returns>
        public string ObtenerNodoHijo(string etiqueta)
        {
            string resultado = null; string key = string.Empty;
            //se busca el subnodo por nombre como key
            if (_subNodos.TryGetValue(etiqueta, out key))
            {
                resultado = _subNodos[etiqueta].ToString();
            }
            return resultado;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Elimina los recursos utilizados
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
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
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finalizador de la clase, llama a dispose
        /// </summary>
        ~OXml()
        {
            Dispose(false);
        }

        /// <summary>
        /// Elimina los recursos utilizados, se comprueba si se ha llamado para no realizarlo 2 veces
        /// </summary>
        /// <param name="disposing"></param>
        void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._xmlDato = string.Empty;
                    this._xmlDato = null;
                    this._subNodos.Clear();
                    this._subNodos = null;
                }
            }
            _disposed = true;
        }
        #endregion
    }
}