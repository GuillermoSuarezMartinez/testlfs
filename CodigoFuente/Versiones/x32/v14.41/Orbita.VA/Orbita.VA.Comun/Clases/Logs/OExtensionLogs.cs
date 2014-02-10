//***********************************************************************
// Assembly         : Orbita.VA.Comun
// Author           : aibañez
// Created          : 26-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Orbita.Trazabilidad;
using Orbita.Utiles;

namespace Orbita.VA.Comun
{
    public static class OLogsVAComun
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Módulo de funciones comunes del sistema. 
        /// </summary>
        public static ILogger Comun;
        /// <summary>
        /// Módulo de funciones propias del inicio y la finalización del sistema. 
        /// </summary>
        public static ILogger Sistema;
        /// <summary>
        /// Módulo de Threads del sistema. 
        /// </summary>
        public static ILogger Threads;
        /// <summary>
        /// Módulo de monitorización del sistema. 
        /// </summary>
        public static ILogger Monitorizacion;
        /// <summary>
        /// Módulo de funciones encargadas de monitorizar la creación y destrucción de objetos de origen propio que ocupan gran cantidad de memoria y de creación frecuente, así como la gestión del colector de basura de .net
        /// </summary>
        public static ILogger GestionMemoria;
        /// <summary>
        /// Módulo de funciones multimedia de creación y compresión de imagenes y video
        /// </summary>
        public static ILogger Multimedia;
        /// <summary>
        /// Módulo de las variables del sistema
        /// </summary>
        public static ILogger Variables;
        /// <summary>
        /// Módulo de funciones base para las imagenes y gráficos
        /// </summary>
        public static ILogger ImagenGraficos;
        /// <summary>
        /// Módulo de funciones base para el almacenamientod de información
        /// </summary>
        public static ILogger AlmacenInformacion;
        /// <summary>
        /// Módulo de mapeo de regiones de memoria
        /// </summary>
        public static ILogger RegionMemoriaMapeada;
        /// <summary>
        /// Módulo de funciones de trabamo con remoting
        /// </summary>
        public static ILogger Remoting;
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
            Comun = LogManager.GetLogger("Comun");
            ValidarLog("Comun", Comun);

            Sistema = LogManager.GetLogger("Sistema");
            ValidarLog("Sistema", Sistema);

            Threads = LogManager.GetLogger("Threads");
            ValidarLog("Threads", Threads);

            Monitorizacion = LogManager.GetLogger("Monitorizacion");
            ValidarLog("Monitorizacion", Monitorizacion);

            GestionMemoria = LogManager.GetLogger("GestionMemoria");
            ValidarLog("GestionMemoria", GestionMemoria);

            Multimedia = LogManager.GetLogger("Multimedia");
            ValidarLog("Multimedia", Multimedia);

            Variables = LogManager.GetLogger("Variables");
            ValidarLog("Variables", Variables);

            ImagenGraficos = LogManager.GetLogger("ImagenGraficos");
            ValidarLog("ImagenGraficos", ImagenGraficos);

            AlmacenInformacion = LogManager.GetLogger("AlmacenInformacion");
            ValidarLog("AlmacenInformacion", AlmacenInformacion);

            RegionMemoriaMapeada = LogManager.GetLogger("RegionMemoriaMapeada");
            ValidarLog("Comun", RegionMemoriaMapeada);

            Remoting = LogManager.GetLogger("Remoting");
            ValidarLog("Remoting", Remoting);

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