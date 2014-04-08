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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSInspeccionOrdenes
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionInspeccionOrdenes
        {
            public ControlNuevaDefinicionComunicacion(OGSInspeccionOrdenes sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden1 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden1(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden1 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden1(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden2 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden2(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden2 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden2(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden3 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden3(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden3 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden3(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionAlarmasOrden4 : OGSAlarmasOrdenes
        {
            public ControlNuevaDefinicionAlarmasOrden4(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Ordenes del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoOrden4 : OGSCambioDatoOrdenes
        {
            public ControlNuevaDefinicionCambioDatoOrden4(OGSInspeccionOrdenes sender, object inspeccion)
                : base(sender, inspeccion) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionOrdenes
        /// </summary>
        OrbitaGSInspeccionOrdenes control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden1 definicionAlarmasOrden1;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden1 definicionCambioDatoOrden1;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden2 definicionAlarmasOrden2;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden2 definicionCambioDatoOrden2;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden3 definicionAlarmasOrden3;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden3 definicionCambioDatoOrden3;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionAlarmasOrden4 definicionAlarmasOrden4;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ControlNuevaDefinicionCambioDatoOrden4 definicionCambioDatoOrden4;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSInspeccionOrdenes
        /// </summary>
        /// <param name="control"></param>
        public OGSInspeccionOrdenes(object control)
            : base()
        {
            this.control = (OrbitaGSInspeccionOrdenes)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionOrdenes
        /// </summary>
        internal OrbitaGSInspeccionOrdenes Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden1 AlarmasOrden1
        {
            get { return this.definicionAlarmasOrden1; }
            set { this.definicionAlarmasOrden1 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden1 CambioDatoOrden1
        {
            get { return this.definicionCambioDatoOrden1; }
            set { this.definicionCambioDatoOrden1 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden2 AlarmasOrden2
        {
            get { return this.definicionAlarmasOrden2; }
            set { this.definicionAlarmasOrden2 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden2 CambioDatoOrden2
        {
            get { return this.definicionCambioDatoOrden2; }
            set { this.definicionCambioDatoOrden2 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden3 AlarmasOrden3
        {
            get { return this.definicionAlarmasOrden3; }
            set { this.definicionAlarmasOrden3 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden3 CambioDatoOrden3
        {
            get { return this.definicionCambioDatoOrden3; }
            set { this.definicionCambioDatoOrden3 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasOrden4 AlarmasOrden4
        {
            get { return this.definicionAlarmasOrden4; }
            set { this.definicionAlarmasOrden4 = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoOrden4 CambioDatoOrden4
        {
            get { return this.definicionCambioDatoOrden4; }
            set { this.definicionCambioDatoOrden4 = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
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
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicacion de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionInspeccionOrdenes
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionInspeccionOrdenes
        /// </summary>
        OGSInspeccionOrdenes control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionInspeccionOrdenes
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionInspeccionOrdenes(object control)
            : base()
        {
            this.control = (OGSInspeccionOrdenes)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionInspeccionOrdenes
        /// </summary>
        internal OGSInspeccionOrdenes Control
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
