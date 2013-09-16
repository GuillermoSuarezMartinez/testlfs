//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
// Descripción        : ...
//
//***********************************************************************

using System;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Almacena información del cliente que será utilizada por el evento de suscripción.
    /// </summary>
    public class ServidorClienteEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Inicializar una nueva instancia de la clase ServidorClienteEventArgs.
        /// </summary>
        /// <param name="cliente">Cliente que está suscrito a este evento.</param>
        public ServidorClienteEventArgs(IServidorCliente cliente)
        {
            Cliente = cliente;
        }
        #endregion Constructor

        #region Propiedades públicas
        /// <summary>
        /// Cliente que está suscrito a este evento.
        /// </summary>
        public IServidorCliente Cliente { get; private set; }
        #endregion Propiedades públicas
    }
}