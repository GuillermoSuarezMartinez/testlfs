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