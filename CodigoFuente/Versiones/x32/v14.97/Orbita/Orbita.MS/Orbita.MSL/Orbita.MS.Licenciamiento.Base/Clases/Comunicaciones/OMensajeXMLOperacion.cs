using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS.Comunicaciones
{
    /// <summary>
    /// Operaciones de mensaje.
    /// </summary>
    public enum OMensajeXMLOperacion
    {
        Indefinido = 0,
        RegistrarInicio,
        RegistrarSalida,
        MensajeServidorCliente,
        MensajeClienteServidor,
        DesconexionForzada,
        ConsultaLicencia,
        RecargarLicencias,
        CanalInicio = 800,
        CanalSalida = 801,
        Error = 903
        //ACK = 900,
        //NACK = 901,
        //Error = 903
    }

    /// <summary>
    /// Tipo de mensaje
    /// </summary>
    public enum OMensajeXMLTipoMensaje
    {
        Indefinido = 0,
        /// <summary>
        /// Solicitud, mensaje que precisa respuesta
        /// </summary>
        Solicitud = 100,
        /// <summary>
        /// Notificación, mensaje que no precisa respuesta ni acuse.
        /// </summary>
        Notificacion = 200,
        /// <summary>
        /// Respuesta afirmativa
        /// </summary>
        ACK = 900,
        /// <summary>
        /// Respuesta de rechazo
        /// </summary>
        NACK = 901,
        /// <summary>
        /// Error
        /// </summary>
        Error = 903
    }
}
