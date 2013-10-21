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

namespace Orbita.Trazabilidad
{
    /// <summary>
    /// A dictionary with keys of type string and values of type Logger.
    /// </summary>
    internal class DictionaryLogger : System.Collections.DictionaryBase
    {
        #region Propiedades
        /// <summary>
        /// Gets or sets the Target associated with the given string.
        /// </summary>
        /// <param name="key">
        /// The string whose value to get or set.
        /// </param>
        public virtual ILogger this[string key]
        {
            get { return (ILogger)Dictionary[key]; }
            set { Dictionary[key] = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Adds an element with the specified key and value to this DictionaryLogger.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to add.
        /// </param>
        /// <param name="value">
        /// The Target value of the element to add.
        /// </param>
        public virtual void Add(string key, ILogger value)
        {
            Dictionary.Add(key, value);
        }
        /// <summary>
        /// Determines whether this DictionaryLogger contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The string key to locate in this DictionaryLogger.
        /// </param>
        /// <returns>
        /// true if this DictionaryLogger contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool Contains(string key)
        {
            return Dictionary.Contains(key);
        }
        /// <summary>
        /// Determines whether this DictionaryLogger contains a specific value.
        /// </summary>
        /// <param name="value">
        /// The Target value to locate in this TargetDictionary.
        /// </param>
        /// <returns>
        /// true if this TargetDictionary contains an element with the specified value;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsValue(ILogger value)
        {
            return Dictionary.Values.Cast<ILogger>().Contains(value);
        }
        /// <summary>
        /// Removes the element with the specified key from this TargetDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to remove.
        /// </param>
        public virtual void Remove(string key)
        {
            Dictionary.Remove(key);
        }
        /// <summary>
        /// Gets a collection containing the keys in this TargetDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Keys
        {
            get { return Dictionary.Keys; }
        }
        /// <summary>
        /// Gets a collection containing the values in this TargetDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Values
        {
            get { return Dictionary.Values; }
        }
        #endregion
    }
}