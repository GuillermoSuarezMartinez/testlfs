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
namespace Orbita.Controles.Menu
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OUltraExplorerBar
    {
        #region Atributos
        OrbitaUltraExplorerBar control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Menu.OUltraExplorerBar.
        /// </summary>
        /// <param name="control">>Orbita.Controles.Menu.OrbitaUltraExplorerBar.</param>
        public OUltraExplorerBar(object control)
            : base()
        {
            this.control = (OrbitaUltraExplorerBar)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaUltraExplorerBar Control
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