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
using System;

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
        public static ILogger Vision;
        /// <summary>
        /// Módulo de Vision Pro
        /// </summary>
        public static ILogger VisionPro;
        /// <summary>
        /// Módulo de CCR. Lectura de mátriculas de contenedores
        /// </summary>
        public static ILogger CCR;
        /// <summary>
        /// Módulo de ARH de vehículos
        /// </summary>
        public static ILogger ARH;
        /// <summary>
        /// Módulo de LPR de vehículos
        /// </summary>
        public static ILogger LPR;
        /// <summary>
        /// Módulo de trabajo con las funciones de OpenCV
        /// </summary>
        public static ILogger OpenCV;
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
            Vision = LogManager.GetLogger("Vision");
            ValidarLog("Vision", Vision);

            VisionPro = LogManager.GetLogger("VisionPro");
            ValidarLog("VisionPro", VisionPro);

            CCR = LogManager.GetLogger("CCR");
            ValidarLog("CCR", CCR);

            LPR = LogManager.GetLogger("LPR");
            ValidarLog("LPR", LPR);

            OpenCV = LogManager.GetLogger("OpenCV");
            ValidarLog("OpenCV", OpenCV);

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
