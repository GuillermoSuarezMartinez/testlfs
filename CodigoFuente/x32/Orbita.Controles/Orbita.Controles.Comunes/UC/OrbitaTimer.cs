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
    public partial class OrbitaTimer : System.Windows.Forms.Timer
    {
        public class ControlNuevaDefinicion : OTimer
        {
            public ControlNuevaDefinicion(OrbitaTimer sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaListBox.
        /// </summary>
        public OrbitaTimer()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaTimer(System.ComponentModel.IContainer contenedor)
            : base(contenedor)
        {
            if (contenedor == null)
            {
                return;
            }
            contenedor.Add(this);
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