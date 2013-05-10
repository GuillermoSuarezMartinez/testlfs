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
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Fatal(exception, this.Codigo);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
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
        #endregion
    }
}