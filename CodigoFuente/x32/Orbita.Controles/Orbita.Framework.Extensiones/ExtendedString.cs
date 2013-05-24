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
    internal static class ExtendedString
    {
        #region Atributos internos estáticos
        /// <summary>
        /// Atributo estático volátil de bloqueo.
        /// </summary>
        internal static volatile object Bloqueo = new object();
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Desearializar el XML por el especifico System.String.
        /// </summary>
        /// <typeparam name="T">El tipo de objeto a deserializar.</typeparam>
        /// <param name="s">El System.String contenido en el XML.</param>
        /// <returns>El System.Object deserializado.</returns>
        public static T XmlDeserialize<T>(this string s)
        {
            System.IO.StringReader sr = null;
            try
            {
                lock (Bloqueo)
                {
                    sr = new System.IO.StringReader(s);
                    using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(sr))
                    {
                        //  Referencia: necesario para evitar CA2202: No aplicar Dispose a los objetos varias veces.
                        sr = null;
                        //  Serializa y deserializa objetos en y desde documentos XML.System.Xml.Serialization.XmlSerializer
                        //  permite controlar el modo en que se codifican los objetos en XML.
                        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                        T obj = (T)xmlSerializer.Deserialize(reader);
                        return obj;
                    }
                }
            }
            catch (System.Exception)
            {
                return default(T);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }
}