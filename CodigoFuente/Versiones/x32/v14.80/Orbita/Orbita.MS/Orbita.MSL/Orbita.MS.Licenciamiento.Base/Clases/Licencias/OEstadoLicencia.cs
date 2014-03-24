using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS
{
    public enum OEstadoLicenciaCliente
    {
        Indefinido = 0,
        Pendiente,
        Licenciado,
        LicenciadoSinConexion,
        InvalidaPeriodoGracia,
        InvalidaDesconectado,
        InvalidaEsperandoDesconexion,
        InvalidaForzadaDesconexion,
        InvalidaFinalizada,
        Invalida,
        Consulta
    }
}
