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
    public class OEstadoValidacion
    {
        #region Atributos
        string resultado;
        string mensaje;
        string botón;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.OEstadoValidacion.
        /// </summary>
        public OEstadoValidacion() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.OEstadoValidacion.
        /// </summary>
        /// <param name="resultado">Resultado de la validación.</param>
        /// <param name="mensaje">Mensaje de la validación.</param>
        /// <param name="boton">Botón que se pulsa.</param>
        public OEstadoValidacion(string resultado, string mensaje, string boton)
        {
            this.resultado = resultado;
            this.mensaje = mensaje;
            this.botón = boton;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Resultado de la validación.
        /// </summary>
        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        /// <summary>
        /// Mensaje de la validación.
        /// </summary>
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        /// <summary>
        /// Botón que se pulsa al validar.
        /// </summary>
        public string Botón
        {
            get { return botón; }
            set { botón = value; }
        }
        #endregion
    }
}