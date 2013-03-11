//***********************************************************************
// Assembly         : OrbitaUtiles
// Author           : vnicolau
// Created          : 03-03-2011
//
// Last Modified By : aibañez
// Last Modified On : 24-12-2012
// Description      : Añadidos métodos estáticos "GetStringValue", "GetListStringValue" y "FindStringValue"
//
// Last Modified By : crodriguez
// Last Modified On : 05-04-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
namespace Orbita.Utiles
{
    /// <summary>
    /// Clases para dotar de atributos a los tipos enumerados.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.All, Inherited = true)]
    public class OAtributoEnumerado : Attribute
    {
        #region Atributos
        /// <summary>
        /// Valor del enumerado.
        /// </summary>
        string _valor;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OAtributoEnumerado.
        /// </summary>
        public OAtributoEnumerado() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OAtributoEnumerado.
        /// </summary>
        /// <param name="valor">valor.</param>
        public OAtributoEnumerado(string valor)
        {
            this._valor = valor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el valor.
        /// </summary>
        /// <value></value>
        public string Valor
        {
            get { return this._valor; }
        }
        #endregion

        #region Método(s) estático(s)
        /// <summary>
        /// Gets a string value for a particular enum value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>String Value associated via a <see cref="OAtributoEnumeradoAttribute"/> attribute, or null if not found.</returns>
        public static string GetStringValue(Enum value)
        {
            string output = string.Empty;

            //Look for our 'StringValueAttribute' in the field's custom attributes
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            OAtributoEnumerado[] attrs = fi.GetCustomAttributes(typeof(OAtributoEnumerado), false) as OAtributoEnumerado[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Valor;
            }

            return output;
        }

        /// <summary>
        /// Devuelve una lista con los valores de texto de los enumerados
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetListStringValue(Type enumType)
        {
            Dictionary<int, string> resultado = new Dictionary<int, string>();

            foreach (object value in Enum.GetValues(enumType))
            {
                resultado.Add((int)value, GetStringValue((Enum)value));
            }

            return resultado;
        }

        /// <summary>
        /// Busca si el texto coincide con un enumerado
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static Enum FindStringValue(Type enumType, string stringValue, Enum DefaultValue)
        {
            Enum resultado = DefaultValue;

            foreach (object value in Enum.GetValues(enumType))
            {
                string strAux = GetStringValue((Enum)value);
                if (strAux == stringValue)
                {
                    resultado = (Enum)value;
                    break;
                }
            }

            return resultado;
        }

        #endregion
    }
}