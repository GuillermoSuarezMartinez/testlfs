using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Drawing;
using Orbita.Utiles;
using Orbita.Comunicaciones;
using Orbita.Trazabilidad;
using Orbita.VA.Comun;
using Orbita.Controles.Comunicaciones;

namespace Orbita.Controles.GateSuite
{
    /// <summary>
    /// Control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO asociado a los eventos de comunicaciones
    /// </summary>
    public partial class OrbitaGSDetalleIMO : OrbitaControlBaseEventosComs
    {
        /// <summary>
        /// Clase de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        public new class ControlNuevaDefinicion : OGSDetalleIMO
        {
            public ControlNuevaDefinicion(OrbitaGSDetalleIMO sender)
                : base(sender) { }
        };

        #region Atributos
        /// <summary>
        /// Definición de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        new ControlNuevaDefinicion definicion;
        /// <summary>
        /// Logger del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        ILogger Logger = LogManager.GetLogger("OrbitaGSDetalleIMO");
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado para el cambio de dato del pctInspeccionPLI del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionPLI(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del pctInspeccionPLI del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionPLI(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del pctInspeccionPLI del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionPLI(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del pctRecodPLI del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodPLI(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del pctRecodPLI del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodPLI(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del pctRecodPLI del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodPLI(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del pctInspeccionPLD del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionPLD(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del pctInspeccionPLD del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionPLD(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del pctInspeccionPLD del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionPLD(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del pctRecodPLD del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodPLD(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del pctRecodPLD del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodPLD(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del pctRecodPLD del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodPLD(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el click del bRecodificarPresencia del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoRecodificarClickPresencia(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bIgnorarPresencia del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoIgnorarClickPresencia(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoInspeccionIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaInspeccionIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblInspeccionIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionInspeccionIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblRecodTOSIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoRecodTOSIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblRecodTOSIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaRecodTOSIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblRecodTOSIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionRecodTOSIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del lblFiabilidadIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoFiabilidadIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del lblFiabilidadIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaFiabilidadIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del lblFiabilidadIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionFiabilidadIMO(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el click del bRecodificarIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoRecodificarClickIMO(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el click del bCancelarIMO del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCancelarClickIMO(object sender, EventArgs e);
        /// <summary>
        /// Delegado para el cambio de dato del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoCambioDatoPermutar(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Alarma del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoAlarmaPermutar(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para la Comunicacion del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoComunicacionPermutar(object sender, OEventArgs e);
        /// <summary>
        /// Delegado para el click del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoPermutarClick(object sender, EventArgs e);
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
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
        public OrbitaGSDetalleIMO()
        {
            InitializeComponent();
            this.InitializeAttributes();
        }
        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de pctInspeccionPLI de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionPLI OnCambioDatoInspeccionPLI;
        /// <summary>
        /// Evento que se lanza con la alarma de pctInspeccionPLI de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionPLI OnAlarmaInspeccionPLI;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de pctInspeccionPLI de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionPLI OnComunicacionInspeccionPLI;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de pctRecodPLI de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodPLI OnCambioDatoRecodPLI;
        /// <summary>
        /// Evento que se lanza con la alarma de pctRecodPLI de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodPLI OnAlarmaRecodPLI;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de pctRecodPLI de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodPLI OnComunicacionRecodPLI;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de pctInspeccionPLD de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionPLD OnCambioDatoInspeccionPLD;
        /// <summary>
        /// Evento que se lanza con la alarma de pctInspeccionPLD de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionPLD OnAlarmaInspeccionPLD;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de pctInspeccionPLD de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionPLD OnComunicacionInspeccionPLD;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de pctRecodPLD de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodPLD OnCambioDatoRecodPLD;
        /// <summary>
        /// Evento que se lanza con la alarma de pctRecodPLD de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodPLD OnAlarmaRecodPLD;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de pctRecodPLD de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodPLD OnComunicacionRecodPLD;
        /// <summary>
        /// Evento que se lanza en el click de bRecodificarPresencia 
        /// </summary>
        public event DelegadoRecodificarClickPresencia OnRecodificarClickPresencia;
        /// <summary>
        /// Evento que se lanza en el click de bIgnorarPresencia 
        /// </summary>
        public event DelegadoIgnorarClickPresencia OnIgnorarClickPresencia;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblInspeccionIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoInspeccionIMO OnCambioDatoInspeccionIMO;
        /// <summary>
        /// Evento que se lanza con la alarma de lblInspeccionIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaInspeccionIMO OnAlarmaInspeccionIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblInspeccionIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionInspeccionIMO OnComunicacionInspeccionIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodIMO OnCambioDatoRecodIMO;
        /// <summary>
        /// Evento que se lanza con la alarma de lblRecodIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodIMO OnAlarmaRecodIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodIMO OnComunicacionRecodIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblRecodTOSIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoRecodTOSIMO OnCambioDatoRecodTOSIMO;
        /// <summary>
        /// Evento que se lanza con la alarma de lblRecodTOSIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaRecodTOSIMO OnAlarmaRecodTOSIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblRecodTOSIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionRecodTOSIMO OnComunicacionRecodTOSIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de lblFiabilidadIMO de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoFiabilidadIMO OnCambioDatoFiabilidadIMO;
        /// <summary>
        /// Evento que se lanza con la alarma de lblFiabilidadIMO de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaFiabilidadIMO OnAlarmaFiabilidadIMO;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de lblFiabilidadIMO de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionFiabilidadIMO OnComunicacionFiabilidadIMO;
        /// <summary>
        /// Evento que se lanza en el click de bRecodificar IMO
        /// </summary>
        public event DelegadoRecodificarClickIMO OnRecodificarClickIMO;
        /// <summary>
        /// Evento que se lanza en el click de bCancelarIMO
        /// </summary>
        public event DelegadoCancelarClickIMO OnCancelarClickIMO;
        /// <summary>
        /// Evento que se lanza al Cambio de Dato de pctPermutar de una de las variables asociadas al Cambio
        /// </summary>
        public event DelegadoCambioDatoPermutar OnCambioDatoPermutar;
        /// <summary>
        /// Evento que se lanza con la alarma de pctPermutar de una de las variables asociadas a la Alarma
        /// </summary>
        public event DelegadoAlarmaPermutar OnAlarmaPermutar;
        /// <summary>
        /// Evento que se lanza con la Comunicacion de pctPermutar de una de las variables asociadas a la Comunicacion
        /// </summary>
        public event DelegadoComunicacionPermutar OnComunicacionPermutar;
        /// <summary>
        /// Evento que se lanza en el click de pctPermutar
        /// </summary>
        public event DelegadoPermutarClick OnPermutarClick;
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
                Logger.Error("Error en copiarToolStripMenuItem_Click de Orbita.Controles.GateSuite.OrbitaGSDetalleIMO", ex);
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
                Logger.Error("Error en cmsCopiar_Opening de Orbita.Controles.GateSuite.OrbitaGSDetalleIMO", ex);
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
                Logger.Error("Error en cmsCopiar_Closing de Orbita.Controles.GateSuite.OrbitaGSDetalleIMO", ex);
            }
        }
        #endregion

        #region Presencia
        /// <summary>
        /// Lanza el evento click de bRecodificar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bRecodificarPresencia_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnRecodificarClickPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnRecodificarClickPresencia.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bRecodificarPresencia_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bRecodificarPresencia_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bIgnorar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void bIgnorarPresencia_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnIgnorarClickPresencia != null)
                {
                    Delegate[] eventHandlers = this.OnIgnorarClickPresencia.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bIgnorarPresencia_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bIgnorarPresencia_Click");
            }
        }

        #region PLI
        #region Inspeccion
        /// <summary>
        /// Lanza el evento OnCambio del pctInspeccion del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void pctInspeccionPLI_OnCambioDato(object sender, Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoInspeccionPLI != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoInspeccionPLI.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLI_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLI_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del pctInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionPLI con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctInspeccionPLI_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaInspeccionPLI != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaInspeccionPLI.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLI_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLI_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del pctInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionPLI 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctInspeccionPLI_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionInspeccionPLI != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionInspeccionPLI.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLI_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLI_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del pctRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void pctRecodPLI_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodPLI != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodPLI.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLI_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLI_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del pctRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctRecodPLI_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodPLI != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodPLI.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLI_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLI_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del pctRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctRecodPLI_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodPLI != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodPLI.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLI_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLI_OnComunicacion");
            }
        }
        #endregion
        #endregion
        #region PLD
        #region Inspeccion
        /// <summary>
        /// Lanza el evento OnCambio del pctInspeccion del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void pctInspeccionPLD_OnCambioDato(object sender, Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoInspeccionPLD != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoInspeccionPLD.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLD_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLD_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del pctInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionPLD con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctInspeccionPLD_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaInspeccionPLD != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaInspeccionPLD.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLD_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLD_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del pctInspeccion del control Orbita.Controles.GateSuite.OrbitaGSInspeccionPLD 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctInspeccionPLD_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionInspeccionPLD != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionInspeccionPLD.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLD_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctInspeccionPLD_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evanto OnCambio del pctRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void pctRecodPLD_OnCambioDato(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoRecodPLD != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoRecodPLD.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLD_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLD_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evanto OnAlarma del pctRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctRecodPLD_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaRecodPLD != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaRecodPLD.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLD_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLD_OnComunicacion");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del pctRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctRecodPLD_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionRecodPLD != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionRecodPLD.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLD_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctRecodPLD_OnComunicacion");
            }
        }
        #endregion
        #endregion
        #endregion

        #region IMO
        /// <summary>
        /// Lanza el evento click de bRecodificar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bRecodificarIMO_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnRecodificarClickIMO != null)
                {
                    Delegate[] eventHandlers = this.OnRecodificarClickIMO.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imIMOements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bRecodificarIMO_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bRecodificarIMO_Click");
            }
        }
        /// <summary>
        /// Lanza el evento click de bCancelar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void bCancelarIMO_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnCancelarClickIMO != null)
                {
                    Delegate[] eventHandlers = this.OnCancelarClickIMO.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imIMOements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bCancelarIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.bCancelarIMO_Click");
            }
        }

        #region Inspeccion
        /// <summary>
        /// Lanza el evento OnCambio del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblInspeccionIMO_OnCambioDato(object sender, Utiles.OEventArgs e)
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblInspeccionIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblInspeccionIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con la alarma de una de las variables asociadas a la Alarma.        
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblInspeccionIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblInspeccionIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblInspeccion del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO 
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblInspeccionIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblInspeccionIMO_OnComunicacion");
            }
        }
        #endregion
        #region Recod
        /// <summary>
        /// Lanza el evento OnCambio del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodIMO_OnCambioDato(object sender, Utiles.OEventArgs e)
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSRecodIMO con la alarma de una de las variables asociadas a la Alarma.        
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecod del control Orbita.Controles.GateSuite.OrbitaGSRecodIMO 
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodIMO_OnComunicacion");
            }
        }
        #endregion
        #region RecodTOS
        /// <summary>
        /// Lanza el evento OnCambio del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblRecodTOSIMO_OnCambioDato(object sender, Utiles.OEventArgs e)
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodTOSIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodTOSIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con la alarma de una de las variables asociadas a la Alarma.        
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodTOSIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodTOSIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblRecodTOS del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO 
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodTOSIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblRecodTOSIMO_OnComunicacion");
            }
        }
        #endregion
        #region Fiabilidad
        /// <summary>
        /// Lanza el evento OnCambio del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void lblFiabilidadIMO_OnCambioDato(object sender, Utiles.OEventArgs e)
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblFiabilidadIMO_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblFiabilidadIMO_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con la alarma de una de las variables asociadas a la Alarma.        
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblFiabilidadIMO_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblFiabilidadIMO_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del lblFiabilidad del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO 
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
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblFiabilidadIMO_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.lblFiabilidadIMO_OnComunicacion");
            }
        }
        #endregion
        #endregion

        #region Permutar
        /// <summary>
        /// Lanza el evento OnCambio del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con el cambio de dato de una de las variables asociadas al Cambio.        
        /// </summary>
        /// <param name="e"></param>
        private void pctPermutar_OnCambioDato(object sender, Utiles.OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnCambioDatoPermutar != null)
                {
                    Delegate[] eventHandlers = this.OnCambioDatoPermutar.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_OnCambioDato");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarCambioDato en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_OnCambioDato");
            }
        }
        /// <summary>
        /// Lanza el evento OnAlarma del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO con la alarma de una de las variables asociadas a la Alarma.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctPermutar_OnAlarma(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnAlarmaPermutar != null)
                {
                    Delegate[] eventHandlers = this.OnAlarmaPermutar.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_OnAlarma");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarAlarma en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_OnAlarma");
            }
        }
        /// <summary>
        /// Lanza el evento OnComunicacion del pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pctPermutar_OnComunicacion(object sender, OEventArgs e)
        {
            try
            {
                OInfoDato info = (OInfoDato)e.Argumento;

                // Lanzamos el evento de alarma 
                if (this.OnComunicacionPermutar != null)
                {
                    Delegate[] eventHandlers = this.OnComunicacionPermutar.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imPresenciaements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_OnComunicacion");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "ProcesarComunicacion en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_OnComunicacion");
            }
        }

        /// <summary>
        /// Lanza el evento click de pctPermutar del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void pctPermutar_Click(object sender, EventArgs e)
        {
            try
            {
                // Lanzamos el evento de alarma 
                if (this.OnPermutarClick != null)
                {
                    Delegate[] eventHandlers = this.OnPermutarClick.GetInvocationList();

                    foreach (Delegate d in eventHandlers)
                    {
                        try
                        {
                            // Check whether the target of the delegate imIMOements ISynchronizeInvoke (Winforms controls do), and see if a context-switch is required.
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
                            Logger.Error(ex, "Procesar en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_Click");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Procesar evento click en Orbita.Controles.GateSuite.OrbitaGSDetalleIMO.pctPermutar_Click");
            }
        }
        #endregion
        #endregion

        #region Métodos privados
        /// <summary>
        /// Inicializa los atributos de las propiedades del control Orbita.Controles.GateSuite.OrbitaGSDetalleIMO
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