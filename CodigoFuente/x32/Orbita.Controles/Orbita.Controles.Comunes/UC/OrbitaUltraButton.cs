namespace Orbita.Controles.Comunes
{
    /// <summary>
    /// Orbita.Controles.Comunes.OrbitaUltraButton.
    /// </summary>
    public partial class OrbitaUltraButton : Infragistics.Win.Misc.UltraButton
    {
        #region Atributos
        /// <summary>
        /// Tipo de botón.
        /// </summary>
        Orbita.Controles.Shared.TipoBoton tipo;
        /// <summary>
        /// Proporciona un acceso a los recursos específicos de cada referencia cultural en tiempo de ejecución.
        /// </summary>
        System.Resources.ResourceManager stringManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase Orbita.Controles.Comunes.OrbitaUltraButton.
        /// </summary>
        public OrbitaUltraButton()
            : base()
        {
            InitializeComponent();
            InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Tipo de botón.
        /// </summary>
        [System.ComponentModel.Category("Orbita")]
        [System.ComponentModel.Description("Tipo de botón.")]
        [System.ComponentModel.DefaultValue(typeof(Orbita.Controles.Shared.TipoBoton), "Normal")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Orbita.Controles.Shared.TipoBoton OrbTipo
        {
            get { return this.tipo; }
            set
            {
                this.ImageSize = new System.Drawing.Size(20, 20);
                this.Size = new System.Drawing.Size(98, 26);
                this.tipo = value;
                switch (this.tipo)
                {
                    case Orbita.Controles.Shared.TipoBoton.Aceptar:
                        this.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnAceptarEstandar24;
                        this.Text = stringManager.GetString("Aceptar", System.Globalization.CultureInfo.CurrentUICulture);
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Cancelar:
                        this.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnCerrarEstandar24;
                        this.Text = stringManager.GetString("Cancelar", System.Globalization.CultureInfo.CurrentUICulture);
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Cerrar:
                        this.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnCerrarEstandar24;
                        this.Text = stringManager.GetString("Cerrar", System.Globalization.CultureInfo.CurrentUICulture);
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Guardar:
                        this.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnGuardarEstandar24;
                        this.Text = stringManager.GetString("Guardar", System.Globalization.CultureInfo.CurrentUICulture); ;
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Descartar:
                        this.Appearance.Image = Orbita.Controles.Comunes.Properties.Resources.btnDescartarEstandar24;
                        this.Text = stringManager.GetString("Descartar", System.Globalization.CultureInfo.CurrentUICulture); ;
                        break;
                    case Orbita.Controles.Shared.TipoBoton.Normal:
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializar atributos.
        /// </summary>
        void InitializeAttributes()
        {
            this.stringManager = new System.Resources.ResourceManager("es-ES", System.Reflection.Assembly.GetExecutingAssembly());
        }
        #endregion
    }
}
