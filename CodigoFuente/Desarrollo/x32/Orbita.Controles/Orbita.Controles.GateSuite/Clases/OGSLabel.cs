using System.ComponentModel;
using System.Drawing;
using Orbita.Controles.Comunes;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSLabel
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSLabel
    {
        /// <summary>
        /// Clase de las propiedades de Apariencia del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        public class ControlNuevaDefinicionApariencia : OGSApariencia
        {
            public ControlNuevaDefinicionApariencia(OGSLabel sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        public class ControlNuevaDefinicionComunicaciones : OGSComunicaciones
        {
            public ControlNuevaDefinicionComunicaciones(OGSLabel sender)
                : base(sender) { }
        };
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        OrbitaGSLabel control;
        /// <summary>
        /// Definición de las propiedades de Apariencia del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        ControlNuevaDefinicionApariencia definicionApariencia;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        ControlNuevaDefinicionComunicaciones definicionComunicaciones;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        /// <param name="control"></param>
        public OGSLabel(object control)
            : base()
        {
            this.control = (OrbitaGSLabel)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        internal OrbitaGSLabel Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Apariencia del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionApariencia Apariencia
        {
            get { return this.definicionApariencia; }
            set { this.definicionApariencia = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
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
                return this.control.lblEventosComs.Text;
            }
            set
            {
                this.control.lblEventosComs.Text = value;
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
        /// Inicializa los atributos de las propiedades de Comunicaciones y Apariencia del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionApariencia == null)
            {
                this.definicionApariencia = new ControlNuevaDefinicionApariencia(this);
            }
            if (this.definicionComunicaciones == null)
            {
                this.definicionComunicaciones = new ControlNuevaDefinicionComunicaciones(this);
            }

        }
        #endregion

       
    }
    /// <summary>
    /// Clase de las propiedades de Apariencia del control Orbita.Controles.GateSuite.OrbitaGSLabel
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSApariencia
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSApariencia
        /// </summary>
        OGSLabel control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSAparienciaLabel
        /// </summary>
        /// <param name="control"></param>
        public OGSApariencia(object control)
            : base()
        {
            this.control = (OGSLabel)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSAparienciaLabel
        /// </summary>
        internal OGSLabel Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece la alineación vertical del texto del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        [DefaultValue (AlineacionVertical.Medio)]
        public AlineacionVertical AlineacionTextoVertical
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.AlineacionTextoVertical;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.AlineacionTextoVertical = value;
            }
        }
        /// <summary>
        /// Obtiene o establece la alineación horizontal del texto del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        [DefaultValue (AlineacionHorizontal.Centro)]
        public AlineacionHorizontal AlineacionTextoHorizontal
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.AlineacionTextoHorizontal;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.AlineacionTextoHorizontal = value;
            }
        }
        /// <summary>
        ///Obtiene o establece el adorno del texto del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
        [DefaultValue (AdornoTexto.Ninguno)]
        public AdornoTexto AdornoTexto
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.AdornoTexto;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.AdornoTexto = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el color del borde del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
       
        public Color ColorBorde
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.ColorBorde;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.ColorBorde = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el color del fondo del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
      
        public Color ColorFondo
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.ColorFondo;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.ColorFondo = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el color del texto del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
       
        public Color ColorTexto
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.ColorTexto;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.ColorTexto = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el estilo del borde del control Orbita.Controles.GateSuite.OrbitaGSLabel
        /// </summary>
         [DefaultValue(EstiloBorde.Solido)]
        public EstiloBorde EstiloBorde
        {
            get
            {
                return this.control.Control.lblEventosComs.OI.Apariencia.EstiloBorde;
            }
            set
            {
                this.control.Control.lblEventosComs.OI.Apariencia.EstiloBorde = value;
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
    }
}
