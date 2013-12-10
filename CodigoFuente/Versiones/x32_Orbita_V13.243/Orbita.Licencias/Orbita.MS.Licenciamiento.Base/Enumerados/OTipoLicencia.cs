using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS
{
    /// <summary>
    /// Indica el tipo de licencia que se aplica
    /// </summary>
    public enum OTipoLicencia
    {
        /// <summary>
        /// Licencia sin definir, genérica
        /// </summary>
        Indefinido = 0,
        /// <summary>
        /// Licencia harware, Sentinel HASP SafeNet
        /// </summary>
        HASP = 1,
        /// <summary>
        /// Licencia USB, Orbita
        /// </summary>
        USB = 2,
        /// <summary>
        /// Licencia Software
        /// </summary>
        Software = 3,
        /// <summary>
        /// Licencia prueba
        /// </summary>
        Test = 99
    }

}
