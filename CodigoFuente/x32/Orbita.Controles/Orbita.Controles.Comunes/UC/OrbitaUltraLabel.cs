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
    /// Orbita.Controles.Comunes.OrbitaUltraLabel.
    /// </summary>
    public partial class OrbitaUltraLabel : Infragistics.Win.Misc.UltraLabel
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraLabel.
        /// </summary>
        public OrbitaUltraLabel()
            : base()
        {
            InitializeComponent();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Color del fondo.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color de fondo.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), "Empty")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbColorFondo
        {
            get { return this.Appearance.BackColor; }
            set { this.Appearance.BackColor = value; }
        }
        /// <summary>
        /// Color de la fuente.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Color de la fuente.")]
        [System.ComponentModel.DefaultValue(typeof(System.Drawing.Color), "Empty")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public System.Drawing.Color OrbColorFuente
        {
            get { return this.Appearance.ForeColor; }
            set { this.Appearance.ForeColor = value; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InitializeProperties()
        {
            this.OrbColorFondo = System.Drawing.Color.Empty;
            this.OrbColorFuente = System.Drawing.Color.Empty;
            this.UseMnemonic = false;
        }        
        #endregion
    }
}