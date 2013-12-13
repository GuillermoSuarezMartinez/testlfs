using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Orbita.Trazabilidad;
using Orbita.Utiles;
namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaVisorDiferido : UserControl
    {
        #region Atributos
        /// <summary>
        /// Contiene los datos de configuración de la aplicación almacenados en el ficherod e configuración.
        /// </summary>
        NameValueCollection AppSettings;
        /// <summary>
        /// Contiene listado de argumentos del mensaje de log (columnas a monitorizar en grids) Backup.
        /// </summary>
        Dictionary<int, Argumento> ListaColumnasBackup;
        /// <summary>
        /// Apariencias generales. Color líneas.
        /// </summary>
        Infragistics.Win.Appearance _colorWarning;
        Infragistics.Win.Appearance _colorError;
        Infragistics.Win.Appearance _colorFatal;
        Infragistics.Win.Appearance _colorInfo;
        Infragistics.Win.Appearance _colorKeepAlive;
        /// <summary>
        /// Número de trazas fatal.
        /// </summary>
        int _numFatal;
        /// <summary>
        /// Número de error fatal.
        /// </summary>
        int _numError;
        /// <summary>
        /// Número de warning fatal.
        /// </summary>
        int _numWarning;
        /// <summary>
        /// Tabla de datos del gridLog.
        /// </summary>
        DataTable _dtGridLog;
        /// <summary>
        /// Tabla de datos del gridLogError.
        /// </summary>
        DataTable _dtGridLogError;
        /// <summary>
        /// Etiqueta con tamaño del fichero.
        /// </summary>
        string _tamaño;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor del control.
        /// </summary>
        public OrbitaVisorDiferido()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Visualización del grid errores.
        /// </summary>
        public bool VerVisorErrores
        {
            get { return splitContenedorLogs.Panel2Collapsed; }
            set { splitContenedorLogs.Panel2Collapsed = value; }
        }
        /// <summary>
        /// Tamaño del fichero visualizado.
        /// </summary>
        public string Tamaño
        {
            get { return this._tamaño; }
            set
            {
                this._tamaño = value;
                if ((this.gridLog.Toolbar.Toolbars[0].Tools.Exists("Tamanyo")))
                {
                    gridLog.Toolbar.Tools["Tamanyo"].SharedProps.Caption = _tamaño;
                }
            }
        }
        #endregion

        #region Método(s) Público(s)
        /// <summary>
        /// Inicializa el control.
        /// </summary>
        public void InicializarControl(string ruta)
        {
            this.InicializarApariencias();
            _numWarning = 0; _numFatal = 0; _numError = 0;
            if (!CargarConfiguracion(ruta))
                OMensajes.MostrarError("No se ha cargado la configuración de la aplicación.");
            else
            {
                if (Convert.ToBoolean(AppSettings.GetValues("ActivarConfiguracionXML")[0]))
                {
                    if (!this.CargarColumnas(ruta))
                        OMensajes.MostrarError("No se ha realizado la carga del fichero de configuración, compruebe que la ubicación y el fichero son correctos.");
                }
                this.gridLog.Toolbar.OI.AgregarToolButton(0, "Limpiar", "limpiarGridLog", 0, Properties.Resources.Borrar);
                this.gridLog.Toolbar.OI.AgregarToolLabel(0, "Tamaño", "Tamanyo", 1);
                this.gridLogError.Toolbar.OI.AgregarToolStateButton(0, "Fatales (0)", "fatalGridError", 0, Properties.Resources.Tool_Fatal);
                this.gridLogError.Toolbar.OI.AgregarToolStateButton(0, "Errores (0)", "errorGridError", 1, Properties.Resources.Tool_Error);
                this.gridLogError.Toolbar.OI.AgregarToolStateButton(0, "Warnings (0)", "warningGridError", 2, Properties.Resources.Tool_Warning);
                this.gridLogError.Toolbar.OI.AgregarToolButton(0, "Limpiar", "limpiarGridLogError", 3, Properties.Resources.Borrar);

                FormatearGrid(gridLog);
                FormatearGrid(gridLogError);
            }
        }
        /// <summary>
        /// Llena el grid con el fichero de log (Backup).
        /// </summary>
        /// <param name="rutaFichero"></param>
        public void LogAGrid(string rutaFichero)
        {
            gridLog.SuspendLayout();
            //Se resetean los elementos
            _numError = 0; _numFatal = 0; _numWarning = 0;
            gridLogError.Toolbar.Tools["warningGridError"].SharedProps.Caption = "Warnings (0)";
            gridLogError.Toolbar.Tools["errorGridError"].SharedProps.Caption = "Errores (0)";
            gridLogError.Toolbar.Tools["fatalGridError"].SharedProps.Caption = "Fatales (0)";
            this._dtGridLog = null;
            string sLinea = null;
            string[] arDato;
            DataRow drDato;

            string fecha = string.Empty;
            string nivel = string.Empty;

            this._dtGridLog = this.AddColumnasDataTableBackup(new DataTable());
            this._dtGridLogError = this._dtGridLog.Clone();

            FileStream fs = new FileStream(rutaFichero, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader sr = new StreamReader(fs))
            {
                while ((sLinea = Formatear(sr.ReadLine())) != null)
                {
                    fecha = sLinea.Substring(0, 25);
                    fecha = fecha.TrimEnd();
                    nivel = sLinea.Substring(25, 5);
                    nivel = nivel.TrimEnd();
                    sLinea = sLinea.Remove(0, 32);
                    arDato = sLinea.Split(new string[] { " - " }, StringSplitOptions.None);
                    drDato = this._dtGridLog.NewRow();

                    drDato["Fecha"] = fecha;
                    drDato["Nivel"] = nivel;
                    drDato["Mensaje"] = arDato[0];

                    if (this.ListaColumnasBackup != null && this.ListaColumnasBackup.Values.Count > 0)
                    {
                        foreach (Argumento arg in this.ListaColumnasBackup.Values)
                        {
                            if (arg.ID <= arDato.Length - 1)
                            {
                                drDato[arg.Nombre] = arDato[arg.ID];
                            }
                        }
                    }

                    this._dtGridLog.Rows.InsertAt(drDato, 0);
                    // Añadir una fila a la tabla de errores, si procede.
                    switch ((NivelLog)Enum.Parse(typeof(NivelLog), nivel, true))
                    {
                        case NivelLog.Warn:
                        case NivelLog.Error:
                        case NivelLog.Fatal:
                            DataRow drDatoExtendido = this._dtGridLogError.NewRow();
                            drDatoExtendido.ItemArray = this._dtGridLog.Rows[0].ItemArray;
                            this._dtGridLogError.Rows.InsertAt(drDatoExtendido, 0);
                            break;
                        default:
                            break;
                    }

                    switch ((NivelLog)Enum.Parse(typeof(NivelLog), nivel, true))
                    {
                        case NivelLog.Warn:
                            _numWarning++;
                            gridLogError.Toolbar.Tools["warningGridError"].SharedProps.Caption = "Warnings (" + _numWarning.ToString() + ")";
                            break;
                        case NivelLog.Error:
                            _numError++;
                            gridLogError.Toolbar.Tools["errorGridError"].SharedProps.Caption = "Errores (" + _numError.ToString() + ")";
                            break;
                        case NivelLog.Fatal:
                            _numFatal++;
                            gridLogError.Toolbar.Tools["fatalGridError"].SharedProps.Caption = "Fatales (" + _numFatal.ToString() + ")";
                            break;
                        default:
                            break;
                    }
                }
            }
            this._dtGridLog.AcceptChanges();
            ArrayList cols = this.ColumnasGridBackup(new ArrayList());
            gridLog.OI.Formatear(this._dtGridLog, cols);

            // ...gridLogError.
            if (_dtGridLogError != null)
            {
                gridLogError.OI.Formatear(_dtGridLogError, cols);
            }
            gridLog.ResumeLayout();
        }
        /// <summary>
        /// Vacia DataTable.
        /// </summary>
        public void LimpiarExterno()
        {
            this.Limpiar(_dtGridLogError);
            this.Limpiar(_dtGridLog);
        }
        #endregion

        #region Métodos Privado(s)
        /// <summary>
        /// Carga los datos de configuración en AppSettings.
        /// </summary>
        /// <returns>True si la carga ha sido correcta; false en caso contrario.</returns>
        private bool CargarConfiguracion(string ruta)
        {
            string ficheroConfiguracionAplicacion = Path.Combine(ruta, "ConfiguracionVisorTCP.xml");

            if (ficheroConfiguracionAplicacion.StartsWith("file", true, null))
            {
                ficheroConfiguracionAplicacion = ficheroConfiguracionAplicacion.Remove(0, 6);
            }

            if (!File.Exists(ficheroConfiguracionAplicacion))
            {
                OMensajes.MostrarError("No se encuentra el fichero de configuración. " + ficheroConfiguracionAplicacion);
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
        /// <summary>
        /// Carga las colecciones con los argumentos/columnas correspondientes.
        /// </summary>
        /// <returns>Carga correcta.</returns>
        private bool CargarColumnas(string ruta)
        {
            try
            {
                string ficheroConfiguracion = Path.Combine(ruta, "GestionColumnas.xml");
                //Se comprueba si existe el fichero
                if (!File.Exists(ficheroConfiguracion))
                {
                    OMensajes.MostrarError("Ruta: " + ficheroConfiguracion);
                    return false;
                }

                XmlDocument ficheroXML = new XmlDocument();
                ficheroXML.Load(ficheroConfiguracion);

                ListaColumnasBackup = new Dictionary<int, Argumento>();

                foreach (XmlNode nodo in ficheroXML.GetElementsByTagName("backup"))
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

                            ListaColumnasBackup.Add(arg.ID, arg);
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
        /// Columnas de tabla backup logs.
        /// </summary>
        /// <param name="dt">DataTable a formatear.</param>
        /// <returns>DataTable formateado.</returns>
        private DataTable AddColumnasDataTableBackup(DataTable dt)
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
            if (this.ListaColumnasBackup != null && this.ListaColumnasBackup.Values.Count > 0)
            {
                foreach (Argumento arg in this.ListaColumnasBackup.Values)
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
        private ArrayList ColumnasGridBackup(ArrayList cols)
        {
            cols.Add(new Orbita.Controles.Grid.OEstiloColumna("Nivel", "Nivel", Orbita.Controles.Grid.EstiloColumna.Texto, Orbita.Controles.Grid.Alineacion.Izquierda, 54));
            cols.Add(new Orbita.Controles.Grid.OEstiloColumna("Fecha", "Fecha", Orbita.Controles.Grid.EstiloColumna.Fecha, Orbita.Controles.Grid.Alineacion.Centrado, new Orbita.Controles.Grid.OMascara("dd/mm/yyyy hh:mm:ss"), 120));
            //se comprueba si hay columnas adicionales.
            if (this.ListaColumnasBackup != null && this.ListaColumnasBackup.Values.Count > 0)
            {
                foreach (Argumento arg in this.ListaColumnasBackup.Values)
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
        private static void FormatearGrid(Orbita.Controles.Grid.OrbitaUltraGridToolBar grid)
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
        private static void GestionFiltros(DataTable dt, Orbita.Controles.Grid.OrbitaUltraGridToolBar grid)
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
        /// Vacia DataTable.
        /// </summary>
        /// <param name="dt">Tabla a limpiar.</param>
        private void Limpiar(DataTable dt)
        {
            if (dt != null)
            {
                dt.Clear();
                GC.Collect();
            }
        }
        /// <summary>
        /// Formatea línea pasada como parámetro.
        /// </summary>
        /// <param name="linea">Línea a formatear.</param>
        /// <returns>Línea formateada.</returns>
        private static string Formatear(string linea)
        {
            try
            {
                if (linea == null) { return null; }
                return linea;
            }
            catch (Exception ex) { throw ex; }
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
                                    e.Row.Appearance = this._colorKeepAlive;
                                else
                                    e.Row.Appearance = this._colorInfo;
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
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Layout del grid con cabecera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InitializeLayoutWithHeader(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
                e.Layout.Bands[0].Columns["Mensaje"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
                e.Layout.Bands[0].Columns["Mensaje"].CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Layout del grid sin cabecera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InitializeLayoutWithoutHeader(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            {
                e.Layout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree;
                e.Layout.Bands[0].Columns["Mensaje"].CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
                e.Layout.Bands[0].Columns["Mensaje"].CellDisplayStyle = Infragistics.Win.UltraWinGrid.CellDisplayStyle.FormattedText;
                e.Layout.Bands[0].ColHeadersVisible = false;
                e.Layout.RefreshFilters();
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Evento double click fila de todos los grids. Abre formulario detalle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                if (!e.Row.IsFilterRow)
                {
                    using (FrmDetalle frmDetalle = new FrmDetalle(e.Row))
                    {
                        frmDetalle.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
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
                    case "limpiarGridLogError":
                        {
                            _numWarning = 0; _numFatal = 0; _numError = 0;
                            gridLogError.Toolbar.Tools["warningGridError"].SharedProps.Caption = "Warnings (0)";
                            gridLogError.Toolbar.Tools["errorGridError"].SharedProps.Caption = "Errores (0)";
                            gridLogError.Toolbar.Tools["fatalGridError"].SharedProps.Caption = "Fatales (0)";
                            Limpiar(this._dtGridLogError);
                            break;
                        }
                    case "limpiarGridLog":
                        gridLog.Toolbar.Tools["Tamanyo"].SharedProps.Caption = string.Empty;
                        Limpiar(this._dtGridLog);
                        break;
                    case "errorGridError":
                    case "warningGridError":
                    case "fatalGridError":
                        GestionFiltros(_dtGridLogError, gridLogError);
                        break;
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        #endregion
    }
}