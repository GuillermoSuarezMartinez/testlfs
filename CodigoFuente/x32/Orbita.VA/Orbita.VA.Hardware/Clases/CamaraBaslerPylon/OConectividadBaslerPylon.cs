//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 04/01/2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase encargada de comprobar la conectividad con un dispositivo TCP/IP
    /// </summary>
    public class OConectividadBaslerPylon: OConectividad
    {
        #region Atributo(s)
        /// <summary>
        /// Timer de comprobación del estado de la conexión
        /// </summary>
        private Timer TimerComprobacionConexion;
        /// <summary>
        /// Cronómetro del tiempo sin respuesta de la cámara
        /// </summary>
        private Stopwatch CronometroTiempoSinRespuestaCamara;
        /// <summary>
        /// Identificador interno de la cámara
        /// </summary>
        private string DeviceId;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Inervalo entre comprobaciones
        /// </summary>
        private TimeSpan _IntervaloComprabacion;
        /// <summary>
        /// Inervalo entre comprobaciones
        /// </summary>
        public TimeSpan IntervaloComprabacion
        {
            get { return _IntervaloComprabacion; }
            set { _IntervaloComprabacion = value; }
        }
        #endregion

        #region Propiedad(es) heredada(s)
        /// <summary>
        /// Estado de la conexión
        /// </summary>
        public override EstadoConexion EstadoConexion
        {
            get { return base.EstadoConexion; }
            set
            {
                if (this._EstadoConexion != value)
                {
                    base.EstadoConexion = value;
                }

                switch (value)
                {
                    case EstadoConexion.Reconectado:
                    case EstadoConexion.Conectado:
                        // Actualizo el tiempo sin respuesta de la cámara
                        this.CronometroTiempoSinRespuestaCamara.Stop();
                        this.CronometroTiempoSinRespuestaCamara.Reset();
                        this.CronometroTiempoSinRespuestaCamara.Start();
                        break;
                }
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OConectividadBaslerPylon(string codigo, string deviceId, int intervaloComprobacionMs) :
            base(codigo)
        {
            this._IntervaloComprabacion = TimeSpan.FromMilliseconds(intervaloComprobacionMs);
            this.DeviceId = deviceId;

            // Creación del timer de comprobación de la conexión
            this.TimerComprobacionConexion = new Timer();
            this.TimerComprobacionConexion.Interval = intervaloComprobacionMs;
            this.TimerComprobacionConexion.Enabled = false;

            // Creación del cronómetro de tiempo de espera sin respuesta de la cámara
            this.CronometroTiempoSinRespuestaCamara = new Stopwatch();
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Indica que el dispositivo está conectado
        /// </summary>
        /// <returns>Vedadero si se detecta el dispositivo en la red</returns>
        private bool IsAlive()
        {
            bool resultado = false;

            List<DeviceEnumerator.Device> listaDispositivos = DeviceEnumerator.EnumerateDevices();
            foreach (DeviceEnumerator.Device dispositivo in listaDispositivos)
            {
                if (this.DeviceId == dispositivo.Serial)
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicio de la comprobación
        /// </summary>
        public override void Start()
        {
            base.Start();

            this.TimerComprobacionConexion.Tick += this.TimerComprobacionConexion_Tick;
            this.TimerComprobacionConexion.Start();
        }

        /// <summary>
        /// Finaliza de la comprobación
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            this.TimerComprobacionConexion.Tick -= this.TimerComprobacionConexion_Tick;
            this.TimerComprobacionConexion.Stop();
        }

        /// <summary>
        /// Fuerza una consulta de verificación de la conectividad con el dispositivo TCP/IP
        /// </summary>
        public override bool ForzarVerificacionConectividad()
        {
            bool resultado = false;
            try
            {
                // Verificamos que la cámara está conectada
                resultado = this.IsAlive();
            }
            finally
            {

                // Lanzamos el evento de error de conexión
                if (resultado)
                {
                    if (this.EstadoConexion == EstadoConexion.Reconectando)
                    {
                        this.EstadoConexion = EstadoConexion.Reconectado;
                    }
                    else
                    {
                        this.EstadoConexion = EstadoConexion.Conectado;
                    }
                }
                else
                {
                    if (this.EstadoConexion == EstadoConexion.Conectado)
                    {
                        this.EstadoConexion = EstadoConexion.ErrorConexion;
                    }
                }
            }

            return resultado;
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento del timer de comprobación de la conexión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerComprobacionConexion_Tick(object sender, EventArgs e)
        {
            this.TimerComprobacionConexion.Stop();
            try
            {
                // TimeOut de conectividad
                if (this.Habilitado && (this.EstadoConexion == EstadoConexion.Reconectando) && (this.CronometroTiempoSinRespuestaCamara.Elapsed > this.IntervaloComprabacion))
                {
                    this.ForzarVerificacionConectividad();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error("Conectividad " + this.Codigo, exception);
            }
            this.TimerComprobacionConexion.Start();
        }
        #endregion
    }
}
