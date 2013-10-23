using System;
using System.Text;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para GATEOS
    /// </summary>
    public class OProtocoloTCPSiemensGateLPROS : OProtocoloTCPSiemens
    {
        #region Atributos
        /// <summary>
        /// Fin de la trama de keepAlive envio.
        /// </summary>
        private const int FinTramaKeepAliveEnvio = 15;
        /// <summary>
        /// Fin de la trama de keepAlive recepción.
        /// </summary>
        private const int FinTramaKeepAliveRecepcion = 24;
        /// <summary>
        /// Máxima longitud del mensaje.
        /// </summary>
        private const int MaximaLongitudMensaje = 25;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Identificador del mensaje ocr data.
        /// </summary>
        public byte[] OSLData
        {
            get { return Encoding.ASCII.GetBytes("OSLDATA"); }
        }
        /// <summary>
        /// Identificador del mensaje ocr data result.
        /// </summary>
        public byte[] OSLDataResult
        {
            get { return Encoding.ASCII.GetBytes("OSLDATARESULT"); }
        }
        #endregion Propiedades

        #region Métodos públicos sobreescritos
        /// <summary>
        /// KeepAlive de envío al PLC.
        /// </summary>
        /// <returns>Mensaje de envío.</returns>
        public override byte[] KeepAliveEnviar()
        {
            var resultado = new byte[FinTramaKeepAliveEnvio + 1];

            resultado[0] = STX[0];
            resultado[FinTramaKeepAliveEnvio] = CR[0];

            Array.Copy(OSLData, 0, resultado, 1, OSLData.Length);
            resultado[8] = Separador[0];
            resultado[9] = 0;
            resultado[10] = Separador[0];
            resultado[11] = 0;
            resultado[12] = 0;
            resultado[13] = Separador[0];

            var bcc = new byte[3];
            bcc[0] = 0;
            bcc[1] = 0;
            bcc[2] = 0;

            resultado[14] = CalculoBcc(bcc)[0];

            return resultado;
        }
        /// <summary>
        /// Mensaje de KeepAlive recibido del PLC.
        /// </summary>
        /// <param name="bytesRecibidos">Valor recibido por el PLC.</param>
        /// <param name="bytesLecturas">Lecturas del PLC.</param>
        /// <returns></returns >
        public override bool KeepAliveProcesar(byte[] bytesRecibidos, out byte[] bytesLecturas)
        {
            bool resultado = false;
            bytesLecturas = new byte[4];
            var bcc = new byte[5];

            // Comprobar el inicio y fin de trama.
            if (bytesRecibidos[0] == STX[0] && bytesRecibidos[FinTramaKeepAliveRecepcion] == CR[0] && bytesRecibidos.Length == MaximaLongitudMensaje)
            {
                byte id = bytesRecibidos[15];
                Array.Copy(bytesRecibidos, 17, bytesLecturas, 0, 2);
                Array.Copy(bytesRecibidos, 20, bytesLecturas, 2, 2);
                bcc[0] = id;
                Array.Copy(bytesLecturas, 0, bcc, 1, 4);
                if (CalculoBcc(bcc)[0] == bytesRecibidos[23])
                {
                    resultado = true;
                }
            }
            return resultado;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="salidas">Salidas a escribir.</param>
        /// <param name="idMensaje">Identificador del mensaje.</param>
        /// <returns></returns>
        public override byte[] SalidasEnviar(byte[] salidas, byte idMensaje)
        {
            return null;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="bytesRecibidos">Valor a procesar.</param>
        /// <param name="id">Identificador del mensaje.</param>
        /// <param name="bytesLecturas"></param>
        /// <returns></returns>
        public override bool SalidasProcesar(byte[] bytesRecibidos, byte id, out byte[] bytesLecturas)
        {
            bytesLecturas = null;
            return false;
        }
        #endregion Métodos públicos sobreescritos

        #region Métodos privados
        /// <summary>
        /// Cálculo BCC.
        /// </summary>
        /// <param name="bytesRecibidos">Bytes para cálculo.</param>
        /// <returns>BCC.</returns>
        private static byte[] CalculoBcc(byte[] bytesRecibidos)
        {
            int resultado = 0;
            var retorno = new byte[1];
            for (int i = 0; i < (bytesRecibidos.Length - 1); i++)
            {
                if (i == 0)
                {
                    resultado = bytesRecibidos[i] ^ bytesRecibidos[i + 1];
                }
                else
                {
                    resultado = resultado ^ bytesRecibidos[i + 1];
                }
            }
            retorno[0] = (byte)resultado;
            return retorno;
        }
        #endregion

        #region Miembros de IDisposable
        /// <summary>
        /// Destrucción del objeto.
        /// </summary>
        public override void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (Disposed) return;
            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if (disposing) { }
        }
        #endregion Miembros de IDisposable
    }
}