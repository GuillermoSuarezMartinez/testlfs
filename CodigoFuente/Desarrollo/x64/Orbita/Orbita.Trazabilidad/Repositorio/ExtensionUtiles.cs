//***********************************************************************
// Assembly         : Orbita.Trazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-21-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Trazabilidad
{
    /// <summary>
    /// Extensiones útiles.
    /// </summary>
    public static class ExtensionUtiles
    {
        #region Atributos privados estáticos
        /// <summary>
        /// Colección de ensamblados.
        /// </summary>
        static System.Collections.ArrayList Ensamblados = Inicializar();
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtener la lista de ensamblados cargados en Orbita.Trazabilidad.
        /// </summary>
        /// <returns>Contiene todos los ensamblados que han sido cargados en Orbita.Trazabilidad.</returns>
        public static System.Collections.ArrayList GetEnsamblados
        {
            get { return Ensamblados; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar el atributo de tipo colección de ensamblados.
        /// </summary>
        /// <returns></returns>
        static System.Collections.ArrayList Inicializar()
        {
            // Añade los defectos de logger.
            Ensamblados = new System.Collections.ArrayList();
            Ensamblados.Add(typeof(Orbita.Trazabilidad.LogManager).Assembly);
            return Ensamblados;
        }
        #endregion
    }
}