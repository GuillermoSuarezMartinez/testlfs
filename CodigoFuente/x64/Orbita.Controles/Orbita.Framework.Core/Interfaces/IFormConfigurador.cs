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
    public interface IFormConfigurador
    {
        /// <summary>
        /// Título del formulario que se muestra en la parte superior.
        /// </summary>
        string Titulo { get; set; }
        /// <summary>
        /// Especifica cómo se muestra una ventana de formulario. { Normal, Minimizado, Maximizado }
        /// </summary>
        Core.EstadoVentana EstadoVentana { get; set; }
        /// <summary>
        /// Especifica los estilos de borde de un formulario.
        /// </summary>
        System.Windows.Forms.FormBorderStyle EstiloBorde { get; set; }
        /// <summary>
        /// Mostrar menú principal (MenuStrip).
        /// </summary>
        bool MostrarMenu { get; set; }
        /// <summary>
        /// Número máximo de formularios abiertos.
        /// </summary>
        int NumeroMaximoFormulariosAbiertos { get; set; }
        /// <summary>
        /// Mostrar el formulario de autenticación.
        /// </summary>
        bool Autenticación { get; set; }
        /// <summary>
        /// Cargar un Plugin al iniciar el Framework.
        /// </summary>
        string Plugin { get; set; }
        /// <summary>
        /// Enumerado correspondiente al idioma.
        /// </summary>
        Core.SelectorIdioma Idioma { get; set; }
    }
}