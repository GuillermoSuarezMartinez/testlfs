namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para los dispositivos Tcp de Siemens.
    /// </summary>
    public class OProtocoloTCPSiemens : Protocolo
    {
        #region Métodos públicos virtuales
        /// <summary>
        /// Procesa el mensaje KeepAlive del PLC.
        /// </summary>
        /// <param name="valor">Valor recibido por el PLC.</param>
        /// <param name="lecturas">Lecturas recibida por el PLC.</param>
        /// <returns></returns>
        public virtual bool KeepAliveProcesar(byte[] valor, out byte[] lecturas)
        {
            lecturas = null;
            return false;
        }
        /// <summary>
        /// Prepara el mensaje KeepAlive de respuesta.
        /// </summary>
        /// <returns>mensaje de respuesta.</returns>
        public virtual byte[] KeepAliveEnviar()
        {
            return null;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="valor">Valor a procesar.</param>
        /// <param name="id">Identificador del mensaje.</param>
        /// <param name="lecturas"></param>
        /// <returns></returns>
        public virtual bool SalidasProcesar(byte[] valor, byte id, out byte[] lecturas)
        {
            lecturas = null;
            return false;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="salidas">Salidas a procesar.</param>
        /// <param name="idMensaje">Identificador del mensaje.</param>
        /// <returns></returns>
        public virtual byte[] SalidasEnviar(byte[] salidas, byte idMensaje)
        {
            return null;
        }
        #endregion Métodos públicos virtuales

        #region Miembros de IDisposable
        /// <summary>
        /// Limpia objetos de memoria.
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