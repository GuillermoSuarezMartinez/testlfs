﻿//***********************************************************************
// Assembly         : Orbita.VA.Hardware
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

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Define el conjunto de módulos del sistema
    /// </summary>
    public class ModulosHardware: ModulosSistema
    {
        #region Atributo(s)
        /// <summary>
        /// Módulo de funcionamiento base de las Entradas/Salidas digitales
        /// </summary>
        public static EnumModulosSistema EntradasSalidas = new EnumModulosSistema("EntradasSalidas", "Módulo de funcionamiento base de las Entradas/Salidas digitales", 202);
        /// <summary>
        /// Módulo de funcionamiento de las cámaras Basler Pilot mediante el driver de VisionPro
        /// </summary>
        public static EnumModulosSistema CamaraBaslerVPro = new EnumModulosSistema("CamaraBaslerVPro", "Módulo de funcionamiento de las cámaras Basler Pilot mediante el driver de VisionPro", 203);
        /// <summary>
        /// Módulo de funcionamiento de las cámaras Axis
        /// </summary>
        public static EnumModulosSistema CamaraAxis = new EnumModulosSistema("CamaraAxis", "Módulo de funcionamiento de las cámaras Axis", 204);
        /// <summary>
        /// Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales de las cámaras Axis
        /// </summary>
        public static EnumModulosSistema ES_Axis = new EnumModulosSistema("ES_Axis", "Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales de las cámaras Axis", 205);
        /// <summary>
        /// Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales USB1024HLS de Measurement Computing
        /// </summary>                         
        public static EnumModulosSistema ES_MeasurementComputing = new EnumModulosSistema("ES_USB1024HLS", "Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales USB1024HLS de Measurement Computing", 206);
        /// <summary>
        /// Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales mediante SCED
        /// </summary>
        public static EnumModulosSistema ES_SCED = new EnumModulosSistema("ES_SCED", "Módulo de funcionamiento del dispositivo de Entradas/Salidas digitales mediante SCED", 207);
        /// <summary>
        /// Módulo de funciones base para las imagenes y gráficos de tipo Bitmap
        /// </summary>
        public static EnumModulosSistema ImagenGraficosBitmap = new EnumModulosSistema("ImagenGraficosBitmap", "Módulo de funciones base para las imagenes y gráficos de tipo Bitmap", 208);
        /// <summary>
        /// Módulo de funciones base para las imagenes y gráficos de tipo VisionPro
        /// </summary>
        public static EnumModulosSistema ImagenGraficosVPro = new EnumModulosSistema("ImagenGraficosVPro", "Módulo de funciones base para las imagenes y gráficos de tipo VisionPro", 209);
        /// <summary>
        /// Módulo de funcionamiento de los PTZs
        /// </summary>
        public static EnumModulosSistema PTZ = new EnumModulosSistema("PTZ", "Módulo de funcionamiento de los controladores PTZ", 210);
        /// <summary>
        /// Módulo de funcionamiento de las cámaras Basler mediante el driver propio de Pylon
        /// </summary>
        public static EnumModulosSistema CamaraBaslerPylon = new EnumModulosSistema("CamaraBaslerPylon", "Módulo de funcionamiento de las cámaras Basler mediante el driver de Pylon", 211);
        /// <summary>
        /// Módulo de funcionamiento de las cámaras cliente del servidor de cámaras
        /// </summary>
        public static EnumModulosSistema CamaraRemota = new EnumModulosSistema("CamaraRemota", "Módulo de funcionamiento de las cámaras cliente del servidor de cámaras", 212);
        #endregion
    }
}
