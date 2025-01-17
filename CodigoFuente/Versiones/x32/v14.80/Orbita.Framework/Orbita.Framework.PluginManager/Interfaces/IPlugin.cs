﻿//***********************************************************************
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
    /// Interface de plugin.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Nombre del plugin. Clave del elemento que se va a agregar a la colección de plugins. Opción de menú que pertenece el evento Click.
        /// </summary>
        string Nombre { get; }
        /// <summary>
        /// Descripción del plugin.
        /// </summary>
        string Descripcion { get; }
        /// <summary>
        /// Considerar mostrar el plugin al iniciar el repositorio principal de plugins (Orbita.Framework.Main).
        /// </summary>
        bool MostrarAlIniciar { get; }
    }
}