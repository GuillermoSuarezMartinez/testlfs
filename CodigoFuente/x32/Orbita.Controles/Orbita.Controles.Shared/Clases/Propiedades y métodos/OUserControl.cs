//***********************************************************************
// Assembly         : Orbita.Controles.Shared
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
namespace Orbita.Controles.Shared
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OUserControl
    {
        #region Atributos
        OrbitaUserControl control;
        #endregion

        #region Constructor
        public OUserControl(object control)
            : base()
        {
            this.control = (OrbitaUserControl)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUserControl Control
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