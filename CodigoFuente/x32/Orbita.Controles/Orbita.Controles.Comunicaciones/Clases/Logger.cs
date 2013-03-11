using System;
using Orbita.Trazabilidad;

namespace oVisorTCP
{
    /// <summary>
    /// Clase para la recepción de logs por remoting.
    /// </summary>
    public class Logger : MarshalByRefObject, IRemotingLogger
    {
        #region Método(s) Público(s)
        /// <summary>
        /// Entrada de logs.
        /// </summary>
        /// <param name="mensajes">Listado de mensajes.</param>
        public void Log(ItemLog[] mensajes)
        {
            oVisorTCP visor = oVisorTCP.Visor;
            if (visor != null)
            {
                if (mensajes != null)
                {
                    foreach (ItemLog mensaje in mensajes)
                    {
                        oVisorTCP.Visor.AddLinea(mensaje);
                    }
                }
            }
        }
        #endregion
    }
}
