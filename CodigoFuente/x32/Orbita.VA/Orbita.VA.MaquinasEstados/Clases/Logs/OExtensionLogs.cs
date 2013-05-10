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
using System;

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
        public static ILogger MaquinasEstados;
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
            MaquinasEstados = LogManager.GetLogger("MaquinasEstados");
            ValidarLog("MaquinasEstados", MaquinasEstados);

            return true;
        }

        /// <summary>
        /// Validación del log
        /// </summary>
        /// <param name="identificador"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        private static bool ValidarLog(string identificador, ILogger log)
        {
            if (log == null)
            {
                throw new Exception("No se encuentra la configuración para el log " + identificador);
            }
            return true;
        }
        #endregion
    }
}
