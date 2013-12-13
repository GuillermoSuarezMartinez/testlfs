using System.ComponentModel;
namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSTextBox
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSTextBox
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        public class ControlNuevaDefinicionComunicaciones : OGSComunicaciones
        {
            public ControlNuevaDefinicionComunicaciones(OGSTextBox sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSTextBox
        /// </summary>
        OrbitaGSTextBox control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        ControlNuevaDefinicionComunicaciones definicionComunicaciones;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSTextBox
        /// </summary>
        /// <param name="control"></param>
        public OGSTextBox(object control)
            : base()
        {
            this.control = (OrbitaGSTextBox)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSTextBox
        /// </summary>
        internal OrbitaGSTextBox Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicaciones Comunicaciones
        {
            get { return this.definicionComunicaciones; }
            set { this.definicionComunicaciones = value; }
        }

        public string Text
        {
            get
            {
                return this.control.txtEventosComs.Text;
            }
            set
            {
                this.control.txtEventosComs.Text = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el AutoScrollBar del texto del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        [System.ComponentModel.Description("")]
        [DefaultValue (false)]
        public bool Multiline
        {
            get { return this.control.txtEventosComs.Multiline; }
            set { this.control.txtEventosComs.Multiline = value; }
        }

        /// <summary>
        /// Obtiene o establece el AutoScrollBar del texto del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        [System.ComponentModel.Description("")]
        [DefaultValue (true)]
        public bool AutoScrollBar
        {
            get { return this.control.txtEventosComs.OI.AutoScrollBar; }
            set { this.control.txtEventosComs.OI.AutoScrollBar = value; }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Sobreescribe el método ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return null;
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionComunicaciones == null)
            {
                this.definicionComunicaciones = new ControlNuevaDefinicionComunicaciones(this);
            }
        }
        #endregion
    }
}
