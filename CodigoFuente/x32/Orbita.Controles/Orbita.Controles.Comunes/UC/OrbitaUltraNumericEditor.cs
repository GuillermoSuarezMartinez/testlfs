//***********************************************************************
// Assembly         : Orbita.Controles
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
    /// Orbita.Controles.Comunes.OrbitaUltraNumbericEditor.
    /// </summary>
    public partial class OrbitaUltraNumbericEditor : Infragistics.Win.UltraWinEditors.UltraNumericEditor
    {
		#region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraNumbericEditor.
        /// </summary>
		public OrbitaUltraNumbericEditor()
            : base()
        {
            InitializeComponent();
            InicializeProperties();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InicializeProperties()
        {
            this.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
        }
        #endregion
    }
}
