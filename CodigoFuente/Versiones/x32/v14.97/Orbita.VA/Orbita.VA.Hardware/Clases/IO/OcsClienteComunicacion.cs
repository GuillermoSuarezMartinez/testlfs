//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : fhernandez
// Created          : 06-09-2013
// Description      : Adaptado a la versión nueva del servidor de comunicaciones.
//
//
// Last Modified By : aibañez
// Last Modified On : 13-12-2013
// Description      : Adaptado a la versión nueva del servidor de comunicaciones.
//                    Lectura de entradas tras desconexión del servidor de comunicaciones
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
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Excepciones;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase que implementa las funciones para el control de Entradas/Salidas del Servidor de comunicaciones
    /// </summary>
    public class OcsClienteComunicacion : OModuloIOBase
    {
        #region Constante(s)
        private const int NumMaxLlamadasSimultaneas = 5;
        #endregion

        #region Atributo(s) estático(s)
        /// <summary>
        /// Lista de dispositivos del servidor de comunicaciones
        /// </summary>
        public static Dictionary<int, IOcsClienteSincronizado> ListaClientesSincronizados = new Dictionary<int,IOcsClienteSincronizado>(); 
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Si están o no configurados los terminales
        /// </summary>
        private bool _Valido;
        /// <summary>
        /// Cliente sincronizado
        /// </summary>
        protected IOcsClienteSincronizado ClienteSincronizado;
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
        /// Nombre del canal
        /// </summary>
        private string NombreCanal;
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

        /// <summary>
        /// Número del servidor
        /// </summary>
        private int _NumeroServidor;
        /// <summary>
        /// Número del servidor
        /// </summary>
	    public int NumeroServidor
	    {
		    get { return _NumeroServidor;}
		    set { _NumeroServidor = value;}
	    }
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="codHardware">Código del hardware</param>
        public OcsClienteComunicacion(string codHardware)
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
                this._NumeroServidor = OEntero.Validar(dtTarjetaIO.Rows[0]["COM_NumeroServidor"], 0, int.MaxValue, 1);

                this.NombreCanal = ORemoting.GetCanal(this._HostServidor, this._PuertoRemoto.ToString());
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
                        OcsTerminalClienteComunicacion terminal;

                        OTipoTerminalIO tipoTerminalIO = OEnumerado<OTipoTerminalIO>.Validar(dr["IdTipoTerminalIO"], OTipoTerminalIO.EntradaSalidaDigital);

                        switch (tipoTerminalIO)
                        {
                            case OTipoTerminalIO.EntradaDigital:
                            case OTipoTerminalIO.SalidaDigital:
                            case OTipoTerminalIO.EntradaSalidaDigital:
                            default:
                                terminal = new OcsTerminalClienteComunicacion(codHardware, dr["CodTerminalIO"].ToString(), this.NombreCanal);
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
                    foreach (OcsTerminalClienteComunicacion terminal in this.ListaTerminales.Values)
                    {
                        terminal.Inicializar(this.ClienteSincronizado);
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
                foreach (OcsTerminalClienteComunicacion terminal in this.ListaTerminales.Values)
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
                int[] puertos = new int[1] { (this._PuertoRemoto) };
                string[] servidores = new string[1] { this._HostServidor };
                int[] numeroServidores = new int[1] { this._NumeroServidor };
                ORemoting.InicConfiguracionCliente(puertos, servidores, numeroServidores);
                
                this.ClienteSincronizado = new OcsClienteSincronizado(this._HostServidor, this._PuertoRemoto, (int)(this._IntervaloComprabacion.TotalMilliseconds));
                ListaClientesSincronizados.Add(this._NumeroServidor, this.ClienteSincronizado);

                // Suscripción al evento de conexión y desconexión
                this.ClienteSincronizado.Conectado += new EventHandler(ClienteSincronizado_Conectado);
                this.ClienteSincronizado.Desconectado += new EventHandler(ClienteSincronizado_Desconectado);

                // Eventwrapper de comunicaciones.
                this.ConectarEventWrapper();

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
            // Suscripción al evento de conexión y desconexión
            this.ClienteSincronizado.Conectado -= new EventHandler(ClienteSincronizado_Conectado);
            this.ClienteSincronizado.Desconectado -= new EventHandler(ClienteSincronizado_Desconectado);

            this.DesconectarEventWrapper();

            OLogsVAHardware.EntradasSalidas.Info(this.Codigo, "Desconectado del Servicio");
        }

        /// <summary>
        /// Conectar los eventos
        /// </summary>
        public void ConectarEventWrapper()
        {
            try
            {
                // Eventos del servidor.
                //...cambio de dato.
                this.ClienteSincronizado.MensajeRecibidoCambioDato += eventWrapper_OrbitaCambioDato; 
                //...conectividad.
                this.ClienteSincronizado.MensajeRecibidoComunicaciones += eventWrapper_OrbitaComm; 
                // ...alarma
                this.ClienteSincronizado.MensajeRecibidoAlarma += eventWrapper_OrbitaAlarma; 
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
                this.ClienteSincronizado.MensajeRecibidoCambioDato -= eventWrapper_OrbitaCambioDato; //this.EventWrapper.OnCambioDato;
                //...conectividad.
                this.ClienteSincronizado.MensajeRecibidoComunicaciones -= eventWrapper_OrbitaComm; //this.EventWrapper.OnComm;
                // ...alarma
                this.ClienteSincronizado.MensajeRecibidoAlarma -= eventWrapper_OrbitaAlarma; //this.EventWrapper.OnAlarma;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, "Excepción al desconectar eventos del cliente de comunicaciones", this.Codigo);
            }
        }

        /// <summary>
        /// Conectar/Desconecta al servidor vía Remoting.
        /// </summary>
        /// <param name="estado">Estado de conexión.</param>
        private void ConectarCanal(bool estado)
        {
            if (estado)
            {
                this.ClienteSincronizado.Conectar();
            }
            else
            {
                this.ClienteSincronizado.Desconectar();
            }
        }
        #endregion

        #region Manejador(es) evento(s)
        /// <summary>
        /// Evento de cambio de dato.
        /// </summary>
        /// <param name="e"></param>
        private void eventWrapper_OrbitaCambioDato(object sender, OcsMensajeInfoDatoEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasCambioDato++;

                if (this.ContLlamadasSimultaneasCambioDato <= NumMaxLlamadasSimultaneas)
                {
                    if (e.Mensaje.InfoDato is OInfoDato)
                    {
                        OInfoDato argumento = (OInfoDato)e.Mensaje.InfoDato;

                        // Recogemos el código del terminal, su canal y su dispositivo
                        string codigoCambioEstado = argumento.Texto;
                        string nombreCanalCambioDato = argumento.CanalCambioDato;
                        int dispositivo = argumento.Dispositivo;

                        if (this.NombreCanal != nombreCanalCambioDato)
                        {
                            // Búsqueda del terminal
                            var terminales = this.ListaTerminales.Values.OfType<OcsTerminalClienteComunicacion>().Where(t => (t.CodigoVariableCOM == codigoCambioEstado) && (t.IdDispositivo == dispositivo));
                            if (terminales != null)
                            {
                                foreach (OcsTerminalClienteComunicacion terminal in terminales)
                                {
                                    // Extraemos el valor
                                    terminal.LeerEntrada(e);
                                }
                            }
                        }
                    }
                    else
                    {
                        OLogsVAHardware.EntradasSalidas.Info("Argumento de cambio de dato no válido", this.Codigo);
                    }
                }
                else
                {
                    OLogsVAHardware.EntradasSalidas.Info("Número máximo de llamadas al cambio dato superado: " + this.ContLlamadasSimultaneasCambioDato, this.Codigo);
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
        private void eventWrapper_OrbitaComm(object sender, OcsMensajeComunicacionesEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasComm++;
                if (this.ContLlamadasSimultaneasComm <= NumMaxLlamadasSimultaneas)
                {
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
        private void eventWrapper_OrbitaAlarma(object sender, OcsMensajeInfoDatoEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasAlarma++;
                if (!(this.ContLlamadasSimultaneasAlarma <= NumMaxLlamadasSimultaneas))
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
        #endregion

        #region Evento(s)
        /// <summary>
        /// Conexión del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClienteSincronizado_Conectado(object sender, EventArgs e)
        {
            try
            {
                // Se lee el valor de los terminales
                foreach (OcsTerminalClienteComunicacion terminal in this.ListaTerminales.Values)
                {
                    terminal.LeerEntrada();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }

        /// <summary>
        /// Desconexión del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClienteSincronizado_Desconectado(object sender, EventArgs e)
        {
        } 
        #endregion
    }

    /// <summary>
    /// Terminal del Servidor de comunicaciones
    /// </summary>
    internal class OcsTerminalClienteComunicacion : OTerminalIOBase
    {
        #region Atributo(s)
        /// <summary>
        /// Código de la variable contra la que trabaja el terminal
        /// </summary>
        internal string CodigoVariableCOM;
        /// <summary>
        /// Servidor de comunicación
        /// </summary>
        //protected IOCommRemoting Servidor;
        /// <summary>
        /// Cliente sincronizado
        /// </summary>
        protected IOcsClienteSincronizado ClienteSincronizado;
        /// <summary>
        /// Información del Dispositivo
        /// </summary>
        internal int IdDispositivo;
        /// <summary>
        /// Indica que la escritura del valor se ha de producir inmediatamente al cambio del valor de la variable
        /// </summary>
        protected bool EscrituraInmediata;
        /// <summary>
        /// Nombre del canal
        /// </summary>
        protected string NombreCanal;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public OcsTerminalClienteComunicacion(string codTarjetaIO, string codTerminalIO, string nombreCanal)
            : base(codTarjetaIO, codTerminalIO)
        {
            this.Valor = null;
            this.NombreCanal = nombreCanal;

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
        internal void LeerEntrada(OcsMensajeInfoDatoEventArgs eventArgs)
        {
            try
            {
                if ((this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital) || (this.TipoTerminalIO == OTipoTerminalIO.EntradaSalidaDigital))
                {
                    // Se devuelve el objeto tal cual
                    object valorCOM = ((OInfoDato)eventArgs.Mensaje.InfoDato).Valor;

                    if (!OObjeto.CompararObjetos(this.Valor, valorCOM))
                    {
                        // Conversión
                        this.Valor = COMAFormatoCorrecto(valorCOM, this.TipoDato);

                        // Se lanza el cambio de valor
                        this.LanzarCambioValor();
                    }
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.EntradasSalidas.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Trata el cambio de valor
        /// </summary>
        /// <returns></returns>
        internal void LeerEntrada(OEventArgs eventArgs)
        {
            try
            {
                if ((this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital) || (this.TipoTerminalIO == OTipoTerminalIO.EntradaSalidaDigital))
                {
                    // Se devuelve el objeto tal cual
                    object valorCOM = ((OInfoDato)eventArgs.Argumento).Valor;

                    if (!OObjeto.CompararObjetos(this.Valor, valorCOM))
                    {
                        // Conversión
                        this.Valor = COMAFormatoCorrecto(valorCOM, this.TipoDato);

                        // Se lanza el cambio de valor
                        this.LanzarCambioValor();
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
        public void Inicializar(IOcsClienteSincronizado clienteSincronizado)
        {
            try
            {
                this.Inicializar();
                //this.Servidor = servidor;
                this.ClienteSincronizado = clienteSincronizado;
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
        public override void EscribirSalida(string codigoVariable, object valor, string remitente)
        {
            try
            {
                if (((this.TipoTerminalIO == OTipoTerminalIO.SalidaDigital) || (this.TipoTerminalIO == OTipoTerminalIO.EntradaSalidaDigital) || (this.TipoTerminalIO == OTipoTerminalIO.SalidaComando)) && (this.ClienteSincronizado != null))
                {
                    if (remitente != this.Codigo) // Si el remitente no es el propio terminal !
                    {
                        base.EscribirSalida(codigoVariable, valor, remitente);

                        if (this.EscrituraInmediata)
                        {
                            // Conversión
                            this.Valor = FormatoCorrectoACOM(valor, this.TipoDato);

                            try
                            {
                                // Escritura en el servidor de comunicaciones
                                this.ClienteSincronizado.Escribir(this.IdDispositivo, new string[1] { this.CodigoVariableCOM }, new object[1] { this.Valor }, this.NombreCanal);
                            }
                            catch (ExcepcionComunicacion ex)
                            {
                                OLogsVAHardware.EntradasSalidas.Error(ex, this.Codigo);
                            }
                            catch (TimeoutException ex)
                            {
                                OLogsVAHardware.EntradasSalidas.Error(ex, this.Codigo);
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
        
        /// <summary>
        /// lee del OPC.Servidor el valor de la variable
        /// </summary>       
        /// <param name="variable">variable en la que se escribe el valor</param>
        public override void LeerEntrada()
        {
            try
            {
                if (((this.TipoTerminalIO == OTipoTerminalIO.EntradaDigital) || (this.TipoTerminalIO == OTipoTerminalIO.EntradaSalidaDigital)) && (this.ClienteSincronizado != null))
                {
                    // Lectura del servidor de comunicaciones
                    try
                    {
                        IOcsMensajeLectura lectura = this.ClienteSincronizado.Leer(this.IdDispositivo, new string[1] { this.CodigoVariableCOM }, true);

                        if (lectura.Valores.Length == 1)
                        {
                            if (lectura.Valores[0] != null)
                            {
                                object valorCOM = lectura.Valores[0];
                                if (!OObjeto.CompararObjetos(this.Valor, valorCOM))
                                {
                                    // Conversión
                                    this.Valor = COMAFormatoCorrecto(valorCOM, this.TipoDato);

                                    base.LeerEntrada();

                                    // Se lanza desde un thread distino.
                                    OSimpleMethod setVariableEnThread = new OSimpleMethod(this.LanzarCambioValor);
                                    setVariableEnThread.BeginInvoke(null, null);
                                }
                            }
                        }
                    }
                    catch(ExcepcionComunicacion ex)
                    {
                        OLogsVAHardware.EntradasSalidas.Error(ex, this.Codigo);
                    }
                    catch (TimeoutException ex)
                    {
                        OLogsVAHardware.EntradasSalidas.Error(ex, this.Codigo);
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

}

