using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Comunicaciones;
using Orbita.Utiles;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Collections;

namespace WindowsFormsApplication1
{
    #region Delegados

    public delegate void EventoClienteComs(OEventArgs e, string canal);
    public delegate void EventoClienteCambioDato(OEventArgs e, string canal);
    public delegate void EventoClienteAlarma(OEventArgs e, string canal);
    public delegate void EventoClienteEstadoCabal(OEventArgs e, string canal);

    #endregion
    public class ClienteRemoting
    {

        #region Variables

        /// <summary>
        /// Canal comunicaciones remoto
        /// </summary>
        private string _nombreCanal = "CanalRemoting";
        /// <summary>
        /// Puerto de comunicación de remoting
        /// </summary>
        private int _remotingPuerto = 1852;
        /// <summary>
        /// Servidor de comunicaciones.
        /// </summary>
        private IOCommRemoting _servidor;
        /// <summary>
        /// Servidor remoting
        /// </summary>
        private string _servidorRemoting = "localhost";
        /// <summary>
        /// Evento para los cambios de comunicaciones
        /// </summary>
        public event EventoClienteComs OEventoClienteComs;
        /// <summary>
        /// Evento para los cambios de dato
        /// </summary>
        public event EventoClienteCambioDato OEventoClienteCambioDato;
        /// <summary>
        /// Evento para las alarmas
        /// </summary>
        public event EventoClienteAlarma OEventoClienteAlarma;
        /// <summary>
        /// <summary>
        /// Wrapper de comunicaciones
        /// </summary>
        private OBroadcastEventWrapper _eventWrapper;


        #endregion

        #region Eventos

        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e"></param>
        public virtual void eventWrapper_OrbitaCambioDato(OEventArgs e)
        {
            try
            {
                OEventoClienteCambioDato(e, this._nombreCanal);
            }
            catch (Exception ex)
            {
            }

        }
        /// <summary>
        /// Evento de alarma.
        /// </summary>
        /// <param name="e"></param>
        void eventWrapper_OrbitaAlarma(OEventArgs e)
        {
            try
            {
                OEventoClienteAlarma(e, this._nombreCanal);
            }
            catch (Exception ex)
            {
            }

        }
        /// <summary>
        /// Evento de comunicaciones.
        /// </summary>
        /// <param name="e"></param>
        public void eventWrapper_OrbitaComm(OEventArgs e)
        {
            try
            {
                OEventoClienteComs(e, this._nombreCanal);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        public ClienteRemoting(int puerto, string servidor)
        {
            this._remotingPuerto = puerto;
            this._servidorRemoting = servidor;
        }

        #region Metodos

        /// <summary>
        /// Incia las comunicaciones con el dispositivo remoto
        /// </summary>
        public void Iniciar()
        {
            try
            {
                //ORemoting.InicConfiguracionCliente(this._remotingPuerto, this._servidorRemoting);
                //this._servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));
                IDictionary RemoteChannelProperties = new Hashtable();
                RemoteChannelProperties["name"] = "tcp";
                RemoteChannelProperties["port"] = "0";
                TcpChannel chan = new TcpChannel(RemoteChannelProperties, null, null);
                ChannelServices.RegisterChannel(chan);
                
                RemotingConfiguration.RegisterWellKnownClientType(
                  new WellKnownClientTypeEntry(typeof(IOCommRemoting), 
                      "tcp://localhost:"+this._remotingPuerto.ToString()+"/Orbita.Comunicaciones.soap"));                

                this._servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));


                this.ConectarWrapper();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Conecta con el wrapper de remoting
        /// </summary>
        public void ConectarWrapper()
        {
            try
            {
                // Eventwrapper de comunicaciones.
                this._eventWrapper = new Orbita.Comunicaciones.OBroadcastEventWrapper();

                //Eventos locales.
                //...cambio de dato.
                this._eventWrapper.OrbitaCambioDato += new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                this._eventWrapper.OrbitaAlarma += new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                this._eventWrapper.OrbitaComm += new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato += new OManejadorEventoComm(_eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma += new OManejadorEventoComm(_eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm += new OManejadorEventoComm(_eventWrapper.OnComm);

                // Establecer conexión con el servidor.
                Conectar(true);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Desconectar del wrapper de remoting
        /// </summary>
        public void DesconectarWrapper()
        {
            try
            {
                Conectar(false);
                //Eventos locales.
                //...cambio de dato.
                this._eventWrapper.OrbitaCambioDato -= new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                this._eventWrapper.OrbitaAlarma -= new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                this._eventWrapper.OrbitaComm -= new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato -= new OManejadorEventoComm(_eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma -= new OManejadorEventoComm(_eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm -= new OManejadorEventoComm(_eventWrapper.OnComm);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Conectar al servidor vía Remoting.
        /// </summary>
        /// <param name="estado">Estado de conexión.</param>
        private void Conectar(bool estado)
        {
            try
            {
                string strHostName = "";
                strHostName = System.Net.Dns.GetHostName();

                string canal = "canal" + strHostName + ":" + this._remotingPuerto.ToString();
                this._servidor.OrbitaConectar(canal, estado);
            }
            catch (Exception ex)
            {
            }

        }
        /// <summary>
        /// Metodo para escribir en el Servidor de Comunicaciones
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <param name="valor">Valor a escribir</param>
        public bool EscribirComs(int idDispositivo, string[] variables, object[] valores)
        {
            bool ret = false;
            try
            {
                ret = this._servidor.OrbitaEscribir(idDispositivo, variables, valores);
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
        /// <summary>
        /// Metodo para leer en el Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <returns>Valor leido</returns>
        public object[] LeerComs(int idDispositivo, string[] variables)
        {
            object[] ret = null;

            try
            {
                ret = this._servidor.OrbitaLeer(idDispositivo, variables, true);
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las variables del Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable Variables(int idDispositivo)
        {
            OHashtable ret = null;

            try
            {
                ret = this._servidor.OrbitaGetDatos(idDispositivo);
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
        /// <summary>
        /// Obtiene las alarmas del Servidor de comunicaciones
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable Alarmas(int idDispositivo)
        {
            OHashtable ret = null;

            try
            {
                ret = this._servidor.OrbitaGetAlarmas(idDispositivo);
            }
            catch (Exception ex)
            {
            }
            return ret;
        }
        /// <summary>
        /// Obtiene los dispositivos del Servidor de comunicaciones
        /// </summary>
        /// <returns></returns>
        public int[] Dispositivos()
        {
            int[] ret = null;

            try
            {
                ret = this._servidor.OrbitaGetDispositivos();
            }
            catch (Exception ex)
            {
            }
            return ret;
        }

        #endregion
    }
}
