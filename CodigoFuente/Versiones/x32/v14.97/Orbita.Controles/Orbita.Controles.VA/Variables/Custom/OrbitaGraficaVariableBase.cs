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
using Orbita.VA.Comun;
using Orbita.VA.MaquinasEstados;
namespace Orbita.Controles.VA
{
    public partial class OrbitaGraficaVariableBase : UserControl
    {
        #region Constante(s)
        /// <summary>
        /// Tiempo de permanencia de las información visualizada
        /// </summary>
        protected const int TiempoPermanenciaMS = 60000;
        /// <summary>
        /// Intervalo entre muestreo
        /// </summary>
        protected const int CadenciaMonitorizacionMs = 100;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Código de la variable
        /// </summary>
        protected string Codigo;
        /// <summary>
        /// Descripción de la variable
        /// </summary>
        protected string Descripcion;
        /// <summary>
        /// Último valor registrado de la variable
        /// </summary>
        protected object UltimoValor;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaGraficaVariableBase()
        {
            InitializeComponent();

            //Creación de variables internas
            this.UltimoValor = null;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Método que inicializa las propiedades internas
        /// </summary>
        public virtual void Inicializar(string codigo)
        {
            // Inicializar variables
            this.Codigo = codigo;
            OVariable variable = OVariablesManager.GetVariable(codigo);
            if (variable != null)
            {
                this.Descripcion = variable.Descripcion;
            }

            //this.TimerRefresco.Interval = Convert.ToInt32(OVariablesManager.CadenciaMonitorizacion.TotalMilliseconds) * 2;
            this.TimerRefresco.Interval = CadenciaMonitorizacionMs;
            this.TimerRefresco.Tick += new EventHandler(this.TimerRefresco_Tick);
            this.TimerRefresco.Enabled = true;
        }

        /// <summary>
        /// Inicia la monitorización en el tiempo de la variable
        /// </summary>
        public virtual void IniciarEjecucion()
        {
            this.TimerRefresco.Start();
            OVariablesManager.CrearSuscripcion(this.Codigo, "Monitorización", this.Name, RefrescarVariables);
        }

        /// <summary>
        /// Para la monitorización en el tiempo de la variable
        /// </summary>
        public virtual void PararEjecucion()
        {
            this.TimerRefresco.Enabled = false;
            this.TimerRefresco.Stop();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Refresca la visualización de las variables
        /// </summary>
        protected void RefrescarVariables(string codigo, object valor)
        {
            try
            {
                this.UltimoValor = valor;
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Name);
            }
        }

        /// <summary>
        /// Evento de refresco del timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void TimerRefresco_Tick(object sender, EventArgs e)
        {
        }

        #endregion
    }
}