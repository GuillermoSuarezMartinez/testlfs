﻿//***********************************************************************
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
    public partial class OrbitaUltraGrid : Infragistics.Win.UltraWinGrid.UltraGrid
    {
        #region Nueva definición
        public class ControlNuevaDefinicion : OUltraGrid
        {
            #region Constructor
            /// <summary>
            /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OrbitaUltraGrid.ControlNuevaDefinicion.
            /// </summary>
            /// <param name="sender">Representa un control para mostrar una lista de elementos.</param>
            public ControlNuevaDefinicion(OrbitaUltraGrid sender)
                : base(sender) { }
            #endregion
        }
        #endregion

        #region Atributos
        ControlNuevaDefinicion definicion;
        #endregion

        #region Eventos
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterDataRowActivate;
        [System.ComponentModel.Category("OrbitaUltraGrid")]
        public event Infragistics.Win.UltraWinGrid.RowEventHandler AfterFilterRowActivate;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Grid.OrbitaUltraGrid.
        /// </summary>
        public OrbitaUltraGrid()
            : base()
        {
            InitializeComponent();
            InitializeResourceStrings();
            InitializeAttributes();
            InitializeProperties();
            InitializeEvents();
        }
        #endregion

        #region Propiedades
        [System.ComponentModel.Category("Gestión de controles")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Métodos privados
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        void InitializeProperties()
        {
            this.OI.Editable = Configuracion.DefectoEditable;
            this.OI.OcultarAgrupadorFilas = Configuracion.DefectoOcultarAgrupadorFilas;
            this.OI.CancelarTeclaReturn = Configuracion.DefectoCancelarTeclaReturn;
            this.OI.ModoActualizacion = Configuracion.DefectoModoActualizacion;
            this.OI.MostrarTitulo = Configuracion.DefectoMostrarTitulo;
        }
        void InitializeEvents()
        {
            this.AfterRowActivate += new System.EventHandler(ControlAfterRowActivate);
        }
        #endregion

        #region Métodos estáticos
        /// <summary>
        /// Inicializar recursos alfabéticos.
        /// </summary>
        static void InitializeResourceStrings()
        {
            Infragistics.Shared.ResourceCustomizer resCustomizer = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            resCustomizer.SetCustomizedString("DeleteMultipleRowsPrompt", "Va a borrar {0} filas. Elija Si para borrarlas o No para salir.");
            resCustomizer.SetCustomizedString("DeleteSingleRowPrompt", "¿Está seguro que desea eliminar la fila seleccionada?");
            resCustomizer.SetCustomizedString("DeleteRowsMessageTitle", "Confirmación de borrado de filas");
            resCustomizer.SetCustomizedString("DeleteSingleRowMessageTitle", "Confirmación de borrado de filas");
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
            resCustomizer.SetCustomizedString("FilterDialogTitle", "Personalizar filtro");
            resCustomizer.SetCustomizedString("FilterDialogApplyLabelText", "Filtro basado en {0} las siguientes condiciones:");
            resCustomizer.SetCustomizedString("FilterDialogAnyComboItem", "Cualquier");
            resCustomizer.SetCustomizedString("FilterDialogAllComboItem", "Todas");
            resCustomizer.SetCustomizedString("FilterDialogConditionAddButtonText", "&Añadir");
            resCustomizer.SetCustomizedString("FilterDialogConditionDeleteButtonText", "&Borrar");
            resCustomizer.SetCustomizedString("FilterDialogOkButtonText", "Aceptar");
            resCustomizer.SetCustomizedString("FilterDialogAndRadioText", "Condiciones 'Y'");
            resCustomizer.SetCustomizedString("FilterDialogCancelButtonText", "&Cancelar");
            resCustomizer.SetCustomizedString("FilterDialogDeleteButtonText", "Borrar condición");
            resCustomizer.SetCustomizedString("FilterDialogOkButtonNoFiltersText", "Filtros N&o");
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
            resCustomizer.SetCustomizedString("SummaryTypeCustom", "Personalizado");
            resCustomizer.SetCustomizedString("SummaryTypeMaximum", "Máximo");
            resCustomizer.SetCustomizedString("SummaryTypeMinimum", "Mínimo");
            resCustomizer.SetCustomizedString("SummaryTypeSum", "Suma");
            resCustomizer.SetCustomizedString("SummaryValueInvalidDisplayFormat", "Formato no válido: {0}. Más informacion: {1}");
            resCustomizer.SetCustomizedString("LDR_SelectSummaries", "Seleccione los resúmenes");
            // Este modifica los textos del menú contextual de las celdas numéricas.
            Infragistics.Shared.ResourceCustomizer resCustomizer2 = Infragistics.Win.Resources.Customizer;
            resCustomizer2.SetCustomizedString("EditContextMenuCopy", "Copiar");
            resCustomizer2.SetCustomizedString("EditContextMenuCut", "Cortar");
            resCustomizer2.SetCustomizedString("EditContextMenuPaste", "Pegar");
            resCustomizer2.SetCustomizedString("EditContextMenuSelectAll", "Seleccionar todo");
            // Recursor de la Toolbar.
            Infragistics.Shared.ResourceCustomizer resCustomizerToolbar = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
            resCustomizerToolbar.SetCustomizedString("QuickCustomizeToolTipXP", "Opciones de la barra de tareas");
        }
        #endregion

        #region Manejadores de eventos
        private void ControlAfterRowActivate(object sender, System.EventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow fila = this.ActiveRow;
                if (fila.IsDataRow)
                {
                    if (this.AfterDataRowActivate != null)
                    {
                        this.AfterDataRowActivate(sender, new Infragistics.Win.UltraWinGrid.RowEventArgs(fila));
                    }
                }
                else if (fila.IsFilterRow)
                {
                    if (this.AfterFilterRowActivate != null)
                    {
                        this.AfterFilterRowActivate(sender, new Infragistics.Win.UltraWinGrid.RowEventArgs(fila));
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }
        #endregion
    }
}