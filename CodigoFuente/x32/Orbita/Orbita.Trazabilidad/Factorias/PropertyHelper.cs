//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Globalization;
using System.Reflection;
namespace Orbita.Trazabilidad
{
    internal sealed class PropertyHelper
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.PropertyHelper.
        /// </summary>
        PropertyHelper() { }
        #endregion

        #region Métodos públicos estáticos
        public static string ExpandVariables(string input)
        {
            return input;
        }
        public static bool SetPropertyFromString(object o, string name, string value)
        {
            try
            {
                PropertyInfo propInfo = GetPropertyInfo(o, name);
                if (propInfo == null)
                {
                    throw new NotSupportedException("Parámetro " + name + " no soportado en " + o.GetType().Name);
                }

                object newValue = null;
                if (propInfo.PropertyType.IsEnum)
                {
                    newValue = GetEnumValue(propInfo.PropertyType, value);
                }
                else if (propInfo.PropertyType == typeof(TimeSpan))
                {
                    TimeSpan span;
                    if (TimeSpan.TryParse(value.Replace("h", string.Empty).Replace("m", string.Empty).Replace("s", string.Empty), out span))
                    {
                        newValue = span;
                    }
                }
                else
                {
                    newValue = Convert.ChangeType(value, propInfo.PropertyType, CultureInfo.InvariantCulture);
                }
                propInfo.SetValue(o, newValue, null);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Métodos privados estáticos
        static object GetEnumValue(Type enumType, string value)
        {
            if (enumType.IsDefined(typeof(FlagsAttribute), false))
            {
                ulong union = 0;
                foreach (string v in value.Split(','))
                {
                    FieldInfo enumField = enumType.GetField(v.Trim(), BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
                    union |= Convert.ToUInt64(enumField.GetValue(null), CultureInfo.InvariantCulture);
                }
                object retval = Convert.ChangeType(union, Enum.GetUnderlyingType(enumType), CultureInfo.InvariantCulture);
                return retval;
            }
            else
            {
                FieldInfo enumField = enumType.GetField(value, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
                return enumField.GetValue(null);
            }
        }
        static PropertyInfo GetPropertyInfo(object o, string propiedad)
        {
            PropertyInfo propInfo = o.GetType().GetProperty(propiedad, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propInfo != null)
            {
                return propInfo;
            }
            return null;
        }
        #endregion
    }
}