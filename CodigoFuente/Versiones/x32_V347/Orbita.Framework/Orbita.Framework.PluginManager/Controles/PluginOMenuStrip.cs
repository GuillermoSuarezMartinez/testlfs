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
using System.Linq;
#endregion
namespace Orbita.Framework.PluginManager
{
    /// <summary>
    /// Proporciona una estructura de menú para un formulario.
    /// </summary>
    public class PluginOMenuStrip : System.Windows.Forms.MenuStrip
    {
        #region Atributos
        private System.Collections.Generic.List<string> pluginItems = new System.Collections.Generic.List<string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.PluginManager.PluginOMenuStrip.
        /// </summary>
        public PluginOMenuStrip()
            : base() { }
        #endregion

        #region Métodos privados
        private void AddItem(System.Windows.Forms.ToolStripMenuItem menuItem)
        {
            System.Windows.Forms.ToolStripMenuItem item = (from x in this.Items.Cast<System.Windows.Forms.ToolStripMenuItem>()
                                                           where x.Text == menuItem.Text
                                                           select x).SingleOrDefault();
            if (item == null)
            {
                this.Items.Add(menuItem);
            }
            else
            {
                System.Windows.Forms.ToolStripItem subItem = menuItem.DropDownItems[0];
                if (item != null)
                {
                    item.DropDownItems.Add(subItem);
                }
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Añadir plugin a la opción de menú System.Windows.Forms.ToolStripMenuItem y a la colección de plugins.
        /// </summary>
        /// <param name="pluginInfo">Información del plugin.</param>
        public System.Windows.Forms.ToolStripMenuItem AddPlugin(PluginInfo pluginInfo)
        {
            System.Windows.Forms.ToolStripMenuItem pluginItem = null;
            if (pluginInfo != null)
            {
                pluginItem = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.Plugin.Nombre);
                pluginItem.Tag = pluginInfo;
                System.Windows.Forms.ToolStripMenuItem subGrupo = null;
                try
                {
                    if (!string.IsNullOrEmpty(pluginInfo.ItemMenu.SubGrupo))
                    {
                        subGrupo = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.ItemMenu.SubGrupo);
                        subGrupo.DropDownItems.Add(pluginItem);
                    }
                }
                catch (System.NotImplementedException) { }

                System.Windows.Forms.ToolStripMenuItem grupo = null;
                try
                {
                    if (!string.IsNullOrEmpty(pluginInfo.ItemMenu.Grupo))
                    {
                        grupo = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.ItemMenu.Grupo);
                        if (subGrupo != null)
                        {
                            grupo.DropDownItems.Add(subGrupo);
                        }
                        else
                        {
                            grupo.DropDownItems.Add(pluginItem);
                        }
                        AddItem(grupo);
                        pluginItems.Add(pluginInfo.ItemMenu.Grupo);
                    }
                }
                catch (System.NotImplementedException)
                {
                    if (subGrupo != null)
                    {
                        this.Items.Add(subGrupo);
                        pluginItems.Add(pluginInfo.ItemMenu.SubGrupo);
                    }
                    else
                    {
                        this.Items.Add(pluginItem);
                        pluginItems.Add(pluginInfo.Plugin.Nombre);
                    }
                    return pluginItem;
                }
                if (grupo == null && subGrupo == null)
                {
                    this.Items.Add(pluginItem);
                    pluginItems.Add(pluginInfo.Plugin.Nombre);
                }
            }
            return pluginItem;
        }
        /// <summary>
        /// Eliminar todos los plugins de la colección.
        /// </summary>
        public void EliminarPlugins()
        {
            foreach (string item in pluginItems)
            {
                this.Items.RemoveByKey(item);
            }
        }
        #endregion
    }
}