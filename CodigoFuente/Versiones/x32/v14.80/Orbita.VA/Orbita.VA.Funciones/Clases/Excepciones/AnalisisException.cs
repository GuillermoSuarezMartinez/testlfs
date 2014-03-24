//***********************************************************************
// Assembly         : Orbita.VA.Funciones
// Author           : jbelenguer
// Created          : 02-05-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.VA.Funciones
{
    /// <summary>
    /// Excepción propia de las funciones de visión
    /// </summary>
    public class AnalisisException : ApplicationException
    {
        public AnalisisException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
