//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 06-09-2012
//
// Last Modified By : aibañez
// Last Modified On : 13-12-2012
// Description      : Adaptado a la versión del servidor de comunicaciones.
//                    Un solo tipo de terminal (de objeto)
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Orbita.Comunicaciones;
using Orbita.Utiles;
using Orbita.VA.Comun;
using System.Diagnostics;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase que implementa las funciones para el control de Entradas/Salidas del Servidor de comunicaciones
    /// </summary>
    public class OClienteComunicacion : OModuloIOBase
    {
        #region Constante(s)
        private const int NumMaxLlamadasSimultaneas = 5;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Si están o no configurados los terminales
        /// </summary>
        private bool _Valido;
        /// <summary>
        /// Servidor de comunicaciones.
        /// </summary>
        private IOCommRemoting Servidor;
        /// <summary>
        /// <summary>
        /// Wrapper de comunicaciones
        /// </summary>
        private OBroadcastEventWrapper EventWrapper;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento de cambio de dato
        /// </summary>
        private int ContLlamadasSimultaneasCambioDato;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento de conectividad
        /// </summary>
        private int ContLlamadasSimultaneasComm;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento de alarma
        /// </summary>
        private int ContLlamadasSimultaneasAlarma;
        /// <summary>
        /// Timer de comprobación del estado de la conexión
        /// </summary>
        private Timer TimerComprobacionConexion;
        /// <summary>
        /// Cronómetro del tiempo sin respuesta
        /// </summary>
        private Stopwatch CronometroTiempoSinRespuesta;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Dirección del Servidor de comunicaciones
        /// </summary>
        private string _HostServidor;
        /// <summary>
        /// Dirección del servidor de comunicaciones
        /// </summary>
        public string HostServidor
        {
            get { return this._HostServidor; }
            set { this._HostServidor = value; }
        }

        /// <summary>
        /// Número de puerto remoto
        /// </summary>
        private int _PuertoRemoto;
        /// <summary>
        /// Número de puerto remoto
        /// </summary>
        public int PuertoRemoto
        {
            get { return this._PuertoRemoto; }
            set { this._PuertoRemoto = value; }
        }

        /// <summary>
        /// Inervalo entre comprobaciones
        /// </summary>
        private TimeSpan _IntervaloComprabacion;
        /// <summary>
        /// Inervalo entre comprobaciones
        /// </summary>
        public TimeSpan IntervaloComprabacion
        {
            get { return _IntervaloComprabacion; }
            set { _IntervaloComprabacion = value; }
        }
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codHardware">Código del hardware</param>
        public OClienteComunicacion(string codHardware)
            : base(codHardware)
        {
            // Inicialización de variables
            this.ContLlamadasSimultaneasCambioDato = 0;
            this.ContLlamadasSimultaneasComm = 0;
            this.ContLlamadasSimultaneasAlarma = 0;

            // Cargamos valores de la base de datos
            DataTable dtTarjetaIO = AppBD.GetTarjetaIO(codHardware);
            if (dtTarjetaIO.Rows.Count == 1)
            {
                this._HostServidor = dtTarjetaIO.Rows[0]["COM_Host"].ToString();
                this._PuertoRemoto = OEntero.Validar(dtTarjetaIO.Rows[0]["COM_Puerto"], 0, int.MaxValue, 1851);
                this._IntervaloComprabacion = TimeSpan.FromMilliseconds(OEntero.Validar(dtTarjetaIO.Rows[0]["COM_TimeOut"], 1, int.MaxValue, 15000));

                // Creación del timer de comprobación de la conexión
                this.TimerComprobacionConexion = new Timer();
                this.TimerComprobacionConexion.Interval = (int)this._IntervaloComprabacion.TotalMilliseconds;
                this.TimerComprobacionConexion.Enabled = false;

                // Creación del cronómetro de tiempo de espera sin respuesta de la cámara
                this.CronometroTiempoSinRespuesta = new Stopwatch();
            }

            // Cargamos valores de la base de datos buscamos terminales IO
            using (DataTable dtTerminalesIO = AppBD.GetTerminalesIO(codHardware))
            {
                if (dtTerminalesIO.Rows.Count != 0)
                {
                    this._Valido = true;
                    // Crear los terminales leidas por BBDD  
                    foreach (DataRow dr in dtTerminalesIO.Rows)
                    {
                        OTerminalClienteComunicacion terminal;

                        int intTipoTerminalIO = OEntero.Validar(dr["IdTipoTerminalIO"], 1, 4, 1);

                        OTipoTerminalIO tipoTerminalIO = (OTipoTerminalIO)intTipoTerminalIO;

                        switch (tipoTerminalIO)
                        {
                            case OTipoTerminalIO.EntradaDigital:
                            case OTipoTerminalIO.SalidaDigital:
                            default:
                                terminal = new OTerminalClienteComunicacion(codHardware, dr["CodTerminalIO"].ToString());
                                break;
                            case OTipoTerminalIO.SalidaComando:
                                terminal = new OTerminalClienteComunicacionWriteCommand(codHardware, dr["CodTerminalIO"].ToString());
                                break;
                        }

                        this.ListaTerminales.Add(terminal.Codigo, terminal);
                    }
                }
                else
                {
                    this._Valido = false;
                }
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a heredar donde se conecta y se configura la tarjeta de IO
        /// </summary>
        public override void Inicializar()
        {
            try
            {
                // Base inicializar
                base.Inicializar();

                if ((this.Habilitado) && (this._Valido))
                {
                    //Conectamos con el servicio del servidor de comunicaciones
                    this.Conectar();

                    // Se inicializan los terminales
                    foreach (OTerminalClienteComunicacion terminal in this.ListaTerminales.Values)
                    {
                        terminal.Inicializar(this.Servidor);
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }

        }
        /// <summary>
        /// Método a heredar donde se conecta y se configura la tarjeta de IO
        /// </summary>
        public override void Finalizar()
        {
            try
            {
                // Base finalizar
                base.Finalizar();

                // Se finalizan los terminales
                foreach (OTerminalClienteComunicacion terminal in this.ListaTerminales.Values)
                {
                    terminal.Finalizar();
                }

                if ((this.Habilitado) && (this._Valido))
                {
                    // Desconectamos del servicio del servidor de comunicaciones
                    this.Desconectar();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Conectar al servidor vía Remoting.
        /// </summary>
        private void Conectar()
        {
            try
            {
                // Establecer la configuración Remoting entre procesos.
                ORemoting.InicConfiguracionCliente(this.PuertoRemoto, this.HostServidor);
                this.Servidor = (Orbita.Comunicaciones.IOCommRemoting)ORemoting.GetObject(typeof(Orbita.Comunicaciones.IOCommRemoting));

                // Eventwrapper de comunicaciones.
                this.ConectarEventWrapper();

                // Iniciamos la comprobación de la conectividad con la cámara
                this.CronometroTiempoSinRespuesta.Start();
                this.TimerComprobacionConexion.Tick += this.TimerComprobacionConexion_Tick;
                this.TimerComprobacionConexion.Start();

                OLogsVAHardware.EntradasSalidas.Info(this.Codigo, "Conectado al servicio");
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Desconectar del servidor vía Remoting.
        /// </summary>
        private void Desconectar()
        {
            this.DesconectarEventWrapper();

            // Finalizamos la comprobación de la conectividad con la cámara
            this.TimerComprobacionConexion.Stop();
            this.TimerComprobacionConexion.Tick -= this.TimerComprobacionConexion_Tick;
            this.CronometroTiempoSinRespuesta.Stop();

            OLogsVAHardware.EntradasSalidas.Info(this.Codigo, "Desconectado del Servicio");
        }

        /// <summary>
        /// Conectar los eventos
        /// </summary>
        public void ConectarEventWrapper()
        {
            try
            {
                // Eventwrapper de comunicaciones.
                this.EventWrapper = new Orbita.Comunicaciones.OBroadcastEventWrapper();

                //Eventos locales.
                //...cambio de dato.
                this.ContLlamadasSimultaneasCambioDato = 0;
                this.EventWrapper.OrbitaCambioDato += eventWrapper_OrbitaCambioDato;
                //...conectividad.
                this.ContLlamadasSimultaneasComm = 0;
                this.EventWrapper.OrbitaComm += eventWrapper_OrbitaComm;
                // ...alarma
                this.ContLlamadasSimultaneasAlarma = 0;
                this.EventWrapper.OrbitaAlarma += eventWrapper_OrbitaAlarma;

                // Eventos del servidor.
                //...cambio de dato.
                this.Servidor.OrbitaCambioDato += this.EventWrapper.OnCambioDato;
                //...conectividad.
                this.Servidor.OrbitaComm += this.EventWrapper.OnComm;
                // ...alarma
                this.Servidor.OrbitaAlarma += this.EventWrapper.OnAlarma;

                // Establecer conexión con el servidor.
                this.ConectarCanal(true);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, "Excepción al conectar eventos del cliente de comunicaciones", this.Codigo);
            }
        }
        /// <summary>
        /// Desconectar los eventos
        /// </summary>
        public void DesconectarEventWrapper()
        {
            try
            {
                // Establecer conexión con el servidor.
                this.ConectarCanal(false);

                // Eventos del servidor.
                //...cambio de dato.
                this.Servidor.OrbitaCambioDato -= this.EventWrapper.OnCambioDato;
                //...conectividad.
                this.Servidor.OrbitaComm -= this.EventWrapper.OnComm;
                // ...alarma
                this.Servidor.OrbitaAlarma -= this.EventWrapper.OnAlarma;

                //Eventos locales.
                //...cambio de dato.
                this.EventWrapper.OrbitaCambioDato -= eventWrapper_OrbitaCambioDato;
                this.ContLlamadasSimultaneasCambioDato = 0;
                //...conectividad.
                this.EventWrapper.OrbitaComm -= eventWrapper_OrbitaComm;
                this.ContLlamadasSimultaneasComm = 0;
                // ...alarma
                this.EventWrapper.OrbitaAlarma -= eventWrapper_OrbitaAlarma;
                this.ContLlamadasSimultaneasAlarma = 0;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, "Excepción al desconectar eventos del cliente de comunicaciones", this.Codigo);
            }
        }

        /// <summary>
        /// Conectar al servidor vía Remoting.
        /// </summary>
        /// <param name="estado">Estado de conexión.</param>
        private void ConectarCanal(bool estado)
        {

            //string strHostName = "";
            //strHostName = System.Net.Dns.GetHostName();
            //string canal = "canal" + strHostName + ":" + this._PuertoRemoto.ToString();

            string canal = "canal" + this._PuertoRemoto.ToString();
            this.Servidor.OrbitaConectar(canal, estado);
        }
        #endregion

        #region Manejador(es) evento(s)
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaCambioDato(OEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasCambioDato++;

                // Recogemos el código del terminal
                string codigoCambioEstado = ((OInfoDato)e.Argumento).Texto;

                if (this.ContLlamadasSimultaneasCambioDato <= NumMaxLlamadasSimultaneas)
                {
                    // Recogemos el dispositivo al que pertenece el terminal
                    int dispositivo = ((OInfoDato)e.Argumento).Dispositivo;

                    // Búsqueda del terminal
                    OTerminalClienteComunicacion terminal = this.ListaTerminales.Values.OfType<OTerminalClienteComunicacion>().SingleOrDefault(t => (t.CodigoVariableCOM == codigoCambioEstado) && (t.IdDispositivo == dispositivo));
                    if (terminal != null)
                    {
                        // Extraemos el valor
                        terminal.LeerEntrada(e);
                    }
                }
                else
                {
                    OLogsVAHardware.EntradasSalidas.Info("Número máximo de llamadas al cambio dato superado: " + this.ContLlamadasSimultaneasCambioDato, "Variable del servidor de comunicaciones: " + codigoCambioEstado, this.Codigo);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
            finally
            {
                this.ContLlamadasSimultaneasCambioDato--;
            }
        }
        /// <summary>
        /// Evento de conectividad
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaComm(OEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasComm++;
                if (this.ContLlamadasSimultaneasComm <= NumMaxLlamadasSimultaneas)
                {
                    this.CronometroTiempoSinRespuesta.Stop();
                    this.CronometroTiempoSinRespuesta.Reset();
                    this.CronometroTiempoSinRespuesta.Start();
                    OLogsVAHardware.EntradasSalidas.Debug("Evento Comm", this.Codigo);
                }
                else
                {
                    OLogsVAHardware.EntradasSalidas.Info("Número máximo de llamadas de conectividad: " + this.ContLlamadasSimultaneasComm, this.Codigo);
                }

            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
            finally
            {
                this.ContLlamadasSimultaneasComm--;
            }
        }
        /// <summary>
        /// Evento de alarma
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaAlarma(OEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasAlarma++;
                if (this.ContLlamadasSimultaneasAlarma <= NumMaxLlamadasSimultaneas)
                {
                }
                else
                {
                    OLogsVAHardware.EntradasSalidas.Info("Número máximo de llamadas de alarma: " + this.ContLlamadasSimultaneasAlarma, this.Codigo);
                }

                this.ContLlamadasSimultaneasAlarma--;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Evento del timer de comprobación de la conexión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerComprobacionConexion_Tick(object sender, EventArgs e)
        {
            this.TimerComprobacionConexion.Stop();
            try
            {
                // TimeOut de conectividad
                if (this.Habilitado && (this.CronometroTiempoSinRespuesta.Elapsed > this.IntervaloComprabacion))
                {
                    this.DesconectarEventWrapper();
                    this.ConectarEventWrapper();

                    this.CronometroTiempoSinRespuesta.Stop();
                    this.CronometroTiempoSinRespuesta.Reset();
                    this.CronometroTiempoSinRespuesta.Start();

                    OLogsVAHardware.EntradasSalidas.Error(this.Codigo, "Reconexión del wrapper de eventos", this.Codigo);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, "Conectividad " + this.Codigo);
            }
            this.TimerComprobacionConexion.Start();
        }
        #endregion
    }

    /// <summary>
    /// Terminal del Servidor de comunicaciones
    /// </summary>
    internal class OTerminalClienteComunicacion : OTerminalIOBase
    {
        #region Atributo(s)
        /// <summary>
        /// Código de la variable contra la que trabaja el terminal
        /// </summary>
        internal string CodigoVariableCOM;

        /// <summary>
        /// Servidor de comunicación
        /// </summary>
        protected IOCommRemoting Servidor;

        /// <summary>
        /// Información del Dispositivo
        /// </summary>
        internal int IdDispositivo;

        /// <summary>
        /// Indica que la escritura del valor se ha de producir inmediatamente al cambio del valor de la variable
        /// </summary>
        protected bool EscrituraInmediata;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OTerminalClienteComunicacion(string codTarjetaIO, string codTerminalIO)
            : base(codTarjetaIO, codTerminalIO)
        {
            this.Valor = null;

            // Cargamos valores de la base de datos
            DataTable dtTerminalIO = AppBD.GetTerminalIO(codTarjetaIO, codTerminalIO);
            if (dtTerminalIO.Rows.Count == 1)
            {
                this.IdDispositivo = OEntero.Validar(dtTerminalIO.Rows[0]["COM_ID"], 0, 999, 0);
                this.EscrituraInmediata = OBooleano.Validar(dtTerminalIO.Rows[0]["COM_EscrituraInmediata"], true);
                this.CodigoVariableCOM = dtTerminalIO.Rows[0]["COM_CodVariable"].ToString();
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Convierte el string devuelto por el servidor de comunicaciones al formato correcto de trabajo
        /// </summary>
        /// <param name="valorCOM"></param>
        /// <returns></returns>
        internal static object COMAFormatoCorrecto(object valorCOM, OEnumTipoDato tipoDato)
        {
            object resultado = null;

            switch (tipoDato)
            {
                case OEnumTipoDato.Bit:
                case OEnumTipoDato.Entero:
                case OEnumTipoDato.Texto:
                case OEnumTipoDato.Decimal:
                case OEnumTipoDato.Fecha:
                case OEnumTipoDato.Flag:
                    resultado = valorCOM;
                    break;
                case OEnumTipoDato.SinDefinir:
                case OEnumTipoDato.Grafico: // Todavía no implementado
                default:
                    resultado = null;
                    try
                    {
                        byte[] valorByte = (byte[])valorCOM;

                        IFormatter formatter = new BinaryFormatter();
                        MemoryStream stream = new MemoryStream(valorByte);
                        resultado = formatter.Deserialize(stream);
                    }
                    catch
                    {
                        resultado = null;
                    }
                    break;
                case OEnumTipoDato.Imagen:
                    resultado = null;
                    try
                    {
                        // Por probar
                        OByteArrayImage img = (OByteArrayImage)valorCOM;
                        resultado = img.Desserializar();

                        //byte[] valorByte = (byte[])valorCOM;
                        //OImagenBitmap bmp = new OImagenBitmap();

                        //resultado = bmp.FromArray(valorByte);
                    }
                    catch
                    {
                        resultado = null;
                    }
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Convierte el string devuelto por el servidor de comuniaciones al formato correcto de trabajo
        /// </summary>
        /// <param name="valorObj"></param>
        /// <returns></returns>
        internal static object FormatoCorrectoACOM(object valorObj, OEnumTipoDato tipoDato)
        {
            object resultado = null;

            switch (tipoDato)
            {
                case OEnumTipoDato.Bit:
                case OEnumTipoDato.Entero:
                case OEnumTipoDato.Texto:
                case OEnumTipoDato.Decimal:
                case OEnumTipoDato.Fecha:
                    resultado = valorObj;
                    break;
                case OEnumTipoDato.Flag:
                    resultado = null;
                    break;
                case OEnumTipoDato.SinDefinir:
                case OEnumTipoDato.Grafico: // Todavía no implementado
                default:
                    IFormatter formatter = new BinaryFormatter();
                    MemoryStream stream = new MemoryStream();
                    formatter.Serialize(stream, valorObj);
                    stream.Close();
                    resultado = stream.ToArray();
                    break;
                case OEnumTipoDato.Imagen:
                    if (valorObj is OImagen)
                    {
                        OImagen imagen = (OImagen)valorObj;

                        resultado = imagen.ToDataArray(ImageFormat.Jpeg, 1);
                    }
                    break;
            }

            return resultado;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Trata el cambio de valor
        /// </summary>
        /// <returns></returns>
        internal void LeerEntrada(OEventArgs eventArgs)
        {
            try
            {
                if (this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital)
                {
                    // Se devuelve el objeto tal cual
                    object valorCOM = ((OInfoDato)eventArgs.Argumento).Valor;

                    if (!OObjeto.CompararObjetos(this.Valor, valorCOM))
                    {
                        // Conversión
                        this.Valor = COMAFormatoCorrecto(valorCOM, this.TipoDato);

                        // Se lanza el cambio de valor
                        this.LanzarCambioValor();

                        // Se lanza desde un thread distino.
                        //OSimpleMethod setVariableEnThread = new OSimpleMethod(this.LanzarCambioValor);
                        //setVariableEnThread.BeginInvoke(null, null);
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Devuelve el valor listo para ser enviado al servidor de comunicaciones
        /// </summary>
        /// <param name="valorObj"></param>
        /// <returns></returns>
        internal object ValorFormateado()
        {
            return FormatoCorrectoACOM(this.Valor, this.TipoDato);
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Método a heredar donde se inicializan los terminales
        /// </summary>
        public void Inicializar(IOCommRemoting servidor)
        {
            try
            {
                this.Inicializar();
                this.Servidor = servidor;

                //Leo de cada terminal su valor y lo actualizo.
                this.LeerEntrada();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Simulación de la escritura de la entrada física
        /// </summary>
        public override void EscribirEntrada(string codigoVariable, object valor)
        {
            return; // NO SE PUEDE ESCRIBIR UNA ENTRADA !!!!
        }

        /// <summary>
        /// Escritura de la salida
        /// </summary>
        public override void EscribirSalida(string codigoVariable, object valor)
        {
            try
            {
                if ((this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital) || (this.TipoTerminalIO == OTipoTerminalIO.SalidaComando))
                {
                    base.EscribirSalida(codigoVariable, valor);

                    if (this.EscrituraInmediata)
                    {
                        // Conversión
                        this.Valor = FormatoCorrectoACOM(valor, this.TipoDato);

                        // Escritura en el servidor de comunicaciones
                        this.Servidor.OrbitaEscribir(this.IdDispositivo, new string[1] { this.CodigoVariableCOM }, new object[1] { this.Valor });
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        
        /// <summary>
        /// lee del OPC.Servidor el valor de la variable
        /// </summary>       
        /// <param name="variable">variable en la que se escribe el valor</param>
        public override void LeerEntrada()
        {
            try
            {
                if (this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital)
                {
                    base.LeerEntrada();

                    // Lectura del servidor de comunicaciones
                    object[] infoDato = this.Servidor.OrbitaLeer(this.IdDispositivo, new string[1] { this.CodigoVariableCOM }, true);
                    if (infoDato.Length == 1)
                    {
                        if (infoDato[0] != null)
                        {
                            object valorCOM = infoDato[0];

                            if (!OObjeto.CompararObjetos(this.Valor, valorCOM))
                            {
                                // Conversión
                                this.Valor = COMAFormatoCorrecto(valorCOM, this.TipoDato);

                                // Se lanza desde un thread distino.
                                OSimpleMethod setVariableEnThread = new OSimpleMethod(this.LanzarCambioValor);
                                setVariableEnThread.BeginInvoke(null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        #endregion
    }

    /// <summary>
    /// Terminal del servidor de comunicaciones para trabajo con texto
    /// </summary>
    internal class OTerminalClienteComunicacionWriteCommand : OTerminalClienteComunicacion
    {
        #region Atributo(s)
        /// <summary>
        /// Lista de códigos de terminales asociados
        /// </summary>
        private List<string> ListaCodigosTerminalesAsociados;

        /// <summary>
        /// Lista de terminales asociados
        /// </summary>
        private List<OTerminalClienteComunicacion> ListaTerminalesAsociados;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OTerminalClienteComunicacionWriteCommand(string codTarjetaIO, string codTerminalIO)
            : base(codTarjetaIO, codTerminalIO)
        {
            this.ListaCodigosTerminalesAsociados = new List<string>();
            this.ListaTerminalesAsociados = new List<OTerminalClienteComunicacion>();

            // Cargamos valores de la base de datos
            DataTable dtTerminalIO = AppBD.GetTerminalesIO_EscrituraCOM(codTarjetaIO, codTerminalIO);
            if (dtTerminalIO.Rows.Count > 0)
            {
                foreach (DataRow drTerminalIOAsociado in dtTerminalIO.Rows)
                {
                    string codigoTerminalAsociado = drTerminalIOAsociado["CodTerminalIO"].ToString();
                    this.ListaCodigosTerminalesAsociados.Add(codigoTerminalAsociado);
                }
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Inicialización de los terminales
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();

            OModuloIOBase tarjetaTerminal = OIOManager.ListaTarjetasIO.Find(delegate(OModuloIOBase t) { return t.Codigo == this.CodTarjeta; });
            foreach (string codTerminalIOAsociado in this.ListaCodigosTerminalesAsociados)
            {
                //OTerminalIOCOM terminalAsociado = (OTerminalIOCOM)tarjetaTerminal.ListaTerminales.Find(delegate(OTerminalIOBase t) { return t.Codigo == codTerminalIOAsociado; });
                OTerminalIOBase terminalAsociado;
                if (tarjetaTerminal.ListaTerminales.TryGetValue(codTerminalIOAsociado, out terminalAsociado))
                {
                    this.ListaTerminalesAsociados.Add((OTerminalClienteComunicacion)terminalAsociado);
                }
            }
        }

        /// <summary>
        /// Escritura de la salida
        /// </summary>
        public override void EscribirSalida(string codigoVariable, object valor)
        {
            try
            {
                base.EscribirSalida(codigoVariable, null); // No guardamos el valor

                if (this.ListaTerminalesAsociados.Count > 0)
                {
                    // Inicializamos las variables de envio
                    List<string> variables = new List<string>();
                    List<object> valores = new List<object>();

                    foreach (OTerminalClienteComunicacion terminalAsociado in this.ListaTerminalesAsociados)
                    {
                        variables.Add(terminalAsociado.CodigoVariableCOM);
                        valores.Add(terminalAsociado.ValorFormateado());
                    }

                    // Escritura en el servidor de comunicaciones de las variables asocidas a este terminal tipo Comando salida
                    bool resultado = this.Servidor.OrbitaEscribir(this.IdDispositivo, variables.ToArray(), valores.ToArray());

                    // Conversión a string
                    object valorCOM = FormatoCorrectoACOM(valor, this.TipoDato);
                    
                    // Escritura en el servidor de comunicaciones de la variable tipo Comando Salida, para que sea escrita en ultimo lugar
                    resultado = this.Servidor.OrbitaEscribir(this.IdDispositivo, new string[1] { this.CodigoVariableCOM }, new object[1] { valorCOM });
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        #endregion
    }
}

