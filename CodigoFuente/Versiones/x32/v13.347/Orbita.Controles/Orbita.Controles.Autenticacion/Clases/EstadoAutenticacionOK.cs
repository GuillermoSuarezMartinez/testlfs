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
    /// Estado de autenticación correcto.
    /// </summary>
    public class EstadoAutenticacionOK : EstadoAutenticacion
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacionOK.
        /// </summary>
        public EstadoAutenticacionOK()
            : base(ResultadoAutenticacion.OK) { }
        #endregion
    }
}