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
    public partial class OrbitaUltraGroupBox : Infragistics.Win.Misc.UltraGroupBox
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaUltraGroupBox.
        /// </summary>
        public OrbitaUltraGroupBox()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Color del borde.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color del borde.")]
        public System.Drawing.Color OrbColorBorde
        {
            get { return this.ContentAreaAppearance.BorderColor; }
            set { this.ContentAreaAppearance.BorderColor = value; }
        }
        /// <summary>
        /// Color de la cabecera.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color de la cabecera.")]
        public System.Drawing.Color OrbColorCabecera
        {
            get { return this.HeaderAppearance.ForeColor; }
            set { this.HeaderAppearance.ForeColor = value; }
        }
        #endregion
    }
}