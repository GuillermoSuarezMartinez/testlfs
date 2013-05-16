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
    public class OUltraNumericEditor
    {
        #region Atributos
        /// <summary>
        /// Control (sender).
        /// </summary>
        OrbitaUltraNumericEditor control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraNumericEditor.
        /// </summary>
        /// <param name="control"></param>
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

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>El nombre de tipo completo del objeto.</returns>
        public override string ToString()
        {
            return null;
        }
        #endregion
    }
}