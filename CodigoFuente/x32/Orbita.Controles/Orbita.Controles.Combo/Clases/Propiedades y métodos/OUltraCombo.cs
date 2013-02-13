using System;
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
namespace Orbita.Controles.Combo
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class OUltraCombo : OControlBase
    {
        #region Atributos
        /// <summary>
        /// Control (sender).
        /// </summary>
        OrbitaUltraCombo control;
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
        /// El valor que ha sido seleccionado de la lista.
        /// </summary>
        object valor;
        /// <summary>
        /// El texto mostrado en la posición editable del control.
        /// </summary>
        string texto;
        /// <summary>
        /// Permite suprimir el valor del combo con las teclas backspace ó supresión.
        /// </summary>
        bool nullablePorTeclado;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OUltraCombo.
        /// </summary>
        public OUltraCombo(object control)
            : base()
        {
            this.control = (OrbitaUltraCombo)control;
            this.Editable = Configuracion.DefectoEditable;
            this.Valor = Configuracion.DefectoValor;
            this.Texto = Configuracion.DefectoTexto;
            this.NullablePorTeclado = Configuracion.DefectoNullablePorTeclado;
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Description(" Permite suprimir el valor del combo con las teclas backspace ó supresión.")]
        public bool NullablePorTeclado
        {
            get { return this.nullablePorTeclado; }
            set { this.nullablePorTeclado = value; }
        }
        [System.ComponentModel.Description("El valor que ha sido seleccionado de la lista.")]
        [Browsable(false)]
        public object Valor
        {
            get { return this.valor; }
            set
            {
                this.valor = value;
                this.OnChanged(new OPropiedadEventArgs("Valor"));
            }
        }
        [System.ComponentModel.Description("El texto mostrado en la posición editable del control.")]
        public string Texto
        {
            get { return this.texto; }
            set
            {
                if (this.editable)
                {
                    this.texto = value;
                    this.OnChanged(new OPropiedadEventArgs("Texto"));
                }
            }
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
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public override OApariencia Apariencia
        {
            get { return base.Apariencia; }
            set { base.Apariencia = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las filas.")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OFilas Filas
        {
            get
            {
                if (this.filas == null)
                {
                    this.filas = new OFilas();
                    this.filas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(FilasAparienciaChanged);
                    this.filas.Activa.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(FilasActivaAparienciaChanged);
                    this.filas.Alterna.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(FilasAlternaAparienciaChanged);
                }
                return this.filas;
            }
            set { this.filas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de la cabecera.")]
        //[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OCabecera Cabecera
        {
            get
            {
                if (this.cabecera == null)
                {
                    this.cabecera = new OCabecera();
                    this.cabecera.PropertyChanged += new EventHandler<OPropiedadEventArgs>(CabeceraChanged);
                    this.cabecera.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(CabeceraAparienciaChanged);
                }
                return this.cabecera;
            }
            set { this.cabecera = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las columnas.")]
        //[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OColumnas Columnas
        {
            get
            {
                if (this.columnas == null)
                {
                    this.columnas = new OColumnas();
                    this.columnas.PropertyChanged += new EventHandler<OPropiedadEventArgs>(ColumnasChanged);
                    this.columnas.PermitirOrdenar = Configuracion.DefectoPermitirOrdenar;
                    this.columnas.Estilo = Configuracion.DefectoAutoAjustarEstilo;
                    this.columnas.MostrarFiltro = Configuracion.DefectoMostrarFiltro;
                }
                return this.columnas;
            }
            set { this.columnas = value; }
        }
        [System.ComponentModel.Description("Determina la configuración de las celdas.")]
        //[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OCeldas Celdas
        {
            get
            {
                if (this.celdas == null)
                {
                    this.celdas = new OCeldas();
                    this.celdas.Apariencia.PropertyChanged += new EventHandler<OPropiedadEventArgs>(CeldasAparienciaChanged);
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
                            this.control.DropDownStyle = UltraComboStyle.DropDown;
                        }
                        else
                        {
                            this.control.DropDownStyle = UltraComboStyle.DropDownList;
                        }
                        break;
                    case "Valor":
                        this.control.Value = this.valor;
                        break;
                    case "Texto":
                        this.control.Text = this.texto;
                        break;
                }
            }
        }
        protected virtual void CabeceraChanged(object sender, OPropiedadEventArgs e) { }
        protected virtual void ColumnasChanged(object sender, OPropiedadEventArgs e)
        {
            if (e != null)
            {
                if (e.Nombre == "PermitirOrdenar")
                {
                    if (this.columnas.PermitirOrdenar)
                    {
                        this.control.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
                    }
                    else
                    {
                        this.control.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    }
                }
                else if (e.Nombre == "Estilo")
                {
                    if (this.columnas.Estilo == AutoAjustarEstilo.ExtenderUltimaColumna)
                    {
                        this.control.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                    }
                    else if (this.columnas.Estilo == AutoAjustarEstilo.RedimensionarTodasLasColumnas)
                    {
                        this.control.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                    }
                    else if (this.columnas.Estilo == AutoAjustarEstilo.SinAutoajusteColumnas)
                    {
                        this.control.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
                    }
                }
                else if (e.Nombre == "MostrarFiltro")
                {
                    if (this.Columnas.MostrarFiltro)
                    {
                        this.control.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
                    }
                    else
                    {
                        this.control.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.Default;
                    }
                }
            }
        }
        protected override void AparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.control.Appearance.BackColor = this.Apariencia.ColorFondo;
            this.control.Appearance.BorderColor = this.Apariencia.ColorBorde;
            this.control.Appearance.ForeColor = this.Apariencia.ColorTexto;
            this.control.Appearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.Apariencia.AlineacionTextoHorizontal;
            this.control.Appearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.Apariencia.AlineacionTextoVertical;
            this.control.Appearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.Apariencia.AdornoTexto;
        }
        protected virtual void CeldasAparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.control.DisplayLayout.Override.CellAppearance.BackColor = this.celdas.Apariencia.ColorFondo;
            this.control.DisplayLayout.Override.CellAppearance.BorderColor = this.celdas.Apariencia.ColorBorde;
            this.control.DisplayLayout.Override.CellAppearance.ForeColor = this.celdas.Apariencia.ColorTexto;
            this.control.DisplayLayout.Override.CellAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.celdas.Apariencia.AlineacionTextoHorizontal;
            this.control.DisplayLayout.Override.CellAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.celdas.Apariencia.AlineacionTextoVertical;
            this.control.DisplayLayout.Override.CellAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.celdas.Apariencia.AdornoTexto;
        }
        protected virtual void CabeceraAparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.control.DisplayLayout.Override.HeaderAppearance.BackColor = this.cabecera.Apariencia.ColorFondo;
            this.control.DisplayLayout.Override.HeaderAppearance.BorderColor = this.cabecera.Apariencia.ColorBorde;
            this.control.DisplayLayout.Override.HeaderAppearance.ForeColor = this.cabecera.Apariencia.ColorTexto;
            this.control.DisplayLayout.Override.HeaderAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.cabecera.Apariencia.AlineacionTextoHorizontal;
            this.control.DisplayLayout.Override.HeaderAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.cabecera.Apariencia.AlineacionTextoVertical;
            this.control.DisplayLayout.Override.HeaderAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.cabecera.Apariencia.AdornoTexto;
        }
        protected virtual void FilasAparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.control.DisplayLayout.Override.RowAppearance.BackColor = this.filas.Apariencia.ColorFondo;
            this.control.DisplayLayout.Override.RowAppearance.BorderColor = this.filas.Apariencia.ColorBorde;
            this.control.DisplayLayout.Override.RowAppearance.ForeColor = this.filas.Apariencia.ColorTexto;
            this.control.DisplayLayout.Override.RowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Apariencia.AlineacionTextoHorizontal;
            this.control.DisplayLayout.Override.RowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Apariencia.AlineacionTextoVertical;
            this.control.DisplayLayout.Override.RowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Apariencia.AdornoTexto;
        }
        protected virtual void FilasActivaAparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.control.DisplayLayout.Override.SelectedRowAppearance.BackColor = this.filas.Activa.Apariencia.ColorFondo;
            this.control.DisplayLayout.Override.SelectedRowAppearance.BorderColor = this.filas.Activa.Apariencia.ColorBorde;
            this.control.DisplayLayout.Override.SelectedRowAppearance.ForeColor = this.filas.Activa.Apariencia.ColorTexto;
            this.control.DisplayLayout.Override.SelectedRowAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Activa.Apariencia.AlineacionTextoHorizontal;
            this.control.DisplayLayout.Override.SelectedRowAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Activa.Apariencia.AlineacionTextoVertical;
            this.control.DisplayLayout.Override.SelectedRowAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Activa.Apariencia.AdornoTexto;
        }
        protected virtual void FilasAlternaAparienciaChanged(object sender, OPropiedadEventArgs e)
        {
            this.control.DisplayLayout.Override.RowAlternateAppearance.BackColor = this.filas.Alterna.Apariencia.ColorFondo;
            this.control.DisplayLayout.Override.RowAlternateAppearance.BorderColor = this.filas.Alterna.Apariencia.ColorBorde;
            this.control.DisplayLayout.Override.RowAlternateAppearance.ForeColor = this.filas.Alterna.Apariencia.ColorTexto;
            this.control.DisplayLayout.Override.RowAlternateAppearance.TextHAlign = (Infragistics.Win.HAlign)(int)this.filas.Alterna.Apariencia.AlineacionTextoHorizontal;
            this.control.DisplayLayout.Override.RowAlternateAppearance.TextVAlign = (Infragistics.Win.VAlign)(int)this.filas.Alterna.Apariencia.AlineacionTextoVertical;
            this.control.DisplayLayout.Override.RowAlternateAppearance.TextTrimming = (Infragistics.Win.TextTrimming)(int)this.filas.Alterna.Apariencia.AdornoTexto;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Método formatear.
        /// </summary>
        public virtual void Formatear()
        {
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
            this.NullablePorTeclado = Configuracion.DefectoNullablePorTeclado;
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
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEditable()
        {
            return (this.Editable != Configuracion.DefectoEditable);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeNullablePorTeclado()
        {
            return (this.NullablePorTeclado != Configuracion.DefectoNullablePorTeclado);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTexto()
        {
            return (this.Texto != Configuracion.DefectoTexto);
        }
        #endregion
    }
}

