﻿//***********************************************************************
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
    public class OToolClickCollectionEventArgs : Infragistics.Win.UltraWinToolbars.ToolClickEventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Colección de filas.
        /// </summary>
        Infragistics.Win.UltraWinGrid.UltraGridRow[] filas;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OToolClickCollectionEventArgs.
        /// </summary>
        public OToolClickCollectionEventArgs(Infragistics.Win.UltraWinToolbars.ToolBase tool, Infragistics.Win.UltraWinToolbars.ListToolItem listToolItem)
            : base(tool, listToolItem) { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Colección de filas.
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGridRow[] Filas
        {
            get { return this.filas; }
            set { this.filas = value; }
        }
        #endregion
    }
}