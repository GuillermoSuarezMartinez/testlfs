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
using System;
namespace Orbita.Controles.Comunes
{
    public partial class OrbitaUltraMaskedEdit : Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    {
        public class ControlNuevaDefinicion : OUltraMaskedEdit
        {
            public ControlNuevaDefinicion(OrbitaUltraMaskedEdit sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Eventos
        public new event EventHandler Enter;
        public new event EventHandler Click;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaListBox.
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
        void InitializeEvents()
        {
            this.Enter += new System.EventHandler(ControlEnter);
            this.Click += new System.EventHandler(ControlClick);
        }
        #endregion

        #region Manejadores de eventos
        private void ControlEnter(object sender, EventArgs e)
        {
            try
            {
                this.SelectAll();
                if (this.Enter != null)
                {
                    this.Enter(sender, e);
                }
            }
            catch (Exception)
            {
            }
        }
        private void ControlClick(object sender, EventArgs e)
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
            catch (Exception)
            {
            }
        }
        #endregion
    }
}