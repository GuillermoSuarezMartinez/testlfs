﻿//***********************************************************************
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
    public partial class OrbitaUltraNumericEditor : Infragistics.Win.UltraWinEditors.UltraNumericEditor
    {
        public class ControlNuevaDefinicion : OUltraNumericEditor
        {
            public ControlNuevaDefinicion(OrbitaUltraNumericEditor sender)
                : base(sender) { }
        };

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraNumbericEditor.
        /// </summary>
        public OrbitaUltraNumericEditor()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
            InicializeProperties();
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
        /// <summary>
        /// Inicializar propiedades.
        /// </summary>
        void InicializeProperties()
        {
            this.PromptChar = char.MinValue;
        }
        #endregion
    }
}