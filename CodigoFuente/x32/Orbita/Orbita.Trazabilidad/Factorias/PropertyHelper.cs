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

using System.Linq;
using System.Reflection;

namespace Orbita.Trazabilidad
{
    internal static class PropertyHelper
    {
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
                    throw new System.NotSupportedException("Parámetro " + name + " no soportado en " + o.GetType().Name);
                }
                object newValue = null;
                if (propInfo.PropertyType.IsEnum)
                {
                    newValue = GetEnumValue(propInfo.PropertyType, value);
                }
                else if (propInfo.PropertyType == typeof(System.TimeSpan))
                {
                    System.TimeSpan span;
                    if (System.TimeSpan.TryParse(value.Replace("h", string.Empty).Replace("m", string.Empty).Replace("s", string.Empty), out span))
                    {
                        newValue = span;
                    }
                }
                else
                {
                    newValue = System.Convert.ChangeType(value, propInfo.PropertyType, System.Globalization.CultureInfo.InvariantCulture);
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
        private static object GetEnumValue(System.Type enumType, string value)
        {
            if (enumType.IsDefined(typeof(System.FlagsAttribute), false))
            {
                ulong union = value.Split(',').Select(v => enumType.GetField(v.Trim(), BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public)).Aggregate<FieldInfo, ulong>(0, (current, enumField) => current | System.Convert.ToUInt64(enumField.GetValue(null), System.Globalization.CultureInfo.InvariantCulture));
                object retval = System.Convert.ChangeType(union, System.Enum.GetUnderlyingType(enumType), System.Globalization.CultureInfo.InvariantCulture);
                return retval;
            }
            var enumField2 = enumType.GetField(value, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
            return enumField2.GetValue(null);
        }
        private static PropertyInfo GetPropertyInfo(object o, string propiedad)
        {
            return o.GetType().GetProperty(propiedad, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
        #endregion
    }
}