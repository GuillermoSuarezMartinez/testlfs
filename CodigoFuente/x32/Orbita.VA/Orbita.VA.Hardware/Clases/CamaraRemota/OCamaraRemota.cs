//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 04-02-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;
using System.Security.Permissions;
using Orbita.Utiles;
using Orbita.VA.Comun;
using System.Runtime.Remoting;
using System.Diagnostics;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Cámara remota
    /// </summary>
    public class OCamaraRemota : OCamaraBase
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Booleano que evita que se construya varias veces el listado de cámaras de tipo GigE
        /// </summary>
        public static bool PrimeraInstancia = true;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Cámara remota
        /// </summary>
        private ORemotingCamaraProxie CamaraCliente;
        /// <summary>
        /// Objeto utilizado para enlazar con los eventos del OCamaraCliente de forma remota
        /// </summary>
        private OCamaraBroadcastEventWraper EventWrapper;
        /// <summary>
        /// Timer de comprobación del estado de la conexión
        /// </summary>
        private Timer TimerComprobacionConexion;
        /// <summary>
        /// Cronómetro del tiempo sin respuesta
        /// </summary>
        private Stopwatch CronometroTiempoSinRespuesta;
        /// <summary>
        /// Código identificador de la cámara remota
        /// </summary>
        private string CodigoRemoto;
        /// <summary>
        /// Nombre del canal remoto
        /// </summary>
        private string NombreCanal;
        /// <summary>
        /// Dirección IP de la cámara
        /// </summary>
        private IPAddress IP;
        /// <summary>
        /// Puerto de conexión con la cámara
        /// </summary>
        private int Puerto;
        /// <summary>
        /// Región de memoria mapeada con multibuffer
        /// </summary>
        protected OMemoriaMapeadaMultiBuffer MemoriaMapeada;
        /// <summary>
        /// Número de buffers del fichero mapeado
        /// </summary>
        private int NumBuffers;
        #endregion

        #region Propiedad(es)
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
        /// Estado de la conexión
        /// </summary>
        public EstadoConexion EstadoConexionRemota
        {
            get
            {
                if ((this.CamaraCliente is ORemotingCamaraProxie) && this.CamaraCliente.Iniciado)
                {
                    return this.CamaraCliente.GetEstadoConexion();
                }
                return EstadoConexion.Desconectado;
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCamaraRemota(string codigo)
            : base(codigo)
        {
            try
            {
                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(codigo);
                if (dt.Rows.Count == 1)
                {
                    this.CodigoRemoto = dt.Rows[0]["RemoteCam_CodigoRemoto"].ToString();
                    this.NombreCanal = dt.Rows[0]["RemoteCam_NombreCanal"].ToString();
                    this.IP = IPAddress.Parse(dt.Rows[0]["RemoteCam_IP"].ToString());
                    this.Puerto = OEntero.Validar(dt.Rows[0]["RemoteCam_Puerto"], 0, int.MaxValue, 80);
                    this.NumBuffers = OEntero.Validar(dt.Rows[0]["RemoteCam_NumBuffers"], 0, int.MaxValue, 10);
                    this._IntervaloComprabacion = TimeSpan.FromMilliseconds(OEntero.Validar(dt.Rows[0]["RemoteCam_WatchDogTimeMs"], 1, int.MaxValue, 15000));

                    // Creación del timer de comprobación de la conexión
                    this.TimerComprobacionConexion = new Timer();
                    this.TimerComprobacionConexion.Interval = (int)this._IntervaloComprabacion.TotalMilliseconds;
                    this.TimerComprobacionConexion.Enabled = false;

                    // Creación del cronómetro de tiempo de espera sin respuesta de la cámara
                    this.CronometroTiempoSinRespuesta = new Stopwatch();
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " \r\nde la base de datos.");
                }

                if (this.Habilitado)
                {
                    //Defimos la definición del buffer, id de buffer de región = OrbCamara01 con 0 .. 4 
                    this.MemoriaMapeada = new OMemoriaMapeadaMultiBuffer();
                    OInfoBufferMemoriaMapeada bufferInfo = new OInfoBufferMemoriaMapeada(this.CodigoRemoto, this.NumBuffers);
                    this.MemoriaMapeada.InicializarLectura(bufferInfo);

                    this.CamaraCliente = new ORemotingCamaraProxie(this.Codigo, this.CodigoRemoto, this.NombreCanal, this.IP, this.Puerto);
                }
                this.Existe = true;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
            }
        }
        #endregion

        #region Método(s) privado(s)
        /// <summary>
        /// Conectar los eventos
        /// </summary>
        public void ConectarEventWrapper()
        {
            try
            {
                this.EventWrapper = new OCamaraBroadcastEventWraper();
                this.EventWrapper.NuevaFotografiaCamaraMemoriaMapeada += this.NuevaFotografiaCamaraMemoriaMapeada;
                this.CamaraCliente.CrearSuscripcionNuevaFotografiaMemoriaMapeada(this.EventWrapper.OnNuevaFotografiaCamaraMemoriaMapeada);
                this.EventWrapper.CambioEstadoConexionCamara += this.CambioEstadoConexionCamara;
                this.CamaraCliente.CrearSuscripcionCambioEstadoConexion(this.EventWrapper.OnCambioEstadoConexionCamara);
                this.EventWrapper.CambioEstadoReproduccionCamara += this.CambioEstadoReproduccionCamara;
                this.CamaraCliente.CrearSuscripcionCambioEstadoReproduccion(this.EventWrapper.OnCambioEstadoReproduccionCamara);
                this.EventWrapper.MensajeCamaraRemoting += this.MensajeCamara;
                this.CamaraCliente.CrearSuscripcionMensajes(this.EventWrapper.OnMensajeCamara);
                this.EventWrapper.BitVida += this.BitVida;
                this.CamaraCliente.CrearSuscripcionBitVida(this.EventWrapper.OnBitVida);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "Excepción al conectar eventos del cliente de cámaras", this.Codigo);
            }
        }
        /// <summary>
        /// Desconectar los eventos
        /// </summary>
        public void DesconectarEventWrapper()
        {
            try
            {
                this.EventWrapper.NuevaFotografiaCamaraMemoriaMapeada -= this.NuevaFotografiaCamaraMemoriaMapeada;
                this.CamaraCliente.EliminarSuscripcionNuevaFotografiaMemoriaMapeada(this.EventWrapper.OnNuevaFotografiaCamaraMemoriaMapeada);
                this.EventWrapper.CambioEstadoConexionCamara -= this.CambioEstadoConexionCamara;
                this.CamaraCliente.EliminarSuscripcionCambioEstadoConexion(this.EventWrapper.OnCambioEstadoConexionCamara);
                this.EventWrapper.CambioEstadoReproduccionCamara -= this.CambioEstadoReproduccionCamara;
                this.CamaraCliente.EliminarSuscripcionCambioEstadoReproduccion(this.EventWrapper.OnCambioEstadoReproduccionCamara);
                this.EventWrapper.MensajeCamaraRemoting -= this.MensajeCamara;
                this.CamaraCliente.EliminarSuscripcionMensajes(this.EventWrapper.OnMensajeCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "Excepción al desconectar eventos del cliente de cámaras", this.Codigo);
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();

            if (this.CamaraCliente != null)
            {
                this.CamaraCliente.Desconectar();
            }
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public override bool SetAjuste(string codAjuste, object valor)
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.SetAjuste(codAjuste, valor);
            }
            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public override bool GetAjuste(string codAjuste, out object valor)
        {
            valor = null;
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.GetAjuste(codAjuste, out valor);
            }
            return false;
        }

        /// <summary>
        /// Consulta si el PTZ está habilitado
        /// </summary>
        /// <returns>Verdadero si el PTZ está habilitado</returns>
        public override bool PTZHabilitado()
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.PTZHabilitado();
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="tipo">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="modo">Modo de movimiento: Absoluto o relativo</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public override bool EjecutaMovimientoPTZ(OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.EjecutaMovimientoPTZ(tipo, modo, valor);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public override bool EjecutaMovimientoPTZ(OMovimientoPTZ movimiento, double valor)
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.EjecutaMovimientoPTZ(movimiento, valor);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public override bool EjecutaMovimientoPTZ(OComandoPTZ comando)
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.EjecutaMovimientoPTZ(comando);
            }
            return false; 
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public override bool EjecutaMovimientoPTZ(OComandosPTZ valores)
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.EjecutaMovimientoPTZ(valores);
            }
            return false;
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public override OPosicionesPTZ ConsultaPosicionPTZ()
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.ConsultaPosicionPTZ();
            }
            return null;
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public override OPosicionPTZ ConsultaPosicionPTZ(OEnumTipoMovimientoPTZ movimiento)
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.ConsultaPosicionPTZ(movimiento);
            }
            return new OPosicionPTZ(); 
        }

        /// <summary>
        /// Consulta última posición leida del PTZ
        /// </summary>
        /// <returns></returns>
        public override OPosicionesPTZ ConsultaUltimaPosicionPTZ()
        {
            if (this.EstadoConexion == EstadoConexion.Conectado)
            {
                return this.CamaraCliente.ConsultaPosicionPTZ();
            }
            return null;
        }

        /// <summary>
        /// Se toma el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool ConectarInterno(bool reconexion)
        {
            bool resultado = base.ConectarInterno(reconexion);
            try
            {
                bool conectado = this.CamaraCliente.Conectar();

                if (conectado)
                {
                    // Eventos
                    this.ConectarEventWrapper();

                    // Iniciamos la comprobación de la conectividad con la cámara
                    this.CronometroTiempoSinRespuesta.Start();
                    this.TimerComprobacionConexion.Tick += this.TimerComprobacionConexion_Tick;
                    this.TimerComprobacionConexion.Start();

                    // Inicialización de variables
                    this._TipoImagen = this.CamaraCliente.TipoImagen;

                    resultado = true;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo, "Error al conectarse a la cámara " + this.Codigo + ": ".ToString());
            }

            return resultado;
        }

        /// <summary>
        /// Se deja el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool DesconectarInterno(bool errorConexion)
        {
            bool resultado = base.DesconectarInterno(errorConexion);

            try
            {
                // Finalizamos la comprobación de la conectividad con la cámara
                this.TimerComprobacionConexion.Stop();
                this.TimerComprobacionConexion.Tick -= this.TimerComprobacionConexion_Tick;
                this.CronometroTiempoSinRespuesta.Stop();

                // Eventos
                this.DesconectarEventWrapper();
                
                this.CamaraCliente.Desconectar();

                resultado = true;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected override bool StartInterno()
        {
            bool resultado = false;

            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.StartInterno();

                    resultado = this.CamaraCliente.Start();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        protected override bool StopInterno()
        {
            bool resultado = false;

            try
            {

                if (this.EstadoConexion != EstadoConexion.Desconectado)
                {
                    resultado = this.CamaraCliente.Stop();

                    base.StopInterno();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        protected override bool SnapInterno()
        {
            bool resultado = false;
            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    base.SnapInterno();

                    resultado = this.CamaraCliente.Snap();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
            return resultado;
        }

        /// <summary>
        /// Carga una imagen de disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se encuentra la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool CargarImagenDeDisco(out OImagen imagen, string ruta)
        {
            bool resultado = false;

            if (this.ImagenActual != null)
            {
                this.ImagenActual = null;
            }

            imagen = this.NuevaImagen();
            bool imagenok = imagen.Cargar(ruta);
            if (imagenok)
            {
                this.ImagenActual = imagen;
                resultado = true;
            }

            return resultado;
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public override bool GuardarImagenADisco(string ruta)
        {
            bool resultado = false;

            if (this.ImagenActual is OImagen)
            {
                resultado = this.ImagenActual.Guardar(ruta);
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve una nueva imagen del tipo adecuado al trabajo con la cámara
        /// </summary>
        /// <returns>Imagen del tipo adecuado al trabajo con la cámara</returns>
        public override OImagen NuevaImagen()
        {
            OImagen resultado = null;

            switch (this.TipoImagen)
            {
                case TipoImagen.Bitmap:
                default:
                    resultado = new OImagenBitmap();
                    break;
                case TipoImagen.VisionPro:
                    resultado = new OImagenVisionPro();
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Crea el objeto de conectividad adecuado para la cámara
        /// </summary>
        protected override void CrearConectividad()
        {
            // Creación de la comprobación de la conexión con la cámara
            this.Conectividad = new OConectividad(this.Codigo);
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento de recepción de nueva imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaFotografiaCamaraMemoriaMapeada(object sender, NuevaFotografiaCamaraMemoriaMapeadaEventArgs e)
        {
            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    // Lectura de la memoria mapeada
                    bool imagenLeida = e.ImagenMemoriaMapeada.LeerImagen(this.MemoriaMapeada, ref this._ImagenActual);

                    // Lanamos el evento de adquisición
                    if (imagenLeida)
                    {
                        OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de recepción de cambio de fotografía", this._ImagenActual.ToString());
                        this.AdquisicionCompletada(this.ImagenActual);
                    }
                }
                this.BitVida(sender, null);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Evento de recepción de nueva imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaFotografiaCamaraRemota(object sender, NuevaFotografiaCamaraRemotaEventArgs e)
        {
            try
            {
                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    // Lectura del array de imagenes
                    OImagen imagen = e.ImagenByteArray.Desserializar();
                    this._ImagenActual = imagen;

                    // Lanamos el evento de adquisición
                    if (imagen.EsValida())
                    {
                        OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de recepción de cambio de fotografía", this._ImagenActual.ToString());
                        this.AdquisicionCompletada(this.ImagenActual);
                    }
                }
                this.BitVida(sender, null);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Evento de cambio de estado de conexión
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void CambioEstadoConexionCamara(object sender, CambioEstadoConexionCamaraEventArgs e)
        {
            OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de recepción de cambio del estado de conexión");
            this.LanzarEventoCambioEstadoConexionCamaraSincrona(e.Codigo, e.EstadoConexionActual, e.EstadoConexionAnterior);
            this.BitVida(sender, null);
        }
        /// <summary>
        /// Evento de cambio de estado de reproducción
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void CambioEstadoReproduccionCamara(object sender, CambioEstadoReproduccionCamaraEventArgs e)
        {
            OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de recepción de cambio del estado de reproducción");
            this.LanzarEventoCambioReproduccionCamaraSincrona(e.Codigo, e.ModoReproduccionContinua);
            this.BitVida(sender, null);
        }
        /// <summary>
        /// Evento de nuevo mensaje
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void MensajeCamara(object sender, OMessageEventArgs e)
        {
            OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de recepción de mensaje de la cámara");
            this.LanzarEventoMensajeCamaraSincrona(e.Codigo, e.Mensaje);
            this.BitVida(sender, null);
        }
        /// <summary>
        /// Evento de bit de ivda
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void BitVida(object sender, OEventArgs e)
        {
            OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de recepción del bit de vida de la cámara");
            this.CronometroTiempoSinRespuesta.Stop();
            this.CronometroTiempoSinRespuesta.Reset();
            this.CronometroTiempoSinRespuesta.Start();
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
                if (this.Habilitado && (this.CronometroTiempoSinRespuesta.Elapsed > this.IntervaloComprabacion) && 
                    ((this.EstadoConexion == Hardware.EstadoConexion.Conectado)) &&
                    (OSistemaManager.EstadoSistema == EstadoSistema.Iniciado))
                {
                    this.DesconectarEventWrapper();
                    this.ConectarEventWrapper();

                    this.CronometroTiempoSinRespuesta.Stop();
                    this.CronometroTiempoSinRespuesta.Reset();
                    this.CronometroTiempoSinRespuesta.Start();

                    OLogsVAHardware.Camaras.Error(this.Codigo, "Reconexión del wrapper de eventos", this.Codigo);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "Conectividad " + this.Codigo);
            }

            if (this.EstadoConexion == Hardware.EstadoConexion.Conectado)
            {
                this.TimerComprobacionConexion.Start();
            }
        }
        #endregion
    }

    /// <summary>
    /// Clase para acceder a los objetos OCamaraBase remotos
    /// </summary>
    [Serializable]
    internal class ORemotingCamaraProxie : ORemotingProxie<ORemotingCamaraServidor>
    {
        #region Atributo(s)
        /// <summary>
        /// Código identificador de la cámara remota
        /// </summary>
        private string CodigoRemoto;
        /// <summary>
        /// Identificador del cliente
        /// </summary>
        private string CodigoCliente;
        #endregion

        #region Propiedad(es)
        /// <summary>
        /// Indica que se ha podido acceder a la cámara con éxito
        /// </summary>
        public bool Existe
        {
            get 
            {
                bool resultado = false;
                try
                {
                    if (this.Instancia != null)
                    {
                        resultado = this.Instancia.GetExiste(this.CodigoRemoto);
                    }
                }
                catch { };
                return resultado; 
            }
        }

        /// <summary>
        /// Tipo de imagen que almacena
        /// </summary>
        public TipoImagen TipoImagen
        {
            get 
            { 
                return this.Instancia.GetTipoImagen(this.CodigoRemoto);
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ORemotingCamaraProxie(string codigoCliente, string codigoRemoto, string nombreCanal, IPAddress ip, int puerto):
            base(nombreCanal, ip, puerto)
        {
            // Cargamos valores de la base de datos
            this.CodigoRemoto = codigoRemoto;
            this.CodigoCliente = codigoCliente + nombreCanal;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                return this.Instancia.Start(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            try
            {
                return this.Instancia.Stop(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        public bool Snap()
        {
            try
            {
                return this.Instancia.Snap(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Comienza una grabación continua de la cámara
        /// </summary>
        /// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
        /// <returns></returns>
        public bool StartREC(string fichero)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.StartREC(this.CodigoRemoto, fichero);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool StopREC()
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.StopREC(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codAjuste, object valor)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.SetAjuste(this.CodigoRemoto, codAjuste, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codAjuste, out object valor)
        {
            bool resultado = false;
            valor = null;
            try
            {
                resultado = this.Instancia.GetAjuste(this.CodigoRemoto, codAjuste, out valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el estado de la conexión de la cámara servidora
        /// </summary>
        /// <returns></returns>
        public EstadoConexion GetEstadoConexion()
        {
            EstadoConexion resultado = EstadoConexion.Desconectado;
            try
            {
                resultado = this.Instancia.GetEstadoConexion(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Consulta si el PTZ está habilitado
        /// </summary>
        /// <returns>Verdadero si el PTZ está habilitado</returns>
        public bool PTZHabilitado()
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.PTZHabilitado(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="tipo">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="modo">Modo de movimiento: Absoluto o relativo</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.EjecutaMovimientoPTZ(this.CodigoRemoto, tipo, modo, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OMovimientoPTZ movimiento, double valor)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.EjecutaMovimientoPTZ(this.CodigoRemoto, movimiento, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OComandoPTZ comando)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.EjecutaMovimientoPTZ(this.CodigoRemoto, comando);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OComandosPTZ valores)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.EjecutaMovimientoPTZ(this.CodigoRemoto, valores);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaPosicionPTZ()
        {
            OPosicionesPTZ resultado = new OPosicionesPTZ();
            try
            {
                resultado = this.Instancia.ConsultaPosicionPTZ(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public OPosicionPTZ ConsultaPosicionPTZ(OEnumTipoMovimientoPTZ movimiento)
        {
            OPosicionPTZ resultado = new OPosicionPTZ();
            try
            {
                resultado = this.Instancia.ConsultaPosicionPTZ(this.CodigoRemoto, movimiento);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Consulta última posición leida del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaUltimaPosicionPTZ()
        {
            OPosicionesPTZ resultado = new OPosicionesPTZ();
            try
            {
                resultado = this.Instancia.ConsultaUltimaPosicionPTZ(this.CodigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public bool GuardarImagenADisco(string ruta)
        {
            bool resultado = false;
            try
            {
                resultado = this.Instancia.GuardarImagenADisco(this.CodigoRemoto, ruta);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
            return resultado;
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaMemoriaMapeada(EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                this.Instancia.CrearSuscripcionNuevaFotografiaMemoriaMapeada(this.CodigoCliente, this.CodigoRemoto, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaMemoriaMapeada(EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                this.Instancia.EliminarSuscripcionNuevaFotografiaMemoriaMapeada(this.CodigoCliente, this.CodigoRemoto, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaRemota(EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                this.Instancia.CrearSuscripcionNuevaFotografiaRemota(this.CodigoCliente, this.CodigoRemoto, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaRemota(EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                this.Instancia.EliminarSuscripcionNuevaFotografiaRemota(this.CodigoCliente, this.CodigoRemoto, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoConexion(EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                this.Instancia.CrearSuscripcionCambioEstadoConexion(this.CodigoCliente, this.CodigoRemoto, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoConexion(EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                this.Instancia.EliminarSuscripcionCambioEstadoConexion(this.CodigoCliente, this.CodigoRemoto, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoReproduccion(EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                this.Instancia.CrearSuscripcionCambioEstadoReproduccion(this.CodigoCliente, this.CodigoRemoto, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoReproduccion(EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                this.Instancia.EliminarSuscripcionCambioEstadoReproduccion(this.CodigoCliente, this.CodigoRemoto, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionMensajes(OMessageEvent messageDelegate)
        {
            try
            {
                this.Instancia.CrearSuscripcionMensajes(this.CodigoCliente, this.CodigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionMensajes(OMessageEvent messageDelegate)
        {
            try
            {
                this.Instancia.EliminarSuscripcionMensajes(this.CodigoCliente, this.CodigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe la recepción del bit de vida de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionBitVida(ManejadorEvento messageDelegate)
        {
            try
            {
                this.Instancia.CrearSuscripcionBitVida(this.CodigoCliente, this.CodigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del bit de vida de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionBitVida(ManejadorEvento messageDelegate)
        {
            try
            {
                this.Instancia.EliminarSuscripcionBitVida(this.CodigoCliente, this.CodigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.CodigoRemoto);
            }
        }
        
        #endregion
    }

    /// <summary>
    /// Clase utilizada para enlazar con los eventos del variablecore de forma remota
    /// </summary>
    [Serializable]
    public class OCamaraBroadcastEventWraper : ORemotingObject
    {
        #region Atributo(s)
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento
        /// </summary>
        private int ContLlamadasSimultaneasNuevaFotografiaMemoriaMapeada;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento
        /// </summary>
        private int ContLlamadasSimultaneasNuevaFotografiaRemota;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento de conectividad
        /// </summary>
        private int ContLlamadasSimultaneasCambioEstadoConexion;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento de alarma
        /// </summary>
        private int ContLlamadasSimultaneasCambioEstadoReproduccion;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento de alarma
        /// </summary>
        private int ContLlamadasSimultaneasMensaje;
        /// <summary>
        /// Informa del número de llamadas simultáneas al evento del bit de vida
        /// </summary>
        private int ContLlamadasSimultaneasBitVida;
        #endregion

        #region Declaración de evento(s)
        /// <summary>
        /// Evento de cambio de fotografía.
        /// </summary>
        public event EventoNuevaFotografiaCamaraMemoriaMapeada NuevaFotografiaCamaraMemoriaMapeada;

        /// <summary>
        /// Evento de cambio de fotografía.
        /// </summary>
        public event EventoNuevaFotografiaCamaraRemota NuevaFotografiaCamaraRemota;

        /// <summary>
        /// Cambio de estado de conexión.
        /// </summary>
        public event EventoCambioEstadoConexionCamara CambioEstadoConexionCamara;

        /// <summary>
        /// Cambio de estado de Reproducción.
        /// </summary>
        public event EventoCambioEstadoReproduccionCamara CambioEstadoReproduccionCamara;

        /// <summary>
        /// Nuevo Mensaje.
        /// </summary>
        public event OMessageEvent MensajeCamaraRemoting;

        /// <summary>
        /// Bit de vida
        /// </summary>
        public event ManejadorEvento BitVida;
        #endregion

        #region Constructor(es)
        public OCamaraBroadcastEventWraper()
        {
            // Inicialización de variables
            this.ContLlamadasSimultaneasNuevaFotografiaMemoriaMapeada = 0;
            this.ContLlamadasSimultaneasNuevaFotografiaRemota = 0;
            this.ContLlamadasSimultaneasCambioEstadoConexion = 0;
            this.ContLlamadasSimultaneasCambioEstadoReproduccion = 0;
            this.ContLlamadasSimultaneasMensaje = 0;
            this.ContLlamadasSimultaneasBitVida = 0;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Evento de cambio de fotografía.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        //[OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnNuevaFotografiaCamaraMemoriaMapeada(object sender, NuevaFotografiaCamaraMemoriaMapeadaEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasNuevaFotografiaMemoriaMapeada++;

                if (NuevaFotografiaCamaraMemoriaMapeada != null)
                {
                    this.NuevaFotografiaCamaraMemoriaMapeada(null, e);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("Número máximo de llamadas a nueva fotografía de memoria mapeada superado: " + this.ContLlamadasSimultaneasNuevaFotografiaMemoriaMapeada);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            finally
            {
                this.ContLlamadasSimultaneasNuevaFotografiaMemoriaMapeada--;
            }
        }

        /// <summary>
        /// Evento de cambio de fotografía.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        //[OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnNuevaFotografiaCamaraRemota(object sender, NuevaFotografiaCamaraRemotaEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasNuevaFotografiaRemota++;

                if (NuevaFotografiaCamaraRemota != null)
                {
                    this.NuevaFotografiaCamaraRemota(null, e);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("Número máximo de llamadas a nueva fotografía de remoting superado: " + this.ContLlamadasSimultaneasNuevaFotografiaRemota);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            finally
            {
                this.ContLlamadasSimultaneasNuevaFotografiaRemota--;
            }
        }

        /// <summary>
        /// Evento de cambio de conexión.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        //[OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnCambioEstadoConexionCamara(object sender, CambioEstadoConexionCamaraEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasCambioEstadoConexion++;

                if (CambioEstadoConexionCamara != null)
                {
                    this.CambioEstadoConexionCamara(null, e);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("Número máximo de llamadas al cambio del estado de conexión superado: " + this.ContLlamadasSimultaneasCambioEstadoConexion);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            finally
            {
                this.ContLlamadasSimultaneasCambioEstadoConexion--;
            }
        }

        /// <summary>
        /// Evento de cambio de Reproducción.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        //[OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnCambioEstadoReproduccionCamara(object sender, CambioEstadoReproduccionCamaraEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasCambioEstadoReproduccion++;

                if (CambioEstadoReproduccionCamara != null)
                {
                    this.CambioEstadoReproduccionCamara(null, e);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("Número máximo de llamadas al cambio del estado de reproducción superado: " + this.ContLlamadasSimultaneasCambioEstadoReproduccion);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            finally
            {
                this.ContLlamadasSimultaneasCambioEstadoReproduccion--;
            }
        }

        /// <summary>
        /// Evento de nuevo mensaje
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        //[OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnMensajeCamara(object sender, OMessageEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasMensaje++;

                if (MensajeCamaraRemoting != null)
                {
                    this.MensajeCamaraRemoting(null, e);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("Número máximo de llamadas al evento de mensaje de la cámara superado: " + this.ContLlamadasSimultaneasMensaje);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            finally
            {
                this.ContLlamadasSimultaneasMensaje--;
            }
        }

        /// <summary>
        /// Evento de bit de vida
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        //[OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnBitVida(object sender, OEventArgs e)
        {
            try
            {
                this.ContLlamadasSimultaneasBitVida++;

                if (BitVida != null)
                {
                    this.BitVida(null, e);
                }
                else
                {
                    OLogsVAHardware.Camaras.Info("Número máximo de llamadas al evento del bit de vida de la cámara superado: " + this.ContLlamadasSimultaneasBitVida);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            finally
            {
                this.ContLlamadasSimultaneasBitVida--;
            }
        }
        #endregion
    }
}
