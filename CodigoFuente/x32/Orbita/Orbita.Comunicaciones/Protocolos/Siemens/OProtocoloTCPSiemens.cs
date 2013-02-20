using System;
using System.Collections.Generic;
using System.Text;
using Orbita.Trazabilidad;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para los dispositivos TSP de siemens
    /// </summary>
    public class OProtocoloTCPSiemens : Protocolo
    {
      

        #region Constructor
        /// <summary>
        /// Protocolo TCP de Siemens
        /// </summary>
        public OProtocoloTCPSiemens()
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
        public virtual byte[] SalidasEnviar(byte[] salidas, byte idMensaje)
        {
            return null;
        }

        /// <summary>
        /// Limpia objetos de memoria
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.disposed)
            {

                // Marcar como desechada ó desechandose,
                // de forma que no se puede ejecutar el
                // código dos veces.
                disposed = true;
            }
        }
        
        #endregion
    }
}
