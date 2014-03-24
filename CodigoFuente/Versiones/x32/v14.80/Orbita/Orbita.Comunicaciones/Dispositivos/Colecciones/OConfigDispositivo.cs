using System;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Configuración del dispositivo.
    /// </summary>
    [Serializable]
    public class OConfigDispositivo
    {
        #region Propiedades
        /// <summary>
        /// Tiempo de espera lectura (segundos).
        /// </summary>
        public int TiempoEsperaLectura { get; set; }
        /// <summary>
        /// Tiempo de espera escritura (segundos).
        /// </summary>
        public int TiempoEsperaEscritura { get; set; }
        /// <summary>
        /// Tiempo vida (segundos).
        /// </summary>
        public int TiempoVida { get; set; }
        /// <summary>
        /// Segundos de envío de evento de comunicaciones.
        /// </summary>
        public decimal SegEventoComs { get; set; }
        #endregion Propiedades
    }
}