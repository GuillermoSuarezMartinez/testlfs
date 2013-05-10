//***********************************************************************
// Assembly         : Orbita.Controles
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System.ComponentModel;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Orbita.Controles.Grid;
namespace Orbita.Controles.Combo
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OUltraCombo : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Configuración de filas.
        /// </summary>
        OFilas filas;
        /// <summary>
        /// Configuración de cabecera.
        /// </summary>
        OCabecera cabecera;
        /// <summary>
        /// Configuración de celdas.
        /// </summary>
        OCeldas celdas;
        /// <summary>
        /// Configuración de columnas.
        /// </summary>
        OColumnas columnas;
        /// <summary>
        /// Indica el tipo de control.
        /// </summary>
        bool editable;
        /// <summary>
        /// Permite suprimir el valor del combo con las teclas backspace ó supresión.
        /// </summary>
        bool anulablePorTeclado;
        bool formateado = false;
        bool activarPrimeraFilaAlFormatear = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OUltraCombo.
        /// </summary>
        public OUltraCombo()
            : base() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OUltraCombo.
        /// </summary>
        /// <param name="control"> Orbita.Controles.Combo.OrbitaUltraCombo.</param>
        public OUltraCombo(object control)
            : base(control)  { }
        #endregion

        #region Propiedades
        [Browsable(false)]
        public bool Formateado
        {
            get { return this.formateado; }
            set { this.formateado = value; }
        }
        [Browsable(false)]
        public object DataSource
        {
            get { return this.Control.DataSource; }
            set
            {
                if (value != null)
                {
                    System.Windows.Forms.BindingSource binding = new System.Windows.Forms.BindingSource();
                    binding.DataSource = value;
                    this.Control.DataSource = binding;
                }
            }
        }
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public bool ActivarPrimeraFilaAlFormatear
        {
            get { return this.activarPrimeraFilaAlFormatear; }
            set { this.activarPrimeraFilaAlFormatear = value; }
        }
        [System.ComponentModel.Description(" Permite suprimir el valor del combo con las teclas backspace ó supresión.")]
        public bool AnulablePorTeclado
        {
            get { return this.anulablePorTeclado; }
            set { this.anulablePorTeclado = value; }
        }
        [Browsable(false)]
        public object Valor
        {
            get 
            {
                if (this.Control.Value != null)
                {
                    return this.Control.Value;
                }
                return string.Empty;
            }
            set { this.Control.Value = value; }
        }
        [Browsable(false)]
        public string Texto
        {
            get
            {
                if (this.Control.Text != null)
                {
                    return this.Control.Text;
                }
                return string.Empty;
            }
            set { this.Control.Text = value; }
        }
        [System.ComponentModel.Description("Determina si se permite editar el TextBox asociado a OrbitaUltraCombo.")]
        public bool Editable
        {
            get { return this.editable; }
            set
            {
                this.editable = value;
                this.OnChanged(new OPropiedadEventArgs("Editable"));
            }
        }
        [System.ComponentModel.Description("Determina la apariencia de OrbitaUltraCombo.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las filas.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OFilas Filas
        {
            get
            {
                if (this.filas == null)
                {
                    this.filas = new OFilas(this.Control);
                    this.filas.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(FilasChanged);
                    this.filas.Apariencia.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(AparienciaFilasChanged);
                    this.filas.Activas.Apariencia.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(AparienciaFilasActivasChanged);
                    this.filas.Alternas.Apariencia.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(AparienciaFilasAlternasChanged);
                    this.filas.Alto = Configuracion.DefectoAlto;
                    this.filas.MostrarIndicador = Configuracion.DefectoMostrarIndicador;
                }
                return this.filas;
            }
            set { this.filas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la cabecera.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OCabecera Cabecera
        {
            get
            {
                if (this.cabecera == null)
                {
                    this.cabecera = new OCabecera();
                    this.cabecera.Apariencia.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(AparienciaCabeceraChanged);
                    this.cabecera.Estilo = Configuracion.DefectoEstiloCabecera;
                    this.cabecera.Multilinea = Configuracion.DefectoCabeceraMultilinea;
                }
                return this.cabecera;
            }
            set { this.cabecera = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las columnas.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OColumnas Columnas
        {
            get
            {
                if (this.columnas == null)
                {
                    this.columnas = new OColumnas(this.Control);
                    this.columnas.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(ColumnasChanged);
                    this.columnas.PermitirOrdenar = Configuracion.DefectoPermitirOrdenar;
                    this.columnas.Estilo = Configuracion.DefectoAutoAjustarEstilo;
                    this.columnas.TipoSeleccion = Configuracion.DefectoTipoSeleccionColumna;
                }
                return this.columnas;
            }
            set { this.columnas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las celdas.")]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OCeldas Celdas
        {
            get
            {
                if (this.celdas == null)
                {
                    this.celdas = new OCeldas();
                    this.celdas.Apariencia.PropertyChanged += new System.EventHandler<OPropiedadEventArgs>(AparienciaCeldasChanged);
                }
                return this.celdas;
            }
            set { this.celdas = value; }
        }
        #endregion

        #region Manejadores de eventos
        protected virtual void OnChanged(OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "Editable":
                        if (this.editable)
                        {
                            this.Control.DropDownStyle = UltraComboStyle.DropDown;
                        }
                        else
                        {
                            this.Control.DropDownStyle = UltraComboStyle.DropDownList;
                        }
                        break;
                }
            }
        }
        protected virtual void FilasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                switch (e.Nombre)
                {
                    case "MostrarIndicador":
                        this.Control.DisplayLayout.Override.RowSelectors = (DefaultableBoolean)System.Enum.Parse(typeof(DefaultableBoolean), this.Filas.MostrarIndicador.ToString(), true);
                        break;
                    case "Alto":
                        int alto = this.Filas.Alto;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridBand ugb in this.Control.DisplayLayout.Bands)
                        {
                            ugb.Override.DefaultRowHeight = alto;
                        }
                        break;
                }
            }
        }
        protected virtual void ColumnasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                if (e.Nombre == "PermitirOrdenar")
                {
                    if (this.columnas.PermitirOrdenar)
                    {
                        this.Control.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
                    }
                    else
                    {
                        this.Control.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    }
                }
                else if (e.Nombre == "Estilo")
                {
                    if (this.columnas.Estilo == AutoAjustarEstilo.ExtenderUltimaColumna)
                    {
                        this.Control.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                    }
                    else if (this.columnas.Estilo == AutoAjustarEstilo.RedimensionarTodasLasColumnas)
                    {
                        this.Control.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    }
                    else if (this.columnas.Estilo == AutoAjustarEstilo.SinAutoajusteColumnas)
                    {
                        this.Control.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                    }
                }
                else if (e.Nombre == "MostrarFiltro")
                {
                    if (this.Columnas.MostrarFiltro)
                    {
                        this.Control.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
                    }
                    else
                    {
                        this.Control.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.Default;
                    }
                }
            }
        }
        protected virtual void AparienciaCeldasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.CellAppearance.BackColor = this.celdas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.CellAppearance.BorderColor = this.celdas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.CellAppearance.ForeColor = this.celdas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.CellAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.celdas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.CellAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.celdas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.CellAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.celdas.Apariencia.AdornoTexto;
        }
        protected virtual void AparienciaCabeceraChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.HeaderAppearance.BackColor = this.cabecera.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.HeaderAppearance.BorderColor = this.cabecera.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.HeaderAppearance.ForeColor = this.cabecera.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.HeaderAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.cabecera.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.HeaderAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.cabecera.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.HeaderAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.cabecera.Apariencia.AdornoTexto;
        }
        protected override void AparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.Appearance.BackColor = this.Apariencia.ColorFondo;
            this.Control.Appearance.BorderColor = this.Apariencia.ColorBorde;
            this.Control.Appearance.ForeColor = this.Apariencia.ColorTexto;
            this.Control.Appearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.Apariencia.AlineacionTextoHorizontal;
            this.Control.Appearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.Apariencia.AlineacionTextoVertical;
            this.Control.Appearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.Apariencia.AdornoTexto;
        }
        protected virtual void AparienciaFilasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.RowAppearance.BackColor = this.filas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.RowAppearance.BorderColor = this.filas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.RowAppearance.ForeColor = this.filas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.RowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.RowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.RowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Apariencia.AdornoTexto;
        }
        protected virtual void AparienciaFilasActivasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.SelectedRowAppearance.BackColor = this.filas.Activas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.SelectedRowAppearance.BorderColor = this.filas.Activas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.SelectedRowAppearance.ForeColor = this.filas.Activas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.SelectedRowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.SelectedRowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Activas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.SelectedRowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Activas.Apariencia.AdornoTexto;
        }
        protected virtual void AparienciaFilasAlternasChanged(object sender, OPropiedadEventArgs e)
        {
            this.Control.DisplayLayout.Override.RowAlternateAppearance.BackColor = this.filas.Alternas.Apariencia.ColorFondo;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.BorderColor = this.filas.Alternas.Apariencia.ColorBorde;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.ForeColor = this.filas.Alternas.Apariencia.ColorTexto;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Alternas.Apariencia.AlineacionTextoHorizontal;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Alternas.Apariencia.AlineacionTextoVertical;
            this.Control.DisplayLayout.Override.RowAlternateAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Alternas.Apariencia.AdornoTexto;
        }
        #endregion

        #region Métodos públicos
        public void Formatear(System.Data.DataTable dt, string columnaDeTexto, string columnaDeValor)
        {
            this.formateado = true;
            this.Formatear(dt, null, columnaDeTexto, columnaDeValor);
        }
        public void Formatear(System.Data.DataTable dt, System.Collections.ArrayList columnas, string columnaDeTexto, string columnaDeValor)
        {
            // Guardar la lista de columnas.
            this.Columnas.Visibles = columnas;
            // Asignar DataSource del Grid.
            this.DataSource = dt;
            //this.Control.DataBind();
            this.Control.DisplayMember = columnaDeTexto;
            this.Control.ValueMember = columnaDeValor;
            // Comprobar el formateo previo, o la carga de la colección de plantillas.
            // La única posición donde se modifica este atributo a False (no formateado)
            if (!this.formateado)
            {
                // Formatear columnas.
                // this.columnaBloqueadas = true;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridBand banda in this.Control.DisplayLayout.Bands)
                {
                    // Ocultar todas las columnas de cada una de las bandas.
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in banda.Columns)
                    {
                        ugc.Hidden = true;
                    }
                    if (columnas != null)
                    {
                        // Definir estilos de columnas.
                        foreach (OEstiloColumna columna in columnas)
                        {
                            if (banda.Columns.Exists(columna.Campo))
                            {
                                // Asignar estilos a las columnas.
                                AsignarEstiloColumna(banda, columna, columnas.IndexOf(columna));
                            }
                        }
                    }
                }
                // Una vez formateado, modificar el atributo.
                this.formateado = true;
            }
            if (this.ActivarPrimeraFilaAlFormatear)
            {
                // Seleccionar y activar la primera fila (ActiveRow).
                this.Filas.Activar(1);
            }
        }
        #endregion

        #region Métodos protegidos
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetEditable()
        {
            this.Editable = Configuracion.DefectoEditable;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetNullablePorTeclado()
        {
            this.AnulablePorTeclado = Configuracion.DefectoNullablePorTeclado;
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void ResetTexto()
        {
            this.Texto = Configuracion.DefectoTexto;
        }
        public void ResetValor()
        {
            this.Valor = Configuracion.DefectoValor;
            this.Texto = Configuracion.DefectoTexto;
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEditable()
        {
            return (this.Editable != Configuracion.DefectoEditable);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeNullablePorTeclado()
        {
            return (this.AnulablePorTeclado != Configuracion.DefectoNullablePorTeclado);
        }
        /// <summary>
        /// El método ShouldSerializePropertyName comprueba si una propiedad ha cambiado respecto a su valor predeterminado.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTexto()
        {
            return (this.Texto != Configuracion.DefectoTexto);
        }
        #endregion

        #region Métodos privados
        static void AsignarEstiloColumna(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna, int posicionColumna)
        {
            OColumnas.AsignarEstilo(banda, columna, posicionColumna);
        }
        #endregion
    }
}