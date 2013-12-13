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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSDetalleIMO
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionIMO
        {
            public ControlNuevaDefinicionComunicacion(OGSDetalleIMO sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionAlarmasPLI : OGSAlarmasPresencia
        {
            public ControlNuevaDefinicionAlarmasPLI(OGSDetalleIMO sender, object inspeccion, object recod)
                : base(sender, inspeccion, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoPLI : OGSCambioDatoPresencia
        {
            public ControlNuevaDefinicionCambioDatoPLI(OGSDetalleIMO sender, object inspeccion, object recod)
                : base(sender, inspeccion, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionAlarmasPLD : OGSAlarmasPresencia
        {
            public ControlNuevaDefinicionAlarmasPLD(OGSDetalleIMO sender, object inspeccion, object recod)
                : base(sender, inspeccion, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoPLD : OGSCambioDatoPresencia
        {
            public ControlNuevaDefinicionCambioDatoPLD(OGSDetalleIMO sender, object inspeccion, object recod)
                : base(sender, inspeccion, recod) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionAlarmasIMO : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmasIMO(OGSDetalleIMO sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoIMO : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDatoIMO(OGSDetalleIMO sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleIMO
        /// </summary>
        OrbitaGSDetalleIMO control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionAlarmasPLI definicionAlarmasPLI;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionCambioDatoPLI definicionCambioDatoPLI;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionAlarmasPLD definicionAlarmasPLD;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionCambioDatoPLD definicionCambioDatoPLD;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionAlarmasIMO definicionAlarmasIMO;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ControlNuevaDefinicionCambioDatoIMO definicionCambioDatoIMO;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSDetalleIMO
        /// </summary>
        /// <param name="control"></param>
        public OGSDetalleIMO(object control)
            : base()
        {
            this.control = (OrbitaGSDetalleIMO)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleIMO
        /// </summary>
        internal OrbitaGSDetalleIMO Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o estable si pctPermutar es visible o no
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool MostrarPermutar
        {
            get
            {
                return this.control.pctPermutar.Visible;
            }
            set
            {
                this.control.pctPermutar.Visible = value;
            }
        }
        Bitmap _ImagenPermutar = Properties.Resources.PermutarADR_16x16;
        /// <summary>
        /// Obtiene la imagen a mostrar en pctPermutar
        /// </summary>
        public Bitmap ImagenPermutar
        {
            get
            {
                return this._ImagenPermutar;
            }
            set
            {
                this._ImagenPermutar = value;
            }
        }
        Bitmap _ImagenPresenciaOK = Properties.Resources.PresenciaOK_16x16;
        /// <summary>
        /// Obtiene la imagen a mostrar en las presencias laterales derecha e izquierda cuando han sido encontradas
        /// </summary>
        public Bitmap ImagenPresenciaOK
        {
            get
            {
                return this._ImagenPresenciaOK;
            }
            set
            {
                this._ImagenPresenciaOK = value;
            }
        }
        Bitmap _ImagenPresenciaNOK = Properties.Resources.PresenciaNOK_16x16;
        /// <summary>
        /// Obtiene la imagen a mostrar en las presencias laterales derecha e izquierda cuando NO han sido encontradas
        /// </summary>
        public Bitmap ImagenPresenciaNOK
        {
            get
            {
                return this._ImagenPresenciaNOK;
            }
            set
            {
                this._ImagenPresenciaNOK = value;
            }
        }
        /// <summary>
        /// Obtiene o establece si bRecodificarPresencia está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarRecodificarPresencia
        {
            get { return this.control.bRecodificarPresencia.Enabled; }
            set { this.control.bRecodificarPresencia.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bIgnorarPresencia está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarIgnorarPresencia
        {
            get { return this.control.bIgnorarPresencia.Enabled; }
            set { this.control.bIgnorarPresencia.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bRecodificarIMO está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarRecodificarIMO
        {
            get { return this.control.bRecodificarIMO.Enabled; }
            set { this.control.bRecodificarIMO.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bIgnorarPresencia está habilitado o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarCancelarIMO
        {
            get { return this.control.bCancelarIMO.Enabled; }
            set { this.control.bCancelarIMO.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasPLI AlarmasPLI
        {
            get { return this.definicionAlarmasPLI; }
            set { this.definicionAlarmasPLI = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoPLI CambioDatoPLI
        {
            get { return this.definicionCambioDatoPLI; }
            set { this.definicionCambioDatoPLI = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasPLD AlarmasPLD
        {
            get { return this.definicionAlarmasPLD; }
            set { this.definicionAlarmasPLD = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoPLD CambioDatoPLD
        {
            get { return this.definicionCambioDatoPLD; }
            set { this.definicionCambioDatoPLD = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasIMO AlarmasIMO
        {
            get { return this.definicionAlarmasIMO; }
            set { this.definicionAlarmasIMO = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoIMO CambioDatoIMO
        {
            get { return this.definicionCambioDatoIMO; }
            set { this.definicionCambioDatoIMO = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmasPLI == null)
            {
                this.definicionAlarmasPLI = new ControlNuevaDefinicionAlarmasPLI(this, this.control.pctInspeccionPLI, this.control.pctRecodPLI);
            }
            if (this.definicionCambioDatoPLI == null)
            {
                this.definicionCambioDatoPLI = new ControlNuevaDefinicionCambioDatoPLI(this, this.control.pctInspeccionPLI, this.control.pctRecodPLI);
            }
            if (this.definicionAlarmasPLD == null)
            {
                this.definicionAlarmasPLD = new ControlNuevaDefinicionAlarmasPLD(this, this.control.pctInspeccionPLD, this.control.pctRecodPLD);
            }
            if (this.definicionCambioDatoPLD == null)
            {
                this.definicionCambioDatoPLD = new ControlNuevaDefinicionCambioDatoPLD(this, this.control.pctInspeccionPLD, this.control.pctRecodPLD);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
            if (this.definicionCambioDatoIMO == null)
            {
                this.definicionCambioDatoIMO = new ControlNuevaDefinicionCambioDatoIMO(this, this.control.lblInspeccionIMO, this.control.lblRecodIMO, this.control.lblRecodTOSIMO, this.control.lblFiabilidadIMO);
            }
            if (this.definicionAlarmasIMO == null)
            {
                this.definicionAlarmasIMO = new ControlNuevaDefinicionAlarmasIMO(this, this.control.lblInspeccionIMO, this.control.lblRecodIMO, this.control.lblRecodTOSIMO, this.control.lblFiabilidadIMO);
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase de las propiedades de Comunicacion de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionIMO
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionIMO
        /// </summary>
        OGSDetalleIMO control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionIMO
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionIMO(object control)
            : base()
        {
            this.control = (OGSDetalleIMO)control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionIMO
        /// </summary>
        internal OGSDetalleIMO Control
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
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLD).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLI).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLD).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLI).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctPermutar).OI.Comunicacion.IdDispositivo = value;
            }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLD).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLI).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLD).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLI).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctPermutar).OI.Comunicacion.NombreCanal = value;

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
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLD).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLI).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLD).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLI).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctPermutar).OI.Comunicacion.Pintar = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLD).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLI).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLD).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLI).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctPermutar).OI.Comunicacion.ColorFondoComunica = value;

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
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLD).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctInspeccionPLI).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLD).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctRecodPLI).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadIMO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.pctPermutar).OI.Comunicacion.ColorFondoNoComunica = value;
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
