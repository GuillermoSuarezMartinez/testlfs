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
    /// Marks class as a logging target and assigns a name to it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TargetAttribute : Attribute
    {
        private string _name;

        /// <summary>
        /// Creates a new instance of the TargetAttribute class and sets the name.
        /// </summary>
        /// <param name="name"></param>
        public TargetAttribute(string name)
        {
            _name = name;
        }

        /// <summary>
        /// The name of the logging target.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
    }
}