//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 26-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Orbita.VA.Comun;
using Orbita.Trazabilidad;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    internal class OLogsControlesVA
    {
        #region Atributo(s)
        /// <summary>
        /// Módulo de las funciones de visión
        /// </summary>
        public static ILogger ControlesVA = new DebugLogger("ControlesVA");
        /// <summary>
        /// Módulo de los escritorios MDI
        /// </summary>
        public static ILogger Escritorios = new DebugLogger("Escritorios");
        #endregion
    }
}
