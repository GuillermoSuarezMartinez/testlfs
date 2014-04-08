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
    /// <summary>
    /// Clase Orbita.Controles.Comunes.OListBox vinculada a la clase Orbita.Controles.Comunes.OrbitaListBox.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OListBox
    {
        #region Atributos
        /// <summary>
        /// Control Orbita.Controles.Comunes.OrbitaListBox vinculado a la clase actual.
        /// </summary>
        OrbitaListBox control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OListBox.
        /// </summary>
        /// <param name="control">Control Orbita.Controles.Comunes.OrbitaListBox vinculado a la clase actual.</param>
        public OListBox(object control)
            : base()
        {
            this.control = (OrbitaListBox)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Control Orbita.Controles.Comunes.OrbitaListBox vinculado a la clase actual.
        /// </summary>
        internal OrbitaListBox Control
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