//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Orbita.Controles.Comunes;
namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.Personalizar.
    /// </summary>
    public partial class FrmPersonalizar : Orbita.Controles.Contenedores.OrbitaDialog
    {
        #region Atributos privados estáticos
        /// <summary>
        /// Grid referencia.
        /// </summary>
        static UltraGrid grid;
        #endregion

        #region Atributos privados
        /// <summary>
        /// Columnas del grid.
        /// </summary>
        List<OColumnaInfo> columnas;
        #endregion

        #region Delegados y eventos
        public event System.EventHandler<System.EventArgs> IndiceSeleccionado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Personalizar.
        /// </summary>
        public FrmPersonalizar(object nodoSeleccionado)
        {
            InitializeComponent();
            FindNodeInHierarchy(this.trvOpciones.Nodes, nodoSeleccionado ?? "1");
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Grid referencia.
        /// </summary>
        public static UltraGrid Grid
        {
            get { return FrmPersonalizar.grid; }
            set { FrmPersonalizar.grid = value; }
        }
        #endregion

        #region Métodos privados
        void AsignarEventosUI()
        {
            this.chbEntornoFilasVacias.CheckedChanged += new System.EventHandler(chbEntornoFilasVacias_CheckedChanged);

            this.chbFilasAutoajuste.CheckedChanged += new System.EventHandler(chbFilasAutoajuste_CheckedChanged);
            this.chbFilasSelector.CheckedChanged += new System.EventHandler(chbFilasSelector_CheckedChanged);
            this.chbFilasFijas.CheckedChanged += new System.EventHandler(chbFilasFijas_CheckedChanged);

            this.cboColumnasAutoajustar.SelectedIndexChanged += new System.EventHandler(cboColumnasAutoajustar_SelectedIndexChanged);
            this.chbColumnasFijas.CheckedChanged += new System.EventHandler(chbColumnasFijas_CheckedChanged);
            this.chbColumnasSumarios.CheckedChanged += new System.EventHandler(chbColumnasSumarios_CheckedChanged);
            this.chbColumnasFiltros.CheckedChanged += new System.EventHandler(chbColumnasFiltros_CheckedChanged);
            this.cboColumnasOperadores.SelectedIndexChanged += new System.EventHandler(cboColumnasOperadores_SelectedIndexChanged);

            this.btnSubir.Click += new System.EventHandler(btnSubir_Click);
            this.btnBajar.Click += new System.EventHandler(btnBajar_Click);
            this.lsvColumnas.ItemChecked += new ItemCheckedEventHandler(lsvColumnas_ItemChecked);
            this.lsvColumnasAgrupadas.ItemChecked += new ItemCheckedEventHandler(lsvColumnasAgrupadas_ItemChecked);

            this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
        }
        void AsignarDatosUI()
        {
            this.chbEntornoFilasVacias.Checked = Grid.DisplayLayout.EmptyRowSettings.ShowEmptyRows;

            this.chbFilasAutoajuste.Checked = Grid.DisplayLayout.Override.RowSizing == RowSizing.AutoFree;
            this.chbFilasSelector.Checked = Grid.DisplayLayout.Override.RowSelectors == DefaultableBoolean.True;
            this.chbFilasFijas.Checked = Grid.DisplayLayout.Override.FixedRowIndicator == FixedRowIndicator.Button;

            this.cboColumnasAutoajustar.SelectedIndex = ((int)System.Enum.Parse(typeof(AutoFitStyle), Grid.DisplayLayout.AutoFitStyle.ToString()));
            this.chbColumnasFijas.Checked = Grid.DisplayLayout.UseFixedHeaders;
            this.chbColumnasSumarios.Checked = Grid.DisplayLayout.Override.AllowRowSummaries == AllowRowSummaries.True;
            this.chbColumnasFiltros.Checked = Grid.DisplayLayout.Override.FilterUIType == Infragistics.Win.UltraWinGrid.FilterUIType.HeaderIcons;
            int indice = ((int)System.Enum.Parse(typeof(FilterOperatorLocation), Grid.DisplayLayout.Override.FilterOperatorLocation.ToString()));
            if (indice == 0)
            {
                indice++;
            }
            else
            {
                indice--;
            }
            this.cboColumnasOperadores.SelectedIndex = indice;
        }
        void AsignarColumnas()
        {
            foreach (var item in Grid.DisplayLayout.Bands)
            {
                columnas = new List<OColumnaInfo>(item.Columns.Count);
                this.lsvColumnas.OI.Columnas.Add(new Orbita.Controles.Comunes.OColumnHeader("Columna", 200, System.Windows.Forms.HorizontalAlignment.Left));
                this.lsvColumnasAgrupadas.OI.Columnas.Add(new Orbita.Controles.Comunes.OColumnHeader("Columna", 200, System.Windows.Forms.HorizontalAlignment.Left));
                foreach (var columnaGrid in item.Columns)
                {
                    //if (columnaGrid.Tag != null)
                    //{
                    OColumnaInfo columna = new OColumnaInfo();
                    columna.Identificador = columnaGrid.Key;
                    columna.Nombre = columnaGrid.Header.Caption;
                    columna.Posicion = columnaGrid.Header.VisiblePosition;
                    columna.Banda = item.Index;
                    columna.Visible = !columnaGrid.Hidden;
                    columna.Agrupada = columnaGrid.MergedCellStyle == MergedCellStyle.Always;
                    columnas.Add(columna);
                    //  }
                }
                columnas.Sort();
                foreach (OColumnaInfo columnaListView in columnas)
                {
                    System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem();
                    lvi.Name = "Columna";
                    lvi.Text = columnaListView.Nombre;
                    lvi.Checked = columnaListView.Visible;
                    this.lsvColumnas.Items.Add(lvi);

                    System.Windows.Forms.ListViewItem lviGroup = new System.Windows.Forms.ListViewItem();
                    lviGroup.Name = lvi.Name;
                    lviGroup.Text = lvi.Text;
                    lviGroup.Checked = columnaListView.Agrupada;
                    this.lsvColumnasAgrupadas.Items.Add(lviGroup);
                }
            }
        }
        void MoveListViewItem(Orbita.Controles.Comunes.OrbitaListView lv, bool moveUp)
        {
            if (lv.SelectedItems.Count == 0)
            {
                return;
            }
            // Columna anterior;
            OColumnaInfo cache;
            // Indice del item seleccionado.
            int selIdx = lv.SelectedItems[0].Index;
            // Posición anterior.
            int posicion;
            // Item seleccionado.
            System.Windows.Forms.ListViewItem item = null;
            if (moveUp)
            {
                // Ignorar el movimiento a la fila (0).
                if (selIdx == 0)
                {
                    return;
                }
                cache = columnas[selIdx - 1];
                columnas[selIdx - 1] = columnas[selIdx];
                columnas[selIdx] = cache;

                posicion = columnas[selIdx - 1].Posicion;
                columnas[selIdx - 1].Posicion = columnas[selIdx].Posicion;
                columnas[selIdx].Posicion = posicion;

                lv.Items[selIdx - 1].SubItems[0].Text = columnas[selIdx - 1].Nombre;
                lv.Items[selIdx - 1].Checked = columnas[selIdx - 1].Visible;
                lv.Items[selIdx].SubItems[0].Text = columnas[selIdx].Nombre;
                lv.Items[selIdx].Checked = columnas[selIdx].Visible;

                item = lv.Items[selIdx - 1];
            }
            else
            {
                // Ignorar el movimiento a la última fila.
                if (selIdx == lv.Items.Count - 1)
                {
                    return;
                }
                cache = columnas[selIdx + 1];
                columnas[selIdx + 1] = columnas[selIdx];
                columnas[selIdx] = cache;

                posicion = columnas[selIdx + 1].Posicion;
                columnas[selIdx + 1].Posicion = columnas[selIdx].Posicion;
                columnas[selIdx].Posicion = posicion;

                lv.Items[selIdx + 1].SubItems[0].Text = columnas[selIdx + 1].Nombre;
                lv.Items[selIdx + 1].Checked = columnas[selIdx + 1].Visible;
                lv.Items[selIdx].SubItems[0].Text = columnas[selIdx].Nombre;
                lv.Items[selIdx].Checked = columnas[selIdx].Visible;

                item = lv.Items[selIdx + 1];
            }
            if (item != null)
            {
                item.Selected = true;
                OColumnaInfo columna = columnas[item.Index];
                Grid.DisplayLayout.Bands[columna.Banda].Columns[columna.Identificador].Header.VisiblePosition = columna.Posicion;
            }
        }
        void FindNodeInHierarchy(TreeNodeCollection nodos, object strSearchValue)
        {
            for (int iCount = 0; iCount < nodos.Count; iCount++)
            {
                if (nodos[iCount].Tag.Equals(strSearchValue))
                {
                    this.trvOpciones.SelectedNode = nodos[iCount];
                    this.trvOpciones.Select();
                    return;
                }
                FindNodeInHierarchy(nodos[iCount].Nodes, strSearchValue);
            }
        }
        #endregion

        #region Manejadores de eventos

        void Personalizar_Shown(object sender, System.EventArgs e)
        {
            try
            {
                this.AsignarDatosUI();
                this.AsignarColumnas();
                this.AsignarEventosUI();
            }
            catch
            {
            }
        }
        void trvOpciones_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tabSeleccionado = null;
                object indice = e.Node.Tag ?? 0;
                switch (indice.ToString())
                {
                    case "0":
                    case "1":
                        tabSeleccionado = this.orbitaTabPageControl1.Tab;
                        break;
                    case "2":
                        tabSeleccionado = this.orbitaTabPageControl2.Tab;
                        break;
                    case "3":
                        tabSeleccionado = this.orbitaTabPageControl3.Tab;
                        break;
                    case "4":
                    case "5":
                        tabSeleccionado = this.orbitaTabPageControl4.Tab;
                        break;
                    case "6":
                    case "7":
                        tabSeleccionado = this.orbitaTabPageControl5.Tab;
                        break;
                }
                if (tabSeleccionado != null)
                {
                    tabSeleccionado.Selected = true;
                }
            }
            catch
            {
            }
        }
        void trvOpciones_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                TreeNode tmpnode = trvOpciones.HitTest(e.Location).Node;
                if (tmpnode == null)
                {
                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    if (tmpnode.Bounds.Contains(e.Location))
                    {
                        trvOpciones.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        trvOpciones.Cursor = Cursors.Arrow;
                    }
                }
            }
            catch
            {
            }
        }
        void btnCancelar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (IndiceSeleccionado != null)
                {
                    IndiceSeleccionado(this.trvOpciones, e);
                }
            }
            catch
            {
            }
        }

        #region Entorno
        /// <summary>
        /// Mostrar filas vacías estilo Excel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbEntornoFilasVacias_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                Grid.DisplayLayout.EmptyRowSettings.ShowEmptyRows = chb.Checked;
            }
            catch
            {
            }
        }
        #endregion

        #region Filas
        /// <summary>
        /// Autoajustar filas al contenido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbFilasAutoajuste_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                if (chb.Checked)
                {
                    Grid.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
                    Grid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True;
                    Grid.DisplayLayout.Override.CellDisplayStyle = CellDisplayStyle.FormattedText;
                }
                else
                {
                    Grid.DisplayLayout.Override.RowSizing = RowSizing.Default;
                    Grid.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.Default;
                    Grid.DisplayLayout.Override.CellDisplayStyle = CellDisplayStyle.Default;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Selector de filas que permite multiselección.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbFilasSelector_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                if (chb.Checked)
                {
                    Grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
                }
                else
                {
                    Grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Indicador de filas fijas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbFilasFijas_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                if (chb.Checked)
                {
                    Grid.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.Button;
                }
                else
                {
                    Grid.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.Default;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Columnas
        /// <summary>
        /// Autoajuste de columna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cboColumnasAutoajustar_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                ComboBox combo = (ComboBox)sender;
                AutoFitStyle autoajuste = (AutoFitStyle)combo.SelectedIndex;
                if (System.Enum.IsDefined(typeof(AutoFitStyle), autoajuste))
                {
                    Grid.DisplayLayout.AutoFitStyle = autoajuste;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Indicador de columnas fijas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbColumnasFijas_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                Grid.DisplayLayout.UseFixedHeaders = chb.Checked;
            }
            catch
            {
            }
        }
        /// <summary>
        /// Sumario de columna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbColumnasSumarios_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                if (chb.Checked)
                {
                    Grid.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.True;
                }
                else
                {
                    Grid.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.False;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Filtros en la cabecera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chbColumnasFiltros_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaUltraCheckEditor chb = (OrbitaUltraCheckEditor)sender;
                if (chb.Checked)
                {
                    Grid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.HeaderIcons;
                }
                else
                {
                    Grid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// Operadores de filtro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cboColumnasOperadores_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                Grid.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Default;
                ComboBox combo = (ComboBox)sender;
                FilterOperatorLocation operador = (FilterOperatorLocation)combo.SelectedIndex + 1;
                if (System.Enum.IsDefined(typeof(FilterOperatorLocation), operador))
                {
                    Grid.DisplayLayout.Override.FilterOperatorLocation = operador;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Agregar o quitar columnas
        void btnSubir_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.MoveListViewItem(this.lsvColumnas, true);
            }
            catch
            {
            }
        }
        void btnBajar_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.MoveListViewItem(this.lsvColumnas, false);
            }
            catch
            {
            }
        }
        void lsvColumnas_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                columnas[e.Item.Index].Visible = e.Item.Checked;
                Grid.DisplayLayout.Bands[columnas[e.Item.Index].Banda].Columns[columnas[e.Item.Index].Identificador].Hidden = e.Item.Checked == false;
            }
            catch
            {
            }
        }
        void lsvColumnasAgrupadas_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                columnas[e.Item.Index].Agrupada = e.Item.Checked;
                UltraGridColumn columna = Grid.DisplayLayout.Bands[columnas[e.Item.Index].Banda].Columns[columnas[e.Item.Index].Identificador];
                if (e.Item.Checked)
                {
                    columna.MergedCellStyle = MergedCellStyle.Always;
                    columna.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    columna.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
                }
                else
                {
                    columna.MergedCellStyle = MergedCellStyle.Never;
                    columna.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
                    columna.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Default;
                }
            }
            catch
            {
            }
        }
        void lsvColumnas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                OrbitaListView lsv = (OrbitaListView)sender;
                if (lsv.SelectedItems.Count > 0)
                {
                    int indice = lsv.SelectedItems[0].Index;
                    this.btnSubir.Enabled = indice > 0;
                    this.btnBajar.Enabled = indice < lsv.Items.Count - 1;
                }
                else
                {
                    this.btnSubir.Enabled = false;
                    this.btnBajar.Enabled = false;
                }
            }
            catch
            {
            }
        }
        #endregion

        #endregion
    }
}