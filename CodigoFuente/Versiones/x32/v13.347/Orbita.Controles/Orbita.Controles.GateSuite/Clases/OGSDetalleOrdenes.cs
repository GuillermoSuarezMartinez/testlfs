using System;
using System.ComponentModel;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using System.Drawing;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSDetalleOrdenes
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionDetalleOrdenes
        {
            public ControlNuevaDefinicionComunicacion(OGSDetalleOrdenes sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden1 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden1(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden1 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden1(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden2 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden2(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden2 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden2(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden3 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden3(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden3 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden3(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden4 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden4(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden4 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden4(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden5 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden5(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden5 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden5(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden6 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden6(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden6 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden6(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden7 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden7(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden7 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden7(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden8 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden8(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden8 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden8(OGSDetalleOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleOrdenes
        /// </summary>
        OrbitaGSDetalleOrdenes control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden1 definicionAlarmasOrden1;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden1 definicionCambioDatoOrden1;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden2 definicionAlarmasOrden2;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden2 definicionCambioDatoOrden2;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden3 definicionAlarmasOrden3;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden3 definicionCambioDatoOrden3;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden4 definicionAlarmasOrden4;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden4 definicionCambioDatoOrden4;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden5 definicionAlarmasOrden5;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden5 definicionCambioDatoOrden5;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden6 definicionAlarmasOrden6;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden6 definicionCambioDatoOrden6;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden7 definicionAlarmasOrden7;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden7 definicionCambioDatoOrden7;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden8 definicionAlarmasOrden8;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden8 definicionCambioDatoOrden8;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSDetalleOrdenes
        /// </summary>
        /// <param name="control"></param>
        public OGSDetalleOrdenes(object control)
            : base()
        {
            this.control = (OrbitaGSDetalleOrdenes)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleOrdenes
        /// </summary>
        internal OrbitaGSDetalleOrdenes Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden1 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden1
        {
            get { return this.control.bCorregirOrden1.Enabled; }
            set { this.control.bCorregirOrden1.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden1 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden1
        {
            get { return this.control.bEliminarOrden1.Enabled; }
            set { this.control.bEliminarOrden1.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden1 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden1
        {
            get { return this.control.bAgregarOrden1.Enabled; }
            set { this.control.bAgregarOrden1.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden2 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden2
        {
            get { return this.control.bCorregirOrden2.Enabled; }
            set { this.control.bCorregirOrden2.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden2 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden2
        {
            get { return this.control.bEliminarOrden2.Enabled; }
            set { this.control.bEliminarOrden2.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden2 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden2
        {
            get { return this.control.bAgregarOrden2.Enabled; }
            set { this.control.bAgregarOrden2.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden3 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden3
        {
            get { return this.control.bCorregirOrden3.Enabled; }
            set { this.control.bCorregirOrden3.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden3 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden3
        {
            get { return this.control.bEliminarOrden3.Enabled; }
            set { this.control.bEliminarOrden3.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden3 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden3
        {
            get { return this.control.bAgregarOrden3.Enabled; }
            set { this.control.bAgregarOrden3.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden4 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden4
        {
            get { return this.control.bCorregirOrden4.Enabled; }
            set { this.control.bCorregirOrden4.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden4 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden4
        {
            get { return this.control.bEliminarOrden4.Enabled; }
            set { this.control.bEliminarOrden4.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden4 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden4
        {
            get { return this.control.bAgregarOrden4.Enabled; }
            set { this.control.bAgregarOrden4.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden5 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden5
        {
            get { return this.control.bCorregirOrden5.Enabled; }
            set { this.control.bCorregirOrden5.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden5 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden5
        {
            get { return this.control.bEliminarOrden5.Enabled; }
            set { this.control.bEliminarOrden5.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden5 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden5
        {
            get { return this.control.bAgregarOrden5.Enabled; }
            set { this.control.bAgregarOrden5.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden6 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden6
        {
            get { return this.control.bCorregirOrden6.Enabled; }
            set { this.control.bCorregirOrden6.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden6 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden6
        {
            get { return this.control.bEliminarOrden6.Enabled; }
            set { this.control.bEliminarOrden6.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden6 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden6
        {
            get { return this.control.bAgregarOrden6.Enabled; }
            set { this.control.bAgregarOrden6.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden7 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden7
        {
            get { return this.control.bCorregirOrden7.Enabled; }
            set { this.control.bCorregirOrden7.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden7 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden7
        {
            get { return this.control.bEliminarOrden7.Enabled; }
            set { this.control.bEliminarOrden7.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden7 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden7
        {
            get { return this.control.bAgregarOrden7.Enabled; }
            set { this.control.bAgregarOrden7.Enabled = value; }
        }

        /// <summary>
        /// Obtiene o establece si bCorregirOrden8 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCorregirOrden8
        {
            get { return this.control.bCorregirOrden8.Enabled; }
            set { this.control.bCorregirOrden8.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bEliminarOrden8 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarEliminarOrden8
        {
            get { return this.control.bEliminarOrden8.Enabled; }
            set { this.control.bEliminarOrden8.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bAgregarOrden8 está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarAgregarOrden8
        {
            get { return this.control.bAgregarOrden8.Enabled; }
            set { this.control.bAgregarOrden8.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden1 AlarmasOrden1
        {
            get { return this.definicionAlarmasOrden1; }
            set { this.definicionAlarmasOrden1 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden1 CambioDatoOrden1
        {
            get { return this.definicionCambioDatoOrden1; }
            set { this.definicionCambioDatoOrden1 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden2 AlarmasOrden2
        {
            get { return this.definicionAlarmasOrden2; }
            set { this.definicionAlarmasOrden2 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden2 CambioDatoOrden2
        {
            get { return this.definicionCambioDatoOrden2; }
            set { this.definicionCambioDatoOrden2 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden3 AlarmasOrden3
        {
            get { return this.definicionAlarmasOrden3; }
            set { this.definicionAlarmasOrden3 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden3 CambioDatoOrden3
        {
            get { return this.definicionCambioDatoOrden3; }
            set { this.definicionCambioDatoOrden3 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden4 AlarmasOrden4
        {
            get { return this.definicionAlarmasOrden4; }
            set { this.definicionAlarmasOrden4 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden4 CambioDatoOrden4
        {
            get { return this.definicionCambioDatoOrden4; }
            set { this.definicionCambioDatoOrden4 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden5 AlarmasOrden5
        {
            get { return this.definicionAlarmasOrden5; }
            set { this.definicionAlarmasOrden5 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden5 CambioDatoOrden5
        {
            get { return this.definicionCambioDatoOrden5; }
            set { this.definicionCambioDatoOrden5 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden6 AlarmasOrden6
        {
            get { return this.definicionAlarmasOrden6; }
            set { this.definicionAlarmasOrden6 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden6 CambioDatoOrden6
        {
            get { return this.definicionCambioDatoOrden6; }
            set { this.definicionCambioDatoOrden6 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden7 AlarmasOrden7
        {
            get { return this.definicionAlarmasOrden7; }
            set { this.definicionAlarmasOrden7 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden7 CambioDatoOrden7
        {
            get { return this.definicionCambioDatoOrden7; }
            set { this.definicionCambioDatoOrden7 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden8 AlarmasOrden8
        {
            get { return this.definicionAlarmasOrden8; }
            set { this.definicionAlarmasOrden8 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden8 CambioDatoOrden8
        {
            get { return this.definicionCambioDatoOrden8; }
            set { this.definicionCambioDatoOrden8 = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmasOrden1 == null)
            {
                this.definicionAlarmasOrden1 = new ControlNuevaDefinicionAlarmasOrden1(this, this.control.lblOrden1);
            }
            if (this.definicionCambioDatoOrden1 == null)
            {
                this.definicionCambioDatoOrden1 = new ControlNuevaDefinicionCambioDatoOrden1(this, this.control.lblOrden1);
            }
            if (this.definicionAlarmasOrden2 == null)
            {
                this.definicionAlarmasOrden2 = new ControlNuevaDefinicionAlarmasOrden2(this, this.control.lblOrden2);
            }
            if (this.definicionCambioDatoOrden2 == null)
            {
                this.definicionCambioDatoOrden2 = new ControlNuevaDefinicionCambioDatoOrden2(this, this.control.lblOrden2);
            }
            if (this.definicionAlarmasOrden3 == null)
            {
                this.definicionAlarmasOrden3 = new ControlNuevaDefinicionAlarmasOrden3(this, this.control.lblOrden3);
            }
            if (this.definicionCambioDatoOrden3 == null)
            {
                this.definicionCambioDatoOrden3 = new ControlNuevaDefinicionCambioDatoOrden3(this, this.control.lblOrden3);
            }
            if (this.definicionAlarmasOrden4 == null)
            {
                this.definicionAlarmasOrden4 = new ControlNuevaDefinicionAlarmasOrden4(this, this.control.lblOrden4);
            }
            if (this.definicionCambioDatoOrden4 == null)
            {
                this.definicionCambioDatoOrden4 = new ControlNuevaDefinicionCambioDatoOrden4(this, this.control.lblOrden4);
            }
            if (this.definicionAlarmasOrden5 == null)
            {
                this.definicionAlarmasOrden5 = new ControlNuevaDefinicionAlarmasOrden5(this, this.control.lblOrden1);
            }
            if (this.definicionCambioDatoOrden5 == null)
            {
                this.definicionCambioDatoOrden5 = new ControlNuevaDefinicionCambioDatoOrden5(this, this.control.lblOrden1);
            }
            if (this.definicionAlarmasOrden6 == null)
            {
                this.definicionAlarmasOrden6 = new ControlNuevaDefinicionAlarmasOrden6(this, this.control.lblOrden2);
            }
            if (this.definicionCambioDatoOrden6 == null)
            {
                this.definicionCambioDatoOrden6 = new ControlNuevaDefinicionCambioDatoOrden6(this, this.control.lblOrden2);
            }
            if (this.definicionAlarmasOrden7 == null)
            {
                this.definicionAlarmasOrden7 = new ControlNuevaDefinicionAlarmasOrden7(this, this.control.lblOrden3);
            }
            if (this.definicionCambioDatoOrden7 == null)
            {
                this.definicionCambioDatoOrden7 = new ControlNuevaDefinicionCambioDatoOrden7(this, this.control.lblOrden3);
            }
            if (this.definicionAlarmasOrden8 == null)
            {
                this.definicionAlarmasOrden8 = new ControlNuevaDefinicionAlarmasOrden8(this, this.control.lblOrden4);
            }
            if (this.definicionCambioDatoOrden8 == null)
            {
                this.definicionCambioDatoOrden8 = new ControlNuevaDefinicionCambioDatoOrden8(this, this.control.lblOrden4);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicacion de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionDetalleOrdenes
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionDetalleOrdenes
        /// </summary>
        OGSDetalleOrdenes control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionDetalleOrdenes
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionDetalleOrdenes(object control)
            : base()
        {
            this.control = (OGSDetalleOrdenes)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionDetalleOrdenes
        /// </summary>
        internal OGSDetalleOrdenes Control
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden1).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden2).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden3).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden4).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden5).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden6).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden7).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden8).OI.Comunicacion.IdDispositivo = value;
            }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden1).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden2).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden3).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden4).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden5).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden6).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden7).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden8).OI.Comunicacion.NombreCanal = value;

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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden1).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden2).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden3).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden4).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden5).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden6).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden7).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden8).OI.Comunicacion.Pintar = value;

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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden1).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden2).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden3).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden4).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden5).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden6).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden7).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden8).OI.Comunicacion.ColorFondoComunica = value;

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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden1).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden2).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden3).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden4).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden5).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden6).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden7).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblOrden8).OI.Comunicacion.ColorFondoNoComunica = value;

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
