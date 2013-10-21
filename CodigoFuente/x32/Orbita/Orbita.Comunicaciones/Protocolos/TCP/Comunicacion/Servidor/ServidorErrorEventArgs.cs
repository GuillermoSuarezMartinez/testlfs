//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using System;
using System.IO;
using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.EndPoints;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Almacena información del error que será utilizada por el evento de suscripción.
    /// </summary>
    public class ServidorErrorEventArgs : ErrorEventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ServidorErrorEventArgs.
        /// </summary>
        /// <param name="endPoint">Dirección endpoint del servidor para escuchar las conexiones entrantes.</param>
        /// <param name="ex">Representa los errores que se producen durante la ejecución de una aplicación.</param>
        public ServidorErrorEventArgs(TcpEndPoint endPoint, Exception ex)
            : base(ex)
        {
            EndPoint = endPoint;
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Dirección endpoint del servidor para escuchar las conexiones entrantes.
        /// </summary>
        public TcpEndPoint EndPoint { get; private set; }
        /// <summary>
        /// Representa los errores que se producen durante la ejecución de una aplicación.
        /// </summary>
        public Exception Excepcion 
        {
            get { return base.GetException(); }
        }
        #endregion Propiedades públicas
    }
}