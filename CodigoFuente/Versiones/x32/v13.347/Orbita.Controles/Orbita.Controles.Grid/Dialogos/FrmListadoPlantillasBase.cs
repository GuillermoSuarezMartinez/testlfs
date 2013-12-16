//***********************************************************************
// Assembly         : Orbita.Controles.Grid
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
    public partial class FrmListadoPlantillasBase : Orbita.Controles.Contenedores.OrbitaDialog
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.FrmListadoPlantillasBase.
        /// </summary>
        public FrmListadoPlantillasBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Etiqueta cabecera de tipo Orbita.Controles.Comunes.OrbitaUltraLabel.
        /// </summary>
        public Orbita.Controles.Comunes.OrbitaUltraLabel Cabecera
        {
            get { return this.lblCabecera; }
        }
        /// <summary>
        /// Control lista de tipo Orbita.Controles.Comunes.OrbitaListView.
        /// </summary>
        public Orbita.Controles.Comunes.OrbitaListView Lista
        {
            get { return this.lstView; }
        }
        /// <summary>
        /// Etiqueta sin elementos de tipo Orbita.Controles.Comunes.OrbitaUltraLabel.
        /// </summary>
        public Orbita.Controles.Comunes.OrbitaUltraLabel SinElementos
        {
            get { return this.lblSinElementos; }
        }
        #endregion
    }
}