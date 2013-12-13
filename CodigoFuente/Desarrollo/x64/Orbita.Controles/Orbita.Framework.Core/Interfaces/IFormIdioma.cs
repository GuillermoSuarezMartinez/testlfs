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
    /// <summary>
    /// Interface de idioma.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public interface IFormIdioma
    {
        /// <summary>
        /// Evento relativo al cambio de idioma desde el/los formularios cliente.
        /// </summary>
        event System.EventHandler<IdiomaChangedEventArgs> OnCambiarIdioma;
    }
}