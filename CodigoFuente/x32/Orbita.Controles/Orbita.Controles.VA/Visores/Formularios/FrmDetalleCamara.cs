//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : aiba�ez
// Last Modified On : 16-11-2012
// Description      : Movido al proyecto Orbita.Controles.VA
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Data;
using System.IO;
using Orbita.VA.Comun;
using Orbita.VA.Hardware;
namespace Orbita.Controles.VA
{
    /// <summary>
    /// Ventana de detalle de la c�mara Axis
    /// </summary>
    public partial class FrmDetalleCamara : FrmDetalleVisor
    {
        #region Constructor
        /// <summary>
        /// Constructor de la c�mara
        /// </summary>
        /// <param name="codigoCamara"></param>
        public FrmDetalleCamara(string codigoCamara):
            base(codigoCamara)
        {
            InitializeComponent();
        }
        #endregion

        #region M�todo(s) heredado(s)
        /// <summary>
        /// Cargamos la informaci�n de la c�mara
        /// </summary>
        protected override void CargarInformacion()
        {
            try
            {
                DataTable dt = global::Orbita.VA.Hardware.AppBD.GetCamara(this.Codigo);
                this.lblCodigoModelo.Text = dt.Rows[0]["CodTipoHardware"].ToString();
                this.lblFabricante.Text = "Fabricante: " + dt.Rows[0]["Fabricante"].ToString();
                this.lblModelo.Text = "Modelo: " + dt.Rows[0]["Modelo"].ToString();
                this.lblResolucion.Text = "Resoluci�n: " + dt.Rows[0]["ResolucionX"].ToString() + " x " + dt.Rows[0]["ResolucionY"].ToString();
                if ((int)dt.Rows[0]["Color"] == 1)
                {
                    this.lblColor.Text = "C�mara RGB";
                }
                else
                {
                    this.lblColor.Text = "C�mara Monocromo";
                }
                this.lblIP.Text = "IP: " + dt.Rows[0]["IPCam_IP"].ToString();
                this.lblFirmware.Text = "Firmware " + dt.Rows[0]["Firmware"].ToString();
                this.lblSerial.Text = "N�mero de serie: " + dt.Rows[0]["Basler_Pilot_DeviceID"].ToString();

                string fileName = dt.Rows[0]["FotoIlustrativa"].ToString();
                if (File.Exists(fileName))
                {
                    this.pbCamara.Load(fileName);
                }

                this.TimerRefresco.Start();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, this.Codigo);
            }
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Cerramos la ventana autom�ticamente despues de 10 segundos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRefresco_Tick(object sender, EventArgs e)
        {
            try
            {
                OCamaraBase camara = OCamaraManager.GetCamara(this.Codigo);
                long contador = camara.ContadorFotografiasTotal;
                this.lblContFotografias.Text = "Contador de fotograf�as: " + contador.ToString();
            }
            catch (Exception exception)
            {
                OLogsControlesVA.ControlesVA.Error(exception, "Apertura de formulario");
            }
        }        
        #endregion
    }
}