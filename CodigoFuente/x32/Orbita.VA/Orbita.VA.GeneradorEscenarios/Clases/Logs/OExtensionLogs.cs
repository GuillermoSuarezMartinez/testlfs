//***********************************************************************
// Assembly         : Orbita.VA.GeneradorEscenarios
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using Orbita.VA.Comun;
using Orbita.Trazabilidad;

namespace Orbita.VA.GeneradorEscenarios
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    internal class OLogsVAGeneradorEscenarios
    {
        #region Atributo(s)
        /// <summary>
        /// Módulo de las funciones de visión
        /// </summary>
        public static ILogger GeneradorCodigo = new DebugLogger("GeneradorCodigo");
        #endregion
    }
}
