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
        Ninguna = 0,
        Arriba = 2,
        ArribaFijo = 4,
        Abajo = 8,
        AbajoFijo = 16
    }
}