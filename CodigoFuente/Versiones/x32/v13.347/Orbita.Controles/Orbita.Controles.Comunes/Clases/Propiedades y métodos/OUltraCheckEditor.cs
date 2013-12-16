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
    public class OUltraCheckEditor
    {
        #region Atributos
        OrbitaUltraCheckEditor control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraCheckEditor.
        /// </summary>
        /// <param name="control">Control Orbita asociado a la clase actual.</param>
        public OUltraCheckEditor(object control)
            : base()
        {
            this.control = (OrbitaUltraCheckEditor)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraCheckEditor Control
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