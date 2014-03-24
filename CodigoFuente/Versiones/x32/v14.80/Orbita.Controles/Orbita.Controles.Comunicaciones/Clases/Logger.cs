using System;
using Orbita.Trazabilidad;
namespace Orbita.Controles.Comunicaciones
{
    /// <summary>
    /// Clase para la recepción de logs por remoting.
    /// </summary>
    public class Logger : MarshalByRefObject, IRemotingLogger
    {
        #region Métodos públicos
        /// <summary>
        /// Entrada de logs.
        /// </summary>
        /// <param name="mensajes">Listado de mensajes.</param>
        public void Log(ItemLog[] mensajes)
        {
            OrbitaVisorTCP visor = OrbitaVisorTCP.Visor;
            if (visor != null)
            {
                if (mensajes != null)
                {
                    foreach (ItemLog mensaje in mensajes)
                    {
                        OrbitaVisorTCP.Visor.AddLinea(mensaje);
                    }
                }
            }
        }
        #endregion
    }
}