//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints
{
    /// <summary>
    /// Representa un endpoint TCP.
    /// </summary>
    public sealed class TcpEndPoint : EndPoint
    {
        #region Constructores
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpEndPoint.
        /// </summary>
        /// <param name="puertoTcp">Puerto de escucha Tcp para solicitudes de conexión entrantes en el servidor.</param>
        public TcpEndPoint(int puertoTcp)
        {
            PuertoTcp = puertoTcp;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpEndPoint.
        /// </summary>
        /// <param name="direccionIp">Dirección IP del servidor.</param>
        /// <param name="puertoTcp">Puerto de escucha Tcp para solicitudes de conexión entrantes en el servidor.</param>
        public TcpEndPoint(string direccionIp, int puertoTcp)
        {
            DireccionIp = direccionIp;
            PuertoTcp = puertoTcp;
        }
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpEndPoint.
        /// Formato de dirección debe ser como Dirección IP: puerto (por ejemplo: 127.0.0.1:8001).
        /// </summary>
        /// <param name="direccionIp">Dirección endpoint TCP.</param>
        /// <returns>TcpEndpoint.</returns>
        public TcpEndPoint(string direccionIp)
        {
            var splittedAddress = direccionIp.Trim().Split(':');
            DireccionIp = splittedAddress[0].Trim();
            PuertoTcp = Convert.ToInt32(splittedAddress[1].Trim());
        }
        #endregion

        #region Propiedades públicas
        ///<summary>
        /// Dirección IP del servidor.
        ///</summary>
        public string DireccionIp { get; set; }
        ///<summary>
        /// Puerto de escucha TCP para solicitudes de conexión entrantes en el servidor.
        ///</summary>
        public int PuertoTcp { get; private set; }
        #endregion

        #region Propiedades internas
        /// <summary>
        /// Crear un servidor que utiliza este endpoint para escuchar las conexiones entrantes.
        /// </summary>
        /// <returns>TcpServidor.</returns>
        internal override IServidor CrearServidor()
        {
            return new TcpServidor(this);
        }
        /// <summary>
        /// Crear un cliente que utiliza este endpoint para conectarse al servidor.
        /// </summary>
        /// <returns>TcpCliente.</returns>
        internal override ICliente CrearCliente()
        {
            return new TcpCliente(this);
        }
        #endregion

        #region Propiedades públicas
        /// <summary>
        /// Invalida el método ToString() para devolver una cadena que representa la instancia de objeto.
        /// </summary>
        /// <returns>Una cadena (string) que representa este objeto.</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(DireccionIp) ? ("tcp://" + PuertoTcp) : (DireccionIp + ":" + PuertoTcp);
        }
        #endregion
    }
}