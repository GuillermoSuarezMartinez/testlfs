﻿//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 16-11-2012
// Description      : Movido al proyecto Orbita.Controles.VA
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Windows.Forms;
using Orbita.Utiles;
using Orbita.VA.Comun;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Formulario para la monitorización de Tiempos de proceso
    /// </summary>
    public partial class FrmMonitorizacionCronometros : FrmBase
    {
        #region Atributo(s)
        /// <summary>
        /// Momento en el que se produjo el último refresco de las variables
        /// </summary>
        DateTime MomentoUltimoRefresco;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la calse
        /// </summary>
        public FrmMonitorizacionCronometros() :
            base()
        {
            InitializeComponent();

            this.ImageListLarge.Images.Add("imgContadorActivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorActivo32);
            this.ImageListLarge.Images.Add("imgContadorInactivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorInactivo32);

            this.ImageListSmall.Images.Add("imgContadorActivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorActivo24);
            this.ImageListSmall.Images.Add("imgContadorInactivo", global::Orbita.Controles.VA.Properties.Resources.imgContadorInactivo24);
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
            this.MomentoUltimoRefresco = DateTime.Now;
            this.TimerRefresco.Interval = Convert.ToInt32(OSistemaManager.Configuracion.CadenciaMonitorizacion.TotalMilliseconds);

            foreach (OCronometro cronometro in OCronometrosManager.ListaCronometros)
            {
                this.CrearItem(cronometro);
            }
        }
        /// <summary>
        /// Carga y muestra datos del formulario en modo nuevo. Se cargan todos datos que se muestran en 
        /// el formulario: grids, combos, etc... Cada carga de elementos estará encapsulada en un método
        /// </summary>
        protected override void CargarDatosModoMonitorizacion()
        {
            base.CargarDatosModoMonitorizacion();

            this.TimerRefresco.Enabled = true;
        }
        /// <summary>
        /// Establece la habiliacion adecuada de los controles para el modo visualizacion
        /// </summary>
        protected override void EstablecerModoMonitorizacion()
        {
            base.EstablecerModoModificacion();
        }
        /// <summary>
        ///  Funciones a realizar al salir del formulario
        /// </summary>
        protected override void AccionesSalir()
        {
            this.TimerRefresco.Enabled = false;
        }
        #endregion

        #region Método(s) privado(s)

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
            //item.SubItems["UltimaEjecucion"].Text = string.Format("{0}:-d:hh:mm:ss.fff}", new DateTime(duracionUltimaEjecucion.Ticks));
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
        #endregion

        #region Evento(s)
        /// <summary>
        /// Refresca la visualización de los cronómetros
        /// </summary>
        private void RefrescarTodosCronometros()
        {
            try
            {
                foreach (ListViewItem item in this.ListView.Items)
                {
                    string codigo = item.Text;

                    OCronometro cronometro = (OCronometro)item.Tag;
                    this.PintarItem(codigo, cronometro.Ejecutando, cronometro.ContadorEjecuciones, cronometro.DuracionUltimaEjecucion, cronometro.DuracionPromedioEjecucion, cronometro.DuracionTotalEjecucion, item);
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosSistema.Monitorizacion, this.Name, exception);
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
                OVALogsManager.Error(ModulosSistema.MonitorizacionVariables, this.Name, exception);
            }
        }

        /// <summary>
        /// Doble clic sobre una variable fuerza su cambio de valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListCronometros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
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
                OVALogsManager.Error(ModulosSistema.Monitorizacion, this.Name, exception);
            }
        }
        #endregion
    }
}