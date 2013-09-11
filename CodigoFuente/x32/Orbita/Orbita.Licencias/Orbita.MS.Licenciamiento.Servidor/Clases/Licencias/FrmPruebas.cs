using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aladdin.HASP;
using System.Xml;
using System.IO;
using Orbita.MS.Licencias;
using System.Globalization;
using Orbita.MS.Clases.Licencias;
using Orbita.MS.Excepciones;
namespace Orbita.MS.Licenciamiento.Servidor
{
    public partial class FrmPruebas : Form
    {
        public FrmPruebas()
        {
            InitializeComponent();
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
        }

        /// <summary>
        /// XML Scope genérico
        /// </summary>
        private string XMLScopeGenerico = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspscope/>";

        /// <summary>
        /// XML Scope de un dispositivo en concreto para consultar
        /// </summary>
        /// <param name="idDipositivo">ID del dispositivo</param>
        /// <returns></returns>
        private string XMLScopeDispositivo(string idDipositivo)
        {
            return  "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspscope><hasp id=\"" + idDipositivo + "\" /></haspscope>";
        }

        /// <summary>
        /// Vendor Code predeterminado
        /// </summary>
        string vendorCode =
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

        protected struct InstanciasLicenciasHASP
        {
            public List<OLicenciaBase> licencias;
            public List<OLicenciaCaracteristica> caracteristicas;
            public List<OLicenciaProducto> productos;
        }
        /// <summary>
        /// Descubre las licencias HASP disponibles en el sistema.
        /// </summary>
        protected InstanciasLicenciasHASP DescubrirLicenciasHASP()
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
                foreach (OLicenciaProducto prod in ProcesarXMLProductos(xprod,lic.IdDispositivoLicencia))
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
                }
                //Registramos la licencia procesada.
                eLicencias.Add(lic.IdDispositivoLicencia, lic);
            }


            return new InstanciasLicenciasHASP()
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
        protected string ConsultaLicenciaHASPXML(string scope, string consulta, string vendorcode, out HaspStatus salida)
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
        protected List<OLicenciaProducto> ProcesarXMLProductos(string xml, string dispositivo = "")
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
        /// Decodifica las cadenas de texto en UTf8
        /// </summary>
        /// <param name="utf8String"></param>
        /// <returns></returns>
        public static string DecodificarUTF8(string utf8String)
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
        static string EliminarTildesNombre(string stIn)
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

        private void button4_Click(object sender, EventArgs e)
        {
            string xmlOrigen = @"<?xml version=\""1.0\"" encoding=\""UTF-8\"" ?>
            <hasp_info>
              <hasp id=\""1280942\"" type=\""HASP-HL\"">
                <feature id=\""0\"" />
                <feature id=\""1\"" />
                <feature id=\""2\"" />
                <feature id=\""3\"" />
              </hasp>
              <hasp id=\""26914391\"" type=\""HASP-HL\"">
                <feature id=\""0\"" />
                <feature id=\""1\"" />
                <feature id=\""2\"" />
                <feature id=\""3\"" />
              </hasp>
            </hasp_info>
            ";
            List<OLicenciaBase> lic = ProcesarXMLDisposisitosHASPConectados(xmlOrigen);
            List<OLicenciaCaracteristica> carac = ProcesarXMLCaracteristicas(xmlOrigen);

            string mensaje = "Dispositivos:\r\n";
            foreach (OLicenciaBase l in lic) { mensaje += l + "\r\n"; };
            mensaje += "Características:\r\n";
            foreach (OLicenciaCaracteristica c in carac) { mensaje += c + "\r\n"; };
            MessageBox.Show(mensaje);
        }

        /// <summary>
        /// Procesa el XML de caracteristicas/dispositivo
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        protected List<OLicenciaCaracteristica> ProcesarXMLCaracteristicas(string xml)
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
        /// <param name="xml"></param>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        protected List<OLicenciaBase> ProcesarXMLDisposisitosHASPConectados(string xml)
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
                    switch(tipo)
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        EventoDispositivoEliminadoSistema(); 
                        break;
                    case UsbNotification.DbtDevicearrival:
                        EventoDispositivoNuevoSistema(); 
                        break;
                    case UsbNotification.WmDevicechange:
                        EventoDispositivoNuevoSistema();
                        break;
                }
            }
        }
        /// <summary>
        /// Se ha eliminado un dispositivo del sistema
        /// </summary>
        private void EventoDispositivoEliminadoSistema()
        {
            MessageBox.Show("Se ha quitado un dispositivo");
            DetectarDispositivos();
        }
        /// <summary>
        /// Un nuevo dispositivo se ha añadido al sistema
        /// </summary>
        private void EventoDispositivoNuevoSistema()
        {
            MessageBox.Show("Se ha añadido un dispositivo al sistema");
            DetectarDispositivos();
        }


        /// <summary>
        /// Detecta los dispositivos de licenciamiento y las características y productos asociados.
        /// </summary>
        protected void DetectarDispositivos()
        {
            try
            {
                InstanciasLicenciasHASP instancia = DescubrirLicenciasHASP();
                Console.WriteLine(instancia.licencias.ToString());
                string mensaje = "Licencias:\r\n";
                foreach (OLicenciaBase lic in instancia.licencias)
                {
                    mensaje += lic.ToString() + "\r\n";
                }
                mensaje += "Productos:\r\n";
                foreach (OLicenciaProducto prod in instancia.productos)
                {
                    mensaje += prod.ToString() + "\r\n";
                }
                mensaje += "Caracteristicas:\r\n";
                foreach (OLicenciaCaracteristica car in instancia.caracteristicas)
                {
                    mensaje += car.ToString() + "\r\n";
                }
                MessageBox.Show(mensaje);
            }
            catch (OExcepcionLicenciaHASP e0)
            {
                switch(e0.Data["Estado"].ToString())
                {
                    default:
                        MessageBox.Show(e0.Message);
                        break;
                    case "EmptyScopeResults":
                        MessageBox.Show("No hay dispositivos que contengan licencias conectados al sistema.");
                        break;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        #region Eventos UI
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DetectarDispositivos();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string xmlProductosDisponibles = "<haspformat><product><element name=\"id\"/><element name=\"name\"/></product></haspformat>";
            string xmlDispositivosCaracteristicasDisponibles = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><haspformat root=\"hasp_info\"><hasp><attribute name=\"id\" /><attribute name=\"type\" /><feature><attribute name=\"id\" /></feature></hasp></haspformat>";

            string info = null;
            string xmlValidezLicenciasDisponibles = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + "<haspformat root=\"hasp_info\">" + "<feature>" + "<attribute name=\"id\" />" + "<element name=\"license\" />" + "<hasp>" + "<attribute name=\"id\" />" + "<attribute name=\"type\" />" + "</hasp>" + "</feature>" + "</haspformat>" + "";
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + "<haspformatroot=\"hasp_info\">" + "<license_manager>" + "<element name=\"hostname\" />" + "<element name=\"ip\" />" + "<element name=\"osname\" />" + "</license_manager> " + "</haspformat>";
            string xmlUsoCaracteristicas =
            "<haspformat root=\"hasp_info\">" +
            "    <feature>" +
            "       <attribute name=\"id\" />" +
            "       <attribute name=\"locked\" />" +
            "       <attribute name=\"expired\" />" +
            "       <attribute name=\"disabled\" />" +
            "       <attribute name=\"usable\" />" +
            "    </feature>" +
            "</haspformat>";

            string format =
            "<haspformat root=\"location\">" +
            "    <license_manager>" +
            "        <attribute name=\"id\" />" +
            "        <attribute name=\"time\" />" +
            "        <element name=\"hostname\" />" +
            "        <element name=\"version\" />" +
            "        <element name=\"host_fingerprint\" />" +
            "     </license_manager>" +
            "</haspformat>";
            format = "<haspformat format=\"updateinfo\"/>";


            XMLScopeGenerico =
            "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
            "<haspscope>" +
            " <hasp id=\"26914391\" />" +
            "</haspscope>" +
            "";

            HaspStatus status = Hasp.GetInfo(XMLScopeGenerico, xmlUsoCaracteristicas, vendorCode, ref info);

            if (HaspStatus.StatusOk != status)
            {
                //handle error
            }

            /*HaspFeature feature = HaspFeature.FromFeature(3);

            string vendorCode =
            "nDziMIFvJOlsEoaQsgo91ii7QN2rTwS91Fd5n6KsPtAGGUaYE+M7v54JBT7VO7AhETH5yW+Q8SvAMTMQ" +
            "u8Sbw9xkbCRjGA+aDqdCgj2V1Xtos+TB7Z71EfiPOK4tmqZxfHwvK3Ybe2w3cuc/oDzHhBsCBlNcYDNs" +
            "sybWuDanQvmZV6RD9wUg1Nnn5viuoVdn4dlhACKLkn1RUg/buPmBaZp4p3luE6R0dWYMEvU671b3Hkxf" +
            "ZICjxhMRd4fq2QpvEJX9nd5UPfBykbG3oqp12apD+K4x/DBBBt3R+oV3NLNeDBw2jTkbKqBmrFfe2dDU" +
            "QNDDYrYHa8HqhK72dQNvambAEpdVjTFRif7cZWdlvOS+FxHrAw2SXrmC/wohjAMFW+PqFZCj+cqwda3+" +
            "7gF8MyeaP4+843lEer/pqiAiD1elM0BTmE8XXnKEdNIK/4QRDrsJqAfzWhsmMJHedZow75jUGtkg/YGB" +
            "ZTmBGQ4+HoVnOa3rURjQi+5Ij+CBjPsFralg/GQIg6mNpRv6UYJh/Sdv7H01e9G/EZOgtqbSu7Kfw6KE" +
            "fFca+3xE5dDwqFT42/HSTidNLDcK5Q5sKBorFI6uUGC4KUM6D5YfDHdL8/okNcKYNI3g/VVuU3eBZY+7" +
            "67iQwVyppJwejXa6lNWv4zixH7aWjw1/WVyOslyjPxHGCTTSabltvLFQbfLQBSaaKCnEGM0VV26W6nFi" +
            "cZm5VOFs0xmInr7bLloa9PpHiJ54ehOQTs/xESmcN3Z9kEHS9wWxIHrwpnYAzlb4xYM7BhMj2BfZByd0" +
            "qX10XbzIRreQa3/nM8A40H1Ods4O5wBmIZkKK8Q8qZecXP/K/hMNvwuA+iCg1g2LyJ2HUKqrhIGXxib9" +
            "4mV04tPfRKbKjVVhzSxZKOPPjpr/S8HGCtWIDjz7dqyaGl+6RUqMU+1jK1c=";

            Hasp hasp = new Hasp(feature);
            HaspStatus status = hasp.Login(vendorCode);

            if (HaspStatus.StatusOk != status)
            {
                //handle error
            }*/
        }



        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();

            String xmlOrigen =
                @"<?xml version=\""1.0\"" encoding=\""UTF-8\"" ?>
            <hasp_info>
              <product>
                <id>2</id>
                <name>ProtecciÃ³n BÃ¡sica</name>
              </product>
              <product>
                <id>3</id>
                <name>Lectura LPR</name>
              </product>
              <product>
                <id>4</id>
                <name>Lectura OCR</name>
              </product>
            </hasp_info>
            ";

            string xmlFinal = "";
            foreach (OLicenciaProducto prod in ProcesarXMLProductos(xmlOrigen, ""))
            {
                xmlFinal += prod.ToString() + "|";
            }
            Console.WriteLine(xmlFinal);
            MessageBox.Show(xmlFinal);
        }
        #endregion
    }
}
