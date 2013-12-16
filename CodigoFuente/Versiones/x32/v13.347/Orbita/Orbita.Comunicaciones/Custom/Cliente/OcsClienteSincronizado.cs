//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase proporciona la funcionalidad básica para todas las clases de clientes.
    /// </summary>
    public class OcsClienteSincronizado : OcsCliente, IOcsClienteSincronizado
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsClienteSincronizado con la dirección Ip local (127.0.0.1)
        /// del servidor.
        /// </summary>
        /// <param name="puertoTcpRemoto">Puerto Tcp de escucha del servidor remoto.</param>
        /// <param name="periodoReConexionMs">Período de reconexión del cliente (opcional, en milisegundos).</param>
        public OcsClienteSincronizado(int puertoTcpRemoto, int periodoReConexionMs = 0)
            : this("127.0.0.1", puertoTcpRemoto, periodoReConexionMs) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsClienteSincronizado.
        /// </summary>
        /// <param name="direccionIpRemoto">Dirección IP del servidor remoto.</param>
        /// <param name="puertoTcpRemoto">Puerto Tcp de escucha del servidor remoto.</param>
        /// <param name="periodoReConexionMs">Período de reconexión del cliente (opcional, en milisegundos).</param>
        public OcsClienteSincronizado(string direccionIpRemoto, int puertoTcpRemoto, int periodoReConexionMs = 0)
            : base(direccionIpRemoto, puertoTcpRemoto, periodoReConexionMs) { }
        #endregion Constructores

        #region Métodos públicos
        /// <summary>
        /// Leer la colección de valores de variables demandadas en el dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se realiza bajo demanda al dispositivo.</param>
        /// <param name="timeoutMs">Valor de tiempo de espera en milisegundos para esperar recibir un mensaje de la llamada al método de Lectura(...).
        /// Valor predeterminado: 60000 ms (1 minuto).</param>
        public IOcsMensajeLectura Leer(int dispositivo, string[] variables, bool demanda, int timeoutMs = 60000)
        {
            IMensaje respuesta;
            using (var mensajero = new OcsMensajeroPeticionRespuesta<ICliente>(Cliente))
            {
                var mensaje = OcsMensajeFactory.CrearMensajeLectura(dispositivo, variables, demanda);
                mensajero.TimeoutMs = timeoutMs;
                respuesta = mensajero.EnviarMensajeEsperarRespuesta(mensaje, timeoutMs);
            }
            if (respuesta != null) return (IOcsMensajeLectura)respuesta;
            return null;
        }
        /// <summary>
        /// Leer la colección de datos del dispositivo especificado.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="timeoutMs">Valor de tiempo de espera en milisegundos para esperar recibir un mensaje de la llamada al método de Lectura(...).
        /// Valor predeterminado: 60000 ms (1 minuto).</param>
        public IOcsMensajeLecturaDatos LeerDatos(int dispositivo, int timeoutMs = 60000)
        {
            IMensaje respuesta;
            using (var mensajero = new OcsMensajeroPeticionRespuesta<ICliente>(Cliente))
            {
                var mensaje = OcsMensajeFactory.CrearMensajeDatos(dispositivo);
                mensajero.TimeoutMs = timeoutMs;
                respuesta = mensajero.EnviarMensajeEsperarRespuesta(mensaje, timeoutMs);
            }
            if (respuesta != null) return (IOcsMensajeLecturaDatos)respuesta;
            return null;
        }
        /// <summary>
        /// Leer la colección de alarmas activas del dispositivo especificado.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="timeoutMs">Valor de tiempo de espera en milisegundos para esperar recibir un mensaje de la llamada al método de Lectura(...).
        /// Valor predeterminado: 60000 ms (1 minuto).</param>
        public IOcsMensajeLecturaAlarmasActivas LeerAlarmasActivas(int dispositivo, int timeoutMs = 60000)
        {
            IMensaje respuesta;
            using (var mensajero = new OcsMensajeroPeticionRespuesta<ICliente>(Cliente))
            {
                var mensaje = OcsMensajeFactory.CrearMensajeAlarmasActivas(dispositivo);
                mensajero.TimeoutMs = timeoutMs;
                respuesta = mensajero.EnviarMensajeEsperarRespuesta(mensaje, timeoutMs);
            }
            if (respuesta != null) return (IOcsMensajeLecturaAlarmasActivas)respuesta;
            return null;
        }
        /// <summary>
        /// Leer la colección de dispositivos.
        /// </summary>
        /// <param name="timeoutMs">Valor de tiempo de espera en milisegundos para esperar recibir un mensaje de la llamada al método de Lectura(...).
        /// Valor predeterminado: 60000 ms (1 minuto).</param>
        public IOcsMensajeLecturaDispositivos LeerDispositivos(int timeoutMs = 60000)
        {
            IMensaje respuesta;
            using (var mensajero = new OcsMensajeroPeticionRespuesta<ICliente>(Cliente))
            {
                var mensaje = OcsMensajeFactory.CrearMensajeDispositivos();
                mensajero.TimeoutMs = timeoutMs;
                respuesta = mensajero.EnviarMensajeEsperarRespuesta(mensaje, timeoutMs);
            }
            if (respuesta != null) return (IOcsMensajeLecturaDispositivos)respuesta;
            return null;
        }
        /// <summary>
        /// Escribir el valor indicado de las variables en el dispositivo asociado indicando el canal.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal">Identificador de canal.</param>
        /// <param name="timeoutMs">Valor de tiempo de espera en milisegundos para esperar recibir un mensaje de la llamada al método de Escritura(...).
        /// Valor predeterminado: 60000 ms (1 minuto).</param>
        public IOcsMensajeEscritura Escribir(int dispositivo, string[] variables, object[] valores, string canal, int timeoutMs = 60000)
        {
            IMensaje respuesta;
            using (var mensajero = new OcsMensajeroPeticionRespuesta<ICliente>(Cliente))
            {
                var mensaje = OcsMensajeFactory.CrearMensajeEscritura(dispositivo, variables, valores, canal);
                mensajero.TimeoutMs = timeoutMs;
                respuesta = mensajero.EnviarMensajeEsperarRespuesta(mensaje, timeoutMs);
            }
            if (respuesta != null) return (IOcsMensajeEscritura)respuesta;
            return null;
        }
        #endregion Métodos públicos

        #region Manejadores de eventos
        /// <summary>
        /// Manejador del evento MensajeRecibido para el cliente que ha iniciado el canal de comunicación.
        /// </summary>
        /// <param name="sender">Contiene una referencia al objeto que provocó el evento.</param>
        /// <param name="e">MensajeEventArgs que contiene los datos del evento.</param>
        protected override void Cliente_MensajeRecibido(object sender, MensajeEventArgs e)
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
            }
        }
        #endregion Manejadores de eventos
    }
}