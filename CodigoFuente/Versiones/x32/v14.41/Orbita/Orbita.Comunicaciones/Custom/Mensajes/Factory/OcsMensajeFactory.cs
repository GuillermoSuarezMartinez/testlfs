﻿//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************
using System;
using Orbita.Utiles;
using System.Collections;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Esta clase se utiliza para crear y obtener mensajes.
    /// </summary>
    public static class OcsMensajeFactory
    {
        #region Métodos públicos

        #region Cambio de dato
        /// <summary>
        /// Crea un mensaje de tipo cambio de dato que contiene información del objeto OInfoDato.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <returns></returns>
        public static IMensaje CrearMensajeCambioDato(OInfoDato infoDato)
        {
            return new OcsMensajeCambioDato(infoDato);
        }
        /// <summary>
        /// Crea un mensaje de tipo cambio de dato que contiene información del objeto OInfoDato.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IMensaje CrearMensajeCambioDato(OInfoDato infoDato, string idMensajeRespuesta)
        {
            return new OcsMensajeCambioDato(infoDato, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo cambio de dato que contiene información del objeto OInfoDato.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static IOcsMensajeInfoDato ObtenerMensajeCambioDato(IMensaje mensaje)
        {
            return (OcsMensajeCambioDato)mensaje;
        }
        #endregion Cambio de dato

        #region Alarma
        /// <summary>
        /// Crea un mensaje de tipo alarma que contiene información del objeto OInfoDato.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <returns></returns>
        public static IMensaje CrearMensajeAlarma(OInfoDato infoDato)
        {
            return new OcsMensajeAlarma(infoDato);
        }
        /// <summary>
        /// Crea un mensaje de tipo alarma que contiene información del objeto OInfoDato.
        /// </summary>
        /// <param name="infoDato">Información del dato que será transmitido.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IMensaje CrearMensajeAlarma(OInfoDato infoDato, string idMensajeRespuesta)
        {
            return new OcsMensajeAlarma(infoDato, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo alarma que contiene información del objeto OInfoDato.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static IOcsMensajeInfoDato ObtenerMensajeAlarma(IMensaje mensaje)
        {
            return (OcsMensajeAlarma)mensaje;
        }
        #endregion Alarma

        #region Comunicaciones
        /// <summary>
        /// Crea un mensaje de tipo comunicaciones que contiene información del objeto OEstadoComms.
        /// </summary>
        /// <param name="infoComm"></param>
        /// <returns></returns>
        public static IMensaje CrearMensajeComunicaciones(OEstadoComms infoComm)
        {
            return new OcsMensajeComunicaciones(infoComm);
        }
        /// <summary>
        /// Crea un mensaje de tipo comunicaciones que contiene información del objeto OEstadoComms.
        /// </summary>
        /// <param name="infoComm"></param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IMensaje CrearMensajeComunicaciones(OEstadoComms infoComm, string idMensajeRespuesta)
        {
            return new OcsMensajeComunicaciones(infoComm, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo comunicaciones que contiene información del objeto OEstadoComms.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeComunicaciones ObtenerMensajeComunicaciones(IMensaje mensaje)
        {
            return (OcsMensajeComunicaciones)mensaje;
        }
        #endregion Comunicaciones

        #region Lecturas
        /// <summary>
        /// Crea un mensaje de tipo lectura que contiene información del objeto OEstadoComms.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="demanda">Indica si la lectura se realiza bajo demanda al dispositivo.</param>
        /// <returns></returns>
        public static IOcsMensajeLectura CrearMensajeLectura(int dispositivo, string[] variables, bool demanda)
        {
            return new OcsMensajeLectura(dispositivo, variables, demanda);
        }
        /// <summary>
        /// Crea un mensaje de tipo lectura que contiene información del objeto OEstadoComms.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeLectura CrearMensajeLectura(int dispositivo, string[] variables, object[] valores, string idMensajeRespuesta)
        {
            return new OcsMensajeLectura(dispositivo, variables, valores, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo lectura que contiene información del objeto OEstadoComms.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeLectura ObtenerMensajeLectura(IMensaje mensaje)
        {
            return (OcsMensajeLectura)mensaje;
        }
        #endregion Lecturas

        #region Datos
        /// <summary>
        /// Crea un mensaje de tipo datos que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaDatos CrearMensajeDatos(int dispositivo)
        {
            return new OcsMensajeLecturaDatos(dispositivo);
        }
        /// <summary>
        /// Crea un mensaje de tipo datos que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="datos">Colección de datos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaDatos CrearMensajeDatos(int dispositivo, OHashtable datos, string idMensajeRespuesta)
        {
            return new OcsMensajeLecturaDatos(dispositivo, datos, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo datos que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaDatos ObtenerMensajeDatos(IMensaje mensaje)
        {
            return (OcsMensajeLecturaDatos)mensaje;
        }
        #endregion Datos

        #region Alarmas activas
        /// <summary>
        /// Crea un mensaje de tipo alarmas activas que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaAlarmasActivas CrearMensajeAlarmasActivas(int dispositivo)
        {
            return new OcsMensajeLecturaAlarmasActivas(dispositivo);
        }
        /// <summary>
        /// Crea un mensaje de tipo alarmas activas que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="datos">Colección de datos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaAlarmasActivas CrearMensajeAlarmasActivas(int dispositivo, ArrayList datos, string idMensajeRespuesta)
        {
            return new OcsMensajeLecturaAlarmasActivas(dispositivo, datos, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo alarmas activas que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaAlarmasActivas ObtenerMensajeAlarmasActivas(IMensaje mensaje)
        {
            return (OcsMensajeLecturaAlarmasActivas)mensaje;
        }
        #endregion Alarmas activas

        #region Dispositivos
        /// <summary>
        /// Crea un mensaje de tipo dispositivo que contiene información del objeto dispositivo.
        /// </summary>
        /// <returns></returns>
        public static IOcsMensajeLecturaDispositivos CrearMensajeDispositivos()
        {
            return new OcsMensajeLecturaDispositivos();
        }
        /// <summary>
        /// Crea un mensaje de tipo dispositivo que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="dispositivos">Colección de dispositivos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaDispositivos CrearMensajeDispositivos(int[] dispositivos, string idMensajeRespuesta)
        {
            return new OcsMensajeLecturaDispositivos(dispositivos, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo dispositivo que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeLecturaDispositivos ObtenerMensajeDispositivos(IMensaje mensaje)
        {
            return (OcsMensajeLecturaDispositivos)mensaje;
        }
        #endregion Dispositivos

        #region Escrituras
        /// <summary>
        /// Crea un mensaje de tipo escritura que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="variables">Colección de variables.</param>
        /// <param name="valores">Colección de valores.</param>
        /// <param name="canal"></param>
        /// <returns></returns>
        public static IOcsMensajeEscritura CrearMensajeEscritura(int dispositivo, string[] variables, object[] valores, string canal)
        {
            return new OcsMensajeEscritura(dispositivo, variables, valores, canal);
        }
        /// <summary>
        /// Crea un mensaje de tipo escritura que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeEscritura CrearMensajeEscritura(string idMensajeRespuesta)
        {
            return new OcsMensajeEscritura(idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo escritura que contiene información del objeto dispositivo.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeEscritura ObtenerMensajeEscritura(IMensaje mensaje)
        {
            return (OcsMensajeEscritura)mensaje;
        }
        #endregion Escrituras


        #region Errores lectura/escritura
        /// <summary>
        /// Crea un mensaje de tipo error que contiene información del objeto error.
        /// </summary>
        /// <param name="error">Representa los errores que se producen durante la ejecución de una aplicación.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeErrorBase CrearMensajeError(string error, string idMensajeRespuesta)
        {
            return new OcsMensajeError(error, idMensajeRespuesta);
        }
        /// <summary>
        /// Crea un mensaje de tipo error que contiene información del objeto error.
        /// </summary>
        /// <param name="error">Representa los errores que se producen durante la ejecución de una aplicación.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        /// <returns></returns>
        public static IOcsMensajeErrorBase CrearMensajeError(Exception error, string idMensajeRespuesta)
        {
            return new OcsMensajeError(error, idMensajeRespuesta);
        }
        /// <summary>
        /// Obtiene un mensaje de tipo error que contiene información del objeto error.
        /// </summary>
        /// <param name="mensaje">Representa un mensaje que se envía y recibe por el servidor y el cliente.</param>
        /// <returns></returns>
        public static IOcsMensajeErrorBase ObtenerMensajeError(IMensaje mensaje)
        {
            return (OcsMensajeError)mensaje;
        }
        #endregion Errores lectura/escritura

        #endregion Métodos públicos
    }
}