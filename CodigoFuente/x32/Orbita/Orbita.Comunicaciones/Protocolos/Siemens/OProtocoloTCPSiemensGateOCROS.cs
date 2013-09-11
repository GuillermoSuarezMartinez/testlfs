using System;
using System.Text;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para GATEOS
    /// </summary>
    public class OProtocoloTCPSiemensGateOCROS : OProtocoloTCPSiemens
    {
        #region Atributos privados
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
        #endregion Atributos privados

        #region Métodos públicos
        /// <summary>
        /// Mensaje de envío KeepAlive al PLC.
        /// </summary>
        /// <returns>Mensaje de respuesta.</returns>
        public override byte[] KeepAliveEnviar()
        {
            var resultado = new byte[FinTramaKeepAliveEnvio + 1];

            resultado[0] = this.STX[0];
            resultado[FinTramaKeepAliveEnvio] = this.CR[0];

            Array.Copy(this.OSData, 0, resultado, 1, this.OSData.Length);
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
        /// Mensaje KeepAlive de respuesta del PLC.
        /// </summary>
        /// <param name="valor">Valor recibido por el PLC.</param>
        /// <param name="lecturas">Lecturas del PLC.</param>
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
        /// <param name="valor">Valor a procesar.</param>
        /// <param name="id">Identificador del mensaje.</param>
        /// <param name="lecturas"></param>
        /// <returns></returns>
        public override bool SalidasProcesar(byte[] valor, byte id, out byte[] lecturas)
        {
            lecturas = null;
            return false;
        }
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
        /// <summary>
        /// Destrucción del objeto
        /// </summary>
        public override void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (this.disposed) return;
            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if (disposing) { }
        }
        #endregion Métodos públicos

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
        public byte[] OSData
        {
            get { return Encoding.ASCII.GetBytes("OSODATA"); }
        }
        /// <summary>
        /// Identificador del mensaje ocr data result.
        /// </summary>
        public byte[] OSDataResult
        {
            get { return Encoding.ASCII.GetBytes("OSODATARESULT"); }
        }
        #endregion Propiedades
    }
}