namespace Orbita.Comunicaciones
{
    /// <summary>
    /// Clase que encapsula información de un puerto de comunicaciones
    /// </summary>
    public class OInformacionPuerto
    {
        #region Atributos
        /// <summary>
        /// Identificador númerico del puerto de comunicaciones
        /// </summary>
        int idPuerto;
        /// <summary>
        /// Tipo del puerto de comunicaciones
        /// </summary>
        string tipoPuerto;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="idPuerto">Identificador númerico del puerto de comunicaciones</param>
        /// <param name="tipoPuerto">Tipo del puerto de comunicaciones</param>
        public OInformacionPuerto(int idPuerto, string tipoPuerto)
        {
            this.idPuerto = idPuerto;
            this.tipoPuerto = tipoPuerto;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Identificador númerico del puerto de comunicaciones
        /// </summary>
        public int IdPuerto
        {
            get { return this.idPuerto; }
        }
        /// <summary>
        /// Identificador textual del puerto de comunicaciones
        /// </summary>
        public string TipoPuerto
        {
            get { return this.tipoPuerto; }
        }
        #endregion
    }
}