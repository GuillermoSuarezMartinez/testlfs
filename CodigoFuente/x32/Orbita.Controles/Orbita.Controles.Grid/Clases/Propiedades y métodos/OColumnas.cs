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
using System;
using System.Collections;
using System.ComponentModel;
namespace Orbita.Controles.Grid
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OColumnas : OControlBase
    {
        #region Atributos
        bool permitirOrdenar;
        AutoAjustarEstilo estilo;
        OColumnasBloqueadas bloqueadas;
        TipoSeleccion tipoSeleccion;
        ArrayList visibles;
        #endregion

        #region Eventos
        public event EventHandler<OPropiedadEventArgs> PropertyChanging;
        public event EventHandler<OPropiedadEventArgs> PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OCeldas.
        /// </summary>
        public OColumnas(object control)
            : base(control) { }
        #endregion

        #region Propiedades
        [Browsable(false)]
        public ArrayList Visibles
        {
            get { return this.visibles; }
            set { this.visibles = value; }
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
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializePermitirOrdenar()
        {
            return (this.PermitirOrdenar != Configuracion.DefectoPermitirOrdenar);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeEstilo()
        {
            return (this.Estilo != Configuracion.DefectoAutoAjustarEstilo);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeTipoSeleccion()
        {
            return (this.TipoSeleccion != Configuracion.DefectoTipoSeleccionColumna);
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected bool ShouldSerializeVisibles()
        {
            return (this.Visibles != null);
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Determina el número de propiedades modificadas.
        /// </summary>
        /// <returns></returns>
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
        public static void AsignarMascara(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (banda != null && columna != null && columna.Mascara != null)
            {
                banda.Columns[columna.Campo].MaskInput = columna.Mascara.Nombre;
                banda.Columns[columna.Campo].MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                banda.Columns[columna.Campo].MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                banda.Columns[columna.Campo].PromptChar = columna.Mascara.Prompt;
                if (columna.Mascara.Maximo != null && columna.Mascara.Minimo != null)
                {
                    banda.Columns[columna.Campo].MaxValue = columna.Mascara.Maximo;
                    banda.Columns[columna.Campo].MinValue = columna.Mascara.Minimo;
                }
            }
        }
        public static void AsignarSumario(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (banda != null && columna != null && columna.Sumario != null)
            {
                // Añadir un nuevo sumario a la columna.
                Infragistics.Win.UltraWinGrid.SummarySettings sumario = banda.Summaries.Add(columna.Campo, columna.Sumario.Operacion, banda.Columns[columna.Campo]);
                // Mostrar sumario en la columna seleccionada.
                sumario.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn;
                sumario.SummaryPositionColumn = sumario.SourceColumn;
                // Formatear la apariencia del resumen.
                sumario.DisplayFormat = columna.Sumario.Mascara;
                // Justificar el texto.
                sumario.Appearance.TextHAlign = (Infragistics.Win.HAlign)columna.Alinear;
            }
        }
        public static void AsignarSumarioRecuento(Infragistics.Win.UltraWinGrid.UltraGridBand banda, OEstiloColumna columna)
        {
            if (banda != null && columna != null && banda.Columns.Exists(columna.Campo))
            {
                string clave = banda.Summaries.Count.ToString(System.Globalization.CultureInfo.CurrentCulture);
                banda.Summaries.Add(clave, Infragistics.Win.UltraWinGrid.SummaryType.Count, banda.Columns[columna.Campo], Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn);
                banda.Summaries[clave].DisplayFormat = "{0:#####.##}";
                banda.Summaries[clave].Band.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False;
                banda.Summaries[clave].Band.Override.BorderStyleSummaryFooter = Infragistics.Win.UIElementBorderStyle.Solid;
            }
        }
        #endregion
    }
}
