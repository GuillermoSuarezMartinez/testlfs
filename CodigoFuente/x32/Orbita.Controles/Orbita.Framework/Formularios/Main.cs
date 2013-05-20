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
namespace Orbita.Framework
{
    [System.CLSCompliantAttribute(false)]
    public partial class Main : Orbita.Framework.Core.ContainerForm
    {
        #region Atributos privados
        /// <summary>
        /// Colección de plugins.
        /// </summary>
        System.Collections.Generic.IDictionary<string, PluginManager.PluginInfo> plugins;
        /// <summary>
        /// Colección de controles de plugins.
        /// </summary>
        System.Collections.Generic.IDictionary<string, Core.ControlInfo> controles;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Main.
        /// </summary>
        public Main()
            : base()
        {
            // Inicializar componentes del entorno.
            InitializeComponent();
            // Inicializar la colección de plugins del entorno.
            InitializePluginsCollection();
            // Cargar formulario de autenticación si la propiedad lo indica.
            LoadAuthentication();
        }
        #endregion

        #region Métodos privados
        void InitializePluginsCollection()
        {
            this.plugins = PluginManager.PluginHelper.Plugins();
        }
        void InitializeMenuPlugins()
        {
            try
            {
                // Obtener aquellos plugins que implementan la interfaz IItemMenu, ordenarlos y vincularlos al control MenuStrip.
                // ... utilizar LINQ para especificar aquellos plugins que implementan la interfaz IItemMenu y ordenar dichos valores.
                // ...AsQueryable(), proporciona funcionalidad para evaluar consultas con respecto a un origen de datos concreto en el 
                // que se especifica el tipo de los datos, evita CA1502 complejidad ciclomática de 28.
                var pluginsDeMenu = (from x in this.plugins
                                     where x.Value.ItemMenu != null
                                     select x.Value).AsQueryable()
                                                    .OrderBy(g => g.ItemMenu.Grupo)
                                                    .ThenBy(sg => sg.ItemMenu.SubGrupo)
                                                    .ThenBy(o => o.ItemMenu.Orden).ToList();

                // Si existen plugins que implementen la interfaz de menú debemos crear el control MenuStrip.
                if (pluginsDeMenu.Count > 0)
                {
                    // Crear dinámicamente el control pluginMenuStrip.
                    InitializeComponentMenuStrip();

                    // Recorrer la colección y vincular cada plugin a cada opción de menú.
                    foreach (PluginManager.PluginInfo pluginInfo in pluginsDeMenu)
                    {
                        if (pluginInfo.Plugin is PluginManager.IFormPlugin)
                        {
                            pluginMenuStrip.AddPlugin(pluginInfo);
                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                this.plugins = this.plugins.OrderBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
            }
            catch (System.NotImplementedException)
            {
                this.plugins = this.plugins.OrderBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
            }
        }
        void InitializePluginsWithChangedLanguage()
        {
            // ... utilizar LINQ para obtener aquellos plugins que implementan la interfaz de cambio de idioma.
            System.Collections.Generic.IEnumerable<PluginManager.PluginInfo> pluginsConCambioDeIdioma = (from x in this.plugins
                                                                                                         where x.Value.Idioma != null
                                                                                                         select x.Value).ToList();
            foreach (var pluginInfo in pluginsConCambioDeIdioma)
            {
                pluginInfo.Idioma.OnCambiarIdioma += new System.EventHandler<PluginManager.IdiomaChangedEventArgs>(OnCambiarIdioma);
            }
        }
        void InitializePluginsWithCloseHandler()
        {
            // ... utilizar LINQ para obtener aquellos plugins que implementan la interfaz de cambio de idioma.
            System.Collections.Generic.IEnumerable<PluginManager.PluginInfo> pluginsConManejadorCierre = (from x in this.plugins
                                                                                                          where x.Value.ManejadorCierre != null
                                                                                                          select x.Value).ToList();
            foreach (var pluginInfo in pluginsConManejadorCierre)
            {
                pluginInfo.ManejadorCierre.OnClose += new System.EventHandler<System.Windows.Forms.FormClosedEventArgs>(OnClose);
            }
        }
        void InitializeEnvironment()
        {
            Core.ConfiguracionHelper.Configuracion.InicializarEntorno(this, System.EventArgs.Empty);
        }
        void InitializePluginControlsCollection()
        {
            this.controles = Core.ConfiguracionHelper.Configuracion.GetControlesPlugin(this.OI.Idioma);
        }
        void InitializePluginControls()
        {
            foreach (PluginManager.PluginInfo pluginInfo in this.plugins.Values)
            {
                System.Windows.Forms.Control control = null;
                if (pluginInfo.Plugin is PluginManager.IUserControlPlugin)
                {
                    Orbita.Framework.PluginManager.IUserControlPlugin plugin = pluginInfo.Plugin as Orbita.Framework.PluginManager.IUserControlPlugin;
                    control = plugin.Control;
                }
                else if (pluginInfo.Plugin is PluginManager.IFormPlugin)
                {
                    Orbita.Framework.PluginManager.IFormPlugin plugin = pluginInfo.Plugin as Orbita.Framework.PluginManager.IFormPlugin;
                    control = plugin.Formulario;
                }
                InitializePluginControls(pluginInfo.Plugin.ToString(), control);
            }
        }
        void InitializePluginControls(string nombre, System.Windows.Forms.Control contenedor)
        {
            foreach (System.Windows.Forms.Control control in contenedor.Controls)
            {
                InitializePluginControls(nombre + "." + control.Name, control);
            }
            if (this.controles.ContainsKey(nombre))
            {
                Core.ControlInfo info = this.controles[nombre];
                if (info.Tipo == "text")
                {
                    contenedor.Text = info.Valor;
                }
            }
        }
        void LoadAuthentication()
        {
            Orbita.Controles.Autenticacion.OManagerValidacion manager = new Orbita.Controles.Autenticacion.OManagerValidacion();
            manager.OValidacion += new Orbita.Controles.Autenticacion.OManagerValidacion.ODelegadoManagerValidacion(Validacion_Click);
            manager.Mostrar(this, this.OI.Autenticación);
        }
        void ShowPlugin(PluginManager.PluginInfo pluginInfo)
        {
            if (pluginInfo != null)
            {
                if (pluginInfo.Plugin is PluginManager.IUserControlPlugin)
                {
                    PluginManager.IUserControlPlugin plugin = pluginInfo.Plugin as PluginManager.IUserControlPlugin;
                    System.Windows.Forms.UserControl control = plugin.Control;
                    if (!this.Controls.Contains(control))
                    {
                        control.Dock = System.Windows.Forms.DockStyle.Fill;
                        control.BringToFront();
                        this.Controls.Add(control);
                    }
                }
                else if (pluginInfo.Plugin is PluginManager.IFormPlugin)
                {
                    PluginManager.IFormPlugin plugin = pluginInfo.Plugin as PluginManager.IFormPlugin;
                    Orbita.Controles.Contenedores.OrbitaForm form = plugin.Formulario;
                    if (form.IsDisposed)
                    {
                        form = PluginManager.PluginHelper.CrearNuevaInstancia<Orbita.Controles.Contenedores.OrbitaForm>(pluginInfo);
                    }
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
                        this.OI.MostrarFormulario(form);
                    }
                }
            }
        }
        #endregion

        #region Métodos privados estáticos
        static void InitializeConfigurationChannelCollection()
        {
            // System.Collections.Generic.IList<Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal> canales = Orbita.Framework.C.ConfiguracionHelper.Configuracion.GetConfiguracionCanal();
        }
        #endregion

        #region Manejadores de eventos
        void OrbitaFramework_Shown(object sender, System.EventArgs e)
        {
            try
            {
                // ... utilizar LINQ para obtener aquellos plugins que se deben mostrar al iniciar el main.
                System.Collections.Generic.IEnumerable<PluginManager.PluginInfo> pluginsIniciales = (from x in this.plugins
                                                                                                     where x.Value.Plugin.MostrarAlIniciar == true
                                                                                                     select x.Value).ToList();
                foreach (var pluginInfo in pluginsIniciales)
                {
                    ShowPlugin(pluginInfo);
                }
            }
            catch (System.NullReferenceException) { }
            catch (System.NotImplementedException) { }
            catch (System.Exception)
            {
                throw;
            }
        }
        void OrbitaFramework_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == System.Windows.Forms.Keys.P)
                {
                    using (PluginsDisponibles form = new PluginsDisponibles())
                    {
                        form.ShowDialog();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        void Validacion_Click(object sender, Orbita.Controles.Autenticacion.AutenticacionChangedEventArgs e)
        {
            try
            {
                if (e.Estado.Resultado == "OK")
                {
                    InitializeMenuPlugins();
                    InitializePluginsWithChangedLanguage();
                    InitializePluginsWithCloseHandler();
                    try
                    {
                        InitializeEnvironment();
                    }
                    catch (System.NullReferenceException) { }
                    catch (System.NotImplementedException) { }

                    try
                    {
                        InitializePluginControlsCollection();
                    }
                    catch (System.NullReferenceException) { }
                    catch (System.NotImplementedException) { }

                    try
                    {
                        InitializeConfigurationChannelCollection();
                    }
                    catch (System.NullReferenceException) { }
                    catch (System.NotImplementedException) { }

                    InitializePluginControls();
                }
            }
            catch (System.NullReferenceException) { }
            catch (System.NotImplementedException) { }
            catch (System.Exception)
            {
                throw;
            }
        }
        void OnCambiarIdioma(object sender, PluginManager.IdiomaChangedEventArgs e)
        {
            try
            {
                // Solo si el idioma de carga es distinto al idioma asignado previamente.
                if (e.Idioma != this.OI.Idioma)
                {
                    // Modificar el atributo de idioma.
                    this.OI.Idioma = e.Idioma;
                    // Inicializar la colección de controles en función del idioma seleccionado.
                    InitializePluginControlsCollection();
                    // Mostrar el valor de cada uno de los controles en los Plugins de carga.
                    InitializePluginControls();
                }
            }
            catch (System.NullReferenceException) { }
            catch (System.NotImplementedException) { }
            catch (System.Exception)
            {
                throw;
            }
        }
        void OnClose(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                if (e.CloseReason == System.Windows.Forms.CloseReason.MdiFormClosing)
                {
                    this.Close();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        #endregion
    }
}