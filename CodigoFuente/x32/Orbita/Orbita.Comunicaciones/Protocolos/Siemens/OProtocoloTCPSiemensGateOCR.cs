using System;
using System.Text;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para GATE OCR
    /// </summary>
    public class OProtocoloTCPSiemensGateOCR : OProtocoloTCPSiemens
    {
        #region Atributos
        /// <summary>
        /// Fin de la trama de keepAlive envio.
        /// </summary>
        private const int FinTramaKeepAliveEnvio = 17;
        /// <summary>
        /// Fin de la trama de keepAlive recepción.
        /// </summary>
        private const int FinTramaKeepAliveRecepcion = 32;
        /// <summary>
        /// Máxima longitud del mensaje.
        /// </summary>
        private const int MaximaLongitudMensaje = 33;
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Identificador del mensaje OCR data.
        /// </summary>
        public byte[] OCRData
        {
            get { return Encoding.ASCII.GetBytes("OCRDATA"); }
        }
        /// <summary>
        /// Identificador del mensaje OCR data result.
        /// </summary>
        public byte[] OCRDataResult
        {
            get { return Encoding.ASCII.GetBytes("OCRDATARESULT"); }
        }
        #endregion Propiedades

        #region Métodos públicos sobreescritos
        /// <summary>
        /// Mensaje de KeepAlive que se envía al PLC.
        /// </summary>
        /// <returns>Mensaje de respuesta.</returns>
        public override byte[] KeepAliveEnviar()
        {
            var resultado = new byte[FinTramaKeepAliveEnvio + 1];

            resultado[0] = STX[0];
            resultado[FinTramaKeepAliveEnvio] = CR[0];

            Array.Copy(OCRData, 0, resultado, 1, OCRData.Length);
            resultado[8] = Separador[0];
            resultado[9] = 0;
            resultado[10] = Separador[0];
            resultado[11] = 0;
            resultado[12] = 0;
            resultado[13] = 0;
            resultado[14] = 0;
            resultado[15] = Separador[0];

            var bcc = new byte[5];
            bcc[0] = 0;
            bcc[1] = 0;
            bcc[2] = 0;
            bcc[3] = 0;
            bcc[4] = 0;

            resultado[16] = CalculoBcc(bcc)[0];
            return resultado;
        }
        /// <summary>
        /// Mensaje de KeepAlive que se recibe del PLC.
        /// </summary>
        /// <param name="bytesRecibidos">Valor recibido por el PLC.</param>
        /// <param name="bytesLecturas">Lecturas leídas en el PLC.</param>
        /// <returns>El resultado de la comprobación de la redundancia cíclica.</returns>
        public override bool KeepAliveProcesar(byte[] bytesRecibidos, out byte[] bytesLecturas)
        {
            bool resultado = false;
            bytesLecturas = new byte[12];
            var bcc = new byte[13];

            // Comprobar el inicio y fin de trama.
            if (bytesRecibidos[0] == STX[0] && bytesRecibidos[FinTramaKeepAliveRecepcion] == CR[0] && bytesRecibidos.Length == MaximaLongitudMensaje)
            {
                byte id = bytesRecibidos[15];
                Array.Copy(bytesRecibidos, 17, bytesLecturas, 0, 8);
                Array.Copy(bytesRecibidos, 26, bytesLecturas, 8, 4);
                bcc[0] = id;
                Array.Copy(bytesLecturas, 0, bcc, 1, 12);
                if (CalculoBcc(bcc)[0] == bytesRecibidos[31])
                {
                    resultado = true;
                }
            }
            return resultado;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="salidas">Salidas a procesar.</param>
        /// <param name="idMensaje">Identificador del mensaje.</param>
        /// <returns></returns>
        public override byte[] SalidasEnviar(byte[] salidas, byte idMensaje)
        {
            byte[] resultado = KeepAliveEnviar();
            resultado[9] = idMensaje;
            resultado[11] = salidas[0];
            resultado[12] = salidas[1];
            resultado[13] = salidas[2];
            resultado[14] = salidas[3];
            var bcc = new byte[5];

            bcc[0] = idMensaje;
            bcc[1] = salidas[0];
            bcc[2] = salidas[1];
            bcc[3] = salidas[2];
            bcc[4] = salidas[3];

            resultado[16] = CalculoBcc(bcc)[0];
            return resultado;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="bytesRecibidos">Valor a preocesar.</param>
        /// <param name="id">Identificador del mensaje.</param>
        /// <param name="bytesLecturas">Colección de lecturas.</param>
        /// <returns></returns>
        public override bool SalidasProcesar(byte[] bytesRecibidos, byte id, out byte[] bytesLecturas)
        {
            bool resultado = false;
            var entradas = new byte[8];
            var salidas = new byte[4];
            var bcc = new byte[13];
            bytesLecturas = new byte[12];

            // Comprobar el inicio y fin de trama.
            if (bytesRecibidos[0] == STX[0] && bytesRecibidos[FinTramaKeepAliveRecepcion] == CR[0] && bytesRecibidos.Length == MaximaLongitudMensaje)
            {
                Array.Copy(bytesRecibidos, 17, entradas, 0, 8); // Entradas.
                Array.Copy(bytesRecibidos, 26, salidas, 0, 4);  // Salidas.

                // Cálculo de la redundancia cíclica a partir del identificador del mensaje.
                bcc[0] = bytesRecibidos[15];
                Array.Copy(entradas, 0, bcc, 1, 8);
                Array.Copy(salidas, 0, bcc, 9, 4);

                Array.Copy(entradas, 0, bytesLecturas, 0, 8); // Entradas resultado.
                Array.Copy(salidas, 0, bytesLecturas, 8, 4);  // Salidas resultado.

                if (CalculoBcc(bcc)[0] == bytesRecibidos[31])
                {
                    resultado = true;
                }
            }
            return resultado;
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
        #endregion Métodos privados

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