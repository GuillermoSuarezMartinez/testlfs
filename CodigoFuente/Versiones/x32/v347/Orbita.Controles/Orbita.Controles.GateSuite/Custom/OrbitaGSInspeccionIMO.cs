using System;
using System.ComponentModel;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO asociado a los eventos de comunicaciones
    /// </summary>
    public partial class OrbitaGSInspeccionIMO : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        public new class ControlNuevaDefinicion : OGSInspeccionIMO
        {
            public ControlNuevaDefinicion(OrbitaGSInspeccionIMO sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSInspeccionIMO");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodTOSIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodTOSIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblFiabilidadPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoFiabilidadIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblInspeccionPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionPresencia(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodPresencia(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodTOSIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodTOSIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblFiabilidadISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionISO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaFiabilidadIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblInspeccionPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionPresencia(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodPresencia(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodTOSIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodTOSIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblFiabilidadIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionFiabilidadIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblInspeccionPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionPresencia(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodPresencia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodPresencia(object sender, OEventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
        /// </summary>
        [System.ComponentModel.Category("Gestión de controles")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        new public ControlNuevaDefinicion OI
        {
            get { return this.definicion; }
            set { this.definicion = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public OrbitaGSInspeccionIMO()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblInspeccionIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionIMO OnCambioDatoInspeccionIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodIMO OnCambioDatoRecodIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodTOSIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodTOSIMO OnCambioDatoRecodTOSIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblFiabilidadIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoFiabilidadIMO OnCambioDatoFiabilidadIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblInspeccionPresencia de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionPresencia OnCambioDatoInspeccionPresencia;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodPresencia de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodPresencia OnCambioDatoRecodPresencia;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblInspeccionIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionIMO OnAlarmaInspeccionIMO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodIMO OnAlarmaRecodIMO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodTOSIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodTOSIMO OnAlarmaRecodTOSIMO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblFiabilidadIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaFiabilidadIMO OnAlarmaFiabilidadIMO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblInspeccionPresencia de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionPresencia OnAlarmaInspeccionPresencia;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodPresencia de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodPresencia OnAlarmaRecodPresencia;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblInspeccionIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionIMO OnComunicacionInspeccionIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodIMO OnComunicacionRecodIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodTOSIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodTOSIMO OnComunicacionRecodTOSIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblFiabilidadIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionFiabilidadIMO OnComunicacionFiabilidadIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblInspeccionPresencia de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionPresencia OnComunicacionInspeccionPresencia;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodPresencia de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodPresencia OnComunicacionRecodPresencia;
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
                Logger.Error("Error en copiarToolStripMenuItem_Click de Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO", ex);
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
                Logger.Error("Error en cmsCopiar_Opening de Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO", ex);
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
                Logger.Error("Error en cmsCopiar_Closing de Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO", ex);
            }
        }
        #endregion
        #region IMO
        #region Inspección
        /// <summary>
        /// Lanza el evanto OnCambio del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblInspeccionIMO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoInspeccionIMO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoInspeccionIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionIMO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaInspeccionIMO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaInspeccionIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionIMO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionInspeccionIMO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionInspeccionIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionIMO_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodIMO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodIMO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodIMO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodIMO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodIMO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodIMO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodIMO_OnComunicacion");
            }
        }
        #endregion
        #region RecodTOS
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodTOSIMO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodTOSIMO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodTOSIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodTOSIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodTOSIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodTOSIMO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodTOSIMO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodTOSIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodTOSIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodTOSIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodTOSIMO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodTOSIMO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodTOSIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodTOSIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodTOSIMO_OnComunicacion");
            }
        }
        #endregion
        #region Fiabilidad
        /// <summary>
        /// Lanza el evanto OnCambio del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblFiabilidadIMO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoFiabilidadIMO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoFiabilidadIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblFiabilidadIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSFiabilidadIMO.lblFiabilidadIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiabilidadIMO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaFiabilidadIMO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaFiabilidadIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblFiabilidadIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblFiabilidadIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiabilidadIMO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionFiabilidadIMO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionFiabilidadIMO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblFiabilidadIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblFiabilidadIMO_OnComunicacion");
            }
        }
        #endregion
        #endregion
        #region Presencia
        #region Inspeccion
        /// <summary>
        /// Lanza el evanto OnCambio del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblInspeccionPresencia_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoInspeccionPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoInspeccionPresencia.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionPresencia_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionPresencia_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionPresencia_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaInspeccionPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaInspeccionPresencia.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionPresencia_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionPresencia_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionPresencia_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionInspeccionPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionInspeccionPresencia.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionPresencia_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblInspeccionPresencia_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodPresencia_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodPresencia.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodPresencia_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodPresencia_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodPresencia_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodPresencia.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodPresencia_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodPresencia_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodPresencia_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodPresencia.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodPresencia_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO.lblRecodPresencia_OnComunicacion");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionIMO
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
