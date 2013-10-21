//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Representa el mensaje que se enviará y recibirá entre cliente y servidor.
    /// Esta es la clase base para todos los mensajes de este tipo.
    /// </summary>
    [Serializable]
    public abstract class OcsMensajeLecturaDatosBase : Mensaje, IOcsMensajeLecturaDatos
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDatosBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        protected OcsMensajeLecturaDatosBase(int dispositivo)
        {
            Dispositivo = dispositivo;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDatosBase.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="datos">Colección de datos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        protected OcsMensajeLecturaDatosBase(int dispositivo, OHashtable datos, string idMensajeRespuesta)
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
        /// Colección de datos.
        /// </summary>
        public OHashtable Datos { get; private set; }
        #endregion Propiedades públicas
    }
}