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

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Este mensaje se utiliza para enviar/recibir un array de int como mensaje de datos.
    /// </summary>
    [Serializable]
    public class OcsMensajeLecturaDispositivos : OcsMensajeLecturaDispositivosBase
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDispositivos.
        /// </summary>
        public OcsMensajeLecturaDispositivos() { }
        /// <summary>
        /// Inicializar una nueva instancia de la clase OcsMensajeLecturaDispositivos.
        /// </summary>
        /// <param name="dispositivos">Colección de dispositivos.</param>
        /// <param name="idMensajeRespuesta">Identificador del mensaje de respuesta.</param>
        public OcsMensajeLecturaDispositivos(int[] dispositivos, string idMensajeRespuesta)
            : base(dispositivos, idMensajeRespuesta) { }
        #endregion
    }
}