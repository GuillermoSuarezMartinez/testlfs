using System.Collections.Generic;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
namespace Orbita.Controles.Comunicaciones
{
    #region Delegados
    /// <summary>
    /// Delegado del evento NuevaImpresionEventHandler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NuevaImpresionEventHandler(object sender, ImpresoraEventArgs e);
    /// <summary>
    /// Delegado del evento FinalizaImpresionEventHandler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void FinalizaImpresionEventHandler(object sender, ImpresoraEventArgs e);
    /// <summary>
    /// Delegado del evento ErrorImpresionEventHandler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ErrorImpresionEventHandler(object sender, ImpresoraEventArgs e);
    #endregion

    /// <summary>
    /// Interfaz para las impresoras
    /// </summary>
    interface IImpresora
    {
        #region Propiedades
        /// <summary>
        /// Devulve el total de documentos a imprimir
        /// </summary>
        int DocumentosImprimirTotal
        {
            get;
        }
        /// <summary>
        /// Devuelve el numero de documento que esta imprimiendo
        /// </summary>
        int DocumentosImprimirActual
        {
            get;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Dispose
        /// </summary>
        void Destruir();
        #endregion

        #region Eventos públicos

        /// <summary>
        /// Evento que se lanza cuando inicia una nueva impresión
        /// </summary>
        [Category("Orbita"),
        Description("Se lanza al comenzar una nueva impresión.")]
        event NuevaImpresionEventHandler OnNuevaImpresion;
        /// <summary>
        /// Evento que se lanza cuando finaliza la ultima impresión
        /// </summary>
        [Category("Orbita"),
        Description("Se lanza al finalizar la impresión.")]
        event FinalizaImpresionEventHandler OnFinalizaImpresion;
        /// <summary>
        /// Evento que se lanza cuando hay un error de impresion
        /// </summary>
        [Category("Orbita"),
        Description("Se lanza se produce un error impresión.")]
        event ErrorImpresionEventHandler OnErrorImpresion;
        #endregion

        #region Metodos privados
        /// <summary>
        /// Eliminamos los trabajos de la cola de impresion
        /// </summary>
        void InvocarMetodoImpresion(EnumMetodosImpresion nombreMetodo);
        /// <summary>
        /// Manda tickets a la impresora
        /// </summary>
        /// <param name="Tickets"></param>
        void ImprimirTickets(List<ReportDocument> Tickets);
        #endregion
    }

    /// <summary>
    /// Argumentos de la impresora
    /// </summary>
    public class ImpresoraEventArgs
    {
        int _DocumentosTotales;
        int _DocumentosImpresos;
        List<ReportDocument> _TicketsNoImpresos;
        EnumErrorImpresora _errorImpresora;

        public int DocumentosTotales
        {
            get { return _DocumentosTotales; }
        }
        public int DocumentosImpresos
        {
            get { return _DocumentosImpresos; }
        }
        public List<ReportDocument> TicketsNoImpresos
        {
            get { return _TicketsNoImpresos; }
        }
        public EnumErrorImpresora ErrorImpresora
        {
            get { return _errorImpresora; }
            set { _errorImpresora = value; }
        }

        public ImpresoraEventArgs(int DocumentosTotales, int DocumentosImpresos, List<ReportDocument> TicketsNoImpresos, EnumErrorImpresora ErrorImpresora)
        {
            this._DocumentosImpresos = DocumentosImpresos;
            this._DocumentosTotales = DocumentosTotales;
            this._TicketsNoImpresos = TicketsNoImpresos;
            this._errorImpresora = ErrorImpresora;
        }
    }

    #region Enumerados
    /// <summary>
    /// Errores de la impresora
    /// </summary>
    public enum EnumErrorImpresora
    {
        NoError,
        SinConexion,
        SinPapel,
        PapelAtascado,
        CortadorAtascado,
        TapaAbierta,
        CasiSinPapel
    }
    /// <summary>
    /// Métodos de impresión
    /// </summary>
    public enum EnumMetodosImpresion
    {
        BorrarCola,
        Pausar,
        Continuar
    }
    #endregion
}