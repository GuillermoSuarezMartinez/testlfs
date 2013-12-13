//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Threading;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Esta clase se utiliza para automáticamente volver a conectar con el servidor, si se desconectan.
    /// Intenta volver a conectarse al servidor periódicamente hasta que se establezca la conexión.
    /// </summary>
    public class ClienteReConexion : IDisposable
    {
        #region Atributos
        /// <summary>
        /// Referencia un cliente.
        /// </summary>
        private readonly IClienteConectable _cliente;
        /// <summary>
        /// Temporizador (timer) para intentar reconectar periódicamente.
        /// </summary>
        private readonly Timer _timerReconexion;
        /// <summary>
        /// Indica el estado dispose de este objeto.
        /// </summary>
        private volatile bool _disposed;
        /// <summary>
        /// Periodo de reconexión predeterminado.
        /// </summary>
        private const int PeriodoReConexionPredeterminado = 20000; // 20 segundos.
        #endregion Atributos

        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ClienteReConexion.
        /// Esto no es necesario para iniciar ClienteReConexion, ya que, de forma automática
        /// comienza cuando el cliente desconecta.
        /// </summary>
        /// <param name="cliente">Referencia al cliente.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException si el cliente es nulo (null).</exception>
        public ClienteReConexion(IClienteConectable cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("cliente");
            }
            _cliente = cliente;
            _cliente.Desconectado += Cliente_Desconectado;
            _timerReconexion = new Timer(PeriodoReConexionPredeterminado);
            _timerReconexion.Elapsed += TimerReconexion_Elapsed;
            _timerReconexion.Iniciar();
        }
        #endregion Constructor

        #region Destructor
        /// <summary>
        /// Destruir (dispose) este objeto.
        /// No hace nada si ya está destruido.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            _cliente.Desconectado -= Cliente_Desconectado;
            _timerReconexion.Parar();
        }
        #endregion Destructor

        #region Propiedades públicas
        /// <summary>
        /// Periodo de reconexión.
        /// Valor predeterminado: 20 segundos.
        /// </summary>
        public int PeriodoReConexion
        {
            get { return _timerReconexion.Periodo; }
            set { _timerReconexion.Periodo = value; }
        }
        #endregion Propiedades públicas

        #region Manejadores de eventos
        /// <summary>
        /// Manejador del evento Desconectado de _cliente.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void Cliente_Desconectado(object sender, EventArgs e)
        {
            _timerReconexion.Iniciar();
        }
        /// <summary>
        /// Manejador del evento Elapsed de _timerReconexion.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        private void TimerReconexion_Elapsed(object sender, EventArgs e)
        {
            if (_disposed || _cliente.EstadoComunicacion == EstadoComunicacion.Conectado)
            {
                _timerReconexion.Parar();
                return;
            }
            try
            {
                _cliente.Conectar();
                _timerReconexion.Parar();
            }
            catch
            {
                // Empty.
            }
        }
        #endregion Manejadores de eventos
    }
}