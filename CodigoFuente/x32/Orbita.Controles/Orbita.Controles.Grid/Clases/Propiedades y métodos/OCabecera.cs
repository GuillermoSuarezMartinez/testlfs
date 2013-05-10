//***********************************************************************
// Assembly         : Orbita.Controles.Grid
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Grid
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OCabecera : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Estilo de cabecera.
        /// </summary>
        EstiloCabecera estilo;
        /// <summary>
        /// Estilo multilínea de la cabecera.
        /// </summary>
        bool multilinea;
        #endregion

        #region Eventos
        /// <summary>
        /// Propiedad cambiando.
        /// </summary>
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanging;
        /// <summary>
        /// Propiedad cambio.
        /// </summary>
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OCabecera.
        /// </summary>
        public OCabecera()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de cabecera.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina el estilo de la cabecera.")]
        public EstiloCabecera Estilo
        {
            get { return this.estilo; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Estilo"));
                }
                this.estilo = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Estilo"));
                }
            }
        }
        [System.ComponentModel.Description("Determina el estilo multilínea de la cabecera.")]
        public bool Multilinea
        {
            get { return this.multilinea; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Multilinea"));
                }
                this.multilinea = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Multilinea"));
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstilo()
        {
            this.Estilo = Configuracion.DefectoEstiloCabecera;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMultilinea()
        {
            this.Multilinea = Configuracion.DefectoCabeceraMultilinea;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != Configuracion.DefectoEstiloCabecera);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMultilinea()
        {
            return (this.Multilinea != Configuracion.DefectoCabeceraMultilinea);
        }
        #endregion
    }
}