using System;
using System.ComponentModel;
using System.Windows.Forms;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.Utiles;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    public partial class OrbitaGSInspeccionOrdenes : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        public new class ControlNuevaDefinicion : OGSInspeccionOrdenes
        {
            public ControlNuevaDefinicion(OrbitaGSInspeccionOrdenes sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSInspeccionOrdenes");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden1(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden2(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden3(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoOrden4(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden1(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden2(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden3(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaOrden4(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicación del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden1(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicación del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden2(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicación del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden3(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicación del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionOrden4(object sender, OEventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
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
        public OrbitaGSInspeccionOrdenes()
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
        public event DelegadoCambioDatoOrden3 OnCambioDatoOrden4;
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
        /// Evento que se lanza con la Comunicación de lblOrden1 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden1 OnComunicacionOrden1;
        /// <summary>
        /// Evento que se lanza con la Comunicación de lblOrden2 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden2 OnComunicacionOrden2;
        /// <summary>
        /// Evento que se lanza con la Comunicación de lblOrden3 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden3 OnComunicacionOrden3;
        /// <summary>
        /// Evento que se lanza con la Comunicación de lblOrden4 de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionOrden4 OnComunicacionOrden4;
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
                Logger.Error("Error en copiarToolStripMenuItem_Click de Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes", ex);
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
                Logger.Error("Error en cmsCopiar_Opening de Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes", ex);
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
                Logger.Error("Error en cmsCopiar_Closing de Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes", ex);
            }
        }
        #endregion
        #region Ordenes
        /// <summary>
        /// Lanza el evento OnCambio del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden1_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden1_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnCambio del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden2_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden2_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnCambio del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden3_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden3_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnCambio del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con el cambio de dato de una de las variables asociadas al Cambio.        
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden4_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSFiabilidadOrdenes.lblOrden4_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden1_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden1_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden2_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden2_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden3_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden3_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes con la alarma de una de las variables asociadas a la Alarma.        
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden4_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden4_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden1 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden1_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden1_OnComunicacion");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden2 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden2_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden2_OnComunicacion");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden3 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden3_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden3_OnComunicacion");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblOrden4 del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes 
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden4_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes.lblOrden4_OnComunicacion");
            }
        }
        #endregion
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSInspeccionOrdenes
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
