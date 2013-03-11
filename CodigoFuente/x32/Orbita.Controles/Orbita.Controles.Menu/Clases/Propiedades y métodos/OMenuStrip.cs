//***********************************************************************
// Assembly         : Orbita.Controles.Menu
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OMenuStrip
    {
        #region Atributos
        OrbitaMenuStrip control;
        #endregion

        #region Constructor
        public OMenuStrip(object control)
            : base()
        {
            this.control = (OrbitaMenuStrip)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaMenuStrip Control
        {
            get { return this.control; }
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}