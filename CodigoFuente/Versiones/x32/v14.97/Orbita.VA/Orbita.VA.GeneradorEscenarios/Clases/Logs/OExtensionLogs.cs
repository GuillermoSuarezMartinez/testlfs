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
        public static ILogger GeneradorCodigo;
        /// <summary>
        /// Indica que la creación de los logs ha sido válida
        /// </summary>
        private static bool Valido = Constructor();
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Constructror de los logs
        /// </summary>
        /// <returns></returns>
        private static bool Constructor()
        {
            GeneradorCodigo = new DebugLogger("GeneradorCodigo");

            return true;
        }
        #endregion
    }
}
