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
namespace Orbita.Framework
{
    [System.CLSCompliantAttribute(false)]
    public partial class Base : Orbita.Controles.Contenedores.OrbitaMdiContainerForm
    {
        #region Atributos
        OBase definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Base.
        /// </summary>
        public Base()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public new OBase OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new OBase(this);
            }
        }
        void InitializeProperties()
        {
            this.OI.MostrarMenu = Configuracion.DefectoMostrarMenu;
            this.OI.NumeroMaximoFormulariosAbiertos = Configuracion.DefectoNumeroMaximoFormulariosAbiertos;
            this.OI.Plugin = Configuracion.DefectoPlugin;
            this.OI.Autenticación = Configuracion.DefectoAutenticación;
            this.OI.Idioma = Configuracion.DefectoIdioma;
        }
        #endregion
    }
}