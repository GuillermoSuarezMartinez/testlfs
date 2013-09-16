using System;
using System.Text;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para GATE LPR de Siemens.
    /// </summary>
    public class OProtocoloTCPSiemensGateLPR : OProtocoloTCPSiemens
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
        /// Tamaño máximo de trama.
        /// </summary>
        private const int TamanyoMensaje = 25;
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
        /// Identificador del mensaje LPR data.
        /// </summary>
        public byte[] LPRData
        {
            get { return Encoding.ASCII.GetBytes("LPRDATA"); }
        }
        /// <summary>
        /// Identificador del mensaje LPR data result.
        /// </summary>
        public byte[] LPRDataResult
        {
            get { return Encoding.ASCII.GetBytes("lprDATARESULT"); }
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

            resultado[0] = this.STX[0];
            resultado[FinTramaKeepAliveEnvio] = this.CR[0];

            Array.Copy(this.LPRData, 0, resultado, 1, this.LPRData.Length);
            resultado[8] = this.Separador[0];
            resultado[9] = 0;
            resultado[10] = this.Separador[0];
            resultado[11] = 0;
            resultado[12] = 0;
            resultado[13] = this.Separador[0];

            var bcc = new byte[3];
            bcc[0] = 0;
            bcc[1] = 0;
            bcc[2] = 0;

            resultado[14] = CalculoBCC(bcc)[0];

            return resultado;
        }
        /// <summary>
        /// KeepAlive de recepción del PLC.
        /// </summary>
        /// <param name="valor">Valor recibido por el PLC.</param>
        /// <param name="lecturas">Lecturas leídas en el PLC.</param>
        /// <returns></returns>
        public override bool KeepAliveProcesar(byte[] valor, out byte[] lecturas)
        {
            bool resultado = false;
            lecturas = new byte[4];
            var bcc = new byte[5];

            // Comprobar el inicio y fin de trama.
            if (valor[0] == this.STX[0] && valor[FinTramaKeepAliveRecepcion] == this.CR[0] && valor.Length == TamanyoMensaje)
            {
                byte id = valor[15];
                Array.Copy(valor, 17, lecturas, 0, 2);
                Array.Copy(valor, 20, lecturas, 2, 2);
                bcc[0] = id;
                Array.Copy(lecturas, 0, bcc, 1, 4);
                if (CalculoBCC(bcc)[0] == valor[23])
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

            var bcc = new byte[3];

            bcc[0] = idMensaje;
            bcc[1] = salidas[0];
            bcc[2] = salidas[1];

            resultado[14] = CalculoBCC(bcc)[0];

            return resultado;
        }
        /// <summary>
        /// Escritura de salidas.
        /// </summary>
        /// <param name="valor">Valor a preprocesar.</param>
        /// <param name="id">Identificador del mensaje.</param>
        /// <param name="lecturas">Lecturas leídas en el PLC.</param>
        /// <returns></returns>
        public override bool SalidasProcesar(byte[] valor, byte id, out byte[] lecturas)
        {
            bool resultado = false;
            var entradas = new byte[2];
            var salidas = new byte[2];
            lecturas = new byte[4];
            var bcc = new byte[5];

            //  Comprobamos el inicio y fin de trama.
            if (valor[0] == this.STX[0] && valor[FinTramaKeepAliveRecepcion] == this.CR[0] && valor.Length == TamanyoMensaje)
            {
                Array.Copy(valor, 17, entradas, 0, 2); // Entradas.
                Array.Copy(valor, 20, salidas, 0, 2);  // Salidas.

                // Cálculo de la redundancia cíclica a partir del identificador del mensaje.
                bcc[0] = valor[15];
                Array.Copy(entradas, 0, bcc, 1, 2);
                Array.Copy(salidas, 0, bcc, 3, 2);

                Array.Copy(entradas, 0, lecturas, 0, 2); // Entradas resultado.
                Array.Copy(salidas, 0, lecturas, 2, 2);  // Salidas resultado.

                if (CalculoBCC(bcc)[0] == valor[23])
                {
                    resultado = true;
                }
            }

            return resultado;
        }
        /// <summary>
        /// Calculo BCC.
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
        #endregion Métodos públicos sobreescritos

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