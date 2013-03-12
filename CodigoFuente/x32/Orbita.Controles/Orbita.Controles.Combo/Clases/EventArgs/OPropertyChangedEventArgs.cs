//***********************************************************************
// Assembly         : OrbitaTrazabilidad
// Author           : crodriguez
// Created          : 02-17-2011
//
// Last Modified By : crodriguez
// Last Modified On : 02-22-2011
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Combo
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
        /// <param name="nombre">Nombre de la propiedad.</param>
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