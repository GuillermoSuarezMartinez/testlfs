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
namespace Orbita.Controles.Contenedores
{
    public partial class OrbitaUltraTabbedMdiManager : Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaUltraTabbedMdiManager.
        /// </summary>
        public OrbitaUltraTabbedMdiManager()
            : base()
        {
            InitializeComponent();
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
            InitializeResourceStrings();
        }
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// InitializeResourceStrings.
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