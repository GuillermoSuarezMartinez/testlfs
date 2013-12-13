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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSInspeccionIMO
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionInspeccionIMO
        {
            public ControlNuevaDefinicionComunicacion(OGSInspeccionIMO sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la IMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        public class ControlNuevaDefinicionAlarmasIMO : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmasIMO(OGSInspeccionIMO sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la IMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoIMO : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDatoIMO(OGSInspeccionIMO sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la Presencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        public class ControlNuevaDefinicionAlarmasPresencia : OGSAlarmasPresencia
        {
            public ControlNuevaDefinicionAlarmasPresencia(OGSInspeccionIMO sender, object inspeccion, object recod)
                : base(sender, inspeccion, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la Presencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoPresencia : OGSCambioDatoPresencia
        {
            public ControlNuevaDefinicionCambioDatoPresencia(OGSInspeccionIMO sender, object inspeccion, object recod)
                : base(sender, inspeccion, recod) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionIMO
        /// </summary>
        OrbitaGSInspeccionIMO control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        ControlNuevaDefinicionAlarmasIMO definicionAlarmasIMO;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        ControlNuevaDefinicionCambioDatoIMO definicionCambioDatoIMO;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        ControlNuevaDefinicionAlarmasPresencia definicionAlarmasPresencia;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        ControlNuevaDefinicionCambioDatoPresencia definicionCambioDatoPresencia;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSInspeccionIMO
        /// </summary>
        /// <param name="control"></param>
        public OGSInspeccionIMO(object control)
            : base()
        {
            this.control = (OrbitaGSInspeccionIMO)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionIMO
        /// </summary>
        internal OrbitaGSInspeccionIMO Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasIMO AlarmasIMO
        {
            get { return this.definicionAlarmasIMO; }
            set { this.definicionAlarmasIMO = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoIMO CambioDatoIMO
        {
            get { return this.definicionCambioDatoIMO; }
            set { this.definicionCambioDatoIMO = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasPresencia AlarmasPresencia
        {
            get { return this.definicionAlarmasPresencia; }
            set { this.definicionAlarmasPresencia = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoPresencia CambioDatoPresencia
        {
            get { return this.definicionCambioDatoPresencia; }
            set { this.definicionCambioDatoPresencia = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmasIMO == null)
            {
                this.definicionAlarmasIMO = new ControlNuevaDefinicionAlarmasIMO(this, this.control.lblInspeccionIMO, this.control.lblRecodIMO, this.control.lblRecodTOSIMO, this.control.lblFiabilidadIMO);
            }
            if (this.definicionCambioDatoIMO == null)
            {
                this.definicionCambioDatoIMO = new ControlNuevaDefinicionCambioDatoIMO(this, this.control.lblInspeccionIMO, this.control.lblRecodIMO, this.control.lblRecodTOSIMO, this.control.lblFiabilidadIMO);
            }
            if (this.definicionAlarmasPresencia == null)
            {
                this.definicionAlarmasPresencia = new ControlNuevaDefinicionAlarmasPresencia(this, this.control.lblInspeccionPresencia, this.control.lblRecodPresencia);
            }
            if (this.definicionCambioDatoPresencia == null)
            {
                this.definicionCambioDatoPresencia = new ControlNuevaDefinicionCambioDatoPresencia(this, this.control.lblInspeccionPresencia, this.control.lblRecodPresencia);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicacion de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionInspeccionIMO
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionInspeccionIMO
        /// </summary>
        OGSInspeccionIMO control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionInspeccionIMO
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionInspeccionIMO(object control)
            : base()
        {
            this.control = (OGSInspeccionIMO)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionInspeccionIMO
        /// </summary>
        internal OGSInspeccionIMO Control
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionPresencia).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodPresencia).OI.Comunicacion.IdDispositivo = value;
            }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionPresencia).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodPresencia).OI.Comunicacion.NombreCanal = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionPresencia).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodPresencia).OI.Comunicacion.Pintar = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionPresencia).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodPresencia).OI.Comunicacion.ColorFondoComunica = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionPresencia).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodPresencia).OI.Comunicacion.ColorFondoNoComunica = value;

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
