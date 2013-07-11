using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Remoting.Channels;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase estática de métodos remoting.
    /// </summary>
    [Serializable]
    public static class ORemoting
    {
        #region Atributos

        /// <summary>
        /// Valor de inicialización.
        /// </summary>
        readonly static bool Inic = false;
        /// <summary>
        /// Colección de  tipos  conocidos
        /// en el establecimiento remoting.
        /// </summary>
        static IDictionary WellKnownTypes;

        #region Constantes
        /// <summary>
        /// Ruta de configuración general.
        /// </summary>
        const string CONFIG = @"\Config";
        /// <summary>
        /// Ruta de configuración de servidor
        /// y cliente para .NET Remoting.
        /// </summary>
        const string REMOTING = @"\Config\remoting";
        #endregion

        #endregion

        #region Métodos públicos estáticos
        /// <summary>
        /// Método de inicialización del configurador de servidor para .NET Remoting.
        /// </summary>
        /// <param name="espacioDEnombres">Espacio de nombres del ensamblado.</param>
        /// <param name="clase">Nombre de la clase.</param>
        /// <param name="puerto">Puerto de salidad de datos.</param>
        /// <param name="canal"></param>
        public static string InicConfiguracionServidor(string espacioDEnombres, string clase, int puerto, string canal)
        {
            // Obtener el nombre del ensamblado.
            AssemblyName ensamblado = Assembly.GetExecutingAssembly().GetName();

            // Crear el documento Xml.
            XmlDocument doc = new XmlDocument();
            
            doc.LoadXml(string.Format(CultureInfo.CurrentCulture,
                @"<?xml version='1.0' encoding='utf-8' ?>" +
                 "<configuration>" +
                    "<system.runtime.remoting>" +
                        "<application>" +
                            "<channels>" +
                                "<channel name=\"{4}\" ref=\"tcp\" port=\"{0}\">" +
                                    "<serverProviders><provider ref=\"wsdl\" /><formatter ref=\"soap\" typeFilterLevel=\"Full\" /><formatter ref=\"binary\" typeFilterLevel=\"Full\" />" +
                                    "</serverProviders>" +
                                "</channel>" +
                            "</channels>" +
                            "<service><wellknown mode=\"Singleton\" type=\"{1}.{2}, {1}\" objectUri=\"{3}.soap\" />" +
                            "</service>" +
                        "</application>" +
                    "</system.runtime.remoting>" +
                 "</configuration>", puerto, espacioDEnombres, clase, ensamblado.Name, canal));
            // Ruta de salida.
            string directorio = string.Concat(Application.StartupPath, CONFIG);

            string fichero = string.Concat(Application.StartupPath, REMOTING + puerto + ".config.xml");

            // Control en la creación del directorio de salida.
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            // Guardar el documento en la salida.
            doc.Save(fichero);

            // Configurar .NET Remoting.
            Configurar(fichero);

            return fichero;
        }
        /// <summary>
        /// Devuelve el servidor remoting de la aplicación
        /// </summary>
        /// <param name="servidor">Número de servidor.</param>
        public static IOCommRemoting getServidor(int servidor)
        {
            IOCommRemoting server = null;

            try
            {
                switch (servidor)
                {
                    case 1:
                        server = (Orbita.Comunicaciones.IOCommRemoting1)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting1));
                        break;
                    case 2:
                        server = (Orbita.Comunicaciones.IOCommRemoting2)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting2));
                        break;
                    case 3:
                        server = (Orbita.Comunicaciones.IOCommRemoting3)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting3));
                        break;
                    case 4:
                        server = (Orbita.Comunicaciones.IOCommRemoting4)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting4));
                        break;
                    case 5:
                        server = (Orbita.Comunicaciones.IOCommRemoting5)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting5));
                        break;
                    case 6:
                        server = (Orbita.Comunicaciones.IOCommRemoting6)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting6));
                        break;
                    case 7:
                        server = (Orbita.Comunicaciones.IOCommRemoting7)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting7));
                        break;
                    case 8:
                        server = (Orbita.Comunicaciones.IOCommRemoting8)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting8));
                        break;
                    case 9:
                        server = (Orbita.Comunicaciones.IOCommRemoting9)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting9));
                        break;
                    case 10:
                        server = (Orbita.Comunicaciones.IOCommRemoting10)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting10));
                        break;
                    case 11:
                        server = (Orbita.Comunicaciones.IOCommRemoting11)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting11));
                        break;
                    case 12:
                        server = (Orbita.Comunicaciones.IOCommRemoting12)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting12));
                        break;
                    case 13:
                        server = (Orbita.Comunicaciones.IOCommRemoting13)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting13));
                        break;
                    case 14:
                        server = (Orbita.Comunicaciones.IOCommRemoting14)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting14));
                        break;
                    case 15:
                        server = (Orbita.Comunicaciones.IOCommRemoting15)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting15));
                        break;
                    case 16:
                        server = (Orbita.Comunicaciones.IOCommRemoting16)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting16));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return server;
        }
        /// <summary>
        /// Método de inicialización del configurador de cliente para .NET Remoting.
        /// </summary>
        /// <param name="puerto">Puerto de salidad de datos.</param>
        /// <param name="maquina">Nombre de la maquina servidor de remoting.</param>
        /// <param name="numeroServidor">Número de servidor remoting.</param>
        public static string InicConfiguracionCliente(int[] puerto, string[] maquina, int[] numeroServidor)
        {
            string[] claseRemoting = new string[numeroServidor.Length];

            for (int i = 0; i < numeroServidor.Length; i++)
            {
                claseRemoting[i] = "IOCommRemoting" + numeroServidor[i].ToString();
            }

            // Obtener el nombre del ensamblado.
            AssemblyName ensamblado = Assembly.GetExecutingAssembly().GetName();
            XmlDocument doc = new XmlDocument();
            IChannel[] regChannels = ChannelServices.RegisteredChannels;
            string url = "";
            // Crear el documento Xml.

            if (regChannels.Length == 0)
            {
                string documento = @"<?xml version='1.0' encoding='utf-8' ?>" +
                 "<configuration>" +
                    "<system.runtime.remoting>" +
                        "<application>" +
                            "<channels>" +
                                "<channel ref=\"tcp\" port='0' />" +
                            "</channels>"+
                            "<client>";
                for (int i = 0; i < puerto.Length; i++)
                {
                    documento = documento + string.Format(CultureInfo.CurrentCulture,
                    "<wellknown type=\"Orbita.Comunicaciones.{1}, {0}\" url=\"tcp://{3}:{2}/{0}.soap\" />",
                    ensamblado.Name, claseRemoting[i], puerto[i], maquina[i]);
                }
                documento = documento +  "</client>" +
                        "</application>" +
                    "</system.runtime.remoting>" +
                 "</configuration>";
                doc.LoadXml(documento);               
            }
            else
            {
                url = "tcp://localhost:" + puerto.ToString() + "/Orbita.Comunicaciones.soap";
            }

            string directorio = string.Concat(Application.StartupPath, CONFIG);
            string fichero = string.Concat(Application.StartupPath, REMOTING + ".config.xml");

            if (regChannels.Length == 0)
            {

                // Control en la creación del directorio de salida.
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }
                // Guardar el documento en la salida.
                doc.Save(fichero);

                // Configurar .NET Remoting.

                Configurar(fichero);
            }
            else
            {
                fichero = url;
            }

            return fichero;
        }
        /// <summary>
        /// Obtener objeto de tipo remoting por el cliente
        /// de conexión.
        /// </summary>
        /// <param name="tipo">Interface de eventos y métodos remoting.</param>
        /// <returns>Objeto con el establecimiento de conexión.</returns>
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public static object GetObject(Type tipo)
        {
            if (!Inic) InicTipoCache();
            WellKnownClientTypeEntry entrada = (WellKnownClientTypeEntry)WellKnownTypes[tipo];
            if (entrada == null)
            {
                throw new RemotingException("Tipo (WellKnownClientTypeEntry) no encontrado.");
            }
            return Activator.GetObject(entrada.ObjectType, entrada.ObjectUrl);
        }
        /// <summary>
        /// Obtiene el canal para establecer la comunicación remota
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="puerto"></param>
        /// <returns></returns>
        public static string GetCanal(string IP, string puerto)
        {
            return IP+":" + puerto;
        }
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// Configurar Remoting a partir de la información
        /// del  fichero creado  en  los  inicializadores.
        /// </summary>
        /// <param name="fichero">Fichero de configuración</param>
        static void Configurar(string fichero)
        {
            // Configurar .NET Remoting.
            RemotingConfiguration.Configure(fichero, false);
        }
        /// <summary>
        /// Inicializar el tipo caché.
        /// </summary>
        static void InicTipoCache()
        {
            WellKnownTypes = new Hashtable();
            foreach (WellKnownClientTypeEntry entrada in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                WellKnownTypes.Add(entrada.ObjectType, entrada);
            }
        }

        public static Object getInterface(int numero)
        {
            Object retorno = null;

            return retorno;
        }
        #endregion
    }
}