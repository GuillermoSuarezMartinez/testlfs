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
    /// This class Represents the collection of Orbita.Controles.Comunes.OrbitaColumnHeader in a Orbita.Controles.Comunes.ListView control.
    /// This class stores the column headers that are displayed in the Orbita.Controles.Comunes.OrbitaListView control when the View 
    /// property is set to View.Details. 
    /// This class stores Orbita.Controles.Comunes.OrbitaColumnHeader objects that define the text to display for a column as well as 
    /// how the column header is displayed in the ListViewEx control when displaying columns.
    /// When a Orbita.Controles.Comunes.OrbitaListView displays columns, the items and their subitems are displayed in their own columns. 
    /// </summary>
    public class OColumnHeaderCollection : System.Windows.Forms.ListView.ColumnHeaderCollection, System.IDisposable, System.Collections.ICollection
    {
        #region Atributos privados
        /// <summary>
        /// This is to maintain the list of columns added to the ListViewEx control, this will contain both visible and hidden columns.
        /// </summary>
        System.Collections.SortedList listaOrdenada = new System.Collections.SortedList();
        ///// <summary>
        ///// MenuItem which contains all columns menuitem as Subitems. This menuitem can be used to add to the 
        ///// context menu, which inturn can be used to Hide/Show the columns.
        ///// </summary>
        //System.Windows.Forms.MenuItem contextMenu = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// You cannot create an instance of this class 
        /// without associating it with a ListView control.
        /// </summary>
        /// <param name="owner"></param>
        public OColumnHeaderCollection(System.Windows.Forms.ListView owner)
            : base(owner)
        {
            // Create a menu item to add submenus for each column added
            //this.contextMenu = new System.Windows.Forms.MenuItem("Columnas");
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Indica si ya se llamo al método Dispose. (Default = false)
        /// </summary>
        bool disposed = false;
        /// <summary>
        /// Implementa IDisposable.
        /// No  hacer  este  método  virtual.
        /// Una clase derivada no debería ser
        /// capaz de  reemplazar este método.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que  contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
            // Este objeto será limpiado por el método Dispose.
            // Llama al método del recolector de basura, GC.SuppressFinalize.
            System.GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método  sobrecargado de  Dispose que será  el que
        /// libera los recursos. Controla que solo se ejecute
        /// dicha lógica una  vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name="disposing">Indica si llama al método Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Llamar a dispose de todos los recursos manejados.
                    // this.contextMenu.Dispose();
                }
                // Liberar recursos nativos.
                this.listaOrdenada = null;
                disposed = true;
            }
        }
        /// <summary>
        /// Destructor(es) de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta 
        /// la lógica anterior para liberar los recursos.
        /// </summary>
        ~OColumnHeaderCollection()
        {
            // Llamar a Dispose(false) es óptimo en terminos de legibilidad y mantenimiento.
            Dispose(false);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Indexer to get columns by index
        /// </summary>
        public new OColumnHeader this[int index]
        {
            get { return (OColumnHeader)this.listaOrdenada.GetByIndex(index); }
        }
        ///// MenuItem which contains all columns menuitem as
        ///// Subitems. This menuitem can be used to add to the 
        ///// context menu, which inturn can be used to
        ///// Hide/Show the columns.
        //public System.Windows.Forms.MenuItem ContextMenu
        //{
        //    get { return this.contextMenu; }
        //}
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Method adds a single column header to the collection.
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="width">Width of column</param>
        /// <param name="textAlign">Alignment</param>
        /// <returns>new ColumnHeaderEx added</returns>
        public override System.Windows.Forms.ColumnHeader Add(string text, int width, System.Windows.Forms.HorizontalAlignment textAlign)
        {
            OColumnHeader columna = new OColumnHeader(text, width, textAlign);
            this.Add(columna);
            return columna;
        }
        /// <summary>
        /// Method adds a single column header to the collection.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The zero-based index into the collection 
        /// where the item was added.</returns>
        public override int Add(System.Windows.Forms.ColumnHeader value)
        {
            return this.Add(new OColumnHeader(value));
        }
        /// <summary>
        /// Adds an array of column headers to the collection.
        /// </summary>
        /// <param name="values">An array of ColumnHeader 
        /// objects to add to the collection. </param>
        public override void AddRange(System.Windows.Forms.ColumnHeader[] values)
        {
            if (values != null)
            {
                // Add range of column headers
                for (int index = 0; index < values.Length; index++)
                {
                    this.Add(new OColumnHeader(values[index]));
                }
            }
        }
        /// <summary>
        /// Adds an existing ColumnHeader to the collection.
        /// </summary>
        /// <param name="columna">The ColumnHeader to 
        /// add to the collection. </param>
        /// <returns>The zero-based index into the collection 
        /// where the item was added.</returns>
        public int Add(OColumnHeader columna)
        {
            if (columna == null) return 0;

            // Add the column to the base
            int retValue = base.Add(columna);
            // Keep a refrence in columnList
            listaOrdenada.Add(columna.Identificador, columna);
            // Add the its menu to main menu
            //ContextMenu.MenuItems.Add(columna.ColumnMenuItem);
            // Subscribe to the visiblity change event of the column
            columna.VisibleChanged += new System.EventHandler(ColumnVisibleChanged);
            return retValue;
        }
        /// <summary>
        /// Removes the specified column header from the collection.
        /// </summary>
        /// <param name="columna">A ColumnHeader representing the 
        /// column header to remove from the collection.</param>
        public new void Remove(System.Windows.Forms.ColumnHeader columna)
        {
            // Remove from base
            base.Remove(columna);
            OColumnHeader columnaExtendida = (OColumnHeader)columna;
            // Remove the reference in columnList
            listaOrdenada.Remove(columnaExtendida.Identificador);
            // remove the menu item associated with it
            // ContextMenu.MenuItems.Remove(columnaExtendida.ColumnMenuItem);
        }
        /// <summary>
        /// Removes the column header at the specified index within the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the 
        /// column header to remove</param>
        public new void RemoveAt(int index)
        {
            System.Windows.Forms.ColumnHeader columna = this[index];
            this.Remove(columna);
        }
        /// <summary>
        /// Removes all column headers from the collection.
        /// </summary>
        public new void Clear()
        {
            // Clear all columns in base.
            base.Clear();
            // Remove all references.
            listaOrdenada.Clear();
            // Clear all menu items.
            //ContextMenu.MenuItems.Clear();
        }
        // Provide the strongly typed member for ICollection. 
        public void CopyTo(System.Exception[] array, int index)
        {
            ((System.Collections.ICollection)this).CopyTo(array, index);
        }
        /// <summary>
        /// The IEnumerable interface is implemented by ICollection. 
        /// Because the type underlying this collection is a reference type, 
        /// you do not need a strongly typed version of GetEnumerator. 
        /// </summary>
        /// <returns>System.Collections.IEnumerator</returns>
        public new System.Collections.IEnumerator GetEnumerator()
        {
            return this.listaOrdenada.GetEnumerator();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// This method is used to find the first visible column
        /// which is present in front of the column specified
        /// </summary>
        /// <param name="columna">refrence columns for search</param>
        /// <returns>null if no visible colums are in front of
        /// the column specified, else previous columns returned</returns>
        OColumnHeader FindPreviousVisibleColumn(OColumnHeader columna)
        {
            // Get the position of the search column
            int index = listaOrdenada.IndexOfKey(columna.Identificador);
            if (index > 0)
            {
                // Start a recursive search for a visible column
                OColumnHeader prevColumn = (OColumnHeader)listaOrdenada.GetByIndex(index - 1);
                if ((prevColumn != null) && (prevColumn.Visible == false))
                {
                    prevColumn = FindPreviousVisibleColumn(prevColumn);
                }
                return prevColumn;
            }
            // No visible columns found in font of specified column
            return null;
        }
        /// <summary>
        /// Handler to handel the visiblity change of columns
        /// </summary>
        /// <param name="sender">ColumnHeaderEx</param>
        /// <param name="e"></param>
        void ColumnVisibleChanged(object sender, System.EventArgs e)
        {
            OColumnHeader columna = (OColumnHeader)sender;
            if (columna.Visible == true)
            {
                // Show the hidden column
                // Get the position where the hidden column has to be shown
                OColumnHeader prevHeader = FindPreviousVisibleColumn(columna);
                if (prevHeader == null)
                {
                    // This is the first column, so add it at 0 location
                    base.Insert(0, columna);
                }
                else
                {
                    // Got the location, place it their.
                    base.Insert(prevHeader.Index + 1, columna);
                }
            }
            else
            {
                // Hide the column.
                // Remove it from the base, dont worry we have the 
                // refrence in columnList to get it back
                base.Remove(columna);
            }
        }
        #endregion
    }
}