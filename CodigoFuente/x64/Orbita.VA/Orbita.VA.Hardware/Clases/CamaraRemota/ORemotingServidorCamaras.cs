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
using System.Collections.Generic;

namespace Orbita.VA.Hardware
{
    /// <summary>
    /// Clase para acceder a los objetos OCamaraBase remotos
    /// </summary>
    [Serializable]
    public class ORemotingCamaraServidor : ORemotingObject
    {
        #region Atributo(s)
        /// <summary>
        /// Cámara asocada
        /// </summary>
        private OCamaraServidor Camara;
        #endregion

        #region Declaración de eventos
        /// <summary>
        /// Delegado de inicio de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StartDelegate(string codigoCliente);
        /// <summary>
        /// Delegado de parada de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StopDelegate(string codigoCliente);
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Start(string codigoRemoto)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StartDelegate(Start), new object[] { codigoRemoto });
            }

            try
            {
                return OCamaraManager.Start(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Stop(string codigoRemoto)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StopDelegate(Stop), new object[] { codigoRemoto });
            }

            try
            {
                OCamaraManager.Stop(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        public bool Snap(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.Snap(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Comienza una grabación continua de la cámara
        /// </summary>
        /// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
        /// <returns></returns>
        public bool StartREC(string codigoRemoto, string fichero)
        {
            try
            {
                return OCamaraManager.StartREC(codigoRemoto, fichero);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool StopREC(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.StopREC(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codigoRemoto, string codAjuste, object valor)
        {
            try
            {
                return OCamaraManager.SetAjuste(codigoRemoto, codAjuste, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codigoRemoto, string codAjuste, out object valor)
        {
            valor = null;
            try
            {
                return OCamaraManager.GetAjuste(codigoRemoto, codAjuste, out valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Consulta si el PTZ está habilitado
        /// </summary>
        /// <returns>Verdadero si el PTZ está habilitado</returns>
        public bool PTZHabilitado(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.PTZHabilitado(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
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
        public bool EjecutaMovimientoPTZ(string codigoRemoto, OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigoRemoto, tipo, modo, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigoRemoto, OMovimientoPTZ movimiento, double valor)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigoRemoto, movimiento, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false; 
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigoRemoto, OComandoPTZ comando)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigoRemoto, comando);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigoRemoto, OComandosPTZ valores)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigoRemoto, valores);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaPosicionPTZ(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.ConsultaPosicionPTZ(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return new OPosicionesPTZ();
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public OPosicionPTZ ConsultaPosicionPTZ(string codigoRemoto, OEnumTipoMovimientoPTZ movimiento)
        {
            try
            {
                return OCamaraManager.ConsultaPosicionPTZ(codigoRemoto, movimiento);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return new OPosicionPTZ();
        }

        /// <summary>
        /// Consulta última posición leida del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaUltimaPosicionPTZ(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.ConsultaUltimaPosicionPTZ(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return new OPosicionesPTZ();
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public bool GuardarImagenADisco(string codigoRemoto, string ruta)
        {
            try
            {
                return OCamaraManager.GuardarImagenADisco(codigoRemoto, ruta);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false; 
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public OByteArrayImage Serializar(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.Serializar(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return null;
        }

        /// <summary>
        /// Devuelve el tipo de imagen con el que trabaja la cámara
        /// </summary>
        /// <returns></returns>
        public TipoImagen GetTipoImagen(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.GetTipoImagen(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return default(TipoImagen);
        }

        /// <summary>
        /// Indica que se ha podido acceder a la cámara con éxito
        /// </summary>
        public bool GetExiste(string codigoRemoto)
        {
            try
            {
                return OCamaraManager.GetExiste(codigoRemoto);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
            return false;
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaMemoriaMapeada(string codigoCliente, string codigoRemoto, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                OCamaraManager.CrearSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigoCliente, codigoRemoto, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaMemoriaMapeada(string codigoCliente, string codigoRemoto, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigoCliente, codigoRemoto, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaRemota(string codigoCliente, string codigoRemoto, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                OCamaraManager.CrearSuscripcionNuevaFotografiaAsincronaRemota(codigoCliente, codigoRemoto, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaRemota(string codigoCliente, string codigoRemoto, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionNuevaFotografiaAsincronaRemota(codigoCliente, codigoRemoto, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoConexion(string codigoCliente, string codigoRemoto, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                OCamaraManager.CrearSuscripcionCambioEstadoConexionAsincrona(codigoCliente, codigoRemoto, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoConexion(string codigoCliente, string codigoRemoto, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionCambioEstadoConexionAsincrona(codigoCliente, codigoRemoto, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoReproduccion(string codigoCliente, string codigoRemoto, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                OCamaraManager.CrearSuscripcionCambioEstadoReproduccionAsincrona(codigoCliente, codigoRemoto, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoReproduccion(string codigoCliente, string codigoRemoto, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionCambioEstadoReproduccionAsincrona(codigoCliente, codigoRemoto, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionMensajes(string codigoCliente, string codigoRemoto, OMessageEvent messageDelegate)
        {
            try
            {
                OCamaraManager.CrearSuscripcionMensajesAsincrona(codigoCliente, codigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionMensajes(string codigoCliente, string codigoRemoto, OMessageEvent messageDelegate)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionMensajesAsincrona(codigoCliente, codigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }

        /// <summary>
        /// Suscribe la recepción del bit de vida
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionBitVida(string codigoCliente, string codigoRemoto, ManejadorEvento messageDelegate)
        {
            try
            {
                OCamaraManager.CrearSuscripcionBitVidaAsincrona(codigoCliente, codigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        /// <summary>
        /// Elimina la suscripción del bit de vida
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionBitVida(string codigoCliente, string codigoRemoto, ManejadorEvento messageDelegate)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionBitVidaAsincrona(codigoCliente, codigoRemoto, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigoRemoto);
            }
        }
        #endregion
    }
}
