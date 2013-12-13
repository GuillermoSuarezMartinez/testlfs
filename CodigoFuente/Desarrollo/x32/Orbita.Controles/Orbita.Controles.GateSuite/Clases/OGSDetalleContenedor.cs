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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSDetalleContenedor
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionContenedor
        {
            public ControlNuevaDefinicionComunicacion(OGSDetalleContenedor sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        public class ControlNuevaDefinicionAlarmasMatricula : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmasMatricula(OGSDetalleContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoMatricula : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDatoMatricula(OGSDetalleContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la ISO del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        public class ControlNuevaDefinicionAlarmasISO : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmasISO(OGSDetalleContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la ISO del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoISO : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDatoISO(OGSDetalleContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleContenedor
        /// </summary>
        OrbitaGSDetalleContenedor control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        ControlNuevaDefinicionAlarmasMatricula definicionAlarmasMatricula;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        ControlNuevaDefinicionCambioDatoMatricula definicionCambioDatoMatricula;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        ControlNuevaDefinicionAlarmasISO definicionAlarmasISO;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        ControlNuevaDefinicionCambioDatoISO definicionCambioDatoISO;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSDetalleContenedor
        /// </summary>
        /// <param name="control"></param>
        public OGSDetalleContenedor(object control)
            : base()
        {
            this.control = (OrbitaGSDetalleContenedor)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleContenedor
        /// </summary>
        internal OrbitaGSDetalleContenedor Control
        {
            get { return this.control; }
        }
        Bitmap _ImagenQuitarContenedor = Properties.Resources.QuitarContenedor_16x16;
        /// <summary>
        /// Obtiene la imagen a mostrar cuando hay que quitar un contenedor
        /// </summary>
        public Bitmap ImagenQuitarContenedor
        {
            get
            {
                return this._ImagenQuitarContenedor;
            }
            set
            {
                this._ImagenQuitarContenedor = value;
            }
        }
        Bitmap _ImagenPonerContenedor = Properties.Resources.AñadirContenedor_16x16;
        /// <summary>
        /// Obtiene la imagen a mostrar cuando hay que añadir un contenedor
        /// </summary>
        public Bitmap ImagenPonerContenedor
        {
            get
            {
                return this._ImagenPonerContenedor;
            }
            set
            {
                this._ImagenQuitarContenedor = value;
            }
        }
        /// <summary>
        /// Obtiene o establece si bRecodificarMatricula es visible o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarRecodificarMatricula
        {
            get { return this.control.bRecodificarMatricula.Enabled; }
            set { this.control.bRecodificarMatricula.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si bRecodificarISO es visible o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool HabilitarRecodificarISO
        {
            get { return this.control.bRecodificarISO.Enabled; }
            set { this.control.bRecodificarISO.Enabled = value; }
        }
        /// <summary>
        /// Obtiene o establece si pctQuitarPonerContenedor es visible o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue(false)]
        public bool MostrarQuitarPonerContenedor
        {
            get { return this.control.pctQuitarPonerContenedor.Visible; }
            set { this.control.pctQuitarPonerContenedor.Visible = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasMatricula AlarmasMatricula
        {
            get { return this.definicionAlarmasMatricula; }
            set { this.definicionAlarmasMatricula = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoMatricula CambioDatoMatricula
        {
            get { return this.definicionCambioDatoMatricula; }
            set { this.definicionCambioDatoMatricula = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasISO AlarmasISO
        {
            get { return this.definicionAlarmasISO; }
            set { this.definicionAlarmasISO = value; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoISO CambioDatoISO
        {
            get { return this.definicionCambioDatoISO; }
            set { this.definicionCambioDatoISO = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleContenedor
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmasMatricula == null)
            {
                this.definicionAlarmasMatricula = new ControlNuevaDefinicionAlarmasMatricula(this, this.control.lblInspeccionMatricula, this.control.lblRecodMatricula, this.control.lblRecodTOSMatricula, this.control.lblFiabilidadMatricula);
            }
            if (this.definicionCambioDatoMatricula == null)
            {
                this.definicionCambioDatoMatricula = new ControlNuevaDefinicionCambioDatoMatricula(this, this.control.lblInspeccionMatricula, this.control.lblRecodMatricula, this.control.lblRecodTOSMatricula, this.control.lblFiabilidadMatricula);
            }
            if (this.definicionAlarmasISO == null)
            {
                this.definicionAlarmasISO = new ControlNuevaDefinicionAlarmasISO(this, this.control.lblInspeccionISO, this.control.lblRecodISO, this.control.lblRecodTOSISO, this.control.lblFiabilidadISO);
            }
            if (this.definicionCambioDatoISO == null)
            {
                this.definicionCambioDatoISO = new ControlNuevaDefinicionCambioDatoISO(this, this.control.lblInspeccionISO, this.control.lblRecodISO, this.control.lblRecodTOSISO, this.control.lblFiabilidadISO);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

}
