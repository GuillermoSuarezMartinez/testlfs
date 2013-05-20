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
namespace Orbita.Framework.PluginManager
{
    /// <summary>
    /// Interface de formularios.
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public interface IFormPlugin : IPlugin
    {
        /// <summary>
        /// Especifica el formulario actual al que hace referencia (this).
        /// </summary>
        Orbita.Controles.Contenedores.OrbitaForm Formulario { get; }
        /// <summary>
        /// Especifica como se quiere mostrar el Plugin. { Normal, Dialog, MdiChild }
        /// </summary>
        MostrarComo Mostrar { get; }
    }
}