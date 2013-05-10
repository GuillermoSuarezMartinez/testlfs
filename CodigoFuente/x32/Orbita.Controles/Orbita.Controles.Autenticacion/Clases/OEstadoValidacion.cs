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
        string estado;
        string mensaje;
        string boton;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.OEstadoValidacion.
        /// </summary>
        public OEstadoValidacion() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.OEstadoValidacion.
        /// </summary>
        /// <param name="estado">Estado de la validación.</param>
        /// <param name="mensaje">Mensaje de la validación.</param>
        /// <param name="boton">Botón que se pulsa.</param>
        public OEstadoValidacion(string estado, string mensaje, string boton)
        {
            this.estado = estado;
            this.mensaje = mensaje;
            this.boton = boton;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Estado de la validación.
        /// </summary>
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
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
        public string Boton
        {
            get { return boton; }
            set { boton = value; }
        }
        #endregion
    }
}