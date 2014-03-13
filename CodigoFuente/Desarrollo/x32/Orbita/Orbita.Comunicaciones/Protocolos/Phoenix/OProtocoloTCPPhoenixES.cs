using System;
namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Protocolo para los dispositivos phoenix
    /// </summary>
    public class OProtocoloTCPPhoenixES : Protocolo
    {
        #region Atributos
        /// <summary>
        /// Valor inicial del registro de lecturas.
        /// </summary>
        private readonly int _registroInicialEntradas;
        /// <summary>
        /// Valor inicial del registro de escrituras.
        /// </summary>
        private readonly int _registroInicialSalidas;
        /// <summary>
        /// Número de lecturas a realizar.
        /// </summary>
        private readonly int _tamanyoEntradas;
        /// <summary>
        /// Número de escrituras a realizar.
        /// </summary>
        private readonly int _tamanyoSalidas;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Constructor para el protocolo Phoenix.
        /// </summary>
        /// <param name="regIniEntradas"></param>
        /// <param name="byteEntradas"></param>
        /// <param name="regIniSalidas"></param>
        /// <param name="byteSalidas"></param>
        public OProtocoloTCPPhoenixES(int regIniEntradas, int byteEntradas, int regIniSalidas, int byteSalidas)
        {
            this._registroInicialEntradas = regIniEntradas;
            this._tamanyoEntradas = byteEntradas;
            this._registroInicialSalidas = regIniSalidas;
            this._tamanyoSalidas = byteSalidas;
        }
        #endregion Constructor

        #region Destructor
        /// <summary>
        /// Destructor de clase
        /// </summary>
        ~OProtocoloTCPPhoenixES()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }
        #endregion Destructor

        #region Métodos públicos
        /// <summary>
        /// Prepara el mensaje KeepAlive de respuesta.
        /// </summary>
        /// <returns>mensaje de respuesta</returns>
        public byte[] KeepAliveEnviar()
        {
            OProtocoloModbusTCP mensaje = new OProtocoloModbusTCP();
            return mensaje.configurarMensajeLecturaF3(this._registroInicialEntradas, this._tamanyoEntradas + this._tamanyoSalidas);
        }
        /// <summary>
        /// Procesa el mensaje KeepAlive del dispositivo.
        /// </summary>
        /// <param name="valor">valor recibido por el dispositivo</param>
        /// <param name="lecturas">lecturas procesadas</param>
        /// <returns></returns>
        public bool KeepAliveProcesar(byte[] valor, out byte[] lecturas)
        {
            byte numResp = valor[8];
            int registros = numResp / 2;

            lecturas = new byte[registros];
            byte[] con = new byte[2];
            for (int i = 0; i < registros; i++)
            {
                int j = 8 + (2 * i + 1);
                con[0] = valor[j];
                con[1] = valor[j + 1];
                Array.Reverse(con);
                lecturas[i] = (byte)BitConverter.ToInt16(con, 0);
            }
            return true;
        }
        /// <summary>
        /// Procesa el mensaje de ES del PLC
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="entradas"></param>
        /// <param name="salidas"></param>
        /// <returns></returns>
        public bool ESprocesar(byte[] valor, out byte[] entradas, out byte[] salidas)
        {
            entradas = new byte[this._tamanyoEntradas];
            salidas = new byte[this._tamanyoSalidas];
            for (int i = 0; i < this._tamanyoEntradas; i++)
            {
                entradas[i] = valor[i];
            }
            int j = 0;
            for (int i = this._tamanyoEntradas; i < (this._tamanyoEntradas + this._tamanyoSalidas); i++)
            {
                salidas[j] = valor[i];
                j++;
            }
            return true;
        }
        /// <summary>
        /// Prepara el mensaje KeepAlive de respuesta.
        /// </summary>
        /// <returns>mensaje de respuesta</returns>
        public byte[] SalidasEnviar(byte[] salidas)
        {
            OProtocoloModbusTCP mensaje = new OProtocoloModbusTCP();
            return mensaje.configurarMensajeEscrituraF16(this._registroInicialSalidas, salidas);
        }
        /// <summary>
        /// Limpia objetos de memoria
        /// </summary>
        /// <param name="disposing"></param>
        public override void Dispose(bool disposing)
        {
            // Preguntar si Dispose ya fue llamado.
            if (!this.Disposed)
            {
                // Marcar como desechada ó desechandose,
                // de forma que no se puede ejecutar el
                // código dos veces.
                Disposed = true;
            }
        }
        #endregion Métodos públicos
    }
}