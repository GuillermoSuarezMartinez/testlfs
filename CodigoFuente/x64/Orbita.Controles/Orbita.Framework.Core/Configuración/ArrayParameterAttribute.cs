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
    /// <summary>
    /// Used to mark configurable parameters which are arrays. 
    /// Specifies the mapping between XML elements and .NET types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ArrayParameterAttribute : Attribute
    {
        private Type _itemType;
        private string _elementName;

        /// <summary>
        /// Creates a new instance of ArrayParameterAttribute specifying the
        /// element type and configuration element name.
        /// </summary>
        /// <param name="itemType">The type of the array item</param>
        /// <param name="elementName">The XML element name that represents the item.</param>
        public ArrayParameterAttribute(Type itemType, string elementName)
        {
            _itemType = itemType;
            _elementName = elementName;
        }

        /// <summary>
        /// The .NET type of the array item
        /// </summary>
        public Type ItemType
        {
            get { return _itemType; }
        }

        /// <summary>
        /// The XML element name.
        /// </summary>
        public string ElementName
        {
            get { return _elementName; }
        }
    }
}