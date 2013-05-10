//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
namespace Orbita.Controles.Grid
{
    [Flags]
    public enum AreaSumario
    {
        /// <summary>
        /// Área sin sumario.
        /// </summary>
        Ninguna = 0,
        /// <summary>
        /// Área de sumario en la parte superior como primera fila ocultable con scroll.
        /// </summary>
        Arriba = 2,
        /// <summary>
        /// Área de sumario en la parte superior como primera fila fijo.
        /// </summary>
        ArribaFijo = 4,
        /// <summary>
        /// Área de sumario en la parte inferior como última fila ocultable con scroll.
        /// </summary>
        Abajo = 8,
        /// <summary>
        /// Área de sumario en la parte inferior como última fila fija.
        /// </summary>
        AbajoFijo = 16
    }
}