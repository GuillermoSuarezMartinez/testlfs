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
namespace Orbita.Controles.Grid
{
    public class OToolClickEventArgs : Infragistics.Win.UltraWinToolbars.ToolClickEventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        Infragistics.Win.UltraWinGrid.UltraGridRow fila;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OToolClickEventArgs.
        /// </summary>
        public OToolClickEventArgs(Infragistics.Win.UltraWinToolbars.ToolBase tool, Infragistics.Win.UltraWinToolbars.ListToolItem listToolItem)
            : base(tool, listToolItem) { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGridRow Fila
        {
            get { return this.fila; }
            set { this.fila = value; }
        }
        #endregion
    }
}