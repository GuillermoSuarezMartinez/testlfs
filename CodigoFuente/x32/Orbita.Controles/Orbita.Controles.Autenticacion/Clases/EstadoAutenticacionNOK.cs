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
        public EstadoAutenticacionNOK()
            : base(ResultadoAutenticacion.NOK)
        {
            this.Botón = BotonesAutenticacion.Cerrar;
        }
        public EstadoAutenticacionNOK(string mensaje)
            : this(mensaje, BotonesAutenticacion.Aceptar) { }
        public EstadoAutenticacionNOK(string mensaje, BotonesAutenticacion botón)
            : base(ResultadoAutenticacion.NOK)
        {
            this.Mensaje = mensaje;
            this.Botón = botón;
        }
        #endregion
    }
}