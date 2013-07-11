using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using System.Xml;
using Infragistics.Win.UltraWinExplorerBar;
using Orbita.Trazabilidad;
using Orbita.Utiles;
namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Control para visor de trazas
    /// </summary>
    [ToolboxItem(true)]
    public partial class OrbitaVisorTCP : UserControl
    {
        #region Enumerado(s)
        /// <summary>
        /// Enumeración de clase
        /// </summary>
        public enum E
        {
            /// <summary>
            /// 
            /// </summary>
            Zero = 0
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Ruta del fichero de configuración.
        /// </summary>
        private string _rutaConfiguracion = Directory.GetCurrentDirectory();
        /// <summary>
        /// Flag que marca si se inicia la carga del control.
        /// </summary>
        private bool _iniciarControl = false;
        /// <summary>
        /// Contiene los datos de configuración de la aplicación almacenados en el fichero de configuración.
        /// </summary>
        private NameValueCollection AppSettings;
        /// <summary>
        /// Contiene listado de argumentos del mensaje de log (columnas a monitorizar en grids) traza.
        /// </summary>
        private Dictionary<int, Argumento> ListaColumnasTraza;
        /// <summary>
        /// Apariencias generales. Color líneas.
        /// </summary>
        private Infragistics.Win.Appearance _colorWarning;
        private Infragistics.Win.Appearance _colorError;
        private Infragistics.Win.Appearance _colorFatal;
        private Infragistics.Win.Appearance _colorInfo;
        private Infragistics.Win.Appearance _colorKeepAlive;
        /// <summary>
        /// Número de trazas fatal.
        /// </summary>
        private int _numFatal;
        /// <summary>
        /// Número de error fatal.
        /// </summary>
        private int _numError;
        /// <summary>
        /// Número de warning fatal.
        /// </summary>
        private int _numWarning;
        /// <summary>
        /// Canal TCP remoting.
        /// </summary>
        private TcpServerChannel tsc = null;
        /// <summary>
        /// Atributo estático que hace referencia a la clase actual, se llama desde clase logger (entrada remoting).
        /// </summary>
        private static OrbitaVisorTCP _main;
        /// <summary>
        /// Tabla de datos del gridTrazas.
        /// </summary>
        private DataTable _dtGridTrazas;
        /// <summary>
        /// Tabla de datos del gridTrazasError.
        /// inferior.
        /// </summary>
        private DataTable _dtGridTrazasError;
        /// <summary>
        /// Indica si la trazas estan en run o stop.
        /// </summary>
        private Boolean _pararTrazas = true;
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado de actualización de Windows Form.
        /// </summary>
        delegate void InvokerParam();
        /// <summary>
        /// Delegado interno recepción logs remoting.
        /// </summary>
        internal delegate void MiDelegado();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor del control.
        /// </summary>
        public OrbitaVisorTCP()
        {
            InitializeComponent();
            _main = this;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Atributo estático que hace referencia a la clase  actual, accesible desde mismo ensamblado.
        /// </summary>
        internal static OrbitaVisorTCP Visor
        {
            get { return _main; }
        }
        /// <summary>
        /// Ruta de los ficheros de configuración.
        /// </summary>
        [Category("Orbita"), Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor)), Description("Ruta de los ficheros de configuración, necesaria para la carga del control.")]
        public string OrbitaRutaConfiguracion
        {
            get { return this._rutaConfiguracion; }
            set
            {
                this._rutaConfiguracion = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Inicializa el control. Carga configuración.
        /// </summary>
        [Category("Orbita"), Description("Inicializa el control. Carga ficheros de configuración.")]
        public bool OrbitaIniciar
        {
            get { return this._iniciarControl; }
            set
            {
                this._iniciarControl = value;
                Invalidate();
            }

        }
        #endregion

        #region Métodos internos
        /// <summary>
        /// Método interno para inserción de mensajes de log accesible desde todo ensamblado. Se invoca delegado.
        /// </summary>
        /// <param name="msg">elemento/mensage a añadir</param>
        internal void AddLinea(ItemLog msg)
        {
            if (IsDisposed) return;
            if (this._pararTrazas) return;

            MiDelegado delegado = delegate()
            {
                AddLineaInterna(msg);
            };

            if (InvokeRequired)
                BeginInvoke(delegado);
            else
                delegado();
        }
        /// <summary>
        /// Método interno para insercion de mensajes de log. Accesible desde todo ensamblado. Invocado por delegado.
        /// </summary>
        /// <param name="msg">elemento/mensage a añadir en grid.</param>
        internal void AddLineaInterna(ItemLog msg)
        {
            if (IsDisposed) return;

            DataRow drGridTrazas = this._dtGridTrazas.NewRow();
            drGridTrazas["Nivel"] = msg.NivelLog.ToString().ToUpper();
            drGridTrazas["Fecha"] = msg.Fecha;
            drGridTrazas["Mensaje"] = msg.Mensaje;

            // Existen argumentos...
            object[] argumentos = msg.GetArgumentos();
            // Se comprueba si están definidos (desde fichero de configuración).
            // si existen se asigna valor a columna correspondiente.
            if (argumentos != null && this.ListaColumnasTraza != null && this.ListaColumnasTraza.Values.Count > 0)
            {
                foreach (Argumento arg in this.ListaColumnasTraza.Values)
                {
                    if (arg.MostrarEnGrid && arg.ID <= argumentos.Length - 1)
                    {
                        drGridTrazas[arg.Nombre] = argumentos[arg.ID];
                    }
                }
            }

            // Insertar la fila en el datatable.
            this._dtGridTrazas.Rows.InsertAt(drGridTrazas, 0);
            gridTrazas.OI.Filas.Activar(1);
            // Eliminamos la ultima fila en el caso de que superemos las filas máximas.
            if (this._dtGridTrazas.Rows.Count > Convert.ToInt32(AppSettings.GetValues("FilasVisualizacionTrazas")[0]))
            {
                this._dtGridTrazas.Rows.RemoveAt(this._dtGridTrazas.Rows.Count - 1);
            }

            Focus();
            // Si se trata de una línea de niveles críticos mostrar
            // dicho mensaje de registro tambien en el grid inferior.
            switch (msg.NivelLog)
            {
                case NivelLog.Warn:
                case NivelLog.Error:
                case NivelLog.Fatal:
                    DataRow drGridTrazasError = this._dtGridTrazasError.NewRow();
                    drGridTrazasError.ItemArray = this._dtGridTrazas.Rows[0].ItemArray;
                    this._dtGridTrazasError.Rows.InsertAt(drGridTrazasError, 0);
                    gridTrazasError.OI.Filas.Activar(1);
                    // Eliminamos la ultima fila en el caso de que superemos las filas maximas
                    if (this._dtGridTrazasError.Rows.Count > Convert.ToInt32(AppSettings.GetValues("FilasVisualizacionError")[0]))
                    {
                        this._dtGridTrazasError.Rows.RemoveAt(this._dtGridTrazasError.Rows.Count - 1);
                    }
                    Focus();
                    break;
                default:
                    break;
            }
            switch (msg.NivelLog)
            {
                case NivelLog.Warn:
                    _numWarning++;
                    gridTrazasError.Toolbar.Tools["warningGridError"].SharedProps.Caption = "Warnings (" + _numWarning.ToString() + ")";
                    break;
                case NivelLog.Error:
                    _numError++;
                    gridTrazasError.Toolbar.Tools["errorGridError"].SharedProps.Caption = "Errores (" + _numError.ToString() + ")";
                    break;
                case NivelLog.Fatal:
                    _numFatal++;
                    gridTrazasError.Toolbar.Tools["fatalGridError"].SharedProps.Caption = "Fatales (" + _numFatal.ToString() + ")";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Método(s) Privado(s)
        /// <summary>
        /// Carga las colecciones con los argumentos/columnas correspondientes.
        /// </summary>
        /// <returns>Carga correcta.</returns>
        private bool CargarColumnas()
        {
            try
            {
                string ficheroConfiguracion = Path.Combine(this._rutaConfiguracion, "GestionColumnas.xml");
                //Se comprueba si existe el fichero
                if (!File.Exists(ficheroConfiguracion))
                {
                    OMensajes.MostrarError("Ruta: " + ficheroConfiguracion);
                    return false;
                }

                XmlDocument ficheroXML = new XmlDocument();
                ficheroXML.Load(ficheroConfiguracion);

                ListaColumnasTraza = new Dictionary<int, Argumento>();

                foreach (XmlNode nodo in ficheroXML.GetElementsByTagName("trazas"))
                {
                    foreach (XmlNode clave in nodo.ChildNodes)
                    {
                        if (clave.Attributes != null)
                        {
                            Argumento arg = new Argumento();
                            arg.ID = Convert.ToInt32(clave.ChildNodes[0].InnerText);
                            arg.Nombre = clave.ChildNodes[1].InnerText;
                            arg.MostrarEnGrid = Convert.ToBoolean(clave.ChildNodes[2].InnerText);
                            arg.With = Convert.ToInt32(clave.ChildNodes[3].InnerText);
                            arg.SetEstilosGrid(Convert.ToInt32(clave.ChildNodes[4].InnerText));
                            arg.PosicionColumna = Convert.ToInt32(clave.Attributes["name"].Value);

                            ListaColumnasTraza.Add(arg.ID, arg);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la carga del fichero de configuración de columnas", ex);
            }
        }
        /// <summary>
        /// Columnas de tabla trazas.
        /// </summary>
        /// <param name="dt">DataTable a formatear.</param>
        /// <returns>DataTable formateado.</returns>
        private DataTable AddColumnasDataTableTrazas(DataTable dt)
        {
            DataColumn columna = new DataColumn();

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nivel";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.DateTime");
            columna.ColumnName = "Fecha";
            dt.Columns.Add(columna);
            //se comprueba si hay columnas adicionales.
            if (this.ListaColumnasTraza != null && this.ListaColumnasTraza.Values.Count > 0)
            {
                foreach (Argumento arg in this.ListaColumnasTraza.Values)
                {
                    if (arg.MostrarEnGrid)
                    {
                        columna = new DataColumn();
                        columna.DataType = System.Type.GetType("System.String");
                        columna.ColumnName = arg.Nombre;
                        dt.Columns.Add(columna);
                    }
                }
            }

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Mensaje";
            dt.Columns.Add(columna);

            return (dt);
        }
        /// <summary>
        /// Formatea las columnas del grid Trazas.
        /// </summary>
        /// <param name="cols">Colección ArrayList.</param>
        /// <returns>Colección columnas formateada.</returns>
        private ArrayList ColumnasGridTrazas(ArrayList cols)
        {
            cols.Add(new Orbita.Controles.Grid.OEstiloColumna("Nivel", "Nivel", Orbita.Controles.Grid.EstiloColumna.Texto, Orbita.Controles.Grid.Alineacion.Izquierda, 54));
            cols.Add(new Orbita.Controles.Grid.OEstiloColumna("Fecha", "Fecha", Orbita.Controles.Grid.EstiloColumna.Fecha, Orbita.Controles.Grid.Alineacion.Centrado, new Orbita.Controles.Grid.OMascara("dd/mm/yyyy hh:mm:ss"), 120));
            //se comprueba si hay columnas adicionales.
            if (this.ListaColumnasTraza != null && this.ListaColumnasTraza.Values.Count > 0)
            {
                foreach (Argumento arg in this.ListaColumnasTraza.Values)
                {
                    if (arg.MostrarEnGrid)
                    {
                        cols.Add(new Orbita.Controles.Grid.OEstiloColumna(arg.Nombre, arg.Nombre, arg.Estilo, arg.Alineacion, arg.With));
                    }
                }
            }
            cols.Add(new Orbita.Controles.Grid.OEstiloColumna("Mensaje", "Mensaje", Orbita.Controles.Grid.EstiloColumna.Texto, Orbita.Controles.Grid.Alineacion.Izquierda));
            return (cols);
        }
        /// <summary>
        /// Da formato a grid.
        /// </summary>
        /// <param name="grid">Grid a formatear.</param>
        private void FormatearGrid(Orbita.Controles.Grid.OrbitaUltraGridToolBar grid)
        {
            grid.OI.Apariencia.ColorBorde = Color.DimGray;
            grid.OI.Filas.Apariencia.ColorBorde = Color.Silver;
            grid.OI.Cabecera.Apariencia.ColorFondo = Color.DimGray;
            grid.OI.Celdas.Activas.Apariencia.ColorFondo = Color.FromArgb(255, 169, 64);
            grid.OI.Filas.Apariencia.ColorFondo = Color.White;
            grid.OI.Filas.Activas.Apariencia.ColorFondo = Color.DarkOrange;
            grid.OI.Filas.Alternas.Apariencia.ColorFondo = Color.White;
            grid.OI.Filtros.Apariencia.ColorFondo = Color.SandyBrown;
            grid.OI.Apariencia.ColorFondo = Color.White;
            grid.OI.Celdas.Activas.Apariencia.ColorTexto = Color.Black;
            grid.OI.Filas.Apariencia.ColorTexto = Color.Black;
            grid.OI.Filas.Activas.Apariencia.ColorTexto = Color.Black;
            grid.OI.Filas.Alternas.Apariencia.ColorTexto = Color.Black;
            grid.Toolbar.Appearance.BackColor = Color.Gray;
            grid.Toolbar.Appearance.BackColor2 = Color.LightGray;
            grid.Toolbar.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            grid.OI.MostrarToolRefrescar = false;
            grid.OI.MostrarToolLimpiarFiltros = false;
        }
        /// <summary>
        /// Inicializa las apariencias de las filas.
        /// </summary>
        private void InicializarApariencias()
        {
            _colorWarning = new Infragistics.Win.Appearance();
            _colorError = new Infragistics.Win.Appearance();
            _colorFatal = new Infragistics.Win.Appearance();
            _colorInfo = new Infragistics.Win.Appearance();
            _colorKeepAlive = new Infragistics.Win.Appearance();

            _colorWarning.BackColor = Color.Yellow;
            _colorWarning.BackColor2 = Color.FromArgb(255, 255, 128);
            _colorWarning.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            _colorError.BackColor = Color.Red;
            _colorError.BackColor2 = Color.FromArgb(255, 128, 128);
            _colorError.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            _colorFatal.BackColor = Color.Violet;
            _colorFatal.BackColor2 = Color.FromArgb(255, 128, 255);
            _colorFatal.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            _colorInfo.BackColor = Color.White;

            _colorKeepAlive.BackColor = Color.DarkGray;
            _colorKeepAlive.BackColor2 = Color.LightGray;
            _colorKeepAlive.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
        }
        /// <summary>
        /// Gestiona los filtros del datatable a partir del los botones pulsados.
        /// </summary>
        /// <param name="dt">datatable sobre el que se filtra.</param>
        /// <param name="grid">grid contenedor de los botones.</param>
        private void GestionFiltros(DataTable dt, Orbita.Controles.Grid.OrbitaUltraGridToolBar grid)
        {
            //Se obtienen los botones para conocer si pulsados.
            Infragistics.Win.UltraWinToolbars.StateButtonTool error = (Infragistics.Win.UltraWinToolbars.StateButtonTool)grid.Toolbar.Tools["errorGridError"];
            Infragistics.Win.UltraWinToolbars.StateButtonTool warning = (Infragistics.Win.UltraWinToolbars.StateButtonTool)grid.Toolbar.Tools["warningGridError"];
            Infragistics.Win.UltraWinToolbars.StateButtonTool fatal = (Infragistics.Win.UltraWinToolbars.StateButtonTool)grid.Toolbar.Tools["fatalGridError"];

            string filtro = string.Empty;
            if (error.Checked)
                filtro = "Nivel = 'ERROR'";

            if (warning.Checked)
            {
                if (filtro != string.Empty)
                    filtro = filtro + "OR Nivel = 'WARN'";
                else
                    filtro = "Nivel = 'WARN'";
            }

            if (fatal.Checked)
            {
                if (filtro != string.Empty)
                    filtro = filtro + "OR Nivel = 'FATAL'";
                else
                    filtro = "Nivel = 'FATAL'";
            }
            dt.DefaultView.RowFilter = filtro;
        }
        /// <summary>
        /// Establece el canal TCP para conexión remoting con logger.
        /// </summary>
        private void IniciarConexionRemoting()
        {
            int puerto = Convert.ToInt32(AppSettings.GetValues("Puerto")[0]);

            try
            {
                tsc = new TcpServerChannel(puerto);
            }
            catch (Exception)
            {
                IChannel[] myIChannelArray = System.Runtime.Remoting.Channels.ChannelServices.RegisteredChannels;
                for (int i = 0; i < myIChannelArray.Length; i++)
                {
                    System.Runtime.Remoting.Channels.ChannelServices.UnregisterChannel(myIChannelArray[i]);
                }
            }
            ChannelServices.RegisterChannel(tsc, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Logger), AppSettings.GetValues("Logger")[0].ToString(), WellKnownObjectMode.Singleton);
        }
        /// <summary>
        /// Cierra el canal TCP para conexión remoting con logger.
        /// </summary>
        private void PararConexionRemoting()
        {
            try
            {
                if (tsc != null)
                    ChannelServices.UnregisterChannel(tsc);
                tsc = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar el canal de comunicaciones TCP", ex);
            }
        }
        /// <summary>
        /// Configura el explorer bar.
        /// </summary>
        private void ConfigurarArbolLogs()
        {
            if (!ebArbol.Groups.Exists("Backup log"))
            {
                ebArbol.SuspendLayout();
                UltraExplorerBarGroup controlTree = this.ebArbol.Groups.Add("Backup log", "Backup log");
                controlTree.Settings.AppearancesLarge.NavigationPaneHeaderAppearance.BorderColor = System.Drawing.Color.Gainsboro;
                controlTree.Settings.NavigationPaneCollapsedGroupAreaText = controlTree.Text;
                this.ebArbol.GroupSettings.Style = GroupStyle.ControlContainer;
                this.ebArbol.NavigationPaneExpansionMode = NavigationPaneExpansionMode.OnButtonClickOrSizeChanged;

                controlTree.Container.Controls.Add(this.pnlArbol);
                this.pnlArbol.Dock = DockStyle.Fill;
                this.ebArbol.Appearance.BackColor = System.Drawing.SystemColors.Control;
                this.ebArbol.ResumeLayout();
            }
        }
        /// <summary>
        /// Carga el control TreeView.
        /// </summary>
        private void CargarArbolLogs()
        {
            try
            {
                ArbolLogs.Nodes.Clear();
                TreeNode nodo = new TreeNode();
                nodo.Text = AppSettings.GetValues("RutaLogs")[0].ToString();
                nodo.ImageIndex = 1;
                nodo.SelectedImageIndex = 0;
                ArbolLogs.Nodes.Add(nodo);
                //Llamada a método recursivo para carga de subdirectorios
                this.CargaDirectorio(nodo.Text, nodo);
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error en la carga del arbol de ficheros. ", ex);
            }
        }
        /// <summary>
        /// Método recursivo para carga del tree view.
        /// </summary>
        /// <param name="ruta">ruta del nodo.</param>
        /// <param name="padre">nodo padre.</param>
        private void CargaDirectorio(string ruta, TreeNode padre)
        {
            DirectoryInfo directorio = new DirectoryInfo(ruta);
            //obtenemos los subdirectorios.
            DirectoryInfo[] directorios = directorio.GetDirectories();
            //se comprueba si existe el directorio.
            if (!directorio.Exists) throw new DirectoryNotFoundException
                       ("No hay acceso al directorio:" + directorio);

            //si hay subdirectorios recursividad.
            if (directorios.Length != 0)
            {
                foreach (DirectoryInfo di in directorio.GetDirectories())
                {
                    TreeNode hijo = new TreeNode();
                    hijo.Text = di.Name;
                    hijo.ImageIndex = 1;
                    hijo.SelectedImageIndex = 0;
                    padre.Nodes.Add(hijo);
                    CargaDirectorio(hijo.FullPath, hijo);
                }
            }
            //cargamos los ficheros del directorio.
            foreach (FileInfo fi in directorio.GetFiles())
            {
                if (fi.Extension == AppSettings.GetValues("ExtensionLogs")[0].ToString().ToLower() || fi.Extension == AppSettings.GetValues("ExtensionLogs")[0].ToString().ToUpper())
                {
                    TreeNode child = new TreeNode();
                    child.Text = fi.Name;
                    child.ImageIndex = 2;
                    child.SelectedImageIndex = 2;
                    child.ToolTipText = CalcularTamanyo(fi.Length);
                    child.ContextMenuStrip = this.cmnTreeView;
                    padre.Nodes.Add(child);
                }
            }
        }
        /// <summary>
        /// Inicializa el formulario.
        /// </summary>
        private void InicializarControl(bool recarga)
        {
            try
            {
                _numWarning = 0; _numFatal = 0; _numError = 0;

                if (!CargarConfiguracion())
                    OMensajes.MostrarError("No se ha cargado la configuración de la aplicación.");
                else
                {
                    //Se carga la configuración de columnas de grids.
                    if (Convert.ToBoolean(AppSettings.GetValues("ActivarConfiguracionXML")[0]))
                    {
                        if (!this.CargarColumnas())
                            OMensajes.MostrarError("No se ha realizado la carga del fichero de configuración, compruebe que la ubicación y el fichero son correctos.");
                    }

                    this.InicializarApariencias();
                    //Cargamos el treeview.
                    this.ConfigurarArbolLogs();
                    this.CargarArbolLogs();

                    //Se añaden los botones a los grids.
                    if (!recarga)
                    {
                        this.oVisorDiferido1.InicializarControl(this._rutaConfiguracion);
                        this.gridTrazas.Toolbar.OI.AgregarToolButton(0, "Iniciar", "tracearGridTrazas", 0, Properties.Resources.Iniciar);
                        this.gridTrazas.Toolbar.OI.AgregarToolButton(0, "Limpiar", "limpiarGridTrazas", 1, Properties.Resources.Borrar);
                        this.gridTrazasError.Toolbar.OI.AgregarToolStateButton(0, "Fatales (0)", "fatalGridError", 0, Properties.Resources.Tool_Fatal);
                        this.gridTrazasError.Toolbar.OI.AgregarToolStateButton(0, "Errores (0)", "errorGridError", 1, Properties.Resources.Tool_Error);
                        this.gridTrazasError.Toolbar.OI.AgregarToolStateButton(0, "Warnings (0)", "warningGridError", 2, Properties.Resources.Tool_Warning);
                        this.gridTrazasError.Toolbar.OI.AgregarToolButton(0, "Limpiar", "limpiarGridTrazasError", 3, Properties.Resources.Borrar);
                    }
                    else
                    {
                        gridTrazasError.Toolbar.Tools["warningGridError"].SharedProps.Caption = "Warnings (0)";
                        gridTrazasError.Toolbar.Tools["errorGridError"].SharedProps.Caption = "Errores (0)";
                        gridTrazasError.Toolbar.Tools["fatalGridError"].SharedProps.Caption = "Fatales (0)";
                    }

                    //Se inicializan y formatean los grids.
                    this._dtGridTrazas = this.AddColumnasDataTableTrazas(new DataTable());
                    this._dtGridTrazasError = this._dtGridTrazas.Clone();

                    ArrayList cols = this.ColumnasGridTrazas(new ArrayList());
                    this.gridTrazas.OI.Formatear(this._dtGridTrazas, cols);
                    this.gridTrazasError.OI.Formatear(this._dtGridTrazasError, cols);

                    this.stEstadoApp.Panels["Puerto"].Text = AppSettings.GetValues("Puerto")[0].ToString();

                    if (!recarga)
                    {
                        this.FormatearGrid(gridTrazas);
                        this.FormatearGrid(gridTrazasError);
                    }
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error en el inicio de la aplicación.", ex);
            }
        }
        /// <summary>
        /// Vacia DataTable.
        /// </summary>
        /// <param name="dt">Tabla a limpiar.</param>
        private void Limpiar(DataTable dt)
        {
            dt.Clear();
            GC.Collect();
        }
        /// <summary>
        /// Calcula el tamaño de un fichero.
        /// </summary>
        /// <param name="len">longitud.</param>
        /// <returns>tamaño como string.</returns>
        private static string CalcularTamanyo(long len)
        {
            string[] tam = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (len >= 1024 && order + 1 < tam.Length)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.##} {1}", len, tam[order]);
        }
        /// <summary>
        /// Carga los datos de configuración en AppSettings.
        /// </summary>
        /// <returns>True si la carga ha sido correcta; false en caso contrario.</returns>
        private bool CargarConfiguracion()
        {
            string ficheroConfiguracionAplicacion = Path.Combine(this._rutaConfiguracion, "ConfiguracionVisorTCP.xml");

            if (ficheroConfiguracionAplicacion.StartsWith("file", true, null))
            {
                ficheroConfiguracionAplicacion = ficheroConfiguracionAplicacion.Remove(0, 6);
            }

            if (!File.Exists(ficheroConfiguracionAplicacion))
            {
                OMensajes.MostrarError("No se encuentra el fichero de configuración. " + this._rutaConfiguracion);
                return false;
            }

            XmlDocument ficheroXML = new XmlDocument();
            ficheroXML.Load(ficheroConfiguracionAplicacion);

            XmlNodeList listaNodos = ficheroXML.GetElementsByTagName("appSettings");

            AppSettings = new NameValueCollection();
            foreach (XmlNode nodo in listaNodos)
            {
                foreach (XmlNode clave in nodo.ChildNodes)
                {
                    if (clave.Attributes != null)
                    {
                        AppSettings.Add(clave.Attributes["key"].Value, clave.Attributes["value"].Value);
                    }
                }
            }
            return true;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento inicializa fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            try
            {
                //se aplica un color a las filas dependiendo del nivel del log
                switch ((NivelLog)Enum.Parse(typeof(NivelLog), e.Row.Cells["Nivel"].Value.ToString(), true))
                {
                    case NivelLog.Debug:
                    case NivelLog.Info:
                        if (!String.IsNullOrEmpty(Convert.ToString(e.Row.Cells["Mensaje"].Value)))
                        {
                            if (Convert.ToString(e.Row.Cells["Mensaje"].Value).Length >= 9)
                            {
                                if (Convert.ToString(e.Row.Cells["Mensaje"].Value).Substring(1, 9) == "KeepAlive")
                                {
                                    e.Row.Appearance = this._colorKeepAlive;
                                }
                                else
                                {
                                    e.Row.Appearance = this._colorInfo;
                                }
                            }
                        }
                        break;
                    case NivelLog.Warn:
                        e.Row.Appearance = this._colorWarning;
                        break;
                    case NivelLog.Error:
                        e.Row.Appearance = this._colorError;
                        break;
                    case NivelLog.Fatal:
                        e.Row.Appearance = this._colorFatal;
                        break;
                    default:
                        e.Row.Appearance = this._colorInfo;
                        break;
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error al iniciar una fila.", ex);
            }
        }
        /// <summary>
        /// Layout del grid con cabecera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InitializeLayoutWithHeader(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            e.Layout.Bands[0].Columns["Mensaje"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Bands[0].Columns["Mensaje"].CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
        }
        /// <summary>
        /// Layout del grid sin cabecera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InitializeLayoutWithoutHeader(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
            e.Layout.Bands[0].Columns["Mensaje"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Bands[0].Columns["Mensaje"].CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
            e.Layout.Bands[0].ColHeadersVisible = false;
            e.Layout.RefreshFilters();
        }
        /// <summary>
        /// Evento double click fila de todos los grids. Abre formulario detalle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (!e.Row.IsFilterRow)
            {
                using (FrmDetalle frmDetalle = new FrmDetalle(e.Row))
                {
                    frmDetalle.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Visualización del grid TrazasErrores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tsmiVerTrazasErrores_Click(object sender, EventArgs e)
        {
            tsmiVerTrazasErrores.Checked = !tsmiVerTrazasErrores.Checked;
            splitContenedorTrazas.Panel2Collapsed = !tsmiVerTrazasErrores.Checked;
        }
        /// <summary>
        /// Visualización del grid LogsErrores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tsmiVerLogsErrores_Click(object sender, EventArgs e)
        {
            tsmiVerLogsErrores.Checked = !tsmiVerLogsErrores.Checked;

            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in tabDiferido.Tabs)
            {
                if (tab.TabPage.Controls[0] is OrbitaVisorDiferido)
                {
                    OrbitaVisorDiferido visor = (OrbitaVisorDiferido)tab.TabPage.Controls[0];
                    visor.VerVisorErrores = !tsmiVerLogsErrores.Checked;
                }
            }
        }
        /// <summary>
        /// Evento CLick botones toolbar grids.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case "limpiarGridTrazas":
                        this.Limpiar(this._dtGridTrazas);
                        break;
                    case "limpiarGridTrazasError":
                        {
                            _numWarning = 0; _numFatal = 0; _numError = 0;
                            gridTrazasError.Toolbar.Tools["warningGridError"].SharedProps.Caption = "Warnings (0)";
                            gridTrazasError.Toolbar.Tools["errorGridError"].SharedProps.Caption = "Errores (0)";
                            gridTrazasError.Toolbar.Tools["fatalGridError"].SharedProps.Caption = "Fatales (0)";
                            Limpiar(this._dtGridTrazasError);
                            break;
                        }
                    case "errorGridError":
                    case "warningGridError":
                    case "fatalGridError":
                        this.GestionFiltros(_dtGridTrazasError, gridTrazasError);
                        break;
                    case "tracearGridTrazas":
                        {
                            if (!this._pararTrazas)
                            {
                                e.Tool.SharedProps.Caption = "Iniciar";
                                e.Tool.SharedProps.AppearancesSmall.Appearance.Image = Properties.Resources.Iniciar;
                                stEstadoApp.Panels["Estado"].Appearance.Image = Properties.Resources.EstadoDetenido;
                                stEstadoApp.Panels["EstadoTexto"].Text = "Detenido";
                                stEstadoApp.Panels["Fecha"].Visible = false;
                                this.PararConexionRemoting();
                            }
                            else
                            {
                                e.Tool.SharedProps.Caption = "Parar";
                                e.Tool.SharedProps.AppearancesSmall.Appearance.Image = Properties.Resources.Parar;
                                stEstadoApp.Panels["Estado"].Appearance.Image = Properties.Resources.EstadoIniciado;
                                stEstadoApp.Panels["EstadoTexto"].Text = "Iniciado";
                                stEstadoApp.Panels["Fecha"].Visible = true;
                                stEstadoApp.Panels["Fecha"].Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                this.IniciarConexionRemoting();

                            }
                            this._pararTrazas = !this._pararTrazas;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Evento botón configuración.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGeneral_Click(object sender, EventArgs e)
        {
            if (_pararTrazas)
            {
                using (FrmConfigLogger frm = new FrmConfigLogger(this.AppSettings, Path.Combine(this._rutaConfiguracion, "ConfiguracionVisorTCP.xml")))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        InicializarControl(true);
                    }
                }
            }
            else
            {
                OMensajes.MostrarAviso("Debe parar las trazas remoting para modificar la configuración.");
            }
        }
        /// <summary>
        /// Evento abrir en otra pestaña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAbrirEnOtraPestaña_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                Cursor = Cursors.AppStarting;
                string key = tabDiferido.Tabs.Count.ToString();
                tabDiferido.Tabs.Add(key, ArbolLogs.SelectedNode.Text);
                tabDiferido.Tabs[key].CloseButtonVisibility = Infragistics.Win.UltraWinTabs.TabCloseButtonVisibility.Always;
                tabDiferido.Tabs[key].AllowClosing = Infragistics.Win.DefaultableBoolean.True;
                OrbitaVisorDiferido visordiferido = new OrbitaVisorDiferido();
                visordiferido.InicializarControl(this._rutaConfiguracion);
                tabDiferido.Tabs[key].TabPage.Controls.Add(visordiferido);
                visordiferido.Dock = DockStyle.Fill;
                visordiferido.Tamaño = "Tamaño " + ArbolLogs.SelectedNode.Text + ": " + ArbolLogs.SelectedNode.ToolTipText;
                visordiferido.LogAGrid(ArbolLogs.SelectedNode.FullPath);
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Evento abrir en pestaña principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAbrirEnPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                string strFullPath = ArbolLogs.SelectedNode.FullPath;
                //Si es un fichero de tipo log.
                if (strFullPath.EndsWith(AppSettings.GetValues("ExtensionLogs")[0].ToString().ToLower()) || strFullPath.EndsWith(AppSettings.GetValues("ExtensionLogs")[0].ToString().ToUpper()))
                {
                    Application.DoEvents();
                    Cursor = Cursors.AppStarting;
                    oVisorDiferido1.LogAGrid(strFullPath);
                    oVisorDiferido1.Tamaño = "Tamaño " + ArbolLogs.SelectedNode.Text + ": " + ArbolLogs.SelectedNode.ToolTipText;
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Evento cerrar el tab page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tabDiferido_TabClosed(object sender, Infragistics.Win.UltraWinTabControl.TabClosedEventArgs e)
        {
            try
            {
                Application.DoEvents();
                Cursor = Cursors.AppStarting;
                using (OrbitaVisorDiferido visor = (OrbitaVisorDiferido)e.Tab.TabPage.Controls[0])
                {
                    visor.LimpiarExterno();
                }
                tabDiferido.Tabs.Remove(e.Tab);
                GC.Collect();
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Carga del control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void oVisorTCP_Load(object sender, EventArgs e)
        {
            if (this._iniciarControl)
                InicializarControl(false);
        }
        #endregion
    }
}