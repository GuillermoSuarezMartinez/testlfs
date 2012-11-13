//***********************************************************************
// Assembly         : Orbita.VAHardware
// Author           : aiba�ez
// Created          : 06-09-2012
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using Orbita.VAComun;

namespace Orbita.VAHardware
{
    public partial class FrmGestionCamaraAxis : FrmBase
    {
        #region Atributo(s)
        /// <summary>
        /// Direcci�n IP de la c�mara
        /// </summary>
        private string IP = "";
        #endregion

        #region Constructor
        public FrmGestionCamaraAxis(string direccionIP)
            : base(ModoAperturaFormulario.Visualizacion)
        {
            InitializeComponent();
            this.IP = direccionIP;
        }
        #endregion

        #region M�todo(s) heredado(s)
        /// <summary>
        /// Carga y muestra datos del formulario comunes para los tres modos de funcionamiento
        /// </summary>
        protected override void CargarDatosComunes()
        {
            base.CargarDatosComunes();

            Uri uri1 = new Uri(" http://" + this.IP);
            this.webBrowser.Navigate(uri1);
            return;
        }
        
        #endregion M�todos virtuales

    }
}