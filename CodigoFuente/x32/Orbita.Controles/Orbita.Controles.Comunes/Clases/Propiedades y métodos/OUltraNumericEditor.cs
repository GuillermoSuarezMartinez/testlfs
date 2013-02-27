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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OUltraNumericEditor
    {
        #region Atributos
        /// <summary>
        /// Control (sender).
        /// </summary>
        OrbitaUltraNumericEditor control;
        #endregion

        #region Constructor
        public OUltraNumericEditor(object control)
            : base()
        {
            this.control = (OrbitaUltraNumericEditor)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraNumericEditor Control
        {
            get { return this.control; }
        }
        #endregion
    }
}