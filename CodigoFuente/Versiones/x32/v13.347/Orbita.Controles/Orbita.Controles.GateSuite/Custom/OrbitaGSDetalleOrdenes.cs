using System;
using System.ComponentModel;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    public partial class OrbitaGSDetalleOrdenes : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        public new class ControlNuevaDefinicion : OGSDetalleOrdenes
        {
            public ControlNuevaDefinicion(OrbitaGSDetalleOrdenes sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSDetalleOrdenes");
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        new public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden1(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden2(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden3(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden4(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden5 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden5(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden6 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden6(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden7 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden7(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden8 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden8(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden1(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden2(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden3(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden4(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden5 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden5(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden6 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden6(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden7 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden7(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden8 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden8(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden1(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden2(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden3(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden4(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden5 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden5(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden6 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden6(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden7 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden7(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblOrden8 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden8(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden1 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden1(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden2 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden2(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden3 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden3(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden4 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden4(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden5 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden5(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden6 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden6(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden7 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden7(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCorregirOrden8 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCorregirClickOrden8(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden1 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden1(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden2 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden2(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden3 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden3(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden4 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden4(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden5 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden5(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden6 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden6(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden7 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden7(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bEliminarOrden8 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminarClickOrden8(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden1 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden1(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden2 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden2(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden3 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden3(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden4 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden4(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden5 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden5(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden6 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden6(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden7 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden7(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bAgregarOrden8 del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAgregarClickOrden8(object sender, EventArgs e);
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public OrbitaGSDetalleOrdenes()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden1 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden1 OnCambioDatoOrden1;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden2 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden2 OnCambioDatoOrden2;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden3 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden3 OnCambioDatoOrden3;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden4 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden4 OnCambioDatoOrden4;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden5 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden5 OnCambioDatoOrden5;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden6 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden6 OnCambioDatoOrden6;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden7 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden7 OnCambioDatoOrden7;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblOrden8 de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoOrden8 OnCambioDatoOrden8;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden1 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden1 OnAlarmaOrden1;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden2 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden2 OnAlarmaOrden2;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden3 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden3 OnAlarmaOrden3;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden4 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden4 OnAlarmaOrden4;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden5 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden5 OnAlarmaOrden5;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden6 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden6 OnAlarmaOrden6;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden7 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden7 OnAlarmaOrden7;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblOrden8 de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaOrden8 OnAlarmaOrden8;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden1 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden1 OnComunicacionOrden1;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden2 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden2 OnComunicacionOrden2;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden3 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden3 OnComunicacionOrden3;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden4 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden4 OnComunicacionOrden4;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden5 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden5 OnComunicacionOrden5;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden6 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden6 OnComunicacionOrden6;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden7 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden7 OnComunicacionOrden7;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblOrden8 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden8 OnComunicacionOrden8;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden1 OnCorregirClickOrden1;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden2 OnCorregirClickOrden2;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden3 OnCorregirClickOrden3;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden4 OnCorregirClickOrden4;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden5 OnCorregirClickOrden5;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden6 OnCorregirClickOrden6;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden7 OnCorregirClickOrden7;
        /// <summary>
        /// Evento que se lanza en el click de bCorregir
        /// </summary>
        public event DelegadoCorregirClickOrden8 OnCorregirClickOrden8;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden1 OnEliminarClickOrden1;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden2 OnEliminarClickOrden2;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden3 OnEliminarClickOrden3;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden4 OnEliminarClickOrden4;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden5 OnEliminarClickOrden5;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden6 OnEliminarClickOrden6;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden7 OnEliminarClickOrden7;
        /// <summary>
        /// Evento que se lanza en el click de bEliminar
        /// </summary>
        public event DelegadoEliminarClickOrden8 OnEliminarClickOrden8;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden1 OnAgregarClickOrden1;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden2 OnAgregarClickOrden2;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden3 OnAgregarClickOrden3;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden4 OnAgregarClickOrden4;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden5 OnAgregarClickOrden5;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden6 OnAgregarClickOrden6;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden7 OnAgregarClickOrden7;
        /// <summary>
        /// Evento que se lanza en el click de bAgregar
        /// </summary>
        public event DelegadoAgregarClickOrden8 OnAgregarClickOrden8;
        #endregion

        #region Eventos
        #region ToolStrip
        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string textoCopiar = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl.Text;
                if (!string.IsNullOrEmpty(textoCopiar))
                {
                    Clipboard.SetText(textoCopiar);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error en copiarToolStripMenuItem_Click de Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes", ex);
            }
        }
        private void cmsCopiar_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                OrbitaGSLabel labelCopiar = (OrbitaGSLabel)((ContextMenuStrip)sender).SourceControl;
                labelCopiar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            catch (Exception ex)
            {
                Logger.Error("Error en cmsCopiar_Opening de Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes", ex);
            }
        }
        private void cmsCopiar_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            try
            {
                OrbitaGSLabel labelCopiar = (OrbitaGSLabel)((ContextMenuStrip)sender).SourceControl;
                labelCopiar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
            catch (Exception ex)
            {
                Logger.Error("Error en cmsCopiar_Closing de Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes", ex);
            }
        }
        #endregion

        #region Orden1
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden1 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden1.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden1_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden1_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden1 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden1.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden1_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden1_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden1 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden1.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden1_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden1_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden1_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden1 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden1.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden1_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden1_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden1_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden1 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden1.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden1_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden1_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden1_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden1 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden1.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden1_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden1_OnComunicacion");
            }
        }
        #endregion

        #region Orden2
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden2 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden2.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden2_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden2_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden2 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden2.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden2_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden2_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden2 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden2.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden2_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden2_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden2_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden2 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden2.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden2_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden2_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden2_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden2 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden2.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden2_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden2_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden2_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden2 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden2.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden2_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden2_OnComunicacion");
            }
        }
        #endregion

        #region Orden3
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden3 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden3.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden3_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden3_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden3 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden3.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden3_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden3_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden3 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden3.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden3_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden3_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden3_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden3 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden3.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden3_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden3_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden3_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden3 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden3.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden3_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden3_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden3_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden3 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden3.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden3_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden3_OnComunicacion");
            }
        }
        #endregion

        #region Orden4
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden4 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden4.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden4_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden4_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden4 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden4.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden4_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden4_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden4 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden4.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden4_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden4_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden4_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden4 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden4.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden4_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden4_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden4_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden4 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden4.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden4_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden4_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden4_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden4 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden4.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden4_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden4_OnComunicacion");
            }
        }
        #endregion

        #region Orden5
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden5_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden5 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden5.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden5_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden5_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden5_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden5 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden5.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden5_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden5_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden5_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden5 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden5.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden5_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden5_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden5_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden5 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden5.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden5_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden5_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden5_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden5 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden5.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden5_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden5_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden5_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden5 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden5.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden5_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden5_OnComunicacion");
            }
        }
        #endregion

        #region Orden6
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden6_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden6 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden6.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden6_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden6_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden6_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden6 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden6.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden6_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden6_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden6_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden6 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden6.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden6_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden6_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden6_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden6 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden6.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden6_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden6_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden6_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden6 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden6.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden6_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden6_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden6_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden6 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden6.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden6_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden6_OnComunicacion");
            }
        }
        #endregion

        #region Orden7
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden7_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden7 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden7.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden7_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden7_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden7_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden7 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden7.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden7_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden7_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden7_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden7 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden7.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden7_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden7_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden7_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden7 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden7.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden7_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden7_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden7_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden7 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden7.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden7_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden7_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden7_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden7 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden7.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden7_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden7_OnComunicacion");
            }
        }
        #endregion

        #region Orden8
        /// <summary>
        /// Lanza el evento click de bCorregirOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCorregirOrden8_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCorregirClickOrden8 != null)
                {
                    Delegate[] eventHandlers = this.OnCorregirClickOrden8.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden8_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bCorregirOrden8_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bEliminarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bEliminarOrden8_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnEliminarClickOrden8 != null)
                {
                    Delegate[] eventHandlers = this.OnEliminarClickOrden8.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden8_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bEliminarOrden8_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bAgregarOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bAgregarOrden8_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnAgregarClickOrden8 != null)
                {
                    Delegate[] eventHandlers = this.OnAgregarClickOrden8.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new EventArgs() });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new EventArgs() });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden8_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.bAgregarOrden8_Click");
            }
        }

        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden8_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaOrden8 != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaOrden8.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden8_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden8_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evanto OnCambio del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblOrden8_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoOrden8 != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoOrden8.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden8_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden8_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOrden8_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionOrden8 != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionOrden8.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate implements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
                            ISynchronizeInvoke target = d.Target as ISynchronizeInvoke;
                            if (target != null && target.InvokeRequired)
                            {
                                target.Invoke(d, new object[] { this, new OEventArgs(e.Argumento) });
                            }
                            else
                            {
                                d.DynamicInvoke(new object[] { this, new OEventArgs(e.Argumento) });
                            }
                        }
                        catch (System.InvalidOperationException)
                        {
                            // No hacemos nada ante este error.
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden8_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes.lblOrden8_OnComunicacion");
            }
        }
        #endregion

        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleOrdenes
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        #endregion
    }
}