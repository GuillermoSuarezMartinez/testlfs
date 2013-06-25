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
    public partial class FrmAutenticacion : System.Windows.Forms.Form
    {
        #region DLL Imports
        /// <summary>
        /// Esta función recupera el estado de la tecla virtual especificada.
        /// </summary>
        /// <param name="keyCode">Specifies a key code for the button to me checked</param>
        /// <returns>Return value will be 0 if off and 1 if on</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);
        #endregion

        #region Atributos
        private OLogon logon = null;
        #endregion

        #region Delegados y eventos
        private event System.EventHandler<AutenticacionResultEventArgs> dialogReturning;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.FrmValidar.
        /// </summary>
        public FrmAutenticacion()
        {
            InitializeComponent();
            //  Leer el estado actual de las keys especificadas.
            UpdateKeys();
            //InitializeAuthentication();
        }
        #endregion

        #region Métodos privados
        private void InitializeAuthentication()
        {
            try
            {
                Orbita.BBDD.OBBDDManager.LeerFicheroConfig(System.Windows.Forms.Application.StartupPath + @"\ConfiguracionBBDD.xml");
                App.COMS = (Orbita.BBDD.OSqlServer)Orbita.BBDD.OBBDDManager.GetBBDD("basedatosfw");
                System.Data.DataTable dt = AppBD.GetTipoAutenticacion();
                if (dt.Rows.Count > 0)
                {
                    TipoAutenticacion autenticacion = (TipoAutenticacion)System.Convert.ToInt32(dt.Rows[0]["FWA_ID_AUTENTICACION"], System.Globalization.CultureInfo.CurrentCulture);
                    string dominio = dt.Rows[0]["FWA_DOMINIO"].ToString();
                    switch (autenticacion)
                    {
                        case TipoAutenticacion.BBDD:
                            this.logon = new OLogonBBDD();
                            break;
                        case TipoAutenticacion.ActiveDirectory:
                            this.logon = new OLogonActiveDirectory();
                            break;
                        case TipoAutenticacion.Ninguna:
                        default:
                            break;
                    }
                    if (logon != null)
                    {
                        logon.dominio = dominio;
                        logon.usuario = this.txtUsuario.Text;
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                throw;
            }
            catch (System.IO.FileNotFoundException)
            {
                throw;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        private EstadoAutenticacion Validar()
        {
            EstadoAutenticacion estado = null;
            if (logon != null)
            {
                logon.password = this.txtContraseña.Text;
                estado = logon.Validar();
            }
            else
            {
                estado = new EstadoAutenticacionOK();
                //estado = new EstadoAutenticacionNOK("error");
            }
            return estado;
        }
        private void UpdateKeys()
        {
            UpdateCAPSLock();
        }
        private void UpdateCAPSLock()
        {
            bool capsLock = (GetKeyState((int)System.Windows.Forms.Keys.CapsLock)) != 0;
            this.lblMayusculasActivada.Visible = capsLock;
            this.Refresh();
        }
        private void Aceptar()
        {
            //  Obtener o establecer el resultado de cuadro de diálogo para el formulario.
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            //  Cerrar el formulario si la autenticación es correcta.
            this.Close();
        }
        private void Cancelar()
        {
            //  Obtener o establecer el resultado de cuadro de diálogo para el formulario.
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //  Cerrar el formulario.
            this.Close();
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Mostrar la ventana de dialogo como hijo de un formulario MDI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dialogReturnedValue">Manejador de evento de retorno.</param>
        public void ShowChildDialog(System.Windows.Forms.Form sender, System.EventHandler<AutenticacionResultEventArgs> dialogReturnedValue)
        {
            this.MdiParent = sender;

            dialogReturning += dialogReturnedValue;
            this.Show();
            this.Refresh();
        }
        #endregion

        #region Manejadores de eventos
        private void txtUsuario_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Return || e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                //  Obtener el valor que indica si el control puede recibir el foco.
                if (this.txtContraseña.CanFocus)
                {
                    //  Establecer el foco de entrada en el control txtContraseña de tipo System.Windows.Forms.TextBox.
                    this.txtContraseña.Focus();
                }
            }
        }
        private void txtContraseña_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Return || e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                Aceptar();
            }
        }
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            Aceptar();
        }
        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Cancelar();
        }
        private void FrmValidar_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //  Validar autenticación en función de las credenciales proporcionadas.
                    EstadoAutenticacion estado = this.Validar();
                    if (estado.Resultado == ResultadoAutenticacion.OK)
                    {
                        //  Ocultar el formulario de autenticación para continuar con el proceso asíncrono.
                        this.Hide();
                    }
                    else if (estado.Resultado == ResultadoAutenticacion.NOK)
                    {
                        //  Cancelar evento de cierre de formulario de autenticación.
                        e.Cancel = true;

                        //  Inicializar resultado del dialogo en procesos de autenticación incorrecta.
                        this.DialogResult = System.Windows.Forms.DialogResult.None;

                        //  Mostrar en pantalla el error concreto al usuario.
                        this.lblCredencialesIncorrectas.Text = estado.Mensaje;
                        this.lblCredencialesIncorrectas.Visible = true;
                        this.lblCredencialesIncorrectas.Refresh();
                    }
                }
            }
            finally
            {
            }
        }
        private void FrmValidar_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            AutenticacionResultEventArgs args = new AutenticacionResultEventArgs(this.DialogResult);
            args.Usuario = "pp";
            if (logon != null)
            {
                args.Usuario = logon.usuario;
            }
            DialogReturned(sender, args);
        }
        private void FrmValidar_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.CapsLock)
            {
                UpdateCAPSLock();
            }
        }
        /// <summary>
        /// Manejador de evento de retorno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DialogReturned(object sender, AutenticacionResultEventArgs e)
        {
            if (this.dialogReturning != null)
            {
                this.dialogReturning(sender, e);
            }
        }
        #endregion
    }
}