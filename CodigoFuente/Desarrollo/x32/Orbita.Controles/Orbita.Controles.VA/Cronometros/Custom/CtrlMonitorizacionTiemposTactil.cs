//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 03-02-2014
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
using System.Collections.Generic;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Formulario para la monitorización de variables
    /// </summary>
    public partial class CtrlMonitorizacionTiemposTactil : OrbitaCtrlTactilBase
    {
        #region Atributo(s)
        /// <summary>
        /// Intervalo entre muestreo
        /// </summary>
        private int CadenciaMonitorizacionMs;

        /// <summary>
        /// Lista de cronómetros a refrescar
        /// </summary>
        private Dictionary<string, bool> ListaCronometrosARefrescar;

        /// <summary>
        /// Permite el bloqueo de la ListaCronometrosARefrescar para el uso multithread
        /// </summary>
        private object ListaCronometrosARefrescarLockObject = new object();
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la calse
        /// </summary>
        public CtrlMonitorizacionTiemposTactil(string codigo, int cadenciaMonitorizacionMs = 500, Control contenedor = null) :
            base(ModoAperturaFormulario.Monitorizacion, codigo, "Monitor de los cronómetros del sistema", contenedor)
        {
            InitializeComponent();

            this.ImageListLarge.Images.Add("imgContadorActivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorActivoTactil24);
            this.ImageListLarge.Images.Add("imgContadorInactivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorInactivoTactil24);

            this.ImageListSmall.Images.Add("imgContadorActivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorActivoTactil24);
            this.ImageListSmall.Images.Add("imgContadorInactivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorInactivoTactil24);

            this.CadenciaMonitorizacionMs = cadenciaMonitorizacionMs;
            this.ListaCronometrosARefrescar = new Dictionary<string, bool>();
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los tres modos de funcionamiento
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            // Inicializamos el timer de refresco
            this.TimerRefresco.Interval = CadenciaMonitorizacionMs;
        }
        /// <summary>
        /// Carga y muestra datos del formulario en modo nuevo. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estará encapsulada en un método
        /// </summary>
        protected override void CargarDatosModoMonitorizacion()
        {
            base.CargarDatosModoMonitorizacion();

            this.CrearItems();

            this.TimerRefresco.Enabled = true;
        }
        /// <summary>
        ///  Funciones a realizar al salir del formulario
        /// </summary>
        protected override void AccionesSalir()
        {
            base.AccionesSalir();

            this.TimerRefresco.Enabled = false;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Crea los items de los cronómetros
        /// </summary>
        private void CrearItems()
        {
            foreach (OCronometro cronometro in OCronometrosManager.ListaCronometros)
            {
                this.CrearItem(cronometro);
                this.ListaCronometrosARefrescar[cronometro.Codigo] = false;
            }
            OCronometrosManager.CrearSuscripcionTodos(EventoRefrescarCronometros);
        }

        /// <summary>
        /// Destruye los items de todos los cronómetros
        /// </summary>
        private void DestruirItems()
        {
            OCronometrosManager.EliminarSuscripcionTodos(EventoRefrescarCronometros);

            this.ListView.Items.Clear();
        }

        /// <summary>
        /// Dibuja un item en la lista de variables
        /// </summary>
        /// <param name="cronometro">Variable a visualizar</param>
        private void CrearItem(OCronometro cronometro)
        {
            string codigo = cronometro.Codigo;
            string nombre = cronometro.Nombre;
            string descripcion = cronometro.Descripcion;

            ListViewItem item = new ListViewItem();

            item.Name = codigo;
            item.Text = nombre;
            item.ToolTipText = descripcion;
            item.Tag = cronometro;

            ListViewItem.ListViewSubItem subItemDescCronometro = new ListViewItem.ListViewSubItem();
            subItemDescCronometro.Name = "Descripcion";
            subItemDescCronometro.Text = descripcion;
            item.SubItems.Add(subItemDescCronometro);

            ListViewItem.ListViewSubItem subItemContador = new ListViewItem.ListViewSubItem();
            subItemContador.Name = "Contador";
            item.SubItems.Add(subItemContador);

            ListViewItem.ListViewSubItem subItemUltimaEjecucion = new ListViewItem.ListViewSubItem();
            subItemUltimaEjecucion.Name = "UltimaEjecucion";
            item.SubItems.Add(subItemUltimaEjecucion);

            ListViewItem.ListViewSubItem subItemPromedio = new ListViewItem.ListViewSubItem();
            subItemPromedio.Name = "Promedio";
            item.SubItems.Add(subItemPromedio);

            ListViewItem.ListViewSubItem subItemTotal = new ListViewItem.ListViewSubItem();
            subItemTotal.Name = "Total";
            item.SubItems.Add(subItemTotal);

            this.PintarItem(codigo, cronometro.Ejecutando, cronometro.ContadorEjecuciones, cronometro.DuracionUltimaEjecucion, cronometro.DuracionPromedioEjecucion, cronometro.DuracionTotalEjecucion, item);

            this.ListView.Items.Add(item);
        }

        /// <summary>
        /// Visualiza el valor del item
        /// </summary>
        /// <param name="codigo">código de la variable</param>
        /// <param name="valor">valor genérico de la variable</param>
        /// <param name="item">item del componente listview</param>
        private void PintarItem(string codigo, bool ejecutando, long contadorEjecuciones, TimeSpan duracionUltimaEjecucion, TimeSpan duracionPromedioEjecucion, TimeSpan duracionTotalEjecucion, ListViewItem item)
        {
            //item.SubItems["Ejecutando"].Text = ejecutando.ToString();
            item.SubItems["Contador"].Text = contadorEjecuciones.ToString();
            item.SubItems["UltimaEjecucion"].Text = string.Format("{0:#######0} {1:00}:{2:00}:{3:00.000}", duracionUltimaEjecucion.TotalDays, duracionUltimaEjecucion.Hours, duracionUltimaEjecucion.Minutes, (double)duracionUltimaEjecucion.Seconds + (double)duracionUltimaEjecucion.Milliseconds / 1000);
            item.SubItems["Promedio"].Text = string.Format("{0:#######0} {1:00}:{2:00}:{3:00.000}", duracionPromedioEjecucion.TotalDays, duracionUltimaEjecucion.Hours, duracionPromedioEjecucion.Minutes, (double)duracionPromedioEjecucion.Seconds + (double)duracionPromedioEjecucion.Milliseconds / 1000);
            item.SubItems["Total"].Text = string.Format("{0:#######0} {1:00}:{2:00}:{3:00.000}", duracionTotalEjecucion.TotalDays, duracionUltimaEjecucion.Hours, duracionTotalEjecucion.Minutes, (double)duracionTotalEjecucion.Seconds + (double)duracionTotalEjecucion.Milliseconds / 1000);

            if (ejecutando)
            {
                item.ImageKey = "imgContadorActivo";
            }
            else
            {
                item.ImageKey = "imgContadorInactivo";
            }
        }

        /// <summary>
        /// Refresca la visualización de los cronómetros
        /// </summary>
        private void RefrescarTodosCronometros()
        {
            foreach (ListViewItem item in this.ListView.Items)
            {
                OCronometro cronometro = (OCronometro)item.Tag;
                string codigo = cronometro.Codigo;

                bool refrescar;
                bool existe;

                lock (ListaCronometrosARefrescarLockObject)
                {
                    existe = ListaCronometrosARefrescar.TryGetValue(codigo, out refrescar);
                }

                if (existe && refrescar)
                {
                    ListaCronometrosARefrescar[codigo] = false;
                    this.PintarItem(codigo, cronometro.Ejecutando, cronometro.ContadorEjecuciones, cronometro.DuracionUltimaEjecucion, cronometro.DuracionPromedioEjecucion, cronometro.DuracionTotalEjecucion, item);
                }
            }
        }

        #endregion

        #region Evento(s)
        /// <summary>
        /// Refresca la visualización de los cronómetros
        /// </summary>
        private void EventoRefrescarCronometros(string codigo)
        {
            try
            {
                lock (ListaCronometrosARefrescarLockObject)
                {
                    ListaCronometrosARefrescar[codigo] = true;
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Clic en la lista del botón desplegable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case "KeyIconosGrandes":
                        this.ListView.View = View.LargeIcon;
                        break;
                    case "KeyIconosPequeños":
                        this.ListView.View = View.SmallIcon;
                        break;
                    case "KeyLista":
                        this.ListView.View = View.List;
                        break;
                    case "KeyDetalles":
                        this.ListView.View = View.Details;
                        break;
                    case "Monitorizar":    // ButtonTool
                        break;
                }
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Timer de refresco del estado actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRefresco_Tick(object sender, EventArgs e)
        {
            try
            {
                this.RefrescarTodosCronometros();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }
        #endregion
    }
}
