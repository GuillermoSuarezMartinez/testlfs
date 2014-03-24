using System;
using System.ComponentModel;
using Orbita.Comunicaciones;
using Orbita.Controles.Comunes;
using Orbita.Controles.GateSuite.Properties;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Control Orbita.Controles.GateSuite.OrbitaGSOrden
    /// </summary>
    public partial class OrbitaGSOrden : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        public new class ControlNuevaDefinicion : OGSOrden
        {
            public ControlNuevaDefinicion(OrbitaGSOrden sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSOrden");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDato(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la alarma del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarma(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la comunicación del canal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacion(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de código
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCodigoIntroducido(int identificadorOrden, OGSEnumModoOrden modo, string contenido);
        /// <summary>
        /// Delegado para la apertura del teclado
        /// </summary>
        public delegate void DelegadoTeclado(int identificadorOrden);
        /// <summary>
        /// Delegado para eliminar la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEliminaCodigo(int identificadorOrden);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        public OrbitaGSOrden()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }

        #endregion

        #region Manejardores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDato OnCambioDatoTextoOrden;
        /// <summary>
        /// Evento que se lanza en la alarma de una de las variables asociadas a la alarma
        /// </summary>
        public event DelegadoAlarma OnAlarmaTextoOrden;
        /// <summary>
        /// Evento que se lanza en la comunicación del canal
        /// </summary>
        public event DelegadoComunicacion OnComunicacionTextoOrden;

        [Category("GateSuite")]
        [Description("Se dispara cuando se introduce un código a una orden desde el teclado.")]
        [Browsable(true), DisplayName("OnCodigoIntroducido")]
        public event DelegadoCodigoIntroducido OnCodigoIntroducido;

        [Category("GateSuite")]
        [Description("Se dispara cuando se pulsa en el botón del teclado.")]
        [Browsable(true), DisplayName("OnTeclado")]
        public event DelegadoTeclado OnTeclado;

        [Category("GateSuite")]
        [Description("Se dispara cuando se elimina el código de una orden.")]
        [Browsable(true), DisplayName("OnEliminaCodigo")]
        public event DelegadoEliminaCodigo OnEliminaCodigo;
        #endregion

        #region Eventos
        /// <summary>
        /// Evento que se lanza con la Comunicación del canal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTextoOrden_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de Comunicacion 
                if (this.OnComunicacionTextoOrden != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionTextoOrden.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSOrden.lblTexto_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSOrden.lblTexto_OnComunicacion");
            }
        }
        /// <summary>
        /// Evento que se lanza con la alarma de alguna de las variables asociadas a la alarma en Orbita.Cotnroles.GateSuite.OrbitaGSOrden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTextoOrden_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaTextoOrden != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaTextoOrden.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSOrden.lblTexto_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSOrden.lblTexto_OnAlarma");
            }
        }
        /// <summary>
        /// Evento que se lanza en el cambio de dato de alguna de las variables asociadas al cambio de dato en Orbita.Cotnroles.GateSuite.OrbitaGSOrden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTextoOrden_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoTextoOrden != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoTextoOrden.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSOrden.lblTexto_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSOrden.lblTexto_OnCambioDato");
            }
        }
        /// <summary>
        /// Se lanza al presionar en el teclado o en eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lblBoton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.OI.OrdenVacia)
                {
                    if (this.OnTeclado != null)
                    {
                        this.OnTeclado(this.OI.IdentificadorOrden);
                    }
                }
                else
                {
                    this.lblPrecaucion.Visible = false;
                    ((OrbitaUltraLabel)sender).Appearance.ImageBackground = Resources.Teclado_72x72;
                    if (this.OnEliminaCodigo != null)
                    {
                        this.OnEliminaCodigo(this.OI.IdentificadorOrden);
                    }
                    this.VaciarOrden();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarClick en Orbita.Controles.GateSuite.OrbitaGSOrden.lblBoton_Click");
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSOrden
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// El código se lee desde el escaner
        /// </summary>
        public void CodigoEscaner(string cadenaTexto)
        {
            this.lblPrecaucion.Visible = false;
            this.OI.Contenido = cadenaTexto;
            this.OI.Modo = OGSEnumModoOrden.ModoEscaner;
            if (this.OnCodigoIntroducido != null)
            {
                this.OnCodigoIntroducido(this.OI.IdentificadorOrden, this.OI.Modo, this.OI.Contenido);
            }
        }

        /// <summary>
        /// Limpia la orden
        /// </summary>
        public void VaciarOrden()
        {
            this.OI.Modo = OGSEnumModoOrden.SinModo;
            this.OI.Contenido = string.Empty;
        }
        #endregion
    }
}
