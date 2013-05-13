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
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Un diccionario con claves de tipo cadena y valores de tipo PropertyInfo.
    /// </summary>
    internal class PropertyInfoDictionary : System.Collections.DictionaryBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.PropertyInfoDictionary.
        /// </summary>
        public PropertyInfoDictionary() { }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Gets or sets the PropertyInfo associated with the given string
        /// </summary>
        /// <param name="key">
        /// The string whose value to get or set.
        /// </param>
        public virtual System.Reflection.PropertyInfo this[string key]
        {
            get { return (System.Reflection.PropertyInfo)this.Dictionary[key]; }
            set { this.Dictionary[key] = value; }
        }
        /// <summary>
        /// Adds an element with the specified key and value to this PropertyInfoDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to add.
        /// </param>
        /// <param name="value">
        /// The PropertyInfo value of the element to add.
        /// </param>
        public virtual void Add(string key, System.Reflection.PropertyInfo value)
        {
            this.Dictionary.Add(key, value);
        }
        /// <summary>
        /// Determines whether this PropertyInfoDictionary contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The string key to locate in this PropertyInfoDictionary.
        /// </param>
        /// <returns>
        /// true if this PropertyInfoDictionary contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool Contains(string key)
        {
            return this.Dictionary.Contains(key);
        }
        /// <summary>
        /// Determines whether this PropertyInfoDictionary contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The string key to locate in this PropertyInfoDictionary.
        /// </param>
        /// <returns>
        /// true if this PropertyInfoDictionary contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsKey(string key)
        {
            return this.Dictionary.Contains(key);
        }
        /// <summary>
        /// Determines whether this PropertyInfoDictionary contains a specific value.
        /// </summary>
        /// <param name="value">
        /// The PropertyInfo value to locate in this PropertyInfoDictionary.
        /// </param>
        /// <returns>
        /// true if this PropertyInfoDictionary contains an element with the specified value;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsValue(System.Reflection.PropertyInfo value)
        {
            foreach (System.Reflection.PropertyInfo item in this.Dictionary.Values)
            {
                if (item == value)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Removes the element with the specified key from this PropertyInfoDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to remove.
        /// </param>
        public virtual void Remove(string key)
        {
            this.Dictionary.Remove(key);
        }
        /// <summary>
        /// Gets a collection containing the keys in this PropertyInfoDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
        /// <summary>
        /// Gets a collection containing the values in this PropertyInfoDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Values
        {
            get { return this.Dictionary.Values; }
        }
        #endregion
    }
}