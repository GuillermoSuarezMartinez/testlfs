namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Mensaje para las comunicaciones TCP
    /// </summary>
    public class OMensajeCanalTCP
    {
        #region Atributos
        /// <summary>
        /// nombre del listener
        /// </summary>
        string _listener;
        /// <summary>
        /// nombre del canal
        /// </summary>
        string _canal;
        /// <summary>
        /// mensaje
        /// </summary>
        string _mensaje;
        /// <summary>
        /// datos del mensaje
        /// </summary>
        object _data;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="canal"></param>
        /// <param name="mensaje"></param>
        public OMensajeCanalTCP(string listener, string canal, string mensaje)
        {
            this._listener = listener;
            this._canal = canal;
            this._mensaje = mensaje;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// nombre del listener
        /// </summary>
        public string Listener
        {
            get { return _listener; }
            set { _listener = value; }
        }
        /// <summary>
        /// nombre del canal
        /// </summary>
        public string Canal
        {
            get { return _canal; }
            set { _canal = value; }
        }
        /// <summary>
        /// mensaje
        /// </summary>
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
        /// <summary>
        /// datos del mensaje
        /// </summary>
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }
        #endregion
    }
}