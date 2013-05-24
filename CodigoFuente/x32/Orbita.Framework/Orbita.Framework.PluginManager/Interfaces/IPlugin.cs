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
    /// Interface de Plugin.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Nombre del Plugin. Clave del elemento que se va a agregar a la colección de Plugins.
        /// Opción de menú que pertenece el evento Click.
        /// </summary>
        string Nombre { get; }
        /// <summary>
        /// Descripción del Plugin.
        /// </summary>
        string Descripcion { get; }
        /// <summary>
        /// Considerar mostrar el plugin al iniciar el repositorio principal de plugins (Main).
        /// </summary>
        bool MostrarAlIniciar { get; }
    }
}