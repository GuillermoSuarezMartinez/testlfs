using System;
using System.Linq;
using System.Threading;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo Siemens 1200 Traffic.
    /// </summary>
    public class ODispositivoSiemens1200ESGTRA : ODispositivoSiemens1200ES
    {
        #region Constantes
        private const int NumeroBytesEntradaTra = 9;
        private const int NumeroByteSalidasTra = 3;
        private const int RegistroInicialEntradasTra = 0;
        private const int RegistroInicialSalidasTra = 0;
        private const int BitInicialSalida = 9;
        #endregion Constantes

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoSiemens1200ESGTRA.
        /// </summary>
        /// <param name="tags">Colección de tags.</param>
        /// <param name="hilos">Colección de hilos.</param>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public ODispositivoSiemens1200ESGTRA(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo) { }
        #endregion Constructor

        #region Métodos protegidos
        /// <summary>
        /// Establece el valor inicial de los objetos
        /// </summary>
        protected override void Inicializar()
        {
            base.Inicializar();

            ProtocoloHiloVida = new OProtocoloTCPSiemensGateTraffic();
            ProtocoloEscritura = new OProtocoloTCPSiemensGateTraffic();
            ProtocoloProcesoMensaje = new OProtocoloTCPSiemensGateTraffic();
            ProtocoloProcesoHilo = new OProtocoloTCPSiemensGateTraffic();

            NumeroLecturas = NumeroBytesEntradaTra + NumeroByteSalidasTra;
            NumeroBytesEntradas = NumeroBytesEntradaTra;
            NumeroBytesSalidas = NumeroByteSalidasTra;
            RegistroInicialEntradas = RegistroInicialEntradasTra;
            RegistroInicialSalidas = RegistroInicialSalidasTra;

            Entradas = new byte[NumeroBytesEntradas];
            Salidas = new byte[NumeroBytesSalidas];

            BytesLecturas = new byte[NumeroLecturas];

            LecturaInicialSalida = BitInicialSalida;
        }
        /// <summary>
        /// Procesa los mensajes recibidos en el evento Winsock_DataArrival.
        /// </summary>
        /// <param name="mensaje">Mensaje de recepción.</param>
        protected override void ProcesarMensajeRecibido(byte[] mensaje)
        {
            lock (this)
            {
                try
                {
                    using (ProtocoloProcesoMensaje)
                    {
                        if (!ProtocoloProcesoMensaje.Deserializar(mensaje).Contains("GTFDATA")) return;

                        // Respuesta para la lectura.
                        byte[] bytesLecturas;
                        if (mensaje[15] == 0)
                        {
                            if (ProtocoloProcesoMensaje.KeepAliveProcesar(mensaje, out bytesLecturas))
                            {
                                if (!BytesLecturas.SequenceEqual(bytesLecturas))
                                {
                                    Encolar(bytesLecturas);
                                }
                                BytesLecturas = bytesLecturas;
                                Reset.Despertar(0); // Despertar el hilo en la línea: this._eReset.Dormir de ProcesarHiloKeepAlive.
                            }
                        }
                        else // Respuesta para la escritura.
                        {
                            if (ProtocoloProcesoMensaje.SalidasProcesar(mensaje, IdMensaje, out bytesLecturas))
                            {
                                if (!BytesLecturas.SequenceEqual(bytesLecturas))
                                {
                                    Encolar(bytesLecturas);
                                }
                                BytesLecturas = bytesLecturas;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Wrapper.Error("ODispositivo1200ESGTRA [ProcesarMensajeRecibido]: " + ex);
                }
            }
        }
        /// <summary>
        /// Hilo de proceso de ES.
        /// </summary>
        protected override void ProcesarHilo()
        {
            while (true)
            {
                byte[] mensaje = Desencolar();
                if (mensaje != null)
                {
                    try
                    {
                        var entradas = new byte[9];
                        var salidas = new byte[3];
                        Array.Copy(mensaje, 0, entradas, 0, 9);
                        Array.Copy(mensaje, 9, salidas, 0, 3);

                        // Procesar los bytes de entradas y salidas para actualizar los valores de las variables.
                        ProcesarEntradasSalidas(entradas, salidas);
                    }
                    catch (Exception ex)
                    {
                        Wrapper.Fatal("ODispositivo1200ESGTRA [ProcesarHilo]: " + ex);
                    }
                    Thread.Sleep(1);
                }
                else
                {
                    Reset.Dormir(1);
                }
            }
        }
        #endregion Métodos protegidos

        #region Métodos privados
        /// <summary>
        /// Procesa los bytes de entradas y salidas para actualizar los valores de las variables.
        /// </summary>
        /// <param name="entradas">Byte de entradas recibido.</param>
        /// <param name="salidas">Byte de salidas recibido.</param>
        private void ProcesarEntradasSalidas(byte[] entradas, byte[] salidas)
        {
            lock (ObjSincronizacion)
            {
                try
                {
                    for (int i = 0; i < entradas.Length; i++)
                    {
                        ActualizarEntradas(entradas[i], i + RegistroInicialEntradas);
                        if (i < 3)
                        {
                            ActualizarSalidas(salidas[i], i + RegistroInicialSalidas);
                        }
                    }
                    Entradas = entradas;
                    Salidas = salidas;
                }
                catch (Exception ex)
                {
                    Wrapper.Fatal("ODispositivoSiemens1200ESTRA [Procesar]:  " + ex);
                    throw;
                }
            }
        }
        /// <summary>
        /// Actualizar los valores de las entradas y genera los eventos de cambio de dato y alarma.
        /// </summary>
        /// <param name="valor">Valor del byte.</param>
        /// <param name="posicion">Posición del byte.</param>
        private void ActualizarEntradas(byte valor, int posicion)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    string key = string.Format("{0}-{1}", posicion, i);
                    var infodato = (OInfoDato)AlmacenLecturas[key];
                    if (infodato == null) continue;

                    // Comprobar el valor nuevo. 
                    int resultado = 0;
                    if ((valor & (1 << i)) != 0)
                    {
                        resultado = 1;
                    }

                    int valorInfoDato = Convert.ToInt32(infodato.Valor);
                    if (resultado == valorInfoDato) continue;

                    // Actualizar la información de valor.
                    infodato.Valor = resultado;

                    // Crear el argumento asociado al evento.
                    var e = new OEventArgs { Argumento = infodato };

                    // Elevar el evento OnCambioDato.
                    OnCambioDato(e);

                    // Alarmas.
                    if (Tags.GetAlarmas(infodato.Identificador) == null) continue;
                    if (valorInfoDato == 1)
                    {
                        if (!AlarmasActivas.Contains(infodato.Texto))
                        {
                            AlarmasActivas.Add(infodato.Texto);
                        }
                    }
                    else
                    {
                        if (AlarmasActivas.Contains(infodato.Texto))
                        {
                            AlarmasActivas.Remove(infodato.Texto);
                        }
                    }

                    // Elevar el evento OnAlarma.
                    OnAlarma(e);

                    // Actualizar la información de último valor.
                    infodato.UltimoValor = resultado;
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivo1200ESGTRA [ActualizarVariablesEntradas]: " + ex);
            }
        }
        /// <summary>
        /// Actualizar los valores de las salidas y genera los eventos de cambio de dato y alarma.
        /// </summary>
        /// <param name="valor">Valor del byte.</param>
        /// <param name="posicion">Posición del byte.</param>
        private void ActualizarSalidas(byte valor, int posicion)
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    string key = string.Format("{0}-{1}", posicion, i);
                    var infodato = (OInfoDato)AlmacenEscrituras[key];
                    if (infodato == null) continue;

                    // Comprobar el valor nuevo.
                    int resultado = 0;
                    if ((valor & (1 << i)) != 0)
                    {
                        resultado = 1;
                    }

                    int valorInfoDato = Convert.ToInt32(infodato.Valor);
                    if (resultado == valorInfoDato) continue;

                    // Actualizar la información de valor.
                    infodato.Valor = resultado;

                    // Crear el argumento asociado al evento.
                    var e = new OEventArgs { Argumento = infodato };

                    // Elevar el evento OnCambioDato.
                    OnCambioDato(e);

                    // Alarmas.
                    if (Tags.GetAlarmas(infodato.Identificador) == null) continue;
                    if (valorInfoDato == 1)
                    {
                        if (!AlarmasActivas.Contains(infodato.Texto))
                        {
                            AlarmasActivas.Add(infodato.Texto);
                        }
                    }
                    else
                    {
                        if (AlarmasActivas.Contains(infodato.Texto))
                        {
                            AlarmasActivas.Remove(infodato.Texto);
                        }
                    }

                    // Elevar el evento OnAlarma.
                    OnAlarma(e);

                    // Actualizar la información de último valor.
                    infodato.UltimoValor = resultado;
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivo1200ESGTRA [ActualizarVariablesSalidas]: " + ex);
            }
        }
        #endregion Métodos privados
    }
}