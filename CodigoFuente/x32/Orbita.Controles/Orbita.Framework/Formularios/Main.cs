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
using Orbita.Controles.Autenticacion;
namespace Orbita.Framework
{
    [System.CLSCompliantAttribute(false)]
    public partial class Main : Base
    {
        #region Atributos privados
        /// <summary>
        /// Colección de Plugins.
        /// </summary>
        System.Collections.Generic.IDictionary<string, Core.PluginInfo> plugins;
        /// <summary>
        /// Colección de controles.
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
            // Inicializar componentes.
            InitializeComponent();
            // Inicializar atributos.
            InicializeAttributes();
            // Cargar Plugins.
            LoadPlugins();
            // Cargar configuración de Framework.
            LoadConfiguration();
            // Cargar formulario de autenticación si la propiedad lo indica.
            // ...en todo caso se ejecuta el evento asociado Validacion_Click 
            // el cual establece la inicialización del menu, la asignación de
            // eventos y la carga de controles.
            LoadAuthentication();
        }
        #endregion

        #region Métodos privados estáticos
        static void InicializeAttributes()
        {
            Core.PluginHelper.Path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Plugins");
        }
        #endregion

        #region Métodos privados
        void LoadPlugins()
        {
            string fichero = "Plugins.xml";
            if (System.IO.File.Exists(fichero))
            {
                PluginManager.Configuracion = Core.Configuracion.Cargar(fichero);
                this.LoadPlugins((from x in PluginManager.Configuracion.Plugins
                                  where x.Ensamblado != null
                                  select x.Ensamblado).ToList());
            }
            else
            {
                PluginManager.Configuracion = new Core.Configuracion();
                PluginManager.Configuracion.Guardar(fichero);
            }
        }
        void LoadAuthentication()
        {
            OManagerValidacion manager = new OManagerValidacion();
            manager.OValidacion += new OManagerValidacion.ODelegadoManagerValidacion(Validacion_Click);
            manager.Mostrar(this, this.Configurador.Autenticación);
        }
        /// <summary>
        /// Cargar controles en la colección de acuerdo al idioma seleccionado.
        /// </summary>
        void LoadControls()
        {
            Core.Persistencia persistencia = Core.PluginHelper.Persistencia;
            if (persistencia != null)
            {
                controles = persistencia.GetControles(this.Configurador.Idioma);
            }
        }
        /// <summary>
        /// Inicializar el valor de los controles en función de la colección.
        /// </summary>
        void InicializeControls()
        {
            foreach (Core.PluginInfo pluginInfo in this.plugins.Values)
            {
                System.Windows.Forms.Control control = null;
                if (pluginInfo.Plugin is Core.IUserControlPlugin)
                {
                    Core.IUserControlPlugin plugin = pluginInfo.Plugin as Core.IUserControlPlugin;
                    control = plugin.Control;
                }
                else if (pluginInfo.Plugin is Core.IFormPlugin)
                {
                    Core.IFormPlugin plugin = pluginInfo.Plugin as Core.IFormPlugin;
                    control = plugin.Formulario;
                }
                InicializeControls(pluginInfo.Plugin.Configuracion.Value, control);
            }
        }
        /// <summary>
        /// Inicializar el valor de todos los controles de un control de forma recursiva.
        /// </summary>
        /// <param name="nombre">Nombre del control incluyendo espacio de nombres.</param>
        /// <param name="contenedor">Control de tipo Plugin.</param>
        void InicializeControls(string nombre, System.Windows.Forms.Control contenedor)
        {
            foreach (System.Windows.Forms.Control control in contenedor.Controls)
            {
                InicializeControls(nombre + "." + control.Name, control);
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
        /// <summary>
        /// Asignar de forma dinámica los eventos asociado al Plugin de carga.
        /// Eventos de acciones de pulsación de menú.
        /// Eventos suscritos al cambio de idioma.
        /// </summary>
        void SetEventsPlugins()
        {
            foreach (Core.PluginInfo pluginInfo in this.plugins.Values)
            {
                if (this.Configurador.MostrarMenu)
                {
                    // Evento click de las opciones de menú principal.
                    System.Windows.Forms.ToolStripMenuItem pluginItem = this.Menu.AddPlugin(pluginInfo);
                    pluginItem.Click += new System.EventHandler(PluginItem_Click);
                }
                if (pluginInfo.Plugin is Core.IFormIdioma)
                {
                    // Suscriptor al evento de cambio de idioma.
                    Core.IFormIdioma idioma = (Core.IFormIdioma)pluginInfo.Plugin;
                    idioma.OnCambiarIdioma += new System.EventHandler<Core.IdiomaChangedEventArgs>(OnCambiarIdioma);
                }
            }
        }
        /// <summary>
        /// Cargar controles en función de los ensamblados existentes de carga.
        /// </summary>
        /// <param name="ensamblados">Colección de ensamblados.</param>
        void LoadPlugins(System.Collections.Generic.IEnumerable<string> ensamblados)
        {
            this.plugins = Core.PluginHelper.GetPlugins(ensamblados);
            try
            {
                this.plugins = this.plugins.OrderBy(g => g.Value.Plugin.Grupo)
                    .ThenBy(sg => sg.Value.Plugin.SubGrupo)
                    .ThenBy(o => o.Value.Plugin.Orden)
                    .ThenBy(t => t.Key)
                    .ToDictionary(k => k.Key, v => v.Value);
            }
            catch (System.NotImplementedException)
            {
                this.plugins = this.plugins.OrderBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
            }
        }
        /// <summary>
        /// Mostrar en el contenedor de controles el Plugin de carga.
        /// </summary>
        /// <param name="pluginInfo"></param>
        void ShowPlugin(Core.PluginInfo pluginInfo)
        {
            if (pluginInfo != null)
            {
                if (pluginInfo.Plugin is Core.IUserControlPlugin)
                {
                    Core.IUserControlPlugin plugin = pluginInfo.Plugin as Core.IUserControlPlugin;
                    System.Windows.Forms.UserControl control = plugin.Control;
                    if (!this.Controls.Contains(control))
                    {
                        control.Dock = System.Windows.Forms.DockStyle.Fill;
                        control.BringToFront();
                        this.Controls.Add(control);
                    }
                }
                else if (pluginInfo.Plugin is Core.IFormPlugin)
                {
                    Core.IFormPlugin plugin = pluginInfo.Plugin as Core.IFormPlugin;
                    Orbita.Controles.Contenedores.OrbitaForm form = plugin.Formulario;
                    if (form.IsDisposed)
                    {
                        form = Core.PluginHelper.CrearNuevaInstancia<Orbita.Controles.Contenedores.OrbitaForm>(pluginInfo);
                    }
                    bool mostrarAlFrente = false;
                    if (plugin.Tipo == Core.TipoForm.Dialog)
                    {
                        form.ShowDialog();
                    }
                    else if (plugin.Tipo == Core.TipoForm.Normal)
                    {
                        form.Show();
                    }
                    else if (plugin.Tipo == Core.TipoForm.MdiChild)
                    {
                        mostrarAlFrente = this.OI.MostrarFormulario(form);
                    }
                    if (!mostrarAlFrente)
                    {
                        form.WindowState = (System.Windows.Forms.FormWindowState)plugin.EstadoVentana;
                    }
                }
            }
        }
        #endregion

        #region Manejadores de eventos
        void OrbitaFramework_Shown(object sender, System.EventArgs e)
        {
            try
            {
                string plugin = this.Configurador.Plugin;
                if (!string.IsNullOrEmpty(plugin) && this.plugins.ContainsKey(plugin))
                {
                    Core.PluginInfo pluginInfo = this.plugins[plugin];
                    this.ShowPlugin(pluginInfo);
                }
            }
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
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            this.LoadPlugins(form.PluginsSeleccionados.Values);
                            this.SetEventsPlugins();
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        void PluginItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.ToolStripMenuItem menuItem = sender as System.Windows.Forms.ToolStripMenuItem;
                Core.PluginInfo plugin = menuItem.Tag as Core.PluginInfo;
                this.ShowPlugin(plugin);
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
                    // Inicializar menu si la propiedad lo indica.
                    this.InicializeMenu();
                    // Asignar eventos de Plugins.
                    this.SetEventsPlugins();
                    this.LoadControls();
                    this.InicializeControls();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        void OnCambiarIdioma(object sender, Core.IdiomaChangedEventArgs e)
        {
            try
            {
                // Solo si el idioma de carga es distinto al idioma asignado previamente.
                if (e.Idioma != this.Configurador.Idioma)
                {
                    // Modificar el atributo de idioma.
                    this.Configurador.Idioma = e.Idioma;
                    // Inicializar la colección de controles en función del idioma seleccionado.
                    this.LoadControls();
                    // Mostrar el valor de cada uno de los controles en los Plugins de carga.
                    this.InicializeControls();
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