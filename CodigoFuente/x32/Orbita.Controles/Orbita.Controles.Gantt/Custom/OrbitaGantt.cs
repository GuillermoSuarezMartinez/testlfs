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
    public partial class OrbitaGantt : Orbita.Controles.Shared.OrbitaUserControl
    {
        #region Atributos
        /// <summary>
        /// Zoom al Gantt.
        /// </summary>
        System.Data.DataTable dtZoom = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.OrbitaGantt.
        /// </summary>
        public OrbitaGantt()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos y delegados
        /// <summary>
        /// Delegado OrbDelegadoBotonVolver.
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento.</param>
        /// <param name="e">System.EventArgs es la clase base para las clases que contienen datos de eventos.</param>
        public delegate void OrbDelegadoBotonVolver(object sender, System.EventArgs e);
        /// <summary>
        /// Volver Button Click
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Volver Button Click.")]
        public event OrbDelegadoBotonVolver OrbBotonVolverClick;
        /// <summary>
        /// Toolbar Button Click genérico
        /// </summary>
        [System.ComponentModel.Category("Orbita Botones")]
        [System.ComponentModel.Description("Toolbar Button Click.")]
        event OrbDelegadoBotonToolBar OrbBotonToolbarClick;
        /// <summary>
        /// Delegado para el toolclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OrbDelegadoBotonToolBar(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve la estructura de origen de datos necesaria para llamar a OrbFormatear
        /// </summary>
        public System.Data.DataTable OrbDatasource
        {
            get { return this.orbitaGantt1.Datasource; }
        }
        /// <summary>
        /// Define las columnas que mostrará el grid de tareas
        /// </summary>
        public Orbita.Controles.Gantt.OColumnHeaderCollection OrbColumnas
        {
            get { return this.orbitaGantt1.Columnas; }
            set { this.orbitaGantt1.Columnas = value; }
        }
        /// <summary>
        /// Define la resolución que mostrará la línea temporal
        /// </summary>
        public Orbita.Controles.Gantt.Resoluciones OrbResolucion
        {
            get { return this.orbitaGantt1.Resolucion; }
            set { this.orbitaGantt1.Resolucion = value; }
        }
        /// <summary>
        /// Define la visibilidad de la toolbar superior
        /// </summary>
        public bool OrbToolBarVisible
        {
            get { return this.OrbitaUltraToolbarsManager1.Visible; }
            set { this.OrbitaUltraToolbarsManager1.Visible = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Representa en el diagrama el contenido del datasource
        /// </summary>
        /// <param name="dt">Esta tabla debe obtenerse de la propiedad datasource del control
        /// y debe ser rellenada con la funcion añadirFila del control</param>
        /// <returns>resultado de la operación</returns>
        public bool OrbFormatear(System.Data.DataTable dt)
        {
            this.dtZoom = dt;
            this.orbitaGantt1.OrbFormatear(dt);
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
        public static bool OrbAñadirFila(ref System.Data.DataTable dt, string idTarea, string idPadre, string descripcion, string comentarios, int completado, System.DateTime inicio, System.DateTime fin, System.DateTime limite, object info1, object info2, object info3, object info4, object info5, object info6, object info7, object info8, object info9)
        {
            return OrbitaUltraGanttView.AñadirFila(ref dt, idTarea, idPadre, descripcion, comentarios, completado, inicio, fin, limite, info1, info2, info3, info4, info5, info6, info7, info8, info9);
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
        public static bool OrbAñadirFila(ref System.Data.DataTable dt, string idTarea, string idPadre, string descripcion, string comentarios, int completado, System.DateTime inicio, System.DateTime fin, System.DateTime limite)
        {
            return OrbitaUltraGanttView.AñadirFila(ref dt, idTarea, idPadre, descripcion, comentarios, completado, inicio, fin, limite);
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Captura de los clicks de los botones de la toolbar para reenviarlos como eventos custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OrbitaUltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case "Volver":
                        OrbBotonVolverClick(sender, new System.EventArgs());
                        break;
                    case "Reducir":
                        if (this.dtZoom != null)
                        {
                            switch (this.orbitaGantt1.Resolucion)
                            {
                                case Resoluciones.Hora:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora2;
                                    break;
                                case Resoluciones.Hora2:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora4;
                                    break;
                                case Resoluciones.Hora4:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora6;
                                    break;
                                case Resoluciones.Hora6:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora12;
                                    break;
                                case Resoluciones.Hora12:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Dia;
                                    break;
                                case Resoluciones.Dia:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Semana;
                                    break;
                                case Resoluciones.Semana:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Mes;
                                    break;
                                case Resoluciones.Mes:
                                    break;
                                default:
                                    break;
                            }
                            this.orbitaGantt1.EstablecerResolucion();
                        }
                        break;
                    case "Ampliar":
                        if (this.dtZoom != null)
                        {
                            switch (this.orbitaGantt1.Resolucion)
                            {
                                case Resoluciones.Hora2:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora;
                                    break;
                                case Resoluciones.Hora4:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora2;
                                    break;
                                case Resoluciones.Hora6:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora4;
                                    break;
                                case Resoluciones.Hora12:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora6;
                                    break;
                                case Resoluciones.Dia:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Hora12;
                                    break;
                                case Resoluciones.Semana:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Dia;
                                    break;
                                case Resoluciones.Mes:
                                    this.orbitaGantt1.Resolucion = Resoluciones.Semana;
                                    break;
                                default:
                                    break;
                            }
                            this.orbitaGantt1.EstablecerResolucion();
                        }
                        break;
                    default:
                        OrbBotonToolbarClick(sender, e);
                        break;
                }
            }
            catch (Orbita.Controles.Shared.OExcepcion ex)
            {
                throw new Orbita.Controles.Shared.OExcepcion("Excepción no controlada en OrbitaGantt", ex.InnerException);
            }
        }
        #endregion
    }
}