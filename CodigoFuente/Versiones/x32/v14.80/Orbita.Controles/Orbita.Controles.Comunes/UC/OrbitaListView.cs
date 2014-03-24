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
    /// Representa un control de vista de lista de Windows, el cual muestra una colección
    /// de elementos que se pueden ver mediante una de cuatro vistas distintas.
    /// </summary>
    public partial class OrbitaListView : System.Windows.Forms.ListView
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OListView
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaListView.ControlNuevaDefinicion.
            /// </summary>
            /// <param name="sender">Representa un control para mostrar una lista de elementos.</param>
            public ControlNuevaDefinicion(OrbitaListView sender)
                : base(sender) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
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
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        void InitializeProperties()
        {
            // Modificar la vista.
            base.View = System.Windows.Forms.View.Details;
            // Crear una nueva colección que contenga las columnas.
            this.OI.Columnas = new OColumnHeaderCollection(this);
        }
        #endregion
    }
}