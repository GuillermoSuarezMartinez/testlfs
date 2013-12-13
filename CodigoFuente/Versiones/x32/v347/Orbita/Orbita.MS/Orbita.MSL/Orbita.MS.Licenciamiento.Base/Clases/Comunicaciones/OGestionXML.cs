using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using Orbita.Xml;
using System.Collections.Generic;
namespace Orbita.MS
{
    /// <summary>
    /// Gestiona las operaciones con XML propias de la serialización/deserialización, cifrado/descifrado de comunicaciones.
    /// </summary>
    public class OGestionXML
    {
        /// <summary>
        /// Lectura de objeto serializado en un fichero
        /// </summary>
        /// <param name="fichero"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static Object LeerObjetoXMLFichero(string fichero, System.Type tipo)
        {
            Object res = null;
            TextReader reader = new StreamReader(fichero);
            XmlSerializer serializer = new XmlSerializer(tipo);
            res = serializer.Deserialize(reader);
            reader.Close();
            return res;
        }
        /// <summary>
        /// Serialización y escritura de objeto a fichero
        /// </summary>
        /// <param name="fichero"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool EscribirObjetoXMLFichero(string fichero, Object obj)
        {
            try
            {
              
                TextWriter writer = new StreamWriter(fichero);
                System.Type tipo = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(tipo);
                serializer.Serialize(writer,obj);
                writer.Close();
                return true;
                
            }
            catch (Exception e1)
            {
                Console.WriteLine("[!] " + e1);
                return false;
            }

           
        }

        /// <summary>
        /// Serialización de un ArrayList (codificación a cadena)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tipos"></param>
        /// <returns></returns>
        public static string SerializarArrayListCadena(ArrayList obj, System.Type[] tipos)
        {
            return SerializaArrayList(obj, tipos, new System.IO.MemoryStream());

        }

        /// <summary>
        /// Serialización de un ArrayList y escritura posterior a fichero
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tipos"></param>
        /// <param name="fichero"></param>
        /// <returns></returns>
        public static bool SerializarArrayListFichero(ArrayList obj, System.Type[] tipos, string fichero)
        {
            TextWriter writer = new StreamWriter(fichero,false);
            
            System.Type tipo = obj.GetType();
            System.Xml.XmlDocument doc = new XmlDocument();
            Type[] extraTypes = tipos;
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ArrayList), extraTypes);
            try
            {
                serializer.Serialize(writer, (ArrayList)obj);
            }
            catch(Exception e1) 
            {
                throw e1; 
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Serializa un ArrayList a cadena
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tipos"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string SerializaArrayList(ArrayList obj, System.Type[] tipos, Stream stream)
        {
            System.Xml.XmlDocument doc = new XmlDocument();
            Type[] extraTypes = tipos;
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ArrayList), extraTypes);
            try
            {
                serializer.Serialize(stream, (ArrayList)obj);
                stream.Position = 0;
                doc.Load(stream);
                return doc.InnerXml;
            }
            catch { throw; }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
        }
        /// <summary>
        /// Deserializa una cadena a ArrayList de objetos compuestos
        /// </summary>
        /// <param name="fichero"></param>
        /// <param name="tipos"></param>
        /// <returns></returns>
        public static ArrayList DeSerializarArrayListFichero(string fichero, System.Type[] tipos)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(fichero);


                string cadena = reader.ReadToEnd();

                ArrayList res = DeSerializarArrayListCadena(cadena, tipos);

                reader.Close();
                reader.Dispose();
                return res;
            }
            catch (Exception)
            {

                try
                {
                    reader.Close();
                    reader.Dispose();
                }
                catch (Exception) { }
                return new ArrayList();
            }
        }
        /// <summary>
        /// Deserializa un ArrayList de objetos compuestos
        /// </summary>
        /// <param name="stringSerializado"></param>
        /// <param name="tipos"></param>
        /// <returns></returns>
        public static ArrayList DeSerializarArrayListCadena(string stringSerializado, System.Type[] tipos)
        {
            ArrayList list = new ArrayList();
            
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ArrayList), tipos);
            XmlReader xReader = XmlReader.Create(new StringReader(stringSerializado));
            try
            {
                object obj = serializer.Deserialize(xReader);
                list = (ArrayList)obj;
            }
            catch
            {
                throw;
            }
            finally
            {
                xReader.Close();
            }
            return list;
        }
        ///// <summary>
        ///// Serializa cifrando la información con un fichero de certificado X509
        ///// </summary>
        ///// <param name="ficheroXML"></param>
        ///// <param name="ficheroCert"></param>
        ///// <returns></returns>
        //public static XmlDocument CifrarXMLX509(string ficheroXML, string ficheroCert)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.PreserveWhitespace = true;
        //    xmlDoc.Load(ficheroXML);

        //    X509CertificateCollection certs = new X509CertificateCollection();
        //    X509Certificate2 cert = null;
        //    cert = new X509Certificate2(@"Certificado.pfx", "contraseña");
        //    cert.FriendlyName = "Lic_Cert";
        //    certs.Add(cert);

        //    XmlElement elem = xmlDoc.DocumentElement;

        //    EncryptedXml eXml = new EncryptedXml();

        //    // Encrypt the element.
        //    EncryptedData elemCifr = eXml.Encrypt(elem, cert);


        //    EncryptedXml.ReplaceElement(elem, elemCifr, false);

        //    xmlDoc.Save(ficheroXML + ".dll");

        //    return xmlDoc;

        //}

    }
}
    

