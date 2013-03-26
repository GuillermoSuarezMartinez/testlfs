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
    /// Marks class as a logging target and assigns a name to it.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class TargetAttribute : System.Attribute
    {
        #region Atributos privados
        /// <summary>
        /// The name of the logging target.
        /// </summary>
        string nombre;
        /// <summary>
        /// Marks the target as 'wrapper' target (used to generate the target summary documentation page).
        /// </summary>
        bool esWrapper = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the TargetAttribute class and sets the name.
        /// </summary>
        /// <param name="nombre"></param>
        public TargetAttribute(string nombre)
        {
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// The name of the logging target.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
        }
        /// <summary>
        /// Marks the target as 'wrapper' target (used to generate the target summary documentation page).
        /// </summary>
        public bool ESWrapper
        {
            get { return this.esWrapper; }
            set { this.esWrapper = value; }
        }
        #endregion
    }
}