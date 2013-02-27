//***********************************************************************
// Assembly         : Orbita.Controles.Comunes
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Comunes
{
    public class OPropiedadEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        string nombre;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OPropiedadEventArgs.
        /// </summary>
        public OPropiedadEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OPropiedadEventArgs.
        /// </summary>
        /// <param name="cadena">Nombre de la propiedad.</param>
        public OPropiedadEventArgs(string nombre)
            : this()
        {
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
        }
        #endregion
    }
}