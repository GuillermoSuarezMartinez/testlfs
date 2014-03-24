//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 25-11-2013
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
using Orbita.Trazabilidad;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Manejador del visor de logs
    /// </summary>
    public static class OLogsViewerManager
    {
        #region Atributo(s)
        /// <summary>
        /// Items a visualizar
        /// </summary>
        public static Queue<LoggerEventArgs> LastLogs;
        /// <summary>
        /// Capacidad máxima de los logs
        /// </summary>
        public static int MaxCapacity = 10;
        /// <summary>
        /// Nivel mínimo de la traza a guardar
        /// </summary>
        private static NivelLog NivelLog = Orbita.Trazabilidad.NivelLog.Warn;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica si hay logs guardados
        /// </summary>
        public static bool HayLogs
        {
            get
            {
                return LastLogs.Count > 0;
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public static void Constructor(int maxCapacity = 10, NivelLog nivelLog = Orbita.Trazabilidad.NivelLog.Warn)
        {
            MaxCapacity = maxCapacity;
            NivelLog = nivelLog;

            LastLogs = new Queue<LoggerEventArgs>(MaxCapacity);
        }
        /// <summary>
        /// Inicialización de la clase
        /// </summary>
        public static void Inicializar()
        {
        }
        /// <summary>
        /// Destructor de la clase
        /// </summary>
        public static void Destructor()
        {

        }
        /// <summary>
        /// Descturcot de la clase
        /// </summary>
        public static void Finalizar()
        {
            LastLogs.Clear();
        } 

        /// <summary>
        /// Incluye el log en la lista de últimos logs lanzados
        /// </summary>
        /// <param name="log"></param>
        public static void RegistrarLog(LoggerEventArgs log)
        {
            if ((int)log.Item.NivelLog >= (int)NivelLog)
            {
                if (LastLogs.Count == MaxCapacity)
                {
                    LastLogs.Dequeue();
                }
                LastLogs.Enqueue(log);
            }
        }

        /// <summary>
        /// Incluye el log en la lista de últimos logs lanzados
        /// </summary>
        public static void Limpiar()
        {
            LastLogs.Clear();
        }
        #endregion
    }
}
