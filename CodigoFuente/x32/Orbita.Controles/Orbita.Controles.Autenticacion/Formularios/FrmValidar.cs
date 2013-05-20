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
using System.Data;
using System.Windows.Forms;
using Orbita.BBDD;
using Orbita.Utiles;
using System.Runtime.InteropServices;
using System.Drawing;
namespace Orbita.Controles.Autenticacion
{
    /// <summary>
    /// Formulario de autenticación.
    /// </summary>
    public partial class FrmValidar : Form
    {
        #region DLL Imports

        /// <summary>
        /// This function retrieves the status of the specified virtual key.
        /// The status specifies whether the key is up, down.
        /// </summary>
        /// <param name="keyCode">Specifies a key code for the button to me checked</param>
        /// <returns>Return value will be 0 if off and 1 if on</returns>
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);
        #endregion

        #region Atributos
        /// <summary>
        /// Tipo de validación a realizar
        /// </summary>
        TipoAutenticacion validacion;
        /// <summary>
        /// Servidor donde se realiza la validación
        /// </summary>
        string dominio;
        #endregion

        #region Delegados y eventos
        /// <summary>
        /// Delegado para el evento de validación.
        /// </summary>
        /// <param name="sender">Objecto de la clase actual.</param>
        /// <param name="e">Mensaje de validación de argumento Orbita.Controles.Autenticacion.OEstadoValidacion.</param>
        public delegate void ODelegadoValidacion(object sender, AutenticacionChangedEventArgs e);
        /// <summary>
        /// Evento para la validación.
        /// </summary>
        public event ODelegadoValidacion OValidacionControl;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Autenticacion.FrmValidar.
        /// </summary>
        /// <param name="parent"></param>
        public FrmValidar(Form parent)
        {
            InitializeComponent();
            MdiParent = parent;
            // Leer el estado actual de las keys especificadas.
            UpdateKeys();
            InitializeAuthentication();
        }
        #endregion

        #region Métodos privados
        void InitializeAuthentication()
        {
            OBBDDManager.LeerFicheroConfig(Application.StartupPath + @"\ConfiguracionBBDD.xml");
            App.COMS = (OSqlServer)OBBDDManager.GetBBDD("basedatosfw");
            this.validacion = TipoAutenticacion.Ninguna;
            DataTable dt = AppBD.Get_Tipo_Autenticacion();
            if (dt.Rows.Count > 0)
            {
                this.validacion = (TipoAutenticacion)System.Convert.ToInt32(dt.Rows[0]["FWA_ID_AUTENTICACION"]);
                this.dominio = dt.Rows[0]["FWA_DOMINIO"].ToString();
            }
        }
        void Validar()
        {
            OLogon logon = null;
            AutenticacionChangedEventArgs args = null;
            switch (this.validacion)
            {
                case TipoAutenticacion.BBDD:
                    logon = new OLogonBBDD();
                    break;
                case TipoAutenticacion.ActiveDirectory:
                    logon = new OLogonAD();
                    break;
                case TipoAutenticacion.Ninguna:
                default:
                    break;
            }
            if (logon != null)
            {
                logon.dominio = this.dominio;
                logon.usuario = this.txtUsuario.Text;
                logon.password = this.txtPassword.Text;
                args = logon.Validar();
            }
            else
            {
                OEstadoValidacion validar = new OEstadoValidacion("NOK", "No hay establecido un método de autenticación", "Aceptar");
                args = new AutenticacionChangedEventArgs(validar);
            }
            this.OValidacionControl(this, args);
        }
        private void UpdateKeys()
        {
            UpdateCAPSLock();
        }
        void UpdateCAPSLock()
        {
            bool CapsLock = (GetKeyState((int)Keys.CapsLock)) != 0;
            this.lblMayusculasActivada.Visible = CapsLock;

            this.Refresh();
        }
        #endregion

        #region Manejadores de eventos
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Validar();
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            try
            {
                OEstadoValidacion validar = new OEstadoValidacion("NOK", "No hay establecido un método de autenticación", "Cancelar");
                AutenticacionChangedEventArgs args = new AutenticacionChangedEventArgs(validar);
                this.OValidacionControl(this, args);
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
                {
                    this.Validar();
                }
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
                {
                    this.txtPassword.Focus();
                }
            }
            catch (System.Exception ex)
            {
                OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void FrmValidar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.CapsLock)
            {
                UpdateCAPSLock();
            }
        }
        #endregion

        private void FrmValidar_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}