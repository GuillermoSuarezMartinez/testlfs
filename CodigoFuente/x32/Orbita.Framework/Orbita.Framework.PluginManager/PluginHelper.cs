//***********************************************************************
// Assembly         : Orbita.Framework.PluginManager
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
#region USING
using Orbita.Framework.Extensiones;
#endregion
namespace Orbita.Framework.PluginManager
{
    /// <summary>
    /// Métodos asistentes.
    /// </summary>
    public static class PluginHelper
    {
        #region Atributos privados estáticos
        /// <summary>
        /// Ruta del directorio de plugins.
        /// </summary>
        private static string path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Plugins");
        #endregion

        #region Propiedades
        /// <summary>
        /// Ruta del directorio de plugins.
        /// </summary>
        public static string Path
        {
            get { return path; }
            set { path = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Buscar plugins en el directorio de plugins configurado.
        /// </summary>
        /// <returns>Un diccionario con el título del plugin como clave y la ruta del ensamblado como valor.</returns>
        public static System.Collections.Generic.IDictionary<string, string> Ensamblados()
        {
            //  Colección de plugins.
            System.Collections.Generic.Dictionary<string, string> ensamblados = new System.Collections.Generic.Dictionary<string, string>();
            //  Si el directorio de plugins no existe, crearlo.
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
        /// Obtener plugins especificados.
        /// </summary>
        /// <returns></returns>
        public static System.Collections.Generic.IDictionary<string, PluginInfo> Plugins(System.EventHandler<IdiomaChangedEventArgs> cambiarIdioma, System.EventHandler<System.Windows.Forms.FormClosedEventArgs> manejadorCierre)
        {
            System.Collections.Generic.Dictionary<string, PluginInfo> plugins = new System.Collections.Generic.Dictionary<string, PluginInfo>();
            System.Collections.Generic.IDictionary<string, string> ensamblados = PluginManager.PluginHelper.Ensamblados();
            foreach (string fichero in ensamblados.Values)
            {
                if (System.IO.File.Exists(fichero))
                {
                    System.IO.FileInfo archivoInfo = new System.IO.FileInfo(fichero);

                    if (archivoInfo.Extension.In(".dll", ".exe"))
                    {
                        System.Reflection.Assembly ensamblado = System.Reflection.Assembly.LoadFile(fichero);
                        System.Type[] tipos = ensamblado.GetTypes();
                        foreach (System.Type tipo in tipos)
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
                                    pluginInfo.CambiarIdioma = cambiarIdioma;
                                    pluginInfo.ManejadorCierreAplicacion = manejadorCierre;
                                    if (typeof(IItemMenu).IsInstanceOfType(control))
                                    {
                                        IItemMenu itemMenu = (IItemMenu)control;
                                        pluginInfo.ItemMenu = itemMenu;
                                    }
                                    if (typeof(IFormIdioma).IsInstanceOfType(control))
                                    {
                                        IFormIdioma formIdioma = (IFormIdioma)control;
                                        formIdioma.OnCambiarIdioma += pluginInfo.CambiarIdioma;
                                    }
                                    if (typeof(IFormManejadorCierre).IsInstanceOfType(control))
                                    {
                                        IFormManejadorCierre formManejadorCierre = (IFormManejadorCierre)control;
                                        formManejadorCierre.OnCloseApplication += pluginInfo.ManejadorCierreAplicacion;
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
        /// Crear una nueva instancia del plugin del fichero de ensamblado especificado.
        /// </summary>
        /// <typeparam name="T">SubclassOf(typeof(System.Windows.Forms.Control.</typeparam>
        /// <param name="pluginInfo">Información del plugin.</param>
        /// <returns>Nueva instancia del objeto plugin.</returns>
        public static T CrearNuevaInstancia<T>(ref PluginInfo pluginInfo)
        {
            if (pluginInfo == null)
            {
                throw new System.ArgumentNullException("pluginInfo");
            }

            System.Reflection.Assembly ensamblado = System.Reflection.Assembly.LoadFile(pluginInfo.Ensamblado);
            PluginManager.IFormPlugin plugin = pluginInfo.Plugin as Orbita.Framework.PluginManager.IFormPlugin;
            System.Windows.Forms.Control control = plugin.Formulario;
            T item = (T)ensamblado.CreateInstance(control.GetType().FullName, true);

            if (typeof(IPlugin).IsInstanceOfType(item))
            {
                IPlugin newPlugin = (IPlugin)item;
                pluginInfo.Plugin = newPlugin;
                if (typeof(IFormIdioma).IsInstanceOfType(item))
                {
                    IFormIdioma formIdioma = (IFormIdioma)item;
                    formIdioma.OnCambiarIdioma += pluginInfo.CambiarIdioma;
                }
                if (typeof(IFormManejadorCierre).IsInstanceOfType(item))
                {
                    IFormManejadorCierre formManejadorCierre = (IFormManejadorCierre)item;
                    formManejadorCierre.OnCloseApplication += pluginInfo.ManejadorCierreAplicacion;
                }
            }
            return item;
        }
        #endregion
    }
}