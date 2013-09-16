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
        /// Tamaño máximo de trama.
        /// </summary>
        private const int TamanyoMensaje = 33;
        #endregion Atributos

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
        /// <summary>
        /// Identificador del mensaje ocr data.
        /// </summary>
        public byte[] OCRData
        {
            get { return Encoding.ASCII.GetBytes("OCRDATA"); }
        }
        /// <summary>
        /// Identificador del mensaje ocr data result.
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
        /// <returns>mensaje de respuesta</returns>
        public override byte[] KeepAliveEnviar()
        {
            var resultado = new byte[FinTramaKeepAliveEnvio + 1];

            resultado[0] = this.STX[0];
            resultado[FinTramaKeepAliveEnvio] = this.CR[0];

            Array.Copy(this.OCRData, 0, resultado, 1, this.OCRData.Length);
            resultado[8] = this.Separador[0];
            resultado[9] = 0;
            resultado[10] = this.Separador[0];
            resultado[11] = 0;
            resultado[12] = 0;
            resultado[13] = 0;
            resultado[14] = 0;
            resultado[15] = this.Separador[0];

            var bcc = new byte[5];
            bcc[0] = 0;
            bcc[1] = 0;
            bcc[2] = 0;
            bcc[3] = 0;
            bcc[4] = 0;

            resultado[16] = CalculoBCC(bcc)[0];
            return resultado;
        }
        /// <summary>
        /// Mensaje de KeepAlive que se recibe del PLC.
        /// </summary>
        /// <param name="valor">valor recibido por el PLC</param>
        /// <param name="lecturas">lecturas leídas en el PLC</param>
        /// <returns></returns>
        public override bool KeepAliveProcesar(byte[] valor, out byte[] lecturas)
        {
            bool resultado = false;
            lecturas = new byte[12];
            var bcc = new byte[13];

            // Comprobar el inicio y fin de trama.
            if (valor[0] == this.STX[0] && valor[FinTramaKeepAliveRecepcion] == this.CR[0] && valor.Length == TamanyoMensaje)
            {
                byte id = valor[15];
                Array.Copy(valor, 17, lecturas, 0, 8);
                Array.Copy(valor, 26, lecturas, 8, 4);
                bcc[0] = id;
                Array.Copy(lecturas, 0, bcc, 1, 12);
                if (CalculoBCC(bcc)[0] == valor[31])
                {
                    resultado = true;
                }
            }
            return resultado;
        }
        /// <summary>
        /// Escritura de salidas
        /// </summary>
        /// <param name="salidas">salidas a procesar</param>
        /// <param name="idMensaje">identificador del mensaje</param>
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

            resultado[16] = CalculoBCC(bcc)[0];
            return resultado;
        }
        /// <summary>
        /// Escritura de salidas
        /// </summary>
        /// <param name="valor">valor a preocesar</param>
        /// <param name="id">identificador del mensaje</param>
        /// <param name="lecturas"></param>
        /// <returns></returns>
        public override bool SalidasProcesar(byte[] valor, byte id, out byte[] lecturas)
        {
            bool resultado = false;
            var entradas = new byte[8];
            var salidas = new byte[4];
            var bcc = new byte[13];
            lecturas = new byte[12];

            // Comprobar el inicio y fin de trama.
            if (valor[0] == this.STX[0] && valor[FinTramaKeepAliveRecepcion] == this.CR[0] && valor.Length == TamanyoMensaje)
            {
                Array.Copy(valor, 17, entradas, 0, 8); // Entradas.
                Array.Copy(valor, 26, salidas, 0, 4);  // Salidas.

                // Cálculo de la redundancia cíclica a partir del identificador del mensaje.
                bcc[0] = valor[15];
                Array.Copy(entradas, 0, bcc, 1, 8);
                Array.Copy(salidas, 0, bcc, 9, 4);

                Array.Copy(entradas, 0, lecturas, 0, 8); // Entradas resultado.
                Array.Copy(salidas, 0, lecturas, 8, 4);  // Salidas resultado.

                if (CalculoBCC(bcc)[0] == valor[31])
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
        /// <param name="dato">Bytes para cálculo.</param>
        /// <returns>BCC.</returns>
        private static byte[] CalculoBCC(byte[] dato)
        {
            int resultado = 0;
            var retorno = new byte[1];
            for (int i = 0; i < (dato.Length - 1); i++)
            {
                if (i == 0)
                {
                    resultado = dato[i] ^ dato[i + 1];
                }
                else
                {
                    resultado = resultado ^ dato[i + 1];
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
            if (this.Disposed) return;
            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if (disposing) { }
        }
        #endregion Miembros de IDisposable
    }
}