//***********************************************************************
// Assembly         : Orbita.Controles.VA
// Author           : aibañez
// Created          : 07-11-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Orbita.Controles.Contenedores;
using Orbita.VA.Comun;

namespace Orbita.Controles.VA
{
    /// <summary>
    /// Control que se muestra mientras se abre la aplicación
    /// </summary>
    public partial class OrbitaSplash : UserControl
    {
        #region Propiedad(es)
        /// <summary>
        /// Contendrá el mensaje a actualizar en el formulario
        /// </summary>
        public string Mensaje
        {
            get { return this.lblMensaje.Text; }
            set
            {
                this.lblMensaje.Text = value;
                Application.DoEvents();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="parent">Formulario padre</param>
        /// <param name="milisegundos">Tiempo de refresco en milisegundos</param>
        /// <param name="inicial">Indica si se trata de la visualización inicial o de una recarga de parámetros</param>
        public OrbitaSplash()
        {
            InitializeComponent();
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Modifica los labels del formulario
        /// </summary>
        private void RealizarVisualizaciones()
        {
            if (this.Mensaje != string.Empty)
            {
                this.lblMensaje.Text = this.Mensaje;
                this.Mensaje = string.Empty;
                Application.DoEvents();
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Cierre del control de splash
        /// </summary>
        public void Cerrar()
        {
            //this.Visible = false; // Ocultamos.
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento de carga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSplash_Load(object sender, System.EventArgs e)
        {
            this.lblUsuario.Text = "Nombre del equipo: " + Environment.MachineName.ToString();
            this.lblMaquina.Text = "Nombre del usuario: " + Environment.UserName.ToString();
            this.lblIdioma.Text = "Idioma : " + Application.CurrentCulture.ToString();
            this.lblVersion.Text = "Versión " + OSistemaManager.Version(System.Reflection.Assembly.GetEntryAssembly());
            this.lblProducto.Text = "Producto: " + Application.ProductName;
            this.lblCompañia.Text = "Compañía: " + Application.CompanyName;
        }

        ///// <summary>
        ///// Evento que se ejecutan antes de cerrar el formulario. Se cancela el cierre por el usuario
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FrmSplash_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (OSplashManager.MostrandoSplash)
        //    {
        //        e.Cancel = true;
        //    }
        //}
        #endregion
    }

    /// <summary>
    /// Clase estática para el acceso al fomrulario de splash
    /// </summary>
    public static class OSplashManagerTactil
    {
        #region Atributo(s)
        /// <summary>
        /// Formulario splash
        /// </summary>
        private static OrbitaSplash Splash;

        /// <summary>
        /// Indica que el formulario de splash está mostrandose
        /// </summary>
        public static bool MostrandoSplash = false;
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Inicio del splash en otro hilo de ejecución
        /// </summary>
        private static void IniciarSplash()
        {
            try
            {
                Splash = new OrbitaSplash();
                Splash.Dock = DockStyle.Fill;
                App.FormularioPrincipal.Controls.Add(Splash);
                Splash.BringToFront();
                Splash.Visible = true;
                MostrandoSplash = true;
                Application.DoEvents();
            }
            catch
            {
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Constructor del splash
        /// </summary>
        public static void Contructor()
        {
            if (ODebug.IsWinForms())
            {
                // Deshabilito el formulario principal
                Application.UseWaitCursor = true;

                IniciarSplash();
            }
        }

        /// <summary>
        /// Destrucción del splash
        /// </summary>
        public static void Destructor()
        {
            if (ODebug.IsWinForms() && MostrandoSplash && App.FormularioPrincipal.Controls.Contains(Splash))
            {
                Splash.Cerrar();
                //Splash.Visible = false;
                App.FormularioPrincipal.Controls.Remove(Splash);
                Splash.Dispose();

                MostrandoSplash = false;

                // Habilito el formulario principal
                Application.UseWaitCursor = false;
            }
        }

        /// <summary>
        /// Visualización de un mensaje en el splash
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Mensaje(string mensaje)
        {
            if (ODebug.IsWinForms() && MostrandoSplash)
            {
                Splash.Mensaje = mensaje;
            }
        }
        #endregion
    }
}
