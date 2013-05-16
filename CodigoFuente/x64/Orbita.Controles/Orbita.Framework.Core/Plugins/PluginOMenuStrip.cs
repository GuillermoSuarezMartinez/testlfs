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
using System.Linq;
namespace Orbita.Framework.Core
{
    public class PluginOMenuStrip : System.Windows.Forms.MenuStrip
    {
        #region Atributos
        System.Collections.Generic.List<string> pluginItems = new System.Collections.Generic.List<string>();
        #endregion

        #region Constructor
        public PluginOMenuStrip()
            : base() { }
        #endregion

        #region Métodos públicos
        public System.Windows.Forms.ToolStripMenuItem AddPlugin(PluginInfo pluginInfo)
        {
            System.Windows.Forms.ToolStripMenuItem pluginItem = null;
            if (pluginInfo != null)
            {
                pluginItem = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.Plugin.Titulo);
                pluginItem.Tag = pluginInfo;
                if (pluginInfo.Plugin.Icono != null)
                {
                    pluginItem.Image = pluginInfo.Plugin.Icono;
                }

                System.Windows.Forms.ToolStripMenuItem subGrupo = null;
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.SubGrupo))
                {
                    subGrupo = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.Plugin.SubGrupo);
                    subGrupo.DropDownItems.Add(pluginItem);
                }

                System.Windows.Forms.ToolStripMenuItem grupo = null;
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.Grupo))
                {
                    grupo = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.Plugin.Grupo);
                    if (subGrupo != null)
                    {
                        grupo.DropDownItems.Add(subGrupo);
                    }
                    else
                    {
                        grupo.DropDownItems.Add(pluginItem);
                    }
                    AddItem(grupo);
                    pluginItems.Add(pluginInfo.Plugin.Grupo);
                }

                if (grupo == null && subGrupo == null)
                {
                    this.Items.Add(pluginItem);
                    pluginItems.Add(pluginInfo.Plugin.Titulo);
                }
            }
            return pluginItem;
        }
        System.Windows.Forms.ToolStripMenuItem AddItem(System.Windows.Forms.ToolStripMenuItem menuItem)
        {
            System.Windows.Forms.ToolStripMenuItem item = (from x in this.Items.Cast<System.Windows.Forms.ToolStripMenuItem>()
                                                           where x.Text == menuItem.Text
                                                           select x).SingleOrDefault();
            if (item == null)
            {
                this.Items.Add(menuItem);
                return menuItem;
            }
            else
            {
                System.Windows.Forms.ToolStripItem subItem = menuItem.DropDownItems[0];
                if (item != null)
                {
                    item.DropDownItems.Add(subItem);
                }
                return item;
            }
        }
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