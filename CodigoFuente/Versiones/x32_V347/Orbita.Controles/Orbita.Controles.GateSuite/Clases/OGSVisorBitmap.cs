using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Orbita.Controles.VA;
namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSVisorBitmap
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSVisorBitmap
    {
        /// <summary>
        /// Clase de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSVisorBitmap
        /// </summary>
        public class ControlNuevaDefinicionComunicaciones : OGSComunicaciones
        {
            public ControlNuevaDefinicionComunicaciones(OGSVisorBitmap sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSVisorBitmap
        /// </summary>
        OrbitaGSVisorBitmap control;
        /// <summary>
        /// Definición de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSVisorBitmap
        /// </summary>
        ControlNuevaDefinicionComunicaciones definicionComunicaciones;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSVisorBitmap
        /// </summary>
        /// <param name="control"></param>
        public OGSVisorBitmap(object control)
            : base()
        {
            this.control = (OrbitaGSVisorBitmap)control;
            this.InitializeAttributes();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase Orbita.Controles.GateSuite.OGSVisorBitmap
        /// </summary>
        internal OrbitaGSVisorBitmap Control
        {
            get { return this.control; }
        }
        /// <summary>
        /// Obtiene o establece las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSVisorBitmap
        /// </summary>
        [Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlNuevaDefinicionComunicaciones Comunicaciones
        {
            get { return this.definicionComunicaciones; }
            set { this.definicionComunicaciones = value; }
        }

        /// <summary>
        /// Obtiene o establece las propiedades del VisorBitmap del control Orbita.Controles.GateSuite.OrbitaGSVisorBitmap
        /// </summary>
        [System.ComponentModel.Description("")]
        public bool Zoom
        {
            get { return this.control.pctEventosComs.PermitirZoom; }
            set { this.control.pctEventosComs.PermitirZoom = value; }
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
        /// Inicializa los atributos de las propiedades de Comunicaciones del control Orbita.Controles.GateSuite.OrbitaGSVisorBitmap
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicionComunicaciones == null)
            {
                this.definicionComunicaciones = new ControlNuevaDefinicionComunicaciones(this);
            }
        }
        #endregion
    }
}
