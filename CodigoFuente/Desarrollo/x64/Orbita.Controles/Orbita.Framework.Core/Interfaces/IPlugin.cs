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
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Interface de Plugin.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Título del Plugin. Clave del elemento que se va a agregar a la colección. Opción de menú que pertenece el evento Click.
        /// </summary>
        string Titulo { get; }
        /// <summary>
        /// Descripción del Plugin.
        /// </summary>
        string Descripcion { get; }
        /// <summary>
        /// Nombre del grupo al que pertenece el Plugin. Opción padre del menú principal.
        /// </summary>
        string Grupo { get; }
        /// <summary>
        /// Nombre del subgrupo al que pertenece el Plugin.
        /// </summary>
        string SubGrupo { get; }
        /// <summary>
        /// Configuración personalizada.
        /// </summary>
        XElement Configuracion { get; set; }
        /// <summary>
        /// Número de índice para ordenar el Plugin en el árbol.
        /// </summary>
        int Orden { get; }
        /// <summary>
        /// Imagen del icono asociado al Plugin.
        /// </summary>
        System.Drawing.Bitmap Icono { get; }
        /// <summary>
        /// Método IDisposable.Dispose() del Plugin.
        /// </summary>
        void Dispose();
    }
}