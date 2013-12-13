using System.ComponentModel;
using System.Drawing;
using Orbita.Controles.Comunicaciones;
using Orbita.Controles.GateSuite.Properties;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSOrden
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSOrden
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionOrden
        {
            public ControlNuevaDefinicionComunicacion(OGSOrden sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public class ControlNuevaDefinicionAlarmas : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmas(OGSOrden sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public class ControlNuevaDefinicionCambioDato : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDato(OGSOrden sender, object inspeccion)
                : base(sender, inspeccion) { }
        };
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSOrden
        /// </summary>
        OrbitaGSOrden control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ControlNuevaDefinicionAlarmas definicionAlarmas;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ControlNuevaDefinicionCambioDato definicionCambioDato;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSOrden
        /// </summary>
        /// <param name="control"></param>
        public OGSOrden(object control)
            : base()
        {
            this.control = (OrbitaGSOrden)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSOrden
        /// </summary>
        internal OrbitaGSOrden Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmas Alarmas
        {
            get { return this.definicionAlarmas; }
            set { this.definicionAlarmas = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDato CambioDato
        {
            get { return this.definicionCambioDato; }
            set { this.definicionCambioDato = value; }
        }
        /// <summary>
        /// Obtiene o establece el número de identificador del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        private int _numId;
        [Description("Número identificador de la Orden")]
        [Browsable(true), DisplayName("IdentificadorOrden")]
        [DefaultValue(0)]
        public int IdentificadorOrden
        {
            get { return _numId; }
            set { _numId = value; }
        }
        /// <summary>
        /// Obtiene o establece el modo en el que es leído el control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        OGSEnumModoOrden _modo = OGSEnumModoOrden.SinModo;
        [Description("Modo de introducción de la Orden")]
        [Browsable(false), DisplayName("Modo")]
        [DefaultValue(OGSEnumModoOrden.SinModo)]
        public OGSEnumModoOrden Modo
        {
            get { return this._modo; }
            set { this._modo = value; }
        }
        /// <summary>
        /// Obtiene o establece el contenido del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        string _contenido = string.Empty;
        [Description("Contenido de la orden")]
        [Browsable(false), DisplayName("Contenido")]
        [DefaultValue("")]
        public string Contenido
        {
            get { return this._contenido; }
            set { this._contenido = value; }
        }
        /// <summary>
        /// Obtiene si el contenido del control Orbita.Controles.GateSuite.OrbitaGSOrden es vacío
        /// </summary>
        [Description("Indica si está vacia la orden")]
        [Browsable(false), DisplayName("OrdenVacia")]
        [DefaultValue(false)]
        public bool OrdenVacia
        {
            get { return this._contenido == string.Empty; }
        }
        /// <summary>
        /// Obtiene o establece si se muestra el botón teclado del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        bool _mostrarBotonTeclado = true;
        [Description("Muestra la imagen del teclado en el control")]
        [Browsable(false), DisplayName("MostrarBotonTeclado")]
        [DefaultValue(false)]
        public bool MostrarBotonTeclado
        {
            get
            {
                return this._mostrarBotonTeclado;
            }
            set
            {
                this._mostrarBotonTeclado = value;

                if (_mostrarBotonTeclado) this.control.lblBoton.Appearance.ImageBackground = Resources.Teclado_72x72;
                else this.control.lblBoton.Appearance.ImageBackground = null;
            }
        }
        /// <summary>
        /// Obtiene y establece el código visual del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        [Description("Código Visual de la orden")]
        [Browsable(false), DisplayName("CodigoVisual")]
        [DefaultValue(false)]
        public string CodigoVisual
        {
            get
            {
                return this.control.lblTextoOrden.Text;
            }
            set
            {
                this.control.lblTextoOrden.Text = value;
            }
        }
        /// <summary>
        /// Obtiene o establece si se muestra el botón borrar del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        bool _mostrarBotonBorrar = false;
        [Description("Muestra la imagen para borrar orden")]
        [Browsable(false), DisplayName("MostrarBotonBorrar")]
        [DefaultValue(false)]
        public bool MostrarBotonBorrar
        {
            get
            {
                return this._mostrarBotonBorrar;
            }
            set
            {
                this._mostrarBotonBorrar = value;

                if (_mostrarBotonBorrar) this.control.lblBoton.Appearance.ImageBackground = Resources.Borrar_72x72;
                else this.control.lblBoton.Appearance.ImageBackground = null;
            }
        }
        /// <summary>
        /// Establece si se muestra la imagen de precaución del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        [Description("Muestra la imagen de precaución de la orden (si ya se ha introducido una orden con el mismo control)")]
        [Browsable(false), DisplayName("MostrarImagenPrecaucion")]
        [DefaultValue(false)]
        public bool MostrarImagenPrecaucion
        {
            set
            {
                this.control.lblPrecaucion.Visible = value;
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmas == null)
            {
                this.definicionAlarmas = new ControlNuevaDefinicionAlarmas(this, this.control.lblTextoOrden);
            }
            if (this.definicionCambioDato == null)
            {
                this.definicionCambioDato = new ControlNuevaDefinicionCambioDato(this, this.control.lblTextoOrden);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicacion de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSOrden
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionOrden
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionOrden
        /// </summary>
        OGSOrden control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionOrden
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionOrden(object control)
            : base()
        {
            this.control = (OGSOrden)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionOrden
        /// </summary>
        internal OGSOrden Control
        {
            get { return this.control; }
        }

        [Description("Dispositivo del servidor de Comunicaciones")]
        public int IdDispositivo
        {
            get
            {
                return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.IdDispositivo;
            }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblTextoOrden).OI.Comunicacion.IdDispositivo = value;
            }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblTextoOrden).OI.Comunicacion.NombreCanal = value;
            }
        }

        [Description("Determina si hay que cambiar el backcolor del control si hay un fallo de comunicación con el servidor de Comunicaciones.")]
        [Browsable(true), DisplayName("Pintar")]
        [DefaultValue(false)]
        public bool Pintar
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.Pintar; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblTextoOrden).OI.Comunicacion.Pintar = value;
            }
        }

        [Description("Backcolor del control al fallar la comunicación con el servidor de Comunicaciones.")]
        [Browsable(true), DisplayName("ColorFondoComunica")]
        [DefaultValue(typeof(Color), "White")]
        public Color ColorFondoComunica
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.ColorFondoComunica; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblTextoOrden).OI.Comunicacion.ColorFondoComunica = value;
            }
        }

        [Description("Backcolor del control al no estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoNoComunica")]
        [DefaultValue(typeof(Color), "Red")]
        public Color ColorFondoNoComunica
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.ColorFondoNoComunica; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblTextoOrden).OI.Comunicacion.ColorFondoNoComunica = value;
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

    /// <summary>
    /// Modo de introducir la orden
    /// </summary>
    public enum OGSEnumModoOrden
    {
        /// <summary>
        /// Orden leída por un escaner
        /// </summary>
        ModoEscaner,
        /// <summary>
        /// Orden leída desde teclado
        /// </summary>
        ModoManual,
        /// <summary>
        /// Orden sin leer
        /// </summary>
        SinModo
    }
}
