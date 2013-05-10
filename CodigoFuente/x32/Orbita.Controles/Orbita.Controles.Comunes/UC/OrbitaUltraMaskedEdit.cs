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
    public partial class OrbitaUltraMaskedEdit : Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OUltraMaskedEdit
        {
            #region Constructor
            public ControlNuevaDefinicion(OrbitaUltraMaskedEdit sender)
                : base(sender) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Eventos
        public new event System.EventHandler Enter;
        public new event System.EventHandler Click;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraMaskedEdit.
        /// </summary>
        public OrbitaUltraMaskedEdit()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeEvents();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraDockManager.
        /// </summary>
        /// <param name="contenedor">Proporciona funcionalidad para contenedores. Los contenedores son objetos
        /// que contienen cero o más componentes de forma lógica.</param>
        public OrbitaUltraMaskedEdit(object owner)
            : base(owner)
        {
            InitializeComponent();
            InitializeAttributes();
            InitializeEvents();
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
        void InitializeEvents()
        {
            this.Enter += new System.EventHandler(ControlEnter);
            this.Click += new System.EventHandler(ControlClick);
        }
        #endregion

        #region Manejadores de eventos
        private void ControlEnter(object sender, System.EventArgs e)
        {
            try
            {
                this.SelectAll();
                if (this.Enter != null)
                {
                    this.Enter(sender, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        private void ControlClick(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Text.Trim()))
                {
                    this.SelectAll();
                }
                if (this.Click != null)
                {
                    this.Click(sender, e);
                }
            }
            catch (System.Exception)
            {
            }
        }
        #endregion
    }
}