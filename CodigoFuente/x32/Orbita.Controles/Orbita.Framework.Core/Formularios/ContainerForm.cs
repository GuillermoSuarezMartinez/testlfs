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
    [System.CLSCompliantAttribute(false)]
    public partial class ContainerForm : Orbita.Controles.Contenedores.OrbitaMdiContainerForm
    {
        #region Atributos
        OIContainerForm definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Base.
        /// </summary>
        public ContainerForm()
            : base()
        {
            // Inicializar componentes.
            InitializeComponent();
            // Inicializar atributos.
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
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new OIContainerForm();
            }
        }
        void InitializeProperties()
        {
            this.OI.NumeroMaximoFormulariosAbiertos = ConfiguracionEntorno.DefectoNumeroMaximoFormulariosAbiertos;
        }
        #endregion
    }
}