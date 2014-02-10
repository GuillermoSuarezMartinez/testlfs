using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades comunes de Comunicaciones para las alarmas de los controles compuestos
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSAlarmasOrbitaGSCompuesto
    {
        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasInspeccion : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasInspeccion(OGSAlarmasOrbitaGSCompuesto sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasRecod : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasRecod(OGSAlarmasOrbitaGSCompuesto sender, object recod)
                : base(sender, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasRecodTOS : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasRecodTOS(OGSAlarmasOrbitaGSCompuesto sender, object recodTOS)
                : base(sender, recodTOS) { }
        };

        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasFiabilidad : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasFiabilidad(OGSAlarmasOrbitaGSCompuesto sender, object fiabilidad)
                : base(sender, fiabilidad) { }
        };

        #region Atributos
        /// <summary>
        /// objeto asociado a la inspección
        /// </summary>
        dynamic inspeccion;
        /// <summary>
        /// objeto asociado a la recodificación
        /// </summary>
        dynamic recod;
        /// <summary>
        /// objeto asociado a la recodificación TOS
        /// </summary>
        dynamic recodTOS;
        /// <summary>
        /// objeto asociado a la fiabilidad
        /// </summary>
        dynamic fiabilidad;
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasOrbitaGSCompuesto
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasInspeccion definicionAlarmasInspeccion;
        /// <summary>
        /// Definición de las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasRecod definicionAlarmasRecod;
        /// <summary>
        /// Definición de las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasRecodTOS definicionAlarmasRecodTOS;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasFiabilidad definicionAlarmasFiabilidad;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSAlarmasOrbitaGSCompuesto
        /// </summary>
        /// <param name="control">control asociado</param>
        /// <param name="inspeccion">objeto para la inspección</param>
        /// <param name="recod">objeto para la recodificación</param>
        /// <param name="recodTOS">objeto para la recodificación TOS</param>
        /// <param name="fiabilidad">objeto para la fiabilidad</param>      
        public OGSAlarmasOrbitaGSCompuesto(object control, object inspeccion, object recod, object recodTOS, object fiabilidad)
            : base()
        {
            this.control = control;
            this.inspeccion = inspeccion;
            this.recod = recod;
            this.recodTOS = recodTOS;
            this.fiabilidad = fiabilidad;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasOrbitaGSCompuesto
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasInspeccion AlarmasInspeccion
        {
            get { return this.definicionAlarmasInspeccion; }
            set { this.definicionAlarmasInspeccion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasRecod AlarmasRecod
        {
            get { return this.definicionAlarmasRecod; }
            set { this.definicionAlarmasRecod = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasRecodTOS AlarmasRecodTOS
        {
            get { return this.definicionAlarmasRecodTOS; }
            set { this.definicionAlarmasRecodTOS = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasFiabilidad AlarmasFiabilidad
        {
            get { return this.definicionAlarmasFiabilidad; }
            set { this.definicionAlarmasFiabilidad = value; }
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

            if (this.definicionAlarmasInspeccion == null)
            {
                this.definicionAlarmasInspeccion = new ControlNuevaDefinicionAlarmasInspeccion(this, this.inspeccion);
            }
            if (this.definicionAlarmasRecod == null)
            {
                this.definicionAlarmasRecod = new ControlNuevaDefinicionAlarmasRecod(this, this.recod);
            }
            if (this.definicionAlarmasRecodTOS == null)
            {
                this.definicionAlarmasRecodTOS = new ControlNuevaDefinicionAlarmasRecodTOS(this, this.recodTOS);
            }
            if (this.definicionAlarmasFiabilidad == null)
            {
                this.definicionAlarmasFiabilidad = new ControlNuevaDefinicionAlarmasFiabilidad(this, this.fiabilidad);
            }
        }
        #endregion
    }
    /// <summary>
    /// Clase de las propiedades de Comunicaciones para las alarmas de la presencia IMO
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSAlarmasPresencia
    {
        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasInspeccion : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasInspeccion(OGSAlarmasPresencia sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasRecod : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasRecod(OGSAlarmasPresencia sender, object recod)
                : base(sender, recod) { }
        };

        #region Atributos
        /// <summary>
        /// objeto asociado a la inspección
        /// </summary>
        dynamic inspeccion;
        /// <summary>
        /// objeto asociado a la recodificación
        /// </summary>
        dynamic recod;
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasPresencia
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasInspeccion definicionAlarmasInspeccion;
        /// <summary>
        /// Definición de las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasRecod definicionAlarmasRecod;
        #endregion

        #region Constructor
        ///<summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSAlarmasPresencia
        /// </summary>
        /// <param name="control">control asociado</param>
        /// <param name="inspeccion">objeto para la inspección</param>
        /// <param name="recod">objeto para la recodificación</param>        
        public OGSAlarmasPresencia(object control, object inspeccion, object recod)
            : base()
        {
            this.control = control;
            this.inspeccion = inspeccion;
            this.recod = recod;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasPresencia
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasInspeccion AlarmasInspeccion
        {
            get { return this.definicionAlarmasInspeccion; }
            set { this.definicionAlarmasInspeccion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasRecod AlarmasRecod
        {
            get { return this.definicionAlarmasRecod; }
            set { this.definicionAlarmasRecod = value; }
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
            if (this.definicionAlarmasInspeccion == null)
            {
                this.definicionAlarmasInspeccion = new ControlNuevaDefinicionAlarmasInspeccion(this, this.inspeccion);
            }
            if (this.definicionAlarmasRecod == null)
            {
                this.definicionAlarmasRecod = new ControlNuevaDefinicionAlarmasRecod(this, this.recod);
            }
        }
        #endregion
    }
    /// <summary>
    /// Clase de las propiedades de Comunicaciones para las alarmas de las órdenes
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSAlarmasOrdenes
    {
        /// <summary>
        /// Clase de las propiedades de Alarmas de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionAlarmasInspeccion : OGSAlarmasCompuesto
        {
            public ControlNuevaDefinicionAlarmasInspeccion(OGSAlarmasOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };


        #region Atributos
        /// <summary>
        /// objeto asociado a la inspección
        /// </summary>
        dynamic inspeccion;
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasOrdenes
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionAlarmasInspeccion definicionAlarmasInspeccion;
        #endregion

        #region Constructor
        ///<summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSAlarmasOrdenes
        /// </summary>
        /// <param name="control">control asociado</param>
        /// <param name="inspeccion">objeto para la inspección</param>             
        public OGSAlarmasOrdenes(object control, object inspeccion)
            : base()
        {
            this.control = control;
            this.inspeccion = inspeccion;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasOrdenes
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasInspeccion AlarmasInspeccion
        {
            get { return this.definicionAlarmasInspeccion; }
            set { this.definicionAlarmasInspeccion = value; }
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
            if (this.definicionAlarmasInspeccion == null)
            {
                this.definicionAlarmasInspeccion = new ControlNuevaDefinicionAlarmasInspeccion(this, this.inspeccion);
            }

        }
        #endregion
    }
    /// <summary>
    /// Clase de las propiedades de las Alarmas comunes de Comunicaciones de los controles compuestos
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSAlarmasCompuesto
    {
        #region Atributos
        /// <summary>
        /// objeto en el que está asociada la alarma
        /// </summary>
        dynamic objetoAlarma;
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasCompuesto
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSAlarmasCompuesto
        /// </summary>
        /// <param name="control"></param>
        public OGSAlarmasCompuesto(object control, object objetoAlarma)
            : base()
        {
            this.control = control;
            this.objetoAlarma = objetoAlarma;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSAlarmasCompuesto
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        [Browsable(false)]
        public List<String> Alarmas
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Alarmas; }
            set { ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Alarmas = value; }
        }
        [Browsable(true), DisplayName("Alarmas")]
        [Description("Alarmas asociadas")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter(typeof(OBaseEventosComs.CsvArrayConverter))]
        public string[] AlarmasArray
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Alarmas.ToArray(); }
            set
            {
                ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Alarmas.Clear();
                if (value != null) { ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Alarmas.AddRange(value); }
            }
        }

        [Description("Determina si hay que cambiar el backcolor del control si está activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("Pintar")]
        [DefaultValue(false)]
        public bool Pintar
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Pintar; }
            set { ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.Pintar = value; }
        }

        [Description("Backcolor del control al estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoAlarma")]
        [DefaultValue(typeof(Color), "Red")]
        public Color ColorFondoAlarma
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.ColorFondoAlarma; }
            set { ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.ColorFondoAlarma = value; }
        }

        [Description("Backcolor del control al no estar activa la(s) alarma(s) asociadas.")]
        [Browsable(true), DisplayName("ColorFondoNoAlarma")]
        [DefaultValue(typeof(Color), "White")]
        public Color ColorFondoNoAlarma
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.ColorFondoNoAlarma; }
            set { ((OrbitaControlBaseEventosComs)this.objetoAlarma).OI.Alarmas.ColorFondoNoAlarma = value; }
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
