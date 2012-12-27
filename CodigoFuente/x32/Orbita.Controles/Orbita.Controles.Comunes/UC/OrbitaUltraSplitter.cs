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
    /// Orbita.Controles.Comunes.OrbitaUltraSplitter.
    /// </summary>
    public partial class OrbitaUltraSplitter : Infragistics.Win.Misc.UltraSplitter
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraSplitter.
        /// </summary>
        public OrbitaUltraSplitter()
            : base()
        {
            InitializeComponent();
            InitializeProperties();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InitializeProperties()
        {
            this.Appearance.BackColor = this.Appearance.BackColor2 = System.Drawing.SystemColors.Control;
        }
        #endregion
    }
}
