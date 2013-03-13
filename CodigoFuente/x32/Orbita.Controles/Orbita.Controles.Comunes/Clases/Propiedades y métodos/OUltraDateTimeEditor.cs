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
    public class OUltraDateTimeEditor
    {
        #region Atributos
        OrbitaUltraDateTimeEditor control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraDateTimeEditor.
        /// </summary>
        /// <param name="control"></param>
        public OUltraDateTimeEditor(object control)
            : base()
        {
            this.control = (OrbitaUltraDateTimeEditor)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraDateTimeEditor Control
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