//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;
using Orbita.Utiles;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Este mensaje se utiliza para enviar/recibir una colección (OHashtable) de datos como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeLecturaDatos : OcsMensajeLecturaDatosBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDatos.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        public OcsMensajeLecturaDatos(int dispositivo)
            : base(dispositivo) { }

        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDatos.
        /// </summary>
        /// <param name="dispositivo">Dispositivo de conexión.</param>
        /// <param name="datos">Colección de datos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeLecturaDatos(int dispositivo, OHashtable datos, string idMensajeRespuesta)
            : base(dispositivo, datos, idMensajeRespuesta) { }
        #endregion
    }
}