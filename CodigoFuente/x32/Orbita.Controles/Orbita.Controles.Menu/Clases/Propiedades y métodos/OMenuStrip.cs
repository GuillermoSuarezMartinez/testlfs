//***********************************************************************
// Assembly         : Orbita.Controles.Menu
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Menu
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OMenuStrip
    {
        #region Atributos
        /// <summary>
        /// Objecto de control de tipo Orbita.Controles.Menu.OrbitaMenuStrip.
        /// </summary>
        OrbitaMenuStrip control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OMenuStrip.
        /// </summary>
        /// <param name="control">Objecto de control de tipo Orbita.Controles.Menu.OrbitaMenuStrip.</param>
        public OMenuStrip(object control)
            : base()
        {
            this.control = (OrbitaMenuStrip)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Objecto de control de tipo Orbita.Controles.Menu.OrbitaMenuStrip.
        /// </summary>
        internal OrbitaMenuStrip Control
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