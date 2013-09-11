//***********************************************************************
// Ensamblado         : Orbita.Comunicaciones.Protocolos.Tcp
// Autor              : crodriguez
// Fecha creación     : 01-09-2013
//
// Modificado         : crodriguez
// Fecha modificación : 01-09-2013
// Descripción        :
//***********************************************************************

using System.Threading;

namespace Orbita.Comunicaciones.Protocolos.Tcp.Comunicacion.Servidor
{
    /// <summary>
    /// Proporciona algunas funciones que son utilizadas por los servidores.
    /// </summary>
    internal static class ServidorManager
    {
        #region Atributos privados
        /// <summary>
        /// Se utiliza para establecer un identificador auto incremential único a los clientes.
        /// </summary>
        private static long _ultimoIdentificador;
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtener un número único como identificador de cliente.
        /// </summary>
        /// <returns>Identificador del cliente.</returns>
        public static long GetIdentificadorAutoincremental()
        {
            return Interlocked.Increment(ref _ultimoIdentificador);
        }
        #endregion
    }
}