//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System.Net;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Canales;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Cliente
{
    /// <summary>
    /// Esta clase se utiliza para comunicarse con el servidor a través del protocolo Tcp / IP.
    /// </summary>
    internal class TcpCliente : ClienteBase
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase TcpCliente.
        /// </summary>
        /// <param name="endPointRemoto">La dirección endpoint del servidor.</param>
        public TcpCliente(TcpEndPoint endPointRemoto)
        {
            EndPointRemoto = endPointRemoto;
        }
        #endregion Constructor

        #region Métodos protegidos
        /// <summary>
        /// Crear un canal de comunicación utilizando dirección Ip y puerto del servidor.
        /// </summary>
        /// <returns>Canal de comunicación preparado para comunicar.</returns>
        protected override ICanalComunicacion CrearCanalComunicacion()
        {
            if (EndPointLocal == null)
            {
                return new TcpCanalComunicacion(
                    TcpHelper.ConectarAlServidor(
                        new IPEndPoint(IPAddress.Parse(EndPointRemoto.DireccionIp), EndPointRemoto.PuertoTcp),
                        TimeoutConexionMs
                        ));
            }
            return new TcpCanalComunicacion(
                    TcpHelper.ConectarAlServidor(
                        new IPEndPoint(IPAddress.Parse(EndPointRemoto.DireccionIp), EndPointRemoto.PuertoTcp),
                        new IPEndPoint(IPAddress.Parse(EndPointLocal.DireccionIp), EndPointLocal.PuertoTcp),
                        TimeoutConexionMs
                        ));
        }
        #endregion Métodos protegidos
    }
}