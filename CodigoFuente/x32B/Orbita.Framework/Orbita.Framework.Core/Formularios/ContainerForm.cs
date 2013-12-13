//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Clase base contenedor de formularios.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public partial class ContainerForm : Controles.Contenedores.OrbitaMdiContainerForm
    {
        #region Atributos
        private OIContainerForm definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.ContainerForm.
        /// </summary>
        public ContainerForm()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de definición de Órbita Ingeniería.
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public new OIContainerForm OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar atributos.
        /// </summary>
        private void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new OIContainerForm(this);
            }
        }
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        private void InitializeProperties()
        {
            this.OI.Autenticación = ConfiguracionEntorno.DefectoAutenticación;
            this.OI.NumeroMaximoFormulariosAbiertos = ConfiguracionEntorno.DefectoNumeroMaximoFormulariosAbiertos;
        }
        #endregion
    }
}