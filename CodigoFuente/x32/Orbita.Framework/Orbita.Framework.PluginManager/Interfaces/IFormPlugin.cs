//***********************************************************************
// Assembly         : Orbita.Framework.PluginManager
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
    /// Interface de plugins de tipo formulario (System.Windows.Forms.Form).
    /// </summary>
    [System.CLSCompliantAttribute(false)]
    public interface IFormPlugin : IPlugin
    {
        /// <summary>
        /// Especifica el plugin actual al que hace referencia (this).
        /// </summary>
        Controles.Contenedores.OrbitaForm Formulario { get; }
        /// <summary>
        /// Especifica como se quiere mostrar el plugin. { Normal, Dialog, MdiChild }
        /// </summary>
        MostrarComo Mostrar { get; }
    }
}