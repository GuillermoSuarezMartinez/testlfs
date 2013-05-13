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
        #region Declaración de eventos
        /// <summary>
        /// Delegado de inicio de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StartDelegate(string codigo);
        /// <summary>
        /// Delegado de parada de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StopDelegate(string codigo);
        /// <summary>
        /// Delegado de inicio de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StartAllDelegate();
        /// <summary>
        /// Delegado de parada de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StopAllDelegate();
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Start(string codigo)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StartDelegate(Start), new object[] { codigo });
            }

            try
            {
                return OCamaraManager.Start(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Stop(string codigo)
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StopDelegate(Stop), new object[] { codigo });
            }

            try
            {
                return OCamaraManager.Stop(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Comienza una reproducción de todas las cámaras
        /// </summary>
        /// <returns></returns>
        public bool StartAll()
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StartAllDelegate(StartAll), new object[] { });
            }

            try
            {
                return OCamaraManager.StartAll();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            return false; 
        }

        /// <summary>
        /// Termina la reproducción de todas las cámaras
        /// </summary>
        /// <returns></returns>
        public bool StopAll()
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StopAllDelegate(StopAll), new object[] { });
            }

            try
            {
                return OCamaraManager.StopAll();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
            return false;
        }

        /// <summary>
        /// Realiza una fotografía de forma sincrona
        /// </summary>
        /// <returns></returns>
        public bool Snap(string codigo)
        {
            try
            {
                return OCamaraManager.Snap(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Comienza una grabación continua de la cámara
        /// </summary>
        /// <param name="fichero">Ruta y nombre del fichero que contendra el video</param>
        /// <returns></returns>
        public bool StartREC(string codigo, string fichero)
        {
            try
            {
                return OCamaraManager.StartREC(codigo, fichero);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool StopREC(string codigo)
        {
            try
            {
                return OCamaraManager.StopREC(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codCamara, string codAjuste, object valor)
        {
            try
            {
                return OCamaraManager.SetAjuste(codCamara, codAjuste, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codCamara);
            }
            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codCamara, string codAjuste, out object valor)
        {
            valor = null;
            try
            {
                return OCamaraManager.GetAjuste(codCamara, codAjuste, out valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codCamara);
            }
            return false;
        }

        /// <summary>
        /// Consulta si el PTZ está habilitado
        /// </summary>
        /// <returns>Verdadero si el PTZ está habilitado</returns>
        public bool PTZHabilitado(string codigo)
        {
            try
            {
                return OCamaraManager.PTZHabilitado(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
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
        public bool EjecutaMovimientoPTZ(string codigo, OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigo, tipo, modo, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OMovimientoPTZ movimiento, double valor)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigo, movimiento, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false; 
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OComandoPTZ comando)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigo, comando);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(string codigo, OComandosPTZ valores)
        {
            try
            {
                return OCamaraManager.EjecutaMovimientoPTZ(codigo, valores);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaPosicionPTZ(string codigo)
        {
            try
            {
                return OCamaraManager.ConsultaPosicionPTZ(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return new OPosicionesPTZ();
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public OPosicionPTZ ConsultaPosicionPTZ(string codigo, OEnumTipoMovimientoPTZ movimiento)
        {
            try
            {
                return OCamaraManager.ConsultaPosicionPTZ(codigo, movimiento);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return new OPosicionPTZ();
        }

        /// <summary>
        /// Consulta última posición leida del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaUltimaPosicionPTZ(string codigo)
        {
            try
            {
                return OCamaraManager.ConsultaUltimaPosicionPTZ(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return new OPosicionesPTZ();
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public bool GuardarImagenADisco(string codigo, string ruta)
        {
            try
            {
                return OCamaraManager.GuardarImagenADisco(codigo, ruta);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false; 
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public OByteArrayImage Serializar(string codigo)
        {
            try
            {
                return OCamaraManager.Serializar(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return null;
        }

        /// <summary>
        /// Devuelve el tipo de imagen con el que trabaja la cámara
        /// </summary>
        /// <returns></returns>
        public TipoImagen GetTipoImagen(string codigo)
        {
            try
            {
                return OCamaraManager.GetTipoImagen(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return default(TipoImagen);
        }

        /// <summary>
        /// Indica que se ha podido acceder a la cámara con éxito
        /// </summary>
        public bool GetExiste(string codigo)
        {
            try
            {
                return OCamaraManager.GetExiste(codigo);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
            return false;
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaMemoriaMapeada(string codigo, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                OCamaraManager.CrearSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigo, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaMemoriaMapeada(string codigo, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigo, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaRemota(string codigo, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                OCamaraManager.CrearSuscripcionNuevaFotografiaAsincronaRemota(codigo, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaRemota(string codigo, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionNuevaFotografiaAsincronaRemota(codigo, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoConexion(string codigo, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                OCamaraManager.CrearSuscripcionCambioEstadoConexionAsincrona(codigo, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoConexion(string codigo, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionCambioEstadoConexionAsincrona(codigo, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoReproduccion(string codigo, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                OCamaraManager.CrearSuscripcionCambioEstadoReproduccionAsincrona(codigo, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoReproduccion(string codigo, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionCambioEstadoReproduccionAsincrona(codigo, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionMensajes(string codigo, OMessageEvent messageDelegate)
        {
            try
            {
                OCamaraManager.CrearSuscripcionMensajesAsincrona(codigo, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionMensajes(string codigo, OMessageEvent messageDelegate)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionMensajesAsincrona(codigo, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Suscribe la recepción del bit de vida
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionBitVida(string codigo, ManejadorEvento messageDelegate)
        {
            try
            {
                OCamaraManager.CrearSuscripcionBitVidaAsincrona(codigo, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        /// <summary>
        /// Elimina la suscripción del bit de vida
        /// </summary>
        /// <param name="codigo">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionBitVida(string codigo, ManejadorEvento messageDelegate)
        {
            try
            {
                OCamaraManager.EliminarSuscripcionBitVidaAsincrona(codigo, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, codigo);
            }
        }
        #endregion
    }
}
