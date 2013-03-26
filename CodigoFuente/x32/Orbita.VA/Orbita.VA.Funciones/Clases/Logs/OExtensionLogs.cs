//***********************************************************************
// Assembly         : Orbita.VA.Funciones
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

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    internal class OLogsVAFunciones
    {
        #region Atributo(s)
        /// <summary>
        /// Módulo de las funciones de visión
        /// </summary>
        public static ILogger Vision = LogManager.GetLogger("Vision");
        /// <summary>
        /// Módulo de Vision Pro
        /// </summary>
        public static ILogger VisionPro = LogManager.GetLogger("VisionPro");
        /// <summary>
        /// Módulo de CCR. Lectura de mátriculas de contenedores
        /// </summary>
        public static ILogger CCR = LogManager.GetLogger("CCR");
        /// <summary>
        /// Módulo de LPR de vehículos
        /// </summary>
        public static ILogger LPR = LogManager.GetLogger("LPR");
        /// <summary>
        /// Módulo de trabajo con las funciones de OpenCV
        /// </summary>
        public static ILogger OpenCV = LogManager.GetLogger("OpenCV");
        #endregion
    }
}
