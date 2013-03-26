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
        public static ILogger Camaras = LogManager.GetLogger("Camaras");
        /// <summary>
        /// Módulo de funcionamiento base de las Entradas/Salidas digitales
        /// </summary>
        public static ILogger EntradasSalidas = LogManager.GetLogger("EntradasSalidas");
        /// <summary>
        /// Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales USB1024HLS de Measurement Computing
        /// </summary>                         
        public static ILogger PTZ = LogManager.GetLogger("PTZ");
        #endregion
    }
}
