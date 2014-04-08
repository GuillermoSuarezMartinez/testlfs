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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSInspeccionContenedor
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionContenedor
        {
            public ControlNuevaDefinicionComunicacion(OGSInspeccionContenedor sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la matricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        public class ControlNuevaDefinicionAlarmasMatricula : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmasMatricula(OGSInspeccionContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la matricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoMatricula : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDatoMatricula(OGSInspeccionContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas de la ISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        public class ControlNuevaDefinicionAlarmasISO : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmasISO(OGSInspeccionContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato de la ISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        public class ControlNuevaDefinicionCambioDatoISO : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDatoISO(OGSInspeccionContenedor sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionMatricula
        /// </summary>
        OrbitaGSInspeccionContenedor control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        ControlNuevaDefinicionAlarmasMatricula definicionAlarmasMatricula;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        ControlNuevaDefinicionCambioDatoMatricula definicionCambioDatoMatricula;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        ControlNuevaDefinicionAlarmasISO definicionAlarmasISO;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        ControlNuevaDefinicionCambioDatoISO definicionCambioDatoISO;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSInspeccionMatricula
        /// </summary>
        /// <param name="control"></param>
        public OGSInspeccionContenedor(object control)
            : base()
        {
            this.control = (OrbitaGSInspeccionContenedor)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionMatricula
        /// </summary>
        internal OrbitaGSInspeccionContenedor Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasMatricula AlarmasMatricula
        {
            get { return this.definicionAlarmasMatricula; }
            set { this.definicionAlarmasMatricula = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionCambioDatoMatricula CambioDatoMatricula
        {
            get { return this.definicionCambioDatoMatricula; }
            set { this.definicionCambioDatoMatricula = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmasISO AlarmasISO
        {
            get { return this.definicionAlarmasISO; }
            set { this.definicionAlarmasISO = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
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
