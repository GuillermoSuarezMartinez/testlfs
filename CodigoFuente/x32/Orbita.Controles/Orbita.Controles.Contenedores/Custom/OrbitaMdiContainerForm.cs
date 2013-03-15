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
    public partial class OrbitaMdiContainerForm : System.Windows.Forms.Form
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OMdiContainerForm
        {
            public ControlNuevaDefinicion(OrbitaMdiContainerForm sender)
                : base(sender) { }
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OrbitaMdiParentForm.
        /// </summary>
        public OrbitaMdiContainerForm()
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
        public ControlNuevaDefinicion OI
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
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        void InitializeProperties()
        {
            this.toolTip.Active = Configuracion.DefectoVerToolTips;
            this.OI.NumeroMaximoFormulariosAbiertos = Configuracion.DefectoNumeroMaximoFormulariosAbiertos;
        }
        #endregion
    }
}