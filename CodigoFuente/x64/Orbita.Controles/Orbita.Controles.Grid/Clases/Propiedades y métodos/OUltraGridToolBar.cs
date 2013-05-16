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
    public class OUltraGridToolBar : OUltraGrid
    {
        #region Atributos
        OrbitaUltraGridToolBar control;
        string campoPosicionable;
        #endregion

        #region Eventos
        public event System.EventHandler<OPropertyExtendedChangedEventArgs> PropertyChanging;
        public event System.EventHandler<OPropertyExtendedChangedEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OUltraGridToolBar.
        /// </summary>
        /// <param name="control"></param>
        public OUltraGridToolBar(OrbitaUltraGridToolBar control)
            : base(control.Grid)
        {
            this.control = control;
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public string CampoPosicionable
        {
            get { return this.campoPosicionable; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropertyExtendedChangedEventArgs("CampoPosicionable", value));
                }
                this.campoPosicionable = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropertyExtendedChangedEventArgs("CampoPosicionable", value));
                }
                this.campoPosicionable = value;
            }
        }
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public new bool Editable
        {
            get { return this.editable; }
            set
            {
                this.editable = value;
                if (value)
                {
                    this.control.Toolbar.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Toolbar_Click);
                }
                else
                {
                    this.control.Toolbar.ToolClick -= new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Toolbar_Click);
                }
            }
        }
        #endregion

        #region Métodos públicos
        [System.ComponentModel.Description("Determina la visibilidad del botón gestionar.")]
        public bool MostrarToolGestionar
        {
            get { return this.control.Toolbar.Tools["Gestionar"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Gestionar"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón ver.")]
        public bool MostrarToolVer
        {
            get { return this.control.Toolbar.Tools["Ver"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Ver"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón modificar.")]
        public bool MostrarToolModificar
        {
            get { return this.control.Toolbar.Tools["Modificar"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Modificar"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón añadir.")]
        public bool MostrarToolAñadir
        {
            get { return this.control.Toolbar.Tools["Añadir"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Añadir"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón eliminar.")]
        public bool MostrarToolEliminar
        {
            get { return this.control.Toolbar.Tools["Eliminar"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Eliminar"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón limpiar filtros.")]
        public bool MostrarToolLimpiarFiltros
        {
            get { return this.control.Toolbar.Tools["LimpiarFiltros"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["LimpiarFiltros"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón editar.")]
        public bool MostrarToolEditar
        {
            get { return this.control.Toolbar.Tools["Editar"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Editar"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón exportar.")]
        public bool MostrarToolExportar
        {
            get { return this.control.Toolbar.Tools["Exportar"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Exportar"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón imprimir.")]
        public bool MostrarToolImprimir
        {
            get { return this.control.Toolbar.Tools["Imprimir"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Imprimir"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón estilo.")]
        public bool MostrarToolEstilo
        {
            get { return this.control.Toolbar.Tools["Estilo"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Estilo"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón refrescar.")]
        public bool MostrarToolRefrescar
        {
            get { return this.control.Toolbar.Tools["Refrescar"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Refrescar"].SharedProps.Visible = value; }
        }
        [System.ComponentModel.Description("Determina la visibilidad del botón refrescar.")]
        public bool MostrarToolCiclico
        {
            get { return this.control.Toolbar.Tools["Ciclico"].SharedProps.Visible; }
            set { this.control.Toolbar.Tools["Ciclico"].SharedProps.Visible = value; }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolGestionar()
        {
            this.MostrarToolGestionar = Configuracion.DefectoMostrarToolGestionar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolVer()
        {
            this.MostrarToolVer = Configuracion.DefectoMostrarToolVer;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolModificar()
        {
            this.MostrarToolModificar = Configuracion.DefectoMostrarToolModificar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolAñadir()
        {
            this.MostrarToolAñadir = Configuracion.DefectoMostrarToolAñadir;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolEliminar()
        {
            this.MostrarToolEliminar = Configuracion.DefectoMostrarToolEliminar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolLimpiarFiltros()
        {
            this.MostrarToolLimpiarFiltros = Configuracion.DefectoMostrarFiltros;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolEditar()
        {
            this.MostrarToolEditar = Configuracion.DefectoMostrarToolEditar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolExportar()
        {
            this.MostrarToolExportar = Configuracion.DefectoMostrarToolExportar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolImprimir()
        {
            this.MostrarToolImprimir = Configuracion.DefectoMostrarToolImprimir;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolEstilo()
        {
            this.MostrarToolEstilo = Configuracion.DefectoMostrarToolEstilo;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarToolRefrescar()
        {
            this.MostrarToolRefrescar = Configuracion.DefectoMostrarToolRefrescar;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolGestionar()
        {
            return (this.MostrarToolGestionar != Configuracion.DefectoMostrarToolGestionar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolVer()
        {
            return (this.MostrarToolVer != Configuracion.DefectoMostrarToolGestionar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolModificar()
        {
            return (this.MostrarToolModificar != Configuracion.DefectoMostrarToolModificar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolAñadir()
        {
            return (this.MostrarToolAñadir != Configuracion.DefectoMostrarToolAñadir);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolEliminar()
        {
            return (this.MostrarToolEliminar != Configuracion.DefectoMostrarToolEliminar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolLimpiarFiltros()
        {
            return (this.MostrarToolLimpiarFiltros != Configuracion.DefectoMostrarFiltros);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolEditar()
        {
            return (this.MostrarToolEditar != Configuracion.DefectoMostrarToolEditar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolExportar()
        {
            return (this.MostrarToolExportar != Configuracion.DefectoMostrarToolExportar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolImprimir()
        {
            return (this.MostrarToolImprimir != Configuracion.DefectoMostrarToolImprimir);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolEstilo()
        {
            return (this.MostrarToolEstilo != Configuracion.DefectoMostrarToolEstilo);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarToolRefrescar()
        {
            return (this.MostrarToolRefrescar != Configuracion.DefectoMostrarToolRefrescar);
        }
        #endregion

        #region Manejadores de eventos
        protected void Toolbar_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Ejecutar acción.
                this.Control.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                // Ejecutar eventos de actualización.
                this.Filas.Actualizar();
            }
            catch (System.Exception)
            {
            }
        }
        #endregion
    }
}