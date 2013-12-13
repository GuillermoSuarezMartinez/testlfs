//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 26-03-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Controles.VA;
using Orbita.Trazabilidad;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Control para la visualización de logs
    /// </summary>
    public partial class CtrlLogViewerTactil : OrbitaCtrlTactilBase
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de visores de eventos
        /// </summary>
        private List<OrbitaLogItemViewer> ListaVisoresEventos;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public CtrlLogViewerTactil(string codigo)
            : base(ModoAperturaFormulario.Monitorizacion, codigo, "LogViewer")
        {
            InitializeComponent();

            this.ListaVisoresEventos = new List<OrbitaLogItemViewer>(OLogsViewerManager.MaxCapacity);
        }  
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga de datos
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            for (int i = 0; i < OLogsViewerManager.MaxCapacity; i++)
            {
                OrbitaLogItemViewer logViewer = new OrbitaLogItemViewer();
                logViewer.Visible = false;
                this.PnlLogs.Controls.Add(logViewer);
                logViewer.Dock = DockStyle.Top;
                this.ListaVisoresEventos.Add(logViewer);
            }

            this.Refrescar();

            this.TimerRefresco.Start();
        }

        protected override void AccionesSalir()
        {
            base.AccionesSalir();

            this.TimerRefresco.Stop();

            foreach (OrbitaLogItemViewer logViewer in this.ListaVisoresEventos)
            {
                this.PnlLogs.Controls.Remove(logViewer);
            }
            
            this.ListaVisoresEventos.Clear();
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Refresco de logs
        /// </summary>
        private void Refrescar()
        {
            int i = 0;
            foreach (LoggerEventArgs log in OLogsViewerManager.LastLogs)
            {
                this.ListaVisoresEventos[i].MostrarLog(log);
                i++;
            }
            for (int j = i; j < OLogsViewerManager.MaxCapacity; j++)
            {
                this.ListaVisoresEventos[j].Ocultar();
            }
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Refrescar información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRefresco_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Refrescar();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Error refrescar la información");
            }
        }

        /// <summary>
        /// Borra los registros actuales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                OLogsViewerManager.Limpiar();
                this.Refrescar();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Error limpiar la información");
            }
        }
        #endregion
    }
}
