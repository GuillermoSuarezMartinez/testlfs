//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
// Author           : jljuan
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
    /// <summary>
    /// Estado de autenticación incorrecto.
    /// </summary>
    public class EstadoAutenticacionNOK : EstadoAutenticacion
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacionNOK.
        /// </summary>
        public EstadoAutenticacionNOK()
            : base(ResultadoAutenticacion.NOK) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacionNOK.
        /// </summary>
        /// <param name="mensaje">Mensaje adicional de una autenticación incorrecta.</param>
        public EstadoAutenticacionNOK(string mensaje)
            : this()
        {
            this.Mensaje = mensaje;
        }
        #endregion
    }
}