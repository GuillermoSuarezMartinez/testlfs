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
    public class OFiltros : OControlBase
    {
        #region Atributos
        bool mostrar;
        TipoFiltro tipo;
        #endregion

        #region Eventos
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OFiltros.
        /// </summary>
        public OFiltros()
            : base() { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina la apariencia de la fila de filtros.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina si muestra la fila de filtros.")]
        public bool Mostrar
        {
            get { return this.mostrar; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Mostrar"));
                }
                this.mostrar = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Mostrar"));
                }
            }
        }
        [System.ComponentModel.Description("Determina si muestra la fila de filtros.")]
        public TipoFiltro Tipo
        {
            get { return this.tipo; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("Tipo"));
                }
                this.tipo = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("Tipo"));
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrar()
        {
            this.Mostrar = Configuracion.DefectoMostrarFiltros;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetTipo()
        {
            this.Tipo = Configuracion.DefectoTipoFiltro;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrar()
        {
            return (this.Mostrar != Configuracion.DefectoMostrarFiltros);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTipo()
        {
            return (this.Tipo != Configuracion.DefectoTipoFiltro);
        }
        #endregion
    }
}