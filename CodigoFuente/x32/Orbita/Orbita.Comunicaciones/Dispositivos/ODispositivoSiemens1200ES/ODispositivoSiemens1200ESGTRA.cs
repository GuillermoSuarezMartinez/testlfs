using System;
using System.Collections;
using System.Text;
using System.Threading;
using Orbita.Utiles;
using Orbita.Winsock;

namespace Orbita.Comunicaciones
{
    public class ODispositivoSiemens1200ESGTRA : ODispositivoSiemens1200ES
    {
        #region Atributos

        private int _bytesEntradaTRA = 9;
        private int _byteSalidasTRA = 3;
        private int _registroInicialEntradasTRA = 0;
        private int _registroInicialSalidasTRA = 0;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de clase de Siemens1200
        /// </summary>
        public ODispositivoSiemens1200ESGTRA(OTags tags, OHilos hilos, ODispositivo dispositivo)
            : base(tags, hilos, dispositivo)
        {

        }
        #endregion

        #region Métodos privados

        #region Comunes

        /// <summary>
        /// Establece el valor inicial de los objetos
        /// </summary>
        protected override void IniciarObjetos()
        {
            base.IniciarObjetos();
            this.protocoloHiloVida = new OProtocoloTCPSiemensGateTraffic();
            this.protocoloEscritura = new OProtocoloTCPSiemensGateTraffic();
            this.protocoloProcesoMensaje = new OProtocoloTCPSiemensGateTraffic();
            this.protocoloProcesoHilo = new OProtocoloTCPSiemensGateTraffic();

            this._numLecturas = this._bytesEntradaTRA + this._byteSalidasTRA;
            this._numeroBytesEntradas = this._bytesEntradaTRA;
            this._numeroBytesSalidas = this._byteSalidasTRA;
            this._registroInicialEntradas = this._registroInicialEntradasTRA;
            this._registroInicialSalidas = this._registroInicialSalidasTRA;

            this.Entradas = new byte[this._numeroBytesEntradas];
            this.Salidas = new byte[this._numeroBytesSalidas];

            this._lecturas = new byte[_numLecturas];
        }
        /// <summary>
        /// Procesa los mensajes recibidos en el data arrival
        /// </summary>
        /// <param name="mensaje"></param>
        protected override void ProcesarMensajeRecibido(byte[] mensaje)
        {
            try
            {
                byte[] bmensaje = new byte[13];
                Array.Copy(mensaje, 1, bmensaje, 0, 13);
                string smensaje = ASCIIEncoding.ASCII.GetString(bmensaje);
                byte[] lecturas;

                using (protocoloProcesoMensaje)
                {
                    if (smensaje.Contains("GTFDATA"))//respuesta para la lectura
                    {
                        if (mensaje[15] == 0)
                        {
                            
                            if (protocoloProcesoMensaje.KeepAliveProcesar(mensaje, out lecturas))
                            {
                                for (int i = 0; i < this._numLecturas; i++)
                                {
                                    if (this._lecturas[i] != lecturas[i])
                                    {
                                        this.ESEncolar(lecturas);
                                        break;
                                    }
                                }
                                this._lecturas = lecturas;
                                // Despertar el hilo en la línea:
                                // this._eReset.Dormir de ProcesarHiloKeepAlive.                        
                                this._eReset.Despertar(0);
                            }
                        }
                        else//respuesta para la escritura
                        {
                            if (protocoloProcesoMensaje.SalidasProcesar(mensaje, this.IdMens, out lecturas))
                            {
                                this._valorEscritura = mensaje;
                                for (int i = 0; i < this._numLecturas; i++)
                                {
                                    if (this._lecturas[i] != lecturas[i])
                                    {
                                        this.ESEncolar(lecturas);
                                        break;
                                    }
                                }
                                this._lecturas = lecturas;
                                this._eReset.Despertar(2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = "ODispositivo1200ESGTRA ProcesarMensajeRecibido Error en ProcesarMensajeRecibido en el dispositivo de ES Siemens: " + ex.ToString();
                wrapper.Error(error);
            }
        }

        #endregion

        #region ES

        /// <summary>
        /// Hilo de proceso de ES
        /// </summary>
        protected override void ESProcesarHilo()
        {
            while (true)
            {
                byte[] mensaje = this.ESDesencolar();

                if (mensaje != null)
                {
                    try
                    {
                        byte[] entradas = null, salidas = null;
                        entradas = new byte[9]; salidas = new byte[3];
                        Array.Copy(mensaje, 0, entradas, 0, 9);
                        Array.Copy(mensaje, 9, salidas, 0, 3);
                        this.ESProcesar(entradas, salidas);
                    }
                    catch (Exception ex)
                    {
                        wrapper.Fatal("ODispositivo1200ESGTRA ESProcesarHilo Error al procesar las ES en el dispositivo de ES Siemens. " + ex.ToString());
                    }
                    Thread.Sleep(10);
                }
                else
                {
                    this._eReset.Dormir(1);
                }
            }
        }
        /// <summary>
        /// Procesa los bytes de entradas y salidas para actualizar los valores de las variables
        /// </summary>
        /// <param name="entradas">byte de entradas recibido</param>
        /// <param name="salidas">byte de salidas recibido</param>
        private void ESProcesar(byte[] entradas, byte[] salidas)
        {           

            lock (this.bloqueo)
            {                
                try
                {
                    for (int i = 0; i < entradas.Length; i++)
                    {
                        this.ESActualizarVariablesEntradas(entradas[i], i + this._registroInicialEntradas);
                        if (i < 3)
                        {
                            this.ESActualizarVariablesSalidas(salidas[i], i + this._registroInicialSalidas);
                        }
                    }
                    this.Entradas = entradas;
                    this.Salidas = salidas;
                    
                }
                catch (Exception ex)
                {
                    wrapper.Fatal("ODispositivoSiemens1200ESTRA ESProcesar Error al procesar las ES en el dispositivo de ES Siemens en ESProcesar. " + ex.ToString());
                    throw ex;
                }

            }

        }
        /// <summary>
        /// Actualiza los valores de las entradas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void ESActualizarVariablesEntradas(byte valor, int posicion)
        {
            OInfoDato infodato = null;
            OEventArgs ev = new OEventArgs();

            try
            {
                OEventArgs evBit = new OEventArgs(); ;
                evBit.Id = posicion;
                evBit.Argumento = valor;
                this.OnCambioDatoEntradas(evBit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                for (int i = 0; i < 8; i++)
                {
                    infodato = (OInfoDato)this._almacenLecturas[posicion.ToString() + "-" + i.ToString()];
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
                    else
                    {
                        //wrapper.Warn("No se puede encontrar la dupla " + posicion.ToString() + "-" + i.ToString() +
                        //    " al actualizar las variables de entrada en el dispositivo de ES Siemens.");
                    }

                }
            }
            catch (Exception ex)
            {
                wrapper.Error("ODispositivo1200ESGTRA ESActualizarVariablesEntradas Error no controlado al procesar las entradas en el dispositivo de ES Siemens" + ex.ToString());
            }
        }
        /// <summary>
        /// Actualiza los valores de las salidas y genera los eventos de cambio de dato y alarma
        /// </summary>
        /// <param name="valor">valor del byte</param>
        /// <param name="posicion">posición del byte</param>
        private void ESActualizarVariablesSalidas(byte valor, int posicion)
        {
            wrapper.Info("ODispositivoSiemens1200ESTRA ESActualizarVariablesSalidas "+ posicion.ToString() + " " + valor.ToString());
            OInfoDato infodato = null;
            OEventArgs ev = new OEventArgs();
            try
            {
                OEventArgs evBit = new OEventArgs(); ;
                evBit.Id = posicion;
                evBit.Argumento = valor;
                this.OnCambioDatoSalidas(evBit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    infodato = (OInfoDato)this._almacenEscrituras[posicion.ToString() + "-" + i.ToString()];
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
                    else
                    {
                        //wrapper.Warn("No se puede encontrar la dupla " + posicion.ToString() + "-" + i.ToString() +
                        //    " al actualizar las variables de salida en el dispositivo de ES Siemens.");
                    }

                }
                catch (Exception ex)
                {
                    wrapper.Error("ODispositivo1200ESGTRA ESActualizarVariablesSalidas Error no controlado al procesar las salidas en el dispositivo de ES Siemens " + ex.ToString());
                }

            }
        }
        #endregion

        #endregion
    }
}
