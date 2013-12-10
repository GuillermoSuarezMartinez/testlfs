using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Trazabilidad;
using System.Net.Sockets;
using Orbita.Comunicaciones;
using System.Collections;
using System.Reflection;
using Orbita.MS;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.ServiceProcess;

namespace Orbita.MS
{
    /// <summary>
    /// Gestor de licencias de aplicación cliente.
    /// </summary>
    public partial class OGestorLicenciasCliente 
    {
        /*
         
         Para facilitar la legibilidad y mantenimiento del código se han separado los métodos y funciones en diversos ficheros.
         Como la definición de esta clase es una 'partial class', en realidad todas esas implementaciones forman parte de esta misma
         clase.
          
         Eventos -> Contine las implementaciones de los eventos
         Licencias -> Implementaciones relativas a inicialización y proceso inicial en cliente de las licencias.
         Protocolo -> Lógica relativa a la recepción, transmisión y proceso de mensajes en base al protocolo existente entre cliente
                      de licencias.
         */ 


        #region Atributos
        
        /// <summary>
        /// Logger
        /// </summary>
        ILogger _log = LogManager.GetLogger("MSLC");
        /// <summary>
        /// Puerto servidor, conexión de control
        /// </summary>
        int _protocoloPuerto = 3625;
        /// <summary>
        /// Servidor, conexión de control
        /// </summary>
        string _protocoloInstancia = "127.0.0.1";
        /// <summary>
        /// Puerto servidor, puerto dinámico
        /// </summary>
        int _conexionPuerto = 3625;
        /// <summary>
        /// Servidor, conexión.
        /// </summary>
        string _conexionServidor = "127.0.0.1";
        /// <summary>
        /// Listener de control (Cliente)
        /// </summary>
        OListenerCliente _protocoloListener;
        /// <summary>
        /// Gestor de conexión de control.
        /// </summary>
        OConexionCliente _protocoloConexion;
        /// <summary>
        /// Gestor de conexión de licencias (dinámico).
        /// </summary>
        OConexionCliente _licenciaConexion;
        /// <summary>
        /// Estado de la comunicación
        /// </summary>
        OEstadoComunicacionCliente _estadoComunicacion = OEstadoComunicacionCliente.Desconectado;
        /// <summary>
        /// Estado general de las licencias declaradas
        /// </summary>
        OEstadoLicenciaCliente _estadoLicencia = OEstadoLicenciaCliente.Indefinido;
        /// <summary>
        /// Nombre de la instancia
        /// </summary>
        string _nombreInstancia = "";
        /// <summary>
        /// Nombre de la instancia en comunicaciones
        /// </summary>
        string _codeName = "ORBITA_DEV001";
        /// <summary>
        /// Datos de licenciamiento de la aplicación
        /// </summary>
        OAplicacion _aplicacion = null;
        /// <summary>
        /// Datos sobre el proceso actual
        /// </summary>
        OProcesoAplicacion _proceso = null;
        object _concurrencia = new object();
        /// <summary>
        /// Número de conexiones correctas
        /// </summary>
        int _conexionesCorrectas = 0;
        /// <summary>
        /// Indica si la aplicación está en periodo de gracia
        /// </summary>
        bool _periodogracia = false;
        /// <summary>
        /// Timer del periodo de gracia
        /// </summary>
        System.Timers.Timer _timerGracia = new System.Timers.Timer();
        /// <summary>
        /// Timer de cierre natural de la aplicación
        /// </summary>
        System.Timers.Timer _cierreAplicacion = new System.Timers.Timer();
        /// <summary>
        /// Servicios asociados a la aplicación.
        /// </summary>
        List<string> _servicios = new List<string>() { };
        
        #endregion Atributos

        #region Propiedades
        /// <summary>
        /// Número de conexiones correctas
        /// </summary>
        private int ConexionesCorrectas
        {
            get
            {
                lock (_concurrencia)
                {
                    return _conexionesCorrectas;
                }
            }
            set
            {
                lock (_concurrencia)
                {
                    _conexionesCorrectas = value;
                }
            }
        }
        /// <summary>
        /// Indica si se encuentra la aplicación en periodo de gracia
        /// </summary>
        private bool PeriodoDeGracia
        {
            get
            {
                lock (_concurrencia)
                {
                    return _periodogracia;
                }
            }
            set
            {
                lock (_concurrencia)
                {
                    _periodogracia = value;
                }
            }
        }
        /// <summary>
        /// Servicios asociados a la aplicación
        /// </summary>
        public List<string> ServiciosAsociados
        {
            get { return _servicios; }
            set { _servicios = value; }
        }
        #endregion Propiedades

        #region Constructores
        /// <summary>
        /// Gestor de licencias para aplicaciones cliente
        /// </summary>
        /// <param name="ipServidorLicencias">Dirección IP del servidor de licencias</param>
        /// <param name="puerto">Puerto de comunicación del servidor de licencias</param>
        /// <param name="datosLicenciamiento">Datos de licenciamiento</param>
        /// <param name="log">Instancia de logger</param>
        public OGestorLicenciasCliente(string ipServidorLicencias, int puerto, ILogger log = null, OAplicacion datosLicenciamiento = null)
        {
            this._conexionServidor = ipServidorLicencias;
            this._conexionPuerto = puerto;
            if (log != null)
            {
                _log = log;
            }
            if (datosLicenciamiento != null)
            {
                _aplicacion = datosLicenciamiento;
            }

            InicializarInformacionLicencias();

            InicializarConexionControlProtocolo();

            IniciarComunicacionServidorLicencias();

        }

        #endregion Constructor

        #region Métodos privados
        #endregion Métodos privados
        #region Métodos públicos
        #endregion Métodos públicos
        
    }
}
