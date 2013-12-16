using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orbita.MS
{
    //Estado comunicación
    public enum OEstadoComunicacionCliente
    {
        Indefinido = 0,
        /// <summary>
        /// Cliente desconectado
        /// </summary>
        Desconectado = 1,
        /// <summary>
        /// Conexión de control
        /// </summary>
        Protocolo = 2,
        /// <summary>
        /// Conexión de control rechazada
        /// </summary>
        ProtocoloRechazada = 3,
        /// <summary>
        ProtocoloCongestion = 4,
        /// Pendiente de establecer comunicación
        /// </summary>
        ConexionPendiente = 8,
        /// <summary>
        /// Pendiente de establecer comunicación, en la comunicación previa fue rechazado el cliente.
        /// </summary>
        ConexionPendienteRechazada = 9,

        ConexionAsignadaSinInicializar = 19,
        /// <summary>
        /// Conexión activa
        /// </summary>
        ConexionAsignada = 20,
        /// <summary>
        /// Conexión en espera o retirada
        /// </summary>
        ConexionRetirada = 21,
        /// <summary>
        /// Conexión dinámica rechazada.
        /// </summary>
        ConexionRechazada = 22
    }
}
