//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    /// <summary>
    /// Orbita.Controles.Estilos.
    /// </summary>
    [System.Serializable]
    public static class OEstilo
    {
        #region Estilos predefinidos
        /// <summary>
        /// Obtiene la máscara predefinida de tipo porcentaje.
        /// </summary>
        /// <returns>La máscara predefinida de tipo porcentaje.</returns>
        public static OMascara MascaraPorcentaje()
        {
            return new OMascara("nnn.nn%", ' ', 100, 0);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tipo porcentaje, con el valor limitado entre 0  % y 99,99 %.
        /// </summary>
        /// <returns>La máscara predefinida de tipo porcentaje, con el valor limitado entre 0  % y 99,99 %.</returns>
        public static OMascara MascaraPorcentajeLimitado()
        {
            return new OMascara("nnn.nn%", ' ', 99.99, 0);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tipo porcentaje.
        /// </summary>
        /// <returns>La máscara predefinida de tipo porcentaje incluyendo negativos.</returns>
        public static OMascara MascaraPorcentajePermiteNegativo()
        {
            return new OMascara("-nnn.nn%", ' ', 100, -100);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tipo porcentaje, con el valor limitado entre -99,99  % y 99,99 %.
        /// </summary>
        /// <returns>La máscara predefinida de tipo porcentaje, con el valor limitado entre -99,99  % y 99,99 %.</returns>
        public static OMascara MascaraPorcentajeLimitadoPermiteNegativo()
        {
            return new OMascara("-nnn.nn%", ' ', 99.99, -99.99);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento.
        /// </summary>
        /// <param name="cifras">Numero de cifras que tendrá esta máscara (se utilizará para acotar el valor en número de cifras y valor máximo y para mostrar los puntos de millar).</param>
        /// <returns>La máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento.</returns>
        public static OMascara MascaraEnteraPositiva(int cifras)
        {
            if (cifras > 10)
            {
                cifras = 10;
            }
            string mascara = string.Empty;
            double valorMaximo = (System.Math.Pow(10, cifras) - 1);
            for (int i = 0; i < cifras; i++)
            {
                if (mascara.Replace(",", "").Length % 3 == 0 && i != 0)
                {
                    mascara = "," + mascara;
                }
                mascara = "n" + mascara;
            }
            return new OMascara(mascara, ' ', valorMaximo, 0);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento, seguidas de dos cifras decimales.
        /// </summary>
        /// <param name="cifrasEnteras">Numero de cifras enteras que tendrá esta máscara (se utilizará para acotar el valor en número de cifras y valor máximo y para mostrar los puntos de millar); habrá dos cifras decimales.</param>
        /// <returns>La máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento.</returns>
        public static OMascara MascaraDecimalPositiva(int cifrasEnteras)
        {
            if (cifrasEnteras > 10)
            {
                cifrasEnteras = 10;
            }
            string mascara = string.Empty;
            double valorMaximo = (System.Math.Pow(10, cifrasEnteras) - 1);
            for (int i = 0; i < cifrasEnteras; i++)
            {
                if (mascara.Replace(",", "").Length % 3 == 0 && i != 0)
                {
                    mascara = "," + mascara;
                }
                mascara = "n" + mascara;
            }
            mascara = mascara + ".nn";
            valorMaximo += (System.Math.Pow(10, 2) - 1) / System.Math.Pow(10, 2);
            return new OMascara(mascara, ' ', valorMaximo, 0);
        }
        /// <summary>
        /// Devuelve una mascara con el número de cifras enteras y decimales deseadas.
        /// <param name="cifrasEnteras">Número de cifras enteras deseadas (se utilizará para acotar el valor en número de cifras y valor máximo y para mostrar los puntos de millar).</param>
        /// <param name="cifrasDecimales">Número de cifras decimales deseadas.</param>
        /// </summary>
        public static OMascara MascaraDecimalPositiva(int cifrasEnteras, int cifrasDecimales)
        {
            if (cifrasEnteras > 10)
            {
                cifrasEnteras = 10;
            }
            if (cifrasDecimales > 10)
            {
                cifrasDecimales = 10;
            }
            string mascara = string.Empty;
            double valorMaximo = (System.Math.Pow(10, cifrasEnteras) - 1);
            for (int i = 0; i < cifrasEnteras; i++)
            {
                if (mascara.Replace(",", "").Length % 3 == 0 && i != 0)
                {
                    mascara = "," + mascara;
                }
                mascara = "n" + mascara;
            }
            if (cifrasDecimales > 0)
            {
                mascara += ".";
                for (int i = 0; i < cifrasDecimales; i++)
                {
                    mascara = mascara + "n";
                }
                valorMaximo += (System.Math.Pow(10, cifrasDecimales) - 1) / System.Math.Pow(10, cifrasDecimales);
            }
            return new OMascara(mascara, ' ', valorMaximo, 0);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento.
        /// </summary>
        /// <param name="cifras">Numero de cifras que tendrá esta máscara (se utilizará para acotar el valor en número de cifras y valor máximo y para mostrar los puntos de millar).</param>
        /// <returns>La máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento.</returns>
        public static OMascara MascaraEntera(int cifras)
        {
            if (cifras > 10)
            {
                cifras = 10;
            }
            string mascara = string.Empty;
            double valorMaximo = (System.Math.Pow(10, cifras) - 1);
            for (int i = 0; i < cifras; i++)
            {
                if (mascara.Replace(",", "").Length % 3 == 0 && i != 0)
                {
                    mascara = "," + mascara;
                }
                mascara = "n" + mascara;
            }
            mascara = "-" + mascara;
            return new OMascara(mascara, ' ', valorMaximo, -valorMaximo);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento, seguidas de dos cifras decimales.
        /// </summary>
        /// <param name="cifrasEnteras">Numero de cifras enteras que tendrá esta máscara (se utilizará para acotar el valor en número de cifras y valor máximo y para mostrar los puntos de millar); habrá dos cifras decimales.</param>
        /// <returns>La máscara predefinida de tantas cifras enteras positivas como se indiquen en el argumento.</returns>
        public static OMascara MascaraDecimal(int cifrasEnteras)
        {
            if (cifrasEnteras > 10)
            {
                cifrasEnteras = 10;
            }
            string mascara = string.Empty;
            double valorMaximo = (System.Math.Pow(10, cifrasEnteras) - 1);
            for (int i = 0; i < cifrasEnteras; i++)
            {
                if (mascara.Replace(",", "").Length % 3 == 0 && i != 0)
                {
                    mascara = "," + mascara;
                }
                mascara = "n" + mascara;
            }
            mascara = mascara + ".nn";
            mascara = "-" + mascara;
            valorMaximo += (System.Math.Pow(10, 2) - 1) / System.Math.Pow(10, 2);
            return new OMascara(mascara, ' ', valorMaximo, -valorMaximo);
        }
        /// <summary>
        /// Devuelve una mascara con el número de cifras enteras y decimales deseadas.
        /// <param name="cifrasEnteras">Número de cifras enteras deseadas (se utilizará para acotar el valor en número de cifras y valor máximo y para mostrar los puntos de millar).</param>
        /// <param name="cifrasDecimales">Número de cifras decimales deseadas.</param>
        /// </summary>
        public static OMascara MascaraDecimal(int cifrasEnteras, int cifrasDecimales)
        {
            if (cifrasEnteras > 10)
            {
                cifrasEnteras = 10;
            }
            if (cifrasDecimales > 10)
            {
                cifrasDecimales = 10;
            }
            string mascara = string.Empty;
            double valorMaximo = (System.Math.Pow(10, cifrasEnteras) - 1);
            for (int i = 0; i < cifrasEnteras; i++)
            {
                if (mascara.Replace(",", "").Length % 3 == 0 && i != 0)
                {
                    mascara = "," + mascara;
                }
                mascara = "n" + mascara;
            }
            if (cifrasDecimales > 0)
            {
                mascara += ".";
                for (int i = 0; i < cifrasDecimales; i++)
                {
                    mascara = mascara + "n";
                }
                valorMaximo += (System.Math.Pow(10, cifrasDecimales) - 1) / System.Math.Pow(10, cifrasDecimales);
            }
            mascara = "-" + mascara;
            return new OMascara(mascara, ' ', valorMaximo, -valorMaximo);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de tipo moneda.
        /// </summary>
        /// <returns>La máscara predefinida de tipo moneda.</returns>
        public static OMascara MascaraMoneda()
        {
            return new OMascara("-nnn,nnn,nnn,nnn,nnn.nn", ' ', System.Double.MaxValue, System.Double.MinValue);
        }
        /// <summary>
        /// Obtiene la máscara predefinida para las jornadas.
        /// </summary>
        /// <returns>La máscara predefinida para las jornadas.</returns>
        public static OMascara MascaraJornadas()
        {
            return new OMascara("nn,nnn.nn", ' ', System.Double.MaxValue, 0);
        }
        /// <summary>
        /// Obtiene la máscara predefinida para las horas.
        /// </summary>
        /// <returns>La máscara predefinida para las horas.</returns>
        public static OMascara MascaraHoras()
        {
            return new OMascara("nn,nnn.nn", ' ', System.Double.MaxValue, 0);
        }
        /// <summary>
        /// Obtiene la máscara predefinida de teléfono.
        /// </summary>
        /// <returns>La máscara predefinida de teléfono.</returns>
        public static OMascara MascaraTelefono()
        {
            return new OMascara("999-999-999");
        }
        /// <summary>
        /// Obtiene el sumario predefinido de tipo entero.
        /// </summary>
        /// <returns>El sumario predefinido de tipo entero.</returns>
        public static OColumnaSumario SumarioEntero()
        {
            return new OColumnaSumario("{0:###,##0}");
        }
        /// <summary>
        /// Obtiene el sumario predefinido de tipo moneda.
        /// </summary>
        /// <returns>El sumario predefinido de tipo moneda.</returns>
        public static OColumnaSumario SumarioMoneda()
        {
            return new OColumnaSumario("{0:###,###,###,###,##0.00}");
        }
        /// <summary>
        /// Obtiene el sumario predefinido de jornadas.
        /// </summary>
        /// <returns>El sumario predefinido de jornadas.</returns>
        public static OColumnaSumario SumarioJornadas()
        {
            return new OColumnaSumario("{0:##,##0.00}");
        }
        /// <summary>
        /// Obtiene el sumario predefinido de horas.
        /// </summary>
        /// <returns>El sumario predefinido de horas.</returns>
        public static OColumnaSumario SumarioHoras()
        {
            return new OColumnaSumario("{0:##,##0.00}");
        }
        /// <summary>
        /// Obtiene la línea a mostrar en las excepciones.
        /// </summary>
        /// <returns>Un String predefinido de excepción.</returns>
        public static string FormatExcepcionGeneral()
        {
            return "Error: {0}\r\nExcepción: {1}\r\nStacktrace: {2}";
        }
        #endregion
    }
}