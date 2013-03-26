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
    internal static class OLogsVAComun
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Módulo de funciones comunes del sistema. 
        /// </summary>
        public static ILogger Comun = LogManager.GetLogger("Comun");
        /// <summary>
        /// Módulo de funciones propias del inicio y la finalización del sistema. 
        /// </summary>
        public static ILogger Sistema = LogManager.GetLogger("Sistema");
        /// <summary>
        /// Módulo de Threads del sistema. 
        /// </summary>
        public static ILogger Threads = LogManager.GetLogger("Threads");
        /// <summary>
        /// Módulo de monitorización del sistema. 
        /// </summary>
        public static ILogger Monitorizacion = LogManager.GetLogger("Monitorizacion");
        /// <summary>
        /// Módulo de funciones encargadas de monitorizar la creación y destrucción de objetos de origen propio que ocupan gran cantidad de memoria y de creación frecuente, así como la gestión del colector de basura de .net
        /// </summary>
        public static ILogger GestionMemoria = LogManager.GetLogger("GestionMemoria");
        /// <summary>
        /// Módulo de funciones multimedia de creación y compresión de imagenes y video
        /// </summary>
        public static ILogger Multimedia = LogManager.GetLogger("Multimedia");
        /// <summary>
        /// Módulo de las variables del sistema
        /// </summary>
        public static ILogger Variables = LogManager.GetLogger("Variables");
        /// <summary>
        /// Módulo de funciones base para las imagenes y gráficos
        /// </summary>
        public static ILogger ImagenGraficos = LogManager.GetLogger("ImagenGraficos");
        /// <summary>
        /// Módulo de funciones base para el almacenamientod de información
        /// </summary>
        public static ILogger AlmacenInformacion = LogManager.GetLogger("AlmacenInformacion");
        #endregion
    }
}