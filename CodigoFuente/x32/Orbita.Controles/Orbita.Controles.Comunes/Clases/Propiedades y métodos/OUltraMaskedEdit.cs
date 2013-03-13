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
namespace Orbita.Controles.Comunes
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OUltraMaskedEdit
    {
        #region Atributos
        OrbitaUltraMaskedEdit control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraMaskedEdit.
        /// </summary>
        /// <param name="control"></param>
        public OUltraMaskedEdit(object control)
            : base()
        {
            this.control = (OrbitaUltraMaskedEdit)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraMaskedEdit Control
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