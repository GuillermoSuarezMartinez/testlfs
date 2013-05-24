//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
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
        /// Estado de la autenticación.
        /// </summary>
        EstadoAutenticacion estado;
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
        public AutenticacionChangedEventArgs(EstadoAutenticacion estado)
            : this()
        {
            this.estado = estado;
        }
        #endregion

        #region Propiedades
        public ResultadoAutenticacion Resultado
        {
            get { return this.estado.Resultado; }
        }
        public string Mensaje
        {
            get { return this.estado.Mensaje; }
        }
        public BotonesAutenticacion BotónPulsado
        {
            get { return this.estado.Botón; }
        }
        #endregion
    }
}