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
    public class ODialog
    {
        #region Atributos
        OrbitaDialog control;
        #endregion

        #region Constructor
        public ODialog(object control)
            : base()
        {
            this.control = (OrbitaDialog)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaDialog Control
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