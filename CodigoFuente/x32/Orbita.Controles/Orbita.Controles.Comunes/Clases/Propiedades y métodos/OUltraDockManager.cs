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
    public class OUltraDockManager
    {
        #region Atributos
        OrbitaUltraDockManager control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OUltraDockManager.
        /// </summary>
        /// <param name="control">Control Orbita asociado a la clase actual.</param>
        public OUltraDockManager(object control)
            : base()
        {
            this.control = (OrbitaUltraDockManager)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Control Orbita asociado a la clase actual.
        /// </summary>
        internal OrbitaUltraDockManager Control
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