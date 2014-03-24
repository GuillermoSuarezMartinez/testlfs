using System.ComponentModel;
using System.Drawing;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Clase de las propiedades comunes de Comunicacion de Comunicaciones para los controles compuestos con matrícula
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionMatricula
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionMatricula
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionMatricula
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionMatricula(object control)
            : base()
        {
            this.control = control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionMatricula
        /// </summary>
        internal dynamic Control
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.IdDispositivo = value;
            }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.NombreCanal = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.Pintar = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.ColorFondoComunica = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
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

    /// <summary>
    /// Clase de las propiedades comunes de Comunicacion de Comunicaciones para los controles compuestos con contenedor
    /// </summary>   
    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class OGSComunicacionContenedor
    {
        #region Atributos
        /// <summary>
        /// Control al que está asociada la clase Orbita.Controles.GateSuite.OGSComunicacionContenedor
        /// </summary>
        dynamic control;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase Orbita.Controles.GateSuite.OGSComunicacionContenedor
        /// </summary>
        /// <param name="control"></param>
        public OGSComunicacionContenedor(object control)
            : base()
        {
            this.control = control;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el control al que está asociada la clase OGSComunicacionContenedor
        /// </summary>
        internal dynamic Control
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionISO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodISO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSISO).OI.Comunicacion.IdDispositivo = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadISO).OI.Comunicacion.IdDispositivo = value;
            }
        }

        [Description("Nombre del canal del servidor de Comunicaciones")]
        public string NombreCanal
        {
            get { return ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal; }
            set
            {
                ((OrbitaControlBaseEventosComs)this.control.Control).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionISO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodISO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSISO).OI.Comunicacion.NombreCanal = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadISO).OI.Comunicacion.NombreCanal = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadISO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionISO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodISO).OI.Comunicacion.Pintar = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSISO).OI.Comunicacion.Pintar = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadISO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionISO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodISO).OI.Comunicacion.ColorFondoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSISO).OI.Comunicacion.ColorFondoComunica = value;
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
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSMatricula).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblFiabilidadISO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblInspeccionISO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodISO).OI.Comunicacion.ColorFondoNoComunica = value;
                ((OrbitaControlBaseEventosComs)this.control.Control.lblRecodTOSISO).OI.Comunicacion.ColorFondoNoComunica = value;

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
