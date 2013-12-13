using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Enumerados
{
    /// <summary>
    /// Nivel de importancia
    /// </summary>
    public enum ONivel
    {
        /// <summary>
        /// Valor sin definir, se utilizará para denotar el valor por defecto o no inicializado.
        /// </summary>
        Indefinido = 0,
        /// <summary>
        /// Si falla el sistema se detendrá.
        /// </summary>
        ParadaInmediata = 1,
        /// <summary>
        /// Si falla, el sistema se detendrá tras un periodo definido de prueba.
        /// </summary>
        Critico = 2,
        /// <summary>
        /// Si falla pero existe otra licencia activa, el sistema no se detendrá.
        /// </summary>
        Opcional = 3,
        /// <summary>
        /// Si falla splamente notificará, no se detendrá el sistema.
        /// </summary>
        NoRequerido = 4
    }
}
