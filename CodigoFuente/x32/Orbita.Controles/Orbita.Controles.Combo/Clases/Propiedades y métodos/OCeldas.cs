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
using System;
using System.IO;
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OCeldas : OControlBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OCeldas.
        /// </summary>
        public OCeldas()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de las celdas.")]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        #endregion
    }
}
