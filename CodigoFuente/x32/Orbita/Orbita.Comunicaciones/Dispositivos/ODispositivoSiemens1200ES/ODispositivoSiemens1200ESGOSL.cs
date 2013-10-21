using System;
using System.Linq;
using System.Threading;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo Siemens 1200 OSL.
    /// </summary>
    public class ODispositivoSiemens1200ESGOSL : ODispositivoSiemens1200ES
    {
        #region Constantes
        private const int NumeroBytesEntradaLPR = 2;
        private const int NumeroByteSalidasLPR = 2;
        private const int RegistroInicialEntradasLPR = 0;
        private const int RegistroInicialSalidasLPR = 0;
        private const int BitInicialSalida = 2;
        #endregion Constantes

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoSiemens1200ESGOSL.
        /// </summary>
        /// <param name="tags">Colección de tags.</param>
        /// <param name="hilos">Colección de hilos.</param>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public ODispositivoSiemens1200ESGOSL(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo) { }
        #endregion Constructor

        #region Métodos protegidos
        /// <summary>
        /// Establece el valor inicial de los objetos.
        /// </summary>
        protected override void Inicializar()
        {
            base.Inicializar();
            ProtocoloHiloVida = new OProtocoloTCPSiemensGateLPROS();
            ProtocoloEscritura = new OProtocoloTCPSiemensGateLPROS();
            ProtocoloProcesoMensaje = new OProtocoloTCPSiemensGateLPROS();
            ProtocoloProcesoHilo = new OProtocoloTCPSiemensGateLPROS();

            NumeroLecturas = NumeroBytesEntradaLPR + NumeroByteSalidasLPR;
            NumeroBytesEntradas = NumeroBytesEntradaLPR;
            NumeroBytesSalidas = NumeroByteSalidasLPR;
            RegistroInicialEntradas = RegistroInicialEntradasLPR;
            RegistroInicialSalidas = RegistroInicialSalidasLPR;

            Entradas = new byte[NumeroBytesEntradas];
            Salidas = new byte[NumeroBytesSalidas];

            BytesLecturas = new byte[NumeroLecturas];
            LecturaInicialSalida = BitInicialSalida;
        }
        /// <summary>
        /// Procesar los mensajes recibidos en el evento Winsock_DataArrival.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected override void ProcesarMensajeRecibido(byte[] mensaje)
        {
            lock (this)
            {
                try
                {
                    using (ProtocoloProcesoMensaje)
                    {
                        if (!ProtocoloProcesoMensaje.Deserializar(mensaje).Contains("OSLDATA")) return;

                        byte[] bytesLecturas;
                        if (mensaje[15] == 0) // Respuesta para la lectura.
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
                    Wrapper.Error("ODispositivoSiemens1200ESGOSL [ProcesarMensajeRecibido]: " + ex);
                }
            }
        }
        /// <summary>
        /// Hilo de proceso de E/S.
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
                        var entradas = new byte[2];
                        var salidas = new byte[2];
                        Array.Copy(mensaje, 0, entradas, 0, 2);
                        Array.Copy(mensaje, 2, salidas, 0, 2);

                        // Procesar los bytes de entradas y salidas para actualizar los valores de las variables.
                        ProcesarEntradasSalidas(entradas, salidas);
                    }
                    catch (Exception ex)
                    {
                        Wrapper.Fatal("ODispositivoSiemens1200ESGOSL [ProcesarHilo]: " + ex);
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
            try
            {
                for (int i = 0; i < entradas.Length; i++)
                {
                    ActualizarEntradas(entradas[i], i + RegistroInicialEntradas);
                    ActualizarSalidas(salidas[i], i + RegistroInicialSalidas);
                }
                Entradas = entradas;
                Salidas = salidas;
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoSiemens1200ESGOSL [Procesar]: " + ex);
                throw;
            }
        }
        /// <summary>
        /// Actualiza los valores de las entradas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void ActualizarEntradas(byte valor, int posicion)
        {
            var e = new OEventArgs();
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    string key = string.Format("{0}-{1}", posicion, i);
                    var infodato = (OInfoDato)AlmacenLecturas[key];

                    // Comprobar el valor nuevo.
                    if (infodato == null) continue;
                    int resultado = 0;
                    if ((valor & (1 << i)) != 0)
                    {
                        resultado = 1;
                    }

                    if (resultado == Convert.ToInt32(infodato.Valor)) continue;
                    infodato.Valor = resultado;
                    e.Argumento = infodato;

                    // Elevar el evento OnCambioDato.
                    OnCambioDato(e);

                    if (Tags.GetAlarmas(infodato.Identificador) == null) continue;
                    if (Convert.ToInt32(infodato.Valor) == 1)
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
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ESGOSL [ActualizarVariablesEntradas]: " + ex);
            }
        }
        /// <summary>
        /// Actualiza los valores de las salidas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void ActualizarSalidas(byte valor, int posicion)
        {
            var e = new OEventArgs();
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    string key = string.Format("{0}-{1}", posicion, i);
                    var infodato = (OInfoDato)AlmacenEscrituras[key];

                    // Comprobar el valor nuevo.
                    if (infodato == null) continue;
                    int resultado = 0;
                    if ((valor & (1 << i)) != 0)
                    {
                        resultado = 1;
                    }

                    if (resultado == Convert.ToInt32(infodato.Valor)) continue;
                    infodato.Valor = resultado;
                    e.Argumento = infodato;

                    // Elevar el evento OnCambioDato.
                    OnCambioDato(e);

                    if (Tags.GetAlarmas(infodato.Identificador) == null) continue;
                    if (Convert.ToInt32(infodato.Valor) == 1)
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
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ESGOSL [ActualizarVariablesSalidas]: " + ex);
            }
        }
        #endregion Métodos privados
    }
}