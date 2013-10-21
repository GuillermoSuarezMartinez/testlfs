//***********************************************************************
//
// Ensamblado         : Orbita.Comunicaciones
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
//***********************************************************************

using Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor;

namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Representa un servidor que se utiliza para aceptar y gestionar las conexiones de clientes.
    /// </summary>
    public interface IOcsServidor : IOcsMensajeroServidor
    {
        /// <summary>
        /// Iniciar los mensajeros.
        /// </summary>
        void Iniciar();
        /// <summary>
        /// Terminar los mensajeros.
        /// </summary>
        void Terminar();
        /// <summary>
        /// Añadir un listener a la colección.
        /// </summary>
        /// <param name="listener">Listener que se utiliza para aceptar y gestionar las conexiones de clientes.</param>
        void Añadir(IServidor listener);
    }
}