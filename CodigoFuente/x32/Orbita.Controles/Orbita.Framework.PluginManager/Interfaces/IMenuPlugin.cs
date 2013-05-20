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
using System.Xml.Linq;
namespace Orbita.Framework.PluginManager
{
    /// <summary>
    /// Interface de Plugin.
    /// </summary>
    public interface IItemMenu
    {
        /// <summary>
        /// Grupo al que pertenece el Plugin. Opción padre del menú principal.
        /// </summary>
        string Grupo { get; }
        /// <summary>
        /// Subgrupo al que pertenece el Plugin.
        /// </summary>
        string SubGrupo { get; }
        /// <summary>
        /// Número de índice para ordenar el plug-in en el árbol.
        /// </summary>
        int Orden { get; }
        /// <summary>
        /// Método IDisposable.Dispose() del Plugin.
        /// </summary>
        void Dispose();
    }
}