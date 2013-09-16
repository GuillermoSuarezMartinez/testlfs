using System;
using System.Collections;
using System.Threading;
using MccDaq;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo de ES de MCC
    /// </summary>
    public class ODispositivoMCUSB : ODispositivoES
    {
        #region Atributos
        /// <summary>
        /// Cola de recepción de tramas de datos.
        /// </summary>
        private Queue _qEntradaSalida;
        /// <summary>
        /// Evento reset de recepción de tramas KeepAlive, 
        /// Entrada/Salida.
        /// </summary>
        private OResetManual _eReset;  // 0-KeepAlive; 1-lecturas; 2-escrituras.
        /// <summary>
        /// Colección para la búsqueda de lecturas. La clave es la dupla "dirección-bit"
        /// </summary>
        private OHashtable _almacenLecturas;
        /// <summary>
        /// Número de lecturas a realizar
        /// </summary>
        private int _numLecturas;
        /// <summary>
        /// Número de bytes de entradas
        /// </summary>
        private int _numeroBytesEntradas;
        /// <summary>
        /// Número de bytes de salidas
        /// </summary>
        private int _numeroBytesSalidas;
        /// <summary>
        /// Valor de las lecturas
        /// </summary>
        private byte[] _lecturas;
        /// <summary>
        /// Valor de las lecturas
        /// </summary>
        private byte[] LecturasContinuas;
        /// <summary>
        /// Valor inicial del registro de escrituras
        /// </summary>
        private int _registroInicialSalidas;
        /// <summary>
        /// tarjeta ES
        /// </summary>
        private MccBoard _daqBoard;
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoMCUSB.
        /// </summary>
        public ODispositivoMCUSB(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo)
        {
            this.IniciarObjetos();
            Wrapper.Info("Objetos del dispositivo de ES MCC creados.");

            try
            {
                Hilos.Add(new ThreadStart(EsProcesarHilo), true);
            }
            catch (Exception ex)
            {
                Wrapper.Error("No se pudo crear la conexión TCP con el dispositivo de ES MCC." + ex);
            }

            Wrapper.Info("Comunicaciones TCP del dispositivo de ES MCC arrancadas correctamente.");
        }
        #endregion Constructor

        #region Métodos públicos
        /// <summary>
        /// Procesa las lecturas del dispositivo
        /// </summary>
        public override void ProcesarHiloVida()
        {
            OEstadoComms estado = new OEstadoComms
                {
                    Nombre = this.Nombre,
                    Id = this.Identificador,
                    Enlace = this.Tags.HtVida.Enlaces[0],
                    Estado = "NOK"
                };

            int reintento = 0;
            const int maxReintentos = 3;

            while (true)
            {
                try
                {
                    Boolean responde = true;
                    short data;
                    ErrorInfo info = _daqBoard.DIn(DigitalPortType.FirstPortA, out data);
                    this._lecturas[0] = (byte)data;
                    if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                    {
                        responde = false;
                        Wrapper.Error("Error en KeepAlive del dispositivo de ES MCC canal A: " + info.Value.ToString());
                    }
                    info = _daqBoard.DIn(DigitalPortType.FirstPortB, out data);
                    this._lecturas[1] = (byte)data;
                    if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                    {
                        responde = false;
                        Wrapper.Error("Error en KeepAlive del dispositivo de ES MCC canal B: " + info.Value.ToString());
                    }
                    info = _daqBoard.DIn(DigitalPortType.FirstPortCL, out data);
                    this._lecturas[2] = (byte)data;
                    if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                    {
                        responde = false;
                        Wrapper.Error("Error en KeepAlive del dispositivo de ES MCC canal CL: " + info.Value.ToString());
                    }
                    info = _daqBoard.DIn(DigitalPortType.FirstPortCH, out data);
                    this._lecturas[3] = (byte)data;
                    if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                    {
                        responde = false;
                        Wrapper.Error("Error en KeepAlive del dispositivo de ES MCC canal CH: " + info.Value.ToString());
                    }

                    this.EsEncolar(this._lecturas);

                    if (!responde)
                    {
                        if (reintento < maxReintentos)
                        {
                            reintento++;
                        }
                        else
                        {
                            estado.Estado = "NOK";
                        }
                        Thread.Sleep(this.ConfigDispositivo.TiempoVida);
                    }
                    else
                    {
                        estado.Estado = "OK";
                        reintento = 0;
                    }
                }
                catch (Exception ex)
                {
                    estado.Estado = "NOK";
                    Wrapper.Error("Error en KeepAlive del dispositivo de ES MCC: ", ex);
                }

                try
                {
                    this.Eventargs.Argumento = estado;
                    this.OnComm(this.Eventargs);
                }
                catch (Exception ex)
                {
                    Wrapper.Error("Error en envío de evento de comunicaciones en dispositivo de ES MCC: ", ex);
                }
                Thread.Sleep(this.ConfigDispositivo.TiempoEsperaLectura);
            }
        }
        /// <summary>
        /// Leer el valor de las descripciones de variables de la colección
        /// a partir del valor de la colección de datos DB actualiza  en el
        /// proceso del hilo vida.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se ejecuta sobre el dispositivo</param>
        /// <returns>Colección de resultados.</returns>
        public override object[] Leer(string[] variables, bool demanda)
        {
            object[] resultado = null;
            try
            {
                if (variables != null)
                {
                    // Inicializar contador de variables.
                    int contador = variables.Length;

                    // Asignar a la colección resultado el número
                    // de variables de la colección de variables.
                    resultado = new object[contador];
                    for (int i = 0; i < contador; i++)
                    {
                        object res = this.Tags.GetDB(variables[i]).Valor;
                        resultado[i] = res;
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("Error al leer en el dispositivo de ES MCC. ", ex);
                throw;
            }

            return resultado;
        }
        /// <summary>
        /// Escribir el valor de los identificadores de variables de la colección.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <returns></returns>
        public override bool Escribir(string[] variables, object[] valores)
        {
            lock (this)
            {
                bool resultado = false;

                byte[] lecturasEscribir = new byte[this._lecturas.Length];
                lecturasEscribir = this._lecturas;
                try
                {
                    for (int i = 0; i < variables.Length; i++)
                    {
                        OInfoDato infodato = this.Tags.GetDB(variables[i]);

                        switch (infodato.Conexion.ToUpper())
                        {
                            case "A":
                                lecturasEscribir[0] = ProcesarByte(this._lecturas[infodato.Direccion - this._registroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                                break;
                            case "B":
                                lecturasEscribir[1] = ProcesarByte(this._lecturas[infodato.Direccion - this._registroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                                break;
                            case "CL":
                                lecturasEscribir[2] = ProcesarByte(this._lecturas[infodato.Direccion - this._registroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                                break;
                            case "CH":
                                lecturasEscribir[3] = ProcesarByte(this._lecturas[infodato.Direccion - this._registroInicialSalidas], infodato.Bit, Convert.ToInt32(valores[i]));
                                break;
                        }
                    }

                    resultado = true;
                    for (int i = 0; i < 2; i++)
                    {
                        ErrorInfo info;
                        switch (Salidas[i])
                        {
                            case 0:
                                info = _daqBoard.DOut(DigitalPortType.FirstPortA, lecturasEscribir[0]);
                                if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                                {
                                    resultado = false;
                                    Wrapper.Error("Error al escribir en el dispositivo de ES MCC canal A: " + info.Value.ToString());
                                }
                                break;
                            case 1:
                                info = _daqBoard.DOut(DigitalPortType.FirstPortB, lecturasEscribir[1]);
                                if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                                {
                                    resultado = false;
                                    Wrapper.Error("Error al escribir en el dispositivo de ES MCC canal B: " + info.Value.ToString());
                                }
                                break;
                            case 2:
                                info = _daqBoard.DOut(DigitalPortType.FirstPortCL, lecturasEscribir[2]);
                                if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                                {
                                    resultado = false;
                                    Wrapper.Error("Error al escribir en el dispositivo de ES MCC canal CL: " + info.Value.ToString());
                                }
                                break;
                            case 3:
                                info = _daqBoard.DOut(DigitalPortType.FirstPortCH, lecturasEscribir[3]);
                                if (info.Value != ErrorInfo.ErrorCode.NoErrors)
                                {
                                    resultado = false;
                                    Wrapper.Error("Error al escribir en el dispositivo de ES MCC canal CH: " + info.Value.ToString());
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Wrapper.Fatal("Error en la escritura de variables en el dispositivo de ES MCC " + ex);
                }

                return resultado;
            }
        }
        #endregion Métodos públicos

        #region Métodos privados

        #region Comunes
        /// <summary>
        /// Establece el valor inicial de los objetos
        /// </summary>
        private void IniciarObjetos()
        {
            _daqBoard = new MccDaq.MccBoard(this.Puerto);
            _daqBoard.FlashLED(); // Prueba para verificar que el módulo está conectado

            // Cola de envío/recepción de tramas.
            this._qEntradaSalida = new Queue();
            // Evento reset de envío/recepción de tramas KeepAlive y Entrada/Salida.
            this._eReset = new OResetManual(1);
            // Iniciamos los datos 
            ArrayList listEntradas = new ArrayList();
            ArrayList listSalidas = new ArrayList();

            this._almacenLecturas = new OHashtable();
            //this._almacenEscrituras = new OHashtable();

            foreach (DictionaryEntry item in this.Tags.GetDatos())
            {
                OInfoDato infodato = (OInfoDato)item.Value;
                infodato.Valor = 0;
                string key = infodato.Conexion.ToString() + "-" + infodato.Bit.ToString();
                this._almacenLecturas.Add(key, infodato);
                if (infodato.EsEntrada)
                {
                    if (!listEntradas.Contains(infodato.Conexion))
                    {
                        listEntradas.Add(infodato.Conexion);
                    }
                }
                else
                {
                    if (!listSalidas.Contains(infodato.Conexion))
                    {
                        listSalidas.Add(infodato.Conexion);
                    }
                }
            }

            listEntradas.Sort();
            listSalidas.Sort();

            this._numLecturas = listEntradas.Count + listSalidas.Count;
            this._numeroBytesEntradas = listEntradas.Count;
            this._numeroBytesSalidas = listSalidas.Count;
            this._registroInicialSalidas = 0;

            this.Entradas = new byte[this._numeroBytesEntradas];

            this.Salidas = new byte[this._numeroBytesSalidas];
            for (int i = 0; i < listSalidas.Count; i++)
            {
                switch (listSalidas[i].ToString().ToUpper())
                {
                    case "A":
                        Salidas[i] = 0;
                        break;
                    case "B":
                        Salidas[i] = 1;
                        break;
                    case "CL":
                        Salidas[i] = 2;
                        break;
                    case "CH":
                        Salidas[i] = 3;
                        break;
                }
            }

            this._lecturas = new byte[_numLecturas];
            this.LecturasContinuas = new byte[_numLecturas];

            #region Configuración entradas y salidas

            for (int i = 0; i < listEntradas.Count; i++)
            {
                string canal = listEntradas[i].ToString();
                switch (canal.ToUpper())
                {
                    case "A":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortA, DigitalPortDirection.DigitalIn);
                        break;
                    case "B":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortB, DigitalPortDirection.DigitalIn);
                        break;
                    case "CH":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortCH, DigitalPortDirection.DigitalIn);
                        break;
                    case "CL":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortCL, DigitalPortDirection.DigitalIn);
                        break;
                }
            }
            for (int i = 0; i < listSalidas.Count; i++)
            {
                string canal = listSalidas[i].ToString();
                switch (canal.ToUpper())
                {
                    case "A":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortA, DigitalPortDirection.DigitalOut);
                        break;
                    case "B":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortB, DigitalPortDirection.DigitalOut);
                        break;
                    case "CH":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortCH, DigitalPortDirection.DigitalOut);
                        break;
                    case "CL":
                        _daqBoard.DConfigPort(DigitalPortType.FirstPortCL, DigitalPortDirection.DigitalOut);
                        break;
                }
            }

            #endregion
        }
        /// <summary>
        /// Procesa los bits poniendo a 1 o 0 el bit correspondiente
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="bit"></param>
        /// <param name="valorBit"></param>
        /// <returns></returns>
        private static byte ProcesarByte(byte valor, int bit, int valorBit)
        {
            byte ret = 0;

            if (valorBit == 1)
            {
                ret = (byte)((valor) | (byte)(Math.Pow(2, bit)));
            }
            else
            {
                ret = (byte)(valor & ~(byte)(Math.Pow(2, bit)));
            }

            return ret;
        }
        #endregion Comunes

        #region ES
        /// <summary>
        /// Método que encola trama GateData.
        /// </summary>
        /// <param name="trama"></param>
        private void EsEncolar(byte[] trama)
        {
            // Bloquear la cola sincronizada.
            lock (this._qEntradaSalida.SyncRoot)
            {
                // Encolar la trama de ES recibida.
                this._qEntradaSalida.Enqueue(trama);

                this._eReset.Despertar(0);
            }
        }
        /// <summary>
        /// Método que desencola trama GateData.
        /// </summary>
        /// <returns>Objeto GateData</returns>
        private byte[] EsDesencolar()
        {
            // Bloquear la cola sincronizada.
            lock (this._qEntradaSalida.SyncRoot)
            {
                byte[] mensaje = null;
                if (this._qEntradaSalida.Count > 0)
                {
                    // Desencolar el objeto Trama encolado en wsk_DataArrival.
                    mensaje = ((byte[])this._qEntradaSalida.Dequeue());
                }
                else
                {
                    // Reset para la siguiente vez que se mande un Set.
                    // Es necesario invocarlo por haber utilizado ManualResetEvent.
                    this._eReset.Resetear(0);
                }
                return mensaje;
            }
        }
        /// <summary>
        /// Hilo de proceso de ES
        /// </summary>
        private void EsProcesarHilo()
        {
            while (true)
            {
                byte[] mensaje = this.EsDesencolar();

                if (mensaje != null)
                {
                    try
                    {
                        this.EsProcesar(mensaje);
                    }
                    catch (Exception ex)
                    {
                        Wrapper.Fatal("Error al procesar las ES en el dispositivo de ES MCC. " + ex);
                    }
                    Thread.Sleep(10);
                }
                else
                {
                    this._eReset.Dormir(0);
                }
            }
        }
        /// <summary>
        /// Procesa los bytes de entradas y salidas para actualizar los valores de las variables
        /// </summary>
        /// <param name="mensaje">byte de entradas recibido</param>
        private void EsProcesar(byte[] mensaje)
        {
            try
            {
                for (int i = 0; i < mensaje.Length; i++)
                {
                    if (mensaje[i] != this.LecturasContinuas[i])
                    {
                        this.EsActualizarVariables(mensaje[i], i);
                        this.LecturasContinuas[i] = mensaje[i];
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("Error al procesar las ES en el dispositivo de ES MCC en ESProcesar. " + ex);
                throw ex;
            }
        }
        /// <summary>
        /// Actualiza los valores de las entradas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void EsActualizarVariables(byte valor, int posicion)
        {
            OInfoDato infodato = null;
            OEventArgs ev = new OEventArgs();
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    switch (posicion)
                    {
                        case 0:
                            infodato = (OInfoDato)this._almacenLecturas["A-" + i.ToString()];
                            break;
                        case 1:
                            infodato = (OInfoDato)this._almacenLecturas["B-" + i.ToString()];
                            break;
                        case 2:
                            infodato = (OInfoDato)this._almacenLecturas["CL-" + i.ToString()];
                            break;
                        case 3:
                            infodato = (OInfoDato)this._almacenLecturas["CH-" + i.ToString()];
                            break;
                    }

                    //Comprobamos el valor nuevo 
                    if (infodato != null)
                    {
                        int resultado = 0;
                        if ((valor & (1 << i)) != 0)
                        {
                            resultado = 1;
                        }

                        if (resultado != Convert.ToInt32(infodato.Valor))
                        {
                            infodato.Valor = resultado;
                            ev.Argumento = infodato;
                            this.OnCambioDato(ev);

                            if (this.Tags.GetAlarmas(infodato.Identificador) != null)
                            {
                                if (Convert.ToInt32(infodato.Valor) == 1)
                                {
                                    if (!AlarmasActivas.Contains(infodato.Texto))
                                    {
                                        this.AlarmasActivas.Add(infodato.Texto);
                                    }
                                }
                                else
                                {
                                    if (AlarmasActivas.Contains(infodato.Texto))
                                    {
                                        this.AlarmasActivas.Remove(infodato.Texto);
                                    }
                                }

                                this.OnAlarma(ev);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Wrapper.Error("Error no controlado al procesar las entradas en el dispositivo de ES Siemens" + ex);
                }
            }
        }
        #endregion ES

        #endregion Métodos privados
    }
}