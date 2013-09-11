using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Orbita.MS
{
    public partial class OGestorLicenciasCliente
    {
        #region Métodos privados
        /// <summary>
        /// Inicializa los datos de licenciamiento
        /// </summary>
        private void InicializarInformacionLicencias()
        {
            _proceso = new OProcesoAplicacion(Process.GetCurrentProcess());
            if (_aplicacion == null)
            {
                _aplicacion = new OAplicacion();
                //_aplicacion
                _proceso.PDatosLicenciamiento = _aplicacion;
            }
        }
        /// <summary>
        /// Comunica y registra las licencias declaradas
        /// </summary>
        private void RegistrarLicenciasDeclaradas()
        {
            if (_aplicacion == null || _proceso == null)
            {
                InicializarInformacionLicencias();
            }

            // if(_estadoComunicacion != OEstadoComunicacionCliente.ConexionPendiente)

            try
            {
                string mensaje = OGestorProtocolo.C_S_RegistrarInicio(_proceso);
                _licenciaConexion.EnviarMensaje(mensaje);
            }
            catch (Exception e1)
            {
                _log.Error(e1);
                Console.Error.WriteLine(e1);
            }

        }
        /// <summary>
        /// Inicia el periodo de gracia
        /// </summary>
        private void EstablecerPeriodoDeGracia()
        {

            lock (_concurrencia)
            {
                double tiempo = 259200000;
                _log.Error("Se ha iniciado el periodo de gracia para esta aplicación. Si no se licencian los productos que lo requieren, la aplicación dejará de funcionar en " + 259200000 + "ms.");
                _timerGracia = new System.Timers.Timer(tiempo);
                _timerGracia.AutoReset = false;
                _timerGracia.Enabled = true;
                _timerGracia.Elapsed += new System.Timers.ElapsedEventHandler(FinalizadoPeriodoDeGracia);
            }
        }

        #endregion Métodos privados
        #region Métodos públicos

        /// <summary>
        /// Inicia la comunicación con el servidor de licencias.
        /// </summary>
        public void IniciarComunicacionServidorLicencias(string codeName = "")
        {
            try
            {
                if (!String.IsNullOrEmpty(codeName)) this._codeName = codeName;
                //Solicitamos canal seguro de comunicación
                string mensaje = OGestorProtocolo.C_S_SolicitaCanal(codeName);
                //Enviamos mensaje de CanalInicio
                _protocoloConexion.EnviarMensaje(mensaje);
                this._estadoComunicacion = OEstadoComunicacionCliente.Protocolo;
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                _log.Error(e1);
            }
        }
        public void IniciarComunicacionPersistente()
        {

            _licenciaConexion = null;
            _licenciaConexion = new OConexionCliente(_log, this._conexionServidor, this._conexionPuerto, this._codeName);
            _licenciaConexion.ODataArrival += new Orbita.Comunicaciones.OManejadorEventoComm(_licenciaConexion_ODataArrival);
            _licenciaConexion.OErrorReceived += new Orbita.Comunicaciones.OManejadorEventoComm(_licenciaConexion_OErrorReceived);
            _licenciaConexion.OSendComplete += new Orbita.Comunicaciones.OManejadorEventoComm(_licenciaConexion_OSendComplete);
            _licenciaConexion.OStateChanged += new Orbita.Comunicaciones.OManejadorEventoComm(_licenciaConexion_OStateChanged);

            this._estadoComunicacion = OEstadoComunicacionCliente.ConexionAsignadaSinInicializar;
        }

        #endregion Métodos públicos
    }
}
