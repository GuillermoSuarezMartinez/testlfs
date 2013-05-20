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
    /// Interface de plugin.
    /// </summary>
    public interface IItemMenu
    {
        /// <summary>
        /// Grupo al que pertenece el plugin. Opción padre del menú principal.
        /// </summary>
        string Grupo { get; }
        /// <summary>
        /// Subgrupo al que pertenece el plugin.
        /// </summary>
        string SubGrupo { get; }
        /// <summary>
        /// Número de índice para ordenar el plugin en el árbol.
        /// </summary>
        int Orden { get; }
        /// <summary>
        /// Método IDisposable.Dispose() del plugin.
        /// </summary>
        void Dispose();
    }
}