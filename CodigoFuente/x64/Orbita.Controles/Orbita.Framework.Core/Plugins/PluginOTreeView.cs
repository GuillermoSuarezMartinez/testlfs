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
    public class PluginOTreeView : System.Windows.Forms.TreeView
    {
        #region Atributos
        /// <summary>
        /// Colección de imagenes.
        /// </summary>
        System.Windows.Forms.ImageList imagenes = new System.Windows.Forms.ImageList();
        #endregion

        #region Constructor
        public PluginOTreeView()
        {
            this.ImageList = imagenes;
            //imagenes.Images.Add(Resources.orbita_icono_32);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Tamaño de las imagenes.
        /// </summary>
        public System.Drawing.Size Tamaño
        {
            get { return imagenes.ImageSize; }
            set { imagenes.ImageSize = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Añadir ramas al árbol.
        /// </summary>
        /// <param name="pluginInfo">Plugin.</param>
        public void AddPlugin(PluginInfo pluginInfo)
        {
            if (pluginInfo != null)
            {
                #region Plugin
                System.Windows.Forms.TreeNode pluginItem = new System.Windows.Forms.TreeNode(pluginInfo.Plugin.Titulo);
                pluginItem.Tag = pluginInfo;
                if (pluginInfo.Plugin.Icono != null)
                {
                    imagenes.Images.Add(pluginInfo.Plugin.Icono);
                    pluginItem.ImageIndex = imagenes.Images.Count - 1;
                    pluginItem.SelectedImageIndex = imagenes.Images.Count - 1;
                }
                #endregion

                #region Subgrupo
                System.Windows.Forms.TreeNode subGrupo = null;
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.SubGrupo))
                {
                    subGrupo = new System.Windows.Forms.TreeNode(pluginInfo.Plugin.SubGrupo);
                    subGrupo.Nodes.Add(pluginItem);
                }
                #endregion

                #region Grupo
                System.Windows.Forms.TreeNode grupo = null;
                if (!string.IsNullOrEmpty(pluginInfo.Plugin.Grupo))
                {
                    grupo = new System.Windows.Forms.TreeNode(pluginInfo.Plugin.Grupo);
                    if (subGrupo != null)
                    {
                        grupo.Nodes.Add(subGrupo);
                    }
                    else
                    {
                        grupo.Nodes.Add(pluginItem);
                    }
                    AddPlugin(grupo);
                }
                #endregion

                if (grupo == null && subGrupo == null)
                {
                    this.Nodes.Add(pluginItem);
                }
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Añadir ramas al árbol.
        /// </summary>
        /// <param name="treeNode">Nodo del árbol formado por grupo/subgrupo/plugin.</param>
        void AddPlugin(System.Windows.Forms.TreeNode treeNode)
        {
            System.Windows.Forms.TreeNode node = (from x in this.Nodes.Cast<System.Windows.Forms.TreeNode>()
                                                  where x.Text == treeNode.Text
                                                  select x).SingleOrDefault();

            // Si no encuentra la rama grupo/subgrupo/Plugin añadirla a la raiz del árbol.
            if (node == null)
            {
                this.Nodes.Add(treeNode);
            }
            else
            {
                bool encontrado = false;
                // SubGrupo formado por grupo/subgrupo.
                System.Windows.Forms.TreeNode subGrupo = treeNode.Nodes[0];
                // Recorrer los nodos de segundo nivel.
                foreach (System.Windows.Forms.TreeNode subGrupos in node.Nodes)
                {
                    // Si se trata de nodos que tienen raices continuar la búsqueda de nodos.
                    if (subGrupos.Nodes.Count > 0)
                    {
                        // Si existe el subgrupo en la lista añadimos el plugin al subgrupo de subnodos.
                        if (subGrupos.Text == subGrupo.Text)
                        {
                            // Añadir el nodo de último nivel,
                            // es decir, el plugin.
                            subGrupos.Nodes.Add(subGrupo.Nodes[0]);
                            encontrado = true;
                            break;
                        }
                    }
                }
                // Si no se encuentra el nodo formado por grupo/subgrupo/Plugin añade la rama completa al root del TreeView.
                if (!encontrado)
                {
                    node.Nodes.Add(subGrupo);
                }
            }
        }
        #endregion
    }
}