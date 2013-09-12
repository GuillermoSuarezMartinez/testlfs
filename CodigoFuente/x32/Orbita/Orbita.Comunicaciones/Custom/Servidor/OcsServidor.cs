//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System.Collections.Generic;
using System.Data;
using System.Linq;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor;
using Orbita.Comunicaciones.Protocolos.Tcp.Threading;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para el cliente conectado al listener.
    /// </summary>
    public class OcsServidor : IOcsServidor
    {
        #region Atributos privados
        /// <summary>
        /// Colección de listeners.
        /// </summary>
        private readonly List<IServidor> _listeners;
        /// <summary>
        /// Colección de datos producidos en el evento cambioDato.
        /// </summary>
        private readonly ProcesadorElementosSecuenciales<OInfoDato> _cambioDato;
        /// <summary>
        /// Colección de datos producidos en el evento alarma.
        /// </summary>
        private readonly ProcesadorElementosSecuenciales<OInfoDato> _alarmas;
        /// <summary>
        /// Colección de datos producidos en el evento comunicaciones.
        /// </summary>
        private readonly ProcesadorElementosSecuenciales<OEstadoComms> _comunicaciones;
        #endregion Atributos privados

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsServidor.
        /// </summary>
        private OcsServidor()
        {
            //  Crear la colección de listeners.
            _listeners = new List<IServidor>();

            //  Crear las colecciones de mensajeros.
            _cambioDato = new ProcesadorElementosSecuenciales<OInfoDato>(OnCambioDato);
            _alarmas = new ProcesadorElementosSecuenciales<OInfoDato>(OnAlarmas);
            _comunicaciones = new ProcesadorElementosSecuenciales<OEstadoComms>(OnComunicaciones);
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsServidor.
        /// </summary>
        /// <param name="variables">Colección de variables.</param>
        public OcsServidor(DataTable variables)
            : this()
        {
            Variables = variables;
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Colección de variables.
        /// </summary>
        private DataTable Variables { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Iniciar los mensajeros.
        /// </summary>
        public void Iniciar()
        {
            if (_listeners.Count <= 0) return;
            _cambioDato.Iniciar();
            _alarmas.Iniciar();
            _comunicaciones.Iniciar();
        }
        /// <summary>
        /// Terminar los mensajeros.
        /// </summary>
        public void Terminar()
        {
            if (_listeners.Count <= 0) return;
            foreach (var listener in _listeners)
            {
                listener.Parar();
            }
            _cambioDato.Terminar();
            _alarmas.Terminar();
            _comunicaciones.Terminar();
        }
        /// <summary>
        /// Añadir un listener a la colección.
        /// </summary>
        /// <param name="listener">Listener que se utiliza para aceptar y gestionar las conexiones de clientes.</param>
        public void Añadir(IServidor listener)
        {
            _listeners.Add(listener);
        }
        /// <summary>
        /// Enviar un mensaje de tipo cambio de dato a la aplicación remota.
        /// </summary>
        /// <param name="infoDato">Información del dato que se está transmitiendo.</param>
        public void CambioDato(OInfoDato infoDato)
        {
            _cambioDato.EncolarMensaje(infoDato);
        }
        /// <summary>
        /// Enviar un mensaje de tipo alarma a la aplicación remota.
        /// </summary>
        /// <param name="infoDato">Información del dato que se está transmitiendo.</param>
        public void Alarma(OInfoDato infoDato)
        {
            _alarmas.EncolarMensaje(infoDato);
        }
        /// <summary>
        /// Enviar un mensaje de tipo estado de las comunicaciones a la aplicación remota.
        /// </summary>
        /// <param name="estadoComm">Información del estado de las comunicaciones que se están transmitiendo.</param>
        public void Comunicaciones(OEstadoComms estadoComm)
        {
            _comunicaciones.EncolarMensaje(estadoComm);
        }
        #endregion Métodos públicos

        #region Métodos protegidos virtuales
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeCambioDato.
        /// </summary>
        /// <param name="infoDato">Contiene información del dato que provocó el evento.</param>
        protected virtual void OnCambioDato(OInfoDato infoDato)
        {
            //  Crear el mensaje de tipo MensajeCambioDato que se va a enviar a partir de la información de InfoDato.
            var mensaje = OcsMensajeFactory.CrearMensajeCambioDato(infoDato);

            //  Obtener cada uno de los canales que apunta el dispositivo y la variable, con el fin de obtener para ese relación 1 a 1 a cada uno de los endpoints.
            var queryCanales = Variables.AsEnumerable().Where(variables => variables.Field<short>("VARC_ID_DISPOSITIVO") == infoDato.Dispositivo && variables.Field<int>("VARC_ID_VARIABLE") == infoDato.Identificador).Select(variables => new { Canal = variables.Field<short>("VARC_ID_CANAL") });

            //  Enviar el mensaje de cambio de dato a todos los clientes conectados que indique infoDato.
            foreach (var cliente in queryCanales.SelectMany(canales => _listeners.Where(listener => listener.EndPoint.PuertoTcp == canales.Canal).Select(listener => listener.Clientes.ObtenerPrimerElemento()).Where(cliente => cliente != null)))
            {
                cliente.EnviarMensaje(mensaje);
            }
        }
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeAlarma.
        /// </summary>
        /// <param name="infoDato">Contiene información del dato que provocó el evento.</param>
        protected virtual void OnAlarmas(OInfoDato infoDato)
        {
            //  Crear el mensaje de tipo Mensajealarma que se va a enviar a partir de la información de InfoDato.
            var mensaje = OcsMensajeFactory.CrearMensajeAlarma(infoDato);

            //  Obtener cada uno de los canales que apunta el dispositivo y la variable con el fin de obtener para ese relación 1 a 1 cada uno de los endpoints.
            var queryCanales = Variables.AsEnumerable().Where(variables => variables.Field<short>("VARC_ID_DISPOSITIVO") == infoDato.Dispositivo && variables.Field<int>("VARC_ID_VARIABLE") == infoDato.Identificador).Select(variables => new { Canal = variables.Field<short>("VARC_ID_CANAL") });

            //  Enviar el mensaje de alarma a todos los clientes conectados que indique infoDato.
            foreach (var cliente in queryCanales.SelectMany(canales => _listeners.Where(listener => listener.EndPoint.PuertoTcp == canales.Canal).Select(listener => listener.Clientes.ObtenerPrimerElemento()).Where(cliente => cliente != null)))
            {
                cliente.EnviarMensaje(mensaje);
            }
        }
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeComunicaciones.
        /// </summary>
        /// <param name="estadoComm">Contiene información del estado de comunicaciones que provocó el evento.</param>
        protected virtual void OnComunicaciones(OEstadoComms estadoComm)
        {
            //  Crear el mensaje de tipo MensajeComunicaciones que se va a enviar a partir de la información de EstadoComms.
            var mensaje = OcsMensajeFactory.CrearMensajeComunicaciones(estadoComm);

            //  Enviar el mensaje de comunicaciones a todos los clientes conectados.
            foreach (var cliente in _listeners.Select(listener => listener.Clientes.ObtenerPrimerElemento()).Where(cliente => cliente != null))
            {
                cliente.EnviarMensaje(mensaje);
            }
        }
        #endregion Métodos protegidos virtuales
    }
}