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
    /// Clase de las propiedades comunes de Comunicaciones para el cambio de dato de los controles compuestos
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSCambioDatoOrbitaGSCompuesto
    {

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones  
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoInspeccion : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoInspeccion(OGSCambioDatoOrbitaGSCompuesto sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoRecod : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoRecod(OGSCambioDatoOrbitaGSCompuesto sender, object recod)
                : base(sender, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones  
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoRecodTOS : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoRecodTOS(OGSCambioDatoOrbitaGSCompuesto sender, object recodTOS)
                : base(sender, recodTOS) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoFiabilidad : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoFiabilidad(OGSCambioDatoOrbitaGSCompuesto sender, object fiabilidad)
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
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoOrbitaGSCompuesto
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoInspeccion definicionCambioDatoInspeccion;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoRecod definicionCambioDatoRecod;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoRecodTOS definicionCambioDatoRecodTOS;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoFiabilidad definicionCambioDatoFiabilidad;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSCambioDatoOrbitaGSCompuesto
        /// </summary>
        /// <param name="control">control asociado</param>
        /// <param name="inspeccion">objeto para la inspección</param>
        /// <param name="recod">objeto para la recodificación</param>
        /// <param name="recodTOS">objeto para la recodificación TOS</param>
        /// <param name="fiabilidad">objeto para la fiabilidad</param>      
        public OGSCambioDatoOrbitaGSCompuesto(object control, object inspeccion, object recod, object recodTOS, object fiabilidad)
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
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoOrbitaGSCompuesto
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoInspeccion CambioDatoInspeccion
        {
            get { return this.definicionCambioDatoInspeccion; }
            set { this.definicionCambioDatoInspeccion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones  
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoRecod CambioDatoRecod
        {
            get { return this.definicionCambioDatoRecod; }
            set { this.definicionCambioDatoRecod = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoRecodTOS CambioDatoRecodTOS
        {
            get { return this.definicionCambioDatoRecodTOS; }
            set { this.definicionCambioDatoRecodTOS = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoFiabilidad CambioDatoFiabilidad
        {
            get { return this.definicionCambioDatoFiabilidad; }
            set { this.definicionCambioDatoFiabilidad = value; }
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
            if (this.definicionCambioDatoInspeccion == null)
            {
                this.definicionCambioDatoInspeccion = new ControlNuevaDefinicionCambioDatoInspeccion(this, this.inspeccion);
            }
            if (this.definicionCambioDatoRecod == null)
            {
                this.definicionCambioDatoRecod = new ControlNuevaDefinicionCambioDatoRecod(this, this.recod);
            }
            if (this.definicionCambioDatoRecodTOS == null)
            {
                this.definicionCambioDatoRecodTOS = new ControlNuevaDefinicionCambioDatoRecodTOS(this, this.recodTOS);
            }
            if (this.definicionCambioDatoFiabilidad == null)
            {
                this.definicionCambioDatoFiabilidad = new ControlNuevaDefinicionCambioDatoFiabilidad(this, this.fiabilidad);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicaciones para el cambio de dato de presencia IMO
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSCambioDatoPresencia
    {

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones  
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoInspeccion : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoInspeccion(OGSCambioDatoPresencia sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones 
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoRecod : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoRecod(OGSCambioDatoPresencia sender, object recod)
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
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoPresencia
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoInspeccion definicionCambioDatoInspeccion;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoRecod definicionCambioDatoRecod;

        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSCambioDatoPresencia
        /// </summary>
        /// <param name="control">control asociado</param>
        /// <param name="inspeccion">objeto para la inspección</param>
        /// <param name="recod">objeto para la recodificación</param>     
        public OGSCambioDatoPresencia(object control, object inspeccion, object recod)
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
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoPresencia
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoInspeccion CambioDatoInspeccion
        {
            get { return this.definicionCambioDatoInspeccion; }
            set { this.definicionCambioDatoInspeccion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones  
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoRecod CambioDatoRecod
        {
            get { return this.definicionCambioDatoRecod; }
            set { this.definicionCambioDatoRecod = value; }
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
            if (this.definicionCambioDatoInspeccion == null)
            {
                this.definicionCambioDatoInspeccion = new ControlNuevaDefinicionCambioDatoInspeccion(this, this.inspeccion);
            }
            if (this.definicionCambioDatoRecod == null)
            {
                this.definicionCambioDatoRecod = new ControlNuevaDefinicionCambioDatoRecod(this, this.recod);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicaciones para el cambio de dato de las ordenes
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSCambioDatoOrdenes
    {

        /// <summary>
        /// Clase de las propiedades de CambioDato de Comunicaciones  
        /// </summary>      
        public class ControlNuevaDefinicionCambioDatoInspeccion : OGSCambioDatoCompuesto
        {
            public ControlNuevaDefinicionCambioDatoInspeccion(OGSCambioDatoOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };


        #region Atributos
        /// <summary>
        /// objeto asociado a la inspección
        /// </summary>
        dynamic inspeccion;
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoOrdenes
        /// </summary>
        dynamic control;
        /// <summary>
        /// Definición de las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        ControlNuevaDefinicionCambioDatoInspeccion definicionCambioDatoInspeccion;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSCambioDatoOrdenes
        /// </summary>
        /// <param name="control">control asociado</param>
        /// <param name="inspeccion">objeto para la inspección</param>
        /// <param name="recod">objeto para la recodificación</param>     
        public OGSCambioDatoOrdenes(object control, object inspeccion)
            : base()
        {
            this.control = control;
            this.inspeccion = inspeccion;
            this.InitializeAttributes();
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoOrdenes
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato de Comunicaciones 
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoInspeccion CambioDatoInspeccion
        {
            get { return this.definicionCambioDatoInspeccion; }
            set { this.definicionCambioDatoInspeccion = value; }
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
            if (this.definicionCambioDatoInspeccion == null)
            {
                this.definicionCambioDatoInspeccion = new ControlNuevaDefinicionCambioDatoInspeccion(this, this.inspeccion);
            }
        }
        #endregion
    }
    /// <summary>
    /// Clase de las propiedades del cambio de dato comunes de Comunicaciones de los controles compuestos
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSCambioDatoCompuesto
    {
        #region Atributos
        /// <summary>
        /// objeto asociado al cambio de dato
        /// </summary>
        dynamic objetoCambioDato;
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoCompuesto
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSCambioDatoCompuesto
        /// </summary>
        /// <param name="control"></param>
        public OGSCambioDatoCompuesto(object control, object objectoCambioDato)
            : base()
        {
            this.control = control;
            this.objetoCambioDato = objectoCambioDato;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSCambioDatoCompuesto
        /// </summary>
        internal dynamic Control
        {
            get { return this.control; }
        }

        [Description("Variable visual")]
        public string Variable
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Variable; }
            set { ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Variable = value; }
        }


        [Browsable(false)]
        public List<String> Cambios
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Cambios; }
            set { ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Cambios = value; }
        }
        [Browsable(true), DisplayName("Cambio")]
        [Description("Variables al cambio")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter(typeof(OBaseEventosComs.CsvArrayConverter))]
        public string[] CambiosArray
        {
            get { return ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Cambios.ToArray(); }
            set
            {
                ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Cambios.Clear();
                if (value != null) { ((OrbitaControlBaseEventosComs)this.objetoCambioDato).OI.CambioDato.Cambios.AddRange(value); }
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
