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
namespace Orbita.Controles.Contenedores
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OTableLayoutPanel
    {
        #region Atributos
        OrbitaTableLayoutPanel control;
        #endregion

        #region Constructor
        public OTableLayoutPanel(object control)
            : base()
        {
            this.control = (OrbitaTableLayoutPanel)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaTableLayoutPanel Control
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