//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 08-05-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase encargada de comprobar la conectividad con un dispositivo TCP/IP
    /// </summary>
    public class OConectividadBitVida : OConectividad
    {
        #region Atributo(s)
        /// <summary>
        /// Timer de comprobación del estado de la conexión
        /// </summary>
        private Timer TimerComprobacionConexion;
        /// <summary>
        /// Cronómetro del tiempo sin respuesta de la cámara
        /// </summary>
        private Stopwatch CronometroTiempoSinRespuesta;
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
                        // Actualizo el tiempo sin respuesta
                        this.CronometroTiempoSinRespuesta.Stop();
                        this.CronometroTiempoSinRespuesta.Reset();
                        this.CronometroTiempoSinRespuesta.Start();
                        break;
                }
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OConectividadBitVida(string codigo, int intervaloComprobacionMs) :
            base(codigo)
        {
            this._IntervaloComprabacion = TimeSpan.FromMilliseconds(intervaloComprobacionMs);

            // Creación del timer de comprobación de la conexión
            this.TimerComprobacionConexion = new Timer();
            this.TimerComprobacionConexion.Interval = intervaloComprobacionMs;
            this.TimerComprobacionConexion.Enabled = false;

            // Creación del cronómetro de tiempo de espera sin respuesta de la cámara
            this.CronometroTiempoSinRespuesta = new Stopwatch();
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
            this.EstablecerConexion(true);
            return true;
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Evento de ping completado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstablecerConexion(bool conexion)
        {
            try
            {
                if (this.Habilitado)
                {
                    if (conexion)
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
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, "Conectividad " + this.Codigo);
            }
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
                if (this.Habilitado && (this.CronometroTiempoSinRespuesta.Elapsed > this.IntervaloComprabacion))
                {
                    this.EstablecerConexion(false);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, "Conectividad " + this.Codigo);
            }
            this.TimerComprobacionConexion.Start();
        }
        #endregion
    }
}
