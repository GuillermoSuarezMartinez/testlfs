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
namespace Orbita.Framework.PluginManager
{
    public class PluginOMenuStrip : System.Windows.Forms.MenuStrip
    {
        #region Atributos
        Orbita.Controles.Contenedores.OrbitaMdiContainerForm control;
        System.Collections.Generic.List<string> pluginItems = new System.Collections.Generic.List<string>();
        #endregion

        #region Constructor
        public PluginOMenuStrip(object control)
            : base() 
        {
            this.control = (Orbita.Controles.Contenedores.OrbitaMdiContainerForm)control;
        }
        #endregion

        #region Métodos privados
        void AddItem(System.Windows.Forms.ToolStripMenuItem menuItem)
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
        public void AddPlugin(PluginInfo pluginInfo)
        {
            System.Windows.Forms.ToolStripMenuItem pluginItem = null;
            if (pluginInfo != null)
            {
                pluginItem = new System.Windows.Forms.ToolStripMenuItem(pluginInfo.Plugin.Nombre);
                pluginItem.Tag = pluginInfo;

                if (pluginInfo.Plugin is IFormPlugin)
                {
                    pluginItem.Click += new System.EventHandler(pluginItem_Click);
                }

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
                    return;
                }
                if (grupo == null && subGrupo == null)
                {
                    this.Items.Add(pluginItem);
                    pluginItems.Add(pluginInfo.Plugin.Nombre);
                }
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

        #region Manejadores de eventos
        void pluginItem_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem menuItem = sender as System.Windows.Forms.ToolStripMenuItem;
            PluginInfo pluginInfo = menuItem.Tag as PluginInfo;
            IFormPlugin plugin = pluginInfo.Plugin as IFormPlugin;
            Orbita.Controles.Contenedores.OrbitaForm form = plugin.Formulario;
            if (plugin.Mostrar == PluginManager.MostrarComo.Dialog)
            {
                form.ShowDialog();
            }
            else if (plugin.Mostrar == PluginManager.MostrarComo.Normal)
            {
                form.Show();
                form.BringToFront();
            }
            else if (plugin.Mostrar == PluginManager.MostrarComo.MdiChild)
            {
                this.control.OI.MostrarFormulario(form);
            }
        }
        #endregion
    }
}