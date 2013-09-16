using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Xml;

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
        /// Colección de  tipos  conocidos
        /// en el establecimiento remoting.
        /// </summary>
        private static IDictionary WellKnownTypes;
        /// <summary>
        /// Valor de inicialización.
        /// </summary>
        private const bool Inic = false;
        /// <summary>
        /// Ruta de configuración general.
        /// </summary>
        private const string Config = @"\Config";
        /// <summary>
        /// Ruta de configuración de servidor
        /// y cliente para .NET Remoting.
        /// </summary>
        private const string Remoting = @"\Config\remoting";
        #endregion Atributos

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
            string directorio = string.Concat(Application.StartupPath, Config);

            string fichero = string.Concat(Application.StartupPath, Remoting + puerto + ".config.xml");

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
            switch (servidor)
            {
                case 1:
                    server = (IOCommRemoting1)ORemoting.GetObject(typeof(IOCommRemoting1));
                    break;
                case 2:
                    server = (IOCommRemoting2)GetObject(typeof(IOCommRemoting2));
                    break;
                case 3:
                    server = (IOCommRemoting3)GetObject(typeof(IOCommRemoting3));
                    break;
                case 4:
                    server = (IOCommRemoting4)GetObject(typeof(IOCommRemoting4));
                    break;
                case 5:
                    server = (IOCommRemoting5)GetObject(typeof(IOCommRemoting5));
                    break;
                case 6:
                    server = (IOCommRemoting6)GetObject(typeof(IOCommRemoting6));
                    break;
                case 7:
                    server = (IOCommRemoting7)GetObject(typeof(IOCommRemoting7));
                    break;
                case 8:
                    server = (IOCommRemoting8)GetObject(typeof(IOCommRemoting8));
                    break;
                case 9:
                    server = (IOCommRemoting9)GetObject(typeof(IOCommRemoting9));
                    break;
                case 10:
                    server = (IOCommRemoting10)GetObject(typeof(IOCommRemoting10));
                    break;
                case 11:
                    server = (IOCommRemoting11)GetObject(typeof(IOCommRemoting11));
                    break;
                case 12:
                    server = (IOCommRemoting12)GetObject(typeof(IOCommRemoting12));
                    break;
                case 13:
                    server = (IOCommRemoting13)GetObject(typeof(IOCommRemoting13));
                    break;
                case 14:
                    server = (IOCommRemoting14)GetObject(typeof(IOCommRemoting14));
                    break;
                case 15:
                    server = (IOCommRemoting15)GetObject(typeof(IOCommRemoting15));
                    break;
                case 16:
                    server = (IOCommRemoting16)GetObject(typeof(IOCommRemoting16));
                    break;
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
                            "</channels>" +
                            "<client>";
                for (int i = 0; i < puerto.Length; i++)
                {
                    documento = documento + string.Format(CultureInfo.CurrentCulture,
                    "<wellknown type=\"Orbita.Comunicaciones.{1}, {0}\" url=\"tcp://{3}:{2}/{0}.soap\" />",
                    ensamblado.Name, claseRemoting[i], puerto[i], maquina[i]);
                }
                documento = documento + "</client>" +
                        "</application>" +
                    "</system.runtime.remoting>" +
                 "</configuration>";
                doc.LoadXml(documento);
            }
            else
            {
                url = "tcp://localhost:" + puerto.ToString() + "/Orbita.Comunicaciones.soap";
            }

            string directorio = string.Concat(Application.StartupPath, Config);
            string fichero = string.Concat(Application.StartupPath, Remoting + ".config.xml");

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
        /// <param name="ip"></param>
        /// <param name="puerto"></param>
        /// <returns></returns>
        public static string GetCanal(string ip, string puerto)
        {
            return ip + ":" + puerto;
        }
        public static Object getInterface(int numero)
        {
            return null;
        }
        #endregion Métodos públicos estáticos

        #region Métodos privados estáticos
        /// <summary>
        /// Configurar Remoting a partir de la información
        /// del  fichero creado  en  los  inicializadores.
        /// </summary>
        /// <param name="fichero">Fichero de configuración</param>
        private static void Configurar(string fichero)
        {
            // Configurar .NET Remoting.
            RemotingConfiguration.Configure(fichero, false);
        }
        /// <summary>
        /// Inicializar el tipo caché.
        /// </summary>
        private static void InicTipoCache()
        {
            WellKnownTypes = new Hashtable();
            foreach (WellKnownClientTypeEntry entrada in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                WellKnownTypes.Add(entrada.ObjectType, entrada);
            }
        }
        #endregion Métodos privados estáticos
    }
}