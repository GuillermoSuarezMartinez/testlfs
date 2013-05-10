using System;
using System.ComponentModel;
using Orbita.Comunicaciones;
using Orbita.Utiles;
namespace Orbita.Controles.Comunicaciones
{
    public delegate void EventoClienteComs(OEventArgs e, string canal);
    public delegate void EventoClienteCambioDato(OEventArgs e, string canal);
    public delegate void EventoClienteAlarma(OEventArgs e, string canal);

    public partial class OrbitaConfiguracionCanal : Component
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
        public static event EventoClienteComs OEventoClienteComs;
        /// <summary>
        /// Evento para los cambios de dato
        /// </summary>
        public static event EventoClienteCambioDato OEventoClienteCambioDato;
        /// <summary>
        /// Evento para las alarmas
        /// </summary>
        public static event EventoClienteAlarma OEventoClienteAlarma;

        #endregion

        #region Propiedades
        /// <summary>
        /// Puerto de comunicación de remoting
        /// </summary>
        public int RemotingPuerto
        {
            get { return _remotingPuerto; }
            set { _remotingPuerto = value; }
        }
        /// <summary>
        /// Servidor de comunicaciones.
        /// </summary>
        public string ServidorRemoting
        {
            get { return _servidorRemoting; }
            set { _servidorRemoting = value; }
        }
        /// <summary>
        /// Canal comunicaciones remoto
        /// </summary>
        public string NombreCanal
        {
            get { return _nombreCanal; }
            set { _nombreCanal = value; }
        }
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {

            }

        }

        #endregion

        public OrbitaConfiguracionCanal()
        {
            InitializeComponent();
        }

        public OrbitaConfiguracionCanal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Inicia la comunicación con el servidor remoto
        /// </summary>
        public void Iniciar()
        {
            try
            {
                // Establecer la configuración Remoting entre procesos.
                ORemoting.InicConfiguracionCliente(this._remotingPuerto, this._servidorRemoting);
                this._servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));

                // Eventwrapper de comunicaciones.
                Orbita.Comunicaciones.OBroadcastEventWrapper eventWrapper = new Orbita.Comunicaciones.OBroadcastEventWrapper();

                //Eventos locales.
                //...cambio de dato.
                eventWrapper.OrbitaCambioDato += new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                eventWrapper.OrbitaAlarma += new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                eventWrapper.OrbitaComm += new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato += new OManejadorEventoComm(eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma += new OManejadorEventoComm(eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm += new OManejadorEventoComm(eventWrapper.OnComm);

                // Establecer conexión con el servidor.
                Conectar(true);
            }
            catch (Exception)
            {
                //OMensajes.MostrarError(ex);
            }
        }

        private void Conectar(bool estado)
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            string canal = "canal" + strHostName + ":" + this._remotingPuerto.ToString();
            this._servidor.OrbitaConectar(canal, estado);
        }

        /// <summary>
        /// Finaliza la conexión con el servidor
        /// </summary>
        public void Finaliza()
        {
            this._servidor.OrbitaConectar("canal" + this._remotingPuerto, false);
        }
        /// <summary>
        /// Metodo para escribir en el SCED
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <param name="valor">Valor a escribir</param>
        public void EscribirSCED(int dispositivo, string variable, object valor)
        {

            // Escribimos en SCED
            this._servidor.OrbitaEscribir(dispositivo, new string[] { variable }, new object[] { valor });

        }

        /// <summary>
        /// Metodo para escribir en el SCED
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <param name="valor">Valor a escribir</param>
        public void EscribirSCED(int dispositivo, string[] variables, object[] valores)
        {

            // Escribimos en SCED
            for (int i = 0; i < variables.Length; i++)
            {
                //Core.EscribeLog(Orbita.Trazabilidad.NivelLog.Info, "ESCRIBIR Variable:" + variables[i] + " Valor:" + valores[i].ToString() + " Dispositivo: " + dispositivo);
                this.EscribirSCED(dispositivo, variables[i], valores[i]);
            }

        }

        /// <summary>
        /// Metodo para leer en el SCED
        /// </summary>
        /// <param name="dispositivo">ID de dispositivo</param>
        /// <param name="variable">Nombre de la variable</param>
        /// <returns>Valor leido</returns>
        public object LeerSCED(int dispositivo, string variable)
        {
            // Leemos del SCED
            return this._servidor.OrbitaLeer(dispositivo, new string[] { variable.ToString() }, true)[0];
        }



        /// <summary>
        /// Obtiene las variables del SCED
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable Variables(int dispositivo)
        {
            return this._servidor.OrbitaGetDatos(dispositivo);
        }

        /// <summary>
        /// Obtiene las alarmas del SCED
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns></returns>
        public OHashtable Alarmas(int dispositivo)
        {
            return this._servidor.OrbitaGetAlarmas(dispositivo);
        }

        /// <summary>
        /// Obtiene los dispositivos del SCED
        /// </summary>
        /// <returns></returns>
        public int[] Dispositivos()
        {
            return this._servidor.OrbitaGetDispositivos();
        }
        #endregion
    }
}