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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using Orbita.Utiles;
using Orbita.VA.Comun;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Manejador del servidor de cámaras
    /// </summary>
    public static class OServidorCamaraManager
    {
        #region Atributo(s)
        /// <summary>
        /// Indica si la clase estática está iniciada
        /// </summary>
        public static bool Iniciado = false;

        /// <summary>
        /// Puerto de comunicación con la variable remota
        /// </summary>
        internal static int Puerto;

        /// <summary>
        /// Canal de Servidor de remoting
        /// </summary>
        internal static TcpChannel CanalServidor; //channel to communicate
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Construye los objetos
        /// </summary>
        public static void Constructor()
        {
            // Creación de los objetos
            Puerto = 9095;

            // Consulta a la base de datos
            DataTable dtSistema = Orbita.VA.Comun.AppBD.GetParametrosAplicacion();
            if (dtSistema.Rows.Count > 0)
            {
                Puerto = (int)OEntero.Validar(dtSistema.Rows[0]["PuertoServidorCamaraRemoting"], 1, 65535, 9095);
            }
            else
            {
                throw new Exception("No existe nigún registro de parametrización de la aplicación en la base de datos");
            }

            // Registro del canal de servidor
            //BinaryClientFormatterSinkProvider clientProvider = null;
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
            IDictionary props = new Hashtable();
            props["port"] = Puerto;
            props["typeFilterLevel"] = TypeFilterLevel.Full;
            props["name"] = "CamsServidor";
            CanalServidor = new TcpChannel(props, clientProvider, serverProvider); //channel to communicate
            ChannelServices.RegisterChannel(CanalServidor, false);  //register channel
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(OServidorCamaras), "Cams", WellKnownObjectMode.Singleton); //register remote object
        }

        /// <summary>
        /// Destruye los objetos
        /// </summary>
        public static void Destructor()
        {
            // Destrucción de los objetos
            ChannelServices.UnregisterChannel(CanalServidor);
        }

        /// <summary>
        /// Se cargan los valores de la clase
        /// </summary>
        public static void Inicializar()
        {
            Iniciado = true;
        }

        /// <summary>
        /// Se finaliza la ejecución
        /// </summary>
        public static void Finalizar()
        {
            Iniciado = false;
        }
        #endregion
    }

    /// <summary>
    /// Clase para acceder a los objetos OCamaraBase remotos
    /// </summary>
    [Serializable]
    public class OServidorCamaras : MarshalByRefObject
    {
        #region Método(s) público(s)
        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Start(string codigo)
        {
            return OCamaraManager.Start(codigo);
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Stop(string codigo)
        {
            return OCamaraManager.Stop(codigo);
        }

        /// <summary>
        /// Comienza una reproducción de todas las cámaras
        /// </summary>
        /// <returns></returns>
        public bool StartAll()
        {
            return OCamaraManager.StartAll();
        }

        /// <summary>
        /// Termina la reproducción de todas las cámaras
        /// </summary>
        /// <returns></returns>
        public bool StopAll()
        {
            return OCamaraManager.StopAll();
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        public bool Snap(string codigo)
        {
            return OCamaraManager.Snap(codigo);
        }

        /// <summary>
        /// Comienza una grabación continua de la cámara
        /// </summary>
        /// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
        /// <returns></returns>
        public bool StartREC(string codigo, string fichero)
        {
            return OCamaraManager.StartREC(codigo, fichero);
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool StopREC(string codigo)
        {
            return OCamaraManager.StopREC(codigo);
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codCamara, string codAjuste, object valor)
        {
            return OCamaraManager.SetAjuste(codCamara, codAjuste, valor);
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codCamara, string codAjuste, out object valor)
        {
            return OCamaraManager.GetAjuste(codCamara, codAjuste, out valor);
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="tipo">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="modo">Modo de movimiento: Absoluto o relativo</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            return OCamaraManager.EjecutaMovimientoPTZ(codigo, tipo, modo, valor);
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OMovimientoPTZ movimiento, double valor)
        {
            return OCamaraManager.EjecutaMovimientoPTZ(codigo, movimiento, valor);
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OComandoPTZ comando)
        {
            return OCamaraManager.EjecutaMovimientoPTZ(codigo, comando);
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OComandosPTZ valores)
        {
            return OCamaraManager.EjecutaMovimientoPTZ(codigo, valores);
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaPosicionPTZ(string codigo)
        {
            return OCamaraManager.ConsultaPosicionPTZ(codigo);
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public OPosicionPTZ ConsultaPosicionPTZ(string codigo, OEnumTipoMovimientoPTZ movimiento)
        {
            return OCamaraManager.ConsultaPosicionPTZ(codigo, movimiento);
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public bool GuardarImagenADisco(string codigo, string ruta)
        {
            return OCamaraManager.GuardarImagenADisco(codigo, ruta);
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public OByteArrayImage Serializar(string codigo)
        {
            return OCamaraManager.Serializar(codigo);
        }

        /// <summary>
        /// Devuelve el tipo de imagen con el que trabaja la cámara
        /// </summary>
        /// <returns></returns>
        public TipoImagen GetTipoImagen(string codigo)
        {
            return OCamaraManager.GetTipoImagen(codigo);
        }

        /// <summary>
        /// Indica que se ha podido acceder a la cámara con éxito
        /// </summary>
        public bool GetExiste(string codigo)
        {
            return OCamaraManager.GetExiste(codigo);
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaRemota(string codigo, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            OCamaraManager.CrearSuscripcionNuevaFotografiaRemota(codigo, delegadoNuevaFotografiaCamaraRemota);
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaRemotaRemota(string codigo, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            OCamaraManager.EliminarSuscripcionNuevaFotografiaRemotaRemota(codigo, delegadoNuevaFotografiaCamaraRemota);
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoConexion(string codigo, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            OCamaraManager.CrearSuscripcionCambioEstadoConexion(codigo, delegadoCambioEstadoConexionCamara);
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoConexion(string codigo, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            OCamaraManager.EliminarSuscripcionCambioEstadoConexion(codigo, delegadoCambioEstadoConexionCamara);
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoReproduccion(string codigo, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            OCamaraManager.CrearSuscripcionCambioEstadoReproduccion(codigo, delegadoCambioEstadoReproduccionCamara);
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoReproduccion(string codigo, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            OCamaraManager.EliminarSuscripcionCambioEstadoReproduccion(codigo, delegadoCambioEstadoReproduccionCamara);
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionMensajes(string codigo, OMessageEvent messageDelegate)
        {
            OHardwareManager.CrearSuscripcionMensajes(codigo, messageDelegate);
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionMensajes(string codigo, OMessageEvent messageDelegate)
        {
            OHardwareManager.EliminarSuscripcionMensajes(codigo, messageDelegate);
        }
        #endregion
    }
}
