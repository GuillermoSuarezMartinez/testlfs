//***********************************************************************
// Assembly         : Orbita.Controles.Autenticacion
// Author           : jljuan
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Formulario de autenticación.
    /// </summary>
    public partial class FrmValidar : System.Windows.Forms.Form
    {
        #region DLL Imports
        /// <summary>
        /// This function retrieves the status of the specified virtual key.
        /// The status specifies whether the key is up, down.
        /// </summary>
        /// <param name="keyCode">Specifies a key code for the button to me checked</param>
        /// <returns>Return value will be 0 if off and 1 if on</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);
        #endregion

        #region Atributos
        /// <summary>
        /// Tipo de autenticación a realizar.
        /// </summary>
        TipoAutenticacion autenticacion;
        /// <summary>
        /// Servidor donde se realiza la autenticación.
        /// </summary>
        string dominio;
        #endregion

        #region Delegados y eventos
        /// <summary>
        /// Evento para la validación.
        /// </summary>
        public event System.EventHandler<AutenticacionChangedEventArgs> ControlAutenticacion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.FrmValidar.
        /// </summary>
        public FrmValidar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.FrmValidar.
        /// </summary>
        /// <param name="parent"></param>
        public FrmValidar(System.Windows.Forms.Form parent)
            : this()
        {
            // Asignar el contenedor a la propiedad de MdiParent.
            // MdiParent = parent;
            // Leer el estado actual de las keys especificadas.
            UpdateKeys();
            //InitializeAuthentication();
        }
        #endregion

        #region Métodos privados
        void InitializeAuthentication()
        {
            Orbita.BBDD.OBBDDManager.LeerFicheroConfig(System.Windows.Forms.Application.StartupPath + @"\ConfiguracionBBDD.xml");
            App.COMS = (Orbita.BBDD.OSqlServer)Orbita.BBDD.OBBDDManager.GetBBDD("basedatosfw");
            this.autenticacion = TipoAutenticacion.Ninguna;
            System.Data.DataTable dt = AppBD.Get_Tipo_Autenticacion();
            if (dt.Rows.Count > 0)
            {
                this.autenticacion = (TipoAutenticacion)System.Convert.ToInt32(dt.Rows[0]["FWA_ID_AUTENTICACION"], System.Globalization.CultureInfo.CurrentCulture);
                this.dominio = dt.Rows[0]["FWA_DOMINIO"].ToString();
            }
        }
        AutenticacionChangedEventArgs Validar()
        {
            OLogOn logon = null;
            AutenticacionChangedEventArgs args = null;
            switch (this.autenticacion)
            {
                case TipoAutenticacion.BBDD:
                    logon = new OLogOnBBDD();
                    break;
                case TipoAutenticacion.ActiveDirectory:
                    logon = new OLogOnActiveDirectory();
                    break;
                case TipoAutenticacion.Ninguna:
                default:
                    break;
            }
            if (logon != null)
            {
                logon.dominio = this.dominio;
                logon.usuario = this.txtUsuario.Text;
                logon.password = this.txtContraseña.Text;
                args = logon.Validar();
            }
            else
            {
                //EstadoAutenticacion estado = new EstadoAutenticacionNOK(MensajesAutenticacion.SinAutenticacion);
                EstadoAutenticacion estado = new EstadoAutenticacionOK();
                args = new AutenticacionChangedEventArgs(estado);
            }
            //this.OnControlAutenticacion(this, args);
            return args;
        }
        void UpdateKeys()
        {
            UpdateCAPSLock();
        }
        void UpdateCAPSLock()
        {
            bool capsLock = (GetKeyState((int)System.Windows.Forms.Keys.CapsLock)) != 0;
            this.lblMayusculasActivada.Visible = capsLock;
            this.Refresh();
        }
        #endregion

        #region Manejadores de eventos
        private void txtUsuario_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)System.Windows.Forms.Keys.Return || e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
                {
                    this.txtContraseña.Focus();
                }
            }
            catch (System.Exception ex)
            {
                Orbita.Utiles.OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void txtContraseña_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)System.Windows.Forms.Keys.Return || e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
                {
                    AutenticacionChangedEventArgs result = this.Validar();
                    if (result.Resultado == ResultadoAutenticacion.OK)
                    {
                        this.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Orbita.Utiles.OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                AutenticacionChangedEventArgs result = this.Validar();
                if (result.Resultado == ResultadoAutenticacion.OK)
                {
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                Orbita.Utiles.OMensajes.MostrarError("Error no controlado: " + ex.ToString());
            }
            finally
            {
            }
        }
        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void FrmValidar_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                // ...en el caso que Windows esté intentando cerrar.
                // ...la pulsación de la tecla Alt+F4.
                //if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown ||
                //    e.CloseReason == System.Windows.Forms.CloseReason.MdiFormClosing)
                //{
                //    return;
                //}
                //if (this.DialogResult == System.Windows.Forms.DialogResult.Cancel ||
                //    this.DialogResult == System.Windows.Forms.DialogResult.None)
                //{
                //    EstadoAutenticacion estado = new EstadoAutenticacionNOK();
                //    this.OnControlAutenticacion(this, new AutenticacionChangedEventArgs(estado));
                //}
            }
            catch (System.Exception ex)
            {
                Orbita.Utiles.OMensajes.MostrarError("Error no controlado: " + ex.ToString());
            }
        }
        private void FrmValidar_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == System.Windows.Forms.Keys.CapsLock)
                {
                    UpdateCAPSLock();
                }
            }
            catch (System.Exception ex)
            {
                Orbita.Utiles.OMensajes.MostrarError("Error no controlado: " + ex.ToString());
            }
        }
        protected void OnControlAutenticacion(object sender, AutenticacionChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.Resultado == ResultadoAutenticacion.NOK && e.BotónPulsado == BotonesAutenticacion.Aceptar)
                {
                    this.lblCredencialesIncorrectas.Text = e.Mensaje;
                    this.lblCredencialesIncorrectas.Visible = true;
                    return;
                }
                if (this.ControlAutenticacion != null)
                {
                    this.ControlAutenticacion(this, e);
                    if (e.Resultado == ResultadoAutenticacion.OK)
                    {
                        this.Close();
                    }
                }
            }
        }
        #endregion

        private void FrmValidar_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}