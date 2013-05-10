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
namespace Orbita.Framework.Core
{
    [System.CLSCompliantAttribute(false)]
    public interface IFormIdioma
    {
        event System.EventHandler<IdiomaChangedEventArgs> OnCambiarIdioma;
    }
}