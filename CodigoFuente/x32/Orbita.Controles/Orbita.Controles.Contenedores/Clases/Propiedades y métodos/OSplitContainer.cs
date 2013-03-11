//***********************************************************************
// Assembly         : Orbita.Controles.Contenedores
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
namespace Orbita.Controles.Contenedores
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OSplitContainer
    {
        #region Atributos
        OrbitaSplitContainer control;
        #endregion

        #region Constructor
        public OSplitContainer(object control)
            : base()
        {
            this.control = (OrbitaSplitContainer)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaSplitContainer Control
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