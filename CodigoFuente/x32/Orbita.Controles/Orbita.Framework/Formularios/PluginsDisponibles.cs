//***********************************************************************
// Assembly         : Orbita.Framework
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
using Orbita.Framework.Core;
namespace Orbita.Framework
{
    public partial class PluginsDisponibles : System.Windows.Forms.Form
    {
        #region Atributos privados
        /// <summary>
        /// Colección de plugins.
        /// </summary>
        System.Collections.Generic.IDictionary<string, string> pluginsDisponibles;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.PluginsDisponibles.
        /// </summary>
        public PluginsDisponibles()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de plugins seleccionados.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, string> PluginsSeleccionados { get; private set; }
        #endregion

        #region Manejadores de eventos
        void PluginsDisponibles_Load(object sender, System.EventArgs e)
        {
            try
            {
                pluginsDisponibles = Core.PluginHelper.BuscarPlugins();
                clbPluginsDisponibles.Items.AddRange(pluginsDisponibles.Keys.ToArray());
                PluginsSeleccionados = (from p in PluginManager.Configuracion.Plugins
                                        select p).ToDictionary(key => key.Titulo, value => value.Ensamblado);
                for (int i = 0; i < clbPluginsDisponibles.Items.Count; i++)
                {
                    if (clbPluginsDisponibles.Items[i].ToString().In(PluginsSeleccionados.Keys))
                    {
                        clbPluginsDisponibles.SetItemChecked(i, true);
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        void btnAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                PluginsSeleccionados = (from p in pluginsDisponibles
                                        where p.Key.In(clbPluginsDisponibles.CheckedItems)
                                        select p).ToDictionary(key => key.Key, value => value.Value);
                if (PluginsSeleccionados != null && PluginsSeleccionados.Count > 0)
                {
                    PluginManager.Configuracion.Plugins.Clear();
                    foreach (System.Collections.Generic.KeyValuePair<string, string> kv in PluginsSeleccionados)
                    {
                        if (!PluginManager.Configuracion.Plugins.Existe(kv.Key))
                        {
                            Core.PluginConfiguracion plugin = new Core.PluginConfiguracion();
                            plugin.Titulo = kv.Key;
                            plugin.Ensamblado = kv.Value;
                            PluginManager.Configuracion.Plugins.Add(plugin);
                        }
                    }
                }
                PluginManager.Configuracion.Guardar("Plugins.xml");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        void btnCancelar_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion
    }
}