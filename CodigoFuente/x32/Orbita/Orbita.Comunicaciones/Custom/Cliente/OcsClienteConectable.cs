//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor;
using Orbita.Comunicaciones.Protocolos.Tcp.Threading;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para el cliente conectado al listener.
    /// </summary>
    public class OcsClienteConectable : IOcsClienteConectable
    {
        #region Atributos
        /// <summary>
        /// Colección de mensajes producidos por el cliente a petición de lecturas de variables.
        /// </summary>
        private readonly ProcesadorElementosSecuencialesT2<object, IMensaje> _lecturas;
        /// <summary>
        /// Colección de mensajes producidos por el cliente a petición de escrituras de variables.
        /// </summary>
        private readonly ProcesadorElementosSecuencialesT2<object, IMensaje> _escrituras;
        /// <summary>
        /// Colección de mensajes producidos por el cliente a petición de lectura de datos.
        /// </summary>
        private readonly ProcesadorElementosSecuencialesT2<object, IMensaje> _datos;
        /// <summary>
        /// Colección de mensajes producidos por el cliente a petición de lectura de alarmas activas.
        /// </summary>
        private readonly ProcesadorElementosSecuencialesT2<object, IMensaje> _alarmasActivas;
        /// <summary>
        /// Colección de mensajes producidos por el cliente a petición de lectura de dispositivos.
        /// </summary>
        private readonly ProcesadorElementosSecuencialesT2<object, IMensaje> _dispositivos;
        #endregion Atributos

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsClienteConectable.
        /// </summary>
        private OcsClienteConectable()
        {
            _lecturas = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnLecturas);
            _datos = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnDatos);
            _alarmasActivas = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnAlarmasActivas);
            _dispositivos = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnDispositivos);
            _escrituras = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnEscrituras);
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsClienteConectable.
        /// </summary>
        /// <param name="dispositivos">Colección de dispositivos conectados.</param>
        public OcsClienteConectable(OHashtable dispositivos)
            : this()
        {
            Dispositivos = dispositivos;
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Colección de dispositivos.
        /// </summary>
        private OHashtable Dispositivos { get; set; }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Iniciar los mensajeros.
        /// </summary>
        public void Iniciar()
        {
            //  Lecturas.
            _lecturas.Iniciar();
            _datos.Iniciar();
            _alarmasActivas.Iniciar();
            _dispositivos.Iniciar();

            //  Escrituras.
            _escrituras.Iniciar();
        }
        /// <summary>
        /// Terminar los mensajeros.
        /// </summary>
        public void Terminar()
        {
            //  Lecturas.
            _lecturas.Terminar();
            _datos.Terminar();
            _alarmasActivas.Terminar();
            _dispositivos.Terminar();

            //  Escrituras.
            _escrituras.Terminar();
        }
        #endregion Métodos públicos

        #region Manejadores de eventos públicos
        /// <summary>
        /// Manejador del evento MensajeRecibido para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        public virtual void MensajeRecibido(object sender, MensajeEventArgs e)
        {
            if (e.Mensaje == null) return;

            //  Mensaje de lectura (...)
            if (e.Mensaje is OcsMensajeLectura)
            {
                _lecturas.EncolarMensaje(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaDatos)
            {
                _datos.EncolarMensaje(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaAlarmasActivas)
            {
                _alarmasActivas.EncolarMensaje(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaDispositivos)
            {
                _dispositivos.EncolarMensaje(sender, e.Mensaje);
                return;
            }

            //  Mensaje de escritura (...)
            if (e.Mensaje is OcsMensajeEscritura)
            {
                _escrituras.EncolarMensaje(sender, e.Mensaje);
            }
        }
        #endregion Manejadores de eventos públicos

        #region Métodos protegidos virtuales
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeLectura.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje de tipo solicitud de lectura.</param>
        protected virtual void OnLecturas(object sender, IMensaje mensaje)
        {
            var mensajeLectura = OcsMensajeFactory.ObtenerMensajeLectura(mensaje);

            object[] valores;
            using (var dispositivo = (ODispositivo) Dispositivos[mensajeLectura.Dispositivo])
            {
                valores = dispositivo.Leer(mensajeLectura.Variables, mensajeLectura.Demanda);
            }

            //  Crear mensaje de respuesta de lectura.
            var mensajeRespuesta = OcsMensajeFactory.CrearMensajeLectura(mensajeLectura.Dispositivo, mensajeLectura.Variables, valores, mensaje.IdMensaje);

            //  Contiene una referencia al objeto que provocó el evento.
            var cliente = (IServidorCliente)sender;

            //  Enviar mensaje de lectura.
            cliente.EnviarMensaje(mensajeRespuesta);
        }
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeLecturaDatos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje de tipo solicitud de datos.</param>
        protected virtual void OnDatos(object sender, IMensaje mensaje)
        {
            var mensajeDatos = OcsMensajeFactory.ObtenerMensajeDatos(mensaje);

            OHashtable valores;
            using (var dispositivo = (ODispositivo) Dispositivos[mensajeDatos.Dispositivo])
            {
                valores = dispositivo.GetDatos();
            }

            //  Crear mensaje de respuesta de datos.
            var mensajeRespuesta = OcsMensajeFactory.CrearMensajeDatos(mensajeDatos.Dispositivo, valores, mensaje.IdMensaje);

            //  Contiene una referencia al objeto que provocó el evento.
            var cliente = (IServidorCliente)sender;

            //  Enviar mensaje de datos.
            cliente.EnviarMensaje(mensajeRespuesta);
        }
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeLecturaAlarmasActivas.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje de tipo solicitud de alarmas activas.</param>
        protected virtual void OnAlarmasActivas(object sender, IMensaje mensaje)
        {
            var mensajeAlarmasActivas = OcsMensajeFactory.ObtenerMensajeAlarmasActivas(mensaje);

            ArrayList valores;
            using (var dispositivo = (ODispositivo) Dispositivos[mensajeAlarmasActivas.Dispositivo])
            {
                valores = dispositivo.GetAlarmasActivas();
            }

            //  Crear mensaje de respuesta de alarmas activas.
            var mensajeRespuesta = OcsMensajeFactory.CrearMensajeAlarmasActivas(mensajeAlarmasActivas.Dispositivo, valores, mensaje.IdMensaje);

            //  Contiene una referencia al objeto que provocó el evento.
            var cliente = (IServidorCliente)sender;

            //  Enviar mensaje de alarmas activas.
            cliente.EnviarMensaje(mensajeRespuesta);
        }
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeLecturaDispositivos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje de tipo solicitud de alarmas activas.</param>
        protected virtual void OnDispositivos(object sender, IMensaje mensaje)
        {
            //  Obtener los dispositivos de la colección.
            var dispositivos = new List<int>();
            dispositivos.AddRange(Dispositivos.Keys.Cast<int>());

            //  Copiar los elementos obtenidos en una nueva matriz.
            var valores = dispositivos.ToArray();

            //  Crear mensaje de respuesta de alarmas activas.
            var mensajeRespuesta = OcsMensajeFactory.CrearMensajeDispositivos(valores, mensaje.IdMensaje);

            //  Contiene una referencia al objeto que provocó el evento.
            var cliente = (IServidorCliente)sender;

            //  Enviar mensaje de alarmas activas.
            cliente.EnviarMensaje(mensajeRespuesta);
        }
        /// <summary>
        /// Evento producido por el manejador MensajeRecibido para mensajes de tipo OcsMensajeEscritura.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje de tipo solicitud de escritura.</param>
        protected virtual void OnEscrituras(object sender, IMensaje mensaje)
        {
            var mensajeEscritura = (OcsMensajeEscritura)mensaje;

            //  Crear mensaje de escritura.
            var mensajeRespuesta = OcsMensajeFactory.CrearMensajeEscritura(mensaje.IdMensaje);

            //  Escribir en el dispositivo y obtener la respuesta que se enviará.
            using (var dispositivo = (ODispositivo) Dispositivos[mensajeEscritura.Dispositivo])
            {
                mensajeRespuesta.Respuesta = dispositivo.Escribir(mensajeEscritura.Variables, mensajeEscritura.Valores, mensajeEscritura.Canal);
            }

            //  Contiene una referencia al objeto que provocó el evento.
            var cliente = (IServidorCliente)sender;

            //  Enviar mensaje de respuesta de escritura.
            cliente.EnviarMensaje(mensajeRespuesta);
        }
        #endregion Métodos protegidos virtuales
    }
}