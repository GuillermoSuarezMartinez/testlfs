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
    public partial class OrbitaToolTip : System.Windows.Forms.ToolTip
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OToolTip
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaToolTip.ControlNuevaDefinicion.
            /// </summary>
            /// <param name="sender">Representa un control para mostrar una lista de elementos.</param>
            public ControlNuevaDefinicion(OrbitaToolTip sender)
                : base(sender) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaToolTip.
        /// </summary>
        public OrbitaToolTip()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaToolTip.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaToolTip(System.ComponentModel.IContainer contenedor)
            : base(contenedor)
        {
            if (contenedor == null)
            {
                return;
            }
            contenedor.Add(this);
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
            // Obtiene o establece un valor que indica si la ventana de información sobre
            // herramientas se muestra aunque el control primario no esté activo.
            this.ShowAlways = true;
        }
        #endregion
    }
}