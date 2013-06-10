using System;
using System.ComponentModel;
using System.Management;
using System.Text;
using System.Windows.Forms;
namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Control para las lectoras de códigos
    /// </summary>
    public partial class OrbitaComponenteEscaner : Component, IEscaner
    {
        #region Campos
        /// <summary>
        /// Timer para leer los dígitos del código
        /// </summary>
        private Timer Timer;
        /// <summary>
        /// Concatena los dígitos del código
        /// </summary>
        private StringBuilder Concatenacion;
        /// <summary>
        /// Tiempo relativo en el que se ejecuta el timer
        /// </summary>
        private int _tiempoAdquisicion = 500;
        /// <summary>
        /// Longitud del código de barras
        /// </summary>
        private int _longitudCodigo = 20;
        /// <summary>
        /// Código de barras leído
        /// </summary>
        private string _codigo;
        #endregion

        #region Propiedades
        private string _dispositivoID;
        [Category("Orbita")]
        [Description("Identificador del dispositivo")]
        [Browsable(true), DisplayName("ODispositivoID")]
        [DefaultValue("")]
        public string DispositivoID
        {
            get
            {
                return this._dispositivoID;
            }
            set
            {
                this._dispositivoID = value;
            }
        }
        /// <summary>
        /// Resultado codigo de barras
        /// </summary>
        [Category("Orbita"),
        Description("Resultado codigo de barras.")]
        [Browsable(false), DisplayName("OCodigo")]
        public string Codigo
        {
            get { return _codigo; }
        }

        /// <summary>
        /// Tiempo pulsación
        /// </summary>
        [Category("Orbita"),
        Description("Tiempo pulsación."),
        DefaultValue(500)]
        [Browsable(true), DisplayName("OTiempoAdquisicion")]
        public int TiempoAdquisicion
        {
            get
            {
                return this._tiempoAdquisicion;
            }
            set
            {
                this._tiempoAdquisicion = value;
                Timer.Interval = this.TiempoAdquisicion;
            }
        }

        /// <summary>
        /// Longitud codigo de barras
        /// </summary>
        [Category("Orbita"),
        Description("Longitud codigo de barras."),
        DefaultValue(20)]
        [Browsable(true), DisplayName("OLongitudCodigo")]
        public int LongitudCodigo
        {
            get
            {
                return this._longitudCodigo;
            }
            set
            {
                this._longitudCodigo = value;
            }
        }
        [Category("Orbita"),
        Description("Resultado codigo de barras es válido."),
        DefaultValue(false)]
        [Browsable(false), DisplayName("OCodigoValido")]
        public bool CodigoValido
        {
            get
            {
                if (string.IsNullOrEmpty(this.Codigo))
                {
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase por defecto
        /// </summary>
        public OrbitaComponenteEscaner()
        {
            Concatenacion = new StringBuilder();

            Timer = new Timer();
            Timer.Tick += TimerTickHandler;
            Timer.Interval = this._tiempoAdquisicion;
            InitializeComponent();
        }
        /// <summary>
        /// constructor de la clase al que se le pasa el componente donde se leerá el código
        /// </summary>
        /// <param name="container"></param>
        public OrbitaComponenteEscaner(IContainer container)
        {
            Concatenacion = new StringBuilder();
            Timer = new Timer();
            Timer.Tick += TimerTickHandler;
            Timer.Interval = this._tiempoAdquisicion;

            container.Add(this);
            InitializeComponent();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Se ejecuta cuando obtiene un codigo de barras
        /// </summary>
        [Category("Orbita"),
        Description("Se ejecuta cuando obtiene un codigo de barras.")]
        public event NuevoCodigoEventHandler NuevoCodigo;
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Si pasa el tiempo definido en TimeRate anula el codigo;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimerTickHandler(object sender, EventArgs e)
        {
            Timer.Stop();
            Concatenacion = new StringBuilder();
        }
        /// <summary>
        /// éetodo para agregar un carácter
        /// </summary>
        /// <param name="caracter"></param>
        public void AgregarCaracter(char caracter)
        {
            Timer.Stop();
            switch (caracter)
            {
                case '\r':
                    // almaceno el codigo
                    this._codigo = Concatenacion.ToString();
                    Concatenacion = new StringBuilder();
                    // Lanzo el evento de captura de codigo
                    if (NuevoCodigo != null && this.CodigoValido)
                    {
                        //Core.Logger.Info("Codigo de barras:" + this.Codigo);
                        NuevoCodigo(this, this.Codigo);
                    }
                    break;
                default:
                    Concatenacion.Append(caracter);
                    Timer.Start();
                    break;
            }
        }

        /// <summary>
        /// método que comprueba la comunicación con el lector de códigos de barra
        /// </summary>
        /// <returns></returns>
        public bool CompruebaComunicacionLectorCodigoBarras()
        {
            bool resultado = true;
            ManagementObjectCollection collection;

            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_Keyboard where DeviceId  like '" + this.DispositivoID + "'"))
            {
                collection = searcher.Get();
                if (collection.Count == 0)
                {
                    resultado = false;
                }
            }
            return resultado;
        }
        #endregion
    }
}
