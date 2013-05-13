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
using System;
using System.Data;
using System.Windows.Forms;
using Orbita.BBDD;
using Orbita.Utiles;
namespace Orbita.Controles.Autenticacion
{
    public partial class FrmValidar : Form
    {
        #region Atributos
        /// <summary>
        /// Tipos de validación.
        /// </summary>
        public enum Validaciones
        {
            Ninguna = 0,
            BBDD = 1,
            ActiveDirectory = 2,
            OpenLDAP = 3
        }
        /// <summary>
        /// Tipo de validación a realizar
        /// </summary>
        Validaciones validacion;
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
        /// <param name="args">Mensaje de validación de argumento Orbita.Controles.Autenticacion.OEstadoValidacion.</param>
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
            //InitializeAuthentication();
        }
        #endregion

        #region Métodos privados
        void InitializeAuthentication()
        {
            OBBDDManager.LeerFicheroConfig(Application.StartupPath + @"\ConfiguracionBBDD.xml");
            App.COMS = (OSqlServer)OBBDDManager.GetBBDD("basedatosfw");
            this.validacion = Validaciones.Ninguna;
            DataTable dt = AppBD.Get_Tipo_Autenticacion();
            if (dt.Rows.Count > 0)
            {
                this.validacion = (Validaciones)Convert.ToInt32(dt.Rows[0]["FWA_ID_AUTENTICACION"]);
                this.dominio = dt.Rows[0]["FWA_DOMINIO"].ToString();
            }
        }
        void Validar()
        {
            OLogon logon = null;
            AutenticacionChangedEventArgs args = null;
            switch (this.validacion)
            {
                case Validaciones.BBDD:
                    logon = new OLogonBBDD();
                    break;
                case Validaciones.ActiveDirectory:
                    logon = new OLogonAD();
                    break;
                case Validaciones.Ninguna:
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
        #endregion

        #region Manejadores de eventos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validar();
            }
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OEstadoValidacion validar = new OEstadoValidacion("NOK", "No hay establecido un método de autenticación", "Cancelar");
                AutenticacionChangedEventArgs args = new AutenticacionChangedEventArgs(validar);
                this.OValidacionControl(this, args);
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                OMensajes.MostrarError("Error no controlado " + ex.ToString());
            }
        }
        #endregion
    }
}