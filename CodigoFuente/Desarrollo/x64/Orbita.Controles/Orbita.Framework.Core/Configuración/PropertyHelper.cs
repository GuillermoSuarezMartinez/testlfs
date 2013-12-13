//***********************************************************************
// Assembly         : Orbita.Framework.Core
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Reflection;
using System.Collections.Specialized;
using System.Globalization;
using System.Xml;
using System.Collections;

namespace Orbita.Framework.Core
{
    internal sealed class PropertyHelper
    {
        private static TypeToPropertyInfoDictionaryAssociation _parameterInfoCache = new TypeToPropertyInfoDictionaryAssociation();

        private PropertyHelper() { }

        public static string ExpandVariables(string input, NameValueCollection variables)
        {
            if (variables == null || variables.Count == 0)
                return input;

            string output = input;

            // TODO - make this case-insensitive, will probably require a different
            // approach

            foreach (string s in variables.Keys)
            {
                output = output.Replace("${" + s + "}", variables[s]);
            }

            return output;
        }

        private static object GetEnumValue(Type enumType, string value)
        {
            if (enumType.IsDefined(typeof(FlagsAttribute), false))
            {
                ulong union = 0;

                foreach (string v in value.Split(','))
                {
                    FieldInfo enumField = enumType.GetField(v.Trim(), BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
                    union |= Convert.ToUInt64(enumField.GetValue(null));
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

        public static bool SetPropertyFromString(object o, string name, string value0, NameValueCollection variables)
        {
            string value = ExpandVariables(value0, variables);

            try
            {
                PropertyInfo propInfo = GetPropertyInfo(o, name);
                if (propInfo == null)
                {
                    throw new NotSupportedException("Parameter " + name + " not supported on " + o.GetType().Name);
                }

                if (propInfo.IsDefined(typeof(ArrayParameterAttribute), false))
                {
                    throw new NotSupportedException("Parameter " + name + " of " + o.GetType().Name + " is an array and cannot be assigned a scalar value.");
                }

                object newValue;

                if (propInfo.PropertyType.IsEnum)
                {
                    newValue = GetEnumValue(propInfo.PropertyType, value);
                }
                else
                {
                    newValue = Convert.ChangeType(value, propInfo.PropertyType, CultureInfo.InvariantCulture);
                }
                propInfo.SetValue(o, newValue, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void AddArrayItemFromElement(object o, XmlElement el, NameValueCollection variables)
        {
            string name = el.Name;
            PropertyInfo propInfo = GetPropertyInfo(o, name);
            if (propInfo == null)
                throw new NotSupportedException("Parameter " + name + " not supported on " + o.GetType().Name);

            IList propertyValue = (IList)propInfo.GetValue(o, null);
            Type elementType = GetArrayItemType(propInfo);
            object arrayItem = FactoryHelper.CreateInstance(elementType);

            foreach (XmlAttribute attrib in el.Attributes)
            {
                string childName = attrib.LocalName;
                string childValue = attrib.InnerText;

                PropertyHelper.SetPropertyFromString(arrayItem, childName, childValue, variables);
            }

            foreach (XmlNode node in el.ChildNodes)
            {
                if (node is XmlElement)
                {
                    XmlElement el2 = (XmlElement)node;
                    string childName = el2.Name;

                    if (IsArrayProperty(elementType, childName))
                    {
                        PropertyHelper.AddArrayItemFromElement(arrayItem, el2, variables);
                    }
                    else
                    {
                        string childValue = el2.InnerXml;

                        PropertyHelper.SetPropertyFromString(arrayItem, childName, childValue, variables);
                    }
                }
            }

            propertyValue.Add(arrayItem);
        }

        private static PropertyInfo GetPropertyInfo(object o, string propertyName)
        {
            PropertyInfo propInfo = o.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propInfo != null)
                return propInfo;

            lock (_parameterInfoCache)
            {
                Type targetType = o.GetType();
                PropertyInfoDictionary cache = _parameterInfoCache[targetType];
                if (cache == null)
                {
                    cache = BuildPropertyInfoDictionary(targetType);
                    _parameterInfoCache[targetType] = cache;
                }
                return cache[propertyName.ToLower()];
            }
        }

        private static PropertyInfo GetPropertyInfo(Type targetType, string propertyName)
        {
            PropertyInfo propInfo = targetType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propInfo != null)
                return propInfo;

            lock (_parameterInfoCache)
            {
                PropertyInfoDictionary cache = _parameterInfoCache[targetType];
                if (cache == null)
                {
                    cache = BuildPropertyInfoDictionary(targetType);
                    _parameterInfoCache[targetType] = cache;
                }
                return cache[propertyName.ToLower()];
            }
        }

        private static PropertyInfoDictionary BuildPropertyInfoDictionary(Type t)
        {
            PropertyInfoDictionary retVal = new PropertyInfoDictionary();
            foreach (PropertyInfo propInfo in t.GetProperties())
            {
                if (propInfo.IsDefined(typeof(ArrayParameterAttribute), false))
                {
                    ArrayParameterAttribute[] attributes = (ArrayParameterAttribute[])propInfo.GetCustomAttributes(typeof(ArrayParameterAttribute), false);

                    retVal[attributes[0].ElementName.ToLower()] = propInfo;
                }
                else
                {
                    retVal[propInfo.Name.ToLower()] = propInfo;
                }
            }
            return retVal;
        }

        private static Type GetArrayItemType(PropertyInfo propInfo)
        {
            if (propInfo.IsDefined(typeof(ArrayParameterAttribute), false))
            {
                ArrayParameterAttribute[] attributes = (ArrayParameterAttribute[])propInfo.GetCustomAttributes(typeof(ArrayParameterAttribute), false);

                return attributes[0].ItemType;
            }
            else
            {
                return null;
            }
        }

        public static bool IsArrayProperty(Type t, string name)
        {
            PropertyInfo propInfo = GetPropertyInfo(t, name);
            if (propInfo == null)
                throw new NotSupportedException("Parameter " + name + " not supported on " + t.Name);

            if (!propInfo.IsDefined(typeof(ArrayParameterAttribute), false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}