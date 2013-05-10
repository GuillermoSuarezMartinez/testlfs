using System.ComponentModel;
using System.Drawing;
namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSCheckBox
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSCheckBox
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSCheckBox
        /// </summary>
        public class ControlNuevaDefinicionComunicaciones : OGSComunicaciones
        {
            public ControlNuevaDefinicionComunicaciones(OGSCheckBox sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSCheckBox
        /// </summary>
        OrbitaGSCheckBox control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSCheckBox
        /// </summary>
        ControlNuevaDefinicionComunicaciones definicionComunicaciones;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSCheckBox
        /// </summary>
        /// <param name="control"></param>
        public OGSCheckBox(object control)
            : base()
        {
            this.control = (OrbitaGSCheckBox)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSCheckBox
        /// </summary>
        internal OrbitaGSCheckBox Control
        {
            get { return this.control; }
        }

        /// <summary>
        ///Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSCheckBox
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
                return this.control.chkEventosComs.Text;
            }
            set
            {
                this.control.chkEventosComs.Text = value;
            }
        }
        [DefaultValue (ContentAlignment.MiddleRight)]
        public ContentAlignment CheckAlign
        {
            get
            {
                return this.control.chkEventosComs.CheckAlign;
            }
            set
            {
                this.control.chkEventosComs.CheckAlign = value;
            }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSCheckBox
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
