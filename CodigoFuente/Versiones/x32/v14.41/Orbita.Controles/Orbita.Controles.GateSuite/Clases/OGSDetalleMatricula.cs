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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSDetalleMatricula
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionMatricula
        {
            public ControlNuevaDefinicionComunicacion(OGSDetalleMatricula sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        public class ControlNuevaDefinicionAlarmas : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmas(OGSDetalleMatricula sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        public class ControlNuevaDefinicionCambioDato : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDato(OGSDetalleMatricula sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleMatricula
        /// </summary>
        OrbitaGSDetalleMatricula control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        ControlNuevaDefinicionAlarmas definicionAlarmas;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        ControlNuevaDefinicionCambioDato definicionCambioDato;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSDetalleMatricula
        /// </summary>
        /// <param name="control"></param>
        public OGSDetalleMatricula(object control)
            : base()
        {
            this.control = (OrbitaGSDetalleMatricula)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSDetalleMatricula
        /// </summary>
        internal OrbitaGSDetalleMatricula Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece si bRecodificarMatricula es visible o no del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
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
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmas Alarmas
        {
            get { return this.definicionAlarmas; }
            set { this.definicionAlarmas = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDato CambioDato
        {
            get { return this.definicionCambioDato; }
            set { this.definicionCambioDato = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSDetalleMatricula
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionAlarmas == null)
            {
                this.definicionAlarmas = new ControlNuevaDefinicionAlarmas(this, this.control.lblInspeccionMatricula, this.control.lblRecodMatricula, this.control.lblRecodTOSMatricula, this.control.lblFiabilidadMatricula);
            }
            if (this.definicionCambioDato == null)
            {
                this.definicionCambioDato = new ControlNuevaDefinicionCambioDato(this, this.control.lblInspeccionMatricula, this.control.lblRecodMatricula, this.control.lblRecodTOSMatricula, this.control.lblFiabilidadMatricula);
            }
            if (this.definicionComunicacion == null)
            {
                this.definicionComunicacion = new ControlNuevaDefinicionComunicacion(this);
            }
        }
        #endregion
    }

}
