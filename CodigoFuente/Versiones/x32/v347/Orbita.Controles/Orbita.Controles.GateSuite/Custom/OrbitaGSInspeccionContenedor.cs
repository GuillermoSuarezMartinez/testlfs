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
    /// Control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor asociado a los eventos de comunicaciones
    /// </summary>
    public partial class OrbitaGSInspeccionContenedor : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        public new class ControlNuevaDefinicion : OGSInspeccionContenedor
        {
            public ControlNuevaDefinicion(OrbitaGSInspeccionContenedor sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSInspeccionContenedor");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del lblInspeccionMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodTOSMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodTOSMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblFiabilidadISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoFiabilidadMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblInspeccionISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodTOSISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodTOSISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblFiabilidadISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoFiabilidadISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblInspeccionMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodTOSMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodTOSMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblFiabilidadMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaFiabilidadMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblInspeccionISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodTOSISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodTOSISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblFiabilidadISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaFiabilidadISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblInspeccionMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodTOSMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodTOSMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblFiabilidadMatricula del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionFiabilidadMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblInspeccionISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodTOSISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodTOSISO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblFiabilidadISO del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionFiabilidadISO(object sender, OEventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
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
        public OrbitaGSInspeccionContenedor()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblInspeccionMatricula de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionMatricula OnCambioDatoInspeccionMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodMatricula de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodMatricula OnCambioDatoRecodMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodTOSMatricula de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodTOSMatricula OnCambioDatoRecodTOSMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblFiabilidadMatricula de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoFiabilidadMatricula OnCambioDatoFiabilidadMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblInspeccionISO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionISO OnCambioDatoInspeccionISO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodISO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodISO OnCambioDatoRecodISO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodTOSISO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodTOSISO OnCambioDatoRecodTOSISO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblFiabilidadISO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoFiabilidadISO OnCambioDatoFiabilidadISO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblInspeccionMatricula de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionMatricula OnAlarmaInspeccionMatricula;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodMatricula de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodMatricula OnAlarmaRecodMatricula;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodTOSMatricula de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodTOSMatricula OnAlarmaRecodTOSMatricula;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblFiabilidadMatricula de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaFiabilidadMatricula OnAlarmaFiabilidadMatricula;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblInspeccionISO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionISO OnAlarmaInspeccionISO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodISO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodISO OnAlarmaRecodISO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblRecodTOSISO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodTOSISO OnAlarmaRecodTOSISO;
        /// <summary>
        /// Evento que se lanza con la Alarma de lblFiabilidadISO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaFiabilidadISO OnAlarmaFiabilidadISO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblInspeccionMatricula de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionMatricula OnComunicacionInspeccionMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodMatricula de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodMatricula OnComunicacionRecodMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodTOSMatricula de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodTOSMatricula OnComunicacionRecodTOSMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblFiabilidadMatricula de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionFiabilidadMatricula OnComunicacionFiabilidadMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblInspeccionISO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionISO OnComunicacionInspeccionISO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodISO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodISO OnComunicacionRecodISO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodTOSISO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodTOSISO OnComunicacionRecodTOSISO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblFiabilidadISO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionFiabilidadISO OnComunicacionFiabilidadISO;
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
                Logger.Error("Error en copiarToolStripMenuItem_Click de Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor", ex);
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
                Logger.Error("Error en cmsCopiar_Opening de Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor", ex);
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
                Logger.Error("Error en cmsCopiar_Closing de Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor", ex);
            }
        }
        #endregion
        #region Matricula
        #region Inspeccion
        /// <summary>
        /// Lanza el evanto OnCambio del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblInspeccionMatricula_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoInspeccionMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoInspeccionMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionMatricula_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionMatricula_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionMatricula_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaInspeccionMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaInspeccionMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionMatricula_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionMatricula_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionMatricula_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionInspeccionMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionInspeccionMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionMatricula_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionMatricula_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodMatricula_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodMatricula_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodMatricula_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodMatricula_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodMatricula_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodMatricula_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodMatricula_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodMatricula_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodMatricula_OnComunicacion");
            }
        }
        #endregion
        #region RecodTOS
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodTOSMatricula_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodTOSMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodTOSMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSMatricula_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSMatricula_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodTOSMatricula_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodTOSMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodTOSMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSMatricula_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSMatricula_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodTOSMatricula_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodTOSMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodTOSMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSMatricula_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSMatricula_OnComunicacion");
            }
        }
        #endregion
        #region Fiabilidad
        /// <summary>
        /// Lanza el evanto OnCambio del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblFiabilidadMatricula_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoFiabilidadMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoFiabilidadMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadMatricula_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSFiabilidadMatricula.lblRecodTOSMatricula_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiabilidadMatricula_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaFiabilidadMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaFiabilidadMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadMatricula_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadMatricula_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiabilidadMatricula_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionFiabilidadMatricula != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionFiabilidadMatricula.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadMatricula_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadMatricula_OnComunicacion");
            }
        }
        #endregion
        #endregion
        #region ISO
        #region Inspeccion
        /// <summary>
        /// Lanza el evanto OnCambio del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblInspeccionISO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoInspeccionISO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoInspeccionISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionISO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionISO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionISO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaInspeccionISO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaInspeccionISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionISO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionISO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInspeccionISO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionInspeccionISO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionInspeccionISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionISO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblInspeccionISO_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodISO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodISO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodISO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodISO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodISO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodISO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodISO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodISO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodISO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodISO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodISO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodISO_OnComunicacion");
            }
        }
        #endregion
        #region RecodTOS
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodTOSISO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodTOSISO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodTOSISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSISO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSISO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodTOSISO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodTOSISO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodTOSISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSISO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSISO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblRecodTOSISO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodTOSISO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodTOSISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSISO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblRecodTOSISO_OnComunicacion");
            }
        }
        #endregion
        #region Fiabilidad
        /// <summary>
        /// Lanza el evanto OnCambio del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblFiabilidadISO_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoFiabilidadISO != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoFiabilidadISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadISO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSFiabilidadISO.lblFiabilidadISO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiabilidadISO_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaFiabilidadISO != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaFiabilidadISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadISO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadISO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFiabilidadISO_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionFiabilidadISO != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionFiabilidadISO.GetInvocationList();

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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadISO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor.lblFiabilidadISO_OnComunicacion");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionContenedor
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
