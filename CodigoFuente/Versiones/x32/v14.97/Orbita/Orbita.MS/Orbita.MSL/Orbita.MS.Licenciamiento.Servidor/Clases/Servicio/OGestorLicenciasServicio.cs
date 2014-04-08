using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orbita.Trazabilidad;
using Orbita.Comunicaciones;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using Orbita.MS.Excepciones;
using Orbita.MS.Clases.Licencias;
using Orbita.MS.Licencias;

namespace Orbita.MS.Licenciamiento.Servidor
{
    public partial class OGestorLicenciasServidor : Form
    {
        #region Atributos

        /// <summary>
        /// Logger principal
        /// </summary>
        ILogger _log = LogManager.GetLogger("MSLS");
        /// <summary>
        /// Puerto principal de protocolo (conexión de control)
        /// </summary>
        int _protocoloPuerto = 3625;
        /// <summary>
        /// Nombre de instancia de escucha predeterminada.
        /// </summary>
        string _protocoloInstancia = "127.0.0.1";
        /// <summary>
        /// Lista de interfaces de escucha
        /// </summary>
        List<string> _protocoloInterfaces = new List<string>() { "127.0.0.1" };
        /// <summary>
        /// Número máximo de clientes
        /// </summary>
        int _protocoloNumMaxClientes = 99;
        /// <summary>
        /// Listener principal (conexión de control, aceptación de conexiones).
        /// </summary>
        OListenerServidor _protocoloListener;
        /// <summary>
        /// Listeners de conexiones de clientes
        /// </summary>
        Dictionary<string, OListenerServidor> _protocoloConexiones = new Dictionary<string, OListenerServidor>() { };

        OGestorDispositivos.OInstanciaLicenciasOrbita _instancias = new OGestorDispositivos.OInstanciaLicenciasOrbita();
        #endregion Atributos
        #region Constructor
        
        public OGestorLicenciasServidor()
        {
            InitializeComponent();
            //Inicializamos el listener de control del protocolo
            int.TryParse(Properties.Settings.Default.PRT_PuertoControl.ToString(), out _protocoloPuerto);
            int.TryParse(Properties.Settings.Default.PRT_NumMaximoClientes.ToString(), out _protocoloNumMaxClientes);
            _protocoloListener = new OListenerServidor(_log, _protocoloPuerto, _protocoloInstancia);
            //Asociamos los eventos
            _protocoloListener.WskClientDataArrival += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskClientDataArrival);
            _protocoloListener.WskClientErrorReceived += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskClientErrorReceived);
            _protocoloListener.WskClientSendComplete += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskClientSendComplete);
            _protocoloListener.WskClientStateChanged += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskClientStateChanged);
            _protocoloListener.WskConnectionRequest += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskConnectionRequest);
            _protocoloListener.WskErrorReceived += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskErrorReceived);
            _protocoloListener.WskStateChanged += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloListener_WskStateChanged);
            //Suscribir a los eventos de sistema de nuevo dispositivo y desconexión.
            UsbNotification.RegisterUsbDeviceNotification(this.Handle); 
            //FrmPruebas frm = new FrmPruebas();
        }
        #endregion Constructor
        #region Métodos privados
        /// <summary>
        /// Obtiene el primer puerto TCP/IP libre.
        /// </summary>
        /// <returns></returns>
        private int GetPuertoTCPLibre()
        {
            TcpListener tcpPuerto = new TcpListener(IPAddress.Loopback, 0);
            tcpPuerto.Start();
            int puerto = ((IPEndPoint)tcpPuerto.LocalEndpoint).Port;
            tcpPuerto.Stop();
            return puerto;
        }

        /// <summary>
        /// Eliminamos una conexión cliente.
        /// </summary>
        /// <param name="nombreInstancia">Nombre de la instancia a eliminar</param>
        private bool EliminarConexionCliente(string nombreInstancia)
        {
            if (!_protocoloConexiones.ContainsKey(nombreInstancia))
            {
                //La instancia (ya) no consta en el sistema.
                return false;
            }
            try
            {
                //Desasociamos los eventos
                _protocoloConexiones[nombreInstancia].WskClientDataArrival -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientDataArrival);
                _protocoloConexiones[nombreInstancia].WskClientErrorReceived -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientErrorReceived);
                _protocoloConexiones[nombreInstancia].WskClientSendComplete -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientSendComplete);
                _protocoloConexiones[nombreInstancia].WskClientStateChanged -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientStateChanged);
                _protocoloConexiones[nombreInstancia].WskConnectionRequest -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskConnectionRequest);
                _protocoloConexiones[nombreInstancia].WskErrorReceived -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskErrorReceived);
                _protocoloConexiones[nombreInstancia].WskStateChanged -= new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskStateChanged);
                //Finalizamos las comunicaciones pendientes
                foreach(OWinSockCliente wcliente in _protocoloConexiones[nombreInstancia].PoolCliente )
                {
                    //Cerrar la conexión.
                    //TODO: Poder realizar un .Close()
                    
                }
                _protocoloConexiones[nombreInstancia].PoolCliente.Clear();

                _protocoloConexiones[nombreInstancia] = null;
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                _log.Error(e1);
                throw e1;
            }

            return true;
        }
        /// <summary>
        /// Procesa una nueva conexión
        /// </summary>
        /// <param name="nombreInstancia"></param>
        /// <returns>Mensaje a enviar al cliente.</returns>
        private string RegistrarNuevaConexionCliente(string nombreInstancia, string codeName = "")
        {
            string res = "";
            try
            {
                //Verificamos el número de clientes conectados.
                int clientesActual = _protocoloConexiones.Count;
                if (clientesActual + 1 >= _protocoloNumMaxClientes)
                {
                    res = GetMensaje_NuevaConexion_NACK_NumeroMaximoConexiones(codeName);
                }
                
                //Verificamos que no exista una instancia con ese mismo nombre.
                verificarInstancia:
                if (_protocoloConexiones.ContainsKey(nombreInstancia))
                {
                    //Generamos nuevo nombre de instancia
                    nombreInstancia = nombreInstancia + new Random(5454).Next(1, 9999);
                    //Verificamos de nuevo que no exista.
                    goto verificarInstancia;
                }
                //Obtenemos un puerto TCP/IP libre y creamos el listener para el cliente.
                int puerto = GetPuertoTCPLibre();
                OListenerServidor cliente = new OListenerServidor(_log, puerto, nombreInstancia);
                //Asociamos los eventos
                cliente.WskClientDataArrival += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientDataArrival);
                cliente.WskClientErrorReceived += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientErrorReceived);
                cliente.WskClientSendComplete += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientSendComplete);
                cliente.WskClientStateChanged += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskClientStateChanged);
                cliente.WskConnectionRequest += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskConnectionRequest);
                cliente.WskErrorReceived += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskErrorReceived);
                cliente.WskStateChanged += new Orbita.Comunicaciones.OManejadorEventoComm(_protocoloConexiones_WskStateChanged);

                //Añadimos el listener
                _protocoloConexiones.Add(nombreInstancia, cliente);
                //Generamos el mensaje de conexión
                res = GetMensaje_NuevaConexion_ACK(puerto,nombreInstancia,codeName);
            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                _log.Error(e1);
                res = GetMensaje_ErrorExcepcion(e1);

            }
            return res;
        }

        /// <summary>
        /// Genera el mensaje ACK de respuesta de la nueva conexión.
        /// </summary>
        /// <param name="puertoConexion"></param>
        /// <param name="nombreInstancia"></param>
        /// <returns></returns>
        private string GetMensaje_NuevaConexion_ACK(int puertoConexion, string nombreInstancia, string codeName = "")
        {
            string res = OGestorProtocolo.S_ACK_SolicitaCanal(this._protocoloInterfaces[0], puertoConexion, codeName, nombreInstancia);
            return res;
        }
        /// <summary>
        /// Genera el error de número máximo de conexioens.
        /// </summary>
        /// <returns></returns>
        private string GetMensaje_NuevaConexion_NACK_NumeroMaximoConexiones(string codeName = "")
        {
            string res = OGestorProtocolo.S_NACK_SolicitaCanal("NUM_MAX_CANAL", codeName);
            return res;
        }
        /// <summary>
        /// Genera un mensaje de error basado en una excepción.
        /// </summary>
        /// <param name="e1"></param>
        /// <returns></returns>
        private string GetMensaje_ErrorExcepcion(Exception e1, string codeName = "")
        {
            string res = OGestorProtocolo.S_NotificarError("EXC", "500", e1.Message, e1.Source, codeName);
            return res;
        }
        /// <summary>
        /// Genera un mensaje de error
        /// </summary>
        /// <param name="e1"></param>
        /// <returns></returns>
        private string GetMensaje_Error(string mensaje = "", string sdatos = "", string codError = "PRT", string idError = "500", string codeName = "")
        {
            return OGestorProtocolo.S_NotificarError(codError, idError, mensaje, "", codeName);
        }
        /// <summary>
        /// Obtiene el mensaje canal (OMensajeCanalTCP) de los eventos
        /// </summary>
        /// <param name="e"></param>
        /// <param name="imprimirMensaje"></param>
        /// <returns></returns>
        private OMensajeCanalTCP GetMensajeCanal(Utiles.OEventArgs e, bool imprimirMensaje = true)
        {
            OMensajeCanalTCP mensaje = (OMensajeCanalTCP)e.Argumento;
            if (mensaje != null)
            {
                if(imprimirMensaje) Console.WriteLine("[#] " + mensaje.Listener + " : " + mensaje.Canal + " = " + mensaje.Mensaje);
                _log.Info("[#] " + mensaje.Listener + " : " + mensaje.Canal + " = " + mensaje.Mensaje);
            }
            return mensaje;
        }
        #endregion Métodos privados
        #region Eventos
        #region Protocolo - Conexión de control
        
        /// <summary>
        /// El estado de la conexión del servidor ha cambiado.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskStateChanged(Utiles.OEventArgs e)
        {

            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Se ha recibido un error.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Solicitud de conexión
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskConnectionRequest(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// El estado del cliente ha cambiado.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskClientStateChanged(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// El envío se ha completado
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskClientSendComplete(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Han llegado datos desde el cliente
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskClientDataArrival(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
            //Verificamos integridad del mensaje, debe de ser deserializable como OMensajeCanalTCP
            if (mensaje == null)
            {
                Console.Error.WriteLine("Mensaje inválido procesado.");
                _log.Error("Mensaje inválido procesado.");
                return;
            }
            ProcesarMensajeCliente(mensaje);
            //_protocoloListener.EnviarMensaje("ACK. Puerto de conexión:55");
            //_protocoloListener.
        }


        private void ProcesarError(OMensajeXML mensaje)
        {

        }

        private void ProcesarIndefinido(OMensajeXML mensaje)
        {
            ProcesarPeticionInvalida(mensaje);
        }

        private void ProcesarMensajeClienteServidor(OMensajeXML mensaje)
        {

        }

        private void ProcesarMensajeServidorCliente(OMensajeXML mensaje)
        {
            ProcesarPeticionInvalida(mensaje);
        }

        private void ProcesarRegistrarInicio(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {
                default:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                    _log.Info("Nueva comunicación por canal dedicado.");
                    //OGestorDispositivos.DescubrirLicenciasHASP();
                    if (mensaje.Atributos.Count < 1)
                    {
                        throw new Exception("Mensaje no válido. Faltan argumentos");
                    }
                    string xmlAplicacion = mensaje.Atributos[0];
                    ArrayList atributoFinal = OMensajeXML.DescifrarAtributoMensajeXML(xmlAplicacion, new List<Type>() { typeof(OProcesoAplicacion), typeof(OAplicacion) });
                    OProcesoAplicacion _proceso = (OProcesoAplicacion)atributoFinal[0];
                    if (_proceso != null)
                    {
                        string ninstancia = "";
                        _protocoloConexiones[ninstancia]._proceso = _proceso;
                        _protocoloConexiones[ninstancia]._aplicacion = _proceso.PDatosLicenciamiento;
                        _log.Info(_proceso.PNombre);
                        //Buscamos productos
                        if (_instancias.licencias.Count < 1)
                        {
                            _instancias = OGestorDispositivos.DescubrirLicenciasHASP();
                        }
                        try{
                        foreach(int idprod in _proceso.PDatosLicenciamiento.IdProductos)
                        {
                            OLicenciaProducto prod = (OLicenciaProducto) _instancias.productos.Select(x => x.Id == idprod);
                            prod.IncrementarUso(_proceso.PID.ToString(), 1);
                        }
                        }catch(Exception e1)
                        {

                        }
                    }
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                    ProcesarPeticionInvalida(mensaje);
                    break;
            }

            //if (mensaje.Atributos.Count > 0)
            //{
            //    string xmlAplicacion = mensaje.Atributos[0];
            //    ArrayList atributoFinal = OMensajeXML.DescifrarAtributoMensajeXML(xmlAplicacion, new List<Type>() { typeof(OProcesoAplicacion), typeof(OAplicacion) });
            //}
        }


        private void ProcesarPeticionInvalida(OMensajeXML mensaje)
        {
            GetMensaje_Error("Petición inválida.",mensaje.ObtenerMensajeCifrado(),"PRT","400","");
        }
        private void ProcesarCanalInicio(OMensajeXML mensaje)
        {
            switch(mensaje._tipo)
            {
                default:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                    _log.Info("Inicio de solictud de canal seguro");
                    if (mensaje.Atributos.Count < 1)
                    {
                        throw new Exception("Mensaje no válido. Faltan argumentos");
                    }
                    string xmlPetCInicio = mensaje.Atributos[0];
                    ArrayList atrPetCInicio = OMensajeXML.DescifrarAtributoMensajeXML(xmlPetCInicio, new List<Type>() { typeof(OGestorProtocolo.C_Datos_ClienteSolicitaCanal) });
                    OGestorProtocolo.C_Datos_ClienteSolicitaCanal dPetCInicio = (OGestorProtocolo.C_Datos_ClienteSolicitaCanal)atrPetCInicio[0];
                    //if (dPetCInicio == null)
                    //{
                    //    throw new Exception("Mensaje no válido. C_Datos_ClienteSolicitaCanal inválido/ilegible.");
                    //}
                    _log.Info(dPetCInicio.NombreAplicacion + " en " + dPetCInicio.NombreEquipo + " (" + dPetCInicio.VersionAplicacion + ") solicita canal seguro e identificarse como " + dPetCInicio.CodeName + " usando la versión de protocolo " + dPetCInicio.VersionComunicacion);
                    string respetCInicio = RegistrarNuevaConexionCliente(dPetCInicio.CodeName, dPetCInicio.CodeName);
                    this._protocoloListener.EnviarMensaje(respetCInicio);
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                    ProcesarPeticionInvalida(mensaje);
                    break;
            }
        }

        private void ProcesarRecargarLicencias(OMensajeXML mensaje)
        {
            switch (mensaje._tipo)
            {
                default:
                case Comunicaciones.OMensajeXMLTipoMensaje.Solicitud:
                    _log.Info("Petición de reproceso de dispositivos y licencias.");
                    OGestorDispositivos.DescubrirLicenciasHASP();
                    break;
                case Comunicaciones.OMensajeXMLTipoMensaje.ACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.NACK:
                case Comunicaciones.OMensajeXMLTipoMensaje.Error:
                case Comunicaciones.OMensajeXMLTipoMensaje.Notificacion:
                    ProcesarPeticionInvalida(mensaje);
                    break;
            }
        }

        private void ProcesarRegistrarSalida(OMensajeXML mensaje)
        {

        }

        private void ProcesarDesconexionForzada(OMensajeXML mensaje)
        {

        }
        private void ProcesarConsultaLicencia(OMensajeXML mensaje)
        {

        }
        /// <summary>
        /// Procesa los mensajes procedentes del cliente
        /// </summary>
        /// <param name="mensaje"></param>
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
                    case Comunicaciones.OMensajeXMLOperacion.Error:
                        ProcesarError(mensaje);
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
                    case Comunicaciones.OMensajeXMLOperacion.RecargarLicencias:
                        ProcesarRecargarLicencias(mensaje);
                        break;
                }

            }
            catch (Exception e1)
            {
                Console.Error.WriteLine(e1);
                _log.Error(e1);
            }
        }
        /// <summary>
        /// Se ha recibido un error desde el cliente.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloListener_WskClientErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        #endregion
        #region Protocolo - Conexiones dinámicas de cliente
        /// <summary>
        /// El estado de la conexión del servidor ha cambiado.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskStateChanged(Utiles.OEventArgs e)
        {

            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Se ha recibido un error.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Solicitud de conexión
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskConnectionRequest(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// El estado del cliente ha cambiado.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskClientStateChanged(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// El envío se ha completado
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskClientSendComplete(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        /// <summary>
        /// Han llegado datos desde el cliente
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskClientDataArrival(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
            ProcesarMensajeCliente(mensaje);
        }
        /// <summary>
        /// Se ha recibido un error desde el cliente.
        /// </summary>
        /// <param name="e"></param>
        void _protocoloConexiones_WskClientErrorReceived(Utiles.OEventArgs e)
        {
            OMensajeCanalTCP mensaje = GetMensajeCanal(e);
        }
        #endregion
        #region Detección de dispositivos, licencias
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        EventoDispositivoEliminadoSistema();
                        break;
                    case UsbNotification.DbtDevicearrival:
                        EventoDispositivoNuevoSistema();
                        break;
                    case UsbNotification.WmDevicechange:
                        EventoDispositivoNuevoSistema();
                        break;
                }
            }
        }
        /// <summary>
        /// Se ha eliminado un dispositivo del sistema
        /// </summary>
        private void EventoDispositivoEliminadoSistema()
        {
            MessageBox.Show("Se ha quitado un dispositivo");
            DetectarDispositivos();
        }
        /// <summary>
        /// Un nuevo dispositivo se ha añadido al sistema
        /// </summary>
        private void EventoDispositivoNuevoSistema()
        {
            MessageBox.Show("Se ha añadido un dispositivo al sistema");
            DetectarDispositivos();
        }


        /// <summary>
        /// Detecta los dispositivos de licenciamiento y las características y productos asociados.
        /// </summary>
        protected void DetectarDispositivos()
        {
            try
            {
                OGestorDispositivos.OInstanciaLicenciasOrbita instancia = OGestorDispositivos.DescubrirLicenciasHASP();
                Console.WriteLine(instancia.licencias.ToString());
                string mensaje = "Licencias:\r\n";
                foreach (OLicenciaBase lic in instancia.licencias)
                {
                    mensaje += lic.ToString() + "\r\n";
                }
                mensaje += "Productos:\r\n";
                foreach (OLicenciaProducto prod in instancia.productos)
                {
                    mensaje += prod.ToString() + "\r\n";
                }
                mensaje += "Caracteristicas:\r\n";
                foreach (OLicenciaCaracteristica car in instancia.caracteristicas)
                {
                    mensaje += car.ToString() + "\r\n";
                }
                MessageBox.Show(mensaje);
            }
            catch (OExcepcionLicenciaHASP e0)
            {
                switch (e0.Data["Estado"].ToString())
                {
                    default:
                        MessageBox.Show(e0.Message);
                        break;
                    case "EmptyScopeResults":
                        MessageBox.Show("No hay dispositivos que contengan licencias conectados al sistema.");
                        break;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        #endregion
        #endregion Eventos
    }
}
