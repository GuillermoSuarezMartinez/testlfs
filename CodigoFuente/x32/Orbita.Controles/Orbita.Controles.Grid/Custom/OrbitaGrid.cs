//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.Grid.OrbitaGrid.
    /// </summary>
    public partial class OrbitaGrid : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos privados

        #region Grid
        /// <summary>
        /// Altura de fila.
        /// </summary>
        int filaAlto = OConfiguracion.OrbGridFilaAlto;
        /// <summary>
        /// Altura mínima de fila.
        /// </summary>
        int filaAltoMinimo = OConfiguracion.OrbGridFilaAltoMinimo;
        /// <summary>
        /// Color de filas contiguas agrupadas (Merge).
        /// </summary>
        System.Drawing.Color? filaColorContiguasAgrupadas;
        /// <summary>
        /// Confirmación de borrado de filas.
        /// </summary>
        bool filaConfirmarBorrar = OConfiguracion.OrbGridFilaConfirmarBorrar;
        /// <summary>
        /// Permitir multiselección de filas.
        /// </summary>
        bool filaPermitirMultiSeleccion = OConfiguracion.OrbGridFilaPermitirMultiSeleccion;
        /// <summary>
        /// Mostrar recuento de filas en la banda de sumario.
        /// </summary>
        bool sumarioMostrarRecuentoFilas = OConfiguracion.OrbGridSumarioMostrarRecuentoFilas;
        /// <summary>
        /// Establece si la tecla Return debe ser ignorada en su pulsación.
        /// </summary>
        bool gridIgnorarReturn = OConfiguracion.OrbGridIgnorarReturn;
        /// <summary>
        /// Indica el bloqueo de todas las columnas.
        /// </summary>
        bool columnaBloqueadas;
        /// <summary>
        /// Autoajustar las columnas del control.
        /// </summary>
        Infragistics.Win.UltraWinGrid.AutoFitStyle columnasAutoajustar;
        /// <summary>
        /// Indica si existen columnas calculadas.
        /// </summary>
        bool columnaExistenCalculadas = false;
        /// <summary>
        /// Estado anterior del orden establecido.
        /// </summary>
        bool ordenEstadoAnterior = false;
        /// <summary>
        /// Orden del nombre de campo.
        /// </summary>
        string ordenNombreCampo;
        /// <summary>
        /// Colección de columnas visibles.
        /// </summary>
        System.Collections.ArrayList columnasVisibles;
        #endregion

        #region ToolBar
        /// <summary>
        /// Ocultar el texto de las Tools de la ToolBar.
        /// </summary>
        Infragistics.Win.UltraWinToolbars.ToolDisplayStyle toolBarToolEstilo = OConfiguracion.OrbGridToolBarToolEstilo;
        /// <summary>
        /// Colección de plantillas.
        /// </summary>
        System.Collections.Generic.Dictionary<string, Orbita.Controles.Grid.OPlantilla> plantillasActivas = null;
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OrbitaGrid.
        /// </summary>
        public OrbitaGrid()
        {
            InitializeComponent();
            InicializarEstilo();
            InitializeResourceStrings();
        }
        #endregion

        #region Delegados públicos
        /// <summary>
        /// Delegado BeforeCellUpdate.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e);
        /// <summary>
        /// Delegado BeforeCellActive.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void BeforeCellActive(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e);
        /// <summary>
        /// Delegado CeldaFinEdicionHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="celda"></param>
        public delegate void CeldaFinEdicionHandler(object sender, Infragistics.Win.UltraWinGrid.UltraGridCell celda);
        /// <summary>
        /// Delegado CeldaCambiaValorHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="celda"></param>
        public delegate void CeldaCambiaValorHandler(object sender, Infragistics.Win.UltraWinGrid.UltraGridCell celda);
        /// <summary>
        /// Delegado FilaSeleccionadaHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="fila"></param>
        public delegate void FilaSeleccionadaHandler(object sender, Infragistics.Win.UltraWinGrid.UltraGridRow fila);
        /// <summary>
        /// Delegado DobleClickFilaHandler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="fila"></param>
        public delegate void DobleClickFilaHandler(object sender, Infragistics.Win.UltraWinGrid.UltraGridRow fila);
        /// <summary>
        /// Delegado FilaFiltradoHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void FilaFiltradoHandler(object sender, Infragistics.Win.UltraWinGrid.FilterRowEventArgs e);
        /// <summary>
        /// Delegado FiltradoFinalizadoHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void FiltradoFinalizadoHandler(object sender, Infragistics.Win.UltraWinGrid.FilterRowEventArgs e);
        /// <summary>
        /// Delegado DobleClickCeldaHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="celda"></param>
        public delegate void DobleClickCeldaHandler(object sender, Infragistics.Win.UltraWinGrid.UltraGridCell celda);
        /// <summary>
        /// Delegado ErrorHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void ErrorHandler(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e);
        /// <summary>
        /// Delegado InitializeLayoutHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void InitializeLayoutHandler(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e);
        /// <summary>
        /// Delegado InitializeRowHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void InitializeRowHandler(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e);
        /// <summary>
        /// Delegado OrbInitializeTemplateAddRowHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void InitializeTemplateAddRowHandler(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e);
        /// <summary>
        /// Delegado OrbClickCellButtonHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void ClickCellButtonHandler(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e);
        /// <summary>
        /// Delegado OrbToolBarClickHandler.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void ToolBarClickHandler(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoRefrescar.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoRefrescar(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoRefrescar2.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoRefrescar2(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoEliminarFila.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoEliminarFila(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado orbDelegadoExportarExcel.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoExportarExcel(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoGestionar.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoGestionar(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoModificar.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoModificar(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoVer.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoVer(object sender, System.EventArgs e);
        /// <summary>
        /// Delegado OrbDelegadoAñadir.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoAñadir(object sender, System.EventArgs e);
        /// <summary>
        /// Permite a los formularios que contengan este control, saber en que momento se activan/desactivan los botones de orden.
        /// </summary>
        /// <param name="activo"></param>
        public delegate void OrbDelegadoOrdenActivo(bool activo);
        #endregion

        #region Eventos públicos
        /// <summary>
        /// Se ejecuta cuando se comienza a editar una celda
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Comienza celda edición.")]
        public event BeforeCellUpdate OrbCeldaComienzoEdicion;
        /// <summary>
        /// Se ejecuta al ppio de activar la celda
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Comienza activación celda.")]
        public event BeforeCellActive OrbCeldaComienzoActivacion;
        /// <summary>
        /// Se ejecuta cuando se sale de la celda despues de haberla editado.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Se ejecuta cuando se sale de la celda despues de haberla editado.")]
        public event CeldaFinEdicionHandler OrbCeldaFinEdicion;
        /// <summary>
        /// Se ejecuta cuando se produce un cambio en la celda.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Se ejecuta cuando se produce un cambio en la celda.")]
        public event CeldaCambiaValorHandler OrbCeldaCambiaValor;
        /// <summary>
        /// Despues de seleccionar una fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Despues de seleccionar una fila.")]
        public event FilaSeleccionadaHandler OrbFilaSeleccionada;
        /// <summary>
        /// Despues de seleccionar la fila de los filtros.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Despues de seleccionar la fila de los filtros.")]
        public event FilaSeleccionadaHandler OrbFilaFiltrosSeleccionada;
        /// <summary>
        /// Doble click en una fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Doble click en una fila.")]
        public event DobleClickFilaHandler OrbDobleClickFila;
        /// <summary>
        /// Fila filtrada.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Fila filtrada.")]
        public event FilaFiltradoHandler OrbFilaFiltrada;
        /// <summary>
        /// Filtrado finalizado.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Filtrado finalizado.")]
        public event FiltradoFinalizadoHandler OrbFiltradoFinalizado;
        /// <summary>
        /// Doble click en una celda.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Doble click en una celda.")]
        public event DobleClickCeldaHandler OrbDobleClickCelda;
        /// <summary>
        /// Error en el Grid.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Error en el Grid.")]
        public event ErrorHandler OrbErrorGrid;
        /// <summary>
        /// Inicializar layout.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Inicializar layout.")]
        public event InitializeLayoutHandler OrbInitializeLayout;
        /// <summary>
        /// Inicializar fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Inicializar fila.")]
        public event InitializeRowHandler OrbInitializeRow;
        /// <summary>
        /// Inicializar nueva fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Inicializar nueva fila.")]
        public event InitializeTemplateAddRowHandler OrbInitializeTemplateAddRow;
        /// <summary>
        /// Click en EditButton.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Click en EditButton.")]
        public event ClickCellButtonHandler OrbClickCellButton;
        /// <summary>
        /// ToolBar Button Click.
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Hacer click en un botón de la barra de herramientas.")]
        public event ToolBarClickHandler OrbToolBarClick;
        /// <summary>
        /// Refrescar Button Click
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Refrescar Button Click.")]
        public event OrbDelegadoRefrescar OrbBotonRefrescarClick;
        /// <summary>
        /// Refrescar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Refrescar Button Click.")]
        public event OrbDelegadoRefrescar2 OrbToolRefrescar;
        /// <summary>
        /// Refrescar Button Click
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Eliminar fila Button Click.")]
        public event OrbDelegadoEliminarFila OrbBotonEliminarFilaClick;
        /// <summary>
        /// Exportar a excel Button Click.
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Exportar a Excel Button Click.")]
        public event OrbDelegadoExportarExcel OrbBotonExportarExcel;
        /// <summary>
        /// Gestionar Button Click.
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Gestionar Button Click.")]
        public event OrbDelegadoGestionar OrbBotonGestionarClick;
        /// <summary>
        /// Ver Button Click.
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Ver Button Click.")]
        public event OrbDelegadoVer OrbBotonVerClick;
        /// <summary>
        /// Modificar Button Click
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Modificar Button Click.")]
        public event OrbDelegadoModificar OrbBotonModificarClick;
        /// <summary>
        /// Añadir Button Click.
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Añadir Button Click.")]
        public event OrbDelegadoAñadir OrbBotonAñadirClick;
        /// <summary>
        /// Evento que indica un cambio en la activación de los botones de orden debido a un cambio en filtros del Grid.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Evento que indica un cambio en la activación de los botones de orden debido a un cambio en filtros del Grid, en el sender tendremos el estado de activación de los botones de orden(true,false).")]
        public event OrbDelegadoOrdenActivo OrbOrdenCambioActivacion;
        #endregion

        #region Propiedades

        /// <summary>
        /// Array de columnas configuradas (visisbles).
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Browsable(false)]
        public System.Collections.ArrayList OrbColumnasVisibles
        {
            get { return this.columnasVisibles; }
        }

        #region Grid

        #region Cabecera
        /// <summary>
        /// Permitir mostrar el texto de la cabecera en múltiples líneas si varía el tamaño de la columna.
        /// </summary>
        [System.ComponentModel.Category("Orbita Cabecera")]
        [System.ComponentModel.Description("Permitir alinear el texto de la cabecera.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridCabeceraAlineacion)]
        public Infragistics.Win.HAlign OrbCabeceraAlineacion
        {
            get { return grid.DisplayLayout.Override.HeaderAppearance.TextHAlign; }
            set { grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = value; }
        }
        /// <summary>
        /// Color del texto de las cabeceras de columnas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Cabecera")]
        [System.ComponentModel.Description("Color del texto de las cabeceras de columnas.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorCabecera)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbCabeceraColor
        {
            get { return this.grid.DisplayLayout.Override.HeaderAppearance.ForeColor; }
            set { this.grid.DisplayLayout.Override.HeaderAppearance.ForeColor = value; }
        }
        /// <summary>
        /// Permitir mostrar el estilo de la cabecera.
        /// </summary>
        [System.ComponentModel.Category("Orbita Cabecera")]
        [System.ComponentModel.Description("Permitir mostrar el estilo de la cabecera.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridCabeceraEstilo)]
        public Infragistics.Win.HeaderStyle OrbCabeceraEstilo
        {
            get { return this.grid.DisplayLayout.Override.HeaderStyle; }
            set { this.grid.DisplayLayout.Override.HeaderStyle = value; }
        }
        /// <summary>
        /// Permitir mostrar el texto de la cabecera en múltiples líneas si varía el tamaño de la columna.
        /// </summary>
        [System.ComponentModel.Category("Orbita Cabecera")]
        [System.ComponentModel.Description("Permitir mostrar el texto de la cabecera en múltiples líneas si varía el tamaño de la columna.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridCabeceraMultilinea)]
        public bool OrbCabeceraMultilinea
        {
            get { return GetBoolean(this.grid.DisplayLayout.Override.WrapHeaderText); }
            set { this.grid.DisplayLayout.Override.WrapHeaderText = GetDefaultableBoolean(value); }
        }
        #endregion

        #region Celda
        /// <summary>
        /// Color de la celda activa.
        /// </summary>
        [System.ComponentModel.Category("Orbita Celda")]
        [System.ComponentModel.Description("Color de la celda activa.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorCeldaActiva)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbCeldaColorActiva
        {
            get { return this.OrbGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor; }
            set { this.OrbGrid.DisplayLayout.Override.ActiveCellAppearance.BackColor = value; }
        }
        /// <summary>
        /// Color del texto de la celda activa.
        /// </summary>
        [System.ComponentModel.Category("Orbita Celda")]
        [System.ComponentModel.Description("Color del texto de la celda activa.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorTextoCeldaActiva)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbCeldaColorActivaTexto
        {
            get { return this.OrbGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor; }
            set { this.OrbGrid.DisplayLayout.Override.ActiveCellAppearance.ForeColor = value; }
        }
        /// <summary>
        /// Permitir editar contenido.
        /// </summary>
        [System.ComponentModel.Category("Orbita Celda")]
        [System.ComponentModel.Description("Permitir editar contenido.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridCeldaEditable)]
        public bool OrbCeldaEditable
        {
            get { return GetBoolean(this.OrbGrid.DisplayLayout.Override.AllowUpdate); }
            set
            {
                if (value)
                {
                    this.OrbGrid.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy |
                        Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste |
                        Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo;
                    this.OrbGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    this.OrbGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                }
                else
                {
                    this.OrbGrid.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy;
                    this.OrbGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
                    this.OrbGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                }
            }
        }
        #endregion

        #region Columna
        /// <summary>
        /// Autoajustar las columnas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Columna")]
        [System.ComponentModel.Description("Autoajustar las columnas.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridColumnaAutoajuste)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.None)]
        public Infragistics.Win.UltraWinGrid.AutoFitStyle OrbColumnaAutoAjuste
        {
            get { return this.columnasAutoajustar; }
            set
            {
                this.columnasAutoajustar = value;
                this.grid.DisplayLayout.AutoFitStyle = this.columnasAutoajustar;
            }
        }
        #endregion

        #region Fila
        /// <summary>
        /// Obtener la fila activa (es identico a this.{NombreGrid}.OrbGrid.ActiveRow).
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("Obtener la fila activa (es identico a this.{NombreGrid}.OrbGrid.ActiveRow).")]
        public Infragistics.Win.UltraWinGrid.UltraGridRow OrbFilaActiva
        {
            get { return this.OrbGrid.ActiveRow; }
            set { this.OrbGrid.ActiveRow = value; }
        }
        /// <summary>
        /// Alto de la fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Alto de la fila.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaAlto)]
        public int OrbFilaAlto
        {
            get { return this.filaAlto; }
            set
            {
                this.filaAlto = value;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.grid.DisplayLayout.Bands)
                {
                    ugb.Override.DefaultRowHeight = this.filaAlto;
                }
            }
        }
        /// <summary>
        /// Alto de la fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Alto mínimo de la fila.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaAltoMinimo)]
        public int OrbFilaAltoMinimo
        {
            get { return this.filaAltoMinimo; }
            set
            {
                this.filaAltoMinimo = value;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.grid.DisplayLayout.Bands)
                {
                    ugb.Override.MinRowHeight = this.filaAltoMinimo;
                }
            }
        }
        /// <summary>
        /// Color de la fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color de la fila.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorFila)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColor
        {
            get { return this.grid.DisplayLayout.Override.RowAppearance.BackColor; }
            set { this.grid.DisplayLayout.Override.RowAppearance.BackColor = value; }
        }
        /// <summary>
        /// Color de la fila activa.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color de la fila activa.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorFilaActiva)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorActiva
        {
            get { return this.grid.DisplayLayout.Override.ActiveRowAppearance.BackColor; }
            set { this.grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = value; }
        }
        /// <summary>
        /// Color del texto de la fila activa.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color del texto de la fila activa.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorTextoFilaActiva)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorActivaTexto
        {
            get { return this.grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor; }
            set { this.grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = value; }
        }
        /// <summary>
        /// Color de la fila alternada.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color de la fila alternada.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorFilaAlterna)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorAlterna
        {
            get { return this.grid.DisplayLayout.Override.RowAlternateAppearance.BackColor; }
            set { this.grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = value; }
        }
        /// <summary>
        /// Color del texto de la fila alternada.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color del texto de la fila alternada.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorTextoFilaAlterna)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorAlternaTexto
        {
            get { return this.grid.DisplayLayout.Override.RowAlternateAppearance.ForeColor; }
            set { this.grid.DisplayLayout.Override.RowAlternateAppearance.ForeColor = value; }
        }
        /// <summary>
        /// Color de las lineas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color de las lineas de filas.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorEntreLinea)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorBorde
        {
            get { return this.grid.DisplayLayout.Override.RowAppearance.BorderColor; }
            set { this.grid.DisplayLayout.Override.RowAppearance.BorderColor = value; }
        }
        /// <summary>
        /// Color de la fila nueva.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color de la fila nueva.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorFilaNueva)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorNueva
        {
            get { return this.grid.DisplayLayout.Override.TemplateAddRowAppearance.BackColor; }
            set { this.grid.DisplayLayout.Override.TemplateAddRowAppearance.BackColor = value; }
        }
        /// <summary>
        /// Color del texto de la fila nueva.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color del texto de la fila nueva.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorTextoFilaNueva)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorNuevaTexto
        {
            get { return this.grid.DisplayLayout.Override.TemplateAddRowAppearance.ForeColor; }
            set { this.grid.DisplayLayout.Override.TemplateAddRowAppearance.ForeColor = value; }
        }
        /// <summary>
        /// Color del texto de la fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Color del texto de la fila.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorTextoFila)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFilaColorTexto
        {
            get { return this.grid.DisplayLayout.Override.RowAppearance.ForeColor; }
            set { this.grid.DisplayLayout.Override.RowAppearance.ForeColor = value; }
        }
        /// <summary>
        /// Preguntar confirmación al eliminar filas
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Preguntar confirmacion al eliminar filas.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaConfirmarBorrar)]
        public bool OrbFilaConfirmarBorrar
        {
            get { return this.filaConfirmarBorrar; }
            set { this.filaConfirmarBorrar = value; }
        }
        /// <summary>
        /// Estilo de texto negrita en fila activa.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Estilo de texto negrita en fila activa.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaActivaTextoNegrita)]
        public bool OrbFilaActivaTextoNegrita
        {
            get { return GetBoolean(this.grid.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold); }
            set { this.grid.DisplayLayout.Override.ActiveRowAppearance.FontData.Bold = GetDefaultableBoolean(value); }
        }
        /// <summary>
        /// Mostrar indicador de fila.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Mostrar indicador de fila.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaMostrarIndicador)]
        public bool OrbFilaMostrarIndicador
        {
            get { return GetBoolean(this.grid.DisplayLayout.Override.RowSelectors); }
            set { this.grid.DisplayLayout.Override.RowSelectors = GetDefaultableBoolean(value); }
        }
        /// <summary>
        /// Permitir seleccionar varias filas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Permitir seleccionar varias filas.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaPermitirMultiSeleccion)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbFilaPermitirMultiSeleccion
        {
            get { return this.filaPermitirMultiSeleccion; }
            set
            {
                this.filaPermitirMultiSeleccion = value;
                OrbFilaMostrarIndicador = this.filaPermitirMultiSeleccion;
                if (this.filaPermitirMultiSeleccion)
                {
                    this.OrbGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
                    this.OrbGrid.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard;
                }
                else
                {
                    this.OrbGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
                    this.OrbGrid.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Default;
                }
            }
        }
        /// <summary>
        /// Permitir eliminar filas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Fila")]
        [System.ComponentModel.Description("Permitir eliminar filas.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFilaPermitirBorrar)]
        public bool OrbFilaPermitirBorrar
        {
            get { return GetBoolean(this.grid.DisplayLayout.Override.AllowDelete); }
            set { this.grid.DisplayLayout.Override.AllowDelete = GetDefaultableBoolean(value); }
        }
        #endregion

        #region Filtro
        /// <summary>
        /// Color de los filtros.
        /// </summary>
        [System.ComponentModel.Category("Orbita Filtro")]
        [System.ComponentModel.Description("Color de los filtros.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorFiltros)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbFiltroColor
        {
            get { return this.grid.DisplayLayout.Override.FilterCellAppearance.BackColor; }
            set { this.grid.DisplayLayout.Override.FilterCellAppearance.BackColor = value; }
        }
        /// <summary>
        /// Mostrar filtros.
        /// </summary>
        [System.ComponentModel.Category("Orbita Filtro")]
        [System.ComponentModel.Description("Mostrar filtros.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridFiltroMostrar)]
        public bool OrbFiltroMostrar
        {
            get { return GetBoolean(this.grid.DisplayLayout.Override.AllowRowFiltering); }
            set { this.grid.DisplayLayout.Override.AllowRowFiltering = GetDefaultableBoolean(value); }
        }
        #endregion

        #region Grid
        /// <summary>
        /// Obtener el identificador único del control.
        /// </summary>
        public string Identificador
        {
            get
            {
                System.Windows.Forms.Control identificador = this;
                string uniqueID = identificador.Name;
                while (!(identificador is System.Windows.Forms.Form))
                {
                    identificador = identificador.Parent;
                    uniqueID = string.Concat(identificador.Name, "_") + uniqueID;
                }
                return uniqueID;
            }
        }
        /// <summary>
        /// Propiedades del Grid de Infragistics.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Description("Propiedades del Grid de Infragistics.")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Infragistics.Win.UltraWinGrid.UltraGrid OrbGrid
        {
            get { return this.grid; }
        }
        /// <summary>
        /// Color del borde.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Description("Color del borde del grid.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorBorde)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbGridColorBorde
        {
            get { return this.grid.DisplayLayout.Appearance.BorderColor; }
            set { this.grid.DisplayLayout.Appearance.BorderColor = value; }
        }
        /// <summary>
        /// Color de fondo.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Description("Color de fondo.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorFondo)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbGridColorFondo
        {
            get { return this.grid.DisplayLayout.Appearance.BackColor; }
            set { this.grid.DisplayLayout.Appearance.BackColor = value; }
        }
        /// <summary>
        /// Set: pone el OrbGrid.DataSource al valor que queramos.
        /// Get: devuelve una COPIA del OrbGrid.DataSource del Grid - ¡ATENCIÓN!. Si queremos obtener el datatable, hay que acceder a OrbGrid.DataSource.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DefaultValue(null)]
        public System.Data.DataTable OrbGridDataSource
        {
            get
            {
                return this.grid.DataSource == null ? null : ((System.Data.DataTable)this.grid.DataSource).Copy();
            }
            set
            {
                System.Windows.Forms.BindingSource binding = new System.Windows.Forms.BindingSource();
                binding.DataSource = value;
                this.grid.DataSource = binding;
            }
        }
        /// <summary>
        /// Ocultar la opción de agrupación de filas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Description("Ocultar la opción de agrupación de filas.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridEsconderDragColumn)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbGridEsconderDragColumn
        {
            get { return this.grid.DisplayLayout.GroupByBox.Hidden; }
            set { this.grid.DisplayLayout.GroupByBox.Hidden = value; }
        }
        /// <summary>
        /// Desactiva el comportamiento de avance de fila al pulsar Enter.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Description("Desactivar el comportamiento de avance de fila al pulsar Return.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridIgnorarReturn)]
        public bool OrbGridIgnorarReturn
        {
            get { return this.gridIgnorarReturn; }
            set { this.gridIgnorarReturn = value; }
        }
        /// <summary>
        /// Nombre del campo por el que se ordenará el Grid y se actualizará con los botones de orden.
        /// Condiciones: los valores en la columna deben ser únicos, de tipo numérico y no nulos.
        /// Es necesario llamar a orbFormatear si se establece esta propiedad.
        /// Solo permitirá ordenar por esta columna. 
        /// Si no se establece esta propiedad no aparecen los botones de orden y permite ordenar por cualquier columna.
        /// </summary>
        [System.ComponentModel.Category("Orbita Grid")]
        [System.ComponentModel.Description("Nombre del campo por el que se ordenara el Grid.")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public string OrbGridOrdenNombreCampo
        {
            get { return this.ordenNombreCampo; }
            set
            {
                this.ordenNombreCampo = value;
                this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Visible = !string.IsNullOrEmpty(value);
            }
        }
        #endregion

        #region Separador
        /// <summary>
        /// Mostrar el separador de filas.
        /// </summary>
        [System.ComponentModel.Category("Orbita Separador")]
        [System.ComponentModel.Description("Mostrar el separador de filas.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridSeparador)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.None)]
        public Infragistics.Win.UltraWinGrid.SpecialRowSeparator OrbSeparador
        {
            get { return this.grid.DisplayLayout.Override.SpecialRowSeparator; }
            set { this.grid.DisplayLayout.Override.SpecialRowSeparator = value; }
        }
        /// <summary>
        /// Alto del separador.
        /// </summary>
        [System.ComponentModel.Category("Orbita Separador")]
        [System.ComponentModel.Description("Alto del separador.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridSeparadorAlto)]
        public int OrbSeparadorAlto
        {
            get { return this.grid.DisplayLayout.Override.SpecialRowSeparatorHeight; }
            set { this.grid.DisplayLayout.Override.SpecialRowSeparatorHeight = value; }
        }
        /// <summary>
        /// Color del separador.
        /// </summary>
        [System.ComponentModel.Category("Orbita Separador")]
        [System.ComponentModel.Description("Color del separador.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorSeparador)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbSeparadorColor
        {
            get { return this.grid.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor; }
            set { this.grid.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = value; }
        }
        /// <summary>
        /// Color del borde del separador.
        /// </summary>
        [System.ComponentModel.Category("Orbita Separador")]
        [System.ComponentModel.Description("Color del borde del separador.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), OConfiguracion.ColorEntreLinea)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbSeparadorColorBorde
        {
            get { return this.grid.DisplayLayout.Override.SpecialRowSeparatorAppearance.BorderColor; }
            set { this.grid.DisplayLayout.Override.SpecialRowSeparatorAppearance.BorderColor = value; }
        }
        #endregion

        #region Sumario
        /// <summary>
        /// Mostrar el recuento de filas del Grid.
        /// </summary>
        [System.ComponentModel.Category("Orbita Sumario")]
        [System.ComponentModel.Description("Mostrar el recuento de filas del Grid.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridSumarioMostrarRecuentoFilas)]
        public bool OrbSumarioMostrarRecuentoFilas
        {
            get { return this.sumarioMostrarRecuentoFilas; }
            set { this.sumarioMostrarRecuentoFilas = value; }
        }
        /// <summary>
        /// Determina la posición de los resumenes.
        /// </summary>
        [System.ComponentModel.Category("Orbita Sumario")]
        [System.ComponentModel.Description("Determina la posición de los resumenes.")]
        [System.ComponentModel.DefaultValue(Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.None)]
        public Infragistics.Win.UltraWinGrid.SummaryDisplayAreas OrbSumarioPosicion
        {
            get { return this.grid.DisplayLayout.Override.SummaryDisplayArea; }
            set { this.grid.DisplayLayout.Override.SummaryDisplayArea = value; }
        }
        #endregion

        #endregion

        #region ToolBar

        #region Tools
        /// <summary>
        /// Ocultar los textos de las Tools de la ToolBar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Ocultar los textos de las Tools de la ToolBar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarToolEstilo)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Infragistics.Win.UltraWinToolbars.ToolDisplayStyle OrbToolBarToolsEstilo
        {
            get { return this.toolBarToolEstilo; }
            set
            {
                this.toolBarToolEstilo = value;
                foreach (Infragistics.Win.UltraWinToolbars.ToolBase tool in this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Tools)
                {
                    tool.SharedProps.DisplayStyle = this.toolBarToolEstilo;
                }
            }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Gestionar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar gestionar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolGestionar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolGestionar
        {
            get { return this.tlbGrid.Tools[Tools.OrbGestionar.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbGestionar.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Ver.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar ver.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolVer)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolVer
        {
            get { return this.tlbGrid.Tools[Tools.OrbVer.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbVer.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Modificar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar modificar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolModificar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolModificar
        {
            get { return this.tlbGrid.Tools[Tools.OrbModificar.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbModificar.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Añadir.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar añadir.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolAñadir)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolAñadir
        {
            get { return this.tlbGrid.Tools[Tools.OrbAñadir.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbAñadir.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Eliminar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar eliminar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolEliminar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolEliminar
        {
            get { return this.tlbGrid.Tools[Tools.OrbEliminar.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbEliminar.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Editar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar editar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolEditar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolEditar
        {
            get { return this.tlbGrid.Tools[Tools.OrbEditar.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbEditar.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Exportar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar exportar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolExportar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolExportar
        {
            get { return this.tlbGrid.Tools[Tools.OrbExportar.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbExportar.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Imprimir.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar imprimir.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolImprimir)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolImprimir
        {
            get { return this.tlbGrid.Tools[Tools.OrbImprimir.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbImprimir.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Estilo.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar estilo.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolEstilo)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolEstilo
        {
            get { return this.tlbGrid.Tools[Tools.OrbEstilo.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbEstilo.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Refrescar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar refrescar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolRefrescar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolRefrescar
        {
            get { return this.tlbGrid.Tools[Tools.OrbRefrescar.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbRefrescar.ToString()].SharedProps.Visible = value; }
        }
        /// <summary>
        /// Mostrar el Tool de la ToolBar Filtrar.
        /// </summary>
        [System.ComponentModel.Category("Orbita Tools ToolBar")]
        [System.ComponentModel.Description("Mostrar el botón de la ToolBar filtrar.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarToolFiltrar)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolFiltrar
        {
            get { return this.tlbGrid.Tools[Tools.OrbLimpiarFiltros.ToString()].SharedProps.Visible; }
            set { this.tlbGrid.Tools[Tools.OrbLimpiarFiltros.ToString()].SharedProps.Visible = value; }
        }
        #endregion

        #region ToolBarManager
        /// <summary>
        /// Propiedades de la ToolBar.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("ToolBar del Grid.")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Orbita.Controles.Menu.OrbitaUltraToolBarsManager OrbToolBarManager
        {
            get { return this.tlbGrid; }
        }
        /// <summary>
        /// Determinar la posición de anclaje de la ToolBar superior.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("Determinar la posición de anclaje de la ToolBar superior.v")]
        [System.ComponentModel.DefaultValue(Infragistics.Win.UltraWinToolbars.DockedPosition.Top)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Infragistics.Win.UltraWinToolbars.DockedPosition OrbToolBarAnclarToolBarArriba
        {
            get { return this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].DockedPosition; }
            set { this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].DockedPosition = value; }
        }
        /// <summary>
        /// Mostrar la ToolBar superior.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("Mostrar la ToolBar superior.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarArriba)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolBarArriba
        {
            get { return this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Visible; }
            set { this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Visible = value; }
        }
        /// <summary>
        /// Mostrar la ToolBar superior extendida.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("Mostrar la ToolBar superior extendida.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarArribaExtendida)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolBarArribaExtendida
        {
            get
            {
                if (this.tlbGrid.Toolbars.Exists(Orbita.Controles.Shared.PosicionToolBar.Extendido.ToString()))
                {
                    ToolBarInicializarPosicionArribaExtendido();
                    return this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Extendido].Visible;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    if (!this.tlbGrid.Toolbars.Exists(Orbita.Controles.Shared.PosicionToolBar.Extendido.ToString()))
                    {
                        this.tlbGrid.Toolbars.AddToolbar(Orbita.Controles.Shared.PosicionToolBar.Extendido.ToString());
                    }
                }
                if (this.tlbGrid.Toolbars.Exists(Orbita.Controles.Shared.PosicionToolBar.Extendido.ToString()))
                {
                    ToolBarInicializarPosicionArribaExtendido();
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Extendido].Visible = value;
                }
            }
        }
        /// <summary>
        /// Mostrar la ToolBar derecha.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("Mostrar la ToolBar derecha.")]
        [System.ComponentModel.DefaultValue(OConfiguracion.OrbGridToolBarMostrarDerecha)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public bool OrbToolBarMostrarToolBarDerecha
        {
            get { return this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Visible; }
            set { this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Visible = value; }
        }
        /// <summary>
        /// Permitir anclar la ToolBar superior a la izquierda.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("Permitir anclar la ToolBar superior a la izquierda.")]
        [System.ComponentModel.DefaultValue(Infragistics.Win.DefaultableBoolean.True)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Infragistics.Win.DefaultableBoolean OrbToolBarPermitirAnclarToolBarArribaIzquierda
        {
            get { return this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Settings.AllowDockLeft; }
            set { this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Settings.AllowDockLeft = value; }
        }
        /// <summary>
        /// Permitir anclar la ToolBar superior a la derecha.
        /// </summary>
        [System.ComponentModel.Category("Orbita ToolBar")]
        [System.ComponentModel.Description("Permitir anclar la ToolBar superior a la derecha.")]
        [System.ComponentModel.DefaultValue(Infragistics.Win.DefaultableBoolean.True)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Infragistics.Win.DefaultableBoolean OrbToolBarPermitirAnclarToolBarArribaDerecha
        {
            get { return this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Settings.AllowDockRight; }
            set { this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].Settings.AllowDockRight = value; }
        }
        #endregion

        #region Plantilla
        /// <summary>
        /// Colección de plantillas.
        /// </summary>
        public System.Collections.Generic.Dictionary<string, Orbita.Controles.Grid.OPlantilla> Plantillas
        {
            get { return this.plantillasActivas; }
            set { this.plantillasActivas = value; }
        }
        #endregion

        #endregion

        #endregion

        #region Métodos públicos

        #region Grid
        /// <summary>
        /// Mirar si existe el ScrollBarVertical.
        /// </summary>
        /// <returns>True si existe el ScrollBar Vertical.</returns>
        public bool OrbTieneVertScrollBar()
        {
            Infragistics.Win.UltraWinGrid.RowScrollbarUIElement aRowScrollbarUIElement;
            aRowScrollbarUIElement = (Infragistics.Win.UltraWinGrid.RowScrollbarUIElement)this.grid.DisplayLayout.UIElement.GetDescendant(typeof(Infragistics.Win.UltraWinGrid.RowScrollbarUIElement));
            return aRowScrollbarUIElement != null;
        }
        /// <summary>
        /// Seleccionar la fila cuyo valor para el campo especificado coincide con el que pasamos como parámetro.
        /// </summary>
        /// <param name="campo">Campo a buscar.</param>
        /// <param name="valor">Valor a comparar.</param>
        public void OrbActivarFila(string campo, string valor)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow fila in this.OrbGrid.Rows)
            {
                if (fila.Cells[campo] != null && fila.Cells[campo].Value.ToString() == valor)
                {
                    this.OrbGrid.ActiveRow = fila;
                    break;
                }
            }
        }
        /// <summary>
        /// Seleccionar la fila cuyos valores de campos coincidan con los que pasamos como parámetro.
        /// </summary>
        /// <param name="campos">Colección con los campos a buscar.</param>
        /// <param name="valor">Colección con los valores a comparar.</param>
        public void OrbActivarFila(string[] campos, string[] valor)
        {
            if (campos == null || valor == null)
            {
                return;
            }
            bool esFila = true;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow fila in this.OrbGrid.Rows)
            {
                for (int i = 0; i < campos.Length; i++)
                {
                    if ((fila.Cells[campos[i]] != null) && (fila.Cells[campos[i]].Value.ToString() != valor[i]))
                    {
                        esFila = false;
                    }
                }
                if (esFila)
                {
                    this.OrbGrid.ActiveRow = fila;
                    return;
                }
                esFila = true;
            }
        }
        /// <summary>
        /// Seleccionar la fila pasándole el índice de fila que se desea activar, utilizaremos la propiedad VisibleIndex de la fila
        /// ¡OJO! Este método debe usarse solo por comodidad mientras no se reasigne el datasource del Grid, en caso 
        /// de reasignación del datasource debemos usar los métodos OrbActivarFila con nombreCampo y valorCampo.
        /// </summary>
        /// <param name="indiceVisible">Indice visible de la fila activa, es decir gridNombreGrid.OrbFilaActiva.VisibleIndex</param>       
        public void OrbActivarFila(int indiceVisible)
        {
            this.grid.ActiveRow = this.grid.Rows.GetRowAtVisibleIndex(indiceVisible);
        }
        /// <summary>
        /// Aplicar los filtros que estén configurados, dejando selecionada la primera fila visible.
        /// </summary>
        public void OrbAplicarFiltros()
        {
            this.OrbGrid.DisplayLayout.Rows.FilterRow.ApplyFilters();
            this.OrbActivarFila(1);
        }
        /// <summary>
        /// Bloquear las columnas.
        /// </summary>
        /// <param name="claves">Columnas clave a bloquear.</param>
        public void OrbBloquearColumnas(string[] claves)
        {
            if (claves == null)
            {
                return;
            }
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.grid.DisplayLayout.Bands)
            {
                foreach (string clave in claves)
                {
                    if (ugb.Columns.Exists(clave))
                    {
                        // Desactivar TabStop (determina si las celdas de la columna pueden obtener el foco en la tabulación).
                        ugb.Columns[clave].TabStop = false;
                        // Columnas no accesibles mediante el ratón.
                        ugb.Columns[clave].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        // Estilos: colores.
                        ugb.Columns[clave].CellAppearance.BackColor = OConfiguracion.OrbGridColorColumnaBloqueada;
                    }
                }
            }
        }
        /// <summary>
        /// Desbloquear las columnas.
        /// </summary>
        public void OrbDesbloquearColumnas()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.grid.DisplayLayout.Bands)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in ugb.Columns)
                {
                    // Activar TabStop (determina si las celdas de la columna pueden obtener el foco en la tabulación).
                    ugc.TabStop = true;
                    // Columnas no accesibles mediante el ratón.
                    ugc.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    // Estilos: colores.
                    ugc.ResetCellAppearance();
                }
            }
        }
        /// <summary>
        /// Eliminar la fila activa del Grid.
        /// </summary>
        /// <returns>True si la fila ha sido eliminada; false en caso contrario.</returns>
        public bool OrbEliminarFilaActiva()
        {
            bool retorno = false;
            if (this.OrbGrid.ActiveRow != null && this.OrbGrid.ActiveRow.IsDataRow && !this.OrbGrid.ActiveRow.IsFilteredOut && !this.OrbGrid.ActiveRow.IsAddRow)
            {
                int indexActivo = this.OrbGrid.ActiveRow.Index;
                if (this.filaConfirmarBorrar)
                {
                    Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
                    if (System.Windows.Forms.MessageBox.Show(resCustomizer.GetCustomizedString("DeleteSingleRowPrompt"), "Confirmación de borrado", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2, 0) == System.Windows.Forms.DialogResult.Yes)
                    {
                        retorno = this.OrbGrid.ActiveRow.Delete(false);
                    }
                }
                else
                {
                    retorno = this.OrbGrid.ActiveRow.Delete(false);
                }
                // Seleccionar la anterior.
                if (indexActivo > 0 || this.OrbGrid.Rows.Count > 0)
                {
                    if (indexActivo >= this.OrbGrid.Rows.Count)
                    {
                        indexActivo = indexActivo - 1;
                    }
                    for (int indice = indexActivo; indice > -1; indice--)
                    {
                        if (!this.OrbGrid.Rows[indice].IsFilteredOut)
                        {
                            this.OrbFilaActiva = this.OrbGrid.Rows[indice];
                            break;
                        }
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Eliminar la fila activa del Grid mostrando o no el prompt de confirmación.
        /// </summary>
        /// <param name="prompt">Indicar si se desea que se muestre el prompt.</param>
        /// <returns>True si la fila ha sido eliminada; false en caso contrario.</returns>
        public bool OrbEliminarFilaActiva(bool prompt)
        {
            if (prompt)
            {
                return this.OrbEliminarFilaActiva();
            }
            else
            {
                // Guardar el valor del atributo this._confirmarBorrarFilas.
                bool confirmarBorrarFilasAnterior = this.filaConfirmarBorrar;

                this.filaConfirmarBorrar = false;
                bool res = this.OrbEliminarFilaActiva();

                // Restaurar el valor del atributo this._confirmarBorrarFilas.
                this.filaConfirmarBorrar = confirmarBorrarFilasAnterior;
                return res;
            }
        }
        /// <summary>
        /// Eliminar las filas seleccionadas del Grid.
        /// </summary>
        /// <returns>True si las filas han sido eliminadas; false en caso contrario.</returns>
        public bool OrbEliminarFilasSeleccionadas()
        {
            bool res = false;
            if (this.filaPermitirMultiSeleccion)
            {
                if (this.OrbGrid.Selected != null)
                {
                    int indexActivo = this.OrbGrid.ActiveRow.Index;
                    if (this.filaConfirmarBorrar)
                    {
                        Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
                        if (System.Windows.Forms.MessageBox.Show(resCustomizer.GetCustomizedString("DeleteMultipleRowsPrompt"), "Confirmación de borrado", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2, 0) == System.Windows.Forms.DialogResult.Yes)
                        {
                            try
                            {
                                this.OrbGrid.DeleteSelectedRows(true);
                                res = true;
                            }
                            catch
                            {
                                res = false;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            this.OrbGrid.DeleteSelectedRows(false);
                            res = true;
                        }
                        catch
                        {
                            res = false;
                        }
                    }
                    // Seleccionar la anterior.
                    if (indexActivo > 0 || this.OrbGrid.Rows.Count > 0)
                    {
                        if (indexActivo >= this.OrbGrid.Rows.Count)
                        {
                            indexActivo = indexActivo - 1;
                        }
                        for (int indice = indexActivo; indice > -1; indice--)
                        {
                            if (!this.OrbGrid.Rows[indice].IsFilteredOut)
                            {
                                this.OrbFilaActiva = this.OrbGrid.Rows[indice];
                                break;
                            }
                        }
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// Mostrar el label de recuento de filas del Grid.
        /// </summary>
        /// <param name="texto">Label que se mostrará.</param>
        /// <param name="key">Nombre de la columna bajo la que se mostrará el recuento.</param>
        public void OrbMostrarRecuentoFilas(string texto, string key)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.grid.DisplayLayout.Bands)
            {
                if (ugb.Columns.Exists(key))
                {
                    string clave = ugb.Summaries.Count.ToString(System.Globalization.CultureInfo.CurrentCulture);
                    ugb.Summaries.Add(clave, Infragistics.Win.UltraWinGrid.SummaryType.Count, ugb.Columns[clave], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                    ugb.Summaries[clave].DisplayFormat = "{0:#####.##}";
                    Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
                    resCustomizer.SetCustomizedString("SummaryDialogCount", texto);
                    resCustomizer.SetCustomizedString("SummaryTypeCount", texto);
                    break;
                }
            }
        }
        /// <summary>
        /// Formatear Grid.
        /// </summary>
        /// <param name="dt">Tabla de datos.</param>
        public void OrbFormatear(System.Data.DataTable dt)
        {
            if (dt == null)
            {
                // Si la tabla es nula lanzamos excepción.
                throw new Orbita.Controles.Shared.OExcepcion("La tabla de datos es nula.");
            }
            this.OrbGridDataSource = dt;
        }
        bool _formateado = false;
        public bool Formateado
        {
            get
            {
                return _formateado;
            }
            set
            {
                _formateado = value;
            }
        }
        /// <summary>
        /// Formatear Grid.
        /// </summary>
        /// <param name="dt">Tabla de datos.</param>
        /// <param name="columnas">Lista de columnas.</param>
        public void OrbFormatear(System.Data.DataTable dt, System.Collections.ArrayList columnas)
        {
            if (dt == null)
            {
                // Si la tabla es nula lanzamos excepción.
                throw new Orbita.Controles.Shared.OExcepcion("Error en OrbFormatear. La tabla de datos es nula.");
            }
            // Guardar la lista de columnas en una variable privada (accesible como propiedad ReadOnly).
            this.columnasVisibles = columnas;
            // Asignar DataSource del Grid.
            // Se pasa el DataTable por referencia, por la posible existencia de columnas calculadas.
            this.SetDatasource(ref dt);
            // Comprobar el formateo previo, o la carga de la colección de plantillas.
            // La única posición donde se modifica este atributo a False (no formateado)
            if (!this._formateado || !this.OrbToolBarMostrarToolEstilo)
            {
                // Comprobar el número de elementos de la colección de plantillas.
                if (this.OrbToolBarMostrarToolEstilo && this.plantillasActivas == null)
                {
                    // Este proceso solo se va a ejecutar tantas  veces como no existan plantillas en la ToolBar.
                    // Obtener las plantillas almacenadas y asignar a la ToolBar si la colección es vacía.
                    if (this.ToolBarGetPlantillas(false))
                    {
                        // Asumir que se formatea el campo.
                        this._formateado = true;
                        return;
                    }
                }
                // Formatear columnas.
                this.columnaBloqueadas = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.OrbGrid.DisplayLayout.Bands)
                {
                    // Eliminar los sumarios si existen.
                    if (banda.Summaries.Count > 0)
                    {
                        banda.Summaries.Clear();
                    }
                    // Ocultar todas las columnas de cada una de las bandas.
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in banda.Columns)
                    {
                        ugc.Hidden = true;
                    }
                    if (columnas != null)
                    {
                        // Definir estilos de columnas.
                        foreach (OEstiloColumna columna in columnas)
                        {
                            // Considerar si se trata de una columna calculada.
                            bool tipoColumnaCalculada = (this.columnaExistenCalculadas && (columna.GetType() == typeof(OColumnaCalculada)));
                            // Incluir la funcionalidad de añadir columnas calculadas en el Orbformatear base aunque CR
                            // ha recomendado encarecidamente que no se modificara la sobrecarga con "hayColumnasCalculadas".
                            if (banda.Columns.Exists(columna.Campo) || tipoColumnaCalculada)
                            {
                                // Asignar la columna calculada al Datatable si se ha definido y aplicamos el estilo.
                                if (tipoColumnaCalculada)
                                {
                                    // Añadir la columna al Datatable.
                                    dt.Columns.Add(((OColumnaCalculada)columna).Calculada);
                                }
                                // Aplicar estilos a las columnas.
                                SetEstilo(banda, columna, columnas.IndexOf(columna));
                                // Aplicar máscaras a las columnas.
                                SetMascara(banda, columna);
                                // Asignar sumario a las columnas.
                                SetSumario(banda, columna);
                                // Bloquear o no el acceso a la columna.
                                // Aplicar estilo (bloqueado) a la columna bloqueada y la celda de filtros.
                                SetEstiloColumnaBloqueada(banda, columna);
                                // Actualizar el flag que indica si todas las columnas que el programador quiere mostrar están bloqueadas o no.
                                this.columnaBloqueadas = this.columnaBloqueadas & columna.Bloqueado;
                            }
                        }
                        // Llamar al método para mostrar el recuento de filas. Resumen del recuento.
                        if (this.sumarioMostrarRecuentoFilas)
                        {
                            if (dt.Rows.Count > 0 && columnas.Count > 0)
                            {
                                SetSumarioCount(banda, (columnas[0] as OEstiloColumna));
                            }
                        }
                    }
                }
                // Una vez formateado, modificar el atributo.
                this._formateado = true;
            }
            // Seleccionar y activar la primera fila (ActiveRow).
            this.ActivarPrimeraFila();
        }
        /// <summary>
        /// Formatear Grid.
        /// </summary>
        /// <param name="dt">Tabla de datos.</param>
        /// <param name="columnas">Lista de columnas.</param>
        /// <param name="existenColumnasCalculadas">Determina la sobrecarga para columnas calculadas.</param>
        public void OrbFormatear(System.Data.DataTable dt, System.Collections.ArrayList columnas, bool existenColumnasCalculadas)
        {
            this.columnaExistenCalculadas = existenColumnasCalculadas;
            this.OrbFormatear(dt, columnas);
        }
        /// <summary>
        /// Formatear Grid.
        /// </summary>
        /// <param name="dt">Tabla de dato.</param>
        /// <param name="columnas">Lista de columnas.</param>
        /// <param name="colorFilasContiguasAgrupadas">Color con el que se quieren pintar las filas agrupadas.</param>
        /// <param name="editable">Indica si se puede editar.</param>
        public void OrbFormatear(System.Data.DataTable dt, System.Collections.ArrayList columnas, System.Drawing.Color? colorFilasContiguasAgrupadas, bool editable)
        {
            this.filaColorContiguasAgrupadas = colorFilasContiguasAgrupadas;
            this.OrbCeldaEditable = editable;
            this.OrbFormatear(dt, columnas);
            // Modificar las propiedades del Grid para permitir agrupar filas contiguas.
            this.AgruparFilasContiguas();
        }
        /// <summary>
        /// Formatear Grid.
        /// </summary>
        /// <param name="dt">Tabla de dato.</param>
        /// <param name="columnas">Lista de columnas.</param>
        /// <param name="colorFilasContiguasAgrupadas">Color con el que se quieren pintar las filas agrupadas.</param>
        /// <param name="editable">Indica si se puede editar.</param>
        /// <param name="existenColumnasCalculadas">Determina la sobrecarga para columnas calculadas.</param>
        public void OrbFormatear(System.Data.DataTable dt, System.Collections.ArrayList columnas, System.Drawing.Color? colorFilasContiguasAgrupadas, bool editable, bool existenColumnasCalculadas)
        {
            this.filaColorContiguasAgrupadas = colorFilasContiguasAgrupadas;
            this.OrbCeldaEditable = editable;
            this.columnaExistenCalculadas = existenColumnasCalculadas;
            this.OrbFormatear(dt, columnas);
        }
        /// <summary>
        /// Borrar todas las filas.
        /// </summary>
        public void OrbLimpiar()
        {
            if (this.grid.DataSource != null)
            {
                if (this.grid.Rows.Count > 0)
                {
                    if (this.grid.DataSource.GetType() == typeof(System.Data.DataTable))
                    {
                        ((System.Data.DataTable)this.grid.DataSource).Rows.Clear();
                    }
                    else
                    {
                        if (this.grid.DataSource.GetType() == typeof(System.Data.DataSet))
                        {
                            ((System.Data.DataSet)this.grid.DataSource).Tables[0].Rows.Clear();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Lanzar un refrescar del Grid (redibuja el contenido y obliga a que se actualicen los campos).
        /// </summary>
        public void OrbRefrescar()
        {
            this.grid.Refresh();
        }
        /// <summary>
        /// Regenerar índices.
        /// </summary>
        public void OrbOrdenRegenerarIndices()
        {
            try
            {
                if ((OrbGridOrdenNombreCampo != null) && (!string.IsNullOrEmpty(OrbGridOrdenNombreCampo)))
                {
                    // Toma la columna de ordenación especial y hace que todas las filas tomen un valor consecutivo según su posición empezando por 1.
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow fila in this.OrbGrid.Rows)
                    {
                        // Vnicolau, 30/08/2010: ahora regeneramos los índices basándonos en el Index de cada fila.
                        fila.Cells[OrbGridOrdenNombreCampo].Value = fila.Index + 1; // fila.Index es de base 0.
                        fila.Update();
                    }
                    this.OrbGrid.UpdateData();
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// Agrega un botón a la ToolBar.
        /// </summary>
        /// <param name="texto">Texto del botón.</param>
        /// <param name="imagen">Imagen del botón.</param>
        /// <param name="key">Key asignado al botón (luego lo capturas en OrbToolBarClick)</param>
        /// <param name="posicion">Posición del control</param>
        /// <param name="alFinal">Va al final.</param>
        public void OrbToolBarAgregarBoton(string texto, System.Drawing.Bitmap imagen, string key, int posicion, bool alFinal)
        {
            this.tlbGrid.AgregarBoton(texto, imagen, key, posicion, alFinal);
        }
        /// <summary>
        /// Agrega un botón a una de las Toolbar del grid
        /// </summary>
        /// <param name="toolBar">Identificador de la toolbar en la que añadimos el botón</param>
        /// <param name="texto">Texto del botón.</param>
        /// <param name="imagen">Imagen del botón.</param>
        /// <param name="key">Key asignado al botón (luego lo capturas en OrbToolBarClick)</param>
        /// <param name="posicion">Posición del control</param>
        /// <param name="alFinal">Va al final.</param>
        public void OrbToolBarAgregarBoton(Orbita.Controles.Shared.PosicionToolBar toolBar, string texto, System.Drawing.Bitmap imagen, string key, int posicion, bool alFinal)
        {
            this.tlbGrid.AgregarBoton(toolBar, texto, imagen, key, posicion, alFinal);
        }
        /// <summary>
        /// Agregar un control a la ToolBar.
        /// </summary>
        /// <param name="toolBar">ToolBar correspondiente a la Orbita.Controles.ToolBarManager.</param>
        /// <param name="control">Control a añadir</param>
        /// <param name="posicion">Posicion del control</param>
        /// <param name="alFinal">Va al final</param>
        public void OrbToolBarAgregarControl(Orbita.Controles.Shared.PosicionToolBar toolBar, System.Windows.Forms.Control control, int posicion, bool alFinal)
        {
            this.tlbGrid.AgregarControl(toolBar, control, posicion, alFinal);
        }
        /// <summary>
        /// Agregar un texto a la toolbar.
        /// </summary>
        /// <param name="texto">Texto a añadir</param>
        /// <param name="posicion">Posicion del texto</param>
        /// <param name="alFinal">Hace spring hasta el final</param>
        /// <returns>La clave del texto que se acaba de añadir para identificar el control dentro de la ToolBar</returns>
        public string OrbToolBarAgregarTexto(string texto, int posicion, bool alFinal)
        {
            return this.tlbGrid.AgregarTexto(texto, posicion, alFinal);
        }
        /// <summary>
        /// Obtener el botón de la ToolBar cuya clave es ButtonKey.
        /// </summary>
        /// <param name="buttonKey">Clave que tiene el botón de la ToolBar</param>
        /// <returns>El botón de la ToolBar que corresponde a la clave especificada</returns>
        public Infragistics.Win.UltraWinToolbars.ButtonTool OrbToolBarObtenerBoton(string buttonKey)
        {
            return (Infragistics.Win.UltraWinToolbars.ButtonTool)this.OrbToolBarManager.Toolbars[0].Tools[buttonKey];
        }
        /// <summary>
        /// Cambiar al visibilidad del el botón de la ToolBar cuya clave es buttonKey.
        /// </summary>
        /// <param name="buttonKey">Clave que tiene el botón de la ToolBar</param>
        /// <param name="visible">Valor con la visibilidad que se desea para el botón</param>
        public void OrbToolBarVisibilidadBoton(string buttonKey, bool visible)
        {
            this.OrbToolBarManager.Toolbars[0].Tools[buttonKey].SharedProps.Visible = visible;
        }
        /// <summary>
        /// Cambiar la imagen que muestra el botón de la ToolBar.
        /// </summary>
        /// <param name="claveBoton">Valor del parámetro key del botón de la ToolBar</param>
        /// <param name="imagenBoton">Imagen tipo System.Drawing.Image</param>
        /// <returns>True si todo ha ido correctamente. False en caso contrario</returns>
        public bool OrbToolBarModificarImagenBoton(string claveBoton, System.Drawing.Bitmap imagenBoton)
        {
            try
            {
                // Autor: Rubén Cuenca (Órbita 1)
                // Fecha: 26/04/2010 10:27
                // Comentario: Modifico las dos appearances: large y small, porque no se si en algun momento se usará una u otra.
                this.OrbToolBarManager.Toolbars[0].Tools[claveBoton].SharedProps.AppearancesLarge.Appearance.Image = imagenBoton;
                this.OrbToolBarManager.Toolbars[0].Tools[claveBoton].SharedProps.AppearancesSmall.Appearance.Image = imagenBoton;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Cambiar el texto mostrado en el botón de la ToolBar.
        /// </summary>
        /// <param name="claveBoton">Valor del parámetro key del botón de la ToolBar</param>
        /// <param name="captionBoton">Texto a mostrar en el botón</param>
        /// <returns>True si todo ha ido correctamente. False en caso contrario</returns>
        public bool OrbToolBarModificarTextoBoton(string claveBoton, string captionBoton)
        {
            try
            {
                this.OrbToolBarManager.Toolbars[0].Tools[claveBoton].SharedProps.Caption = captionBoton;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Eliminar un control de la ToolBar.
        /// </summary>
        /// <param name="toolBar">ToolBar correspondiente a la Orbita.Controles.ToolBarManager.</param>
        /// <param name="control">Control a añadir</param>
        /// <param name="mostrar">Indica si se muestra o no el botón.</param>
        public void OrbToolBarVisibilidadControl(Orbita.Controles.Shared.PosicionToolBar toolBar, System.Windows.Forms.Control control, bool mostrar)
        {
            this.OrbToolBarManager.ControlVisible(toolBar, control, mostrar);
        }
        #endregion

        #endregion

        #region Métodos privados

        #region Grid + ToolBar
        /// <summary>
        /// Aplicar estilos del Grid.
        /// </summary>
        void InicializarEstilo()
        {
            OGetStyleLibrary style = new OGetStyleLibrary();
            Infragistics.Win.AppStyling.StyleManager.Load(style.GetIsl("2"), true, style.IslFileName);
            this.grid.StyleLibraryName = style.IslFileName;

            #region Grid
            // Importante: sin no inicializamos esta propiedad a false, a consecuencia de
            // utilizar TextRenderingMode = GDI, produce que los tooltip de scroll (si hubiera)
            // y los de la fila de filtros, aparezcan en negrita (ilegibles).
            Infragistics.Win.DrawUtility.UseGDIPlusTextRendering = false;
            // Eliminar las líneas discontinuas de la fila seleccionada.
            this.grid.DrawFilter = new ONoFocusRectDrawFilter();
            // FilterRow = Muestra los filtros en fila.
            // HeaderIcons = Default = Muestra el icono de filtros en la cabecera.
            this.grid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            // Estilos.
            this.grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            // Selección.
            this.OrbGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.OrbGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            // Modo de actualización.
            this.grid.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            // Esconder drag column.
            this.OrbGridEsconderDragColumn = OConfiguracion.OrbGridEsconderDragColumn;
            // Ignorar pulsación de la tecla Return.
            this.OrbGridIgnorarReturn = this.gridIgnorarReturn;
            #endregion

            #region Cabecera
            // this.OrbCabeceraAlineacion = Configuracion.OrbGridCabeceraAlineacion;
            // this.OrbCabeceraEstilo = Configuracion.OrbGridCabeceraEstilo;
            // this.OrbCabeceraMultilinea = Configuracion.OrbGridCabeceraMultilinea;
            #endregion

            #region Celda
            this.OrbCeldaEditable = OConfiguracion.OrbGridCeldaEditable;
            #endregion

            #region Columna
            this.OrbColumnaAutoAjuste = OConfiguracion.OrbGridColumnaAutoajuste;
            #endregion

            #region Fila
            this.OrbFilaAlto = this.filaAlto;
            this.OrbFilaAltoMinimo = this.filaAltoMinimo;
            this.OrbFilaConfirmarBorrar = this.filaConfirmarBorrar;
            this.OrbFilaMostrarIndicador = OConfiguracion.OrbGridFilaMostrarIndicador;
            this.OrbFilaPermitirBorrar = OConfiguracion.OrbGridFilaPermitirBorrar;
            this.OrbFilaPermitirMultiSeleccion = this.filaPermitirMultiSeleccion;
            #endregion

            #region Filtro
            this.OrbFiltroMostrar = OConfiguracion.OrbGridFiltroMostrar;
            #endregion

            #region Sumario
            this.grid.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            //  this.gridPro.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.TopFixed;
            this.OrbSumarioMostrarRecuentoFilas = this.sumarioMostrarRecuentoFilas;
            #endregion

            #region ToolBar

            #region Tools
            //this.OrbToolBarMostrarToolGestionar = OConfiguracion.OrbGridToolBarMostrarToolGestionar;
            //this.OrbToolBarMostrarToolVer = OConfiguracion.OrbGridToolBarMostrarToolVer;
            //this.OrbToolBarMostrarToolModificar = OConfiguracion.OrbGridToolBarMostrarToolModificar;
            //this.OrbToolBarMostrarToolAñadir = OConfiguracion.OrbGridToolBarMostrarToolAñadir;
            //this.OrbToolBarMostrarToolEliminar = OConfiguracion.OrbGridToolBarMostrarToolEliminar;
            //this.OrbToolBarMostrarToolEditar = OConfiguracion.OrbGridToolBarMostrarToolEditar;
            //this.OrbToolBarMostrarToolExportar = OConfiguracion.OrbGridToolBarMostrarToolExportar;
            //this.OrbToolBarMostrarToolImprimir = OConfiguracion.OrbGridToolBarMostrarToolImprimir;
            //this.OrbToolBarMostrarToolEstilo = OConfiguracion.OrbGridToolBarMostrarToolEstilo;
            //this.OrbToolBarMostrarToolRefrescar = OConfiguracion.OrbGridToolBarMostrarToolRefrescar;
            //this.OrbToolBarMostrarToolFiltrar = OConfiguracion.OrbGridToolBarMostrarToolFiltrar;
            #endregion

            #region ToolBarManager
            this.OrbToolBarMostrarToolBarArriba = OConfiguracion.OrbGridToolBarMostrarArriba;
            this.OrbToolBarMostrarToolBarArribaExtendida = OConfiguracion.OrbGridToolBarMostrarArribaExtendida;
            this.OrbToolBarMostrarToolBarDerecha = OConfiguracion.OrbGridToolBarMostrarDerecha;
            this.OrbToolBarPermitirAnclarToolBarArribaDerecha = Infragistics.Win.DefaultableBoolean.True;
            this.OrbToolBarPermitirAnclarToolBarArribaIzquierda = Infragistics.Win.DefaultableBoolean.True;
            #endregion

            #endregion
        }
        #endregion

        #region Grid
        /// <summary>
        /// Asignar del DataSource al Grid.
        /// </summary>
        /// <param name="dt">Representa una tabla de datos en memoria.</param>
        void SetDatasource(ref System.Data.DataTable dt)
        {
            // Comentario: Funcionalidad de reordenar filas mediante los botones del Grid.
            if (string.IsNullOrEmpty(this.ordenNombreCampo))
            {
                OrbFormatear(dt);
            }
            else
            {
                if (dt.Columns[this.ordenNombreCampo].GetType() != typeof(int))
                {
                    System.Data.DataTable dtAuxiliar = new System.Data.DataTable();
                    dtAuxiliar.Locale = System.Globalization.CultureInfo.CurrentCulture;
                    dtAuxiliar = dt.Clone();
                    dtAuxiliar.Columns[this.ordenNombreCampo].DataType = typeof(int);
                    foreach (System.Data.DataRow fila in dt.Rows)
                    {
                        dtAuxiliar.ImportRow(fila);
                    }
                    dt = dtAuxiliar;
                    OrbFormatear(dt);
                }
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.OrbGrid.DisplayLayout.Bands)
                {
                    if (ugb.Columns.Exists(this.ordenNombreCampo))
                    {
                        ugb.SortedColumns.Clear();
                        ugb.SortedColumns.Add(ugb.Columns[this.ordenNombreCampo], false);
                        this.OrbGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
                    }
                    else
                    {
                        this.OrbGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
                        ugb.SortedColumns.Clear();
                    }
                }
            }
        }
        /// <summary>
        /// Aplicar estilo (bloqueado) a la columna bloqueada del Grid.
        /// </summary>
        /// <param name="banda">An object that represents a set of related columns of data.</param>
        /// <param name="columna">Campos de estilos.</param>
        static void SetEstiloColumnaBloqueada(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (columna.Bloqueado)
            {
                //System.Drawing.Color colorFilaFiltrosBloqueada = banda.Columns[columna.Campo].FilterCellAppearance.BackColor;
                // Columnas no accesibles mediante el ratón.
                banda.Columns[columna.Campo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                // Estilos: colores.
                banda.Columns[columna.Campo].CellAppearance.BackColor = OConfiguracion.OrbGridColorColumnaBloqueada;
                // Fila de filtros.
                // Apariencia del color de la fila de filtros.
                //ComponentRole componentRole = this.gridPro.ComponentRole;
                //StyleManager styleMgrInst = StyleManager.FromComponentRole(componentRole);
                //UIRole role = styleMgrInst.GetRole(componentRole, "GridRow");
                //AppearanceData appearance = new AppearanceData();
                //AppearancePropFlags requestedProps = AppearancePropFlags.BackColor;
                //role.ResolveAppearance(ref appearance, ref requestedProps, RoleState.FilterRow);
                banda.Columns[columna.Campo].FilterCellAppearance.BackColor = System.Drawing.Color.Transparent;
            }
        }
        /// <summary>
        /// Seleccionar y activar la primera fila del Grid.
        /// </summary>
        void ActivarPrimeraFila()
        {
            if (this.grid.Rows.Count > 0)
            {
                this.grid.ActiveRow = this.grid.Rows[0];
            }
        }
        /// <summary>
        /// Modificar las propiedades del Grid para permitir agrupar filas contiguas.
        /// </summary>
        void AgruparFilasContiguas()
        {
            if (!this.filaColorContiguasAgrupadas.HasValue)
            {
                this.OrbGrid.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Never;
            }
            else
            {
                this.OrbGrid.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                this.OrbGrid.DisplayLayout.Override.MergedCellAppearance.BackColor = this.filaColorContiguasAgrupadas.Value;
            }
        }
        /// <summary>
        /// Se comprueba si ha cambiado el estado de activación de los botones de orden para lanzar el evento en caso de cambio.
        /// </summary>
        void OrdenCambioActivacion()
        {
            bool ordenBajarActivo = this.tlbGrid.Tools[Tools.OrbIrSiguiente.ToString()].SharedProps.Enabled;
            if (this.OrbOrdenCambioActivacion != null && ordenBajarActivo != this.ordenEstadoAnterior)
            {
                this.OrbOrdenCambioActivacion(ordenBajarActivo);
            }
        }
        /// <summary>
        /// Mueve la fila seleccionada tantas poiciones como indique el control.
        /// </summary>
        void ValidarPosicionIrA()
        {
            if (this.nePosicion.Value != null && this.OrbFilaActiva != null)
            {
                int posicionObjetivo;
                int ajusteFila = -1;
                if (this.OrbFiltroMostrar)
                {
                    ajusteFila = 0;
                }
                if (int.TryParse(this.nePosicion.Value.ToString(), out posicionObjetivo))
                {
                    if (posicionObjetivo < this.OrbGrid.Rows.VisibleRowCount)
                    {
                        posicionObjetivo += ajusteFila;
                        if (posicionObjetivo > this.OrbFilaActiva.VisibleIndex)
                        {
                            ToolBarToolIrSiguiente(posicionObjetivo - this.OrbFilaActiva.VisibleIndex, false);
                        }
                        else if (posicionObjetivo < this.OrbFilaActiva.VisibleIndex)
                        {
                            ToolBarToolIrAnterior(this.OrbFilaActiva.VisibleIndex - posicionObjetivo, false);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Desactivar celda.
        /// </summary>
        void DesactivarCelda()
        {
            if (grid.ActiveCell != null)
            {
                this.grid.ActiveCell = null;
            }
        }
        /// <summary>
        /// Exportar a Excel.
        /// </summary>
        void ExportarExcel()
        {
            using (System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveDialog.Filter = "Archivo de Excel (*.xls)|*.xls|Todos los ficheros (*.*)|*.*";
                saveDialog.DefaultExt = "xls";
                saveDialog.FileName = "Informe (fecha " + System.DateTime.Now.ToString("yyyy-MM-dd)", System.Globalization.CultureInfo.CurrentCulture) + " (hora " + System.DateTime.Now.ToString("HH-mm-ss)", System.Globalization.CultureInfo.CurrentCulture);
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(saveDialog.FileName))
                {
                    try
                    {
                        Infragistics.Documents.Excel.Workbook excelWorkbook = new Infragistics.Documents.Excel.Workbook();
                        Infragistics.Documents.Excel.Worksheet excelWorksheet = excelWorkbook.Worksheets.Add("Exportado por Órbita Ingeniería");

                        excelWorksheet.Rows[1].Cells[4].CellFormat.Font.Height = 400;
                        excelWorksheet.Rows[1].Cells[4].CellFormat.Font.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                        excelWorksheet.Rows[1].Cells[4].Value = "Informe";
                        excelWorksheet.Rows[3].Cells[2].CellFormat.Font.Bold = Infragistics.Documents.Excel.ExcelDefaultableBoolean.True;
                        excelWorksheet.Rows[3].Cells[2].Value = "Informe elaborado el " + System.DateTime.Now.ToString();

                        this.ugeeGrid.Export(this.OrbGrid, excelWorksheet, 5, 2);
                        excelWorkbook.Save(saveDialog.FileName);

                        System.Diagnostics.ProcessStartInfo psiExcel = new System.Diagnostics.ProcessStartInfo(saveDialog.FileName);
                        System.Diagnostics.Process.Start(psiExcel);

                        excelWorkbook = null;
                        excelWorksheet = null;
                    }
                    catch (System.IO.IOException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, "Error de entrada y salida. Es probable que el fichero esté ya abierto por Microsoft Office Excel." + ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
                    }
                }
            }
        }
        /// <summary>
        /// Limpiar los posibles filtros existentes.
        /// </summary>
        void LimpiarFiltros()
        {
            this.OrbGrid.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }
        #endregion

        #region ToolBar

        #region Tools

        #region Gestionar
        /// <summary>
        /// Gestionar.
        /// </summary>
        void ToolBarToolGestionar()
        {
            if (this.OrbBotonGestionarClick != null)
            {
                this.OrbBotonGestionarClick(this, new System.EventArgs());
            }
        }
        #endregion

        #region Ver
        /// <summary>
        /// Ver.
        /// </summary>
        void ToolBarToolVer()
        {
            if (this.OrbBotonVerClick != null)
            {
                this.OrbBotonVerClick(this, new System.EventArgs());
            }
        }
        #endregion

        #region Modificar
        /// <summary>
        /// Modificar.
        /// </summary>
        void ToolBarToolModificar()
        {
            if (this.OrbBotonModificarClick != null)
            {
                this.OrbBotonModificarClick(this, new System.EventArgs());
            }
        }
        #endregion

        #region Añadir
        /// <summary>
        /// Añadir.
        /// </summary>
        void ToolBarToolAñadir()
        {
            if (this.OrbBotonAñadirClick != null)
            {
                this.OrbBotonAñadirClick(this, new System.EventArgs());
            }
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// Eliminar.
        /// </summary>
        void ToolBarToolEliminar()
        {
            if (this.OrbBotonEliminarFilaClick != null)
            {
                this.OrbBotonEliminarFilaClick(this, new System.EventArgs());
            }
        }
        #endregion

        #region Editar
        /// <summary>
        /// Permitir acción (Editar).
        /// </summary>
        /// <param name="action">Acción.</param>
        /// <returns></returns>
        bool ToolBarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction action)
        {
            // Los KeyActionMappings revelarán si la acción es válida basada en el estado actual del grid. 
            return this.grid.KeyActionMappings.IsActionAllowed(action, (long)this.grid.CurrentState);
        }
        /// <summary>
        /// Actualizar estado de las Tools de la ToolBar (Editar).
        /// </summary>
        void ToolBarActualizarEstadoToolsEditar()
        {
            this.tlbGrid.Tools[Tools.OrbDeshacer.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Undo);
            this.tlbGrid.Tools[Tools.OrbRehacer.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Redo);
            this.tlbGrid.Tools[Tools.OrbCortar.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Cut);
            this.tlbGrid.Tools[Tools.OrbCopiar.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            this.tlbGrid.Tools[Tools.OrbPegar.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEditar(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
        }
        /// <summary>
        /// Deshacer.
        /// </summary>
        void ToolBarToolEditarDeshacer()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Undo);
        }
        /// <summary>
        /// Rehacer.
        /// </summary>
        void ToolBarToolEditarRehacer()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Redo);
        }
        /// <summary>
        /// Cortar.
        /// </summary>
        void ToolBarToolEditarCortar()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Cut);
        }
        /// <summary>
        /// Copiar.
        /// </summary>
        void ToolBarToolEditarCopiar()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
        }
        /// <summary>
        /// Pegar.
        /// </summary>
        void ToolBarToolEditarPegar()
        {
            this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
        }
        #endregion

        #region Exportar
        /// <summary>
        /// Exportar.
        /// </summary>
        void ToolBarToolExportar(Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // Actualizar ToolBarTool.
            this.tlbGrid.Tools[Tools.OrbExportar.ToString()].SharedProps.AppearancesSmall.Appearance.Image = e.Tool.SharedProps.AppearancesSmall.Appearance.Image;
            this.tlbGrid.Tools[Tools.OrbExportar.ToString()].SharedProps.Tag = e.Tool.Key;
            this.tlbGrid.Tools[Tools.OrbExportar.ToString()].SharedProps.Caption = e.Tool.CaptionResolved;
        }
        /// <summary>
        /// Exportar.
        /// </summary>
        void ToolBarToolExportarExcel(Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // Actualizar ToolBar.
            this.ToolBarToolExportar(e);
            // Si tiene manejador, se ejecuta el manejador.
            if (this.OrbBotonExportarExcel != null && this.OrbBotonExportarExcel.GetInvocationList().Length > 0)
            {
                this.OrbBotonExportarExcel(this, new System.EventArgs());
            }
            else // Si no lo tiene, exportar por defecto a Excel.
            {
                this.ExportarExcel();
            }
        }
        #endregion

        #region Imprimir
        /// <summary>
        /// Imprimir.
        /// </summary>
        void ToolBarToolImprimir()
        {
            if (this.OrbGrid.DataSource != null)
            {
                this.ugpdGrid.Grid = this.OrbGrid;
                this.uppdGrid.Document = ugpdGrid;
                this.uppdGrid.Document.DefaultPageSettings.Landscape = true;
                this.uppdGrid.ShowDialog();
            }
        }
        #endregion

        #region Estilo
        /// <summary>
        /// Permitir acción (Estilo).
        /// </summary>
        /// <returns></returns>
        bool ToolBarPermitirAccionEstilo()
        {
            return (long)this.grid.CurrentState != 0;
        }
        /// <summary>
        /// Actualizar estado de los botones de la ToolBar (Estilo).
        /// </summary>
        void ToolBarActualizarEstadoToolsEstilo()
        {
            this.tlbGrid.Tools[Tools.OrbGuardarPlantilla.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEstilo();
            this.tlbGrid.Tools[Tools.OrbGuardarPlantillaComo.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEstilo();
            this.tlbGrid.Tools[Tools.OrbPublicarPlantilla.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEstilo();
            this.tlbGrid.Tools[Tools.OrbImportarPlantillas.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEstilo();
            this.tlbGrid.Tools[Tools.OrbEliminarPlantillas.ToString()].SharedProps.Enabled = this.ToolBarPermitirAccionEstilo();
        }
        object customNodoSeleccionado = null;
        /// <summary>
        /// ToolBarToolPersonalizar.
        /// </summary>
        void ToolBarToolPersonalizar()
        {
            using (FrmPersonalizar form = new FrmPersonalizar(customNodoSeleccionado))
            {
                form.OrbIndiceSeleccionado += new System.EventHandler<System.EventArgs>(frmPersonalizar_OrbIndiceSeleccionado);
                FrmPersonalizar.Grid = this.grid;
                form.ShowDialog();
            }
        }
        void frmPersonalizar_OrbIndiceSeleccionado(object sender, System.EventArgs e)
        {
            System.Windows.Forms.TreeView trv = (System.Windows.Forms.TreeView)sender;
            customNodoSeleccionado = trv.SelectedNode.Tag;
        }
        /// <summary>
        /// ToolBarToolGuardarPlantilla.
        /// </summary>
        /// <param name="sender"></param>
        void ToolBarToolGuardarPlantilla(object sender)
        {
            // Obtener la clave de la colección de plantillas activa en caso de existir.
            string clave = string.Empty;
            if (this.plantillasActivas != null)
            {
                foreach (var item in this.plantillasActivas)
                {
                    if (item.Value.Activo)
                    {
                        clave = item.Key;
                        break;
                    }
                }
            }
            string opcion = sender as string;
            // Si se ha encontrado una plantilla activa y se ha pulsado Guardar plantilla... (UPDATE).
            if (!string.IsNullOrEmpty(clave) && opcion == Tools.OrbGuardarPlantilla.ToString())
            {
                if (System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, "¿Confirma sobreescribir la plantilla {0}?", this.plantillasActivas[clave].Nombre), "Confirmación", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2, 0) == System.Windows.Forms.DialogResult.Yes)
                {
                    OConfiguracion.OrbPersistencia.SetPlantilla(this, clave as object);
                }
            }
            else
            {
                string nombre = string.Empty;
                string descripcion = string.Empty;
                if (!string.IsNullOrEmpty(clave))
                {
                    nombre = this.plantillasActivas[clave].Nombre;
                    descripcion = this.plantillasActivas[clave].Descripcion;
                }
                // Si se ha encontrado una plantilla activa/inactiva y se ha pulsado Guardar plantilla/Guardar plantilla como... (UPDATE/INSERT).
                using (FrmGuardarArchivo form = new FrmGuardarArchivo(nombre, descripcion))
                {
                    switch ((Tools)System.Enum.Parse(typeof(Tools), opcion))
                    {
                        case Tools.OrbGuardarPlantilla:
                            form.Text = "Guardar plantilla";
                            break;
                        default:
                        case Tools.OrbGuardarPlantillaComo:
                            form.Text = "Guardar plantilla como...";
                            break;
                    }
                    switch (form.ShowDialog())
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            if (form.Nueva)
                            {
                                // Crear una nueva plantilla.
                                if (OConfiguracion.OrbPersistencia.SetPlantilla(this, form.Nombre, form.Descripcion, false) == 0)
                                {
                                    // Resetear valores.
                                    ToolBarGetPlantillas(true);
                                }
                            }
                            else
                            {
                                // Actualizar el nombre de la colección.
                                ToolBarSetPlantilla(clave, form.Nombre, form.Descripcion);
                            }
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// ToolBarToolPublicarPlantilla.
        /// </summary>
        void ToolBarToolPublicarPlantilla()
        {
            using (FrmGuardarArchivo form = new FrmGuardarArchivo())
            {
                form.Text = "Publicar plantilla";
                switch (form.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        OConfiguracion.OrbPersistencia.SetPlantilla(this, form.Nombre, form.Descripcion, true);
                        break;
                }
            }
        }
        /// <summary>
        /// ToolBarToolImportarPlantillas.
        /// </summary>
        void ToolBarToolImportarPlantillas()
        {
            System.Collections.Generic.Dictionary<string, OPlantilla> plantillas = OConfiguracion.OrbPersistencia.GetPlantillas(this);
            using (FrmListadoPlantillasPublicas form = new FrmListadoPlantillasPublicas(plantillas, this.ErrorListarPlantillas(plantillas)))
            {
                switch (form.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        foreach (System.Windows.Forms.ListViewItem item in form.Lista.SelectedItems)
                        {
                            string clave = item.SubItems["identificador"].Text;
                            OConfiguracion.OrbPersistencia.GetPlantilla(this, plantillas[clave]);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// ToolBarSetPlantilla.
        /// </summary>
        void ToolBarToolEliminarPlantillasLocales()
        {
            using (FrmListadoPlantillas form = new FrmListadoPlantillas(this.plantillasActivas, this.ErrorListarPlantillas(this.plantillasActivas)))
            {
                form.Text = "Eliminar plantillas locales";
                form.Cabecera.Text = "Marque las plantillas locales que desea eliminar: \r\n(se excluye del listado la plantilla seleccionada)";
                switch (form.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        int res = 0;
                        foreach (System.Windows.Forms.ListViewItem item in form.Lista.CheckedItems)
                        {
                            string clave = item.SubItems["identificador"].Text;
                            OPlantilla plantilla = this.plantillasActivas[clave];
                            if (OConfiguracion.OrbPersistencia.SetPlantilla(plantilla.Identificador) == 0)
                            {
                                // Eliminar la plantilla de la colección y de la ToolBar.
                                res += this.ToolBarSetPlantilla(plantilla);
                            }
                        }
                        if (res > 0)
                        {
                            // Agrupar las plantillas de la ToolBar.
                            this.ToolBarAgruparPlantillas();
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// ToolBarSetPlantillaPublica.
        /// </summary>
        void ToolBarToolEliminarPlantillasPublicas()
        {
            System.Collections.Generic.Dictionary<string, OPlantilla> plantillas = OConfiguracion.OrbPersistencia.GetPlantillas(this, true);
            using (FrmListadoPlantillas form = new FrmListadoPlantillas(plantillas, this.ErrorListarPlantillas(plantillas)))
            {
                form.Text = "Eliminar plantillas públicas";
                form.Cabecera.Text = "Marque las plantillas públicas que desea eliminar:";
                switch (form.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        foreach (System.Windows.Forms.ListViewItem item in form.Lista.CheckedItems)
                        {
                            string clave = item.SubItems["identificador"].Text;
                            OConfiguracion.OrbPersistencia.SetPlantilla(plantillas[clave].Identificador);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// ToolBarAddPlantilla.
        /// </summary>
        /// <param name="plantilla"></param>
        void ToolBarAddPlantilla(System.Collections.Generic.KeyValuePair<string, OPlantilla> plantilla)
        {
            if (plantilla.Value != null)
            {
                // Obtener el PopupMenuTool (Estilo).
                Infragistics.Win.UltraWinToolbars.PopupMenuTool estilo = this.tlbGrid.Tools[Tools.OrbEstilo.ToString()] as Infragistics.Win.UltraWinToolbars.PopupMenuTool;
                if (!this.tlbGrid.Tools.Exists(plantilla.Key))
                {
                    // Crear los objetos a añadir.
                    Infragistics.Win.UltraWinToolbars.StateButtonTool tool = new Infragistics.Win.UltraWinToolbars.StateButtonTool(plantilla.Key);
                    tool.SharedProps.Caption = plantilla.Value.Nombre;
                    tool.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
                    // Añadir el objeto a la ToolBarManager.
                    this.tlbGrid.Tools.Add(tool);
                    // Añadir el objeto al PopupMenuTool asociado.
                    estilo.Tools.Add(tool);
                    // Definir la línea horizontal de separación para el primer elemento.
                    estilo.Tools[plantilla.Key].InstanceProps.IsFirstInGroup = plantilla.Value.Primero;
                }
                // Desactivar el evento para evitar que se ejecuten los activos del checked.
                this.tlbGrid.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolBar_Click);
                // Actualizar el checked de la Tool en función del atributo activo.
                (estilo.Tools[plantilla.Key] as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked = plantilla.Value.Activo;
                // Activar el evento para evitar que se ejecuten los activos del checked.
                this.tlbGrid.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolBar_Click);
            }
        }
        /// <summary>
        /// ToolBarSetPlantilla.
        /// </summary>
        /// <param name="plantilla"></param>
        int ToolBarSetPlantilla(OPlantilla plantilla)
        {
            // Eliminar la plantilla de la colección.
            if (this.plantillasActivas.ContainsKey(plantilla.Clave))
            {
                this.plantillasActivas.Remove(plantilla.Clave);
            }
            // Eliminar plantilla de la ToolBar.
            Infragistics.Win.UltraWinToolbars.PopupMenuTool estilo = this.tlbGrid.Tools[Tools.OrbEstilo.ToString()] as Infragistics.Win.UltraWinToolbars.PopupMenuTool;
            if (this.tlbGrid.Tools.Exists(plantilla.Clave))
            {
                this.tlbGrid.Tools.Remove(estilo.Tools[plantilla.Clave]);
            }
            return 1;
        }
        /// <summary>
        /// ToolBarSetPlantilla.
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        bool ToolBarSetPlantilla(string clave)
        {
            if (this.plantillasActivas.ContainsKey(clave))
            {
                bool activo = (this.tlbGrid.Tools[clave] as Infragistics.Win.UltraWinToolbars.StateButtonTool).Checked;
                // Actualizar el registro de Base de datos.
                OConfiguracion.OrbPersistencia.SetPlantilla(this, clave, activo);
                return activo;
            }
            return false;
        }
        /// <summary>
        /// ToolBarSetPlantilla.
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        void ToolBarSetPlantilla(string clave, string nombre, string descripcion)
        {
            if (this.plantillasActivas.ContainsKey(clave))
            {
                // Actualizar el nombre y la descripción de la colección.
                this.plantillasActivas[clave].Nombre = nombre;
                this.plantillasActivas[clave].Descripcion = descripcion;
                // Actualizar plantilla actual con un nuevo nombre.
                if (OConfiguracion.OrbPersistencia.SetPlantilla(this, clave as object) == 0)
                {
                    // Resetear valores.
                    (this.tlbGrid.Tools[clave] as Infragistics.Win.UltraWinToolbars.StateButtonTool).SharedProps.Caption = nombre;
                }
            }
        }
        /// <summary>
        /// ToolBarGetPlantilla.
        /// </summary>
        /// <param name="clave">clave.</param>
        void ToolBarGetPlantilla(string clave)
        {
            if (this.plantillasActivas.ContainsKey(clave))
            {
                // Obtener plantilla.
                OConfiguracion.OrbPersistencia.GetPlantilla(this, clave);
                // Seleccionar la primera fila de la plantilla cargada (ActiveRow).
                // Debemos hacer esta llamada, ya que, está seleccionando una fila aleatoriamente.
                this.ActivarPrimeraFila();
            }
        }
        /// <summary>
        /// ToolBarGetPlantillas.
        /// </summary>
        /// <param name="nueva">nueva.</param>
        /// <returns></returns>
        bool ToolBarGetPlantillas(bool nueva)
        {
            bool activa = false;
            this.plantillasActivas = OConfiguracion.OrbPersistencia.GetPlantillas(this, false);
            if (this.plantillasActivas != null)
            {
                int cont = 0;
                string[] grupo = new string[this.plantillasActivas.Count];
                foreach (var item in this.plantillasActivas)
                {
                    this.ToolBarAddPlantilla(item);
                    grupo[cont++] = item.Key;
                    if (!nueva && item.Value.Activo)
                    {
                        this.ToolBarGetPlantilla(item.Key);
                        activa = true;
                    }
                }
                if (this.tlbGrid.OptionSets.Exists("plantillas"))
                {
                    this.tlbGrid.OptionSets.Clear();
                }
                this.tlbGrid.OptionSets.Add(true, "plantillas");
                this.tlbGrid.OptionSets["plantillas"].Tools.AddToolRange(grupo);
            }
            return activa;
        }
        /// <summary>
        /// ToolBarAgruparPlantillas.
        /// </summary>
        void ToolBarAgruparPlantillas()
        {
            if (this.plantillasActivas != null && this.plantillasActivas.Count > 0)
            {
                string[] grupo = new string[this.plantillasActivas.Count];
                this.plantillasActivas.Keys.CopyTo(grupo, 0);
                // Definir la línea horizontal de separación para el primer elemento.
                if (!this.plantillasActivas[grupo[0]].Primero)
                {
                    OPlantilla plantilla = this.plantillasActivas[grupo[0]];
                    plantilla.Primero = true;
                    // Obtener el PopupMenuTool (Estilo).
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool estilo = this.tlbGrid.Tools[Tools.OrbEstilo.ToString()] as Infragistics.Win.UltraWinToolbars.PopupMenuTool;
                    if (this.tlbGrid.Tools.Exists(plantilla.Clave))
                    {
                        estilo.Tools[plantilla.Clave].InstanceProps.IsFirstInGroup = true;
                        if (this.tlbGrid.OptionSets.Exists("plantillas"))
                        {
                            this.tlbGrid.OptionSets.Clear();
                        }
                        this.tlbGrid.OptionSets.Add(true, "plantillas");
                        this.tlbGrid.OptionSets["plantillas"].Tools.AddToolRange(grupo);
                    }
                }
            }
        }
        /// <summary>
        /// ErrorListarPlantillas.
        /// </summary>
        /// <param name="plantillas"></param>
        /// <returns></returns>
        bool ErrorListarPlantillas(System.Collections.Generic.Dictionary<string, Orbita.Controles.Grid.OPlantilla> plantillas)
        {
            bool res = false;
            if (plantillas == null || plantillas.Count == 0)
            {
                res = true;
            }
            else
            {
                if (plantillas.Count == 1)
                {
                    foreach (OPlantilla plantilla in plantillas.Values)
                    {
                        res = plantilla.Activo;
                    }
                }
            }
            return res;
        }
        #endregion

        #region Refrescar
        /// <summary>
        /// Refrescar.
        /// </summary>
        void ToolBarToolRefrescar()
        {
            if (this.OrbBotonRefrescarClick != null)
            {
                this.OrbBotonRefrescarClick(this, new System.EventArgs());
            }
        }
        /// <summary>
        /// ToolRefrescar.
        /// </summary>
        void ToolRefrescar()
        {
            if (this.OrbToolRefrescar != null)
            {
                this.OrbToolRefrescar(this, new System.EventArgs());
            }
        }
        #endregion

        #region Filtrar
        /// <summary>
        /// Limpiar filtros.
        /// </summary>
        void ToolBarToolLimpiarFiltros()
        {
            this.grid.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
            this.tlbGrid.Tools[Tools.OrbLimpiarFiltros.ToString()].SharedProps.Visible = false;
            this.tlbGrid.Tools[Tools.OrbIrPrimero.ToString()].SharedProps.Enabled = true;
            this.tlbGrid.Tools[Tools.OrbIrAnterior.ToString()].SharedProps.Enabled = true;
            this.tlbGrid.Tools[Tools.OrbIrSiguiente.ToString()].SharedProps.Enabled = true;
            this.tlbGrid.Tools[Tools.OrbIrUltimo.ToString()].SharedProps.Enabled = true;
            this.tlbGrid.Tools[Tools.OrbOrdenIrA.ToString()].SharedProps.Enabled = true;
            if (this.OrbOrdenCambioActivacion != null)
            {
                this.OrbOrdenCambioActivacion(!this.tlbGrid.Tools[Tools.OrbLimpiarFiltros.ToString()].SharedProps.Visible);
            }
        }
        #endregion

        #region Ir a posición
        /// <summary>
        /// Mover la fila a la primera posición.
        /// </summary>
        void ToolBarToolIrPrimero()
        {
            ToolBarToolIrAnterior(0, true);
        }
        /// <summary>
        /// Mover la fila a la posición anterior.
        /// </summary>
        void ToolBarToolIrAnterior()
        {
            ToolBarToolIrAnterior(1, false);
        }
        /// <summary>
        /// Mover la fila a la posición anterior.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="principio"></param>
        void ToolBarToolIrAnterior(int x, bool principio)
        {
            if (string.IsNullOrEmpty(OrbGridOrdenNombreCampo))
            {
                return;
            }
            this.OrbGrid.SuspendLayout();
            try
            {
                int contador = 0;
                bool fin = false;
                while (!fin && (contador < x || principio))
                {
                    contador++;
                    if (this.OrbGrid.ActiveRow != null &&
                        this.OrbGrid.ActiveRow.IsDataRow &&
                       !this.OrbGrid.ActiveRow.IsFilteredOut &&
                       !this.OrbGrid.ActiveRow.IsAddRow &&
                      !(this.OrbFiltroMostrar && this.OrbGrid.ActiveRow.VisibleIndex == 1) &&
                        this.OrbGrid.ActiveRow.Cells[OrbGridOrdenNombreCampo].Value != null)
                    {
                        int ordenFila;
                        if (int.TryParse(this.OrbGrid.ActiveRow.Cells[OrbGridOrdenNombreCampo].Value.ToString(), out ordenFila))
                        {
                            int indiceMayor = this.OrbGrid.ActiveRow.VisibleIndex;
                            int ajusteFilas = 0;
                            if (this.OrbFiltroMostrar)
                            {
                                ajusteFilas = 1;
                            }
                            if (indiceMayor > ajusteFilas)
                            {
                                this.OrbGrid.Rows.GetRowAtVisibleIndex(indiceMayor - 1).Cells[OrbGridOrdenNombreCampo].Value = ordenFila;
                                this.OrbGrid.Rows.GetRowAtVisibleIndex(indiceMayor - 1).Update();
                                this.OrbGrid.ActiveRow.Cells[OrbGridOrdenNombreCampo].Value = ordenFila - 1;
                                this.OrbGrid.ActiveRow.Update();
                                this.OrbGrid.ActiveRow.RefreshSortPosition();
                                this.OrbGrid.UpdateData();
                                this.OrbGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
                            }
                            else
                            {
                                fin = true;
                            }
                        }
                        else
                        {
                            fin = true;
                        }
                    }
                    else
                    {
                        fin = true;
                    }
                }
            }
            finally
            {
                this.OrbGrid.ResumeLayout();
            }
        }
        /// <summary>
        /// Mover la fila a la posición siguiente.
        /// </summary>
        void ToolBarToolIrSiguiente()
        {
            ToolBarToolIrSiguiente(1, false);
        }
        /// <summary>
        /// Mover la fila a la posición siguiente.
        /// </summary>
        /// <param name="x">Posición.</param>
        /// <param name="final"></param>
        void ToolBarToolIrSiguiente(int x, bool final)
        {
            if (string.IsNullOrEmpty(this.OrbGridOrdenNombreCampo)) return;
            this.OrbGrid.SuspendLayout();
            try
            {
                int contador = 0;
                bool fin = false;
                while (!fin && (contador < x || final))
                {
                    contador++;
                    if (this.OrbGrid.ActiveRow != null &&
                        this.OrbGrid.ActiveRow.IsDataRow &&
                       !this.OrbGrid.ActiveRow.IsFilteredOut &&
                       !this.OrbGrid.ActiveRow.IsAddRow &&
                        this.OrbGrid.ActiveRow.Cells[this.OrbGridOrdenNombreCampo].Value != null)
                    {
                        int ordenFila;
                        if (int.TryParse(this.OrbGrid.ActiveRow.Cells[OrbGridOrdenNombreCampo].Value.ToString(), out ordenFila))
                        {
                            int indiceMayor = this.OrbGrid.ActiveRow.VisibleIndex;
                            int ajusteFilas = 0;
                            if (!this.OrbFiltroMostrar)
                            {
                                ajusteFilas = 1;
                            }
                            if (indiceMayor < this.OrbGrid.Rows.Count - ajusteFilas)
                            {
                                this.OrbGrid.Rows.GetRowAtVisibleIndex(indiceMayor + 1).Cells[OrbGridOrdenNombreCampo].Value = ordenFila;
                                this.OrbGrid.Rows.GetRowAtVisibleIndex(indiceMayor + 1).Update();
                                this.OrbGrid.ActiveRow.Cells[OrbGridOrdenNombreCampo].Value = ordenFila + 1;
                                this.OrbGrid.ActiveRow.Update();
                                this.OrbGrid.ActiveRow.RefreshSortPosition();
                                this.OrbGrid.UpdateData();
                                this.OrbGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
                            }
                            else
                            {
                                fin = true;
                            }
                        }
                        else
                        {
                            fin = true;
                        }
                    }
                    else
                    {
                        fin = true;
                    }
                }
            }
            finally
            {
                this.OrbGrid.ResumeLayout();
            }
        }
        /// <summary>
        /// Mover la fila a la última posición.
        /// </summary>
        void ToolBarToolIrUltimo()
        {
            ToolBarToolIrSiguiente(0, true);
        }
        #endregion

        #endregion

        #region ToolBarManager
        /// <summary>
        /// Inicializar la posición del ToolBarExtendido.
        /// </summary>
        void ToolBarInicializarPosicionArribaExtendido()
        {
            this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Extendido].DockedColumn = 0;
            this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Extendido].DockedRow = 0;
            this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].DockedColumn = 0;
            this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Arriba].DockedRow = 1;
        }
        #endregion

        #endregion

        #endregion

        #region Métodos estáticos
        /// <summary>
        /// Establecer recursos del Grid.
        /// </summary>
        static void InitializeResourceStrings()
        {
            Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            resCustomizer.SetCustomizedString("DeleteMultipleRowsPrompt", "Va a borrar {0} filas. Elija Si para borrarlas o No para salir.");
            resCustomizer.SetCustomizedString("DeleteSingleRowPrompt", "¿Está seguro que desea eliminar la fila seleccionada?");
            resCustomizer.SetCustomizedString("RowFilterDialogBlanksItem", "(Vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDialogDBNullItem", "(Nulos)");
            resCustomizer.SetCustomizedString("RowFilterDialogEmptyTextItem", "(Vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDialogOperandHeaderCaption", "(Operando)");
            resCustomizer.SetCustomizedString("RowFilterDialogOperatorHeaderCaption", "Operador");
            resCustomizer.SetCustomizedString("RowFilterDialogTitlePrefix", "Establezca el filtro para");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Contains", "(Contiene)");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotContain", "No contiene");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotEndWith", "No acaba en");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotMatch", "No es igual a");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotStartWith", "No empieza por");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_EndsWith", "Acaba en");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Equals", "=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_GreaterThan", ">");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_GreaterThanOrEqualTo", ">=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_LessThan", "<");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_LessThanOrEqualTo", "<=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Like", "Como");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Match", "(Igual)");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_NotEquals", "!=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_NotLike", "No es como");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_StartsWith", "Empieza por");
            resCustomizer.SetCustomizedString("RowFilterDropDownAllItem", "(Todos)");
            resCustomizer.SetCustomizedString("RowFilterDropDownBlanksItem", "(Vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDropDownCustomItem", "(Personalizado)");
            resCustomizer.SetCustomizedString("RowFilterDropDownEquals", "(Igual)");
            resCustomizer.SetCustomizedString("RowFilterDropDownGreaterThan", "Mayor que");
            resCustomizer.SetCustomizedString("RowFilterDropDownGreaterThanOrEqualTo", "Mayor o igual que");
            resCustomizer.SetCustomizedString("RowFilterDropDownLessThan", "Menor que");
            resCustomizer.SetCustomizedString("RowFilterDropDownLessThanOrEqualTo", "Menor o igual que");
            resCustomizer.SetCustomizedString("RowFilterDropDownLike", "Como");
            resCustomizer.SetCustomizedString("RowFilterDropDownMatch", "Coincide con la expresión regular");
            resCustomizer.SetCustomizedString("RowFilterDropDownNonBlanksItem", "(No vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDropDownNotEquals", "No es igual a");
            resCustomizer.SetCustomizedString("RowFilterLogicalOperator_And", "Y");
            resCustomizer.SetCustomizedString("RowFilterLogicalOperator_Or", "O");
            resCustomizer.SetCustomizedString("RowFilterPatternCaption", "Patrón de búsqueda no válido");
            resCustomizer.SetCustomizedString("RowFilterPatternError", "Error parseando el patrón {0}. Por favor, establezca un patrón de búsqueda válido.");
            resCustomizer.SetCustomizedString("RowFilterPatternException", "Patrón de búsqueda no válido {0}.");
            resCustomizer.SetCustomizedString("RowFilterRegexError", "Error parseando la expresión regular {0}. Por favor establezca una expresión regular válida.");
            resCustomizer.SetCustomizedString("RowFilterRegexErrorCaption", "Expresión regular no válida");
            resCustomizer.SetCustomizedString("RowFilterRegexException", "Expresión regular no válida {0}.");
            resCustomizer.SetCustomizedString("FilterClearButtonToolTip_FilterCell", "Click para limpiar el filtro de {0}.");
            resCustomizer.SetCustomizedString("FilterClearButtonToolTip_RowSelector", "Click para limpiar todos los filtros.");
            resCustomizer.SetCustomizedString("FilterDialogAddConditionButtonText", "&Añadir condición");
            resCustomizer.SetCustomizedString("FilterDialogTitle", "Personalizar filtro");
            resCustomizer.SetCustomizedString("FilterDialogApplyLabelText", "Filtro basado en {0} las siguientes condiciones:");
            resCustomizer.SetCustomizedString("FilterDialogAnyComboItem", "Cualquier");
            resCustomizer.SetCustomizedString("FilterDialogAllComboItem", "Todas");
            resCustomizer.SetCustomizedString("FilterDialogConditionAddButtonText", "&Añadir");
            resCustomizer.SetCustomizedString("FilterDialogConditionDeleteButtonText", "&Borrar");
            resCustomizer.SetCustomizedString("FilterDialogOkButtonText", "Aceptar");
            resCustomizer.SetCustomizedString("FilterDialogAndRadioText", "Condiciones 'Y'");
            resCustomizer.SetCustomizedString("FilterDialogCancelButtonText", "&Cancelar");
            resCustomizer.SetCustomizedString("FilterDialogDeleteButtonText", "Borrar condición");
            resCustomizer.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "Filtros N&o");
            resCustomizer.SetCustomizedString("FilterDialogOrRadioText", "Condiciones 'O'");
            resCustomizer.SetCustomizedString("SummaryDialog_Button_Cancel", "&Cancelar");
            resCustomizer.SetCustomizedString("SummaryDialog_Button_OK", "&OK");
            resCustomizer.SetCustomizedString("SummaryDialogAverage", "Media");
            resCustomizer.SetCustomizedString("SummaryDialogCount", "Recuento");
            resCustomizer.SetCustomizedString("SummaryDialogMaximum", "Máximo");
            resCustomizer.SetCustomizedString("SummaryDialogMinimum", "Mínimo");
            resCustomizer.SetCustomizedString("SummaryDialogNone", "Ninguno");
            resCustomizer.SetCustomizedString("SummaryDialogSum", "Suma");
            resCustomizer.SetCustomizedString("SummaryFooterCaption_ChildBandNonGroupByRows", "Resúmenes para [BANDHEADER]: [SCROLLTIPFIELD]");
            resCustomizer.SetCustomizedString("SummaryFooterCaption_GroupByChildRows", "Resúmenes para [GROUPBYROWVALUE]");
            resCustomizer.SetCustomizedString("SummaryFooterCaption_RootRows", "Resúmenes");
            resCustomizer.SetCustomizedString("SummaryTypeAverage", "Media");
            resCustomizer.SetCustomizedString("SummaryTypeCustom", "Personalizado");
            resCustomizer.SetCustomizedString("SummaryTypeMaximum", "Máximo");
            resCustomizer.SetCustomizedString("SummaryTypeMinimum", "Mínimo");
            resCustomizer.SetCustomizedString("SummaryTypeSum", "Suma");
            resCustomizer.SetCustomizedString("SummaryValueInvalidDisplayFormat", "Formato no válido: {0}. Más informacion: {1}");
            resCustomizer.SetCustomizedString("LDR_SelectSummaries", "Seleccione los resúmenes");
            // Este modifica los textos del menú contextual de las celdas numéricas.
            Infragistics.Shared.ResourceCustomizer resCustomizer2 = Infragistics.Win.Resources.Customizer;
            resCustomizer2.SetCustomizedString("EditContextMenuCopy", "Copiar");
            resCustomizer2.SetCustomizedString("EditContextMenuCut", "Cortar");
            resCustomizer2.SetCustomizedString("EditContextMenuPaste", "Pegar");
            resCustomizer2.SetCustomizedString("EditContextMenuSelectAll", "Seleccionar todo");
            // Recursor de la ToolBar.
            Infragistics.Shared.ResourceCustomizer resCustomizerToolbar = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
            resCustomizerToolbar.SetCustomizedString("QuickCustomizeToolTipXP", "Opciones de la barra de tareas");
        }
        /// <summary>
        /// Aplicar estilo a la columna del Grid.
        /// </summary>
        /// <param name="banda">An object that represents a set of related columns of data.</param>
        /// <param name="columna">Campos de estilos.</param>
        /// <param name="posicion">Posición de las columnas visibles.</param>
        static void SetEstilo(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna, int posicion)
        {
            // Visualizar la columna oculta.
            banda.Columns[columna.Campo].Hidden = false;
            banda.Columns[columna.Campo].Tag = true.ToString();
            // Caption de la cabecera.
            banda.Columns[columna.Campo].Header.Caption = columna.Nombre;
            // Estilo.
            banda.Columns[columna.Campo].Style = (Infragistics.Win.UltraWinGrid.ColumnStyle)columna.Estilo;
            // Alineación de celda horizontal.
            banda.Columns[columna.Campo].CellAppearance.TextHAlign = (Infragistics.Win.HAlign)columna.Alinear;
            // Ancho de columna.
            if (columna.Ancho > -1)
            {
                banda.Columns[columna.Campo].Width = columna.Ancho;
            }
            // Posición de la columna.
            banda.Columns[columna.Campo].Header.VisiblePosition = posicion;
        }
        /// <summary>
        /// Aplicar máscara a la columna del Grid.
        /// </summary>
        /// <param name="banda">An object that represents a set of related columns of data.</param>
        /// <param name="columna">Campos de estilos.</param>
        static void SetMascara(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (columna.Mascara != null)
            {
                banda.Columns[columna.Campo].MaskInput = columna.Mascara.Nombre;
                banda.Columns[columna.Campo].MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                banda.Columns[columna.Campo].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                banda.Columns[columna.Campo].PromptChar = columna.Mascara.Prompt;
                if (columna.Mascara.Maximo != null && columna.Mascara.Minimo != null)
                {
                    banda.Columns[columna.Campo].MaxValue = columna.Mascara.Maximo;
                    banda.Columns[columna.Campo].MinValue = columna.Mascara.Minimo;
                }
            }
        }
        /// <summary>
        /// Aplicar Sumario al Grid.
        /// </summary>
        /// <param name="banda">An object that represents a set of related columns of data.</param>
        /// <param name="columna">Campos de estilos.</param>
        static void SetSumario(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (columna.Sumario != null)
            {
                // Añadir un nuevo sumario a la columna.
                Infragistics.Win.UltraWinGrid.SummarySettings sumario = banda.Summaries.Add(columna.Campo, columna.Sumario.Operacion, banda.Columns[columna.Campo]);
                // Mostrar sumario en la columna seleccionada.
                sumario.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
                sumario.SummaryPositionColumn = sumario.SourceColumn;
                // Formatear la apariencia del resumen.
                sumario.DisplayFormat = columna.Sumario.Mascara;
                // Justificar el texto.
                sumario.Appearance.TextHAlign = (Infragistics.Win.HAlign)columna.Alinear;
            }
        }
        /// <summary>
        /// Aplicar Sumario de recuento de filas al Grid.
        /// </summary>
        /// <param name="banda">SummarySettings object represents a summary. Objects of this type are also refered to as summaries.</param>
        /// <param name="columna">Campos de estilos.</param>
        static void SetSumarioCount(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (banda.Columns.Exists(columna.Campo))
            {
                string clave = banda.Summaries.Count.ToString(System.Globalization.CultureInfo.CurrentCulture);
                banda.Summaries.Add(clave, Infragistics.Win.UltraWinGrid.SummaryType.Count, banda.Columns[columna.Campo], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                banda.Summaries[clave].DisplayFormat = "{0:#####.##}";
                banda.Summaries[clave].Band.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
                banda.Summaries[clave].Band.Override.BorderStyleSummaryFooter = Infragistics.Win.UIElementBorderStyle.Solid;
            }
        }
        /// <summary>
        /// Obtener el valor boolean a partir de un valor Infragistics.Win.DefaultableBoolean.
        /// </summary>
        /// <param name="valor">Valor de tipo Infragistics.Win.DefaultableBoolean.</param>
        /// <returns>boolean.</returns>
        static bool GetBoolean(Infragistics.Win.DefaultableBoolean valor)
        {
            return valor == Infragistics.Win.DefaultableBoolean.True;
        }
        /// <summary>
        /// Obtener el valor Infragistics.Win.DefaultableBoolean a partir de un valor boolean.
        /// </summary>
        /// <param name="valor">Valor de tipo boolean.</param>
        /// <returns>Infragistics.Win.DefaultableBoolean.</returns>
        static Infragistics.Win.DefaultableBoolean GetDefaultableBoolean(bool valor)
        {
            switch (valor)
            {
                case true:
                    return Infragistics.Win.DefaultableBoolean.True;
                case false:
                default:
                    return Infragistics.Win.DefaultableBoolean.False;
            }
        }
        /// <summary>
        /// Aplicar estilo a la celda de filtro de la columna.
        /// </summary>
        /// <param name="banda">An object that represents a set of related columns of data.</param>
        /// <param name="columna">Campos de estilos.</param>
        static void SetEstiloFiltro(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            banda.ColumnFilters[columna.Campo].ClearFilterConditions();
            Infragistics.Win.UltraWinGrid.FilterCondition condicion = new Infragistics.Win.UltraWinGrid.FilterCondition();
            condicion.ComparisionOperator = Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Contains;
            if (banda.Columns[columna.Campo].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
            {
                banda.ColumnFilters[columna.Campo].FilterConditions.Add(condicion);
                banda.ColumnFilters[columna.Campo].FilterConditions[0].CompareValue = string.Empty;
            }
        }
        #endregion

        #region Manejadores de eventos

        #region Grid
        /// <summary>
        /// AfterCellUpdate.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (this.OrbCeldaFinEdicion != null &&
                    this.grid.ActiveRow != null &&
                    this.grid.ActiveRow.IsDataRow &&
                    this.grid.ActiveCell != null)
                {
                    this.OrbCeldaFinEdicion(this, e.Cell);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// AfterRowActivate.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>      
        void Grid_AfterRowActivate(object sender, System.EventArgs e)
        {
            try
            {
                if (this.grid.ActiveRow.IsDataRow)
                {
                    if (this.OrbFilaSeleccionada != null)
                    {
                        this.OrbFilaSeleccionada(this, this.grid.ActiveRow);
                    }
                }
                else if (this.grid.ActiveRow.IsFilterRow)
                {
                    if (this.OrbFilaFiltrosSeleccionada != null)
                    {
                        this.OrbFilaFiltrosSeleccionada(this, this.grid.ActiveRow);
                    }
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// AfterRowFilterChanged.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
        {
            try
            {
                if (this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Visible)
                {
                    this.ordenEstadoAnterior = string.IsNullOrEmpty(e.NewColumnFilter.ToString());
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Tools[Tools.OrbLimpiarFiltros.ToString()].SharedProps.Visible = !this.ordenEstadoAnterior;
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Tools[Tools.OrbIrPrimero.ToString()].SharedProps.Enabled = this.ordenEstadoAnterior;
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Tools[Tools.OrbIrAnterior.ToString()].SharedProps.Enabled = this.ordenEstadoAnterior;
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Tools[Tools.OrbIrSiguiente.ToString()].SharedProps.Enabled = this.ordenEstadoAnterior;
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Tools[Tools.OrbIrUltimo.ToString()].SharedProps.Enabled = this.ordenEstadoAnterior;
                    this.tlbGrid.Toolbars[(int)Orbita.Controles.Shared.PosicionToolBar.Derecha].Tools[Tools.OrbOrdenIrA.ToString()].SharedProps.Enabled = this.ordenEstadoAnterior;
                    if (!this.ordenEstadoAnterior)
                    {
                        this.OrdenCambioActivacion();
                    }
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BeforeCellActivate.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (this.OrbCeldaComienzoActivacion != null)
                {
                    this.OrbCeldaComienzoActivacion(this.grid, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BeforeCellUpdate.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            try
            {
                if (this.OrbCeldaComienzoEdicion != null)
                {
                    this.OrbCeldaComienzoEdicion(this.grid, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// CellChange.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (this.OrbCeldaCambiaValor != null &&
                    this.grid.ActiveRow != null &&
                    this.grid.ActiveRow.IsDataRow &&
                    this.grid.ActiveCell != null)
                {
                    this.OrbCeldaCambiaValor(this, e.Cell);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// CellDataError.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            try
            {
                e.RaiseErrorEvent = false;
                System.Windows.Forms.MessageBox.Show("Formato de valor erroneo.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// ClickCellButton.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (this.OrbClickCellButton != null)
                {
                    this.OrbClickCellButton(this.grid, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// DoubleClickRow.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                if (this.OrbDobleClickFila != null)
                {
                    this.OrbDobleClickFila(this, e.Row);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// DoubleClickCell.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            try
            {
                if (this.OrbDobleClickCelda != null)
                {
                    this.OrbDobleClickCelda(this, e.Cell);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// Error.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_Error(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            try
            {
                if (this.OrbErrorGrid != null)
                {
                    this.OrbErrorGrid(this, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// FilterRow.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_FilterRow(object sender, Infragistics.Win.UltraWinGrid.FilterRowEventArgs e)
        {
            try
            {
                if (this.OrbFilaFiltrada != null)
                {
                    this.OrbFilaFiltrada(this, e);
                }
                if (this.OrbFiltradoFinalizado != null && e.Row == this.grid.Rows[this.grid.Rows.Count - 1])
                {
                    this.OrbFiltradoFinalizado(this, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// InitializeLayout.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            {
                if (this.OrbInitializeLayout != null)
                {
                    this.OrbInitializeLayout(this, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// InitializeRow.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            try
            {
                if (this.OrbInitializeRow != null)
                {
                    this.OrbInitializeRow(this, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// InitializeTemplateAddRow.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_InitializeTemplateAddRow(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e)
        {
            try
            {
                if (this.OrbInitializeTemplateAddRow != null)
                {
                    this.OrbInitializeTemplateAddRow(this.grid, e);
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// KeyDown.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void Grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case System.Windows.Forms.Keys.Return:
                        if (this.OrbGridIgnorarReturn) return;
                        this.OrbGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                        this.OrbGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        e.Handled = true;
                        break;
                    case System.Windows.Forms.Keys.Tab:
                    case System.Windows.Forms.Keys.Left:
                    case System.Windows.Forms.Keys.Right:
                        if ((this.columnaBloqueadas && !this.OrbFilaActiva.IsFilterRow) && ((this.OrbFilaActiva.IsFilterRow && this.OrbGrid.ActiveCell.Column == this.OrbGrid.DisplayLayout.Bands[0].Columns[0].GetRelatedVisibleColumn(Infragistics.Win.UltraWinGrid.VisibleRelation.Last) && !e.Shift) || (!this.OrbFilaActiva.IsFilterRow)))
                        {
                            e.Handled = true;
                        }
                        break;
                    case System.Windows.Forms.Keys.Delete:
                        if (!this.OrbCeldaEditable && this.OrbFilaPermitirBorrar)
                        {
                            if (this.OrbToolBarMostrarToolEliminar && this.OrbBotonEliminarFilaClick != null)
                            {
                                this.OrbBotonEliminarFilaClick(this, new System.EventArgs());
                            }
                        }
                        break;
                    case System.Windows.Forms.Keys.Escape:
                        this.DesactivarCelda();
                        break;
                    default:
                        e.Handled = false;
                        break;
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        #region Funcionalidad Ir a
        /// <summary>
        /// Validar el valor introducido en el number editor y mover la fila.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                ValidarPosicionIrA();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Intenta validar el number editor y mueve el foco al botón Aceptar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void nePosicion_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar('\r'))
            {
                this.btnAceptar.Focus();
            }
        }
        #endregion
        #endregion

        #region ToolBar
        /// <summary>
        /// OrbToolBarToolClick.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        void ToolBar_Click(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                // Ejecutar acción.
                this.grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                // Ejecutar eventos.
                if (this.OrbFilaActiva != null && this.OrbFilaActiva.IsDataRow && !this.OrbFilaActiva.IsFilteredOut && this.OrbFilaActiva.IsAddRow)
                {
                    this.OrbFilaActiva.Update();
                }
                if (this.OrbToolBarClick != null)
                {
                    this.OrbToolBarClick(this, e);
                }
                // En función del tipo de menú actuar de una manera.
                if (e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)
                {
                    if (e.Tool.OwningMenu != null)
                    {
                        switch (e.Tool.OwningMenu.Key)
                        {
                            case "OrbEstilo":
                                if (this.ToolBarSetPlantilla(e.Tool.Key))
                                {
                                    // Si se ha chequeado la plantilla seleccionada, cargar plantilla.
                                    this.ToolBarGetPlantilla(e.Tool.Key);
                                    // Asumir que se formatea el campo.
                                    this._formateado = true;
                                }
                                else
                                {
                                    // Omitir que el campo se encuentre formateado.
                                    this._formateado = false;
                                    // Limpiar los posibles filtros existentes.
                                    this.LimpiarFiltros();
                                    // IMPORTANTE: cualquier asignación de parámetros de configuración
                                    // hacerlos previo a refrescar = formatear.
                                    // No existe ninguna plantilla seleccionada, extender el manejador Refrescar.
                                    this.ToolRefrescar();
                                }
                                break;
                        }
                    }
                }
                else
                {
                    switch (e.Tool.Key)
                    {
                        case "OrbGestionar":
                            this.ToolBarToolGestionar();
                            break;
                        case "OrbVer":
                            this.ToolBarToolVer();
                            break;
                        case "OrbModificar":
                            this.ToolBarToolModificar();
                            break;
                        case "OrbAñadir":
                            this.ToolBarToolAñadir();
                            break;
                        case "OrbEliminar":
                            this.ToolBarToolEliminar();
                            break;
                        case "OrbDeshacer":
                            this.ToolBarToolEditarDeshacer();
                            break;
                        case "OrbRehacer":
                            this.ToolBarToolEditarRehacer();
                            break;
                        case "OrbCortar":
                            this.ToolBarToolEditarCortar();
                            break;
                        case "OrbCopiar":
                            this.ToolBarToolEditarCopiar();
                            break;
                        case "OrbPegar":
                            this.ToolBarToolEditarPegar();
                            break;
                        case "OrbExportarExcel":
                            this.ToolBarToolExportarExcel(e);
                            break;
                        case "OrbPersonalizar":
                            this.ToolBarToolPersonalizar();
                            break;
                        case "OrbGuardarPlantilla":
                        case "OrbGuardarPlantillaComo":
                            this.ToolBarToolGuardarPlantilla(e.Tool.Key as object);
                            break;
                        case "OrbPublicarPlantilla":
                            this.ToolBarToolPublicarPlantilla();
                            break;
                        case "OrbImportarPlantillas":
                            this.ToolBarToolImportarPlantillas();
                            break;
                        case "OrbEliminarPlantillasLocales":
                            this.ToolBarToolEliminarPlantillasLocales();
                            break;
                        case "OrbEliminarPlantillasPublicas":
                            this.ToolBarToolEliminarPlantillasPublicas();
                            break;
                        case "OrbImprimir":
                            this.ToolBarToolImprimir();
                            break;
                        case "OrbRefrescar":
                            this.ToolBarToolRefrescar();
                            break;
                        case "OrbLimpiarFiltros":
                            this.ToolBarToolLimpiarFiltros();
                            break;
                        case "OrbIrPrimero":
                            this.ToolBarToolIrPrimero();
                            break;
                        case "OrbIrAnterior":
                            this.ToolBarToolIrAnterior();
                            break;
                        case "OrbIrSiguiente":
                            this.ToolBarToolIrSiguiente();
                            break;
                        case "OrbIrUltimo":
                            this.ToolBarToolIrUltimo();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), "ExcepcionOrbitaGridPro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            }
        }
        /// <summary>
        /// BeforeToolDropdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolBar_BeforeToolDropdown(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e)
        {
            switch ((Tools)System.Enum.Parse(typeof(Tools), e.Tool.Key))
            {
                case Tools.OrbEditar:
                    ToolBarActualizarEstadoToolsEditar();
                    break;
                case Tools.OrbEstilo:
                    ToolBarActualizarEstadoToolsEstilo();
                    break;
            }
        }
        /// <summary>
        /// Controla la pulsación de teclas de acceso rápido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolBar_BeforeShortcutKeyProcessed(object sender, Infragistics.Win.UltraWinToolbars.BeforeShortcutKeyProcessedEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #endregion
    }
}