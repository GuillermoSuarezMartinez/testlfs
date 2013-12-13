namespace Orbita.Controles.Gantt
{
    partial class OrbitaUltraGanttView: Infragistics.Win.UltraWinGanttView.UltraGanttView
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dsDatasource = new System.Data.DataSet();
            this.dtOrigen = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsDatasource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dsDatasource
            // 
            this.dsDatasource.DataSetName = "dsDatasource";
            this.dsDatasource.Tables.AddRange(new System.Data.DataTable[] {
            this.dtOrigen});
            // 
            // dtOrigen
            // 
            this.dtOrigen.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18});
            this.dtOrigen.TableName = "dtOrigen";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "IdTarea";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "IdPadreTarea";
            this.dataColumn2.ColumnName = "IdPadreTarea";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "DescTarea";
            this.dataColumn3.ColumnName = "DescTarea";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Fin";
            this.dataColumn4.ColumnName = "Fin";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "Inicio";
            this.dataColumn5.ColumnName = "Inicio";
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "Duracion";
            this.dataColumn6.ColumnName = "Duracion";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "Info1";
            this.dataColumn7.ColumnName = "Info1";
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "Info2";
            this.dataColumn8.ColumnName = "Info2";
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "Info3";
            this.dataColumn9.ColumnName = "Info3";
            // 
            // dataColumn10
            // 
            this.dataColumn10.Caption = "Info4";
            this.dataColumn10.ColumnName = "Info4";
            // 
            // dataColumn11
            // 
            this.dataColumn11.Caption = "Info5";
            this.dataColumn11.ColumnName = "Info5";
            // 
            // dataColumn12
            // 
            this.dataColumn12.Caption = "Info6";
            this.dataColumn12.ColumnName = "Info6";
            // 
            // dataColumn13
            // 
            this.dataColumn13.Caption = "Completado";
            this.dataColumn13.ColumnName = "Completado";
            // 
            // dataColumn14
            // 
            this.dataColumn14.Caption = "Comentarios";
            this.dataColumn14.ColumnName = "Comentarios";
            // 
            // dataColumn15
            // 
            this.dataColumn15.Caption = "Info7";
            this.dataColumn15.ColumnName = "Info7";
            // 
            // dataColumn16
            // 
            this.dataColumn16.Caption = "Info8";
            this.dataColumn16.ColumnName = "Info8";
            // 
            // dataColumn17
            // 
            this.dataColumn17.Caption = "Info9";
            this.dataColumn17.ColumnName = "Info9";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "Limite";
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            this.ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            // 
            // OrbitaUltraGanttView
            // 
            this.CalendarInfo = this.ultraCalendarInfo1;
            this.GridSettings.ColumnSettings.GetValue("Constraint").VisiblePosition = 6;
            this.GridSettings.ColumnSettings.GetValue("ConstraintDateTime").VisiblePosition = 7;
            this.GridSettings.ColumnSettings.GetValue("Dependencies").VisiblePosition = 4;
            this.GridSettings.ColumnSettings.GetValue("Deadline").VisiblePosition = 8;
            this.GridSettings.ColumnSettings.GetValue("Duration").VisiblePosition = 1;
            this.GridSettings.ColumnSettings.GetValue("EndDateTime").VisiblePosition = 3;
            this.GridSettings.ColumnSettings.GetValue("Milestone").VisiblePosition = 9;
            this.GridSettings.ColumnSettings.GetValue("Name").VisiblePosition = 0;
            this.GridSettings.ColumnSettings.GetValue("Notes").VisiblePosition = 10;
            this.GridSettings.ColumnSettings.GetValue("PercentComplete").VisiblePosition = 11;
            this.GridSettings.ColumnSettings.GetValue("Resources").VisiblePosition = 5;
            this.GridSettings.ColumnSettings.GetValue("StartDateTime").VisiblePosition = 2;
            this.GridSettings.ColumnSettings.GetValue("RowNumber").VisiblePosition = 12;
            ((System.ComponentModel.ISupportInitialize)(this.dsDatasource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        Infragistics.Win.UltraWinSchedule.UltraCalendarInfo ultraCalendarInfo1;
        System.Data.DataSet dsDatasource;
        System.Data.DataTable dtOrigen;
        System.Data.DataColumn dataColumn1;
        System.Data.DataColumn dataColumn2;
        System.Data.DataColumn dataColumn3;
        System.Data.DataColumn dataColumn4;
        System.Data.DataColumn dataColumn5;
        System.Data.DataColumn dataColumn6;
        System.Data.DataColumn dataColumn7;
        System.Data.DataColumn dataColumn8;
        System.Data.DataColumn dataColumn9;
        System.Data.DataColumn dataColumn10;
        System.Data.DataColumn dataColumn11;
        System.Data.DataColumn dataColumn12;
        System.Data.DataColumn dataColumn13;
        System.Data.DataColumn dataColumn14;
        System.Data.DataColumn dataColumn15;
        System.Data.DataColumn dataColumn16;
        System.Data.DataColumn dataColumn17;
        System.Data.DataColumn dataColumn18;
    }
}
