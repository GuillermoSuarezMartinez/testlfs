﻿//***********************************************************************
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
    /// Excepción de filtrado
    /// </summary>
    public class FiltradoException : ApplicationException
    {
        public FiltradoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
