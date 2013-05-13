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
namespace Orbita.Controles.Autenticacion
{
    public class AutenticacionChangedEventArgs : System.EventArgs
    {
        #region Atributos privados
        /// <summary>
        /// Estado de la validación.
        /// </summary>
        OEstadoValidacion estado;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.AutenticacionChangedEventArgs.
        /// </summary>
        public AutenticacionChangedEventArgs()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.AutenticacionChangedEventArgs.
        /// </summary>
        /// <param name="estado">Nombre de la propiedad.</param>
        public AutenticacionChangedEventArgs(OEstadoValidacion estado)
            : this()
        {
            this.estado = estado;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Estado de la validación.
        /// </summary>
        public OEstadoValidacion Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        #endregion
    }
}