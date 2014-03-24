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
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSInspeccionMatricula
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public class ControlNuevaDefinicionComunicacion : OGSComunicacionMatricula
        {
            public ControlNuevaDefinicionComunicacion(OGSInspeccionMatricula sender)
                : base(sender) { }
        };

        /// <summary>
        /// Clase de las propiedades de alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public class ControlNuevaDefinicionAlarmas : OGSAlarmasOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionAlarmas(OGSInspeccionMatricula sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        /// <summary>
        /// Clase de las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public class ControlNuevaDefinicionCambioDato : OGSCambioDatoOrbitaGSCompuesto
        {
            public ControlNuevaDefinicionCambioDato(OGSInspeccionMatricula sender, object inspeccion, object recod, object recodTOS, object fiabilidad)
                : base(sender, inspeccion, recod, recodTOS, fiabilidad) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionMatricula
        /// </summary>
        OrbitaGSInspeccionMatricula control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ControlNuevaDefinicionComunicacion definicionComunicacion;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ControlNuevaDefinicionAlarmas definicionAlarmas;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ControlNuevaDefinicionCambioDato definicionCambioDato;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSInspeccionMatricula
        /// </summary>
        /// <param name="control"></param>
        public OGSInspeccionMatricula(object control)
            : base()
        {
            this.control = (OrbitaGSInspeccionMatricula)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSInspeccionMatricula
        /// </summary>
        internal OrbitaGSInspeccionMatricula Control
        {
            get { return this.control; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicacion Comunicacion
        {
            get { return this.definicionComunicacion; }
            set { this.definicionComunicacion = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de Alarmas del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionAlarmas Alarmas
        {
            get { return this.definicionAlarmas; }
            set { this.definicionAlarmas = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades de CambioDato del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
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
