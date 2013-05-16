//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework.Core
{
    /// <summary>
    /// Representa la configuración principal del Framework.
    /// </summary>
    [Target("Configurador")]
    public class Configurador : Target, IFormConfigurador
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.Configurador.
        /// </summary>
        public Configurador() { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Título del formulario que se muestra en la parte superior.
        /// </summary>
        public string Titulo
        {
            get;
            set;
        }
        /// <summary>
        /// Especifica cómo se muestra una ventana de formulario. { Normal, Minimizado, Maximizado }
        /// </summary>
        public Core.EstadoVentana EstadoVentana
        {
            get;
            set;
        }
        /// <summary>
        /// Especifica los estilos de borde de un formulario.
        /// </summary>
        public System.Windows.Forms.FormBorderStyle EstiloBorde
        {
            get;
            set;
        }
        /// <summary>
        /// Mostrar menú principal (MenuStrip).
        /// </summary>
        public bool MostrarMenu
        {
            get;
            set;
        }
        /// <summary>
        /// Número máximo de formularios abiertos.
        /// </summary>
        public int NumeroMaximoFormulariosAbiertos
        {
            get;
            set;
        }
        /// <summary>
        /// Mostrar el formulario de autenticación.
        /// </summary>
        public bool Autenticación
        {
            get;
            set;
        }
        /// <summary>
        /// Cargar un Plugin al iniciar el Framework.
        /// </summary>
        public string Plugin
        {
            get;
            set;
        }
        /// <summary>
        /// Enumerado correspondiente al idioma.
        /// </summary>
        public Core.SelectorIdioma Idioma
        {
            get;
            set;
        }
        #endregion
    }
}