//***********************************************************************
// Assembly         : Orbita.Controles.Shared
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Shared
{
    /// <summary>
    /// Proporciona un control vacío que se puede usar para crear otros controles.
    /// </summary>
    public partial class OrbitaUserControl : System.Windows.Forms.UserControl
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Shared.OrbitaUserControl.
        /// </summary>
        public OrbitaUserControl()
            : base()
        {
            InitializeComponent();
        }
        #endregion
    }
}