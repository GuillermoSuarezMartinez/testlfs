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
using Orbita.Framework.Extensiones;
namespace Orbita.Framework.PluginManager
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
        static string path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Plugins");
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
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Buscar Plugins en el directorio de Plugins configurado.
        /// </summary>
        /// <returns>Un diccionario con el título del Plugin como clave y la ruta del ensamblado como valor.</returns>
        public static System.Collections.Generic.IDictionary<string, string> Ensamblados()
        {
            // Colección de Plugins.
            System.Collections.Generic.Dictionary<string, string> ensamblados = new System.Collections.Generic.Dictionary<string, string>();
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
                    ensamblados.Add(assembly.FullName, fichero);
                }
            }
            return ensamblados;
        }
        /// <summary>
        /// Obtener Plugins especificados.
        /// </summary>
        /// <returns></returns>
        public static System.Collections.Generic.IDictionary<string, PluginInfo> Plugins()
        {
            System.Collections.Generic.Dictionary<string, PluginInfo> plugins = new System.Collections.Generic.Dictionary<string, PluginInfo>();
            foreach (string fichero in PluginManager.PluginHelper.Ensamblados().Values)
            {
                if (System.IO.File.Exists(fichero))
                {
                    System.IO.FileInfo archivoInfo = new System.IO.FileInfo(fichero);
                    if (archivoInfo.Extension.In(".dll", ".exe"))
                    {
                        System.Reflection.Assembly ensamblado = System.Reflection.Assembly.LoadFile(fichero);
                        foreach (System.Type tipo in ensamblado.GetTypes())
                        {
                            if (tipo.IsSubclassOf(typeof(System.Windows.Forms.Control)))
                            {
                                object control = ensamblado.CreateInstance(tipo.FullName, true);
                                if (typeof(IPlugin).IsInstanceOfType(control))
                                {
                                    IPlugin plugin = (IPlugin)control;
                                    PluginInfo pluginInfo = new PluginInfo();
                                    pluginInfo.Ensamblado = ensamblado.Location;
                                    pluginInfo.Plugin = plugin;
                                    if (typeof(IItemMenu).IsInstanceOfType(control))
                                    {
                                        IItemMenu itemMenu = (IItemMenu)control;
                                        pluginInfo.ItemMenu = itemMenu;
                                    }
                                    if (typeof(IFormIdioma).IsInstanceOfType(control))
                                    {
                                        IFormIdioma idioma = (IFormIdioma)control;
                                        pluginInfo.Idioma = idioma;
                                    }
                                    if (typeof(IFormManejadorCierre).IsInstanceOfType(control))
                                    {
                                        IFormManejadorCierre manejadorCierre = (IFormManejadorCierre)control;
                                        pluginInfo.ManejadorCierre = manejadorCierre;
                                    }
                                    if (!plugins.ContainsKey(plugin.Nombre))
                                    {
                                        plugins.Add(pluginInfo.Plugin.Nombre, pluginInfo);
                                    }
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
        /// <typeparam name="T">SubclassOf(typeof(System.Windows.Forms.Control.</typeparam>
        /// <param name="pluginInfo">Plugin a cargar.</param>
        /// <returns>Nueva instancia del objeto plugin.</returns>
        public static T CrearNuevaInstancia<T>(PluginInfo pluginInfo)
        {
            if (pluginInfo == null)
            {
                throw new System.ArgumentNullException("pluginInfo");
            }
            return (T)System.Reflection.Assembly.LoadFile(pluginInfo.Ensamblado).CreateInstance(pluginInfo.Plugin.ToString(), true);
        }
        #endregion
    }
}