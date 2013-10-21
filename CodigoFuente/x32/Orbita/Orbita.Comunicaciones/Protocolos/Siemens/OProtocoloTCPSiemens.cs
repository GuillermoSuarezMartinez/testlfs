using System;
using System.Text;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para los dispositivos Tcp de Siemens.
    /// </summary>
    public class OProtocoloTCPSiemens : Protocolo
    {
        #region Propiedades
        /// <summary>
        /// Byte inicio trama.
        /// </summary>
        public byte[] STX
        {
            get { return Encoding.ASCII.GetBytes("\x02"); }
        }
        /// <summary>
        /// Byte retorno de carro.
        /// </summary>
        public byte[] CR
        {
            get { return Encoding.ASCII.GetBytes("\x0D"); }
        }
        /// <summary>
        /// Byte separador del mensaje.
        /// </summary>
        public byte[] Separador
        {
            get { return Encoding.ASCII.GetBytes("\x2F"); }
        }
        #endregion

        #region Métodos públicos virtuales
        /// <summary>
        /// Procesar el mensaje KeepAlive del PLC.
        /// </summary>
        /// <param name="bytesRecibidos">Valor recibido por el PLC.</param>
        /// <param name="bytesLecturas">Lecturas recibida por el PLC.</param>
        /// <returns>false.</returns>
        public virtual bool KeepAliveProcesar(byte[] bytesRecibidos, out byte[] bytesLecturas)
        {
            bytesLecturas = null;
            return false;
        }
        /// <summary>
        /// Preparar el mensaje KeepAlive de respuesta.
        /// </summary>
        /// <returns>Mensaje de respuesta.</returns>
        public virtual byte[] KeepAliveEnviar()
        {
            return null;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="bytesRecibidos">Valor a procesar.</param>
        /// <param name="id">Identificador del mensaje.</param>
        /// <param name="bytesLecturas">Colección de lecturas.</param>
        /// <returns></returns>
        public virtual bool SalidasProcesar(byte[] bytesRecibidos, byte id, out byte[] bytesLecturas)
        {
            bytesLecturas = null;
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
        /// <summary>
        /// Deserializar.
        /// </summary>
        /// <param name="bytesRecibidos">Bytes recibidos del mensaje.</param>
        /// <returns></returns>
        public virtual string Deserializar(byte[] bytesRecibidos)
        {
            var bytesMensaje = new byte[13];
            Array.Copy(bytesRecibidos, 1, bytesMensaje, 0, 13);
            return Encoding.ASCII.GetString(bytesMensaje);
        }
        #endregion Métodos públicos virtuales

        #region Miembros de IDisposable
        /// <summary>
        /// Libera objetos de memoria.
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!Disposed)
            {
                // Marcar como desechada ó desechandose,
                // de forma que no se puede ejecutar el
                // código dos veces.
                Disposed = true;
            }
        }
        #endregion
    }
}