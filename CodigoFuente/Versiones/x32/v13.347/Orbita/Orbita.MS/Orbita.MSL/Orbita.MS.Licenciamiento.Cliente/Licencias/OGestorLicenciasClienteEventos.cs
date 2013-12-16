using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Comunicaciones;

namespace Orbita.MS
{
    public partial class OGestorLicenciasCliente
    {
        //Contiene la implementación de eventos y tratamiento básico

        #region Atributos
        #region Definición de eventos
        /// <summary>
        /// Definición de Manejador principal
        /// </summary>
        /// <param name="e"></param>
        public delegate void OManejadorEventoLicenciaCliente(OLicenciaClienteEventArgs e);

        /// <summary>
        /// Una o más licencias especificadas no son válidas.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaInvalida;
        /// <summary>
        /// Las licencias proporcionadas son válidas.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaValida;
        /// <summary>
        /// Se requiere el cierre de la aplicación
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaSalidaAplicacion;
        /// <summary>
        /// Se ha reconectado con el servidor.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaReconexion;
        /// <summary>
        /// Se ha producido un error de comunicación.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaErrorComunicacion;
        /// <summary>
        /// Ha fallado la primera negociación de licenciamiento con el servidor de licencias.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaErrorInicioLicencia;
        /// <summary>
        /// La reconexión con el servidor ha fallado.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaReconexionFallida;
        /// <summary>
        /// Se inicia el periodo de gracia.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaInicioPeriodoGracia;
        /// <summary>
        /// Finaliza el periodo de gracia.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaFinPeriodoGracia;
        /// <summary>
        /// El mensaje entrega un mensaje informativa al cliente.
        /// </summary>
        public event OManejadorEventoLicenciaCliente LicenciaMensajeServidor;

        #endregion Definición de eventos
        #endregion Atributos

        #region Eventos
        #region Conexiones
        #region Conexión de control

        /// <summary>
        /// El estado ha cambiado
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexion_OStateChanged(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// El envío del mensaje se ha completado
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexion_OSendComplete(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Ha llegado un error de comunicaciones
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexion_OErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Ha llegado datos procedentes del servidor
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexion_ODataArrival(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
            //Procesamos el mensaje cliente (Protocolo)
            ProcesarMensajeCliente(mensaje);
        }


        /// <summary>
        /// El estado de la conexión ha cambiado
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskStateChanged(Utiles.OEventArgs e)
        {

            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }

        void _protocoloListener_WskErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }

        void _protocoloListener_WskConnectionRequest(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }

        void _protocoloListener_WskClientStateChanged(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }

        void _protocoloListener_WskClientSendComplete(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }

        void _protocoloListener_WskClientDataArrival(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }

        void _protocoloListener_WskClientErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        #endregion Conexión de control
        #region Conexión dinámica
        /// <summary>
        /// El estado de la conexión ha cambiado
        /// </summary>
        /// <param name="e"></param>
        void _licenciaConexion_OStateChanged(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Transferencia completada
        /// </summary>
        /// <param name="e"></param>
        void _licenciaConexion_OSendComplete(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Error de comunicaciones
        /// </summary>
        /// <param name="e"></param>
        void _licenciaConexion_OErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Nuevo mensaje
        /// </summary>
        /// <param name="e"></param>
        void _licenciaConexion_ODataArrival(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
            ProcesarMensajeCliente(mensaje);
        }
        #endregion Conexión dinámica
        #endregion Conexiones
        #region Aplicación
        /// <summary>
        /// Acciones a realizar cuando finaliza el periodo de gracia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FinalizadoPeriodoDeGracia(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_concurrencia)
            {
                double tiempo = 30000;
                _log.Error("Finalizado periodo de gracia. Se cerrará la aplicación en " + tiempo + "ms");
                if (this.LicenciaFinPeriodoGracia != null)
                {
                    OLicenciaClienteEventArgs args = new OLicenciaClienteEventArgs();
                    this.LicenciaFinPeriodoGracia(args);
                }
                _cierreAplicacion = new System.Timers.Timer(tiempo);
                _cierreAplicacion.Enabled = true;
                _cierreAplicacion.AutoReset = false;
                _cierreAplicacion.Elapsed += new System.Timers.ElapsedEventHandler(FinalizadoTiempoCierre);
                if (this.LicenciaFinPeriodoGracia != null)
                {
                    OLicenciaClienteEventArgs args = new OLicenciaClienteEventArgs();
                    this.LicenciaFinPeriodoGracia(args);
                }
            }

        }
        /// <summary>
        /// Acciones a realizar cuando ha terminado el tiempo de espera de cierre natural de cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FinalizadoTiempoCierre(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _log.Error("Forzando cierre definitivo de aplicación.");
                TerminarProcesosCliente();
                //La aplicación ya debería de haberse cerrado en este punto
                Application.Exit();
            }
            catch (Exception e1)
            {
                _log.Error(e1);
            }
        }
        #endregion Aplicacion
        #region Internos
        private void InicializarEventosInternos()
        {
            this.LicenciaErrorComunicacion +=new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);
            this.LicenciaErrorInicioLicencia += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);
            this.LicenciaFinPeriodoGracia += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);
            this.LicenciaInicioPeriodoGracia += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);
            this.LicenciaInvalida += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);
            this.LicenciaMensajeServidor += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);
            this.LicenciaMensajeServidor += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno); 
            this.LicenciaMensajeServidor += new OManejadorEventoLicenciaCliente(TrazabilidadEventoInterno);

            //TrazabilidadEventoInterno
        }
        void TrazabilidadEventoInterno(OLicenciaClienteEventArgs e)
        {
            string detalles = "";
            foreach(var detalle in e.Datos)
            {
                detalles += detalle + "|";
            }
            _log.Debug("Se ha producido un evento de aplicación cliente/biblioteca Orbita.MS: " + e.Mensaje + " " + detalles);
        }
        #endregion Internos
        #endregion Eventos
    }
}
