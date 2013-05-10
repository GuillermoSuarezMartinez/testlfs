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
        /// Especifica de que tipo de formulario se trata. { Normal, Dialog, MdiChild }
        /// </summary>
        TipoForm Tipo { get; }
        /// <summary>
        /// Especifica cómo se muestra una ventana de formulario. { Normal, Minimizado, Maximizado }
        /// </summary>
        EstadoVentana EstadoVentana { get; }
        /// <summary>
        /// Especifica los estilos de borde de un formulario.
        /// </summary>
        System.Windows.Forms.FormBorderStyle EstiloBorde { get; }
    }
}