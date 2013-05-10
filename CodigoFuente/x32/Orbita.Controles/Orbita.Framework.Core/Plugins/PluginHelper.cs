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
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Objeto de carga.
    /// </summary>
    public static class PluginHelper
    {
        #region Atributos privados estáticos
        /// <summary>
        /// Ruta del directorio de Plugins.
        /// </summary>
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        #endregion

        #region Propiedades
        /// <summary>
        /// Ruta del directorio de Plugins.
        /// </summary>
        public static string Path
        {
            get { return path; }
            set { path = value; }
        }
        public static Persistencia Persistencia { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Buscar Plugins en el directorio de Plugins configurado.
        /// </summary>
        /// <returns>Un diccionario con el título del Plugin como clave y la ruta del ensamblado como valor.</returns>
        public static System.Collections.Generic.IDictionary<string, string> BuscarPlugins()
        {
            // Colección de Plugins.
            System.Collections.Generic.Dictionary<string, string> plugins = new System.Collections.Generic.Dictionary<string, string>();
            // Si el directorio de Plugins no existe, crearlo.
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            foreach (string fichero in System.IO.Directory.GetFiles(path))
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fichero);
                if (fileInfo.Extension.In(".dll", ".exe"))
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(fichero);
                    plugins.Add(assembly.FullName, fichero);
                }
            }
            return plugins;
        }
        /// <summary>
        /// Obtener Plugins especificados.
        /// </summary>
        /// <param name="pluginsDEcarga">Colección de librerías.</param>
        /// <returns></returns>
        public static System.Collections.Generic.IDictionary<string, PluginInfo> GetPlugins(System.Collections.Generic.IEnumerable<string> pluginsDEcarga)
        {
            if (pluginsDEcarga == null)
            {
                return null;
            }
            System.Collections.Generic.Dictionary<string, PluginInfo> plugins = new System.Collections.Generic.Dictionary<string, PluginInfo>();
            foreach (string fichero in pluginsDEcarga)
            {
                if (System.IO.File.Exists(fichero))
                {
                    System.IO.FileInfo archivoInfo = new System.IO.FileInfo(fichero);
                    if (archivoInfo.Extension.In(".dll", ".exe"))
                    {
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(fichero);
                        foreach (System.Type tipo in assembly.GetTypes())
                        {
                            if (tipo.IsSubclassOf(typeof(System.Windows.Forms.Form)) || tipo.IsSubclassOf(typeof(System.Windows.Forms.UserControl)))
                            {
                                object o = assembly.CreateInstance(tipo.FullName, true);
                                if (typeof(IPlugin).IsInstanceOfType(o))
                                {
                                    IPlugin plugin = (IPlugin)o;
                                    PluginInfo pluginInfo = new PluginInfo();
                                    pluginInfo.Ensamblado = assembly.Location;
                                    pluginInfo.Plugin = plugin;
                                    pluginInfo.Plugin.Configuracion.Value = tipo.FullName;
                                    plugins.Add(pluginInfo.Plugin.Titulo, pluginInfo);
                                }
                            }
                        }
                    }
                }
            }
            return plugins;
        }
        /// <summary>
        /// Crear una nueva instancia del Plugin del fichero de ensamblado especificado.
        /// </summary>
        /// <typeparam name="T">Form / UserControl.</typeparam>
        /// <param name="plugin">El Plugin a cargar.</param>
        /// <returns>Una nueva instancia de Plugin.</returns>
        public static T CrearNuevaInstancia<T>(PluginInfo plugin)
        {
            if (plugin == null)
            {
                throw new System.ArgumentNullException("plugin");
            }
            return (T)System.Reflection.Assembly.LoadFile(plugin.Ensamblado).CreateInstance(plugin.Plugin.Configuracion.Value, true);
        }
        #endregion
    }
}