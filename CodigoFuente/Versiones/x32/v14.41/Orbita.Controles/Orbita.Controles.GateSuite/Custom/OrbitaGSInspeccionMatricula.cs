using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using System.Drawing;
using Orbita.Utiles;
using Orbita.Trazabilidad;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula asociado a los eventos de comunicaciones
    /// </summary>
    public partial class OrbitaGSInspeccionMatricula : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public new class ControlNuevaDefinicion : OGSInspeccionMatricula
        {
            public ControlNuevaDefinicion(OrbitaGSInspeccionMatricula sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSInspeccionMatricula");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodTOSMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoFiabilidadMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodTOSMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaFiabilidadMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodTOSMatricula(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionFiabilidadMatricula(object sender, OEventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
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
        /// Inicializa una nueva instancia del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
        /// </summary>
        public OrbitaGSInspeccionMatricula()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblInspeccion de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionMatricula OnCambioDatoInspeccionMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecod de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodMatricula OnCambioDatoRecodMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodTOS de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodTOSMatricula OnCambioDatoRecodTOSMatricula;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblFiabilidad de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoFiabilidadMatricula OnCambioDatoFiabilidadMatricula;
        /// <summary>
        /// Evento que se lanza con la alarma de lblInspeccion de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionMatricula OnAlarmaInspeccionMatricula;
        /// <summary>
        /// Evento que se lanza con la alarma de lblRecod de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodMatricula OnAlarmaRecodMatricula;
        /// <summary>
        /// Evento que se lanza con la alarma de lblRecodTOS de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodTOSMatricula OnAlarmaRecodTOSMatricula;
        /// <summary>
        /// Evento que se lanza con la alarma de lblFiabilidad de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaFiabilidadMatricula OnAlarmaFiabilidadMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblInspeccion de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionMatricula OnComunicacionInspeccionMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecod de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodMatricula OnComunicacionRecodMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodTOS de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodTOSMatricula OnComunicacionRecodTOSMatricula;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblFiabilidad de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionFiabilidadMatricula OnComunicacionFiabilidadMatricula;
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
                Logger.Error("Error en copiarToolStripMenuItem_Click de Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula", ex);
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
                Logger.Error("Error en cmsCopiar_Opening de Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula", ex);
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
                Logger.Error("Error en cmsCopiar_Closing de Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula", ex);
            }
        }
        #endregion

        #region Matricula
        #region Inspección
        /// <summary>
        /// Lanza el evento OnCambio del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblInspeccion_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblInspeccion_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblInspeccion_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblInspeccion_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblInspeccion_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblInspeccion_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecod_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecod_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecod_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecod_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecod_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecod_OnComunicacion");
            }
        }
        #endregion
        #region RecodTOS
        /// <summary>
        /// Lanza el evento OnCambio del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecodTOS_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecodTOS_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecodTOS_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecodTOS_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecodTOS_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblRecodTOS_OnComunicacion");
            }
        }

        #endregion
        #region Fiabilidad
        /// <summary>
        /// Lanza el evento OnCambio del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblFiabilidad_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblFiabilidad_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblFiabilidad_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblFiabilidad_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblFiabilidad_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula.lblFiabilidad_OnComunicacion");
            }
        }
        #endregion
        #endregion

        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionMatricula
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
