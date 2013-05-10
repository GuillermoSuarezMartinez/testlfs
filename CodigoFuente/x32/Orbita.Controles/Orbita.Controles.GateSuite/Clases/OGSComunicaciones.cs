using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades de Comunicaciones
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicaciones
    {
        /// <summary>
        /// Clase de las propiedades de las Alarmas de Comunicaciones 
        /// </summary>
        public class ControlNuevaDefinicionAlarmas : OGSAlarmas
        {
            public ControlNuevaDefinicionAlarmas(OGSComunicaciones sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades al Cambio de Dato de Comunicaciones
        /// </summary>
        public class ControlNuevaDefinicionCambioDato : OGSCambioDato
        {
            public ControlNuevaDefinicionCambioDato(OGSComunicaciones sender)
                : base(sender) { }
        };
        /// <summary>
        /// Clase de las propiedades de Comunicacion de Comunicaciones
        /// </summary>      
        public class ControlNuevaDefinicionComunicacion : OGSComunicacion
        {
            public ControlNuevaDefinicionComunicacion(OGSComunicaciones sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada a la clase Orbita.Controles.GateSuite.OGSComunicaciones
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de las Alarmas de Comunicaciones
        /// </summary>
        ControlNuevaDefinicionAlarmas definicionAlarmas;
        /// <summary>
        /// Definición de las propiedades del Cambio de Dato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDato definicionCambioDato;
        /// <summary>
        /// Definición de las propiedades de Comunicacion de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicaciones
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicaciones(object control)
            : base()
        {
            this.control = control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicaciones
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de las Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmas Alarmas
        {
            get { return this.definicionAlarmas; }
            set { this.definicionAlarmas = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades del Cambio de Dato de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDato CambioDato
        {
            get { return this.definicionCambioDato; }
            set { this.definicionCambioDato = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicación de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones 
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
    /// <summary>
    /// Clase de las propiedades de las Alarmas de Comunicaciones 
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSAlarmas
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmas
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSAlarmas
        /// </summary>
        /// <param name="control"></param>
        public OGSAlarmas(object control)
            : base()
        {
            this.control = control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmas
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        [Browsable(false)]
        public List<String> Alarmas
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Alarmas; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Alarmas = value; }
        }
        [Browsable(true), DisplayName("Alarmas")]
        [Description("Alarmas asociadas")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter(typeof(OBaseEventosComs.CsvArrayConverter))]
        public string[] AlarmasArray
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Alarmas.ToArray(); }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Alarmas.Clear();
                if (value != null) { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Alarmas.AddRange(value); }
            }
        }

        [Description("Determina si hay que cambiar el backcolor del control si está activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("Pintar")]
        [DefaultValue(false)]
        public bool Pintar
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Pintar; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.Pintar = value; }
        }

        [Description("Backcolor del control al estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoAlarma")]
        [DefaultValue(typeof(Color), "Red")]
        public Color ColorFondoAlarma
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.ColorFondoAlarma; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.ColorFondoAlarma = value; }
        }

        [Description("Backcolor del control al no estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoNoAlarma")]
        [DefaultValue(typeof(Color), "White")]
        public Color ColorFondoNoAlarma
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.ColorFondoNoAlarma; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Alarmas.ColorFondoNoAlarma = value; }
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
    /// Clase de las propiedades al Cambio de Dato de Comunicaciones 
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSCambioDato
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDato
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSCambioDato
        /// </summary>
        /// <param name="control"></param>
        public OGSCambioDato(object control)
            : base()
        {
            this.control = control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDato
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        [Description("Variable visual")]
        public string Variable
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Variable; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Variable = value; }
        }


        [Browsable(false)]
        public List<String> Cambios
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Cambios; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Cambios = value; }
        }
        [Browsable(true), DisplayName("Cambio")]
        [Description("Variables al cambio")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter(typeof(OBaseEventosComs.CsvArrayConverter))]
        public string[] CambiosArray
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Cambios.ToArray(); }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Cambios.Clear();
                if (value != null) { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.CambioDato.Cambios.AddRange(value); }
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
    /// Clase de las propiedades de Comunicacion de Comunicaciones 
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacion
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacion
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacion
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacion(object control)
            : base()
        {
            this.control = control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacion
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        [Description("Dispositivo del servidor de Comunicaciones")]
        public int IdDispositivo
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.IdDispositivo; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.IdDispositivo = value; }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.NombreCanal; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.NombreCanal = value; }
        }

        [Description("Determina si hay que cambiar el backcolor del control si hay un fallo de comunicación con el servidor de Comunicaciones.")]
        [Browsable(true), DisplayName("Pintar")]
        [DefaultValue(false)]
        public bool Pintar
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.Pintar; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.Pintar = value; }
        }

        [Description("Backcolor del control al fallar la comunicación con el servidor de Comunicaciones.")]
        [Browsable(true), DisplayName("ColorFondoComunica")]
        [DefaultValue(typeof(Color), "White")]
        public Color ColorFondoComunica
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.ColorFondoComunica; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.ColorFondoComunica = value; }
        }

        [Description("Backcolor del control al no estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoNoComunica")]
        [DefaultValue(typeof(Color), "Red")]
        public Color ColorFondoNoComunica
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.ColorFondoNoComunica; }
            set { ((OrbitaControlBaseEventosComs)this.control.Control.Control).OI.Comunicacion.ColorFondoNoComunica = value; }
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
