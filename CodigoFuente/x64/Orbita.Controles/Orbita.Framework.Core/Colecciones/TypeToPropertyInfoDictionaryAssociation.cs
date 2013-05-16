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
    /// A dictionary with keys of type Type and values of type PropertyInfoDictionary
    /// </summary>
    internal class TypeToPropertyInfoDictionaryAssociation : System.Collections.DictionaryBase
    {
        /// <summary>
        /// Initializes a new empty instance of the TypeToPropertyInfoDictionaryAssociation class
        /// </summary>
        public TypeToPropertyInfoDictionaryAssociation()
        {
            // empty
        }

        /// <summary>
        /// Gets or sets the PropertyInfoDictionary associated with the given Type
        /// </summary>
        /// <param name="key">
        /// The Type whose value to get or set.
        /// </param>
        public virtual PropertyInfoDictionary this[Type key]
        {
            get { return (PropertyInfoDictionary)this.Dictionary[key]; }
            set { this.Dictionary[key] = value; }
        }

        /// <summary>
        /// Adds an element with the specified key and value to this TypeToPropertyInfoDictionaryAssociation.
        /// </summary>
        /// <param name="key">
        /// The Type key of the element to add.
        /// </param>
        /// <param name="value">
        /// The PropertyInfoDictionary value of the element to add.
        /// </param>
        public virtual void Add(Type key, PropertyInfoDictionary value)
        {
            this.Dictionary.Add(key, value);
        }

        /// <summary>
        /// Determines whether this TypeToPropertyInfoDictionaryAssociation contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The Type key to locate in this TypeToPropertyInfoDictionaryAssociation.
        /// </param>
        /// <returns>
        /// true if this TypeToPropertyInfoDictionaryAssociation contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool Contains(Type key)
        {
            return this.Dictionary.Contains(key);
        }

        /// <summary>
        /// Determines whether this TypeToPropertyInfoDictionaryAssociation contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The Type key to locate in this TypeToPropertyInfoDictionaryAssociation.
        /// </param>
        /// <returns>
        /// true if this TypeToPropertyInfoDictionaryAssociation contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsKey(Type key)
        {
            return this.Dictionary.Contains(key);
        }

        /// <summary>
        /// Determines whether this TypeToPropertyInfoDictionaryAssociation contains a specific value.
        /// </summary>
        /// <param name="value">
        /// The PropertyInfoDictionary value to locate in this TypeToPropertyInfoDictionaryAssociation.
        /// </param>
        /// <returns>
        /// true if this TypeToPropertyInfoDictionaryAssociation contains an element with the specified value;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsValue(PropertyInfoDictionary value)
        {
            foreach (PropertyInfoDictionary item in this.Dictionary.Values)
            {
                if (item == value)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the element with the specified key from this TypeToPropertyInfoDictionaryAssociation.
        /// </summary>
        /// <param name="key">
        /// The Type key of the element to remove.
        /// </param>
        public virtual void Remove(Type key)
        {
            this.Dictionary.Remove(key);
        }

        /// <summary>
        /// Gets a collection containing the keys in this TypeToPropertyInfoDictionaryAssociation.
        /// </summary>
        public virtual System.Collections.ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }

        /// <summary>
        /// Gets a collection containing the values in this TypeToPropertyInfoDictionaryAssociation.
        /// </summary>
        public virtual System.Collections.ICollection Values
        {
            get { return this.Dictionary.Values; }
        }
    }
}