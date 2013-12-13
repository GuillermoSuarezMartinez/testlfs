using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Sistema
{
    /// <summary>
    /// Estado de un proceso
    /// </summary>
    public enum OEstadoProceso
    {
        Indefinido = 0,
        Iniciando,
        Ejecutandose,
        Pausado,
        Deteniendose,
        Finalizado,
        Inestable = 100
    }

    /// <summary>
    /// Tipo de salida
    /// </summary>
    public enum OSalidaProceso
    {
        Indefinido = 0,
        Normal,
        Sistema,
        ServidorFalloLicencias,
        ServidorFinPeriodoGracia,
        ServidorInicioNoAutorizado,
        ServidorFinalizacion,
        ClienteFalloLicencias,
        ClienteFinPeriodoGracia,
        ClienteInicioNoAutorizado,
        ClienteFinalizacion,
        ClienteError
    }

}
