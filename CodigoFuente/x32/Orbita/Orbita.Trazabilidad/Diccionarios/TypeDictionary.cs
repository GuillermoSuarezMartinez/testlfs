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
    /// <summary>
    /// A dictionary with keys of type string and values of type Type.
    /// </summary>
    internal class TypeDictionary : System.Collections.DictionaryBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Trazabilidad.TypeDictionary.
        /// </summary>
        public TypeDictionary() { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Gets or sets the Type associated with the given string
        /// </summary>
        /// <param name="key">
        /// The string whose value to get or set.
        /// </param>
        public virtual System.Type this[string key]
        {
            get { return (System.Type)this.Dictionary[key]; }
            set { this.Dictionary[key] = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Adds an element with the specified key and value to this TypeDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to add.
        /// </param>
        /// <param name="value">
        /// The Type value of the element to add.
        /// </param>
        public virtual void Add(string key, System.Type value)
        {
            this.Dictionary.Add(key, value);
        }
        /// <summary>
        /// Determines whether this TypeDictionary contains a specific key.
        /// </summary>
        /// <param name="key">
        /// The string key to locate in this TypeDictionary.
        /// </param>
        /// <returns>
        /// true if this TypeDictionary contains an element with the specified key;
        /// otherwise, false.
        /// </returns>
        public virtual bool Contains(string key)
        {
            return this.Dictionary.Contains(key);
        }
        /// <summary>
        /// Determines whether this TypeDictionary contains a specific value.
        /// </summary>
        /// <param name="value">
        /// The Type value to locate in this TypeDictionary.
        /// </param>
        /// <returns>
        /// true if this TypeDictionary contains an element with the specified value;
        /// otherwise, false.
        /// </returns>
        public virtual bool ContainsValue(System.Type value)
        {
            foreach (System.Type item in this.Dictionary.Values)
            {
                if (item == value)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Removes the element with the specified key from this TypeDictionary.
        /// </summary>
        /// <param name="key">
        /// The string key of the element to remove.
        /// </param>
        public virtual void Remove(string key)
        {
            this.Dictionary.Remove(key);
        }
        /// <summary>
        /// Gets a collection containing the keys in this TypeDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
        /// <summary>
        /// Gets a collection containing the values in this TypeDictionary.
        /// </summary>
        public virtual System.Collections.ICollection Values
        {
            get { return this.Dictionary.Values; }
        }
        #endregion
    }
}