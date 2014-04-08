using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Orbita.Utiles
{
    /// <summary>
    /// Clase estática que extiende los métodos de las colecciones
    /// </summary>
    public static class OExtensionesColecciones
    {
        #region Diccionarios
        /// <summary>
        /// Añade items a un diccionario
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Diccionario"></param>
        /// <param name="Valores"></param>
        public static void AddRange<T, U>(this IDictionary<T, U> Diccionario, IEnumerable<KeyValuePair<T, U>> Valores)
        {
            foreach (var kvp in Valores)
            {
                Diccionario[kvp.Key] = kvp.Value;
            }
        } 
        #endregion

        #region Listas
        /// <summary>
        /// Convierte una colección en una cadena de texto
        /// </summary>
        /// <param name="coleccion">Colección que se desea convertir en texto</param>
        /// <param name="separador">Caracter separador de cada uno de los valores de la colección</param>
        /// <returns>Cadena de texto con todos los valores de la colección separados por el carácter separador</returns>
        public static string Colection2String(this ICollection coleccion, char separador)
        {
            string resultado = string.Empty;
            bool insertarSeparador = false;

            foreach (object valor in coleccion)
            {
                string str = OObjeto.ToString(valor);

                if (insertarSeparador)
                {
                    resultado += separador;
                }
                insertarSeparador = false;
                if (!string.IsNullOrEmpty(str))
                {
                    resultado += str;
                    insertarSeparador = true;
                }
            }

            return resultado;
        }
        /// <summary>
        /// Delegado para la conversión de cualquier tipo al tipo string
        /// </summary>
        /// <typeparam name="T">Tipo que se desea devolver</typeparam>
        /// <param name="value">Valor a convertir</param>
        /// <returns>Cadena de texto convertida</returns>
        public delegate string ConvertToString<T>(T value);
        /// <summary>
        /// Convierte una colección en una cadena de texto
        /// </summary>
        /// <typeparam name="T">Tipo que se desea convertir</typeparam>
        /// <param name="coleccion">Colección que se desea convertir en texto</param>
        /// <param name="separador">Caracter separador de cada uno de los valores de la colección</param>
        /// <returns>Cadena de texto con todos los valores de la colección separados por el carácter separador</returns>
        public static string Colection2String<T>(this ICollection<T> coleccion, char separador, ConvertToString<T> conversion)
        {
            string resultado = string.Empty;
            bool insertarSeparador = false;

            foreach (T valor in coleccion)
            {
                string str = conversion(valor);

                if (insertarSeparador)
                {
                    resultado += separador;
                }
                insertarSeparador = false;
                if (!string.IsNullOrEmpty(str))
                {
                    resultado += str;
                    insertarSeparador = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Delegado para la conversión del tipo string a cualquier tipo
        /// </summary>
        /// <typeparam name="T">Tipo que se desea devolver</typeparam>
        /// <param name="text">Cadena de texto a convertir</param>
        /// <returns>Valor resultante de la conversión</returns>
        public delegate T ConvertFromString<T>(string text);
        /// <summary>
        /// Convierte una cadena de texto en una colección
        /// </summary>
        /// <typeparam name="T">Tipo de colección que se desea devolver</typeparam>
        /// <param name="texto">Texto que se convertira en colección</param>
        /// <param name="separador">Caracter separador de cada uno de los valores de la colección</param>
        /// <returns>Objeto de tipo colección con todos los valores que contiene el texto separados por el carácter separador</returns>
        public static T String2Collection<T>(this string texto, char separador, ConvertFromString<T> conversion)
            where T : IList, new()
        {
            T resultado = new T();

            string[] strArray = texto.Split(separador);
            foreach (string strValue in strArray)
            {
                resultado.Add(conversion(strValue));
            }

            return resultado;
        }
        #endregion
    }
}
