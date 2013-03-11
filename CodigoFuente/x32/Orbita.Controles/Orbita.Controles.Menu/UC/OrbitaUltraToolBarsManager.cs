//***********************************************************************
// Assembly         : Orbita.Controles.Contenedores
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
namespace Orbita.Controles.Menu
{
    public partial class OrbitaUltraToolbarsManager : Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    {
        public class ControlNuevaDefinicion : OUltraToolbarsManager
        {
            public ControlNuevaDefinicion(OrbitaUltraToolbarsManager sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OrbitaUltraToolbarsManager.
        /// </summary>
        public OrbitaUltraToolbarsManager()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeResourceStrings();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OrbitaUltraToolbarsManager.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaUltraToolbarsManager(System.ComponentModel.IContainer contenedor)
            : base(contenedor)
        {
            if (contenedor == null)
            {
                return;
            }
            contenedor.Add(this);
            InitializeComponent();
            InitializeAttributes();
            InitializeResourceStrings();
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
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// InitializeResourceStrings.
        /// </summary>
        static void InitializeResourceStrings()
        {
            Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
            resCustomizer.SetCustomizedString("MdiCommandArrangeIcons", "Organizar iconos");
            resCustomizer.SetCustomizedString("MdiCommandCascade", "Mostrar ventanas en cascada");
            resCustomizer.SetCustomizedString("MdiCommandCloseWindows", "Cerrar todas las ventanas");
            resCustomizer.SetCustomizedString("MdiCommandTileHorizontal", "Pestañas horizontal");
            resCustomizer.SetCustomizedString("MdiCommandTileVertical", "Pestañas vertical");
            resCustomizer.SetCustomizedString("MdiCommandMinimizeWindows", "Minimizar todas las ventanas");
        }
        #endregion
    }
}