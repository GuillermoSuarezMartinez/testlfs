//***********************************************************************
// Assembly         : Orbita.Framework.Core
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Extensiones
{
    public static class ExtendedObject
    {
        #region Atributos internos estáticos
        /// <summary>
        /// Atributo estático volátil de bloqueo.
        /// </summary>
        internal static volatile object Bloqueo = new object();
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Determina si el System.Object figura en el IEnumerable especificado.
        /// </summary>
        /// <param name="ocomparable">El System.Object</param>
        /// <param name="enumerable">El enumerable.</param>
        /// <returns>Verdadero si el enumerable contiene el System.Object, falso en caso contrario.</returns>
        public static bool In(this object ocomparable, System.Collections.IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                foreach (object item in enumerable)
                {
                    if (item.Equals(ocomparable))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Determina si el T figura en el IEnumerable de T especificado.
        /// </summary>
        /// <typeparam name="T">El tipo de System.Object.</typeparam>
        /// <param name="ocomparable">El item.</param>
        /// <param name="enumerable">El enumerable de T.</param>
        /// <returns>Verdadero si el enumerable contiene el item, falso en caso contrario.</returns>
        public static bool In<T>(this T ocomparable, System.Collections.Generic.IEnumerable<T> enumerable)
        {
            if (enumerable != null)
            {
                foreach (T item in enumerable)
                {
                    if (item.Equals(ocomparable))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Determina si el T figura en los valores especificados.
        /// </summary>
        /// <typeparam name="T">El tipo System.Object.</typeparam>
        /// <param name="ocomparable">Item.</param>
        /// <param name="items">El valor a comparar.</param>
        /// <returns>Verdadero si el valor contiene el item, falso en caso contrario.</returns>
        public static bool In<T>(this T ocomparable, params T[] items)
        {
            if (items != null)
            {
                foreach (T item in items)
                {
                    if (item.Equals(ocomparable))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Serializa el System.Object especificado y escribe el documento XML en el fichero especificado.
        /// </summary>
        /// <typeparam name="T">El tipo item.</typeparam>
        /// <param name="item">El item.</param>
        /// <param name="fileName">El fichero donde escribir.</param>
        /// <returns>Verdadero si todo ha ido bien, falso en caso contrario.</returns>
        public static bool XmlSerialize<T>(this T item, string fileName)
        {
            System.IO.FileStream fs = null;
            bool resultado = false;
            try
            {
                System.Xml.Serialization.XmlSerializerNamespaces xmlns = new System.Xml.Serialization.XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                lock (Bloqueo)
                {
                    using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(fileName, settings))
                    {
                        xmlSerializer.Serialize(writer, item, xmlns);
                    }
                    resultado = true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            return resultado;
        }
        #endregion
    }
}