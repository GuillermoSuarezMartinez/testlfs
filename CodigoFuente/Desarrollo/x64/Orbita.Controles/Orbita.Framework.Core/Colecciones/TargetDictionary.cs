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
namespace Orbita.Framework.Core
{
    // CLOVER:OFF

    /// <summary>
    /// A dictionary with keys of type string and values of type Target
    /// </summary>
    internal class TargetDictionary : System.Collections.DictionaryBase
    {
        /// <summary>
        /// Initializes a new empty instance of the TargetDictionary class
        /// </summary>
        public TargetDictionary()
        {
            // empty
        }

        /// <summary>
        /// Gets or sets the Target associated with the given string
        /// </summary>
        /// <param name="key">
        /// The string whose value to get or set.
        /// </param>
        public virtual Target this[string key]
        {
            get { return (Target)this.Dictionary[key]; }
            set { this.Dictionary[key] = value; }
        }

        /// <summary>
        /// Adds an element with the specified key and value to this TargetDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to add.
        /// </param>
        /// <param name="value">
        /// The Target value of the element to add.
        /// </param>
        public virtual void Add(string key, Target value)
        {
            this.Dictionary.Add(key, value);
        }

        /// <summary>
        /// Determines whether this TargetDictionary contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The string key to locate in this TargetDictionary.
        /// </param>
        /// <returns>
        /// true if this TargetDictionary contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool Contains(string key)
        {
            return this.Dictionary.Contains(key);
        }

        /// <summary>
        /// Determines whether this TargetDictionary contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The string key to locate in this TargetDictionary.
        /// </param>
        /// <returns>
        /// true if this TargetDictionary contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsKey(string key)
        {
            return this.Dictionary.Contains(key);
        }

        /// <summary>
        /// Determines whether this TargetDictionary contains a specific value.
        /// </summary>
        /// <param name="value">
        /// The Target value to locate in this TargetDictionary.
        /// </param>
        /// <returns>
        /// true if this TargetDictionary contains an element with the specified value;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsValue(Target value)
        {
            foreach (Target item in this.Dictionary.Values)
            {
                if (item == value)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the element with the specified key from this TargetDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to remove.
        /// </param>
        public virtual void Remove(string key)
        {
            this.Dictionary.Remove(key);
        }

        /// <summary>
        /// Gets a collection containing the keys in this TargetDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }

        /// <summary>
        /// Gets a collection containing the values in this TargetDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Values
        {
            get { return this.Dictionary.Values; }
        }
    }
}