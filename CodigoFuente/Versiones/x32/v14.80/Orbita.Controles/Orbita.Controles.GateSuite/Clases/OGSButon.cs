using System.ComponentModel;
using Orbita.Controles.Comunes;
namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSButon
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSButon
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSButon
        /// </summary>
        public class ControlNuevaDefinicionComunicaciones : OGSComunicaciones
        {
            public ControlNuevaDefinicionComunicaciones(OGSButon sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSButon
        /// </summary>
        OrbitaGSButon control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSButon
        /// </summary>
        ControlNuevaDefinicionComunicaciones definicionComunicaciones;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSButon
        /// </summary>
        /// <param name="control"></param>
        public OGSButon(object control)
            : base()
        {
            this.control = (OrbitaGSButon)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSButon
        /// </summary>
        internal OrbitaGSButon Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSButon
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
                return this.control.bEventosComs.Text;
            }
            set
            {
                this.control.bEventosComs.Text = value;
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSButon
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
