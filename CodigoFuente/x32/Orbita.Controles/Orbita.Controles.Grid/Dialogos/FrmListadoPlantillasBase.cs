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
namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.DialogoListView.
    /// </summary>
    public partial class FrmListadoPlantillasBase : Orbita.Controles.Contenedores.OrbitaDialog
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.DialogoListView.
        /// </summary>
        public FrmListadoPlantillasBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// OrbitaUltraLabel.
        /// </summary>
        public Orbita.Controles.Comunes.OrbitaUltraLabel Cabecera
        {
            get { return this.lblCabecera; }
        }
        /// <summary>
        /// OrbitaListView.
        /// </summary>
        public Orbita.Controles.Comunes.OrbitaListView Lista
        {
            get { return this.lstView; }
        }
        /// <summary>
        /// OrbitaUltraLabel.
        /// </summary>
        public Orbita.Controles.Comunes.OrbitaUltraLabel SinElementos
        {
            get { return this.lblSinElementos; }
        }
        #endregion
    }
}
