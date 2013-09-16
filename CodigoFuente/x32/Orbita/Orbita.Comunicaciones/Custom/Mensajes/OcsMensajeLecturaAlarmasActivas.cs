//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;
using System.Collections;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Este mensaje se utiliza para enviar/recibir un array de bytes como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeLecturaAlarmasActivas : OcsMensajeLecturaAlarmasActivasBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaAlarmasActivas.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public OcsMensajeLecturaAlarmasActivas(int dispositivo)
            : base(dispositivo) { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaAlarmasActivas.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="datos">Colección de datos de alarmas activas.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeLecturaAlarmasActivas(int dispositivo, ArrayList datos, string idMensajeRespuesta)
            : base(dispositivo, datos, idMensajeRespuesta) { }
        #endregion Constructores
    }
}