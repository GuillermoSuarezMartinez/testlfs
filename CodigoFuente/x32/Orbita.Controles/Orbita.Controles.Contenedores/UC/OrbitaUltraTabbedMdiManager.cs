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
namespace Orbita.Controles.Contenedores
{
    public partial class OrbitaUltraTabbedMdiManager : Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OUltraTabbedMdiManager
        {
            public ControlNuevaDefinicion(OrbitaUltraTabbedMdiManager sender)
                : base(sender) { }
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaTableLayoutPanel.
        public OrbitaUltraTabbedMdiManager()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeResourceStrings();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaUltraTabbedMdiManager.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaUltraTabbedMdiManager(System.ComponentModel.IContainer contenedor)
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
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// Inicializar recursos.
        /// </summary>
        static void InitializeResourceStrings()
        {
            Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinTabbedMdi.Resources.Customizer;
            resCustomizer.SetCustomizedString("MenuItemCancel", "C&ancelar");
            resCustomizer.SetCustomizedString("MenuItemClose", "&Cerrar");
            resCustomizer.SetCustomizedString("MenuItemMaximize", "&Maximizar");
            resCustomizer.SetCustomizedString("MenuItemMoveToNextGroup", "Mover a la siguiente pestaña");
            resCustomizer.SetCustomizedString("MenuItemMoveToPreviousGroup", "Mover a la pestaña anterior");
            resCustomizer.SetCustomizedString("MenuItemNewHorizontalGroup", "Nuevo grupo de pestañas horizontal");
            resCustomizer.SetCustomizedString("MenuItemNewVerticalGroup", "Nuevo grupo de pestañas vertical");
            Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.Resources.Customizer;
            rc.SetCustomizedString("TabManagerScrollNext", "Siguiente");
            rc.SetCustomizedString("TabManagerScrollPrevious", "Anterior");
            rc.SetCustomizedString("TabManagerCloseButton", "Cerrar");
        }
        #endregion
    }
}