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
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Net;
using Orbita.VA.Comun;
using System.Runtime.Remoting.Channels.Tcp;
using Orbita.Utiles;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Cámara remota
    /// </summary>
    public class OCamaraRemota : OCamaraBase
    {
        #region Atributo(s) estático(s)
        /// <summary>
        /// Clase remoting del servidor de cámaras
        /// </summary>
        private static OServidorCamaras ServidorCamaras;
        /// <summary>
        /// Booleano que evita que se construya varias veces el listado de cámaras de tipo GigE
        /// </summary>
        public static bool PrimeraInstancia = true;
        #endregion

        #region Atributo(s)
        /// <summary>
        /// Cámara remota
        /// </summary>
        private OCamaraCliente CamaraCliente;
        /// <summary>
        /// Objeto utilizado para enlazar con los eventos del OCamaraCliente de forma remota
        /// </summary>
        private OCamaraBroadcastEventWraper EventWrapper;
        /// <summary>
        /// Código identificador de la cámara remota
        /// </summary>
        private string CodigoRemoto;
        /// <summary>
        /// Dirección IP de la cámara
        /// </summary>
        private IPAddress IP;
        /// <summary>
        /// Puerto de conexión con la cámara
        /// </summary>
        private int Puerto;
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
                    this.IP = IPAddress.Parse(dt.Rows[0]["RemoteCam_IP"].ToString());
                    this.Puerto = OEntero.Validar(dt.Rows[0]["RemoteCam_Puerto"], 0, int.MaxValue, 80);
                }
                else
                {
                    throw new Exception("No se ha podido cargar la información de la cámara " + codigo + " \r\nde la base de datos.");
                }

                this.CamaraCliente = new OCamaraCliente(this.CodigoRemoto, this.IP, this.Puerto);

                this.Existe = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Fatal(ModulosHardware.CamaraRemota, this.Codigo, exception);
                throw new Exception("Imposible iniciar la cámara " + this.Codigo);
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
        /// Se toma el control de la cámara
        /// </summary>
        /// <returns>Verdadero si la operación ha funcionado correctamente</returns>
        protected override bool ConectarInterno(bool reconexion)
        {
            bool resultado = base.ConectarInterno(reconexion);
            try
            {
                resultado = this.CamaraCliente.Conectar();

                // Eventos
                this.EventWrapper = new OCamaraBroadcastEventWraper();
                this.EventWrapper.NuevaFotografiaCamaraRemota += this.NuevaFotografiaCamaraRemota;
                this.CamaraCliente.CrearSuscripcionNuevaFotografiaRemota(this.EventWrapper.OnNuevaFotografiaCamaraRemota);
                this.EventWrapper.CambioEstadoConexionCamara += this.CambioEstadoConexionCamara;
                this.CamaraCliente.CrearSuscripcionCambioEstadoConexion(this.EventWrapper.OnCambioEstadoConexionCamara);
                this.EventWrapper.CambioEstadoReproduccionCamara += this.CambioEstadoReproduccionCamara;
                this.CamaraCliente.CrearSuscripcionCambioEstadoReproduccion(this.EventWrapper.OnCambioEstadoReproduccionCamara);
                this.EventWrapper.MensajeCamara += this.MensajeCamara;
                this.CamaraCliente.CrearSuscripcionMensajes(this.EventWrapper.OnMensajeCamara);

                // Inicialización de variables
                this._TipoImagen = this.CamaraCliente.TipoImagen;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, "Error al conectarse a la cámara " + this.Codigo + ": " + exception.ToString());
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
                this.EventWrapper.NuevaFotografiaCamaraRemota -= this.NuevaFotografiaCamaraRemota;
                this.CamaraCliente.EliminarSuscripcionNuevaFotografiaRemota(this.EventWrapper.OnNuevaFotografiaCamaraRemota);
                this.EventWrapper.CambioEstadoConexionCamara -= this.CambioEstadoConexionCamara;
                this.CamaraCliente.EliminarSuscripcionCambioEstadoConexion(this.EventWrapper.OnCambioEstadoConexionCamara);
                this.EventWrapper.CambioEstadoReproduccionCamara -= this.CambioEstadoReproduccionCamara;
                this.CamaraCliente.EliminarSuscripcionCambioEstadoReproduccion(this.EventWrapper.OnCambioEstadoReproduccionCamara);
                this.EventWrapper.MensajeCamara -= this.MensajeCamara;
                this.CamaraCliente.EliminarSuscripcionMensajes(this.EventWrapper.OnMensajeCamara);
                this.CamaraCliente.Desconectar();

                resultado = true;
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, exception);
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
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, exception);
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
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, exception);
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
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, exception);
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
        private void NuevaFotografiaCamaraRemota(NuevaFotografiaCamaraRemotaEventArgs e)
        {
            try
            {
                if (!OThreadManager.EjecucionEnTrheadPrincipal())
                {
                    OThreadManager.SincronizarConThreadPrincipal(new EventoNuevaFotografiaCamaraRemota(this.NuevaFotografiaCamaraRemota), new object[] { e });
                    return;
                }

                if (this.EstadoConexion == EstadoConexion.Conectado)
                {
                    this.ImagenActual = e.Imagen.Desserializar();

                    //// Actualizo la conectividad
                    //this.Conectividad.EstadoConexion = EstadoConexion.Conectado;

                    //// Actualizo el Frame Rate
                    //this.MedidorVelocidadAdquisicion.NuevaCaptura();

                    // Lanamos el evento de adquisición
                    this.AdquisicionCompletada(this.ImagenActual);

                    //// Se asigna el valor de la variable asociada
                    //if (this.LanzarEventoAlSnap && this.ImagenActual.EsValida())
                    //{
                    //    this.EstablecerVariableImagenAsociada(this.ImagenActual);
                    //}
                }
            }
            catch (Exception exception)
            {
                OVALogsManager.Error(ModulosHardware.CamaraRemota, this.Codigo, exception);
            }
        }
        /// <summary>
        /// Evento de cambio de estado de conexión
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void CambioEstadoConexionCamara(CambioEstadoConexionCamaraEventArgs e)
        {
            this.OnCambioEstadoConectividadCamara(e.Codigo, e.EstadoConexionActual, e.EstadoConexionAnterior);
        }
        /// <summary>
        /// Evento de cambio de estado de reproducción
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void CambioEstadoReproduccionCamara(CambioEstadoReproduccionCamaraEventArgs e)
        {
            this.LanzarEventoCambioReproduccionCamara(e.Codigo, e.ModoReproduccionContinua);
        }
        /// <summary>
        /// Evento de nuevo mensaje
        /// </summary>
        /// <param name="estadoConexion"></param>
        private void MensajeCamara(OMessageEventArgs e)
        {
            this.LanzarEventoMensajeCamara(e.Codigo, e.Mensaje);
        }
        #endregion
    }

    /// <summary>
    /// Clase para acceder a los objetos OCamaraBase remotos
    /// </summary>
    [Serializable]
    internal class OCamaraCliente
    {
        #region Atributo(s)
        /// <summary>
        /// Clase remoting del servidor de cámaras
        /// </summary>
        private OServidorCamaras ServidorCamaras;
        /// <summary>
        /// Código identificador de la cámara remota
        /// </summary>
        private string CodigoRemoto;
        /// <summary>
        /// Dirección IP de la cámara
        /// </summary>
        private IPAddress IP;
        /// <summary>
        /// Puerto de conexión con la cámara
        /// </summary>
        private int Puerto;
        /// <summary>
        /// Canal del ciente
        /// </summary>
        private TcpChannel CanalCliente;
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
                    if (this.ServidorCamaras != null)
                    {
                        resultado = this.ServidorCamaras.GetExiste(this.CodigoRemoto);
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
                return this.ServidorCamaras.GetTipoImagen(this.CodigoRemoto);
            }
        }
        #endregion

        #region Constructor(es)
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public OCamaraCliente(string codigoRemoto, IPAddress ip, int puerto)
        {
            // Cargamos valores de la base de datos
            this.CodigoRemoto = codigoRemoto;
            this.IP = ip;
            this.Puerto = puerto;
        }
        #endregion

        #region Método(s) privado(s)
        private bool CanalRegistrado()
        {
            bool resultado = false;
            foreach (IChannel canal in ChannelServices.RegisteredChannels)
            {
                if (canal.ChannelName == "CamsCliente")
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Carga los valores de la cámara
        /// </summary>
        public bool Conectar()
        {
            if (!this.CanalRegistrado())
            {
                BinaryClientFormatterSinkProvider clientProvider2 = new BinaryClientFormatterSinkProvider();
                BinaryServerFormatterSinkProvider serverProvider2 = new BinaryServerFormatterSinkProvider();
                serverProvider2.TypeFilterLevel = TypeFilterLevel.Full;
                IDictionary props2 = new Hashtable();
                props2["port"] = 0;
                props2["typeFilterLevel"] = TypeFilterLevel.Full;
                props2["name"] = "CamsCliente";
                this.CanalCliente = new TcpChannel(props2, clientProvider2, serverProvider2);
                this.CanalCliente.StartListening(0);
                ChannelServices.RegisterChannel(this.CanalCliente, false);  //register channel
            }

            string direccion = string.Format(@"tcp://{0}:{1}/{2}", this.IP, this.Puerto, "Cams"); // Dirección remota
            this.ServidorCamaras = (OServidorCamaras)Activator.GetObject(typeof(OServidorCamaras), direccion);

            return this.Existe;
        }

        /// <summary>
        /// Finaliza la cámara
        /// </summary>
        public void Desconectar()
        {
            if (this.CanalRegistrado())
            {
                ChannelServices.UnregisterChannel(this.CanalCliente);
            }
        }

        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            return this.ServidorCamaras.Start(this.CodigoRemoto);
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            return this.ServidorCamaras.Stop(this.CodigoRemoto);
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        public bool Snap()
        {
            return this.ServidorCamaras.Snap(this.CodigoRemoto);
        }

        /// <summary>
        /// Comienza una grabación continua de la cámara
        /// </summary>
        /// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
        /// <returns></returns>
        public bool StartREC(string fichero)
        {
            return this.ServidorCamaras.StartREC(this.CodigoRemoto, fichero);
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool StopREC()
        {
            return this.ServidorCamaras.StopREC(this.CodigoRemoto);
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codAjuste, object valor)
        {
            return this.ServidorCamaras.SetAjuste(this.CodigoRemoto, codAjuste, valor);
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codAjuste, out object valor)
        {
            return this.ServidorCamaras.GetAjuste(this.CodigoRemoto, codAjuste, out valor);
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public bool GuardarImagenADisco(string ruta)
        {
            return this.ServidorCamaras.GuardarImagenADisco(this.CodigoRemoto, ruta);
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaRemota(EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            this.ServidorCamaras.CrearSuscripcionNuevaFotografiaRemota(this.CodigoRemoto, delegadoNuevaFotografiaCamaraRemota);
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaRemota(EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            this.ServidorCamaras.EliminarSuscripcionNuevaFotografiaRemotaRemota(this.CodigoRemoto, delegadoNuevaFotografiaCamaraRemota);
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoConexion(EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            this.ServidorCamaras.CrearSuscripcionCambioEstadoConexion(this.CodigoRemoto, delegadoCambioEstadoConexionCamara);
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoConexion(EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            this.ServidorCamaras.EliminarSuscripcionCambioEstadoConexion(this.CodigoRemoto, delegadoCambioEstadoConexionCamara);
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoReproduccion(EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            this.ServidorCamaras.CrearSuscripcionCambioEstadoReproduccion(this.CodigoRemoto, delegadoCambioEstadoReproduccionCamara);
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoReproduccion(EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            this.ServidorCamaras.EliminarSuscripcionCambioEstadoReproduccion(this.CodigoRemoto, delegadoCambioEstadoReproduccionCamara);
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionMensajes(OMessageEvent messageDelegate)
        {
            this.ServidorCamaras.CrearSuscripcionMensajes(this.CodigoRemoto, messageDelegate);
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionMensajes(OMessageEvent messageDelegate)
        {
            this.ServidorCamaras.EliminarSuscripcionMensajes(this.CodigoRemoto, messageDelegate);
        }
        #endregion
    }

    /// <summary>
    /// Clase utilizada para enlazar con los eventos del variablecore de forma remota
    /// </summary>
    [Serializable]
    public class OCamaraBroadcastEventWraper : MarshalByRefObject
    {
        #region Evento(s)
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
        public event OMessageEvent MensajeCamara;
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Evento de cambio de fotografía.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        [OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnNuevaFotografiaCamaraRemota(NuevaFotografiaCamaraRemotaEventArgs e)
        {
            try
            {
                if (NuevaFotografiaCamaraRemota != null)
                {
                    this.NuevaFotografiaCamaraRemota(e);
                }
            }
            catch { }
        }

        /// <summary>
        /// Evento de cambio de conexión.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        [OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnCambioEstadoConexionCamara(CambioEstadoConexionCamaraEventArgs e)
        {
            try
            {
                if (CambioEstadoConexionCamara != null)
                {
                    this.CambioEstadoConexionCamara(e);
                }
            }
            catch { }
        }

        /// <summary>
        /// Evento de cambio de Reproducción.
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        [OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnCambioEstadoReproduccionCamara(CambioEstadoReproduccionCamaraEventArgs e)
        {
            try
            {
                if (CambioEstadoReproduccionCamara != null)
                {
                    this.CambioEstadoReproduccionCamara(e);
                }
            }
            catch { }
        }

        /// <summary>
        /// Evento de nuevo mensaje
        /// </summary>
        /// <param name="e">Argumento que puede ser utilizado en el manejador de evento.</param>
        [OneWay]
        [EnvironmentPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public void OnMensajeCamara(OMessageEventArgs e)
        {
            try
            {
                if (MensajeCamara != null)
                {
                    this.MensajeCamara(e);
                }
            }
            catch { }
        }
        #endregion
    }
}
