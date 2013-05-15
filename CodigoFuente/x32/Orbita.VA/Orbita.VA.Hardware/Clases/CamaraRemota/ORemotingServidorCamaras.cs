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
        /// Identificador de la cámara
        /// </summary>
        private string CodigoCliente;
        /// <summary>
        /// Identificador de la cámara servidora
        /// </summary>
        private string CodigoServidor;
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
        private delegate bool StartDelegate();
        /// <summary>
        /// Delegado de parada de reproducción
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private delegate bool StopDelegate();
        #endregion

        #region Método(s) público(s)
        /// <summary>
        /// Enlaza con el cliente
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="codigoServidor"></param>
        public void Enlazar(string codigoCliente, string codigoServidor)
        {
            try
            {
                this.CodigoCliente = codigoCliente;
                this.CodigoServidor = codigoServidor;
                this.Camara = null;

                object camObj = OCamaraManager.GetCamara(codigoServidor);
                if (camObj is OCamaraServidor)
                {
                    this.Camara = camObj as OCamaraServidor;
                }
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }

        /// <summary>
        /// Desenlaza con el cliente
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="codigoServidor"></param>
        public void Desenlazar()
        {
            try
            {
                this.CodigoCliente = string.Empty;
                this.CodigoServidor = string.Empty;
                this.Camara = null;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception);
            }
        }

        /// <summary>
        /// Comienza una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StartDelegate(Start), new object[] { });
            }

            try
            {
                return this.Camara.Start();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Termina una reproducción continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            if (!OThreadManager.EjecucionEnTrheadPrincipal())
            {
                return (bool)OThreadManager.SincronizarConThreadPrincipal(new StopDelegate(Stop), new object[] { });
            }

            try
            {
                this.Camara.Stop();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
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
                return this.Camara.Snap();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
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
            try
            {
                return this.Camara.StartREC(fichero);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Termina una grabación continua de la cámara
        /// </summary>
        /// <returns></returns>
        public bool StopREC()
        {
            try
            {
                return this.Camara.StopREC();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Ajusta un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool SetAjuste(string codAjuste, object valor)
        {
            try
            {
                return this.Camara.SetAjuste(codAjuste, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Consulta el valor de un determinado parámetro de la cámara
        /// </summary>
        /// <param name="codAjuste">Código identificativo del ajuste</param>
        /// <param name="valor">valor a ajustar</param>
        /// <returns>Verdadero si la acción se ha realizado con éxito</returns>
        public bool GetAjuste(string codAjuste, out object valor)
        {
            valor = null;
            try
            {
                return this.Camara.GetAjuste(codAjuste, out valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Consulta si el PTZ está habilitado
        /// </summary>
        /// <returns>Verdadero si el PTZ está habilitado</returns>
        public bool PTZHabilitado()
        {
            try
            {
                return this.Camara.PTZHabilitado();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
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
        public bool EjecutaMovimientoPTZ(OEnumTipoMovimientoPTZ tipo, OEnumModoMovimientoPTZ modo, double valor)
        {
            try
            {
                return this.Camara.EjecutaMovimientoPTZ(tipo, modo, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="movimiento">Tipo de movimiento ptz a ejecutar</param>
        /// <param name="valor">valor a establecer</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OMovimientoPTZ movimiento, double valor)
        {
            try
            {
                return this.Camara.EjecutaMovimientoPTZ(movimiento, valor);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false; 
        }

        /// <summary>
        /// Ejecuta un movimiento simple de ptz
        /// </summary>
        /// <param name="comando">Comando del movimiento ptz a ejecutar</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OComandoPTZ comando)
        {
            try
            {
                return this.Camara.EjecutaMovimientoPTZ(comando);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento compuesto de ptz
        /// </summary>
        /// <param name="valores">Tipos de movimientos y valores</param>
        /// <returns>Verdadero si se ha ejecutado correctamente</returns>
        public bool EjecutaMovimientoPTZ(OComandosPTZ valores)
        {
            try
            {
                return this.Camara.EjecutaMovimientoPTZ(valores);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Actualiza la posición actual del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaPosicionPTZ()
        {
            try
            {
                return this.Camara.ConsultaPosicionPTZ();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return new OPosicionesPTZ();
        }

        /// <summary>
        /// Actualiza la posición actual de un determinado movimiento PTZ
        /// </summary>
        /// <returns>Listado de posiciones actuales</returns>
        public OPosicionPTZ ConsultaPosicionPTZ(OEnumTipoMovimientoPTZ movimiento)
        {
            try
            {
                return this.Camara.ConsultaPosicionPTZ(movimiento);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return new OPosicionPTZ();
        }

        /// <summary>
        /// Consulta última posición leida del PTZ
        /// </summary>
        /// <returns></returns>
        public OPosicionesPTZ ConsultaUltimaPosicionPTZ()
        {
            try
            {
                return this.Camara.ConsultaUltimaPosicionPTZ();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return new OPosicionesPTZ();
        }

        /// <summary>
        /// Guarda una imagen en disco
        /// </summary>
        /// <param name="ruta">Indica la ruta donde se ha de guardar la fotografía</param>
        /// <returns>Devuelve verdadero si la operación se ha realizado con éxito</returns>
        public bool GuardarImagenADisco(string ruta)
        {
            try
            {
                return this.Camara.GuardarImagenADisco(ruta);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false; 
        }

        /// <summary>
        /// Método que realiza el empaquetado de un objeto para ser enviado por remoting
        /// </summary>
        /// <returns></returns>
        public OByteArrayImage Serializar()
        {
            try
            {
                return this.Camara.Serializar();
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return null;
        }

        /// <summary>
        /// Devuelve el tipo de imagen con el que trabaja la cámara
        /// </summary>
        /// <returns></returns>
        public TipoImagen GetTipoImagen()
        {
            try
            {
                return this.Camara.TipoImagen;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return default(TipoImagen);
        }

        /// <summary>
        /// Indica que se ha podido acceder a la cámara con éxito
        /// </summary>
        public bool GetExiste()
        {
            try
            {
                return this.Camara.Existe;
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
            return false;
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaMemoriaMapeada(string codigoCliente, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                this.Camara.CrearSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigoCliente, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaMemoriaMapeada(string codigoCliente, EventoNuevaFotografiaCamaraMemoriaMapeada delegadoNuevaFotografiaCamaraMemoriaMapeada)
        {
            try
            {
                this.Camara.EliminarSuscripcionNuevaFotografiaAsincronaMemoriaMapeada(codigoCliente, delegadoNuevaFotografiaCamaraMemoriaMapeada);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }

        /// <summary>
        /// Suscribe el cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void CrearSuscripcionNuevaFotografiaRemota(string codigoCliente, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                this.Camara.CrearSuscripcionNuevaFotografiaAsincronaRemota(codigoCliente, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de fotografía de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de fotografía</param>
        public void EliminarSuscripcionNuevaFotografiaRemota(string codigoCliente, EventoNuevaFotografiaCamaraRemota delegadoNuevaFotografiaCamaraRemota)
        {
            try
            {
                this.Camara.EliminarSuscripcionNuevaFotografiaAsincronaRemota(codigoCliente, delegadoNuevaFotografiaCamaraRemota);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoConexion(string codigoCliente, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                this.Camara.CrearSuscripcionCambioEstadoConexionAsincrona(codigoCliente, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoConexion(string codigoCliente, EventoCambioEstadoConexionCamara delegadoCambioEstadoConexionCamara)
        {
            try
            {
                this.Camara.EliminarSuscripcionCambioEstadoConexionAsincrona(codigoCliente, delegadoCambioEstadoConexionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }

        /// <summary>
        /// Suscribe el cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void CrearSuscripcionCambioEstadoReproduccion(string codigoCliente, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                this.Camara.CrearSuscripcionCambioEstadoReproduccionAsincrona(codigoCliente, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        /// <summary>
        /// Elimina la suscripción del cambio de estado de reproducción de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir llamadas a cada cambio de estado</param>
        public void EliminarSuscripcionCambioEstadoReproduccion(string codigoCliente, EventoCambioEstadoReproduccionCamara delegadoCambioEstadoReproduccionCamara)
        {
            try
            {
                this.Camara.EliminarSuscripcionCambioEstadoReproduccionAsincrona(codigoCliente, delegadoCambioEstadoReproduccionCamara);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }

        /// <summary>
        /// Suscribe la recepción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionMensajes(string codigoCliente, OMessageEvent messageDelegate)
        {
            try
            {
                this.Camara.CrearSuscripcionMensajesAsincrona(codigoCliente, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        /// <summary>
        /// Elimina la suscripción de mensajes de una determinada cámara
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionMensajes(string codigoCliente, OMessageEvent messageDelegate)
        {
            try
            {
                this.Camara.EliminarSuscripcionMensajesAsincrona(codigoCliente, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }

        /// <summary>
        /// Suscribe la recepción del bit de vida
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void CrearSuscripcionBitVida(string codigoCliente, ManejadorEvento messageDelegate)
        {
            try
            {
                this.Camara.CrearSuscripcionBitVidaAsincrona(codigoCliente, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        /// <summary>
        /// Elimina la suscripción del bit de vida
        /// </summary>
        /// <param name="codigoRemoto">Código de la cámara</param>
        /// <param name="delegadoNuevaFotografiaCamara">Delegado donde recibir los mensajes</param>
        public void EliminarSuscripcionBitVida(string codigoCliente, ManejadorEvento messageDelegate)
        {
            try
            {
                this.Camara.EliminarSuscripcionBitVidaAsincrona(codigoCliente, messageDelegate);
            }
            catch (Exception exception)
            {
                OLogsVAHardware.Camaras.Error(exception, CodigoCliente);
            }
        }
        #endregion
    }
}
