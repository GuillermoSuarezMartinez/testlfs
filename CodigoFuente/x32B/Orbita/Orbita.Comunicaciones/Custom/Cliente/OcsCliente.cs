//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;
using Orbita.Comunicaciones.Protocolos.Tcp.Threading;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para todas las clases de clientes.
    /// </summary>
    public class OcsCliente : IOcsCliente
    {
        #region Eventos públicos
        /// <summary>
        /// Este evento se produce cuando el cliente se conecta al servidor.
        /// </summary>
        public event EventHandler Conectado;
        /// <summary>
        /// Este evento se produce cuando el cliente se desconecta del servidor.
        /// </summary>
        public event EventHandler Desconectado;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de variables.
        /// </summary>
        public event EventHandler<OcsMensajeLecturaEventArgs> MensajeEnviadoLectura;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de escritura de variables.
        /// </summary>
        public event EventHandler<OcsMensajeEscrituraEventArgs> MensajeEnviadoEscritura;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de datos.
        /// </summary>
        public event EventHandler<OcsMensajeEventArgs> MensajeEnviadoLecturaDatos;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de alarmas activas.
        /// </summary>
        public event EventHandler<OcsMensajeEventArgs> MensajeEnviadoLecturaAlarmasActivas;
        /// <summary>
        /// Este evento se produce cuando se envia un nuevo mensaje de lectura de dispositivos.
        /// </summary>
        public event EventHandler<MensajeEventArgs> MensajeEnviadoLecturaDispositivos;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de cambio de dato.
        /// </summary>
        public event EventHandler<OcsMensajeInfoDatoEventArgs> MensajeRecibidoCambioDato;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de alarma.
        /// </summary>
        public event EventHandler<OcsMensajeInfoDatoEventArgs> MensajeRecibidoAlarma;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de comunicaciones.
        /// </summary>
        public event EventHandler<OcsMensajeComunicacionesEventArgs> MensajeRecibidoComunicaciones;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de variables.
        /// </summary>
        public event EventHandler<OcsMensajeLecturaEventArgs> MensajeRecibidoLectura;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de escritura de variables.
        /// </summary>
        public event EventHandler<OcsMensajeEscrituraEventArgs> MensajeRecibidoEscritura;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de datos.
        /// </summary>
        public event EventHandler<OcsMensajeLecturaDatosEventArgs> MensajeRecibidoLecturaDatos;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de alarmas activas.
        /// </summary>
        public event EventHandler<OcsMensajeLecturaAlarmasActivasEventArgs> MensajeRecibidoLecturaAlarmasActivas;
        /// <summary>
        /// Este evento se produce cuando se recibe un nuevo mensaje de lectura de dispositivos.
        /// </summary>
        public event EventHandler<OcsMensajeLecturaDispositivosEventArgs> MensajeRecibidoLecturaDispositivos;
        #endregion Eventos públicos

        #region Atributos
        /// <summary>
        /// Representa un cliente para conectarse a un servidor.
        /// </summary>
        private readonly ICliente _cliente;
        /// <summary>
        /// Período de reconexión del cliente (opcional, en milisegundos).
        /// </summary>
        private readonly int _periodoReConexionMs;
        /// <summary>
        /// Estructura que procesa los mensajes recibidos de cambio de dato de forma secuencial.
        /// </summary>
        protected readonly ProcesadorElementosSecuencialesT2<object, IMensaje> MensajesEntrantesCambioDato;
        /// <summary>
        /// Estructura que procesa los mensajes recibidos de alarma de forma secuencial.
        /// </summary>
        protected readonly ProcesadorElementosSecuencialesT2<object, IMensaje> MensajesEntrantesAlarma;
        /// <summary>
        /// Estructura que procesa los mensajes recibidos de comunicaciones de forma secuencial.
        /// </summary>
        protected readonly ProcesadorElementosSecuencialesT2<object, IMensaje> MensajesEntrantesComunicaciones;
        #endregion Atributos

        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsCliente con la dirección Ip local (127.0.0.1)
        /// del servidor.
        /// </summary>
        /// <param name="puertoTcpRemoto">Puerto Tcp de escucha del servidor remoto.</param>
        /// <param name="periodoReConexionMs">Período de reconexión del cliente (opcional, en milisegundos).</param>
        public OcsCliente(int puertoTcpRemoto, int periodoReConexionMs = 0)
            : this("127.0.0.1", puertoTcpRemoto, periodoReConexionMs) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsCliente.
        /// </summary>
        /// <param name="direccionIpRemoto">Dirección IP del servidor remoto.</param>
        /// <param name="puertoTcpRemoto">Puerto Tcp de escucha del servidor remoto.</param>
        /// <param name="periodoReConexionMs">Período de reconexión del cliente (opcional, en milisegundos).</param>
        public OcsCliente(string direccionIpRemoto, int puertoTcpRemoto, int periodoReConexionMs = 0)
        {
            _cliente = ClienteFactory.Crear(new TcpEndPoint(direccionIpRemoto, puertoTcpRemoto));

            //  Suscribirse a los eventos de conexión y desconexión.
            _cliente.Conectado += Cliente_Conectado;
            _cliente.Desconectado += Cliente_Desconectado;

            //  Inicializar las colecciones de mensajes entrantes.
            MensajesEntrantesCambioDato = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnMensajeRecibidoCambioDato);
            MensajesEntrantesAlarma = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnMensajeRecibidoAlarma);
            MensajesEntrantesComunicaciones = new ProcesadorElementosSecuencialesT2<object, IMensaje>(OnMensajeRecibidoComunicaciones);

            //  Considerar el periodo de reconexión.
            _periodoReConexionMs = periodoReConexionMs;
            if (periodoReConexionMs <= 0) return;
            new ClienteReConexion(_cliente) { PeriodoReConexion = periodoReConexionMs };
        }
        #endregion Constructores

        #region Propiedades
        /// <summary>
        /// Representa un cliente para conectarse al servidor.
        /// </summary>
        protected ICliente Cliente
        {
            get { return _cliente; }
        }
        /// <summary>
        /// Estados de la comunicación.
        /// </summary>
        public Protocolos.Tcp.Comunicacion.EstadoComunicacion EstadoComunicacion
        {
            get { return _cliente.EstadoComunicacion; }
        }
        #endregion Propiedades

        #region Métodos públicos
        /// <summary>
        /// Conectar al servidor.
        /// </summary>
        public void Conectar()
        {
            _cliente.Conectar();
        }
        /// <summary>
        /// Desconectar del servidor.
        /// No hace nada si ya se encuentra desconectado.
        /// </summary>
        public void Desconectar()
        {
            _cliente.Desconectar();
        }
        /// <summary>
        /// Leer la colección de datos del dispositivo especificado.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public void LeerDatos(int dispositivo)
        {
            var mensaje = OcsMensajeFactory.CrearMensajeDatos(dispositivo);
            _cliente.EnviarMensaje(mensaje);
        }
        /// <summary>
        /// Leer la colección de valores de variables demandadas en el dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se realiza bajo demanda al dispositivo.</param>
        public void Leer(int dispositivo, string[] variables, bool demanda)
        {
            var mensaje = OcsMensajeFactory.CrearMensajeLectura(dispositivo, variables, demanda);
            _cliente.EnviarMensaje(mensaje);
        }
        /// <summary>
        /// Leer la colección de alarmas activas del dispositivo especificado.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public void LeerAlarmasActivas(int dispositivo)
        {
            var mensaje = OcsMensajeFactory.CrearMensajeAlarmasActivas(dispositivo);
            _cliente.EnviarMensaje(mensaje);
        }
        /// <summary>
        /// Leer la colección de dispositivos.
        /// </summary>
        public void LeerDispositivos()
        {
            var mensaje = OcsMensajeFactory.CrearMensajeDispositivos();
            _cliente.EnviarMensaje(mensaje);
        }
        /// <summary>
        /// Escribir el valor indicado de las variables en el dispositivo asociado indicando el canal.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal">Identificador de canal.</param>
        public void Escribir(int dispositivo, string[] variables, object[] valores, string canal)
        {
            var mensaje = OcsMensajeFactory.CrearMensajeEscritura(dispositivo, variables, valores, canal);
            _cliente.EnviarMensaje(mensaje);
        }
        #endregion Métodos públicos

        #region Manejadores de eventos
        /// <summary>
        /// Manejador del evento Conectado para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        protected void Cliente_Conectado(object sender, EventArgs e)
        {
            _cliente.MensajeEnviado += Cliente_MensajeEnviado;
            _cliente.MensajeRecibido += Cliente_MensajeRecibido;
            MensajesEntrantesAlarma.Iniciar();
            MensajesEntrantesCambioDato.Iniciar();
            MensajesEntrantesComunicaciones.Iniciar();
            OnConectado();
        }
        /// <summary>
        /// Manejador del evento Desconectado para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">EventArgs que contiene los datos del evento.</param>
        protected void Cliente_Desconectado(object sender, EventArgs e)
        {
            if (_periodoReConexionMs <= 0)
            {
                _cliente.Conectado -= Cliente_Conectado;
                _cliente.Desconectado -= Cliente_Desconectado;
            }
            _cliente.MensajeEnviado -= Cliente_MensajeEnviado;
            _cliente.MensajeRecibido -= Cliente_MensajeRecibido;
            MensajesEntrantesAlarma.Terminar();
            MensajesEntrantesCambioDato.Terminar();
            MensajesEntrantesComunicaciones.Terminar();
            OnDesconectado();
        }
        /// <summary>
        /// Manejador del evento MensajeEnviado para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        protected void Cliente_MensajeEnviado(object sender, MensajeEventArgs e)
        {
            if (e.Mensaje == null) return;

            //  Mensaje de lectura enviado (...)
            if (e.Mensaje is OcsMensajeLectura)
            {
                OnMensajeEnviadoLectura(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaDatos)
            {
                OnMensajeEnviadoLecturaDatos(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaAlarmasActivas)
            {
                OnMensajeEnviadoLecturaAlarmasActivas(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaDispositivos)
            {
                OnMensajeEnviadoLecturaDispositivos(sender, e.Mensaje);
                return;
            }

            //  Mensaje de escritura recibido (...)
            if (e.Mensaje is OcsMensajeEscritura)
            {
                OnMensajeEnviadoEscritura(sender, e.Mensaje);
            }
        }
        /// <summary>
        /// Manejador del evento MensajeRecibido para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        protected virtual void Cliente_MensajeRecibido(object sender, MensajeEventArgs e)
        {
            if (e.Mensaje == null) return;
            if (e.Mensaje is OcsMensajeCambioDato)
            {
                MensajesEntrantesCambioDato.EncolarMensaje(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeAlarma)
            {
                MensajesEntrantesAlarma.EncolarMensaje(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeComunicaciones)
            {
                MensajesEntrantesComunicaciones.EncolarMensaje(sender, e.Mensaje);
                return;
            }

            //  Mensaje de lectura recibido (...)
            if (e.Mensaje is OcsMensajeLectura)
            {
                OnMensajeRecibidoLectura(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaDatos)
            {
                OnMensajeRecibidoLecturaDatos(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaAlarmasActivas)
            {
                OnMensajeRecibidoLecturaAlarmasActivas(sender, e.Mensaje);
                return;
            }
            if (e.Mensaje is OcsMensajeLecturaDispositivos)
            {
                OnMensajeRecibidoLecturaDispositivos(sender, e.Mensaje);
                return;
            }

            //  Mensaje de escritura recibido (...)
            if (e.Mensaje is OcsMensajeEscritura)
            {
                OnMensajeRecibidoEscritura(sender, e.Mensaje);
            }
        }
        #endregion Manejadores de eventos

        #region Métodos protegidos de eventos elevados

        #region Cliente
        /// <summary>
        /// Elevar el evento Conectado.
        /// </summary>
        protected virtual void OnConectado()
        {
            var handler = Conectado;
            if (handler != null)
            {
                handler(_cliente, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Elevar el evento Desconectado.
        /// </summary>
        protected virtual void OnDesconectado()
        {
            var handler = Desconectado;
            if (handler != null)
            {
                handler(_cliente, EventArgs.Empty);
            }
        }
        #endregion

        #region Mensajes enviados
        /// <summary>
        /// Elevar el evento MensajeEnviadoLectura.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje enviado.</param>
        protected virtual void OnMensajeEnviadoLectura(object sender, IMensaje mensaje)
        {
            var handler = MensajeEnviadoLectura;
            if (handler != null)
            {
                handler(sender, new OcsMensajeLecturaEventArgs(OcsMensajeFactory.ObtenerMensajeLectura(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeEnviadoLecturaDatos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje enviado.</param>
        protected virtual void OnMensajeEnviadoLecturaDatos(object sender, IMensaje mensaje)
        {
            var handler = MensajeEnviadoLecturaDatos;
            if (handler != null)
            {
                handler(sender, new OcsMensajeEventArgs(OcsMensajeFactory.ObtenerMensajeDatos(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeEnviadoLecturaAlarmasActivas.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje enviado.</param>
        protected virtual void OnMensajeEnviadoLecturaAlarmasActivas(object sender, IMensaje mensaje)
        {
            var handler = MensajeEnviadoLecturaAlarmasActivas;
            if (handler != null)
            {
                handler(sender, new OcsMensajeEventArgs(OcsMensajeFactory.ObtenerMensajeAlarmasActivas(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeEnviadoLecturaDispositivos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje enviado.</param>
        protected virtual void OnMensajeEnviadoLecturaDispositivos(object sender, IMensaje mensaje)
        {
            var handler = MensajeEnviadoLecturaDispositivos;
            if (handler != null)
            {
                handler(sender, new MensajeEventArgs(OcsMensajeFactory.ObtenerMensajeDispositivos(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeEnviadoEscritura.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje enviado.</param>
        protected virtual void OnMensajeEnviadoEscritura(object sender, IMensaje mensaje)
        {
            var handler = MensajeEnviadoEscritura;
            if (handler != null)
            {
                handler(sender, new OcsMensajeEscrituraEventArgs(OcsMensajeFactory.ObtenerMensajeEscritura(mensaje)));
            }
        }
        #endregion Mensajes enviados

        #region Mensajes recibidos
        /// <summary>
        /// Elevar el evento MensajeRecibidoCambioDato.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoCambioDato(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoCambioDato;
            if (handler != null)
            {
                handler(sender, new OcsMensajeInfoDatoEventArgs(OcsMensajeFactory.ObtenerMensajeCambioDato(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoAlarma.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoAlarma(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoAlarma;
            if (handler != null)
            {
                handler(sender, new OcsMensajeInfoDatoEventArgs(OcsMensajeFactory.ObtenerMensajeAlarma(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoComunicaciones.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoComunicaciones(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoComunicaciones;
            if (handler != null)
            {
                handler(sender, new OcsMensajeComunicacionesEventArgs(OcsMensajeFactory.ObtenerMensajeComunicaciones(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoLectura.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoLectura(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoLectura;
            if (handler != null)
            {
                handler(sender, new OcsMensajeLecturaEventArgs(OcsMensajeFactory.ObtenerMensajeLectura(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoLecturaDatos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoLecturaDatos(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoLecturaDatos;
            if (handler != null)
            {
                handler(sender, new OcsMensajeLecturaDatosEventArgs(OcsMensajeFactory.ObtenerMensajeDatos(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoLecturaAlarmasActivas.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoLecturaAlarmasActivas(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoLecturaAlarmasActivas;
            if (handler != null)
            {
                handler(sender, new OcsMensajeLecturaAlarmasActivasEventArgs(OcsMensajeFactory.ObtenerMensajeAlarmasActivas(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoLecturaDispositivos.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoLecturaDispositivos(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoLecturaDispositivos;
            if (handler != null)
            {
                handler(sender, new OcsMensajeLecturaDispositivosEventArgs(OcsMensajeFactory.ObtenerMensajeDispositivos(mensaje)));
            }
        }
        /// <summary>
        /// Elevar el evento MensajeRecibidoEscritura.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="mensaje">Mensaje recibido.</param>
        protected virtual void OnMensajeRecibidoEscritura(object sender, IMensaje mensaje)
        {
            var handler = MensajeRecibidoEscritura;
            if (handler != null)
            {
                handler(sender, new OcsMensajeEscrituraEventArgs(OcsMensajeFactory.ObtenerMensajeEscritura(mensaje)));
            }
        }
        #endregion Mensajes recibidos

        #endregion Métodos protegidos de eventos elevados
    }
}