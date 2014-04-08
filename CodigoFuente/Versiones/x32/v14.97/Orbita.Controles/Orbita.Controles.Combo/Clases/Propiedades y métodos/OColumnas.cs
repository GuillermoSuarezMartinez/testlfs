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
using Orbita.Controles.Grid;
namespace Orbita.Controles.Combo
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OColumnas : OControlBase
    {
        #region Atributos
        bool permitirOrdenar;
        AutoAjustarEstilo estilo;
        OColumnasBloqueadas bloqueadas;
        TipoSeleccion tipoSeleccion;
        System.Collections.ArrayList visibles;
        bool mostrarFiltro;
        #endregion

        #region Eventos
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event System.EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OColumnas.
        /// </summary>
        /// <param name="control"></param>
        public OColumnas(object control)
            : base(control) { }
        #endregion

        #region Propiedades
        [System.ComponentModel.Browsable(false)]
        public System.Collections.ArrayList Visibles
        {
            get { return this.visibles; }
            set { this.visibles = value; }
        }
        [System.ComponentModel.Description("Mostrar fila de filtros.")]
        public bool MostrarFiltro
        {
            get { return this.mostrarFiltro; }
            set
            {
                if (this.mostrarFiltro != value)
                {
                    if (this.PropertyChanging != null)
                    {
                        this.PropertyChanging(this, new OPropiedadEventArgs("MostrarFiltro"));
                    }
                    this.mostrarFiltro = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new OPropiedadEventArgs("MostrarFiltro"));
                    }
                }
            }
        }
        [System.ComponentModel.Description("Determina si se permite ordenación por columna.")]
        public bool PermitirOrdenar
        {
            get { return this.permitirOrdenar; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("PermitirOrdenar"));
                }
                this.permitirOrdenar = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("PermitirOrdenar"));
                }
            }
        }
        [System.ComponentModel.Description("Determina la apariencia de columna.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Especifica el estilo de columnas.")]
        public AutoAjustarEstilo Estilo
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
        [System.ComponentModel.Description("Determina la configuración de las columnas bloqueadas.")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Category("Fila")]
        public OColumnasBloqueadas Bloqueadas
        {
            get
            {
                if (this.bloqueadas == null)
                {
                    this.bloqueadas = new OColumnasBloqueadas();
                }
                return this.bloqueadas;
            }
            set { this.bloqueadas = value; }
        }
        [System.ComponentModel.Description("Especifica el estilo de columnas.")]
        public TipoSeleccion TipoSeleccion
        {
            get { return this.tipoSeleccion; }
            set
            {
                if (this.PropertyChanging != null)
                {
                    this.PropertyChanging(this, new OPropiedadEventArgs("TipoSeleccion"));
                }
                this.tipoSeleccion = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new OPropiedadEventArgs("TipoSeleccion"));
                }
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetMostrarFiltro()
        {
            this.MostrarFiltro = Configuracion.DefectoMostrarFiltro;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetPermitirOrdenar()
        {
            this.PermitirOrdenar = Configuracion.DefectoPermitirOrdenar;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEstilo()
        {
            this.Estilo = Configuracion.DefectoAutoAjustarEstilo;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetTipoSeleccion()
        {
            this.TipoSeleccion = Configuracion.DefectoTipoSeleccionColumna;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializePermitirOrdenar()
        {
            return (this.PermitirOrdenar != Configuracion.DefectoPermitirOrdenar);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != Configuracion.DefectoAutoAjustarEstilo);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTipoSeleccion()
        {
            return (this.TipoSeleccion != Configuracion.DefectoTipoSeleccionColumna);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeVisibles()
        {
            return (this.Visibles != null);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeMostrarFiltro()
        {
            return (this.MostrarFiltro != Configuracion.DefectoMostrarFiltro);
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
        public void Bloquear(params string[] columnas)
        {
            if (columnas == null)
            {
                return;
            }
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.Control.DisplayLayout.Bands)
            {
                foreach (string columna in columnas)
                {
                    this.Bloqueadas.AsignarEstilo(banda, columna);
                }
            }
        }
        public void Desbloquear()
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.Control.DisplayLayout.Bands)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in ugb.Columns)
                {
                    // Columnas no accesibles mediante el ratón.
                    ugc.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    // Estilos: colores.
                    ugc.ResetCellAppearance();
                }
            }
        }
        public static void AsignarEstilo(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna, int posicionColumna)
        {
            if (banda != null && columna != null)
            {
                // Visualizar la columna oculta.
                banda.Columns[columna.Campo].Hidden = false;
                // banda.Columns[columna.Campo].Tag = true.ToString();
                // Caption de la cabecera.
                banda.Columns[columna.Campo].Header.Caption = columna.Nombre;
                // Estilo.
                banda.Columns[columna.Campo].Style = (Infragistics.Win.UltraWinGrid.ColumnStyle)columna.Estilo;
                // Alineación de celda horizontal.
                banda.Columns[columna.Campo].CellAppearance.TextHAlign = (Infragistics.Win.HAlign)columna.Alinear;
                // Ancho de columna.
                if (columna.Ancho > -1)
                {
                    banda.Columns[columna.Campo].Width = columna.Ancho;
                }
                // Posición de la columna.
                banda.Columns[columna.Campo].Header.VisiblePosition = posicionColumna;
            }
        }
        #endregion
    }
}