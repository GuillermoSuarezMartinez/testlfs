﻿//***********************************************************************
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
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Determina de que tipo de formulario se trata.
    /// </summary>
    public enum TipoForm
    {
        /// <summary>
        /// Formulario normal.
        /// </summary>
        Normal,
        /// <summary>
        /// Formulario diálogo.
        /// </summary>
        Dialog,
        /// <summary>
        /// Formulario hijo del MDI parent.
        /// </summary>
        MdiChild
    }
}