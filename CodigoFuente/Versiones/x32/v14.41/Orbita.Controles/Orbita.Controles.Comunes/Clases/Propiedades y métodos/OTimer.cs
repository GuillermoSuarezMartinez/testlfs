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
namespace Orbita.Controles.Comunes
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OTimer
    {
        #region Atributos
        /// <summary>
        /// Control Orbita asociado a la clase actual.
        /// </summary>
        OrbitaTimer control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OTimer.
        /// </summary>
        /// <param name="control">Control Orbita asociado a la clase actual.</param>
        public OTimer(object control)
            : base()
        {
            this.control = (OrbitaTimer)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Control Orbita asociado a la clase actual.
        /// </summary>
        internal OrbitaTimer Control
        {
            get { return this.control; }
        }
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