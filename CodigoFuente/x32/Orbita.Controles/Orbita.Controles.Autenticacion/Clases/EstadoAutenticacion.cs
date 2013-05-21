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
    /// Estado de la validación.
    /// </summary>
    public abstract class EstadoAutenticacion
    {
        #region Atributos
        ResultadoAutenticacion resultado;
        string mensaje;
        BotonesAutenticacion botón;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.EstadoAutenticacion.
        /// </summary>
        protected EstadoAutenticacion() { }
        protected EstadoAutenticacion(ResultadoAutenticacion resultado)
        {
            this.resultado = resultado;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Resultado de la autenticación.
        /// </summary>
        public ResultadoAutenticacion Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
        /// <summary>
        /// Mensaje de la validación.
        /// </summary>
        public string Mensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }
        /// <summary>
        /// Botón que se pulsa al validar.
        /// </summary>
        public BotonesAutenticacion Botón
        {
            get { return this.botón; }
            set { this.botón = value; }
        }
        #endregion
    }
}