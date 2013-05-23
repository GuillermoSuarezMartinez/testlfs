using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Utiles;
using System.Threading;


namespace Orbita.Controles.Comunicaciones.Custom.Remoting
{
    public partial class OrbitaClienteEventoComs : UserControl
    {
        #region Atributos
        /// <summary>
        /// Puerto de comunicación de remoting
        /// </summary>
        internal int _remotingPuerto = 1852;
        /// <summary>
        /// Servidor de comunicaciones.
        /// </summary>
        internal IOCommRemoting _servidor;
        /// <summary>
        /// Servidor remoting
        /// </summary>
        internal string _servidorRemoting = "localhost";
        /// <summary>
        /// <summary>
        /// Wrapper de comunicaciones
        /// </summary>
        OBroadcastEventWrapper eventWrapper;
        /// <summary>
        /// Hilos de estado
        /// </summary>
        private OHilos HilosEstado;
        /// <summary>
        /// Fecha de recepción del evento de comunicaciones
        /// </summary>
        private DateTime _fechaEventoComs;
        /// <summary>
        /// Segundos que esperamos para la reconexión
        /// </summary>
        private int _segundosReconexion = 10;
        /// <summary>
        /// Reintentos de reconexión
        /// </summary>
        private int _reintentosReconexion = 3;
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para mostar los datos en el formulario
        /// </summary>
        /// <param name="Elemento"></param>
        internal delegate void DelegadoAgregar(string Elemento);
        /// <summary>
        /// Delegado para el cambio de estado
        /// </summary>
        /// <param name="estado"></param>
        internal delegate void DelegadoCambioEstado(OEstadoComms estado);
        /// <summary>
        /// Delegado para el cambio de las ES
        /// </summary>
        /// <param name="estado"></param>
        internal delegate void DelegadoES(OEventArgs estado);
        #endregion

        public OrbitaClienteEventoComs()
        {
            InitializeComponent();
        }

        #region Eventos
        /// <summary>
        /// Conectamos con el servidor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            this.Iniciar();
            string err = "";
            this.ConectarWrapper(out err);
            if (err.Length>0)
            {
                OMensajes.MostrarInfo(err);
            }
            else
            {
                OMensajes.MostrarInfo("Servidor conectado");
            }
        }
        /// <summary>
        /// Borra los datos del listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.listViewCDato.Clear();
            this.listViewComunicaciones.Clear();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Inicio de la conexión de remoting
        /// </summary>
        private void Iniciar()
        {
            try
            {
                this._remotingPuerto = Convert.ToInt32(this.txtPuertoRemoting.Text);
                this._servidorRemoting = this.txtServidorRemoting.Text;
                this._fechaEventoComs = DateTime.Now;
                try
                {
                    // Establecer la configuración Remoting entre procesos.
                    ORemoting.InicConfiguracionCliente(this._remotingPuerto, this._servidorRemoting);
                    this._servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));
                    OMensajes.MostrarInfo("Objeto servidor Iniciado");
                }
                catch (Exception ex)
                {
                    OMensajes.MostrarError(ex);
                }
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error al convertir los valores de configuración.", ex);
            }

        }
        /// <summary>
        /// Conecta con el wrapper de remoting
        /// </summary>
        public void ConectarWrapper(out string error)
        {
            try
            {
                // Eventwrapper de comunicaciones.
                this.eventWrapper = new Orbita.Comunicaciones.OBroadcastEventWrapper();

                //Eventos locales.
                //...cambio de dato.
                this.eventWrapper.OrbitaCambioDato += new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                this.eventWrapper.OrbitaAlarma += new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                this.eventWrapper.OrbitaComm += new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato += new OManejadorEventoComm(eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma += new OManejadorEventoComm(eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm += new OManejadorEventoComm(eventWrapper.OnComm);

                // Establecer conexión con el servidor.
                Conectar(true);
                error = "";
                //OMensajes.MostrarInfo("Servidor conectado");
            }
            catch (Exception ex)
            {
                //OMensajes.MostrarError("Error al conectar.", ex);
                error = "Error al conectar." + ex.ToString();
            }
        }
        /// <summary>
        /// Desconectar del wrapper de remoting
        /// </summary>
        public void DesconectarWrapper(out string error)
        {
            try
            {
                //Eventos locales.
                //...cambio de dato.
                this.eventWrapper.OrbitaCambioDato -= new OManejadorEventoComm(eventWrapper_OrbitaCambioDato);
                // ...alarma
                this.eventWrapper.OrbitaAlarma -= new OManejadorEventoComm(eventWrapper_OrbitaAlarma);
                // ...comunicaciones.
                this.eventWrapper.OrbitaComm -= new OManejadorEventoComm(eventWrapper_OrbitaComm);

                // Eventos del servidor.
                // ...cambio de dato.
                this._servidor.OrbitaCambioDato -= new OManejadorEventoComm(eventWrapper.OnCambioDato);
                // ...alarma.
                this._servidor.OrbitaAlarma -= new OManejadorEventoComm(eventWrapper.OnAlarma);
                // ...comunicaciones.
                this._servidor.OrbitaComm -= new OManejadorEventoComm(eventWrapper.OnComm);

                Conectar(false);
                error = "";
            }
            catch (Exception ex)
            {
                //OMensajes.MostrarError("Error al Desconectar.", ex);
                error = "Error al conectar." + ex.ToString();
            }
        }
        /// <summary>
        /// Conectar al servidor vía Remoting.
        /// </summary>
        /// <param name="estado">Estado de conexión.</param>
        private void Conectar(bool estado)
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            string canal = "canal" + strHostName + ":" + this._remotingPuerto.ToString();
            this._servidor.OrbitaConectar(canal, estado);
        }
        #region Hilo Control Canal

        /// <summary>
        /// Iniciamos el hilo del estado del canal
        /// </summary>
        private void IniciarHiloEstadoCanal()
        {
            HilosEstado = new OHilos();
            HilosEstado.OnDespuesAdicionar += new ManejadorEvento(hilos_OnDespuesAdicionar);
            OHilo hiloEsado = HilosEstado.Add(new ThreadStart(GestionEstados), true);
        }
        /// <summary>
        /// Arranca el hilo de lectura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void hilos_OnDespuesAdicionar(object sender, OEventArgs e)
        {
            OHilo hilo = sender as OHilo;

            if (hilo != null)
            {
                hilo.OnDespuesAccion += new ManejadorEvento(hilo_OnDespuesAccion);
                if (hilo.Iniciarlo)
                {
                    hilo.Iniciar();
                }
            }
        }
        /// <summary>
        /// Traza el hilo de lectura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void hilo_OnDespuesAccion(object sender, OEventArgs e)
        {
            //traza hilo
        }
        /// <summary>
        /// Proceso para la gestión de estados del componente
        /// </summary>
        private void GestionEstados()
        {
            int reintentos = 0;
            OEventArgs arg = new OEventArgs();
            DateTime fechaUltimaRecepcion = DateTime.Now;
            string err = "";

            while (true)
            {
                TimeSpan ts = DateTime.Now.Subtract(this._fechaEventoComs);

                if (ts.Seconds > this._segundosReconexion)
                {
                    if (reintentos > _reintentosReconexion)
                    {
                        this.agregarItemComs("Desconectando el canal");
                        this.DesconectarWrapper(out err);
                        if (err.Length>0)
                        {
                            this.MostrarMensajesComs(err);
                        }
                        this.Conectar(false);
                        this.agregarItemComs("Conectando el canal");
                        this.ConectarWrapper(out err);
                        if (err.Length > 0)
                        {
                            this.MostrarMensajesComs(err);
                        }
                        this.Conectar(true);
                    }
                    else
                    {
                        reintentos++;
                    }
                }
                else
                {
                    reintentos = 0;
                }
                
                Thread.Sleep(100);
            }
        }

        #endregion
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
                OInfoDato info = (OInfoDato)e.Argumento;
                string texto = "Cambio de dato de la variable " + info.Texto.ToString() + " a " + info.Valor.ToString();
                this.agregarItemOrbita(texto);                
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
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
                OInfoDato info = (OInfoDato)e.Argumento;
                string texto = "Alarma " + info.Texto.ToString() + " pasa a valer " + info.Valor.ToString();
                this.agregarItemOrbita(texto);                
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
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
                this._fechaEventoComs = DateTime.Now;
                this.procesarComunicacionesServidor(e);
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Agrega Item a la colección
        /// </summary>
        /// <param name="texto"></param>
        private void agregarItemOrbita(string texto)
        {
            if (this.listViewCDato.InvokeRequired)
            {
                DelegadoAgregar Delegado = new DelegadoAgregar(agregarItemOrbita);
                this.Invoke(Delegado, new object[] { texto });
            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = texto;
                //lvi.ImageIndex = 0;
                lvi.Tag = texto;
                this.listViewCDato.Items.Add(lvi);
            }
        }
        /// <summary>
        /// Procesa la información del evento de comunicaciones
        /// </summary>
        /// <param name="e"></param>
        private void procesarComunicacionesServidor(OEventArgs e)
        {
            try
            {
                OEstadoComms estado = (OEstadoComms)e.Argumento;
                DelegadoCambioEstado MyDelegado = new DelegadoCambioEstado(cambiarEstado);
                this.Invoke(MyDelegado, new object[] { estado });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// Agrega Item a la colección
        /// </summary>
        /// <param name="texto"></param>
        private void agregarItemComs(string texto)
        {
            if (this.listViewCDato.InvokeRequired)
            {
                DelegadoAgregar Delegado = new DelegadoAgregar(agregarItemComs);
                this.Invoke(Delegado, new object[] { texto });
            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = texto;
                //lvi.ImageIndex = 0;
                lvi.Tag = texto;
                this.listViewComunicaciones.Items.Add(lvi);
            }
        }
        /// <summary>
        /// Procesa la información para el cambio de estado por pantalla
        /// </summary>
        /// <param name="estado"></param>
        public virtual void cambiarEstado(OEstadoComms estado)
        {
            if (estado.Estado == "OK")
            {
                this.agregarItemComs("Recibido OK del dispositivo " + estado.Id.ToString());
            }
            else
            {
                this.agregarItemComs("Recibido NOK del dispositivo " + estado.Id.ToString());
            }
        }
        /// <summary>
        /// Agrega Item a la colección
        /// </summary>
        /// <param name="texto"></param>
        private void MostrarMensajesComs(string texto)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)delegate { MessageBox.Show(this, texto); });
            }
        }

        #endregion
    }
}
