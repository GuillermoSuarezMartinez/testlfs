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
namespace Orbita.Controles.Contenedores
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OTableLayoutPanel
    {
        #region Atributos
        OrbitaTableLayoutPanel control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Contenedores.OTableLayoutPanel.
        /// </summary>
        /// <param name="control"></param>
        public OTableLayoutPanel(object control)
            : base()
        {
            this.control = (OrbitaTableLayoutPanel)control;
        }
        #endregion

        #region Propiedades
        internal OrbitaTableLayoutPanel Control
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