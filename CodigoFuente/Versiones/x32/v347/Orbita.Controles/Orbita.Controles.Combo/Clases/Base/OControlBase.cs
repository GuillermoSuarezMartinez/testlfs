﻿//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Orbita.Controles.Grid;
namespace Orbita.Controles.Combo
{
    public abstract class OControlBase
    {
        #region Atributos
        OrbitaUltraCombo control;
        OApariencia apariencia;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OControlBase.
        /// </summary>
        protected OControlBase() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OControlBase.
        /// </summary>
        /// <param name="control"></param>
        protected OControlBase(object control)
        {
            this.control = (OrbitaUltraCombo)control;
        }
        #endregion

        #region Propiedades
        public virtual OApariencia Apariencia
        {
            get
            {
                if (this.apariencia == null)
                {
                    this.apariencia = new OApariencia();
                    this.apariencia.PropertyChanging += AparienciaChanging;
                    this.apariencia.PropertyChanged += AparienciaChanged;
                }
                return this.apariencia;
            }
            set { this.apariencia = value; }
        }
        internal OrbitaUltraCombo Control
        {
            get { return this.control; }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetApariencia()
        {
            this.apariencia.Reset();
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeApariencia()
        {
            return this.apariencia.ShouldSerialize();
        }
        #endregion

        #region Métodos protegidos virtuales
        protected virtual void AparienciaChanging(object sender, OPropiedadEventArgs e) { }
        protected virtual void AparienciaChanged(object sender, OPropiedadEventArgs e) { }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>El nombre de tipo completo del objeto.</returns>
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}