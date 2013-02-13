//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Infragistics.Win.UltraWinToolbars;
namespace Orbita.Controles.Grid
{
    public class OToolClickEventArgs : ToolClickEventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        string nombre;
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
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion
    }
}