namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Mensaje para las comunicaciones Tcp.
    /// </summary>
    public class OMensajeCanalTCP
    {
        #region Constructor
        /// <summary>
        /// Constructor de clase.
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="canal"></param>
        /// <param name="mensaje"></param>
        public OMensajeCanalTCP(string listener, string canal, string mensaje)
        {
            Listener = listener;
            Canal = canal;
            Mensaje = mensaje;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre del listener.
        /// </summary>
        public string Listener { get; set; }
        /// <summary>
        /// Nombre del canal.
        /// </summary>
        public string Canal { get; set; }
        /// <summary>
        /// Mensaje.
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// Datos del mensaje.
        /// </summary>
        public object Data { get; set; }
        #endregion Propiedades
    }
}