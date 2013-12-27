﻿//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 17-09-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using Infragistics.Win.UltraWinDataSource;
using Orbita.VA.Comun;
using Orbita.VA.MaquinasEstados;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Control para la monitorización en el tiempo de variables de tipo bool
    /// </summary>
    public partial class OrbitaGraficaVariableDouble : OrbitaGraficaVariableBase
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaGraficaVariableDouble()
        {
            InitializeComponent();
        }
        #endregion

        #region Método(s) virtual(es)
        /// <summary>
        /// Método que inicializa las propiedades internas
        /// </summary>
        public override void Inicializar(string codigo)
        {
            base.Inicializar(codigo);

            this.ChartVariable.TitleTop.Text = this.Descripcion;
        }

        /// <summary>
        /// Inicia la monitorización en el tiempo de la variable
        /// </summary>
        public override void IniciarEjecucion()
        {
            base.IniciarEjecucion();

            // Se cargan los valores acumulados de la varible
            //int numeroMonitorizaciones = Convert.ToInt32(Math.Round(OVariablesManager.TiempoPermanenciaTrazasEnMemoria.TotalMilliseconds / OVariablesManager.CadenciaMonitorizacion.TotalMilliseconds));
            int numeroMonitorizaciones = TiempoPermanenciaMS / CadenciaMonitorizacionMs;
            DateTime presente = DateTime.Now;
            DateTime ahora = presente - TimeSpan.FromMilliseconds(TiempoPermanenciaMS);
            for (int i = 0; i < numeroMonitorizaciones; i++)
            {
                ahora += TimeSpan.FromMilliseconds(CadenciaMonitorizacionMs);
                UltraDataRow dr = this.varDataSource.Rows.Add();
                dr["Valor"] = 0.0;
                dr["Fecha"] = ahora;
            }
        }

        /// <summary>
        /// Para la monitorización en el tiempo de la variable
        /// </summary>
        public override void PararEjecucion()
        {
            base.PararEjecucion();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento de refresco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void TimerRefresco_Tick(object sender, EventArgs e)
        {
            try
            {
                base.TimerRefresco_Tick(sender, e);


                this.varDataSource.SuspendBindingNotifications();

                UltraDataRow dr = this.varDataSource.Rows.Add();
                dr["Valor"] = Convert.ToDouble(UltimoValor);
                dr["Fecha"] = DateTime.Now;

                this.varDataSource.Rows.RemoveAt(0);

                // Búscamos el máximo y el mínimo
                double minValue = double.MaxValue;
                double maxValue = double.MinValue;
                foreach (UltraDataRow row in this.varDataSource.Rows)
                {
                    double valor = (double)row["Valor"];
                    minValue = valor > minValue ? minValue : valor;
                    maxValue = valor < maxValue ? maxValue : valor;
                }
                double rango = Math.Abs(maxValue - minValue);
                double intervalo = (rango / 10) + 1;

                // Intervalor entre ejes Y
                this.ChartVariable.Axis.Y.TickmarkInterval = intervalo;

                this.varDataSource.ResumeBindingNotifications();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }
        #endregion
    }
}