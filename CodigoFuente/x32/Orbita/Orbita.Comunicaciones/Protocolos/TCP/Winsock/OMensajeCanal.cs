namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Mensaje para las comunicaciones Tcp.
    /// </summary>
    public class OMensajeCanalTCP
    {
        #region Constructor
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="canal"></param>
        /// <param name="mensaje"></param>
        public OMensajeCanalTCP(string listener, string canal, string mensaje)
        {
            this.Listener = listener;
            this.Canal = canal;
            this.Mensaje = mensaje;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// nombre del listener
        /// </summary>
        public string Listener { get; set; }
        /// <summary>
        /// nombre del canal
        /// </summary>
        public string Canal { get; set; }
        /// <summary>
        /// mensaje
        /// </summary>
        public string Mensaje { get; set; }
        /// <summary>
        /// datos del mensaje
        /// </summary>
        public object Data { get; set; }
        #endregion
    }
}