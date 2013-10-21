using System;
using System.Collections;
using System.Data;
using System.IO.Ports;
using System.Threading;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase que encapsula un puerto serie RS232
    /// </summary>
    public class OPuertoRS : OPuertoComunicaciones
    {
        #region Eventos
        /// <summary>
        /// Evento para la recepción de datos
        /// </summary>
        public event OManejadorEventoSerie OrbitaRX;
        #endregion Eventos

        #region Delegados
        /// <summary>
        /// Manejador para la recepción de datos
        /// </summary>
        /// <param name="e"></param>
        public delegate void OManejadorEventoSerie(OEventArgs e);
        #endregion Delegados

        #region Atributos

        /// <summary>
        /// Buffer de recepción de datos
        /// </summary>
        public Queue BufferDatosRecibidos;
        #endregion Atributos

        #region Constructores
        /// <summary>
        /// Constructor del puerto con la configuración por defecto
        /// </summary>
        public OPuertoRS()
            : base(new OConfiguracionPuertoRS())
        {
            this.IniciarComponentes();
        }
        /// <summary>
        /// Constructor del puerto con la configuración pasada por argumento
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto serie RS232</param>
        public OPuertoRS(OConfiguracionPuertoRS configuracionPuerto)
            : base(configuracionPuerto)
        {
            this.IniciarComponentes();
        }
        /// <summary>
        /// Constructor del puerto con la configuración e información básica pasada por argumento
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto serie RS232</param>
        /// <param name="info">Información básica del puerto de comunicaciones</param>
        public OPuertoRS(OConfiguracionPuertoRS configuracionPuerto, OInformacionPuerto info)
            : base(configuracionPuerto, info)
        {
            this.IniciarComponentes();
        }
        /// <summary>
        /// Constructor del puerto con la configuración e información básica pasada por argumento
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto serie RS232</param>
        /// <param name="idNumerico">Identificador númerico del puerto de comunicaciones</param>
        /// <param name="tipoPuerto">Tipo del puerto de comunicaciones</param>
        public OPuertoRS(OConfiguracionPuertoRS configuracionPuerto, int idNumerico, string tipoPuerto)
            : base(configuracionPuerto, idNumerico, tipoPuerto)
        {
            this.IniciarComponentes();
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// PuertoRS232.
        /// </summary>
        public SerialPort PuertoRs232 { get; set; }
        /// <summary>
        /// Indica si el puerto serie RS232  está abierto.
        /// </summary>
        public bool EstaAbierto
        {
            get { return this.PuertoRs232.IsOpen; }
            set { throw new NotImplementedException(); }
        }
        #endregion Propiedades

        #region Métodos privados
        /// <summary>
        /// Iniciar todos los componentes de este puerto de comunicaciones, a excepción del inicio del puerto serie, ya que se hace desde la clase padre al configurar el puerto.
        /// </summary>
        private void IniciarComponentes()
        {
            this.BufferDatosRecibidos = new Queue();
            if (this.PuertoRs232 != null)
            {
                if (this.PuertoRs232.IsOpen)
                {
                    this.PuertoRs232.Close();
                }
                this.PuertoRs232.Dispose();
                this.PuertoRs232 = null;
            }
            this.PuertoRs232 = new SerialPort();
            this.PuertoRs232.DataReceived += PuertoRS232_DataReceived;
            this.ConfigurarPuerto(this.ConfiguracionPuerto);
        }
        /// <summary>
        /// Establecer una equivalencia unidireccional entre el tipo Paridades y el tipo Parity.
        /// </summary>
        /// <param name="paridad">Paridad a convertir</param>
        /// <returns>Paridad convertida</returns>
        private static Parity ConvertirParidad(OParidades paridad)
        {
            Parity convParidad = Parity.None;
            switch (paridad)
            {
                case OParidades.Ninguna:
                    convParidad = Parity.None;
                    break;
                case OParidades.Par:
                    convParidad = Parity.Even;
                    break;
                case OParidades.Impar:
                    convParidad = Parity.Odd;
                    break;
                case OParidades.Marca:
                    convParidad = Parity.Mark;
                    break;
                case OParidades.Espacio:
                    convParidad = Parity.Space;
                    break;
            }
            return convParidad;
        }
        /// <summary>
        /// Establecer una equivalencia unidireccional entre el tipo BitsStop y el tipo StopBits.
        /// </summary>
        /// <param name="bitsStop">Bits de parada a convertir</param>
        /// <returns>Bits de parada convertidos</returns>
        private StopBits ConvertirBitsStop(OBitsStop bitsStop)
        {
            StopBits convBitsStop = StopBits.Two;
            switch (bitsStop)
            {
                case OBitsStop.Uno:
                    convBitsStop = StopBits.One;
                    break;
                case OBitsStop.UnoYMedio:
                    convBitsStop = StopBits.OnePointFive;
                    break;
                case OBitsStop.Dos:
                    convBitsStop = StopBits.Two;
                    break;
            }
            return convBitsStop;
        }
        /// <summary>
        /// Establecer una equivalencia unidireccional entre el tipo HandShakes y el tipo Handshake.
        /// </summary>
        /// <param name="handshake">Control de flujo a convertir</param>
        /// <returns>Control de flujo convertidos</returns>
        private Handshake ConvertirHandshake(OHandShakes handshake)
        {
            Handshake convHandshake = Handshake.None;
            switch (handshake)
            {
                case OHandShakes.CtsRts:
                    convHandshake = Handshake.RequestToSend;
                    break;
                case OHandShakes.XonXoff:
                    convHandshake = Handshake.XOnXOff;
                    break;
                case OHandShakes.DsrDtr:
                    throw new Exception("Handshake DsrDtr no disponible con el control de Orbita.Comunicaciones serie de VS2005.");
            }
            return convHandshake;
        }
        #endregion Métodos privados

        #region Métodos públicos sobreescritos
        /// <summary>
        /// Crear y configurar el puerto serie RS232.
        /// </summary>
        /// <param name="configuracionPuerto">Configuración del puerto RS232 a establecer.</param>
        public override void ConfigurarPuerto(OConfiguracionPuerto configuracionPuerto)
        {
            this.ConfiguracionPuerto = configuracionPuerto;
            if (this.PuertoRs232 != null)
            {
                if (this.PuertoRs232.IsOpen)
                {
                    this.PuertoRs232.Close();
                }
            }
            OConfiguracionPuertoRS configRS232 = (OConfiguracionPuertoRS)configuracionPuerto;
            var puertoRs232 = this.PuertoRs232;
            if (puertoRs232 == null) return;
            puertoRs232.PortName = "COM" + configRS232.NumeroPuerto;
            puertoRs232.BaudRate = configRS232.Velocidad;
            puertoRs232.DataBits = configRS232.BitsDatos;
            puertoRs232.Parity = ConvertirParidad(configRS232.Paridad);
            puertoRs232.StopBits = this.ConvertirBitsStop(configRS232.BitsStop);
            puertoRs232.Handshake = this.ConvertirHandshake(configRS232.Handshake);
        }
        /// <summary>
        /// Abrir el puerto serie RS232.
        /// </summary>
        public override void Abrir()
        {
            if (this.PuertoRs232 != null)
            {
                if (this.PuertoRs232.IsOpen)
                {
                    return;
                }
                this.PuertoRs232.Open();
            }
        }
        /// <summary>
        /// Cerrar el puerto serie RS232.
        /// </summary>
        public override void Cerrar()
        {
            if (this.PuertoRs232 != null)
            {
                if (this.PuertoRs232.IsOpen)
                {
                    this.PuertoRs232.Close();
                    Thread.Sleep(200);
                }
            }
        }
        /// <summary>
        /// Enviar por el puerto serie RS232 el vector de bytes TramaTx.
        /// </summary>
        /// <param name="tramaTx">Vector de bytes a enviar por el puerto serie RS232.</param>
        public override void Enviar(byte[] tramaTx)
        {
            if (this.PuertoRs232 != null)
            {
                if (this.PuertoRs232.IsOpen)
                {
                    if (tramaTx.Length > 0)
                    {
                        this.PuertoRs232.Write(tramaTx, 0, tramaTx.Length);
                    }
                }
            }
        }
        /// <summary>
        /// Copia en el vector de bytes tramaRx la información recibida por el puerto de comunicaciones.
        /// </summary>
        /// <returns>Vector de bytes donde que contendrá la información recibida hasta el momento.</returns>
        public override byte[] RecibirBytes()
        {
            lock (this)
            {
                byte[] tramaRx;
                if (this.BufferDatosRecibidos.Count == 0)
                {
                    tramaRx = null;
                }
                else
                {
                    tramaRx = new byte[this.BufferDatosRecibidos.Count];
                    int i = 0;
                    while (this.BufferDatosRecibidos.Count > 0)
                    {
                        tramaRx[i] = (byte)this.BufferDatosRecibidos.Dequeue();
                        i++;
                    }
                    this.BufferDatosRecibidos.TrimToSize();
                }
                return tramaRx;
            }
        }
        /// <summary>
        /// Devuleve el número de bytes recibidos hasta el momento.
        /// </summary>
        /// <returns>El número de bytes recibidos hasta el momento.</returns>
        public override int BytesRecibidos()
        {
            lock (this)
            {
                return this.BufferDatosRecibidos.Count;
            }
        }
        /// <summary>
        /// Resetear el buffer de recepcion de datos. Realmente resetea la variable que lleva la posición del último byte recibido, por lo que los datos permanencen en el buffer hasta que son sobreescritos.
        /// </summary>
        public override void ResetBuffer()
        {
            lock (this)
            {
                this.BufferDatosRecibidos.Clear();
                this.BufferDatosRecibidos.TrimToSize();
            }
        }
        /// <summary>
        /// Buscar un carácter en el buffer de recepcion de datos.
        /// </summary>
        /// <param name="caracter">Carácter a buscar.</param>
        /// <returns>True encuentra el valor buscado; false en caso contrario.</returns>
        public override bool BuscarCaracter(byte caracter)
        {
            lock (this)
            {
                return this.BufferDatosRecibidos.Contains(caracter);
            }
        }
        /// <summary>
        /// Eliminar los recursos que está utilizando.
        /// </summary>
        public override void Dispose()
        {
            if (this.PuertoRs232 == null) return;
            this.Cerrar();
            this.PuertoRs232.DataReceived -= PuertoRS232_DataReceived;
            this.PuertoRs232.Dispose();
            this.PuertoRs232 = null;
            this.BufferDatosRecibidos.Clear();
            this.BufferDatosRecibidos.TrimToSize();
            this.BufferDatosRecibidos = null;
        }
        /// <summary>
        /// Lista los puertos COM RS-232 disponbles en el sistema en un DataTable con 3 columnas:
        ///  - Identificador: identificador numérico dado por el orden de la lista de puertos COM devuelto por el sistema
        ///  - Nombre: nombre del puerto serie RS-232
        ///  - NumeroCOM: número del puerto serie RS-232
        /// </summary>
        /// <returns>Un DataTable con los puertos COM RS-232 disponbles en el sistema con 3 columnas:
        ///  - Identificador: identificador numérico dado por el orden de la lista de puertos COM devuelto por el sistema
        ///  - Nombre: nombre del puerto serie RS-232
        ///  - NumeroCOM: número del puerto serie RS-232</returns>
        public override DataTable ObtenerPuertosDisponibles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Identificador", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("NumeroCOM", typeof(String));
            string[] puertos = SerialPort.GetPortNames();

            for (int i = 0; i < puertos.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Identificador"] = i;
                dr["Nombre"] = puertos[i];
                dr["NumeroCOM"] = puertos[i].Substring(3);
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion Métodos públicos

        #region Manejadores de eventos
        /// <summary>
        /// Se ejecuta cada vez que se reciben datos por this.PuertoRS232
        /// </summary>
        /// <param name="sender">Objeto que lanza el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void PuertoRS232_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (this)
                {
                    int numeroBytes = this.PuertoRs232.BytesToRead;
                    if (numeroBytes <= 0) return;
                    byte[] vb = new byte[numeroBytes];
                    this.PuertoRs232.Read(vb, 0, numeroBytes);
                    foreach (byte b in vb)
                    {
                        this.BufferDatosRecibidos.Enqueue(b);
                    }

                    if (vb.Length > 0)
                    {
                        this.OnCambioDato(new OEventArgs(System.Text.Encoding.ASCII.GetString(vb)));
                    }
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex.ToString());
            }
        }
        /// <summary>
        /// Actualiza el estado del buffer en el puerto
        /// </summary>
        /// <param name="e"></param>
        protected void OnCambioDato(OEventArgs e)
        {
            // Hacer una copia temporal del evento para evitar una condición
            // de carrera, si el último suscriptor desuscribe inmediatamente
            // después de la comprobación nula y antes de que el  evento  se
            // produce.
            var handler = OrbitaRX;
            if (handler != null)
            {
                handler(e);
            }
        }
        #endregion Manejadores de eventos
    }
}