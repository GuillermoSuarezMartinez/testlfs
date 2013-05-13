//***********************************************************************
// Assembly         : Orbita.Framework
// Author           : crodriguez
// Created          : 18-04-2013
//
// Last Modified By : crodriguez
// Last Modified On : 18-04-2013
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
namespace Orbita.Framework
{
    [System.CLSCompliantAttribute(false)]
    public partial class Base : Orbita.Controles.Contenedores.OrbitaMdiContainerForm
    {
        #region Atributos
        /// <summary>
        /// Configurador de Framework.
        /// </summary>
        Core.IFormConfigurador configurador;
        /// <summary>
        /// Control Core.PluginOMenuStrip.
        /// </summary>
        Core.PluginOMenuStrip menu = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Framework.Base.
        /// </summary>
        public Base()
            : base()
        {
            // Inicializar componentes.
            InitializeComponent();
            // Inicializar atributos.
            InitializeAttributes();
        }
        #endregion

        #region Propiedades
        public Core.IFormConfigurador Configurador
        {
            get { return this.configurador; }
            set { this.configurador = value; }
        }
        protected Core.PluginOMenuStrip Menu
        {
            get { return this.menu; }
            set { this.menu = value; }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar atributos.
        /// </summary>
        void InitializeAttributes()
        {
            if (this.configurador == null)
            {
                this.configurador = new Core.Configurador();
                this.configurador.EstadoVentana = Configuracion.DefectoEstadoVentanta;
                this.configurador.EstiloBorde = Configuracion.DefectoEstiloBorde;
                this.configurador.MostrarMenu = Configuracion.DefectoMostrarMenu;
                this.configurador.NumeroMaximoFormulariosAbiertos = Configuracion.DefectoNumeroMaximoFormulariosAbiertos;
                this.configurador.Autenticación = Configuracion.DefectoAutenticación;
                this.configurador.Idioma = Configuracion.DefectoIdioma;
            }
        }
        #endregion

        /// <summary>
        /// Inicializar menu.
        /// </summary>
        protected void InicializeMenu()
        {
            if (this.configurador.MostrarMenu)
            {
                if (!this.Controls.Contains(menu))
                {
                    menu = new Core.PluginOMenuStrip();
                    menu.Name = "MainMenu";
                    this.SuspendLayout();
                    this.Controls.Add(menu);
                    this.MainMenuStrip = menu;
                    this.Controls.SetChildIndex(menu, 0);
                    this.ResumeLayout(false);
                    this.PerformLayout();
                }
            }
        }
        protected void LoadConfiguration()
        {
            try
            {
                Core.IFormConfigurador configurador;
                Core.Persistencia persistencia = Core.PluginHelper.Persistencia;
                if (persistencia != null)
                {
                    configurador = persistencia.GetConfiguracion();
                    this.configurador.Titulo = configurador.Titulo;
                    this.configurador.EstadoVentana = configurador.EstadoVentana;
                }
                //// Leer la configuración del Framework de base de datos.
                //System.Data.DataTable dt = DatosHelper.GetConfiguracion();
                //if (dt.Rows.Count == 1)
                //{
                //    // Asignar los valores leidos de base de datos.
                //    bool.TryParse(dt.Rows[0]["MostrarMenu"].ToString(), out mostrarMenu);
                //    int.TryParse(dt.Rows[0]["NumeroMaximoFormsAbiertos"].ToString(), out numeroMaximoFormulariosAbiertos);
                //    bool.TryParse(dt.Rows[0]["Autenticacion"].ToString(), out autenticación);
                //    plugin = dt.Rows[0]["Plugin"].ToString();
                //    int.TryParse(dt.Rows[0]["Idioma"].ToString(), out idioma);
                //}
            }
            catch
            { } // Empty.
            finally
            {
                this.Text = this.configurador.Titulo;
                this.FormBorderStyle = this.configurador.EstiloBorde;
                this.WindowState = (System.Windows.Forms.FormWindowState)this.configurador.EstadoVentana;
            }
        }
    }
}