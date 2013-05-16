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
namespace Orbita.Framework.Core
{
    internal class FactoryHelper
    {
        private static Type[] EmptyTypes = new Type[0];
        private static object[] EmptyParams = new object[0];

        public static object CreateInstance(Type t)
        {
            ConstructorInfo constructor = t.GetConstructor(EmptyTypes);
            if (constructor != null)
            {
                return constructor.Invoke(EmptyParams);
            }
            else
            {
                throw new Exception("Cannot access the constructor of type: " + t.FullName + ". Is the required permission granted?");
            }
        }
    }
}