using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orbita.Comunicaciones;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace Orbita.MS
{
    public partial class OGestorLicenciasCliente
    {
        //Contiene las implementaciones relativas al protocolo de comunicación, recepción de mensajes y su tratamiento
        #region Métodos privados
        #region Inicialización de conexiones
        /// <summary>
        /// Inicialización de la conexión del protocolo
        /// </summary>
        private void InicializarConexionControlProtocolo()
        {
            //Configuramos un nombre de cliente para las comunicaciones
            _codeName = Assembly.GetExecutingAssembly().GetName().Name.Replace(".exe", "_DEV01_") + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "") + "_";
            //Inicializamos la conexión de cliente.
            _protocoloConexion = new OConexionCliente(_log, _protocoloInstancia, _protocoloPuerto, _codeName);
            _protocoloConexion.ODataArrival += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexion_ODataArrival);
            _protocoloConexion.OErrorReceived += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexion_OErrorReceived);
            _protocoloConexion.OSendComplete += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexion_OSendComplete);
            _protocoloConexion.OStateChanged += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexion_OStateChanged);
        }
        /// <summary>
        /// Prepara una conexión persistente
        /// </summary>
        /// <param name="ip">IP servidor</param>
        /// <param name="puerto">Puerto</param>
        /// <param name="instancia">Nombre de la instancia</param>
        /// <param name="codeName">Key</param>
        public void EstablecerConexionPersistente(string ip, int puerto, string instancia, string codeName)
        {
            _protocoloConexion = new OConexionCliente(_log, ip, puerto, instancia);
        }
        #endregion Inicialización de conexiones

        #region Preprocesado de mensajes
        /// <summary>
        /// Obtiene el mensaje canal de los eventos
        /// </summary>
        /// <param name="e">Evento de mensaje</param>
        /// <param name="imprimirMensaje">Imprime el mensaje</param>
        /// <returns></returns>
        private OMensajeCanalTCP GetMensajeCanal(Utiles.OEventArgs e, bool imprimirMensaje = true)
        {
            OMensajeCanalTCP mensaje = (OMensajeCanalTCP)e.Argumento;
            if (mensaje != null)
            {
                if (imprimirMensaje) Console.WriteLine("[#] " + mensaje.Listener + " : " + mensaje.Canal + " = " + mensaje.Mensaje);
                _log.Info("[#] " + mensaje.Listener + " : " + mensaje.Canal + " = " + mensaje.Mensaje);
            }
            return mensaje;
        }
        #endregion Preprocesado de mensajes

        #region Recepción mensajes
        /// <summary>
        /// Procesa los mensajes procedentes del cliente
        /// </summary>
        /// <param name="mensaje">Mensaje TCP RAW (sin decodificar ni descifrar)</param>
        private void ProcesarMensajeCliente(OMensajeCanalTCP mensajeTCP)
        {
            string mensajeTrans = "";

            try
            {
                byte[] mbase = (byte[])mensajeTCP.Data;
                mensajeTrans = OMensajeXML.ByteArrayAString(mbase);
                OMensajeXML mensaje = OMensajeXML.DescifrarMensajeXML(mensajeTrans);
                int natributos = mensaje.Atributos.Count;
                switch (mensaje.Operacion)
                {
                    default:
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.Indefinido:
                        ProcesarIndefinido(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.MensajeClienteServidor:
                        ProcesarMensajeClienteServidor(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.MensajeServidorCliente:
                        ProcesarMensajeServidorCliente(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.RegistrarInicio:
                        ProcesarRegistrarInicio(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.RegistrarSalida:
                        ProcesarRegistrarSalida(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.DesconexionForzada:
                        ProcesarDesconexionForzada(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.ConsultaLicencia:
                        ProcesarConsultaLicencia(mensaje);
                        break;
                    case Comunicaciones.OMensajeXMLOperacion.CanalInicio:
                        ProcesarCanalInicio(mensaje);
                        break;
                }

            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                _log.Error(e1);
            }
        }
        #endregion Recepción mensajes

        #region Acciones mensajes
        /// <summary>
        /// Genera un mensaje de error basado en una excepción.
        /// </summary>
        /// <param name="e1"></param>
        /// <returns></returns>
        private string GetMensaje_ErrorExcepcion(Exception e1, string codeName = "")
        {
            string res = OGestorProtocolo.C_NotificarError("EXC", "500", e1.Message, e1.Source, codeName);
            return res;
        }
        /// <summary>
        /// Genera un mensaje de error
        /// </summary>
        /// <param name="e1"></param>
        /// <returns></returns>
        private string GetMensaje_Error(string mensaje = "", string sdatos = "", string codError = "PRT", string idError = "500", string codeName = "")
        {
            return OGestorProtocolo.C_NotificarError(codError, idError, mensaje, "", codeName);
        }
        /// <summary>
        /// Proceso de mensaje desconocido
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarIndefinido(OMensajeXML mensaje)
        {
            ProcesarPeticionInvalida(mensaje);
        }
        /// <summary>
        /// Procesa mensaje de cliente - servidor
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarMensajeClienteServidor(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {
                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Indefinido:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                default:
                    ProcesarPeticionInvalida(mensaje);
                    break;
            }
        }
        /// <summary>
        /// Procesa mensaje servidor - cliente
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarMensajeServidorCliente(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {

                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Indefinido:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                default:
                    ProcesarPeticionInvalida(mensaje);
                    break;

            }
        }
        /// <summary>
        /// Procesa RegistrarInicio
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarRegistrarInicio(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {

                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                    if (this.LicenciaValida != null)
                    {
                        OLicenciaClienteEventArgs e = new OLicenciaClienteEventArgs();
                        e.Datos.Add(mensaje._operacion);
                        e.Datos.Add(mensaje._tipo);
                        this.LicenciaValida(e);
                    }
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                    if (this.LicenciaInvalida != null)
                    {
                        OLicenciaClienteEventArgs e0 = new OLicenciaClienteEventArgs();
                        e0.Datos.Add(mensaje._operacion);
                        e0.Datos.Add(mensaje._tipo);
                        this.LicenciaInvalida(e0);
                    }
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                    if (this.LicenciaInvalida != null)
                    {
                        OLicenciaClienteEventArgs e1 = new OLicenciaClienteEventArgs();
                        e1.Datos.Add(mensaje._operacion);
                        e1.Datos.Add(mensaje._tipo);
                        this.LicenciaInvalida(e1);
                    }
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Indefinido:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                default:
                    ProcesarPeticionInvalida(mensaje);
                    break;

            }

            if (mensaje.Atributos.Count > 0)
            {
                string xmlAplicacion = mensaje.Atributos[0];
                ArrayList atributoFinal = OMensajeXML.DescifrarAtributoMensajeXML(xmlAplicacion, new List<Type>() { typeof(OProcesoAplicacion), typeof(OAplicacion) });
            }
        }

        /// <summary>
        /// Acciones a realizar en caso de una petición inválida
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarPeticionInvalida(OMensajeXML mensaje)
        {
            GetMensaje_Error("Petición inválida.", mensaje.ObtenerMensajeCifrado(), "PRT", "400", "");
        }
        
        /// <summary>
        /// Proceso de CanalInicio
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarCanalInicio(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {

                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                    _log.Info("Respuesta afirmativa, se concede canal de comunicación.");
                    if (mensaje.Atributos.Count < 1)
                    {
                        throw new Exception("Mensaje no válido. Faltan argumentos");
                    }
                    string xmlACK = mensaje.Atributos[0];
                    ArrayList atrACK = OMensajeXML.DescifrarAtributoMensajeXML(xmlACK, new List<Type>() { typeof(OGestorProtocolo.S_ACK_ClienteSolicitaCanal) });
                    OGestorProtocolo.S_ACK_ClienteSolicitaCanal dACK = (OGestorProtocolo.S_ACK_ClienteSolicitaCanal)atrACK[0];
                    //if (dPetCInicio == null)
                    //{
                    //    throw new Exception("Mensaje no válido. C_Datos_ClienteSolicitaCanal inválido/ilegible.");
                    //}
                    _log.Info(dACK.NombreServidor + " " + dACK.IP + ":" + dACK.Puerto + " -> " + dACK.IdComunicacion + "|" + dACK.CodeName + "|" + dACK.VersionComunicacion);
                    this._codeName = dACK.CodeName;
                    this._estadoComunicacion = OEstadoComunicacionCliente.ConexionPendiente;
                    this._conexionPuerto = dACK.Puerto;
                    this._conexionServidor = dACK.IP;
                    this._nombreInstancia = dACK.IP;//dACK.IdComunicacion;
                    IniciarComunicacionPersistente();
                    if (this._aplicacion != null)
                    {
                        RegistrarLicenciasDeclaradas();

                    }
                    //TODO: Finalizar conexión con servidor, el Listener no permite finalizar la conexión.
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                    this._estadoComunicacion = OEstadoComunicacionCliente.ConexionPendienteRechazada;
                    OLicenciaClienteEventArgs e = new OLicenciaClienteEventArgs();
                    e.Datos.Add("Conexión pendiente rechazada");
                    e.Datos.Add(mensaje._tipo);
                    if (this.LicenciaErrorComunicacion != null)
                    {
                        this.LicenciaErrorComunicacion(e);
                    }
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                    this._estadoComunicacion = OEstadoComunicacionCliente.ConexionPendienteRechazada;
                    this._estadoComunicacion = OEstadoComunicacionCliente.ConexionPendienteRechazada;
                    OLicenciaClienteEventArgs e0 = new OLicenciaClienteEventArgs();
                    e0.Datos.Add("Conexión pendiente rechazada");
                    e0.Datos.Add(mensaje._tipo);
                    if (this.LicenciaErrorComunicacion != null)
                    {
                        this.LicenciaErrorComunicacion(e0);
                    }
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Indefinido:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:

                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                default:
                    ProcesarPeticionInvalida(mensaje);
                    break;

            }

        }
        /// <summary>
        /// Registra salida de aplicación
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarRegistrarSalida(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {

                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                    this.LicenciaSalidaAplicacion(new OLicenciaClienteEventArgs("Debe salir de la aplicación."));
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Indefinido:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                default:
                    ProcesarPeticionInvalida(mensaje);
                    break;

            }
        }
        /// <summary>
        /// Procesa una desconexión forzada
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarDesconexionForzada(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {

                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:

                    ProcesarPeticionInvalida(mensaje);
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.Indefinido:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                default:
                    if (this.LicenciaSalidaAplicacion != null)
                    {
                        OLicenciaClienteEventArgs e = new OLicenciaClienteEventArgs("Desconexión forzada");
                        e.Datos.Add("Desconexión solicitada por el servidor");
                        this.LicenciaSalidaAplicacion(e);
                    }
                    Application.Exit();
                    break;

            }
        }
        /// <summary>
        /// Procesa los mensajes de ConsultaLicencia
        /// </summary>
        /// <param name="mensaje"></param>
        private void ProcesarConsultaLicencia(OMensajeXML mensaje)
        {

            ProcesarPeticionInvalida(mensaje);
        }
        #endregion Protocolo mensajes

        #endregion Métodos privados
    }
}
