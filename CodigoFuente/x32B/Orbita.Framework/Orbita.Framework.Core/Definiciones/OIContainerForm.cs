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
    /// Clase propia asociada a la clase base.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [System.CLSCompliantAttribute(false)]
    public class OIContainerForm : Controles.Contenedores.OMdiContainerForm
    {
        #region Atributos
        /// <summary>
        /// Indica si se quiere mostrar el formulario de autenticación.
        /// </summary>
        private bool autenticación;
        /// <summary>
        /// Enumerado correspondiente al idioma seleccionado.
        /// </summary>
        private SelectorIdioma idioma;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Core.OIContainerForm.
        /// </summary>
        /// <param name="control">Control contenedor de plugins.</param>
        public OIContainerForm(object control)
            : base(control) { }
        #endregion

        #region Propiedades
        /// <summary>
        /// Indica si se quiere mostrar el formulario de autenticación.
        /// </summary>
        [System.ComponentModel.Description("Indica si se quiere mostrar un formulario de autenticación.")]
        public bool Autenticación
        {
            get { return this.autenticación; }
            set { this.autenticación = value; }
        }
        /// <summary>
        /// Enumerado correspodiente al idioma seleccionado.
        /// </summary>
        [System.ComponentModel.Description("Idioma de los controles que contiene cada formulario que contiene el Framework.")]
        public SelectorIdioma Idioma
        {
            get { return this.idioma; }
            set { this.idioma = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>El nombre de tipo completo del objeto.</returns>
        public override string ToString()
        {
            return null;
        }
        #endregion

        #region Métodos protegidos
        /// <summary>
        /// Resetear tipo de autenticación con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAutenticación()
        {
            this.Autenticación = ConfiguracionEntorno.DefectoAutenticación;
        }
        /// <summary>
        /// Resetear selector de idioma con el valor predeterminado.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetIdioma()
        {
            this.Idioma = ConfiguracionEntorno.DefectoIdioma;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAutenticación()
        {
            return (this.Autenticación != ConfiguracionEntorno.DefectoAutenticación);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeIdioma()
        {
            return (this.Idioma != ConfiguracionEntorno.DefectoIdioma);
        }
        #endregion
    }
}