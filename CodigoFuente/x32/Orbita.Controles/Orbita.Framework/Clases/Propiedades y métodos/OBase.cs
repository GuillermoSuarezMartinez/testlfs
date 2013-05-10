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
namespace Orbita.Framework
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [System.CLSCompliantAttribute(false)]
    public class OBase : Orbita.Controles.Contenedores.OMdiContainerForm
    {
        #region Atributos
        /// <summary>
        /// Control base.
        /// </summary>
        Base control;
        /// <summary>
        /// Mostrar menú principal.
        /// </summary>
        bool mostrarMenu;
        /// <summary>
        /// Cargar un Plugin al iniciar Framework.
        /// </summary>
        string pluginAlIniciar;
        /// <summary>
        /// Muestrar el formulario de autenticación.
        /// </summary>
        bool autenticación;
        /// <summary>
        /// Enumerado correspondiente al idioma.
        /// </summary>
        Core.SelectorIdioma idioma;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.OBase.
        /// </summary>
        /// <param name="control"></param>
        public OBase(object control)
            : base(control)
        {
            this.control = (Base)control;
        }
        #endregion

        #region Propiedades
        internal Base Control
        {
            get { return this.control; }
        }
        [System.ComponentModel.Description("Indica si se quiere mostrar un menú principal (MenuStrip).")]
        public bool MostrarMenu
        {
            get { return this.mostrarMenu; }
            set { this.mostrarMenu = value; }
        }
        [System.ComponentModel.Description("Identificador de formulario que se quiere cargar al iniciar.")]
        public string Plugin
        {
            get { return this.pluginAlIniciar; }
            set { this.pluginAlIniciar = value; }
        }
        [System.ComponentModel.Description("Indica si se quiere mostrar un formulario de autenticación.")]
        public bool Autenticación
        {
            get { return this.autenticación; }
            set { this.autenticación = value; }
        }
        [System.ComponentModel.Description("Idioma de los controles que contiene cada formulario que contiene el Framework.")]
        public Core.SelectorIdioma Idioma
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
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarMenu()
        {
            this.MostrarMenu = Configuracion.DefectoMostrarMenu;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetPlugin()
        {
            this.Plugin = Configuracion.DefectoPlugin;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetAutenticación()
        {
            this.Autenticación = Configuracion.DefectoAutenticación;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetIdioma()
        {
            this.Idioma = Configuracion.DefectoIdioma;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarMenu()
        {
            return (this.MostrarMenu != Configuracion.DefectoMostrarMenu);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializePlugin()
        {
            return (!string.IsNullOrEmpty(this.Plugin));
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeAutenticación()
        {
            return (this.Autenticación != Configuracion.DefectoAutenticación);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeIdioma()
        {
            return (this.Idioma != Configuracion.DefectoIdioma);
        }
        #endregion
    }
}