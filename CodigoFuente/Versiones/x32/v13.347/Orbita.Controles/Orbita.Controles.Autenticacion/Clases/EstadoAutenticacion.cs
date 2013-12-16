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
    /// Estado de autenticación.
    /// </summary>
    public abstract class EstadoAutenticacion
    {
        #region Atributos
        /// <summary>
        /// Resultado de autenticación.
        /// </summary>
        private ResultadoAutenticacion resultado;
        /// <summary>
        /// Mensaje de autenticación.
        /// </summary>
        private string mensaje;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacion.
        /// </summary>
        protected EstadoAutenticacion() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacion.
        /// </summary>
        /// <param name="resultado">Resultado del formulario de autenticación.</param>
        protected EstadoAutenticacion(ResultadoAutenticacion resultado)
        {
            this.resultado = resultado;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacion.
        /// </summary>
        /// <param name="resultado">Resultado del formulario de autenticación.</param>
        /// <param name="mensaje">Mensaje adicional de autenticación.</param>
        protected EstadoAutenticacion(ResultadoAutenticacion resultado, string mensaje)
            : this(resultado)
        {
            this.resultado = resultado;
            this.mensaje = mensaje;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Resultado de autenticación.
        /// </summary>
        public ResultadoAutenticacion Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
        /// <summary>
        /// Mensaje de autenticación.
        /// </summary>
        public string Mensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }
        #endregion
    }
}