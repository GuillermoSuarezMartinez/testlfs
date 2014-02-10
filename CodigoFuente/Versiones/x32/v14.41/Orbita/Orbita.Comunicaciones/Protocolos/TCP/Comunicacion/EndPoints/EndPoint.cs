//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints
{
    ///<summary>
    /// Representa un endpoint del lado del servidor.
    ///</summary>
    public abstract class EndPoint
    {
        #region Métodos públicos
        /// <summary>
        /// Crear endPoint de un string.
        /// La dirección debe tener el formato: protocolo://dirección
        /// Ejemplo: tcp://10.37.2.30:8000 uno de los extremos Tcp con
        /// dirección IP 10.37.2.30 y puerto 8000.
        /// </summary>
        /// <param name="direccionEndPoint">Dirección endpoint.</param>
        /// <returns>Endpoint.</returns>
        public static EndPoint CrearEndPoint(string direccionEndPoint)
        {
            if (string.IsNullOrEmpty(direccionEndPoint))
            {
                throw new ArgumentNullException("direccionEndPoint");
            }
            //  Si no se especifica protocolo, asume Tcp.
            var direccionEndPointAuxiliar = direccionEndPoint;
            if (!direccionEndPointAuxiliar.Contains("://"))
            {
                direccionEndPointAuxiliar = "tcp://" + direccionEndPointAuxiliar;
            }
            //  Dividir en partes, protocolo y dirección.
            var endPoint = direccionEndPointAuxiliar.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
            if (endPoint.Length != 2)
            {
                throw new ApplicationException(direccionEndPoint + " no es una dirección de endpoint válida.");
            }
            //  Dividir endpoint, encontrar el protocolo y la dirección.
            var protocolo = endPoint[0].Trim().ToLower();
            var direccion = endPoint[1].Trim();
            switch (protocolo)
            {
                case "tcp":
                    return new TcpEndPoint(direccion);
                default:
                    throw new ApplicationException("Protocolo " + protocolo + "no compatible en el endpoint " + direccionEndPoint);
            }
        }
        #endregion Métodos públicos

        #region Métodos internos abstractos
        /// <summary>
        /// Crear un servidor que utiliza este endpoint para escuchar las conexiones entrantes.
        /// </summary>
        /// <returns>Servidor.</returns>
        internal abstract IServidor CrearServidor();
        /// <summary>
        /// Crear un cliente que utiliza este endpoint para conectar al servidor.
        /// </summary>
        /// <returns>Cliente.</returns>
        internal abstract ICliente CrearCliente();
        #endregion Métodos internos abstractos
    }
}