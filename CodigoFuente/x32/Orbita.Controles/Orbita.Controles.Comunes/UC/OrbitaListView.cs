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
    public partial class OrbitaListView : System.Windows.Forms.ListView
    {
        #region Atributos privados
        /// <summary>
        /// Colección de todos los encabezados de columna que aparecen en el control.
        /// </summary>
        OColumnHeaderCollection columnaHeadersEx;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaListView.
        /// </summary>
        public OrbitaListView()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene la colección de todos los encabezados de columna que aparecen en el control.
        /// </summary>
        public OColumnHeaderCollection Columnas
        {
            get { return this.columnaHeadersEx; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// ContextMenuPopup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ContextMenuPopup(object sender, System.EventArgs e) { }
        /// <summary>
        /// Inicializar atributos.
        /// </summary>
        void InitializeAttributes()
        {
            // Crear una nueva colección que contenga las columnas.
            this.columnaHeadersEx = new OColumnHeaderCollection(this);
            // Crear un menu de contexto.
            base.ContextMenu = new System.Windows.Forms.ContextMenu();
            base.ContextMenu.MenuItems.Add(this.columnaHeadersEx.ContextMenu);
            base.ContextMenu.Popup += new System.EventHandler(ContextMenuPopup);
            // Modificar la vista.
            base.View = System.Windows.Forms.View.Details;
        }
        #endregion
    }
}