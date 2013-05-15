//***********************************************************************
// Assembly         : Orbita.VA.Hardware
// Author           : aibañez
// Created          : 02-04-2013
//
// Last Modified By : 
// Last Modified On : 
// Description      : 
//
// Copyright        : (c) Orbita Ingenieria. All rights reserved.
//***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using Orbita.Utiles;
using Orbita.VA.Comun;
using System.Windows.Forms;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase base para todas las cámaras
    /// </summary>
    public class OCamaraServidor : OCamaraBase
    {
        #region Atributo(s)
        /// <summary>
        /// Región de memoria mapeada con multibuffer
        /// </summary>
        protected OMemoriaMapeadaMultiBuffer MemoriaMapeada;
        /// <summary>
        /// Número de buffers del fichero mapeado
        /// </summary>
        private int NumBuffers;
        /// <summary>
        /// Tamaño en bytes de cada región. Siempre debe ser mayor que las imagenes a almacenar.
        /// </summary>
        private long CapacidadRegion;
        /// <summary>
        /// Objeto utilizado para el lanzamiento del evento de forma asíncrona
        /// </summary>
        private ORemotingEvent<NuevaFotografiaCamaraMemoriaMapeadaEventArgs> EventoNuevaFotografiaAsincronaMemoriaMapeada;
        /// <summary>
        /// Objeto utilizado para el lanzamiento del evento de forma asíncrona
        /// </summary>
        private ORemotingEvent<NuevaFotografiaCamaraRemotaEventArgs> EventoNuevaFotografiaAsincronaRemota;
        /// <summary>
        /// Objeto utilizado para el lanzamiento del evento de forma asíncrona
        /// </summary>
        private ORemotingEvent<CambioEstadoConexionCamaraEventArgs> EventoEstadoConexionAsincrona;
        /// <summary>
        /// Objeto utilizado para el lanzamiento del evento de forma asíncrona
        /// </summary>
        private ORemotingEvent<OMessageEventArgs> EventoMensajeCamaraAsincrona;
        /// <summary>
        /// Objeto utilizado para el lanzamiento del evento de forma asíncrona
        /// </summary>
        private ORemotingEvent<CambioEstadoReproduccionCamaraEventArgs> EventoCambioReproduccionAsincrona;
        /// <summary>
        /// Objeto utilizado para el lanzamiento del evento de forma asíncrona
        /// </summary>
        private ORemotingEvent<OEventArgs> EventoBitVidaAsincrona;
        /// <summary>
        /// Timer de comprobación del estado de la conexión
        /// </summary>
        private Timer TimerComprobacionConexion;

        /// <summary>
        /// Lista de eventos de nueva fotografía de memoria mapeada
        /// </summary>
        private Dictionary<string, EventoNuevaFotografiaCamaraMemoriaMapeada> ListaClientesNuevaFotografiaCamaraMemoriaMapeada;
        /// <summary>
        /// Lista de eventos de nueva fotografía de remoting
        /// </summary>
        private Dictionary<string, EventoNuevaFotografiaCamaraRemota> ListaClientesNuevaFotografiaCamaraRemota;
        /// <summary>
        /// Lista de eventos de cambio del estado de conectividad de la cámara
        /// </summary>
        private Dictionary<string, EventoCambioEstadoConexionCamara> ListaClientesCambioEstadoConexionCamara;
        /// <summary>
        /// Lista de eventos de cambio del estado de reproducción de la cámara
        /// </summary>
        private Dictionary<string, EventoCambioEstadoReproduccionCamara> ListaClientesCambioEstadoReproduccionCamara;
        /// <summary>
        /// Lista de eventos de mensaje de la cámara
        /// </summary>
        private Dictionary<string, OMessageEvent> ListaClientesMensajes;
        /// <summary>
        /// Lista de eventos del bit de vida
        /// </summary>
        private Dictionary<string, ManejadorEvento> ListaClientesBitVida;
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
        #endregion

        #region Declaración de evento(s)
        /// <summary>
        /// Delegado de nueva fotografía Remota. Evento Asíncrono.
        /// </summary>
        /// <param name="estadoConexion"></param>
        internal event EventoNuevaFotografiaCamaraMemoriaMapeada OnNuevaFotografiaCamaraAsincronaMemoriaMapeada;
        /// <summary>
        /// Delegado de nueva fotografía Remota. Evento Asíncrono.
        /// </summary>
        /// <param name="estadoConexion"></param>
        internal event EventoNuevaFotografiaCamaraRemota OnNuevaFotografiaCamaraAsincronaRemota;
        /// <summary>
        /// Delegado de cambio de estaco de conexión de la cámara. Evento Asíncrono
        /// </summary>
        /// <param name="estadoConexion"></param>
        internal event EventoCambioEstadoConexionCamara OnCambioEstadoConexionCamaraAsincrono;
        /// <summary>
        /// Delegado de mensaje del módulo de Entrada / salida
        /// </summary>
        /// <param name="estadoConexion"></param>
        internal event OMessageEvent OnMensajeAsincrono;
        /// <summary>
        /// Delegado de mensaje de cambio de estado de reproducción. Evento asíncrono
        /// </summary>
        internal event EventoCambioEstadoReproduccionCamara OnCambioEstadoReproduccionCamaraAsincrono;
        /// <summary>
        /// Delegado de bit de vida
        /// </summary>
        /// <param name="estadoConexion"></param>
        internal event ManejadorEvento OnBitVidaAsincrono;
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCamaraServidor(string codigo) :
            base(codigo)
        {
            try
            {
                // Cargamos valores de la base de datos
                DataTable dt = AppBD.GetCamara(codigo);
                if (dt.Rows.Count == 1)
                {
                    this.NumBuffers = OEntero.Validar(dt.Rows[0]["RemoteCam_NumBuffers"], 0, int.MaxValue, 10);
                    this.CapacidadRegion = OEntero.Validar(dt.Rows[0]["RemoteCam_CapacidadRegion"], 0, int.MaxValue, 1000);
                    this._IntervaloComprabacion = TimeSpan.FromMilliseconds(OEntero.Validar(dt.Rows[0]["RemoteCam_WatchDogTimeMs"], 1, int.MaxValue, 10000));

                    // Creación del timer de comprobación de la conexión
                    this.TimerComprobacionConexion = new Timer();
                    this.TimerComprobacionConexion.Interval = (int)this._IntervaloComprabacion.TotalMilliseconds;
                    this.TimerComprobacionConexion.Enabled = false;
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " \r\nde la base de datos.");
                }

                if (this.Habilitado)
                {
                    //Defimos la definición del buffer, id de buffer de región = OrbCamara01 con 0 .. 4 
                    this.MemoriaMapeada = new OMemoriaMapeadaMultiBuffer();
                    OInfoBufferMemoriaMapeada bufferInfo = new OInfoBufferMemoriaMapeada(this.Codigo, this.NumBuffers, this.CapacidadRegion);
                    this.MemoriaMapeada.InicializarEscritura(bufferInfo);

                    // Construcción del lanzamiento de evento asíncronos
                    this.EventoNuevaFotografiaAsincronaMemoriaMapeada = new ORemotingEvent<NuevaFotografiaCamaraMemoriaMapeadaEventArgs>("NuevaFoto" + this.Codigo, this.NumBuffers - 1, new EventHandler<NuevaFotografiaCamaraMemoriaMapeadaEventArgs>(this.LanzarEventoNuevaFotografiaCamaraAsincronaMemoriaMapeada));
                    this.EventoNuevaFotografiaAsincronaRemota = new ORemotingEvent<NuevaFotografiaCamaraRemotaEventArgs>("NuevaFoto" + this.Codigo, this.NumBuffers - 1, new EventHandler<NuevaFotografiaCamaraRemotaEventArgs>(this.LanzarEventoNuevaFotografiaCamaraAsincronaRemoting));
                    this.EventoEstadoConexionAsincrona = new ORemotingEvent<CambioEstadoConexionCamaraEventArgs>("CambioEstadoConexion" + this.Codigo, this.NumBuffers - 1, new EventHandler<CambioEstadoConexionCamaraEventArgs>(this.LanzarEventoCambioEstadoConexionCamaraAsincrona));
                    this.EventoMensajeCamaraAsincrona = new ORemotingEvent<OMessageEventArgs>("MensajeCamara" + this.Codigo, this.NumBuffers - 1, new EventHandler<OMessageEventArgs>(this.LanzarEventoMensajeCamaraAsincrona));
                    this.EventoCambioReproduccionAsincrona = new ORemotingEvent<CambioEstadoReproduccionCamaraEventArgs>("CambioEstadoReproduccion" + this.Codigo, this.NumBuffers - 1, new EventHandler<CambioEstadoReproduccionCamaraEventArgs>(this.LanzarEventoCambioReproduccionCamaraAsincrona));
                    this.EventoBitVidaAsincrona = new ORemotingEvent<OEventArgs>("BitVida" + this.Codigo, this.NumBuffers - 1, new EventHandler<OEventArgs>(this.LanzarEventoBitVidaAsincrona));

                    // Listado de clientes
                    this.ListaClientesNuevaFotografiaCamaraMemoriaMapeada = new Dictionary<string,EventoNuevaFotografiaCamaraMemoriaMapeada>();
                    this.ListaClientesNuevaFotografiaCamaraRemota = new Dictionary<string, EventoNuevaFotografiaCamaraRemota>();
                    this.ListaClientesCambioEstadoConexionCamara = new Dictionary<string, EventoCambioEstadoConexionCamara>();
                    this.ListaClientesCambioEstadoReproduccionCamara = new Dictionary<string, EventoCambioEstadoReproduccionCamara>();
                    this.ListaClientesMensajes = new Dictionary<string, OMessageEvent>();
                    this.ListaClientesBitVida = new Dictionary<string, ManejadorEvento>();
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
            }
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        internal void CrearSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(string codigoCliente, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            this.EliminarSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigoCliente);
            this.ListaClientesNuevaFotografiaCamaraMemoriaMapeada.Add(codigoCliente, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            this.OnNuevaFotografiaCamaraAsincronaMemoriaMapeada += delegadoNuevaFotografiaCamaraMemoriaMapeada;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        internal void EliminarSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(string codigoCliente, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            this.ListaClientesNuevaFotografiaCamaraMemoriaMapeada.Remove(codigoCliente);
            this.OnNuevaFotografiaCamaraAsincronaMemoriaMapeada -= delegadoNuevaFotografiaCamaraMemoriaMapeada;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        internal void EliminarSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(string codigoCliente)
        {
            EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada;
            if (this.ListaClientesNuevaFotografiaCamaraMemoriaMapeada.TryGetValue(codigoCliente, out delegadoNuevaFotografiaCamaraMemoriaMapeada))
            {
                this.ListaClientesNuevaFotografiaCamaraMemoriaMapeada.Remove(codigoCliente);
                this.OnNuevaFotografiaCamaraAsincronaMemoriaMapeada -= delegadoNuevaFotografiaCamaraMemoriaMapeada;
            } 
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        internal void CrearSuscripcionNuevaFotografiaAsincronaRemota(string codigoCliente, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            this.EliminarSuscripcionNuevaFotografiaAsincronaRemota(codigoCliente);
            this.ListaClientesNuevaFotografiaCamaraRemota.Add(codigoCliente, delegadoNuevaFotografiaCamaraRemota);
            this.OnNuevaFotografiaCamaraAsincronaRemota += delegadoNuevaFotografiaCamaraRemota;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        internal void EliminarSuscripcionNuevaFotografiaAsincronaRemota(string codigoCliente, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            this.ListaClientesNuevaFotografiaCamaraRemota.Remove(codigoCliente);
            this.OnNuevaFotografiaCamaraAsincronaRemota -= delegadoNuevaFotografiaCamaraRemota;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        internal void EliminarSuscripcionNuevaFotografiaAsincronaRemota(string codigoCliente)
        {
            EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota;
            if (this.ListaClientesNuevaFotografiaCamaraRemota.TryGetValue(codigoCliente, out delegadoNuevaFotografiaCamaraRemota))
            {
                this.ListaClientesNuevaFotografiaCamaraRemota.Remove(codigoCliente);
                this.OnNuevaFotografiaCamaraAsincronaRemota -= delegadoNuevaFotografiaCamaraRemota;
            } 
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        internal void CrearSuscripcionCambioEstadoConexionAsincrona(string codigoCliente, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            this.EliminarSuscripcionCambioEstadoConexionAsincrona(codigoCliente);
            this.ListaClientesCambioEstadoConexionCamara.Add(codigoCliente, delegadoCambioEstadoConexionCamara);
            this.OnCambioEstadoConexionCamaraAsincrono += delegadoCambioEstadoConexionCamara;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        internal void EliminarSuscripcionCambioEstadoConexionAsincrona(string codigoCliente, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            this.ListaClientesCambioEstadoConexionCamara.Remove(codigoCliente);
            this.OnCambioEstadoConexionCamaraAsincrono -= delegadoCambioEstadoConexionCamara;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        internal void EliminarSuscripcionCambioEstadoConexionAsincrona(string codigoCliente)
        {
            EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara;
            if (this.ListaClientesCambioEstadoConexionCamara.TryGetValue(codigoCliente, out delegadoCambioEstadoConexionCamara))
            {
                this.ListaClientesCambioEstadoConexionCamara.Remove(codigoCliente);
                this.OnCambioEstadoConexionCamaraAsincrono -= delegadoCambioEstadoConexionCamara;
            } 
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        internal void CrearSuscripcionCambioEstadoReproduccionAsincrona(string codigoCliente, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            this.EliminarSuscripcionCambioEstadoReproduccionAsincrona(codigoCliente);
            this.ListaClientesCambioEstadoReproduccionCamara.Add(codigoCliente, delegadoCambioEstadoReproduccionCamara);
            this.OnCambioEstadoReproduccionCamaraAsincrono += delegadoCambioEstadoReproduccionCamara;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        internal void EliminarSuscripcionCambioEstadoReproduccionAsincrona(string codigoCliente, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            this.ListaClientesCambioEstadoReproduccionCamara.Remove(codigoCliente);
            this.OnCambioEstadoReproduccionCamaraAsincrono -= delegadoCambioEstadoReproduccionCamara;
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        internal void EliminarSuscripcionCambioEstadoReproduccionAsincrona(string codigoCliente)
        {
            EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara;
            if (this.ListaClientesCambioEstadoReproduccionCamara.TryGetValue(codigoCliente, out delegadoCambioEstadoReproduccionCamara))
            {
                this.ListaClientesCambioEstadoReproduccionCamara.Remove(codigoCliente);
                this.OnCambioEstadoReproduccionCamaraAsincrono -= delegadoCambioEstadoReproduccionCamara;
            }
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        internal void CrearSuscripcionMensajesAsincrona(string codigoCliente, OMessageEvent messageDelegate)
        {
            this.EliminarSuscripcionMensajesAsincrona(codigoCliente);
            this.ListaClientesMensajes.Add(codigoCliente, messageDelegate);
            this.OnMensajeAsincrono += messageDelegate;
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        internal void EliminarSuscripcionMensajesAsincrona(string codigoCliente, OMessageEvent messageDelegate)
        {
            this.ListaClientesMensajes.Remove(codigoCliente);
            this.OnMensajeAsincrono -= messageDelegate;
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        internal void EliminarSuscripcionMensajesAsincrona(string codigoCliente)
        {
            OMessageEvent messageDelegate;
            if (this.ListaClientesMensajes.TryGetValue(codigoCliente, out messageDelegate))
            {
                this.ListaClientesMensajes.Remove(codigoCliente);
                this.OnMensajeAsincrono -= messageDelegate;
            }
        }

        /// <summary>
        /// Suscribe la recepción del bit de vida de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        internal void CrearSuscripcionBitVidaAsincrona(string codigoCliente, ManejadorEvento delegadoBitVida)
        {
            this.EliminarSuscripcionBitVidaAsincrona(codigoCliente);
            this.ListaClientesBitVida.Add(codigoCliente, delegadoBitVida);
            this.OnBitVidaAsincrono += delegadoBitVida;
        }
        /// <summary>
        /// Elimina la suscripción del bit de vida de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        internal void EliminarSuscripcionBitVidaAsincrona(string codigoCliente, ManejadorEvento delegadoBitVida)
        {
            this.ListaClientesBitVida.Remove(codigoCliente);
            this.OnBitVidaAsincrono -= delegadoBitVida;
        }
        /// <summary>
        /// Elimina la suscripción del bit de vida de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        internal void EliminarSuscripcionBitVidaAsincrona(string codigoCliente)
        {
            ManejadorEvento delegadoBitVida;
            if (this.ListaClientesBitVida.TryGetValue(codigoCliente, out delegadoBitVida))
            {
                this.ListaClientesBitVida.Remove(codigoCliente);
                this.OnBitVidaAsincrono -= delegadoBitVida;
            }
        }
        #endregion

        #region Método(s) heredado(s)
        /// <summary>
        /// Carga los valores de la cámara
        /// </summary>
        public override void Inicializar()
        {
            base.Inicializar();

            if (this.Habilitado)
            {
                this.EventoNuevaFotografiaAsincronaMemoriaMapeada.Start();
                this.EventoNuevaFotografiaAsincronaRemota.Start();
                this.EventoEstadoConexionAsincrona.Start();
                this.EventoMensajeCamaraAsincrona.Start();
                this.EventoCambioReproduccionAsincrona.Start();
                this.EventoBitVidaAsincrona.Start();

                // Iniciamos la comprobación de la conectividad con la cámara
                this.TimerComprobacionConexion.Tick += this.TimerComprobacionConexion_Tick;
                this.TimerComprobacionConexion.Start();
            }
        }

        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public override void Finalizar()
        {
            base.Finalizar();

            if (this.Habilitado)
            {
                this.EventoNuevaFotografiaAsincronaMemoriaMapeada.Stop();
                this.EventoNuevaFotografiaAsincronaRemota.Stop();
                this.EventoEstadoConexionAsincrona.Stop();
                this.EventoMensajeCamaraAsincrona.Stop();
                this.EventoCambioReproduccionAsincrona.Stop();
                this.EventoBitVidaAsincrona.Stop();

                // Finalizamos la comprobación de la conectividad con la cámara
                this.TimerComprobacionConexion.Stop();
                this.TimerComprobacionConexion.Tick -= this.TimerComprobacionConexion_Tick;
            }
        }
        #endregion

        #region Evento(s) heredado(s)
        /// <summary>
        /// Evento de cambio en de la imagen de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected override void OnCambioFotografiaCamara(string codigo, OImagen imagen, DateTime momentoAdquisicion, double velocidadAdquisicion)
        {
            // Memoria mapeada
            if (this.DebeLanzarEventoNuevaFotografiaCamaraAsincronaMemoriaMapeada())
            {
                if (!this.EventoNuevaFotografiaAsincronaMemoriaMapeada.Lleno)
                {
                    OImagenMemoriaMapeada imagenMemoriaMapeada = new OImagenMemoriaMapeada();
                    try
                    {
                        // Escritura en memoria mapeada
                        imagenMemoriaMapeada.EscribirImagen(imagen, this.MemoriaMapeada, this.Codigo);

                        this.EventoNuevaFotografiaAsincronaMemoriaMapeada.LanzarEvento(new NuevaFotografiaCamaraMemoriaMapeadaEventArgs(codigo, imagenMemoriaMapeada, momentoAdquisicion, velocidadAdquisicion));
                        //OLogsVAHardware.Camaras.Debug(this.Codigo, "Encolado del evento de cambio de fotografía", "Momento de creación de la fotografía: " + imagen.MomentoCreacion.ToString("yyyyMMddHHmmssfff"), "Tamaño de la cola: " + this.EventoNuevaFotografiaAsincronaMemoriaMapeada.Count);
                    }
                    catch (Exception exception)
                    {
                        OLogsVAHardware.Camaras.Error(exception, this.Codigo);
                    }
                }
                else
                {
                    //OLogsVAHardware.Camaras.Debug(this.Codigo, "Imposible encolar del evento de cambio de fotografía por cola llena", "Momento de creación de la fotografía: " + imagen.MomentoCreacion.ToString("yyyyMMddHHmmssfff"), "Tamaño de la cola: " + this.EventoNuevaFotografiaAsincronaRemota.Count);
                }
            }

            // Remoting
            if (this.DebeLanzarEventoNuevaFotografiaCamaraAsincronaRemoting())
            {
                if (!this.EventoNuevaFotografiaAsincronaRemota.Lleno)
                {
                    OByteArrayImage byteArrayImage = new OByteArrayImage();
                    try
                    {
                        // Serialización de la imagen
                        byteArrayImage.Serializar(imagen, TipoSerializacionImagen.Pixel);
                        
                        this.EventoNuevaFotografiaAsincronaRemota.LanzarEvento(new NuevaFotografiaCamaraRemotaEventArgs(codigo, byteArrayImage, momentoAdquisicion, velocidadAdquisicion));
                        //OLogsVAHardware.Camaras.Debug(this.Codigo, "Encolado del evento de cambio de fotografía", "Momento de creación de la fotografía: " + imagen.MomentoCreacion.ToString("yyyyMMddHHmmssfff"), "Tamaño de la cola: " + this.EventoNuevaFotografiaAsincronaRemota.Count);
                    }
                    catch (Exception exception)
                    {
                        OLogsVAHardware.Camaras.Error(exception, this.Codigo);
                    }
                }
                else
                {
                    //OLogsVAHardware.Camaras.Debug(this.Codigo, "Imposible encolar del evento de cambio de fotografía por cola llena", "Momento de creación de la fotografía: " + imagen.MomentoCreacion.ToString("yyyyMMddHHmmssfff"), "Tamaño de la cola: " + this.EventoNuevaFotografiaAsincronaRemota.Count);
                }
            }

            // Lanza el evento síncrono
            base.OnCambioFotografiaCamara(codigo, imagen, momentoAdquisicion, velocidadAdquisicion);
        }

        /// <summary>
        /// Evento de cambio en de la imagen de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected override void OnCambioEstadoConectividadCamara(string codigo, EstadoConexion estadoConexionActual, EstadoConexion estadoConexionAnterior)
        {
            base.OnCambioEstadoConectividadCamara(codigo, estadoConexionActual, estadoConexionAnterior);
            if (this.DebeLanzarEventoCambioEstadoConexionCamaraAsincrona())
            {
                this.EventoEstadoConexionAsincrona.LanzarEvento(new CambioEstadoConexionCamaraEventArgs(codigo, estadoConexionActual, estadoConexionAnterior));
            }
        }

        /// <summary>
        /// Evento de cambio en de la imagen de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected override void OnCambioReproduccionCamara(string codigo, bool modoReproduccionContinua)
        {
            base.OnCambioReproduccionCamara(codigo, modoReproduccionContinua);
            if (this.DebeLanzarEventoCambioReproduccionCamaraAsincrona())
            {
                this.EventoCambioReproduccionAsincrona.LanzarEvento(new CambioEstadoReproduccionCamaraEventArgs(codigo, modoReproduccionContinua));
            }
        }

        /// <summary>
        /// Evento de cambio en de la imagen de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected override void OnNuevoMensajeCamara(string codigo, string mensaje)
        {
            base.OnNuevoMensajeCamara(codigo, mensaje);
            if (this.DebeLanzarEventoMensajeCamaraAsincrona())
            {
                this.EventoMensajeCamaraAsincrona.LanzarEvento(new OMessageEventArgs(codigo, mensaje));
            }
        }

        /// <summary>
        /// Evento de bit de vida
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected override void OnBitVida(string codigo)
        {
            base.OnBitVida(codigo);
            if (this.DebeLanzarEventoBitVidaAsincrona())
            {
                this.EventoBitVidaAsincrona.LanzarEvento(new OEventArgs());
            }
        }
        #endregion

        #region Evento(s)
        /// <summary>
        /// Evento del timer de comprobación de la conexión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerComprobacionConexion_Tick(object sender, EventArgs e)
        {
            try
            {
                this.OnBitVida(this.Codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, "Timer de evento del bit de vida " + this.Codigo);
            }
        }
        #endregion

        #region Lanzamiento de evento(s)
        /// <summary>
        /// Lanza evento de nueva fotografía
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoNuevaFotografiaCamaraAsincronaMemoriaMapeada(object sender, NuevaFotografiaCamaraMemoriaMapeadaEventArgs e)
        {
            try
            {
                if (this.DebeLanzarEventoNuevaFotografiaCamaraAsincronaMemoriaMapeada())
                {
                    this.OnNuevaFotografiaCamaraAsincronaMemoriaMapeada(sender, e);
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Debe lanzar el evento de nueva fotografía
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected bool DebeLanzarEventoNuevaFotografiaCamaraAsincronaMemoriaMapeada()
        {
            return this.OnNuevaFotografiaCamaraAsincronaMemoriaMapeada != null;
        }

        /// <summary>
        /// Lanza evento de nueva fotografía
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoNuevaFotografiaCamaraAsincronaRemoting(object sender, NuevaFotografiaCamaraRemotaEventArgs e)
        {
            try
            {
                if (this.DebeLanzarEventoNuevaFotografiaCamaraAsincronaRemoting())
                {
                    OLogsVAHardware.Camaras.Debug(this.Codigo, "Evento de remoting de cambio de fotografía", "Momento de creación de la fotografía: " + e.ImagenByteArray.MomentoCreacion.ToString("yyyyMMddHHmmssfff"));
                    this.OnNuevaFotografiaCamaraAsincronaRemota(sender, e);
                    OLogsVAHardware.Camaras.Debug(this.Codigo, "Fin del evento de remoting de cambio de fotografía", "Momento de creación de la fotografía: " + e.ImagenByteArray.MomentoCreacion.ToString("yyyyMMddHHmmssfff"));
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, this.Codigo);
            }
        }
        /// <summary>
        /// Debe lanzar el evento de nueva fotografía
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected bool DebeLanzarEventoNuevaFotografiaCamaraAsincronaRemoting()
        {
            return this.OnNuevaFotografiaCamaraAsincronaRemota != null;
        }

        /// <summary>
        /// Lanza evento de cambio de estado de conexión de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoCambioEstadoConexionCamaraAsincrona(object sender, CambioEstadoConexionCamaraEventArgs e)
        {
            if (this.DebeLanzarEventoCambioEstadoConexionCamaraAsincrona())
            {
                try
                {
                    this.OnCambioEstadoConexionCamaraAsincrono(sender, e);
                }
                catch (Exception exception)
                {
                    OLogsVAHardware.Camaras.Error(exception, this.Codigo);
                }
            }
        }
        /// <summary>
        /// Debe lanzar el evento de cambio de estado de conexión de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected bool DebeLanzarEventoCambioEstadoConexionCamaraAsincrona()
        {
            return this.OnCambioEstadoConexionCamaraAsincrono != null;
        }
        /// <summary>
        /// Lanza evento de mensaje de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoMensajeCamaraAsincrona(object sender, OMessageEventArgs e)
        {
            if (this.DebeLanzarEventoMensajeCamaraAsincrona())
            {
                try
                {
                    this.OnMensajeAsincrono(sender, e);
                }
                catch (Exception exception)
                {
                    OLogsVAHardware.Camaras.Error(exception, this.Codigo);
                }
            }
        }
        /// <summary>
        /// Debe lanzar el evento de mensaje de la cámara
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected bool DebeLanzarEventoMensajeCamaraAsincrona()
        {
            return this.OnMensajeAsincrono != null;
        }

        /// <summary>
        /// Lanza evento de mensaje de cambio de estado de reproducción
        /// </summary>
        protected void LanzarEventoCambioReproduccionCamaraAsincrona(object sender, CambioEstadoReproduccionCamaraEventArgs e)
        {
            if (this.DebeLanzarEventoCambioReproduccionCamaraAsincrona())
            {
                try
                {
                    this.OnCambioEstadoReproduccionCamaraAsincrono(sender, e);
                }
                catch (Exception exception)
                {
                    OLogsVAHardware.Camaras.Error(exception, this.Codigo);
                }
            }
        }
        /// <summary>
        /// Debe lanzar el evento de mensaje de cambio de estado de reproducción
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected bool DebeLanzarEventoCambioReproduccionCamaraAsincrona()
        {
            return this.OnCambioEstadoReproduccionCamaraAsincrono != null;
        }

        /// <summary>
        /// Lanza evento de mensaje del bit de vida
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected void LanzarEventoBitVidaAsincrona(object sender, OEventArgs e)
        {
            if (this.DebeLanzarEventoMensajeCamaraAsincrona())
            {
                try
                {
                    this.OnBitVidaAsincrono(sender, e);
                }
                catch (Exception exception)
                {
                    OLogsVAHardware.Camaras.Error(exception, this.Codigo);
                }
            }
        }
        /// <summary>
        /// Debe lanzar el evento del bit de vida
        /// </summary>
        /// <param name="estadoConexion"></param>
        protected bool DebeLanzarEventoBitVidaAsincrona()
        {
            return this.OnBitVidaAsincrono != null;
        }
        #endregion
    }
}