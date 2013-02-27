//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
namespace Orbita.Controles.Grid
{
    public class OToolClickEventArgs : ToolClickEventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        UltraGridRow fila;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OPropiedadEventArgs.
        /// </summary>
        public OToolClickEventArgs(ToolBase tool, Infragistics.Win.UltraWinToolbars.ListToolItem listToolItem)
            : base(tool, listToolItem) { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        public UltraGridRow Fila
        {
            get { return this.fila; }
            set { this.fila = value; }
        }
        #endregion
    }
}