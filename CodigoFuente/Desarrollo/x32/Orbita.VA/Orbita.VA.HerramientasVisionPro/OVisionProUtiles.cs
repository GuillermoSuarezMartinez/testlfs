//***********************************************************************
// Assembly         : Orbita.VA.HerramientasVisionPro
// Author           : fhernandez
// Created          : 02-09-2013
//
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ColorSegmenter;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;

namespace Orbita.VA.HerramientasVisionPro
{
    #region Clase estática App: Contiene métodos genéricos
    /// <summary>
    /// Clase estática con funciones de uso general
    /// </summary>
    [Serializable]
    public static class OVisionProUtiles
    {
        #region Campos de la clase
        /// <summary>
        /// ToolBlock utilizado para ejecutar tools individuales
        /// </summary>
        private static CogToolBlock ToolBlock = new CogToolBlock();
        /// <summary>
        /// Delegado para realizar la visualización en pantalla
        /// </summary>
        /// <param name="imagen"></param>
        /// <param name="graficos"></param>
        /// <param name="indice"></param>
        public delegate void DelegadoVisualizacion(ICogImage imagen, CogGraphicCollection graficos, int indice);
        #endregion Campos de la clase

        #region Utilidades programación estándar
        #region Método para Loggear de manera rápida
        /// <summary>
        /// Loggear rápido , si el fichero ocupa más del espacio configurado , los almacena por fecha
        /// </summary>
        /// <param name="tipoLog"></param>
        /// <param name="procedencia"></param>
        /// <param name="descrError"></param>
        public static void EscribirEnLog(string tipoLog, string procedencia, string descrError)
        {
            try
            {
                //// Si no existe lo creamos
                if (!File.Exists(Properties.Settings.Default.RutaLog))
                {
                    File.Create(Properties.Settings.Default.RutaLog);
                }

                // Si ha aumentado demasiado el tamaño renombramos por fecha y empezamos otro
                FileInfo info = new System.IO.FileInfo(Properties.Settings.Default.RutaLog);
                if (info.Length > Properties.Settings.Default.TamMaxLog)
                {
                    string rutaNuevaFecha = DateTime.Now.Year.ToString("0000") + "_" + DateTime.Now.Month.ToString("00") + "_" + DateTime.Now.Day.ToString("00") + "_"
                      + DateTime.Now.Hour.ToString("00") + "_" + DateTime.Now.Minute.ToString("00") + "_" + DateTime.Now.Second.ToString("00") + ".jpg";
                    rutaNuevaFecha = Properties.Settings.Default.RutaLog.Insert(Properties.Settings.Default.RutaLog.Length - 4, rutaNuevaFecha);
                    File.Move(Properties.Settings.Default.RutaLog, rutaNuevaFecha);
                    File.Create(Properties.Settings.Default.RutaLog);
                }

                StreamWriter sw = new StreamWriter(Properties.Settings.Default.RutaLog, true);
                sw.WriteLine(DateTime.Now + "|" + tipoLog + "|" + procedencia + "|" + descrError);
                sw.Close();
            }
            catch
            {
            }
        }
        #endregion

        #region Métodos de evaluación de números
        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool InRange(int value, int min, int max)
        {
            return (value >= min) && (value <= max);
        }

        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static bool InRange(double value, double min, double max)
        {
            return (value >= min) && (value <= max);
        }

        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static int EnsureRange(int value, int min, int max)
        {
            int resultado = value;

            if (value < min)
            {
                resultado = min;
            }
            if (value > max)
            {
                resultado = max;
            }

            return resultado;
        }

        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado y en caso contrario lo modifica para que cumpla la condición
        /// </summary>
        /// <returns>Devuelve el número obligando a que esté dentro del rango determinado</returns>
        public static double EnsureRange(double value, double min, double max)
        {
            double resultado = value;

            if (value < min)
            {
                resultado = min;
            }
            if (value > max)
            {
                resultado = max;
            }

            return resultado;
        }

        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static int EvaluaNumero(object value, int min, int max, int defecto)
        {
            object objValue = value;
            if (IsNumericInt(objValue))
            {
                int intValue = (int)objValue;
                if (InRange(intValue, min, max))
                {
                    return intValue;
                }
            }
            return defecto;
        }

        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double EvaluaDecimal(object value, double min, double max, double defecto)
        {
            object objValue = value;
            if (IsNumericFloat(objValue))
            {
                double floatValue = (double)objValue;
                if (InRange(floatValue, min, max))
                {
                    return floatValue;
                }
            }
            return defecto;
        }

        /// <summary>
        /// Evalúa si el parámetro está dentro del rango determinado
        /// </summary>
        /// <returns>Devuelve verdadero si el parámetro está dentro del rango determinado</returns>
        public static double EvaluaNumero(object value, double min, double max, double defecto)
        {
            object objValue = value;
            if (IsNumericFloat(objValue))
            {
                double floatValue = (double)objValue;
                if (InRange(floatValue, min, max))
                {
                    return floatValue;
                }
            }
            return defecto;
        }

        /// <summary>
        /// Evalúa si el parámetro es booleano
        /// </summary>
        public static bool EvaluaBooleano(object value, bool defecto)
        {
            bool Resulado = defecto;

            if (value is bool)
            {
                Resulado = (bool)value;
            }
            return Resulado;
        }

        /// <summary>
        /// Evalúa si el parámetro es booleano
        /// </summary>
        public static DateTime EvaluaFecha(object value, DateTime defecto)
        {
            DateTime Resulado = defecto;

            if (value is DateTime)
            {
                Resulado = (DateTime)value;
            }
            return Resulado;
        }

        /// <summary>
        /// Función que devuelve si el objeto pertenece a alguno de los tipos listados
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer el tipo</param>
        /// <param name="types">Vector de tipos con lo que se ha de comparar el tipo del objeto</param>
        /// <returns>Verdadero si el tipo del objeto está dentro de la lista de tipos pasados como parámetros</returns>
        public static bool IsTypeOf(object o, params Type[] types)
        {
            foreach (Type t in types)
            {
                if (o.GetType() == t)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Indica si el objeto pasado es de tipo numérico
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo numérico</param>
        /// <returns>Verdadero si el tipo del objeto es numérico</returns>
        public static bool IsNumeric(object o)
        {
            return (o != null) && IsTypeOf(o, typeof(int), typeof(short), typeof(long), typeof(uint), typeof(ushort), typeof(ulong), typeof(byte), typeof(float), typeof(double), typeof(decimal));
        }

        /// <summary>
        /// Indica si el objeto pasado es de tipo entero
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo entero</param>
        /// <returns>Verdadero si el tipo del objeto es entero</returns>
        public static bool IsNumericInt(object o)
        {
            return (o != null) && IsTypeOf(o, typeof(int), typeof(short), typeof(long), typeof(uint), typeof(ushort), typeof(ulong), typeof(byte));
        }

        /// <summary>
        /// Indica si el objeto pasado es de tipo decimal
        /// </summary>
        /// <param name="o">Objeto que se quiere conocer si es de tipo decimal</param>
        /// <returns>Verdadero si el tipo del objeto es decimal</returns>
        public static bool IsNumericFloat(object o)
        {
            return (o != null) && IsTypeOf(o, typeof(float), typeof(double), typeof(decimal));
        }
        #endregion

        #region Métodos de evaluación de enumerados
        /// <summary>
        /// Se utiliza con enumerados y devuelve verdadero si el enumerado está contenido en el valor
        /// </summary>
        /// <param name="value">Valor del cual se quiere saber si contiene cieto enumerado</param>
        /// <param name="enumerate">Enumerado que deseamos comparar con el valor</param>
        /// <returns>Devuelve verdadero si el enumerado está contenido en el valor</returns>
        public static bool EnumContains(int value, int[] enumerate)
        {
            foreach (int i in enumerate)
            {
                if ((value & i) != 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Se utiliza con enumerados para convertir un valor de texto en un enumerado del tipo indicado
        /// </summary>
        /// <param name="enumType">Tipo del enumerado al que deseamos convertir</param>
        /// <param name="value">Texto que queremos convertir a enumerado</param>
        /// <param name="defaultValue">Valor por defecto en el caso que el texto no coincida con ningun elemento del enumerado</param>
        /// <returns>Devuelve el enumerado correspondiente con el texto</returns>
        public static object EnumParse(Type enumType, string value, object defaultValue)
        {
            object resultado;

            try
            {
                resultado = Enum.Parse(enumType, value);
            }
            catch
            {
                resultado = defaultValue;
            }

            return resultado;
        }
        #endregion

        #region Métodos de trabajo con números binarios
        /// <summary>
        /// Extrae un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos extraer el bit</param>
        /// <param name="posicion">Posición del bit a extraer</param>
        /// <returns>Booleano con el valor del bit extraido</returns>
        public static bool GetBit(byte numero, int posicion)
        {
            byte mascara = Convert.ToByte(Math.Pow(2, posicion));
            return (numero & mascara) != 0;
        }

        /// <summary>
        /// Extrae un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos extraer el bit</param>
        /// <param name="posicion">Posición del bit a extraer</param>
        /// <returns>Booleano con el valor del bit extraido</returns>
        public static bool GetBit(ushort numero, int posicion)
        {
            UInt16 mascara = Convert.ToUInt16(Math.Pow(2, posicion));
            return (numero & mascara) != 0;
        }

        /// <summary>
        /// Extrae un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos extraer el bit</param>
        /// <param name="posicion">Posición del bit a extraer</param>
        /// <returns>Booleano con el valor del bit extraido</returns>
        public static bool GetBit(uint numero, int posicion)
        {
            uint mascara = Convert.ToUInt32(Math.Pow(2, posicion));
            return (numero & mascara) != 0;
        }

        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static void SetBit(ref byte numero, int posicion, bool valor)
        {
            byte mascara = Convert.ToByte(Math.Pow(2, posicion));
            if (valor)
            {
                numero = (byte)(numero | mascara);
            }
            else
            {
                numero = (byte)(numero & ~mascara);
            }
        }

        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static void SetBit(ref ushort numero, int posicion, bool valor)
        {
            ushort mascara = Convert.ToUInt16(Math.Pow(2, posicion));
            if (valor)
            {
                numero = (ushort)(numero | mascara);
            }
            else
            {
                numero = (ushort)(numero & ~mascara);
            }
        }

        /// <summary>
        /// Establece un bit en la posición indicada
        /// </summary>
        /// <param name="numero">Valor al cual queremos establecer el bit</param>
        /// <param name="posicion">Posición del bit a establecer</param>
        /// <param name="valor">Booleano con el valor del bit a establecer</param>
        public static void SetBit(ref uint numero, int posicion, bool valor)
        {
            uint mascara = Convert.ToUInt32(Math.Pow(2, posicion));
            if (valor)
            {
                numero = (uint)(numero | mascara);
            }
            else
            {
                numero = (uint)(numero & ~mascara);
            }
        }
        #endregion

        #region Trabajo seguro con variables
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static bool ValidarTexto(object valor, string codigo, int maxLength, bool admiteVacio, bool lanzarExcepcionSiValorNoValido)
        {
            EstadoTexto estado = EstadoTexto.ResultadoCorrecto;
            bool valido = true;

            if (valido)
            {
                if (!(valor is string))
                {
                    estado = EstadoTexto.ValorNoString;
                    valido = false;
                }
            }

            if (valido)
            {
                string strValor = (string)valor;
                if (strValor.Length > maxLength)
                {
                    estado = EstadoTexto.LongitudSobrepasada;
                    valido = false;
                }
            }

            if (valido)
            {
                string strValor = (string)valor;
                if (!admiteVacio && (strValor == string.Empty))
                {
                    estado = EstadoTexto.CadenaVacia;
                    valido = false;
                }
            }

            if (lanzarExcepcionSiValorNoValido && !valido)
            {
                OVisionProUtiles.LanzarExcepcionTexto(estado, codigo);
            }

            return valido;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        private static void LanzarExcepcionTexto(EstadoTexto resultado, string codigo)
        {
            switch (resultado)
            {
                case EstadoTexto.ValorNoString:
                    throw new Exception("El campo " + codigo + " no es válido.");
                    break;
                case EstadoTexto.LongitudSobrepasada:
                    throw new Exception("El campo " + codigo + " es demasiado largo.");
                    break;
                case EstadoTexto.CadenaVacia:
                    throw new Exception("El campo " + codigo + " no puede estar en blanco.");
                    break;
            }
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static bool ValidarEntero(object valor, string codigo, int minValue, int maxValue, bool lanzarExcepcionSiValorNoValido)
        {
            EstadoEntero estado = EstadoEntero.ResultadoCorrecto;
            bool valido = true;

            if (valido)
            {
                if (!OVisionProUtiles.IsNumericInt(valor))
                {
                    estado = EstadoEntero.ValorNoEntero;
                    valido = false;
                }
            }

            if (valido)
            {
                int intValor = Convert.ToInt32(valor);
                if (intValor < minValue)
                {
                    estado = EstadoEntero.ValorInferiorMinimo;
                    valido = false;
                }
            }

            if (valido)
            {
                int intValor = Convert.ToInt32(valor);
                if (intValor > maxValue)
                {
                    estado = EstadoEntero.ValorSuperiorMaximo;
                    valido = false;
                }
            }

            if (lanzarExcepcionSiValorNoValido && !valido)
            {
                OVisionProUtiles.LanzarExcepcionEntero(estado, codigo, minValue, maxValue);
            }

            return valido;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        private static void LanzarExcepcionEntero(EstadoEntero resultado, string codigo, int minValue, int maxValue)
        {
            switch (resultado)
            {
                case EstadoEntero.ValorNoEntero:
                    throw new Exception("El campo " + codigo + " no es un número entero.");
                    break;
                case EstadoEntero.ValorInferiorMinimo:
                    throw new Exception("El campo " + codigo + " es inferior al mínimo " + minValue.ToString() + ".");
                    break;
                case EstadoEntero.ValorSuperiorMaximo:
                    throw new Exception("El campo " + codigo + " es superior al máximo " + maxValue.ToString() + ".");
                    break;
            }
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="valor">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static bool ValidarDecimal(object valor, string codigo, double minValue, double maxValue, bool lanzarExcepcionSiValorNoValido)
        {
            EstadoDecimal estado = EstadoDecimal.ResultadoCorrecto;
            bool valido = true;

            if (valido)
            {
                if (!OVisionProUtiles.IsNumericFloat(valor))
                {
                    estado = EstadoDecimal.ValorNoDecimal;
                    valido = false;
                }
            }

            if (valido)
            {
                double intValor = Convert.ToDouble(valor);
                if (intValor < minValue)
                {
                    estado = EstadoDecimal.ValorInferiorMinimo;
                    valido = false;
                }
            }

            if (valido)
            {
                double intValor = Convert.ToDouble(valor);
                if (intValor > maxValue)
                {
                    estado = EstadoDecimal.ValorSuperiorMaximo;
                    valido = false;
                }
            }

            if (lanzarExcepcionSiValorNoValido && !valido)
            {
                OVisionProUtiles.LanzarExcepcionDecimal(estado, codigo, minValue, maxValue);
            }

            return valido;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        private static void LanzarExcepcionDecimal(EstadoDecimal resultado, string codigo, double minValue, double maxValue)
        {
            switch (resultado)
            {
                case EstadoDecimal.ValorNoDecimal:
                    throw new Exception("El campo " + codigo + " no es un número decimal.");
                    break;
                case EstadoDecimal.ValorInferiorMinimo:
                    throw new Exception("El campo " + codigo + " es inferior al mínimo " + minValue.ToString() + ".");
                    break;
                case EstadoDecimal.ValorSuperiorMaximo:
                    throw new Exception("El campo " + codigo + " es superior al máximo " + maxValue.ToString() + ".");
                    break;
            }
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="value">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static bool ValidarEnum<T>(object valor, string codigo, bool lanzarExcepcionSiValorNoValido)
        {
            EstadoEnum estado = EstadoEnum.ValorNoEnumerado;
            bool valido = false;

            if (!valido)
            {
                if ((valor is T) && (typeof(T).IsEnum))
                {
                    estado = EstadoEnum.ResultadoCorrecto;
                    valido = true;
                }
            }

            if (!valido)
            {
                if (valor is string)
                {
                    string strValor = (string)valor;
                    try
                    {
                        T tValor = (T)Enum.Parse(typeof(T), strValor);
                        estado = EstadoEnum.ResultadoCorrecto;
                        valido = true;
                    }
                    catch
                    {
                        estado = EstadoEnum.ValorNoPermitido;
                        valido = false;
                    }
                }
            }

            if (!valido)
            {
                if (OVisionProUtiles.IsNumericInt(valor))
                {
                    try
                    {
                        T tValor = (T)valor;
                        estado = EstadoEnum.ResultadoCorrecto;
                        valido = true;
                    }
                    catch
                    {
                        estado = EstadoEnum.ValorNoPermitido;
                        valido = false;
                    }
                }
            }

            if (lanzarExcepcionSiValorNoValido && !valido)
            {
                OVisionProUtiles.LanzarExcepcionEnum(estado, codigo);
            }

            return valido;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        private static void LanzarExcepcionEnum(EstadoEnum resultado, string codigo)
        {
            switch (resultado)
            {
                case EstadoEnum.ValorNoEnumerado:
                    throw new Exception("El campo " + codigo + " no es válido.");
                    break;
                case EstadoEnum.ValorNoPermitido:
                    throw new Exception("El campo " + codigo + " no está permitido.");
                    break;
            }
        }
        /// <summary>
        /// Comprueba que el valor del objeto es correcto
        /// </summary>
        /// <param name="value">Valor del objeto a comprobar</param>
        /// <returns>Verdadero si el valor es correcto</returns>
        public static bool ValidarFechaHora(object valor, string codigo, DateTime minValue, DateTime maxValue, bool lanzarExcepcionSiValorNoValido)
        {
            EstadoFechaHora estado = EstadoFechaHora.ResultadoCorrecto;
            bool valido = true;

            if (valido)
            {
                if (!(valor is DateTime))
                {
                    estado = EstadoFechaHora.ValorNoFecha;
                    valido = false;
                }
            }

            if (valido)
            {
                DateTime datetimeValor = (DateTime)valor;
                if (datetimeValor < minValue)
                {
                    estado = EstadoFechaHora.ValorInferiorMinimo;
                    valido = false;
                }
            }

            if (valido)
            {
                DateTime datetimeValor = (DateTime)valor;
                if (datetimeValor > maxValue)
                {
                    estado = EstadoFechaHora.ValorSuperiorMaximo;
                    valido = false;
                }
            }

            if (lanzarExcepcionSiValorNoValido && !valido)
            {
                OVisionProUtiles.LanzarExcepcionFechaHora(estado, codigo, minValue, maxValue);
            }

            return valido;
        }
        /// <summary>
        /// Lanza una exepción por no estár permitido el valor especificado
        /// </summary>
        /// <param name="value">valor no permitido</param>
        private static void LanzarExcepcionFechaHora(EstadoFechaHora resultado, string codigo, DateTime minValue, DateTime maxValue)
        {
            switch (resultado)
            {
                case EstadoFechaHora.ValorNoFecha:
                    throw new Exception("El campo " + codigo + " no es una fecha válida.");
                    break;
                case EstadoFechaHora.ValorInferiorMinimo:
                    throw new Exception("El campo " + codigo + " es inferior al mínimo " + minValue.ToString() + ".");
                    break;
                case EstadoFechaHora.ValorSuperiorMaximo:
                    throw new Exception("El campo " + codigo + " es superior al máximo " + maxValue.ToString() + ".");
                    break;
            }
        }
        /// <summary>
        /// Convierte un objeto a string
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string ToString(object valor)
        {
            return valor != null ? valor.ToString() : string.Empty;
        }
        /// <summary>
        /// Realiza una comparación entre dos objetos
        /// </summary>
        /// <param name="valor1">Primer objeto a comparar</param>
        /// <param name="valor2">Segundo objeto a comparar</param>
        /// <returns></returns>
        public static bool CompararObjetos(object valor1, object valor2)
        {
            bool resultado = false;

            if ((valor1 == null) && (valor2 == null))
            {
                // Ambos son null
                return true;
            }

            if ((valor1 != null) && (valor2 != null))
            {
                if (valor1.GetType() != valor2.GetType())
                {
                    // No son del mismo tipo
                    return false;
                }

                if (valor1 is byte[])
                {
                    byte[] valorByte1 = (byte[])valor1;
                    byte[] valorByte2 = (byte[])valor2;

                    if (valorByte1.Length != valorByte2.Length)
                    {
                        // No tienen la misma longitud
                        return false;
                    }

                    for (int i = 0; i < valorByte1.Length; i++)
                    {
                        if (valorByte1[i] != valorByte2[i])
                        {
                            // Tienen algun valor distinto
                            return false;
                        }
                    }

                    // Los arrays son iguales
                    return true;
                }

                return valor1.Equals(valor2);
            }

            return resultado;
        }

        #region Enumerados
        /// <summary>
        /// Resultado de la validación del texto
        /// </summary>
        private enum EstadoTexto
        {
            /// <summary>
            /// Resultado correcto
            /// </summary>
            ResultadoCorrecto = 0,
            /// <summary>
            /// El valor a asignar no es string
            /// </summary>
            ValorNoString = 1,
            /// <summary>
            /// La longitud del texto es demasiado larga
            /// </summary>
            LongitudSobrepasada = 2,
            /// <summary>
            /// El texto no contiene ningun caracter
            /// </summary>
            CadenaVacia = 3
        }
        /// <summary>
        /// Resultado de la validación del Entero
        /// </summary>
        private enum EstadoEntero
        {
            /// <summary>
            /// Resultado correcto
            /// </summary>
            ResultadoCorrecto = 0,
            /// <summary>
            /// El valor a asignar no es entero
            /// </summary>
            ValorNoEntero = 1,
            /// <summary>
            /// El valor a asignar es sueprior al máximo permitido
            /// </summary>
            ValorSuperiorMaximo = 2,
            /// <summary>
            /// El valor a asignar es inferior al mínimo permitido
            /// </summary>
            ValorInferiorMinimo = 3
        }
        /// <summary>
        /// Resultado de la validación del Decimal
        /// </summary>
        private enum EstadoDecimal
        {
            /// <summary>
            /// Resultado correcto
            /// </summary>
            ResultadoCorrecto = 0,
            /// <summary>
            /// El valor a asignar no es entero
            /// </summary>
            ValorNoDecimal = 1,
            /// <summary>
            /// El valor a asignar es sueprior al máximo permitido
            /// </summary>
            ValorSuperiorMaximo = 2,
            /// <summary>
            /// El valor a asignar es inferior al mínimo permitido
            /// </summary>
            ValorInferiorMinimo = 3
        }
        /// <summary>
        /// Resultado de la validación del enumerado
        /// </summary>
        private enum EstadoEnum
        {
            /// <summary>
            /// Resultado correcto
            /// </summary>
            ResultadoCorrecto = 0,
            /// <summary>
            /// El valor a asignar no es enumerado
            /// </summary>
            ValorNoEnumerado = 1,
            /// <summary>
            /// El valor a asignar no está permitido
            /// </summary>
            ValorNoPermitido = 2
        }
        /// <summary>
        /// Resultado de la validación del DateTimne
        /// </summary>
        private enum EstadoFechaHora
        {
            /// <summary>
            /// Resultado correcto
            /// </summary>
            ResultadoCorrecto = 0,
            /// <summary>
            /// El valor a asignar no es entero
            /// </summary>
            ValorNoFecha = 1,
            /// <summary>
            /// El valor a asignar es sueprior al máximo permitido
            /// </summary>
            ValorSuperiorMaximo = 2,
            /// <summary>
            /// El valor a asignar es inferior al mínimo permitido
            /// </summary>
            ValorInferiorMinimo = 3
        }
        #endregion

        #endregion

        #region Esperas

        /// <summary>
        /// Método que realiza una espera (sin parar la ejecución del sistema) de cierto tiempo en milisegundos
        /// </summary>
        /// <param name="timeOut">Tiempo de espera en milisegundos</param>
        public static void Espera(int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            while (DateTime.Now < momentoTimeOut)
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Método que realiza una espera hasta que cierto valor sea verdadero durante un máximo de tiempo
        /// </summary>
        /// <param name="valor">Valor al cual se espera que su estado sea verdadero o falso</param>
        /// <param name="valorEsperado">Valor de comparación</param>
        /// <param name="timeOut">Tiempo máximo de la espera en milisegundos</param>
        /// <returns>Verdadero si el valor a cambiado a verdadero antes de que finalizase el TimeOut</returns>
        public static bool Espera(ref bool valor, bool valorEsperado, int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            while ((valor != valorEsperado) && (DateTime.Now < momentoTimeOut))
            {
                Application.DoEvents();
            }

            return valor == valorEsperado;
        }

        /// <summary>
        /// Método que realiza una espera hasta que cierto valor sea verdadero durante un máximo de tiempo
        /// </summary>
        /// <param name="valor">Valor al cual se espera que su estado sea verdadero o falso</param>
        /// <param name="valorEsperado">Valor de comparación</param>
        /// <param name="timeOut">Tiempo máximo de la espera en milisegundos</param>
        /// <returns>Verdadero si el valor a cambiado a verdadero antes de que finalizase el TimeOut</returns>
        public static bool Espera(ref object valor, object valorEsperado, int timeOut)
        {
            // Momento en el que finalizará la espera
            DateTime momentoTimeOut = DateTime.Now.AddMilliseconds(timeOut);

            while ((valor != valorEsperado) && (DateTime.Now < momentoTimeOut))
            {
                Application.DoEvents();
            }

            return valor == valorEsperado;
        }
        #endregion

        #region Arrays
        /// <summary>
        /// Función para redimiendionar un Array
        /// </summary>
        /// <param name="orgArray">Array</param>
        /// <param name="tamaño">Tamaño</param>
        /// <returns>Array redimensionado</returns>

        public static Array aRedimensionar(Array orgArray, Int32 tamaño)
        {
            Type t = orgArray.GetType().GetElementType();
            Array nArray = Array.CreateInstance(t, tamaño);
            Array.Copy(orgArray, 0, nArray, 0, Math.Min(orgArray.Length, tamaño));
            return nArray;
        }
        #endregion        

        #region Matemáticas
        /// <summary>
        /// Convierte un ángulo de grados a radianes
        /// </summary>
        /// <param name="angle">Ángulo en grados</param>
        /// <returns>Ángulo en radianes</returns>
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        /// <summary>
        /// Convierte un ángulo de radianes a grados
        /// </summary>
        /// <param name="angle">Ángulo en radianes</param>
        /// <returns>Ángulo en grados</returns>
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
        #endregion          

        #region Delegados genéricos
        /// <summary>
        /// Delegado de método simple
        /// </summary>
        public delegate void SimpleMethod();
        #endregion

        #region Trabajo con fechas
        /// <summary>
        /// Conversión de día gregocriano a juliano
        /// </summary>
        /// <param name="dia">Día</param>
        /// <param name="mes">Mes</param>
        /// <param name="anno">Año</param>
        /// <returns></returns>
        public static long GregorianoAJuliano(int dia, int mes, int anno)
        {
            //dada una fecha del calendario gregoriano, obtiene
            //un entero que la representa
            long tmes, tanno;
            long jdia;
            //marzo es el mes 0 del año
            if (mes > 2)
            {
                tmes = mes - 3;
                tanno = anno;
            }
            else
            //febrero es el mes 11 del año anterior.
            {
                tmes = mes + 9;
                tanno = anno - 1;
            }
            jdia = (tanno / 4000) * 1460969;
            tanno = (tanno % 4000);
            jdia = jdia +
               (((tanno / 100) * 146097) / 4) +
               (((tanno % 100) * 1461) / 4) +
               (((153 * tmes) + 2) / 5) +
               dia +
               1721119;
            return jdia;
        }

        /// <summary>
        /// Conversión de dia juliano a gregoriano
        /// </summary>
        /// <param name="jdia">Día juliano</param>
        /// <returns>Fecha gregoriana</returns>
        public static DateTime JulianoAGregoriano(long jdia)
        {
            long anno, mes, dia;
            long tmp1, tmp2;
            tmp1 = jdia - 1721119;
            anno = ((tmp1 - 1) / 1460969) * 4000;
            tmp1 = ((tmp1 - 1) % 1460969) + 1;
            tmp1 = (4 * tmp1) - 1;
            tmp2 = (4 * ((tmp1 % 146097) / 4)) + 3;
            anno = (100 * (tmp1 / 146097)) + (tmp2 / 1461) + anno;
            tmp1 = (5 * (((tmp2 % 1461) + 4) / 4)) - 3;
            mes = tmp1 / 153;
            dia = ((tmp1 % 153) + 5) / 5;
            if (mes < 10)
                mes = mes + 3;
            else
            {
                mes = mes - 9;
                anno = anno + 1;
            }
            return new DateTime((int)anno, (int)mes, (int)dia);
        }
        #endregion
        #endregion

        #region Utilidades VisionPro 
        /// <summary>
        /// Para Visualizar en otra ventana
        /// </summary>
        /// <param name="graficos"></param>
        /// <returns></returns>
        public static void Visualizacion(ICogImage imagen, CogGraphicCollection graficos, int indice)
        {
            Form mainForm = Application.OpenForms[indice];

            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new DelegadoVisualizacion(Visualizacion), imagen, graficos, indice);
                return;
            }

            Form form = new Form();
            CogDisplay display = new CogDisplay();
            form.Controls.Add(display);
            display.Dock = DockStyle.Fill;

            form.Show();

            display.DrawingEnabled = false;
            display.StaticGraphics.Clear();
            display.Image = imagen;
            display.Fit(true);

            display.StaticGraphics.AddList(graficos, "features");
            display.DrawingEnabled = true;
        }
        /// <summary>
        /// Función para obtener el angulo y la distancia de un blob pasado en la imagen  a un punto
        /// </summary>
        /// <param name="imagen">imagen de un único blob</param>
        /// <param name="centerX">X del blob</param>
        /// <param name="centerY">Y del blob</param>
        /// <param name="angulo">angulo respecto al origen</param>
        /// <param name="distancia">distancia respecto al origen</param>
        /// <returns></returns>
        public static void ObtenerAnguloDistanciaBlobAPunto(CogImage8Grey imagen, double origenX, double origenY, double centerBlobX, double centerBlobY, ref double angulo, ref double distancia)
        {
            // Creamos una herramienta que nos permita realizar los cálculos comodamente
            CogDistancePointPointTool medidorAnguloBlob = new CogDistancePointPointTool();
            // Le pasamos la imagen
            medidorAnguloBlob.InputImage = imagen;

            // el punto origen es el centro de la barqueta
            medidorAnguloBlob.StartX = origenX;
            medidorAnguloBlob.StartY = origenY;
            // y el punto destino es el centro del blob encontrado
            medidorAnguloBlob.EndX = centerBlobX;
            medidorAnguloBlob.EndY = centerBlobY;
            // Ejecutamos la herramienta
            medidorAnguloBlob.Run();
            //devolvemos el angulo en grados y la distancia calculada   
            angulo = (medidorAnguloBlob.Angle * 360) / (2 * 3.14);
            distancia = medidorAnguloBlob.Distance;
            // Eliminamos la herramienta creada
            medidorAnguloBlob.Dispose();
        }
        /// <summary>
        /// Para añadir label al conjunto de gráficos
        /// </summary>
        /// <param name="posx">X</param>
        /// <param name="posy">Y</param>
        /// <param name="textoSi">Texto si bueno</param>
        /// <param name="textoNo">Texto si malo</param>
        /// <param name="buena">bueno o malo</param>
        /// <param name="tamSi">Tamaño si bueno</param>
        /// <param name="tamNo">Tamaño si malo</param>
        /// <param name="estiloSi">Estilo si bueno</param>
        /// <param name="estiloNo">Estilo si malo</param>
        /// <param name="alineacion">alineacion</param>
        /// <param name="coleccionGrafica">coleccionGrafica a la que añade la etiqueta</param>
        /// <returns></returns>
        public static void AnyadeEtiqueta(int posx, int posy, string textoSi, string textoNo, bool buena,
            int tamSi, int tamNo, System.Drawing.FontStyle estiloSi,
            System.Drawing.FontStyle estiloNo, CogGraphicLabelAlignmentConstants alineacion, ref CogGraphicCollection coleccionGrafica)
        {
            CogGraphicLabel label = new CogGraphicLabel();
            string texto;
            int tam;
            System.Drawing.FontStyle estilo;

            if (buena)
            {
                texto = textoSi;
                tam = tamSi;
                estilo = estiloSi;
                label.Color = Cognex.VisionPro.CogColorConstants.Green;
            }
            else
            {
                texto = textoNo;
                tam = tamNo;
                estilo = estiloNo;
                label.Color = Cognex.VisionPro.CogColorConstants.Red;
            }
            label.Alignment = alineacion;
            label.Font = new Font("Arial", tam, estilo, System.Drawing.GraphicsUnit.Point);
            label.SetXYText(posx, posy, texto);
            label.SelectedSpaceName = @"#";
            coleccionGrafica.Add((ICogGraphic)label);
        }
        /// <summary>
        /// Ejecutamos todos los patrones pasados y devolvemos una lista con los resultados
        /// </summary>
        /// <returns></returns>
        public static void EjecutarPatrones(ref string message, ref CogToolResultConstants result, ref List<ResultadoPatMax> resultadosPatmax, CogToolCollection Tools, CogImage8Grey imagen, ref CogGraphicCollection graficos)
        {
            // Ejecucion todos los patrones
            foreach (ICogTool tool in Tools)
            {
                if (tool is CogPMAlignTool)
                {
                    ExecutePatMax(ref message, ref result, (CogPMAlignTool)tool, imagen, tool.Name, ref resultadosPatmax,ref graficos);
                }
            }
        }
        /// <summary>
        /// Ejecutamos todos los patrones pasados y devolvemos una lista con los resultados , y si no esta entrenado el patrón lo entrena
        /// </summary>
        /// <returns></returns>
        public static void EjecutarPatrones(ref string message, ref CogToolResultConstants result, ref List<ResultadoPatMax> resultadosPatmax, CogToolCollection Tools, CogImage8Grey imagen, ref CogGraphicCollection graficos, bool activoTrain)
        {
            // Ejecucion todos los patrones
            foreach (ICogTool tool in Tools)
            {
                if (tool is CogPMAlignTool)
                {
                    //Revisar: Si por lo que sea no esta entrenado, por parámetro
                    if (activoTrain && !((CogPMAlignTool)tool).Pattern.Trained)
                    {
                        ((CogPMAlignTool)tool).Pattern.Train();
                    }
                    ExecutePatMax(ref message, ref result, (CogPMAlignTool)tool, imagen, tool.Name, ref resultadosPatmax, ref graficos);
                }
            }
        }
        /// <summary>
        /// Ejecución de la herramienta patmax
        /// </summary>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <param name="patmax"></param>
        /// <param name="image"></param>
        /// <param name="patMaxResults"></param>
        /// <returns>true si encuentra algo</returns>
        public static bool ExecutePatMax(ref string message, ref CogToolResultConstants result, CogPMAlignTool patmax, ICogImage image, string cadenaGrupo, ref List<ResultadoPatMax> resultados,ref CogGraphicCollection graficos)
        {
            patmax.InputImage = (CogImage8Grey)image;
            ToolBlock.RunTool(patmax, ref message, ref result);
            foreach (CogPMAlignResult PMAlignResult in patmax.Results)
            {
                ResultadoPatMax resultado = new ResultadoPatMax(PMAlignResult, cadenaGrupo);
                resultados.Add(resultado);
                graficos.Add(PMAlignResult.CreateResultGraphics(CogPMAlignResultGraphicConstants.All));
            }
            return (patmax.Results.Count != 0);
        }
        #endregion
    }
    #endregion

    #region Trabajo con colecciones
    /// <summary>
    /// Clase utilizada para almacenar un par de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    [Serializable]
    public class OPair<TFirst, TSecond>
    {
        #region Campos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPair()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OPair(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un trío de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    [Serializable]
    public class OTriplet<TFirst, TSecond, TThird>
    {
        #region Campos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTriplet()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTriplet(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un trío de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    [Serializable]
    public class OQuartet<TFirst, TSecond, TThird, TFourth>
    {
        #region Campos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuartet()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuartet(TFirst first, TSecond second, TThird third, TFourth fourth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para almacenar un trío de valores
    /// </summary>
    /// <typeparam name="TFirst">Tipo del primer valor</typeparam>
    /// <typeparam name="TSecond">Tipo del segundo valor</typeparam>
    /// <typeparam name="TThird">Tipo del tercer valor</typeparam>
    /// <typeparam name="TFourth">Tipo del cuarto valor</typeparam>
    /// <typeparam name="TFifth">Tipo del quinto valor</typeparam>
    [Serializable]
    public class OQuintet<TFirst, TSecond, TThird, TFourth, TFifth>
    {
        #region Campos
        /// <summary>
        /// Primer valor
        /// </summary>
        public TFirst First;
        /// <summary>
        /// Segundo valor
        /// </summary>
        public TSecond Second;
        /// <summary>
        /// Tercer valor
        /// </summary>
        public TThird Third;
        /// <summary>
        /// Cuarto valor
        /// </summary>
        public TFourth Fourth;
        /// <summary>
        /// Quinto valor
        /// </summary>
        public TFifth Fifth;
        #endregion

        #region Constructor de la clase
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuintet()
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OQuintet(TFirst first, TSecond second, TThird third, TFourth fourth, TFifth fifth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
            this.Fifth = fifth;
        }
        #endregion
    }

    #endregion

    #region Clase Enumerado: Implementa un enumerado con posibilidad de herencia
    /// <summary>
    /// Clase que agrupa a un conjunto de enumerados
    /// </summary>
    [Serializable]
    public class Enumerados
    {
        #region Campos
        /// <summary>
        /// Lista de los enumerados que contiene
        /// </summary>
        public List<Enumerado> ListaEnumerados;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Enumerados()
        {
            this.ListaEnumerados = new List<Enumerado>();

            Type tipo = this.GetType();

            while (tipo != typeof(Enumerados))
            {
                FieldInfo[] fields = tipo.GetFields();
                foreach (FieldInfo fieldInfo in fields)
                {
                    if (fieldInfo.IsStatic)
                    {
                        object valor = fieldInfo.GetValue(null);
                        if (valor is Enumerado)
                        {
                            this.ListaEnumerados.Add((Enumerado)valor);
                        }
                    }
                }
                tipo = tipo.BaseType;
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public T Parse<T>(string nombre)
            where T : Enumerado
        {
            T resultado = null;

            foreach (Enumerado enumerado in this.ListaEnumerados)
            {
                if (enumerado.Nombre == nombre)
                {
                    return (T)enumerado;
                }
            }

            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public T Parse<T>(int valor)
            where T : Enumerado
        {
            T resultado = null;

            foreach (Enumerado enumerado in this.ListaEnumerados)
            {
                if (enumerado.Valor == valor)
                {
                    return (T)enumerado;
                }
            }

            return resultado;
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para permitir la herencia de enumerados
    /// </summary>
    [Serializable]
    public class Enumerado
    {
        #region Campos
        /// <summary>
        /// Nombre del enumerado
        /// </summary>
        public string Nombre;
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion;
        /// <summary>
        /// Valor del enumerado
        /// </summary>
        public int Valor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Enumerado(string nombre, string descripcion, int valor)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Valor = valor;
        }
        #endregion
    }
    #endregion

    #region Clase ResultadoPatmax: Implementa el resultado del Patmax con texto asociado
    /// <summary>
    /// Clase para añadir un string aclaratorio a cada resultado
    /// </summary>
    [Serializable]
    public class ResultadoPatMax
    {
        #region Campos
        /// <summary>
        /// Resultado Patmax
        /// </summary>
        public CogPMAlignResult ResultPatmax;
        /// <summary>
        /// CadenaResultado
        /// </summary>
        public string CadenaResultado;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public ResultadoPatMax()
        {
            this.ResultPatmax = new CogPMAlignResult();
            this.CadenaResultado = string.Empty;
        }
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="cadena"></param>
        public ResultadoPatMax(CogPMAlignResult resultado, string cadena)
        {
            this.ResultPatmax = resultado;
            this.CadenaResultado = cadena;
        }
        #endregion
    }
    #endregion
}
