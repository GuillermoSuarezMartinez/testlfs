using System;
using System.Linq;
using System.Text;
using System.Threading;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Dispositivo Siemens 1200 OSO.
    /// </summary>
    public class ODispositivoSiemens1200ESGOSO : ODispositivoSiemens1200ES
    {
        #region Constantes
        private const int BytesEntradaOCR = 8;
        private const int ByteSalidasOCR = 4;
        private const int RegistroInicialEntradasOCR = 0;
        private const int RegistroInicialSalidasOCR = 0;
        #endregion Constantes

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ODispositivoSiemens1200ESGOSO.
        /// </summary>
        /// <param name="tags">Colección de tags.</param>
        /// <param name="hilos">Colección de hilos.</param>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public ODispositivoSiemens1200ESGOSO(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo) { }
        #endregion Constructor

        #region Métodos privados

        #region Comunes
        /// <summary>
        /// Establece el valor inicial de los objetos.
        /// </summary>
        protected override void IniciarObjetos()
        {
            base.IniciarObjetos();

            this.ProtocoloHiloVida = new OProtocoloTCPSiemensGateOCROS();
            this.ProtocoloEscritura = new OProtocoloTCPSiemensGateOCROS();
            this.ProtocoloProcesoMensaje = new OProtocoloTCPSiemensGateOCROS();
            this.ProtocoloProcesoHilo = new OProtocoloTCPSiemensGateOCROS();

            this.NumLecturas = BytesEntradaOCR + ByteSalidasOCR;
            this.NumeroBytesEntradas = BytesEntradaOCR;
            this.NumeroBytesSalidas = ByteSalidasOCR;
            this.RegistroInicialEntradas = RegistroInicialEntradasOCR;
            this.RegistroInicialSalidas = RegistroInicialSalidasOCR;

            this.Entradas = new byte[this.NumeroBytesEntradas];
            this.Salidas = new byte[this.NumeroBytesSalidas];

            this._lecturas = new byte[NumLecturas];
        }
        /// <summary>
        /// Procesa los mensajes recibidos en el evento Winsock_DataArrival.
        /// </summary>
        /// <param name="mensaje">Colección de bytes que forman el mensaje.</param>
        protected override void ProcesarMensajeRecibido(byte[] mensaje)
        {
            try
            {
                var bmensaje = new byte[13];
                Array.Copy(mensaje, 1, bmensaje, 0, 13);
                string smensaje = Encoding.ASCII.GetString(bmensaje);
                using (ProtocoloProcesoMensaje)
                {
                    if (!smensaje.Contains("OSODATA")) return;

                    byte[] lecturas;
                    // Respuesta para la lectura.
                    if (mensaje[15] == 0)
                    {
                        if (ProtocoloProcesoMensaje.KeepAliveProcesar(mensaje, out lecturas))
                        {
                            bool iguales = this._lecturas.SequenceEqual(lecturas);
                            if (!iguales)
                            {
                                this.EsEncolar(lecturas);
                            }
                            this._lecturas = lecturas;
                            // Despertar el hilo en la línea: this._eReset.Dormir de ProcesarHiloKeepAlive.                        
                            this.Reset.Despertar(0);
                        }
                    }
                    else // Respuesta para la escritura.
                    {
                        if (ProtocoloProcesoMensaje.SalidasProcesar(mensaje, this.IdMensaje, out lecturas))
                        {
                            bool iguales = this._lecturas.SequenceEqual(lecturas);
                            if (!iguales)
                            {
                                this.EsEncolar(lecturas);
                            }
                            this._lecturas = lecturas;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ESGOSO [ProcesarMensajeRecibido]: " + ex);
            }
        }
        #endregion Comunes

        #region ES
        /// <summary>
        /// Hilo de proceso de ES.
        /// </summary>
        protected override void EsProcesarHilo()
        {
            while (true)
            {
                byte[] mensaje = this.EsDesencolar();
                if (mensaje != null)
                {
                    try
                    {
                        var entradas = new byte[BytesEntradaOCR];
                        var salidas = new byte[ByteSalidasOCR];
                        Array.Copy(mensaje, 0, entradas, 0, BytesEntradaOCR);
                        Array.Copy(mensaje, BytesEntradaOCR, salidas, 0, ByteSalidasOCR);
                        this.EsProcesar(entradas, salidas);
                    }
                    catch (Exception ex)
                    {
                        Wrapper.Fatal("ODispositivoSiemens1200ESGOSO [EsProcesarHilo]: " + ex);
                    }
                    Thread.Sleep(1);
                }
                else
                {
                    this.Reset.Dormir(1);
                }
            }
        }
        /// <summary>
        /// Procesa los bytes de entradas y salidas para actualizar los valores de las variables.
        /// </summary>
        /// <param name="entradas">Byte de entradas recibido.</param>
        /// <param name="salidas">Byte de salidas recibido.</param>
        private void EsProcesar(byte[] entradas, byte[] salidas)
        {
            try
            {
                for (int i = 0; i < entradas.Length; i++)
                {
                    this.EsActualizarVariablesEntradas(entradas[i], i + this.RegistroInicialEntradas);
                    if (i < ByteSalidasOCR)
                    {
                        this.EsActualizarVariablesSalidas(salidas[i], i + this.RegistroInicialSalidas);
                    }
                }
                this.Entradas = entradas;
                this.Salidas = salidas;
            }
            catch (Exception ex)
            {
                Wrapper.Fatal("ODispositivoSiemens1200ESGOSO [EsProcesar]: " + ex);
                throw;
            }
        }
        /// <summary>
        /// Actualiza los valores de las entradas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void EsActualizarVariablesEntradas(byte valor, int posicion)
        {
            var e = new OEventArgs();
            try
            {
                this.OnCambioDatoEntradas(new OEventArgs { Id = posicion, Argumento = valor });
            }
            catch
            {
                // Empty.
            }
            try
            {
                OInfoDato infodato;
                if (posicion < 4)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        string key = string.Format("{0}-{1}", posicion, i);
                        infodato = (OInfoDato)this.AlmacenLecturas[key];
                        if (infodato == null) continue;

                        // Comprobar el valor nuevo.
                        int resultado = 0;
                        if ((valor & (1 << i)) != 0)
                        {
                            resultado = 1;
                        }

                        if (resultado == Convert.ToInt32(infodato.Valor)) continue;
                        infodato.Valor = resultado;
                        e.Argumento = infodato;
                        this.OnCambioDato(e);

                        if (this.Tags.GetAlarmas(infodato.Identificador) == null) continue;
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
                        this.OnAlarma(e);
                    }
                }
                else
                {
                    string key = string.Format("{0}-0", posicion);
                    infodato = (OInfoDato)this.AlmacenLecturas[key];

                    // Comprobar el valor nuevo.
                    if (infodato != null)
                    {
                        if (valor != Convert.ToInt32(infodato.Valor))
                        {
                            infodato.Valor = valor;
                            e.Argumento = infodato;
                            this.OnCambioDato(e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Wrapper.Error("ODispositivoSiemens1200ESGOSO [EsActualizarVariablesEntradas]: " + ex);
            }
        }
        /// <summary>
        /// Actualiza los valores de las salidas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void EsActualizarVariablesSalidas(byte valor, int posicion)
        {
            var e = new OEventArgs();
            try
            {
                this.OnCambioDatoSalidas(new OEventArgs { Id = posicion, Argumento = valor });
            }
            catch
            {
                // Empty.
            }

            for (int i = 0; i < 8; i++)
            {
                try
                {
                    string key = string.Format("{0}-{1}", posicion, i);
                    var infodato = (OInfoDato)this.AlmacenEscrituras[key];
                    if (infodato == null) continue;

                    // Comprobar el valor nuevo.
                    int resultado = 0;
                    if ((valor & (1 << i)) != 0)
                    {
                        resultado = 1;
                    }

                    if (resultado == Convert.ToInt32(infodato.Valor)) continue;
                    infodato.Valor = resultado;
                    e.Argumento = infodato;
                    this.OnCambioDato(e);

                    if (this.Tags.GetAlarmas(infodato.Identificador) == null) continue;
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
                    this.OnAlarma(e);
                }
                catch (Exception ex)
                {
                    Wrapper.Error("ODispositivoSiemens1200ESGOSO [EsActualizarVariablesSalidas]: " + ex);
                }
            }
        }
        #endregion ES

        #endregion Métodos privados
    }
}