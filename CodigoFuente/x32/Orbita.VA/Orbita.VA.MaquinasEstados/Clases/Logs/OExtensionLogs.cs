//***********************************************************************
// Assembly         : Orbita.VA.MaquinasEstados
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

namespace Orbita.VA.MaquinasEstados
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    internal static class OLogsVAMaquinasEstados
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Módulo de las máquinas de estado
        /// </summary>
        public static ILogger MaquinasEstados = LogManager.GetLogger("MaquinasEstados");
        #endregion
    }
}
