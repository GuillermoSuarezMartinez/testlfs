using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Orbita.MS.Licencias;
using System.Globalization;
using Aladdin.HASP;
using Orbita.MS.Excepciones;

namespace Orbita.MS.Clases.Licencias
{
    public class OGestorDispositivos
    {
        #region Atributos
        /// <summary>
        /// Instancias de licencias y dispositivos
        /// </summary>
        private static OInstanciaLicenciasOrbita _instancias = new OInstanciaLicenciasOrbita() { };
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Instancias de licencias y dispositivos
        /// </summary>
        public static OInstanciaLicenciasOrbita Instancias
        {
            get { return OGestorDispositivos._instancias; }
            set { OGestorDispositivos._instancias = value; }
        }
        #endregion Propiedades
        #region Constantes
        /// <summary>
        /// XML Scope genérico
        /// </summary>
        private const string XMLScopeGenerico = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspscope/>";
        /// <summary>
        /// XML Scope de un dispositivo en concreto para consultar
        /// </summary>
        /// <param name="idDipositivo">ID del dispositivo</param>
        /// <returns></returns>
        private static string XMLScopeDispositivo(string idDipositivo)
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspscope><hasp id=\"" + idDipositivo + "\" /></haspscope>";
        }
        /// <summary>
        /// Vendor Code predeterminado
        /// </summary>
        private const string vendorCode =
        "tAdmCzECOL/pdzqY2SWHxWhMQopof2o/v30hztddYBLEK+oMAgBBLmnpeNKtl21K8FYsIrDn0ZCfPIoZ" +
        "lUkwv8DRNnaGMe6AW7MxEAFs5U7jT5b7oE7orC8s+93ZDYA0yTlTJAs5iE4h7npOkhjRGImdy+xVzYgG" +
        "FOORltFS6A9BAUSHSgpq1cmBvYfdsE1tSZAufwfe+Qi1scccVNy/GeuelfroKQt1prF6BYIq8kRWb68H" +
        "FNRRJGQnotrU06XmUhO8LqJfnkLCLBrrGYZytK2/dfPqB7XmBaaYQ1Di8JMwg8xTTGO76cBDKuxud40P" +
        "opcVXsXinG2B4qshncS5aU5fDhUbd2byMpE6Xwc2ZnWE/GxuwYnMLNc51gdfn+c8iUtcumYw5Q2b1FnD" +
        "wkHIKK78QASf2ZHQtObLQGA5UIhiICvbplJ4+0ertgN2NOPWFDxwKJoOyaHb3MOK3ujTrlX472PNarc1" +
        "WIjQZXiuyLlGFDVHPeMi1zMnTC5TTNbpfwr3qbF9t27GJGcqFmwDOrX174IK78xGiXi00ARuRQCO+Wgo" +
        "vjwdZslXjUkH6F8uAHxpgdWWQ+BcYiaOVwNFZyLFqCAeUXFBrhIg+heLimn3hjpriQkqUPc0anzl3oKn" +
        "udy62yfb4iRyO250109AgkVJNjXFPTsPotdIjy5b44ceAGj8eC0FIigBxvzWEwDXuYQkH/5+sKpJ/szo" +
        "hG2lJG48R8sEnjqS3QIZ/geOZjwPEkRf667TDvgpP6kl0Qs1aBAMCx5Ys1fJss1D26Urel91khN9pgv4" +
        "eo0xlg8seszzpeiJOKLp/UKer/T2NqX9o+JOpKGsJDfPak/3N3YF60DER2iEZMXZtIwu/qUCnIh+4MYt" +
        "F3QD8nS+J401dtiEa3GwuMrd5hyUzuXcF8T6mEqKBxkIJCyckMloWh8E6lY=";

        /// <summary>
        /// Consulta de dispositivos disponibles
        /// </summary>
        private const string XML_HASP_Dispositivos = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspformat root=\"hasp_info\"><hasp><attribute name=\"id\" /><attribute name=\"type\" /></hasp></haspformat>";
        /// <summary>
        /// Consulta de productos disponibles
        /// </summary>
        private const string XML_HASP_Productos = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspformat><product><element name=\"id\"/><element name=\"name\"/></product></haspformat>";
        /// <summary>
        /// Consulta de características disponibles
        /// </summary>
        private const string XML_HASP_Caracteristicas = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspformat root=\"hasp_info\"><hasp><attribute name=\"id\" /><attribute name=\"type\" /><feature><attribute name=\"id\" /></feature></hasp></haspformat>";
        /// <summary>
        /// Consulta de validez de las licencias
        /// </summary>
        private const string XML_HASP_ValidezLicencias = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspformat root=\"hasp_info\"><feature><attribute name=\"id\" /><element name=\"license\" /><hasp><attribute name=\"id\" /><attribute name=\"type\" /></hasp></feature></haspformat>";
        /// <summary>
        /// Estructura de resultados
        /// </summary>
        public class OInstanciaLicenciasOrbita
        {
            public List<OLicenciaBase> licencias = new List<OLicenciaBase>() { };
            public List<OLicenciaCaracteristica> caracteristicas = new List<OLicenciaCaracteristica>() { };
            public List<OLicenciaProducto> productos  = new List<OLicenciaProducto>() { };
        }
        #endregion Constantes
        #region Métodos públicos
        /// <summary>
        /// Descubre las licencias HASP disponibles en el sistema.
        /// </summary>
        public static OInstanciaLicenciasOrbita DescubrirLicenciasHASP()
        {
            Dictionary<string, OLicenciaBase> eLicencias = new Dictionary<string, OLicenciaBase>() { };
            Dictionary<int, OLicenciaCaracteristica> eCaracteristcias = new Dictionary<int, OLicenciaCaracteristica>() { };
            Dictionary<int, OLicenciaProducto> eProductos = new Dictionary<int, OLicenciaProducto>() { };

            //Procesamos los dispositivos HASP activos:
            HaspStatus estado = HaspStatus.InternalError;
            string xdisp = ConsultaLicenciaHASPXML(XMLScopeGenerico, XML_HASP_Dispositivos, vendorCode, out estado);
            if (estado != HaspStatus.StatusOk)
            {
                throw new OExcepcionLicenciaHASP("Listar dispositivo.", estado.ToString(), xdisp);
            }
            foreach (OLicenciaBase lic in ProcesarXMLDisposisitosHASPConectados(xdisp))
            {
                //Consultamos los productos asociados
                string xprod = ConsultaLicenciaHASPXML(XMLScopeDispositivo(lic.IdDispositivoLicencia), XML_HASP_Productos, vendorCode, out estado);
                if (estado != HaspStatus.StatusOk)
                {
                    throw new OExcepcionLicenciaHASP("Listar productos de " + lic.IdDispositivoLicencia, estado.ToString(), xdisp);
                }
                foreach (OLicenciaProducto prod in ProcesarXMLProductos(xprod, lic.IdDispositivoLicencia))
                {
                    if (eProductos.ContainsKey(prod.Id))
                    {
                        //Ya existe un producto asociado
                        if (eProductos[prod.Id].DispositivoOrigen.Exists(x => x == lic.IdDispositivoLicencia))
                        {
                            //Ya se ha procesado producto para este dispositivo
                            continue;
                        }
                        else
                        {
                            //Ya existe este producto pero este nuevo dispositivo lo incluye
                            eProductos[prod.Id].DispositivoOrigen.Add(lic.IdDispositivoLicencia);
                            eProductos[prod.Id].IncrementarRecurso(1);
                        }
                    }
                    else
                    {
                        //Es la primera vez que aparece este producto
                        eProductos.Add(prod.Id, prod);
                        //eProductos[prod.Id].DispositivoOrigen.Add(lic.IdDispositivoLicencia);
                        eProductos[prod.Id].IncrementarRecurso(1);
                    }
                    lic.RefIDCaracteristicas.Add(prod.Id);
                }

                //Consultamos las características asociadas
                string xcar = ConsultaLicenciaHASPXML(XMLScopeDispositivo(lic.IdDispositivoLicencia), XML_HASP_Caracteristicas, vendorCode, out estado);
                if (estado != HaspStatus.StatusOk)
                {
                    throw new OExcepcionLicenciaHASP("Listar caracteristicas de " + lic.IdDispositivoLicencia, estado.ToString(), xdisp);
                }
                foreach (OLicenciaCaracteristica prod in ProcesarXMLCaracteristicas(xcar))
                {
                    if (eCaracteristcias.ContainsKey(prod.Id))
                    {
                        //Ya existe una característica asociada
                        if (eCaracteristcias[prod.Id].DispositivoOrigen.Exists(x => x == lic.IdDispositivoLicencia))
                        {
                            //Ya se ha procesado esta característica para este dispositivo
                            continue;
                        }
                        else
                        {
                            //Ya existe este producto pero este nuevo dispositivo lo incluye
                            eCaracteristcias[prod.Id].DispositivoOrigen.Add(lic.IdDispositivoLicencia);
                            eCaracteristcias[prod.Id].IncrementarRecurso(1);
                        }
                    }
                    else
                    {
                        //Es la primera vez que aparece este producto
                        eCaracteristcias.Add(prod.Id, prod);
                        //eCaracteristcias[prod.Id].DispositivoOrigen.Add(lic.IdDispositivoLicencia);
                        eCaracteristcias[prod.Id].IncrementarRecurso(1);
                    }
                    lic.RefIDCaracteristicas.Add(prod.Id);
                }
                //Registramos la licencia procesada.
                eLicencias.Add(lic.IdDispositivoLicencia, lic);
            }


            return new OInstanciaLicenciasOrbita()
            {
                licencias = eLicencias.Values.ToList<OLicenciaBase>(),
                productos = eProductos.Values.ToList<OLicenciaProducto>(),
                caracteristicas = eCaracteristcias.Values.ToList<OLicenciaCaracteristica>()

            };
        }
        /// <summary>
        /// Realiza una consulta XML utilizando la libreria HASP para comunicar con los dispositivos
        /// </summary>
        /// <param name="scope">Scope genérica/dispositivo</param>
        /// <param name="consulta">Consulta XML</param>
        /// <param name="vendorcode">VendorCode</param>
        /// <returns></returns>
        protected static string ConsultaLicenciaHASPXML(string scope, string consulta, string vendorcode, out HaspStatus salida)
        {
            string res = "";
            HaspStatus status = Hasp.GetInfo(scope, consulta, vendorcode, ref res);
            salida = status;
            return res;
        }
        /// <summary>
        /// Procesa el XML de productos/dispositivo
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        protected static List<OLicenciaProducto> ProcesarXMLProductos(string xml, string dispositivo = "")
        {

            xml = xml.Replace("\\", "");
            List<OLicenciaProducto> productos = new List<OLicenciaProducto>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                //reader.ReadToFollowing("xml");
                reader.ReadToFollowing("hasp_info");
                string valor = reader.Value;
                while (reader.ReadToFollowing("product"))
                {
                    reader.ReadToFollowing("id");
                    string id = reader.ReadElementContentAsString();
                    if (String.IsNullOrEmpty(id))
                    {
                        //En este caso, es una lectura nula. Ignoramos la entrada.
                        continue;
                    }
                    int pid = -1;
                    int.TryParse(id, out pid);
                    if (pid < 0)
                    {
                        //Entrada inválida
                        continue;
                    }
                    reader.ReadToFollowing("name");
                    //Normalizamos el nombre del producto.
                    string nombre = reader.ReadElementContentAsString();
                    nombre = DecodificarUTF8(nombre);
                    string nombreInterno = EliminarTildesNombre(nombre).Replace(" ", "");
                    OLicenciaProducto producto = new OLicenciaProducto(pid, nombreInterno);
                    producto.Nombre = nombre;
                    producto.DispositivoOrigen.Add(dispositivo);
                    productos.Add(producto);
                }

            }

            return productos;
        }
        /// <summary>
        /// Procesa el XML de caracteristicas/dispositivo
        /// </summary>
        /// <param name="xml">XML</param>
        /// <param name="dispositivo">ID del dispositivo</param>
        /// <returns></returns>
        protected static List<OLicenciaCaracteristica> ProcesarXMLCaracteristicas(string xml)
        {
            // Create an XmlReader
            xml = xml.Replace("\\", "");
            List<OLicenciaCaracteristica> caracteristica = new List<OLicenciaCaracteristica>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                //reader.ReadToFollowing("xml");
                reader.ReadToFollowing("hasp_info");
                string valor = reader.Value;
                while (reader.ReadToFollowing("hasp"))
                {
                    //reader.ReadToFollowing("id");
                    reader.MoveToFirstAttribute();
                    string dispositivo = reader.Value;
                    Console.WriteLine(dispositivo);
                    reader.MoveToNextAttribute();
                    string tipo = reader.Value;

                    while (reader.ReadToFollowing("feature"))
                    {
                        reader.MoveToFirstAttribute();
                        string id = reader.Value;
                        if (String.IsNullOrEmpty(id))
                        {
                            //En este caso, es una lectura nula. Ignoramos la entrada.
                            continue;
                        }
                        int pid = -1;
                        int.TryParse(id, out pid);
                        if (pid < 0)
                        {
                            //Entrada inválida
                            continue;
                        }

                        OLicenciaCaracteristica carac = new OLicenciaCaracteristica(pid, id.ToString());
                        carac.Nombre = id.ToString();
                        carac.DispositivoOrigen.Add(dispositivo);
                        caracteristica.Add(carac);

                    }
                }
            }

            return caracteristica;
        }
        /// <summary>
        /// Procesa el XML de caracteristicas/dispositivo
        /// </summary>
        /// <param name="xml">XML Consulta</param>
        /// <param name="dispositivo">ID del dispositivo</param>
        /// <returns></returns>
        protected static List<OLicenciaBase> ProcesarXMLDisposisitosHASPConectados(string xml)
        {
            // Create an XmlReader
            xml = xml.Replace("\\", "");
            List<OLicenciaBase> licencias = new List<OLicenciaBase>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                //reader.ReadToFollowing("xml");
                reader.ReadToFollowing("hasp_info");
                string valor = reader.Value;
                while (reader.ReadToFollowing("hasp"))
                {
                    reader.MoveToFirstAttribute();
                    string dispositivo = reader.Value;
                    Console.WriteLine(dispositivo);
                    reader.MoveToNextAttribute();
                    string tipo = reader.Value;
                    switch (tipo)
                    {
                        default:
                        case "HASP-HL":
                            OLicenciaHaspHLPro lic = new OLicenciaHaspHLPro();
                            lic.IdDispositivoLicencia = dispositivo;
                            licencias.Add(lic);
                            break;
                        case "HASP-SL":
                            OLicenciaHaspSL licS = new OLicenciaHaspSL();
                            licS.IdDispositivoLicencia = dispositivo;
                            licencias.Add(licS);
                            break;
                    }
                }
            }
            return licencias;
        }
        #endregion Métodos públicos
        #region Funciones auxiliares
        /// <summary>
        /// Decodifica las cadenas de texto en UTf8
        /// </summary>
        /// <param name="utf8String"></param>
        /// <returns></returns>
        private static string DecodificarUTF8(string utf8String)
        {
            byte[] utf8Bytes = new byte[utf8String.Length];
            for (int i = 0; i < utf8String.Length; ++i)
            {
                utf8Bytes[i] = (byte)utf8String[i];
            }

            return Encoding.UTF8.GetString(utf8Bytes, 0, utf8Bytes.Length);
        }
        /// <summary>
        /// Elimina las tildes en el nombre
        /// </summary>
        /// <param name="stIn"></param>
        /// <returns></returns>
        private static string EliminarTildesNombre(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        #endregion Funciones auxiliares
    }
}
