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
using Orbita.Controles;
using System.IO;
using Orbita.VA.Hardware;
using Orbita.VA.Comun;

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
            this(codigoCamara, string.Empty, OrigenDatos.OrigenBBDD)
        {
        }

        public FrmDetalleCamara(string codigoCamara, string xmlFile, OrigenDatos origenDatos):
            base(codigoCamara, xmlFile, origenDatos)
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
                DataTable dt = Orbita.VA.Hardware.AppBD.GetCamara(this.Codigo);
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
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.Camaras, this.Codigo, exception);
            }
        }
        #endregion
  }
}