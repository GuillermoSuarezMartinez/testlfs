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
using System.Windows.Forms;
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

        #region Delegados
        internal delegate void DelegadoInitializePluginsMenu(Core.WaitWindowEventArgs e);
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Main.
        /// </summary>
        public Main()
            : base()
        {
            InitializeComponent();
            InitializeApplication();
        }
        #endregion

        #region Métodos privados
        void InitializeApplication()
        {
            // Inicializar todos los métodos del entorno.
            object result = Core.WaitWindow.Mostrar(InitializeAllMethods);

            // En el caso que no exista autenticación y se han ejecutado el resto de métodos de inicialización,
            // se deben mostrar aquellos plugin que necesiten iniciarse al inicio.
            if (result.ToString() == bool.FalseString)
            {
                // Mostrar plugins que deben iniciarse según el valor de inicio de plugin que indica la interface (IPlugin.MostrarAlIniciar).
                ShowPluginsStartup();
            }
            else
            {
                // Se produce la llamada al formulario de autenticación a consecuencia de la configuración del entorno.
                // La resolución del método LoadAuthentication() se resuelve en el manejador Authentication_DialogReturned.
                LoadAuthentication();
            }
        }
        void InitializeAllMethods(object sender, Core.WaitWindowEventArgs e)
        {
            // Inicializar la colección de plugins del entorno.
            InitializePluginsCollection(e);

            // Inicializar entorno de acuerdo a lo que establezca el cliente en su clase
            // 'Configuración' herencia de la clase abstracta.
            InitializeEnvironment(e);

            e.Resultado = this.OI.Autenticación;
            if (e.Resultado.ToString() == bool.TrueString) return;

            // Inicializar el resto de métodos que implementan las interfaces de plugins.
            InitializeAllPluginsMethods(e);
        }
        void InitializeAllPluginsMethods(object sender, Core.WaitWindowEventArgs e)
        {
            InitializeAllPluginsMethods(e);
        }
        void InitializeAllPluginsMethods(Core.WaitWindowEventArgs e)
        {
            // Inicializar plugins que implementan la interface IMenuPlugin.
            InitializePluginsMenu(e);

            // Inicializar plugins que implementan la interface IFormIdioma.
            InitializePluginsWithChangedLanguage(e);
            
            // Inicializar plugins que implementan la interface IFormManejadorCierre.
            InitializePluginsWithCloseHandler(e);
            
            // Inicializar configuración de canales.
            InitializeConfigurationChannelCollection(e);

            // Inicializar colección de controles de plugins.
            InitializePluginControlsCollection(e);
        }
        void InitializePluginsCollection(Core.WaitWindowEventArgs e)
        {
            e.Window.Mensaje = "Cargando plugins ...";
            this.plugins = PluginManager.PluginHelper.Plugins();
        }
        void InitializeEnvironment(Core.WaitWindowEventArgs e)
        {
            try
            {
                e.Window.Mensaje = "Inicializando entorno ...";
                Core.ConfiguracionHelper.Configuracion.InicializarEntorno(this, System.EventArgs.Empty);
            }
            catch (System.NullReferenceException) { }
            catch (System.NotImplementedException) { }
        }
        void InitializePluginsMenu(Core.WaitWindowEventArgs e)
        {
            this.SuspendLayout();
            try
            {
                e.Window.Mensaje = "Inicializar menu ...";
                if (this.InvokeRequired)
                {
                    // Si el objeto tiene otros subprocesos pendientes, entonces
                    // el delegado atendera esa petición invocando un nuevo objeto
                    // caso contrario se añadira el menú en el entorno.
                    DelegadoInitializePluginsMenu delegado = new DelegadoInitializePluginsMenu(InitializePluginsMenu);
                    this.Invoke(delegado, new object[] { e });
                }
                else
                {
                    // Obtener aquellos plugins que implementan la interfaz IItemMenu, ordenarlos y vincularlos al control MenuStrip.
                    // ...utilizar LINQ para especificar aquellos plugins que implementan la interfaz IItemMenu y ordenar dichos valores.
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
            }
            catch (System.NullReferenceException)
            {
                this.plugins = this.plugins.OrderBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
            }
            catch (System.NotImplementedException)
            {
                this.plugins = this.plugins.OrderBy(t => t.Key).ToDictionary(k => k.Key, v => v.Value);
            }
            finally
            {
               this.ResumeLayout(false);
               this.PerformLayout();
            }
        }
        void InitializePluginsWithChangedLanguage(Core.WaitWindowEventArgs e)
        {
            e.Window.Mensaje = "Inicializar cambio de idioma ...";
            // ... utilizar LINQ para obtener aquellos plugins que implementan la interfaz de cambio de idioma.
            System.Collections.Generic.IEnumerable<PluginManager.PluginInfo> pluginsConCambioDeIdioma = (from x in this.plugins
                                                                                                         where x.Value.Idioma != null
                                                                                                         select x.Value).ToList();
            
            foreach (var pluginInfo in pluginsConCambioDeIdioma)
            {
                pluginInfo.Idioma.OnCambiarIdioma += new System.EventHandler<PluginManager.IdiomaChangedEventArgs>(OnCambiarIdioma);
            }
        }
        void InitializePluginsWithCloseHandler(Core.WaitWindowEventArgs e)
        {
            e.Window.Mensaje = "Inicializar manejador de cierre ...";
            // ... utilizar LINQ para obtener aquellos plugins que implementan la interfaz de manejador de cierre de formulario principal.
            System.Collections.Generic.IEnumerable<PluginManager.PluginInfo> pluginsConManejadorCierre = (from x in this.plugins
                                                                                                          where x.Value.ManejadorCierre != null
                                                                                                          select x.Value).ToList();
            foreach (var pluginInfo in pluginsConManejadorCierre)
            {
                pluginInfo.ManejadorCierre.OnClose += new System.EventHandler<System.Windows.Forms.FormClosedEventArgs>(OnClose);
            }
        }
        void InitializePluginControlsCollection(Core.WaitWindowEventArgs e)
        {
            e.Window.Mensaje = "Inicializar colección de controles ...";
            try
            {
                this.controles = Core.ConfiguracionHelper.Configuracion.GetControlesPlugin(this.OI.Idioma);
                // Inicializar el valor de cada uno de los controles de la colección.
                InitializePluginControls(e);
            }
            catch (System.NullReferenceException) { }
            catch (System.NotImplementedException) { }
        }
        void InitializePluginControls(Core.WaitWindowEventArgs e)
        {
            e.Window.Mensaje = "Inicializar controles ... ";
            foreach (PluginManager.PluginInfo pluginInfo in this.plugins.Values)
            {
                System.Windows.Forms.Control control = null;
                if (pluginInfo.Plugin is PluginManager.IUserControlPlugin)
                {
                    PluginManager.IUserControlPlugin plugin = pluginInfo.Plugin as Orbita.Framework.PluginManager.IUserControlPlugin;
                    control = plugin.Control;
                }
                else if (pluginInfo.Plugin is PluginManager.IFormPlugin)
                {
                    PluginManager.IFormPlugin plugin = pluginInfo.Plugin as Orbita.Framework.PluginManager.IFormPlugin;
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
        void ShowPluginsStartup()
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
        void LoadAuthentication()
        {
            Orbita.Controles.Autenticacion.FrmValidar formValidar = new Orbita.Controles.Autenticacion.FrmValidar();
            ShowChildDialog(formValidar, Authentication_DialogReturned); //Show the form as an dialog, nothing else will be enabled. set the recieving method for the dialog result
            //Orbita.Controles.Autenticacion.AutenticacionManager autenticacion = new Orbita.Controles.Autenticacion.AutenticacionManager();
            //autenticacion.ControlAutenticacion += new System.EventHandler<Controles.Autenticacion.AutenticacionChangedEventArgs>(Autenticacion_Click);
            //if (this.OI.Autenticación)
            //{
            //    autenticacion.Mostrar(this);
            //}
            //else
            //{
            //    autenticacion.Validar();
            //}
        }
        #endregion

        protected void Authentication_DialogReturned(object sender, Core.DialogResultArgs e)
        {
            try
            {
                if (e.Result == System.Windows.Forms.DialogResult.OK)
                {
                    Orbita.Controles.Autenticacion.FrmValidar frm = (Orbita.Controles.Autenticacion.FrmValidar)sender;
                    frm.Hide();
                    Core.WaitWindow.Mostrar(InitializeAllPluginsMethods);
                    // Mostrar plugins que deben iniciarse según el valor de inicio de plugin que indica la interface.
                    ShowPluginsStartup();
                }
                else
                {
                    // El usuario quiere salir de la aplicación. Cerrar todo.
                    System.Windows.Forms.Application.Exit();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #region Métodos privados estáticos
        static void InitializeConfigurationChannelCollection(Core.WaitWindowEventArgs e)
        {
            try
            {
                e.Window.Mensaje = "";
                foreach (Orbita.Controles.Comunicaciones.OrbitaConfiguracionCanal canal in Core.ConfiguracionHelper.Configuracion.GetConfiguracionCanal())
                {
                    canal.Iniciar();
                }
            }
            catch (System.NullReferenceException) { }
            catch (System.NotImplementedException) { }
        }
        #endregion

        #region Manejadores de eventos
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
        void Autenticacion_Click(object sender, Orbita.Controles.Autenticacion.AutenticacionChangedEventArgs e)
        {
            try
            {
                if (e.Resultado == Orbita.Controles.Autenticacion.ResultadoAutenticacion.OK)
                {
                    Core.WaitWindow.Mostrar(InitializeAllPluginsMethods);
                }
                else if (e.Resultado == Orbita.Controles.Autenticacion.ResultadoAutenticacion.NOK)
                {
                    // El usuario quiere salir de la aplicación. Cerrar todo.
                    System.Windows.Forms.Application.Exit();
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
                    //InitializePluginControlsCollection();
                    // Mostrar el valor de cada uno de los controles en los Plugins de carga.
                    //InitializePluginControls();
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