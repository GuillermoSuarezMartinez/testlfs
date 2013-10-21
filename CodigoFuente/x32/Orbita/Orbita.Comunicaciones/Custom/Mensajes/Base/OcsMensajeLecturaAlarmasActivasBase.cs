//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.Collections;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Representa el mensaje que se enviará y recibirá entre cliente y servidor.
    /// Esta es la clase base para todos los mensajes de este tipo.
    /// </summary>
    [Serializable]
    public abstract class OcsMensajeLecturaAlarmasActivasBase : Mensaje, IOcsMensajeLecturaAlarmasActivas
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaAlarmasActivasBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        protected OcsMensajeLecturaAlarmasActivasBase(int dispositivo)
        {
            Dispositivo = dispositivo;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaAlarmasActivasBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="datos">Colección de datos que contienen las alarmas activas.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeLecturaAlarmasActivasBase(int dispositivo, ArrayList datos, string idMensajeRespuesta)
            : this(dispositivo)
        {
            Datos = datos;
            IdMensajeRespuesta = idMensajeRespuesta;
        }
        #endregion Constructores

        #region Propiedades públicas
        /// <summary>
        /// Dispositivo de conexión.
        /// </summary>
        public int Dispositivo { get; private set; }
        /// <summary>
        /// Colección de datos que contienen las alarmas activas.
        /// </summary>
        public ArrayList Datos { get; private set; }
        #endregion Propiedades públicas
    }
}