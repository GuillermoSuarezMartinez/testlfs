//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 13-02-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Orbita.VA.Comun;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Clase estática para la gestión de mensajes de notificación en la barra de tareas
    /// </summary>
    public static class ONotificacionManager
    {
        #region Atributo(s)
        /// <summary>
        /// Componente de notificación en la barra de tareas
        /// </summary>
        private static NotifyIcon NotifyIcon;

        /// <summary>
        /// Tiemo de visualización
        /// </summary>
        private static int TimeOut;
	    #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Constructor de los campos de la clase
        /// </summary>
        public static void Constructor(NotifyIcon notifyIcon, int timeout)
        {
            NotifyIcon = notifyIcon;
            TimeOut = timeout;
        }

        /// <summary>
        /// Destruye los campos de la clase
        /// </summary>
        public static void Destructor()
        {
            NotifyIcon = null;
        }

        /// <summary>
        /// Visualización de un mensaje en la barra de notificación
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Mensaje(string mensaje)
        {
            if (ODebug.IsWinForms() && (NotifyIcon != null))
            {
                NotifyIcon.ShowBalloonTip(TimeOut, Application.ProductName, mensaje, ToolTipIcon.Info);
            }
        }
        #endregion
    }
}
