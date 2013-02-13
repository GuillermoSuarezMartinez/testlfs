using System;
//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Combo
{
    public abstract class OControlBase
    {
        #region Atributos
        /// <summary>
        /// Apariencia.
        /// </summary>
        OApariencia apariencia;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OControlBase.
        /// </summary>
        protected OControlBase() { }
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
        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeApariencia()
        {
            return this.apariencia.ShouldSerialize();
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetApariencia()
        {
            this.apariencia.Reset();
        }

        protected virtual void AparienciaChanging(object sender, OPropiedadEventArgs e) { }
        protected virtual void AparienciaChanged(object sender, OPropiedadEventArgs e) { }

        /// <summary>
        /// Determina el número de propiedades modificadas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return null;
        }
    }
}
