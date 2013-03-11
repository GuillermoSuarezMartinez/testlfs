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
using System.ComponentModel;
namespace Orbita.Controles.Menu
{
    public partial class OrbitaMenuStrip : System.Windows.Forms.MenuStrip
    {
        public class ControlNuevaDefinicion : OMenuStrip
        {
            public ControlNuevaDefinicion(OrbitaMenuStrip sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OrbitaMenuStrip.
        /// </summary>
        public OrbitaMenuStrip()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
        #endregion
    }
}