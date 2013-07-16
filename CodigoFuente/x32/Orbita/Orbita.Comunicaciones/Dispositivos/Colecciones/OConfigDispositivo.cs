using System;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Configuración del dispositivo
    /// </summary>
    [Serializable]
    public class OConfigDispositivo
    {
        #region Atributos privados
        /// <summary>
        /// Tiempos de espera de lectura (segundos).
        /// </summary>
        int _tiempoEsperaLectura;
        /// <summary>
        /// Tiempos de espera de escritura (segundos).
        /// </summary>
        int _tiempoEsperaEscritura;
        /// <summary>
        /// Tiempos de espera de vida (segundos).
        /// </summary>
        int _tiempoVida;
        /// <summary>
        /// Segundos de envío de evento Coms
        /// </summary>
        decimal _segEventoComs;   
        #endregion

        #region Propiedades
        /// <summary>
        /// Tiempo de espera lectura (segundos).
        /// </summary>
        public int TiempoEsperaLectura
        {
            get { return this._tiempoEsperaLectura; }
            set { this._tiempoEsperaLectura = value; }
        }
        /// <summary>
        /// Tiempo de espera escritura (segundos).
        /// </summary>
        public int TiempoEsperaEscritura
        {
            get { return this._tiempoEsperaEscritura; }
            set { this._tiempoEsperaEscritura = value; }
        }
        /// <summary>
        /// Tiempo vida (segundos).
        /// </summary>
        public int TiempoVida
        {
            get { return this._tiempoVida; }
            set { this._tiempoVida = value; }
        }
        /// <summary>
        /// Segundos de envío de evento de comunicaciones
        /// </summary>
        public decimal SegEventoComs
        {
            get { return _segEventoComs; }
            set { _segEventoComs = value; }
        }
        #endregion
    }
}