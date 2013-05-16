using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using System.Printing;
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using Orbita.Utiles;
using StarMicronics.StarIO;
namespace Orbita.Controles.Comunicaciones
{
    public partial class OrbitaComponenteTup492 : Component, IImpresora
    {
        #region Constantes
        /// <summary>
        /// Nombre del puerto de impresora
        /// </summary>
        private const string NOMBRE_PUERTO_IMPRESORA = "USBPRN:Star TUP992 Raster Printer";
        /// <summary>
        /// Indica el nombre de la impresora
        /// </summary>
        private const string NOMBRE_IMPRESORA = "Star TUP992 Raster Printer";
        /// <summary>
        /// Configuracion del puerto. Vacia para USB
        /// </summary>
        private const string SETTINGS_PUERTO_IMPRESORA = "";
        #endregion

        #region Atributos
        /// <summary>
        /// Timer de comprobacion de la impresion
        /// </summary>
        private Timer timerComprobacionColaImpresion;
        /// <summary>
        /// Timer de comprobacion de los errores de la impresora
        /// </summary>
        private Timer timerComprobacionError;
        /// <summary>
        /// Puerto de comunicaciones con la impresora
        /// </summary>
        private static IPort puertoImpresora;
        /// <summary>
        /// Estado privado para la maquina de estados de la impresora
        /// </summary>
        private static EnumEstadosImpresora estadoImpresora = EnumEstadosImpresora.Inicial;
        /// <summary>
        /// Estado privado para la maquina de estados de la impresora
        /// </summary>
        private static EnumErrorImpresora errorImpresora = EnumErrorImpresora.NoError;
        /// <summary>
        /// Indica los documentos que quedan en la cola de impresion
        /// </summary>
        private static int iDocumentosRestantesEnCola;
        /// <summary>
        /// Indica la cantidad de documentos que se envian a imprimir en total
        /// </summary>
        private static int iTotalDocumentosImprimir;
        /// <summary>
        /// Indica el numero de documento que se esta imprimiendo
        /// </summary>
        private static int iActualDocumentosImprimir;
        /// <summary>
        /// Guarda los tickets que tiene que imprimir
        /// </summary>
        private static List<ReportDocument> ticketsImprimir;
        /// <summary>
        /// Se activa cuando terminamos de mandar los tickets a la impresora
        /// </summary>
        private static bool bFinMandarImprimir = false;
        /// <summary>
        /// Devulve los estados de la impresora
        /// </summary>
        private StarPrinterStatus StarPrinterStatus
        {
            get { return puertoImpresora.GetParsedStatus(); }

        }
        #endregion

        #region Propiedades
        [Description("Devulve si la impresora esta OnLine")]
        [Browsable(false), DisplayName("OIsOnline")]
        [DefaultValue(false)]
        public bool IsOnline
        {
            get { return puertoImpresora.GetOnlineStatus(); }
        }

        [Description("Devulve el total de documentos a imprimir")]
        [Browsable(false), DisplayName("ODocumentosImprimirTotal")]
        [DefaultValue(0)]
        public int DocumentosImprimirTotal
        {
            get { return iTotalDocumentosImprimir; }
        }
        /// <summary>
        /// Devuelve el numero de documento que esta imprimiendo
        /// </summary>
        [Description("Devuelve el número de documento que está imprimiendo")]
        [Browsable(false), DisplayName("ODocumentosImprimirActual")]
        [DefaultValue(0)]
        public int DocumentosImprimirActual
        {
            get { return iTotalDocumentosImprimir; }
        }
        #endregion

        #region Constructor/es
        public OrbitaComponenteTup492()
        {
            InitializeComponent();
        }
        public OrbitaComponenteTup492(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Destructor/es
        /// <summary>
        /// Dispose
        /// </summary>
        public void Destruir()
        {
            //Core.Logger.Info("Destruyendo ImpresoraTup992");

            if (timerComprobacionColaImpresion != null)
            {
                timerComprobacionColaImpresion.Change(Timeout.Infinite, Timeout.Infinite);
                timerComprobacionColaImpresion.Dispose();
                timerComprobacionColaImpresion = null;
            }
            if (timerComprobacionError != null)
            {
                timerComprobacionError.Change(Timeout.Infinite, Timeout.Infinite);
                timerComprobacionError.Dispose();
                timerComprobacionError = null;
            }

            puertoImpresora = null;

            if (ticketsImprimir != null)
            {
                ticketsImprimir.Clear();
                ticketsImprimir = null;
            }
        }
        #endregion

        #region Eventos públicos

        /// <summary>
        /// Evento que se lanza cuando inicia una nueva impresión
        /// </summary>
        [Category("Orbita"),
        Description("Se lanza al comenzar una nueva impresión.")]
        public event NuevaImpresionEventHandler OnNuevaImpresion;
        /// <summary>
        /// Evento que se lanza cuando finaliza la ultima impresión
        /// </summary>
        [Category("Orbita"),
        Description("Se lanza al finalizar la impresión.")]
        public event FinalizaImpresionEventHandler OnFinalizaImpresion;
        /// <summary>
        /// Evento que se lanza cuando hay un error de impresion
        /// </summary>
        [Category("Orbita"),
        Description("Se lanza se produce un error impresión.")]
        public event ErrorImpresionEventHandler OnErrorImpresion;
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Manda tickets a la impresora
        /// </summary>
        /// <param name="Tickets"></param>
        public void ImprimirTickets(List<ReportDocument> Tickets)
        {
            // Eliminamos la cola de impresion
            this.InvocarMetodoImpresion(EnumMetodosImpresion.BorrarCola);

            // Intentamos crear el driver de la impresora
            if (Tickets.Count > 0)
            {
                try
                {
                    // Creamos el puerto de la impresora
                    puertoImpresora = Factory.I.GetPort(NOMBRE_PUERTO_IMPRESORA, SETTINGS_PUERTO_IMPRESORA, 10000);
                    estadoImpresora = EnumEstadosImpresora.Inicial;
                }
                catch (Exception)
                {
                    //Core.Logger.Error(ex.ToString());
                    // Error al crear la impresora
                    puertoImpresora = null;
                    estadoImpresora = EnumEstadosImpresora.Error;
                }
                //Guardamos los tickets a imprimir (nos hacemos una copia de los tickets)
                ReportDocument[] ticketsAux = new ReportDocument[Tickets.Count];
                Tickets.CopyTo(ticketsAux);
                ticketsImprimir = new List<ReportDocument>(ticketsAux);

                //Core.Logger.Debug("Tickets a imprimir: " + Tickets.Count);
                //Core.Logger.Debug("Tickets copiados: " + ticketsImprimir.Count);

                // Iniciamos el timer de monitorizacion de la cola                 
                this.timerComprobacionColaImpresion = new Timer(OnTimerComprobacionColaImpresion, null, 0, 10);
                errorImpresora = EnumErrorImpresora.NoError;
                this.timerComprobacionError = new Timer(OnTimerComprobacionError, null, 0, 250);
                // Contamos los tickets a imprimir antes de imprimir
                iTotalDocumentosImprimir = ticketsImprimir.Count;

                // Creamos el hilo para mandar los documentos a imprimir
                bFinMandarImprimir = false;
                OHilo hiloImpresion = new OHilo(Imprimir, true);
                hiloImpresion.Iniciar();
            }
            else
            {
                //Core.Logger.Debug("Tickets a imprimir: " + Tickets.Count);
                estadoImpresora = EnumEstadosImpresora.Final;
                bFinMandarImprimir = true;
                // Lanzamos el evento de nueva impresion
                if (this.OnFinalizaImpresion != null)
                {
                    OnFinalizaImpresion(this, new ImpresoraEventArgs(iTotalDocumentosImprimir, iActualDocumentosImprimir, ticketsImprimir, errorImpresora));
                }
            }
        }
        #endregion

        #region Metodos privados
        /// <summary>
        /// Timer privado que refresca la cantidad de tuckets en la cola de impresion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerComprobacionColaImpresion(Object state)
        {
            try
            {
                // Detenemos el timer para que no se lance 2 veces
                this.timerComprobacionColaImpresion.Change(System.Threading.Timeout.Infinite, 0);
                // Obtenemos los documentos en la cola de impresion
                int iDocumentosEnColaImpresion = (new LocalPrintServer().DefaultPrintQueue).NumberOfJobs;

                switch (estadoImpresora)
                {
                    case EnumEstadosImpresora.Inicial:
                        try
                        {
                            if (iDocumentosEnColaImpresion == iTotalDocumentosImprimir)
                            {
                                // Inicialmente se imprime el numero 1
                                iActualDocumentosImprimir = 1;
                                // Actualizamos los restantes sacandolo de la cola
                                iDocumentosRestantesEnCola = iDocumentosEnColaImpresion;
                                estadoImpresora = EnumEstadosImpresora.Imprimiendo;

                                // Lanzamos el evento de nueva impresion
                                if (this.OnNuevaImpresion != null)
                                {
                                    OnNuevaImpresion(this, new ImpresoraEventArgs(iTotalDocumentosImprimir, iActualDocumentosImprimir, ticketsImprimir, errorImpresora));
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //Core.Logger.Error("EstadosImpresora.Inicial", ex);
                            estadoImpresora = EnumEstadosImpresora.Error;
                        }
                        break;
                    case EnumEstadosImpresora.Imprimiendo:
                        try
                        {
                            if (iDocumentosEnColaImpresion == iDocumentosRestantesEnCola - 1)
                            {
                                // Actualizamos estado (ha terminado la impresion)
                                estadoImpresora = EnumEstadosImpresora.Transicion;
                                // Eliminamos el primer ticket que es el que se ha impreso
                                ticketsImprimir.RemoveAt(0);
                            }
                        }
                        catch (Exception)
                        {
                            //Core.Logger.Error("EstadosImpresora.Imprimiendo", ex);
                            estadoImpresora = EnumEstadosImpresora.Error;
                        }
                        break;
                    case EnumEstadosImpresora.Transicion:
                        try
                        {
                            if (this.StarPrinterStatus.PresenterState == 3)
                            {
                                // Actualizamos estado (se ha estirado el ticket del presentador)
                                estadoImpresora = EnumEstadosImpresora.TicketFuera;
                            }
                        }
                        catch (Exception)
                        {
                            //Core.Logger.Error("EstadosImpresora.Transicion", ex);
                            estadoImpresora = EnumEstadosImpresora.Error;
                        }
                        break;
                    case EnumEstadosImpresora.TicketFuera:
                        try
                        {
                            if (this.StarPrinterStatus.PresenterState == 0)
                            {
                                // Actualizamos los documentos restantes
                                iDocumentosRestantesEnCola = iDocumentosEnColaImpresion;
                                if (iDocumentosRestantesEnCola == 0)
                                {
                                    iActualDocumentosImprimir = 0;
                                    // Si no quedan documentos que imprimir, hemos finalizado
                                    estadoImpresora = EnumEstadosImpresora.Final;
                                }
                                else
                                {
                                    // Reiniciamos la maquina e imprimiendo
                                    estadoImpresora = EnumEstadosImpresora.Imprimiendo;
                                    // Si quedan documentos, actualizamos la variable del documento que esta imprimiendo
                                    iActualDocumentosImprimir = iTotalDocumentosImprimir - iDocumentosRestantesEnCola + 1;

                                    // Lanzamos el evento de nueva impresion
                                    if (this.OnNuevaImpresion != null)
                                    {
                                        OnNuevaImpresion(this, new ImpresoraEventArgs(iTotalDocumentosImprimir, iActualDocumentosImprimir, ticketsImprimir, errorImpresora));
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //Core.Logger.Error("EstadosImpresora.TicketFuera", ex);
                            estadoImpresora = EnumEstadosImpresora.Error;
                        }
                        break;
                    case EnumEstadosImpresora.Final:
                        // Detenemos la ejecucion del timer
                        this.timerComprobacionColaImpresion.Change(Timeout.Infinite, Timeout.Infinite);

                        // Lanzamos el evento de nueva impresion
                        if (this.OnFinalizaImpresion != null)
                        {
                            OnFinalizaImpresion(this, new ImpresoraEventArgs(iTotalDocumentosImprimir, iActualDocumentosImprimir, ticketsImprimir, errorImpresora));
                        }
                        // Salimos de la comprobacion
                        return;
                    case EnumEstadosImpresora.Error:
                        // Detenemos la ejecucion del timer
                        this.timerComprobacionColaImpresion.Change(Timeout.Infinite, Timeout.Infinite);
                        // Esperamos a que se terminen de mandar los tickets a imprimir para lanzar el error
                        while (!bFinMandarImprimir)
                        {
                            Thread.Sleep(1);
                        }
                        // Borramos la cola de impresion
                        this.InvocarMetodoImpresion(EnumMetodosImpresion.BorrarCola);

                        // Lanzamos el evento de error de impresion
                        if (this.OnErrorImpresion != null)
                        {
                            OnErrorImpresion(this, new ImpresoraEventArgs(iTotalDocumentosImprimir, iActualDocumentosImprimir, ticketsImprimir, errorImpresora));
                        }
                        // Salimos de la comprobacion
                        return;
                }
                // Relanzamos el timer a los 10 milisegundos
                this.timerComprobacionColaImpresion.Change(10, 10);
            }
            catch (Exception)
            {
                //Core.Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Timer de comprobacion de errores
        /// </summary>
        /// <param name="state"></param>
        private void OnTimerComprobacionError(Object state)
        {
            try
            {
                // Parar el timer
                this.timerComprobacionError.Change(Timeout.Infinite, Timeout.Infinite);

                if ((new LocalPrintServer().DefaultPrintQueue).IsOffline)
                {
                    errorImpresora = EnumErrorImpresora.SinConexion;
                }
                if (this.StarPrinterStatus == null || this.StarPrinterStatus.Offline)
                {
                    errorImpresora = EnumErrorImpresora.SinConexion;
                }
                if (this.StarPrinterStatus.CoverOpen)
                {
                    errorImpresora = EnumErrorImpresora.TapaAbierta;
                }
                if (this.StarPrinterStatus.CutterError)
                {
                    errorImpresora = EnumErrorImpresora.CortadorAtascado;
                }
                if (this.StarPrinterStatus.PresenterPaperJamError)
                {
                    errorImpresora = EnumErrorImpresora.PapelAtascado;
                }
                if (this.StarPrinterStatus.ReceiptPaperEmpty)
                {
                    errorImpresora = EnumErrorImpresora.SinPapel;
                }
                if (errorImpresora == EnumErrorImpresora.NoError)
                {
                    if (this.StarPrinterStatus.ReceiptPaperNearEmptyInner)
                    {
                        errorImpresora = EnumErrorImpresora.CasiSinPapel;
                    }
                }
                else if (errorImpresora != EnumErrorImpresora.CasiSinPapel)
                {
                    estadoImpresora = EnumEstadosImpresora.Error;
                    this.timerComprobacionError.Change(Timeout.Infinite, Timeout.Infinite);
                    return;
                }
                // Reiniciar el timer
                this.timerComprobacionError.Change(250, 250);

            }
            catch (Exception)
            {
                //Core.Logger.Error(ex.ToString());
                errorImpresora = EnumErrorImpresora.SinConexion;
                estadoImpresora = EnumEstadosImpresora.Error;
                if (this.timerComprobacionError != null)
                {
                    this.timerComprobacionError.Change(Timeout.Infinite, Timeout.Infinite);
                }
            }
        }

        /// <summary>
        /// Eliminamos los trabajos de la cola de impresion
        /// </summary>
        public void InvocarMetodoImpresion(EnumMetodosImpresion nombreMetodo)
        {
            string query = @"Select * From Win32_Printer Where Name = '" + NOMBRE_IMPRESORA + "'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject printer in searcher.Get())
            {
                switch (nombreMetodo)
                {
                    case EnumMetodosImpresion.BorrarCola:
                        printer.InvokeMethod("CancelAllJobs", null);
                        break;
                    case EnumMetodosImpresion.Pausar:
                        printer.InvokeMethod("Pause", null);
                        break;
                    case EnumMetodosImpresion.Continuar:
                        printer.InvokeMethod("Resume", null);
                        break;
                    default:
                        throw new Exception("Metodo de impresion no soportado.");
                }
            }
        }

        /// <summary>
        /// Hilo encargado de mandar a imprimir los tickets
        /// </summary>
        public void Imprimir()
        {
            try
            {
                //Si tenemos acceso a la impresora mandamos los tickets.
                if (puertoImpresora != null)
                {
                    this.InvocarMetodoImpresion(EnumMetodosImpresion.Pausar);
                    foreach (ReportDocument ticket in ticketsImprimir)
                    {
                        // Mando a imprimir
                        ticket.PrintToPrinter(1, true, 1, 1);
                        //Core.Logger.Info("Termina de imprimir los tickets");
                    }
                    this.InvocarMetodoImpresion(EnumMetodosImpresion.Continuar);
                }
            }
            catch (Exception)
            {
                //Core.Logger.Error(ex.ToString());
            }
            finally
            {
                // Hemos finalizado de mandar tickets a la impresora
                bFinMandarImprimir = true;
            }
        }
        #endregion
    }

    /// <summary>
    /// Enumarado de la maquina de estados para controlar la impresion de tickets
    /// </summary>
    enum EnumEstadosImpresora
    {
        /// <summary>
        /// Estado en el que no se ha empezado a imprimir
        /// </summary>
        Inicial,
        /// <summary>
        /// Estado en el que esta imprimiendo ticket
        /// </summary>
        Imprimiendo,
        /// <summary>
        /// Estado en el que ha terminado de imprimir y sale por el presentador
        /// </summary>
        Transicion,
        /// <summary>
        /// Estado en el que el ticket se queda en el presentador
        /// </summary>
        TicketFuera,
        /// <summary>
        /// Fin de impresion de todos los tickets
        /// </summary>
        Final,
        /// <summary>
        /// Contempla el caso en el que tengamos un error en la impresora
        /// </summary>
        Error
    }
}