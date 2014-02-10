using System;
using System.ComponentModel;
using System.Drawing;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Control Orbita.Controles.GateSuite.OrbitaGSTextBox asociado a los eventos de comunicaciones
    /// </summary>
    public partial class OrbitaGSTextBox : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        public new class ControlNuevaDefinicion : OGSTextBox
        {
            public ControlNuevaDefinicion(OrbitaGSTextBox sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSTextBox");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de valor de la propiedad .Text del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        /// <param name="valor">valor de la propiedad .Text</param>
        internal delegate void DelegadoValor(string valor);
        /// <summary>
        /// Delegado para el cambio de color de la propiedad .BackColor del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        /// <param name="color">color de la propiedad .BackColor</param>
        internal delegate void DelegadoColor(Color color);
        /// <summary>
        /// Delegado para el cambio de dato del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDato(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la alarma del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarma(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la comunicación del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacion(object sender, OEventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSTextBox
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
        /// Inicializa una nueva instancia del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        public OrbitaGSTextBox()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDato OnCambioDato;
        /// <summary>
        /// Evento que se lanza con la alarma de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarma OnAlarma;
        /// <summary>
        /// Evento que se lanza con la comunicación del canal
        /// </summary>
        public event DelegadoComunicacion OnComunicacion;
        #endregion

        #region Eventos
        /// <summary>
        /// Cambia la propiedad .BackColor  y lanza el evento OnAlarma del control Orbita.Controles.GateSuite.OrbitaGSTextBox al lanzarse una alarma asociada a Alarmas      
        /// </summary>
        /// <param name="e"></param>
        public override void ProcesarAlarma(Orbita.Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;
                if (info.Valor.ToString().ToLower() == "true" || info.Valor.ToString() == "1")
                {
                    if (this.OI.Comunicaciones.Alarmas.Pintar)
                        this.CambiarFondoAlarma(this.OI.Comunicaciones.Alarmas.ColorFondoAlarma);
                }
                else
                {
                    if (this.OI.Comunicaciones.Alarmas.Pintar)
                        this.CambiarFondoAlarma(this.OI.Comunicaciones.Alarmas.ColorFondoNoAlarma);
                }
                // Lanzamos el evento de alarma 
                if (this.OnAlarma != null)
                {

                    Delegate[] eventHandlers = this.OnAlarma.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSTextBox");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSTextBox");
            }
        }
        /// <summary>
        /// Cambia la propiedad .BackColor y lanza el evento de comunicación del control Orbita.Controles.GateSuite.OrbitaGSTextBox dependiendo de si se comunica o no con el Servidor de Comunicaciones      
        /// </summary>
        /// <param name="e"></param>
        public override void ProcesarComunicaciones(Orbita.Utiles.OEventArgs e)
        {
            try
            {
                OEstadoComms estado = (OEstadoComms)e.Argumento;
                if (estado.Estado.ToLower() != "ok")
                {
                    if (this.OI.Comunicaciones.Comunicacion.Pintar)
                        this.CambiarFondoComunicaciones(this.OI.Comunicaciones.Comunicacion.ColorFondoComunica);
                }
                else
                {
                    if (this.OI.Comunicaciones.Comunicacion.Pintar)
                        this.CambiarFondoComunicaciones(this.OI.Comunicaciones.Comunicacion.ColorFondoNoComunica);
                }
                // Lanzamos el evento de comunicación 
                if (this.OnComunicacion != null)
                {

                    Delegate[] eventHandlers = this.OnComunicacion.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSTextBox");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicaciones en Orbita.Controles.GateSuite.OrbitaGSTextBox");
            }

        }
        /// <summary>
        /// Lanza el evanto OnCambio del control Orbita.Controles.GateSuite.OrbitaGSTextBox con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        public override void ProcesarCambioDato(Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDato != null)
                {

                    Delegate[] eventHandlers = this.OnCambioDato.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSTextBox");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSTextBox");
            }
        }
        /// <summary>
        /// Cambia la propiedad .Text del control Orbita.Controles.GateSuite.OrbitaGSTextBox con el cambio de dato de la variable asociada a Variable.        
        /// </summary>
        /// <param name="e"></param>        
        public override void ProcesarVariableVisual(Orbita.Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;
                this.CambiarValor(info.Valor.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarVariableVisual en Orbita.Controles.GateSuite.OrbitaGSTextBox");
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSTextBox
        /// </summary>
        void InitializeAttributes()
        {
            if (this.definicion == null)
            {
                this.definicion = new ControlNuevaDefinicion(this);
            }
        }

        /// <summary>
        /// Cambia la propiedad .BackColor del control Orbita.Controles.GateSuite.OrbitaGSTextBox ante una Alarma      
        /// </summary>
        /// <param name="color">color</param>
        private void CambiarFondoAlarma(Color color)
        {
            if (this.txtEventosComs.InvokeRequired)
            {
                DelegadoColor MyDelegado = new DelegadoColor(CambiarFondoAlarma);
                this.Invoke(MyDelegado, new object[] { color });
            }
            else
            {
                this.txtEventosComs.BackColor = color;
            }
        }
        /// <summary>
        /// Cambia la propiedad .BackColor del control Orbita.Controles.GateSuite.OrbitaGSTextBox ante un cambio de la comunicación con el Servidor de Comunicaciones       
        /// </summary>
        /// <param name="color">color</param>
        private void CambiarFondoComunicaciones(Color color)
        {
            if (this.txtEventosComs.InvokeRequired)
            {
                DelegadoColor MyDelegado = new DelegadoColor(CambiarFondoComunicaciones);
                this.Invoke(MyDelegado, new object[] { color });
            }
            else
            {
                this.txtEventosComs.BackColor = color;
            }
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Cambia el valor de la propiedad .Text del control Orbita.Controles.GateSuite.OrbitaGSTextBox ante el cambio de dato de la Variable
        /// </summary>
        /// <param name="valor"></param>
        public void CambiarValor(string valor)
        {
            if (this.txtEventosComs.InvokeRequired)
            {
                DelegadoValor MyDelegado = new DelegadoValor(CambiarValor);
                this.Invoke(MyDelegado, new object[] { valor });
            }
            else
            {
                this.txtEventosComs.Text = valor;
            }
        }
        #endregion
    }
}
