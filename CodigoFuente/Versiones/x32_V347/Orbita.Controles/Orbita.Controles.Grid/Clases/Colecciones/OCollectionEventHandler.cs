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
    /// <summary>
    /// A dictionary with keys of type string and values of type Target.
    /// </summary>
    internal class OCollectionEventHandler : System.Collections.Generic.Dictionary<string, OEventHandler>
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.OCollectionEventHandler.
        /// </summary>
        public OCollectionEventHandler() { }
        #endregion
    }
}