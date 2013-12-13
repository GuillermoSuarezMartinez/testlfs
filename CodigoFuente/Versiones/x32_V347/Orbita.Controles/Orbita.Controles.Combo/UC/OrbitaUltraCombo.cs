//***********************************************************************
// Assembly         : Orbita.Controles.Combo
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Combo
{
    public partial class OrbitaUltraCombo : Infragistics.Win.UltraWinGrid.UltraCombo
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OUltraCombo
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OrbitaUltraCombo.ControlNuevaDefinicion.
            /// </summary>
            /// <param name="sender">Representa un control para mostrar una lista de elementos.</param>
            public ControlNuevaDefinicion(OrbitaUltraCombo sender)
                : base(sender as object) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Combo.OrbitaUltraCombo.
        /// </summary>
        public OrbitaUltraCombo()
            : base()
        {
            InitializeComponent();
            InitializeResourceStrings();
            InitializeAttributes();
            InitializeProperties();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        //[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        //#region Métodos públicos
        ///// <summary>
        ///// Formatear el combo.
        ///// </summary>
        ///// <param name="dt">Tabla de datos.</param>
        ///// <param name="columnas">Lista de columnas.</param>
        ///// <param name="displayMember">Campo texto a visualizar.</param>
        ///// <param name="valueMember">Campo valor.</param>
        //public void OrbFormatear(System.Data.DataTable dt, System.Collections.ArrayList columnas, string displayMember, string valueMember)
        //{
        //    try
        //    {
        //        if (dt != null)
        //        {
        //            this.DataSource = dt;
        //            this.DataBind();
        //            this.DisplayMember = displayMember;
        //            this.ValueMember = valueMember;
        //            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in this.DisplayLayout.Bands[0].Columns)
        //            {
        //                ugc.Hidden = true;
        //            }
        //            if (columnas == null)
        //            {
        //                return;
        //            }
        //            foreach (OEstiloColumna columna in columnas)
        //            {
        //                if (this.DisplayLayout.Bands[0].Columns.Exists(columna.Campo))
        //                {
        //                    this.DisplayLayout.Bands[0].Columns[columna.Campo].Hidden = false;
        //                    this.DisplayLayout.Bands[0].Columns[columna.Campo].Header.Caption = columna.Nombre;
        //                    this.DisplayLayout.Bands[0].Columns[columna.Campo].Style = (Infragistics.Win.UltraWinGrid.ColumnStyle)columna.Estilo;
        //                    this.DisplayLayout.Bands[0].Columns[columna.Campo].CellAppearance.TextHAlign = (Infragistics.Win.HAlign)columna.Alinear;
        //                    if (columna.Ancho > -1)
        //                    {
        //                        this.DisplayLayout.Bands[0].Columns[columna.Campo].Width = columna.Ancho;
        //                    }
        //                    this.DisplayLayout.Bands[0].Columns[columna.Campo].Header.VisiblePosition = columnas.IndexOf(columna);
        //                }
        //                else
        //                {
        //                    // Si el campo que le hemos pasado como parámetro no existe en el combo.
        //                    throw new OExcepcion("Error en FormatearCombo. El campo " + columna.Campo + " no existe en el Grid.");
        //                }
        //            }
        //            if (dt.Rows.Count > 0)
        //            {
        //                this.SelectedRow = this.Rows[0];
        //            }
        //        }
        //        else
        //        {
        //            // Si la tabla es nula lanzamos la excepción.
        //            throw new OExcepcion("Error en FormatearCombo. La tabla es nula.");
        //        }
        //    }
        //    catch (OExcepcion ex)
        //    {
        //        throw new OExcepcion("Error en FormatearCombo.", ex);
        //    }
        //}
        ///// <summary>
        ///// Obtiene el valor de la columna de la fila seleccionada.
        ///// </summary>
        ///// <param name="nombreColumna">Nombre de la columna.</param>
        ///// <returns></returns>
        //public string OrbCeldaSeleccionada(string nombreColumna)
        //{
        //    if (this.ActiveRow != null)
        //    {
        //        if (this.DisplayLayout.Bands[0].Columns.Exists(nombreColumna))
        //        {
        //            return this.ActiveRow.Cells[nombreColumna].Text;
        //        }
        //        else
        //        {
        //            // Si el campo que le hemos pasado como parametro no existe en el combo.
        //            throw new OExcepcion("Error en OrbCeldaSeleccionada. El campo " + nombreColumna + " no existe en el combo.");
        //        }
        //    }
        //    else
        //    {
        //        // Si el campo que le hemos pasado como parametro no existe en el combo.
        //        throw new OExcepcion("Error en OrbCeldaSeleccionada. No hay fila seleccionada");
        //    }
        //}
        ///// <summary>
        ///// Una vez orbFormateado este método añade una fila al combo con el valor nulo o sin especificar que queramos
        ///// Ojito!! solo funciona si el datasource del combo es un datatable, si tenemos otro tipo de datasource se tendrá que hacer a mano.
        ///// </summary>
        ///// <param name="displayMemberValue">Valor para la columna establecida como displaymember y se añadirá también en el resto de columnas string(solo).</param>
        ///// <param name="valueMemberValue">Valor para la columna establecida como valuemember.</param>
        //public void OrbMostrarValorNulo(object displayMemberValue, object valueMemberValue)
        //{
        //    if (this.UltraCombo.DataSource is System.Data.DataTable)
        //    {
        //        System.Data.DataTable tablaDatasource = (System.Data.DataTable)this.UltraCombo.DataSource;
        //        System.Data.DataRow filaNueva = tablaDatasource.NewRow();
        //        filaNueva[this.UltraCombo.DisplayMember] = displayMemberValue;
        //        filaNueva[this.UltraCombo.ValueMember] = valueMemberValue;
        //        for (int i = 0; i < filaNueva.Table.Columns.Count - 1; i++)
        //        {
        //            if (filaNueva.Table.Columns[i].ColumnName != this.UltraCombo.ValueMember)
        //            {
        //                if (filaNueva.Table.Columns[i].DataType.Name == "String")
        //                {
        //                    filaNueva[i] = displayMemberValue;
        //                }
        //            }
        //        }
        //        tablaDatasource.Rows.InsertAt(filaNueva, 0);
        //        this.UltraCombo.DataSource = tablaDatasource;
        //        this.valorNulo = valueMemberValue;
        //    }
        //}
        ///// <summary>
        ///// Una vez orbFormateado este método añade una fila al combo con el valor nulo o sin especificar que queramos
        ///// Cuidado!! solo funciona si el datasource del combo es un datatable, si tenemos otro tipo de datasource se tendrá que hacer a mano.
        ///// </summary>
        ///// <param name="displayMemberValue">Valor para la columna establecida como DisplayMember.</param>
        ///// <param name="valueMemberValue">Valor para la columna establecida como ValueMember.</param>
        ///// <param name="columnDisplayMemberValue">Indica la columna única en la que se desea mostrar el DisplayMember.</param>
        //public void OrbMostrarValorNulo(object displayMemberValue, object valueMemberValue, string columnDisplayMemberValue)
        //{
        //    if (this.UltraCombo.DataSource is System.Data.DataTable)
        //    {
        //        System.Data.DataTable tablaDatasource = (System.Data.DataTable)this.UltraCombo.DataSource;
        //        System.Data.DataRow filaNueva = tablaDatasource.NewRow();
        //        filaNueva[this.UltraCombo.DisplayMember] = displayMemberValue;
        //        filaNueva[this.UltraCombo.ValueMember] = valueMemberValue;
        //        for (int i = 0; i < filaNueva.Table.Columns.Count - 1; i++)
        //        {
        //            if (filaNueva.Table.Columns[i].ColumnName != this.UltraCombo.ValueMember)
        //            {
        //                if (filaNueva.Table.Columns[i].ColumnName == columnDisplayMemberValue)
        //                {
        //                    filaNueva[i] = displayMemberValue;
        //                }
        //            }
        //        }
        //        tablaDatasource.Rows.InsertAt(filaNueva, 0);
        //        this.UltraCombo.DataSource = tablaDatasource;
        //        this.valorNulo = valueMemberValue;
        //    }
        //}
        //#endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        //void InitializeProperties()
        //{
        //Stream isl = Estilos.Comunes.GetIsl("FlatNature");
        //Infragistics.Win.AppStyling.StyleManager.Load(isl, true, "FlatNature");
        //this.StyleLibraryName = "FlatNature";
        // Importante: sin no inicializamos esta propiedad a false, a consecuencia de
        // utilizar TextRenderingMode = GDI, produce que los tooltip de scroll (si hubiera)
        // y los de la fila de filtros, aparezcan en negrita (ilegibles).
        // Infragistics.Win.DrawUtility.UseGDIPlusTextRendering = false;
        //this.Orbita.Estilo = Configuracion.DefectoAutoAjustarEstilo;
        //this.Orbita.PermitirOrdenar = Configuracion.DefectoPermitirOrdenar;
        // this.Orbita.Editable = Configuracion.DefectoEditable;
        //this.DisplayLayout.Override.ResetActiveRowAppearance();
        //this.DisplayLayout.Override.ResetRowAppearance();
        //this.DisplayLayout.Override.ResetRowAlternateAppearance();

        // Extender la última columna.
        // this.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;


        //this.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
        //this.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
        //this.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;

        // Estilo de cabecera.
        //this.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
        // Eliminar las líneas discontinuas de la fila seleccionada.
        //this.DrawFilter = new ONoFocusRectDrawFilter();
        // No mostrar indicador de fila.
        // this.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
        // Justificar centrado el texto de la cabecera.
        //this.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
        // Mostrar ls posibilidad de ordenar columna.
        // this.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
        //}
        void InitializeProperties()
        {
            this.OI.Editable = Configuracion.DefectoEditable;
            this.OI.AnulablePorTeclado = Configuracion.DefectoNullablePorTeclado;
            this.OI.Valor = Configuracion.DefectoValor;
            this.OI.Texto = Configuracion.DefectoTexto;
        }
        #endregion

        #region Métodos privados estáticos
        /// <summary>
        /// Inicializar recursos alfabéticos.
        /// </summary>
        static void InitializeResourceStrings()
        {
            Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            resCustomizer.SetCustomizedString("RowFilterDialogBlanksItem", "(Vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDialogDBNullItem", "(Nulos)");
            resCustomizer.SetCustomizedString("RowFilterDialogEmptyTextItem", "(Vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDialogOperandHeaderCaption", "(Operando)");
            resCustomizer.SetCustomizedString("RowFilterDialogOperatorHeaderCaption", "Operador");
            resCustomizer.SetCustomizedString("RowFilterDialogTitlePrefix", "Establezca el filtro para");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Contains", "(Contiene)");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotContain", "No contiene");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotEndWith", "No acaba en");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotMatch", "No es igual a");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_DoesNotStartWith", "No empieza por");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_EndsWith", "Acaba en");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Equals", "=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_GreaterThan", ">");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_GreaterThanOrEqualTo", ">=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_LessThan", "<");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_LessThanOrEqualTo", "<=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Like", "Como");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_Match", "(Igual)");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_NotEquals", "!=");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_NotLike", "No es como");
            resCustomizer.SetCustomizedString("RowFilterDropDown_Operator_StartsWith", "Empieza por");
            resCustomizer.SetCustomizedString("RowFilterDropDownAllItem", "(Todos)");
            resCustomizer.SetCustomizedString("RowFilterDropDownBlanksItem", "(Vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDropDownCustomItem", "(Personalizado)");
            resCustomizer.SetCustomizedString("RowFilterDropDownEquals", "(Igual)");
            resCustomizer.SetCustomizedString("RowFilterDropDownGreaterThan", "Mayor que");
            resCustomizer.SetCustomizedString("RowFilterDropDownGreaterThanOrEqualTo", "Mayor o igual que");
            resCustomizer.SetCustomizedString("RowFilterDropDownLessThan", "Menor que");
            resCustomizer.SetCustomizedString("RowFilterDropDownLessThanOrEqualTo", "Menor o igual que");
            resCustomizer.SetCustomizedString("RowFilterDropDownLike", "Como");
            resCustomizer.SetCustomizedString("RowFilterDropDownMatch", "Coincide con la expresión regular");
            resCustomizer.SetCustomizedString("RowFilterDropDownNonBlanksItem", "(No vacíos)");
            resCustomizer.SetCustomizedString("RowFilterDropDownNotEquals", "No es igual a");
            resCustomizer.SetCustomizedString("RowFilterLogicalOperator_And", "Y");
            resCustomizer.SetCustomizedString("RowFilterLogicalOperator_Or", "O");
            resCustomizer.SetCustomizedString("RowFilterPatternCaption", "Patrón de búsqueda no válido");
            resCustomizer.SetCustomizedString("RowFilterPatternError", "Error parseando el patrón {0}. Por favor, establezca un patrón de búsqueda válido.");
            resCustomizer.SetCustomizedString("RowFilterPatternException", "Patrón de búsqueda no válido {0}.");
            resCustomizer.SetCustomizedString("RowFilterRegexError", "Error parseando la expresión regular {0}. Por favor establezca una expresión regular válida.");
            resCustomizer.SetCustomizedString("RowFilterRegexErrorCaption", "Expresión regular no válida");
            resCustomizer.SetCustomizedString("RowFilterRegexException", "Expresión regular no válida {0}.");
            resCustomizer.SetCustomizedString("FilterClearButtonToolTip_FilterCell", "Click para limpiar el filtro de {0}.");
            resCustomizer.SetCustomizedString("FilterClearButtonToolTip_RowSelector", "Click para limpiar todos los filtros.");
            resCustomizer.SetCustomizedString("FilterDialogAddConditionButtonText", "&Añadir condición");
            resCustomizer.SetCustomizedString("FilterDialogAndRadioText", "Condiciones 'Y'");
            resCustomizer.SetCustomizedString("FilterDialogCancelButtonText", "&Cancelar");
            resCustomizer.SetCustomizedString("FilterDialogDeleteButtonText", "Borrar condición");
            resCustomizer.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "Filtros N&o");
            resCustomizer.SetCustomizedString("FilterDialogOkButtonText", "&OK");
            resCustomizer.SetCustomizedString("FilterDialogOrRadioText", "Condiciones 'O'");
            resCustomizer.SetCustomizedString("SummaryDialog_Button_Cancel", "&Cancelar");
            resCustomizer.SetCustomizedString("SummaryDialog_Button_OK", "&OK");
            resCustomizer.SetCustomizedString("SummaryDialogAverage", "Media");
            resCustomizer.SetCustomizedString("SummaryDialogCount", "Recuento");
            resCustomizer.SetCustomizedString("SummaryDialogMaximum", "Máximo");
            resCustomizer.SetCustomizedString("SummaryDialogMinimum", "Mínimo");
            resCustomizer.SetCustomizedString("SummaryDialogNone", "Ninguno");
            resCustomizer.SetCustomizedString("SummaryDialogSum", "Suma");
            resCustomizer.SetCustomizedString("SummaryFooterCaption_ChildBandNonGroupByRows", "Resúmenes para [BANDHEADER]: [SCROLLTIPFIELD]");
            resCustomizer.SetCustomizedString("SummaryFooterCaption_GroupByChildRows", "Resúmenes para [GROUPBYROWVALUE]");
            resCustomizer.SetCustomizedString("SummaryFooterCaption_RootRows", "Resúmenes");
            resCustomizer.SetCustomizedString("SummaryTypeAverage", "Media");
            resCustomizer.SetCustomizedString("SummaryTypeCount", "Recuento");
            resCustomizer.SetCustomizedString("SummaryTypeCustom", "Personalizado");
            resCustomizer.SetCustomizedString("SummaryTypeMaximum", "Máximo");
            resCustomizer.SetCustomizedString("SummaryTypeMinimum", "Mínimo");
            resCustomizer.SetCustomizedString("SummaryTypeSum", "Suma");
            resCustomizer.SetCustomizedString("SummaryValueInvalidDisplayFormat", "Formato no válido: {0}. Más informacion: {1}");
            resCustomizer.SetCustomizedString("LDR_SelectSummaries", "Seleccione los resúmenes");
        }
        #endregion

        #region Manejadores de eventos
        void OrbitaUltraCombo_BeforeCustomRowFilterDialog(object sender, Infragistics.Win.UltraWinGrid.BeforeCustomRowFilterDialogEventArgs e)
        {
            try
            {
                e.CustomRowFiltersDialog.TopMost = true;
            }
            catch
            {
                throw;
            }
        }
        void OrbitaUltraCombo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (this.DropDownStyle == Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList && this.OI.AnulablePorTeclado)
                {
                    if (e != null)
                    {
                        switch (e.KeyCode)
                        {
                            case System.Windows.Forms.Keys.Back:
                            case System.Windows.Forms.Keys.Delete:
                                this.OI.ResetValor();
                                break;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        void OrbitaUltraCombo_AfterSortChange(object sender, Infragistics.Win.UltraWinGrid.BandEventArgs e)
        {
            //try
            //{
            //    if (e != null && e.Band.SortedColumns.Count > 0)
            //    {
            //        this.UltraCombo.ValueMember = this.UltraCombo.ValueMemberResolved;
            //        if (this.UltraCombo.DisplayLayout.Bands[0].Columns.Exists(e.Band.SortedColumns[0].Key))
            //        {
            //            this.UltraCombo.DisplayMember = e.Band.SortedColumns[0].Key;
            //            if (this.UltraCombo.ActiveRow != null && this.UltraCombo.ActiveRow.Cells[this.UltraCombo.DisplayMember].Value != System.DBNull.Value)
            //            {
            //                this.UltraCombo.Text = this.UltraCombo.ActiveRow.Cells[this.UltraCombo.DisplayMember].Value.ToString();
            //            }
            //            else
            //            {
            //                this.UltraCombo.Text = "";
            //            }
            //        }
            //    }
            //}
            //catch (OExcepcion ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), stringManager.GetString("ExcepcionOrbitaCombo", System.Globalization.CultureInfo.CurrentUICulture), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            //}
        }
        void OrbitaUltraCombo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //// Autor: Rubén Cuenca (Órbita 1).
            //// Fecha: 01/09/2009 18:11.
            //// Comentario: con esto se soluciona el error que se producía al pulsar CTRL+F4 con el combo desplegado.
            //try
            //{
            //    this.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.CloseDropdown);
            //}
            //catch (OExcepcion ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentCulture, OEstilo.FormatExcepcionGeneral(), ex.TargetSite, ex.ToString(), ex.StackTrace), stringManager.GetString("ExcepcionOrbitaCombo", System.Globalization.CultureInfo.CurrentUICulture), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation, System.Windows.Forms.MessageBoxDefaultButton.Button1, 0);
            //}
        }
        #endregion
    }
}
