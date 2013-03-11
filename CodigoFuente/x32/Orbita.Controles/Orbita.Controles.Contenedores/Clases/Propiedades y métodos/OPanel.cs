﻿//***********************************************************************
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
    public class OPanel
    {
        #region Atributos
        OrbitaPanel control;
        #endregion

        #region Constructor
        public OPanel(object control)
            : base()
        {
            this.control = (OrbitaPanel)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaPanel Control
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