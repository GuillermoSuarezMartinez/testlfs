//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Esta clase de objeto representa un encabezado de columna en un control Orbita.Controles.Comunes.OrbitaListView.
    /// Esta clase se extiende de Orbita.Controles.Comunes.OrbitaColumnHeader, a fin de apoyar ocultación de la columna.
    /// </summary>
    public class OColumnHeader : System.Windows.Forms.ColumnHeader
    {
        #region Atributos privados
        System.Windows.Forms.MenuItem item = null;
        bool columnaVisible = true;
        int identificador = 0;
        #endregion

        #region Atributos privados estáticos
        static int autoColumnaId = 0;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor.
        /// </summary>
        public OColumnHeader()
            : this("", 0, System.Windows.Forms.HorizontalAlignment.Left) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="str">Texto a visualizar.</param>
        /// <param name="width">Ancho de columna.</param>
        /// <param name="textAlign">Alineación.</param>
        public OColumnHeader(string str, int width, System.Windows.Forms.HorizontalAlignment textAlign)
            : base()
        {
            Initialize(str, width, textAlign);
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columna">Columna.</param>
        public OColumnHeader(System.Windows.Forms.ColumnHeader columna)
            : base()
        {
            if (columna != null)
            {
                Initialize(columna.Text, columna.Width, columna.TextAlign);
            }
        }
        #endregion

        #region Eventos públicos
        /// <summary>
        /// This event is raised when the visibility of column
        /// is changed.
        /// </summary>
        public event System.EventHandler VisibleChanged;
        #endregion

        #region Propiedades
        /// <summary>
        /// A unique identifier for a column.
        /// </summary>
        public int Identificador
        {
            get { return this.identificador; }
        }
        /// <summary>
        /// Property to change the visibility of the column.
        /// </summary>
        public bool Visible
        {
            get { return this.columnaVisible; }
            set { ShowColumn(value); }
        }
        /// <summary>
        /// Menu item which represents the column.
        /// This menuitem can be used to add to the 
        /// context menu, which can inturn used to
        /// Hide/Show the column
        /// </summary>
        public System.Windows.Forms.MenuItem ColumnMenuItem
        {
            get { return this.item; }
        }
        /// <summary>
        /// Column Text to be displayed.
        /// </summary>
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                // Ensure that menu name is same as column name.
                item.Text = value;
            }
        }
        /// <summary>
        /// Gets the ListViewEx control the ColumnHeader is located in.
        /// </summary>
        public new Orbita.Controles.Comunes.OrbitaListView ListView
        {
            get { return (Orbita.Controles.Comunes.OrbitaListView)base.ListView; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Column Initialization.
        /// </summary>
        /// <param name="str">Text to display</param>
        /// <param name="width">Width of column</param>
        /// <param name="textAlign">Alignment</param>
        void Initialize(string str, int width, System.Windows.Forms.HorizontalAlignment textAlign)
        {
            base.Text = str;
            base.Width = width;
            base.TextAlign = textAlign;
            this.identificador = autoColumnaId++;

            // Create the menu item associated with this column
            item = new System.Windows.Forms.MenuItem(Text, new System.EventHandler(this.MenuItemClick));
            item.Checked = true;
        }
        /// <summary>
        /// Method to show/hide column.
        /// </summary>
        /// <param name="visible">visibility</param>
        void ShowColumn(bool visible)
        {
            if (columnaVisible != visible)
            {
                columnaVisible = visible;
                item.Checked = visible;
                if (VisibleChanged != null)
                {
                    VisibleChanged(this, System.EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Handler to handel toggel of menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuItemClick(System.Object sender, System.EventArgs e)
        {
            System.Windows.Forms.MenuItem itemMenu = (System.Windows.Forms.MenuItem)sender;
            // Ensure Column is hidden/shown accordingly.
            ShowColumn(!itemMenu.Checked);
        }
        #endregion
    }
}