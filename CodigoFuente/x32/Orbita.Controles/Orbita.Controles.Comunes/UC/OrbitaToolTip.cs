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
using System.ComponentModel;
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaToolTip : System.Windows.Forms.ToolTip
    {
        public class ControlNuevaDefinicion : OToolTip
        {
            public ControlNuevaDefinicion(OrbitaToolTip sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraLabel.
        /// </summary>
        public OrbitaToolTip()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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