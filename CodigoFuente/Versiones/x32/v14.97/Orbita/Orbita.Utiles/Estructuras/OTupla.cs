//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 24/02/2014
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Orbita.Utiles
{
    /// <summary>
    /// Dato compuesto que posibilita el acceso a sus registros mediante su código o de forma indexada.
    /// También permite la conversión a y desde cadenas de texto. Idóneo para almacenar información en bases de dato o ficheros de texto.
    /// </summary>
    public class OTupla : IEnumerable
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de valores contenidos en la tupla
        /// </summary>
        private Dictionary<string, object> ListaValores;

        /// <summary>
        /// Caracter separador. Por defecto ';'
        /// </summary>
        private char Separador = ';';
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Descripción del contenido de la tupla
        /// </summary>
        private string _Significado;
        /// <summary>
        /// Descripción del contenido de la tupla
        /// </summary>
        public string Significado
        {
            get { return _Significado; }
            set { _Significado = value; }
        }

        /// <summary>
        /// Acceso a valores por índice
        /// </summary>
        /// <param name="index">Índice del parámetro</param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                return this.ListaValores.Values.Select(c => c).ToList()[index];
            }
            set
            {
                this.ListaValores.Values.Select(c => c).ToList()[index] = value;
            }
        }
        /// <summary>
        /// Acceso a valores por código
        /// </summary>
        /// <param name="codigo">Código del parámetro</param>
        /// <returns></returns>
        public object this[string codigo]
        {
            get
            {
                return this.ListaValores[codigo];
            }
            set
            {
                this.ListaValores[codigo] = value;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTupla(char separador = ';')
        {
            this.ListaValores = new Dictionary<string, object>();
            this.Separador = separador;
            this.Significado = "Tupla";
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTupla(string significado, string codigosValores, char separador = ';')
        {
            this.ListaValores = new Dictionary<string, object>();
            this.Separador = separador;
            this.Significado = significado;

            string[] strArray = codigosValores.Split(separador);
            foreach (string str in strArray)
            {
                if (str.Length > 1)
                {
                    KeyValuePair<string, object> kvp = this.ConvertirCodigoValorDeString(str);
                    this.ListaValores[kvp.Key] = kvp.Value;
                }
            }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OTupla(string significado, string codigos, string valores, char separador = ';')
        {
            this.ListaValores = new Dictionary<string, object>();
            this.Separador = separador;
            this.Significado = significado;

            string[] strArrayCodigos = codigos.Split(separador);
            string[] strArrayValores = valores.Split(separador);

            if (strArrayCodigos.Length == strArrayValores.Length)
            {
                for (int i = 0; i < strArrayCodigos.Length; i++)
                {
                    if ((strArrayCodigos[i].Length > 0) && (strArrayValores[i].Length > 0))
                    {
                        string key = strArrayCodigos[i];
                        object value = this.ConvertirValorDeString(strArrayValores[i]);

                        this.ListaValores[key] = value;
                    }
                }

            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Conversión a string de la pareja codigo-valor
        /// </summary>
        /// <returns></returns>
        private string ConvertirCodigoValorAString(KeyValuePair<string, object> valor)
        {
            return string.Format("{0}={1}", ConvertirCodigoAString(valor), ConvertirValorAString(valor));
        }

        /// <summary>
        /// Conversión a string de un codigo
        /// </summary>
        /// <returns></returns>
        private string ConvertirCodigoAString(KeyValuePair<string, object> valor)
        {
            return valor.Key;
        }

        /// <summary>
        /// Conversión a string de un valor
        /// </summary>
        /// <returns></returns>
        private string ConvertirValorAString(KeyValuePair<string, object> valor)
        {
            string resultado = string.Empty;

            if ((valor.Value is int) || (valor.Value is uint) || (valor.Value is short) || (valor.Value is ushort) || (valor.Value is byte))
            {
                resultado = valor.Value.ToString();
            }
            if ((valor.Value is long) || (valor.Value is ulong))
            {
                resultado = valor.Value.ToString() + "L";
            }
            else if ((valor.Value is double) || (valor.Value is float))
            {
                resultado = ((double)valor.Value).ToString(CultureInfo.InvariantCulture) + "D";
            }
            else if (valor.Value is string)
            {
                resultado = "\"" + valor.Value.ToString() + "\"";
            }
            else if (valor.Value is DateTime)
            {
                resultado = ((DateTime)valor.Value).ToString(CultureInfo.InvariantCulture) + "T";
            }
            else if (valor.Value is bool)
            {
                resultado = valor.Value.ToString();
            }

            return resultado;
        }

        /// <summary>
        /// Conversión desde string una pareja codigo-valor
        /// </summary>
        /// <returns></returns>
        private KeyValuePair<string, object> ConvertirCodigoValorDeString(string valor)
        {
            string key = string.Empty;
            object value = null;

            string[] strArray = valor.Split('=');
            if (strArray.Length == 2)
            {
                key = strArray[0];
                value = this.ConvertirValorDeString(strArray[1]);
            }

            return new KeyValuePair<string, object>(key, value);
        }

        /// <summary>
        /// Conversión desde string un valor
        /// </summary>
        /// <returns></returns>
        private object ConvertirValorDeString(string valor)
        {
            object resultado = null;
            Regex rgx;

            // Int
            rgx = new Regex(@"^-{0,1}[0-9]{1,}$");
            if (rgx.IsMatch(valor))
            {
                return OEntero.Validar(valor, int.MinValue, int.MaxValue, CultureInfo.InvariantCulture, default(int));
            }
            else
            {
                // Long
                rgx = new Regex(@"^-{0,1}[0-9]{1,}[Ll]$");
                if (rgx.IsMatch(valor))
                {
                    string valorNumero = valor.Substring(0, valor.Length - 1);
                    return OEnteroLargo.Validar(valorNumero, long.MinValue, long.MaxValue, CultureInfo.InvariantCulture, default(long));
                }
                else
                {
                    // Double
                    rgx = new Regex(@"^-{0,1}[0-9.]{1,}[Dd]$");
                    if (rgx.IsMatch(valor))
                    {
                        string valorNumero = valor.Substring(0, valor.Length - 1);
                        return ODecimal.Validar(valorNumero, double.MinValue, double.MaxValue, CultureInfo.InvariantCulture, default(double));
                    }
                    else
                    {
                        // string
                        rgx = new Regex(@"^"".{0,}""$");
                        if (rgx.IsMatch(valor))
                        {
                            return valor.Substring(1, valor.Length - 2);
                        }
                        else
                        {
                            // DateTime
                            rgx = new Regex(@"^[0-9]{2}/[0-9]{2}/[0-9]{4} [0-9]{2}:[0-9]{2}:[0-9]{2}[Tt]$");
                            if (rgx.IsMatch(valor))
                            {
                                string valorNumero = valor.Substring(0, valor.Length - 1);
                                return OFechaHora.Validar(valorNumero, CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                // Bool
                                rgx = new Regex(@"^(?i)True$|^(?i)False$");
                                if (rgx.IsMatch(valor))
                                {
                                    return OBooleano.Validar(valor);
                                }
                            }
                        }
                    }
                }
            }

            return resultado;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Añade un valor a la tupla
        /// </summary>
        /// <param name="key">clave</param>
        /// <param name="value">valor</param>
        public void Add(string key, object value)
        {
            this.ListaValores[key] = value;
        }

        /// <summary>
        /// Conversión a string
        /// </summary>
        /// <returns>Cadena de la tupla convertida a string</returns>
        public override string ToString()
        {
            return ListaValores.Colection2String<KeyValuePair<string, object>>(this.Separador, this.ConvertirCodigoValorAString);
        }

        /// <summary>
        /// Conversión a string de los códigos
        /// </summary>
        /// <returns>Cadena de los códigos convertidos a string</returns>
        public string ToCodigoString()
        {
            return ListaValores.Colection2String<KeyValuePair<string, object>>(this.Separador, this.ConvertirCodigoAString);
        }

        /// <summary>
        /// Conversión a string de los valores
        /// </summary>
        /// <returns>Cadena de los valores convertidos a string</returns>
        public string ToValorString()
        {
            return ListaValores.Colection2String<KeyValuePair<string, object>>(this.Separador, this.ConvertirValorAString);
        }

        /// <summary>
        /// Devuelve un enumerador que recorre en iteración una colección.
        /// </summary>
        /// <returns>Objeto System.Collections.IEnumerator que se puede utilizar para recorrer
        /// en iteración la colección.</returns>
        public IEnumerator GetEnumerator()
        {
            return this.ListaValores.GetEnumerator();
        }
        #endregion
    }
}
