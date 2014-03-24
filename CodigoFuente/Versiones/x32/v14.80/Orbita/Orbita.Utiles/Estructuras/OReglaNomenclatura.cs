//***********************************************************************
// Assembly         : Orbita.Utiles
// Author           : aibañez
// Created          : 02-09-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//                    
//                    
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Orbita.Utiles
{
    /// <summary>
    /// Clase con utilidades para la validación de nombres de clases ensamblados, propiedades...
    /// </summary>
    public static class OReglaNomenclaturaNet
    {
        #region Método(s) público(s)
        /// <summary>
        /// Valida si el nombre cumple las reglas de nomenclatura para clases, ensamblados, propiedades...
        /// </summary>
        /// <param name="valor">Nombre a validar</param>
        /// <returns>Verdadero si el nombre cumple las reglas de nomenclatura para clases, ensamblados, propiedades...</returns>
        public static bool ValidarNomenclaturaPropiedadNet(this string valor)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(valor))
            {
                Regex rgxFirst = new Regex(@"^[a-zA-Z_@]");
                bool inicioValido = rgxFirst.IsMatch(valor);

                valor = valor.Substring(1, valor.Length - 1);
                Regex rgxRest = new Regex(@"[^a-zA-Z0-9ñÑçÇ_]");
                bool restoValido = !rgxRest.IsMatch(valor);

                resultado = inicioValido && restoValido;

            }
            return resultado;
        }

        /// <summary>
        /// Valida si el nombre cumple las reglas de nomenclatura para clases, ensamblados, propiedades...
        /// </summary>
        /// <param name="valor">Nombre a validar</param>
        /// <returns>Verdadero si el nombre cumple las reglas de nomenclatura para clases, ensamblados, propiedades...</returns>
        public static bool ValidarNomenclaturaEnsambladoNet(this string valor)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(valor))
            {
                Regex rgx = new Regex(@"[/\\:*\?""<>|]");
                resultado = !rgx.IsMatch(valor);
            }
            return resultado;
        }

        /// <summary>
        /// Valida si el nombre cumple las reglas de nomenclatura para clases, ensamblados, propiedades...
        /// </summary>
        /// <param name="valor">Nombre a validar</param>
        /// <returns>Verdadero si el nombre cumple las reglas de nomenclatura para clases, ensamblados, propiedades...</returns>
        public static bool ValidarNomenclaturaEspacioNombresNet(this string valor)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(valor) && (valor.Length > 1))
            {
                Regex rgxFirst = new Regex(@"^[a-zA-Z_]");
                bool inicioValido = rgxFirst.IsMatch(valor);

                Regex rgxLast = new Regex(@"^z[a-zA-Z_]");
                bool finValido = rgxLast.IsMatch(valor);

                valor = valor.Substring(1, valor.Length - 2);
                Regex rgxRest = new Regex(@"[^a-zA-Z0-9ñÑçÇ_.]");
                bool restoValido = !rgxRest.IsMatch(valor);

                resultado = inicioValido && restoValido && finValido;

            }
            return resultado;
        } 
        #endregion
    }

    public class ONomenclaturaNetException: Exception
    {
        #region Atributo(s)
        /// <summary>
        /// Nombre que no es válido
        /// </summary>
        public string Nombre;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ONomenclaturaNetException():
            base("La cadena de texto no cumple la nomenclatura de .net")
        {
            this.Nombre = string.Empty;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ONomenclaturaNetException(string nombre):
            base(string.Format("El nombre {0} no cumple las reglas de nomenclatura de .net", nombre))
        {
            this.Nombre = nombre;
        }
        #endregion
    }
}
