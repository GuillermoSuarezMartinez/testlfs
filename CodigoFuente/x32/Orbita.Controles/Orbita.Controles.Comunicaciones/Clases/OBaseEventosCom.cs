
using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Drawing.Design;
using System.Text;

namespace Orbita.Controles.Comunicaciones
{
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OBaseEventosComs
    {
        /// <summary>
        /// Conversor del array
        /// </summary>
        public class CsvArrayConverter : ArrayConverter
        {
            #region Métodos
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                Array array = value as Array;
                if (destinationType == typeof(string) && array != null)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(", ");
                        }
                        sb.Append(array.GetValue(i));
                    }
                    return sb.ToString();

                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
            #endregion
        }
        /// <summary>
        /// Clase de las propiedades del control OrbitaUltraLabel
        /// </summary>
        public class ControlNuevaDefinicionAlarmas : OAlarmas
        {
            public ControlNuevaDefinicionAlarmas(OBaseEventosComs sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades del control OrbitaUltraLabel
        /// </summary>
        public class ControlNuevaDefinicionCambioDato : OCambioDato
        {
            public ControlNuevaDefinicionCambioDato(OBaseEventosComs sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades del control OrbitaUltraLabel
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OComunicacion
        {
            public ControlNuevaDefinicionComunicacion(OBaseEventosComs sender)
                : base(sender) { }
        };
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase OGSLabel
        /// </summary>
        OrbitaControlBaseEventosComs control;
        /// <summary>
        /// definición de las propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        ControlNuevaDefinicionAlarmas definicionAlarmas;
        /// <summary>
        /// definición de las propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        ControlNuevaDefinicionCambioDato definicionCambioDato;
        /// <summary>
        /// definición de las propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        /// <param name="control"></param>
        public OBaseEventosComs(object control)
            : base()
        {
            this.control = (OrbitaControlBaseEventosComs)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSLabel
        /// </summary>
        internal OrbitaControlBaseEventosComs Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmas Alarmas
        {
            get { return this.definicionAlarmas; }
            set { this.definicionAlarmas = value; }
        }

        /// <summary>
        /// propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDato CambioDato
        {
            get { return this.definicionCambioDato; }
            set { this.definicionCambioDato = value; }
        }

        /// <summary>
        /// propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del OrbitaUltraLabel contenido en el control
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmas == null)
            {
                this.definicionAlarmas = new ControlNuevaDefinicionAlarmas(this);
            }
            if (this.definicionCambioDato == null)
            {
                this.definicionCambioDato = new ControlNuevaDefinicionCambioDato(this);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OAlarmas
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase OGSLabel
        /// </summary>
        OBaseEventosComs control;
        private List<string> _alarmas = new List<string>();
        private bool _pintar = false;
        private Color _colorFondoAlarma = Color.Red;
        private Color _colorFondoNoAlarma = Color.White;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        /// <param name="control"></param>
        public OAlarmas(object control)
            : base()
        {
            this.control = (OBaseEventosComs)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSLabel
        /// </summary>
        internal OBaseEventosComs Control
        {
            get { return this.control; }
        }


        [Browsable(false)]
        public List<String> Alarmas
        {
            get { return _alarmas; }
            set { _alarmas = value; }
        }
        [Browsable(true), DisplayName("Alarmas")]
        [Description("Alarmas asociadas")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter(typeof(OBaseEventosComs.CsvArrayConverter))]
        public string[] AlarmasArray
        {
            get { return _alarmas.ToArray(); }
            set
            {
                _alarmas.Clear();
                if (value != null) { _alarmas.AddRange(value); }
            }
        }

        [Description("Determina si hay que cambiar el backcolor del control si está activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("Pintar")]
        [DefaultValue(false)]
        public bool Pintar
        {
            get { return _pintar; }
            set { _pintar = value; }
        }

        [Description("Backcolor del control al estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoAlarma")]
        [DefaultValue(typeof(Color), "Red")]
        public Color ColorFondoAlarma
        {
            get { return this._colorFondoAlarma; }
            set { this._colorFondoAlarma = value; }
        }

        [Description("Backcolor del control al no estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoNoAlarma")]
        [DefaultValue(typeof(Color), "White")]
        public Color ColorFondoNoAlarma
        {
            get { return this._colorFondoNoAlarma; }
            set { this._colorFondoNoAlarma = value; }
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        #endregion
    }

    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OCambioDato
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase OGSLabel
        /// </summary>
        OBaseEventosComs control;
        private string _variable;
        private List<string> _cambios = new List<string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        /// <param name="control"></param>
        public OCambioDato(object control)
            : base()
        {
            this.control = (OBaseEventosComs)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSLabel
        /// </summary>
        internal OBaseEventosComs Control
        {
            get { return this.control; }
        }


        [Description("Variable cuyo valor veremos en el el TEXT.")]
        [Browsable(true), DisplayName("Variable visual")]
        [DefaultValue("")]
        public string Variable
        {
            get { return _variable; }
            set { _variable = value; }
        }


        [Browsable(false)]
        public List<String> Cambios
        {
            get { return _cambios; }
            set { _cambios = value; }
        }

        [Browsable(true), DisplayName("Cambio")]
        [Description("Variables al cambio")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter(typeof(OBaseEventosComs.CsvArrayConverter))]
        public string[] CambiosArray
        {
            get { return _cambios.ToArray(); }
            set
            {
                _cambios.Clear();
                if (value != null) { _cambios.AddRange(value); }
            }
        }

        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        #endregion
    }

    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OComunicacion
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase OGSLabel
        /// </summary>
        OBaseEventosComs control;
        string _nombreCanal = string.Empty;
        int _idDispositivo = 0;
        bool _pintar = false;
        Color _colorFondoComunica = Color.White;
        Color _colorFondoNoComunica = Color.Red;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSLabel
        /// </summary>
        /// <param name="control"></param>
        public OComunicacion(object control)
            : base()
        {
            this.control = (OBaseEventosComs)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSLabel
        /// </summary>
        internal OBaseEventosComs Control
        {
            get { return this.control; }
        }

        [Description("Dispositivo del servidor de comunicaciones")]
        public int IdDispositivo
        {
            get { return this._idDispositivo; }
            set { this._idDispositivo = value; }
        }

        [Description("Nombre del canal del servidor de comunicaciones")]
        public string NombreCanal
        {
            get { return this._nombreCanal; }
            set { this._nombreCanal = value; }
        }

        [Description("Determina si hay que cambiar el backcolor del control si hay un fallo de comunicación con el servidor de comunicaciones.")]
        [Browsable(true), DisplayName("Pintar")]
        [DefaultValue(false)]
        public bool Pintar
        {
            get { return _pintar; }
            set { _pintar = value; }
        }

        [Description("Backcolor del control al fallar la comunicación con el servidor de comunicaciones.")]
        [Browsable(true), DisplayName("ColorFondoComunica")]
        [DefaultValue(typeof(Color), "White")]
        public Color ColorFondoComunica
        {
            get { return this._colorFondoComunica; }
            set { this._colorFondoComunica = value; }
        }

        [Description("Backcolor del control al no estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoNoComunica")]
        [DefaultValue(typeof(Color), "Red")]
        public Color ColorFondoNoComunica
        {
            get { return this._colorFondoNoComunica; }
            set { this._colorFondoNoComunica = value; }
        }
        #endregion

        #region Métodos públicos
        public override string ToString()
        {
            return null;
        }
        #endregion
    }   
}
