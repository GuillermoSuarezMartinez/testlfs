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
                System.Reflection.PropertyInfo propInfo = GetPropertyInfo(o, name);
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
        static object GetEnumValue(System.Type enumType, string value)
        {
            if (enumType.IsDefined(typeof(System.FlagsAttribute), false))
            {
                ulong union = 0;
                foreach (string v in value.Split(','))
                {
                    System.Reflection.FieldInfo enumField = enumType.GetField(v.Trim(), System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public);
                    union |= System.Convert.ToUInt64(enumField.GetValue(null), System.Globalization.CultureInfo.InvariantCulture);
                }
                object retval = System.Convert.ChangeType(union, System.Enum.GetUnderlyingType(enumType), System.Globalization.CultureInfo.InvariantCulture);
                return retval;
            }
            else
            {
                System.Reflection.FieldInfo enumField = enumType.GetField(value, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public);
                return enumField.GetValue(null);
            }
        }
        static System.Reflection.PropertyInfo GetPropertyInfo(object o, string propiedad)
        {
            System.Reflection.PropertyInfo propInfo = o.GetType().GetProperty(propiedad, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (propInfo != null)
            {
                return propInfo;
            }
            return null;
        }
        #endregion
    }
}