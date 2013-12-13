//***********************************************************************
// Assembly         : Orbita.Framework
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
    /// Representa la configuración principal del Framework.
    /// </summary>
    [Target("Autenticación")]
    public class Autenticación : Target
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.Autenticación.
        /// </summary>
        public Autenticación() { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Título del formulario que se muestra en la parte superior.
        /// </summary>
        public string Tipo
        {
            get;
            set;
        }
        #endregion
    }
}