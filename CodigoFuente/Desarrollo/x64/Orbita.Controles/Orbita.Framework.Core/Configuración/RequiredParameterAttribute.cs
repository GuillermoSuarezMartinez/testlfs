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
    /// Attribute used to mark the required parameters for targets,
    /// layout targets and filters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class RequiredParameterAttribute : Attribute
    {
        /// <summary>
        /// Creates a new RequiredParameterAttribute object.
        /// </summary>
        public RequiredParameterAttribute()
        {
        }
    }
}