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
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaUltraButton : Infragistics.Win.Misc.UltraButton
    {
        #region Nueva definici�n
        public class ControlNuevaDefinicion : OUltraButton
        {
            #region Constructor
            public ControlNuevaDefinicion(OrbitaUltraButton sender)
                : base(sender) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraButton.
        /// </summary>
        public OrbitaUltraButton()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gesti�n de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
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
        #endregion
    }
}