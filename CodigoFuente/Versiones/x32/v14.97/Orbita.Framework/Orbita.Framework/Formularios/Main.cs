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
#region USING
using System.Linq;
#endregion
namespace Orbita.Framework
{
    /// <summary>
    /// Contenedor principal.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public partial class Main : Orbita.Framework.Core.ContainerForm
    {
        #region Atributos privados
        /// <summary>
        /// Colección de plugins, identificada por el nombre como clave.
        /// </summary>
        private System.Collections.Generic.IDictionary<string, PluginManager.PluginInfo> plugins;
        /// <summary>
        /// Colección de controles de plugins.
        /// </summary>
        private System.Collections.Generic.IDictionary<string, Core.ControlInfo> controles;
        /// <summary>
        /// Formulario de autenticación.
        /// </summary>
        private Controles.Autenticacion.FrmAutenticacion formAutenticacion;
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

        #region Propiedades
        /// <summary>
        /// Colección de controles de plugin.
        /// </summary>
        public System.Collections.Generic.IDictionary<string, Core.ControlInfo> Controles
        {
            get { return this.controles; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar colección de plugins, entorno y posteriormente mostrar el formulario de autenticación
        /// si la configuración del entorno lo indica, en caso contrario, nicializar plugins que implementan 
        /// la interface IMenuPlugin, inicializar configuración de canales e iniciarlos, inicializar colección
        /// de controles, y por último, mostrar plugins de inicio.
        /// </summary>
        private void InitializeApplication()
        {
            //  Inicializar los métodos del entorno.
            object result = Core.WaitWindow.Mostrar(InitializeAllMethods);

            //  En el caso que no exista autenticación y se han ejecutado el resto de métodos de inicialización,
            //  se deben mostrar aquellos plugin que necesiten iniciarse al inicio.
            if (result.ToString() == bool.FalseString)
            {
                //  Mostrar plugins que deben iniciarse según el valor de inicio de plugin que indica la interface (IPlugin.MostrarAlIniciar).
                ShowPluginsStartup();
            }
            else
            {
                //  Suscribirse al evento de muestra de formulario principal necesario para establecer el posicionamiento central
                //  del formulario de autenticación.
                this.Shown += new System.EventHandler(OrbitaFramework_Shown);

                //  Se produce la llamada al formulario de autenticación a consecuencia de la configuración del entorno.
                //  La resolución del método LoadAuthentication() se resuelve en el manejador Authentication_DialogReturned.
                LoadAuthentication();
            }
        }
        /// <summary>
        ///  Inicializar colección de plugins, entorno y el resto de métodos relativos a plugins sino requiere autenticación,
        ///  en caso contrario, devolver Verdadero; indicando que debe iniciarse el formulario de autenticación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">Core.WaitWindowEventArgs que contiene los datos del evento.</param>
        private void InitializeAllMethods(object sender, Core.WaitWindowEventArgs e)
        {
            //  Inicializar la colección de plugins del entorno.
            InitializePluginsCollection();

            //  Inicializar entorno de acuerdo a lo que establezca el cliente en su clase 'Configuración' herencia de la clase abstracta.
            InitializeEnvironment();

            e.Resultado = this.OI.Autenticación;
            if (e.Resultado.ToString() == bool.TrueString)
            {
                return;
            }

            //  Inicializar el resto de métodos que implementan las interfaces de plugins.
            InitializeAllPluginsMethods();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">Orbita.Framework.Core.WaitWindowEventArgs que contiene los datos del evento.</param>
        private void InitializeAllPluginsMethods(object sender, Core.WaitWindowEventArgs e)
        {
            InitializeAllPluginsMethods();
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeAllPluginsMethods()
        {
            //  Inicializar plugins que implementan la interface IMenuPlugin.
            InitializePluginsMenu();

            //  Inicializar configuración de canales.
            InitializeConfigurationChannelCollection();

            //  Inicializar colección de controles de plugins.
            InitializePluginControlsCollection();
        }
        /// <summary>
        /// Inicializar la colección de plugins.
        /// </summary>
        private void InitializePluginsCollection()
        {
            this.plugins = PluginManager.PluginHelper.Plugins(OnCambiarIdioma, OnCloseApplication);
        }
        /// <summary>
        /// Inicializar entorno.
        /// </summary>
        private void InitializeEnvironment()
        {
            try
            {
                Core.ConfiguracionHelper.Configuracion.InicializarEntorno(this, System.EventArgs.Empty);
            }
            catch (System.NullReferenceException)
            {
                //  Empty.
            }
            catch (System.NotImplementedException)
            {
                //  Empty.
            }
        }
        /// <summary>
        /// Inicializar menú de acuerdo a aquellos plugins que implementen la interfaz IItemMenu, ordenando y asignando al evento clic.
        /// </summary>
        private void InitializePluginsMenu()
        {
            try
            {
                //  Obtener aquellos plugins que implementan la interfaz IItemMenu, ordenarlos y vincularlos al control MenuStrip.
                //  ...utilizar LINQ para especificar aquellos plugins que implementan la interfaz IItemMenu y ordenar dichos valores.
                //  ...AsQueryable(), proporciona funcionalidad para evaluar consultas con respecto a un origen de datos concreto en el 
                //  que se especifica el tipo de los datos, evita CA1502 complejidad ciclomática de 28.
                var pluginsDeMenu = (from x in this.plugins
                                     where x.Value.ItemMenu != null
                                     select x.Value).AsQueryable()
                                                    .OrderBy(g => g.ItemMenu.Grupo)
                                                    .ThenBy(sg => sg.ItemMenu.SubGrupo)
                                                    .ThenBy(o => o.ItemMenu.Orden).ToList();

                //  Si existen plugins que implementen la interfaz de menú debemos crear el control MenuStrip.
                if (pluginsDeMenu.Count > 0)
                {
                    //  Crear dinámicamente el control pluginMenuStrip.
                    this.pluginMenuStrip = new PluginManager.PluginOMenuStrip();

                    //  Recorrer la colección y vincular cada plugin a cada opción de menú.
                    foreach (PluginManager.PluginInfo pluginInfo in pluginsDeMenu)
                    {
                        if (pluginInfo.Plugin is PluginManager.IFormPlugin)
                        {
                            System.Windows.Forms.ToolStripMenuItem pluginItem = pluginMenuStrip.AddPlugin(pluginInfo);
                            pluginItem.Click += new System.EventHandler(PluginItem_Click);
                        }
                    }
                    //  Obtener un valor que indica si el llamador debe llamar a un método de invocación
                    //  cuando realiza llamadas a métodos del control porque el llamador se encuentra
                    //  en un subproceso distinto al del control donde se creó.
                    if (this.InvokeRequired)
                    {
                        //  Si el objeto tiene otros subprocesos pendientes, entonces
                        //  el delegado atendera esa petición invocando un nuevo objeto,
                        //  en caso contrario, se añadira el menú en el entorno.
                        Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            InitializeComponentMenuStrip();
                        });
                    }
                    else
                    {
                        InitializeComponentMenuStrip();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">Orbita.Framework.Core.WaitWindowEventArgs que contiene los datos del evento.</param>
        private void InitializePluginControlsCollection(object sender, Core.WaitWindowEventArgs e)
        {
            //  Establecer un micro tiempo de retardo que permita visualizar la ventana de espera en procesos cortos.
            System.Threading.Thread.Sleep(100);

            //  Inicializar textos de la colección de controles de cada plugin.
            InitializePluginControlsCollection();
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializePluginControlsCollection()
        {
            try
            {
                //  Obtener la colección de controles, así como el valor asociado a cada uno de ellos.
                this.controles = Core.ConfiguracionHelper.Configuracion.GetControlesPlugin(this.OI.Idioma);
            }
            catch (System.NullReferenceException)
            {
                this.controles = null;
            }
            catch (System.NotImplementedException)
            {
                this.controles = null;
            }
        }
        /// <summary>
        /// Mostrar aquellos plugins que deben iniciarle al iniciar el contenedor principal.
        /// </summary>
        private void ShowPluginsStartup()
        {
            //  ... utilizar LINQ para obtener aquellos plugins que se deben mostrar al iniciar el GUI.
            System.Collections.Generic.IEnumerable<PluginManager.PluginInfo> pluginsIniciales = (from x in this.plugins
                                                                                                 where x.Value.Plugin.MostrarAlIniciar == true
                                                                                                 select x.Value).ToList();
            foreach (var pluginInfo in pluginsIniciales)
            {
                ContainerBase result = ShowPlugin(pluginInfo);
                if (result != null)
                {
                    result.Mostrar();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Orbita.Framework.Core.WaitWindowEventArgs que contiene los datos del evento.</param>
        private void ShowPlugin(object sender, Core.WaitWindowEventArgs e)
        {
            if (e == null) return;

            if (e.Argumentos.Count == 1)
            {
                //  Establecer un micro tiempo de retardo que permita visualizar la ventana de espera en procesos cortos.
                System.Threading.Thread.Sleep(100);

                PluginManager.PluginInfo pluginInfo = e.Argumentos[0] as PluginManager.PluginInfo;
                e.Resultado = ShowPlugin(pluginInfo);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pluginInfo">Información del plugin.</param>
        /// <returns></returns>
        private ContainerBase ShowPlugin(PluginManager.PluginInfo pluginInfo)
        {
            ContainerBase contenedor = null;
            if (pluginInfo.Plugin is PluginManager.IUserControlPlugin)
            {
                PluginManager.IUserControlPlugin plugin = pluginInfo.Plugin as PluginManager.IUserControlPlugin;
                Controles.Shared.OrbitaUserControl control = plugin.Control;
                if (!this.Controls.Contains(control))
                {
                    contenedor = new UserControl(this, control);
                }
            }
            else if (pluginInfo.Plugin is PluginManager.IFormPlugin)
            {
                PluginManager.IFormPlugin plugin = pluginInfo.Plugin as PluginManager.IFormPlugin;
                Controles.Contenedores.OrbitaForm form = plugin.Formulario;
                if (form.IsDisposed)
                {
                    form = PluginManager.PluginHelper.CrearNuevaInstancia<Orbita.Controles.Contenedores.OrbitaForm>(ref pluginInfo);
                }
                if (form != null)
                {
                    if (plugin.Mostrar == PluginManager.MostrarComo.Dialog)
                    {
                        contenedor = new FormDialog(this, form);
                    }
                    else if (plugin.Mostrar == PluginManager.MostrarComo.Normal)
                    {
                        contenedor = new FormNormal(this, form);
                    }
                    else if (plugin.Mostrar == PluginManager.MostrarComo.MdiChild)
                    {
                        contenedor = new FormMdiChild(this, form);
                    }
                }
            }
            return contenedor;
        }
        /// <summary>
        /// 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void LoadAuthentication()
        {
            //  Crear el objecto de tipo  Orbita.Controles.Autenticacion.FrmAutenticacion.
            formAutenticacion = new Controles.Autenticacion.FrmAutenticacion();

            //  Mostrar el formulario de autenticación como un cuadro de diálogo. Establecer el método recibiendo el resultado del diálogo.
            formAutenticacion.ShowChildDialog(this, AuthenticationDialogReturned);
        }
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// 
        /// </summary>
        private static void InitializeConfigurationChannelCollection()
        {
            try
            {
                foreach (Controles.Comunicaciones.OrbitaConfiguracionCanal canal in Core.ConfiguracionHelper.Configuracion.GetConfiguracionCanal())
                {
                    canal.Iniciar();
                }
            }
            catch (System.NullReferenceException)
            {
                //  Empty.
            }
            catch (System.NotImplementedException)
            {
                //  Empty.
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Se produce antes de que se muestre un formulario por primera vez.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">System.EventArgs que contiene los datos del evento.</param>
        private void Main_Load(object sender, System.EventArgs e)
        {
            this.SetBevel(false);
        }
        /// <summary>
        /// Se produce cuando se muestra el formulario por primera vez.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">System.EventArgs que contiene los datos del evento.</param>
        private void OrbitaFramework_Shown(object sender, System.EventArgs e)
        {
            this.SuspendLayout();
            //  Obtener el primer elemento de la secuencia de tipo MdiClient.
            System.Windows.Forms.MdiClient client = this.Controls.OfType<System.Windows.Forms.MdiClient>().First();
            //  Encontrar el punto central del formulario MDI.
            System.Drawing.Point centerPoint = new System.Drawing.Point((client.Width - formAutenticacion.Width) / 2, (client.Height - formAutenticacion.Height) / 2);
            //  Localizar el formulario de autenticación en el punto central.
            formAutenticacion.Location = centerPoint;
            this.ResumeLayout(false);
        }
        /// <summary>
        /// Se produce cuando se presiona una tecla mientras el control tiene el foco.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">System.Windows.Forms.KeyEventArgs que contiene los datos del evento.</param>
        private void OrbitaFramework_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //  Acceso rápido a la lista de plugins disponibles a través de la combinación de tecla Ctrl+P.
            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.P)
            {
                using (PluginsDisponibles form = new PluginsDisponibles())
                {
                    form.ShowDialog();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">PluginManager.IdiomaChangedEventArgs que contiene los datos del evento.</param>
        private void OnCambiarIdioma(object sender, PluginManager.IdiomaChangedEventArgs e)
        {
            //  Solo si el idioma de carga es distinto al idioma asignado previamente.
            if (e.Idioma != this.OI.Idioma)
            {
                //  Modificar el atributo de idioma.
                this.OI.Idioma = e.Idioma;

                //  Inicializar la colección de controles en función del idioma seleccionado.
                Core.WaitWindow.Mostrar(InitializePluginControlsCollection);

                //  Asignar el idioma a cada uno de los controles de los formularios abiertos.
                foreach (var item in System.Windows.Forms.Application.OpenForms)
                {
                    //  Considerar únicamente los formularios abiertos de tipo IPlugin.
                    if (typeof(PluginManager.IPlugin).IsInstanceOfType(item))
                    {
                        PluginManager.IPlugin plugin = (PluginManager.IPlugin)item;
                        string key = plugin.Nombre;
                        if (this.plugins.ContainsKey(key))
                        {
                            ShowPlugin(this.plugins[key]);
                        }
                    }
                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">System.Windows.Forms.FormClosedEventArgs que contiene los datos del evento.</param>
        private void OnCloseApplication(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.MdiFormClosing)
            {
                this.Close();
            }
        }
        /// <summary>
        /// Manejador de evento subscrito al formulario de autenticación. 
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">Orbita.Controles.Autenticacion.AutenticacionResultEventArgs que contiene los datos del evento.</param>
        private void AuthenticationDialogReturned(object sender, Controles.Autenticacion.AutenticacionResultEventArgs e)
        {
            //  Si el resultado de la autenticación es positivo.
            if (e.Resultado == System.Windows.Forms.DialogResult.OK)
            {
                //  Asignar el usuario validado a la clase abstracta pública disponible en el plugin de llamada.
                Core.ConfiguracionHelper.Configuracion.Usuario = e.Usuario;

                //  Inicializar plugins que implementan la interface IMenuPlugin, IFormIdioma, IFormManejadorCierre.
                //  Inicializar configuración de canales.
                //  Inicializar colección de controles de plugins.
                Core.WaitWindow.Mostrar(InitializeAllPluginsMethods);

                //  Mostrar plugins que deben iniciarse según el valor de inicio de plugin que indica la interface.
                ShowPluginsStartup();
            }
            else
            {
                //  Botón cancelar, e.Resultado == System.Windows.Forms.DialogResult.Cancel.
                //  Cerrar ventana, e.Resultado == System.Windows.Forms.DialogResult.None.
                //  El usuario quiere salir de la aplicación. Cerrar todo.
                System.Windows.Forms.Application.Exit();
            }
        }
        /// <summary>
        /// Se produce cuando se hace clic en cualquiera de las opciones de menú.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">System.EventArgs que contiene los datos del evento.</param>
        private void PluginItem_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem menuItem = sender as System.Windows.Forms.ToolStripMenuItem;
            PluginManager.PluginInfo pluginInfo = menuItem.Tag as PluginManager.PluginInfo;
            object result = Core.WaitWindow.Mostrar(ShowPlugin, null, pluginInfo);
            if (result != null)
            {
                ContainerBase plugin = result as ContainerBase;
                plugin.Mostrar();
            }
        }
        #endregion
    }
}