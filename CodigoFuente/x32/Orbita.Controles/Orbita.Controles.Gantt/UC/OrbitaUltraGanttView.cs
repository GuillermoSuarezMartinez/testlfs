//***********************************************************************
// Assembly         : Orbita.Controles.Gantt
// Author           : crodriguez
// Created          : 19-01-2012
//
// Last Modified By : crodriguez
// Last Modified On : 19-01-2012
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Gantt
{
    public partial class OrbitaUltraGanttView : Infragistics.Win.UltraWinGanttView.UltraGanttView
    {
        #region Atributos públicos
        /// <summary>
        /// Resolucion.
        /// </summary>
        Resoluciones resolucion = Resoluciones.Dia;
        /// <summary>
        /// OrbColumnas.
        /// </summary>
        OColumnHeaderCollection columnas;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.OrbitaUltraGanttView.
        /// </summary>
        public OrbitaUltraGanttView()
            : base()
        {
            InitializeComponent();
            columnas = new OColumnHeaderCollection();
            this.TaskToolTipDisplaying += new Infragistics.Win.UltraWinGanttView.TaskToolTipDisplayingHandler(EventoMostrarToolTip);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Datasource.
        /// </summary>
        public System.Data.DataTable Datasource
        {
            get { return dsDatasource.Tables[0].Clone(); }
        }
        /// <summary>
        /// Resolución.
        /// </summary>
        public Resoluciones Resolucion
        {
            get { return this.resolucion; }
            set { this.resolucion = value; }
        }
        /// <summary>
        /// Columnas.
        /// </summary>
        public OColumnHeaderCollection Columnas
        {
            get { return this.columnas; }
            set { this.columnas = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Configurar columnas.
        /// </summary>
        /// <returns></returns>
        public bool ConfigurarColumnas()
        {
            int anchoPorDefecto = 100;
            this.TaskSettings.ReadOnly = Infragistics.Win.DefaultableBoolean.True;
            this.GridSettings.ReadOnly = Infragistics.Win.DefaultableBoolean.True;
            foreach (object ajuste in this.GridSettings.ColumnSettings)
            {
                ((System.Collections.Generic.KeyValuePair<string, Infragistics.Win.UltraWinGanttView.TaskColumnSettings>)ajuste).Value.Reset();
            }
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Constraint].Visible = Infragistics.Win.DefaultableBoolean.False;
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.ConstraintDateTime].Visible = Infragistics.Win.DefaultableBoolean.False;
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Deadline].Visible = Infragistics.Win.DefaultableBoolean.False;
            if (columnas.Limite != null)
            {
                this.GridSettings.ColumnSettings["Limite"].Visible = (columnas.Limite.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Limite"].Text = columnas.Limite.Caption;
                this.GridSettings.ColumnSettings["Limite"].Width = columnas.Limite.Ancho == 0 ? 120 : columnas.Limite.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Limite"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Limite"].Text = "Límite";
                this.GridSettings.ColumnSettings["Limite"].Width = 120;
            }

            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Dependencies].Visible = Infragistics.Win.DefaultableBoolean.False;
            if (columnas.Duracion != null)
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Duration].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Duracion"].Visible = (columnas.Duracion.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Duracion"].Text = columnas.Duracion.Caption;
                this.GridSettings.ColumnSettings["Duracion"].Width = columnas.Duracion.Ancho == 0 ? 50 : columnas.Duracion.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Duration].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Duracion"].Visible = Infragistics.Win.DefaultableBoolean.True;
                this.GridSettings.ColumnSettings["Duracion"].Text = "Duración";
                this.GridSettings.ColumnSettings["Duracion"].Width = 50;
            }
            if (columnas.Fin != null)
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.EndDateTime].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["FFin"].Visible = (columnas.Fin.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["FFin"].Text = "Fin";
                this.GridSettings.ColumnSettings["FFin"].Width = columnas.Fin.Ancho == 0 ? 120 : columnas.Fin.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.EndDateTime].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.EndDateTime].Text = "Fin";
                this.GridSettings.ColumnSettings["FFin"].Visible = Infragistics.Win.DefaultableBoolean.True;
                this.GridSettings.ColumnSettings["FFin"].Text = "Fin";
                this.GridSettings.ColumnSettings["FFin"].Width = 120;
            }
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.EndDateTime].ReadOnly = Infragistics.Win.DefaultableBoolean.True;
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Milestone].Visible = Infragistics.Win.DefaultableBoolean.False;
            if (columnas.Descripcion != null)
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Name].Visible = (columnas.Descripcion.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Name].Text = columnas.Descripcion.Caption;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Name].Width = columnas.Descripcion.Ancho == 0 ? 150 : columnas.Descripcion.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Name].Visible = Infragistics.Win.DefaultableBoolean.True;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Name].Text = "Descripción";
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Name].Width = 150;
            }
            if (columnas.Comentarios != null)
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Notes].Visible = (columnas.Comentarios.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Notes].Text = columnas.Comentarios.Caption;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Notes].Width = columnas.Comentarios.Ancho == 0 ? 200 : columnas.Comentarios.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Notes].Visible = Infragistics.Win.DefaultableBoolean.True;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Notes].Text = "Comentarios";
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Notes].Width = 200;
            }
            if (columnas.Completado != null)
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete].Visible = (columnas.Completado.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete].Text = columnas.Completado.Caption;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete].Width = columnas.Completado.Ancho == 0 ? 75 : columnas.Completado.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete].Visible = Infragistics.Win.DefaultableBoolean.True;
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete].Text = "Completado";
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete].Width = 75;
            }
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.Resources].Visible = Infragistics.Win.DefaultableBoolean.False;
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.RowNumber].Visible = Infragistics.Win.DefaultableBoolean.False;
            if (columnas.Inicio != null)
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.StartDateTime].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["FInicio"].Visible = (columnas.Fin.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["FInicio"].Text = "Inicio";
                this.GridSettings.ColumnSettings["FInicio"].Width = columnas.Fin.Ancho == 0 ? 120 : columnas.Fin.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.StartDateTime].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["FInicio"].Visible = Infragistics.Win.DefaultableBoolean.True;
                this.GridSettings.ColumnSettings["FInicio"].Text = "Inicio";
                this.GridSettings.ColumnSettings["FInicio"].Width = 120;
            }
            this.GridSettings.ColumnSettings[Infragistics.Win.UltraWinSchedule.TaskField.StartDateTime].ReadOnly = Infragistics.Win.DefaultableBoolean.True;
            if (columnas.Info1 != null)
            {
                this.GridSettings.ColumnSettings["Info1"].Visible = (columnas.Info1.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info1"].Text = columnas.Info1.Caption;
                this.GridSettings.ColumnSettings["Info1"].Width = columnas.Info1.Ancho == 0 ? anchoPorDefecto : columnas.Info1.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info1"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info1"].Text = "Info1";
                this.GridSettings.ColumnSettings["Info1"].Width = anchoPorDefecto;
            }
            if (columnas.Info2 != null)
            {
                this.GridSettings.ColumnSettings["Info2"].Visible = (columnas.Info2.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info2"].Text = columnas.Info2.Caption;
                this.GridSettings.ColumnSettings["Info2"].Width = columnas.Info2.Ancho == 0 ? anchoPorDefecto : columnas.Info2.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info2"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info2"].Text = "Info2";
                this.GridSettings.ColumnSettings["Info2"].Width = anchoPorDefecto;
            }
            if (columnas.Info3 != null)
            {
                this.GridSettings.ColumnSettings["Info3"].Visible = (columnas.Info3.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info3"].Text = columnas.Info3.Caption;
                this.GridSettings.ColumnSettings["Info3"].Width = columnas.Info3.Ancho == 0 ? anchoPorDefecto : columnas.Info3.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info3"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info3"].Text = "Info3";
                this.GridSettings.ColumnSettings["Info3"].Width = anchoPorDefecto;
            }
            if (columnas.Info4 != null)
            {
                this.GridSettings.ColumnSettings["Info4"].Visible = (columnas.Info4.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info4"].Text = columnas.Info4.Caption;
                this.GridSettings.ColumnSettings["Info4"].Width = columnas.Info4.Ancho == 0 ? anchoPorDefecto : columnas.Info4.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info4"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info4"].Text = "Info4";
                this.GridSettings.ColumnSettings["Info4"].Width = anchoPorDefecto;
            }
            if (columnas.Info5 != null)
            {
                this.GridSettings.ColumnSettings["Info5"].Visible = (columnas.Info5.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info5"].Text = columnas.Info5.Caption;
                this.GridSettings.ColumnSettings["Info5"].Width = columnas.Info5.Ancho == 0 ? anchoPorDefecto : columnas.Info5.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info5"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info5"].Text = "Info5";
                this.GridSettings.ColumnSettings["Info5"].Width = anchoPorDefecto;
            }
            if (columnas.Info6 != null)
            {
                this.GridSettings.ColumnSettings["Info6"].Visible = (columnas.Info6.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info6"].Text = columnas.Info6.Caption;
                this.GridSettings.ColumnSettings["Info6"].Width = columnas.Info6.Ancho == 0 ? anchoPorDefecto : columnas.Info6.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info6"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info6"].Text = "Info6";
                this.GridSettings.ColumnSettings["Info6"].Width = anchoPorDefecto;
            }
            if (columnas.Info7 != null)
            {
                this.GridSettings.ColumnSettings["Info7"].Visible = (columnas.Info7.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info7"].Text = columnas.Info7.Caption;
                this.GridSettings.ColumnSettings["Info7"].Width = columnas.Info7.Ancho == 0 ? anchoPorDefecto : columnas.Info7.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info7"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info7"].Text = "Info7";
                this.GridSettings.ColumnSettings["Info7"].Width = anchoPorDefecto;
            }
            if (columnas.Info8 != null)
            {
                this.GridSettings.ColumnSettings["Info8"].Visible = (columnas.Info8.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info8"].Text = columnas.Info8.Caption;
                this.GridSettings.ColumnSettings["Info8"].Width = columnas.Info8.Ancho == 0 ? anchoPorDefecto : columnas.Info8.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info8"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info8"].Text = "Info8";
                this.GridSettings.ColumnSettings["Info8"].Width = anchoPorDefecto;
            }
            if (columnas.Info9 != null)
            {
                this.GridSettings.ColumnSettings["Info9"].Visible = (columnas.Info9.Visible ? Infragistics.Win.DefaultableBoolean.True : Infragistics.Win.DefaultableBoolean.False);
                this.GridSettings.ColumnSettings["Info9"].Text = columnas.Info9.Caption;
                this.GridSettings.ColumnSettings["Info9"].Width = columnas.Info9.Ancho == 0 ? anchoPorDefecto : columnas.Info9.Ancho;
            }
            else
            {
                this.GridSettings.ColumnSettings["Info9"].Visible = Infragistics.Win.DefaultableBoolean.False;
                this.GridSettings.ColumnSettings["Info9"].Text = "Info9";
                this.GridSettings.ColumnSettings["Info9"].Width = anchoPorDefecto;
            }
            this.GridSettings.AllowChangeIndentation = false;
            this.GridSettings.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None;
            return true;
        }
        /// <summary>
        /// Representa en el diagrama el contenido del datasource
        /// </summary>
        /// <param name="dt">Esta tabla debe obtenerse de la propiedad datasource del control
        /// y debe ser rellenada con la funcion añadirFila del control</param>
        /// <returns>resultado de la operación</returns>
        public bool OrbFormatear(System.Data.DataTable dt)
        {
            this.ultraCalendarInfo1.Reset();
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Duracion"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("FInicio"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("FFin"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Limite"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info1"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info2"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info3"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info4"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info5"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info6"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info7"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info8"));
            this.ultraCalendarInfo1.CustomTaskColumns.Add(new Infragistics.Win.UltraWinSchedule.TaskColumn("Info9"));
            if (ProcesarHijos(dt))
            {
                this.ConfigurarColumnas();
                this.EstablecerResolucion();
                this.CalendarLook.ActiveDayAppearance.BackColor = Orbita.Controles.Grid.OConfiguracion.OrbGridColorFilaActiva;
                this.CalendarInfo.ActivateDay(System.DateTime.Now);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Crea una fila del tipo que necesita datasource, 
        /// la rellena con los valores pasados por parametro
        /// y la asigna a datasource
        /// </summary>
        /// <param name="dt">tabla origen del gantt(obtenerla de la propiedad datasource del gantt)</param>
        /// <param name="idTarea">id único de la tarea</param>
        /// <param name="idPadre">si es una tarea hija, id de la tarea padre, 
        /// - Solo puede haber una tarea con idpadre="", esta y sus hijas serán 
        /// las únicas que se muestren en el gantt 
        /// - Debe haber una tarea raiz (sin idPadre) de la que colgarán todas las demás</param>
        /// <param name="descripcion"></param>
        /// <param name="comentarios"></param>
        /// <param name="completado"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <param name="limite"></param>
        /// <param name="info1"></param>
        /// <param name="info2"></param>
        /// <param name="info3"></param>
        /// <param name="info4"></param>
        /// <param name="info5"></param>
        /// <param name="info6"></param>
        /// <param name="info7"></param>
        /// <param name="info8"></param>
        /// <param name="info9"></param>
        /// <returns></returns>
        public static bool AñadirFila(ref System.Data.DataTable dt, string idTarea, string idPadre, string descripcion, string comentarios, int completado, System.DateTime inicio, System.DateTime fin, System.DateTime limite, object info1, object info2, object info3, object info4, object info5, object info6, object info7, object info8, object info9)
        {
            System.Data.DataRow fila = dt.NewRow();
            fila["IdTarea"] = idTarea;
            fila["IdPadreTarea"] = idPadre;
            fila["DescTarea"] = descripcion;
            fila["Comentarios"] = comentarios;
            fila["Completado"] = completado;
            fila["Inicio"] = inicio;
            fila["Fin"] = fin;
            fila["Limite"] = limite;
            fila["Info1"] = info1;
            fila["Info2"] = info2;
            fila["Info3"] = info3;
            fila["Info4"] = info4;
            fila["Info5"] = info5;
            fila["Info6"] = info6;
            fila["Info7"] = info7;
            fila["Info8"] = info8;
            fila["Info9"] = info9;
            dt.Rows.Add(fila);
            return true;
        }
        /// <summary>
        /// Crea una fila del tipo que necesita datasource, 
        /// la rellena con los valores pasados por parametro
        /// y la asigna a datasource
        /// </summary>
        /// <param name="dt">tabla origen del gantt(obtenerla de la propiedad datasource del gantt)</param>
        /// <param name="idTarea">id único de la tarea</param>
        /// <param name="idPadre">si es una tarea hija, id de la tarea padre, 
        /// - Solo puede haber una tarea con idpadre="", esta y sus hijas serán 
        /// las únicas que se muestren en el gantt 
        /// - Debe haber una tarea raiz (sin idPadre) de la que colgarán todas las demás</param>
        /// <param name="descripcion"></param>
        /// <param name="comentarios"></param>
        /// <param name="completado"></param>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        /// <param name="limite"></param>
        /// <returns></returns>
        public static bool AñadirFila(ref System.Data.DataTable dt, string idTarea, string idPadre, string descripcion, string comentarios, int completado, System.DateTime inicio, System.DateTime fin, System.DateTime limite)
        {
            return AñadirFila(ref dt, idTarea, idPadre, descripcion, comentarios, completado, inicio, fin, limite, "", "", "", "", "", "", "", "", "");
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Configura el control de línea de tiempo para mostrar las fechas con la resolución establecida
        /// </summary>
        public void EstablecerResolucion()
        {
            switch (this.resolucion)
            {
                case Resoluciones.Hora:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.TimeInterval(1, Infragistics.Win.UltraWinSchedule.TimeIntervalUnits.Hours);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Days));
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks));
                    break;
                case Resoluciones.Hora2:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.TimeInterval(2, Infragistics.Win.UltraWinSchedule.TimeIntervalUnits.Hours);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Days));
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks));
                    break;
                case Resoluciones.Hora4:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.TimeInterval(4, Infragistics.Win.UltraWinSchedule.TimeIntervalUnits.Hours);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Days));
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks));
                    break;
                case Resoluciones.Hora6:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.TimeInterval(6, Infragistics.Win.UltraWinSchedule.TimeIntervalUnits.Hours);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Days));
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks));
                    break;
                case Resoluciones.Hora12:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.TimeInterval(12, Infragistics.Win.UltraWinSchedule.TimeIntervalUnits.Hours);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Days));
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks));
                    break;
                case Resoluciones.Dia:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Days);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks));
                    break;
                case Resoluciones.Semana:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Weeks);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Months));
                    break;
                case Resoluciones.Mes:
                    this.TimelineSettings.PrimaryInterval = new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Months);
                    this.TimelineSettings.AutoAddAdditionalInterval = false;
                    this.TimelineSettings.AdditionalIntervals.Reset();
                    this.TimelineSettings.AdditionalIntervals.Add(new Infragistics.Win.UltraWinSchedule.DateInterval(1, Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Years));
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Punto de entrada en la función recursiva procesarHijos que representa el contenido del datasource en el diagrama de Gantt.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        bool ProcesarHijos(System.Data.DataTable dt)
        {
            Infragistics.Win.UltraWinSchedule.Task tarea = new Infragistics.Win.UltraWinSchedule.Task();
            tarea.Tag = "RAIZ";
            ProcesarHijos(dt, ref tarea, "");
            return true;
        }
        /// <summary>
        /// Función Recursiva que procesa el datasource pintando
        /// en el diagrama el arbol de tareas
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tareaPadre"></param>
        /// <param name="idPadre"></param>
        /// <returns></returns>
        bool ProcesarHijos(System.Data.DataTable dt, ref Infragistics.Win.UltraWinSchedule.Task tareaPadre, string idPadre)
        {
            string select;
            if (string.IsNullOrEmpty(idPadre))
            {
                select = "IdPadreTarea = ''";
            }
            else
            {
                select = "IdPadreTarea = '" + idPadre + "'";
            }
            foreach (System.Data.DataRow fila in dt.Select(select))
            {
                Infragistics.Win.UltraWinSchedule.Project elProyecto = new Infragistics.Win.UltraWinSchedule.Project();
                if (fila["IdPadreTarea"] == System.DBNull.Value || string.IsNullOrEmpty(fila["IdPadreTarea"].ToString()))
                {
                    // Crear proyecto.
                    elProyecto = new Infragistics.Win.UltraWinSchedule.Project();
                    elProyecto.Name = fila["IdTarea"].ToString();
                    elProyecto.StartDate = System.Convert.ToDateTime(fila["Inicio"]);
                    this.ultraCalendarInfo1.Projects.Add(elProyecto);
                    this.Project = elProyecto;
                }
                Infragistics.Win.UltraWinSchedule.Task tareaNueva = new Infragistics.Win.UltraWinSchedule.Task();
                System.TimeSpan duracion = System.Convert.ToDateTime(fila["Fin"].ToString()) - System.Convert.ToDateTime(fila["Inicio"].ToString());
                if (duracion <= new System.TimeSpan(0, 0, 0))
                {
                    duracion = new System.TimeSpan(0, 0, 0);
                }

                tareaNueva.Duration = duracion;
                tareaNueva.StartDateTime = System.Convert.ToDateTime(fila["Inicio"].ToString());
                tareaNueva.EndDateTime = System.Convert.ToDateTime(fila["Fin"].ToString());
                if (tareaNueva.EndDateTime == System.DateTime.MaxValue)
                {
                    tareaNueva.Milestone = true;
                }
                else
                {
                    tareaNueva.Milestone = false;
                }
                fila["Duracion"] = tareaNueva.Duration.TotalDays.ToString("##0 días");
                tareaNueva.Name = fila["DescTarea"].ToString();
                tareaNueva.Notes = fila["Comentarios"].ToString();
                tareaNueva.PercentComplete = System.Convert.ToInt32(fila["Completado"]);
                if (this.columnas.Limite != null)
                {
                    System.DateTime limite = System.Convert.ToDateTime(fila["Limite"].ToString());
                    if (limite != System.DateTime.MaxValue)
                    {
                        tareaNueva.Deadline = limite;
                    }
                }
                if ("RAIZ".CompareTo(tareaPadre.Tag) == 0)
                {
                    tareaNueva.Project = elProyecto;
                    this.ultraCalendarInfo1.Tasks.Add(tareaNueva);
                }
                else
                {
                    tareaPadre.Tasks.Add(tareaNueva);
                }
                tareaNueva.SetCustomProperty("Info1", fila["Info1"]);
                tareaNueva.SetCustomProperty("Info2", fila["Info2"]);
                tareaNueva.SetCustomProperty("Info3", fila["Info3"]);
                tareaNueva.SetCustomProperty("Info4", fila["Info4"]);
                tareaNueva.SetCustomProperty("Info5", fila["Info5"]);
                tareaNueva.SetCustomProperty("Info6", fila["Info6"]);
                tareaNueva.SetCustomProperty("Info7", fila["Info7"]);
                tareaNueva.SetCustomProperty("Info8", fila["Info8"]);
                tareaNueva.SetCustomProperty("Info9", fila["Info9"]);
                tareaNueva.SetCustomProperty("Duracion", fila["Duracion"]);
                tareaNueva.SetCustomProperty("FInicio", tareaNueva.StartDateTime.ToString("dd/MM/yyyy HH:mm"));
                if (tareaNueva.EndDateTime == System.DateTime.MaxValue)
                {
                    tareaNueva.SetCustomProperty("FFin", "");
                }
                else
                {
                    tareaNueva.SetCustomProperty("FFin", tareaNueva.EndDateTime.ToString("dd/MM/yyyy HH:mm"));
                }

                this.ProcesarHijos(dt, ref tareaNueva, fila["IdTarea"].ToString());
                if ("RAIZ".CompareTo(tareaPadre.Tag) == 0)
                {
                    return true;
                }
            }
            return true;
        }
        void EventoMostrarToolTip(object sender, Infragistics.Win.UltraWinGanttView.TaskToolTipDisplayingEventArgs e)
        {
            Infragistics.Win.ToolTipInfo info = e.ToolTipInfo;
            info.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip;
            info.Title = "Tarea: " + e.Task.Name;
            info.ToolTipText = "";
            info.ToolTipText += "Inicio: " + e.Task.StartDateTime.ToString("dd/MM/yyyy HH:mm");
            info.ToolTipText += "\rFin: " + e.Task.EndDateTime.ToString("dd/MM/yyyy HH:mm");
            info.ToolTipText += "\rComentarios: " + e.Task.Notes;
            info.ToolTipText += "\rAvance: " + (e.Task.PercentComplete / 100).ToString("##0%");
            e.ToolTipInfo = info;
        }
        #endregion
    }
}