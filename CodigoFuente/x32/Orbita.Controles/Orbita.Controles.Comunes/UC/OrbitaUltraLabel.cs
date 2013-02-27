//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.ComponentModel;
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaUltraLabel : Infragistics.Win.Misc.UltraLabel
    {
        public class ControlNuevaDefinicion : OUltraLabel
        {
            public ControlNuevaDefinicion(OrbitaUltraLabel sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Proporciona un acceso a los recursos espec�ficos de cada referencia cultural en tiempo de ejecuci�n.
        /// </summary>
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraLabel.
        /// </summary>
        public OrbitaUltraLabel()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gesti�n de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion Orbita
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region M�todos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InitializeProperties()
        {
            this.UseMnemonic = false;
        }        
        #endregion
    }
}