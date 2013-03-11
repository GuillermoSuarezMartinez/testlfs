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
    public class OUltraOptionSet
    {
        #region Atributos
        OrbitaUltraOptionSet control;
        #endregion

        #region Constructor
        public OUltraOptionSet(object control)
            : base()
        {
            this.control = (OrbitaUltraOptionSet)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraOptionSet Control
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