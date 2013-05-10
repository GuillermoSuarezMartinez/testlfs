//***********************************************************************
// Assembly         : Orbita.VA.Hardware
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

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    internal class OLogsVAHardware
    {
        #region Atributo(s)
        /// <summary>
        /// Módulo de funcionamiento general de las cámaras
        /// </summary>
        public static ILogger Camaras;
        /// <summary>
        /// Módulo de funcionamiento base de las Entradas/Salidas digitales
        /// </summary>
        public static ILogger EntradasSalidas;
        /// <summary>
        /// Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales USB1024HLS de Measurement Computing
        /// </summary>                         
        public static ILogger PTZ;
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
            Camaras = LogManager.GetLogger("Camaras");
            ValidarLog("Camaras", Camaras);

            EntradasSalidas = LogManager.GetLogger("EntradasSalidas");
            ValidarLog("EntradasSalidas", EntradasSalidas);

            PTZ = LogManager.GetLogger("PTZ");
            ValidarLog("PTZ", PTZ);

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
