using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Utiles;

namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaClienteComsMultidispositivo : UserControl
    {
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

        internal delegate int DelegadoInt();
        #endregion

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
        /// Identificador de dispositivo
        /// </summary>
        internal int _idDispositivo = 1;
        /// <summary>
        /// Servidor remoting
        /// </summary>
        internal string _servidorRemoting = "localhost";
        /// <summary>
        /// <summary>
        /// Wrapper de comunicaciones
        /// </summary>
        OBroadcastEventWrapper _eventWrapper;
        #endregion

        public OrbitaClienteComsMultidispositivo()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Arranca las comunicaciones con el dispositivo
        /// </summary>
        public virtual void Iniciar()
        {
            try
            {
                this._remotingPuerto = Convert.ToInt32(this.txtPuertoRemoting.Text);
                this._servidorRemoting = this.txtServidorRemoting.Text;
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error al convertir los valores de configuración.", ex);
            }
            try
            {
                // Establecer la configuración Remoting entre procesos.
                ORemoting.InicConfiguracionCliente(this._remotingPuerto, this._servidorRemoting);
                this._servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));

                string err = "";
                this.ConectarWrapper(out err);
                if (err.Length > 0)
                {
                    OMensajes.MostrarInfo(err);
                }
                else
                {
                    OMensajes.MostrarInfo("Servidor conectado");
                    //this.IniciarHiloEstadoCanal();
                }

                this.cmbDispositivo.Items.Clear();
                int[] disp = this._servidor.OrbitaGetDispositivos();

                for (int i = 0; i < disp.Length; i++)
                {
                    this.cmbDispositivo.Items.Add(disp[i].ToString());
                }
                this.cmbDispositivo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
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
                error = "";
                //OMensajes.MostrarInfo("Servidor conectado");
                this.cmbDispositivo.Items.Clear();
                int[] disp = this._servidor.OrbitaGetDispositivos();

                for (int i = 0; i < disp.Length; i++)
                {
                    this.cmbDispositivo.Items.Add(disp[i].ToString());
                }
                this.cmbDispositivo.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                //OMensajes.MostrarError("Error al conectar.", ex);
                error = "Error al conectar." + ex.ToString();
            }
        }
        /// <summary>
        /// Conectar al servidor vía Remoting.
        /// </summary>
        /// <param name="estado">Estado de conexión.</param>
        void Conectar(bool estado)
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            string canal = "canal" + strHostName + ":" + this._remotingPuerto.ToString();
            this._servidor.OrbitaConectar(canal, estado);
        }
        /// <summary>
        /// Desconectar del servidor vía Remoting.
        /// </summary>
        public void DesconectarWrapper(out string error)
        {
            try
            {
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

                if (this.checkBoxDispositivo.Checked)
                {
                    lock (this)
                    {
                        DelegadoInt delegado = new DelegadoInt(this.getIdDisp);
                        int disp = (int)this.Invoke(delegado);

                        if (estado.Id == disp)
                        {
                            this.agregarItemComs("Coms id " + estado.Id.ToString() + " " + estado.Estado);
                        }
                    }
                    
                }
                else
                {
                    this.agregarItemComs("Coms id " + estado.Id.ToString() + " " + estado.Estado);
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// Procesa la información para el cambio de estado por pantalla
        /// </summary>
        /// <param name="estado"></param>
        public virtual void cambiarEstado(OEstadoComms estado)
        {
            int idDispositivo = 0;
            try
            {
                idDispositivo = Convert.ToInt32(this.cmbDispositivo.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (estado.Estado == "OK")
            {
                if (estado.Id == idDispositivo)
                {
                    this.txtCom.BackColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                if (estado.Id == idDispositivo)
                {
                    this.txtCom.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        /// <summary>
        /// Agrega los items a la lista
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
        /// Obtener identificador del dipositivo
        /// </summary>
        /// <param name="texto"></param>
        private int getIdDisp()
        {
            int ret = Convert.ToInt32(this.cmbDispositivo.Text);

            return ret;
        }
        /// <summary>
        /// Inicializa el grid de lecturas y escrituras
        /// </summary>
        private void configurarDataGridEscrituras()
        {
            DataTable dtc = new DataTable();

            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Variable";
            dtc.Columns.Add(column);

            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.Object");
            column2.ColumnName = "Valor";
            dtc.Columns.Add(column2);

            this.dataGridViewOrbita.DataSource = dtc;
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
                this.listViewComs.Items.Add(lvi);
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Carga del dispositivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrbitaClienteComsMultidispositivo_Load(object sender, EventArgs e)
        {
            this.configurarDataGridEscrituras();
        }
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e"></param>
        void eventWrapper_OrbitaCambioDato(OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;
                string texto = "Cambio de dato de la variable " + info.Texto.ToString() + " a " + info.Valor.ToString() + " del dispositivo " + info.Dispositivo.ToString();
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
                string texto = "Alarma " + info.Texto.ToString() + " pasa a valer " + info.Valor.ToString() + " del dispositivo " + info.Dispositivo;
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
                this.procesarComunicacionesServidor(e);
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
        }
        /// <summary>
        /// Inicia el cliente de comunicaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            this.Iniciar();
        }
        /// <summary>
        /// Lee una variable por OPC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLectura_Click(object sender, EventArgs e)
        {
            try
            {
                int idDispositivo = Convert.ToInt32(this.cmbDispositivo.Text);
                string[] lectura = new string[1];
                lectura[0] = this.txtVarLeer.Text;
                DateTime dtini = DateTime.Now;
                object[] valor = this._servidor.OrbitaLeer(idDispositivo, lectura, true);
                TimeSpan ts = DateTime.Now.Subtract(dtini);
                this.lblTpoLect.Text = ts.TotalMilliseconds.ToString() + " ms.";
                string svalor = valor[0].ToString();
                this.txtValLeer.Text = svalor;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// EScribe un valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscritura_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idDispositivo = Convert.ToInt32(this.cmbDispositivo.Text);
                string[] lectura = new string[1];
                lectura[0] = this.txtVarLeer.Text;
                object[] valor = new object[1];
                valor[0] = this.txtValLeer.Text;
                
                this._servidor.OrbitaEscribir(idDispositivo, lectura, valor);
               
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// Escribe una variable por OPC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscritura_Click(object sender, EventArgs e)
        {
            try
            {

                int idDispositivo = Convert.ToInt32(this.cmbDispositivo.Text);
                DataTable dt = (DataTable)this.dataGridViewOrbita.DataSource;

                string[] variable = new string[dt.Rows.Count];
                object[] valor = new object[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    variable[i] = dt.Rows[i][0].ToString();
                    valor[i] = dt.Rows[i][1];
                }
                DateTime dtini = DateTime.Now;

                bool resp = this._servidor.OrbitaEscribir(idDispositivo, variable, valor);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// Lee el valor de todas las variables del dispositivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerVariables_Click(object sender, EventArgs e)
        {
            try
            {
            int idDispositivo = Convert.ToInt32(this.cmbDispositivo.Text);

            OHashtable datos = this._servidor.OrbitaGetDatos(idDispositivo);
            string[] variables = new string[datos.Count];
            int i = 0;
            foreach (DictionaryEntry item in datos)
            {
                OInfoDato dato = (OInfoDato)item.Value;

                variables[i] = dato.Texto;
                i++;
            }

            object[] resultado = this._servidor.OrbitaLeer(idDispositivo, variables, true);

            DataTable dt = new DataTable();

            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Variable";
            dt.Columns.Add(column);

            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.ColumnName = "Valor";
            dt.Columns.Add(column2);

            for (int j = 0; j < variables.Length; j++)
            {
                DataRow dr = dt.NewRow();
                dr["Variable"] = variables[j];
                try
                {
                    dr["Valor"] = resultado[j];
                }
                catch (Exception)
                {
                    dr["Valor"] = "";
                }

                dt.Rows.Add(dr);
            }
            this.dataGridViewOrbita.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// Lee las alarmas activas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerAlarmas_Click(object sender, EventArgs e)
        {
            try
            {
            int idDispositivo = Convert.ToInt32(this.cmbDispositivo.Text);
            ArrayList alarmas = this._servidor.OrbitaGetAlarmasActivas(idDispositivo);
            string[] variables = new string[alarmas.Count];
            for (int i = 0; i < alarmas.Count; i++)
            {
                variables[i] = alarmas[i].ToString();
            }

            object[] resultado = this._servidor.OrbitaLeer(idDispositivo, variables, true);

            DataTable dt = new DataTable();

            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Variable";
            dt.Columns.Add(column);

            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.ColumnName = "Valor";
            dt.Columns.Add(column2);

            for (int j = 0; j < variables.Length; j++)
            {
                DataRow dr = dt.NewRow();
                dr["Variable"] = variables[j];
                try
                {
                    dr["Valor"] = resultado[j];
                }
                catch (Exception)
                {
                    dr["Valor"] = "";
                }

                dt.Rows.Add(dr);
            }

            this.dataGridViewOrbita.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// Reconecta el wrapper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReconectar_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                this.DesconectarWrapper(out err);
                if (err.Length > 0)
                {
                    this.MostrarMensajesComs(err);
                }
                this.Conectar(false);
                this.ConectarWrapper(out err);
                if (err.Length > 0)
                {
                    this.MostrarMensajesComs(err);
                }
                this.Conectar(true);
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError(ex);
            }
            
        }
        #endregion

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.listViewCDato.Items.Clear();
            this.listViewComs.Items.Clear();
        }
        
    }
}
