using System;
using System.Collections.Generic;
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
        /// byte inicio trama
        /// </summary>
        private byte[] _stx;
        /// <summary>
        /// byte retorno de carro
        /// </summary>
        private byte[] _cr;
        /// <summary>
        /// byte identificador de la petición OCR
        /// </summary>
        private byte[] _ocrData;
        /// <summary>
        /// byte identificador de la respuesta OCR
        /// </summary>
        private byte[] _ocrDataResult;
        /// <summary>
        /// byte separador
        /// </summary>
        private byte[] _separador;
        /// <summary>
        /// Fin de la trama de keepAlive envio
        /// </summary>
        private int _finTramaKeepAliveEnvio = 17;
        /// <summary>
        /// Fin de la trama de keepAlive recepcion
        /// </summary>
        private int _finTramaKeepAliveRecepcion = 32;
        /// <summary>
        /// Tamaño máximo de trama
        /// </summary>
        private int _tamanyoMensaje = 33;

        #endregion

        #region Constructores
        /// <summary>
        /// Contructor de clase para GATE OCR
        /// </summary>
        public OProtocoloTCPSiemensGateOCR()
        {

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Mensaje de keep alive que se envía al PLC
        /// </summary>
        /// <returns>mensaje de respuesta</returns>
        public override byte[] KeepAliveEnviar()
        {
            byte[] ret = null;
            byte[] BCC = null;
            try
            {
                ret = new byte[_finTramaKeepAliveEnvio + 1];

                ret[0] = this.STX[0];
                ret[this._finTramaKeepAliveEnvio] = this.CR[0];

                Array.Copy(this.OCRData, 0, ret, 1, this.OCRData.Length);
                ret[8] = this.Separador[0];
                ret[9] = 0;
                ret[10] = this.Separador[0];
                ret[11] = 0;
                ret[12] = 0;
                ret[13] = 0;
                ret[14] = 0;
                ret[15] = this.Separador[0];

                BCC = new byte[5];
                BCC[0] = 0;
                BCC[1] = 0;
                BCC[2] = 0;
                BCC[3] = 0;
                BCC[4] = 0;

                ret[16] = this.CalculoBCC(BCC)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        /// <summary>
        /// Mensaje de keep alive que se recibe del PLC
        /// </summary>
        /// <param name="valor">valor recibido por el PLC</param>
        /// <param name="lecturas">lecturas leídas en el PLC</param>
        /// <returns></returns>
        public override bool KeepAliveProcesar(byte[] valor, out byte[] lecturas)
        {
            bool ret = false;
            byte id = 0;
            lecturas = new byte[12];
            byte[] BCC = new byte[13];

            try
            {
                //Comprobamos el inicio y fin de trama
                if (valor[0] == this.STX[0] && valor[_finTramaKeepAliveRecepcion] == this.CR[0] && valor.Length == this._tamanyoMensaje)
                {
                    id = valor[15];
                    Array.Copy(valor, 17, lecturas, 0, 8);
                    Array.Copy(valor, 26, lecturas, 8, 4);
                    BCC[0] = id;
                    Array.Copy(lecturas, 0, BCC, 1, 12);
                    if (this.CalculoBCC(BCC)[0] == valor[31])
                    {
                        ret = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        /// <summary>
        /// Escritura de salidas
        /// </summary>
        /// <param name="salidas">salidas a procesar</param>
        /// <param name="idMensaje">identificador del mensaje</param>
        /// <returns></returns>
        public override byte[] SalidasEnviar(byte[] salidas, byte idMensaje)
        {
            byte[] ret = null;

            try
            {
                ret = KeepAliveEnviar();
                ret[9] = idMensaje;
                ret[11] = salidas[0];
                ret[12] = salidas[1];
                ret[13] = salidas[2];
                ret[14] = salidas[3];
                byte[] BCC = new byte[5];

                BCC[0] = idMensaje;
                BCC[1] = salidas[0];
                BCC[2] = salidas[1];
                BCC[3] = salidas[2];
                BCC[4] = salidas[3];

                ret[16] = this.CalculoBCC(BCC)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        /// <summary>
        /// Escritura de salidas
        /// </summary>
        /// <param name="valor">valor a preocesar</param>
        /// <param name="id">identificador del mensaje</param>
        /// <returns></returns>
        public override bool SalidasProcesar(byte[] valor, byte id)
        {
            bool ret = false;
            byte[] entradas = new byte[8];
            byte[] salidas = new byte[4];
            byte[] BCC = new byte[13];

            try
            {
                //Comprobamos el inicio y fin de trama
                if (valor[0] == this.STX[0] && valor[_finTramaKeepAliveRecepcion] == this.CR[0] && valor.Length == this._tamanyoMensaje)
                {
                    Array.Copy(valor, 17, entradas, 0, 8);
                    Array.Copy(valor, 26, salidas, 0, 4);

                    BCC[0] = (byte)(id - 1);
                    Array.Copy(entradas, 0, BCC, 1, 8);
                    Array.Copy(salidas, 0, BCC, 9, 4);
                    if (this.CalculoBCC(BCC)[0] == valor[31])
                    {
                        ret = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        /// <summary>
        /// Calculo BCC
        /// </summary>
        /// <param name="dato">bytes para calculo</param>
        /// <returns>BCC</returns>
        private byte[] CalculoBCC(byte[] dato)
        {
            int resultado = 0;
            byte[] retorno = new byte[1];

            try
            {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
        /// <summary>
        /// Destrucción del objeto
        /// </summary>
        public override void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.

                }

            }
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// byte inicio trama
        /// </summary>
        public byte[] STX
        {
            get
            {
                this._stx = Encoding.ASCII.GetBytes("\x02");
                return this._stx;
            }
        }
        /// <summary>
        /// byte retorno de carro
        /// </summary>
        public byte[] CR
        {
            get
            {
                this._cr = Encoding.ASCII.GetBytes("\x0D");
                return this._cr;
            }
        }
        /// <summary>
        /// Byte separador del mensaje
        /// </summary>
        public byte[] Separador
        {
            get
            {
                this._separador = Encoding.ASCII.GetBytes("\x2F");
                return this._separador;
            }
        }
        /// <summary>
        /// Identificador del mensaje ocr data
        /// </summary>
        public byte[] OCRData
        {
            get
            {
                this._ocrData = Encoding.ASCII.GetBytes("OCRDATA");
                return this._ocrData;
            }
        }
        /// <summary>
        /// Identificador del mensaje ocr data result
        /// </summary>
        public byte[] OCRDataResult
        {
            get
            {
                this._ocrDataResult = Encoding.ASCII.GetBytes("OCRDATARESULT");
                return this._ocrDataResult;
            }
        }
        #endregion
    }
}
