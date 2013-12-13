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
using Orbita.Trazabilidad;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Visor de un registro de evento
    /// </summary>
    public partial class OrbitaLogItemViewer : UserControl
    {
        #region Contructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OrbitaLogItemViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Visualización de un log
        /// </summary>
        /// <param name="log"></param>
        public void MostrarLog(LoggerEventArgs log)
        {
            switch (log.Item.NivelLog)
            {
                case NivelLog.Error:
                    this.picImage.Image = Properties.Resources.ImgError64;
                    break;
                case NivelLog.Fatal:
                    this.picImage.Image = Properties.Resources.ImgError64;
                    break;
                default:
                case NivelLog.Warn:
                    this.picImage.Image = Properties.Resources.ImgWarning64;
                    break;
            }
            this.lblTime.Text = log.Item.Fecha.ToString();

            if (log.Excepcion != null)
            {
                this.lblMensaje.Text = log.Excepcion.Message;
            }
            else
            {
                string mensaje = log.Item.Mensaje;
                object[] args = log.Item.GetArgumentos();
                if ((args != null) && (args.Length > 0))
                {
                    foreach (object obj in args)
                    {
                        mensaje += ". " + obj.ToString();
                    }
                }
                this.lblMensaje.Text = mensaje;
            }
            this.Visible = true;
        }

        /// <summary>
        /// Ocultar su información
        /// </summary>
        /// <param name="item"></param>
        public void Ocultar()
        {
            this.Visible = false;
        } 
        #endregion
    }
}
