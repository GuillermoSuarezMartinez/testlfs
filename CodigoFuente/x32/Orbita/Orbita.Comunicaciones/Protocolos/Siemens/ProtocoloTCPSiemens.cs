﻿using System;
using System.Collections.Generic;
using System.Text;
using Orbita.Trazabilidad;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para los dispositivos TSP de siemens
    /// </summary>
    public class ProtocoloTCPSiemens : IDisposable
    {
        #region Variables
        /// <summary>
        /// Variable para la llamada al método dispose
        /// </summary>
        public bool disposed = false;
        ///// <summary>
        ///// Logger de la clase
        ///// </summary>
        //public static ILogger wrapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Protocolo TCP de Siemens
        /// </summary>
        public ProtocoloTCPSiemens()
        {
            //wrapper = LogManager.GetLogger("wrapper"); 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Procesa el mensaje keep alive del PLC
        /// </summary>
        /// <param name="valor">valor recibido por el PLC</param>
        /// <param name="lecturas">lecturas recibida por el PLC</param>
        /// <returns></returns>
        public virtual bool KeepAliveProcesar(byte[] valor, out byte[] lecturas)
        {
            lecturas = null;
            return false;
        }
        /// <summary>
        /// Prepara el mensaje keep alive de respuesta
        /// </summary>
        /// <returns>mensaje de respuesta</returns>
        public virtual byte[] KeepAliveEnviar()
        {
            return null;
        }
        /// <summary>
        /// Escritura de salidas
        /// </summary>
        /// <param name="valor">valor a procesar</param>
        /// <param name="id">identificador del mensaje</param>
        /// <returns></returns>
        public virtual bool SalidasProcesar(byte[] valor, byte id)
        {
            return false;
        }
        /// <summary>
        /// Escritura de salidas
        /// </summary>
        /// <param name="salidas">salidas a procesar</param>
        /// <param name="idMensaje">identificador del mensaje</param>
        /// <returns></returns>
        public virtual byte[] SalidasEnviar(byte salidas, byte idMensaje)
        {
            return null;
        }
        /// <summary>
        /// Destrucción del objeto
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Destrucción del objeto
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
           
        }
        #endregion
    }
}
